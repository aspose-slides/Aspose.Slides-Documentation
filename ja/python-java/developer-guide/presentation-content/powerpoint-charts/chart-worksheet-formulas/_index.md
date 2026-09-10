---
title: Python via Java でプレゼンテーションのチャート ワークシート数式を適用
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/python-java/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- チャート データ ワークブック
- 数式 計算
- 優先ロケール
- ロケール固有 数式
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
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して、PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のチャートは通常、埋め込みワークシートに元データを格納します。Aspose.Slides for Python via Java では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込んだり、セルに数式を割り当てたり、サポートされている数式を計算したり、計算されたセルをチャート データとして使用したりできます。

本記事では、完全な数式ワークフローを説明します。チャートの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式の割り当て、再計算、計算結果の取得、これらのセルをチャート系列に接続、プレゼンテーションの保存の手順です。また、サポートされる数式構文、組み込み関数のサブセット、キャッシュされた値、サポート外の数式、およびスプレッドシート固有のエラーについても説明します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![埋め込みワークシートが開かれた PowerPoint チャートで、カテゴリと系列データを表示](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) クラスを通じて公開されます。A1 形式の数式には [ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setFormula) を使用し、R1C1 形式の数式には [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setR1C1Formula) を使用します。入力セルや数式を変更した後は、[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算済みセルは依然として [ChartDataCell.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#getValue) を介して結果を取得できます。コード内で数式結果を確認したり、セルをチャート データ ポイントとして使用したりする場合に重要です。

## **チャートの作成とワークシート数式の計算**

次のサンプルは、エンドツーエンドのワークフローを示しています。クラスター化縦棒チャートを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャートの値として使用し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

チャート データ ポイントは `D2:D4` を参照しているため、チャートは計算された利益の値を使用します。このワークフローでは別途チャートの更新呼び出しは不要です。まずワークブックを再計算し、計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字、行を数字で識別します。A1 形式の式は [ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setFormula) を使用して割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

一般的な A1 参照形式は次のとおりです：

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は、スプレッドシート アプリケーションで数式を移動またはコピーしたときに変更される可能性があります。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧内のオフセットで表します。この構文は [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setR1C1Formula) を使用して割り当てます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

一般的な R1C1 参照形式は次のとおりです：

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえば、セル `D2` で `RC[-2]` は、同じ行の左に 2 列離れたセル（`B2`）を意味します。

## **数式定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| タイプ | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と指数表記の両方がサポートされます。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は、通常結果の代わりにスプレッドシートのエラー値を返すことがあります。 |

この例では、いくつかの定数タイプが使用されています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # 偽
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または否定 | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセント | `30%` |
| `^` | べき乗 | `2^3` |

評価順序を明示するにはかっこを使用します。例: `(A2+B2)*C2`.

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

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数セットは以下の関数に限定されています。[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) が任意の Excel 関数を再計算できると推測しないでください。

| 関数 | 目的またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定した倍数へ切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト値を結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト値を結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムを使用して日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | 文字列内で別のテキストを検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件付き結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計値 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でドキュメント化されています。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能や関数は、別途ドキュメント化されていない限り、Aspose.Slides の数式評価エンジンではサポートされていないものとみなしてください。

## **優先ロケールで数式を計算する**

一部のチャート ワークブック関数は、テキストをロケール固有の規則で解釈します。これは、ダブルバイト文字セット（DBCS）を使用する言語向けの関数に特に重要です。このような数式を正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) で優先ロケールを設定し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) でスプレッドシート オプションを割り当ててから、プレゼンテーションをロードします。

次の例では、日本語ロケールを選択し、設定したロードオプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

優先ロケールはプレゼンテーションのロード設定の一部であるため、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成する前に指定してください。ワークブックの数式が期待するロケールを使用します。たとえば、日本語 DBCS 計算規則に従う数式には `ja-JP` を使用します。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を保存します。したがって、プレゼンテーションがロードされ、該当するチャート データが変更されていない場合、Aspose.Slides は [ChartDataCell.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#getValue) からキャッシュされた値を読み取ることができます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取るか、それらに依存するチャート データを保存する前に、[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。

サポート外の数式については、Aspose.Slides が数式を解析できなかったり、依存関係を確立できなかったりする場合があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できません。そのような状況で、サポート外データを持つセルの値を読み取ろうとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellunsupporteddataexception/) が発生する可能性があります。

