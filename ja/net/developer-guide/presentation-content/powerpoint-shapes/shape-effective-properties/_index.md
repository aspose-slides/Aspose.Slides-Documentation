---
title: .NET のプレゼンテーションからシェイプの Effective プロパティを取得
linktitle: Effective プロパティ
type: docs
weight: 50
url: /ja/net/shape-effective-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が正確な PowerPoint 表示のために Effective シェイプ プロパティを計算および適用する方法を紹介します。"
---
## **概要**

このトピックでは **local** と **effective** プロパティの違いを説明します。ローカル値は、特定の書式レベルで直接設定された値で、以下のようなものがあります。

1. スライド上の部分（Portion）プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプのテキストスタイル（対象の部分のテキストフレームシェイプに設定されている場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式を必要とする場合、継承チェーンを解決し **effective** 値を返します。ローカル書式オブジェクトの `GetEffective` メソッドを呼び出すことで取得できます。

以下の例は effective 値の取得方法を示します。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも1つの Portion がある [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effective 書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformateffectivedata/) のような一部の effective データオブジェクトが内部でキャッシュされることがあります。親や継承された書式を変更した後に `GetEffective` を再度呼び出すと、キャッシュがリフレッシュされ、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために effective 値を保持する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置など必要なプロパティを自分のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの Effective プロパティの取得**

Aspose.Slidesではカメラの effective プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) インターフェイスは、effective カメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはカメラの effective プロパティの取得方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定されていると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **ライトリグの Effective プロパティの取得**

Aspose.Slidesではライトリグの effective プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) インターフェイスは、effective ライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはライトリグの effective プロパティの取得方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定されていると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **ベベルシェイプの Effective プロパティの取得**

Aspose.Slidesではシェイプベベルの effective プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの effective なフェイスリリーフプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) のインスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルはシェイプの上部ベベルの effective プロパティの取得方法を示しています。最初のスライドの最初のシェイプが 3D 書式設定されていると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **テキストフレームの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの effective プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformateffectivedata/) インターフェイスは、effective なテキストフレーム書式プロパティを含みます。

以下のコードサンプルはテキストフレームの effective 書式プロパティの取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **テキストスタイルの Effective プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの effective プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextstyleeffectivedata/) インターフェイスは、effective なテキストスタイルプロパティを含みます。

以下のコードサンプルはテキストスタイルの effective プロパティの取得方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Effective フォント高さ値の取得**

Aspose.Slides を使用すると、effective なフォント高さを取得できます。以下のコードは、プレゼンテーション構造のさまざまなレベルでローカルフォント高さが設定された後に、Portion の effective フォント高さがどのように変化するかを示しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **テーブルの Effective 塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分の effective 塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/) インターフェイスは effective な塗りつぶし書式プロパティを含みます。セルの書式は行の書式より優先され、行の書式は列の書式より優先され、列の書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルはテーブルのさまざまな部分の effective 塗りつぶし書式の取得方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) であると想定しています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### `GetEffective` はスナップショットを返しますか？

必ずしもそうではありません。Effective データは継承が適用された後に計算された書式を表しますが、一部の effective データオブジェクトは内部でキャッシュされることがあります。その後の `GetEffective` 呼び出しで書式が再計算されキャッシュが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

### effective プロパティを再取得すべきタイミングは？

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーションレベルの既定値を変更した後に `GetEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の effective 結果が返されます。

### レイアウト/マスタースライドの変更や削除は、既に取得した effective プロパティに影響しますか？

はい、ただし変更は次回の `GetEffective` 呼び出しで反映されます。親書式ソースが変更または削除されると、以前取得した effective データは古くなる可能性があります。`GetEffective` を再度呼び出すと、Aspose.Slides は書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

### effective データオブジェクトを介して値を変更できますか？

いいえ。effective データオブジェクトは計算された値を提供するだけです。ローカル書式オブジェクトで変更を行い、再度 effective 値を取得してください。

### シェイプレベル、レイアウト/マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？

effective 値は、PowerPoint および Aspose.Slides の既定を含むデフォルトメカニズムによって決定されます。その解決された値が現在の effective データの一部となります。

### effective フォント値から、どのレベルがサイズや書体を提供したか判断できますか？

直接はできません。effective データは最終的な値を返すだけです。どのレベルがソースかを確認するには、Portion、Paragraph、テキストフレーム、そしてレイアウト、マスター、プレゼンテーションレベルのテキストスタイルのローカル値を調べ、最初に明示的に定義されている場所を特定してください。

### なぜ effective 値がローカル値と同じに見えることがあるのですか？

ローカル値が最終的な値となり（上位レベルの継承が不要だった）ためです。そのような場合、effective 値はローカル値と一致します。

### effective プロパティを使用すべき時と、ローカルだけで作業すべき時は？

すべての継承が適用された「レンダリング後」の結果が必要な場合（色やインデント、サイズを揃える等）は effective データを使用します。後の書式変更に関係なくその値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて再度 effective データを読み取り、結果を確認します。