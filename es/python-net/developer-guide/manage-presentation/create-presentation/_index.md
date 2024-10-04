---
title: Crear Presentación
type: docs
weight: 10
url: /python-net/create-presentation/
keywords: "Crear PowerPoint, PPTX, PPT, Crear Presentación, Inicializar Presentación, Python, .NET"
description: "Abrir Presentación de PowerPoint en Python"
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