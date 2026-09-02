---
title: .NET でプレゼンテーション シェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- Interop シェイプ ID の取得
- シェイプ代替テキスト
- シェイプ調整ポイント
- プリセットシェイプ調整
- シェイプジオメトリ
- シェイプレイアウト書式
- シェイプの SVG 変換
- シェイプを SVG に変換
- シェイプの整列
- シェイプの反転
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET を使用して、プレゼンテーション シェイプの識別、調整、クローン作成、削除、非表示、順序変更、エクスポート、整列、反転の方法を学びます。
---
## **概要**

Aspose.Slides for .NET は、スライド上のシェイプを順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/) として表します。このコレクションはシェイプの検索・変更の場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面のシェイプで、最後のインデックスが最前面のシェイプです。

本記事はこのモデルに従います。まずシェイプを確実に特定し、プリセットの調整ポイントを変更する方法を説明し、続いてシェイプのクローン作成、削除、非表示、並び替えを示します。最終セクションではレイアウトレベルの書式設定、SVG エクスポート、整列、反転設定を扱います。各例は独立しているため、必要な操作だけを使用できます。

## **シェイプの識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。シェイプの追加・削除・並び替えによりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/) は開発者が管理するテンプレートに有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetext/) はアクセシビリティ記述や作成者が付与したタグが既にシェイプを識別している場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために書き換えられる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/officeinteropshapeid/) は読み取り専用で、スライド内で一意であり、PowerPoint Interop が使用するシェイプ ID に対応します。PowerPoint 連携やシェイプのライフタイム中に曖昧でない参照が必要な場合に使用してください。クローンや再作成されたシェイプは別のシェイプとなり、独自の ID を取得します。

関連する [UniqueId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/uniqueid/) プロパティはプレゼンテーション全体で有効ですが、アドイン向けで再割り当て可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプが依然として存在するか検証してください。

以下の例は `Name` を序数比較で検索し、スライドスコープの Interop ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

操作がシェイプタイプに依存する場合は、型固有メンバーを使用する前にインターフェイスを確認してください。この例は、対象オブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) である場合にのみテキストと代替テキストを更新します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **プリセットシェイプ調整の識別と変更**

