---
title: 在 JavaScript 中更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/nodejs-java/slide-size/
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
- 特殊幻灯片尺寸
- 唯一幻灯片尺寸
- 全尺寸幻灯片
- 屏幕类型
- 不缩放
- 确保适配
- 最大化
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Node.js 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片尺寸，在任意屏幕上优化演示文稿且不损失质量。"
---
## **简介**

Aspose.Slides 提供全面的工具来调整 PowerPoint 演示文稿的幻灯片尺寸和宽高比，这对于打印和屏幕显示都至关重要。 

常用幻灯片尺寸和比例：

- **标准（4:3 宽高比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为所有幻灯片都使用相同的尺寸和宽高比。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以避免后续出现问题。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

## **在演示文稿中更改幻灯片尺寸**

以下示例代码展示了如何使用 Aspose.Slides 在 JavaScript 中更改演示文稿的幻灯片尺寸：

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果您发现常用的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片尺寸。例如，若您计划在自定义页面布局上打印全尺寸幻灯片，或希望在特定类型的屏幕上展示演示文稿，使用自定义尺寸设置将对您有所帮助。 

以下示例代码展示了如何通过 Node.js 的 Aspose.Slides（使用 Java）在 JavaScript 中为演示文稿指定自定义幻灯片尺寸：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 纸张尺寸
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **更改演示文稿幻灯片尺寸时处理问题**

在更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会出现变形。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改幻灯片尺寸时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。 

根据您的需求或目标，您可以使用以下任意设置：

- `DoNotScale`

  如果您 **不** 想让幻灯片上的对象被缩放，请使用此设置。

- `EnsureFit`

  如果您希望缩放到更小的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小以确保它们全部适配幻灯片（从而避免内容丢失），请使用此设置。 

- `Maximize`

  如果您希望缩放到更大的幻灯片尺寸，并且需要 Aspose.Slides 放大幻灯片对象以使其与新的幻灯片尺寸成比例，请使用此设置。 

以下示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `Maximize` 设置：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

是的。Aspose.Slides 在内部使用点（point）作为单位，1 point 等于 1/72 英寸。您可以将任意单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

是的。较大的幻灯片尺寸（以点为单位）以及更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要时调整渲染比例以实现所需的输出质量。

**我可以定义一种非标准的幻灯片尺寸，然后合并来自不同尺寸的演示文稿的幻灯片吗？**

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/nodejs-java/merge-presentation/)。首先，需要将其中一个演示文稿的尺寸调整为与另一个相匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidesizescaletype/)选项来选择如何处理现有内容。尺寸对齐后，您即可在保留格式的情况下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？**

是的。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getImage)以及[选定的形状](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getImage)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状保持一致。