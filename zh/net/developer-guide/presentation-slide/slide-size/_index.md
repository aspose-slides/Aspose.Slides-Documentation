---
title: 在 .NET 中更改演示文稿幻灯片大小
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
descriptions: "了解如何使用 .NET 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，在任何屏幕上优化演示文稿而不失真。"
---

## **自定义演示文稿中的幻灯片尺寸和宽高比**

Aspose.Slides for .NET 提供了全面的工具，用于在 PowerPoint 演示文稿中调整幻灯片尺寸和宽高比，这对打印和屏幕显示都至关重要。

### **常用幻灯片尺寸和比例**

- **标准（4:3 宽高比）**：适用于旧屏幕和设备。  
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为单一的幻灯片尺寸和宽高比适用于所有幻灯片。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以避免后续问题。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

## **如何更改演示文稿的幻灯片尺寸**

以下示例演示如何使用 Aspose.Slides 在 C# 中更改演示文稿的幻灯片尺寸：
```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```


## **指定自定义幻灯片尺寸**

根据特定需求定制幻灯片尺寸，例如独特的纸张布局或屏幕规格，可能会带来优势。以下演示如何使用 Aspose.Slides for .NET 设置自定义幻灯片尺寸：
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张尺寸
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```


## **调整大小后处理幻灯片内容**

尺寸调整后，幻灯片内容可能会失真。您可以控制 Aspose.Slides 如何处理此类调整：

- **`DoNotScale`**：保持对象原始大小，以避免缩放。  
- **`EnsureFit`**：缩放对象以适配较小的幻灯片，防止内容丢失。  
- **`Maximize`**：放大对象以适配更大的幻灯片，保持美观一致性。

以下示例演示如何使用 `Maximize` 设置进行幻灯片尺寸调整：
```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```


## **常见问题**

**我可以使用除英寸以外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用点（point），1 point 等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，并使用转换后的值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）配合更高的渲染比例会导致内存消耗增加和处理时间延长。请保持幻灯片尺寸在实际可接受范围内，仅在需要达到所需输出质量时调整渲染比例。

**我可以定义一种非标准的幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

在幻灯片尺寸不同的情况下，无法[merge presentations](/slides/zh/net/merge-presentation/)——首先将其中一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可合并幻灯片并保留格式。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 可以渲染[entire slides](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/)以及[selected shapes](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)的缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保构图和几何形状保持一致。