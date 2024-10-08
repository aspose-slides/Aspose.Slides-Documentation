---
title: Portion
type: docs
weight: 70
url: /fr/php-java/portion/
---

## **Obtenez les coordonnées de position de la portion**
La méthode [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) a été ajoutée à l'[IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) et à la classe [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) qui permet de récupérer les coordonnées du début de la portion.

```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    # Remodeler le contexte de la présentation
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