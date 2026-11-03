---
title: "Run a Converter in Docker"
type: docs
weight: 30
url: /net/examples/application-integration/docker/
description: "Complete runnable C# application for run a converter in docker, with real host execution and reproducible input."
---

Build and run a complete Linux converter using the pinned Aspose.Slides.NET6.CrossPlatform package. The multi-stage image contains fontconfig and DejaVu fonts. Input is mounted read-only, output has its own mount, and a file license is supplied only at runtime.

## **Prerequisites**

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

## **Complete application**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Start a Linux Docker engine before running this example. The program creates the container build files.
The copied program writes its files under `example-output` by default.

Start a Linux Docker engine and allow registry/package access for the image build. Save this entire program as `Program.cs` and keep it in the project folder: the host copies it into a temporary build context. Run `dotnet run` for a generated two-slide input, or `dotnet run -- --input PATH --output FOLDER`. Optional `ASPOSE_LICENSE_PATH` is mounted read-only at runtime; license bytes never enter the build context. Conversion runs with container networking disabled.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        var outputDirectory = Path.GetFullPath(Value(args, "--output") ?? "example-output");
        var inputPath = Value(args, "--input");
        var licenseSetting = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        var licensePath = string.IsNullOrWhiteSpace(licenseSetting) ? null : Path.GetFullPath(licenseSetting);
        if (licensePath != null)
        {
            if (!File.Exists(licensePath))
            {
                Console.Error.WriteLine("ASPOSE_LICENSE_PATH must name a readable license file.");
                return 2;
            }

            new License().SetLicense(licensePath);
        }

        Directory.CreateDirectory(outputDirectory);
        if (args.Contains("--in-container"))
            return ConvertInsideContainer(inputPath, outputDirectory);
        // Host orchestration: the pasted source remains on disk for the build context.
        var programPath = Path.GetFullPath("Program.cs");
        if (!File.Exists(programPath))
        {
            Console.Error.WriteLine("Run from the project folder containing the pasted Program.cs.");
            return 2;
        }

        var engineType = await RunProcess("docker", "info", "--format", "{{.OSType}}");
        if (!string.Equals(engineType?.Trim(), "linux", StringComparison.OrdinalIgnoreCase))
        {
            Console.Error.WriteLine("Start a Linux Docker engine, or switch Docker Desktop to Linux containers, then retry.");
            return 2;
        }

        if (inputPath == null)
        {
            inputPath = Path.Combine(outputDirectory, "source.pptx");
            CreateInput(inputPath);
        }

        inputPath = Path.GetFullPath(inputPath);
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine("Pass an existing PPTX using --input PATH.");
            return 2;
        }

        const string imageName = "slides-standalone-converter:26.10.0";
        var buildContext = CreateBuildContext(programPath);
        try
        {
            if (await RunProcess("docker", "build", "--tag", imageName, buildContext.FullName) == null)
                return 1;
        }
        finally
        {
            buildContext.Delete(recursive: true);
        }

        var dockerArguments = new List<string>
        {
            "run",
            "--rm",
            "--network",
            "none",
            "--mount",
            "type=bind,source=" + inputPath + ",target=/input/source.pptx,readonly",
            "--mount",
            "type=bind,source=" + outputDirectory + ",target=/output"
        };
        if (OperatingSystem.IsLinux())
        {
            var userId = (await RunProcess("id", "-u"))?.Trim();
            var groupId = (await RunProcess("id", "-g"))?.Trim();
            if (!uint.TryParse(userId, out _) || !uint.TryParse(groupId, out _))
                return 2;
            dockerArguments.AddRange(new[] { "--user", userId + ":" + groupId, "--env", "HOME=/tmp", "--env", "XDG_CACHE_HOME=/tmp/example-cache" });
        }

        if (licensePath != null)
        {
            dockerArguments.AddRange(new[] { "--mount", "type=bind,source=" + licensePath + ",target=/run/license/slides.lic,readonly", "--env", "ASPOSE_LICENSE_PATH=/run/license/slides.lic" });
        }

        dockerArguments.AddRange(new[] { imageName, "--in-container", "--input", "/input/source.pptx", "--output", "/output" });
        if (await RunProcess("docker", dockerArguments.ToArray()) == null)
            return 1;
        using var reopened = new Presentation(Path.Combine(outputDirectory, "converted.pptx"));
        var pdfBytes = File.ReadAllBytes(Path.Combine(outputDirectory, "converted.pdf"));
        if (reopened.Slides.Count == 0 || pdfBytes.Length < 5 || !pdfBytes.AsSpan(0, 5).SequenceEqual("%PDF-"u8))
        {
            Console.Error.WriteLine("The container did not produce usable presentation/PDF output.");
            return 1;
        }

        Console.WriteLine($"Container output: {outputDirectory}; {reopened.Slides.Count} slides.");
        return 0;
    }

    private static int ConvertInsideContainer(string? inputPath, string outputDirectory)
    {
        if (inputPath == null || !File.Exists(inputPath))
        {
            Console.Error.WriteLine("Mount a PPTX and pass its path with --input.");
            return 2;
        }

        using var presentation = new Presentation(inputPath);
        if (presentation.Slides.Count == 0)
        {
            Console.Error.WriteLine("The input must contain a slide for its preview.");
            return 2;
        }

        presentation.Save(Path.Combine(outputDirectory, "converted.pptx"), SaveFormat.Pptx);
        presentation.Save(Path.Combine(outputDirectory, "converted.pdf"), SaveFormat.Pdf);
        using var preview = presentation.Slides[0].GetImage(new Size(640, 360));
        preview.Save(Path.Combine(outputDirectory, "preview.png"), Aspose.Slides.ImageFormat.Png);
        return 0;
    }

    private static void CreateInput(string path)
    {
        using var presentation = new Presentation();
        for (var index = 0; index < 2; index++)
        {
            var slide = index == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 550, 100).TextFrame.Text = index == 0 ? "Alpha" : "Bravo";
        }

        presentation.Save(path, SaveFormat.Pptx);
    }

    private static async Task<string?> RunProcess(string executable, params string[] arguments)
    {
        var start = new ProcessStartInfo(executable)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        foreach (var argument in arguments)
            start.ArgumentList.Add(argument);
        try
        {
            using var process = Process.Start(start);
            if (process == null)
                return null;
            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            var output = await outputTask;
            var error = await errorTask;
            if (process.ExitCode != 0)
            {
                Console.Error.WriteLine($"{executable} failed ({process.ExitCode}). Check the engine, registry access, and build output.");
                Console.Error.WriteLine(error);
                return null;
            }

            Console.WriteLine(output);
            return output;
        }
        catch (System.ComponentModel.Win32Exception)
        {
            Console.Error.WriteLine("Install Docker Desktop or a compatible Linux engine and make its CLI available.");
            return null;
        }
    }

    private static DirectoryInfo CreateBuildContext(string sourcePath)
    {
        var build = Directory.CreateTempSubdirectory("slides-docker-");
        File.Copy(sourcePath, Path.Combine(build.FullName, "Program.cs"));
        File.WriteAllText(Path.Combine(build.FullName, "Example.csproj"), """
            <Project Sdk="Microsoft.NET.Sdk">
              <PropertyGroup>
                <OutputType>Exe</OutputType>
                <TargetFramework>net8.0</TargetFramework>
                <RollForward>Major</RollForward>
                <Nullable>enable</Nullable>
              </PropertyGroup>
              <ItemGroup>
                <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.10.0" />
              </ItemGroup>
            </Project>
            """);
        File.WriteAllText(Path.Combine(build.FullName, "Dockerfile"), """
            FROM mcr.microsoft.com/dotnet/sdk:10.0.403-noble AS build
            WORKDIR /src
            COPY Example.csproj ./
            RUN dotnet restore Example.csproj
            COPY Program.cs ./
            RUN dotnet publish Example.csproj --no-restore --configuration Release --output /app /p:UseAppHost=false

            FROM mcr.microsoft.com/dotnet/runtime:10.0.14-noble
            RUN apt-get update && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core libicu74 && rm -rf /var/lib/apt/lists/*
            WORKDIR /app
            COPY --from=build /app ./
            USER $APP_UID
            ENTRYPOINT ["dotnet", "Example.dll"]
            """);
        return build;
    }

    private static string? Value(string[] args, string name)
    {
        int i = Array.IndexOf(args, name);
        return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
    }
}
```

## **Dockerfile**

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0.403-noble AS build
WORKDIR /src
COPY Example.csproj global.json ./
RUN dotnet restore Example.csproj
COPY *.cs example-manifest.json ./
COPY Fonts ./Fonts
RUN dotnet publish Example.csproj --no-restore --configuration Release --output /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:10.0.14-noble
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core libicu74 \
    && rm -rf /var/lib/apt/lists/* \
    && mkdir -p /output && chown "$APP_UID:$APP_UID" /output
WORKDIR /app
COPY --from=build /app ./
USER $APP_UID
ENTRYPOINT ["dotnet", "Example.dll"]
CMD ["--input", "/input/source.pptx", "--output", "/output"]
```

## **Run and verify**

```text
dotnet run --project Example.csproj --configuration Release -- --verify-container
```

Docker Desktop or a Linux Docker engine must be available. Run the project with --verify-container on the host: it generates two input slides, builds the actual image, runs conversion with container networking disabled, and verifies saved text and an unchanged input. It also inspects the application image for copied license files. The Dockerfile uses fixed official .NET10 image versions. Consumer SDK selection is flexible and ordinary restore does not require a dependency lock. Linux font availability still affects rendering; inspect the returned substitution list and preview. No license is copied during image build.

The verification run writes result.json plus "container-output/converted.pptx", "container-output/converted.pdf", "container-output/preview.png", "container-output/result.json", "image-history.txt". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.






## **Download, prerequisites and run**

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default Run/F5 or `--verify-container` builds and runs the real Linux image. Docker must be running. Container conversion has no network; input and any license are read-only mounts, with a separate writable output mount.
