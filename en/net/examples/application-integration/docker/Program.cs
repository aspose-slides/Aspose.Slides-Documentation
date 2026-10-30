using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath)) new License().SetLicense(licensePath);
        if (args.Contains("--verify-container")) { await VerifyContainer(licensePath); return; }
        string input = Value(args, "--input") ?? "/input/source.pptx";
        string output = Value(args, "--output") ?? "/output";
        Directory.CreateDirectory(output);
        using var presentation = new Presentation(input);
        int sourceCount = presentation.Slides.Count;
        string sourceText = string.Join(" ", presentation.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
        presentation.Save(Path.Combine(output, "converted.pptx"), SaveFormat.Pptx);
        presentation.Save(Path.Combine(output, "converted.pdf"), SaveFormat.Pdf);
        using var image = presentation.Slides[0].GetImage(new Size(640, 360));
        image.Save(Path.Combine(output, "preview.png"), Aspose.Slides.ImageFormat.Png);
        using var reopened = new Presentation(Path.Combine(output, "converted.pptx"));
        string text = string.Join(" ", reopened.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
        if (reopened.Slides.Count != sourceCount || text != sourceText) throw new InvalidOperationException("Editable input text or slide count changed.");
        string result = JsonSerializer.Serialize(new { linux = OperatingSystem.IsLinux(), slides = reopened.Slides.Count, full_text_retained = true, runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription, architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(), substitutions = presentation.FontsManager.GetSubstitutions().Select(s => s.OriginalFontName + " -> " + s.SubstitutedFontName).ToArray() });
        await File.WriteAllTextAsync(Path.Combine(output, "result.json"), result);
        Console.WriteLine(result);
    }

    private static async Task VerifyContainer(string? licensePath)
    {
        if (string.IsNullOrWhiteSpace(licensePath) || !File.Exists(licensePath)) throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to your license file for this licensed check.");
        string input = Path.GetFullPath("container-input");
        string output = Path.GetFullPath("container-output");
        Directory.CreateDirectory(input);
        Directory.CreateDirectory(output);
        using (var presentation = new Presentation())
        {
            var first = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 550, 100);
            first.TextFrame.Text = "Docker Alpha";
            first.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("DejaVu Sans");
            var second = presentation.Slides.AddEmptySlide(presentation.LayoutSlides.GetByType(SlideLayoutType.Blank));
            var text = second.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 550, 100);
            text.TextFrame.Text = "Docker Bravo";
            text.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("DejaVu Sans");
            presentation.Save(Path.Combine(input, "source.pptx"), SaveFormat.Pptx);
        }
        byte[] before = System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(Path.Combine(input, "source.pptx")));
        const string imageName = "slides-examples-converter:26.10.0";
        await Docker("build", "--pull", "--tag", imageName, ".");
        await Docker("run", "--rm", "--network", "none",
            "--mount", "type=bind,source=" + input + ",target=/input,readonly",
            "--mount", "type=bind,source=" + output + ",target=/output",
            "--mount", "type=bind,source=" + Path.GetFullPath(licensePath) + ",target=/run/secrets/slides.lic,readonly",
            "--env", "ASPOSE_LICENSE_PATH=/run/secrets/slides.lic", imageName,
            "--input", "/input/source.pptx", "--output", "/output");
        using var result = JsonDocument.Parse(await File.ReadAllTextAsync(Path.Combine(output, "result.json")));
        if (!result.RootElement.GetProperty("linux").GetBoolean() || result.RootElement.GetProperty("slides").GetInt32() != 2) throw new InvalidOperationException("Expected a real two-slide Linux conversion.");
        if (!before.SequenceEqual(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(Path.Combine(input, "source.pptx"))))) throw new InvalidOperationException("Mounted input was modified.");
        string secrets = await Docker("run", "--rm", "--network", "none", "--entrypoint", "sh", imageName, "-c", "find /app -type f -iname '*.lic'");
        if (!string.IsNullOrWhiteSpace(secrets)) throw new InvalidOperationException("License material was copied into the image.");
        string history = await Docker("history", "--no-trunc", imageName);
        await File.WriteAllTextAsync("image-history.txt", history);
        string imageId = (await Docker("image", "inspect", "--format", "{{.Id}}", imageName)).Trim();
        string summary = JsonSerializer.Serialize(new { linux = true, slides = 2, full_text_retained = true, input_unchanged = true, no_license_in_image = true, networking_disabled = true, image_id = imageId, runtime = result.RootElement.GetProperty("runtime").GetString() });
        await File.WriteAllTextAsync("result.json", summary);
        Console.WriteLine(summary);
    }

    private static async Task<string> Docker(params string[] arguments)
    {
        var start = new ProcessStartInfo("docker") { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
        foreach (string argument in arguments) start.ArgumentList.Add(argument);
        using var process = Process.Start(start) ?? throw new InvalidOperationException("Could not start Docker.");
        Task<string> stdout = process.StandardOutput.ReadToEndAsync();
        Task<string> stderr = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();
        string output = await stdout;
        string error = await stderr;
        if (arguments.Length > 0 && arguments[0] == "build") await File.WriteAllTextAsync("docker-build.log", output + error);
        if (process.ExitCode != 0) throw new InvalidOperationException("Docker command failed: " + error);
        Console.WriteLine(output);
        return output;
    }

    private static string? Value(string[] args, string name)
    {
        int index = Array.IndexOf(args, name);
        return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
    }
}
