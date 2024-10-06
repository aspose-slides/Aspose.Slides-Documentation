---
title: シェイプ効果的プロパティ
type: docs
weight: 50
url: /ja/androidjava/shape-effective-properties/
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定するとき

1. ポーションのスライド上のポーションプロパティ；
1. レイアウトまたはマスタースライドのプロトタイプシェイプテキストスタイル（ポーションのテキストフレームシェイプがある場合）；
1. プレゼンテーションのグローバルテキスト設定；

これらの値は**ローカル**値と呼ばれます。どのレベルでも、**ローカル**値は定義されるか、省略されることがあります。しかし、アプリケーションがポーションがどのように見えるべきかを知る必要がある場合、**効果的**値を使用します。**getEffective()**メソッドを使用してローカルフォーマットから効果的な値を取得できます。

このサンプルコードでは、効果的な値を取得する方法を示します：

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

## **カメラの効果的プロパティの取得**
Aspose.Slides for Android via Javaは、開発者がカメラの効果的プロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData)インターフェイスがAspose.Slidesに追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData)インターフェイスは、効果的なカメラプロパティを含む不変のオブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICameraEffectiveData)インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)インターフェイスの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)クラスのための[効果的な値](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードサンプルでは、カメラの効果的プロパティを取得する方法を示します：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的なカメラプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("視野角: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("ズーム: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライトリグの効果的プロパティの取得**
Aspose.Slides for Android via Javaは、開発者がライトリグの効果的プロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData)インターフェイスがAspose.Slidesに追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData)インターフェイスは、効果的なライトリグプロパティを含む不変のオブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ILightRigEffectiveData)インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)インターフェイスの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)クラスのための[効果的な値](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードサンプルでは、ライトリグの効果的プロパティを取得する方法を示します：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的なライトリグプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("方向: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ベベルシェイプの効果的プロパティの取得**
Aspose.Slides for Android via Javaは、開発者がベベルシェイプの効果的プロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)インターフェイスがAspose.Slidesに追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)インターフェイスは、効果的なシェイプの面の浮き出しプロパティを含む不変のオブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeBevelEffectiveData)インターフェイスのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IThreeDFormatEffectiveData)インターフェイスの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat)クラスのための[効果的な値](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ThreeDFormat#getEffective--)のペアです。

このサンプルコードサンプルでは、ベベルシェイプの効果的プロパティを取得する方法を示します：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的なシェイプの上面浮き出しプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("幅: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("高さ: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームの効果的プロパティの取得**
Aspose.Slides for Android via Javaを使用すると、テキストフレームの効果的プロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrameFormatEffectiveData)インターフェイスがAspose.Slidesに追加されました。これは、効果的なテキストフレームフォーマットプロパティを含みます。

このサンプルコードでは、効果的なテキストフレームフォーマットプロパティを取得する方法を示します：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("アンカータイプ: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("オートフィットタイプ: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("テキストの縦方向タイプ: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("マージン");
    System.out.println("   左: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   上: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   右: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   下: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストスタイルの効果的プロパティの取得**
Aspose.Slides for Android via Javaを使用すると、テキストスタイルの効果的プロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextStyleEffectiveData)インターフェイスがAspose.Slidesに追加されました。これは、効果的なテキストスタイルプロパティを含みます。

このサンプルコードサンプルでは、効果的なテキストスタイルプロパティを取得する方法を示します：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= スタイルレベル #" + i + " の効果的な段落フォーマット =");

        System.out.println("深さ: " + effectiveStyleLevel.getDepth());
        System.out.println("インデント: " + effectiveStyleLevel.getIndent());
        System.out.println("整列: " + effectiveStyleLevel.getAlignment());
        System.out.println("フォント整列: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **効果的なフォント高さ値の取得**
Aspose.Slides for Android via Javaを使用すると、フォント高さの効果的なプロパティを取得できます。ここでは、異なるプレゼンテーション構造レベルでローカルフォント高さ値を設定した後のポーションの効果的フォント高さ値が変化することを示すコードを提供します：

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("最初のポーションを含むサンプルテキスト");
    IPortion portion1 = new Portion(" と二番目のポーション。");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("作成直後の効果的フォント高さ:");
    System.out.println("ポーション #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("プレゼンテーション全体のデフォルトフォント高さを設定後の効果的フォント高さ:");
    System.out.println("ポーション #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("段落のデフォルトフォント高さを設定後の効果的フォント高さ:");
    System.out.println("ポーション #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("ポーション #0フォント高さを設定後の効果的フォント高さ:");
    System.out.println("ポーション #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("ポーション #1フォント高さを設定後の効果的フォント高さ:");
    System.out.println("ポーション #0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション #1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルの効果的なフィルフォーマットの取得**
Aspose.Slides for Android via Javaを使用すると、さまざまなテーブルロジック部分の効果的なフィルフォーマットを取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICellFormatEffectiveData)インターフェイスがAspose.Slidesに追加されました。これは、効果的なフィルフォーマットプロパティを含みます。注意点として、セルフォーマットは常に行フォーマットよりも優先され、行は列よりも優先され、列は全体のテーブルよりも優先されます。

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