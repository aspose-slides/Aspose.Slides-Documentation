---
title: Convert PowerPoint Presentations in Handout Mode in .NET
linktitle: Handout Mode
type: docs
weight: 150
url: /net/convert-powerpoint-in-handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PowerPoint
- presentation
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Convert presentations to handouts in .NET. Set slides per page, keep notes, export to PDF or images with Aspose.Slides, with sample C# code. Try it free."
---

## **Introduction**

Aspose.Slides allows you to convert presentations to output formats that support Handout mode. In this mode, multiple slides are arranged on a single page, which is useful for printing presentation materials for conferences, seminars, and similar events.

Handout mode is configured through the `SlidesLayoutOptions` property, which is available in [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/), and [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/). To define the handout layout, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) object.

## **Handout Mode Export**

To export a presentation in Handout mode, set the `SlidesLayoutOptions` property for the target export options and assign a [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) instance that defines the number of slides per page and related display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```c#
// Load a presentation.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slides on one page horizontally
        PrintSlideNumbers = true,                   // print slide numbers
        PrintFrameSlide = true,                     // print a frame around slides
        PrintComments = false                       // no comments
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

Keep in mind that the `SlidesLayoutOptions` property is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides supports [presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) enumeration; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Enable the `ShowHiddenSlides` option in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/).
