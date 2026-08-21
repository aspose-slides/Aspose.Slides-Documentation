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
- チャート データ ワークブック
- 数式 計算
- 優先カルチャ
- カルチャ固有の数式
- DBCS
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 スタイル
- R1C1 スタイル
- 組み込み関数
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートにソース データを格納します。Aspose.Slides for Python via .NET では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをチャート データとして使用できます。

この記事では、チャートの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式の割り当て、再計算、計算結果の取得、セルをチャート シリーズに接続、プレゼンテーションの保存という完全な数式ワークフローを解説します。また、サポートされる数式構文、組み込み関数サブセット、キャッシュ値、非サポート数式、スプレッドシート固有のエラーについても説明します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、シリーズ名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートが開かれ、カテゴリとシリーズ データが表示されているチャート](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [チャート データ ワークブック](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdataworkbook/) を通じて公開されています。A1 形式の数式には [formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/formula/) プロパティを、R1C1 形式の数式には [r1c1_formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) プロパティを使用します。入力セルや数式を変更した後は、[calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算されたセルは [value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/value/) プロパティを介して結果を公開します。コード内で数式結果を確認したり、セルをチャート データ ポイントとして使用したりする場合に重要です。

## **チャートの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示しています。クラスター化された縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャート値として使用し、プレゼンテーションを保存します。

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

チャート データ ポイントは `D2:D4` を参照しているため、計算された利益値が使用されます。このワークフローでは別途チャート更新呼び出しは不要です。まずワークブックを再計算し、その後計算されたセルを参照または保存します。

## **A1 形式の数式の使用**

A1 表記は列を文字、行を数字で識別します。A1 形式の式は [IChartDataCell.formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/formula/) で割り当てます。

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

一般的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式を移動またはコピーしたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式の使用**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧でオフセットを示します。この構文は [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) で割り当てます。

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

一般的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえばセル `D2` で `RC[-2]` は「同じ行で左に 2 列」のセル (`B2`) を指します。

## **数式定数と演算子**

組み込みの数式評価エンジンは論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と指数表記の両方がサポートされます。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルはダブルクオートで囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式でもスプレッドシート エラー値を結果として返すことがあります。 |

この例は複数の定数型を使用しています。

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

    logical_value = workbook.get_cell(0, "B2").value  # False
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
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

評価順序を明示したい場合は括弧を使用します。例: `(A2+B2)*C2`.

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

Aspose.Slides はチャート ワークシート用に組み込みの数式評価エンジンを提供しますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数は以下の一覧に限定されます。任意の Excel 関数が [calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) で再計算できると想定しないでください。

| 関数 | 用途またはサポート形態 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定の倍数に切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付系で日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形で、`LOOKUP` と `MATCH` はベクトル形でのみサポートされます。`DATE` は 1900 日付系を使用します。ここに記載されていない機能や関数は、Aspose.Slides の数式評価エンジンではサポートされていないと見なしてください。

## **優先カルチャでの数式計算**

一部のワークブック関数はカルチャ固有の規則に従ってテキストを解釈します。特にダブルバイト文字セット (DBCS) を使用する言語向け関数では重要です。正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) を作成し、[LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/spreadsheet_options/) から [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/spreadsheetoptions/) を設定してからプレゼンテーションをロードします。

以下の例は日本語カルチャを選択し、設定したロードオプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

優先カルチャはプレゼンテーションのロード設定の一部であるため、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成する前に指定します。ワークブック数式が期待するカルチャを使用してください。例: 日本語 DBCS 計算規則が必要な数式には `ja-JP` を使用します。

## **再計算とキャッシュ値**

スプレッドシート ファイルは通常、数式とその最終計算値の両方を保存します。Aspose.Slides はプレゼンテーションがロードされ、関連するチャート データが変更されていない場合、[IChartDataCell.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/value/) からキャッシュ値を読み取ります。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取る前、またはそれらに依存するチャート データを保存する前に、[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出します。

サポート外の数式については、Aspose.Slides が数式の解析や依存関係の確立に失敗する可能性があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できなくなります。この状況でサポート外データを含むセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) が発生することがあります。

Excel 関数で Aspose.Slides が評価できないものがある場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値をチャート ワークブックに書き戻してください。推測した値で非サポート数式を置き換えないでください。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

1. 数式自体は有効だが、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` などのスプレッドシート エラー結果を返す場合。この場合エラー トークンはセルの結果として `value` から取得できます。

2. 解析、参照、依存関係、またはサポートデータのレベルで失敗する場合。Aspose.Slides はこれらのケースに対してスプレッドシート固有の例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)、および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算と値アクセスの周囲でこれらの例外を捕捉してください。

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

チャート ワークシートにおける数式サポートは、完全な Excel 互換性を目指すものではなく、定義された計算サブセット向けです。レポート ワークフローを設計する際は次の点に留意してください。

- Aspose.Slides に数式再計算を委ねる場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
- セルの変更後は必ず再計算してください。
- ロードされたプレゼンテーションから取得したキャッシュ値はスナップショットとみなし、編集後の再計算の代替として使用しないでください。
- 既存テンプレートの数式は、ドキュメント化されたリスト外の関数を使用していないか事前にテストしてください。
- 完全なスプレッドシート計算エンジンが必要な数式は外部で計算し、結果だけをチャート ワークブックに書き戻してください。

## **FAQ**

**`formula` と `r1c1_formula` の違いは何ですか？**

[formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/formula/) は `B2-C2` のような A1 形式の式を保存します。[r1c1_formula](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) は `RC[-2]-RC[-1]` のような R1C1 形式の式を保存します。数式の生成・コピー方法に合わせて適切な表記を選択してください。

**計算後はセル自体を読むべきですか、値を読むべきですか？**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) は `IChartDataCell` を返します。再計算後に計算結果を取得するには、そのセルの [value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichartdatacell/value/) プロパティを読み取ります。

**`calculate_formulas` はいつ呼び出すべきですか？**

入力値または数式を変更した後、計算結果に依存する前に必ず [calculate_formulas](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) を呼び出してください。これにより組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換が必要な場合は、別のスプレッドシート エンジンで計算し、最終値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションに非サポート数式が含まれている場合はどうなりますか？**

チャート データが変更されていなければ、ワークブックに以前計算されたキャッシュ値が残っている可能性があります。関連データが変更された後はそのキャッシュが無効になることがあります。処理できない数式を含むセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は Python の例外と同じですか？**

いいえ。`#DIV/0!` などの結果は有効な計算が生成したスプレッドシート値です。`CellInvalidFormulaException` や `CellCircularReferenceException` といった例外は、数式そのものが正常に処理できないことを示します。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート シリーズはワークブックセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングすれば、計算されたセル値がチャートに反映されます。別途チャート更新メソッドは必要ありません。

**外部 Excel ワークブックをチャートで使用できますか？**

はい、チャート データ API を使用して外部ワークブックを参照できます。ただし、この記事で説明する数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限定されます。外部 XLSX ファイルの任意の数式が完全に再計算されると期待しないでください。

**別シートや別ブックを参照する数式は使用できますか？**

チャート ワークブック内で Excel 形式の参照は可能ですが、評価はサポートされているパーサと関数セットに依存します。クロスシートや外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に評価できるか事前に確認してください。広範な Excel 参照互換が必要な場合は、外部でワークブックを計算し、解決済みの値をチャート データに書き戻すことを検討してください。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API サンプルは `B2-C2` や `SUM(B2:B5)` のように先頭の `=` を付けずに式を割り当てます。この形式で記述すると、API ドキュメントの例と整合性が保たれます。