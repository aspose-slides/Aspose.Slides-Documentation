---
title: جزء
type: docs
weight: 70
url: /php-java/portion/
---

## **احصل على إحداثيات موضع الجزء**
تم إضافة [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) إلى [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) و [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) والتي تتيح استرجاع إحداثيات بداية الجزء.

```php
  # إنشاء كائن من فئة Presentation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # إعادة تشكيل سياق العرض التقديمي
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