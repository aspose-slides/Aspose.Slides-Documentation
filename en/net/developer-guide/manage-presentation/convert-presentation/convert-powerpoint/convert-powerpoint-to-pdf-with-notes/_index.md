---
title: Convert PowerPoint to PDF with Notes in C#
linktitle: Convert PowerPoint to PDF with Notes
type: docs
weight: 50
url: /net/convert-powerpoint-to-pdf-with-notes/
keywords: "convert PowerPoint, Presentation, PowerPoint to PDF, notes, c#, csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint to PDF with notes with C# or .NET"
---

## **Overview**

While [converting PowerPoint to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/), you can also control how notes and comments are placed in exported document. It covers the following topics.

- [C# Convert PPT to PDF with Notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convert PPTX to PDF with Notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convert ODP to PDF with Notes](#convert-powerpoint-to-pdf-with-notes)
- [C# Convert PowerPoint to PDF with Notes](#convert-powerpoint-to-pdf-with-notes)

## **Convert PowerPoint to PDF with Notes**

The [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method provided by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/#presentation-class) class can be used to convert a PowerPoint PPT or PPTX presentation to a PDF with notes. With Aspose.Slides for .NET, saving a Microsoft PowerPoint presentation to a PDF with notes is a straightforward process. You simply load the presentation, configure the [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) property to include notes, and save the file as a PDF. The C# code snippet below demonstrates how to convert a sample presentation to a PDF in Notes Slide view:

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("SelectedSlides.pptx"))
{
    // Configure PDF options for rendering notes
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Render notes below the slide
        }
    };

    // Save the presentation to PDF with notes
    presentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) or [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) converter. 

{{% /alert %}} 
