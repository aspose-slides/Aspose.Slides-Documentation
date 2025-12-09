---
title: 幻灯片尺寸
type: docs
weight: 70
url: /zh/nodejs-java/slide-size/
---

## **PowerPoint 演示文稿中的幻灯片尺寸**

Aspose.Slides for Node.js via Java 允许您在 PowerPoint 演示文稿中更改幻灯片尺寸或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则必须注意其幻灯片尺寸或宽高比。

以下是最常见的幻灯片尺寸和宽高比：

- **Standard (4:3 aspect ratio)**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或观看，您可能希望使用此设置。

- **Widescreen (16:9 aspect ratio)** 

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能希望使用此设置。

一次演示文稿中不能使用多种幻灯片尺寸设置。选定演示文稿的幻灯片尺寸后，该尺寸设置会应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特殊的幻灯片尺寸，强烈建议您及早进行。理想情况下，您应在演示文稿的开头，即仅设置演示文稿时——在向演示文稿添加任何内容之前——指定首选的幻灯片尺寸。这样可以避免因（将来）更改幻灯片尺寸而导致的复杂情况。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动采用标准尺寸或 4:3 宽高比。

{{% /alert %}} 

## **在演示文稿中更改幻灯片尺寸**

 以下示例代码演示如何使用 Aspose.Slides（Node.js via Java）在 JavaScript 中更改演示文稿的幻灯片尺寸：
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

如果常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或希望在某些屏幕类型上显示演示文稿时，使用自定义尺寸设置可能会受益。

以下示例代码演示如何使用 Aspose.Slides for Node.js via Java 在 JavaScript 中为演示文稿指定自定义幻灯片尺寸：
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


## **更改演示文稿幻灯片尺寸时的处理问题**

更改演示文稿的幻灯片尺寸后，幻灯片内容（例如图像或对象）可能会失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求或目标，您可以使用以下任意设置：

- `DoNotScale`

  如果您 **不** 希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您要缩小至较小的幻灯片尺寸，并希望 Aspose.Slides 缩小幻灯片对象以确保它们全部适配幻灯片（从而避免内容丢失），请使用此设置。

- `Maximize`

  如果您要放大至较大的幻灯片尺寸，并希望 Aspose.Slides 放大幻灯片对象以使其与新的幻灯片尺寸保持比例，请使用此设置。

以下示例代码演示在更改演示文稿幻灯片尺寸时如何使用 `Maximize` 设置：
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


## **常见问题解答**

**是否可以使用英寸以外的单位（例如点或毫米）设置自定义幻灯片尺寸？**

可以。Aspose.Slides 在内部使用点，1 点等于 1/72 英寸。您可以将任何单位（如毫米或厘米）转换为点，并使用转换后的值来定义幻灯片宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点计）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请采用实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

**能否定义一种非标准幻灯片尺寸，然后合并拥有不同尺寸的演示文稿中的幻灯片？**

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/nodejs-java/merge-presentation/)。必须先将其中一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/)选项选择如何处理已有内容。对齐尺寸后，即可在保持格式的前提下合并幻灯片。

**是否可以为单个形状或幻灯片的特定区域生成缩略图，并且这些缩略图会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage)以及[选定形状](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保构图和几何保持一致。