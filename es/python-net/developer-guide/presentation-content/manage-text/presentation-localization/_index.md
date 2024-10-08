---
title: Localización de Presentaciones
type: docs
weight: 100
url: /es/python-net/presentation-localization/
keywords: "Cambiar idioma, Verificación ortográfica, Corrector ortográfico, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Cambiar o verificar el idioma en una presentación de PowerPoint. Verificar ortografía del texto en Python"
---
## **Cambiar el Idioma para el Texto de la Presentación y de la Forma**
- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtener la referencia de una diapositiva utilizando su índice.
- Agregar una AutoShape del tipo Rectángulo a la diapositiva.
- Agregar algo de texto al TextFrame.
- Establecer el Id del Idioma al texto.
- Escribir la presentación como un archivo PPTX.

La implementación de los pasos anteriores se demuestra a continuación en un ejemplo.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Texto para aplicar idioma de verificación ortográfica")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```