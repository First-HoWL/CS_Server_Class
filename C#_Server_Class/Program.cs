using C__Server_Class.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(
    options =>
    {
        options.Conventions.AddPageRoute("/Posts/post", "/news");
        //options.Conventions.AddPageRoute("/Products", "/shop");
    });
builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<EmployeeService>();
builder.Services.AddSingleton<SushiService>();
builder.Services.AddSingleton<SushiSetService>();
builder.Services.AddSingleton<BucketService>();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
