---
title: Convert PowerPoint to PDF with Notes in C++
linktitle: Convert PowerPoint to PDF with Notes
type: docs
weight: 50
url: /cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- convert PowerPoint
- convert PPT
- convert PPTX
- presentation
- PowerPoint to PDF
- PPT to PDF
- PPTX to PDF
- OpenDocument to PDF
- ODP to PDF
- speaker notes
- C++
- Aspose.Slides
description: "Convert PowerPoint to PDF with notes with C++"
---

## **Overview**

In this article, you will learn how to convert PowerPoint presentations to PDF format with speaker notes using Aspose.Slides. This guide will cover the necessary steps and provide code examples to help you achieve this task efficiently. By the end of this article, you will be able to:

- Implement the conversion process to transform PowerPoint slides into PDF documents while preserving the speaker notes.
- Customize the output PDF to ensure that the speaker notes are included and formatted according to your requirements.

## **Convert PowerPoint to PDF with Notes**

The `Save` method in the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class can be used to convert a PPT or PPTX presentation to a PDF with speaker notes. With Aspose.Slides, you simply load the presentation, configure the layout options using the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) class to include speaker notes, and then save the file as a PDF. The following code snippet demonstrates how to convert a sample presentation to a PDF in Notes Slide view.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Render speaker notes below the slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 
