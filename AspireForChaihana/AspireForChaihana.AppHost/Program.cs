using Microsoft.AspNetCore.Builder;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var ChaihanaForCustomers = builder.AddProject<Projects.WebApplication1>("ChaihanaForCustomers");

var ChaihanaForEmployee = builder.AddProject<Projects.ChaihanaForEmplyee>("ChaihanaForEmployee");

builder.Build().Run();
