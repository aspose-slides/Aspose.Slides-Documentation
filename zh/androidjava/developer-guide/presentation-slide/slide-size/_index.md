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
descriptions: "使用 Java 和 Aspose.Slides for Android 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片尺寸，优化演示文稿以适配任何屏幕且不失真。"
---

## **PowerPoint 演示文稿中的幻灯片大小**

Aspose.Slides for Android via Java 允许您更改 PowerPoint 演示文稿中的幻灯片大小或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则需要注意幻灯片的大小或宽高比。

以下是最常见的幻灯片大小和宽高比：

- **标准（4:3 宽高比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或观看，您可能希望使用此设置。

- **宽屏（16:9 宽高比）**

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能希望使用此设置。

在同一演示文稿中不能使用多种幻灯片大小设置。当您为演示文稿选择幻灯片大小时，该大小设置会应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特殊的幻灯片大小，我们强烈建议您尽早进行设置。理想情况下，您应在演示文稿的起始阶段（即仅在设置演示文稿时，还未添加任何内容之前）指定首选的幻灯片大小。这样可以避免因以后更改幻灯片大小而导致的复杂情况。

{{% alert color="primary" %}} 

 使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动采用标准大小或 4:3 宽高比。

{{% /alert %}} 

## **在演示文稿中更改幻灯片大小**

 此示例代码展示了如何在 Java 中使用 Aspose.Slides 更改演示文稿的幻灯片大小：
```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **在演示文稿中指定自定义幻灯片大小**

如果您发现常用的幻灯片大小（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片大小。例如，如果您计划在自定义页面布局上打印全尺寸幻灯片，或打算在某些类型的屏幕上显示演示文稿，则使用自定义大小设置可能会受益。

此示例代码展示了如何在 Java 中使用 Aspose.Slides for Android via Java 为演示文稿指定自定义幻灯片大小：
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

在更改演示文稿的幻灯片大小后，幻灯片的内容（如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片大小。然而，在更改演示文稿的幻灯片大小时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，您可以使用以下任意设置：

- `DoNotScale`

  如果您 **不** 想让幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您想缩小到更小的幻灯片大小，并且需要 Aspose.Slides 缩小幻灯片对象以确保它们全部适配到幻灯片上（这样可以避免内容丢失），请使用此设置。

- `Maximize`

  如果您想放大到更大的幻灯片大小，并且需要 Aspose.Slides 放大幻灯片对象使其与新幻灯片大小保持比例，请使用此设置。

此示例代码展示了在更改演示文稿幻灯片大小时如何使用 `Maximize` 设置：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片大小吗？**

可以。Aspose.Slides 在内部使用点作为单位，1 点等于 1/72 英寸。您可以将任何单位（如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片大小会影响渲染时的性能和内存使用吗？**

会。更大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可用的幻灯片大小，并仅在需要达到所需输出质量时调整渲染比例。

**我能定义一种非标准幻灯片大小，然后合并来自不同大小演示文稿的幻灯片吗？**

在幻灯片大小不同的情况下，您不能[合并演示文稿](/slides/zh/androidjava/merge-presentation/)——首先需要将其中一个演示文稿的大小调整为与另一个匹配。更改幻灯片大小时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐大小后，您即可在保留格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片大小吗？**

可以。Aspose.Slides 能够渲染[整个幻灯片](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)的缩略图，也能渲染[选定形状](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)的缩略图。生成的图像会反映当前的幻灯片大小和宽高比，确保框架和几何形状一致。