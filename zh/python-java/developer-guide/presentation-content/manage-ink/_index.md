---
title: 通过 Java 的 Python 管理演示文稿墨迹对象
linktitle: 管理墨迹
type: docs
weight: 95
url: /zh/python-java/manage-ink/
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
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 管理 PowerPoint 墨迹对象，编辑轨迹和笔刷属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨迹外观。"
---
## **简介**

PowerPoint 提供了墨迹功能，允许您绘制自由形式的笔画。墨迹可用于突出显示其他对象、展示连接和流程，以及吸引对幻灯片中特定项目的注意。

Aspose.Slides 提供了处理墨迹对象所需的类型。例如， [Ink](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ink/) 类表示幻灯片上的墨迹对象。

## **常规对象与墨迹对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。最简单的形式中，形状是一个容器，定义对象本身的区域（其框架），以及容器大小、形状和背景等属性。欲了解更多信息，请参阅 [Shape Layout Format](/slides/zh/python-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨迹对象时，它会忽略对象框架（容器）的所有属性，除尺寸外。容器区域的大小由标准的 [Shape.getWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getWidth) 和 [Shape.getHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getHeight) 方法决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹轨迹**

墨迹轨迹是用于记录用户书写数字墨迹时笔的轨迹的基本元素。轨迹存储一系列相连的点。

最简的编码形式指定每个采样点的 X 和 Y 坐标。当所有相连的点被渲染时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图笔刷属性**

笔刷用于绘制连接墨迹轨迹点的线条。笔刷具有自己的颜色和大小，分别由 [InkBrush.getColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkbrush/#getColor) 和 [InkBrush.getSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkbrush/#getSize) 方法表示。

### **设置墨迹笔刷颜色**

以下 Python 代码展示了如何设置墨迹笔刷的颜色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **设置墨迹笔刷大小**

以下 Python 代码展示了如何设置墨迹笔刷的大小：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

通常，笔刷的宽度和高度不匹配，PowerPoint 因此不显示笔刷尺寸（相应的数据段显示为灰色）。当笔刷的宽度和高度匹配时，PowerPoint 会如下显示其尺寸：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们将增加墨迹对象的高度，并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨迹对象的可见区域，必须考虑其轨迹的笔刷大小。在此，目标对象（手写文本轨迹）已被缩放至容器（框架）的尺寸。当容器尺寸变化时，笔刷尺寸保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象也使用类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **在导出和渲染期间控制墨迹外观**

Aspose.Slides 提供了 [InkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/) 类，以控制墨迹对象在导出或渲染输出中的显示方式。您可以使用其属性完全隐藏墨迹或更改墨迹笔刷遮罩操作的解释方式。

墨迹选项可通过多种输出类型的导出或渲染选项获得：

| 输出 | 墨迹选项属性 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| 幻灯片图像 | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/#getInkOptions) |

以下 [InkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/) 方法提供了相同的两个设置：

- [getHideInk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#getHideInk) 决定是否在输出中包含墨迹对象。默认值为 `False`。
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 决定在渲染墨迹笔刷时是否将遮罩操作解释为不透明度。默认值为 `True`；如需改为使用 ROP 操作，请使用 `False` 调用 [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)。

### **在 PDF 输出中隐藏墨迹对象**

默认情况下，导出时墨迹对象保持可见。若要生成没有手写批注或其他墨迹内容的干净输出，请使用 `True` 调用 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#setHideInk)。

以下 Python 示例将演示文稿导出为 PDF，并隐藏所有墨迹对象：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **在将幻灯片渲染为图像时隐藏墨迹对象**

要在将幻灯片渲染为位图图像时隐藏墨迹对象，请配置 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/renderingoptions/#getInkOptions) 并将渲染选项传递给 [Slide.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)。

以下 Python 示例将第一张幻灯片渲染为不包含墨迹对象的 PNG 图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **控制墨迹遮罩渲染**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 设置控制在渲染墨迹笔刷时遮罩操作的解释方式。默认值为 `True`，即使用不透明度。若改为使用 ROP 操作，请使用 `False` 调用 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)。

以下 Python 示例将幻灯片导出为 SVG，并对墨迹遮罩操作使用基于 ROP 的渲染方式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

相同的设置也可通过 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#getInkOptions) 在导出演示文稿或将幻灯片渲染为 TIFF 时使用。

### **选择隐藏或保留墨迹**

当您需要一个没有审阅标记的干净注释版演示文稿以供分发时，请在导出时使用 `True` 调用 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#setHideInk)。

如果墨迹批注是预期内容的一部分（例如审阅评论、手写笔记、突出显示或应在导出结果中保持可见的绘图），请保持 [InkOptions.getHideInk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#getHideInk) 的默认值 `False`。这样，应用程序即可在不修改源墨迹对象的情况下，从同一演示文稿生成审阅版和最终版的独立输出。

## **常见问题**

**我可以更改已有墨迹笔画的颜色或大小吗？**

可以。通过 [Ink.getTraces](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ink/#getTraces) 获取轨迹，然后更改其 [InkTrace.getBrush](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inktrace/#getBrush)。调用 [InkBrush.setColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkbrush/#setColor) 或 [InkBrush.setSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkbrush/#setSize) 即可更改笔刷。

**隐藏墨迹会更改源演示文稿吗？**

不会。调用 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh/python-java/aspose.slides/inkoptions/#setHideInk) 仅影响渲染或导出的结果；它不会从源演示文稿中删除或修改墨迹对象。

**哪些导出格式支持墨迹选项？**

您可以通过上表中的相应导出或渲染选项，为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨迹选项。

**进一步阅读**

* 了解形状的通用信息，请参阅 [PowerPoint Shapes](/slides/zh/python-java/powerpoint-shapes/) 部分。
* 欲了解有效值的更多信息，请查看 [Shape Effective Properties](/slides/zh/python-java/shape-effective-properties/#get-effective-font-height-value)。
* 关于 PDF 导出的详细信息，请参阅 [Convert PPT and PPTX to PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)。
* 关于 HTML 导出的详细信息，请参阅 [Convert PowerPoint Presentations to HTML](/slides/zh/python-java/convert-powerpoint-to-html/)。
* 关于 SVG 导出的详细信息，请参阅 [Render Presentation Slides as SVG Images](/slides/zh/python-java/render-a-slide-as-an-svg-image/)。
* 关于 TIFF 导出的详细信息，请参阅 [Convert PowerPoint Presentations to TIFF](/slides/zh/python-java/convert-powerpoint-to-tiff/)。
* 关于幻灯片到图像的渲染详情，请参阅 [Convert Presentation Slides to Images](/slides/zh/python-java/convert-slide/).