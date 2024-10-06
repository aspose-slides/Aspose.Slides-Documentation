---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Présentation, PowerPoint en SWF, SWF flash PPT en SWF, PPTX en SWF, Python"
description: "Convertir une Présentation PowerPoint en SWF Flash en Python"
---

La méthode [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) exposée par [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) peut être utilisée pour convertir l'ensemble de la présentation en document SWF.  Vous pouvez également inclure des commentaires dans le SWF généré en utilisant [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) et [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)interface. L'exemple suivant montre comment convertir une présentation en document SWF en utilisant les options fournies par la classe SWFOptions.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Enregistrer la présentation et les pages de notes
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```