---
title: 在 Java 中管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/java/manage-ink/
keywords:
- 墨水
- 墨水对象
- 墨水轨迹
- 管理墨水
- 绘制墨水
- 绘图
- 墨水导出
- 墨水渲染
- 隐藏墨水
- IInkOptions
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理 PowerPoint 墨水对象，编辑轨迹和刷子属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨水外观。"
---
## **简介**

PowerPoint 提供了墨水功能，允许您绘制自由形状的笔画。墨水可用于突出显示其他对象，展示连接和流程，并吸引对幻灯片上特定项目的注意。

Aspose.Slides 提供了处理墨水对象所需的类型。例如，[IInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iink/) 接口表示幻灯片上的墨水对象。

## **普通对象和墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。最简单的形式中，形状是一个容器，定义对象本身的区域（其框架），以及容器大小、形状和背景等属性。更多信息请参阅[Shape Layout Format](https://docs.aspose.com/slides/zh/java/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，仅保留其大小。容器区域的大小由标准的[IShape.getWidth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getWidth--)和[IShape.getHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getHeight--)方法确定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

墨水轨迹是一种基本元素，用于记录用户书写数字墨水时笔的轨迹。轨迹保存一系列相连的点。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连点时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图刷属性**

刷子用于绘制连接墨水轨迹点的线条。刷子具有自己的颜色和大小，分别由[IInkBrush.getColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkbrush/#getColor--)和[IInkBrush.getSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkbrush/#getSize--)方法表示。

### **设置墨水刷颜色**

以下 Java 代码演示如何设置墨水刷的颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **设置墨水刷大小**

以下 Java 代码演示如何设置墨水刷的大小：

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

通常情况下，刷子的宽度和高度不一致，PowerPoint 因此不会显示刷子大小（相应的数据段呈灰色）。当刷子的宽度和高度相等时，PowerPoint 会如下方式显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们增大墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）并不考虑刷子的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨水对象的可见区域，必须考虑其轨迹刷子的大小。此处，目标对象（手写文本轨迹）已被缩放至容器（框架）的大小。当容器大小变化时，刷子大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象使用了类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制导出和渲染期间的墨水外观**

Aspose.Slides 提供[IInkOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/) 接口，以控制墨水对象在导出或渲染输出中的显示方式。您可以使用其属性来完全隐藏墨水或更改墨水刷遮罩操作的解释方式。

墨水选项可通过以下几种输出类型的导出或渲染选项进行设置：

| 输出 | 墨水选项属性 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| 幻灯片图像 | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/zh/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

以下[IInkOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/) 方法公开了相同的两个设置：

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#getHideInk--) 决定是否在输出中包含墨水对象。默认值为 `false`。
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 决定在渲染墨水刷时是否将遮罩操作解释为不透明度。默认值为 `true`；使用 `false` 调用[IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) 可改为使用 ROP 操作。

### **在 PDF 输出中隐藏墨水对象**

默认情况下，导出时墨水对象保持可见。若要创建不含手写批注或其他墨水内容的干净输出，请使用 `true` 调用[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

以下 Java 示例在导出为 PDF 时隐藏所有墨水对象：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **在将幻灯片渲染为图像时隐藏墨水对象**

若要在将幻灯片渲染为位图图像时隐藏墨水对象，请配置[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/renderingoptions/#getInkOptions--)，并将渲染选项传递给[ISlide.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-)。

以下 Java 示例将第一张幻灯片渲染为 PNG 图像且不包含墨水对象：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **控制墨水遮罩渲染**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 设置控制在渲染墨水刷时遮罩操作的解释方式。默认值为 `true`（使用不透明度）。若改为使用 ROP 操作，请使用 `false` 调用[IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

以下 Java 示例将幻灯片导出为 SVG，并使用基于 ROP 的墨水遮罩渲染：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

相同的设置也可以通过[TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tiffoptions/#getInkOptions--) 在导出为 TIFF 或渲染幻灯片时使用。

### **选择隐藏还是保留墨水**

当您需要为分发提供不含批注标记的干净版本时，请在导出期间使用 `true` 调用[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

如果墨水批注是预期内容的一部分（例如审阅评论、手写笔记、突出显示或应保留的绘图），则保持[IInkOptions.getHideInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#getHideInk--) 默认的 `false`。这样可在同一演示文稿中生成分别用于审阅和最终输出的文件，而无需修改源墨水对象。

## **常见问题**

**我可以更改已有墨水笔画的颜色或大小吗？**

可以。先通过[IInk.getTraces](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iink/#getTraces--) 获取轨迹，然后更改其[IInkTrace.getBrush](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinktrace/#getBrush--)。调用[IInkBrush.setColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-)或[IInkBrush.setSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-)即可更改刷子。

**隐藏墨水会改变源演示文稿吗？**

不会。调用[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 只影响渲染或导出结果；它不会删除或修改源演示文稿中的墨水对象。

**哪些导出格式支持墨水选项？**

您可以在上述表格中对应的导出或渲染选项里为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨水选项。

**进一步阅读**

* 欲了解一般形状，请参阅[PowerPoint Shapes](https://docs.aspose.com/slides/zh/java/powerpoint-shapes/)章节。
* 有关有效值的更多信息，请参阅[Shape Effective Properties](https://docs.aspose.com/slides/zh/java/shape-effective-properties/#get-effective-font-height-value)。
* 有关 PDF 导出的详细信息，请参阅[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh/java/convert-powerpoint-to-pdf/)。
* 有关 HTML 导出的详细信息，请参阅[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh/java/convert-powerpoint-to-html/)。
* 有关 SVG 导出的详细信息，请参阅[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh/java/render-a-slide-as-an-svg-image/)。
* 有关 TIFF 导出的详细信息，请参阅[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh/java/convert-powerpoint-to-tiff/)。
* 有关幻灯片渲染为图像的详细信息，请参阅[Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh/java/convert-slide/).