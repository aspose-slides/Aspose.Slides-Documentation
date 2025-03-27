---
title: Convert PowerPoint to PDF with Notes in PHP
linktitle: Convert PowerPoint to PDF with Notes
type: docs
weight: 50
url: /php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Java
- Aspose.Slides
description: "Convert PowerPoint to PDF with notes in PHP"
---

## **Overview**

In this article, you will learn how to convert PowerPoint presentations to PDF format with speaker notes using Aspose.Slides. This guide will cover the necessary steps and provide code examples to help you achieve this task efficiently. By the end of this article, you will be able to:

- Implement the conversion process to transform PowerPoint slides into PDF documents while preserving the speaker notes.
- Customize the output PDF to ensure that the speaker notes are included and formatted according to your requirements.

## **Convert PowerPoint to PDF with Notes**

The `save` method in the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class can be used to convert a PPT or PPTX presentation to a PDF with speaker notes. With Aspose.Slides, you simply load the presentation, configure the layout options using the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) class to include speaker notes, and then save the file as a PDF. The following code snippet demonstrates how to convert a sample presentation to a PDF in Notes Slide view.

```php
$presentation = new Presentation("sample.pptx");

// Configure PDF options for rendering speaker notes.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Render speaker notes below the slide.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Save the presentation to PDF with speaker notes.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 
