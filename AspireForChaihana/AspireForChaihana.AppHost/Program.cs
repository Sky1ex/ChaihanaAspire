using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var employeeDb = builder.AddPostgres("postgres-employee")
	.WithPgWeb()
	.AddDatabase("WebDbForEmployee");

var customerDb = builder.AddPostgres("postgres-customer")
	.WithPgWeb()
	.AddDatabase("WebDbForCustomers");

var cafeDb = builder.AddPostgres("postgres-cafe")
	.WithPgWeb()
	.AddDatabase("WebDbForCafe");

var ChaihanaForCustomers = builder.AddProject<Projects.WebApplication1>("ChaihanaForCustomers")
	.WithReference(employeeDb)
	.WithReference(cafeDb);

var ChaihanaForEmployee = builder.AddProject<Projects.ChaihanaForEmplyee>("ChaihanaForEmployee")
	.WithReference(customerDb)
	.WithReference(cafeDb);

builder.Build().Run();
