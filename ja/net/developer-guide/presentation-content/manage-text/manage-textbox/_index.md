---
title: .NET でのプレゼンテーションのテキスト ボックスの管理
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
- テキスト ボックスの確認
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーション内のテキスト ボックスを作成、識別、書式設定、更新します。"
---
## **はじめに**

Aspose.Slides for .NET では、スライドのテキストはシェイプに属するテキスト フレームに保存されます。[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) インターフェイスは最も一般的なテキストを保持するシェイプを表し、テキストは [IAutoShape.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/textframe/) プロパティを介して取得できます。

{{% alert color="info" title="Note" %}}
すべてのオート シェイプは[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) を実装していますが、すべてのシェイプがオート シェイプであるわけでもテキスト フレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、シェイプが `IAutoShape` を実装しているか確認してからテキストにアクセスしてください。
{{% /alert %}}

## **スライド上にテキスト ボックスを作成**

テキスト ボックスを作成するには、スライドにオート シェイプを追加し、そのテキスト フレームにテキストを設定してプレゼンテーションを保存します。以下の例は長方形のテキスト ボックスを作成します：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addautoshape/) に渡される座標とサイズはポイントで測定されます。[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/addtextframe/) は指定されたテキストでテキスト フレームを初期化します。

## **テキスト ボックス シェイプかどうかを確認**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/istextbox/) プロパティを使用して、オート シェイプがテキスト ボックスとして扱われるかどうかを判定します。プレゼンテーションにテキストを保持するシェイプと純粋にグラフィックだけのシェイプの両方が含まれる場合に便利です。

![テキスト ボックスとシェイプ](istextbox.png)

以下の例はプレゼンテーション内のすべてのオート シェイプを検査します：

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

新しく追加されたオート シェイプは、空でないテキストが設定されるまでテキスト ボックスとはみなされません。そのテキストは[IAutoShape.AddTextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/addtextframe/) または[ITextFrame.Text](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/text/)で提供できます。空文字列を追加または代入した場合、`IsTextBox` は `false` のままです：

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

最初の 2 回の呼び出しは `True` を出力し、最後の 2 回は `False` を出力します。

## **テキスト フレームを所有するシェイプを見つける**

汎用的なテキスト処理コードは、どのプレゼンテーション オブジェクトが所有しているか分からないまま[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) を受け取ることがあります。読み取り専用の[ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/) プロパティを使用して、所有者である[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) に遡ります。

オート シェイプや他のテキストを保持するシェイプが所有するテキスト フレームの場合、`ParentShape` に所有者が格納され、[ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) は `null` です。アクセスする前に返された値を確認してください。シェイプとテーブル セルの両方の所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定するには、[Search and Replace Text](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/columncount/) プロパティはテキスト フレームを列に分割し、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/columnspacing/) は列間の間隔をポイントで設定します。これらの設定はすべて[ITextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/) に属し、既存のテキスト ボックスのテキスト フレームを介して変更できます。同一シェイプ内で列間でテキストが再配置されますが、別のシェイプに続くことはありません。

以下の例は、列間 10 ポイントの 3 列テキスト ボックスを作成し、プレゼンテーションを保存して、出力ファイルから保存された設定を読み戻します：

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

## **個別列からテキストを抽出**

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/splittextbycolumns/) を使用して、既存のテキスト フレーム内の各視覚列に割り当てられたテキストを取得します。このメソッドは列ごとに 1 つの文字列を、列ベースの読み順で返します。1 列のテキスト フレームは要素が 1 つの配列を生成し、空の列は空文字列で表されます。文字列はプレーンテキストのみを含み、部分レベルの書式設定は保持されません。

これは次のような場合に便利です：

- 列ベースの読み順を保持したままテキストを抽出する。
- 複数列スライドの内容をインデックス化または比較する。
- 各列を別々のファイル、データベース フィールド、または他の宛先にエクスポートする。
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/columncount/)、[ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/columnspacing/)、フォント、またはテキスト フレームのサイズを変更した後、テキストがどのように再配分されるかを確認する。

このメソッドは現在の[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) 内に分布しているテキストを報告します。別々のシェイプやテキスト ボックス間で自動的にテキストを流すことはありません。列の分布は使用可能なフォントやその他のテキスト配置設定に依存するため、結果の一貫性が重要な場合は必要なフォントが利用可能であることを確認してください。

以下の例はプレゼンテーションを読み込み、テキスト フレームを持つ最初の複数列オート シェイプを検索し、設定された列数を取得して、各列のテキストを別々のファイルに書き出します。テキスト フレームを提供しないシェイプはスキップされます。

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

## **テキストを更新**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを反復処理し、オート シェイプを選択してからテキストの部分を編集します。部分レベルで作業することで、テキストと文字書式の両方を変更できます。

以下の例はオート シェイプのテキスト内のすべての `years` を `months` に置換し、影響を受けた各部分を太字にします：

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

この走査はオート シェイプのテキストのみを更新します。テーブル、チャート、SmartArt、またはグループ化されたシェイプに格納されたテキストは、それらオブジェクトのコレクションを走査する必要があります。

## **ハイパーリンク付きテキスト ボックスを追加**

ハイパーリンクは特定のテキスト部分に割り当てることができ、そのテキストだけがクリック可能なリンクとして機能します。[IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) を使用して、部分を外部 URL に関連付けます。

以下の例はリンク付きテキストを作成し、プレゼンテーションに保存します：

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

## **FAQ**

**マスタースライドまたはレイアウトスライド上のテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/net/manage-placeholder/) は [master slide](https://reference.aspose.com/slides/ja/net/aspose.slides/masterslide/) または [layout slide](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutslide/) から位置と書式を継承できます。通常のテキスト ボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されてもプレースホルダーの動作は取得しません。

**チャート、テーブル、SmartArt のテキストを変更せずにテキストを置換するにはどうすればよいですか？**

Update Text の例に示すように、[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を実装しているシェイプのみに走査を限定してください。チャート、テーブル、SmartArt はそれぞれのオブジェクト モデルにテキストを保持しているため、そのループでは変更されません。