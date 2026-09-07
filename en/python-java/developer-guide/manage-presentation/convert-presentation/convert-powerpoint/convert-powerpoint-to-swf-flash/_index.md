---
title: Convert PowerPoint Presentations to SWF Flash in Python via Java
linktitle: PowerPoint to SWF
type: docs
weight: 80
url: /python-java/convert-powerpoint-to-swf-flash/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to SWF
- presentation to SWF
- slide to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint to Flash
- presentation to Flash
- slide to Flash
- PPT to Flash
- PPTX to Flash
- save PPT as SWF
- save PPTX as SWF
- export PPT to SWF
- export PPTX to SWF
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to SWF Flash in Python via Java with Aspose.Slides. Configure the viewer, notes, hidden slides, compression, and fonts."
---

## **Overview**

Aspose.Slides for Python via Java lets you convert PowerPoint presentations to SWF without Microsoft PowerPoint. Use [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) to export the presentation and [SwfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/) to configure viewer settings, image quality, and the layout of notes or comments.

## **Convert Presentations to Flash**

Load the source file with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), configure [SwfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/), and save it using [SaveFormat.Swf](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Swf).

The following example exports `presentation.pptx` to `presentation.swf`. It disables the embedded viewer with [setViewerIncluded](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setViewerIncluded) and includes speaker notes below the slides using [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Before running the example, [install Aspose.Slides for Python via Java](/slides/python-java/installation/) and place `presentation.pptx` in the working directory. The JVM is started once per Python process.

The example applies [NotesPositions.BottomFull](https://reference.aspose.com/slides/python-java/aspose.slides/notespositions/#BottomFull) through [setNotesPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) and passes the layout to [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). To include comments as well, configure [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) before exporting.

## **FAQ**

**Can I include hidden slides in the SWF?**

Yes. Call [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) with `True`. By default, hidden slides are not exported.

**How can I control compression and the final SWF size?**

Use [SwfOptions.setCompressed](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setCompressed) to enable or disable compression and [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setJpegQuality) to adjust JPEG image quality. Lower JPEG quality can reduce file size at the cost of image fidelity.

**What is the embedded viewer for, and when should I disable it?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/#setViewerIncluded) controls whether the generated SWF includes the viewer. Pass `False` when you need the exported slides without the embedded viewer, as in the example above.

**What happens if a source font is missing on the export machine?**

You can specify a default regular font with [setDefaultRegularFont](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), inherited by [SwfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/swfoptions/). Choose a font available to the export process; font substitution can change text appearance and layout.
