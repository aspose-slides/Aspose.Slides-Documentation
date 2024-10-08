---
title: Portion
type: docs
weight: 70
url: /de/php-java/portion/
---

## **Positionkoordinaten der Portion abrufen**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) Methode wurde zur [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) und [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Anfangs der Portion abzurufen.

```php
  # Instanziieren der Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Neugestaltung des Kontexts der Präsentation
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