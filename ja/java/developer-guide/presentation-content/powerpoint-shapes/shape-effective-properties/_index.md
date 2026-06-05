---
title: Java でプレゼンテーションからシェイプの実効プロパティを取得する
linktitle: 実効プロパティ
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
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が正確な PowerPoint 表示のためにシェイプの実効プロパティを計算し適用する方法を紹介します。"
---
## **概要**

このトピックでは **local** と **effective** のプロパティの違いについて説明します。Local 値とは、特定の書式設定レベルで直接設定された値のことで、以下のような例があります。

1. スライド上のテキスト部分のプロパティ。
2. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（テキストフレームシェイプにそれがある場合）。
3. プレゼンテーション全体のグローバルテキスト設定。

Local 値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「描画結果」書式設定を必要とする場合、継承チェーンを解決して **effective** 値を返します。これらはローカル書式オブジェクトの `getEffective` メソッドを呼び出すことで取得できます。

次の例は effective 値の取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも 1 つの部分を含む [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Effective 書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortionFormatEffectiveData) などの一部の effective データオブジェクトが内部でキャッシュされることがあります。親または継承された書式を変更した後に `getEffective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために effective 値を保持したい場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置など必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの実効プロパティの取得**

Aspose.Slides を使用するとカメラの実効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICameraEffectiveData) インターフェイスは、実効カメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICameraEffectiveData) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の実効値を提供します。

次のコードサンプルはカメラの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **ライトリグの実効プロパティの取得**

Aspose.Slides を使用するとライトリグの実効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスは、実効ライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ILightRigEffectiveData) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の実効値を提供します。

次のコードサンプルはライトリグの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **シェイプベベルの実効プロパティの取得**

Aspose.Slides を使用するとシェイプベベルの実効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスは、シェイプの実効面彫刻プロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeBevelEffectiveData) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の実効値を提供します。

次のコードサンプルはシェイプの上部ベベルの実効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **テキストフレームの実効プロパティの取得**

Aspose.Slides を使用するとテキストフレームの実効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormatEffectiveData) インターフェイスは、実効テキストフレーム書式プロパティを含みます。

次のコードサンプルは実効テキストフレーム書式プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **テキストスタイルの実効プロパティの取得**

Aspose.Slides を使用するとテキストスタイルの実効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextStyleEffectiveData) インターフェイスは、実効テキストスタイルプロパティを含みます。

次のコードサンプルは実効テキストスタイルプロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **実効フォント高さ値の取得**

Aspose.Slides を使用すると実効フォント高さを取得できます。次のコードは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後に、部分の実効フォント高さがどのように変化するかを示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テーブルの実効塗りつぶし書式の取得**

Aspose.Slides を使用するとテーブルのさまざまな部分の実効塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IFillFormatEffectiveData) インターフェイスは、実効塗りつぶし書式プロパティを含みます。セルの書式は行の書式よりも優先され、行の書式は列の書式よりも優先され、列の書式はテーブル全体の書式よりも優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICellFormatEffectiveData) のプロパティがテーブルセルの描画に使用されます。次のコードサンプルはテーブルのさまざまな部分の実効塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITable) であると想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` はスナップショットを返しますか？**

必ずしもそうではありません。Effective データは継承が適用された後に計算された書式を表しますが、一部の effective データオブジェクトは内部でキャッシュされることがあります。続く `getEffective` 呼び出しは書式を再計算しキャッシュを更新する可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**実効プロパティを再度読み取るべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスタ書式、またはプレゼンテーションレベルの既定を変更した後に `getEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の実効結果が返されます。

**レイアウト／マスタースライドを変更または削除すると、すでに取得した実効プロパティに影響しますか？**

はい。ただし、変更は次の `getEffective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した実効データは古くなる可能性があります。`getEffective` を再度呼び出すと Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**実効データオブジェクトを通じて値を変更できますか？**

できません。Effective データオブジェクトは計算された値を提供するだけです。ローカル書式オブジェクトで変更を行い、必要に応じて再度実効値を取得してください。

**シェイプレベルでもレイアウト／マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

実効値はデフォルトメカニズムに従って決定されます。これには PowerPoint と Aspose.Slides の既定が含まれます。その解決された値が現在の実効データの一部となります。

**実効フォント値から、どのレベルがサイズまたはフォント名を提供したか判断できますか？**

直接は判断できません。Effective データは最終的な値を返すだけです。ソースを特定したい場合は、部分、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションレベルのローカル値を順に確認し、最初に明示的に定義された場所を探してください。

**実効値がローカル値と同じに見えることがありますが、なぜですか？**

ローカル値が最終的な値となり、上位レベルの継承が不要だった場合です。そのような場合、実効値はローカル値と一致します。

**実効プロパティを使用すべきタイミングと、ローカルだけで作業すべきタイミングは？**

すべての継承が適用された「描画結果」を取得したいときは実効データを使用します。たとえば色、インデント、サイズを合わせる必要がある場合です。後で変更があってもその値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて実効データを再取得して結果を確認します。