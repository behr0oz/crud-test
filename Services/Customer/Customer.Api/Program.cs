using Customer.Application;
using Customer.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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

app.Run();
