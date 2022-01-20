using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceRegistration();
builder.Services.AddInfrastructureRegistration();
builder.Services.AddApplicationRegistration();
builder.Services.AddControllers(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>())
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false); //ValidationBehaviour handle fluent validations.

#region Api Versioning
builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});
#endregion

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

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
