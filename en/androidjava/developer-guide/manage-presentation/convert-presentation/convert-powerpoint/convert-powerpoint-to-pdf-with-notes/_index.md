---
title: Convert PowerPoint Presentations to PDF with Notes on Android
linktitle: PowerPoint to PDF with Notes
type: docs
weight: 50
url: /androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to PDF
- presentation to PDF
- slide to PDF
- PPT to PDF
- PPTX to PDF
- save presentation as PDF
- save PPT as PDF
- save PPTX as PDF
- export PPT to PDF
- export PPTX to PDF
- speaker notes
- PDF with notes
- Android
- Java
- Aspose.Slides
description: "Convert formats PPT and PPTX to PDF with notes using Aspose.Slides for Android via Java. Preserve layouts and speaker notes for professional presentations."
---

## **Overview**

In this article, you will learn how to convert PowerPoint presentations to PDF format with speaker notes using Aspose.Slides. This guide will cover the necessary steps and provide code examples to help you achieve this task efficiently. By the end of this article, you will be able to:

- Implement the conversion process to transform PowerPoint slides into PDF documents while preserving the speaker notes.
- Customize the output PDF to ensure that the speaker notes are included and formatted according to your requirements.

## **Convert PowerPoint to PDF with Notes**

The `save` method in the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class can be used to convert a PPT or PPTX presentation to a PDF with speaker notes. With Aspose.Slides, you simply load the presentation, configure the layout options using the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) class to include speaker notes, and then save the file as a PDF. The following code snippet demonstrates how to convert a sample presentation to a PDF in Notes Slide view.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Configure PDF options for rendering speaker notes.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Render speaker notes below the slide.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Save the presentation to PDF with speaker notes.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 
