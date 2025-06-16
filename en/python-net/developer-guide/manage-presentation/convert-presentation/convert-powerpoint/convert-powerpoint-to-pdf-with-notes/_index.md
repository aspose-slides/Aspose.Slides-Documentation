---
title: Convert Presentations to PDF with Notes in Python
linktitle: Presentation to PDF with Notes
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convert PowerPoint
- convert OpenDocument
- convert presentation
- convert PPT
- convert PPTX
- convert ODP
- PowerPoint to PDF
- OpenDocument to PDF
- presentation to PDF
- PPT to PDF
- PPTX to PDF
- ODP to PDF
- speaker notes
- PDF with notes
- Python
- Aspose.Slides
description: "Convert formats PPT, PPTX and ODP to PDF with notes using Aspose.Slides for Python. Preserve layouts and speaker notes for professional presentations."
---

## **Overview**

In this article, you will learn how to convert PowerPoint presentations to PDF format with speaker notes using Aspose.Slides. This guide will cover the necessary steps and provide code examples to help you achieve this task efficiently. By the end of this article, you will be able to:

- Implement the conversion process to transform PowerPoint slides into PDF documents while preserving the speaker notes.
- Customize the output PDF to ensure that the speaker notes are included and formatted according to your requirements.

## **Convert PowerPoint to PDF with Notes**

The `save` method in the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can be used to convert a PPT or PPTX presentation to a PDF with speaker notes. With Aspose.Slides, you simply load the presentation, configure the layout options using the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) class to include speaker notes, and then save the file as a PDF. The following code snippet demonstrates how to convert a sample presentation to a PDF in Notes Slide view.

```py
with slides.Presentation("sample.pptx") as presentation:

    # Configure PDF options for rendering speaker notes.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Save the presentation to PDF with speaker notes.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 
