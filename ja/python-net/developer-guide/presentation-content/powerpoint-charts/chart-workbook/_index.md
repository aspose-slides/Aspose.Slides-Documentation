---
title: Python を使用したプレゼンテーションでのチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/python-net/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部ワークブック
- 外部データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事は Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを通じてチャート データの読み取りと書き込みを行い、ワークブック セルをチャート データ ラベルとして使用し、ワークシート コレクションにアクセスし、チャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法もカバーします。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャート データを編集する方法を示します。

欠損データを表すワークブック セルについては、[空のセルの表示を制御する](/slides/ja/python-net/chart-series/) を参照し、空セルと 0 の違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示の行と列からデータを含める**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) を使用して、チャートが非表示のワークシート 行および列からデータをプロットするかどうかを制御します。`True` に設定すると表示セルのみをプロットし、`False` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシート 行や列を非表示または表示にするものではありません。

[hidden-source-data.pptx](hidden-source-data.pptx) をダウンロードし、作業ディレクトリに配置してください。最初のスライドの最初のシェイプは列グラフです。埋め込みワークシート `Sheet1` にはソース範囲 `A1:C4` が含まれます。行 3 と列 C は非表示ですが、セルには値が残っています。

| ワークシート 行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData.chart_data_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) でソース セルにアクセスし、[ChartDataCell.is_hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/is_hidden/) で非表示状態を調べます。このプロパティは読み取り専用です。このファイルでは B2 が表示、B3 が非表示行に属し、C2 が非表示列に属しています。例はそれぞれ `False`、`True`、`True` を出力します。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [read_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) で取得し、[write_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) で再ロードします。すべてのセルを含める場合は、[set_range](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_range/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # 埋め込みワークブックからチャート データを更新します。
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 非表示のカテゴリを含む完全なソース範囲を復元します。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

例では、表示セルのみ（小売値 10 と 20）だけを含む `hidden_cells_True.pptx` と、すべての 6 つの値を含む `hidden_cells_False.pptx` を保存します。下の画像は、保存後に再度開いたプレゼンテーションからレンダリングしたものです。両ファイルとも割り当てられたプロット設定を保持し、行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![表示セルのみ: 1 月と 3 月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1 月、2 月、3 月の小売および卸売値.](hidden_cells_False.png) |

値を含む非表示セルは空セルとは異なります。[Chart.display_blanks_as](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/display_blanks_as/) は欠損値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。[空のセルの表示を制御する](/slides/ja/python-net/chart-series/#control-the-display-of-empty-cells) で例をご確認ください。

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for Python via .NET は、[read_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) および [write_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたデータを含む）を読み書きできます。**注**：チャート データは同様の構造で整理されている必要があります。

この例は、最初のスライドの最初のシェイプにチャートが含まれている `chart.pptx` を開きます。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[Chart.validate_chart_layout](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/validate_chart_layout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は、最初のスライドの最初のシェイプにチャートがある `chart.pptx` を前提としています。コメントでワークブック編集箇所を示し、実行可能な例は元のワークブックを書き戻してメモリ上でレイアウトを検証します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # ここでワークブックストリームを変更します。たとえば Aspose.Cells を使用します。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。以下の手順は、バブル チャートのラベルをデータ ワークブックのセルにリンクする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ゼロベース インデックスで最初のスライドにアクセスします。
3. デフォルト データでバブル チャートを追加します。
4. チャート系列にアクセスします。
5. ワークブック セルをデータ ラベルとして設定します。
6. プレゼンテーションを保存します。

この例は、少なくとも 1 枚のスライドが含まれる `chart2.pptx` を開き、デフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 ラベルに使用し、セルからラベルを有効にして結果を `resultchart.pptx` に保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **ワークシートの管理**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **データ ソース タイプの指定**

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。結果は `pres.pptx` に保存されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/) の [embedded_workbook_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) プロパティと [WorkbookType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例は `sample.pptx` の最初のスライド上のシェイプを調べ、非チャートシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートに診断メッセージを出力します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # サポートされているチャート ワークブック データをここで読み取るか変更します。
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、その外部ワークブックにチャートをリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックを `externalWorkbook1.xlsx` に書き込み、出力ストリームを閉じてからファイルをチャート データ ソースとして割り当てます。リンクされたプレゼンテーションは `externalWorkbook.pptx` として保存されます。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **外部ワークブックの設定**

[set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（ファイルが移動された場合）にも更新に使用できます。

リモート場所やリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この例は作業ディレクトリに `externalWorkbook.xlsx` があることを前提とします。シート `Sheet1` には B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が含まれている必要があります。例は円グラフを作成し、ワークブックをリンクし、[set_range](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_range/) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。結果は `Presentation_with_externalWorkbook.pptx` に保存されます。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` の `update_chart_data` パラメーターは、ワークブックをロードするかどうかを制御します。

* `update_chart_data` が `False` の場合、パスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `update_chart_data` が `True` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は、`update_chart_data` を `False` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データを保持したまま、利用できないワークブックをロードせずにプレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **チャートの外部データ ソース ワークブック パスの取得**

チャートにリンクされているワークブックを特定するには、まずチャートが外部データ ソースを使用しているか確認します。使用している場合は、以下の手順でワークブック パスを取得できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. ゼロベース インデックスで最初のスライドにアクセスします。
3. 最初のシェイプがチャートであることを確認します。
4. チャート データ ソース タイプを読み取ります。
5. ソースが外部ワークブックの場合、そのパスを読み取ります。

この例は、前述の例で作成した `externalWorkbook.pptx` を開き、最初のスライドの最初のシェイプを調べます。外部ワークブックにリンクされたチャートである場合、[external_workbook_path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) をコンソールに出力し、プレゼンテーションのコピーを `Result.pptx` として保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様の手順で編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプにチャートがある `presentation.pptx` と、アクセス可能な外部ワークブックを前提としています。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、結果を `presentation_out.pptx` に保存します。セルの値を編集するとリンクされた外部 XLSX ファイルが更新されるため、元のワークブックを保持したい場合はコピーを使用してください。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **チャート キャッシュからワークブックを復元する**

チャートが存在しないまたは利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。まず [LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) を作成し、その [spreadsheet_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/spreadsheet_options/) を構成し、[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ja/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を `True` に設定してプレゼンテーションを開きます。

以下の Python 例は、最初のスライドの最初のシェイプが利用できない外部ワークブックを参照している `presentation.pptx` を開き、[Chart.chart_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/chart_data/) と [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を介して復元されたデータにアクセスします。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # ここで回復されたワークブック データを読み取るか変更します。
    else:
        print("The first shape is not a chart.")
```

利用できない外部ワークブックがあり、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックへの最後の更新後の変更が含まれていない可能性があります。

## **よくある質問**

**特定のチャートが外部または埋め込みワークブックにリンクされているかどうかを判定できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/data_source_type/) と [external workbook のパス](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、外部ワークブックがソースの場合は完全パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされており、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません—ソースとしてのみ使用可能です。

**プレゼンテーションを保存すると外部 XLSX が上書きされますか？**

プレゼンテーションは [external file へのリンク](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存します。セル参照のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/python-net/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持しますが、同じファイルを指す場合、そのファイルを更新すれば次回データがロードされる際にすべてのチャートに反映されます。