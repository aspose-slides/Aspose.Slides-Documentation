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
- テキストを配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint スライド内のテーブルを作成および編集します。テーブル操作を効率化するシンプルな C# コード例をご紹介します。"
---
## **はじめに**

PowerPoint のテーブルは、情報を表示および伝える効率的な方法です。行と列で構成されたセルのグリッドにある情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/net/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/ja/net/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/) インターフェイス、その他の型を提供し、さまざまなプレゼンテーションでテーブルの作成、更新、管理が可能です。

## **テーブルを一から作成する**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. スライドに対して [AddTable](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/addtable/) メソッドを使用して [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) オブジェクトを追加します。  
6. 各 [ICell](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/) を反復処理して、上・下・右・左の罫線の書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [ICell](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/) の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。  

この C# コードは、プレゼンテーション内にテーブルを作成する方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();

// 最初のスライドにアクセスします
ISlide sld = pres.Slides[0];

// 列の幅と行の高さを定義します
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// 結合されたセルにテキストを追加します
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// プレゼンテーションをディスクに保存します
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルで 0 から始まります。テーブルの最初のセルは 0,0（列 0、行 0）としてインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この C# コードは、上記の番号付けがされた標準の 4 × 4 テーブルを作成し、各セルの罫線書式を設定する方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // 列の幅と行の高さを定義します
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

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスでテーブルを含むスライドへの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) オブジェクトを作成し、null に設定します。  
4. テーブルが見つかるまですべての [IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) オブジェクトを反復処理します。

   スライドに単一のテーブルしか含まれていないと疑われる場合は、含まれるすべてのシェイプをチェックすれば十分です。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/ja/net/aspose.slides/table/) オブジェクトに型変換できます。ただし、スライドに複数のテーブルが含まれる場合は、[AlternativeText](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/alternativetext/) を使用して目的のテーブルを検索した方が適しています。  
5. [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) オブジェクトを使用してテーブルを操作します。下の例では、テーブルに新しい行を追加しました。  
6. 変更されたプレゼンテーションを保存します。  

この C# コードは、既存のテーブルにアクセスして操作する方法を示しています:

```c#
using Aspose.Slides;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // 最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    // null の TableEx を初期化します
    ITable tbl = null;

    // シェイプを反復処理し、見つかったテーブルへの参照を設定します
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 2 行目の最初の列のテキストを設定します
    tbl[0, 1].TextFrame.Text = "New";

    // 変更されたプレゼンテーションをディスクに保存します
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **テキストフレームを所有するセルを取得する**

テーブルから取得した [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) に対して汎用的なテキスト処理コードが実行される場合は、所有者である [ICell](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/) を取得するために [ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) プロパティを使用します。テーブルセルのテキストフレームでは、[ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) が設定され、[ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/) は `null` になります（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [ICell.FirstColumnIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/firstcolumnindex/) と [ICell.FirstRowIndex](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/firstrowindex/) プロパティで取得できます。[ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) も読み取り専用で、所有者へのナビゲーションを提供しますが、所有権は変更しません。使用前に必ず `null` かどうかを確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを配置する**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライドに [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) オブジェクトを追加します。  
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。  

この C# コードは、テーブル内のテキストを揃える方法を示しています:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// 最初のスライドを取得します 
ISlide slide = presentation.Slides[0];

// 列の幅と行の高さを定義します
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// スライドにテーブルシェイプを追加します
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// テキストフレームにアクセスします
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// テキストフレーム用の Paragraph オブジェクトを作成します
IParagraph paragraph = txtFrame.Paragraphs[0];

// Paragraph 用の Portion オブジェクトを作成します
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// テキストを垂直方向に揃えます
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// プレゼンテーションをディスクに保存します
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **テーブルレベルでテキスト書式設定を行う**

1. the [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) class のインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) オブジェクトにアクセスします。  
4. テキストの [FontHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/fontheight/) を設定します。  
5. [Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginright/) を設定します。  
6. [TextVerticalType](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/textverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。  

この C# コードは、テーブル内のテキストに好みの書式オプションを適用する方法を示しています:

```c#
using Aspose.Slides;

// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると想定します

// テーブルセルのフォント高さを設定します
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// テーブルセルのテキスト配置と右マージンを一括で設定します
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

## **テーブルスタイルプロパティの取得**

Aspose.Slides は、テーブルのスタイルプロパティを取得できるようにし、取得した詳細を別のテーブルや他の場所で使用できます。この C# コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更します

    // テーブルのスタイルプリセットを取得します。
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // 取得したスタイルプリセットを別のテーブルに適用します。
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は `AspectRatioLocked` プロパティを提供し、テーブルやその他のシェイプに対してアスペクト比のロック設定を行えるようにしています。

この C# コードは、テーブルのアスペクト比をロックする方法を示しています:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

**テーブル全体とセル内のテキストに右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [RightToLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/table/righttoleft/) プロパティを提供し、段落は [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphformat/righttoleft/) を持ちます。両方を使用することで、セル内で正しい RTL の順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするには？**

[shape locks](/slides/ja/net/applying-protection-to-presentation/) を使用して移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/ja/net/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。