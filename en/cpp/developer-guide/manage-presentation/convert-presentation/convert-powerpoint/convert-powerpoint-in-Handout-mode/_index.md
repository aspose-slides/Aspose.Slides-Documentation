---
title: Convert PowerPoint Presentations in Handout Mode Using C++
linktitle: Handout Mode
type: docs
weight: 150
url: /cpp/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Convert presentations to handouts in C++. Set slides per page, keep notes, export to PDF or images with Aspose.Slides, with sample code. Try it free."
---

## **Handout Mode Export**

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `set_SlidesLayoutOptions` method in the [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/), and [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) interfaces.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```cpp
// Load a presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slides on one page horizontally
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // print slide numbers
slidesLayoutOptions->set_PrintFrameSlide(true);                      // print a frame around slides
slidesLayoutOptions->set_PrintComments(false);                       // no comments

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 

Keep in mind that the `set_SlidesLayoutOptions` method is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides supports [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) enumeration; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Use the `set_ShowHiddenSlides` method in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).
