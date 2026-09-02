---
title: 在 .NET 中管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/net/manage-ink/
keywords:
- 墨水
- 墨水对象
- 墨迹
- 管理墨水
- 绘制墨水
- 绘图
- 墨水导出
- 墨水渲染
- 隐藏墨水
- IInkOptions
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理 PowerPoint 墨水对象，编辑痕迹和画笔属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨水外观。"
---
## **介绍**

PowerPoint 提供了一个墨水功能，允许您绘制自由笔画。墨水可用于突出显示其他对象、展示连接和流程，以及引起对幻灯片上特定项目的注意。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/) 命名空间包含处理墨水对象所需的类和接口。例如，[IInk](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iink/) 接口表示幻灯片上的墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。最简单的形式是，形状是一个容器，定义对象本身的区域（其框架）以及容器大小、形状和背景等属性。更多信息请参阅[形状布局格式](https://docs.aspose.com/slides/zh/net/shape-manipulations/#access-layout-formats-for-shape)。

但是，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，仅保留其大小。容器区域的大小由标准[IShape.Width](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/width/) 和[IShape.Height](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/height/) 属性决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹**

墨迹是用于记录用户书写数字墨水时笔尖轨迹的基本元素。墨迹存储一系列相连的点。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连的点时，会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图画笔属性**

画笔用于绘制连接墨迹点的线条。画笔拥有自己的颜色和大小，分别由[IInkBrush.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iinkbrush/color/) 和[IInkBrush.Size](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iinkbrush/size/) 属性表示。

### **设置墨水画笔颜色**

此 C# 代码示例展示如何设置墨水画笔的颜色：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **设置墨水画笔大小**

此 C# 代码示例展示如何设置墨水画笔的大小：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

通常，画笔的宽度和高度不匹配，PowerPoint 因此不显示画笔大小（对应的数据段为灰显）。当画笔的宽度和高度匹配时，PowerPoint 会如下显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为便于说明，我们增加墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不考虑画笔的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨水对象的可见区域，必须考虑其痕迹的画笔大小。在此示例中，目标对象（手写文本痕迹）已按容器（框架）的大小进行缩放。当容器大小改变时，画笔大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象使用了类似的行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **在导出和渲染期间控制墨水外观**

Aspose.Slides 提供[IInkOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/) 接口，以控制墨水对象在导出或渲染输出中的显示方式。您可以使用其属性完全隐藏墨水或更改墨水画笔遮罩操作的解释方式。

墨水选项可通过多种输出类型的导出或渲染选项进行设置：

| Output | Ink options property |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/renderingoptions/inkoptions/) |

这两个设置可通过上述属性进行配置：

- [`HideInk`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/hideink/) 决定是否在输出中包含墨水对象。默认值为`false`。
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) 决定在渲染墨水画笔时是否将遮罩操作解释为不透明度。默认值为`true`；将其设为`false` 可改用 ROP 操作。

### **在 PDF 输出中隐藏墨水对象**

默认情况下，导出时墨水对象保持可见。当需要无手写批注或其他墨水内容的干净输出时，将[IInkOptions.HideInk](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/hideink/) 设置为`true`。

下面的 C# 示例在导出为 PDF 时隐藏所有墨水对象：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **在将幻灯片渲染为图像时隐藏墨水对象**

要在将幻灯片渲染为位图图像时隐藏墨水对象，请配置[RenderingOptions.InkOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/renderingoptions/inkoptions/)，并将渲染选项传递给[ISlide.GetImage](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 方法。

下面的 C# 示例将第一张幻灯片渲染为不带墨水对象的 PNG 图像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **控制墨水遮罩渲染**

[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) 属性控制在渲染墨水画笔时遮罩操作的解释方式。默认值为`true`，使用不透明度。将该属性设为`false` 可改用 ROP 操作。

下面的 C# 示例将幻灯片导出为 SVG，并使用基于 ROP 的墨水遮罩渲染：

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

相同的设置也可通过[TiffOptions.InkOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/inkoptions/) 在导出为 TIFF 或渲染幻灯片时使用。

### **选择隐藏还是保留墨水**

当导出的文件应为带批注的演示文稿的干净版本（例如用于分发的最终副本）时，请将[IInkOptions.HideInk](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/hideink/) 设置为`true`。

如果墨水批注是预期内容的一部分（如审阅评论、手写笔记、突出显示或应保持可见的绘图），则保持[IInkOptions.HideInk](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/hideink/) 的默认值`false`。这使应用程序能够从同一演示文稿生成单独的审阅版和最终版，而无需修改源墨水对象。

## **常见问题**

**我可以更改现有墨水笔画的颜色或大小吗？**

可以。从[IInk.Traces](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iink/traces/) 获取痕迹，然后更改其[IInkTrace.Brush](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iinktrace/brush/)。您可以设置画笔的[IInkBrush.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iinkbrush/color/) 和[IInkBrush.Size](https://reference.aspose.com/slides/zh/net/aspose.slides.ink/iinkbrush/size/) 属性。

**隐藏墨水会改变源演示文稿吗？**

不会。[IInkOptions.HideInk](https://reference.aspose.com/slides/zh/net/aspose.slides.export/iinkoptions/hideink/) 仅影响渲染或导出结果；它不会删除或修改源演示文稿中的墨水对象。

**哪些导出格式支持墨水选项？**

您可以通过上表中相应的导出或渲染选项，为 PDF、HTML、SVG、TIFF 和幻灯片图像等格式配置墨水选项。

**进一步阅读**

* 要了解形状的整体概念，请参阅[PowerPoint 形状](https://docs.aspose.com/slides/zh/net/powerpoint-shapes/)章节。
* 有关有效值的更多信息，请参阅[形状有效属性](https://docs.aspose.com/slides/zh/net/shape-effective-properties/#get-effective-font-height-value)。
* 有关 PDF 导出的详细信息，请参阅[将 PPT 和 PPTX 转换为 PDF](https://docs.aspose.com/slides/zh/net/convert-powerpoint-to-pdf/)。
* 有关 HTML 导出的详细信息，请参阅[将 PowerPoint 演示文稿转换为 HTML](https://docs.aspose.com/slides/zh/net/convert-powerpoint-to-html/)。
* 有关 SVG 导出的详细信息，请参阅[将演示文稿幻灯片渲染为 SVG 图像](https://docs.aspose.com/slides/zh/net/render-a-slide-as-an-svg-image/)。
* 有关 TIFF 导出的详细信息，请参阅[将 PowerPoint 演示文稿转换为 TIFF](https://docs.aspose.com/slides/zh/net/convert-powerpoint-to-tiff/)。
* 有关幻灯片转图像渲染的详细信息，请参阅[将演示文稿幻灯片转换为图像](https://docs.aspose.com/slides/zh/net/convert-slide/)。