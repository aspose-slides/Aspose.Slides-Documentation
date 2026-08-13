---
title: 更改 .NET 中的演示文稿幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/net/slide-size/
keywords:
- 幻灯片大小
- 宽高比
- 标准
- 宽屏
- 4:3
- 16:9
- 设置幻灯片大小
- 更改幻灯片大小
- 自定义幻灯片大小
- 特殊幻灯片大小
- 独特幻灯片大小
- 全尺寸幻灯片
- 屏幕类型
- 不缩放
- 确保适配
- 最大化
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 .NET 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件的幻灯片大小，优化演示文稿以适配任何屏幕且不失真。"
---
## **介绍**

Aspose.Slides for .NET 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片大小和宽高比，这对打印和屏幕显示都至关重要。

常用幻灯片大小和比例：

- **Standard (4:3 Aspect Ratio)**：适用于较旧的屏幕和设备。
- **Widescreen (16:9 Aspect Ratio)**：推荐用于现代投影仪和显示器。

请确保整个演示文稿保持一致的幻灯片大小和宽高比，因为单一的尺寸和比例会应用于所有幻灯片。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以免后期出现复杂问题。

{{% alert color="info" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

## **如何在演示文稿中更改幻灯片大小**

以下示例演示如何使用 Aspose.Slides for .NET 在 C# 中更改演示文稿的幻灯片大小：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **指定自定义幻灯片大小**

根据您的特定需求（例如独特的纸张布局或屏幕规格）定制幻灯片大小可能会更有帮助。以下示例展示如何在 Aspose.Slides for .NET 中设置自定义幻灯片大小：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张尺寸
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **调整大小后处理幻灯片内容**

调整大小后，幻灯片内容可能会出现变形。您可以控制 Aspose.Slides 如何处理此类调整：

- **`DoNotScale`**：保持对象原始大小，避免缩放。
- **`EnsureFit`**：将对象缩放以适应较小的幻灯片，防止内容丢失。
- **`Maximize`**：放大对象以匹配较大的幻灯片，实现美观一致。

以下示例演示在调整幻灯片大小时使用 `Maximize` 设置：

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **常见问题**

### 我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片大小吗？

可以。Aspose.Slides 在内部使用点（point），1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，然后使用转换后的数值定义幻灯片的宽度和高度。

### 非常大的自定义幻灯片大小会影响渲染时的性能和内存使用吗？

会。更大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请设定实际可行的幻灯片大小，并仅在需要提升输出质量时调整渲染比例。

### 我能否定义一种非标准幻灯片大小，然后合并具有不同尺寸的演示文稿？

在不同幻灯片大小的情况下，您无法[合并演示文稿](/slides/zh/net/merge-presentation/)，必须首先将其中一个演示文稿的尺寸调整为匹配另一个。当更改幻灯片大小时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesizescaletype/) 选项选择如何处理已有内容。对齐尺寸后，您即可在保留格式的前提下合并幻灯片。

### 我能为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片大小吗？

可以。Aspose.Slides 能够为[整个幻灯片](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/)以及[选定形状](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage/)渲染缩略图。生成的图像会反映当前的幻灯片大小和宽高比，确保构图和几何形状的一致性。