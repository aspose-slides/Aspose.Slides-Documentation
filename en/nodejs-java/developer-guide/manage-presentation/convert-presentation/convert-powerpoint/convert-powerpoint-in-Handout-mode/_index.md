---
title: Convert Presentations in Handout Mode in JavaScript
type: docs
weight: 150
url: /nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- handout mode
- handout
- PowerPoint
- PPT
- PPTX
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convert Presentations in Handout Mode in JavaScript"
---

## **Handout Mode Export**

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `setSlidesLayoutOptions` method in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/), and [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) classes.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```js
// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slides on one page horizontally
slidesLayoutOptions.setPrintSlideNumbers(true);                                // print slide numbers
slidesLayoutOptions.setPrintFrameSlide(true);                                  // print a frame around slides
slidesLayoutOptions.setPrintComments(false);                                   // no comments

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 

Keep in mind that the `setSlidesLayoutOptions` method is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 

## **FAQ**

**What is the maximum number of slide thumbnails per page in Handout mode?**

Aspose.Slides supports [presets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) up to 9 thumbnails per page with horizontal or vertical ordering: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), and 9 (horizontal/vertical).

**Can I define a custom grid, such as 5 or 8 slides per page?**

No. The number and ordering of thumbnails are controlled strictly by the [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) enumeration; arbitrary layouts are not supported.

**Can I include hidden slides in the Handout output?**

Yes. Use the `setShowHiddenSlides` method in the export settings for the target format, such as [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/), or [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).
