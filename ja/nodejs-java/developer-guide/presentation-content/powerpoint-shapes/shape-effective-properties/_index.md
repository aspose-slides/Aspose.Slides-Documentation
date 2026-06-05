---
title: JavaScript でプレゼンテーションからシェイプの有効プロパティを取得
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
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js（Java）を使用して、正確な PowerPoint のレンダリングのために有効なシェイプ プロパティがどのように計算および適用されるかを確認できます。"
---
## **概要**

このトピックでは、**ローカル** と **エフェクティブ** プロパティの違いを説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、次のような場合があります:

1. スライド上のテキスト部分（ポーション）のプロパティ。
1. レイアウトまたはマスター スライド上のプロトタイプ シェイプのテキスト スタイル（該当部分のテキスト フレーム シェイプがある場合）。
1. プレゼンテーション全体のグローバル テキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「描画結果」としての書式設定が必要な場合、継承チェーンを解決し、**エフェクティブ** 値を返します。ローカル書式オブジェクトで `getEffective` メソッドを呼び出すことで取得できます。

以下の例はエフェクティブ値の取得方法を示します。最初のスライドの最初のシェイプがテキスト フレームを持ち、少なくとも1つのポーションがある [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

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
エフェクティブな書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、一部のエフェクティブ データ オブジェクトが内部でキャッシュされる場合があります。親または継承された書式を変更した後に `getEffective` を再度呼び出すと、キャッシュされたデータが更新され、以前取得したオブジェクトは以前の状態を表さない可能性があります。エフェクティブ値を後で再利用するために保持する必要がある場合は、フォントの高さ、塗りつぶし色、フォント スタイル、または配置などの必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラのエフェクティブ プロパティの取得**

Aspose.Slides を使用すると、カメラのエフェクティブ プロパティを取得できます。エフェクティブ カメラ データ オブジェクトは変更不可のカメラ プロパティを保持し、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) のエフェクティブ値として公開されます。

以下のコードサンプルはカメラのエフェクティブ プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **ライト リグのエフェクティブ プロパティの取得**

Aspose.Slides を使用すると、ライト リグのエフェクティブ プロパティを取得できます。エフェクティブ ライト リグ データオブジェクトは変更不可のライト リグ プロパティを保持し、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) のエフェクティブ値として公開されます。

以下のコードサンプルはライト リグのエフェクティブ プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **ベベル シェイプのエフェクティブ プロパティの取得**

Aspose.Slides を使用すると、シェイプ ベベルのエフェクティブ プロパティを取得できます。エフェクティブ シェイプ ベベル データ オブジェクトはシェイプの変更不可の面彫刻（フェイス リリーフ）プロパティを保持し、[ThreeDFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/) のエフェクティブ値として公開されます。

以下のコードサンプルはシェイプの上ベベルのエフェクティブ プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **テキスト フレームのエフェクティブ プロパティの取得**

Aspose.Slides を使用すると、テキスト フレームのエフェクティブ プロパティを取得できます。返されるエフェクティブ データ オブジェクトはテキスト フレームの書式設定プロパティを含みます。

以下のコードサンプルはエフェクティブなテキスト フレーム書式設定プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキスト フレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

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

## **テキスト スタイルのエフェクティブ プロパティの取得**

Aspose.Slides を使用すると、テキスト スタイルのエフェクティブ プロパティを取得できます。返されるエフェクティブ データ オブジェクトはテキスト スタイルのプロパティを含みます。

以下のコードサンプルはエフェクティブなテキスト スタイル プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキスト フレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) であることを前提としています。

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

## **エフェクティブなフォント高さの取得**

Aspose.Slides を使用すると、エフェクティブなフォント高さを取得できます。以下のコードは、プレゼンテーションのさまざまな構造レベルでローカルのフォント高さが設定された後、ポーションのエフェクティブ フォント高さがどのように変化するかを示しています。

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

## **テーブルのエフェクティブな塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対するエフェクティブな塗りつぶし書式を取得できます。返されるエフェクティブ データ オブジェクトは塗りつぶし書式プロパティを含みます。セルの書式設定は行の書式設定よりも優先度が高く、行の書式設定は列の書式設定よりも優先度が高く、列の書式設定はテーブル全体の書式設定よりも優先度が高いです。

その結果、エフェクティブなセル書式設定プロパティがテーブルセルの描画に使用されます。以下のコードサンプルは、テーブルのさまざまな部分に対するエフェクティブな塗りつぶし書式を取得する方法を示します。最初のスライドの最初のシェイプが [Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) であることを前提としています。

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

必ずしもそうではありません。エフェクティブ データは継承が適用された後に計算された書式を表しますが、一部のエフェクティブ データ オブジェクトは内部でキャッシュされることがあります。続く `getEffective` 呼び出しにより書式が再計算されキャッシュが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**エフェクティブ プロパティはいつ再取得すべきですか？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション レベルのデフォルトを変更した後に、`getEffective` を再度呼び出します。次の呼び出しで書式階層が再評価され、現在のエフェクティブ結果が返されます。

**レイアウト/マスター スライドを変更または削除すると、すでに取得したエフェクティブ プロパティに影響しますか？**

はい、ただし変更は次の `getEffective` 呼び出しで反映されます。親書式ソースが変更または削除された場合、以前取得したエフェクティブ データは古くなる可能性があります。`getEffective` を再度呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**エフェクティブ データ オブジェクトを介して値を変更できますか？**

いいえ。エフェクティブ データ オブジェクトは計算された値を公開するだけです。ローカル書式オブジェクトで変更を行い、再度エフェクティブ 値を取得してください。

**シェイプレベル、レイアウト/マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**

エフェクティブ 値はデフォルト機構により決定されます。これには PowerPoint と Aspose.Slides の既定値が含まれます。その解決された値が現在のエフェクティブ データの一部となります。

**エフェクティブなフォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接はできません。エフェクティブ データは最終的な値を返すだけです。どのレベルがソースかを知るには、ポーション、段落、テキスト フレーム、レイアウト、マスター、プレゼンテーション レベルのテキストスタイルでローカル値を確認し、最初に明示的に定義された場所を特定してください。

**なぜエフェクティブ値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となった（上位レベルの継承が必要なかった）ためです。このような場合、エフェクティブ値はローカル値と同一になります。

**エフェクティブ プロパティを使用すべき時と、ローカル プロパティだけで作業すべき時はいつですか？**

すべての継承が適用された「描画結果」が必要な場合（色やインデント、サイズを合わせるなど）、エフェクティブ データを使用します。後の書式変更に関係なくこれらの値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じてエフェクティブ データを再取得して結果を確認します。