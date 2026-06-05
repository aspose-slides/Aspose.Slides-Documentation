---
title: PHP でプレゼンテーションからシェイプの Effective プロパティを取得
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
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides が、正確な PowerPoint 表示のために Effective シェイプ プロパティを計算・適用する方法を学びましょう。"
---
## **概要**

このトピックでは **local** と **effective** のプロパティの違いについて説明します。ローカル値とは、特定の書式設定レベルで直接設定される値で、例えば以下のようなものです。

1. スライド上の Portion プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ シェイプ テキストスタイル（Portion のテキストフレーム シェイプにある場合）。
1. プレゼンテーションのグローバルテキスト設定。

ローカル値は任意のレベルで定義または省略できます。Aspose.Slides が最終的な「レンダリングされた」書式設定を必要とする場合、継承チェーンを解決し **effective** 値を返します。ローカル書式オブジェクトの `getEffective` メソッドを呼び出すことで取得できます。

以下の例は effective 値の取得方法を示します。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも 1 つの Portion を含む [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であると想定しています。

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
Effective 書式データは、継承が適用された後に計算された現在の書式設定を表します。現在の実装では、[PortionFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/geteffective/) などのメソッドが返す一部の effective データオブジェクトは内部でキャッシュされる可能性があります。親または継承された書式設定を変更した後に `getEffective` を再度呼び出すとキャッシュが刷新され、以前取得したオブジェクトは以前の状態を表さなくなることがあります。後で再利用するために effective 値を保持する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置など必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの Effective プロパティの取得**

Aspose.Slides を使用すると、カメラの effective プロパティを取得できます。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) が返す effective データには、[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) の最終的なカメラプロパティが含まれます。

以下のコードサンプルはカメラの effective プロパティの取得方法を示します。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

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

以下のコードサンプルはライトリグの effective プロパティの取得方法を示します。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

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

## **ベベルシェイプの Effective プロパティの取得**

Aspose.Slides を使用すると、シェイプベベルの effective プロパティを取得できます。[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/geteffective/) が返す effective データには、[ThreeDFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/threedformat/) の最終的なフェイスリリーフ プロパティが含まれます。

以下のコードサンプルはシェイプの上部ベベルの effective プロパティの取得方法を示します。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

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

Aspose.Slides を使用すると、テキストフレームの effective プロパティを取得できます。[TextFrameFormat.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/geteffective/) が返す effective データにはテキストフレームの書式設定プロパティが含まれます。

以下のコードサンプルはテキストフレームの effective 書式設定プロパティの取得方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であると想定しています。

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

Aspose.Slides を使用すると、テキストスタイルの effective プロパティを取得できます。[TextStyle.getEffective](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textstyle/geteffective/) が返す effective データにはテキストスタイルのプロパティが含まれます。

以下のコードサンプルはテキストスタイルの effective プロパティの取得方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であると想定しています。

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

Aspose.Slides を使用すると、effective フォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカルのフォント高さが設定された後、Portion の effective フォント高さがどのように変化するかを示しています。

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

## **テーブルの Effective 塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対する effective 塗りつぶし書式を取得できます。書式オブジェクトが返す effective データには [FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fillformat/) のプロパティが含まれます。セルの書式は行の書式より優先され、行の書式は列の書式より優先され、列の書式はテーブル全体の書式より優先されます。

その結果、effective な [CellFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellformat/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルはテーブルのさまざまな部分に対する effective 塗りつぶし書式の取得方法を示します。最初のスライドの最初のシェイプが [Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/table/) であると想定しています。

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

**Does `getEffective` return a snapshot?**

常にではありません。Effective データは継承が適用された後に計算された書式設定を表しますが、一部の effective データオブジェクトは内部でキャッシュされる可能性があります。`getEffective` を再度呼び出すと書式設定が再計算されキャッシュが刷新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**When should I read effective properties again?**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション全体のデフォルトを変更した後に `getEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の effective 結果が返されます。

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

はい。ただし、変更は次回の `getEffective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した effective データは古くなる可能性があります。再度 `getEffective` を呼び出すと Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

**Can I modify values through effective data objects?**

できません。Effective データオブジェクトは計算済みの値を公開するだけです。変更はローカル書式オブジェクトで行い、再度 effective 値を取得してください。

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

そのプロパティの effective 値は PowerPoint および Aspose.Slides の既定メカニズムに基づいて決定されます。解決された既定値が現在の effective データの一部となります。

**From an effective font value, can I tell which level provided the size or typeface?**

直接的には分かりません。Effective データは最終的な値を返すだけです。どのレベルで最初に明示的に定義されたかを知りたい場合は、Portion、Paragraph、TextFrame、そしてレイアウト・マスター・プレゼンテーションレベルのローカル値を順に確認してください。

**Why do effective values sometimes look identical to the local ones?**

ローカル値が最終的な値となった（上位レベルからの継承が不要だった）場合です。このような場合、effective 値はローカル値と一致します。

**When should I use effective properties, and when should I work only with local ones?**

継承がすべて適用された「レンダリング結果」が必要なときは effective データを使用してください。例えば、色やインデント、サイズを正確に合わせる場合などです。後で値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて effective データを再取得して結果を確認してください。