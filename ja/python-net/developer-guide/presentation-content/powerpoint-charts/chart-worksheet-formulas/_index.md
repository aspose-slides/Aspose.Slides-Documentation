---
title: Python を使用したプレゼンテーションでのチャート ワークシート数式の適用
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/python-net/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
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
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python の .NET チャート ワークシートを使用して Excel スタイルの数式を適用し、PPT、PPTX、ODP ファイル間でレポートを自動化します。"
---

## **プレゼンテーションにおけるチャート スプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet にはデータが格納されており、これらはグラフ上に視覚的に表現されます。PowerPoint でチャートを作成すると、そのチャートに関連付けられたワークシートが自動的に作成されます。チャート ワークシートは、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべてのチャート タイプに対して作成されます。PowerPoint でチャート スプレッドシートを表示するには、チャートをダブルクリックします。

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet には、チャート要素の名前（カテゴリ名: *Category1*、系列名）と、これらのカテゴリおよび系列に対応する数値データの表が含まれます。既定では、新しいチャートを作成すると、チャート スプレッドシートのデータはデフォルト データで設定されます。その後、ワークシート内のデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務分析、科学分析）を表し、セルは他のセルの値や動的データから計算されます。セルの値を手動で計算しハードコードすると、将来変更しにくくなります。あるセルの値を変更すると、そのセルに依存するすべてのセルも更新する必要があります。さらに、表データは他の表のデータに依存することがあり、プレゼンテーション データのスキーマが複雑になり、容易かつ柔軟に更新できる必要があります。

**Chart spreadsheet formula** は、チャート スプレッドシート データを自動的に計算・更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用した数学式または論理式です。数式の定義はセルに記述され、そのセルは単純な値を保持しません。数式が値を計算して返し、その値がセルに割り当てられます。プレゼンテーション内のチャート スプレッドシート数式は Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/python-net/) のチャート スプレッドシートは、[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) プロパティ（[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) 型）で表されます。スプレッドシート数式は、[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) プロパティで割り当ておよび変更できます。Aspose.Slides でサポートされている数式機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式セル参照
- R1C1 形式セル参照
- 事前定義関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていない場合、**IChartDataCell.Value** プロパティはその値を返します。しかし、スプレッドシート データが変更された場合、**ChartDataCell.Value** プロパティの読み取り時にサポートされていない数式に対して **CellUnsupportedDataException** がスローされます。これは、数式が正常に解析されたときにセル依存関係が確定し、最後の値の正確性が判定されるためです。数式が解析できない場合、セル値の正確性は保証できません。

## **プレゼンテーションにチャート スプレッドシート数式を追加する**
まず、[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) を使用して新しいプレゼンテーションの最初のスライドにサンプル データ付きのチャートを追加します。チャートのワークシートは自動的に作成され、[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) プロパティでアクセスできます:
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```


セルに値を書き込むには、**Object** 型の [**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) プロパティを使用します。これにより、任意の値を設定できます:
```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```


数式をセルに書き込むには、[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) プロパティを使用します:
```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```


*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) プロパティは A1 形式のセル参照を設定するために使用されます。

R1C1 形式のセル参照を設定するには、[**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) プロパティを使用します:
```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```


その後、[**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) メソッドを呼び出して、ワークブック内のすべての数式を計算し、対応するセル値を更新します:
```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **論理定数**
セル数式では *FALSE* および *TRUE* のような論理定数を使用できます。

## **数値定数**
数値は通常表記や科学的表記で使用でき、チャート スプレッドシート数式を作成できます。

## **文字列定数**
文字列（リテラル）定数は、そのまま使用され変更されない特定の値です。文字列定数には日付、テキスト、数値などが含まれます。

## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。各エラーには固有のコードがあります。

- #DIV/0! - 数式がゼロ除算を試みた場合。
- #GETTING_DATA - 値の計算中にセルに表示されることがあります。
- #N/A - 情報が不足または利用できない場合。例: 参照セルが空、余分なスペース文字、綴り間違いなど。
- #NAME? - 名前でセルや他の数式オブジェクトが見つからない場合。
- #NULL! - 数式に誤りがある場合に発生します（例: (,) やコロン (:) の代わりにスペース文字が使用された場合）。
- #NUM! - 数式内の数値が無効、桁数が多すぎる、または小さすぎる場合。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しないデータ型。例: 文字列が数値セルに設定された場合。

## **算術演算子**
チャート ワークシートの数式ではすべての算術演算子を使用できます。

|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|+ (plus sign)|加算または単項プラス|2 + 3|
|- (minus sign)|減算または単項マイナス|2 - 3<br>-3|
|* (asterisk)|乗算|2 * 3|
|/ (forward slash)|除算|2 / 3|
|% (percent sign)|パーセント|30%|
|^ (caret)|べき乗|2 ^ 3|

*Note*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較した結果は、論理値 *TRUE* または *FALSE* になります。

|**Operator**|**Description**|**Example**|
| :- | :- | :- |
|= (equal sign)|等しい|A2 = 3|
|<> (not equal sign)|等しくない|A2 <> 3|
|> (greater than sign)|大きい|A2 > 3|
|>= (greater than or equal to sign)|以上|A2 >= 3|
|< (less than sign)|小さい|A2 < 3|
|<= (less than or equal to sign)|以下|A2 <= 3|

## **A1 形式セル参照**
**A1 形式セル参照**は、列が文字識別子（例: *A*）で行が数字識別子（例: *1*）で表されるワークシートで使用されます。A1 形式セル参照は次のように使用できます。

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下は A1 形式セル参照を数式で使用する例です：

## **R1C1 形式セル参照**
**R1C1 形式セル参照**は、行と列の両方が数字識別子で表されるワークシートで使用されます。R1C1 形式セル参照は次のように使用できます。

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||Absolute|Relative|Mixed|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下は R1C1 形式セル参照を数式で使用する例です：

## **事前定義関数**
数式で使用できる事前定義関数があり、実装を簡素化できます。これらの関数は、以下のような一般的に使用される操作をカプセル化しています。

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

**外部 Excel ファイルを数式付きチャートのデータ ソースとして使用できますか？**

はい。Aspose.Slides は外部ブックを [chart's data source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は、同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブック内の他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。