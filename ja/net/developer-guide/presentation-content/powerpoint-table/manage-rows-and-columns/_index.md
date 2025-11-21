---
title: .NET の PowerPoint テーブルで行と列を管理
linktitle: 行と列
type: docs
weight: 20
url: /ja/net/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行のクローン
- 列のクローン
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行テキスト書式設定
- 列テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---

PowerPointプレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slidesは[Table](https://reference.aspose.com/slides/net/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)インターフェイス、その他多数の型を提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。  
4. すべての[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)オブジェクトを走査して、対象のテーブルを見つけます。  
5. テーブルの最初の行をヘッダーとして設定します。  

このC#コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("table.pptx");

// 最初のスライドにアクセス
ISlide sld = pres.Slides[0];

// null の TableEx を初期化
ITable tbl = null;

// 形状を反復処理し、テーブルへの参照を設定
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


## **テーブルの行または列をコピー**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)メソッドを使用して、スライドに[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを追加します。  
6. テーブルの行をコピーします。  
7. テーブルの列をコピーします。  
8. 変更されたプレゼンテーションを保存します。  

このC#コードは、PowerPointテーブルの行または列をコピーする方法を示しています:
```c#
 // Presentation クラスのインスタンスを作成
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 最初のスライドにアクセス
    ISlide sld = presentation.Slides[0];

    // 幅付き列と高さ付き行を定義
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // スライドにテーブルシェイプを追加
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 行 1 のセル 1 にテキストを追加
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 行 1 のセル 2 にテキストを追加
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // テーブルの末尾に行 1 をクローン
    table.Rows.AddClone(table.Rows[0], false);

    // 行 2 のセル 1 にテキストを追加
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 行 2 のセル 2 にテキストを追加
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // 行 2 をテーブルの 4 行目としてクローン
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 末尾に最初の列をクローン
    table.Columns.AddClone(table.Columns[0], false);

    // 4 列目の位置に 2 番目の列をクローン
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // プレゼンテーションをディスクに保存 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)メソッドを使用して、スライドに[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトを追加します。  
6. テーブルの行を削除します。  
7. テーブルの列を削除します。  
8. 変更されたプレゼンテーションを保存します。  

このC#コードは、テーブルから行または列を削除する方法を示しています:
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

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトにアクセスします。  
4. 最初の行のセルの[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)を設定します。  
5. 最初の行のセルの[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)と[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)を設定します。  
6. 2 行目のセルの[TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)を設定します。  
7. 変更されたプレゼンテーションを保存します。  

このC#コードは操作を示しています。
```c#
// Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると想定します

// 最初の行のセルのフォント高さを設定
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 最初の行のセルの文字揃えと右余白を設定
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 2 行目のセルのテキスト縦方向タイプを設定
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **テーブル列レベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、プレゼンテーションを読み込みます。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから対象の[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)オブジェクトにアクセスします。  
4. 最初の列のセルの[FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)を設定します。  
5. 最初の列のセルの[Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)と[MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)を設定します。  
6. 2 列目のセルの[TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)を設定します。  
7. 変更されたプレゼンテーションを保存します。  

このC#コードは操作を示しています:
```c#
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 最初のスライドの最初のシェイプがテーブルであると想定します

// 最初の列のセルのフォント高さを設定
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 最初の列のセルのテキスト揃えと右余白を一度に設定
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 2 列目のセルのテキスト縦方向タイプを設定
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```


## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得でき、取得した詳細を別のテーブルや他の場所で利用できます。このC#コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています:
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // デフォルトのスタイルプリセットテーマを変更 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**既に作成されたテーブルにPowerPointのテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承しますが、その上で塗りつぶし、枠線、文字色を上書きすることができます。

**Excelのようにテーブルの行をソートできますか？**

できません。Aspose.Slidesのテーブルには組み込みのソートやフィルタ機能はありません。データをメモリ上で先にソートし、その順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持しながら、バンド（ストライプ）列を設定できますか？**

はい。バンド列を有効にした後、個別のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルより優先されます。