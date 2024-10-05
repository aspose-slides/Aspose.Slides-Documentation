---
title: 部分
type: docs
weight: 70
url: /php-java/portion/
---

## **部分の位置座標を取得する**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) メソッドが [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) および [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) クラスに追加され、部分の始まりの座標を取得できるようになりました。

```php
  # PPTXを表すPresentationクラスをインスタンス化する
  $pres = new Presentation();
  try {
    # プレゼンテーションのコンテキストを再構築する
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