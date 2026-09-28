---
title: Deploy Fonts for Aspose.Slides on Linux and in Docker
linktitle: Deploy Fonts
type: docs
weight: 145
url: /net/deploy-fonts/
keywords:
- deploy fonts
- install fonts
- fonts in Docker
- fonts on Linux
- missing fonts
- font substitution
- Microsoft core fonts
- ttf-mscorefonts-installer
- custom fonts
- default font
- server
- container
- PDF conversion
- presentation
- .NET
- C#
- Aspose.Slides
description: "Deploy fonts for Aspose.Slides for .NET on Linux servers and in Docker containers: check which fonts are substituted, install font packages on Debian, Ubuntu, and Alpine, add your own font files, and set a default font."
---

## **Overview**

Aspose.Slides draws text with the fonts that are available to it when it renders a presentation, for example when it converts slides to PDF or to images. A Windows desktop usually has the fonts that presentations use. Linux servers and containers usually have few fonts or none, so Aspose.Slides draws the text with a substitute font. A substitute has different letter shapes and widths, so lines can wrap differently and text can overflow its shape, and characters that the substitute lacks are not drawn correctly. If no font is installed at all, the conversion stops with an error.

This article shows how to check which fonts Aspose.Slides substitutes, how to install fonts on Debian, Ubuntu, and Alpine Linux, how to add your own font files, and how to set the font that is used when a font is missing. The examples run in Docker on the official .NET images, as in [Run Aspose.Slides for .NET in Docker](/slides/net/how-to-run-aspose-slides-in-docker/). The package commands are Dockerfile instructions; on a Linux server, run the same commands as root.

For the font API itself, such as embedding fonts in a presentation and fallback and replacement rules, see [PowerPoint Fonts](/slides/net/powerpoint-fonts/).

## **Check Which Fonts Are Substituted**

The following console application reports the fonts that Aspose.Slides substitutes in the current environment. Create a folder named *FontCheck* and add the files below to it.

*FontCheck.csproj* references [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), the package for Debian and Ubuntu. It also copies the files of an optional *fonts* folder to the application output; the [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) section uses it.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* adds one text box per font name to a slide and assigns the font through the [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/) property. The font names come from the command line; without arguments, the application checks Calibri, Arial, and Times New Roman. It prints the folders in which Aspose.Slides looks for fonts ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), renders the slide to *output/fonts.pdf*, and prints the substitutions reported by [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). The two optional steps at the start, loading a *fonts* folder and reading a `DEFAULT_FONT` variable, are explained later in this article.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// The fonts to check: the command-line arguments, or three common Office fonts.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Load the font files from the fonts folder next to the application, if there is one.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Use the font named in the DEFAULT_FONT environment variable, if it is set, for text whose font is missing.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* keeps local build results out of the build context:

```text
bin/
obj/
output/
```

*Dockerfile* builds the application with the .NET SDK image and runs it on the .NET runtime image. The runtime stage installs `libfontconfig1`, which Aspose.Slides.NET6.CrossPlatform requires, and the DejaVu fonts. [Run Aspose.Slides for .NET in Docker](/slides/net/how-to-run-aspose-slides-in-docker/) explains each instruction.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Build the image and run the check:

```bash
docker build -t font-check .
docker run --rm font-check
```

The image has only the DejaVu fonts, so all three fonts are replaced with DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

