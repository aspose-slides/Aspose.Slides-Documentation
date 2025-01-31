---
title: Convert Presentations in Handout Mode in PHP
type: docs
weight: 150
url: /php-java/convert-powerpoint-in-Handout-mode/
keywords:
- convert PowerPoint
- handout mode
- handout
- PowerPoint
- PPT
- PPTX
- presentation
- PHP
- Java
- Aspose.Slides
description: "Convert Presentations in Handout Mode in PHP"
---

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing in Handout mode. This mode allows you to configure how multiple slides appear on a single page, making it useful for conferences, seminars, and other events. You can enable this mode by setting the `setSlidesLayoutOptions` method in the [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), and [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) classes.

To configure Handout mode, use the [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/) object, which determines how many slides are placed on a single page and other display parameters.

Below is a code example showing how to convert a presentation to PDF in Handout mode.

```php
// Load a presentation and set the export options.
$presentation = new Presentation("sample.pptx");

$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slides on one page horizontally
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // print slide numbers
$slidesLayoutOptions->setPrintFrameSlide(true);                      // frame around slides
$slidesLayoutOptions->setPrintComments(false);                       // no comments

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

Keep in mind that the `setSlidesLayoutOptions` method is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 
