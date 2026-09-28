---
title: System Requirements
type: docs
weight: 60
url: /net/system-requirements/
keywords:
- system requirements
- supported platforms
- target frameworks
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Check what Aspose.Slides for .NET needs before you install it: the frameworks each NuGet package targets, the supported operating systems and processors, and the libraries and fonts that Linux requires."
---

## **Introduction**

Aspose.Slides for .NET is a standalone library: it does not need Microsoft PowerPoint or Microsoft Office. It is published as two NuGet packages, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) and [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Both provide the same Aspose.Slides namespaces and classes; they differ in the frameworks they target and in how they draw slides, which decides where they run and what they need.

This article lists the .NET versions and platforms each package supports and the system libraries and fonts that Linux needs, and ends with a short program that checks your setup. To add a package to a project, see [Installation](/slides/net/installation/).

## **Supported .NET Versions**

Each package contains one build of Aspose.Slides per target framework, and NuGet selects the build that matches your project's target framework.

| Package | Target frameworks in the package | Your project can target |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 or later; .NET 6 or later, including .NET 8, .NET 9, and .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 or later, including .NET 8, .NET 9, and .NET 10 |

The `netstandard2.0` build lets a .NET Standard 2.0 class library reference Aspose.Slides.NET. An application that uses such a library runs the build that matches the application's own target framework: a .NET 8 application, for example, runs the `net6.0` build.

## **Supported Operating Systems and Processors**

**Aspose.Slides.NET** contains only processor-independent (AnyCPU) managed code, so it runs on the processor architecture of the .NET runtime that loads it. It draws slides through Microsoft's System.Drawing.Common library, which Microsoft supports [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). On Linux, Aspose.Slides.NET therefore needs the `libgdiplus` library and a startup switch, described in [Linux](#linux). It runs on Linux distributions that provide `libgdiplus`, such as Debian, Ubuntu, and Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** draws slides with its own graphics engine. The engine is a native library that the package contains in one build per platform, so the package runs only on these platforms:

| Operating system | Processors | Notes |
|---|---|---|
| Windows | x86, x64 | Windows on ARM64 is not supported. |
| Linux | x64, ARM64 | Requires glibc 2.23 or later on x64 and glibc 2.39 or later on ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) | |

Aspose.Slides.NET6.CrossPlatform does not run on Alpine Linux or other distributions built on musl instead of glibc, or on distributions with an older glibc, such as CentOS 7. Use Aspose.Slides.NET on those systems.

