using Customer.Application;
using Customer.Application.Exceptions;
using Customer.Application.Features.Customers.Commands.AddCustomer;
using Customer.Application.Features.Customers.Commands.DeleteCustomer;
using Customer.Application.Features.Customers.Commands.UpdateCustomer;
using Customer.Infrastructure;
using Customer.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

Customer.Api.Extensions.HostExtensions.MigrateDatabase<CustomerContext>(app.Services, (context, services) => { }, 50);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

//app.UseHttpsRedirection();

app.MapGet("/customer", async ([FromServices] IMediator _mediator) =>
{
    var query = new Customer.Application.Features.Customers.Queries.GetAllCustomers.GetAllCustomersQuery();
    return await _mediator.Send(query);
});

app.MapGet("/customer/{id}", async (int id, [FromServices] IMediator _mediator) =>
{
    var query = new Customer.Application.Features.Customers.Queries.GetCustomerById.GetCustomerByIdQuery(id);
    return await _mediator.Send(query);
});

app.MapPost("/customer", async (AddCustomerCommand customer, [FromServices] IMediator _mediator) =>
{
    try
    {
        var result = await _mediator.Send(customer);
        return Results.Ok(result);
    }
    catch (ValidationException ex)
    {
        return Results.BadRequest(ex.Errors);
    }
});

app.MapPut("/customer", async (UpdateCustomerCommand customer, [FromServices] IMediator _mediator) =>
{
    try
    {
        var result = await _mediator.Send(customer);
        return Results.Ok(result);
    }
    catch (ValidationException ex)
    {
        return Results.BadRequest(ex.Errors);
    }

});

app.MapDelete("/customer/{id}", async (int id, [FromServices] IMediator _mediator) =>
{
    await _mediator.Send(new DeleteCustomerCommand() { Id = id });
    return Results.Ok();
});

app.Run();
