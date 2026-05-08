---
title: 系统要求
type: docs
weight: 60
url: /zh/net/system-requirements/
keywords:
- 系统要求
- 操作系统
- 安装
- 依赖项
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的系统要求。在 Windows、Linux 和 macOS 上确保无缝的 PowerPoint 和 OpenDocument 支持。"
---
## **概述**
Aspose.Slides for .NET 不需要安装 Microsoft PowerPoint，因为 Aspose.Slides 是一个独立的 Microsoft PowerPoint 文档创建、转换、页面布局和渲染引擎。

## **受支持的操作系统**
Aspose.Slides for .NET 支持任何已安装 .NET 或 Mono 框架的 32 位或 64 位操作系统，包括（但不限于）：

### **Windows**
- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**
- Linux（Ubuntu、OpenSUSE、CentOS、Alpine 等）

### **Mac**
- Mac OS X

## **受支持的框架**
Aspose.Slides for .NET 支持 .NET 和 Mono 框架：

### **.NET 框架**
- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Mono 框架**
- MONO Support in MAC and Linux platforms

## **开发环境**
Aspose.Slides for .NET 可在任何面向 .NET 平台的开发环境中使用，但以下环境得到明确支持：

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides 主要构建**
当前，Aspose.Slides 有两个主要构建——Aspose.Slides.NET 和 Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
这是产品的主要版本，使用标准的 .NET 图形引擎。
- 在非 Windows 平台上，可能需要安装 `libgdiplus` 库及其依赖项。
- 在 Aspose.Slides 25.3 之前的版本，非 Windows 平台需要使用 Aspose.Slides ZIP 包中的 .NET Standard 2.0 DLL。
- 从 Aspose.Slides 25.3 开始，即使在非 Windows 系统上也可以直接使用 NuGet 包。
- 在非 Windows 系统上运行时，应用程序必须在启动时包含以下行：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **从 25.3 版本开始，您可以在支持 .NET 的平台上使用此包，例如 Linux aarch64 (ARM64)。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
这是 Aspose.Slides 使用由 Aspose.Slides 团队开发的自定义跨平台图形引擎的版本。  
在非 Windows 平台上，可能需要 `fontconfig` 库。

**受支持的平台**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**不受支持的平台**
- *Windows 11 ARM* (ARM64) — *目前不考虑*

{{%  alert  title="Notes"  color="primary"  %}}  
对于 Linux x64，需要 GLIBC 2.23+；对于 Linux ARM64，需要 GLIBC 2.39+。如 CentOS 7 (GLIBC 2.14) 等系统不受支持。如果需要在 CentOS 7 或其他不兼容系统（例如 Alpine）上运行 Aspose.Slides，请使用标准包：[Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)。  
{{% /alert %}} 

## **常见问题**

**是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 并非必装；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/net/create-presentation/)、修改、[转换](/slides/zh/net/convert-presentation/)和[渲染](/slides/zh/net/convert-powerpoint-to-png/)演示文稿。

**渲染正确需要哪些字体？**

实际使用中，演示文稿中使用的字体或合适的[替代字体](/slides/zh/net/font-substitution/)必须可用。为确保在 Linux/macOS 上渲染一致，建议安装常用字体包。

**为什么自定义字体在 Linux 上显示为回退或缺失文本？**

如果字体文件的 name 表条目不一致或损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，导致字体无法解析。使用已修正 name 表记录的字体版本或安装一致的替代字体即可解决此问题。