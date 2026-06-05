---
title: PHP でプレゼンテーションからシェイプの Effective プロパティを取得する
linktitle: Effective プロパティ
type: docs
weight: 50
url: /ja/php-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗り 書式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides が、正確な PowerPoint 表示のためにシェイプの Effective プロパティを計算し適用する方法を紹介します。"
---
## **概要**

このトピックでは **local** と **effective** プロパティの違いについて説明します。ローカル値は、次のような特定の書式設定レベルで直接設定される値です。

1. スライド上の Portion プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（Portion のテキストフレームシェイプがある場合）。
1. プレゼンテーション内のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式設定を必要とする場合、継承チェーンを解決して **effective** 値を返します。ローカル書式オブジェクトで `getEffective` メソッドを呼び出すことで取得できます。

次の例は、effective 値の取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームと少なくとも 1 つの Portion を持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Effective 書式データは、継承が適用された後に計算された現在の書式設定を表します。現在の実装では、[PortionFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) などのメソッドが返す一部の effective データオブジェクトが内部でキャッシュされる場合があります。親または継承された書式設定を変更した後に `getEffective` を再度呼び出すとキャッシュがリフレッシュされ、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために effective 値を保持する必要がある場合は、フォントの高さ、塗りの色、フォントスタイル、配置など必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの Effective プロパティの取得**

Aspose.Slides を使用すると、カメラの effective プロパティを取得できます。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) が返す effective データには、[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) の最終的なカメラプロパティが含まれます。

次のコードサンプルは、カメラの effective プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **ライトリグの Effective プロパティの取得**

Aspose.Slides を使用すると、ライトリグの effective プロパティを取得できます。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) が返す effective データには、[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) の最終的なライトリグプロパティが含まれます。

次のコードサンプルは、ライトリグの effective プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **シェイプベベルの Effective プロパティの取得**

Aspose.Slides を使用すると、シェイプベベルの effective プロパティを取得できます。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) が返す effective データには、[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) の最終的なフェイスリリーフプロパティが含まれます。

次のコードサンプルは、シェイプの上部ベベルの effective プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **テキストフレームの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの effective プロパティを取得できます。[TextFrameFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/geteffective/) が返す effective データには、テキストフレームの書式設定プロパティが含まれます。

次のコードサンプルは、テキストフレームの effective 書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **テキストスタイルの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの effective プロパティを取得できます。[TextStyle.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textstyle/geteffective/) が返す effective データには、テキストスタイルのプロパティが含まれます。

次のコードサンプルは、テキストスタイルの effective プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Effective フォント高さ値の取得**

Aspose.Slides を使用すると、effective フォント高さを取得できます。次のコードは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後、Portion の effective フォント高さがどのように変化するかを示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **テーブルの Effective 塗り設定の取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対する effective 塗り書式設定を取得できます。フォーマットオブジェクトが返す effective データには [FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) のプロパティが含まれます。セルの書式設定は行の書式設定より優先され、行の書式設定は列の書式設定より、列の書式設定はテーブル全体の書式設定より優先されます。

その結果、effective な [CellFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellformat/) プロパティがテーブルセルの描画に使用されます。次のコードサンプルは、テーブルのさまざまな部分に対する effective 塗り書式設定を取得する方法を示しています。最初のスライドの最初のシェイプが [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) であることを前提としています。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**`getEffective` はスナップショットを返しますか？**

常にではありません。Effective データは継承が適用された後に計算された書式設定を表しますが、一部の effective データオブジェクトは内部でキャッシュされる可能性があります。`getEffective` を再度呼び出すと書式設定が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**Effective プロパティを再度取得すべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `getEffective` を再度呼び出します。次の呼び出しで書式階層が再評価され、現在の effective 結果が返されます。

**レイアウト／マスタースライドを変更または削除すると、すでに取得した effective プロパティに影響しますか？**

はい。ただし変更は次の `getEffective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した effective データは古くなる可能性があります。`getEffective` を再度実行すると Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

**effective データオブジェクトを通じて値を変更できますか？**

できません。effective データオブジェクトは計算された値を公開するだけです。ローカル書式オブジェクトで変更し、再度 effective 値を取得してください。

**シェイプレベルでもレイアウト／マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

effective 値はデフォルトメカニズムに基づいて決定されます。これは PowerPoint と Aspose.Slides のデフォルト設定を含みます。解決された値が現在の effective データの一部となります。

**effective フォント値から、どのレベルがサイズまたはフォント名を提供したか判断できますか？**

直接は判断できません。effective データは最終的な値を返すだけです。ソースを特定するには、Portion、Paragraph、TextFrame、そしてレイアウト、マスター、プレゼンテーションレベルのテキストスタイルのローカル値を確認し、最初に明示的に定義された場所を探します。

**effective 値がローカル値と同じに見えるのはなぜですか？**

ローカル値が最終的な値となった（上位レベルからの継承が不要だった）ためです。このような場合、effective 値はローカル値と一致します。

**effective プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**

すべての継承が適用された「レンダリング後」の結果が必要な場合は effective データを使用します。例えば、色やインデント、サイズを揃える際などです。後の書式変更に関係なくその値を保持したい場合は、必要なプロパティを独自のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて effective データを再取得して結果を確認します。