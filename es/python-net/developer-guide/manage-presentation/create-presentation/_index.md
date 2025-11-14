---
title: Crear una Presentación en Python
linktitle: Crear Presentación
type: docs
weight: 10
url: /es/python-net/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nueva PPT
- crear PPTX
- nueva PPTX
- crear ODP
- nueva ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Crea presentaciones de PowerPoint en Python con Aspose.Slides—produce archivos PPT, PPTX y ODP, aprovecha la compatibilidad con OpenDocument y guárdalos mediante programación para obtener resultados fiables."
---

## **Crear Presentación de PowerPoint**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue un AutoShape de tipo `LINE` utilizando el método `add_auto_shape` expuesto por el objeto `shapes`.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```