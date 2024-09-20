using System;
using WanderHub_ResortAPI.Data;
using WanderHub_ResortAPI.Models; // Importing Resort Model
using WanderHub_ResortAPI.Models.DTO;     //Using DTO instead of model
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WanderHub_ResortAPI.Controllers
{
    [Route("api/ResortAPI")]        // Defining route to the Controller, so the Swagger UI can access this API controller
    // [Route("api/[controller]")]     - same, but if the class name changes, route (url) also gets changed.

    [ApiController]     // Attribute indicating this is API Controller class.
                        // Including this also ensures, Model's data annotation rules (specified in the DTO) are followed.               
    public class ResortAPIController : ControllerBase   // If we use Controller class, it supports View as well. But since this is only API, no need the View.
    {
        private readonly ApplicationDBContext _dbContext;
        //private readonly ILogger<ResortAPIController> _logger;

        // Extracting DB Context from build container using dependancy injection. 
        public ResortAPIController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Implementation of Logger using dependancy injection
        //public ResortAPIController(ILogger<ResortAPIController> logger)     // using the built-in implementation of the logger.
        //{
        //// install Serilog.AspNetCore,Serilog.Sinks.File, Serilog.Sinks.Console NuGet patches to log messages into a file.
        //    _logger = logger;

        //}

    // Creating a GET endpoint, which returns a list of resorts (but using Resort DTO/wrapper instead of Resort Model)
    [HttpGet(Name = "GetResortsList")]   //When we create an endpoint to API Controller, need to define the HTTP action. Because we are retrieing data here, it's HTTP GET

        [ProducesResponseType(StatusCodes.Status200OK)]             // If these are not specified, the response code returns as undocumented.

        public ActionResult<IEnumerable<ResortDTO>> GetResorts()          // Returning Action Result code also.
        {
            //_logger.LogInformation("Getting all resorts.");
            return Ok(_dbContext.Resort);      // Returning the list and status code 200 (for Ok)
        }



        // Another GET end point to retrieve only 1 record based on ID
        [HttpGet("{Id:int}", Name = "GetResort")]     // specify the difference between the two GET actions (e.g. this expects ID as parameter). Same HTTPGet gives error >> request with multiple endpoints.
                                                      // given a name, so the endpoint can be specifically called as a function.
                                                      // Document Status Codes (for response)
        [ProducesResponseType(StatusCodes.Status200OK)]         // same as [ProducesResponseType(200)]  // including return type also here [ProducesResponseType(200, Type = typeof(ResortDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ResortDTO> GetResort(int Id)     // so, the return type is not a list, it's one Resort
        {
            if (Id == 0)
            {
                //_logger.LogError("Error in retrieving ID " + Id + ". Resort does not exist!");
                return BadRequest();       // status 400
            }

            var resort = _dbContext.Resort.FirstOrDefault(u => u.ResortId == Id);
            if (resort == null)
            {
                return NotFound();         // status 404
            }

            return Ok(resort);
        }



        // POST end point to create new resort record
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]        // Inclusing this because, of returning created at route.

        public ActionResult<ResortDTO> CreateResort([FromBody]ResortDTO resortDTO)       // Object receive from http request body   // Return the created resort
        {
            //if (!ModelState.IsValid)              // Checking the data annotations rules defined in Model (or DTO). Because we specified this is [ApiController] class, this Custom Validation is not required.
            //{
            //    return BadRequest(ModelState);
            //}

            // Validating for unique villa name
            if (_dbContext.Resort.FirstOrDefault(u => u.ResortName.ToLower() == resortDTO.ResortName.ToLower()) != null)   // If the condition is not met, FirstOrDefault() returns null for reference types, 0 for numeric types   
            {
                // Adding Custom Validation to the Model State
                ModelState.AddModelError("ResortNameError", "Resort name already exists!");    //(uniquekeyname,validation message)     // uniquekeyname can be kept empty >> ""

                return BadRequest(ModelState);
            }

            if (resortDTO == null)
            {
                return BadRequest();
            }
            if (resortDTO.ResortId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Resort model = new()
            {
                ResortId = resortDTO.ResortId,
                ResortName = resortDTO.ResortName,
                ImageUrl = resortDTO.ImageUrl,
                Amenity = resortDTO.Amenity,
                Details = resortDTO.Details,
                Occupancy = resortDTO.Occupancy,
                Rate = resortDTO.Rate,
                Sqft = resortDTO.Sqft,
            };
            _dbContext.Resort.Add(model);       // track the changes
            _dbContext.SaveChanges();           // push the changes to the database

            //return Ok(resortDTO);                                                           // Instead of returning the created resort,
            return CreatedAtRoute("GetResort", new { Id = resortDTO.ResortId }, resortDTO);    // we are giving the url/path to the created resort, so the user can access it later also.
                                                                                               // CreatedAtRoute returns 201 as Response Code.
        }


        // DELETE end point
        [HttpDelete("{Id:int}", Name = "DeleteResort")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteResort(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }

            var resort = _dbContext.Resort.FirstOrDefault(u => u.ResortId == Id);
            if (resort == null)
            {
                return NotFound();
            }

            _dbContext.Resort.Remove(resort);
            _dbContext.SaveChanges();   //saving the changes

            return NoContent();     // using return Ok() is fine. But standard way is returning nothing, after deleting a record.
        }


        // PUT end point to update the Complete record
        [HttpPut("{Id:int}", Name = "UpdateResort")]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ResortDTO> UpdateResort(int Id, [FromBody]ResortDTO resortDTO)          // can use IActionResult, if returning NoContent()
        {
            if (Id != resortDTO.ResortId || resortDTO == null)
            {
                return BadRequest();
            }

            Resort model = new()
            {
                ResortId = resortDTO.ResortId,
                ResortName = resortDTO.ResortName,
                ImageUrl = resortDTO.ImageUrl,
                Amenity = resortDTO.Amenity,
                Details = resortDTO.Details,
                Occupancy = resortDTO.Occupancy,
                Rate = resortDTO.Rate,
                Sqft = resortDTO.Sqft,
            };
            _dbContext.Resort.Update(model);
            _dbContext.SaveChanges();

            return Ok(model);
        }



        // PATCH endpoint to update only some fields of the record

        // JSON Patch is a format for describing changes to a Json document.
        // When it's used with HTTPPatch method, it allows partial updates for LTTP APIs. (Ref: jsonpatch.com)
        // To add patch support, install these 2 Nuget packages: (first close all opened files. Right click on Project >> Manage Nuget Packages)
        // 1. Microsoft.AspNetCore.JsonPatch (install the same version as .net version)
        // 2. Microsoft.ApsNetCore.Mvc.NewtonsoftJson (install the same version as .net version) (include in Program.cs)

        [HttpPatch("{Id:int}", Name = "UpdatePartialResort")]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<ResortDTO> UpdatePartialResort(int Id, JsonPatchDocument<ResortDTO> patchDTO)       // patch document doesn't have the complete object, only the fields need to be updated.
        {
            //patchDTO >>
            // path : "/ResortName"         op: "replace"      value: "Sunset View"
            if (Id == 0 || patchDTO == null)
            {
                return BadRequest();
            }

            var resort = _dbContext.Resort.AsNoTracking().FirstOrDefault(u => u.ResortId == Id);

            ResortDTO resortDTO = new()
            {
                ResortId = resort.ResortId,
                ResortName = resort.ResortName,
                ImageUrl = resort.ImageUrl,
                Amenity = resort.Amenity,
                Details = resort.Details,
                Occupancy = resort.Occupancy,
                Rate = resort.Rate,
                Sqft = resort.Sqft,
            };



            if (resort == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(resortDTO, ModelState);   // Apply any updates in patchDTO To resort. If any errors, store in ModelState

            Resort model = new()
            {
                ResortId = resortDTO.ResortId,
                ResortName = resortDTO.ResortName,
                ImageUrl = resortDTO.ImageUrl,
                Amenity = resortDTO.Amenity,
                Details = resortDTO.Details,
                Occupancy = resortDTO.Occupancy,
                Rate = resortDTO.Rate,
                Sqft = resortDTO.Sqft,
            };
            _dbContext.Resort.Update(model);    // updating the complete record
            _dbContext.SaveChanges();




            if (!ModelState.IsValid)        // Checking for DTO validations
            {
                return BadRequest(ModelState);
            }

            return Ok(model);
        }

    }
}

