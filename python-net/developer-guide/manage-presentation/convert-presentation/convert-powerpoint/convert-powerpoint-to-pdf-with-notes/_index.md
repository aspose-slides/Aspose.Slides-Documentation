---
title: Convert PowerPoint to PDF with Notes
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "convert PowerPoint, Presentation, PowerPoint to PDF, notes, Python, Aspose.Slides"
description: "Convert PowerPoint to PDF with notes with Python"
---

The [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method exposed by Presentation class can be used to convert PowerPoint PPT or PPTX presentation to PDF with notes. Saving a Microsoft PowerPoint presentation to PDF notes with Aspose.Slides for Python via .NET is a two-line process. You simply open the presentation and save it out to PDF notes. The code snippets below update the sample presentation to PDF in Notes Slide view:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Setting Slide Type and Size 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

You may want to check out Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion) or [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) converter. 

{{% /alert %}}
