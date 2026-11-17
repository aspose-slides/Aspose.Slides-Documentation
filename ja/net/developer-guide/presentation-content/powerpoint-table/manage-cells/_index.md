---
title: .NET のプレゼンテーションでテーブルセルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/net/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# で PowerPoint のテーブルセルを管理します：結合セルの特定、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for .NET で行います。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーションのテーブルセルにアクセスし、変更することができます。この記事では、結合されたテーブルセルの識別方法、セルの枠線の削除、セルの結合または分割後の番号付けの操作、セルの背景色の変更、テーブルセル内への画像の挿入方法について説明します。例では、プレゼンテーションの作成または読み込み、スライドからテーブルを取得、セルプロパティを使用したセル書式の更新、そして変更したプレゼンテーションを PPTX ファイルとして保存する手順を示します。

Aspose.Slides はゼロベースのインデックスを使用し、テーブルセルへは `(column, row)` の順序でアクセスします。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を走査し、[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) を使用して結合領域内のセルを識別します。該当するセルごとに、`row;column` の順序でセル座標、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)、および領域の開始座標である [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) と [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) を出力します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **テーブルセルの枠線の削除**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、およびテーブル位置はポイント単位で指定します。この例では、すべてのセル枠線を [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) に設定し、枠線を非表示にしています。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **対角線枠線の追加**

[BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) を使用して左上隅から右下隅へ線を描画し、[BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) を使用して左下隅から右上隅へ線を描画します。対角線は角ヘッダーを示すことができ、両方の対角線を組み合わせて「X」形にすることでセルが該当しないことを表すことができます。

各対角線は [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/) です。その [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) で [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) に設定し、[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) を選択します。線の太さは [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) でポイント単位で指定します。

この例では、1 行に 3 つのセルを作成し、下向きの赤い対角線、上向きの青い対角線、そして両方の対角線を設定しています。上、下、左、右の枠線は変更せずにそのまま残します。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

対角線は書式プロパティであり、セルの分割ではありません。各セルは単一の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) を保持し、対角線の両側の領域を個別に編集することはできません。

保存されたテーブルは Microsoft PowerPoint で次のように表示されます。

![左上から右下への赤い対角線、左下から右上への青い対角線、そして両方の対角線で X 形になる 3 つのテーブルセル。](diagonal-cell-borders.png)

*左から右へ: 下向き対角線（赤、3 pt）、上向き対角線（青、5 pt）、両方の対角線。*

## **テーブルセルの結合**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。結合範囲の左上隅と右下隅のセルを指定します。最終引数は結合範囲外のセルを含めるかどうかを制御し、`false` にすると範囲内に限定されます。

この例では、列幅 70 ポイント、行高さ 70 ポイントの 4×4 テーブルを作成し、中心の 4 つのセル `(1, 1)` から `(2, 2)` までを結合します。結果として、結合されたセルは 2 列・2 行にまたがりますが、テーブルの基礎グリッドは 4 列・4 行のままです。結合セルの内容や書式にアクセスするには、左上位置 `table[1, 1]` を使用します。結合範囲内の他の位置はテーブルグリッドの一部であるため、範囲外のセルインデックスは変わりません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **テーブルセルの分割**

前の例でセルを結合した場合、テーブルのグリッドは保持されます。セルを分割すると新しいグリッド列が導入され、右側のセルの列インデックスが変わります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅 70 ポイント、行高さ 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) を呼び出します。セル幅 70 ポイントの半分を渡すことで、幅が等しい 2 つのセルが作成されます。

分割後、2 つの半分は `table[1, 1]` と `table[2, 1]` としてアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変わりません。分割後にセルへアクセスする際は、更新された列インデックスを使用してください。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **行または列のスパンで結合セルを分割する**

結合テンプレートセルをデータ入力用に準備するには、既存の行境界に沿って分割する [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) または列境界に沿って分割する [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) を使用します。

`index` 引数は分割上部の行または左部の列を数え、結合領域に対して相対的です。

- 行分割: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- 列分割: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

この例は、最初のスライドの最初のシェイプがテーブルであるプレゼンテーションを想定し、`(1, 2)` と `(1, 3)` が垂直に結合されていることを前提としています。下側の位置から開始し、[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) と [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`SplitByRowSpan(1)` は製品名用に行 2 と 3 を分離します。横方向の 2 列結合の場合は `SplitByColSpan(1)` を使用します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // 分割後にテーブルから得られるセルを取得します。
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

テーブルグリッドと周囲のセルインデックスは変更されません。座標で結果のセルを取得すると、両方ともスパンが 1 であり、[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) は `False` を返します。1 回の分割後も一部が結合されたままの大きな領域が残ることがあります。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには「Product A」および「Product B」セルが個別に存在し、テンプレートのセル書式が保持されています。詳細は [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) を参照してください。


<!-- visual-explanation:manage-cells:start -->
[![列 1、行 2 と 3 の結合セルが、同じグリッドインデックスで「Product A」と「Product B」に分割される様子。](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*行スパンの分割は既存の境界を使用します。「Product A」と「Product B」はそれぞれ (1, 2) と (1, 3) を占有します。*
<!-- visual-explanation:manage-cells:end -->

### **特定の高さでセルを分割する**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) は上部の高さ（ポイント）を指定します。[SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) は上部に含める既存グリッド行数を指定します。右側の列で 40 ポイントのセルを中央に配置するには、セルの実際の高さから 40 を引き、残りのスペースを上下に均等に分割します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

最初の分割でグリッド行が追加され、下部 90 ポイントが `[1, 1]` に残ります。2 回目の分割はそのセルを対象にさらに下に行を追加します。右側の列は現在、`[1, 0]` が 50 ポイント（余白）、`[1, 1]` が 40 ポイント、`[1, 2]` が 50 ポイント（余白）となります。左側のセルは 3 行すべてを跨ぎ、元の高さ 140 ポイントのままです。

![左側のセルがテーブル全高を占め、右側に中央に「Middle」がある 3 つのセルが配置されている様子。](split-by-height.png)

## **テーブルセルの背景色の変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。セル `(2, 3)`（3 列目・4 行目）に対して、[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を Solid に設定し、[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) を赤にします。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **テーブルセル内への画像追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) で読み込み、[AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をセル `(0, 0)`（テーブルの最初のセル）のピクチャーフィルに割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) は画像をセル全体に伸ばすため、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。読み込まれた画像は using 宣言により自動的に破棄されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**単一セルの各辺に異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) の枠線は個別のプロパティを持ち、各辺の太さやスタイルを別々に設定できます。

**セルの背景に画像を設定した後で列/行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch／tile）に依存します。stretch の場合は画像が新しいセルサイズに合わせて調整され、tile の場合はタイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、セル内のテキスト全体または一部のポーションにリンクを割り当てます。

**単一セル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（ラン）をサポートし、フォントファミリ、スタイル、サイズ、色などを個別に設定できます。