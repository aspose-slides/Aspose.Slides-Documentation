---
title: Convert Presentations in Handout Mode in Java
type: docs
weight: 150
url: /java/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- handout mode
- handout
- PowerPoint
- PPT
- PPTX
- presentation
- Java
- Aspose.Slides
description: "Convert Presentations in Handout Mode in Java"
---

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `setSlidesLayoutOptions` method in the [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/), and [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) interfaces.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```java
// Load a presentation and set the export options.
Presentation presentation = new Presentation("sample.pptx");

HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slides on one page horizontally
slidesLayoutOptions.setPrintSlideNumbers(true);                   // print slide numbers
slidesLayoutOptions.setPrintFrameSlide(true);                     // frame around slides
slidesLayoutOptions.setPrintComments(false);                      // no comments

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 

Keep in mind that the `setSlidesLayoutOptions` method is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 
