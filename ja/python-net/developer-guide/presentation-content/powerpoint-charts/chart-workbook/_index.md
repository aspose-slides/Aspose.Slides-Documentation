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
description: "Aspose.Slides for Python via .NET を使って、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャートのワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、およびチャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も扱います。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、そしてワークブックが利用可能なときにチャート データを編集する方法を示しています。

ワークブックセルが欠損データを表す場合は、[空白セルの表示制御](/slides/ja/python-net/chart-series/) を参照し、空白セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行・列からのデータを含める**

このメソッド[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)を使用して、チャートが非表示のワークシート行や列のデータをプロットするかどうかを制御します。`True` に設定すると表示セルのみをプロットし、`False` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示または表示にするものではありません。

この[サンプルプレゼンテーション](hidden-source-data.pptx)には、最初のスライドの最初の図形として列グラフが含まれています。埋め込みワークシート `Sheet1` には、ソース範囲 `A1:C4` が含まれます。3 行目と C 列は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

ソースセルには[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)でアクセスし、[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)で非表示ステータスを確認します。このプロパティは読み取り専用です。このファイルでは、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属します。例ではそれぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定変更後にチャート データをリフレッシュします。埋め込みワークブックは[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)で取得し、[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)で再ロードします。すべてのセルを含める場合は、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データやカテゴリ ラベルはリフレッシュされません。

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
                # 隠しカテゴリを含む完全なソース範囲を復元します。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

この例では、プレゼンテーションを 2 つのバージョンで保存します。1 つは表示されている小売値（10 と 20）のみ、もう 1 つはすべて 6 つの値です。以下の画像は、保存したプレゼンテーションを再度開いた後にレンダリングしたものです。両ファイルとも割り当てられたプロット設定を保持しています。3 行目と C 列は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![表示セルのみ：1月と3月の小売値 10 と 20](hidden_cells_True.png) | ![すべてのセル：1月、2月、3月の小売と卸売の値](hidden_cells_False.png) |

