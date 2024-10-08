---
title: 在 C# 中将幻灯片呈现为 SVG 图像
linktitle: 在 C# 中将幻灯片呈现为 SVG 图像
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: 本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 SVG 格式。您可以将 PPT、PPTX、ODP 格式转换为 SVG 图像。
keywords: C# 将 PowerPoint 转换为 SVG, C# PPT 转换为 SVG, C# PPTX 转换为 SVG
---

## 概述

本文解释了如何 **使用 C# 将 PowerPoint 演示文稿转换为 SVG 格式**。它涵盖以下主题。

_格式_: **PowerPoint**
- [C# PowerPoint 转换为 SVG](#csharp-powerpoint-to-svg)
- [C# 将 PowerPoint 转换为 SVG](#csharp-powerpoint-to-svg)
- [C# 如何将 PowerPoint 文件转换为 SVG](#csharp-powerpoint-to-svg)

_格式_: **PPT**
- [C# PPT 转换为 SVG](#csharp-ppt-to-svg)
- [C# 将 PPT 转换为 SVG](#csharp-ppt-to-svg)
- [C# 如何将 PPT 文件转换为 SVG](#csharp-ppt-to-svg)

_格式_: **PPTX**
- [C# PPTX 转换为 SVG](#csharp-pptx-to-svg)
- [C# 将 PPTX 转换为 SVG](#csharp-pptx-to-svg)
- [C# 如何将 PPTX 文件转换为 SVG](#csharp-pptx-to-svg)

_格式_: **ODP**
- [C# ODP 转换为 SVG](#csharp-odp-to-svg)
- [C# 将 ODP 转换为 SVG](#csharp-odp-to-svg)
- [C# 如何将 ODP 文件转换为 SVG](#csharp-odp-to-svg)

_格式_: **幻灯片**
- [C# 将 PowerPoint 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 PPT 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 PPTX 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 ODP 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)

本文涵盖的其他主题。
- [另请参见](#see-also)

## SVG 格式
SVG——可缩放矢量图形的缩写——是一种用于呈现二维图像的标准图形类型或格式。SVG 将图像存储为 XML 中的矢量，并包括定义其行为或外观的详细信息。

SVG 是满足这些标准中的一些很高标准的少数图像格式之一：可缩放性、交互性、性能、可访问性、可编程性等。因此，它在 web 开发中被广泛使用。

您可能希望在需要时使用 SVG 文件：

- **以 *非常大格式* 打印演示文稿。** SVG 图像可以缩放到任何分辨率或级别。您可以随意调整 SVG 图像的大小，而不会牺牲质量。
- **在 *不同介质或平台* 上使用幻灯片中的图表和图形。** 大多数阅读器能够解释 SVG 文件。
- **使用 *尽可能小的图像大小*。** SVG 文件通常比其他基于位图（JPEG 或 PNG）的高分辨率格式的文件要小。

## 将幻灯片呈现为 SVG 图像

Aspose.Slides for .NET 允许您将演示文稿中的幻灯片导出为 SVG 图像。请按照以下步骤生成 SVG 图像：

_步骤：C# 中的 PowerPoint 到 SVG 转换_

以下示例代码解释了如何使用 .NET 进行这些转换。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>步骤：在 C# 中将 PowerPoint 转换为 SVG</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>步骤：在 C# 中将 PPT 转换为 SVG</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>步骤：在 C# 中将 PPTX 转换为 SVG</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>步骤：在 C# 中将 ODP 转换为 SVG</strong></a>

_代码步骤：_

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
   * _.ppt_ 扩展名加载 _Presentation_ 类中的 **PPT** 文件。
   * _.pptx_ 扩展名加载 _Presentation_ 类中的 **PPTX** 文件。
   * _.odp_ 扩展名加载 _Presentation_ 类中的 **ODP** 文件。
   * _.pps_ 扩展名加载 _Presentation_ 类中的 **PPS** 文件。
2. 遍历演示文稿中的所有幻灯片。
3. 通过 FileStream 将每个幻灯片写入各自的 SVG 文件。

{{% alert color="primary" %}} 

您可能想尝试我们实现了从 Aspose.Slides for .NET 的 PPT 到 SVG 转换功能的 [免费网络应用程序](https://products.aspose.app/slides/conversion/ppt-to-svg)。

{{% /alert %}} 

以下 C# 示例代码展示了如何使用 Aspose.Slides 将 PowerPoint 转换为 SVG： 

``` csharp
// Presentation 对象可以加载 PPT、PPTX、ODP 等 PowerPoint 格式。
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## 另请参见 

本文还涵盖这些主题。代码与上述相同。

_格式_: **PowerPoint**
- [C# PowerPoint 转换为 SVG 代码](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转换为 SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转换为 SVG 编程](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转换为 SVG 库](#csharp-powerpoint-to-svg)
- [C# 将 PowerPoint 保存为 SVG](#csharp-powerpoint-to-svg)
- [C# 从 PowerPoint 生成 SVG](#csharp-powerpoint-to-svg)
- [C# 从 PowerPoint 创建 SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转换为 SVG 转换器](#csharp-powerpoint-to-svg)

_格式_: **PPT**
- [C# PPT 转换为 SVG 代码](#csharp-ppt-to-svg)
- [C# PPT 转换为 SVG API](#csharp-ppt-to-svg)
- [C# PPT 转换为 SVG 编程](#csharp-ppt-to-svg)
- [C# PPT 转换为 SVG 库](#csharp-ppt-to-svg)
- [C# 将 PPT 保存为 SVG](#csharp-ppt-to-svg)
- [C# 从 PPT 生成 SVG](#csharp-ppt-to-svg)
- [C# 从 PPT 创建 SVG](#csharp-ppt-to-svg)
- [C# PPT 转换为 SVG 转换器](#csharp-ppt-to-svg)

_格式_: **PPTX**
- [C# PPTX 转换为 SVG 代码](#csharp-pptx-to-svg)
- [C# PPTX 转换为 SVG API](#csharp-pptx-to-svg)
- [C# PPTX 转换为 SVG 编程](#csharp-pptx-to-svg)
- [C# PPTX 转换为 SVG 库](#csharp-pptx-to-svg)
- [C# 将 PPTX 保存为 SVG](#csharp-pptx-to-svg)
- [C# 从 PPTX 生成 SVG](#csharp-pptx-to-svg)
- [C# 从 PPTX 创建 SVG](#csharp-pptx-to-svg)
- [C# PPTX 转换为 SVG 转换器](#csharp-pptx-to-svg)

_格式_: **ODP**
- [C# ODP 转换为 SVG 代码](#csharp-odp-to-svg)
- [C# ODP 转换为 SVG API](#csharp-odp-to-svg)
- [C# ODP 转换为 SVG 编程](#csharp-odp-to-svg)
- [C# ODP 转换为 SVG 库](#csharp-odp-to-svg)
- [C# 将 ODP 保存为 SVG](#csharp-odp-to-svg)
- [C# 从 ODP 生成 SVG](#csharp-odp-to-svg)
- [C# 从 ODP 创建 SVG](#csharp-odp-to-svg)
- [C# ODP 转换为 SVG 转换器](#csharp-odp-to-svg)