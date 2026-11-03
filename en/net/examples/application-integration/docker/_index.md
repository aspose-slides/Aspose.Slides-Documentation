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

The code below shows the main operation. The runnable download includes [ExampleSupport.cs](ExampleSupport.cs) with the entry point and supporting code.

```csharp
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
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
        string project=ProjectRoot(),input=Path.GetFullPath("container-input"),output=Path.GetFullPath("container-output");Directory.CreateDirectory(input);Directory.CreateDirectory(output);
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
        const string image="slides-examples-converter:26.10.0-net10";await Docker("build","--tag",image,project);
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
}
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
