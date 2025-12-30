---
title: PHP のプレゼンテーションから段落の境界を取得する
linktitle: 段落
type: docs
weight: 60
url: /ja/php-java/paragraph/
keywords:
- 段落の境界
- テキストポーションの境界
- 段落座標
- ポーション座標
- 段落サイズ
- テキストポーションサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で段落とテキストポーションの境界を取得し、PowerPoint プレゼンテーションにおけるテキスト配置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落およびポーションの座標取得**
Aspose.Slides for PHP via Java を使用すると、開発者は TextFrame の段落コレクション内の Paragraph の矩形座標を取得できるようになりました。また、段落のポーションコレクション内の [ポーションの座標](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) を取得することもできます。このトピックでは、例を使って段落の矩形座標と段落内のポーションの位置を取得する方法を示します。
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **段落の矩形座標取得**
開発者は [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) メソッドを使用して段落の境界矩形を取得できます。
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **テーブルセルの TextFrame 内の段落およびポーションのサイズ取得**
テーブルセルの TextFrame で [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) または [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) のサイズと座標を取得するには、[IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) および [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) メソッドを使用できます。

このサンプルコードは上記の操作を示しています：
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


## **FAQ**

**段落およびテキストポーションの座標はどの単位で返されますか？**  
ポイント単位です。1 インチ = 72 ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**ワードラップは段落の境界に影響しますか？**  
はい。もし [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) が [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) で有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポートされた画像のピクセルに確実にマッピングできますか？**  
はい。ポイントをピクセルに変換するには次の式を使用します: pixels = points × (DPI / 72)。結果はレンダリング/エクスポートに使用する DPI に依存します。

**スタイルの継承を考慮した「実効」段落書式設定パラメータを取得するにはどうすればよいですか？**  
[effective paragraph formatting data structure](/slides/ja/php-java/shape-effective-properties/) を使用します。インデント、間隔、ラップ、RTL などの最終的に統合された値を返します。