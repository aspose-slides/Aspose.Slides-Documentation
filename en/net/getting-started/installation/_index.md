---
title: Installation
type: docs
weight: 70
url: /net/installation/
keywords:
- install Aspose.Slides
- download Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Install Aspose.Slides for .NET from NuGet on Windows, Linux, and macOS: choose between the two packages, add one with the .NET CLI or Visual Studio, and install the Linux prerequisites."
---

## **Overview**

This article explains how to add Aspose.Slides for .NET to a project on Windows, Linux, and macOS. Aspose.Slides is distributed through NuGet. You can add it with the .NET CLI on any operating system, or with the NuGet Package Manager or the Package Manager Console in Visual Studio on Windows. The article also explains which of the two NuGet packages to choose and what Linux needs in addition.

Before installation, review the supported operating systems, .NET implementations, and additional dependencies in [System Requirements](/slides/net/system-requirements/).

## **Choose a Package**

Aspose.Slides for .NET is published as two NuGet packages. Both provide the same Aspose.Slides namespaces and classes, so your code does not change when you switch between them; only the package reference and the platform requirements differ.

| Package | Use it for | Additional requirements |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows, and .NET Framework applications | On Linux and macOS: the `libgdiplus` library, and the `System.Drawing.EnableUnixSupport` switch enabled at application startup |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 or later on Windows, Linux, and macOS | On Linux: the `fontconfig` library, if it is not already installed |

If you are unsure, use Aspose.Slides.NET on Windows and Aspose.Slides.NET6.CrossPlatform on Linux and macOS. On Alpine Linux, and on Linux systems whose glibc is older than 2.23 (x64) or 2.39 (ARM64), use Aspose.Slides.NET instead. [System Requirements](/slides/net/system-requirements/) lists the supported platforms of each package.

## **Install with the .NET CLI**

These steps work on Windows, Linux, and macOS with the .NET SDK 6 or later. Create a console application:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Then add the package for your platform. Add only one of the two packages to a project.

- On Windows: `dotnet add package Aspose.Slides.NET`
- On Linux and macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (on Linux, install its prerequisite first; see [Linux](#linux))

To check that the package works, replace the contents of *Program.cs* with the first example in [Create Presentations](/slides/net/create-presentation/) and run `dotnet run`. It saves *hello.pptx* in the project folder.

## **Windows**

### **Method 1: Install or Update Aspose.Slides from the NuGet Package Manager**

1. Open Microsoft Visual Studio.
2. Create a console app or open an existing project.
3. In **Solution Explorer**, right-click the project and select **Manage NuGet Packages** (or go to **Project** > **Manage NuGet Packages**).
4. Under **Browse**, search for *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Click **Aspose.Slides.NET** and then click **Install**.
   * If you already installed Aspose.Slides and want to update it, click **Update** instead.

The package is downloaded and referenced in your project.

### **Method 2: Install or Update Aspose.Slides Through the Package Manager Console**

This is how you reference the [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) package through the Package Manager Console:

1. Open Microsoft Visual Studio.
2. Create a console app or open an existing project.
3. Go to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Run this command: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
The latest release is installed in your project.

The **Installing Aspose.Slides.NET** message appears near the bottom of the window.
![Installation progress in the Package Manager Console](installation_4.png)

When the download completes, confirmation messages appear. The package is distributed under the [Aspose EULA](https://about.aspose.com/legal/eula).
![Installation confirmation messages](installation_5.png)

Aspose.Slides is now added to your project and referenced.
![Aspose.Slides referenced in the project](installation_6.png)

To update the package, run `Update-Package Aspose.Slides.NET` in the Package Manager Console.

## **Linux**

Use the .NET CLI steps above. Choose the package and install its prerequisite with your distribution's package manager. On Debian and Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: install `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: install `libgdiplus`, and enable Unix support for System.Drawing before your application uses Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Add this statement at the start of your application, before any Aspose.Slides call. In a *Program.cs* with top-level statements, put it after the `using` directives:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Use this package on Alpine Linux, and on systems whose glibc is too old for Aspose.Slides.NET6.CrossPlatform.

The fonts used in your presentations, or suitable substitutes, must be installed on the system for text to render correctly. [System Requirements](/slides/net/system-requirements/) describes the packages Aspose.Slides.NET needs on Alpine Linux, including fonts.

## **macOS**

Use the .NET CLI steps above with the **Aspose.Slides.NET6.CrossPlatform** package, which supports both Intel (x86_64) and Apple silicon (ARM64) Macs:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Is there a free version or trial limitation?**

Yes. Without a license, Aspose.Slides runs in evaluation mode: it adds an evaluation watermark to every slide it saves and truncates text read from presentations. To remove these limitations, apply a valid [license](/slides/net/licensing/).
