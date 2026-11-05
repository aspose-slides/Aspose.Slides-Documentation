---
title: 更改 Android 上的演示文稿幻灯片大小
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
description: "快速使用 Java 和 Aspose.Slides for Android 调整 PPT、PPTX 和 ODP 文件的幻灯片大小，优化演示文稿以适配任何屏幕且不失真。"
---
## **介绍**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片大小和宽高比，这对于打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 宽高比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为单一的幻灯片大小和宽高比适用于所有幻灯片。为了获得最佳效果，请在创建演示文稿的过程开始时设置幻灯片尺寸，以避免后续的复杂情况。

{{% alert color="info" title="Note" %}}
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 宽高比。
{{% /alert %}}

备注页和讲义页的尺寸与普通幻灯片不同。请参阅[备注页大小](/slides/zh/androidjava/notes-size/)以更改其尺寸和方向。

## **在演示文稿中更改幻灯片大小**

以下示例代码演示了如何在 Java 中使用 Aspose.Slides 更改演示文稿的幻灯片大小：

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

如果常用的幻灯片尺寸（4:3 和 16:9）不适合您的需求，您可以选择使用特定或独特的幻灯片尺寸。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或在特定类型的屏幕上展示演示文稿时，使用自定义尺寸设置会带来优势。

以下示例代码演示了如何通过 Java 使用 Aspose.Slides for Android 为演示文稿指定自定义幻灯片大小：

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

更改演示文稿的幻灯片大小后，幻灯片中的内容（如图像或对象）可能会出现变形。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。不过，在更改幻灯片大小时，您可以指定一个设置，决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可使用以下任意设置：

- `DoNotScale`  
  如果您 **不希望** 幻灯片上的对象被缩放，请使用此设置。

- `EnsureFit`  
  如果您希望缩小幻灯片尺寸，并且需要 Aspose.Slides 将对象缩小以确保它们全部适合幻灯片（从而避免内容丢失），请使用此设置。

- `Maximize`  
  如果您希望放大幻灯片尺寸，并且需要 Aspose.Slides 将对象放大以保持与新幻灯片尺寸的比例，请使用此设置。

以下示例代码演示了在更改演示文稿幻灯片大小时使用 `Maximize` 设置：

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

**我可以使用除英寸之外的单位（例如磅或毫米）设置自定义幻灯片大小吗？**

可以。Aspose.Slides 在内部使用磅（point），1 磅等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为磅，然后使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。更大的幻灯片尺寸（以磅为单位）结合更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

**我可以定义一种非标准幻灯片尺寸，然后合并具有不同尺寸的演示文稿吗？**

在幻灯片尺寸不同的情况下，您无法直接[合并演示文稿](/slides/zh/androidjava/merge-presentation/)。请先将其中一个演示文稿的尺寸调整为与另一个匹配。更改幻灯片大小时，可通过 [SlideSizeScaleType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidesizescaletype/) 选项选择如何处理现有内容。尺寸统一后，即可合并幻灯片并保持格式。

**我能为单个形状或幻灯片的特定区域生成缩略图，并且它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[选定形状](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状的一致性。