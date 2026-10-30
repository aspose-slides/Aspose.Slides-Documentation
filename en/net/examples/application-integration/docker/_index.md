---
title: "Run a Converter in Docker"
type: docs
weight: 30
url: /net/examples/application-integration/docker/
description: "Complete runnable C# application for run a converter in docker, with real host execution and reproducible input."
---

Build and run a complete Linux converter using the pinned Aspose.Slides.NET6.CrossPlatform package. The multi-stage image contains fontconfig and DejaVu fonts. Input is mounted read-only, output has its own mount, and a file license is supplied only at runtime.

## Prerequisites

[Download the complete project](example.zip). Install the pinned .NET SDK and set `ASPOSE_LICENSE_PATH` to your valid file license for the full-content checks. See [installation](/slides/net/installation/) and [licensing](/slides/net/licensing/). The project generates synthetic inputs in self-test mode; no private input or credential is included.

## Complete application

```csharp
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
```

## Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0.427-noble AS build
WORKDIR /src
COPY Example.csproj global.json packages.lock.json ./
RUN dotnet restore Example.csproj --locked-mode
COPY Program.cs ./
RUN dotnet publish Example.csproj --no-restore --configuration Release --output /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:8.0.33-noble
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
ENTRYPOINT ["dotnet", "Example.dll"]
```

## Run and verify

```text
dotnet run --project Example.csproj --configuration Release -- --verify-container
```

Docker Desktop or a Linux Docker engine must be available. Run the project with --verify-container on the host: it generates two input slides, builds the actual image, runs conversion with container networking disabled, and verifies saved text and an unchanged input. It also inspects the application image for copied license files. The fixed official .NET 8 image versions and NuGet lock make the tested dependencies explicit. Linux font availability still affects rendering; inspect the returned substitution list and preview. No license is copied during image build.

The verification run writes result.json plus "container-output/converted.pptx", "container-output/converted.pdf", "container-output/preview.png", "container-output/result.json", "image-history.txt". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.
