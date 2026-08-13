---
title: 在 Java 中更改演示文稿幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/java/slide-size/
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
- Java
- Aspose.Slides
description: "了解如何使用 Java 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，在不失真的情况下为任何屏幕优化演示文稿。"
---
## **简介**

Aspose.Slides 提供全面的工具来调整 PowerPoint 演示文稿的幻灯片大小和宽高比，这对打印和屏幕显示都至关重要。 

常用幻灯片尺寸和比例：

- **标准 (4:3 宽高比)**：适用于较旧的屏幕和设备。
- **宽屏 (16:9 宽高比)**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为单一的幻灯片尺寸和宽高比适用于所有幻灯片。为了获得最佳效果，请在演示文稿创建过程的开始设置幻灯片尺寸，以避免后续的复杂情况。

{{% alert color="info" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

## **更改演示文稿中的幻灯片大小**

此示例代码展示了如何使用 Aspose.Slides 在 Java 中更改演示文稿的幻灯片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上从演示文稿中打印全尺寸幻灯片，或打算在某些屏幕类型上显示演示文稿，使用自定义尺寸设置可能会受益。

此示例代码展示了如何使用 Aspose.Slides for Java 在 Java 中为演示文稿指定自定义幻灯片尺寸：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片大小后，幻灯片的内容（例如图像或对象）可能会失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片大小时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图或目标，您可以使用以下任意设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您想缩小到较小的幻灯片尺寸并且需要 Aspose.Slides 将幻灯片对象缩小以确保它们全部适合幻灯片（这样可以避免内容丢失），请使用此设置。 

- `Maximize`

  如果您想放大到更大的幻灯片尺寸并且需要 Aspose.Slides 将幻灯片对象放大以使其与新幻灯片尺寸成比例，请使用此设置。 

此示例代码展示了在更改演示文稿幻灯片大小时如何使用 `Maximize` 设置：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

### 我可以使用除英寸以外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？

是的。Aspose.Slides 在内部使用点（point），1 point 等于 1/72 英寸。您可以将任意单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

### 非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？

是的。较大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。应选择实用的幻灯片尺寸，仅在需要时调整渲染比例以获得所需的输出质量。

### 我可以定义一种非标准幻灯片尺寸，然后合并具有不同尺寸的演示文稿的幻灯片吗？

当幻灯片尺寸不同，您无法[合并演示文稿](/slides/zh/java/merge-presentation/) — 首先，将一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可在保留格式的情况下合并幻灯片。

### 我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？

是的。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[选定形状](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/#getImage-int-float-float-)渲染缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状保持一致。