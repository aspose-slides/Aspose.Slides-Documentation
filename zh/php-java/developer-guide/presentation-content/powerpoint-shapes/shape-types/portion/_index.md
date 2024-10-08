---
title: 部分
type: docs
weight: 70
url: /php-java/portion/
---

## **获取部分的坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) 方法已添加至 [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) 和 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 类中，允许获取部分开始的坐标。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 重新调整演示文稿的上下文
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