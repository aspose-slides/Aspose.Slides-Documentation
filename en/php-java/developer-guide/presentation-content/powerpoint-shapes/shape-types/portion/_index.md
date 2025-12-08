---
title: Manage Text Portions in Presentations Using PHP
linktitle: Text Portion
type: docs
weight: 70
url: /php-java/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for PHP via Java, boosting performance and customization."
---

## **Get Position Coordinates of Portion**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) method has been added to [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) and [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

```php
  # Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Reshaping the context of presentation
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
