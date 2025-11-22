---
title: 行と列の管理
type: docs
weight: 20
url: /ja/net/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションのテーブルの行と列を管理します"
---

PowerPoint プレゼンテーション内でテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイス、その他多数の型を提供しています。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションをロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを作成し、null に設定します。  
4. すべての [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) オブジェクトを列挙して、対象のテーブルを見つけます。  
5. テーブルの最初の行をヘッダーとして設定します。  

この C# コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:
```c#
 // Presentation クラスのインスタンスを作成します
 Presentation pres = new Presentation("table.pptx");

 // 最初のスライドにアクセスします
 ISlide sld = pres.Slides[0];

 // null の TableEx を初期化します
 ITable tbl = null;

 // シェイプを反復処理し、テーブルへの参照を設定します
 foreach (IShape shp in sld.Shapes)
 {
     if (shp is ITable)
     {
         tbl = (ITable)shp;
     }
 }

 // テーブルの最初の行をヘッダーとして設定します
 tbl.FirstRow = true;

 // プレゼンテーションをディスクに保存します
 pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。  
6. テーブルの行をクローンします。  
7. テーブルの列をクローンします。  
8. 変更したプレゼンテーションを保存します。  

この C# コードは、PowerPoint テーブルの行または列をクローンする方法を示しています:
```c#
 // Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 最初のスライドにアクセスします
    ISlide sld = presentation.Slides[0];

    // 列幅と行高さを定義します
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加します
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 行 1 のセル 1 にテキストを追加します
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 行 1 のセル 2 にテキストを追加します
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // テーブルの末尾に行 1 をクローンします
    table.Rows.AddClone(table.Rows[0], false);

    // 行 2 のセル 1 にテキストを追加します
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 行 2 のセル 2 にテキストを追加します
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // テーブルの 4 行目として行 2 をクローンします
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 末尾に最初の列をクローンします
    table.Columns.AddClone(table.Columns[0], false);

    // 4 列目の位置に 2 番目の列をクローンします
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // プレゼンテーションをディスクに保存します 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを追加します。  
6. テーブルの行を削除します。  
7. テーブルの列を削除します。  
8. 変更したプレゼンテーションを保存します。  

この C# コードは、テーブルから行または列を削除する方法を示しています:
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


## **テーブル行レベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトにアクセスします。  
4. 最初の行のセルの [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。  
5. 最初の行のセルの [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。  
6. 2 行目のセルの [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。  
7. 変更したプレゼンテーションを保存します。  

この C# コードは操作を示しています。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の行のセルのフォント高さを設定します
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 最初の行のセルのテキスト配置と右マージンを設定します
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 2 行目のセルのテキストの垂直方向タイプを設定します
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存します
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **テーブル列レベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、プレゼンテーションをロードします、  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトにアクセスします。  
4. 最初の列のセルの [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。  
5. 最初の列のセルの [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。  
6. 2 列目のセルの [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。  
7. 変更したプレゼンテーションを保存します。  

この C# コードは操作を示しています:
```c#
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の列のセルのフォント高さを設定します
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 最初の列のセルのテキスト配置と右マージンを一度に設定します
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 2 列目のセルのテキストの垂直方向タイプを設定します
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存します
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **テーブルのスタイルプロパティを取得**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、取得した詳細を別のテーブルや他の場所で使用できます。この C# コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更します
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承しますが、テーマの上に塗りつぶし、枠線、テキストの色を上書きすることも可能です。

**Excel のようにテーブルの行を並び替えられますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルタはありません。まずメモリ上でデータを並び替え、その順序でテーブルの行を再配置してください。

**特定のセルにカスタムカラーを保持しつつ、バンド（ストライプ）列を持つことはできますか？**

はい。バンド列を有効にした上で、特定のセルにローカルの書式設定で上書きすれば、セルレベルの書式設定がテーブルスタイルより優先されます。