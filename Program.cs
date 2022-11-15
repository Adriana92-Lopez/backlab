var builder = WebApplication.CreateBuilder(args);
string cors = "labCors";

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson();  
builder.Services.AddCors(Op =>
{
    Op.AddPolicy(name: cors, builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowCredentials().WithMethods("GET", "POST").WithExposedHeaders("Content-Disposition");
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(cors);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
