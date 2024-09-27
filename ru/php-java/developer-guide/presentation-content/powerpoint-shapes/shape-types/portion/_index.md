---
title: Порция
type: docs
weight: 70
url: /ru/php-java/portion/
---

## **Получение координат позиции порции**
Метод [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) был добавлен в [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) и класс [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion), который позволяет извлекать координаты начала порции.

```php
  # Создание экземпляра класса Presentation, который представляет PPTX
  $pres = new Presentation();
  try {
    # Изменение контекста презентации
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