プリセットジオメトリシェイプは、角サイズ、矢印の比率、弧の角度などの機能を制御する調整ポイントを公開することがあります。これらは読み取り専用の [IGeometryShape.Adjustments](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/adjustments/) コレクションを通じてアクセスします。コレクション自体はシェイプから提供されますが、各 [IAdjustValue](https://reference.aspose.com/slides/ja/net/aspose.slides/iadjustvalue/) が変更可能な値を保持しています。

固定インデックスだけに依存しないでください。調整項目を走査し、読み取り専用の [Type](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/type/) プロパティを確認します。このプロパティの [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeadjustmenttype/) の値が、調整が何を制御するかを示します。読み取り専用の [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/name/) プロパティは追加の識別情報を提供し、同一のセマンティックタイプを持つ調整が複数あるプリセットでは特に有用です。

調整の意味に合った値プロパティを使用してください。

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| `CornerSize` | 角丸のサイズ | [RawValue](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 矢印の尾部の太さ | `RawValue` |
| `ArrowheadLength` | 矢尻の長さ | `RawValue` |
| `ArrowheadWidth` | 矢尻の幅 | `RawValue` |
| `StartAngle` | パイまたは弧の開始角度 | [AngleValue](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | パイまたは弧の終了角度 | `AngleValue` |

`Type` と `Name` は代入できません。`RawValue` はプリセット固有のジオメトリ単位の整数で読み書き可能、`AngleValue` は度単位の角度で読み書き可能です。調整項目の数・順序・意味・有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/shapetype/) に依存します。あるプリセットで有効な値が、別のプリセットでは無効または異なる効果を持つことがあります。

`Type` が `ShapeAdjustmentType.Custom` の場合、API は標準的なセマンティック意味を認識しません。`Name`、プリセットタイプ、既存値を確認し、期待する意味と範囲が分からない限り調整は変更しないでください。認識されたタイプでも、同一タイプが複数回出現するかどうかを確認してから値を設定します。[Connector](/slides/ja/net/connector/) 記事はコネクタの曲げ調整でこの状況を示しています。

以下の完全な例は、3 つのプリセットシェイプのデフォルト版と変更版を作成します。すべての調整を走査し、`Name` と `Type` を報告し、サイズ関連の値は `RawValue`、角度は `AngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整された角丸矩形、四方向矢印、パイです。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// デフォルトと調整されたシェイプ列の見出しを追加します。
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

値を変更する前にセマンティックタイプを確認することで、コードは意図を明示的に示し、異なるプリセットシェイプ間で同一インデックスが同じ意味を持つと誤認することを防げます。

## **シェイプコレクションの変更**

追加、クローン、削除、並び替えメソッドはコレクションに即座に反映されます。操作がシェイプの数や順序を変更した場合、操作前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン作成**

[AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/insertclone/) もコピーを作成しますが、指定した Z 順序インデックスに配置します。座標を受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅・高さを受け取るオーバーロードはサイズ変更も可能です。

例では、宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンを変更しても元のシェイプは影響を受けません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

クローンはシェイプのコンテンツと書式設定、名前、代替テキストをコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑なシェイプが使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新たなシェイプ ID を持ちます。

### **シェイプの削除**

[Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/remove/) は特定のシェイプオブジェクトをコレクションから削除します。インデックス付きで複数一致項目を削除する場合は、最後から順に走査して各残りインデックスが有効なままになるようにしてください。

この例は、指定された名前を持つすべてのシェイプを削除します。固定のコレクション項目ではなく `slide.Shapes[i]` を読み取り、不要なキャストも行っていません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

削除後はシェイプ数と以降のシェイプインデックスが変わります。影響を受けないシェイプへの参照は保存したインデックスよりも信頼性が高くなります。また、コネクタやアニメーションなど、削除対象オブジェクトを参照しているプレゼンテーション機能も考慮してください。表示上のシェイプを削除すると、スライドの外観以上の変化が起こる可能性があります。

### **シェイプの非表示**

[Hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/hidden/) を `true` に設定すると、シェイプはコレクションに残りますが、通常のスライドショーには表示されません。インデックス、書式、コンテンツはコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

非表示は削除やセキュリティとは異なります。ユーザーやコードで再び表示状態にでき、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合うシェイプはコレクション順に描画されます。[Reorder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/reorder/) は既存シェイプをクローンせずに対象インデックスへ移動します。インデックス `0` が背面、`Count - 1` が前面です。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

矩形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動すると前面に表示されます。すべての関連シェイプの追加またはクローン作成が完了した後で Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順を変更する可能性があります。

## **レイアウトスライド上のシェイプの検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクションのシェイプは、通常スライド上の同位置シェイプとは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウトシェイプを検査してください。

以下の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/fillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/lineformat/) を読み取り、すべてが `AutoShape` であると仮定しません。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

レイアウトの編集は、そのレイアウトを使用している複数のスライドに影響します。レイアウトシェイプを変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、レイアウトを使用しているすべてのスライドでテストしてください。

## **シェイプをSVGにエクスポート**

[WriteAsSvg](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/writeassvg/) は単一シェイプの描画結果をストリームに書き込みます。出力はシェイプのみを含み、スライド全体の背景や隣接シェイプは含まれません。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式設定やフォント・画像といったリソースに依存します。全体の構成が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。ストリームは呼び出し側が所有し、適切に破棄する必要があります。

## **シェイプの整列**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/alignshapes/) のオーバーロードは、すべてのシェイプまたは選択されたコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` にすると選択シェイプ同士の相対位置で整列します。

この例は 3 つのシェイプをスライド上部エッジに整列させます。返されるシェイプ参照は整列直前に現在のインデックスへ変換されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

整列は位置を変更しますが Z オーダーは変わりません。相対整列には通常最低 2 つのシェイプが必要で、水平または垂直の分布には間隔を定義できるだけのシェイプが必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **シェイプの反転**

[ShapeFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。`FlipH` と `FlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) を使用し、`True` でフリップ有効、`False` で無効、`NotDefined` で未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションにはフリップされていないシェイプが 1 つ含まれています。

![反転前のシェイプ](shape_to_be_flipped.png)

例では他のフレーム値はすべて保持し、フリップ設定のみを置き換えています。これは新しい [Frame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/frame/) を代入するとフレーム全体が置き換えられるため重要です。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

保存されたシェイプは水平・垂直ともに鏡像になり、位置・サイズ・回転はそのままです。

![反転後のシェイプ](flipped_shape.png)

## **FAQ**

**コレクションインデックスをシェイプ識別子として使用すべきですか？**

短期間の処理で、インデックス取得後にコレクションが変更されないことが保証されている場合のみ使用してください。作成されたテンプレートでは検証済みの `Name` または `AlternativeText` の規約を、スライドスコープの Interop 作業では `OfficeInteropShapeId` を優先してください。

**シェイプを非表示にすると Z オーダーから除外されますか？**

いいえ。非表示シェイプは同じインデックスでコレクションに残り、検索、並び替え、編集、再表示が可能です。

**クローンしたシェイプが別のシェイプの前に表示されたのはなぜですか？**

`AddClone` はクローンをコレクションの末尾に追加し、Z オーダーの最前面になります。初期インデックスを指定したい場合は `InsertClone` を使用するか、すべてのシェイプ追加後に `Reorder` で調整してください。

**プリセットシェイプの調整を固定インデックスで識別できますか？**

正確なプリセットとコレクション構造を検証した場合に限り可能です。`IGeometryShape.Adjustments` を走査し `IAdjustValue.Type` を確認することを推奨します。同一セマンティックタイプが複数ある場合は `IAdjustValue.Name` を追加情報として利用してください。