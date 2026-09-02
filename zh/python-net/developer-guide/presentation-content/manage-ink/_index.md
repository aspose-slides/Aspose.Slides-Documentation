---
title: 在 Python 中管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/python-net/manage-ink/
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
- InkOptions
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理 PowerPoint 墨水对象，编辑轨迹和笔刷属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨水外观。"
---
## **介绍**

PowerPoint 提供了墨水功能，允许您绘制自由形式的笔画。墨水可用于突出显示其他对象、展示连接和过程，以及吸引对幻灯片中特定项目的注意。

[aspose.slides.ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/) 名称空间包含处理墨水对象所需的类。例如，[Ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/ink/) 类表示幻灯片上的墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。在最简形式下，形状是一个容器，定义对象本身的区域（其框架），以及容器大小、形状和背景等属性。更多信息，请参阅 [Shape Layout Format](https://docs.aspose.com/slides/zh/python-net/shape-manipulations/#access-layout-formats-for-shape)。

但是，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，仅保留其大小。容器区域的大小由标准 [Ink.width](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/ink/width/) 和 [Ink.height](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/ink/height/) 属性决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨水轨迹**

墨水轨迹是一种基本元素，用于记录用户书写数字墨水时笔的轨迹。轨迹保存一系列相连的点。

最简的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连的点时，会产生如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图笔刷属性**

笔刷用于绘制连接墨水轨迹点的线。其 [InkBrush.color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/inkbrush/color/) 和 [InkBrush.size](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/inkbrush/size/) 属性控制颜色和大小。

### **设置墨水笔刷颜色**

下面的 Python 代码演示如何设置墨水笔刷的颜色：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **设置墨水笔刷大小**

下面的 Python 代码演示如何设置墨水笔刷的大小：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

通常，笔刷的宽度和高度不相等，因此 PowerPoint 不会显示笔刷大小（相应的数据段呈灰色）。当笔刷宽度和高度相等时，PowerPoint 会如下显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们将增加墨水对象的高度并查看重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑笔刷的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨水对象的可见区域，需要考虑其轨迹的笔刷大小。此处，目标对象（手写文本轨迹）已按容器（框架）的尺寸进行缩放。当容器尺寸改变时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象也采用类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制导出和渲染期间的墨水外观**

Aspose.Slides 提供了 [InkOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/) 类，用于控制墨水对象在导出或渲染输出中的显示方式。您可以使用其属性完全隐藏墨水或更改墨水笔刷掩码操作的解释方式。

墨水选项可通过多种输出类型的导出或渲染选项进行设置：

| 输出 | 墨水选项属性 |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/renderingoptions/ink_options/) |

这两个设置可以通过这些属性进行配置：

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/hide_ink/) 确定是否在输出中包含墨水对象。默认值为 `False`。
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 确定在渲染墨水笔刷时，掩码操作是否解释为不透明度。默认值为 `True`；将其设为 `False` 可改用 ROP 操作。

### **在 PDF 输出中隐藏墨水对象**

默认情况下，导出时墨水对象仍然可见。需要无手写批注或其他墨水内容的干净输出时，将 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/hide_ink/) 设置为 `True`。

下面的 Python 示例将演示如何在导出为 PDF 时隐藏所有墨水对象：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **在将幻灯片渲染为图像时隐藏墨水对象**

要在将幻灯片渲染为位图图像时隐藏墨水对象，请配置 [RenderingOptions.ink_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/renderingoptions/ink_options/) 并将渲染选项传递给 [Slide.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/) 方法。

下面的 Python 示例将首张幻灯片渲染为不含墨水对象的 PNG 图像：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **控制墨水掩码渲染**

[InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) 属性控制在渲染墨水笔刷时掩码操作的解释方式。默认值为 `True`，表示使用不透明度。将该属性设为 `False` 可改用 ROP 操作。

下面的 Python 示例将幻灯片导出为 SVG，并使用基于 ROP 的墨水掩码渲染方式：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

在导出为 TIFF 或渲染幻灯片为 TIFF 时，也可以通过 [TiffOptions.ink_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/ink_options/) 应用相同的设置。

### **选择隐藏或保留墨水**

当导出的文件应为带批注演示文稿的干净版本（例如，供发布而不含审阅标记的最终副本）时，将 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/hide_ink/) 设置为 `True`。

如果墨水批注是预期内容的一部分（如审阅评论、手写笔记、突出显示或应在导出结果中保持可见的绘图），请保持 [InkOptions.hide_ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/hide_ink/) 的默认值 `False`。这使得应用程序能够在不修改源墨水对象的情况下，从同一演示文稿生成独立的审阅版和最终版输出。

## **常见问题**

**我可以更改现有墨水笔画的颜色或大小吗？**

可以。从 [Ink.traces](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/ink/traces/) 获取轨迹，然后更改其 [InkTrace.brush](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/inktrace/brush/)。您可以设置笔刷的 [InkBrush.color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/inkbrush/color/) 和 [InkBrush.size](https://reference.aspose.com/slides/zh/python-net/aspose.slides.ink/inkbrush/size/) 属性。

**隐藏墨水会更改源演示文稿吗？**

不会。[InkOptions.hide_ink](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/inkoptions/hide_ink/) 仅影响渲染或导出的结果；它不会删除或修改源演示文稿中的墨水对象。

**哪些导出格式支持墨水选项？**

您可以通过上述相应的导出或渲染选项，为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨水选项。

**进一步阅读**

* 如需了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/zh/python-net/powerpoint-shapes/) 部分。
* 有关有效值的更多信息，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/zh/python-net/shape-effective-properties/#get-effective-font-height-value)。
* 有关 PDF 导出的详细信息，请参阅 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh/python-net/convert-powerpoint-to-pdf/)。
* 有关 HTML 导出的详细信息，请参阅 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh/python-net/convert-powerpoint-to-html/)。
* 有关 SVG 导出的详细信息，请参阅 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh/python-net/render-a-slide-as-an-svg-image/)。
* 有关 TIFF 导出的详细信息，请参阅 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh/python-net/convert-powerpoint-to-tiff/)。
* 有关幻灯片转图像渲染的详细信息，请参阅 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh/python-net/convert-slide/).