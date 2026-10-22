---
title: Pythonでプレゼンテーションのチャート データシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャートシリーズ
- シリーズ オーバーラップ
- シリーズ 色
- カテゴリ 色
- シリーズ名
- データポイント
- シリーズ ギャップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用して、プレゼンテーションでチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックセルに保存することも、数値リテラルとして直接保存することもできます。[ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) は関連する値のセットを表し、各 [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) はそのシリーズ内のポイントを表します。[ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイント値はチャートワークブックの [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートでは、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名に使用し、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) に渡すワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルトデータでチャートを作成する場合に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

Chart 設定には次の 3 つのスコープがあります。

- シリーズレベルの設定（例: [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)）は、1 つのシリーズ内のすべてのポイントのデフォルト外観を提供します。
- データポイントの設定（例: [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)）は、1 つのポイントのシリーズ外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) を介してグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ（PowerPoint）](chart-series-powerpoint.png)

## **数値リテラルを使用してシリーズの値を設定する**

シリーズの値がアプリケーション データや計算結果から取得され、ワークシートセル参照が不要な場合は、数値リテラルを使用します。[data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) を [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) に設定し、各ポイントの [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) を [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) で割り当てる前に設定してください。

コレクションの設定は、そのシリーズ内のすべてのポイント値のソース タイプを制御します。各ポイントの [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) は選択されたタイプを報告します。コレクション設定を介して変更します。`WORKSHEET` の場合は [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) を使用して参照セルにアクセスします。`DOUBLE_LITERALS` の場合は `as_literal_double` を使用して数値を直接読み書きします。

次の例は、デフォルトのシリーズとカテゴリを持つ縦棒チャートを作成し、最初のシリーズの既存ポイントに 10、20 などの計算値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

ポイント値のソース タイプは、[ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) とは別で、チャートの内部または外部ワークブック構成を識別します。数値リテラルを使用しても、埋め込みワークブックが自動的に削除されるわけではありません。この例では、ワークブックはカテゴリ ラベル、シリーズ名、他のシリーズに引き続き利用可能です。ワークブック管理については、[Chart Workbook](/slides/ja/python-net/chart-workbook/) を参照してください。

散布図およびバブルチャートの場合、[data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) と [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) を設定して、[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) と [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) のソースを選択します。バブルチャートはさらに [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) を使用して [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) を指定します。該当する各ソースを `DOUBLE_LITERALS` に設定し、その値の `as_literal_double` プロパティを介して数値を割り当てます。

## **チャートシリーズのオーバーラップを設定する**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) は、2D チャートで棒または縦棒がどの程度重なるか（-100〜100％）を示します。これは、親シリーズ グループの設定の読み取り専用の投影です。[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) を設定すると、そのグループ内のすべての互換シリーズが更新されます。このオプションは、グループ化された棒または縦棒を表示するチャート タイプに適用され、組み合わせチャート内の無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青い塗りつぶしを適用します。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズの色](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスタ化縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が含まれます。以下の例の名前付き定数は、その構造を明示的に示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

また、[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) がすでに参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を仮定することを回避します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズ名](series_name.png)

### **複数セルから名前を持つシリーズを作成する**

製品名と報告期間が別々のワークブックセルに保存されている場合、複合シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を単一のシリーズ名に結合し、両方の部分をソース セルにリンクしたままにできます。

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) を使用して名前範囲を取得し、そのコレクションを [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) に渡します。`skip_hidden_cells` 引数は非表示セルを含めるかどうかを制御します：`True` は除外し、`False` は含めます。この例では `False` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。セル B1:C1 はシリーズ名のみを供給し、A2:A3 はカテゴリ ラベル、B2:B3 は数値を供給します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # これらの 2 つのセルはシリーズ名を提供します。
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # 別々のセルがカテゴリと数値データポイントを提供します。
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

結果のシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は両方の列に対して 1 つのエントリとして表示されます。以下の画像は保存されたプレゼンテーションからレンダリングされたものです。

![北および南の値を持つ縦棒グラフ、凡例に複合シリーズ名「Product A 2026」](composite_series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得され、新しい塗りつぶしは割り当てられません。

次の例は、デフォルトシリーズそれぞれの自動色を出力します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

デフォルトのチャート スタイルの例出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマに依存します。

## **チャートシリーズの反転塗りつぶし色を設定する**

棒、縦棒、バブルシリーズの場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にして、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値の色を割り当てます。負の数はワークブック内では変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![反転した塗りつぶし色](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **特定のデータポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、対応するワークブックセルを `None` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) から取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

散布図は X と Y のセルが別々に使用され、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したままにしたい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するかについては、[Include Data from Hidden Rows and Columns](/slides/ja/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルは欠損データを表し、`0` を含むセルは既知の数値を表します。[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) を `None` に設定するとセルが空になります。数値のゼロはブランクセル設定に関係なくゼロのままです。

[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブックセルにゼロや補間値が自動で入力されることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアして、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Day 3 を本当に空にしたまま、カテゴリとデータポイントは保持します。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

各出力ファイルは保存時に割り当てたモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのケースでワークブック上で空です。

![ライン チャートで同一データ: Gap は Day 3 でラインを切断し、Zero はラインをゼロに落とし、Span は Day 2 から Day 4 を接続します。](display_blanks_as.png)

目に見える効果はチャート タイプによって異なります。折れ線チャートは 3 つのモードを比較しやすく、棒や縦棒チャートは欠損カテゴリを横断するラインがないため `SPAN` は上記のような接続セグメントを生成できません。欠損列とゼロ高さ列は見た目が似ることがあります。同様に、マーカーのみの散布図にも接続ラインはありません。すべてのチャート タイプで 3 つの異なる結果が得られるとは限りませんので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒または縦棒クラスタ間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) をグループ単位で一度設定します。値を大きくするとクラスタ間のスペースが広がり、値を小さくすると密度が高まります。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![ギャップ幅](gap_width.png)

## **よくある質問**

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズごとに同じ値構造や設定があるわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブルチャートはバブル サイズを追加します。シリーズ タイプに合わせたデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅といったオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じてアクセスされるグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新しく作成されたチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データポイント値は [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく、1つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `None` に設定して、ポイントのカテゴリ位置は保持しつつ空のポイントにします。すべてのポイントを削除したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を使用してください。このメソッドはそのシリーズ内のすべてのデータポイントを削除します。

**空のポイントはどのように表示されますか？**

結果はチャート タイプと [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) に依存します。サポートされているチャートは、ブランクをギャップとして表示したり、ゼロ値として表示したり、隣接ポイントを接続したりできます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較については、[空セルの表示を制御する](#空セルの表示を制御する) を参照してください。

**負の値はどのように書式設定されますか？**

棒、縦棒、バブルシリーズをサポートする場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値の色を設定します。個々のポイントに対しては、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) で動作を上書きできます。これらのプロパティは書式設定に影響し、保存された数値そのものは変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

特定のポイントに対しては、明示的なデータポイントの書式設定が優先されます。他のポイントは明示的なシリーズ書式設定を使用し、シリーズ書式が未定義の場合は自動的にチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅といったグループプロパティはレイアウトを制御し、ポイントレベルの書式設定上書きにはなりません。

**チャートに含められるシリーズの数に制限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を左右します。

**列が互いに近すぎる、または遠すぎる場合、何を変更すべきですか？**

適切な親シリーズ グループの [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) を設定してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタがより密集します。