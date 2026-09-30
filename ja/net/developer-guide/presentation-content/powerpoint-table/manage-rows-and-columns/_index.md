---
title: .NET 用 Aspose.Slides で PowerPoint テーブルの行と列を管理する
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
## **はじめに**

Aspose.Slides for .NET を使用すると、PowerPoint プレゼンテーション内のテーブル構造と書式設定を [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) クラスおよび [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) インターフェイスを介して管理できます。ヘッダー行を指定したり、行や列をクローンまたは削除したり、行や列全体にテキスト書式設定を適用したりできます。

この記事では、C# のサンプルを使ってこれらの操作を説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行および列のインデックスは 0 から始まります。

## **行の高さの制御**

行の最小高さ（ポイント）を設定するには [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) を使用します。これは下限であり、固定高さではありません。[IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) は実際の高さを返し、読み取り専用です。行には [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) を介してアクセスします。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された [row-height-input.pptx](row-height-input.pptx) をロードします。最初の行は 70 ポイントから始まります。セルは 18 ポイントの Arial テキスト、折り返し、上下 6 ポイントの余白を使用しています。2 列目の長いテキストは複数行に折り返されます。この例では、最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後に実際の高さを出力し、両方の結果を保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

提供されたプレゼンテーションでは、最小値を増やすと行に余白が追加されます。減らすと余分なスペースが削除されますが、テキストとセル余白がより多くの領域を必要とするため、実際の高さは 20 ポイント以上のままです。最小値を減らすだけでは、コンテンツが必要とするスペース以下に行を強制することはできません。

実際の高さに影響を与える要因は次のとおりです：

- **テキストとフォントサイズ:** 長いテキスト、明示的な改行、または大きなフォントは、より多くの垂直スペースを必要とする場合があります。
- **折り返しと列幅:** 折り返しが有効な場合、狭い [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) は行数を増やす可能性があります。広い列は垂直方向の必要スペースを減らすことができます。
- **セル余白:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) と [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) は垂直スペースを追加します。[ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) と [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) はテキストに利用できる幅を減らし、追加の折り返しを引き起こす可能性があります。

結合セルのないこのテーブルでは、最も垂直スペースを必要とするセルが行全体のコンテンツ駆動の下限を決定します。行を短くするには、テキストを短くしたり、フォントサイズや余白を減らしたり、列幅を広げる必要がある場合があります。

以下の画像は同じスケールで同じテーブルを示しています。この実行では、実際の高さは 70、100、55.2 ポイントでした。最終行は 20 ポイントの最小値よりも高くなりました。正確なテキスト測定は、環境にインストールされているフォントにより変わる可能性があります。保存された結果をダウンロードしてください: [increased minimum](row-height-increased.pptx) および [decreased minimum](row-height-decreased.pptx)。

| 元: 最小 70 pt、実際 70 pt | 増加: 最小 100 pt、実際 100 pt | 減少: 最小 20 pt、実際 55.2 pt |
| --- | --- | --- |
| ![最初の行が 70 ポイントの元のテーブル。](row-height-before.png) | ![最初の行の最小値を 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小値を 20 ポイントに減らした後のテーブル。折り返しテキストにより行は最小値よりも高くなります。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定**

[FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) プロパティを使用して、最初の行をヘッダー書式設定としてマークします。その外観はテーブルに適用されたテーブルスタイルに依存します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. 最初のスライドにアクセスします。
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスします。
4. 最初の行のヘッダー書式設定を有効にします。
5. 変更されたプレゼンテーションを保存します。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要です。最初の行のヘッダー書式設定を有効にし、`First_row_header.pptx` として保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **テーブル行または列のクローン作成**

行や列をクローンして、そのコンテンツと書式設定を再利用できます。コピーをテーブルの末尾に追加したり、特定の位置に挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドでテーブルを追加します。
5. 必要な行をクローンします。
6. 必要な列をクローンします。
7. 変更されたプレゼンテーションを保存します。

この例では、少なくとも 1 枚のスライドがある `Test.pptx` が必要です。3 列 5 行のテーブルを作成し、サイズはポイントで指定します。最初の行と列のコピーを末尾に追加し、次に2 行目と2 列目のコピーをインデックス 3（4 番目の位置）に挿入します。結果として得られるテーブルは 7 行 5 列になります。`false` 引数は、隣接する結合行や列へのクローンを無効にします。このテーブルには結合セルがありません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **テーブルから行または列を削除**

テーブルで不要になった行や列を削除します。項目を削除すると、後続の行や列のインデックスがシフトします。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションを作成します。
2. 最初のスライドにアクセスします。
3. 列幅と行高さを定義します。
4. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) メソッドでテーブルを追加します。
5. 2 行目と 2 列目を削除します。
6. 変更されたプレゼンテーションを保存します。

この例では、3×3 のテーブルを作成し、インデックス 1 の行と列を削除して、`TestTable_out.pptx` に 2×2 のテーブルを残します。サイズはポイントです。`false` 引数は、隣接する結合行や列の削除を無効にします。このテーブルには結合セルがありません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **テーブル行レベルでテキスト書式設定を設定**

行全体にテキスト書式設定を適用して、セルの一貫性を保ちます。各セルを個別に書式設定することなく、フォントプロパティ、段落書式設定、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の行の [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。
4. 最初の行の [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。
5. 2 行目の [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。
6. 変更されたプレゼンテーションを保存します。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 行があります。最初の行に 25 ポイントのテキスト、右揃え、20 ポイントの右段落余白を適用し、2 行目に縦書きテキストを設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **テーブル列レベルでテキスト書式設定を設定**

列全体にテキスト書式設定を適用して、セルの一貫性を保ちます。各セルを個別に書式設定することなく、フォントプロパティ、段落書式設定、テキスト方向を設定できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスでプレゼンテーションをロードします。
2. 最初のスライド上のテーブルにアクセスします。
3. 最初の列の [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) を設定します。
4. 最初の列の [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) と [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) を設定します。
5. 2 列目の [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) を設定します。
6. 変更されたプレゼンテーションを保存します。

この例では、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` が必要で、少なくとも 2 列があります。最初の列に 25 ポイントのテキスト、右揃え、20 ポイントの右段落余白を適用し、2 列目に縦書きテキストを設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **テーブルスタイルプロパティの取得**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) プロパティを使用して、テーブルに適用されたプリセットを取得し、別のテーブルで再利用します。これにより、個々のセルの書式設定オーバーライドではなく、プリセットが識別されます。

この例ではテーブルを作成し、[TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) を適用して、プリセットを取得します。`DarkStyle1` を出力し、テーブルを `table.pptx` に保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスターテーマを継承しますが、これらのテーマ上で塗りつぶし、枠線、テキスト色を上書きすることは依然として可能です。

**Excel のようにテーブル行を並べ替えることはできますか？**

いいえ、Aspose.Slides のテーブルには組み込みの並べ替えやフィルタ機能はありません。まずメモリ上でデータを並べ替え、その順序でテーブル行を再度配置してください。

**特定のセルにカスタムカラーを保持しながら、バンド（ストライプ）列を設定できますか？**

はい。バンド付き列を有効にし、特定のセルにローカル書式設定で上書きすれば、セル単位の書式設定がテーブルスタイルよりも優先されます。