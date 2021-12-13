---
title: Convert PowerPoint to SWF Flash
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "Convert PowerPoint, Presentation, PowerPoint to SWF, SWF flash PPT to SWF, PPTX to SWF, Python"
description: "Convert PowerPoint Presentation to SWF Flash in Python"
---

The [Save](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://apireference.aspose.com/slides/python-net/aspose.slides.export/swfoptions) class and [INotesCommentsLayoutingOptions ](https://apireference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

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