値を含む非表示セルは、空白セルとは異なります。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) は欠損値の表示方法を制御しますが、非表示ソース データの含有は行いません。例については、[空白セルの表示制御](/slides/ja/python-net/chart-series/#control-the-display-of-empty-cells)をご覧ください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシートセルを特定するためにソース範囲を検査します。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) メソッドは、現在のデータ範囲をワークシート限定の数式で返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` はワークシート名、`!` はセル範囲との区切り、`$A$1:$D$5` は A1 から D5 まで（両端含む）を示します。ドル記号は絶対行・列参照を表します。

このメソッドはチャートやワークブックを変更せずに現在の範囲を読み取ります。チャートがデータソースとしてワークブックを使用していない場合、例外がスローされます。詳細については、[ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) を参照してください。

この例では、プレゼンテーションを開き、各スライド上の図形を直接チェックしてチャートを探します。各チャートの名前とソース範囲を出力します。範囲が取得できない場合は診断メッセージを出力し、次のチャートに進みます。

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

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for Python via .NET は、[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたデータを含む）の読み書きを可能にします。**注意** チャート データは同じ形式で構成されているか、元と同様の構造である必要があります。

この例では、最初のスライドの最初の図形としてチャートがあるプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ内に保持され、プレゼンテーションは保存されません。

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

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例では、最初のスライドの最初の図形としてのチャートを使用します。コメントはワークブック編集が行われる位置を示しています；実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # ここでワークブック ストリームを変更します。たとえば Aspose.Cells を使用してください。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。チャートを使用する前に、更新されたワークブック用に必要な系列およびカテゴリのマッピングを再構築してください。

## **カテゴリ ラベルの格納方法を選択**

カテゴリ コレクションが空の間に[ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) を設定します。ワークシートセルを参照するラベルや、年ごとに四半期を階層化する場合は `True` に設定します。文字列で提供される単一レベルのラベルの場合は `False` に設定します。この設定はカテゴリにのみ適用されます。例の両方のチャートは、数値系列の値にワークシートセルを使用しています。

この例では、2 つの列チャートを作成し、各チャートの格納モードとラベル `Q1 Q2 Q3 Q4` を出力します。セルベースのラベルについては、[ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) がワークシートセルを返し、[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) がそのセルに保存されたラベルを返します。文字列リテラルのラベルの場合は、[ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/) から直接文字列を取得します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **ワークブックセルのカスタム数値書式を設定する**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) を使用して、チャートの埋め込みワークブック内で数値がどのように表示されるかを制御します。たとえば、レポートで変換率を小数点以下 4 桁のパーセンテージとして、係数を小数点以下 5 桁で表示する必要がある場合があります。どちらの値も数値のままにしておくことで、計算やチャートのプロットに利用できます。

数値書式は表示を変更するものであり、保存された値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値を `12.5` に置き換えるわけではありません。同様に、`0.00000` は `0.1234567` を `0.12346` と表示しますが、保存値は丸められません。カスタム書式が空文字列（`""`）の場合は、[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) が代わりに使用されます。

以下の例では、列チャートを作成し、[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を介してセルにアクセスします。ワークシート 0 の B2 には変換率、C2 には係数が格納されています。両方のセルがチャートの値として使用されます。また、例ではソース書式にリンクした値ラベルを有効にしています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

ワークブックセルの書式は、チャート軸やデータ ラベルに直接設定された書式とは別です。この例では、[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) が有効になっているため各ラベルはソースセルの値を表示し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) が `True` のためソースの数値書式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します（下図参照）。縦軸は独自の [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` を使用し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) は `False` に設定されています。

データ ラベルを個別に書式設定するには、ソースリンクフラグを `False` に設定し、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) を割り当てます。これによりワークブックセルの書式は変更されません。たとえば、個別ラベル書式 `0.00` を設定すると、最初の値は `0.13` と表示されますが、B2 は引き続き `12.5000%` を表示します。直接的なラベル書式設定については、[Chart Data Labels](/slides/ja/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) をご覧ください。

![ソースリンクされたラベルが 12.5000% と 0.12346 を示し、独立して書式設定された数値軸を持つ縦棒グラフ](custom-cell-formats.png)

## **ワークブックセルをチャート データ ラベルとして設定する**

ワークブックセルのテキストをチャート データ ラベルとして使用できます。

この例では、既存のプレゼンテーションの最初のスライドにデフォルト データのバブルチャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) プロパティは、チャート ワークブック内のワークシートへのアクセスを提供します。この例では、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データ ソース タイプを指定する**

系列のポイント値は数値リテラルとして直接格納することもできます。保存および読み取りの完全な例については、[Set Series Values Using Numeric Literals](/slides/ja/python-net/chart-series/#set-series-values-using-numeric-literals) を参照してください。ポイント値のソース タイプは、チャートの内部または外部ワークブック設定とは別であり、数値リテラルを使用するだけでは埋め込みワークブックが削除されるわけではありません。

この例では、デフォルト データの 3D 列チャートを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラルを使用し、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 列挙体で各名前のソースを選択します。例は、更新された系列名でプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) の [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) プロパティと [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、それらのチャートをスキップできます。この例では、既存のプレゼンテーションの最初のスライドの図形を検査し、チャートでない図形をスキップし、埋め込み .xlsb ワークブックを持つ各チャートに対して診断メッセージを出力します。

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

        # ここでサポートされているチャート ワークブック データを読み取るか、変更してください。
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例では、デフォルト データの円グラフを作成し、そのワークブックをエクスポートします。外部ワークブックをチャート データ ソースとして割り当てる前に出力ストリームを閉じ、リンクされたプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新する（移動された場合）にも使用できます。

リモート ロケーションやリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定されている場合、自動的にフルパスに変換されます。

この例では、`Sheet1` という名前のワークシートを持つ外部ワークブックを使用します。このシートには B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が含まれます。例は円グラフを作成し、ワークブックをリンクし、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用して A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートでプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) の `update_chart_data` パラメータは、ワークブックをロードするかどうかを制御します。

* `update_chart_data` が `False` の場合、ワークブックのパスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。
* `update_chart_data` が `True` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例では、`update_chart_data` を `False` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データを保持し、利用できないワークブックをロードせずにプレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **チャートの外部データ ソース ワークブック パスを取得する**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例では、外部ワークブックがリンクされたプレゼンテーションの最初のスライドの最初の図形を検査します。もしそれが外部ワークブックにリンクされたチャートであれば、[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) をコンソールに出力します。その後、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例では、最初のスライドの最初の図形としてのチャートを使用し、利用可能な外部ワークブックにリンクしています。第 1 系列の第1 データポイントのセルベース値を 100 に設定し、更新されたプレゼンテーションを保存します。セルの値を編集するとリンクされた外部 XLSX ファイルが更新されるため、元のワークブックを保持したい場合は、ワークブックのコピーを使用してください。

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

### **チャートキャッシュからワークブックを復元する**

チャートが欠損または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。プレゼンテーションを開く前に、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) を作成し、その [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) を設定し、[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を `True` に設定します。

以下の Python 例は、最初のスライドの最初の図形としてのチャートで、利用できない外部ワークブックを参照している場合にワークブック データを復元します。復元されたデータは [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) と [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を通じてアクセスします。

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

        # ここで復元されたワークブック データを読み取るか、変更します。
    else:
        print("The first shape is not a chart.")
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックに加えられた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、ソースが外部ワークブックの場合、完全なパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされており、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイルに絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存します。セルベースのチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のファイルを変更したくない場合は、ワークブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合、どうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（たとえば [Aspose.Cells](https://reference.aspose.com/cells/python-net/) を使用）を作成し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると、次回データがロードされる際に各チャートに反映されます。