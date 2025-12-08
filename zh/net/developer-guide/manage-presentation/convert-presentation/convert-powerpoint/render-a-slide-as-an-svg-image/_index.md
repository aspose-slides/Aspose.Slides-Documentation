---
title: 在 C# 中将幻灯片呈现为 SVG 图像
linktitle: 将幻灯片呈现为 SVG 图像
type: docs
weight: 50
url: /zh/net/render-a-slide-as-an-svg-image/
description: 本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 SVG 格式。您可以将 PPT、PPTX、ODP 格式转换为 SVG 图像。
keywords: C# 将 PowerPoint 转换为 SVG, C# PPT 转换为 SVG, C# PPTX 转换为 SVG
---

## **概述**

本文介绍了如何使用 **C# 将 PowerPoint 演示文稿转换为 SVG 格式**。涵盖以下主题。

_Format_: **PowerPoint**
- [C# PowerPoint 转 SVG](#csharp-powerpoint-to-svg)
- [C# 将 PowerPoint 转换为 SVG](#csharp-powerpoint-to-svg)
- [C# 如何将 PowerPoint 文件转换为 SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT 转 SVG](#csharp-ppt-to-svg)
- [C# 将 PPT 转换为 SVG](#csharp-ppt-to-svg)
- [C# 如何将 PPT 文件转换为 SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX 转 SVG](#csharp-pptx-to-svg)
- [C# 将 PPTX 转换为 SVG](#csharp-pptx-to-svg)
- [C# 如何将 PPTX 文件转换为 SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP 转 SVG](#csharp-odp-to-svg)
- [C# 将 ODP 转换为 SVG](#csharp-odp-to-svg)
- [C# 如何将 ODP 文件转换为 SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# 将 PowerPoint 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 PPT 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 PPTX 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)
- [C# 将 ODP 幻灯片转换为 SVG](#render-a-slide-as-an-svg-image)

本文还涉及其他主题。
- [另请参阅](#see-also)

## **SVG 格式**
SVG（Scalable Vector Graphics）是一种用于渲染二维图像的标准图形类型或格式。SVG 以 XML 中的矢量方式存储图像，并包含定义其行为或外观的细节。

SVG 是为数不多的在以下方面符合极高标准的图像格式：可缩放性、交互性、性能、可访问性、可编程性等。因此，它在 Web 开发中被广泛使用。

当您需要时，可能会选择使用 SVG 文件：

- **以*超大尺寸*打印演示文稿。** SVG 图像可以无限放大，分辨率不受限制。您可以多次调整大小而不会降低质量。
- **在*不同媒介或平台*中使用幻灯片中的图表和图形。** 大多数阅读器都能正确解析 SVG 文件。
- **使用*尽可能小的图像体积*。** 与基于位图的高分辨率格式（如 JPEG 或 PNG）相比，SVG 文件通常更小。

## **将幻灯片呈现为 SVG 图像**

Aspose.Slides for .NET 允许将演示文稿中的幻灯片导出为 SVG 图像。按以下步骤生成 SVG 图像：

_Steps: PowerPoint to SVG Conversions in C#_

下面的示例代码演示了使用 .NET 进行这些转换的过程。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>步骤：在 C# 中将 PowerPoint 转换为 SVG</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>步骤：在 C# 中将 PPT 转换为 SVG</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>步骤：在 C# 中将 PPTX 转换为 SVG</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>步骤：在 C# 中将 ODP 转换为 SVG</strong></a>

_Code Steps:_

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
   * _.ppt_ 扩展名用于在 **Presentation** 类中加载 **PPT** 文件。
   * _.pptx_ 扩展名用于在 **Presentation** 类中加载 **PPTX** 文件。
   * _.odp_ 扩展名用于在 **Presentation** 类中加载 **ODP** 文件。
   * _.pps_ 扩展名用于在 **Presentation** 类中加载 **PPS** 文件。
2. 遍历演示文稿中的所有幻灯片。
3. 通过 FileStream 将每张幻灯片写入其各自的 SVG 文件。

{{% alert color="primary" %}} 

您可以尝试我们的[免费网络应用](https://products.aspose.app/slides/conversion/ppt-to-svg)，其中已经实现了 Aspose.Slides for .NET 的 PPT 转 SVG 功能。

{{% /alert %}} 

下面的 C# 示例代码演示了如何使用 Aspose.Slides 将 PowerPoint 转换为 SVG：
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


## **常见问答**

**导致不同浏览器中 SVG 显示差异的原因是什么？**

不同浏览器引擎对特定 SVG 功能的实现方式不同。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) 参数可帮助平滑这些不兼容。

**是否可以导出不仅是幻灯片，而是单独的形状为 SVG？**

可以。任何[形状都可以另存为单独的 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)，这对于图标、图示以及复用图形非常方便。

**能否将多张幻灯片合并为一个 SVG（条带/文档）？**

标准做法是一张幻灯片对应一个 SVG。将多张幻灯片合并到同一个 SVG 画布是应用层的后处理步骤。

## **另请参阅** 

本文还涵盖以下主题。代码与上述相同。

_Format_: **PowerPoint**
- [C# PowerPoint 转 SVG 代码](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转 SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转 SVG 编程方式](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转 SVG 库](#csharp-powerpoint-to-svg)
- [C# 将 PowerPoint 保存为 SVG](#csharp-powerpoint-to-svg)
- [C# 从 PowerPoint 生成 SVG](#csharp-powerpoint-to-svg)
- [C# 从 PowerPoint 创建 SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint 转 SVG 转换器](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT 转 SVG 代码](#csharp-ppt-to-svg)
- [C# PPT 转 SVG API](#csharp-ppt-to-svg)
- [C# PPT 转 SVG 编程方式](#csharp-ppt-to-svg)
- [C# PPT 转 SVG 库](#csharp-ppt-to-svg)
- [C# 将 PPT 保存为 SVG](#csharp-ppt-to-svg)
- [C# 从 PPT 生成 SVG](#csharp-ppt-to-svg)
- [C# 从 PPT 创建 SVG](#csharp-ppt-to-svg)
- [C# PPT 转 SVG 转换器](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX 转 SVG 代码](#csharp-pptx-to-svg)
- [C# PPTX 转 SVG API](#csharp-pptx-to-svg)
- [C# PPTX 转 SVG 编程方式](#csharp-pptx-to-svg)
- [C# PPTX 转 SVG 库](#csharp-pptx-to-svg)
- [C# 将 PPTX 保存为 SVG](#csharp-pptx-to-svg)
- [C# 从 PPTX 生成 SVG](#csharp-pptx-to-svg)
- [C# 从 PPTX 创建 SVG](#csharp-pptx-to-svg)
- [C# PPTX 转 SVG 转换器](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP 转 SVG 代码](#csharp-odp-to-svg)
- [C# ODP 转 SVG API](#csharp-odp-to-svg)
- [C# ODP 转 SVG 编程方式](#csharp-odp-to-svg)
- [C# ODP 转 SVG 库](#csharp-odp-to-svg)
- [C# 将 ODP 保存为 SVG](#csharp-odp-to-svg)
- [C# 从 ODP 生成 SVG](#csharp-odp-to-svg)
- [C# 从 ODP 创建 SVG](#csharp-odp-to-svg)
- [C# ODP 转 SVG 转换器](#csharp-odp-to-svg)