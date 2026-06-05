---
title: JavaScript でプレゼンテーションからシェイプの有効プロパティを取得する
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/nodejs-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js (Java) が、正確な PowerPoint のレンダリングのためにシェイプの有効プロパティを計算し適用する方法をご紹介します。"
---
## **概要**

このトピックでは、**ローカル** と **有効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、例えば次のようなものです:

1. スライド上の部分（ポーション）プロパティ。
1. レイアウトやマスタースライド上のプロトタイプシェイプのテキストスタイル（その部分のテキストフレームシェイプが存在する場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「描画結果」としての書式設定を必要とする場合、継承チェーンを解決して **有効** な値を返します。ローカル書式オブジェクトの `getEffective` メソッドを呼び出すことで取得できます。

以下の例は、有効な値を取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも1つの部分がある [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
有効な書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、一部の有効データオブジェクトが内部でキャッシュされることがあります。親や継承された書式を変更した後に `getEffective` を再度呼び出すと、キャッシュされたデータが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために有効な値を保持する必要がある場合は、フォント高さ、塗りつぶしカラー、フォントスタイル、配置などの必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティの取得**

Aspose.Slides を使用すると、カメラの有効プロパティを取得できます。有効なカメラデータオブジェクトは不変のカメラプロパティを含み、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) の有効値として返されます。

以下のコードサンプルは、カメラの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **ライトリグの有効プロパティの取得**

Aspose.Slides を使用すると、ライトリグの有効プロパティを取得できます。有効なライトリグデータオブジェクトは不変のライトリグプロパティを含み、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) の有効値として返されます。

以下のコードサンプルは、ライトリグの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **ベベルシェイプの有効プロパティの取得**

Aspose.Slides を使用すると、シェイプベベルの有効プロパティを取得できます。有効なシェイプベベルデータオブジェクトはシェイプの不変の面（フェイス）リリーフプロパティを含み、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) の有効値として返されます。

以下のコードサンプルは、シェイプの上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **テキストフレームの有効プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの有効プロパティを取得できます。返される有効データオブジェクトはテキストフレームの書式設定プロパティを含みます。

以下のコードサンプルは、テキストフレームの有効な書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **テキストスタイルの有効プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの有効プロパティを取得できます。返される有効データオブジェクトはテキストスタイルのプロパティを含みます。

以下のコードサンプルは、テキストスタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **有効なフォント高さ値の取得**

Aspose.Slides を使用すると、有効なフォント高さを取得できます。以下のコードは、プレゼンテーションのさまざまな階層でローカルのフォント高さが設定された後、部分の有効フォント高さがどのように変化するかを示しています。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **テーブルの有効な塗りつぶし形式の取得**

Aspose.Slides を使用すると、テーブルのさまざまなパーツに対する有効な塗りつぶし書式設定を取得できます。返される有効データオブジェクトは塗りつぶし書式設定プロパティを含みます。セルの書式設定は行の書式設定よりも優先度が高く、行の書式設定は列の書式設定よりも優先度が高く、列の書式設定はテーブル全体の書式設定よりも優先度が高いです。

結果として、テーブルセルの描画には有効なセル書式設定プロパティが使用されます。以下のコードサンプルは、テーブルのさまざまなパーツに対する有効な塗りつぶし書式設定を取得する方法を示しています。最初のスライドの最初のシェイプが [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) であることを前提としています。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` はスナップショットを返しますか？**

必ずしもそうではありません。有効データは継承が適用された後に計算された書式を表しますが、一部の有効データオブジェクトは内部でキャッシュされることがあります。その後の `getEffective` 呼び出しでは書式が再計算され、キャッシュデータが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**有効プロパティを再度取得すべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `getEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の有効結果が返されます。

**レイアウト／マスタースライドの変更や削除は、すでに取得した有効プロパティに影響しますか？**

はい。ただし、変更は次回の `getEffective` 呼び出し時に反映されます。親の書式設定ソースが変更または削除されると、以前取得した有効データは古くなる可能性があります。`getEffective` を再度呼び出すと、Aspose.Slides は書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**有効データオブジェクトを通じて値を変更できますか？**

いいえ。有効データオブジェクトは計算された値を提供するだけです。ローカルの書式設定オブジェクトで変更を行い、再度有効な値を取得してください。

**シェイプレベル、レイアウト／マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**

有効値はデフォルト機構により決定されます。この機構は PowerPoint と Aspose.Slides のデフォルトを含みます。解決された値が現在の有効データの一部となります。

**有効なフォント値から、どの階層がサイズやフォント名を提供したか判別できますか？**

直接的には判別できません。有効データは最終的な値を返すだけです。どの階層が元となったかを確認するには、部分、段落、テキストフレーム、そしてレイアウト、マスター、プレゼンテーションレベルのテキストスタイルのローカル値を調べ、最初に明示的に定義されている箇所を探してください。

**なぜ有効値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となった（上位レベルの継承が必要なかった）ためです。このような場合、有効値はローカル値と一致します。

**有効プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**

すべての継承が適用された「描画結果」が必要な場合（色やインデント、サイズを合わせるなど）は、有効データを使用してください。後の書式変更に関係なくそれらの値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーします。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて有効データを再度取得して結果を確認してください。