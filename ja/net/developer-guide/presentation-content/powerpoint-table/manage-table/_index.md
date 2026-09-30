---
title: .NET でプレゼンテーション テーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/net/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの整列
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルな C# コード例をご覧ください。"
---
## **概要**

PowerPoint のテーブルは情報を行と列に整理し、値の読み取りや比較を容易にします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) インターフェイス、およびその他の型を提供し、プレゼンテーション内のテーブルを作成、更新、管理できるようにします。

## **最初からテーブルを作成する**

位置、列幅、行高さを指定してテーブルを作成します。スライドに追加した後、セルの枠線を設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅の配列（ポイント）を定義します。
4. 行高さの配列（ポイント）を定義します。
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。
6. 各 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) を反復処理し、上・下・右・左の枠線を設定します。
7. テーブルの最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルの [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) プロパティにアクセスします。
9. 結合セルにテキストを設定します。
10. 変更されたプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントの位置に列が 3、行が 5 のテーブルを作成し、幅 5 ポイントの赤い枠線を適用し、最初の行の最初の 2 つのセルを結合し、結果を `table.pptx` として保存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルのインデックスは 0 から始まり、(列, 行) の順序で使用されます。最初のセルは (0, 0) とインデックス付けされます。

例として、4 列 4 行のテーブルのセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上記の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、枠線を幅 5 ポイントの赤で設定します。座標はセルインデックスを示しています。セルは空のままにし、テーブルを `StandardTables_out.pptx` として保存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **既存のテーブルにアクセスする**

テーブルはスライドのシェイプコレクションに格納されています。シェイプを反復処理してテーブルを見つけ、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイスを使用してセルを読み取ったり更新したりします。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでテーブルを含むスライドへの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) オブジェクトを反復処理し、テーブルが見つかった時点で停止します。スライドに複数のテーブルがある場合は、[AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) を使用して必要なテーブルを特定します。
4. 対象セルのテキストを更新します。
5. 変更されたプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、最初のスライドの最初のテーブルを見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 枚のスライドが含まれ、該当スライドの最初のテーブルは少なくとも 1 列 2 行を持っている必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

行の高さの制御については、[Control Row Height](/slides/ja/net/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルを見つける**

テーブルから取得した [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) を汎用テキスト処理コードが受け取った場合、所有する [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) を取得するには [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) プロパティを使用します。テーブルセルのテキストフレームでは、[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) が設定され、[ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) は `null` になります（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) および [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) プロパティで取得できます。[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) も読み取り専用で、所有者へのナビゲーションを提供しますが、所有権は変更しません。使用前に取得したセルが `null` でないことを必ず確認してください。

テーブルセルとシェイプの所有者を特定する完全なサンプル（SmartArt ノードに関連付けられたシェイプを含む）については、[Search and Replace Text](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを整列する**

個々のテーブルセルの垂直位置合わせとテキスト方向を制御できます。このセクションの例は、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) オブジェクトにアクセスします。
5. 最初の [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) にアクセスし、テキストと色を設定します。
6. セルの [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) と [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) を設定します。
7. 変更されたプレゼンテーションを保存します。

この例は列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成し、セル (0, 0) のテキストを整形し、最初の行の残りのセルに値を追加し、結果を `Vertical_Align_Text_out.pptx` として保存します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **テーブルレベルでテキスト書式設定を行う**

[SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) を使用すると、テーブル内のすべてのセルに対してテキスト書式設定を適用できます。オーバーロードは部分、段落、テキストフレームの書式設定を受け取り、個々のセルを反復処理せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトにアクセスします。
4. テキストの [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。
7. 変更されたプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます（このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプがテーブルである必要があります）。フォントサイズを 25 ポイントに設定し、右マージン 20 ポイントで段落を右揃えにし、テキストを垂直にします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **テーブルスタイルプロパティを取得する**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) を使用してテーブルのプリセットスタイルを読み取ったり割り当てたりできます。この例は、1 つのテーブルに [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) を適用し、プリセット名を出力し、同じプリセットを 2 番目のテーブルに割り当てます。両方のテーブルは `table-style.pptx` に保存されます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **テーブルのアスペクト比をロックする**

テーブルのアスペクト比は幅と高さの比率です。[AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます（このファイルは少なくとも 1 枚のスライドを含み、最初のシェイプがテーブルである必要があります）。現在のロック状態を出力し、アスペクト比ロックを有効にし、更新された状態 (`True`) を出力し、結果を `pres-out.pptx` として保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**テーブル全体とセル内のテキストに対して右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) プロパティを公開し、段落は [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) を持ちます。両方を使用すると、セル内で正しい RTL の順序とレンダリングが保証されます。

**最終ファイルでテーブルの移動やサイズ変更をユーザーに防止するにはどうすればよいですか？**

[shape locks](/slides/ja/net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（ストレッチまたはタイル）に従ってセル領域を覆います。