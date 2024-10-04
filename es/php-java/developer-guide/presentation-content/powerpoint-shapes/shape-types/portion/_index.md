---
title: Porción
type: docs
weight: 70
url: /php-java/portion/
---

## **Obtener las coordenadas de posición de la porción**
Se ha añadido el método [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) a [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) y a la clase [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) que permite recuperar las coordenadas del inicio de la porción.

```php
  # Instanciar la clase Presentation que representa el PPTX
  $pres = new Presentation();
  try {
    # Reestructurando el contexto de la presentación
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