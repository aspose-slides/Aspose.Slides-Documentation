---
title: .NET のプレゼンテーションでチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/net/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート数式
- ワークシート数式
- スプレッドシート数式
- データ ソース
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術定数
- 比較演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義関数
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のチャート ワークシートで Excel 形式の数式を適用し、PPT および PPTX ファイル全体でレポートを自動化します。"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet には、チャート上にグラフィカルに表現されるデータが含まれます。PowerPoint でチャートを作成すると、対応するワークシートも自動的に作成されます。チャート ワークシートは、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべてのチャート タイプに対して作成されます。PowerPoint でチャート スプレッドシートを表示するには、チャートをダブルクリックしてください。

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet には、チャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリとシリーズに対応する数値データの表が含まれます。既定では、新しいチャートを作成すると、チャート スプレッドシート データは既定データで設定されます。その後、ワークシート内のデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）を表し、他のセルの値や動的データから計算されるセルを含みます。セルの値を手動で計算してハードコーディングすると、将来的に変更しにくくなります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新が必要になります。さらに、表データが他の表のデータに依存することがあり、更新が容易で柔軟なプレゼンテーション データ スキーマが必要になります。

プレゼンテーション内の **Chart spreadsheet formula** は、チャート スプレッドシート データを自動的に計算および更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに記述され、そのセルは単純な値を持ちません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーション内のチャート スプレッドシート数式は実際には Excel の数式と同じで、同じ既定関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/net/) では、チャート スプレッドシートは
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティで
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) 型として表されます。  
スプレッドシート数式は
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティで割り当ておよび変更できます。  
Aspose.Slides がサポートする数式機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数



通常、スプレッドシートは最後に計算された数式の値を保持します。プレゼンテーションの読み込み後にチャート データが変更されていない場合、**IChartDataCell.Value** プロパティはそれらの値を返します。但し、スプレッドシート データが変更された場合、**ChartDataCell.Value** プロパティの読み取り時にサポートされていない数式に対して **CellUnsupportedDataException** がスローされます。これは、数式が正常に解析されるとセルの依存関係が確定し、最後の値の正確性が判断できるためです。数式が解析できない場合、セル値の正確性は保証できません。
## **プレゼンテーションにチャート スプレッドシート数式を追加する**
まず、[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) を使用して新しいプレゼンテーションの最初のスライドにサンプル データ付きのチャートを追加します。  
チャートのワークシートは自動的に作成され、次のプロパティでアクセスできます:
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティ:
``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```




次に、**Object** 型の
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) プロパティを使用してセルに値を書き込みます。これにより任意の値を設定できます:
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




セルに数式を書き込むには、次のプロパティを使用します:
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティ:
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティは A1 形式のセル参照を設定するために使用されます。  



R1C1 形式のセル参照を設定するには、[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) プロパティを使用します:
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


その後、[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) メソッドを使用してワークブック内のすべての数式を計算し、対応するセルの値を更新します:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **論理定数**
セル数式で *FALSE* と *TRUE* のような論理定数を使用できます:




## **数値定数**
数式では、通常表記または指数表記の数値を使用してチャート スプレッドシート数式を作成できます:




## **文字列定数**
文字列（リテラル）定数は、そのまま使用され変更されない特定の値です。文字列定数には、日付、テキスト、数値などが含まれます:




## **エラー定数**
数式で結果を計算できない場合があります。その場合、セルには値の代わりにエラーコードが表示されます。各エラーのコードは次のとおりです:

- #DIV/0! – 数式がゼロで除算しようとしました。
- #GETTING_DATA – セルの値がまだ計算中であることを示す場合があります。
- #N/A – 情報が欠落している、または利用できません。原因例: 数式で使用されたセルが空、余分なスペース文字、スペルミスなど。
- #NAME? – 特定のセルまたは数式オブジェクトが名前で見つかりません。
- #NULL! – 数式に誤りがある場合に発生します（例: (,) やコロン (:) の代わりにスペース文字が使用された場合）。
- #NUM! – 数式内の数値が無効、長すぎる、または小さすぎるなど。
- #REF! – 無効なセル参照。
- #VALUE! – 予期しない値の型。例: 文字列値が数値セルに設定された場合。




## **算術演算子**
チャート ワークシート数式ではすべての算術演算子を使用できます:



|**Operator** |**Meaning** |**Example**|
| :- | :- | :- |
|+ (plus sign) |加算または単項プラス|2 + 3|
|- (minus sign) |減算または単項マイナス|2 - 3<br>-3|
|* (asterisk)|乗算|2 * 3|
|/ (forward slash)|除算|2 / 3|
|% (percent sign) |パーセンテージ|30%|
|^ (caret) |べき乗|2 ^ 3|


*Note*: 計算順序を変更するには、先に計算したい部分を括弧で囲んでください。


## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較された結果は、*TRUE* または FALSE の論理値になります:



|**Operator** |**Meaning** |**Meaning** |
| :- | :- | :- |
|= (equal sign) |等しい|A2 = 3|
|<> (not equal sign) |等しくない|A2 <> 3|
|> (greater than sign) |大きい|A2 > 3|
|>= (greater than or equal to sign)|以上|A2 >= 3|
|< (less than sign)|小さい|A2 < 3|
|<= (less than or equal to sign)|以下|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照**は、列が文字（例: "*A*」）で行が数値（例: "*1*」）で示されるワークシートで使用されます。A1 形式のセル参照は次のように使用できます:



|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixed|
|Cell |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Row |$2:$2 |2:2 |-|
|Column |$A:$A |A:A |-|
|Range |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


A1 形式のセル参照を数式で使用する例:




## **R1C1 形式のセル参照**
**R1C1 形式のセル参照**は、行と列の両方が数値で示されるワークシートで使用されます。R1C1 形式のセル参照は次のように使用できます:



|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixed|
|Cell |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row |R2|R[2]|-|
|Column |C3|C[3]|-|
|Range |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


R1C1 形式のセル参照を数式で使用する例:




## **事前定義関数**
数式で使用できる事前定義関数があります。これらの関数は、次のような最も一般的に使用される操作をカプセル化します:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**外部 Excel ファイルは、数式付きチャートのデータ ソースとしてサポートされていますか？**

はい。Aspose.Slides は、[chart's data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/) として外部ブックをサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は、同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブックの他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めてください。