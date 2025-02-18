using Leodanny_maria_mercedes_P1_AP1.Components;
using Leodanny_maria_mercedes_P1_AP1.DAL;
using Leodanny_maria_mercedes_P1_AP1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ServicesReportes>();
builder.Services.AddBlazorBootstrap();

var connectionString = builder.Configuration.GetConnectionString("SqlConStr")
    ?? throw new InvalidOperationException("Connection string 'SqlConStr' not found.");

// ?? Cambio importante: Usar IDbContextFactory para Blazor Server
builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
