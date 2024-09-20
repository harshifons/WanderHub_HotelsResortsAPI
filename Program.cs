using Serilog;

var builder = WebApplication.CreateBuilder(args);   // logger registered inside the create builder.  Can use the logger inside the API Controller, using dependancy injection.

// Add services to the container.

// Configuring logger using the Sirilog Logger
Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.File("log/resortlogs.txt", rollingInterval:RollingInterval.Month).CreateLogger();
            // all messages above the debug level will be logged, in the specified place
            // rolling interval >> when a new file should be created

builder.Host.UseSerilog();      // Notifying the application to use Sirilog instead of builder



//builder.Services.AddControllers().AddNewtonsoftJson();
//OR
//builder.Services.AddControllers(option => {
//    option.ReturnHttpNotAcceptable = true;
//}).AddNewtonsoftJson();
// OR
builder.Services.AddControllers(option => {
    option.ReturnHttpNotAcceptable = true;          // If a document format (e.g. html, xml, json) is not acceptable, it will return error.
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();    //Adding built-in support for xml in the API. Not the Resort data will be displayed in xml format, instead of json format.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

