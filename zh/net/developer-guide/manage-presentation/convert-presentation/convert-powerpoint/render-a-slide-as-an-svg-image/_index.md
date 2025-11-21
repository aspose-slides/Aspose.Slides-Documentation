---
title: 在 .NET 中将演示文稿幻灯片呈现为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿 转 SVG
- 幻灯片 转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- 将 PPT 保存为 SVG
- 将 PPTX 保存为 SVG
- 导出 PPT 为 SVG
- 导出 PPTX 为 SVG
- 渲染 幻灯片
- 转换 幻灯片
- 导出 幻灯片
- 矢量图像
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 将 PowerPoint 幻灯片呈现为 SVG 图像。通过简单的 C# 代码示例实现高质量的可视化。"
---

## **概述**

本文解释了如何使用 C# **将 PowerPoint 演示文稿转换为 SVG 格式**。它涵盖了以下主题。

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

本文还涉及以下主题。
- [参见](#see-also)

## **SVG 格式**
SVG——可伸缩矢量图形（Scalable Vector Graphics）的缩写——是一种用于呈现二维图像的标准图形类型或格式。SVG 在 XML 中以向量形式存储图像，并包含定义其行为或外观的细节。

SVG 是为数不多的能够在以下方面满足极高标准的图像格式：可伸缩性、交互性、性能、可访问性、可编程性等。因此，它在网页开发中被广泛使用。

当您需要时，可能希望使用 SVG 文件
- **以*非常大的尺寸*打印您的演示文稿**。
- **在*不同的媒介或平台*中使用幻灯片中的图表和图形**。
- **使用*尽可能最小*的图像尺寸**。

SVG 文件通常比其它格式的高分辨率等效文件更小，尤其是基于位图的格式（JPEG 或 PNG）。

## **将幻灯片渲染为 SVG 图像**

Aspose.Slides for .NET 允许您将演示文稿中的幻灯片导出为 SVG 图像。请按照以下步骤生成 SVG 图像：

_步骤：PowerPoint 转 SVG 转换（C#）_

下面的示例代码使用 .NET 解释这些转换。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>步骤：在 C# 中将 PowerPoint 转换为 SVG</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>步骤：在 C# 中将 PPT 转换为 SVG</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>步骤：在 C# 中将 PPTX 转换为 SVG</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>步骤：在 C# 中将 ODP 转换为 SVG</strong></a>

代码步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
   * _.ppt_ 扩展名用于在 _Presentation_ 类中加载 **PPT** 文件。
   * _.pptx_ 扩展名用于在 _Presentation_ 类中加载 **PPTX** 文件。
   * _.odp_ 扩展名用于在 _Presentation_ 类中加载 **ODP** 文件。
   * _.pps_ 扩展名用于在 _Presentation_ 类中加载 **PPS** 文件。
2. 遍历演示文稿中的所有幻灯片。
3. 通过 FileStream 将每张幻灯片写入各自的 SVG 文件。

{{% alert color="primary" %}} 
您可以尝试我们的[免费网络应用程序](https://products.aspose.app/slides/conversion/ppt-to-svg)，其中实现了来自 Aspose.Slides for .NET 的 PPT 转 SVG 转换功能。
{{% /alert %}} 

下面的 C# 示例代码展示了如何使用 Aspose.Slides 将 PowerPoint 转换为 SVG：
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


## **常见问题**

**为什么生成的 SVG 在不同浏览器中可能显示不同？**

不同浏览器引擎对特定 SVG 功能的实现方式不同。[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) 参数可帮助平滑这些不兼容性。

**是否可以导出不仅是幻灯片，还包括单个形状为 SVG？**

可以。任何[形状都可以另存为单独的 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)，这对于图标、示意图以及重复使用图形非常方便。

**是否可以将多个幻灯片合并为单个 SVG（条形图/文档）？**

标准情形是一张幻灯片对应一个 SVG。将多个幻灯片合并到单个 SVG 画布是需要在应用层进行的后处理步骤。

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