On Windows, the native library of Aspose.Slides.NET6.CrossPlatform uses the Microsoft Visual C++ runtime (*MSVCP140.dll* and *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* on x64). If these files are missing on the target machine, install the [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Both packages need additional system libraries on Linux. Without them, the first example in [Create Presentations](/slides/net/create-presentation/) fails with an exception instead of saving the file. The commands below are for Debian and Ubuntu; on these distributions, each library also brings in the DejaVu fonts (`fonts-dejavu-core`), so text renders without further font packages.

### **Aspose.Slides.NET6.CrossPlatform**

The package's Linux library requires the `fontconfig` library:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Without it, creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) fails with a `TypeInitializationException` whose inner `DllNotFoundException` reports that `libfontconfig.so.1` cannot be opened.

Minimal base images may not include `fontconfig` either. The AWS Lambda base image for .NET 8, for example, contains neither `fontconfig` nor any fonts. In a container image built on it, run `dnf install -y fontconfig`, which also installs the Noto Sans fonts.

### **Aspose.Slides.NET**

The package requires two things on Linux:

1. The `libgdiplus` library:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

1. The `System.Drawing.EnableUnixSupport` switch, enabled at the start of your application before any Aspose.Slides call. In a *Program.cs* with top-level statements, put it after the `using` directives:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Without `libgdiplus`, saving a presentation fails with a `TypeInitializationException` whose inner `DllNotFoundException` reports that `libgdiplus` cannot be loaded. Without the switch, the inner exception is `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
The switch works only with System.Drawing.Common 6, the version that Aspose.Slides.NET depends on. Microsoft removed it in System.Drawing.Common 7. If your project references System.Drawing.Common 7 or later, directly or through another package, Aspose.Slides.NET fails on Linux with `PlatformNotSupportedException` even with `libgdiplus` installed and the switch enabled. In that case, use Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

On Alpine Linux, use Aspose.Slides.NET with the switch described above. Alpine images usually contain no fonts, and `libgdiplus` alone does not install any, so install `libgdiplus` together with at least one font package. Without fonts, saving a presentation fails with this error:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Option 1: DejaVu fonts**

The recommended option is the `ttf-dejavu` package:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

On current Alpine releases, `ttf-dejavu` installs the `font-dejavu` package, which also installs `fontconfig` and the font tools it depends on.

**Option 2: Microsoft core fonts**

If your presentations use Microsoft fonts such as Arial, Times New Roman, Courier New, or Verdana, install the Microsoft core fonts instead. The `update-ms-fonts` step downloads the fonts while the image is built, so the build needs internet access:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Globalization Support**

Both packages need .NET globalization support, which .NET on Linux provides through the ICU libraries. In [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) fails with `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Some container images turn this mode on. The .NET runtime images for Alpine Linux (`runtime-deps`, `runtime`, and `aspnet`), for example, set `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` and do not include ICU. In an image built on them, install ICU and turn the mode off:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Also make sure that your project file does not set the `InvariantGlobalization` property to `true`.

## **Check Your Setup**

To check that a package and its requirements are in place, run a program that saves a presentation and renders a slide to an image. Saving and rendering use the graphics library and the fonts, which are what the Linux requirements above provide.

Create a console application and add the package as described in [Installation](/slides/net/installation/), replace the contents of *Program.cs* with the code below, and run `dotnet run`. If you use Aspose.Slides.NET on Linux, add the `System.Drawing.EnableUnixSupport` switch statement shown in [Linux](#linux) after the `using` directives. The program uses top-level statements and `using` declarations, which need C# 9 or later. Projects that target .NET 6 or later use a newer C# version by default; in a project that targets .NET Framework, add `<LangVersion>latest</LangVersion>` to a `PropertyGroup` in the project file.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

The program adds a rectangle with text to the first slide and saves the presentation as *hello.pptx* with the [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method. It then renders the slide with [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) and saves the result as *hello.png* with [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) in the [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) format. The scale factors of 1 render one pixel per point, so the default 720 × 540 point slide becomes a 720 × 540 pixel image, with the text visible inside the rectangle. Without a license, both files also carry an evaluation watermark; see [Licensing](/slides/net/licensing/). If a requirement is missing, the program stops with one of the exceptions described in [Linux](#linux).

## **Development Tools**

You can build applications that use Aspose.Slides with any tool that supports your project's target framework: the .NET SDK and its `dotnet` command-line interface on Windows, Linux, and macOS, or Visual Studio on Windows. [Installation](/slides/net/installation/) describes both.

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

No, PowerPoint is not required. Aspose.Slides is a standalone engine for [creating](/slides/net/create-presentation/), modifying, [converting](/slides/net/convert-presentation/), and [rendering](/slides/net/convert-powerpoint-to-png/) presentations.

**Which package should I use?**

Use Aspose.Slides.NET on Windows and Aspose.Slides.NET6.CrossPlatform on Linux and macOS. On Alpine Linux, on Linux systems whose glibc is older than the versions listed above, and in projects that target .NET Framework, use Aspose.Slides.NET. Add only one of the two packages to a project.

**Which fonts are needed for correct rendering?**

The fonts used in the presentation, or suitable substitutes, must be available in the operating system. On Linux and macOS, install the font packages your presentations need to get consistent rendering. On Alpine Linux, install at least one font package in addition to `libgdiplus`, as described in [Alpine Linux](#alpine-linux).

**Why does a custom font render as a fallback or missing text on Linux?**

If the font file has inconsistent or corrupted name-table entries, the Linux font-matching stack (FreeType/fontconfig) may select an invalid record, causing the font to be unresolved. Using a font version with corrected name-table records or installing a consistent replacement resolves the issue.
