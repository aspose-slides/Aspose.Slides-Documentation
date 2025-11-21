---
title: シェイプの有効プロパティ
type: docs
weight: 50
url: /ja/nodejs-java/shape-effective-properties/
---

このトピックでは、**effective** と **local** のプロパティについて説明します。これらのレベルで直接値を設定した場合

1. スライド上の部分プロパティ;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（該当するテキストフレームシェイプがある場合）;
1. プレゼンテーションのグローバルテキスト設定;

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されても、省略されても構いません。しかし、アプリケーションがその部分の見た目を知る必要があるときは **effective** 値を使用します。ローカルフォーマットから **getEffective()** メソッドを呼び出すことで、effective 値を取得できます。

このサンプルコードは effective 値の取得方法を示しています:
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


## **Getting Effective Properties of the Camera**
Aspose.Slides for Node.js via Java を使用すると、カメラの effective プロパティを取得できます。この目的のために、[**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) クラスが Aspose.Slides に追加されました。[CameraEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) クラスは、effective カメラプロパティを含む不変オブジェクトを表します。[**CameraEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CameraEffectiveData) クラスのインスタンスは、[**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData) クラスの一部として使用されます。このクラスは、[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはカメラの effective プロパティ取得方法を示しています:
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


## **Getting Effective Properties of Light Rig**
Aspose.Slides for Node.js via Java を使用すると、ライトリグの effective プロパティを取得できます。この目的のために、[**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) クラスが Aspose.Slides に追加されました。[LightRigEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) クラスは、effective ライトルィグプロパティを含む不変オブジェクトを表します。[**LightRigEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LightRigEffectiveData) クラスのインスタンスは、[**ThreeDFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormatEffectiveData) クラスの一部として使用され、[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) ペアとなります。

このサンプルコードはライトリグの effective プロパティ取得方法を示しています:
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


## **Getting Effective Properties of Bevel Shape**
Aspose.Slides for Node.js via Java を使用すると、ベベルシェイプの effective プロパティを取得できます。この目的のために、[**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) クラスが Aspose.Slides に追加されました。[ShapeBevelEffectiveData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) クラスは、effective なシェイプの面リリーフプロパティを含む不変オブジェクトを表します。[**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData) クラスのインスタンスは、[**ThreeDFormatEffectiveData**]([**ShapeBevelEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeBevelEffectiveData)) クラスの一部として使用され、[ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはベベルシェイプの effective プロパティ取得方法を示しています:
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


## **Getting Effective Properties of a Text Frame**
Aspose.Slides for Node.js via Java を使用すると、テキストフレームの effective プロパティを取得できます。この目的のために、[**TextFrameFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormatEffectiveData) クラスが Aspose.Slides に追加されました。このクラスは effective なテキストフレームの書式プロパティを保持します。

このサンプルコードはテキストフレームの effective 書式プロパティ取得方法を示しています:
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


## **Getting Effective Properties of a Text Style**
Aspose.Slides for Node.js via Java を使用すると、テキストスタイルの effective プロパティを取得できます。この目的のために、[**TextStyleEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextStyleEffectiveData) クラスが Aspose.Slides に追加されました。このクラスは effective なテキストスタイルプロパティを保持します。

このサンプルコードはテキストスタイルの effective プロパティ取得方法を示しています:
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


## **Getting Effective Font Height Value**
Aspose.Slides for Node.js via Java を使用すると、フォント高さの effective プロパティを取得できます。ここでは、プレゼンテーション構造の異なるレベルでローカルフォント高さを設定した後に、部分の effective フォント高さがどのように変化するかを示すコードを提供します:
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


## **Getting Effective Fill Format for Table**
Aspose.Slides for Node.js via Java を使用すると、テーブルの各論理部品に対する effective 塗りつぶし書式を取得できます。この目的のために、[**CellFormatEffectiveData**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellFormatEffectiveData) クラスが Aspose.Slides に追加されました。このクラスは effective な塗りつぶし書式プロパティを保持します。注意点として、セルの書式は常に行の書式より優先され、行は列の書式より優先され、列はテーブル全体の書式より優先されます。
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

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

EffectiveData オブジェクトは呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 effective データを取得して更新された値を取得してください。

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

はい、ただし再取得したときにのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されないため、レイアウトやマスターを変更した後に再度要求してください。

**Can I modify values through EffectiveData?**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）で変更し、必要に応じて再度 effective 値を取得してください。

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

そのプロパティは PowerPoint/Aspose.Slides のデフォルトメカニズムに従って決定されます。解決されたデフォルト値が EffectiveData スナップショットに含まれます。

**From an effective font value, can I tell which level provided the size or typeface?**

直接は分かりません。EffectiveData は最終的な値のみを返します。どのレベルで設定されたかを知りたい場合は、部分/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを順に確認し、最初に明示的に定義された場所を特定してください。

**Why do EffectiveData values sometimes look identical to the local ones?**

ローカルの値が最終的な値となり、上位レベルからの継承が不要だった場合です。このようなケースでは effective 値とローカル値が一致します。

**When should I use effective properties, and when should I work only with local ones?**

すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用します（例: 色、インデント、サイズの調整）。特定のレベルで書式を変更したい場合はローカルプロパティを操作し、必要に応じて EffectiveData を再取得して結果を確認してください。