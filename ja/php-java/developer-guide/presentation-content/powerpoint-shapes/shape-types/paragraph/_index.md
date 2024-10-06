---
title: 段落
type: docs
weight: 60
url: /ja/php-java/paragraph/
---


## テキストフレーム内の段落およびポーションの座標を取得する ##
Aspose.Slides for PHP via Javaを使用して、開発者はテキストフレームの段落コレクション内の段落の矩形座標を取得できるようになりました。また、段落のポーションコレクション内の[ポーションの座標](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--)を取得することもできます。このトピックでは、段落の矩形座標と段落内のポーションの位置を取得する方法を例を示して説明します。

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **段落の矩形座標を取得する**
[**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)メソッドを使用することで、開発者は段落の境界矩形を取得できます。

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " 幅: " . $rect->$width . " 高さ: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **テーブルセルのテキストフレーム内の段落およびポーションのサイズを取得する** ##

テーブルセルのテキストフレーム内の[ポーション](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)または[段落](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--)および[IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)メソッドを使用できます。

このサンプルコードは、記述された操作を示しています：

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```