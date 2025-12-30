---
title: Administrar porciones de texto en presentaciones usando PHP
linktitle: Porción de texto
type: docs
weight: 70
url: /es/php-java/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para PHP a través de Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) and [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Reformar el contexto de la presentación
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/php-java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Portion y qué se toma del Paragraph/TextFrame?**

Las propiedades a nivel de Portion tienen la precedencia más alta. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); si tampoco está establecida allí, del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Portion falta en la máquina/servidor de destino?**

[Font substitution rules](/slides/es/php-java/font-selection-sequence/) se aplican. El texto puede reorganizarse: las métricas, la hyphenation y el ancho pueden cambiar, lo que es importante para una posición precisa.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Portion independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) pueden diferir de los fragmentos adyacentes.