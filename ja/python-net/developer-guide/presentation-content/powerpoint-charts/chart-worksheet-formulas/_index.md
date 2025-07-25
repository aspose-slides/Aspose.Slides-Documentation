---
title: Python でプレゼンテーションのチャート ワークシートに数式を適用する
linktitle: ワークシートの数式
type: docs
weight: 70
url: /ja/python-net/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート数式
- ワークシート数式
- スプレッドシート数式
- データソース
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術定数
- 比較演算子
- A1 形式
- R1C1 形式
- 定義済み関数
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のチャート ワークシートで Excel スタイルの数式を適用し、PPT、PPTX、ODP ファイル全体のレポートを自動化します。"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**チャートスプレッドシート**（またはチャートワークシート）は、チャートのデータソースです。チャートスプレッドシートには、チャート上にグラフィック方式で表現されるデータが含まれています。PowerPointでチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャートワークシートは、すべてのタイプのチャート（折れ線グラフ、棒グラフ、サンバーストチャート、円グラフなど）に対して作成されます。PowerPointでチャートスプレッドシートを見るには、チャートをダブルクリックする必要があります：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

チャートスプレッドシートには、チャート要素の名前（カテゴリー名：*Category1*、シリーズ名）と、これらのカテゴリーとシリーズに適した数値データのテーブルが含まれています。デフォルトでは、新しいチャートを作成すると、チャートスプレッドシートデータはデフォルトデータで設定されます。その後、ワークシート内のスプレッドシートデータを手動で変更することができます。

通常、チャートは複雑なデータを表現します（例：財務アナリスト、科学アナリスト）、他のセルの値や他の動的データから計算されるセルを持っています。セルの値を手動で計算し、それをセルにハードコーディングすると、将来的に変更が難しくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新する必要があります。さらに、テーブルデータは他のテーブルのデータに依存している可能性があり、簡単かつ柔軟な方法で更新する必要がある複雑なプレゼンテーションデータスキームを作成します。

プレゼンテーションにおける**チャートスプレッドシート数式**は、チャートスプレッドシートデータを自動的に計算して更新するための式です。スプレッドシート数式は、特定のセルまたはセルのセットに対するデータ計算ロジックを定義します。スプレッドシート数式は、数式や論理式であり、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用します。数式の定義はセルに書き込まれ、このセルは単純な値を含まない状態になります。スプレッドシート数式は値を計算し、それを返し、この値がセルに割り当てられます。プレゼンテーションのチャートスプレッドシート数式は、実際にはExcel数式と同じであり、その実装のためにサポートされているデフォルト関数、演算子、および定数も同じです。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/)では、チャートスプレッドシートが
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)プロパティで表現されます。
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/)型です。
スプレッドシート数式は
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)プロパティで設定および変更できます。
Aspose.Slidesの数式には、次の機能がサポートされています：

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1スタイルのセル参照
- R1C1スタイルのセル参照
- 事前定義された関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションを読み込んだ後、チャートデータが変更されていない場合は、**IChartDataCell.Value**プロパティは、その値を読み込むときに返します。しかし、スプレッドシートデータが変更された場合、**ChartDataCell.Value**プロパティを読み込むと、サポートされていない数式に対して**CellUnsupportedDataException**がスローされます。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正確性が決定されるためです。しかし、数式が解析できない場合、セル値の正確性は保証されません。

## **プレゼンテーションにチャートスプレッドシート数式を追加する**
まず、新しいプレゼンテーションの最初のスライドにサンプルデータを持つチャートを追加します。
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)を使って。
チャートのワークシートは自動的に作成され、次の
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)プロパティでアクセスできます：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

次に、**Object**型の
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)プロパティを使用してセルにいくつかの値を書き込みます。このプロパティには任意の値を設定できます：

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

今、セルに数式を書き込むには、
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)プロパティを使用できます：

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*注*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)プロパティは、A1スタイルのセル参照を設定するために使用されます。

[r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)セル参照を設定するには、[**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)プロパティを使用できます：

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

次に、[**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)メソッドを使用して、ワークブック内のすべての数式を計算し、対応するセルの値を更新します：

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **論理定数**
セルの数式で*FALSE*や*TRUE*のような論理定数を使用できます：

## **数値定数**
数値は、チャートスプレッドシート数式を作成するために、一般的または科学的表記法で使用できます：

## **文字列定数**
文字列（またはリテラル）定数は、特定の値であり、そのまま使用され、変更されません。文字列定数には、日付、テキスト、数値などがあります：

## **エラー定数**
時には、数式で結果を計算することが不可能な場合があります。その場合、セルの値の代わりにエラーコードが表示されます。各種のエラーには特定のコードがあります：

- #DIV/0! - 数式はゼロで割ろうとします。
- #GETTING_DATA - 値がまだ計算中である間、セルに表示される場合があります。
- #N/A - 情報が欠落または利用できない場合です。理由には、数式で使用されるセルが空であること、余分なスペース文字、スペルミスなどが考えられます。
- #NAME? - 特定のセルまたは他の数式オブジェクトがその名前で見つけられません。
- #NULL! - 数式に誤りがある場合、例えば:(,) またはコロン (:) の代わりにスペース文字が使用されることがあります。
- #NUM! - 数式内の数値が無効である、長すぎる、または小さすぎるなどがあります。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない値のタイプ。例えば、文字列の値が数値セルに設定されています。

## **算術演算子**
チャートワークシート数式で、すべての算術演算子を使用できます：

|**演算子** |**意味** |**例**|
| :- | :- | :- |
|+ (プラス記号) |加算または単項プラス|2 + 3|
|- (マイナス記号) |減算または否定 |2 - 3<br>-3|
|* (アスタリスク)|乗算 |2 * 3|
|/ (スラッシュ)|除算 |2 / 3|
|% (パーセント記号) |パーセント |30%|
|^ (キャレット) |累乗 |2 ^ 3|

*注*: 評価の順序を変更するには、最初に計算される部分を括弧で囲みます。

## **比較演算子**
比較演算子を使用して、セルの値を比較できます。これらの演算子を使用して二つの値を比較すると、結果は論理値のいずれかで、*TRUE*または*FALSE*です：

|**演算子** |**意味** |**意味** |
| :- | :- | :- |
|= (等号) |等しい |A2 = 3|
|<> (不等号) |等しくない|A2 <> 3|
|> (大なり) |より大きい|A2 > 3|
|>= (大なりまたは等しい)|より大きいまたは等しい|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりまたは等しい)|より小さいまたは等しい|A2 <= 3|

## **A1スタイルのセル参照**
**A1スタイルのセル参照**は、列に文字識別子（例： "*A*"）があり、行に数値識別子（例： "*1*"）があるワークシートに使用されます。A1スタイルのセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|範囲 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

数式でA1スタイルのセル参照を使用する例は以下の通りです：

## **R1C1スタイルのセル参照**
**R1C1スタイルのセル参照**は、どちらの行と列にも数値識別子があるワークシートに使用されます。R1C1スタイルのセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|範囲 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

数式でA1スタイルのセル参照を使用する例は以下の通りです：

## **事前定義された関数**
数式の実装を簡素化するために、使用できる事前定義された関数があります。これらの関数は、最も一般的に使用される操作をカプセル化しています：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900年日付システム)
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