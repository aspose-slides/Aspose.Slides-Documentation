---
title: Convertir presentaciones de PowerPoint a SWF Flash en Python
linktitle: PowerPoint a SWF Flash
type: docs
weight: 80
url: /es/python-net/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- PowerPoint a SWF
- presentación a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en Python con Aspose.Slides. Ejemplos de código paso a paso, salida rápida y de calidad, sin automatización de PowerPoint."
---

## **Convertir Presentaciones a Flash**

El método [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) puede usarse para convertir toda la presentación en un documento SWF. También puede incluir comentarios en el SWF generado utilizando la clase [SWFOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) y la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/). El siguiente ejemplo muestra cómo convertir una presentación en un documento SWF usando las opciones proporcionadas por la clase SWFOptions.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Guardar la presentación y las páginas de notas
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **Preguntas frecuentes**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Active la opción [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) en [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Use la bandera [compressed](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/compressed/) (activada por defecto) y ajuste [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/jpeg_quality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'viewer_included' y cuándo debería desactivarlo?**

[viewer_included](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/viewer_included/) añade una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Desactívelo si planea usar su propio reproductor o necesita un marco SWF sin UI.

**¿Qué ocurre si falta una fuente origen en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/default_regular_font/) en [SwfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/swfoptions/) para evitar una sustitución no deseada.