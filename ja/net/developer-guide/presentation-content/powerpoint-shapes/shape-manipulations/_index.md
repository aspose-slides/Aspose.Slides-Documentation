---
title: .NET でプレゼンテーションの形状を管理する
linktitle: 形状操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords:
- PowerPoint 形状
- プレゼンテーション形状
- スライド上の形状
- 形状の検索
- 形状のクローン
- 形状の削除
- 形状の非表示
- 形状順序の変更
- インターロップ形状 ID の取得
- 形状の代替テキスト
- 形状調整ポイント
- プリセット形状調整
- 形状ジオメトリ
- 形状レイアウト書式
- SVG 形式の形状
- 形状を SVG に変換
- 形状の整列
- 形状のフリップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、プレゼンテーションの形状を識別、調整、クローン、削除、非表示、順序変更、エクスポート、整列、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for .NET は、スライド上の形状を順序付けられた[IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/)として表します。このコレクションは、形状を検索・変更する場所であると同時に、スタッキング順序の元でもあります。インデックス`0`は最背面の形状で、最後のインデックスが最前面の形状です。

この記事はそのモデルに従っています。まず、形状を確実に識別し、プリセット形状の調整ポイントを変更する方法を説明し、次に形状のクローン作成、削除、非表示、並び替えを示します。最後のセクションでは、レイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **形状の識別と検索**

コレクションのインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。形状を追加、削除、または並び替えるとインデックスが変わります。プレゼンテーションの作成・管理方法に応じて識別子を選択してください：

- [Name](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/name/) は開発者が管理するテンプレートに便利で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を設定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetext/) は、アクセシビリティの説明や作者が付与したタグですでに形状を識別できる場合に便利です。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えることができ、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして黙って再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/officeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint のインターオップで使用される形状 ID に対応しています。PowerPoint と連携する場合や、形状の存続期間中に明確な参照が必要なときに使用してください。クローンまたは再作成された形状は別の形状となり、独自の ID を持ちます。

関連する[UniqueId](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/uniqueid/) プロパティはプレゼンテーション単位のスコープを持ちますが、アドイン向けで再割り当て可能です。永久的な外部キーとして扱うべきではありません。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待する形状がまだ存在するか検証してください。

代替テキストのタイトルと説明の読み取りと更新の実践例については、[Manage Alternative Text Titles and Descriptions](/slides/ja/net/presentation-accessibility/)をご覧ください。代替テキストは視覚要素の意味を読者に説明するために使用し、コードが形状を検索する際に使用する形状名とは別に管理してください。

以下の例は`Name`で序数比較を行って検索し、スライド単位のインターロップ ID を報告します。テンプレートに期待する形状が存在しない場合、コードは誤ったオブジェクトで続行するのではなく、その結果を報告します。

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

操作が特定の形状タイプに限定される場合、型固有のメンバーを使用する前にインターフェイスを確認してください。この例は、名前付きオブジェクトが[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)である場合にのみテキストと代替テキストを更新します。

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

## **プリセット形状調整の識別と変更**

