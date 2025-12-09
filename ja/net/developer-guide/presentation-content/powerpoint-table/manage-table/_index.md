---
title: .NET でプレゼンテーションのテーブルを管理する
linktitle: テーブルの管理
type: docs
weight: 10
url: /ja/net/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストを整列
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライドのテーブルを作成および編集します。テーブルのワークフローを効率化するシンプルな C# コード例を紹介します。"
---

PowerPoint の表は、情報を効率的に表示・表現する方法です。行と列で構成されたセルのグリッドに情報を配置することで、分かりやすくシンプルに伝えることができます。

Aspose.Slides は、[テーブル](https://reference.aspose.com/slides/net/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) インターフェイス、その他の型を提供し、さまざまなプレゼンテーションで表の作成、更新、管理が可能です。

## **ゼロから表を作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドを使ってスライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。  
6. 各 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) を反復処理し、上・下・左・右の罫線に書式設定を適用します。  
7. 表の最初の行の最初の 2 つのセルを結合します。  
8. [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

この C# コードは、プレゼンテーションに表を作成する方法を示しています:
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


## **標準表の番号付け**

標準表では、セルの番号付けはゼロベースで単純です。表の最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行の表のセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この C# コードは、表のセル番号を指定する方法を示しています:
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


## **既存の表にアクセスする**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して表を含むスライドの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを作成し、null に設定します。  
4. すべての [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) オブジェクトを走査し、表が見つかるまで調べます。  

   スライドに単一の表しか含まれていないと推測できる場合は、含まれるすべてのシェイプをチェックすればよいです。シェイプが表として識別されたら、[Table](https://reference.aspose.com/slides/net/aspose.slides/table/) オブジェクトにキャストできます。複数の表がある場合は、[AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) を使用して目的の表を検索した方が便利です。  
5. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを使って表を操作します。以下の例では、表に新しい行を追加しています。  
6. 変更したプレゼンテーションを保存します。

この C# コードは、既存の表にアクセスして操作する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // null TableEx を初期化します
    ITable tbl = null;

    // シェイプを走査し、見つかったテーブルへの参照を設定します
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 第2行の第1列のテキストを設定します
    tbl[0, 1].TextFrame.Text = "New";

    // 変更されたプレゼンテーションをディスクに保存します
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **表内のテキスト配置**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。  
4. 表から [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に配置します。  
7. 変更したプレゼンテーションを保存します。

この C# コードは、表内のテキストを配置する方法を示しています:
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


## **表レベルでテキスト書式を設定する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトにアクセスします。  
4. テキストの [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。  
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。  
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。  
7. 変更したプレゼンテーションを保存します。

この C# コードは、表内テキストに好みの書式設定を適用する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると想定しています

// テーブルセルのフォント高さを設定します
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// テーブルセルのテキスト配置と右マージンを一度に設定します
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// テーブルセルのテキスト垂直方向を設定します
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **表のスタイルプロパティを取得する**

Aspose.Slides を使用すると、表のスタイルプロパティを取得でき、取得した情報を別の表や他の場所で再利用できます。この C# コードは、表のプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更します 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **表のアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は `AspectRatioLocked` プロパティを提供し、表やその他のシェイプのアスペクト比設定をロックできます。

この C# コードは、表のアスペクト比をロックする方法を示しています:
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

**テーブル全体とセル内のテキストに右から左 (RTL) の読み方向を設定できますか？**

はい。テーブルは [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) プロパティを公開しており、段落は [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) を使用します。両方を設定することで、セル内の正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするには？**

[シェイプレック](/slides/ja/net/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。