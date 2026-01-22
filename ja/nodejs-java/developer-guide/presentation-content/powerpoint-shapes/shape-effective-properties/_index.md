---
title: JavaScript でプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/nodejs-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライトリグ
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
description: "Aspose.Slides for Node.js via Java が、正確な PowerPoint 表示のためにシェイプの有効なプロパティを計算し適用する方法を紹介します。"
---

このトピックでは、**effective** と **local** プロパティについて説明します。これらのレベルで値を直接設定する場合

1. パーツのスライド上のプロパティで;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプテキストスタイルで（パーツのテキストフレームシェイプにある場合）;
1. プレゼンテーション全体のテキスト設定で;

これらの値は **local** 値と呼ばれます。任意のレベルで、**local** 値は定義されても、されなくてもかまいません。但し、アプリケーションがパーツの外観を知る必要があるときは、**effective** 値を使用します。**getEffective()** メソッドをローカルフォーマットから呼び出すことで、effective 値を取得できます。

このサンプルコードは、effective 値の取得方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    var effectiveTextFrameFormat = localTextFrameFormat.getEffective();
    var localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    var effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カメラのEffectiveプロパティの取得**
Aspose.Slides for Node.js via Java を使用すると、開発者はカメラの effective プロパティを取得できます。この目的のために、Aspose.Slides に **CameraEffectiveData** クラスが追加されました。**CameraEffectiveData** クラスは、effective カメラ プロパティを保持する不変オブジェクトを表します。**CameraEffectiveData** クラスのインスタンスは **ThreeDFormatEffectiveData** クラスの一部として使用され、これは [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) のペアである [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスに対応します。

このサンプルコードは、カメラの effective プロパティを取得する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective camera properties =");
    console.log("Type: " + threeDEffectiveData.getCamera().getCameraType());
    console.log("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    console.log("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Light Rig のEffectiveプロパティの取得**
Aspose.Slides for Node.js via Java を使用すると、開発者は Light Rig の effective プロパティを取得できます。この目的のために、Aspose.Slides に **LightRigEffectiveData** クラスが追加されました。**LightRigEffectiveData** クラスは、effective ライトリグ プロパティを保持する不変オブジェクトを表します。**LightRigEffectiveData** クラスのインスタンスは **ThreeDFormatEffectiveData** クラスの一部として使用され、これは [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) のペアである [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスに対応します。

このサンプルコードは、Light Rig の effective プロパティを取得する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective light rig properties =");
    console.log("Type: " + threeDEffectiveData.getLightRig().getLightType());
    console.log("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ベベルシェイプの Effective プロパティの取得**
Aspose.Slides for Node.js via Java を使用すると、開発者はベベルシェイプの effective プロパティを取得できます。この目的のために、Aspose.Slides に **ShapeBevelEffectiveData** クラスが追加されました。**ShapeBevelEffectiveData** クラスは、effective なシェイプの面リリーフ プロパティを保持する不変オブジェクトを表します。**ShapeBevelEffectiveData** クラスのインスタンスは **ThreeDFormatEffectiveData** クラスの一部として使用され、これは [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) のペアである [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスに対応します。

このサンプルコードは、ベベルシェイプの effective プロパティを取得する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();
    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    console.log("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    console.log("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストフレームの Effective プロパティの取得**
Aspose.Slides for Node.js via Java を使用すると、テキストフレームの effective プロパティを取得できます。この目的のために、Aspose.Slides に **TextFrameFormatEffectiveData** クラスが追加されました。これは effective なテキストフレームの書式設定プロパティを含みます。

このサンプルコードは、effective なテキストフレーム書式設定プロパティを取得する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();
    console.log("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    console.log("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    console.log("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    console.log("Margins");
    console.log("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    console.log("   Top: " + effectiveTextFrameFormat.getMarginTop());
    console.log("   Right: " + effectiveTextFrameFormat.getMarginRight());
    console.log("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テキストスタイルの Effective プロパティの取得**
Aspose.Slides for Node.js via Java を使用すると、テキストスタイルの effective プロパティを取得できます。この目的のために、Aspose.Slides に **TextStyleEffectiveData** クラスが追加されました。これは effective なテキストスタイル プロパティを含みます。

このサンプルコードは、effective なテキストスタイル プロパティを取得する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    for (var i = 0; i <= 8; i++) {
        var effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        console.log(("= Effective paragraph formatting for style level #" + i) + " =");
        console.log("Depth: " + effectiveStyleLevel.getDepth());
        console.log("Indent: " + effectiveStyleLevel.getIndent());
        console.log("Alignment: " + effectiveStyleLevel.getAlignment());
        console.log("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Effective フォント高さ値の取得**
Aspose.Slides for Node.js via Java を使用すると、フォント高さの effective プロパティを取得できます。ここでは、プレゼンテーションの各レベルでローカルフォント高さが設定された後に、パーツの effective フォント高さ値が変化する様子を示すコードを提供します。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();
    var portion0 = new aspose.slides.Portion("Sample text with first portion");
    var portion1 = new aspose.slides.Portion(" and second portion.");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    console.log("Effective font height after setting entire presentation default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    console.log("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());
    pres.save("SetLocalFontHeightValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **テーブルの Effective 塗りつぶし書式の取得**
Aspose.Slides for Node.js via Java を使用すると、テーブルのさまざまな論理部分の effective 塗りつぶし書式を取得できます。この目的のために、Aspose.Slides に **CellFormatEffectiveData** クラスが追加されました。これは effective な塗りつぶし書式プロパティを含みます。次の点に注意してください：セルの書式設定は常に行の書式設定より優先され、行は列の書式設定より優先され、列はテーブル全体の書式設定より優先されます。
```javascript
var pres = new aspose.slides.Presentation("Presentation1.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var tableFormatEffective = tbl.getTableFormat().getEffective();
    var rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    var columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    var cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();
    var tableFillFormatEffective = tableFormatEffective.getFillFormat();
    var rowFillFormatEffective = rowFormatEffective.getFillFormat();
    var columnFillFormatEffective = columnFormatEffective.getFillFormat();
    var cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**取得したオブジェクトが「スナップショット」か「ライブオブジェクト」かをどのように判断し、いつ effective プロパティを再取得すべきですか？**
EffectiveData オブジェクトは、呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合、更新された値を取得するために effective データを再取得してください。

**レイアウト/マスタースライドを変更すると、すでに取得した effective プロパティに影響しますか？**
はい、ただし再度読み取ったときにのみ反映されます。すでに取得した EffectiveData オブジェクトは自動で更新されません—レイアウトまたはマスターを変更した後に再度取得してください。

**EffectiveData を通じて値を変更できますか？**
いいえ。EffectiveData は読み取り専用です。ローカルの書式設定オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 effective 値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**
effective 値はデフォルトのメカニズム（PowerPoint/Aspose.Slides の既定値）により決定されます。その解決された値が EffectiveData のスナップショットに含まれます。

**effective フォント値から、どのレベルがサイズまたはフォント名を提供したか判断できますか？**
直接はできません。EffectiveData は最終的な値を返すだけです。元を調べるには、パーツ/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初の明示的な定義がどこにあるかを見つけます。

**EffectiveData の値がローカル値と同じに見えることがあるのはなぜですか？**
ローカル値が最終的な値となったため（上位レベルからの継承が不要）です。その場合、effective 値はローカル値と同一になります。

**effective プロパティを使用すべき時と、ローカルプロパティだけで作業すべき時はいつですか？**
すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用します（例：色、インデント、サイズを合わせる場合）。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて EffectiveData を再取得して結果を確認してください。