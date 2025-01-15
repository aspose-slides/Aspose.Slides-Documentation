---
title: Convert Presentations in Handout Mode in C#
type: docs
weight: 150
url: /net/convert-powerpoint-in-Handout-mode/
keywords: "Convert PowerPoint in Handout Mode, Handout, PowerPoint, PPT, PPTX, Presentation, C#, Csharp, .NET, Aspose.Slides"
description: "Convert Presentations in Handout Mode in C#"
---

 **Converting Presentations in Handout Mode**

Aspose.Slides provides the ability to convert presentations into various formats, including creating handouts for printing, such as in Handout mode. This mode allows you to configure the display of slides on a single page, which is useful for conferences, seminars, and other events. This mode is set using the [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) property of the [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) and [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) interfaces.

To configure Handout mode, the [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) object is used, which determines how many slides will be placed on a single page and other display parameters.

Below is a code example that converts a presentation to PDF in Handout mode:
```c#
        // Load the presentation and set export options
        using (Presentation presentation = new Presentation(inputFilePath))
        {
            PdfOptions pdfOptions = new PdfOptions
            {
                SlidesLayoutOptions = new HandoutLayoutingOptions
                {
                    Handout = HandoutType.Handouts4Horizontal, // 4 slides on one page horizontally
                    PrintSlideNumbers = true,                 // Print slide numbers
                    PrintFrameSlide = true,                   // Frame around slides
                    PrintComments = false                     // No comments
                }
            };

            // Export the presentation to PDF with the chosen layout
            presentation.Save(outputFilePath, SaveFormat.Pdf, pdfOptions);
        }
```


{{% alert color="warning" %}} 

Keep in mind that the SlidesLayoutOptions property is available only for certain output formats, such as PDF, HTML, TIFF, and when rendering as images.

{{% /alert %}} 
