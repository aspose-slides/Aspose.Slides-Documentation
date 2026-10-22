---
title: プレゼンテーションで Python を使用したチャート ワークブックの管理
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
- ワークブック 復旧
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を活用し、PowerPoint および OpenDocument 形式のチャート ワークブックを容易に管理してプレゼンテーション データを効率化します。"
---
## **概要**

このドキュメントでは、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを通じてチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。サンプルでは、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能なときのチャート データ編集を実演します。

欠損データを表すワークブック セルについては、[空セルの表示制御](/slides/ja/python-net/chart-series/) を参照し、空セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示の行と列からデータを含める**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) を使用して、チャートが非表示のワークシート 行・列からデータをプロットするかどうかを制御します。`True` に設定すると表示されているセルのみをプロットし、`False` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートの描画にのみ影響し、ワークシート の行や列を非表示/表示にするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初の図形として列グラフが含まれています。埋め込みワークシート `Sheet1` のソース範囲は `A1:C4` です。行 3 と列 C は非表示ですが、セルの値は残っています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) でソース セルにアクセスし、[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) で非表示状態を調べます。このプロパティは読み取り専用です。この例では、B2 は表示、B3 は非表示行、C2 は非表示列に該当し、それぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) で取得し、[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) で再ロードします。すべてのセルを含める場合は、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データやカテゴリ ラベルは更新されません。

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

このサンプルは、表示セルのみ（10 と 20）のプレゼンテーションと、すべての 6 つの値を含むプレゼンテーションの 2 つのバージョンを保存します。下の画像は、保存後に再度開いたプレゼンテーションからレンダリングしたものです。どちらのファイルも設定したプロット オプションを保持しています。行 3 と列 C は両方の埋め込みワークブックで引き続き非表示です。

| 表示セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20。](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売と卸売の値。](hidden_cells_False.png) |

値を持つ非表示セルは空セルとは異なります。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) は欠損値の表示方法を制御しますが、非表示ソース データの含有・除外は行いません。[空セルの表示制御](/slides/ja/python-net/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルの範囲を確認します。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) メソッドは、`Sheet1!$A$1:$D$5` のようなワークシート限定の数式で現在のデータ範囲を返します。ここで `Sheet1` がシート名、`!` がシート名とセル範囲の区切り、`$A$1:$D$5` が絶対参照のセル範囲です。

このメソッドはチャートやワークブックを変更せずに現在の範囲を取得します。ワークブックをデータ ソースとして使用していないチャートに対して呼び出すと例外がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドの図形を走査してチャートを検出します。チャート名とソース範囲を出力し、取得できなかった場合は診断メッセージを表示して次のチャートへ進みます。

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

Aspose.Slides for Python via .NET は、[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) メソッドを提供し、Aspose.Cells で編集したチャート データを含むワークブックの読み書きが可能です。**注意**: チャート データは元の構造と同一、または類似した構造である必要があります。

この例は、最初のスライドの最初の図形として配置されたチャートを含むプレゼンテーションを使用します。埋め込みワークブックをストリームに読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ上に残り、プレゼンテーションは保存しません。

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

埋め込みワークブックを修正したものに差し替えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不一致により、[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例は、最初のスライドの最初の図形として配置されたチャートを使用します。コメント位置にワークブック編集処理が入りますが、実行可能なサンプルは元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # ここでワークブックストリームを変更します。例えば Aspose.Cells を使用します。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列やカテゴリのマッピングを再構築してください。

## **ワークブックセルのカスタム数値書式を設定する**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) を使用して、チャートの埋め込みワークブック内の数値表示形式を制御できます。たとえば、コンバージョン率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁で表示したい場合があります。計算やチャート描画に使用できるよう、両方とも数値として保持してください。

数値書式は表示方法を変更するだけで、保存された実際の値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値は `0.125` のままです。同様に、`0.00000` は `0.1234567` を `0.12346` と表示しますが、元の数値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) が使用されます。

