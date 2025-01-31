---
title: Convert Presentations in Handout Mode in C++
type: docs
weight: 150
url: /cpp/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- handout mode
- handout
- PowerPoint
- PPT
- PPTX
- presentation
- C++
- Aspose.Slides
description: "Convert Presentations in Handout Mode in C++"
---

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
