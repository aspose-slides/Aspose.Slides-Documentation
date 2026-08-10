---
title: Manage Presentation Ink Objects in C++
linktitle: Manage Ink
type: docs
weight: 95
url: /cpp/manage-ink/
keywords:
- ink
- ink object
- ink trace
- manage ink
- draw ink
- drawing
- ink export
- ink rendering
- hide ink
- IInkOptions
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Manage PowerPoint ink objects, edit traces and brush properties, and control ink appearance during PDF, HTML, SVG, TIFF, and image export with Aspose.Slides for C++."
---

## **Introduction**

PowerPoint provides an ink feature that allows you to draw freeform strokes. Ink can be used to highlight other objects, show connections and processes, and draw attention to specific items on a slide.

The [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) namespace contains the classes and interfaces needed to work with ink objects. For example, the [IInk](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iink/) interface represents an ink object on a slide.

## **Differences between Regular Objects and Ink Objects**

Objects on a PowerPoint slide are typically represented by shape objects. In its simplest form, a shape is a container that defines the area of the object itself (its frame) along with properties such as the container size, shape, and background. For more information, see [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

However, when PowerPoint handles an ink object, it ignores all properties of the object frame (container) except its size. The size of the container area is determined by the standard [IShape::get_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_width/) and [IShape::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_height/) methods:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink Traces**

An ink trace is a basic element used to record the trajectory of a pen as a user writes digital ink. A trace stores a sequence of connected points.

The simplest form of encoding specifies the X and Y coordinates of each sample point. When all connected points are rendered, they produce an image like this:

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

A brush is used to draw lines that connect the points of an ink trace. The brush has its own color and size, represented by the [IInkBrush::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iinkbrush/get_color/) and [IInkBrush::get_Size](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iinkbrush/get_size/) methods.

### **Set Ink Brush Color**

This C++ code shows how to set the color of an ink brush:

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

### **Set Ink Brush Size**

This C++ code shows how to set the size of an ink brush:

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

Generally, a brush's width and height do not match, so PowerPoint does not display the brush size (the corresponding data section is grayed out). When the brush width and height match, PowerPoint displays its size this way:

![ink_powerpoint3](ink_powerpoint3.png)

For clarity, let's increase the height of the ink object and review the important dimensions:

![ink_powerpoint4](ink_powerpoint4.png)

The container (frame) does not account for the size of the brushes—it always assumes that the line thickness is zero (see the previous image).

Therefore, to determine the visible area of the entire ink object, the brush size of its traces must be taken into account. Here, the target object (the handwritten text trace) has been scaled to the size of the container (frame). When the size of the container changes, the brush size remains constant, and vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint uses similar behavior for text objects:

![ink_powerpoint6](ink_powerpoint6.png)

## **Control Ink Appearance During Export and Rendering**

Aspose.Slides provides the [IInkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/) interface to control how ink objects appear in exported or rendered output. You can use its methods to hide ink completely or change how ink brush mask operations are interpreted.

Ink options are available through the export or rendering options for several output types:

| Output | Ink options method |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

The same two settings are available through these methods:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_hideink/) determines whether ink objects are included in the output. Its default value is `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) determines whether a mask operation is interpreted as opacity when rendering an ink brush. Its default value is `true`; set it to `false` to use the ROP operation instead.

### **Hide Ink Objects in PDF Output**

By default, ink objects remain visible during export. Call [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_hideink/) with `true` when you need a clean output without handwritten annotations or other ink content.

The following C++ example exports a presentation to PDF while hiding all ink objects:

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

### **Hide Ink Objects When Rendering a Slide as an Image**

To hide ink objects when rendering slides as bitmap images, configure [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) and pass the rendering options to the [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method.

The following C++ example renders the first slide as a PNG image without ink objects:

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

### **Control Ink Mask Rendering**

The [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) method controls how mask operations are interpreted when rendering ink brushes. The default value is `true`, which uses opacity. Call the method with `false` to use the ROP operation instead.

The following C++ example exports a slide to SVG and uses ROP-based rendering for ink mask operations:

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

The same setting can be applied through [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) when exporting a presentation or rendering a slide to TIFF.

### **Choose Whether to Hide or Preserve Ink**

Use [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_hideink/) with `true` when the exported file should be a clean version of an annotated presentation, for example, a final copy intended for distribution without review marks.

Leave ink visible (the default `false` setting) when ink annotations are part of the intended content, such as review comments, handwritten notes, highlights, or drawings that should remain visible in the exported result. This allows applications to generate separate review and final outputs from the same presentation without modifying the source ink objects.

## **FAQ**

**Can I change the color or size of an existing ink stroke?**

Yes. Get the trace from [IInk::get_Traces](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iink/get_traces/), then change its [IInkTrace::get_Brush](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iinktrace/get_brush/). You can call [IInkBrush::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iinkbrush/set_color/) and [IInkBrush::set_Size](https://reference.aspose.com/slides/cpp/aspose.slides.ink/iinkbrush/set_size/) on the brush.

**Does hiding ink change the source presentation?**

No. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/cpp/aspose.slides.export/iinkoptions/set_hideink/) affects only the rendered or exported result; it does not remove or modify ink objects in the source presentation.

**Which export formats support ink options?**

You can configure ink options for PDF, HTML, SVG, TIFF, and bitmap slide images through the corresponding export or rendering options shown above.

**Further reading**

* To read about shapes in general, see the [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/) section.
* For more information on effective values, see [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).
* For details on PDF export, see [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/).
* For details on HTML export, see [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/).
* For details on SVG export, see [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/cpp/render-a-slide-as-an-svg-image/).
* For details on TIFF export, see [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-tiff/).
* For details on slide-to-image rendering, see [Convert Presentation Slides to Images](https://docs.aspose.com/slides/cpp/convert-slide/).
