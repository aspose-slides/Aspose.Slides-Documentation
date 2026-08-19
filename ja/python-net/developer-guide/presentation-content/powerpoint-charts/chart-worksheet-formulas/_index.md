---
title: Python を使用したプレゼンテーションでチャート ワークシート数式を適用する
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
- チャート データ ワークブック
- 数式 計算
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 演算子
- 比較 演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義 関数
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のチャート ワークシートで Excel 形式の数式を適用し、値を再計算し、PowerPoint のグラフで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートにソースデータを保存します。Aspose.Slides for Python via .NET では、チャート データ ワークブックを通じてそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをグラフ データとして使用できます。

この記事では、完全な数式ワークフローを説明します。グラフの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式の割り当て、再計算、計算結果の取得、セルをグラフ系列に接続し、プレゼンテーションを保存する手順を示します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュされた値、サポート外の数式、およびスプレッドシート固有のエラーについても説明します。

## **グラフ ワークシートと数式**

グラフ ワークシートには、グラフで使用されるカテゴリ、系列名、および値が含まれます。PowerPoint では、グラフ データ エディターを開くことでワークシートを確認できます。

![埋め込みワークシートが開いた PowerPoint グラフ、カテゴリと系列データを表示](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [chart data workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdataworkbook/) を通じて公開されています。A1 形式の数式には [formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/formula/) プロパティを、R1C1 形式の数式には [r1c1_formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) プロパティを使用します。入力セルや数式を変更した後は、[calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出してサポートされている数式を再計算し、対応するセルの値を更新します。

計算されたセルは依然として [value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/value/) プロパティを通じて結果を公開します。コードで数式の結果を確認したり、セルをグラフ データ ポイントとして使用したりする場合に重要です。

## **グラフの作成とワークシート数式の計算**

以下の例は、エンドツーエンドのワークフローを示しています。クラスター化された縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算済みセルをグラフの値として使用し、プレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

グラフのデータ ポイントは `D2:D4` を参照しているため、計算された利益の値が使用されます。このワークフローでは別途チャートのリフレッシュ呼び出しは不要です。まずワークブックを再計算し、その後計算済みセルを指すチャート データを使用または保存します。

## **A1 形式数式の使用**

A1 表記は列を文字で、行を数字で識別します。[IChartDataCell.formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/formula/) を使用して A1 形式の式を割り当てます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

一般的な A1 参照形式は次のとおりです：

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は、スプレッドシート アプリケーションで数式を移動またはコピーしたときに変更される可能性があります。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式数式の使用**

R1C1 表記は行と列の両方を数値で識別します。相対参照は角括弧内のオフセットを使用します。この構文は [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) を通じて割り当てます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

一般的な R1C1 参照形式は次のとおりです：

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例として、セル `D2` で `RC[-2]` は、同じ行の左に 2 列あるセル（`B2`）を指します。

## **数式の定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、および比較演算子をサポートしています。

### **定数とリテラル**

| タイプ | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 一般的な表記と指数表記の両方がサポートされます。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは数式内で二重引用符で囲まれます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は、通常の結果ではなくスプレッドシート エラー値に評価されることがあります。 |

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # 偽
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # 除算エラー
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセント | `30%` |
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
| `<` | 未満 | `A2<3` |
| `<=` | 以下 | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides には、グラフ ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数セットは以下の関数に限定されています。[calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) で任意の Excel 関数が再計算できると想定しないでください。

| 関数 | 目的またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 数値を上方向に指定の倍数に丸める | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト値を結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト値を結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムを使用して日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | あるテキスト内で別のテキストを検索 | `FIND("-",A2)` |
| `FINDB` | バイト指向のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 列方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で記載されており、`LOOKUP` と `MATCH` はベクトル形式で記載されています。`DATE` は 1900 日付システムを使用します。この表に記載されていない機能や関数は、別途文書化されていない限り、Aspose.Slides の数式評価エンジンではサポートされていないものと見なしてください。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式とその最後に計算された値の両方を保存します。そのため、プレゼンテーションが読み込まれ、該当するグラフデータが変更されていない場合、Aspose.Slides は [IChartDataCell.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/value/) からキャッシュされた値を読み取ることができます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取るか、それらに依存するグラフデータを保存する前に、[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出します。

サポート対象外の数式については、Aspose.Slides が数式を解析できない、または依存関係を確立できない場合があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できなくなります。そのような状況で、サポートされていないデータを持つセルの値を読み取ると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされる可能性があります。

グラフが Aspose.Slides が評価できない Excel 関数に依存している場合は、サポートされたスプレッドシート エンジンでそれらの数式を計算し、結果の値をグラフ ワークブックに書き戻してください。サポートされていない数式を推測値で置き換えないでください。

## **数式エラーの取り扱い**

区別すべき問題は大きく2種類あります。

数式は有効でも、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` などのスプレッドシート エラー結果を返すことがあります。この場合、エラー トークンはセルの結果として扱われ、`value` を通じて取得できます。

数式は、構文解析、参照、依存関係、またはサポートデータのレベルで失敗することもあります。このようなケースに対して、Aspose.Slides はスプレッドシート固有の例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

テンプレートやユーザー入力からの数式を使用する場合は、再計算および値取得の周囲でこれらの例外を処理してください：

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **実務上の制限**

グラフ ワークシートにおける数式サポートは、定義されたサブセットのスプレッドシート計算を対象としており、完全な Excel 互換性を提供するものではありません。レポーティング ワークフローを設計する際は、以下の制約を考慮してください：

- Aspose.Slides に数式の再計算を依頼する場合は、ドキュメント化された定数、演算子、参照、および関数のみを使用してください。
- 数式結果が依存するセルを変更した後は、必ず再計算してください。
- ロードされたプレゼンテーションからのキャッシュ値はスナップショットとして扱い、編集後の再計算の代替としないでください。
- 特にドキュメント化されたリスト外の関数を使用している場合は、既存テンプレートの数式を計算値として使用する前にテストしてください。
- 完全なスプレッドシート計算エンジンが必要な数式は、外部で計算し、結果の値でグラフ ワークブックを更新してください。

## **FAQ**

**`formula` と `r1c1_formula` の違いは何ですか？**  
[formula] は `B2-C2` のような A1 形式の式を保持します。[r1c1_formula] は `RC[-2]-RC[-1]` のような R1C1 形式の式を保持します。数式の生成やコピー方法に最も適した表記を使用してください。

**計算後にセル自体を読み取るべきですか、それとも値を読み取るべきですか？**  
[ChartDataWorkbook.get_cell] は `IChartDataCell` を返します。計算結果を取得するには、再計算後にそのセルの [value] プロパティを読み取ります。

**`calculate_formulas` はいつ呼び出すべきですか？**  
入力値や数式を変更した後、計算結果に依存する前に [calculate_formulas] を呼び出します。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**  
いいえ。組み込み評価エンジンはドキュメント化された関数のサブセットのみをサポートします。そのサブセット外の関数が正しく再計算できると想定しないでください。完全な Excel 数式互換性が必要な場合は、適切なスプレッドシート エンジンで計算し、最終的な値をグラフ ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポートされていない数式が含まれている場合はどうなりますか？**  
グラフ データが変更されていない場合、ワークブックには以前に計算されたキャッシュ値が残っている可能性があります。関連データが変更された後は、そのキャッシュ値はもはや有効でない場合があります。処理できない数式を持つセルにアクセスすると、[CellUnsupportedDataException] がスローされることがあります。

**数式エラーの値は Python の例外と同じですか？**  
いいえ。`#DIV/0!` のような結果は、有効な計算によって生成されたスプレッドシートの値です。[CellInvalidFormulaException] や [CellCircularReferenceException] などの例外は、数式が通常通り処理できないことを示します。

**数式セルが変更されたときにグラフは自動的に更新されますか？**  
グラフ系列はワークブックのセルを参照できます。まずワークブックを再計算し、その後プレゼンテーションを保存またはレンダリングします。グラフのデータ ポイントが計算されたセルを参照していれば、グラフは更新されたセルの値を使用します。このワークフローでは別途チャートのリフレッシュ メソッドは必要ありません。

**グラフは外部の Excel ワークブックを使用できますか？**  
はい、チャート データはチャート データ API を使用して外部ワークブックを利用するように設定できます。ただし、本記事で説明した数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価する数式サブセットに限られます。[calculate_formulas] が外部 XLSX ファイル内の任意の数式を完全に再計算できると想定しないでください。

**別のワークシートやワークブックを参照する数式を使用できますか？**  
チャート ワークブックに Excel 形式の参照が含まれることはありますが、数式の評価はサポートされているパーサーと関数セットに制限されます。シート間や外部参照が必須の場合は、対象の Aspose.Slides バージョンでその数式を検証してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決された値をチャート データに書き戻してください。

**数式文字列は `=` で始めるべきですか？**  
Aspose.Slides の API 例では、`B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てています。その形式を使用すると、生成される数式がドキュメント化された API 例と一致します。