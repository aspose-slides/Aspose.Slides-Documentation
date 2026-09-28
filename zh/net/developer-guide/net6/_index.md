---
title: 适用于 .NET 6 及更高版本的跨平台包
linktitle: 跨平台包
type: docs
weight: 235
url: /zh/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- 跨平台
- .NET 6 支持
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
description: "了解何时使用 Aspose.Slides.NET6.CrossPlatform 包：它存在的原因、可运行的平台以及在 Linux 上取代 libgdiplus 所需的内容。"
---
## **介绍**

Aspose.Slides for .NET 以两个 NuGet 包的形式发布。[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 通过 Microsoft 的 System.Drawing.Common 库绘制幻灯片。[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 则使用其自己的图形引擎进行绘制。本文说明第二个包存在的原因、它可以运行的环境、在 Linux 上的需求，以及它如何与 System.Drawing.Common 在同一项目中共存。

从 .NET 6 开始，Microsoft 仅在 Windows 上支持 System.Drawing.Common [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)。因此，在 Linux 上 Aspose.Slides.NET 除了需要 `libgdiplus` 库外，还需要 `System.Drawing.EnableUnixSupport` 开关；如果项目引用了 7 版或更高版的 System.Drawing.Common，则会失败。[System Requirements](/slides/zh/net/system-requirements/) 描述了这些条件。

Aspose.Slides.NET6.CrossPlatform 不使用 System.Drawing.Common 或 `libgdiplus`。它的图形引擎是一个原生库，包中为每个受支持平台都包含一个构建。两个包提供相同的 Aspose.Slides 命名空间和类，因此从一个切换到另一个只需更改包引用，而无需修改代码。

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| 图形 | System.Drawing.Common | 包中包含的本地图形引擎 |
| 目标框架 | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux 要求 | `libgdiplus` 和 `System.Drawing.EnableUnixSupport` 开关 | `fontconfig` |
| Alpine Linux | 受支持 | 不受支持 |

## **支持的平台**

Aspose.Slides.NET6.CrossPlatform 可在以下平台上与 .NET 6 及更高版本一起使用：

- **Windows**：x86 和 x64。原生库使用 Microsoft Visual C++ 运行时；请参阅 [System Requirements](/slides/zh/net/system-requirements/)。
- **Linux**：x64（glibc 2.23 或更高）以及 ARM64（glibc 2.39 或更高）。
- **macOS**：x64（Intel）和 ARM64（Apple silicon）。

它不在 Windows ARM64、Alpine Linux 或其他基于 musl 而非 glibc 的发行版，以及使用较旧 glibc（如 CentOS 7）的发行版上运行。这些系统请使用 Aspose.Slides.NET。

## **在 Linux 上安装**

在 Linux 上，包需要 `fontconfig` 库，但不需要 `libgdiplus`。在 Debian 和 Ubuntu 上，先安装 `fontconfig`，然后将包添加到项目中：

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

在 Debian 和 Ubuntu 上，`libfontconfig1` 同时安装 DejaVu 字体，因此文本能够正常渲染，无需额外的字体包。如果没有 `fontconfig`，创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 会因 `TypeInitializationException` 失败，其内部的 `DllNotFoundException` 报告无法打开 `libfontconfig.so.1`。[System Requirements](/slides/zh/net/system-requirements/) 包含一个检查设置的简短程序。

## **云和容器主机**

由于不需要 `libgdiplus`，Aspose.Slides.NET6.CrossPlatform 是在无法安装 `libgdiplus` 的 Linux 主机上使用的包。它仍然需要 `fontconfig` 和字体，而最小化的基础镜像可能缺少这些。例如，.NET 8 的 AWS Lambda 基础镜像既不包含 `libgdiplus` 也不包含 `fontconfig`。在基于该镜像构建的容器镜像中，运行 `dnf install -y fontconfig`，该命令还会安装 Noto Sans 字体。

有关特定云平台的指南，请参阅 [Aspose.Slides on Cloud Platforms](/slides/zh/net/slides-on-cloud-platforms/)。

## **在同一项目中使用 System.Drawing.Common (CS0433)**

使用 Aspose.Slides.NET6.CrossPlatform 的项目也可以引用 System.Drawing.Common，无论是直接引用还是通过其他包。当前版本的 Aspose.Slides 未在 `System` 命名空间中公开类型，因此这两个库不会冲突，您可以在同一个文件中同时使用 `Aspose.Slides` 和 `System.Drawing` 命名空间。

如果编译器因 `Image` 或 `Graphics` 等类型同时存在于 Aspose.Slides 和 System.Drawing.Common 而报告 CS0433 错误，则说明项目使用了较旧版本的 Aspose.Slides。请将包更新到最新版本。Aspose.Slides 将渲染后的图像作为 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象返回，相关内容在 [Modern API](/slides/zh/net/modern-api/) 中有说明。

## **常见问题**

**从 Aspose.Slides.NET 切换到 Aspose.Slides.NET6.CrossPlatform 时，我需要更改代码吗？**

不需要。两个包提供相同的 Aspose.Slides 命名空间和类，因此只需更换包引用。Aspose.Slides.NET6.CrossPlatform 不需要 `System.Drawing.EnableUnixSupport` 开关。在项目中只能添加这两个包中的一个。

**我可以在 .NET Framework 项目中使用 Aspose.Slides.NET6.CrossPlatform 吗？**

不能。该包仅针对 .NET 6 及更高版本。对于 .NET Framework 4.6.2 及更高版本，请使用 Aspose.Slides.NET。