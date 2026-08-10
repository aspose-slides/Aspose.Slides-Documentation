---
title: 管理 JavaScript 中的演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/nodejs-java/manage-ink/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理 PowerPoint 墨迹对象，编辑轨迹和画笔属性，并在 PDF、HTML、SVG、TIFF 和图像导出过程中控制墨迹外观。"
---
## **简介**

PowerPoint 提供了墨迹功能，允许您自由绘制笔画。墨迹可用于突出显示其他对象、展示连接和流程，并吸引对幻灯片中特定项目的注意。

Aspose.Slides 提供了处理墨迹对象所需的类型。例如，[Ink](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ink/) 类表示幻灯片上的墨迹对象。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。最简单的形式中，形状是一个容器，定义对象本身的区域（其框架），以及容器大小、形状和背景等属性。欲了解更多信息，请参阅[Shape Layout Format](https://docs.aspose.com/slides/zh/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，除了其大小。容器区域的大小由标准的[Shape.getWidth](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getWidth--)和[Shape.getHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getHeight--)方法决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹轨迹**

墨迹轨迹是用于记录用户书写数字墨迹时笔的轨迹的基本元素。轨迹存储一系列相连的点。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连的点时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图刷属性**

刷子用于绘制连接墨迹轨迹点的线条。刷子具有自己的颜色和大小，由[InkBrush.getColor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/inkbrush/#getColor--)和[InkBrush.getSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/inkbrush/#getSize--)方法表示。

### **设置墨迹刷颜色**

以下 JavaScript 代码演示如何设置墨迹刷的颜色：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **设置墨迹刷大小**

以下 JavaScript 代码演示如何设置墨迹刷的大小：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

通常情况下，刷子的宽度和高度不一致，因此 PowerPoint 不显示刷子大小（相应的数据段呈灰色）。当刷子的宽度和高度相匹配时，PowerPoint 会如下显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为清晰起见，我们将增加墨迹对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑刷子的大小——它始终假设线条厚度为零（见前图）。

因此，要确定整个墨迹对象的可见区域，必须考虑其轨迹的刷子大小。在此，目标对象（手写文本轨迹）已按容器（框架）的大小进行缩放。当容器大小改变时，刷子大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象也采用类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **导出和渲染期间控制墨迹外观**

Aspose.Slides 提供了[InkOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/inkoptions/)类，可控制墨迹对象在导出或渲染输出中的显示方式。您可以使用其属性完全隐藏墨迹或更改墨迹刷掩码操作的解释方式。

墨迹选项可通过多种输出类型的导出或渲染选项获得：

| 输出 | 墨迹选项属性 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

以下[InkOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/inkoptions/)方法公开相同的两个设置：

- `InkOptions.getHideInk` 确定是否在输出中包含墨迹对象。其默认值为 `false`。
- `InkOptions.getInterpretMaskOpAsOpacity` 确定在渲染墨迹刷时，掩码操作是否被解释为不透明度。其默认值为 `true`；调用 `InkOptions.setInterpretMaskOpAsOpacity` 并传入 `false` 可改用 ROP 操作。

### **在 PDF 输出中隐藏墨迹对象**

默认情况下，导出时墨迹对象仍然可见。要创建没有手写批注或其他墨迹内容的干净输出，请调用 `InkOptions.setHideInk` 并传入 `true`。

以下 JavaScript 示例将演示文稿导出为 PDF，同时隐藏所有墨迹对象：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **将幻灯片渲染为图像时隐藏墨迹对象**

要在将幻灯片渲染为位图图像时隐藏墨迹对象，请配置[RenderingOptions.getInkOptions]并将渲染选项传递给[Slide.getImage]。

以下 JavaScript 示例将第一张幻灯片渲染为不含墨迹对象的 PNG 图像：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **控制墨迹掩码渲染**

`InkOptions.getInterpretMaskOpAsOpacity` 设置控制在渲染墨迹刷时，掩码操作的解释方式。默认值为 `true`，使用不透明度。若改用 ROP 操作，请使用 `false` 调用 `InkOptions.setInterpretMaskOpAsOpacity`。

以下 JavaScript 示例将幻灯片导出为 SVG，并对墨迹掩码操作使用基于 ROP 的渲染：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

相同的设置也可以通过[TiffOptions.getInkOptions]在导出演示文稿或将幻灯片渲染为 TIFF 时使用。

### **选择隐藏或保留墨迹**

当您需要分发没有审阅标记的标注演示文稿的干净版本时，请在导出时调用 `InkOptions.setHideInk` 并传入 `true`。

如果墨迹批注是预期内容的一部分，如审阅评论、手写笔记、突出显示或应在导出结果中保持可见的绘图，请将 `InkOptions.getHideInk` 保持其默认值 `false`。这使得应用程序能够在同一演示文稿中生成分离的审阅版和最终版输出，而无需修改源墨迹对象。

## **常见问题**

**我可以更改现有墨迹笔画的颜色或大小吗？**

可以。从 `Ink.getTraces` 获取轨迹，然后更改其 `InkTrace.getBrush`。调用 `InkBrush.setColor` 或 `InkBrush.setSize` 来更改刷子。

**隐藏墨迹会更改源演示文稿吗？**

不会。调用 `InkOptions.setHideInk` 仅影响渲染或导出结果；它不会从源演示文稿中删除或修改墨迹对象。

**哪些导出格式支持墨迹选项？**

您可以通过上表中的相应导出或渲染选项，为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨迹选项。

**进一步阅读**

* 如需了解形状的常规信息，请参阅 [PowerPoint Shapes] 部分。
* 有关有效值的更多信息，请参阅 [Shape Effective Properties]。
* 有关 PDF 导出的详细信息，请参阅 [Convert PPT and PPTX to PDF]。
* 有关 HTML 导出的详细信息，请参阅 [Convert PowerPoint Presentations to HTML]。
* 有关 SVG 导出的详细信息，请参阅 [Render Presentation Slides as SVG Images]。
* 有关 TIFF 导出的详细信息，请参阅 [Convert PowerPoint Presentations to TIFF]。
* 有关将幻灯片渲染为图像的详细信息，请参阅 [Convert Presentation Slides to Images]。