チャートが Aspose.Slides が評価しない Excel 関数に依存している場合、サポートされているスプレッドシート エンジンでそれらの数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測した値で置き換えないでください。

## **数式エラーの処理**

区別すべき問題は大きく2つあります。

数式が有効でも、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` などのスプレッドシート エラー結果を返すことがあります。この場合、エラー トークンはセルの結果であり、[ChartDataCell.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#getValue) を通じて取得できます。

数式は、構文解析、参照、依存関係、またはサポートデータのレベルで失敗することもあります。そのような場合、Aspose.Slides は次のスプレッドシート固有例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellcircularreferenceexception/)、および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が提供される場合、再計算および値取得の周囲でこれらの例外を処理してください：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **実用的な制限事項**

チャート ワークシートでの数式サポートは、定義されたサブセットのスプレッドシート計算を対象としており、完全な Excel 互換性を提供するものではありません。レポート ワークフローを設計する際は、以下の制約を念頭に置いてください：

- Aspose.Slides に数式の再計算を任せる場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
- 数式結果が依存するセルを変更した後は、再計算してください。
- ロードされたプレゼンテーションのキャッシュ値はスナップショットとして扱い、編集後の再計算の代替として使用しないでください。
- 既存テンプレートからの数式は、特にドキュメント外の関数を使用している場合、計算結果に依存する前にテストしてください。
- フルスプレッドシート計算エンジンが必要な数式は、外部で計算し、結果の値でチャート ワークブックを更新してください。

## **よくある質問**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setFormula) と [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setR1C1Formula) の違いは何ですか？**

[ChartDataCell.setFormula] は `B2-C2` のような A1 形式の式を保存します。[ChartDataCell.setR1C1Formula] は `RC[-2]-RC[-1]` のような R1C1 形式の式を保存します。生成またはコピーする数式に最も適した表記を使用してください。

**計算後、セル自体を読むべきですか、あるいはその値を読むべきですか？**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getCell) は [ChartDataCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/) を返します。再計算後に計算結果を取得するには、そのセルの [ChartDataCell.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#getValue) メソッドを呼び出してください。

**[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) はいつ呼び出すべきですか？**

入力値や数式を変更した後、計算結果に依存する前に [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化された関数のサブセットのみをサポートします。そのサブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 数式互換性が必要な場合は、適切なスプレッドシート エンジンで計算し、最終的な値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポート外の数式が含まれている場合、どうなりますか？**

チャート データが変更されていない限り、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更されると、そのキャッシュ値は無効になる可能性があります。処理できない数式を持つセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellunsupporteddataexception/) が発生することがあります。

**数式エラー値は例外と同じですか？**

いいえ。`#DIV/0!` のような結果は、有効な計算によって生成されたスプレッドシートの値です。[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cellcircularreferenceexception/) などの例外は、数式を正常に処理できないことを示します。

**数式セルが変更されたとき、チャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存または描画します。データ ポイントが計算されたセルを参照している場合、チャートは更新されたセル値を使用します。このワークフローでは別途チャート更新メソッドは必要ありません。

**チャートは外部の Excel ワークブックを使用できますか？**

はい、チャート データは API を通じて外部ワークブックを使用するように構成できます。ただし、本記事で説明した数式計算ワークフローは、チャート データ ワークブックと Aspose.Slides が評価する数式サブセットに限定されています。[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) が外部 XLSX ファイルの任意の数式を完全に再計算すると想定しないでください。

**別のワークシートやワークブックを参照する数式を使用できますか？**

Excel 形式の参照はチャート ワークブックに存在する可能性がありますが、数式評価はサポートされているパーサーと関数セットに制限されています。クロスシートまたは外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確な数式を検証してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決した値をチャート データに書き戻してください。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API 例では、`B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てています。その形式を使用すると、ドキュメント化された API 例と一貫性が保たれます。