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
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java が正確な PowerPoint 表示のためにシェイプの有効プロパティを計算し適用する方法を紹介します。"
---
## **概要**

このトピックでは **ローカル** プロパティと **有効 (effective)** プロパティの違いについて説明します。ローカル値とは、特定の書式設定レベルで直接設定された値のことです。例として次のようなものがあります。

1. スライド上のテキスト部分（ポーション）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（テキストフレームシェイプがある場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式設定を必要とする場合、継承チェーンを解決して **有効** 値を返します。ローカル書式オブジェクトの `getEffective` メソッドを呼び出すことで取得できます。

以下の例は有効値の取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも 1 つのポーションを含む [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であることを前提としています。

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
有効書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IPortionFormatEffectiveData) のような一部の有効データオブジェクトが内部でキャッシュされることがあります。親または継承された書式を変更した後に `getEffective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために有効値を保持したい場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置など必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの有効プロパティの取得**

Aspose.Slides ではカメラの有効プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICameraEffectiveData) インターフェイスは、変更できないオブジェクトとしてカメラの有効プロパティを保持します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICameraEffectiveData) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の有効値を提供します。

以下のコードサンプルは、カメラの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```java
import com.aspose.slides.*;

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

## **ライトリグの有効プロパティの取得**

Aspose.Slides ではライトリグの有効プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ILightRigEffectiveData) インターフェイスは、変更できないオブジェクトとしてライトリグの有効プロパティを保持します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ILightRigEffectiveData) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の有効値を提供します。

以下のコードサンプルは、ライトリグの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```java
import com.aspose.slides.*;

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

## **シェイプベベルの有効プロパティの取得**

Aspose.Slides ではシェイプベベルの有効プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeBevelEffectiveData) インターフェイスは、シェイプのベベルに関する有効な面リリーフプロパティを保持する変更不可能なオブジェクトです。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeBevelEffectiveData) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormatEffectiveData) を介して公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IThreeDFormat) の有効値を提供します。

以下のコードサンプルは、シェイプの上部ベベルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定を持つことを前提としています。

```java
import com.aspose.slides.*;

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

## **テキストフレームの有効プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの有効プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextFrameFormatEffectiveData) インターフェイスは、テキストフレームの有効な書式設定プロパティを保持します。

以下のコードサンプルは、テキストフレームの有効書式設定プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であることを前提としています。

```java
import com.aspose.slides.*;

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

## **テキストスタイルの有効プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの有効プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITextStyleEffectiveData) インターフェイスは、テキストスタイルの有効プロパティを保持します。

以下のコードサンプルは、テキストスタイルの有効プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) であることを前提としています。

```java
import com.aspose.slides.*;

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

## **有効フォント高さの取得**

Aspose.Slides を使用すると、有効フォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカルフォント高さが設定された後に、ポーションの有効フォント高さがどのように変化するかを示しています。

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

## **テーブルの有効塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルの各部分に対する有効塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IFillFormatEffectiveData) インターフェイスは、有効な塗りつぶし書式プロパティを保持します。セルの書式は行の書式より優先され、行の書式は列の書式より優先され、列の書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICellFormatEffectiveData) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルは、テーブルのさまざまな部分に対する有効塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITable) であることを前提としています。

```java
import com.aspose.slides.*;

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

### `getEffective` はスナップショットを返しますか？

必ずしもそうではありません。有効データは継承適用後に計算された書式を表しますが、一部の有効データオブジェクトは内部でキャッシュされることがあります。`getEffective` を再度呼び出すと書式が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

### 有効プロパティを再度取得すべきタイミングは？

ローカル書式、親スタイル、レイアウト書式、マスタ書式、またはプレゼンテーションレベルのデフォルトを変更した後に `getEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の有効結果が返されます。

### レイアウト／マスタースライドを変更または削除すると、すでに取得した有効プロパティに影響がありますか？

はい。ただし、変更は次の `getEffective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した有効データは古くなる可能性があります。`getEffective` を再度呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォントや色、サイズなどの値が変わることがあります。

### 有効データオブジェクトを通じて値を変更できますか？

できません。有効データオブジェクトは計算された値を公開するだけです。ローカル書式オブジェクトで変更を行い、必要に応じて再度有効値を取得してください。

### シェイプレベルでもレイアウト／マスターでもグローバル設定でもプロパティが設定されていない場合は？

有効値はデフォルトメカニズムにより決定されます。このメカニズムには PowerPoint と Aspose.Slides のデフォルトが含まれます。解決された値が現在の有効データの一部となります。

### 有効フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？

直接はできません。有効データは最終的な値を返すだけです。ソースを特定したい場合は、ポーション、段落、テキストフレーム、レイアウト／マスター／プレゼンテーションレベルのテキストスタイルにおけるローカル値を確認し、最初に明示的に定義された場所を探してください。

### なぜ有効値がローカル値と同じに見えることがあるのですか？

ローカル値が最終的な結果となり、上位レベルからの継承が不要だった場合です。このようなケースでは有効値はローカル値と一致します。

### いつ有効プロパティを使用し、いつローカルプロパティだけを扱うべきですか？

すべての継承が適用された「レンダリング後」の結果が必要なときは有効データを使用します。たとえば、色やインデント、サイズを揃える場合などです。後で書式が変わってもその値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて有効データを再取得して結果を確認します。