プリセットジオメトリ形状は、角のサイズ、矢印の比率、円弧の角度などの機能を制御する調整ポイントを公開できます。これらは読み取り専用の[IGeometryShape.Adjustments](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/adjustments/)コレクションを介してアクセスします。コレクション自体は形状が提供しますが、各[IAdjustValue](https://reference.aspose.com/slides/ja/net/aspose.slides/iadjustvalue/)は変更可能な値を保持しています。

固定されたコレクションインデックスのみに依存しないでください。調整項目を列挙し、読み取り専用の[Type](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/type/)プロパティを調べます。この[ShapeAdjustmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeadjustmenttype/) の値が調整が制御する内容を示します。読み取り専用の[Name](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/name/) プロパティは追加の識別情報を提供し、同一の意味タイプを持つ調整が複数あるプリセットで特に有用です。

調整の意味に一致する値プロパティを使用してください：

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| `CornerSize` | 丸みの角のサイズ | [RawValue](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | 矢印の尾部の太さ | `RawValue` |
| `ArrowheadLength` | 矢じりの長さ | `RawValue` |
| `ArrowheadWidth` | 矢じりの幅 | `RawValue` |
| `StartAngle` | 円弧または扇形の開始角度 | [AngleValue](https://reference.aspose.com/slides/ja/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | 円弧または扇形の終了角度 | `AngleValue` |

`Type` と `Name` は代入できません。`RawValue` はプリセットのネイティブジオメトリ単位の読み書き可能な整数で、`AngleValue` は度単位の読み書き可能な角度です。調整項目の数、順序、意味、許容範囲はプリセットの[ShapeType](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/shapetype/)に依存します。あるプリセットで有効な値が別のプリセットでは無効だったり、異なる効果を持つことがあります。

`Type` が `ShapeAdjustmentType.Custom` の場合、API は標準的な意味を認識しません。`Name`、プリセットタイプ、既存の値を確認し、期待される意味と範囲が分からない限り調整は変更しないでください。認識されたタイプでも、同じタイプが複数回出現するかどうかを確認してから値を選択します。[Connector](/slides/ja/net/connector/) 記事では、コネクタの曲げ調整でこの状況が示されています。

以下の完全な例は、3つのプリセット形状のデフォルト版と変更版を作成します。すべての調整項目を列挙し、`Name` と `Type` を報告し、サイズ関連の値は `RawValue` で、角度は `AngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリを保持し、右列は調整された角丸矩形、4方向矢印、円弧を示します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// デフォルトおよび調整された形状列のヘッダーを追加します。
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

値を変更する前に意味タイプを確認することで、コードの意図が明確になり、特定のコレクションインデックスが異なるプリセット形状で同じ意味を持つと仮定することを防げます。

## **形状コレクションの変更**

追加、クローン、削除、並び替えのメソッドはコレクションに対して即座に作用します。操作により形状の数や順序が変わる場合、操作前に取得したインデックスに依存し続けないでください。

### **形状のクローン作成**

[AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[InsertClone](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/insertclone/) もコピーを作成しますが、指定した Z 順序インデックスに配置します。座標を受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも行えます。

この例は宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンに対する変更は元の形状に影響しません。

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

クローンは形状のコンテンツと書式設定、名前と代替テキストを含めてコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑な形状が使用するリソースはプレゼンテーションが管理しますが、クローンは新しい形状 ID を持つ新しいコレクション項目となります。

### **形状の削除**

[Remove](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/remove/) は特定の形状オブジェクトをそのコレクションから削除します。インデックスで反復しながら複数の一致を削除する場合は、後方から走査して残りのインデックスが有効であり続けるようにします。

この例は指定された名前を持つすべての形状を削除します。固定のコレクション項目ではなく `slide.Shapes[i]` を読み取り、不要に形状をキャストしません。

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

削除後は形状数と後続形状のインデックスが変わります。影響を受けない形状への参照は保存したインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除されたオブジェクトを参照している可能性があるため、可視形状の削除はスライドの外観以上の変更を引き起こすことがあります。

### **形状の非表示**

[Hidden](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/hidden/) を `true` に設定すると、形状はコレクション内に残りますが、通常のスライドショーには表示されません。インデックス、書式設定、コンテンツはコードから利用可能なままであるため、後で復元できるオプション要素に対して非表示は適切です。

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

非表示は削除やセキュリティではありません。ユーザーやコードがオブジェクトを検出して再表示でき、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う形状はコレクションの順序で描画されます。[Reorder](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/reorder/) は既存の形状をクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`Count - 1` が前面です。

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

矩形は最初に作成され、最初は楕円の背後にあります。最終インデックスへ移動すると前面に配置されます。関連するすべての形状を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタックを変更する可能性があります。

## **レイアウトスライド上の形状の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の形状コレクションを持ちます。レイアウトコレクションの形状は、通常スライド上の同様の位置にある形状と同一オブジェクトではありません。レイアウトが提供する書式設定を理解または変更する必要がある場合は、レイアウト形状を検査してください。

以下の例は、各レイアウト形状の[FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/fillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/lineformat/) を読み取り、すべての形状が `AutoShape` であると仮定しません。

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

レイアウトを編集すると、それを使用している複数のスライドに影響を与える可能性があります。レイアウト形状を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、そのレイアウトを使用しているすべてのスライドでテストしてください。

## **形状を SVG にエクスポート**

[WriteAsSvg](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/writeassvg/) は単一の形状の描画内容をストリームに書き出します。結果には形状だけが含まれ、スライド全体の背景や隣接する形状は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は形状の書式設定やフォント、画像などのリソースに依存します。全体の構成が必要な場合は、個々の形状ではなくスライド全体をエクスポートしてください。呼び出し側がストリームを所有し、破棄する必要があります。

## **形状の配置**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/alignshapes/) のオーバーロードは、すべての形状または選択されたコレクションインデックスを整列します。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/net/aspose.slides/shapesalignmenttype/) はエッジ、中心線、配布モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジを基準に、`false` に設定すると選択された形状同士の相対位置で整列します。

この例は3つの形状をスライドの上端に整列させます。返された形状参照は、整列直前に現在のインデックスに変換されます。

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

配置は位置を変更し、Z オーダーは変えません。相対配置には通常少なくとも2つの形状が必要で、水平または垂直の配布には間隔を定義できるだけの形状が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **形状のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `FlipH` と `FlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) を使用します：`True` はフリップを有効にし、`False` は無効にし、`NotDefined` は未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションには、フリップされていない形状が1つ含まれています。

![フリップ前の形状](shape_to_be_flipped.png)

この例は他のすべてのフレーム値を保持し、フリップ設定の2つだけを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/frame/) を代入するとフレーム全体が置き換えられるため、これは重要です。

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

保存された形状は位置、サイズ、回転を保持したまま、水平・垂直に鏡像化されています。

![フリップ後の形状](flipped_shape.png)

## **FAQ**

**コレクションインデックスを形状識別子として使用すべきですか？**

インデックスが使用されるまでコレクションが変わらない一時的な処理の場合に限り使用してください。作成されたテンプレートでは検証済みの `Name` または `AlternativeText` の規約を、スライド単位のインターロップ作業では `OfficeInteropShapeId` を使用することを推奨します。

**形状を非表示にすると Z オーダーから削除されますか？**

いいえ。非表示の形状は同じインデックスでコレクションに残ります。検索、並び替え、編集、再表示が可能です。

**なぜクローンされた形状が別の形状の前に表示されたのですか？**

`AddClone` はクローンをコレクションの末尾に追加し、これが Z オーダーの前面になります。初期インデックスを指定したい場合は `InsertClone` を使用するか、すべての形状を追加した後に `Reorder` を使用してください。

**固定インデックスを使用してプリセット形状の調整を識別できますか？**

正確なプリセットとコレクション配置を検証した後にのみ可能です。`IGeometryShape.Adjustments` を列挙し `IAdjustValue.Type` を確認することを優先してください。同じ意味タイプが複数ある場合は `IAdjustValue.Name` を追加情報として使用します。