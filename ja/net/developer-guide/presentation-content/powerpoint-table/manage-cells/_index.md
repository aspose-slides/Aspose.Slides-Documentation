---
title: .NET でプレゼンテーションのテーブルセルを管理する
linktitle: セルの管理
type: docs
weight: 30
url: /ja/net/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 境界線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、C# で PowerPoint のテーブルセルを管理します。結合セルの特定、境界線の削除、セルの分割、背景色や画像の設定が可能です。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint プレゼンテーション内のテーブルセルにアクセスして変更できます。この記事では、結合されたテーブルセルの識別、セルの枠線の削除、結合または分割後のセル番号の取り扱い、セルの背景色の変更、テーブルセル内への画像の追加方法を解説します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルを取得、セルプロパティを介したセル書式設定の更新、変更されたプレゼンテーションを PPTX ファイルとして保存する手順を示します。

Aspose.Slides は、テーブルセルにゼロベースのインデックスで `(column, row)` の順序でアクセスします。

## **結合されたテーブルセルを識別する**

この例は既存のプレゼンテーションを開き、最初のスライドの最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。その後、すべての行と列を反復し、[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) を使用して結合領域内のセルを識別します。該当するセルが見つかると、`row;column` の順序でセル座標、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)、および領域の開始座標である [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) と [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) を出力します。

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

## **テーブルセルの枠線を削除する**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブル位置はポイントで指定します。この例では、4 つのセル枠線すべてを [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) に設定し、枠線を非表示にします。

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

## **テーブルセルを結合する**

[MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) を使用して、矩形領域のテーブルセルを 1 つのセルに結合します。結合範囲の左上と右下のセルを指定します。最後の引数は、指定範囲外のセルを結合に含めるかどうかを制御します。`false` を指定すると、結合は範囲内に留まります。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中心セルを結合します。結果のセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは 4 列 4 行のままです。結合セルの内容や書式にアクセスするには、左上の位置 `table[1, 1]` を使用します。結合範囲内の他の位置はテーブルグリッドの一部であるため、範囲外のセルインデックスは変更されません。

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

## **テーブルセルを分割する**

前述の例でセルを結合すると、テーブルのグリッドは保持されます。セルを分割すると、新しいグリッド列が追加され、右側のセルの列インデックスが変更されることがあります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では、列幅・行高さが 70 ポイントの 4×4 テーブルを作成し、セル `(1, 1)` に対して [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) を呼び出します。セルの幅 70 ポイントの半分を渡して、幅が等しい 2 つのセルを作成します。

分割後、2 つの半分は `table[1, 1]` と `table[2, 1]` としてアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、更新された列インデックスを使用してください。

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

データ入力のために結合テンプレートセルを準備する場合、既存の行境界に沿って分割するには [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) を、列境界に沿って分割するには [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) を使用します。

`index` 引数は、分割の上部部分の行または左側部分の列をカウントし、結合領域に対して相対的です：

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

この例は、最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が縦に結合されていることを前提としています。下側の位置から開始し、[FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) と [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`SplitByRowSpan(1)` は製品名用に行 2 と行 3 を分離します。横方向の 2 列結合の場合は、代わりに `SplitByColSpan(1)` を使用します。

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

テーブルグリッドと周囲のセルインデックスは変更されません。結果のセルは座標で取得できます。ここでは両方ともスパンが 1 であり、[IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) は `False` を返します。1 回の分割後も、より大きな領域は部分的に結合されたままにすることができます。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにテキストを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持されたまま「Product A」および「Product B」セルが個別に存在します。詳細は [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) を参照してください。

## **テーブルセルの背景色を変更する**

この例では、列幅 150 ポイント、行高さ 50 ポイントのテーブルを作成します。セル `(2, 3)`（3 列目・4 行目）に対して、[FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を solid に、[SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) を赤に設定します。

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

## **テーブルセル内に画像を追加する**

このサンプルを実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) で読み込み、[AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像をテーブルの最初のセル `(0, 0)` のピクチャーフィルとして割り当てます。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) は画像をセル全体に伸ばすので、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。読み込んだ画像は using 宣言により自動的に破棄されます。

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

**単一のセルの各側面に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) の枠線は個別のプロパティを持つため、各側面の太さやスタイルを異なる設定にできます。

**セルの背景に画像を設定した後、列/行サイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。stretch を使用すると、画像は新しいセルサイズに合わせて調整されます。tile を使用すると、タイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/net/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実務では、ポーション単位またはセル内すべてのテキストに対してリンクを設定します。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、フォントファミリ、スタイル、サイズ、カラーを個別に指定できる [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（ラン）をサポートしています。