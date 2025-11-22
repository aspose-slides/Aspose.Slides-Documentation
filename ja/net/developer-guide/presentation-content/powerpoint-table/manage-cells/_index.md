---
title: セルの管理
type: docs
weight: 30
url: /ja/net/manage-cells/
keywords:
- テーブル
- 結合セル
- 分割セル
- テーブルセルの画像
- C#
- C#
- Aspose.Slides for .NET
description: "PowerPoint プレゼンテーションのテーブルセル（C# または .NET）"
---

## **マージされたテーブルセルの識別**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して、結合されたセルを検出します。
4. 結合されたセルが見つかったときにメッセージを出力します。

この C# コードは、プレゼンテーションで結合されたテーブルセルを識別する方法を示します:
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // Slide#0.Shape#0 がテーブルであると想定しています
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```


## **テーブルセルの罫線を削除**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを使用してスライドにテーブルを追加します。
6. すべてのセルを反復処理し、上、下、右、左の罫線をクリアします。
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、テーブルセルの罫線を削除する方法を示します:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
   // 最初のスライドにアクセスします
    Slide sld = (Slide)pres.Slides[0];

    // 列の幅と行の高さを定義します
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加します
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの罫線フォーマットを設定します
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTX ファイルを書き込みます
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **結合セルの番号付け**

セルのペア (1,1) x (2,1) と (1,2) x (2,2) を結合すると、結果のテーブルに番号が付けられます。この C# コードはそのプロセスを示します:
```c#
 // Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Accesses the first slide
    ISlide sld = presentation.Slides[0];

    // Defines columns with widths and rows with heights
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Adds a table shape to the slide
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Sets the border format for each cell
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

    // Merges cells (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Merges cells (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


次に、(1,1) と (1,2) を結合してさらにセルを結合します。その結果、中央に大きな結合セルを持つテーブルが得られます: 
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 列の幅と行の高さを定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加します
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの罫線フォーマットを設定します
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

    // セル (1, 1) と (2, 1) を結合します
    table.MergeCells(table[1, 1], table[2, 1], false);

    // セル (1, 2) と (2, 2) を結合します
    table.MergeCells(table[1, 2], table[2, 2], false);

    // セル (1, 1) と (1, 2) を結合します
    table.MergeCells(table[1, 1], table[1, 2], true);

    // ディスクに PPTX ファイルを書き込みます
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **分割セルの番号付け**

前の例では、テーブルセルが結合されたとき、他のセルの番号付けや番号体系は変わりませんでした。

今回、結合されていない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint がテーブルセルに付ける番号付けの方法であり、Aspose.Slides も同じです。

この C# コードは、上記のプロセスを示します:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 列の幅と行の高さを定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加します
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの罫線フォーマットを設定します
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

    // セル (1, 1) と (2, 1) を結合します
    table.MergeCells(table[1, 1], table[2, 1], false);

    // セル (1, 2) と (2, 2) を結合します
    table.MergeCells(table[1, 2], table[2, 2], false);

    // セル (1, 1) を分割します。
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // ディスクに PPTX ファイルを書き込みます
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **テーブルセルの背景色を変更**

この C# コードは、テーブルセルの背景色を変更する方法を示します:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 新しいテーブルを作成する
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // セルの背景色を設定する
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```


## **テーブルセル内に画像を追加**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持するための `Bitmap` オブジェクトを作成します。
7. `IPPImage` オブジェクトにビットマップ画像を追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示します:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 列の幅と行の高さを定義します
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // スライドにテーブルシェイプを追加します
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // ファイルから画像を読み込み、プレゼンテーションのリソースに追加します
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 画像を最初のテーブルセルに追加します
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // PPTX ファイルをディスクに保存します
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[上](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)、[下](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)、[左](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)、[右](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) の罫線は個別のプロパティを持ち、各辺の太さやスタイルを別々に設定できます。これは、記事で示されたセルの辺ごとの罫線制御に論理的に対応しています。

**セルの背景に画像を設定した後、列/行のサイズを変更すると画像はどうなりますか？**

動作は [塗りつぶしモード](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch/tile）に依存します。stretch の場合、画像は新しいセルサイズに合わせて伸縮します；tile の場合、タイルが再計算されます。記事ではセル内の画像表示モードについて言及しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[ハイパーリンク](/slides/ja/net/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定できます。実際には、セル内の特定の部分またはすべてのテキストにリンクを割り当てます。

**単一セル内でフォントを異なるものに設定できますか？**

はい。セルのテキストフレームは、[ポーション](https://reference.aspose.com/slides/net/aspose.slides/portion/)（ラン）ごとに独立した書式設定（フォントファミリ、スタイル、サイズ、色）をサポートしています。