---
title: Convert PowerPoint Presentations to TIFF with Notes in Java
linktitle: PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to TIFF
- presentation to TIFF
- slide to TIFF
- PPT to TIFF
- PPTX to TIFF
- save PPT as TIFF
- save PPTX as TIFF
- export PPT to TIFF
- export PPTX to TIFF
- PowerPoint with notes
- presentation with notes
- slide with notes
- PPT with notes
- PPTX with notes
- TIFF with notes
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to TIFF with notes using Aspose.Slides for Java. Learn how to export slides with speaker notes efficiently."
---

## **Overview**

Aspose.Slides for Java provides a simple solution for converting PowerPoint and OpenDocument presentations (PPT, PPTX, and ODP) with notes to the TIFF format. This format is widely used for high-quality image storage, printing, and document archiving. With Aspose.Slides, you can not only export entire presentations with speaker notes but also generate slide thumbnails in the Notes Slide view. The conversion process is simple and efficient, utilizing the `save` method of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class to transform the entire presentation into a series of TIFF images while preserving the notes and layout.

## **Convert a Presentation to TIFF with Notes**

Saving a PowerPoint or OpenDocument presentation to TIFF with notes using Aspose.Slides for Java involves the following steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class: Load a PowerPoint or OpenDocument file.
1. Configure the output layout options: Use the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) class to specify how notes and comments should be displayed.
1. Save the presentation to TIFF: Pass the configured options to the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method.

Let's say we have a "speaker_notes.pptx" file with the following slide:

![The presentation slide with speaker notes](slide_with_notes.png)

The code snippet below demonstrates how to convert the presentation to a TIFF image in Notes Slide view using the [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) method.

```java
// Instantiate the Presentation class that represents a presentation file.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Display the notes below the slide.

    // Configure the TIFF options with Notes layouting.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Save the presentation to TIFF with the speaker notes.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

The result:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Check out Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}
