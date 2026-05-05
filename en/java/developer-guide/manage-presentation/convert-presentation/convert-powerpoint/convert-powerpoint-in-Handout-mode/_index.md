---
title: Convert PowerPoint Presentations in Handout Mode Using Java
linktitle: Handout Mode
type: docs
weight: 150
url: /java/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Convert presentations to handouts in Java. Set slides per page, keep notes, export to PDF or images with Aspose.Slides, with sample Java code. Try it free."
---

## **Introduction**

Aspose.Slides allows you to convert presentations to output formats that support Handout mode. In this mode, multiple slides are arranged on a single page, which is useful for printing presentation materials for conferences, seminars, and similar events.

Handout mode is configured through the `setSlidesLayoutOptions` method, which is available in [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/), and [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/). To define the handout layout, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) object.

## **Handout Mode Export**

To export a presentation in Handout mode, set the `setSlidesLayoutOptions` method for the target export options and assign a [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) instance that defines the number of slides per page and related display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```java
// Load a presentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Set the export options.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slides on one page horizontally
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // print slide numbers
    slidesLayoutOptions.setPrintFrameSlide(true);                     // print a frame around slides
    slidesLayoutOptions.setPrintComments(false);                      // no comments

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Export the presentation to PDF with the chosen layout.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 

Keep in mind that the `setSlidesLayoutOptions` method is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides supports [presets](https://reference.aspose.com/slides/java/com.aspose.slides/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/java/com.aspose.slides/handouttype/) class; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Enable the hidden slides using the `setShowHiddenSlides` method in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/).
