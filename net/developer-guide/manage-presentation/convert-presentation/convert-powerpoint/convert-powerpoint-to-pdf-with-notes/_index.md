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

The [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method exposed by Presentation class can be used to convert PowerPoint PPT or PPTX presentation to PDF with notes. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for .NET is a two-line process. You simply open the presentation and save it out to PDF notes. The C# code snippets below update the sample presentation to PDF in Notes Slide view:

```c#
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Setting Slide Type and Size 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) or [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) converter. 

{{% /alert %}} 
