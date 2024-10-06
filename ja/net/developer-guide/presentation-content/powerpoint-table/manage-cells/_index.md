---
title: セルの管理
type: docs
weight: 30
url: /ja/net/manage-cells/
keywords:
- テーブル
- 結合されたセル
- 分割されたセル
- テーブルセル内の画像
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETにおけるPowerPointプレゼンテーションのテーブルセル"
---

## **結合されたテーブルセルの特定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復して、結合されたセルを探します。
4. 結合されたセルが見つかったときにメッセージを表示します。

このC#コードは、プレゼンテーション内の結合されたテーブルセルを特定する方法を示しています：

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // assuming that Slide#0.Shape#0 is a table
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} は、RowSpan={2} および ColSpan={3} の結合セルの一部であり、Cell {4};{5} から始まります。",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **テーブルセルの境界線を削除**
1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを通じてスライドにテーブルを追加します。
6. 各セルを反復して、上、下、右、および左の境界線をクリアします。
7. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、テーブルセルから境界線を削除する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{
   // 最初のスライドにアクセス
    Slide sld = (Slide)pres.Slides[0];

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTXファイルをディスクに書き込み
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **結合されたセル内の番号付け**
1組のセル(1, 1) x (2, 1) および (1, 2) x (2, 2)を結合すると、結果のテーブルに番号が付けられます。このC#コードはそのプロセスを示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide sld = presentation.Slides[0];

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // セル (1, 1) x (2, 1) を結合
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // セル (1, 2) x (2, 2) を結合
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

次に、（1, 1）および（1, 2）を結合して、中央に大きな結合セルを持つテーブルを得ます：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = presentation.Slides[0];

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // セル (1, 1) x (2, 1) を結合
    table.MergeCells(table[1, 1], table[2, 1], false);

    // セル (1, 2) x (2, 2) を結合
    table.MergeCells(table[1, 2], table[2, 2], false);

    // セル (1, 1) と (1, 2) を結合
    table.MergeCells(table[1, 1], table[1, 2], true);

    // PPTXファイルをディスクに書き込み
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **分割されたセル内の番号付け**
以前の例では、テーブルセルが結合されると、他のセルのナンバリングまたは番号システムは変更されませんでした。

今回は、通常のテーブル（結合されたセルのないテーブル）を取り、セル (1, 1) を分割して特別なテーブルを取得します。このテーブルの番号付けには奇妙な点があるかもしれませんが、これはMicrosoft PowerPointがテーブルセルに番号を付ける方法であり、Aspose.Slidesも同様のことを行います。

このC#コードは、私たちが説明したプロセスを示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = presentation.Slides[0];

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの境界線形式を設定
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // セル (1, 1) x (2, 1) を結合
    table.MergeCells(table[1, 1], table[2, 1], false);

    // セル (1, 2) x (2, 2) を結合
    table.MergeCells(table[1, 2], table[2, 2], false);

    // セル (1, 1) を分割
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // PPTXファイルをディスクに書き込み
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **テーブルセルの背景色を変更**

このC#コードは、テーブルセルの背景色を変更する方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 新しいテーブルを作成
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // セルの背景色を設定 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **テーブルセル内に画像を追加**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを通じてスライドにテーブルを追加します。 
6. 画像ファイルを保持する `Bitmap` オブジェクトを作成します。
7. ビットマップ画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 修正されたプレゼンテーションをPPTXファイルとして保存します。

このC#コードは、テーブルを作成するときにテーブルセル内に画像を配置する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = presentation.Slides[0];

    // 幅と高さを持つ列と行を定義
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // スライドにテーブル形状を追加
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // ファイルから画像を読み込み、プレゼンテーションリソースに追加
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 最初のテーブルセルに画像を追加
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTXファイルをディスクに保存
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```