以下の例は列グラフを作成し、[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を通じてセルにアクセスします。シート 0 の B2 にコンバージョン率、C2 に係数が格納され、両方がチャート値として使用されます。さらに、ソース書式にリンクした値ラベルも有効にしています。

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

ワークブックセルの書式は、チャート軸やデータ ラベルに直接設定された書式とは別物です。この例では、[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) が有効で、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) が `True` のため、ラベルはソース セルの書式を継承します。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` を使用し、[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) が `False` です。

データ ラベルの書式を個別に設定したい場合は、ソース リンク フラグを `False` にし、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) を割り当てます。これによりワークブック セルの書式は変わりません。たとえば、独立した書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を示します。詳細は [Chart Data Labels](/slides/ja/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、保存後に再度開いたプレゼンテーションからレンダリングしたものです。

![ソース書式リンクラベルが 12.5000% と 0.12346 を表示し、独立書式の数値軸を持つ列グラフ。](custom-cell-formats.png)

## **ワークブックセルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、シート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セル ラベルを有効にして更新されたプレゼンテーションを保存します。

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) プロパティを使用すると、チャート ワークブック内のワークシートにアクセスできます。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データソースタイプを指定する**

系列の点の値は数値リテラルとして直接格納することもできます。[数値リテラルを使用した系列値の設定](/slides/ja/python-net/chart-series/#set-series-values-using-numeric-literals) に完全なサンプルがあります。点の値のソース タイプは、チャートの内部または外部ワークブック構成とは別で、数値リテラルを使用しただけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列グラフを作成し、2 つの系列名に異なるデータ ソースを使用します。最初の名前は文字列リテラル、2 番目の名前はシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 列挙型で各名前のソースを選択します。例は更新された系列名を含むプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) の [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) プロパティと、[WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) 列挙型を組み合わせて、サポート外形式を検出し、該当チャートをスキップできます。この例は既存プレゼンテーションの最初のスライドの図形を走査し、非チャート図形を除外し、.xlsb 埋め込みワークブックを持つチャートに対して診断メッセージを出力します。

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

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、その外部ワークブックにチャートをリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。出力ストリームを閉じてから外部ワークブックをデータ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。ファイルの場所が変更された場合にパスを更新する用途でも利用できます。

リモート ロケーションやリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この例は、シート `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) で A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートを含むプレゼンテーションを保存します。

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) の `update_chart_data` パラメータは、ワークブックの読み込み要否を制御します。

* `update_chart_data` が `False` の場合、パスのみが更新され、チャート データは読み込まれません。そのため、ワークブックが利用不可でも問題ありません。
* `update_chart_data` が `True` の場合、ターゲット ワークブックからチャート データが更新されます。

次の例はプレースホルダー URL を割り当て、`update_chart_data` を `False` に設定します。円グラフはデフォルト データのままで、利用不可のワークブックは読み込まれません。

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

チャートが外部データ ソースを使用しているか確認し、リンクされたワークブックのパスを取得します。

この例は、外部ワークブックがリンクされたプレゼンテーションの最初のスライドの最初の図形を調べます。対象が外部ワークブックにリンクされたチャートであれば、[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックが読み込めない場合は例外がスローされます。

この例は、最初のスライドの最初の図形として配置されたチャートがアクセシブルな外部ワークブックにリンクされているシナリオです。最初の系列の最初のデータ ポイントのセル バックされた値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

チャートが外部ワークブックにリンクされているが、ファイルが欠損または利用不可の場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) を作成し、[spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) を構成し、[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を `True` に設定してからプレゼンテーションを開きます。

以下の Python サンプルは、最初のスライドの最初の図形として配置されたチャートが利用不可の外部ワークブックを参照しているケースで、キャッシュされたデータを復元します。復元されたデータは [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) と [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を通じてアクセスできます。

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

外部ワークブックが利用不可で復元が無効の場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できる場合にのみ復元を有効にしてください。キャッシュには外部ワークブックの変更が反映されていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックかを判別できますか？**

はい。チャートは [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [external workbook のパス](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を持ちます。外部ワークブックであれば、完全パスを取得して外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？保存方法は？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX 内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク共有やリモートリソース上のワークブックを使用できますか？**

はい、外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ利用できます。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存します。セル バックされたチャート データを編集すると、リンクされたローカル XLSX が更新されることがあります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/python-net/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは個別にリンクを保持します。すべて同じファイルを指す場合、そのファイルを更新すれば次回データをロードしたときにすべてのチャートに反映されます。