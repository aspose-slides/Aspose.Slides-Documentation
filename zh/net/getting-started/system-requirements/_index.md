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
description: "了解 Aspose.Slides for .NET 的系统要求。确保在 Windows、Linux 和 macOS 上实现 PowerPoint 和 OpenDocument 的无缝支持。"
---
## **简介**

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

### **Mono Framework**

- 在 MAC 和 Linux 平台上的 MONO 支持

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

## **Aspose.Slides 主要版本**

目前，Aspose.Slides 有两个主要版本 —— Aspose.Slides.NET 和 Aspose.Slides.NET6.CrossPlatform。

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

这是产品的主版本。它使用标准的 .NET 图形引擎。
- 在非 Windows 平台上，可能需要安装 `libgdiplus` 库及其依赖项。
- 在 Aspose.Slides 25.3 之前的版本中，非 Windows 平台必须使用 Aspose.Slides ZIP 包中的 .NET Standard 2.0 DLL。
- 从 Aspose.Slides 25.3 版本开始，即使在非 Windows 系统上也可以直接使用 NuGet 包。
- 在非 Windows 系统上运行时，应用程序必须在启动时包含以下行：
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **从 25.3 版本开始，您可以在支持 .NET 的平台上使用此包，例如 Linux aarch64（ARM64）。**

#### **Additional Packages for Linux Alpine**

在 Alpine Linux 容器中运行 Aspose.Slides for .NET 时，仅安装 `libgdiplus` 可能不足。Alpine 容器默认通常不包含字体。如果没有可用字体，渲染或转换操作可能会出现类似以下错误的失败：

```text
System.ArgumentException: Font '?' cannot be found
```
要在 Alpine 上使用 Aspose.Slides，请同时安装 `libgdiplus` 和至少一个字体包。

**Option 1: DejaVu Fonts**

推荐的做法是安装 `ttf-dejavu` 包：

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` 包会自动安装所需的字体相关依赖，例如 `fontconfig`、`encodings`、`mkfontscale` 和 `mkfontdir`。大多数使用场景下不需要额外的字体包。

**Option 2: Microsoft Core Fonts**

如果您的演示文稿使用 Microsoft 专有字体（如 Arial、Times New Roman、Courier New 或 Verdana），请改为安装 Microsoft Core Fonts：

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

仅在处理的演示文稿需要 Microsoft 字体时才使用此选项。对于大多数情况，安装 `ttf-dejavu` 更简单、更可靠。

**Additional requirements for globalization**

要在 Alpine 上实现正确的全球化支持，请安装 `icu-libs` 包并禁用不变模式：

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

这是 Aspose.Slides 使用由 Aspose.Slides 团队开发的自定义跨平台图形引擎的版本。  
在非 Windows 平台上，可能需要 `fontconfig` 库。

**Supported Platforms**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Unsupported Platforms**
- *Windows 11 ARM* (ARM64) — *目前暂无计划支持*

{{%  alert  title="Notes"  color="primary"  %}}  
对于 Linux x64，需要 GLIBC 2.23+；对于 Linux ARM64，需要 GLIBC 2.39+。如 CentOS 7（GLIBC 2.14）等系统不受支持。如果需要在 CentOS 7 或其他不兼容系统（例如 Alpine）上运行 Aspose.Slides，请使用标准包：[Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)。  
{{% /alert %}}

## **常见问题**

**是否需要安装 Microsoft PowerPoint 才能进行转换和渲染？**

不需要，PowerPoint 并非必装；Aspose.Slides 是一个独立的引擎，用于[创建](/slides/zh/net/create-presentation/)、修改、[转换](/slides/zh/net/convert-presentation/)和[渲染](/slides/zh/net/convert-powerpoint-to-png/)演示文稿。

**需要哪些字体才能确保正确渲染？**

演示文稿中使用的字体或其合适的替代品必须在操作系统中可用。在 Linux 和 macOS 上，安装常见的字体包以确保渲染一致。

对于 Alpine Linux 容器，除 `libgdiplus` 外还需至少安装一个字体包。推荐的最小配置是 `libgdiplus` 加 `ttf-dejavu`。如果需要 Arial、Times New Roman、Courier New 或 Verdana 等 Microsoft 字体，请使用 `msttcorefonts-installer` 并配合 `fontconfig`。

**为什么自定义字体在 Linux 上会显示为回退或缺失文字？**

如果字体文件的 name 表条目不一致或损坏，Linux 的字体匹配堆栈（FreeType/fontconfig）可能会选择无效记录，导致字体无法解析。使用已修正 name 表的字体版本或安装一致的替代字体即可解决此问题。