---
title: Gestionar porciones de texto en presentaciones usando PHP
linktitle: Porción de texto
type: docs
weight: 70
url: /es/php-java/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición del texto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para PHP a través de Java, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
Se ha añadido el método [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) a la clase [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) que permite obtener las coordenadas del inicio de la porción.
```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Reformando el contexto de la presentación
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

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Porción y qué se toma del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); si tampoco está establecida allí, del [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está disponible en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/php-java/font-selection-sequence/). El texto puede reflujo: las métricas, la separación de sílabas y el ancho pueden variar, lo que es relevante para una posición precisa.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Porción, independiente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel de [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.