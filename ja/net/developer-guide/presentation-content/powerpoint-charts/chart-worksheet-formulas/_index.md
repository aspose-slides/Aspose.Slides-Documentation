---
title: .NET のプレゼンテーションでチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/net/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- チャート データ ワークブック
- 数式 計算
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 演算子
- 比較 演算子
- A1 形式
- R1C1 形式
- 組み込み 関数
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides のチャート ワークシートで Excel 様式の数式を適用し、値を再計算して、PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートにソース データを格納します。Aspose.Slides for .NET では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。チャートを作成し、ワークシートにデータを配置し、A1 形式または R1C1 形式の数式を割り当て、再計算し、計算結果を読み取り、それらのセルをチャート シリーズに接続し、プレゼンテーションを保存します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュされた値、サポート外の数式、スプレッドシート固有のエラーについても説明します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは[チャート データ ワークブック](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/)を通じて公開されます。A1 形式の数式には[Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/formula/)プロパティを、R1C1 形式の数式には[R1C1Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/r1c1formula/)プロパティを使用します。入力セルまたは数式を変更したら、[CalculateFormulas](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してサポートされている数式を再計算し、対応するセルの値を更新します。

計算されたセルは[Value](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/value/) プロパティを通じて結果を公開します。コードで数式結果を確認したり、セルをチャート データ ポイントとして使用したりする場合に重要です。

## **チャートの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示しています。クラスター化縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャート 値として使用し、プレゼンテーションを保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

チャート データ ポイントは `D2:D4` を参照しているため、チャートは計算された利益値を使用します。このワークフローでは別個のチャート更新呼び出しは不要です。まずワークブックを再計算し、次に計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字、行を数字で識別します。[IChartDataCell.Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/formula/) を使って A1 形式の式を割り当てます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

一般的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は、数式がスプレッドシート アプリケーションで移動またはコピーされたときに変わります。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧内のオフセットで表します。この構文は[IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/r1c1formula/) を使って割り当てます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

一般的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえば、セル `D2` で `RC[-2]` は「同じ行の左に 2 列あるセル」（`B2`）を意味します。

## **数式の定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 補足 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 整数表記と科学技術表記の両方がサポートされています。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は、通常の結果ではなくスプレッドシート エラー値を返すことがあります。 |

この例では複数の定数タイプを使用しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // 偽
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセンテージ | `30%` |
| `^` | 累乗 | `2^3` |

評価順序を明示するには括弧を使用します。例: `(A2+B2)*C2`。

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | より大きい | `A2>3` |
| `>=` | 以上 | `A2>=3` |
| `<` | より小さい | `A2<3` |
| `<=` | 以下 | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数セットは以下に限定されます。[CalculateFormulas](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) で任意の Excel 関数が再計算できると想定しないでください。

| 関数 | 用途またはサポート形態 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 数値を指定した倍数に切上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムで日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 つの日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で別のテキストを検索 | `FIND("-",A2)` |
| `FINDB` | バイト指向テキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件付き結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされます。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能や関数は、Aspose.Slides の数式評価エンジンではサポートされていないと見なしてください。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式とその最終計算値の両方を保持します。Aspose.Slides は、プレゼンテーションがロードされたときに関連するチャート データが変更されていなければ、[IChartDataCell.Value](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/value/) からキャッシュされた値を読み取ることができます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取ったり、計算結果に依存するチャート データを保存したりする前に、[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してください。

サポート外のサブセットに含まれない数式の場合、Aspose.Slides は数式の解析や依存関係の確定に失敗することがあります。ワークブックが変更された場合、以前のキャッシュ値はもはや信頼できません。そのような状況でサポート外データを含むセルの値を読み取ろうとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされる可能性があります。

Excel 関数で Aspose.Slides が評価できないものがある場合は、対応するスプレッドシート エンジンでそれらの数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測した値で置き換えてはいけません。

## **数式エラーの取り扱い**

区別すべき問題は 2 種類あります。

* 数式自体は有効だが、`#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!` などのスプレッドシート エラー結果を返す場合。この場合、エラー トークンはセル結果として `Value` から取得できます。
* パース、参照、依存関係、またはサポートデータのレベルで数式が失敗する場合。Aspose.Slides はこれらのケースに対してスプレッドシート固有の例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算および値へのアクセス時にこれらの例外を捕捉してください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **実務上の制限事項**

チャート ワークシートの数式サポートは、完全な Excel 互換性を目指すものではなく、定義されたサブセットの計算に限定されています。レポート ワークフローを設計する際は次の点に留意してください。

* Aspose.Slides に再計算させる必要がある場合は、ドキュメント化された定数、演算子、参照形式、関数のみを使用してください。
* 計算結果が依存するセルを変更したら必ず再計算してください。
* 読み込んだプレゼンテーションからのキャッシュ値はスナップショットとして扱い、編集後に再計算しないまま使用しないでください。
* 既存テンプレートの数式は、ドキュメント化されたリスト外の関数を使用していないか事前にテストしてください。
* 完全なスプレッドシート計算エンジンが必要な数式は、外部で計算し、その結果をチャート ワークブックに書き戻してください。

## **FAQ**

**`Formula` と `R1C1Formula` の違いは何ですか？**

[Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/formula/) は `B2-C2` のような A1 形式の式を保持します。[R1C1Formula](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/r1c1formula/) は `RC[-2]-RC[-1]` のような R1C1 形式の式を保持します。数式の生成やコピー方法に最も適した表記を選んでください。

**計算後にセル自体を読むべきですか、値を読むべきですか？**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/getcell/) は `IChartDataCell` を返します。再計算後に計算結果を取得するには、そのセルの[Value](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdatacell/value/) プロパティを読み取ります。

**`CalculateFormulas` はいつ呼び出すべきですか？**

入力値または数式を変更した直後、計算結果に依存する前に [CalculateFormulas](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) を呼び出してください。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットの関数のみをサポートします。そのサブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 数式互換性が必要な場合は、適切なスプレッドシート エンジンで計算し、最終値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポート外の数式が含まれていたらどうなりますか？**

チャート データが変更されていなければ、ワークブックには以前に計算されたキャッシュ値が残っている可能性があります。関連データが変更された後は、そのキャッシュ値は無効になることがあります。処理できない数式を含むセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は .NET 例外と同じですか？**

いいえ。`#DIV/0!` などの結果は、有効な計算から生成されたスプレッドシート値です。一方、[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) などの例外は、数式が正常に処理できないことを示します。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。計算されたセルを参照している場合、チャートは更新されたセル値を使用します。このワークフローでは別途チャート更新メソッドは不要です。

**チャートは外部 Excel ワークブックを使用できますか？**

はい、チャート データ API を使用して外部ワークブックを参照するように構成できます。ただし、この記事で説明する数式計算ワークフローはチャート データ ワークブックに限定され、Aspose.Slides が評価する数式サブセットのみを対象とします。[CalculateFormulas](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) が外部 XLSX ファイル内の任意の数式を完全に再計算するとは限らないことに注意してください。

**別シートや別ブックを参照する数式は使用できますか？**

チャート ワークブック内で Excel 形式の参照は可能ですが、評価はサポートされているパーサと関数セットに限定されます。クロスシートまたは外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に動作するか検証してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決済みの値をチャート データに書き戻すことをお勧めします。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API 例では `B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てます。この形にすると、ドキュメント化された API 例と一貫性が保たれます。