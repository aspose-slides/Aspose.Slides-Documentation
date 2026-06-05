---
title: Androidでプレゼンテーションからシェイプの有効プロパティを取得する
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/androidjava/shape-effective-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java が正確な PowerPoint のレンダリングのためにシェイプの有効プロパティを計算および適用する方法を学びましょう。"
---
## **概要**

このトピックでは、**ローカル** プロパティと **有効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値であり、例えば次のようなものです:

1. スライド上の部分（Portion）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（その部分のテキストフレームシェイプがある場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「実際に描画される」書式設定を必要とする場合、継承チェーンを解決して **有効** な値を返します。ローカル書式オブジェクトで `getEffective()` メソッドを呼び出すことで取得できます。

以下の例は有効な値を取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームと少なくとも1つの部分を持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを前提としています。

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
有効な書式設定データは、継承が適用された後に計算された現在の書式設定を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformateffectivedata/) のような一部の有効データオブジェクトが内部でキャッシュされることがあります。親や継承された書式設定を変更した後に `getEffective()` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために有効な値を保持する必要がある場合は、フォントの高さ、塗りつぶしカラー、フォントスタイル、配置などの必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティの取得**

Aspose.Slides はカメラの有効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) インターフェイスは、有効なカメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効な値を提供します。

以下のコードサンプルはカメラの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **ライトリグの有効プロパティの取得**

Aspose.Slides はライトリグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) インターフェイスは、有効なライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効な値を提供します。

以下のコードサンプルはライトリグの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **ベベルシェイプの有効プロパティの取得**

Aspose.Slides はシェイプベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの有効な面リリーフプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効な値を提供します。

以下のコードサンプルはシェイプの上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持っていることを前提としています。

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

## **テキストフレームの有効プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformateffectivedata/) インターフェイスは、有効なテキストフレーム書式設定プロパティを含みます。

以下のコードサンプルはテキストフレームの有効書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを前提としています。

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

## **テキストスタイルの有効プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextstyleeffectivedata/) インターフェイスは、有効なテキストスタイルプロパティを含みます。

以下のコードサンプルはテキストスタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であることを前提としています。

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

## **有効なフォント高さの取得**

Aspose.Slides を使用すると、有効なフォント高さを取得できます。以下のコードは、プレゼンテーション構造のさまざまなレベルでローカルのフォント高さが設定された後に、部分の有効フォント高さがどのように変化するかを示しています。

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

## **テーブルの有効な塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルの各部分に対して有効な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/) インターフェイスは、有効な塗りつぶし書式プロパティを含みます。セルの書式は行の書式よりも優先度が高く、行の書式は列の書式よりも優先度が高く、列の書式はテーブル全体の書式よりも優先度が高くなります。

結果として、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルはテーブルの異なる部分に対して有効な塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) であることを前提としています。

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

必ずしも返しません。有効データは継承が適用された後に計算された書式設定を表しますが、一部の有効データオブジェクトは内部でキャッシュされることがあります。続けて `getEffective()` を呼び出すと書式設定が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**有効プロパティはいつ再度取得すべきですか？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルのデフォルトを変更した後に `getEffective()` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の有効な結果が返されます。

**レイアウト／マスタースライドを変更または削除すると、既に取得した有効プロパティに影響しますか？**

影響しますが、変更は次の `getEffective()` 呼び出しで反映されます。親書式ソースが変更または削除された場合、以前取得した有効データは古くなる可能性があります。再度 `getEffective()` を呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変化することがあります。

**有効データオブジェクトを介して値を変更できますか？**

できません。有効データオブジェクトは計算された値を提供するだけです。変更はローカル書式オブジェクトで行い、再度 `getEffective()` を取得して新しい有効値を確認してください。

**シェイプレベルでもレイアウト／マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

デフォルトメカニズム（PowerPoint および Aspose.Slides のデフォルト）に従って値が決定されます。その解決された値が現在の有効データの一部となります。

**有効フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接は判断できません。有効データは最終的な値だけを返します。どのレベルで最初に明示的に定義されたかを知りたい場合は、部分、段落、テキストフレーム、そしてレイアウト、マスター、プレゼンテーションレベルのローカル値を順に確認してください。

**なぜ有効値がローカル値と同じに見えることがあるのですか？**

ローカル値がそのまま最終値となり、上位レベルからの継承が不要だったためです。そのような場合、有効値はローカル値と一致します。

**有効プロパティはいつ使用し、ローカルプロパティだけで作業すべき時はいつですか？**

すべての継承が適用された「実際に描画される」結果が必要な場合は有効データを使用してください（例: 色、インデント、サイズの整合）。これらの値を後で変更に左右されずに保持したい場合は、必要なプロパティを独自のオブジェクトにコピーします。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて有効データを再取得して結果を確認してください。