---
title: 行と列の管理
type: docs
weight: 20
url: /ja/net/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションのテーブル行と列の管理"

---

PowerPointプレゼンテーションのテーブルの行と列を管理するために、Aspose.Slidesは[Table](https://reference.aspose.com/slides/net/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)インターフェース、およびその他多くのタイプを提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。
4. すべての[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)オブジェクトを反復して、関連するテーブルを見つけます。 
5. テーブルの最初の行をヘッダーとして設定します。

このC#コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています：

```c#
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("table.pptx");

// 最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// nullのTableExを初期化
ITable tbl = null;

// シェイプを反復してテーブルへの参照を設定
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// テーブルの最初の行をヘッダーとして設定
tbl.FirstRow = true;

// プレゼンテーションをディスクに保存
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを、[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)メソッドを介してスライドに追加します。
6. テーブル行をクローンします。
7. テーブル列をクローンします。
8. 修正されたプレゼンテーションを保存します。

このC#コードは、PowerPointテーブルの行または列をクローンする方法を示しています：

```c#
// Presentationクラスのインスタンスを作成
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 最初のスライドにアクセス
    ISlide sld = presentation.Slides[0];

    // 幅のある列と高さのある行を定義
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 行1のセル1にテキストを追加
    table[0, 0].TextFrame.Text = "行 1 セル 1";

    // 行1のセル2にテキストを追加
    table[1, 0].TextFrame.Text = "行 1 セル 2";

    // テーブルの最後に行1をクローン
    table.Rows.AddClone(table.Rows[0], false);

    // 行2のセル1にテキストを追加
    table[0, 1].TextFrame.Text = "行 2 セル 1";

    // 行2のセル2にテキストを追加
    table[1, 1].TextFrame.Text = "行 2 セル 2";

    // 行2をテーブルの4番目の行としてクローン
    table.Rows.InsertClone(3, table.Rows[1], false);

    // 最後に最初の列をクローン
    table.Columns.AddClone(table.Columns[0], false);

    // 2番目の列を4番目の列インデックスにクローン
    table.Columns.InsertClone(3, table.Columns[1], false);
    
    // プレゼンテーションをディスクに保存 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを、[AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)メソッドを介してスライドに追加します。
6. テーブル行を削除します。
7. テーブル列を削除します。
8. 修正されたプレゼンテーションを保存します。 

このC#コードは、テーブルから行または列を削除する方法を示しています：

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **テーブル行レベルでのテキストフォーマットの設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトにアクセスします。 
4. 最初の行のセルの[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)を設定します。 
5. 最初の行のセルの[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)および[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)を設定します。 
6. 2番目の行のセルの[TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。

このC#コードは操作を示しています。

```c#
// Presentationクラスのインスタンスを作成
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の行のセルのフォント高さを設定
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 最初の行のセルのテキストの整列と右マージンを設定
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 2番目の行のセルのテキストの垂直タイプを設定
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **テーブル列レベルでのテキストフォーマットの設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドへの参照を取得します。 
3. スライドから関連する[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトにアクセスします。 
4. 最初の列のセルの[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)を設定します。 
5. 最初の列のセルの[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)および[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)を設定します。 
6. 2番目の列のセルの[TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。 

このC#コードは操作を示しています：

```c#
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の列のセルのフォント高さを設定
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 最初の列のセルのテキストの整列と右マージンを一度の呼び出しで設定
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 2番目の列のセルのテキストの垂直タイプを設定
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得できるため、これらの詳細を別のテーブルや他の場所で使用することができます。このC#コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```