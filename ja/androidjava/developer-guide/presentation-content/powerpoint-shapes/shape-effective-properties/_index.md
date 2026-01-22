---
title: Android でのプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/androidjava/shape-effective-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java が、正確な PowerPoint 表示のためにシェイプの有効プロパティを計算および適用する方法をご紹介します。"
---

このトピックでは、**有効**プロパティと**ローカル**プロパティについて説明します。これらのレベルで直接値を設定する場合

1. 部分のスライド上の部分プロパティ;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプテキストスタイル（部分のテキストフレームシェイプにある場合）;
1. プレゼンテーション全体のテキスト設定;

これらの値は **ローカル** 値と呼ばれます。任意のレベルで **ローカル** 値は定義されても、されなくてもかまいません。ただし、アプリケーションがその部分の表示を知る必要がある場合は **有効** 値を使用します。**getEffective()** メソッドをローカル形式から呼び出すことで **有効** 値を取得できます。

このサンプルコードは **有効** 値の取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IPortionFormat localPortionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    if (pres != null) pres.dispose();
}
```


## **カメラの有効プロパティを取得**
Aspose.Slides for Android via Java は、開発者がカメラの有効プロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) インターフェイスは、カメラの有効プロパティを保持する不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) クラスの[effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはカメラの有効プロパティの取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("Field of view: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("Zoom: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **ライトリグの有効プロパティを取得**
Aspose.Slides for Android via Java は、開発者がライトリグの有効プロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) インターフェイスは、ライトリグの有効プロパティを保持する不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) クラスの[effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはライトリグの有効プロパティの取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("Direction: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```


## **ベベルシェイプの有効プロパティを取得**
Aspose.Slides for Android via Java は、開発者がベベルシェイプの有効プロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスが Aspose.Slides に追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスは、シェイプの面リリーフの有効プロパティを保持する不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat) クラスの[effective values](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはベベルシェイプの有効プロパティの取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("Width: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("Height: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストフレームの有効プロパティを取得**
Aspose.Slides for Android via Java を使用すると、テキストフレームの有効プロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これにはテキストフレームの有効な書式設定プロパティが含まれます。

このサンプルコードはテキストフレームの有効書式設定プロパティの取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```


## **テキストスタイルの有効プロパティを取得**
Aspose.Slides for Android via Java を使用すると、テキストスタイルの有効プロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには有効なテキストスタイルプロパティが含まれます。

このサンプルコードはテキストスタイルの有効プロパティの取得方法を示しています:
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= Effective paragraph formatting for style level #" + i + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **有効なフォント高さの値を取得**
Aspose.Slides for Android via Java を使用すると、フォント高さの有効プロパティを取得できます。ここでは、プレゼンテーションの異なる構造レベルでローカルフォント高さが設定された後に、部分の有効フォント高さの値が変化するコードを示しています:
```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("Effective font height just after creation:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("Effective font height after setting entire presentation default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("Effective font height after setting paragraph default font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("Effective font height after setting portion #0 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("Effective font height after setting portion #1 font height:");
    System.out.println("Portion #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("Portion #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **テーブルの有効な塗りつぶし書式を取得**
Aspose.Slides for Android via Java を使用すると、テーブルのさまざまな論理部分の有効な塗りつぶし書式を取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには有効な塗りつぶし書式プロパティが含まれます。注意点として、セル書式は常に行書式より優先され、行は列より優先され、列はテーブル全体より優先されます。
```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    ITable tbl = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITableFormatEffectiveData tableFormatEffective = tbl.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = tbl.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = tbl.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = tbl.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**「スナップショット」か「ライブオブジェクト」かを判断する方法、そして有効プロパティを再取得すべきタイミングは？**

EffectiveData オブジェクトは呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト/マスタースライドを変更すると、既に取得した有効プロパティは影響を受けますか？**

はい、ただし再取得したときのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されません。レイアウトまたはマスターを変更した後に再度取得してください。

**EffectiveData を通じて値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）を変更し、その後必要に応じて EffectiveData を再取得してください。

**シェイプレベル、レイアウト/マスター、全体設定のいずれにもプロパティが設定されていない場合はどうなりますか？**

有効値はデフォルトの仕組み（PowerPoint/Aspose.Slides のデフォルト）によって決定されます。その解決された値が EffectiveData のスナップショットに含まれます。

**有効なフォント値から、サイズやフォント名がどのレベルで設定されたか判断できますか？**

直接はできません。EffectiveData は最終的な値のみを返します。ソースを特定するには、部分/段落/テキストフレームのローカル値やレイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探してください。

**なぜ EffectiveData の値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。そのような場合、EffectiveData の値はローカル値と一致します。

**有効プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**

すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用します（例: 色、インデント、サイズの整合）。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて EffectiveData を再取得して結果を確認してください。