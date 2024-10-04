---
title: Crear presentación de PowerPoint usando Java
linktitle: Crear presentación
type: docs
weight: 10
url: /java/create-presentation/
keywords: crear ppt java, crear presentación ppt, crear pptx java
description: Aprende a crear presentaciones de PowerPoint, por ejemplo, PPT, PPTX usando Java desde cero.
---

## **Crear presentación de PowerPoint**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
1. Obtén la referencia de una diapositiva usando su índice.
1. Agrega una AutoShape del tipo Línea utilizando el método addAutoShape expuesto por el objeto Shapes.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar un autoshape del tipo línea
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```