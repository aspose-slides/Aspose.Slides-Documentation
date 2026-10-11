---
title: .NET 中更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/net/slide-size/
keywords:
- 幻灯片尺寸
- 宽高比
- 标准
- 宽屏
- 4:3
- 16:9
- 设置幻灯片尺寸
- 更改幻灯片尺寸
- 自定义幻灯片尺寸
- 专用幻灯片尺寸
- 独特幻灯片尺寸
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
description: "了解如何使用 .NET 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，优化演示文稿以适配任何屏幕且不失真。"
---
## **介绍**

Aspose.Slides for .NET 提供了全面的工具来调整 PowerPoint 演示文稿中的幻灯片大小和宽高比，这对于打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 宽高比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为所有幻灯片都使用相同的幻灯片尺寸和宽高比。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以避免后续出现问题。

{{% alert color="info" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

备注页和讲义页的尺寸与普通幻灯片不同。请参阅[备注页面尺寸](/slides/zh/net/notes-size/)以更改其大小和方向。

## **如何更改演示文稿的幻灯片尺寸**

此示例演示了如何使用 Aspose.Slides 在 C# 中更改演示文稿的幻灯片尺寸：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **指定自定义幻灯片尺寸**

根据您的特定需求（例如独特的纸张布局或屏幕规格）定制幻灯片尺寸可能会有帮助。以下示例展示了如何在 .NET 中使用 Aspose.Slides 设置自定义幻灯片尺寸：

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

调整大小后，幻灯片内容可能会失真。您可以控制 Aspose.Slides 如何处理此类调整：

- **`DoNotScale`**：保持对象原始大小，以避免缩放。
- **`EnsureFit`**：将对象缩放以适应较小的幻灯片，防止内容丢失。
- **`Maximize`**：放大对象以适应更大的幻灯片，保持美观一致。

以下示例演示了在调整幻灯片尺寸时使用 `Maximize` 设置：

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **常见问题**

### 我可以使用除英寸之外的单位（例如点或毫米）来设置自定义幻灯片尺寸吗？

是的。Aspose.Slides 在内部使用点（points），其中 1 点等于 1/72 英寸。您可以将任何单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

### 非常大的自定义幻灯片尺寸会影响渲染期间的性能和内存使用吗？

是的。更大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。应选择实际可用的幻灯片尺寸，并仅在需要时调整渲染比例以获得所需的输出质量。

### 我能定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/net/merge-presentation/)——首先将其中一个演示文稿的尺寸调整为与另一个相同。更改幻灯片尺寸时，可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/net/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。尺寸对齐后，您即可在保持格式的前提下合并幻灯片。

### 我能为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？

是的。Aspose.Slides 可以渲染[整张幻灯片](https://reference.aspose.com/slides/zh/net/aspose.slides/slide/getimage/)的缩略图，也可以渲染[选定形状](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/getimage/)的缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状的一致性。