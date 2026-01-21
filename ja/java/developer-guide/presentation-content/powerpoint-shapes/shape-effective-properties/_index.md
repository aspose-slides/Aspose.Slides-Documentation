---
title: Java のプレゼンテーションからシェイプの実効プロパティを取得
linktitle: 実効プロパティ
type: docs
weight: 50
url: /ja/java/shape-effective-properties/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が正確な PowerPoint のレンダリングのために実効シェイププロパティを計算し適用する方法をご紹介します。"
---

このトピックでは、**effective** と **local** プロパティについて説明します。これらのレベルで直接値を設定する場合

1. 部分のスライド上の部分プロパティで;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイルで（部分のテキストフレームシェイプにある場合）;
1. プレゼンテーションのグローバルテキスト設定で;

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されてもされなくても構いません。しかし、アプリケーションが部分の表示結果を知る必要がある場合は **effective** 値を使用します。**local** フォーマットから **getEffective()** メソッドを呼び出すことで **effective** 値を取得できます。

このサンプルコードは **effective** 値の取得方法を示しています:
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


## **カメラの実効プロパティを取得**
Aspose.Slides for Java は開発者がカメラの実効プロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスは、実効カメラ プロパティを含む不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはカメラの実効プロパティの取得方法を示しています:
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


## **ライトリグの実効プロパティを取得**
Aspose.Slides for Java は開発者がライトリグの実効プロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスは、実効ライトリグ プロパティを含む不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはライトリグの実効プロパティの取得方法を示しています:
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


## **ベベル形状の実効プロパティを取得**
Aspose.Slides for Java は開発者がベベル形状の実効プロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスが Aspose.Slides に追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスは、実効形状の面リリーフ プロパティを含む不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

このサンプルコードはベベル形状の実効プロパティの取得方法を示しています:
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


## **テキストフレームの実効プロパティを取得**
Aspose.Slides for Java を使用すると、テキストフレームの実効プロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには実効テキストフレーム書式プロパティが含まれます。

このサンプルコードはテキストフレームの実効書式プロパティの取得方法を示しています:
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


## **テキストスタイルの実効プロパティを取得**
Aspose.Slides for Java を使用すると、テキストスタイルの実効プロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには実効テキストスタイル プロパティが含まれます。

このサンプルコードはテキストスタイルの実効プロパティの取得方法を示しています:
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


## **実効フォント高さの取得**
Aspose.Slides for Java を使用すると、フォント高さの実効プロパティを取得できます。ここでは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後に、部分の実効フォント高さが変化するコードを示します:
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


## **テーブルの実効塗りつぶし書式を取得**
Aspose.Slides for Java を使用すると、テーブルのさまざまな論理部位に対して実効塗りつぶし書式を取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これには実効塗りつぶし書式プロパティが含まれます。注意点として、セルの書式は常に行の書式より優先され、行は列の書式より優先され、列はテーブル全体の書式より優先されます。
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

**「スナップショット」と「ライブオブジェクト」の違いはどう判断し、実効プロパティはいつ再取得すべきですか？**

EffectiveData オブジェクトは呼び出し時点の計算値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト/マスタースライドを変更すると、既に取得した実効プロパティは影響を受けますか？**

はい、ただし再取得したときにのみ反映されます。既に取得した EffectiveData オブジェクトは自動更新されません。レイアウトまたはマスターを変更した後に再取得してください。

**EffectiveData を介して値を変更できますか？**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 EffectiveData を取得して結果を確認してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

実効値はデフォルトのメカニズム（PowerPoint/Aspose.Slides のデフォルト）により決定されます。その解決された値が EffectiveData のスナップショットに含まれます。

**実効フォント値から、どのレベルがサイズまたは書体を提供したか判断できますか？**

直接はできません。EffectiveData は最終的な値を返します。ソースを特定したい場合は、部分/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探してください。

**実効データの値がローカル値と同じに見えることがありますが、なぜですか？**

ローカル値が最終的な値となり、上位レベルの継承が不要だったためです。この場合、実効値はローカル値と一致します。

**実効プロパティはいつ使用し、ローカルプロパティだけを使うべき場面は？**

すべての継承が適用された「実際に表示される」結果が必要なときは EffectiveData を使用します（例: 色、インデント、サイズの整合）。特定のレベルで書式を変更したいときはローカルプロパティを操作し、必要なら EffectiveData を再取得して結果を検証します。