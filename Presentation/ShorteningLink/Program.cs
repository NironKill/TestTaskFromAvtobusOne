using Microsoft.EntityFrameworkCore;
using ShorteningLink.Application.Interfaces;
using ShorteningLink.Application.Repositories.URL;
using ShorteningLink.Application.Services;
using ShorteningLink.Persistence;
using ShorteningLink.Persistence.Settings;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<DataBaseSet>(builder.Configuration.GetSection(DataBaseSet.Configuration));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(builder.Configuration.GetSection(DataBaseSet.Configuration).Get<DataBaseSet>().ConnectionString));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

builder.Services.AddScoped<IURLShortenerService, URLShortenerService>();
builder.Services.AddScoped<ILinkRepository, LinkRepository>();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (IServiceScope scope = app.Services.CreateScope())
{
    ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await Preparation.Initialize(context);
}

app.Run();
