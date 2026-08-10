---
title: 管理 PHP 中的演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/php-java/manage-ink/
keywords:
- 墨迹
- 墨迹对象
- 墨迹轨迹
- 管理墨迹
- 绘制墨迹
- 绘图
- 墨迹导出
- 墨迹渲染
- 隐藏墨迹
- InkOptions
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PowerPoint 墨迹对象，编辑轨迹和刷属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨迹外观。"
---
## **介绍**

PowerPoint 提供了一个墨迹功能，允许您绘制自由形式的笔画。墨迹可用于高亮其他对象、显示连接和流程，并吸引对幻灯片上特定项目的注意。

Aspose.Slides 提供了处理墨迹对象所需的类型。例如，[Ink](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ink/) 类表示幻灯片上的墨迹对象。

## **常规对象和墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 对象表示。最简单的形式中，形状是一个容器，定义对象本身的区域（其框架）以及容器大小、形状和背景等属性。有关更多信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/zh/php-java/shape-manipulations/#access-layout-formats-for-shape)。

但是，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，仅保留其大小。容器区域的大小由标准的 [Shape.getWidth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getWidth) 和 [Shape.getHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getHeight) 方法决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹轨迹**

墨迹轨迹是一种基本元素，用于记录用户书写数字墨迹时笔的轨迹。轨迹存储一系列连接的点。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当所有连接的点被渲染时，它们会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图刷属性**

刷用于绘制连接墨迹轨迹点的线。刷拥有自己的颜色和大小，分别由 [InkBrush.getColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkbrush/#getColor) 和 [InkBrush.getSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkbrush/#getSize) 方法表示。

### **设置墨迹刷颜色**

以下 PHP 代码展示了如何设置墨迹刷的颜色：

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **设置墨迹刷大小**

以下 PHP 代码展示了如何设置墨迹刷的大小：

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

通常，刷的宽度和高度不匹配，PowerPoint 不会显示刷的大小（相应的数据区段呈灰色）。当刷的宽度和高度匹配时，PowerPoint 会如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为清晰起见，我们将墨迹对象的高度增加，并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）并不考虑刷的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨迹对象的可见区域，必须考虑其轨迹的刷大小。这里，目标对象（手写文本轨迹）已按容器（框架）的大小进行缩放。当容器大小变化时，刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象也使用类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **在导出和渲染期间控制墨迹外观**

Aspose.Slides 提供了 [InkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/) 类，用于控制墨迹对象在导出或渲染输出中的显示方式。您可以使用其属性完全隐藏墨迹或更改墨迹刷遮罩操作的解释方式。

墨迹选项可通过多种输出类型的导出或渲染选项使用：

| 输出 | 墨迹选项属性 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| 幻灯片图像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/#getInkOptions) |

以下 [InkOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/) 方法公开相同的两个设置：

- [InkOptions.getHideInk](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/#getHideInk) 确定是否在输出中包含墨迹对象。默认值为 `false`。
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 确定在渲染墨迹刷时是否将遮罩操作解释为不透明度。默认值为 `true`；调用 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) 并传入 `false` 可改为使用 ROP 操作。

### **在 PDF 输出中隐藏墨迹对象**

默认情况下，墨迹对象在导出时保持可见。若要生成不含手写批注或其他墨迹内容的干净输出，请以 `true` 调用 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/#setHideInk)。

以下 PHP 示例将演示文稿导出为 PDF，同时隐藏所有墨迹对象：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **在将幻灯片渲染为图像时隐藏墨迹对象**

要在将幻灯片渲染为位图图像时隐藏墨迹对象，请配置 [RenderingOptions.getInkOptions] 并将渲染选项传递给 [Slide.getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage)。

以下 PHP 示例将第一张幻灯片渲染为 PNG 图像且不包含墨迹对象：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **控制墨迹遮罩渲染**

[InkOptions.getInterpretMaskOpAsOpacity] 设置控制在渲染墨迹刷时遮罩操作的解释方式。默认值为 `true`，使用不透明度。若要改为使用 ROP 操作，请以 `false` 调用 [InkOptions.setInterpretMaskOpAsOpacity]。

以下 PHP 示例将幻灯片导出为 SVG，并使用基于 ROP 的墨迹遮罩渲染：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

相同的设置也可以通过 [TiffOptions.getInkOptions] 在导出演示文稿或将幻灯片渲染为 TIFF 时使用。

### **选择隐藏或保留墨迹**

当您需要为分发提供一个不含审阅标记的干净注释版演示文稿时，请在导出时以 `true` 调用 [InkOptions.setHideInk]。

如果墨迹批注是预期内容的一部分（例如审阅评论、手写笔记、高亮或应在导出结果中保持可见的绘图），请保持 [InkOptions.getHideInk] 的默认值 `false`。这使得应用程序能够在同一演示文稿上生成分离的审阅版和最终版输出，而无需修改源墨迹对象。

## **常见问题**

**我可以更改现有墨迹笔画的颜色或大小吗？**

可以。先通过 [Ink.getTraces](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ink/#getTraces) 获取轨迹，然后更改其 [InkTrace.getBrush](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inktrace/#getBrush)。调用 [InkBrush.setColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkbrush/#setColor) 或 [InkBrush.setSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkbrush/#setSize) 来更改刷。

**隐藏墨迹会更改源演示文稿吗？**

不会。调用 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh/php-java/aspose.slides/inkoptions/#setHideInk) 仅影响渲染或导出结果；它不会删除或修改源演示文稿中的墨迹对象。

**哪些导出格式支持墨迹选项？**

您可以通过上表中相应的导出或渲染选项为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨迹选项。

**进一步阅读**

* 欲了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/zh/php-java/powerpoint-shapes/) 部分。  
* 有关有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/zh/php-java/shape-effective-properties/#get-effective-font-height-value)。  
* 有关 PDF 导出的详细信息，请参阅 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh/php-java/convert-powerpoint-to-pdf/)。  
* 有关 HTML 导出的详细信息，请参阅 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh/php-java/convert-powerpoint-to-html/)。  
* 有关 SVG 导出的详细信息，请参阅 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh/php-java/render-a-slide-as-an-svg-image/)。  
* 有关 TIFF 导出的详细信息，请参阅 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh/php-java/convert-powerpoint-to-tiff/)。  
* 有关幻灯片转图像渲染的详细信息，请参阅 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh/php-java/convert-slide/).