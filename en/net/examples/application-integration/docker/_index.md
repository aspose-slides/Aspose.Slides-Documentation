---
title: "Run a Converter in Docker"
type: docs
weight: 30
url: /net/examples/application-integration/docker/
description: "Complete runnable C# application for run a converter in docker, with real host execution and reproducible input."
---

Build and run a complete Linux converter using the pinned Aspose.Slides.NET6.CrossPlatform package. The multi-stage image contains fontconfig and DejaVu fonts. Input is mounted read-only, output has its own mount, and a file license is supplied only at runtime.

## Prerequisites

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

## Complete application

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
Start a Linux Docker engine before running this example. The program creates the container build files.
The copied program writes its files under `example-output` by default.

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

internal static class Program
{
    private static async Task Convert(string input)
    {
        Context.Prerequisite(File.Exists(input),"Mount a valid PPTX at --input PATH. The container writes to the supplied --output directory.");
        byte[] before=SHA256.HashData(File.ReadAllBytes(input));
        using var p=new Presentation(input);int count=p.Slides.Count;string original=Context.IsLicensed?AllText(p):"";
        Context.Require(count>0,"A presentation with at least one slide is required for the preview.");
        p.Save("converted.pptx",SaveFormat.Pptx);p.Save("converted.pdf",SaveFormat.Pdf);
        using(var image=p.Slides[0].GetImage(new Size(640,360)))image.Save("preview.png",Aspose.Slides.ImageFormat.Png);
        using var reopened=new Presentation("converted.pptx");string retained=Context.IsLicensed?AllText(reopened):"";
        Context.Require(reopened.Slides.Count==count,"Input slide count changed after reopening.");
        if(Context.IsLicensed)Context.Require(retained==original,"Licensed editable input text changed after reopening.");
        Context.Require(before.SequenceEqual(SHA256.HashData(File.ReadAllBytes(input))),"Input was modified.");
        Context.Require(File.ReadAllBytes("converted.pdf").AsSpan(0,5).SequenceEqual(Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF.");
        await File.WriteAllTextAsync("result.json",JsonSerializer.Serialize(new{linux=OperatingSystem.IsLinux(),slides=count,text_checked=Context.IsLicensed,full_text_retained=Context.IsLicensed&&retained==original,input_unchanged=true,runtime=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,architecture=System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),substitutions=p.FontsManager.GetSubstitutions().Select(s=>s.OriginalFontName+" -> "+s.SubstitutedFontName).ToArray()}));
    }

    private static async Task VerifyContainer()
    {
        await Docker("version","--format","{{.Server.Version}}");
        string engine=(await Docker("info","--format","{{.OSType}}")).Trim();
        Context.Prerequisite(engine.Equals("linux",StringComparison.OrdinalIgnoreCase),"A Linux container engine is required; Docker reports "+engine+". Switch Docker Desktop to Linux containers or use a compatible Linux engine before running this example.");
        string input=Path.GetFullPath("container-input"),output=Path.GetFullPath("container-output");Directory.CreateDirectory(input);Directory.CreateDirectory(output);
        using(var p=new Presentation())
        {
            for(int i=0;i<2;i++)
            {
                var slide=i==0?p.Slides[0]:p.Slides.AddEmptySlide(p.LayoutSlides.GetByType(SlideLayoutType.Blank));
                var shape=slide.Shapes.AddAutoShape(ShapeType.Rectangle,40,40,550,100);shape.Name="example-content";
                shape.TextFrame.Text=Context.IsLicensed?(i==0?"Docker Alpha":"Docker Bravo"):(i==0?"Alpha":"Bravo");shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont=new FontData("Noto Sans");
            }
            p.Save(Path.Combine(input,"source.pptx"),SaveFormat.Pptx);
        }
        byte[] before=SHA256.HashData(File.ReadAllBytes(Path.Combine(input,"source.pptx")));
        const string image = "slides-standalone-converter:26.10.0";
        DirectoryInfo build = CreateBuildContext();
        try
        {
            await Docker("build", "--tag", image, build.FullName);
        }
        finally
        {
            build.Delete(recursive: true);
        }
        var args=new System.Collections.Generic.List<string>{"run","--rm","--network","none","--mount","type=bind,source="+input+",target=/input,readonly","--mount","type=bind,source="+output+",target=/output"};
        if(OperatingSystem.IsLinux())
        {
            string uid=(await RunProcess("id","-u")).Trim(),gid=(await RunProcess("id","-g")).Trim();
            Context.Require(uint.TryParse(uid,out _)&&uint.TryParse(gid,out _),"Cannot determine the Linux caller identity for the writable output mount.");
            args.AddRange(new[]{"--user",uid+":"+gid,"--env","HOME=/tmp","--env","XDG_CACHE_HOME=/tmp/example-cache"});
        }
        if(Context.IsLicensed){Context.Prerequisite(runtimeLicense!=null&&File.Exists(runtimeLicense),"Container licensed verification needs a readable runtime license file.");args.AddRange(new[]{"--mount","type=bind,source="+runtimeLicense+",target=/run/license/slides.lic,readonly","--env","ASPOSE_LICENSE_PATH=/run/license/slides.lic"});}
        args.AddRange(new[]{image,"--input","/input/source.pptx","--output","/output","--mode",Context.Mode});await Docker(args.ToArray());
        using var data=JsonDocument.Parse(await File.ReadAllTextAsync(Path.Combine(output,"result.json")));var result=data.RootElement;
        Context.Require(result.GetProperty("linux").GetBoolean()&&result.GetProperty("slides").GetInt32()==2,"A genuine Linux container conversion is required.");
        using(var reopened=new Presentation(Path.Combine(output,"converted.pptx")))
        {
            string fixture=string.Join(" ",reopened.Slides.SelectMany(s=>s.Shapes.OfType<IAutoShape>()).Where(s=>s.Name=="example-content").Select(s=>s.TextFrame.Text));
            Context.Require(fixture==(Context.IsLicensed?"Docker Alpha Docker Bravo":"Alpha Bravo"),"Bounded fixture text changed in the real container output.");
        }
        Context.Require(before.SequenceEqual(SHA256.HashData(File.ReadAllBytes(Path.Combine(input,"source.pptx")))),"Read-only input bytes changed.");
        string files=await Docker("run","--rm","--network","none","--entrypoint","sh",image,"-c","find /app -type f -iname '*.lic'");Context.Require(string.IsNullOrWhiteSpace(files),"License material entered the application image.");
        string history=await Docker("history","--no-trunc",image);await File.WriteAllTextAsync("image-history.txt",history);
        string id=(await Docker("image","inspect","--format","{{.Id}}",image)).Trim();
        await File.WriteAllTextAsync("result.json",JsonSerializer.Serialize(new{linux=true,slides=2,fixture_text_retained=true,full_text_retained=Context.IsLicensed&&result.GetProperty("full_text_retained").GetBoolean(),input_unchanged=true,no_license_in_image=true,networking_disabled=true,image_id=id,runtime=result.GetProperty("runtime").GetString()}));
    }

    private static ExampleContext Context=null!;

    private static string? runtimeLicense;

    private static string? runtimeInput;

    private static Task<int> Main(string[] args)
    {
        string? path=Value(args,"--license")??Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        runtimeLicense=string.IsNullOrWhiteSpace(path)?null:Path.GetFullPath(path);
        string? input=Value(args,"--input");runtimeInput=string.IsNullOrWhiteSpace(input)?null:Path.GetFullPath(input);
        return ExampleBootstrap.RunAsync(args,async context=>
        {
            Context=context;
            bool verify=context.Arguments.Contains("--verify-container")||Value(context.Arguments,"--input")==null;
            string actionId=verify?"application-integration/docker/block-001":"application-integration/docker/convert-file";
            if(verify)await VerifyContainer();
            else await Convert(runtimeInput!);
            using var result=JsonDocument.Parse(File.ReadAllText("result.json"));
            var root=result.RootElement;
            if(verify)context.Require(root.GetProperty("slides").GetInt32()==2&&root.GetProperty("fixture_text_retained").GetBoolean(),"The synthetic two-slide text fixture must survive conversion.");
            context.Require(root.GetProperty("input_unchanged").GetBoolean(),"Input bytes changed.");
            if(context.IsLicensed)context.Require(root.GetProperty("full_text_retained").GetBoolean(),"Licensed full text changed.");
            var checks=new System.Collections.Generic.Dictionary<string,bool>();
            if(verify&&context.IsLicensed)
            {
                foreach(string field in new[]{"linux","full_text_retained","input_unchanged","no_license_in_image","networking_disabled"}){context.Require(root.GetProperty(field).GetBoolean(),"Container check failed: "+field);checks["licensed-"+field]=true;}
                checks["licensed-slides"]=true;
            }
            else if(verify){checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;}
            else{checks["input slide count retained"]=true;checks["input bytes unchanged"]=true;checks["valid PDF and preview"]=true;}
        });
    }

    private static string AllText(IPresentation p)=>string.Join(" ",p.Slides.SelectMany(s=>s.Shapes.OfType<IAutoShape>()).Select(s=>s.TextFrame.Text));

    private static DirectoryInfo CreateBuildContext()
    {
        string? sourcePath = null;
        for (var directory = new DirectoryInfo(AppContext.BaseDirectory); directory != null; directory = directory.Parent)
        {
            string path = Path.Combine(directory.FullName, "Program.cs");
            if (!File.Exists(path)) continue;
            sourcePath = path;
            break;
        }
        if (sourcePath is null)
            throw new ExamplePrerequisiteException("Save this example as Program.cs in your .NET console project and run it there.");

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

    private static Task<string> Docker(params string[] args)=>RunProcess("docker",args);

    private static async Task<string> RunProcess(string executable, params string[] args)
    {
        var start = new ProcessStartInfo(executable)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        foreach (string argument in args)
            start.ArgumentList.Add(argument);

        Process process;
        try
        {
            process = Process.Start(start) ?? throw new InvalidOperationException();
        }
        catch (System.ComponentModel.Win32Exception)
        {
            throw new ExamplePrerequisiteException(
                "Install Docker Desktop or a compatible Linux engine and start it before container verification.");
        }

        using (process)
        {
            Task<string> stdout = process.StandardOutput.ReadToEndAsync();
            Task<string> stderr = process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            string output = await stdout;
            string error = await stderr;

            if (executable == "docker" && args[0] == "build")
                await File.WriteAllTextAsync("docker-build.log", output + error);
            if (process.ExitCode != 0)
            {
                if (executable == "docker" && args[0] is "version" or "info")
                    throw new ExamplePrerequisiteException(
                        "Docker engine is unavailable. Start a Linux container engine and retry.");
                throw new InvalidOperationException(executable + " operation failed: " + error);
            }

            Console.WriteLine(output);
            return output;
        }
    }

    private static string? Value(string[] args,string name){int i=Array.IndexOf(args,name);return i>=0&&i+1<args.Length?args[i+1]:null;}
}

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(string[] args, Func<ExampleContext, Task> run)
    {
        string start = Environment.CurrentDirectory;
        string output = Path.Combine(start, "example-output");
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        string? mode = null;
        var recipeArgs = new List<string>();

        try
        {
            for (int i = 0; i < args.Length; i++)
            {
                string option = args[i];
                if (option is not ("--output" or "--license" or "--mode"))
                {
                    recipeArgs.Add(option);
                    continue;
                }
                if (++i == args.Length)
                    throw new ExamplePrerequisiteException("Supply a value for " + option);
                if (option == "--output")
                    output = Path.GetFullPath(args[i], start);
                else if (option == "--license")
                    licensePath = args[i];
                else
                    mode = args[i];
            }

            mode ??= string.IsNullOrWhiteSpace(licensePath) ? "evaluation" : "licensed";
            if (mode is not ("evaluation" or "licensed"))
                throw new ExamplePrerequisiteException("Use --mode evaluation or --mode licensed.");
            if (mode == "licensed")
            {
                if (string.IsNullOrWhiteSpace(licensePath))
                    throw new ExamplePrerequisiteException("Set ASPOSE_LICENSE_PATH to a valid Aspose.Slides license.");
                var license = new License();
                license.SetLicense(Path.GetFullPath(licensePath, start));
                if (!license.IsLicensed())
                    throw new ExamplePrerequisiteException("The supplied license could not be applied.");
            }

            Directory.CreateDirectory(output);
            Console.WriteLine("Output: " + output);
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, mode, recipeArgs.ToArray()));
            return 0;
        }
        catch (ExamplePrerequisiteException error)
        {
            Console.Error.WriteLine(error.Message);
            return 2;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed class ExampleContext(string output, string mode, string[] arguments)
{
    public string OutputRoot { get; } = output;
    public string Mode { get; } = mode;
    public bool IsLicensed => Mode == "licensed";
    public string[] Arguments { get; } = arguments;

    public string ExpectedText(string text) => IsLicensed || text.Length <= 5
        ? text
        : text[..5] + "... text has been truncated due to evaluation version limitation.";

    public void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    public void Prerequisite(bool condition, string message)
    {
        if (!condition) throw new ExamplePrerequisiteException(message);
    }
}

internal sealed class ExamplePrerequisiteException(string message) : Exception(message);
```

## Dockerfile

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

## Run and verify

```text
dotnet run --project Example.csproj --configuration Release -- --verify-container
```

Docker Desktop or a Linux Docker engine must be available. Run the project with --verify-container on the host: it generates two input slides, builds the actual image, runs conversion with container networking disabled, and verifies saved text and an unchanged input. It also inspects the application image for copied license files. The Dockerfile uses fixed official .NET10 image versions. Consumer SDK selection is flexible and ordinary restore does not require a dependency lock. Linux font availability still affects rendering; inspect the returned substitution list and preview. No license is copied during image build.

The verification run writes result.json plus "container-output/converted.pptx", "container-output/converted.pdf", "container-output/preview.png", "container-output/result.json", "image-history.txt". Inspect the returned PDF files and the manifest or image preview. Exit 0 requires the named assertions to pass; an invalid input is reported explicitly.

Read the [detailed Docker guide](/slides/net/how-to-run-aspose-slides-in-docker/) for package and native-library choices when adapting Linux hosting.






## Download, prerequisites and run

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default Run/F5 or `--verify-container` builds and runs the real Linux image. Docker must be running. Container conversion has no network; input and any license are read-only mounts, with a separate writable output mount.
