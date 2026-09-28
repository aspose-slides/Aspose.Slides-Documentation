---
title: Run Aspose.Slides for .NET in Docker
linktitle: Docker
type: docs
weight: 140
url: /net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker container
- multi-stage build
- container image
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- fonts
- PDF conversion
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Build and run an Aspose.Slides for .NET console application in Docker: a multi-stage Dockerfile on the official .NET images, the Linux libraries and fonts it needs, and how to copy the generated files to your machine."
---

## **Overview**

This article shows how to run Aspose.Slides for .NET in a Docker container. You build a small console application that creates a presentation with a text box and converts it to PDF, package it with a multi-stage Dockerfile on Microsoft's official .NET images, run it, and copy the generated files to your machine. The article also lists the Linux libraries and fonts that Aspose.Slides needs in the container and ends with a variant for Alpine Linux.

You only need Docker on your machine. The .NET SDK is part of the build image, so you do not have to install it. To install Docker, see [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Choose the Package and the Base Image**

The default .NET 10 container images are based on Ubuntu 24.04. On these images, use the [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) package. It requires the `fontconfig` library, and the .NET runtime image contains neither that library nor any fonts, so the Dockerfile in this article installs both.

Aspose.Slides.NET6.CrossPlatform does not run on Alpine Linux. For Alpine-based images, use the [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) package with `libgdiplus`, as described in [Run on Alpine Linux](#run-on-alpine-linux). [Installation](/slides/net/installation/) compares the two packages.

## **Create the Project**

Create a folder named *HelloSlidesDocker* and add the following three files to it.

*HelloSlidesDocker.csproj* describes a console application for .NET 10, the version of the container images used below, and references Aspose.Slides.NET6.CrossPlatform. Set the package version to the latest one listed on [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* creates a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), adds a rectangle with text to its first slide, and saves the presentation twice with the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method: as PPTX and as PDF. Both files go to the *output* folder under the working directory. The application then lists the fonts that were replaced while the PDF was rendered, using [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), so you can see whether the container has the fonts the presentation uses.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* keeps the *bin* and *obj* folders of a local build, and the output of earlier runs, out of the Docker build context, so the image is built from the source files only.

```text
bin/
obj/
output/
```

## **Write the Dockerfile**

Add a file named *Dockerfile* to the same folder:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

The file has two stages:

- **The build stage** starts from the .NET SDK image. It copies the project file and restores the NuGet packages first, so Docker reuses that layer as long as the project file does not change. It then copies the source code and publishes the application to */app*.
- **The runtime stage** starts from the smaller .NET runtime image, which has no SDK, and copies in only the published application. It installs two packages:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform loads this library when it starts. Without it, the application stops with a `DllNotFoundException` that names `libfontconfig.so.1`.
  - `fonts-dejavu-core`: the runtime image contains no fonts, and Aspose.Slides needs at least one installed font to draw text; without any, the conversion stops with `InvalidOperationException: Cannot find any fonts installed on the system.` Text in fonts that are not installed is drawn with a substitute font. The DejaVu fonts are a small set that makes text render; to render presentations with the fonts they were designed with, see [Deploy Fonts](/slides/net/deploy-fonts/).

  `--no-install-recommends` and the removal of the package lists keep the image small. The last lines create the *output* folder, give it to the non-root `app` user that the official .NET images define (its user ID is in the `APP_UID` variable), and run the application as that user.

For an ASP.NET Core application, start the runtime stage from `mcr.microsoft.com/dotnet/aspnet:10.0` instead. It is based on the same Ubuntu image, so the same packages are needed.

## **Build and Run the Container**

Open a terminal in the *HelloSlidesDocker* folder. Build the image, then run a container from it:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

The first build downloads the base images and the NuGet packages, so it takes longer than later builds. The container runs the application and stops. It prints:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

The first line shows that the text uses Calibri, the default font of a new presentation, and that Calibri is not installed in the image, so Aspose.Slides drew the text with DejaVu Sans. The text in the PDF is real, selectable text in that font. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/net/licensing/).

## **Copy the Output to Your Machine**

The files are in the */app/output* folder of the stopped container. Copy them to an *output* folder on your machine, then remove the container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

These two commands work the same way in Bash, PowerShell, and the Windows Command Prompt.

On Linux, you can instead mount a folder of your machine into the container, so the application writes its files there directly:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

The `--user` option runs the application with your user and group IDs, so it can write to the folder you created and the files belong to you. `--rm` removes the container when it stops.

## **Run on Alpine Linux**

To run the application in an Alpine-based image, switch to the Aspose.Slides.NET package and change the runtime stage. The build stage stays the same.

1. In *HelloSlidesDocker.csproj*, replace the package reference:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. In *Program.cs*, add this statement after the `using` directives, before the first Aspose.Slides call. It enables the System.Drawing support for Linux that Aspose.Slides.NET uses:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. In *Dockerfile*, replace the runtime stage (everything from the second `FROM` line) with:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

The Alpine stage installs three packages and changes one setting:

- `libgdiplus` is the graphics library that Aspose.Slides.NET uses on Linux.
- `font-dejavu` provides fonts. Without any font, the conversion stops with `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` and `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` provide culture data. The Alpine .NET images run in globalization-invariant mode by default, and in that mode Aspose.Slides stops with a `CultureNotFoundException` for `en-US`.

Build, run, and copy the output with the same commands as above. On this image, the application prints only the `Saved` line: with Aspose.Slides.NET on Linux, fontconfig chooses the replacement for a missing font, and [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) does not list it. [Deploy Fonts](/slides/net/deploy-fonts/) shows how to check which font is used.

## **FAQ**

**The application stops with "Unable to load shared library 'libaspose.slides.drawing.capi…'". What is missing?**

On Ubuntu and Debian images, the `libfontconfig1` package; the message lists `libfontconfig.so.1` as the file that could not be opened. On Alpine Linux, the message means that Aspose.Slides.NET6.CrossPlatform is in use; switch to Aspose.Slides.NET as described in [Run on Alpine Linux](#run-on-alpine-linux).

**Why is the text in the PDF in a different font than in PowerPoint?**

The fonts that the presentation uses are not installed in the image, so Aspose.Slides draws the text with a substitute font. The application's output names each replaced font. [Deploy Fonts](/slides/net/deploy-fonts/) explains how to install fonts in the image or load them from the application folder.

**Do I need the .NET SDK on my machine?**

No. The build stage compiles the application inside the SDK image. You need the SDK only if you also want to build and run the application outside Docker; see [Installation](/slides/net/installation/).
