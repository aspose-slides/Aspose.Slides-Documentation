---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /python-net/convert-powerpoint-to-swf-flash/
keywords: "Convertir PowerPoint, Presentación, PowerPoint a SWF, SWF flash PPT a SWF, PPTX a SWF, Python"
description: "Convertir Presentación de PowerPoint a SWF Flash en Python"
---

El [método Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la [clase Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) se puede utilizar para convertir toda la presentación en un documento SWF.  También puedes incluir comentarios en el SWF generado utilizando la [clase SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) y la [interfaz INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF utilizando las opciones proporcionadas por la clase SWFOptions.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Guardar presentación y páginas de notas
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```