To check the fonts of your own presentations, pass their names as arguments, for example `docker run --rm font-check "Segoe UI" Consolas`. To copy *output/fonts.pdf* out of the container, use the commands in [Copy the Output to Your Machine](/slides/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Install Fonts on Debian and Ubuntu**

### **Microsoft Core Fonts**

The `ttf-mscorefonts-installer` package downloads and installs Microsoft's core fonts for the web, among them Arial, Times New Roman, Courier New, Verdana, Georgia, and Trebuchet MS. The fonts are licensed under Microsoft's end-user license agreement (EULA), and the package installs them only after the EULA is accepted. A Docker build cannot answer the prompt, so the installer declines the EULA and installs no fonts, while `apt-get install` still reports success. Accept the EULA with `debconf-set-selections` **before** the package is installed.

In the *Dockerfile*, replace the `RUN` instruction that installs the packages in the runtime stage with:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Build the image and run the check again with the same two commands. Arial and Times New Roman are now installed:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, the default font of a presentation that Aspose.Slides creates, is not one of the core fonts, so it is still replaced. See [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

On Debian, the package is in the `contrib` repository component, which the Debian images do not enable; the default .NET 8 and .NET 9 images are based on Debian 12. Enable `contrib` in the same instruction:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

The Ubuntu-based .NET 10 images already enable `multiverse`, the Ubuntu component that contains the package.

### **Other Font Packages**

Debian and Ubuntu also package freely licensed fonts, for example:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

Install them with `apt-get install` in the same `RUN` instruction. Aspose.Slides.NET6.CrossPlatform does not apply the font aliases of the Linux font configuration: with `fonts-liberation` installed, text in Arial is still drawn with the general substitute font, not with Liberation Sans. To use a metric-compatible font in place of a missing one, set it as the [default font](#set-a-default-font-for-missing-fonts) or add a [font substitution rule](/slides/net/font-substitution/).

## **Add Your Own Font Files**

Fonts that the distributions do not package, such as your organization's fonts or other fonts that you are licensed to use on the server, can be added as font files. Put the font files, for example *.ttf* files, in a folder named *fonts* inside the *FontCheck* folder. The examples below use the files of Carlito, a font with the same metrics as Calibri, which you can download from [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Install the Fonts in a System Font Folder**

Aspose.Slides reads the fonts in the folders printed on the `Font folders` line. To install your fonts for every application in the image, copy them into */usr/local/share/fonts*, the folder for locally installed fonts. Add this instruction to the runtime stage of the *Dockerfile*, after the `RUN` instruction that installs the packages:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Load Fonts from the Application Folder**

Instead of installing the fonts in the image, you can ship them with the application and load them with [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). The fonts are then available to Aspose.Slides only, and they are deployed together with the application. *FontCheck* does this: *FontCheck.csproj* copies the *fonts* folder to the application output, and *Program.cs* passes that folder to `LoadExternalFonts` before it creates the presentation. [Custom Font](/slides/net/custom-font/) describes the other ways to supply fonts, such as loading them from memory.

Rebuild the image, then check Calibri and Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

The application folder now appears among the font folders, and Carlito is no longer substituted:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Set a Default Font for Missing Fonts**

When a font is missing, Aspose.Slides uses a substitute that it chooses itself. To choose it yourself, set the [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) property of [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) and pass the options to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) constructor. *FontCheck* reads the font name from the `DEFAULT_FONT` environment variable. With Carlito loaded, use it for missing fonts:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri is now drawn with Carlito, whose characters have the same widths as those of Calibri, so the text keeps its line breaks:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

The default font replaces every missing font. To map individual fonts, for example Arial to Liberation Sans and Calibri to Carlito, use [font substitution rules](/slides/net/font-substitution/). Rules change the rendered output, but `GetSubstitutions` does not reflect them, so check the fonts in the output file instead. For Asian text, also set [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); see [Default Font](/slides/net/default-font/).

## **Install Fonts on Alpine Linux**

On Alpine Linux, use the Aspose.Slides.NET package; [Run on Alpine Linux](/slides/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) lists the changes to the project. Make the same changes to *FontCheck*: replace the package reference, add the `SetSwitch` statement to *Program.cs*, and use this runtime stage, which also installs the Microsoft core fonts:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` downloads and installs the same Microsoft core fonts as the Debian and Ubuntu package, and their EULA applies in the same way. `fc-cache` updates the font cache.

With Aspose.Slides.NET on Linux, the font configuration library (fontconfig) chooses the substitute for a missing font, and `GetSubstitutions` does not report it, so *FontCheck* prints `No font substitutions.` To see which font is used for a font name, ask fontconfig in the container:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

With the Microsoft core fonts installed, Arial is used for Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Without them, when the `RUN` instruction installs only `icu-libs libgdiplus font-dejavu`, the same command prints:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Why does a presentation look different when it is converted on a server?**

The server does not have the fonts that the presentation uses, so Aspose.Slides draws the text with a substitute font whose letters have other widths. Run *FontCheck* with the presentation's font names to see which fonts are substituted, then install those fonts or load them from the application folder.

**The build installed ttf-mscorefonts-installer, but Arial is still substituted. Why?**

The EULA was not accepted before the package was installed, so the installer skipped the fonts. Add the `debconf-set-selections` command before `apt-get install`, as shown in [Microsoft Core Fonts](#microsoft-core-fonts), and rebuild the image.

**Does the computer that opens the PDF need the fonts?**

No. In these examples, the PDF contains the fonts that were used to draw the text, so it looks the same on any computer. The fonts are needed only where Aspose.Slides renders the presentation.
