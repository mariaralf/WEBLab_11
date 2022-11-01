var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//Remove all user_uploads files before new session
string sourceDir = Environment.CurrentDirectory + "\\wwwroot\\user_uploads";
Console.WriteLine(sourceDir);
string[] uploaded_files = Directory.GetFiles(sourceDir);
for (int i = 0; i < uploaded_files.Length; i++)
{
    string fileName = uploaded_files[i];
    System.IO.File.Delete(fileName);
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
