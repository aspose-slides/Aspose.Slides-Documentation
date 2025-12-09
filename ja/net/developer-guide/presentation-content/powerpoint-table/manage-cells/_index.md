---
title: PowerPoint プレゼンテーションでテーブルセルを管理する (.NET)
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
description: "Aspose.Slides for .NET を使用して PowerPoint のテーブルセルを簡単に管理できます。セルへのアクセス、変更、スタイル設定を迅速に習得し、スライドの自動化をシームレスに実現します。"
---

## **結合されたテーブルセルの識別**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を反復処理して結合セルを探します。
4. 結合セルが見つかったときにメッセージを出力します。

この C# コードは、プレゼンテーションで結合されたテーブルセルを識別する方法を示しています：
```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // Slide#0.Shape#0 がテーブルであると仮定しています
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


## **テーブルセルの境界線を削除**

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを使用してスライドにテーブルを追加します。
6. 各セルを反復処理し、上、下、右、左の境界線をクリアします。
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、テーブルセルの境界線を削除する方法を示しています：
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
   // 最初のスライドにアクセスします
    Slide sld = (Slide)pres.Slides[0];

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの枠線フォーマットを設定します
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // PPTX ファイルをディスクに書き込みます
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **結合セルの番号付け**

セル (1, 1) と (2, 1)、および (1, 2) と (2, 2) の 2 ペアを結合すると、結果のテーブルに番号が付けられます。この C# コードはその手順を示しています：
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide sld = presentation.Slides[0];

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの枠線フォーマットを設定します
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

    // セル (1, 1) と (2, 1) を結合します
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // セル (1, 2) と (2, 2) を結合します
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```


その後、セル (1, 1) と (1, 2) をさらに結合します。結果として、中央に大きな結合セルを持つテーブルが得られます：
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの枠線フォーマットを設定します
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

    // PPTX ファイルをディスクに書き込みます
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```


## **分割セルの番号付け**

前の例では、テーブルセルが結合されたとき、他のセルの番号付けや番号体系は変わりませんでした。

今回は、結合セルのない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint がテーブルセルに付ける番号付けの方法であり、Aspose.Slides も同様です。

この C# コードは、上記の手順を示しています：
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル シェイプを追加します
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの枠線フォーマットを設定します
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

    // PPTX ファイルをディスクに書き込みます
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```


## **テーブルセルの背景色を変更**

この C# コードは、テーブルセルの背景色を変更する方法を示しています：
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
2. インデックスを使用してスライドの参照を取得します。
3. 幅を持つ列の配列を定義します。
4. 高さを持つ行の配列を定義します。
5. `AddTable` メソッドを使用してスライドにテーブルを追加します。
6. 画像ファイルを保持するために `Bitmap` オブジェクトを作成します。
7. ビットマップ画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、テーブル作成時にテーブルセル内に画像を配置する方法を示しています：
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = presentation.Slides[0];

    // 幅を持つ列と高さを持つ行を定義します
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // スライドにテーブル シェイプを追加します
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


## **FAQ**

**単一セルの各側面に対して異なる線の太さやスタイルを設定できますか？**

はい。 [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) の各境界線は個別のプロパティを持っているため、各側面の太さやスタイルを別々に設定できます。これは、記事で示されたセルの各側面の境界線制御の論理的な結果です。

**セルの背景に画像を設定した後で列/行のサイズを変更すると、画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) に依存します。ストレッチの場合、画像は新しいセルに合わせて調整されます。タイルの場合、タイルが再計算されます。この記事ではセル内の画像表示モードについて言及しています。

**セルの全コンテンツにハイパーリンクを割り当てることはできますか？**

[Hyperlinks](/slides/ja/net/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、リンクをポーションに割り当てるか、セル内のすべてのテキストに割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（ラン）ごとに独立した書式設定（フォントファミリー、スタイル、サイズ、色）をサポートします。