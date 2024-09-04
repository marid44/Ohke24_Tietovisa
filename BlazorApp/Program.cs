using BlazorApp.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<QuizService>(); // Register the QuizService

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

// Define QuizService in a separate file, such as Services/QuizService.cs
public class QuizService
{
    private readonly string filePath = "Ohke_tietovisaA.csv";  // Relative path to the CSV file
    public List<(string Question, string[] Options, string Answer)> Questions { get; private set; } = new List<(string, string[], string)>();

    public async Task LoadQuestionsAsync()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("CSV file not found", path);
        }

        using (var reader = new StreamReader(path))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] values = line.Split(',');

                if (values.Length == 5)
                {
                    string question = values[0];
                    string[] options = new[] { values[1], values[2], values[3], values[4] };
                    string answer = values[4]; // Assuming the last option is the correct answer

                    Questions.Add((question, options, answer));
                }
            }
        }
    }
}
