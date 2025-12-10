---
title: Java でプレゼンテーションからシェイプの有効プロパティを取得する
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/java/shape-effective-properties/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が正確な PowerPoint 表示のためにシェイプの有効プロパティを計算し適用する方法を紹介します。"
---

このトピックでは、**effective** と **local** プロパティについて説明します。これらのレベルで値を直接設定する場合

1. パートのスライド上のパートプロパティ;
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（パートのテキストフレームシェイプにそれがある場合）;
1. プレゼンテーションのグローバルテキスト設定;

これらの値は **local** 値と呼ばれます。任意のレベルで、**local** 値は定義されても、定義されなくても構いません。しかし、アプリケーションがパートの見た目を知る必要がある場合は、**effective** 値を使用します。**getEffective()** メソッドをローカルフォーマットから使用して、effective 値を取得できます。

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


## **カメラの Effective プロパティの取得**
Aspose.Slides for Java は開発者がカメラの effective プロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスは、effective カメラプロパティを含む不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

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


## **ライトリグの Effective プロパティの取得**
Aspose.Slides for Java は開発者が Light Rig の effective プロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスが Aspose.Slides に追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスは、effective ライトルグプロパティを含む不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

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


## **ベベルシェイプの Effective プロパティの取得**
Aspose.Slides for Java は開発者がベベルシェイプの effective プロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスが Aspose.Slides に追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスは、effective シェイプのフェイスリリーフプロパティを含む不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)) インターフェイスの一部として使用され、これは [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat) クラスの [effective values](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--) ペアです。

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


## **テキストフレームの Effective プロパティの取得**
Aspose.Slides for Java を使用すると、テキストフレームの effective プロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これは effective テキストフレームの書式設定プロパティを含みます。

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


## **テキストスタイルの Effective プロパティの取得**
Aspose.Slides for Java を使用すると、テキストスタイルの effective プロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData) インターフェイスが Aspose.Slides に追加されました。これは effective テキストスタイルのプロパティを含みます。

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


## **Effective フォント高さの取得**
Aspose.Slides for Java を使用すると、フォント高さの effective プロパティを取得できます。ここでは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後、パートの effective フォント高さ値が変化する様子を示すコードを提供します。

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


## **テーブルの Effective 塗りつぶし書式の取得**
Aspose.Slides for Java を使用すると、テーブルのさまざまな論理部分の effective 塗りつぶし書式を取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData) インターフェイスが Aspose.Slides に追加されました。これは effective 塗りつぶし書式プロパティを含みます。次の点に注意してください：セルの書式設定は常に行の書式設定より優先され、行は列より優先され、列はテーブル全体より優先されます。

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

**取得したオブジェクトが「スナップショット」なのか「ライブオブジェクト」なのかをどのように判断し、いつ再度 effective プロパティを読み取るべきですか？**  
EffectiveData オブジェクトは、呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合、最新の値を取得するために effective データを再取得してください。

**レイアウト／マスタースライドを変更すると、すでに取得した effective プロパティに影響しますか？**  
はい、ですが再度取得した後にのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されません。レイアウトやマスターを変更した後、再度リクエストしてください。

**EffectiveData を通じて値を変更できますか？**  
いいえ。EffectiveData は読み取り専用です。ローカルの書式設定オブジェクト（シェイプ/テキスト/3D など）を変更し、再度 effective 値を取得してください。

**シェイプレベル、レイアウト/マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**  
effective 値はデフォルトの仕組み（PowerPoint/Aspose.Slides のデフォルト）により決定されます。その解決された値が EffectiveData のスナップショットに含まれます。

**effective フォント値から、サイズやフォントがどのレベルで設定されたか判断できますか？**  
直接は判断できません。EffectiveData は最終的な値を返します。元を特定するには、パート/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探してください。

**なぜ EffectiveData の値がローカルのものと同じに見えることがあるのでしょうか？**  
ローカルの値が最終的な値となったためです（上位レベルからの継承が不要）。このような場合、effective 値はローカル値と同一になります。

**effective プロパティをいつ使用し、ローカルプロパティだけで作業すべきはいつですか？**  
すべての継承が適用された「実際の」結果が必要な場合に EffectiveData を使用します（例：色、インデント、サイズを揃える場合）。特定のレベルで書式設定を変更したい場合はローカルプロパティを変更し、必要に応じて EffectiveData を再取得して結果を確認してください。