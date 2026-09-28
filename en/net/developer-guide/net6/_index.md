---
title: Cross-Platform Package for .NET 6 and Later
linktitle: Cross-Platform Package
type: docs
weight: 235
url: /net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- cross-platform
- .NET 6 support
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Learn when to use the Aspose.Slides.NET6.CrossPlatform package: why it exists, the platforms it runs on, and what it needs on Linux instead of libgdiplus."
---

## **Introduction**

Aspose.Slides for .NET is published as two NuGet packages. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) draws slides through Microsoft's System.Drawing.Common library. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) draws them with its own graphics engine instead. This article explains why the second package exists, where it runs, what it needs on Linux, and how it coexists with System.Drawing.Common in one project.

## **Why a Separate Package**

Starting with .NET 6, Microsoft supports System.Drawing.Common [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). As a result, on Linux Aspose.Slides.NET needs the `System.Drawing.EnableUnixSupport` switch in addition to the `libgdiplus` library, and it fails there if the project references System.Drawing.Common 7 or later. [System Requirements](/slides/net/system-requirements/) describes these conditions.

Aspose.Slides.NET6.CrossPlatform does not use System.Drawing.Common or `libgdiplus`. Its graphics engine is a native library that the package contains in one build per supported platform. Both packages provide the same Aspose.Slides namespaces and classes, so switching from one to the other changes only the package reference, not your code.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Graphics | System.Drawing.Common | Native graphics engine included in the package |
| Target frameworks | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux requirements | `libgdiplus` and the `System.Drawing.EnableUnixSupport` switch | `fontconfig` |
| Alpine Linux | Supported | Not supported |

## **Supported Platforms**

Aspose.Slides.NET6.CrossPlatform works with .NET 6 and later versions on these platforms:

- **Windows**: x86 and x64. The native library uses the Microsoft Visual C++ runtime; see [System Requirements](/slides/net/system-requirements/).
- **Linux**: x64 with glibc 2.23 or later, and ARM64 with glibc 2.39 or later.
- **macOS**: x64 (Intel) and ARM64 (Apple silicon).

It does not run on Windows on ARM64, on Alpine Linux or other distributions built on musl instead of glibc, or on distributions with an older glibc, such as CentOS 7. Use Aspose.Slides.NET on those systems.

## **Install on Linux**

On Linux, the package requires the `fontconfig` library, but not `libgdiplus`. On Debian and Ubuntu, install `fontconfig` and then add the package to your project:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

On Debian and Ubuntu, `libfontconfig1` also installs the DejaVu fonts, so text renders without further font packages. Without `fontconfig`, creating a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) fails with a `TypeInitializationException` whose inner `DllNotFoundException` reports that `libfontconfig.so.1` cannot be opened. [System Requirements](/slides/net/system-requirements/) includes a short program that checks the setup.

## **Cloud and Container Hosts**

Because it does not need `libgdiplus`, Aspose.Slides.NET6.CrossPlatform is the package to use on Linux hosts where you cannot install `libgdiplus`. It still needs `fontconfig` and fonts, which minimal base images may lack. The AWS Lambda base image for .NET 8, for example, contains neither. In a container image built on it, run `dnf install -y fontconfig`, which also installs the Noto Sans fonts.

For guides to specific cloud platforms, see [Aspose.Slides on Cloud Platforms](/slides/net/slides-on-cloud-platforms/).

## **Using System.Drawing.Common in the Same Project (CS0433)**

A project that uses Aspose.Slides.NET6.CrossPlatform can also reference System.Drawing.Common, directly or through another package. The current version of Aspose.Slides exposes no public types in `System` namespaces, so the two libraries do not conflict, and you can import the `Aspose.Slides` and `System.Drawing` namespaces in the same file.

If the compiler reports error CS0433 because a type such as `Image` or `Graphics` exists in both Aspose.Slides and System.Drawing.Common, your project uses an older version of Aspose.Slides. Update the package to the latest version. Aspose.Slides returns rendered images as [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) objects, which are described in [Modern API](/slides/net/modern-api/).

## **FAQ**

**Do I need to change my code when I switch from Aspose.Slides.NET to Aspose.Slides.NET6.CrossPlatform?**

No. Both packages provide the same Aspose.Slides namespaces and classes, so you only replace the package reference. Aspose.Slides.NET6.CrossPlatform does not need the `System.Drawing.EnableUnixSupport` switch. Add only one of the two packages to a project.

**Can I use Aspose.Slides.NET6.CrossPlatform in a .NET Framework project?**

No. The package targets only .NET 6 and later. For .NET Framework 4.6.2 and later, use Aspose.Slides.NET.
