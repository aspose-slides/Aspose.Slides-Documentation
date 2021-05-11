---
title: Convert PowerPoint PPT and PPTX to PDF with Notes
type: docs
weight: 50
url: /net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/
keywords: "convert powerpoint to pdf with notes"
description: "Convert PowerPoint to PDF with notes. Convert PPT and PPTX to PDF with notes in Aspose.Slides."
---

The [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by Presentation class can be used to convert PowerPoint PPT or PPTX presentation to PDF with notes. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for .NET is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Conversion();

// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation(dataDir + "SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// Setting Slide Type and Size 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);
auxPresentation.Save(dataDir + "PDFnotes_out.pdf", SaveFormat.PdfNotes);
```


