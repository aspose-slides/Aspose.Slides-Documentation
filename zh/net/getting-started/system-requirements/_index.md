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
description: "了解 Aspose.Slides for .NET 的系统要求。确保在 Windows、Linux 和 macOS 上实现无缝的 PowerPoint 和 OpenDocument 支持。"
---
## **概述**
Aspose.Slides for .NET 不需要安装 Microsoft PowerPoint，因为 Aspose.Slides 是一个独立的 Microsoft PowerPoint 文档创建、转换、页面布局和渲染引擎。

## **受支持的操作系统**
Aspose.Slides for .NET 支持任何已安装 .NET 或 Mono 框架的 32 位或 64 位操作系统，包括（但不限于）：

### **Windows**
- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

{{%  alert  title="Notes"  color="primary"  %}} 
因为 CentOS 7 附带 GLIBC 2.14，而 Aspose.Slides for .NET 6 和 .NET 7（包括跨平台构建）需要 GLIBC 2.23 或更高版本的 Linux x86_64，所以可以在此类系统上使用 Aspose.Slides for .NET Standard。
{{% /alert %}} 

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
- MONO 在 MAC 和 Linux 平台上的支持

## **开发环境**
Aspose.Slides for .NET 可以在任何针对 .NET 平台的开发环境中开发应用程序，但以下环境得到明确支持：

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
目前，Aspose.Slides 有两种主要构建 —— Aspose.Slides.NET 和 Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**
这是产品的主要版本。它使用标准的 .NET 图形引擎。
- 在非 Windows 平台上，可能需要安装 `libgdiplus` 库及其依赖项。
- 在 Aspose.Slides 25.3 版之前，对于非 Windows 平台，需要使用 Aspose.Slides ZIP 包中的 .NET Standard 2.0 DLL。
- 从 Aspose.Slides 25.3 版开始，即使在非 Windows 系统上也可以直接使用 NuGet 包。
- 在非 Windows 系统上运行时，您的应用程序必须在启动时包含以下行：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **从 25.3 版开始，您可以在支持 .NET 的平台上使用此包，例如 Linux aarch64（ARM64）。**

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**
这是 Aspose.Slides 使用由 Aspose.Slides 团队开发的自定义跨平台图形引擎的版本。 在非 Windows 平台上，可能需要 `fontconfig` 库。

**支持的平台**
- *Windows*：x86, x86_64  
- *Linux*：x86_64  
- *macOS*：x86_64, ARM64

**计划将来支持**  
- *Linux*：aarch64（ARM64） — *预计完成时间：2025 年底*  

**未计划**  
- *Windows 11 ARM*（ARM64） — *目前未考虑*  

## **常见问题**

**我是否需要安装 Microsoft PowerPoint 来进行转换和渲染？**

不，需要。PowerPoint 并非必需；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/net/create-presentation/)、修改、[转换](/slides/zh/net/convert-presentation/)和[渲染](/slides/zh/net/convert-powerpoint-to-png/)演示文稿。

**正确渲染需要哪些字体？**

实际上，演示文稿中使用的字体或适当的[替代字体](/slides/zh/net/font-substitution/)必须可用。为了确保 Linux/macOS 上的一致渲染，建议安装常用字体包。

**为什么自定义字体在 Linux 上显示为回退或缺失文本？**

如果字体文件的名称表条目不一致或损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，导致字体无法解析。使用已修正名称表记录的字体版本或安装一致的替代字体即可解决此问题。