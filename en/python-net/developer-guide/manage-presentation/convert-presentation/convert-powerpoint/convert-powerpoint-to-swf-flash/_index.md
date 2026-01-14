---
title: Convert PowerPoint Presentations to SWF Flash in Python
linktitle: PowerPoint to SWF Flash
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- PowerPoint to SWF
- presentation to SWF
- slide to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Convert PowerPoint (PPT/PPTX) to SWF Flash in Python with Aspose.Slides. Step‑by‑step code samples, fast quality output, no PowerPoint automation."
---

## **Convert Presentations to Flash**

The [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method exposed by [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) class and [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) class. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Saving presentation and notes pages
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **FAQ**

**Can I include hidden slides in the SWF?**

Yes. Enable the [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) option in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). By default, hidden slides are not exported.

**How can I control compression and the final SWF size?**

Use the [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) flag (enabled by default) and adjust [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) to balance file size and image fidelity.

**What is 'viewer_included' for, and when should I disable it?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) adds an embedded player UI (navigation controls, panels, search). Disable it if you plan to use your own player or need a bare SWF frame without UI.

**What happens if a source font is missing on the export machine?**

Aspose.Slides will substitute the font you specify via [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) in [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) to avoid an unintended fallback.
