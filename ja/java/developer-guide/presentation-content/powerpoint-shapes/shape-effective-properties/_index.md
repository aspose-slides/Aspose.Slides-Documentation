---
title: 形状の効果的プロパティ
type: docs
weight: 50
url: /java/shape-effective-properties/
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定すると、

1. ポーションのスライドのポーションプロパティ;
1. レイアウトまたはマスタースライドにおけるプロトタイプの形状テキストスタイル（ポーションのテキストフレーム形状に存在する場合）;
1. プレゼンテーションのグローバルテキスト設定;

これらの値は**ローカル**値と呼ばれます。どのレベルでも、**ローカル**値は定義または省略することができます。しかし、アプリケーションがポーションがどのように見えるべきかを知る必要があるとき、それは**効果的**な値を使用します。**getEffective()**メソッドを使用してローカルフォーマットから効果的な値を取得できます。

このサンプルコードは、効果的な値を取得する方法を示しています：

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

## **カメラの効果的プロパティを取得する**
Aspose.Slides for Javaは、開発者がカメラの効果的プロパティを取得できるようにします。この目的のために、[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData)インターフェースがAspose.Slidesに追加されました。[ICameraEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData)インターフェースは、効果的なカメラプロパティを含む不変オブジェクトを表します。[**ICameraEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICameraEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData)インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--)ペアです。

このサンプルコードは、カメラの効果的プロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的なカメラのプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getCamera().getCameraType());
    System.out.println("視野角: " + threeDEffectiveData.getCamera().getFieldOfViewAngle());
    System.out.println("ズーム: " + threeDEffectiveData.getCamera().getZoom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ライトリグの効果的プロパティを取得する**
Aspose.Slides for Javaは、開発者がライトリグの効果的プロパティを取得できるようにします。この目的のために、[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData)インターフェースがAspose.Slidesに追加されました。[ILightRigEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData)インターフェースは、効果的なライトリグプロパティを含む不変オブジェクトを表します。[**ILightRigEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ILightRigEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData)インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--)ペアです。

このサンプルコードは、ライトリグの効果的プロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的なライトリグのプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getLightRig().getLightType());
    System.out.println("方向: " + threeDEffectiveData.getLightRig().getDirection());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ベベル形状の効果的プロパティを取得する**
Aspose.Slides for Javaは、開発者がベベル形状の効果的プロパティを取得できるようにします。この目的のために、[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)インターフェースがAspose.Slidesに追加されました。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)インターフェースは、効果的な形状の面の浮き出しプロパティを含む不変オブジェクトを表します。[**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeBevelEffectiveData)インターフェースのインスタンスは、[**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/IThreeDFormatEffectiveData)インターフェースの一部として使用され、これは[ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat)クラスの[効果的な値](https://reference.aspose.com/slides/java/com.aspose.slides/ThreeDFormat#getEffective--)ペアです。

このサンプルコードは、ベベル形状の効果的プロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IThreeDFormatEffectiveData threeDEffectiveData = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThreeDFormat().getEffective();

    System.out.println("= 効果的な形状の上面浮き出しプロパティ =");
    System.out.println("タイプ: " + threeDEffectiveData.getBevelTop().getBevelType());
    System.out.println("幅: " + threeDEffectiveData.getBevelTop().getWidth());
    System.out.println("高さ: " + threeDEffectiveData.getBevelTop().getHeight());
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストフレームの効果的プロパティを取得する**
Aspose.Slides for Javaを使用すると、テキストフレームの効果的なプロパティを取得できます。この目的のために、[**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormatEffectiveData)インターフェースがAspose.Slidesに追加されました。このインターフェースは、効果的なテキストフレームのフォーマットプロパティを含んでいます。

このサンプルコードは、効果的なテキストフレームのフォーマットプロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("アンカーのタイプ: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("オートフィットのタイプ: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("テキストの垂直タイプ: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("マージン");
    System.out.println("   左: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   上: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   右: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   下: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    if (pres != null) pres.dispose();
}
```

## **テキストスタイルの効果的プロパティを取得する**
Aspose.Slides for Javaを使用すると、テキストスタイルの効果的なプロパティを取得できます。この目的のために、[**ITextStyleEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ITextStyleEffectiveData)インターフェースがAspose.Slidesに追加されました。このインターフェースは、効果的なテキストスタイルプロパティを含んでいます。

このサンプルコードは、効果的なテキストスタイルのプロパティを取得する方法を示しています：

```java
Presentation pres = new Presentation("Presentation1.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(i);
        System.out.println("= スタイルレベル＃" + i + " の効果的な段落フォーマット =");

        System.out.println("深さ: " + effectiveStyleLevel.getDepth());
        System.out.println("インデント: " + effectiveStyleLevel.getIndent());
        System.out.println("整列: " + effectiveStyleLevel.getAlignment());
        System.out.println("フォント整列: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **フォント高さの効果的値を取得する**
Aspose.Slides for Javaを使用すると、フォント高さの効果的なプロパティを取得できます。ここでは、異なるプレゼンテーション構造レベルでローカルフォント高さの値が設定された後、ポーションの効果的なフォント高さの値が変化することを示すコードを提供します：

```java
Presentation pres = new Presentation();
try {
    IAutoShape newShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.addTextFrame("");
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().clear();

    IPortion portion0 = new Portion("最初のポーションを含むサンプルテキスト");
    IPortion portion1 = new Portion(" と2番目のポーション。");

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion0);
    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion1);

    System.out.println("作成直後の効果的なフォント高さ:");
    System.out.println("ポーション＃0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション＃1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    System.out.println("全体のプレゼンテーションのデフォルトフォント高さ設定後の効果的なフォント高さ:");
    System.out.println("ポーション＃0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション＃1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    System.out.println("段落のデフォルトフォント高さ設定後の効果的なフォント高さ:");
    System.out.println("ポーション＃0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション＃1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(55);
    System.out.println("ポーション＃0のフォント高さ設定後の効果的なフォント高さ:");
    System.out.println("ポーション＃0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション＃1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    newShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1).getPortionFormat().setFontHeight(18);
    System.out.println("ポーション＃1のフォント高さ設定後の効果的なフォント高さ:");
    System.out.println("ポーション＃0: " + portion0.getPortionFormat().getEffective().getFontHeight());
    System.out.println("ポーション＃1: " + portion1.getPortionFormat().getEffective().getFontHeight());

    pres.save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **テーブルの効果的な塗りつぶしフォーマットを取得する**
Aspose.Slides for Javaを使用すると、異なるテーブルロジック部分の効果的な塗りつぶしフォーマットを取得できます。この目的のために、[**ICellFormatEffectiveData**](https://reference.aspose.com/slides/java/com.aspose.slides/ICellFormatEffectiveData)インターフェースがAspose.Slidesに追加されました。これは、効果的な塗りつぶしフォーマットプロパティを含んでいます。注意してください：セルフォーマットは常に行フォーマットよりも優先され、行は列よりも優先され、列は全体のテーブルよりも優先されます。

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