---
title: .NET でプレゼンテーションの図形を管理
linktitle: 図形操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- インターオップ形状 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- SVG 形式の図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、プレゼンテーションの図形を識別、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for .NET は、スライド上の図形を順序付けられた[IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/)として表します。このコレクションは、図形を検索・変更する場所であると同時に、スタッキング順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

本記事はこのモデルに従っています。まず図形を確実に識別する方法を説明し、続いて図形のクローン作成、削除、非表示、順序変更の手順を示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について解説します。各例は独立しているため、ワークフローに必要な操作だけを利用できます。

## **図形の識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形の追加・削除・順序変更によりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/) は、開発者が管理するテンプレートで便利で、PowerPoint の選択ウィンドウでも確認しやすいです。名前は編集可能で一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetext/) は、アクセシビリティ記述や作者が付与したタグが既に図形を特定できる場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために変更される可能性があり、一意性は保証されません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/officeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり PowerPoint のインターオップで使用される形状 ID と対応しています。PowerPoint と連携する場合や、図形の存続期間中に曖昧でない参照が必要な場合に使用してください。クローンや再作成された図形は別の図形となり、独自の ID が付与されます。

関連する[UniqueId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/uniqueid/) プロパティはプレゼンテーション全体で有効ですが、アドイン向けで再割り当て可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待する図形がまだ存在するか検証してください。

次の例は `Name` を序数比較で検索し、スライドスコープのインターオップ ID を報告します。テンプレートに期待する図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

操作が特定の図形タイプに限定される場合は、型固有のメンバーを使用する前にインターフェイスを確認してください。この例は、名前付きオブジェクトが[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)である場合にのみテキストと代替テキストを更新します。

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

## **図形コレクションの変更**

追加、クローン、削除、順序変更のメソッドはコレクションに即座に反映されます。操作により図形の数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標だけを受け取るオーバーロードはサイズを変えずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも可能です。

この例は宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。どちらのクローンに対する変更も元の図形には影響しません。

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

クローンは図形の内容と書式（名前や代替テキストを含む）をコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑な図形で使用されるリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目であり新しい図形 ID を持ちます。

### **図形の削除**

[Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/remove/) は特定の図形オブジェクトをそのコレクションから削除します。インデックス順に複数の一致を削除する場合は、末尾から走査して各残りインデックスが有効なままにしてください。

この例は指定された名前を持つすべての図形を削除します。固定のコレクション項目ではなく `slide.Shapes[i]` を読み取り、不要なキャストも行いません。

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

削除後は図形数と後続図形のインデックスが変わります。影響を受けない図形への参照は保存したインデックスよりも信頼性が高くなります。また、コネクタやアニメーションなど、削除されたオブジェクトを参照しているプレゼンテーション機能があるか考慮してください。可視図形を削除すると、スライドの外観以上の変化が生じることがあります。

### **図形の非表示**

[Hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/hidden/) を `true` に設定すると、図形はコレクション内に残りますが通常のスライドショーには表示されなくなります。インデックス、書式、コンテンツはコードから利用可能なままなので、後で復元できるオプション要素に適しています。

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

非表示は削除やセキュリティとは異なります。ユーザーやコードによって再び発見・非表示解除でき、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う図形はコレクション順に描画されます。[Reorder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/reorder/) は既存の図形をクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`Count - 1` が前面です。

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

矩形は最初に作成され、最初は楕円の背面にあります。最終インデックスに移動すると前面に表示されます。関連するすべての図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタックを変更する可能性があります。

## **レイアウトスライド上の図形の検査**

標準スライド、レイアウトスライド、マスタースライドはそれぞれ別個の図形コレクションを持ちます。レイアウトコレクション内の図形は、同じ位置にある標準スライド上の図形とは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウト図形を検査してください。

次の例は各レイアウト図形の[FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/fillformat/) と[LineFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/lineformat/) を取得し、すべてが `AutoShape` であると仮定せずに処理します。

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

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、標準スライドがそのオブジェクトを継承しているかローカルで上書きしているかを確認し、レイアウトを使用するすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[WriteAsSvg](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/writeassvg/) は単一図形のレンダリング結果をストリームに書き込みます。出力には図形そのものだけが含まれ、スライド全体の背景や隣接図形は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式とフォントや画像といったリソースに依存します。全体の構成が必要な場合は、個別図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、Dispose が必要です。

## **図形の配置**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/alignshapes/) のオーバーロードは、すべての図形または選択されたコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または配置モードを指定します。`alignToSlide` を `true` に設定するとスライドの端に合わせ、`false` にすると選択した図形同士の相対位置に合わせます。

この例は 3 つの図形をスライドの上端に揃えます。返された図形参照は整列直前に現在のインデックスへ変換されます。

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

配置は位置を変更しますが Z オーダー は変わりません。相対配置は通常少なくとも 2 つの図形が必要で、水平または垂直の均等配置は間隔を定義するために十分な図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeframe/) クラスは位置、サイズ、水平/垂直フリップ設定、回転を保持します。その `FlipH` と `FlipV` の値は[NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) を使用し、`True` でフリップ、`False` で無効、`NotDefined` で未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションにはフリップされていない図形が 1 つ含まれています。

![The shape before flipping](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、フリップ設定のみを置き換えます。新しい[Frame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/frame/) を割り当てるとフレーム全体が置き換わるため重要です。

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

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転はそのままです。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

短時間の処理でコレクションが変化しない場合に限り使用できます。テンプレートが作者管理の場合は検証済みの `Name` または `AlternativeText` を、スライドスコープのインターオップ操作が必要な場合は `OfficeInteropShapeId` を推奨します。

**図形を非表示にすると Z オーダー から削除されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、再順序付け、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`AddClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダー の前面になるためです。初期インデックスを指定したい場合は `InsertClone` を使用するか、すべての図形を追加した後に `Reorder` で位置を調整してください。