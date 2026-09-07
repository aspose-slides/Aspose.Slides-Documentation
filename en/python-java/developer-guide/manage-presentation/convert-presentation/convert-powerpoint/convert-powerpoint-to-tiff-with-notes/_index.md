---
title: Convert PowerPoint Presentations to TIFF with Notes in Python
linktitle: PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /python-java/convert-powerpoint-to-tiff-with-notes/
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
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to TIFF with notes using Aspose.Slides for Python via Java. Learn how to export slides with speaker notes efficiently."
---

## **Introduction**

Aspose.Slides for Python via Java provides a simple solution for converting PowerPoint and OpenDocument presentations (PPT, PPTX, and ODP) with notes to the TIFF format. This format is widely used for high-quality image storage, printing, and document archiving. Use the [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class to export slides and their speaker notes to a single multipage TIFF file.

## **Convert a Presentation to TIFF with Notes**

Saving a PowerPoint or OpenDocument presentation to TIFF with notes using Aspose.Slides for Python via Java involves the following steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class: Load a PowerPoint or OpenDocument file.
1. Configure the output layout options: Use the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) class to specify how notes and comments should be displayed.
1. Save the presentation to TIFF: Pass the configured options to the [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method.

Let's say we have a "speaker_notes.pptx" file with the following slide:

![The presentation slide with speaker notes](slide_with_notes.png)

The code snippet below demonstrates how to convert the presentation to a TIFF image in Notes Slide view using the [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) method.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Display the complete speaker notes below each slide.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Configure TIFF resolution and the notes layout.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Save the presentation to TIFF with speaker notes.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

The result:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}

Check out Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Can I control the position of the notes area in the resulting TIFF?**

Yes. Configure [setNotesPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) with [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/python-java/aspose.slides/notespositions/#BottomTruncated) to fit notes on one page, possibly truncating them, or [NotesPositions.BottomFull](https://reference.aspose.com/slides/python-java/aspose.slides/notespositions/#BottomFull) to display all notes using additional pages when needed. To export slides without notes, omit the notes layout configuration as shown in [Convert PowerPoint to TIFF](/slides/python-java/convert-powerpoint-to-tiff/).

**How can I reduce the size of a TIFF file with notes without losing image quality?**

Use lossless [LZW compression](https://reference.aspose.com/slides/python-java/aspose.slides/tiffcompressiontypes/#LZW) through [setCompressionType](https://reference.aspose.com/slides/python-java/aspose.slides/tiffoptions/#setCompressionType). Reducing resolution or color depth can further decrease file size, but may affect image quality and note readability. See [TIFF export settings](/slides/python-java/convert-powerpoint-to-tiff/) for more options.

**Does the font in the notes affect the result if the original fonts are missing from the system?**

Yes. Missing fonts trigger [font substitution](/slides/python-java/font-selection-sequence/), which can change text metrics and appearance. [Supply the required fonts](/slides/python-java/custom-font/) to preserve the intended typefaces.
