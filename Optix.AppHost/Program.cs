var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Optix_Presentation_WebBlazor>("optix-presentation-webblazor");

builder.AddProject<Projects.Optix_Service_ServiceAPI>("optix-service-serviceapi");

builder.Build().Run();
