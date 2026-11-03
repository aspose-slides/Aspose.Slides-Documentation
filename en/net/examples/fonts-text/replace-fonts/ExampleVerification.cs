using System.Threading.Tasks;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;

internal static partial class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("fonts-text/replace-fonts/block-001");
        ReplaceFonts();
        await Task.CompletedTask;
        context.Pass("fonts-text/replace-fonts/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });
    private static void Require(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }

    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }
}
