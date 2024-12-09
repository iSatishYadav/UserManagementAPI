public void ConfigureServices(IServiceCollection services)
{
    // ...existing code...
    services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "https://your-auth-server";
            options.RequireHttpsMetadata = false;
            options.Audience = "UserManagementAPI";
        });
    // ...existing code...
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // ...existing code...

    // Error-handling middleware
    app.UseMiddleware<ErrorHandlingMiddleware>();

    // Authentication middleware
    app.UseAuthentication();

    // Logging middleware
    app.UseMiddleware<RequestResponseLoggingMiddleware>();

    // ...existing code...
}