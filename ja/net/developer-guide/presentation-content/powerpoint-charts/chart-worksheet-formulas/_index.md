---
title: チャート ワークシート数式
type: docs
weight: 70
url: /ja/net/chart-worksheet-formulas/
keywords: "チャート スプレッドシート, チャート 数式, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションにおける C# または .NET のチャート スプレッドシートと数式"
---

## **プレゼンテーションのチャート スプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。チャート スプレッドシートにはデータが含まれ、チャート上にグラフィカルに表現されます。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャート ワークシートは、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべての種類のチャートに対して作成されます。PowerPoint でチャート スプレッドシートを表示するには、チャートをダブルクリックします。

![todo:image_alt_text](chart-worksheet-formulas_1.png)



チャート スプレッドシートには、チャート要素の名前（カテゴリ名: *Category1*、系列名）と、これらのカテゴリと系列に対応する数値データの表が含まれます。既定では、新しいチャートを作成すると、チャート スプレッドシートのデータは既定のデータで設定されます。その後、ワークシート内のデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）を表し、他のセルの値や動的データから計算されたセルを含みます。セルの値を手動で計算しハードコーディングすると、将来変更しにくくなります。あるセルの値を変更すると、それに依存するすべてのセルも更新する必要があります。さらに、表データは他の表のデータに依存することがあり、簡単かつ柔軟に更新できるプレゼンテーション データ スキーマが必要になります。

**Chart spreadsheet formula** は、チャート スプレッドシート データを自動的に計算および更新する式です。スプレッドシート数式は、特定のセルまたはセル集合のデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数値関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに書き込まれ、セルは単純な値を保持しません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーション内のチャート スプレッドシート数式は実質的に Excel の数式と同じで、同じ既定関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/net/) では、チャート スプレッドシートは
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティの
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) 型で表されます。
スプレッドシート数式は
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティで割り当ておよび変更できます。
Aspose.Slides でサポートされている数式機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式セル参照
- R1C1 形式セル参照
- 事前定義関数



通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていない場合、**IChartDataCell.Value** プロパティはそれらの値を返します。しかし、スプレッドシート データが変更された場合、**ChartDataCell.Value** プロパティの読み取り時にサポートされていない数式に対して **CellUnsupportedDataException** がスローされます。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正当性が判断されるためです。数式が解析できない場合、セル値の正当性は保証できません。
## **プレゼンテーションへのチャート スプレッドシート数式の追加**
最初に、[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) を使用して新しいプレゼンテーションの最初のスライドにサンプル データを持つチャートを追加します。チャートのワークシートは自動的に作成され、次のプロパティでアクセスできます。
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティ:
```csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```




セルに値を書き込むには、**Object** 型の
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) プロパティを使用します。これにより、任意の値を設定できます:
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




数式を書き込むには、次のプロパティを使用します:
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティ:
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*注*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティは A1 形式のセル参照を設定するために使用されます。  


R1C1 形式のセル参照を設定するには、[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) プロパティを使用します:
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


その後、[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) メソッドを使用してワークブック内のすべての数式を計算し、対応するセル値を更新します:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **論理定数**
セル数式で *FALSE* と *TRUE* のような論理定数を使用できます：




## **数値定数**
数値は通常表記または科学表記で使用でき、チャート スプレッドシート数式を作成できます：




## **文字列定数**
文字列（リテラル）定数はそのまま使用され、変更されません。文字列定数は日付、テキスト、数値などがあります：




## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。各エラータイプには固有のコードがあります：

- #DIV/0! – 数式がゼロで除算しようとした場合。
- #GETTING_DATA – 値がまだ計算中のセルに表示される場合。
- #N/A – 情報が欠落または利用できない場合。理由は、数式で使用されるセルが空、余分なスペース文字、綴り間違いなど。
- #NAME? – 特定のセルまたは他の数式オブジェクトが名前で見つからない場合。
- #NULL! – 数式に誤りがある場合、例: (,) またはコロン (:) の代わりにスペース文字が使用されたとき。
- #NUM! – 数式内の数値が無効、長すぎる、または小さすぎるなど。
- #REF! – 無効なセル参照。
- #VALUE! – 予期しない値の型。例えば、文字列値が数値セルに設定された場合。




## **算術演算子**
チャート ワークシート数式ではすべての算術演算子を使用できます：

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス記号)|加算または単項プラス|2 + 3|
|- (マイナス記号)|減算または否定|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号)|パーセンテージ|30%|
|^ (キャレット)|べき乗|2 ^ 3|

*注*: 計算順序を変更するには、先に計算する部分を丸括弧で囲んでください。


## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較すると、結果は *TRUE* または FALSE の論理値になります：

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|= (イコール)|等しい|A2 = 3|
|<> (不等号)|等しくない|A2 <> 3|
|> (大なり)|より大きい|A2 > 3|
|>= (大なりイコール)|以上|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりイコール)|以下|A2 <= 3|

## **A1 形式セル参照**
**A1 形式セル参照**は、列が文字識別子（例: *A*）で行が数値識別子（例: *1*）であるワークシートで使用されます。A1 形式セル参照の使用方法は次の通りです：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下は A1 形式セル参照を数式で使用する例です：




## **R1C1 形式セル参照**
**R1C1 形式セル参照**は、行も列も数値識別子を持つワークシートで使用されます。R1C1 形式セル参照の使用方法は次の通りです：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下は R1C1 形式セル参照を数式で使用する例です：




## **事前定義関数**
数式で使用できる事前定義関数があり、実装を簡素化できます。これらの関数は最も一般的に使用される操作をカプセル化します。例:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 日付システム)
- DAYS
- FIND
- FINDB
- IF
- INDEX (参照形式)
- LOOKUP (ベクトル形式)
- MATCH (ベクトル形式)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**外部の Excel ファイルを数式付きチャートのデータ ソースとして使用できますか？**

はい。Aspose.Slides は外部ブックを [チャートのデータ ソース](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブックの他のシートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めてください。