---
title: Installation
type: docs
weight: 70
url: /nodejs-net/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- Aspose.Slides installation
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Install Aspose.Slides for Node.js via .NET from npm on Windows or Linux: prerequisites, the edge-js override, a one-time NuGet restore, and a first program that creates a presentation."
---

## **Overview**

Aspose.Slides for Node.js via .NET is the npm package `aspose.slides.via.net`. It runs the Aspose.Slides .NET library inside Node.js through the [edge-js](https://github.com/agracio/edge-js) bridge, so a working installation needs both Node.js and .NET.

This article takes you from a clean machine to a first program that creates a presentation. There are four steps: create a project with an edge-js override, install the package from npm, restore the package's .NET dependencies once, and run your script from the project folder.

## **Prerequisites**

- **Node.js 22 or 24 LTS**, x64 build, from [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 or later**, from [dotnet.microsoft.com](https://dotnet.microsoft.com/download). The .NET runtime alone is not enough: the restore step below needs the SDK, and so does the bridge when your script runs. Run `dotnet --list-sdks` to check which SDKs are installed.
- **On Linux only**:
  - the build tools `python3`, `make` and `g++`, because npm compiles edge-js during installation on Linux;
  - the fontconfig library, which the Aspose.Slides native drawing library loads.

  On Debian, these are the packages `python3`, `make`, `g++` and `libfontconfig1`.

The steps in this article were tested on these platforms:

| Platform | Result |
|---|---|
| Windows x64 with Node.js 22 or 24 | Works. Tested with the Microsoft Visual C++ Redistributable installed. |
| Linux x64 with Node.js 22 or 24, where the system OpenSSL is from the same release line as the OpenSSL built into Node.js, such as Debian 13 | Works. |
| Linux where the two OpenSSL versions differ, such as Debian 12 | Node.js crashes with a segmentation fault when a presentation is created. |
| macOS | Not verified. |

On Linux, compare the two versions before you start. The first command prints the OpenSSL version built into Node.js; the second prints the system version. Use a system where both start with the same major and minor numbers, for example `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

If the `openssl` command is not found, install the `openssl` package first.

## **Create a Project**

Create a folder for your project, initialize it, and add an override that tells npm which edge-js release to install:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

The package asks for an older edge-js release whose prebuilt Windows binaries stop at Node.js 20, so without the override the first script on Windows stops with "The edge module has not been pre-compiled for node.js version". The command writes the override to the `overrides` section of `package.json`; add it before you install the package.

## **Install the Package**

Install Aspose.Slides for Node.js via .NET from npm:

```sh
npm install aspose.slides.via.net
```

During installation, the package copies its native drawing libraries (the files whose names contain `aspose.slides.drawing.capi`) into the project folder, next to `package.json`.

The package is also published as a ZIP archive on [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). This article covers installation from npm only.

## **Restore the .NET Dependencies**

The package contains the Aspose.Slides .NET assemblies, but not the 20 NuGet packages that those assemblies depend on. At run time, .NET looks for them in the NuGet package cache: `%USERPROFILE%\.nuget\packages` on Windows, `~/.nuget/packages` on Linux, or the folder set in the `NUGET_PACKAGES` environment variable. If they are missing, the first script stops with "assembly specified in the dependencies manifest was not found".

To fill the cache, create a folder named `deps` in the project folder and save the following file in it as `deps.csproj`. Each `PackageDownload` item downloads one package at the exact version in brackets; nothing is built.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Then restore it from the project folder:

```sh
dotnet restore deps/deps.csproj
```

You need this step once per machine, not once per project: the packages stay in the NuGet cache, and later projects on the same machine use them. After the restore, you can delete the `deps` folder.

## **Run a First Program**

Create a file named `hello.js` in the project folder with the following code. It creates a presentation, adds a rectangle with the text "Hello, World!" to the first slide, and saves the result as `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// A new presentation contains one empty slide.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position and size are in points (1/72 inch): x, y, width, height.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Release the .NET object that backs the presentation.
    presentation.dispose();
}
```

Run it from the project folder:

```sh
node hello.js
```

The script prints `Saved hello.pptx`. Open `hello.pptx` to see one slide with a filled rectangle that contains the text. Without a license, Aspose.Slides also adds an evaluation watermark; see [Evaluate Aspose.Slides](/slides/nodejs-net/evaluate-aspose-slides/) and [Licensing](/slides/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Run your scripts from the project folder, the one that contains `package.json`. Relative paths such as `hello.pptx` are resolved against the current folder, and on some machines a script started from another folder cannot create a presentation.
{{% /alert %}}

The JavaScript API mirrors Aspose.Slides for .NET: classes keep their .NET names, properties and methods use camelCase (`Slides` becomes `slides`, `AddAutoShape` becomes `addAutoShape`), and collection items are read with `get(index)`. There is no separate API reference for this package, so use the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) for class and member details, for example [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) and [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**What does "The edge module has not been pre-compiled for node.js version" mean?**

npm installed the older edge-js release that the package asks for. Add the override from [Create a Project](#create-a-project) and run `npm install` again.

**What does "assembly specified in the dependencies manifest was not found" mean?**

The .NET dependencies are not in the NuGet cache. The same run also reports "edge.initializeClrFunc is not a function". Follow [Restore the .NET Dependencies](#restore-the-net-dependencies) once, then run your script again.

**What does "The edge native module is not available" mean on Linux?**

edge-js was not compiled during `npm install`, for example because `python3`, `make` or `g++` was missing. npm does not report this as an error. Install the build tools, then run `npm rebuild edge-js` in the project folder.

**Why does creating a presentation fail with an empty "Error"?**

On Linux, check that the fontconfig library is installed (`libfontconfig1` on Debian); without it, the native drawing library cannot load. On any system, also check that you run the script from the project folder.

**Why does Node.js crash with a segmentation fault on Linux?**

The system OpenSSL and the OpenSSL built into Node.js are from different release lines. Compare them as shown in [Prerequisites](#prerequisites) and use a distribution or Node.js build where they match.

**Do I need to repeat the NuGet restore for every project?**

No. The restore fills the NuGet cache for your user account, and every project on that machine uses the same cache.
