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

1. Because CentOS 7 ships with GLIBC 2.14 while Aspose.Slides for .NET 6 and .NET 7 (including the cross-platform build) require Linux x86_64 with GLIBC 2.23 or newer, you should use Aspose.Slides for .NET Standard on such a system.

2. As of version 25.3, Aspose.Slides for .NET can be used on Alpine Linux. To ensure proper operation in an Alpine environment, follow these steps:
- Install the `libgdiplus` package (for example, in Docker): `RUN apk add --no-cache libgdiplus`
- To enable support for `System.Drawing.Common`, set the following flag:
```cs
    AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

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
