---
title: System Requirements
type: docs
weight: 60
url: /net/system-requirements/
keywords:
- system requirements
- operating system
- installation
- dependencies
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- preentation
- Aspose.Slides
description: "Discover Aspose.Slides for .NET system requirements. Ensure seamless PowerPoint and OpenDocument support on Windows, Linux, and macOS."
---

## **Overview**
Aspose.Slides for .NET does not require Microsoft PowerPoint to be installed because Aspose.Slides is an independent Microsoft PowerPoint document creation, conversion, page layout, and rendering engine.

## **Supported Operating Systems**
Aspose.Slides for .NET supports any 32-bit or 64-bit operating system where .NET or Mono framework is installed including (but not limited to):

### **Windows**
- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

{{%  alert  title="Notes"  color="primary"  %}} 

Because CentOS 7 ships with GLIBC 2.14 while Aspose.Slides for .NET 6 and .NET 7 (including the cross-platform build) require Linux x86_64 with GLIBC 2.23 or newer, you can use Aspose.Slides for .NET Standard on such a system.

{{% /alert %}} 

### **Mac**
- Mac OS X

## **Supported Frameworks**
Aspose.Slides for .NET supports .NET and Mono frameworks:

### **.NET Frameworks**
- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono Framework**
- MONO Support in MAC and Linux platforms

## **Development Environments**
Aspose.Slides for .NET can be used to develop applications in any development environment that targets the .NET platform, but these environments are explicitly supported:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides Main Builds**
Currently, there are two main builds of Aspose.Slides — Aspose.Slides.NET and Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
This is the main version of the product. It uses the standard .NET graphics engine.
- On non-Windows platforms, you may need to install the `libgdiplus` library and its dependencies.
- Prior to version Aspose.Slides 25.3, for non-Windows platforms, it was necessary to use the .NET Standard 2.0 DLL from the Aspose.Slides ZIP package.
- Starting from version Aspose.Slides 25.3, the NuGet package can be used directly even on non-Windows systems.
- When running on non-Windows systems, your application must include the following line at startup:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Starting from version 25.3, you can use this package on platforms that support .NET, such as Linux aarch64 (ARM64).**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
This is the version of Aspose.Slides using a custom cross-platform graphics engine developed by the Aspose.Slides team.  
On non-Windows platforms, the `fontconfig` library may be required.

**Supported Platforms**
- *Windows*: x86, x86_64  
- *Linux*: x86_64  
- *macOS*: x86_64, ARM64

**Planned for Future Support**  
- *Linux*: aarch64 (ARM64) — *ETA: end of 2025*  

**Not Planned**
- *Windows 11 ARM* (ARM64) — *Not currently under consideration*

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

No, PowerPoint is not required; Aspose.Slides is a standalone engine for [creating](/slides/net/create-presentation/), modifying, [converting](/slides/net/convert-presentation/), and [rendering](/slides/net/convert-powerpoint-to-png/) presentations.

**Which fonts are needed for correct rendering?**

In practice, the fonts used in the presentation or proper [substitutes](/slides/net/font-substitution/) must be available. To ensure consistent rendering on Linux/macOS, it is advisable to install common font packages.
