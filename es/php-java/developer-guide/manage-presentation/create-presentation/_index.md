---
title: Crear presentación de PowerPoint usando PHP
linktitle: Crear presentación
type: docs
weight: 10
url: /es/php-java/create-presentation/
keywords: crear ppt java, crear presentación ppt, crear pptx java
description: Aprende cómo crear presentaciones de PowerPoint, por ejemplo, PPT, PPTX usando PHP desde cero.
---

## **Crear presentación de PowerPoint**
Para agregar una línea simple a una diapositiva seleccionada de la presentación, sigue los pasos a continuación:

1. Crea una instancia de la clase Presentation.
1. Obtén la referencia de una diapositiva usando su índice.
1. Agrega una AutoShape de tipo línea usando el método addAutoShape expuesto por el objeto Shapes.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation();
  try {
    # Obtener la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Agregar un autoshape de tipo línea
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```