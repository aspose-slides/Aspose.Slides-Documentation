---
title: 在 Android 上更改演示文稿幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
description: "使用 Java 和 Aspose.Slides for Android 快速调整 PPT、PPTX 和 ODP 文件的幻灯片大小，优化演示文稿以适配任何屏幕且不失真。"
---
## **介绍**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿中的幻灯片大小和宽高比，这对打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **Standard (4:3 Aspect Ratio)**：适用于较旧的屏幕和设备。
- **Widescreen (16:9 Aspect Ratio)**：推荐用于现代投影仪和显示器。

确保在整个演示文稿中保持一致，因为所有幻灯片使用相同的尺寸和宽高比。为获得最佳效果，请在创建演示文稿的早期设置幻灯片尺寸，以避免后续问题。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

## **更改演示文稿中的幻灯片尺寸**

以下示例代码展示了如何使用 Aspose.Slides 在 Java 中更改演示文稿的幻灯片尺寸：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上打印演示文稿的全尺寸幻灯片，或希望在特定类型的屏幕上显示演示文稿，那么使用自定义尺寸设置将对您有帮助。

以下示例代码展示了如何通过 Java 使用 Aspose.Slides for Android 为演示文稿指定自定义幻灯片尺寸：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张大小
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片尺寸后，幻灯片内容（例如图像或对象）可能会失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。但是，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图或目标，您可以使用以下任意设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被重新调整大小，请使用此设置。

- `EnsureFit`

  如果您希望缩放到较小的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小以确保它们全部适应幻灯片（从而避免内容丢失），请使用此设置。

- `Maximize`

  如果您希望缩放到较大的幻灯片尺寸，并且需要 Aspose.Slides 放大幻灯片对象，使其与新的幻灯片尺寸保持比例，请使用此设置。

以下示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `Maximize` 设置：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）来设置自定义幻灯片尺寸吗？**

是的。Aspose.Slides 在内部使用点（point），1 点等于 1/72 英寸。您可以将任何单位（例如毫米或厘米）转换为点，然后使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

是的。较大的幻灯片尺寸（以点为单位）以及更高的渲染比例会导致内存消耗增加和处理时间延长。请选取实际可用的幻灯片尺寸，并仅在需要时调整渲染比例，以实现所需的输出质量。

**我可以定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

当演示文稿的幻灯片尺寸不同且您尝试[合并演示文稿](/slides/zh/androidjava/merge-presentation/)时是不可行的——请先将其中一个演示文稿的尺寸调整为与另一个相匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidesizescaletype/)选项选择如何处理已有内容。对齐尺寸后，您即可在保留格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片尺寸吗？**

是的。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[选定的形状](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状的一致性。