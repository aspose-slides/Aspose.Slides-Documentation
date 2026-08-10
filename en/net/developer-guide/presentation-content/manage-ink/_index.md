---
title: Manage Presentation Ink Objects in .NET
linktitle: Manage Ink
type: docs
weight: 95
url: /net/manage-ink/
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
- .NET
- C#
- Aspose.Slides
description: "Manage PowerPoint ink objects, edit traces and brush properties, and control ink appearance during PDF, HTML, SVG, TIFF, and image export with Aspose.Slides for .NET."
---

## **Introduction**

PowerPoint provides an ink feature that allows you to draw freeform strokes. Ink can be used to highlight other objects, show connections and processes, and draw attention to specific items on a slide.

The [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) namespace contains the classes and interfaces needed to work with ink objects. For example, the [IInk](https://reference.aspose.com/slides/net/aspose.slides.ink/iink/) interface represents an ink object on a slide.

## **Differences between Regular Objects and Ink Objects**

Objects on a PowerPoint slide are typically represented by shape objects. In its simplest form, a shape is a container that defines the area of the object itself (its frame) along with properties such as the container size, shape, and background. For more information, see [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

However, when PowerPoint handles an ink object, it ignores all properties of the object frame (container) except its size. The size of the container area is determined by the standard [IShape.Width](https://reference.aspose.com/slides/net/aspose.slides/ishape/width/) and [IShape.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) properties:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ink Traces**

An ink trace is a basic element used to record the trajectory of a pen as a user writes digital ink. A trace stores a sequence of connected points.

The simplest form of encoding specifies the X and Y coordinates of each sample point. When all connected points are rendered, they produce an image like this:

![ink_powerpoint2](ink_powerpoint2.png)

## **Brush Properties for Drawing**

A brush is used to draw lines that connect the points of an ink trace. The brush has its own color and size, represented by the [IInkBrush.Color](https://reference.aspose.com/slides/net/aspose.slides.ink/iinkbrush/color/) and [IInkBrush.Size](https://reference.aspose.com/slides/net/aspose.slides.ink/iinkbrush/size/) properties.

### **Set Ink Brush Color**

This C# code shows how to set the color of an ink brush:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Set Ink Brush Size**

This C# code shows how to set the size of an ink brush:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
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

Aspose.Slides provides the [IInkOptions](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/) interface to control how ink objects appear in exported or rendered output. You can use its properties to hide ink completely or change how ink brush mask operations are interpreted.

Ink options are available through the export or rendering options for several output types:

| Output | Ink options property |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/inkoptions/) |

The same two settings are available through these properties:

- [`HideInk`](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/hideink/) determines whether ink objects are included in the output. Its default value is `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) determines whether a mask operation is interpreted as opacity when rendering an ink brush. Its default value is `true`; set it to `false` to use the ROP operation instead.

### **Hide Ink Objects in PDF Output**

By default, ink objects remain visible during export. Set [IInkOptions.HideInk](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/hideink/) to `true` when you need a clean output without handwritten annotations or other ink content.

The following C# example exports a presentation to PDF while hiding all ink objects:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Hide Ink Objects When Rendering a Slide as an Image**

To hide ink objects when rendering slides as bitmap images, configure [RenderingOptions.InkOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/inkoptions/) and pass the rendering options to the [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) method.

The following C# example renders the first slide as a PNG image without ink objects:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Control Ink Mask Rendering**

The [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) property controls how mask operations are interpreted when rendering ink brushes. The default value is `true`, which uses opacity. Set the property to `false` to use the ROP operation instead.

The following C# example exports a slide to SVG and uses ROP-based rendering for ink mask operations:

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

The same setting can be applied through [TiffOptions.InkOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/inkoptions/) when exporting a presentation or rendering a slide to TIFF.

### **Choose Whether to Hide or Preserve Ink**

Use [IInkOptions.HideInk](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/hideink/) set to `true` when the exported file should be a clean version of an annotated presentation, for example, a final copy intended for distribution without review marks.

Leave [IInkOptions.HideInk](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/hideink/) at its default value of `false` when ink annotations are part of the intended content, such as review comments, handwritten notes, highlights, or drawings that should remain visible in the exported result. This allows applications to generate separate review and final outputs from the same presentation without modifying the source ink objects.

## **FAQ**

**Can I change the color or size of an existing ink stroke?**

Yes. Get the trace from [IInk.Traces](https://reference.aspose.com/slides/net/aspose.slides.ink/iink/traces/), then change its [IInkTrace.Brush](https://reference.aspose.com/slides/net/aspose.slides.ink/iinktrace/brush/). You can set the brush's [IInkBrush.Color](https://reference.aspose.com/slides/net/aspose.slides.ink/iinkbrush/color/) and [IInkBrush.Size](https://reference.aspose.com/slides/net/aspose.slides.ink/iinkbrush/size/) properties.

**Does hiding ink change the source presentation?**

No. [IInkOptions.HideInk](https://reference.aspose.com/slides/net/aspose.slides.export/iinkoptions/hideink/) affects only the rendered or exported result; it does not remove or modify ink objects in the source presentation.

**Which export formats support ink options?**

You can configure ink options for PDF, HTML, SVG, TIFF, and bitmap slide images through the corresponding export or rendering options shown above.

**Further reading**

* To read about shapes in general, see the [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/) section.
* For more information on effective values, see [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).
* For details on PDF export, see [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/).
* For details on HTML export, see [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/).
* For details on SVG export, see [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/).
* For details on TIFF export, see [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/).
* For details on slide-to-image rendering, see [Convert Presentation Slides to Images](https://docs.aspose.com/slides/net/convert-slide/).
