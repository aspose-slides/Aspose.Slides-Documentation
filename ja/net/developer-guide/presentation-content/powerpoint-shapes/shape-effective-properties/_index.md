---
title: .NET のプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
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
description: "Aspose.Slides for .NET が正確な PowerPoint 表示のために、シェイプの有効プロパティを計算および適用する方法を確認してください。"
---
## **概要**

このトピックでは **local** と **effective** プロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定される値で、例えば次のようなものがあります。

1. スライド上のポーション プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ シェイプ テキスト スタイル（ポーションのテキスト フレーム シェイプがそれを持つ場合）。
1. プレゼンテーション全体のグローバル テキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式設定を必要とする場合、継承チェーンを解決して **effective** 値を返します。ローカル書式オブジェクトの `GetEffective` メソッドを呼び出すことで取得できます。

以下の例は effective 値の取得方法を示します。最初のスライドの最初のシェイプがテキストフレームと少なくとも 1 つのポーションを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると仮定しています。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Effective 書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformateffectivedata/) などの一部の effective データオブジェクトが内部でキャッシュされる場合があります。親または継承された書式を変更した後に `GetEffective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。後で再利用するために effective 値を保持する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置などの必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの Effective プロパティを取得**

Aspose.Slides ではカメラの effective プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) インターフェイスは、immutable なオブジェクトで effective カメラ プロパティを保持します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルは、カメラの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定されていると仮定しています。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **ライト リグの Effective プロパティを取得**

Aspose.Slides ではライト リグの effective プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) インターフェイスは、immutable なオブジェクトで effective ライト リグ プロパティを保持します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルは、ライト リグの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定されていると仮定しています。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **シェイプ ベベルの Effective プロパティを取得**

Aspose.Slides ではシェイプ ベベルの effective プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプのフェイスリリーフ プロパティを保持する immutable オブジェクトです。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の effective 値を提供します。

以下のコードサンプルは、シェイプの上部ベベルの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプが 3D 書式設定されていると仮定しています。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **テキスト フレームの Effective プロパティを取得**

Aspose.Slides を使用すると、テキスト フレームの effective プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformateffectivedata/) インターフェイスは、effective テキスト フレーム書式プロパティを保持します。

以下のコードサンプルは、テキスト フレームの effective 書式プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキスト フレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると仮定しています。

```csharp
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

## **テキスト スタイルの Effective プロパティを取得**

Aspose.Slides を使用すると、テキスト スタイルの effective プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextstyleeffectivedata/) インターフェイスは、effective テキスト スタイル プロパティを保持します。

以下のコードサンプルは、テキスト スタイルの effective プロパティを取得する方法を示します。最初のスライドの最初のシェイプがテキスト フレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると仮定しています。

```csharp
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

## **Effective フォント高さ値を取得**

Aspose.Slides を使用すると、effective フォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカル フォント高さが設定された後、ポーションの effective フォント高さがどのように変化するかを示します。

```csharp
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

## **テーブルの Effective 塗りつぶし書式を取得**

Aspose.Slides を使用すると、テーブルのさまざまな部分に対する effective 塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/) インターフェイスは、effective 塗りつぶし書式プロパティを保持します。セル書式は行書式より優先度が高く、行書式は列書式より、列書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icellformateffectivedata/) のプロパティがテーブル セルの描画に使用されます。以下のコードサンプルは、テーブルのさまざまな部分に対する effective 塗りつぶし書式を取得する方法を示します。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) であると仮定しています。

```csharp
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

**`GetEffective` はスナップショットを返しますか？**

必ずしもそうではありません。Effective データは継承が適用された後に計算された書式を表しますが、一部の effective データオブジェクトは内部でキャッシュされることがあります。`GetEffective` を再度呼び出すと書式が再計算されキャッシュが更新される可能性があるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**いつ effective プロパティを再取得すべきですか？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション レベルのデフォルトを変更した後に `GetEffective` を再度呼び出してください。次の呼び出しで書式階層が再評価され、現在の effective 結果が返されます。

**レイアウト/マスター スライドを変更または削除すると、すでに取得した effective プロパティに影響しますか？**

影響しますが、変更は次の `GetEffective` 呼び出しで反映されます。親書式ソースが変更または削除された場合、以前取得した effective データは古くなる可能性があります。再度 `GetEffective` を呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**effective データオブジェクトを介して値を変更できますか？**

できません。effective データオブジェクトは計算された値を公開します。ローカル書式オブジェクトを変更し、必要に応じて再度 effective 値を取得してください。

**シェイプ レベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

effective 値は PowerPoint および Aspose.Slides のデフォルトを含む既定のメカニズムによって決定されます。その決定された値が現在の effective データの一部になります。

**effective フォント値から、どのレベルがサイズやフォント名を提供したか判断できますか？**

直接は判断できません。effective データは最終的な値を返します。ソースを特定するには、ポーション、段落、テキスト フレーム、およびレイアウト、マスター、プレゼンテーション レベルのテキスト スタイルでローカル値を確認し、最初に明示的に定義されている場所を探してください。

**なぜ effective 値がローカル値と同じに見えることがありますか？**

ローカル値が最終的な値となり、上位レベルの継承が不要だった場合です。そのようなケースでは effective 値はローカル値と一致します。

**effective プロパティを使用すべきとき、ローカルだけを使用すべきときはどちらですか？**

すべての継承が適用された後の「レンダリング結果」を必要とする場合は effective データを使用してください。たとえば、色、インデント、サイズを揃えるときなどです。後で書式変更があっても値を保持したい場合は、必要なプロパティを独自のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて effective データを再取得して結果を確認してください。