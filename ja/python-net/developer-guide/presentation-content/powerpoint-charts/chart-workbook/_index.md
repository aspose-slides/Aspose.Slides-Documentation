---
title: Python でプレゼンテーションのチャート ワークブックを管理する
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
description: "Aspose.Slides for Python via .NET を使って、PowerPoint と OpenDocument 形式のチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャートワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み書き、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャートのデータ ソースとして使用する方法も扱います。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示します。

ワークブック セルが欠落データを表す場合は、[空のセルの表示制御](/slides/ja/python-net/chart-series/) を参照して、空のセルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示の行と列からデータを含める**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) を使用して、チャートが非表示のワークシート 行と列のデータをプロットするかどうかを制御します。`True` に設定すると表示セルのみをプロットし、`False` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示または表示にするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初の形状として列グラフが含まれています。埋め込みワークシート `Sheet1` には次のソース範囲 `A1:C4` が含まれます。行 3 と列 C は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) でソースセルにアクセスし、[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) で非表示状態を確認します。このプロパティは読み取り専用です。このファイルでは B2 が表示、B3 が非表示行に属し、C2 が非表示列に属します。例ではそれぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します: 埋め込みワークブックを [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) で取得し、[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) で再ロードします。すべてのセルを含める場合は、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

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
                # 非表示カテゴリを含む完全なソース範囲を復元します。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

例では、表示セルのみ（10 と 20）のプレゼンテーションと、すべての 6 つの値を含むプレゼンテーションの 2 つのバージョンを保存します。下の画像は、保存後に再度開いたプレゼンテーションからレンダリングしたもので、両方のファイルとも割り当てられたプロット設定を保持しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値.](hidden_cells_False.png) |

値を持つ非表示セルは空のセルとは異なります。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) は欠落値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。[空のセルの表示制御](/slides/ja/python-net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲の取得**

既存のプレゼンテーションでワークブック データを更新する前に、ソース範囲を確認して各チャートが使用しているワークシート セルを特定します。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) メソッドは、現在のデータ範囲をワークシート限定の数式として返します（例: `Sheet1!$A$1:$D$5`）。ここで `Sheet1` はワークシート名、`!` はセル範囲から区切り、`$A$1:$D$5` は A1 から D5 までのセルを絶対参照で示しています。

このメソッドはチャートやワークブックを変更せずに現在の範囲を取得します。チャートがワークブックをデータ ソースとして使用していない場合は例外がスローされます。詳細は [ChartData API リファレンス](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) を参照してください。

この例ではプレゼンテーションを開き、各スライドの形状を直接チェックしてチャートを探します。各チャートの名前とソース範囲を出力し、範囲が取得できない場合は診断メッセージを表示して次のチャートへ進みます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **ワークブックからチャート データの読み書き**

Aspose.Slides for Python via .NET は、[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) メソッドを提供し、チャート データワークブック（Aspose.Cells で編集されたチャート データを含む）の読み書きが可能です。**Note** チャート データは同じ構造であるか、ソースに類似した構造である必要があります。

この例では、最初のスライドの最初の形状としてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

### **ワークブック変更後のチャート レイアウト検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリコレクションを保持したままになります。この不一致により [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) がインデックス範囲外エラーで失敗することがあります。更新したワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例では最初のスライドの最初の形状としてチャートを使用します。コメントはワークブック編集が行われる場所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ上でレイアウトを検証します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # ここでワークブック ストリームを変更します。例として Aspose.Cells を使用します。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに対して必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブック セルをチャート データ ラベルとして設定**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例では、既存のプレゼンテーションの最初のスライドにバブル チャート（デフォルト データ）を追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして更新されたプレゼンテーションを保存します。

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例ではデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

この例ではデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 列挙型で各名前のソースを選択します。例では更新された系列名でプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) の [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) プロパティと [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 列挙型を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例では既存のプレゼンテーションの最初のスライドの形状を調べ、非チャート形状をスキップし、.xlsb 埋め込みワークブックを持つ各チャートに診断メッセージを出力します。

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

        # ここでサポートされているチャート ワークブック データを読み取るか、変更します。
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例ではデフォルト データの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをチャートのデータ ソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にも更新に利用できます。

リモート ロケーションやリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定されている場合は、自動的にフル パスに変換されます。

この例では、ワークシート `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が格納された外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用して A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートでプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) の `update_chart_data` パラメーターは、ワークブックがロードされるかどうかを制御します。

* `update_chart_data` が `False` の場合、ワークブック パスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `update_chart_data` が `True` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は、`update_chart_data` を `False` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データは保持され、利用できないワークブックをロードせずにプレゼンテーションが保存されます。

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

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、そのワークブック パスを取得します。

この例では、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初の形状を調べます。外部ワークブックにリンクされたチャートであれば、[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックがロードできない場合、例外がスローされます。

この例では、最初のスライドの最初の形状としてチャートを使用し、アクセス可能な外部ワークブックにリンクしています。最初の系列の最初のデータ ポイントのセル バック値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

### **チャート キャッシュからワークブックを回復**

チャートが欠落または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) を作成し、その [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) を構成し、[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を `True` に設定してプレゼンテーションを開く前に設定してください。

以下の Python 例は、最初のスライドの最初の形状としてチャートを使用し、利用できない外部ワークブックを参照している場合にワークブック データを回復します。回復したデータは [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) と [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を介してアクセスできます。

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

        # ここで回復されたワークブック データを読み取るか、変更します。
    else:
        print("The first shape is not a chart.")
```

外部ワークブックが利用できず、回復が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できる場合にのみ回復を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、外部ワークブックがソースである場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存します。セル バックされたチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/python-net/) などを使用して復号化したコピーを作成し、そのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされるときにすべてのチャートに反映されます。