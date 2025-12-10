---
title: .NET でプレゼンテーション テーブルを管理
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/net/manage-table/
keywords:
- テーブルの追加
- テーブルの作成
- テーブルへのアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのテーブルを作成および編集します。テーブル作業を効率化するシンプルな C# コード例をご紹介します。"
---

PowerPoint のテーブルは、情報を表示・提示する効率的な方法です。行と列で構成されたセルのグリッド内の情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) インターフェイス、その他の型を提供し、さまざまなプレゼンテーションでテーブルを作成、更新、管理できるようにします。

## **スクラッチからテーブルを作成**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドを使ってスライドに [ITable] オブジェクトを追加します。  
6. 各 [ICell] を反復処理し、上・下・右・左の境界線に書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [ICell] の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。

この C# コードは、プレゼンテーションにテーブルを作成する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();

// 最初のスライドにアクセスします
ISlide sld = pres.Slides[0];

// 列幅と行高さを定義します
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// スライドにテーブルシェイプを追加します
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// 各セルの罫線書式を設定します
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
// 行 1 のセル 1 と 2 を結合します
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 結合されたセルにテキストを追加します
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// プレゼンテーションをディスクに保存します
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この C# コードは、テーブル内のセルの番号付けを指定する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // 列幅と行高さを定義します
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // スライドにテーブルシェイプを追加します
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 各セルの罫線書式を設定します
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

    // プレゼンテーションをディスクに保存します
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```


## **既存のテーブルにアクセス**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してテーブルを含むスライドの参照を取得します。  
3. [ITable] オブジェクトを作成し、null に設定します。  
4. テーブルが見つかるまで、すべての [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) オブジェクトを反復処理します。  

   スライドに単一のテーブルしか含まれていないと疑う場合は、含まれるすべてのシェイプをチェックすればよいです。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/) オブジェクトとして型変換できます。ただし、スライドに複数のテーブルが含まれる場合は、[AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) を使用して目的のテーブルを検索する方が良いでしょう。  

5. [ITable] オブジェクトを使用してテーブルを操作します。以下の例ではテーブルに新しい行を追加しています。  
6. 変更されたプレゼンテーションを保存します。

この C# コードは、既存のテーブルにアクセスして操作する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // null の TableEx を初期化します
    ITable tbl = null;

    // 形状を走査し、見つかったテーブルへの参照を設定します
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 2 行目の最初の列のテキストを設定します
    tbl[0, 1].TextFrame.Text = "New";

    // 変更したプレゼンテーションをディスクに保存します
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **テーブル内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [ITable] オブジェクトを追加します。  
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。

この C# コードは、テーブル内のテキストを揃える方法を示しています:
```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトにアクセスします。  
4. テキストの [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。  
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。  
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この C# コードは、テーブル内のテキストに好みの書式設定オプションを適用する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると想定します

// テーブルセルのフォント高さを設定します
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// テーブルセルのテキスト配置と右余白を一度に設定します
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// テーブルセルのテキスト垂直方向タイプを設定します
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **テーブルのスタイルプロパティを取得**

Aspose.Slides は、テーブルのスタイルプロパティを取得できるようにし、取得した詳細を別のテーブルや他の場所で使用できます。この C# コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更します
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **テーブルのアスペクト比をロック**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、テーブルやその他の形状のアスペクト比設定をロックできるように `AspectRatioLocked` プロパティを提供しています。

この C# コードは、テーブルのアスペクト比をロックする方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 反転

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**テーブル全体とセル内のテキストに右から左 (RTL) 読み方向を有効にできますか？**

はい。テーブルは [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) プロパティを公開しており、段落には [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) があります。両方を使用することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでテーブルの移動やサイズ変更をユーザーに防止するには？**

[shape locks](/slides/ja/net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。