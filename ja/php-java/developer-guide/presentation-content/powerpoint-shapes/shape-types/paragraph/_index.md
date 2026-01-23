---
title: PHP でプレゼンテーションから段落境界を取得する
linktitle: 段落
type: docs
weight: 60
url: /ja/php-java/paragraph/
keywords:
- 段落境界
- テキストポーション境界
- 段落座標
- ポーション座標
- 段落サイズ
- テキストポーションサイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で段落とテキストポーションの境界を取得し、PowerPoint プレゼンテーションのテキスト位置を最適化する方法を学びます。"
---

## **テキストフレーム内の段落とポーションの座標を取得する**
Aspose.Slides for PHP via Java を使用すると、開発者はテキストフレームの段落コレクション内の段落の矩形座標を取得できるようになります。また、段落のポーションコレクション内の[ポーションの座標](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getCoordinates)も取得できます。この項目では、例を使って段落の矩形座標と段落内のポーションの位置を取得する方法を示します。
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
[**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) メソッドを使用すると、段落の境界矩形を取得できます。
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


## **テーブルセルのテキストフレーム内の段落およびポーションのサイズを取得する**

テーブルセルのテキストフレーム内の[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)または[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)のサイズと座標を取得するには、[Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) および [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) メソッドを使用できます。

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

**段落とテキストポーションの座標はどの単位で返されますか？**

ポイントで返されます。1 インチ = 72 ポイントです。スライド上のすべての座標と寸法に適用されます。

**単語ラッピングは段落の境界に影響しますか？**

はい。[ラッピング](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) が [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) で有効になっている場合、テキストは領域幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポート画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換する式は: pixels = points × (DPI / 72)。結果はレンダリング/エクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実効」段落書式パラメータを取得するには？**

[実効段落書式データ構造](/slides/ja/php-java/shape-effective-properties/) を使用してください。インデント、間隔、ラッピング、RTL などの最終的な統合値が返されます。