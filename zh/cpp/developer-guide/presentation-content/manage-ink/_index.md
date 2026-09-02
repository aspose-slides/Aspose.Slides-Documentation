---
title: 在 C++ 中管理演示文稿墨水对象
linktitle: 管理墨水
type: docs
weight: 95
url: /zh/cpp/manage-ink/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 管理 PowerPoint 墨水对象，编辑轨迹和笔刷属性，并在 PDF、HTML、SVG、TIFF 和图像导出期间控制墨水外观。"
---
## **简介**

PowerPoint 提供了一项墨水功能，允许您绘制自由形式的笔画。墨水可用于突出显示其他对象、展示连接和流程，以及吸引对幻灯片中特定项目的注意。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/) 命名空间包含处理墨水对象所需的类和接口。例如，[IInk](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iink/) 接口表示幻灯片上的墨水对象。

## **常规对象与墨水对象的区别**

PowerPoint 幻灯片上的对象通常由形状对象表示。最简单的形式中，形状是一个容器，定义对象本身的区域（其框架），以及容器大小、形状和背景等属性。有关更多信息，请参阅[Shape Layout Format](https://docs.aspose.com/slides/zh/cpp/shape-manipulations/#access-layout-formats-for-shape)。

然而，当 PowerPoint 处理墨水对象时，它会忽略对象框架（容器）的所有属性，除非其大小。容器区域的大小由标准[IShape::get_Width](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_width/)和[IShape::get_Height](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_height/)方法决定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨迹**

墨迹是用于记录用户书写数字墨水时笔尖轨迹的基本元素。墨迹存储一系列相连的点。

最简单的编码形式指定每个采样点的 X 和 Y 坐标。当渲染所有相连的点时，它们会生成如下图像：

![ink_powerpoint2](ink_powerpoint2.png)

## **绘图笔刷属性**

笔刷用于绘制连接墨迹点的线条。笔刷具有自己的颜色和大小，由[IInkBrush::get_Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iinkbrush/get_color/)和[IInkBrush::get_Size](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iinkbrush/get_size/)方法表示。

### **设置墨水笔刷颜色**

此 C++ 代码示例展示如何设置墨水笔刷的颜色：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **设置墨水笔刷大小**

此 C++ 代码示例展示如何设置墨水笔刷的大小：

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

通常，笔刷的宽度和高度不相等，PowerPoint 不会显示笔刷大小（对应的数据段呈灰色）。当笔刷宽度和高度相等时，PowerPoint 会这样显示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

为清晰起见，让我们增加墨水对象的高度并查看重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）并不考虑笔刷的大小——它始终假设线条粗细为零（见前图）。

因此，要确定整个墨水对象的可见区域，必须考虑其轨迹的笔刷大小。此处，目标对象（手写文字轨迹）已缩放至容器（框架）的大小。当容器大小更改时，笔刷大小保持不变，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 对文本对象也采用类似行为：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制导出和渲染期间的墨水外观**

Aspose.Slides 提供[IInkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/) 接口，以控制墨水对象在导出或渲染输出中的显示方式。您可以使用其方法完全隐藏墨水或更改墨水笔刷遮罩操作的解释方式。

墨水选项可通过多种输出类型的导出或渲染选项获得：

| 输出 | 墨水选项方法 |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| 幻灯片图像 | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

这两项设置可通过上述方法进行配置：

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_hideink/) 决定是否在输出中包含墨水对象。默认值为 `false`。
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 决定在渲染墨水笔刷时是否将遮罩操作解释为不透明度。默认值为 `true`；将其设为 `false` 可改用 ROP 操作。

### **在 PDF 输出中隐藏墨水对象**

默认情况下，导出时墨水对象保持可见。需要无手写批注或其他墨水内容的干净输出时，请以 `true` 调用[IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_hideink/)。

以下 C++ 示例在导出为 PDF 时隐藏所有墨水对象：

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **在将幻灯片渲染为图像时隐藏墨水对象**

要在将幻灯片渲染为位图图像时隐藏墨水对象，配置[RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) 并将渲染选项传递给[ISlide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/getimage/) 方法。

以下 C++ 示例将第一张幻灯片渲染为 PNG 图像且不包含墨水对象：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **控制墨水遮罩渲染**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 方法控制在渲染墨水笔刷时遮罩操作的解释方式。默认值为 `true`，使用不透明度。将该方法设为 `false` 可改用 ROP 操作。

以下 C++ 示例将幻灯片导出为 SVG，并使用基于 ROP 的墨水遮罩渲染：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

在导出演示文稿或将幻灯片渲染为 TIFF 时，可通过[TiffOptions::get_InkOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) 应用相同设置。

### **选择隐藏还是保留墨水**

在导出的文件应为带批注的演示文稿的干净版本（例如用于分发的最终副本）时，请使用[IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_hideink/) 并设为 `true`。

当墨水批注是预期内容的一部分时（如审阅评论、手写笔记、突出显示或应保持可见的绘图），请保留墨水可见（默认 `false` 设置）。这使得应用程序能够从同一演示文稿生成单独的审阅版和最终版，而无需修改源墨水对象。

## **常见问题**

**我可以更改现有墨水笔划的颜色或大小吗？**

可以。通过[IInk::get_Traces](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iink/get_traces/) 获取轨迹，然后更改其[IInkTrace::get_Brush](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iinktrace/get_brush/)。您可以对笔刷调用[IInkBrush::set_Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iinkbrush/set_color/)和[IInkBrush::set_Size](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ink/iinkbrush/set_size/)。

**隐藏墨水会改变源演示文稿吗？**

不会。[IInkOptions::set_HideInk](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/iinkoptions/set_hideink/) 只影响渲染或导出结果；它不会删除或修改源演示文稿中的墨水对象。

**哪些导出格式支持墨水选项？**

您可以通过上表中相应的导出或渲染选项，为 PDF、HTML、SVG、TIFF 和位图幻灯片图像配置墨水选项。

**进一步阅读**

* 如需了解一般形状，请参阅 [PowerPoint Shapes](https://docs.aspose.com/slides/zh/cpp/powerpoint-shapes/) 部分。
* 如需了解有效值，请参阅 [Shape Effective Properties](https://docs.aspose.com/slides/zh/cpp/shape-effective-properties/#get-effective-font-height-value)。
* 有关 PDF 导出的详细信息，请参阅 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh/cpp/convert-powerpoint-to-pdf/)。
* 有关 HTML 导出的详细信息，请参阅 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh/cpp/convert-powerpoint-to-html/)。
* 有关 SVG 导出的详细信息，请参阅 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh/cpp/render-a-slide-as-an-svg-image/)。
* 有关 TIFF 导出的详细信息，请参阅 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh/cpp/convert-powerpoint-to-tiff/)。
* 有关幻灯片转图像渲染的详细信息，请参阅 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh/cpp/convert-slide/)。