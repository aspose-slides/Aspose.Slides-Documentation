---
title: PowerPoint in SWF Flash umwandeln
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "PowerPoint umwandeln, Präsentation, PowerPoint in SWF, SWF Flash PPT in SWF, PPTX in SWF, Python"
description: "PowerPoint-Präsentation in SWF Flash in Python umwandeln"
---

Die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF-Dokument umzuwandeln. Sie können auch Kommentare im generierten SWF einfügen, indem Sie die [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) Klasse und das [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)Interface verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation in ein SWF-Dokument umwandelt, indem man die von der SWFOptions-Klasse bereitgestellten Optionen verwendet.

```py
import aspose.slides as slides

# Instanziieren eines Presentation-Objekts, das eine Präsentationsdatei repräsentiert
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Speichern der Präsentation und Notizseiten
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```