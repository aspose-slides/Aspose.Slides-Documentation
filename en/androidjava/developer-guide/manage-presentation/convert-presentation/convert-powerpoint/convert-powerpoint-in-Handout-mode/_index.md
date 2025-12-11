---
title: Convert PowerPoint Presentations in Handout Mode on Android
linktitle: Handout Mode
type: docs
weight: 150
url: /androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- convert presentation
- handout mode
- handout
- PPT
- PPTX
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Convert presentations to handouts in Java. Set slides per page, keep notes, export to PDF or images with Aspose.Slides for Android, with sample code. Try it free."
---

## **Handout Mode Export**

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `setSlidesLayoutOptions` method in the [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), and [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) interfaces.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

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

Aspose.Slides supports [presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) class; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Enable the hidden slides using the `setShowHiddenSlides` method in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).
