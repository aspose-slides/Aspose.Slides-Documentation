---
title: 在 Android 上更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/androidjava/slide-size/
keywords:
- 幻灯片尺寸
- 纵横比
- 标准
- 宽屏
- 4:3
- 16:9
- 设置幻灯片尺寸
- 更改幻灯片尺寸
- 自定义幻灯片尺寸
- 特殊幻灯片尺寸
- 独特幻灯片尺寸
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
description: "使用 Java 和 Aspose.Slides for Android 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，优化演示文稿以适应任何屏幕而不失真。"
---
## **介绍**

Aspose.Slides 提供全面的工具来调整 PowerPoint 演示文稿的幻灯片尺寸和纵横比，这对打印和屏幕显示都至关重要。

常见幻灯片尺寸和比例：

- **标准（4:3 纵横比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 纵横比）**：推荐用于现代投影仪和显示器。

在整个演示文稿中保持一致性，因为单一的幻灯片尺寸和纵横比会应用于所有幻灯片。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以避免后续复杂问题。

{{% alert color="info" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 纵横比。
{{% /alert %}}

## **在演示文稿中更改幻灯片大小**

 以下示例代码展示了如何使用 Java 通过 Aspose.Slides 更改演示文稿的幻灯片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在演示文稿中指定自定义幻灯片大小**

如果常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，要在自定义页面布局上完整打印幻灯片，或在某些类型的屏幕上显示演示文稿时，使用自定义尺寸设置通常会带来优势。

以下示例代码展示了如何使用 Android 版 Aspose.Slides（通过 Java）在 Java 中为演示文稿指定自定义幻灯片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 纸张大小
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **调整大小后处理幻灯片内容**

更改演示文稿的幻灯片大小后，幻灯片上的内容（如图像或对象）可能会出现扭曲。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片大小时，您可以指定一个设置，决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可以使用以下任意设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您要缩小幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象向下缩放以确保全部适配到幻灯片上（从而避免内容丢失），请使用此设置。

- `Maximize`

  如果您要放大幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象放大以匹配新的幻灯片尺寸，请使用此设置。

以下示例代码展示了在更改演示文稿幻灯片大小时使用 `Maximize` 设置的方法：

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

### 我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片大小吗？

可以。Aspose.Slides 在内部使用点（point），1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

### 非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？

会。更大的幻灯片尺寸（以点为单位）配合更高的渲染比例会导致内存消耗增加和处理时间延长。建议使用实际可行的幻灯片尺寸，并仅在需要达到特定输出质量时调整渲染比例。

### 我能定义一种非标准幻灯片尺寸，然后合并具有不同尺寸的演示文稿的幻灯片吗？

在不同尺寸的演示文稿之间无法直接[merge presentations](/slides/zh/androidjava/merge-presentation/)。首先，需要将其中一个演示文稿的尺寸调整为与另一个相匹配。更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidesizescaletype/)选项指定现有内容的处理方式。对齐尺寸后，即可在保持格式的前提下合并幻灯片。

### 我可以为幻灯片的单个形状或特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？

可以。Aspose.Slides 能够为[entire slides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[selected shapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)生成缩略图。生成的图像会反映当前的幻灯片尺寸和纵横比，确保框架和几何形状保持一致。