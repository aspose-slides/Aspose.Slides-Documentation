---
title: .NET でプレゼンテーションからシェイプの効果的プロパティを取得する
linktitle: 効果的プロパティ
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
description: "Aspose.Slides for .NET が、正確な PowerPoint 表示のためにシェイプの効果的プロパティをどのように計算し適用するかを学びます。"
---
## **概要**

このトピックでは **ローカル** と **効果的** なプロパティの違いについて説明します。ローカル値は、特定の書式設定レベルで直接設定された値で、例えば以下のようなものです。

1. スライド上のポーション プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプ シェイプのテキストスタイル（対象のポーションのテキストフレーム シェイプにスタイルが設定されている場合）。
1. プレゼンテーション全体のグローバルテキスト設定。

ローカル値は任意のレベルで定義したり省略したりできます。Aspose.Slides が最終的な「レンダリング後」の書式設定を必要とするとき、継承チェーンを解決し **効果的** な値を返します。ローカル書式オブジェクトで `GetEffective` メソッドを呼び出すことで取得できます。

以下の例は、効果的な値を取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持ち、少なくとも 1 つのポーションがある [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

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
効果的な書式データは、継承が適用された後に計算された現在の書式を表します。現在の実装では、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformateffectivedata/) などの一部の効果的データオブジェクトが内部的にキャッシュされることがあります。親または継承された書式を変更した後に `GetEffective` を再度呼び出すとキャッシュが更新され、以前取得したオブジェクトは以前の状態を表さなくなる可能性があります。効果的な値を後で再利用する必要がある場合は、フォント高さ、塗りつぶし色、フォントスタイル、配置などの必要なプロパティを独自のデータオブジェクトにコピーしてください。
{{% /alert %}}

## **カメラの効果的プロパティの取得**

Aspose.Slides はカメラの効果的プロパティを取得できます。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) インターフェイスは、効果的なカメラプロパティを含む不変オブジェクトを表します。[ICameraEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icameraeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の効果的な値を提供します。

以下のコードサンプルは、カメラの効果的プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定がされていると想定しています。

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

## **ライトリグの効果的プロパティの取得**

Aspose.Slides はライトリグの効果的プロパティを取得できます。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) インターフェイスは、効果的なライトリグプロパティを含む不変オブジェクトを表します。[ILightRigEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilightrigeffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の効果的な値を提供します。

以下のコードサンプルは、ライトリグの効果的プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定がされていると想定しています。

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **シェイプベベルの効果的プロパティの取得**

Aspose.Slides はシェイプベベルの効果的プロパティを取得できます。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) インターフェイスは、シェイプの効果的な面リリーフプロパティを含む不変オブジェクトを表します。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapebeveleffectivedata/) インスタンスは [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformateffectivedata/) を通じて公開され、[IThreeDFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ithreedformat/) の効果的な値を提供します。

以下のコードサンプルは、シェイプの上部ベベルの効果的プロパティを取得する方法を示しています。最初のスライドの最初のシェイプに 3D 書式設定がされていると想定しています。

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

## **テキストフレームの効果的プロパティの取得**

Aspose.Slides を使用すると、テキストフレームの効果的プロパティを取得できます。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformateffectivedata/) インターフェイスは、効果的なテキストフレーム書式プロパティを含みます。

以下のコードサンプルは、テキストフレームの効果的な書式プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

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

## **テキストスタイルの効果的プロパティの取得**

Aspose.Slides を使用すると、テキストスタイルの効果的プロパティを取得できます。[ITextStyleEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/itextstyleeffectivedata/) インターフェイスは、効果的なテキストスタイルプロパティを含みます。

以下のコードサンプルは、テキストスタイルの効果的プロパティを取得する方法を示しています。最初のスライドの最初のシェイプがテキストフレームを持つ [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) であると想定しています。

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

## **効果的なフォント高さの取得**

Aspose.Slides を使用すると、効果的なフォント高さを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカルのフォント高さが設定された後に、ポーションの効果的フォント高さがどのように変化するかを示しています。

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

## **テーブルの効果的な塗りつぶし書式の取得**

Aspose.Slides を使用すると、テーブルの各部分に対する効果的な塗りつぶし書式を取得できます。[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformateffectivedata/) インターフェイスは、効果的な塗りつぶし書式プロパティを含みます。セルの書式は行の書式より優先度が高く、行の書式は列の書式より、列の書式はテーブル全体の書式より優先されます。

その結果、[ICellFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/icellformateffectivedata/) のプロパティがテーブルセルの描画に使用されます。以下のコードサンプルは、テーブルの各部分に対する効果的な塗りつぶし書式を取得する方法を示しています。最初のスライドの最初のシェイプが [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) であると想定しています。

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

必ずしもありません。効果的データは継承が適用された後に計算された書式を表しますが、一部の効果的データオブジェクトは内部でキャッシュされることがあります。`GetEffective` を再度呼び出すと書式が再計算されキャッシュが更新されるため、以前取得したオブジェクトを永続的なスナップショットとして扱うべきではありません。

**効果的プロパティはいつ再取得すべきですか？**

ローカル書式、親スタイル、レイアウト書式、マスター書式、またはプレゼンテーション全体の既定を変更した後に `GetEffective` を再度呼び出します。次回の呼び出しで書式階層が再評価され、現在の効果的結果が返されます。

**レイアウト/マスタースライドを変更または削除すると、すでに取得した効果的プロパティに影響しますか？**

はい。ただし、変更は次回の `GetEffective` 呼び出し時に反映されます。親書式ソースが変更または削除された場合、以前取得した効果的データは古くなる可能性があります。`GetEffective` を再度呼び出すと、Aspose.Slides が書式ツリーを再評価し、フォント、色、サイズ、その他の値が変わることがあります。

**効果的データオブジェクトを介して値を変更できますか？**

できません。効果的データオブジェクトは計算済みの値を公開するだけです。変更はローカルの書式オブジェクトで行い、再度 `GetEffective` で効果的な値を取得してください。

**シェイプレベルでもレイアウト/マスターでもグローバル設定でもプロパティが設定されていない場合はどうなりますか？**

効果的値はデフォルト機構により決定されます。デフォルトは PowerPoint と Aspose.Slides の規定値を含み、解決された値が現在の効果的データの一部となります。

**効果的なフォント値から、どのレベルがサイズやフォントファミリを提供したか判断できますか？**

直接は判断できません。効果的データは最終的な値を返すだけです。どのレベルで最初に明示的に定義されたかを知りたい場合は、ポーション、段落、テキストフレーム、レイアウト、マスター、プレゼンテーション各レベルのローカル値を順に確認してください。

**なぜ効果的値がローカル値と同じに見えることがあるのですか？**

ローカル値がそのまま最終値となり、上位レベルの継承が不要だったためです。このような場合、効果的値はローカル値と一致します。

**効果的プロパティを使用すべき時と、ローカルプロパティだけを使用すべき時の違いは何ですか？**

すべての継承が適用された後の「実際にレンダリングされる」結果が必要な場合は効果的データを使用します。たとえば、色・インデント・サイズを揃えるときなどです。後で書式が変更されても値を保持したい場合は、必要なプロパティを自分のオブジェクトにコピーしてください。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて再度効果的データを取得して結果を確認します。