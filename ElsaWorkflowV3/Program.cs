using Elsa.EntityFrameworkCore.Extensions;
using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.Extensions;
using Elsa.Identity.Features;
using ElsaWorkflowV3.Activities;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddElsa(elsa =>
{
    // Configure management feature to use EF Core.
    elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef => ef.UseSqlite()));

    // Expose API endpoints.
    elsa.UseWorkflowsApi();

    // Add services for HTTP activities and workflow middleware.
    elsa.UseHttp();

    // Configure identity so that we can create a default admin user.
    elsa.UseIdentity(identity =>
    {
        identity.UseAdminUserProvider();
        identity.TokenOptions = options => options.SigningKey = "secret-token-signing-key";
    });

    // Use default authentication (JWT + API Key).
    elsa.UseDefaultAuthentication(auth => auth.UseAdminApiKey());
    //elsa.UseDefaultAuthentication();

    elsa.AddActivity<Greeter>();
    elsa.AddActivity<CreateFolder>();
});

// Add Razor pages.
builder.Services.AddRazorPages();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseWorkflowsApi();
app.UseWorkflows();
app.MapRazorPages();
app.Run();
