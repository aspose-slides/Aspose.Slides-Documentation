---
title: Android のプレゼンテーションからシェイプの有効プロパティを取得する
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
description: "Java を介した Android 向け Aspose.Slides が、正確な PowerPoint 表示のためにシェイプの有効プロパティを計算し適用する方法を紹介します。"
---
## **概要**

このトピックでは **ローカル** プロパティと **有効** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、次のようなものがあります。

1. スライド上の部分 (portion) のプロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプ テキスト スタイル (テキスト フレーム シェイプに部分がある場合)。
1. プレゼンテーション全体のグローバル テキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリングされた」書式設定を必要とする場合、継承チェーンを解決して **有効** 値を返します。ローカル書式オブジェクトの `getEffective()` メソッドを呼び出すことで取得できます。

以下の例は有効値の取得方法を示しています。最初のスライドの最初のシェイプがテキスト フレームを持ち、少なくとも 1 つの部分を含む [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であると想定しています。

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
有効な書式設定データは、継承が適用された後に計算された現在の書式設定を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformateffectivedata/) などの一部の有効データオブジェクトが内部でキャッシュされることがあります。親や継承書式を変更した後に `getEffective()` を再度呼び出すとキャッシュが刷新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために有効値を保持したい場合は、フォントの高さ、塗りつぶし色、フォント スタイル、配置など必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティを取得する**

Aspose.Slides ではカメラの有効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) インターフェイスは、変更不可のオブジェクトでカメラの有効プロパティを保持します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icameraeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効値を提供します。

以下のコード サンプルは、カメラの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

```java
import com.aspose.slides.*;

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

## **ライト リグの有効プロパティを取得する**

Aspose.Slides ではライト リグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) インターフェイスは、変更不可のオブジェクトでライト リグの有効プロパティを保持します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilightrigeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効値を提供します。

以下のコード サンプルは、ライト リグの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

```java
import com.aspose.slides.*;

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

## **シェイプ ベベルの有効プロパティを取得する**

Aspose.Slides ではシェイプ ベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの有効な面リリーフ プロパティを保持する変更不可オブジェクトです。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapebeveleffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/) の有効値を提供します。

以下のコード サンプルは、シェイプの上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定が適用されていると想定しています。

```java
import com.aspose.slides.*;

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

## **テキスト フレームの有効プロパティを取得する**

Aspose.Slides を使用すると、テキスト フレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformateffectivedata/) インターフェイスは、テキスト フレームの有効書式設定プロパティを含みます。

以下のコード サンプルは、テキスト フレームの有効書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキスト フレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であると想定しています。

```java
import com.aspose.slides.*;

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

## **テキスト スタイルの有効プロパティを取得する**

Aspose.Slides を使用すると、テキスト スタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextstyleeffectivedata/) インターフェイスは、テキスト スタイルの有効プロパティを保持します。

以下のコード サンプルは、テキスト スタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキスト フレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であると想定しています。

```java
import com.aspose.slides.*;

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

## **有効なフォント 高さの値を取得する**

Aspose.Slides を使用すると、有効なフォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカル フォント高さが設定された後、部分の有効フォント高さがどのように変化するかを示します。

```java
import com.aspose.slides.*;

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

## **テーブルの有効な塗りつぶし形式を取得する**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対する有効な塗りつぶし書式設定を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/) インターフェイスは、有効な塗りつぶし書式設定プロパティを保持します。セルの書式設定は行の書式設定より優先され、行の書式設定は列の書式設定より優先され、列の書式設定はテーブル全体の書式設定より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icellformateffectivedata/) のプロパティがテーブル セルの描画に使用されます。以下のコード サンプルは、テーブルのさまざまな部分に対する有効な塗りつぶし書式設定を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) であると想定しています。

```java
import com.aspose.slides.*;

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

### `getEffective()` はスナップショットを返しますか？

必ずしも返しません。有効データは継承が適用された後に計算された書式設定を表しますが、一部の有効データオブジェクトは内部でキャッシュされることがあります。`getEffective()` を再度呼び出すと書式設定が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

### 有効プロパティはいつ再取得すべきですか？

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション レベルのデフォルトを変更した後に `getEffective()` を再度呼び出してください。次の呼び出しで書式設定階層が再評価され、現在の有効結果が返されます。

### レイアウト/マスタースライドを変更または削除すると、既に取得した有効プロパティに影響しますか？

はい。ただし変更は次回の `getEffective()` 呼び出しで反映されます。親書式ソースが変更または削除された場合、以前取得した有効データは古くなる可能性があります。`getEffective()` を再度呼び出すと Aspose.Slides が書式設定ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

### 有効データオブジェクトを介して値を変更できますか？

できません。有効データオブジェクトは計算済みの値を公開するだけです。変更はローカル書式オブジェクトで行い、必要に応じて再度有効値を取得してください。

### シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？

既定のメカニズム（PowerPoint と Aspose.Slides の既定値）により決定された有効値が使用されます。その解決された値が現在の有効データの一部となります。

### 有効フォント値から、サイズやフォント ファミリがどのレベルで提供されたか判断できますか？

直接はできません。有効データは最終的な値を返すだけです。ソースを特定したい場合は、部分、段落、テキストフレーム、レイアウト、マスター、プレゼンテーションの各レベルでローカル値を確認し、最初に明示的に定義されている場所を探してください。

### 有効値がローカル値と同一に見えることがありますか？

あります。ローカル値が最終的な値となり、上位レベルからの継承が不要だった場合です。そのようなケースでは有効値はローカル値と同じになります。

### いつ有効プロパティを使用し、いつローカルプロパティだけを使用すべきですか？

すべての継承が適用された「レンダリング結果」が必要なときは有効データを使用します。たとえば、色やインデント、サイズを揃える場合などです。後で書式が変わっても値を保持したい場合は、必要なプロパティを独自のオブジェクトにコピーしてください。特定のレベルで書式を変更したいときはローカルプロパティを変更し、必要に応じて有効データを再取得して結果を確認してください。