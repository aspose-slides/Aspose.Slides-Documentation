---
title: テーブルの管理
type: docs
weight: 10
url: /ja/net/manage-table/
keywords: "テーブル、テーブルを作成、テーブルにアクセス、テーブルのアスペクト比、PowerPointプレゼンテーション、C#、Csharp、Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーション内のテーブルを作成および管理する"
---

PowerPointのテーブルは、情報を表示および表現する効率的な方法です。セルのグリッドに含まれる情報（行と列に整列）は、明確で理解しやすいです。

Aspose.Slidesは、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)インターフェース、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/)クラス、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)インターフェース、およびその他のタイプを提供しており、さまざまなプレゼンテーションでテーブルを作成、更新、および管理することができます。

## **最初からテーブルを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドのインデックスを介して、スライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトをスライドに[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)メソッドを通じて追加します。
6. 各[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)を繰り返し処理し、上、下、右、左の境界に書式設定を適用します。
7. テーブルの最初の行の最初の2つのセルを結合します。
8. [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)の[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にアクセスします。
9. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にテキストを追加します。
10. 修正されたプレゼンテーションを保存します。

このC#コードは、プレゼンテーション内にテーブルを作成する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// 幅を持つ列と高さを持つ行を定義
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// スライドにテーブル形状を追加
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// 各セルの境界の書式を設定
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// 行1のセル1とセル2を結合
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 結合されたセルにテキストを追加
tbl.Rows[0][0].TextFrame.Text = "結合されたセル";

// プレゼンテーションをディスクに保存
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けは直感的でゼロベースです。テーブルの最初のセルは0,0（列0、行0）としてインデックス付けされます。

例えば、4列4行のテーブルのセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

このC#コードは、テーブルのセルに対する番号付けを指定する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    // 幅を持つ列と高さを持つ行を定義
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブル形状を追加
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの境界の書式を設定
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

    // プレゼンテーションをディスクに保存
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。

2. インデックスを介して、テーブルを含むスライドへの参照を取得します。

3. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。

4. テーブルが見つかるまで、すべての[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)オブジェクトを繰り返し処理します。

   スライドに単一のテーブルが含まれていると疑う場合は、スライドに含まれるすべての形状を単純に確認できます。形状がテーブルとして特定された場合、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/)オブジェクトとして型キャストできます。しかし、スライドに複数のテーブルが含まれている場合は、[AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/)を通じて必要なテーブルを検索する方が良いでしょう。

5. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを使用してテーブルにアクセスします。以下の例では、テーブルに新しい行を追加しました。

6. 修正したプレゼンテーションを保存します。

このC#コードは、既存のテーブルにアクセスし、操作する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスのインスタンスを作成
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    // nullで初期化されたTableExを宣言
    ITable tbl = null;

    // 形状を繰り返し処理し、見つかったテーブルへの参照を設定
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 2行目の最初の列のテキストを設定
    tbl[0, 1].TextFrame.Text = "新しい";

    // 修正されたプレゼンテーションをディスクに保存
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **テーブル内のテキストを整列させる**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドのインデックスを介して、スライドの参照を取得します。
3. スライドに[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを追加します。
4. テーブルから[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)オブジェクトにアクセスします。
5. [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)の[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)にアクセスします。
6. テキストを垂直に整列させます。
7. 修正されたプレゼンテーションを保存します。

このC#コードは、テーブル内のテキストを整列させる方法を示しています：

```c#
// Presentationクラスのインスタンスを作成
Presentation presentation = new Presentation();

// 最初のスライドを取得
ISlide slide = presentation.Slides[0];

// 幅を持つ列と高さを持つ行を定義
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// スライドにテーブル形状を追加
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// テキストフレームにアクセス
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// テキストフレームのためのParagraphオブジェクトを作成
IParagraph paragraph = txtFrame.Paragraphs[0];

// 段落のためのPortionオブジェクトを作成
IPortion portion = paragraph.Portions[0];
portion.Text = "ここにテキスト";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// テキストを垂直に整列させる
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// プレゼンテーションをディスクに保存
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **テーブルレベルでのテキスト書式設定の設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. スライドのインデックスを介して、スライドの参照を取得します。
3. スライドから[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトにアクセスします。
4. テキストの[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)を設定します。
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)および[MARGIN RIGHT](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)を設定します。
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。

このC#コードは、テーブルのテキストに希望する書式設定オプションを適用する方法を示しています：

```c#
// Presentationクラスのインスタンスを作成
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初の形状がテーブルであると仮定します

// テーブルセルのフォント高さを設定
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// テーブルセルのテキストの配置と右マージンを一度の呼び出しで設定
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// テーブルセルのテキストの垂直タイプを設定
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **テーブルのスタイルプロパティを取得する**

Aspose.Slidesを使用すると、別のテーブルや別の場所で使用できるように、テーブルのスタイルプロパティを取得できます。このC#コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slidesは、テーブルや他の形状のアスペクト比設定をロックできる`AspectRatioLocked`プロパティを提供しています。

このC#コードは、テーブルのアスペクト比をロックする方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"アスペクト比ロック設定: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 反転

    Console.WriteLine($"アスペクト比ロック設定: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```