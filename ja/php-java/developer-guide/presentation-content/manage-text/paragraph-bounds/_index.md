---
title: PHPでプレゼンテーションから段落境界を取得する
linktitle: 段落境界
type: docs
weight: 43
url: /ja/php-java/paragraph-bounds/
keywords:
- 段落境界
- 段落座標
- 段落サイズ
- テキストフレーム
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides の段落境界を取得し、PowerPoint プレゼンテーションでテキスト配置を最適化する方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides における段落の境界、サイズ、座標の取得方法を説明します。[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) から段落の矩形を取得する方法は[Paragraph::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/getrect/) を使用し、テーブルセルの TextFrame 内の段落座標の取得方法、および測定単位、テキスト折り返しが境界に与える影響、ピクセル変換、実際の段落書式設定値などの重要な詳細をハイライトしています。

## **段落の矩形座標を取得する**

段落のバウンディング矩形を取得するには、[Paragraph::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/getrect/) を使用します。

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **テーブルセルの TextFrame 内の段落のサイズを取得する**

テーブルセルの TextFrame 内の[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) のサイズと座標を取得するには、[Paragraph::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/getrect/) を使用します。返される矩形はテーブルセルの TextFrame に対して相対的であるため、スライドレベルの座標が必要な場合はテーブルの位置とセルオフセットを加算してください。

以下の例はテーブルセル内の段落境界を取得し、スライド上に矩形を描画してその境界を可視化します：

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **よくある質問**

**段落の座標はどの単位で測定されますか？**

座標はポイントで測定されます。1インチは 72 ポイントです。これはスライド上のすべての座標と寸法に適用されます。

**テキストの折り返しは段落の境界に影響しますか？**

はい。[TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/setwraptext/) が[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) に対して有効になっている場合、テキストは領域の幅に合わせて折り返され、段落の実際の境界が変わります。

**段落の座標をエクスポート画像のピクセルに確実にマッピングできますか？**

はい。ポイントをピクセルに変換するには次の式を使用します: pixels = points x (DPI / 72)。結果はレンダリングまたはエクスポート時に選択した DPI に依存します。

**スタイル継承を考慮した「実際の」段落書式設定パラメータを取得するにはどうすればよいですか？**

実効的な段落書式設定パラメータを取得するには、[effective paragraph formatting data structure](/slides/ja/php-java/shape-effective-properties/) を使用します。これによりインデント、間隔、折り返し、RTL などの最終的な統合値が返されます。