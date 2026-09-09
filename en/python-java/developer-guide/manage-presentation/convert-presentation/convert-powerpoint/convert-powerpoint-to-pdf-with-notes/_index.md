---
title: Convert PowerPoint Presentations to PDF with Notes in Python
linktitle: PowerPoint to PDF with Notes
type: docs
weight: 50
url: /python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- convert PowerPoint
- convert presentation
- convert PPT
- convert PPTX
- PowerPoint to PDF
- presentation to PDF
- PPT to PDF
- PPTX to PDF
- save presentation as PDF
- export PPT to PDF
- export PPTX to PDF
- speaker notes
- PDF with notes
- Python
- Java
- Aspose.Slides
description: "Convert PPT and PPTX presentations to PDF with speaker notes using Aspose.Slides for Python via Java. Configure note placement and preserve long notes."
---

## **Overview**

This article explains how to convert PowerPoint presentations to PDF with speaker notes using Aspose.Slides for Python via Java. You can include notes below each slide and allow long notes to continue onto additional pages. For other PDF export settings, see [Convert PowerPoint to PDF](/slides/python-java/convert-powerpoint-to-pdf/).

## **Convert PowerPoint to PDF with Notes**

Use the [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class to export a PPT or PPTX presentation to PDF. To include speaker notes, create a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) object and configure note placement with its [setNotesPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) method. Assign this layout to [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) using [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

The following example loads `sample.pptx` and exports it to `output.pdf` with speaker notes below the slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Configure PDF options for rendering speaker notes.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Save the presentation to PDF with speaker notes.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

You can also try the [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion).

{{% /alert %}}

## **FAQ**

**How can I prevent long speaker notes from being cut off?**

Use [NotesPositions.BottomFull](https://reference.aspose.com/slides/python-java/aspose.slides/notespositions/#BottomFull), as in the example above. This setting displays the full notes, using additional pages when needed.

**Can I keep each slide and its notes on a single page?**

Use [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/python-java/aspose.slides/notespositions/#BottomTruncated). This setting limits the notes to one page, so notes that do not fit may be truncated.

**How do I export slides without speaker notes?**

Omit the notes layout configuration and use the standard PDF export described in [Convert PowerPoint to PDF](/slides/python-java/convert-powerpoint-to-pdf/).
