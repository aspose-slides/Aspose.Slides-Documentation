---
title: Android でプレゼンテーションからシェイプの実効プロパティを取得する
linktitle: 実効プロパティ
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
description: "Aspose.Slides for Android via Java が PowerPoint の正確なレンダリングのために実効シェイププロパティを計算し適用する方法を学びましょう。"
---
## **概要**

このトピックでは **ローカル** と **実効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値であり、例えば次のようなものです:

1. スライド上の部分（Portion）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ形状テキストスタイル（その部分のテキストフレーム形状が持っている場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」書式設定を必要とする場合、継承チェーンを解決して **実効** 値を返します。ローカル書式オブジェクトの `getEffective()` メソッドを呼び出すことで取得できます。

以下の例は実効値の取得方法を示します。最初のスライドの最初のシェイプがテキストフレームと少なくとも1つの部分を持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
実効書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformateffectivedata/) などの一部の実効データオブジェクトが内部でキャッシュされることがあります。親や継承された書式を変更した後に `getEffective()` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。実効値を後で再利用する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置などの必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの実効プロパティを取得する**

Aspose.Slides はカメラの実効プロパティの取得をサポートします。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) インターフェイスは、実効カメラプロパティを保持する不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはカメラの実効プロパティを取得する方法を示します。最初のスライドの最初のシェイプに3D書式設定があることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **ライトリグの実効プロパティを取得する**

Aspose.Slides はライトリグの実効プロパティの取得をサポートします。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) インターフェイスは、実効ライトリグプロパティを保持する不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはライトリグの実効プロパティを取得する方法を示します。最初のスライドの最初のシェイプに3D書式設定があることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **ベベルシェイプの実効プロパティを取得する**

Aspose.Slides はシェイプベベルの実効プロパティの取得をサポートします。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの実効フェイスリリーフプロパティを保持する不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の実効値を提供します。

以下のコードサンプルはシェイプの上部ベベルの実効プロパティを取得する方法を示します。最初のスライドの最初のシェイプに3D書式設定があることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **テキストフレームの実効プロパティを取得する**

Aspose.Slides を使用すると、テキストフレームの実効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformateffectivedata/) インターフェイスは実効テキストフレーム書式プロパティを保持します。

以下のコードサンプルは実効テキストフレーム書式プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

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
    presentation.dispose();
}
```

## **テキストスタイルの実効プロパティを取得する**

Aspose.Slides を使用すると、テキストスタイルの実効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextstyleeffectivedata/) インターフェイスは実効テキストスタイルプロパティを保持します。

以下のコードサンプルは実効テキストスタイルプロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **実効フォント高さの取得**

Aspose.Slides を使用すると、実効フォント高さを取得できます。以下のコードは、プレゼンテーションのさまざまな階層でローカルフォント高さが設定された後、部分の実効フォント高さがどのように変化するかを示しています。

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

## **テーブルの実効塗りつぶし書式を取得する**

Aspose.Slides を使用すると、テーブルの各部分に対する実効塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/) インターフェイスは実効塗りつぶし書式プロパティを保持します。セルの書式は行の書式より優先され、行の書式は列の書式より優先され、列の書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルはテーブルのさまざまな部分に対する実効塗りつぶし書式を取得する方法を示します。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) であることを想定しています。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective()` はスナップショットを返しますか？**

必ずしもそうではありません。実効データは継承が適用された後に計算された書式を表しますが、一部の実効データオブジェクトは内部でキャッシュされることがあります。その後の `getEffective()` 呼び出しにより書式が再計算されキャッシュが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**実効プロパティを再度取得すべきタイミングは？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `getEffective()` を再度呼び出します。次回の呼び出しで書式階層が再評価され、現在の実効結果が返されます。

**レイアウト/マスタースライドを変更または削除すると、既に取得した実効プロパティに影響しますか？**

はい、ただし変更は次回の `getEffective()` 呼び出しで反映されます。親の書式情報が変更または削除された場合、以前取得した実効データは古くなる可能性があります。`getEffective()` を再度呼び出すと Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**実効データオブジェクトを通じて値を変更できますか？**

いいえ。実効データオブジェクトは計算済みの値を提供するだけです。ローカル書式オブジェクトで変更を行い、再度実効値を取得してください。

**シェイプレベル、レイアウト/マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**

実効値はデフォルトメカニズムにより決定されます。これは PowerPoint と Aspose.Slides のデフォルト設定を含みます。解決された値が現在の実効データの一部となります。

**実効フォント値から、どの階層がサイズやフォントを提供したか判断できますか？**

直接的にはできません。実効データは最終的な値を返すだけです。情報源を特定するには、部分、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションレベルのテキストスタイルにおけるローカル値を確認し、最初に明示的に定義された場所を探す必要があります。

**なぜ実効値がローカル値と同じに見えることがあるのですか？**

ローカル値が最終的な値となった（上位レベルの継承が不要だった）ためです。その場合、実効値はローカル値と同一になります。

**実効プロパティを使用すべきとき、ローカルプロパティだけで作業すべきときはいつですか？**

すべての継承が適用された「レンダリング後」の結果が必要な場合（色、インデント、サイズの揃えなど）は実効データを使用します。後の書式変更に関係なくその値を保持したい場合は、必要なプロパティを独自のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて実効データを再取得して結果を確認します。