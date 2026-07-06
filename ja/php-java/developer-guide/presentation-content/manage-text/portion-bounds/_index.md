---
title: PHP でプレゼンテーションからテキスト部分の境界を取得する
linktitle: 部分の境界
type: docs
weight: 47
url: /ja/php-java/portion-bounds/
keywords:
- テキスト部分の境界
- テキスト部分
- テキスト部
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint プレゼンテーション内のテキスト部分の境界を取得する方法を学びます。"
---
## **概要**

テキスト部分は段落内の特定の文字列を表し、周囲のコンテンツとは独立してその断片を操作できるようにします。Aspose.Slides では、テキスト断片の境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより細かく制御したりする必要がある場合に部分を使用できます。

この記事では、[Portion::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/getrect/) を使用して部分の境界矩形を取得する方法を示します。また、[Portion::getCoordinates](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/getcoordinates/) を使用して部分の開始座標を取得する方法も示します。さらに、単一のテキスト断片にハイパーリンクを適用する方法、書式設定が部分、段落、テキストフレーム、テーマの継承を通じてどのように解決されるか、指定したフォントが利用できない場合の対処方法など、部分に関する一般的なシナリオを取り上げています。

## **テキスト部分の境界を取得**

[Portion::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/getrect/) を使用してテキスト部分の境界矩形を取得します：

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **テキスト部分の座標を取得**

[Portion::getCoordinates](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/getcoordinates/) を使用してテキスト部分の開始座標を取得します：

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個別の部分に[ハイパーリンクを割り当てる](/slides/ja/php-java/manage-hyperlinks/)ことができます。その断片だけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか。部分が上書きするものと、段落やテキストフレームから取得されるものは何ですか？**

部分レベルのプロパティが最も高い優先順位を持ちます。プロパティが[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/)で設定されていない場合、Aspose.Slides は[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)から取得します。そちらでも設定されていない場合、Aspose.Slides は[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/ja/php-java/aspose.slides/theme/)のスタイルを使用します。

**部分に指定されたフォントが対象のマシンまたはサーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/php-java/font-selection-sequence/)が適用されます。テキストは再配置される可能性があり、メトリクス、ハイフネーション、幅が変わるため、正確な配置が必要な場合に影響します。

**段落全体とは別に、部分固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/)レベルでテキストの色、塗りつぶし、透明度を隣接する断片と異なる設定にできます。