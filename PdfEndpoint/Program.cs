global using FastEndpoints;
global using FastEndpoints.Validation;
using FastEndpoints.Swagger;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();


var app = builder.Build();
app.UseFastEndpoints();
app.UseHsts();
app.UseHttpsRedirection();
app.UseOpenApi(); //add this
app.UseSwaggerUi3(c => c.ConfigureDefaults());
app.Run();