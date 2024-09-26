---
title: Print Presentation
type: docs
weight: 50
url: /nodejs-java/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, Java, Printer, PrinterJob, PrintService"
description: "Print PowerPoint Presentation in Javascript"
---

In Aspose.Slides for Node.js via Java 24.4, we have introduced a [Modern API](https://docs.aspose.com/slides/nodejs-java/modern-api/) that limits print support. However, we have taken a new approach to help you overcome this limitation. In this article, we will show you how to print a presentation using the current API.

## Print Presentation

This Javascript code snippet demonstrates how to print a PowerPoint presentation using Aspose.Slides for Node.js via Java API.

To print a presentation, follow these steps:

1. Create an instance of the `PrintRequestAttributeSet` and specify printing attributes such as orientation and page range.
2. Create an instance of the `RenderingOptions` and specify options for slide notes layout.
3. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, specifying the presentation file.
4. Create an instance of the `PrinterJob` to specify the desired printer.
5. Generate an array of Slide Images using the [getImages](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getImages-aspose.slides.IRenderingOptions-int---java.awt.Dimension-) method.
6. Set the `IImage` array as Printable for `PrinterJob`.
7. Call the `print` method of the `PrinterJob` class.

Ensure to replace **"printerName"** with the name of your specific printer and configure the `PrintRequestAttributeSet` and `RenderingOptions` according to your printing requirements.

{{% alert color="primary" %}} 
Please note that printing Notes must require changing the page orientation to `OrientationRequested.PORTRAIT`.
{{% /alert %}} 

If you encounter any issues or need further assistance, feel free to reach out to [our support team](https://forum.aspose.com/c/slides/11).