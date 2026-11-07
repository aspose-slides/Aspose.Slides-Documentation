---
title: .NET におけるプレゼンテーションのテキスト ボックスの管理
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/net/manage-textbox/
keywords:
- テキスト ボックス
- テキスト フレーム
- テキストの追加
- テキストの更新
- テキスト ボックスの作成
- テキスト ボックスのチェック
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキスト ボックスを作成、識別、書式設定、および更新します。"
---
## **導入**

Aspose.Slides for .NET では、スライドのテキストはシェイプに属するテキストフレームに格納されます。[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) インターフェイスは、最も一般的なテキストを保持するシェイプを表し、[IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) プロパティを介してテキストを公開します。

{{% alert color="info" title="Note" %}}
すべてのオートシェイプは[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) を実装しますが、すべてのシェイプがオートシェイプであるわけでもテキストフレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、シェイプが `IAutoShape` を実装しているか確認してからテキストにアクセスしてください。
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

テキスト ボックスを作成するには、スライドにオートシェイプを追加し、そのテキストフレームにテキストを入れてからプレゼンテーションを保存します。以下の例は矩形のテキスト ボックスを作成します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) に渡す座標とサイズはポイント単位で測定されます。[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) は、指定されたテキストでテキストフレームを初期化します。

## **テキスト ボックス シェイプのチェック**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) プロパティを使用して、オートシェイプがテキスト ボックスとして扱われるかどうかを判断します。プレゼンテーションにテキストを含むオートシェイプと純粋にグラフィックだけのオートシェイプの両方が含まれる場合に便利です。

![テキスト ボックスとシェイプ](istextbox.png)

以下の例はプレゼンテーション内のすべてのオートシェイプを検査します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

新しく追加されたオートシェイプは、空でないテキストが含まれるまでテキスト ボックスとみなされません。そのテキストは[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) または[ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) を使用して提供できます。空文字列を追加または割り当てた場合、`IsTextBox` は `false` のままです。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

最初の2回の呼び出しは `True` を出力し、最後の2回は `False` を出力します。

## **テキスト フレームを所有するシェイプの検索**

汎用的なテキスト処理コードは、どのプレゼンテーションオブジェクトが所有しているか分からない状態で[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) を受け取ることがあります。読み取り専用の[ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) プロパティを使用して、所有する[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) へ戻ることができます。

オートシェイプや他のテキストを保持するシェイプが所有するテキスト フレームの場合、`ParentShape` に所有者が格納され、[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) は `null` です。アクセスする前に返された値を確認してください。シェイプとテーブルセルの所有者の両方、さらに SmartArt ノードに関連付けられたシェイプを特定するには、[テキストの検索と置換](/slides/ja/net/search-and-replace-text/) を参照してください。

## **シェイプのテキスト矩形の取得**

Aspose.Slides for .NET 26.11 以降、[ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) は親シェイプのジオメトリで定義されたテキスト領域を返します。その座標とサイズはポイント単位で、シェイプの左上隅を基準とします。たとえば、楕円形は外形よりも小さいテキスト矩形を持ちます。

この矩形はシェイプを表すものであり、実際に描画された文字を示すものではありません。テキストやテキストフレームの余白を変更しても、占有テキストの測定にはなりません。描画されたテキストの測定には[段落境界](/slides/ja/net/paragraph-bounds/)または[部分境界](/slides/ja/net/portion-bounds/) を使用してください。

[Aspose.Slides for .NET のインストール](/slides/ja/net/installation/) 26.11 以降に、次の例を実行してジオメトリのテキスト矩形を赤で描画します。シェイプは回転もグループ化もされていないため、X/Y 位置を加えるだけでスライド上にオーバーレイを配置できます。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

上記の 200 × 100 ポイントのシェイプの場合、矩形は `(0, 0, 200, 100)` を返します。楕円形はおおよそ `(29.289, 14.645, 141.421, 70.711)` を返します。このメソッドはカスタムジオメトリで宣言されたテキスト矩形も読み取りますが、スライド空間の回転やグループ変換は適用されません。オーバーレイの位置決め時にそれらを別途考慮してください。ジオメトリシェイプを持たないテキストフレーム（例: テーブルセルのテキストフレーム）は `InvalidOperationException` をスローする可能性があります。

## **テキスト ボックスに列を追加する**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) プロパティはテキストフレームを列に分割し、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) は列間の間隔をポイントで設定します。これらの設定は[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) に属し、既存のテキスト ボックスのテキストフレームを介して変更できます。テキストは同じシェイプ内の列間で再配置され、別のシェイプに続くことはありません。

以下の例は、列間に 10 ポイントの間隔を持つ 3 列のテキスト ボックスを作成し、プレゼンテーションを保存し、出力ファイルから保存された設定を読み取ります。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **個々の列からテキストを抽出する**

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) を使用して、既存のテキストフレーム内の各可視列に割り当てられたテキストを取得します。このメソッドは列ごとに 1 つの文字列を、列ベースの読み順で返します。1 列のテキストフレームは要素が 1 つの配列を生成し、空の列は空文字列で表されます。文字列はプレーンテキストのみを含み、部分レベルの書式は保持されません。

これは次のような場合に便利です：

- 列ベースの読み順を保持したままテキストを抽出する。
- マルチ列スライドの内容をインデックス化または比較する。
- 各列を別々のファイル、データベースフィールド、または他の宛先にエクスポートする。
- フォントやテキストフレームのサイズ、[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/)、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) を変更した後、テキストがどのように再分配されるかを確認する。

このメソッドは現在の[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 内に配布されたテキストを報告しますが、別々のシェイプやテキスト ボックス間で自動的にテキストを流すことはありません。列の分配は利用可能なフォントやその他のテキストレイアウト設定に依存する可能性があるため、一貫した結果が重要な場合は必要なフォントが利用可能であることを確認してください。

以下の例はプレゼンテーションを読み込み、テキストフレームを持つ最初のマルチ列オートシェイプを見つけ、その設定された列数を取得し、各列のテキストを別々のファイルに書き出します。テキストフレームを提供しないシェイプはスキップされます。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **テキストの更新**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを反復処理し、オートシェイプを選択してからテキスト部分を編集します。部分レベルで作業することで、テキストと文字書式の両方を変更できます。

以下の例は、オートシェイプのテキスト内で `years` のすべての出現を `months` に置換し、影響を受けた各部分を太字にします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

この走査はオートシェイプのテキストのみを更新します。テーブル、チャート、SmartArt、またはグループ化シェイプに格納されたテキストを変更するには、これらオブジェクト独自のコレクションを走査する必要があります。

## **ハイパーリンク付きテキスト ボックスの追加**

ハイパーリンクは特定のテキスト部分に割り当てることができ、そのテキストだけがクリック可能なリンクとして機能します。[IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) を使用して、部分を外部 URL に関連付けます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **よくある質問**

**テキスト ボックスとマスターまたはレイアウト スライド上のテキスト プレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/net/manage-placeholder/) は[マスタースライド](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)や[レイアウトスライド](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/)から位置と書式を継承できます。通常のテキスト ボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されてもプレースホルダーの動作を取得しません。

**チャート、テーブル、または SmartArt のテキストを変更せずにテキストを置換するにはどうすればよいですか？**

更新テキストの例に示すように、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を実装するシェイプに走査を限定します。チャート、テーブル、SmartArt は独自のオブジェクトモデルにテキストを保持しているため、そのループでは変更されません。