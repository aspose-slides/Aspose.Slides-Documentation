---
title: Pythonでプレゼンテーションのチャートシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズのギャップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Pythonを使用してプレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに格納します。 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) は関連する値の 1 セットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。したがって、シリーズ名、カテゴリ、ポイント値は、表示テキストとしてだけでなく、[ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) に渡されるワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがそれを使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)) は、1 系列内のすべてのポイントのデフォルト外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)) は、1 ポイントのシリーズ外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。シリーズとポイントの両方の書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズの PowerPoint 表示例](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) は、2D チャートでバーや列がどれだけ重なるかを -100 から 100 パーセントで報告します。これは親シリーズ グループの設定の読み取り専用投影です。[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) を設定すると、そのグループ内のすべての互換性のあるシリーズが更新されます。このオプションは、グループ化されたバーまたは列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します。

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

## **シリーズの塗りの色を変更**

[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) を使用して、シリーズ全体のデフォルト塗りを設定します。ポイントに明示的な塗りが設定されている場合、その [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) がそのポイントのシリーズ塗りを上書きします。

以下の例は、最初のシリーズに単色の青塗りを適用します。

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

## **シリーズ名を変更**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスター化列チャート用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が含まれています。以下の例の名前定数はその構造を明示的に示しています。

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

また、[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) がすでに参照しているセルを更新することもできます。このアプローチは、既存チャートで特定の行と列を想定することを回避します。

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

### **複数セルから名前を作成するシリーズ**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のパーツがソース セルにリンクされた単一のシリーズ名にできます。

[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) を使用して名前範囲を取得し、そのコレクションを [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) に渡します。`skip_hidden_cells` 引数は非表示セルを含めるかどうかを制御します: `True` は除外し、`False` は含めます。この例では `False` を使用して名前範囲のすべてのセルを含めています。

以下の例は、1 系列と 2 データ ポイントを持つプレゼンテーションを作成します。セル B1:C1 はシリーズ名のみを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値です。

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

    # これらの 2 つのセルがシリーズ名を提供します。
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

結果として得られるシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は両方の列を 1 エントリとして表示します。下の画像は保存されたプレゼンテーションからレンダリングしたものです。

![北部と南部の値を持つ列チャート、凡例に合成シリーズ名「Product A 2026」](composite_series_name.png)

## **自動シリーズ塗り色を取得**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りが明示的に定義されていない場合に使用される色です。メソッドは計算された色を取得するだけで、新しい塗りを割り当てることはありません。

以下の例は、各デフォルトシリーズの自動色を出力します。

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

デフォルト チャート スタイルのサンプル出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマに依存します。

## **チャートシリーズの負の値用塗り色を反転**

バー、列、バブル シリーズの場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を使用して負の値を別の塗りで表示できます。通常のシリーズ塗りを単色に設定し、反転を有効にし、負の値用色を [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で割り当てます。ワークブック内の負の数値は変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシート行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値です。

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

![反転した単色塗り色](inverted_solid_fill_color.png)

1 ポイントだけに反転を有効にするには、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択されたポイントだけに有効にしています。そのポイントには負の値も割り当てられているため、効果が確認できます。

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

## **特定のデータ ポイントの値をクリア**

ポイントだけを空にし、他のポイントを残すには、その裏付けセルを `None` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートは空白設定に従ってその値を空として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y の別々のセルを使用し、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを保持したまますべてのポイントを削除したくない場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション全体を削除します。

## **空セルの表示を制御**

値を含む非表示セルは空セルとは別のケースです。非表示の行や列からデータを含めるか除外する方法は、[Include Data from Hidden Rows and Columns](/slides/ja/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルは欠損データを表し、`0` を含むセルは既知の数値を表します。セルを空にするには [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) を `None` に設定します。数値のゼロはブランク設定に関係なくゼロのままです。

[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空セル自体をゼロや補間値で埋めることはありません。

以下の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    # Day 3を実際に空のままにし、カテゴリとデータポイントを保持します。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

各出力ファイルは保存時に設定されたモードで名前が付けられます: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`。1 バージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![同一データの折れ線グラフ: Gap は Day 3 で線を切断、Zero は線をゼロに落とし、Span は Day 2 と Day 4 を接続](display_blanks_as.png)

見た目の効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、バーや列のチャートは欠損カテゴリをつなぐ線がなく、`SPAN` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ていることもあります。同様に、マーカーのみの散布図は接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないため、使用するタイプで出力を確認してください。

## **シリーズ ギャップ幅を設定**

ギャップ幅は隣接するバーまたは列クラスタ間のスペースで、バーまたは列幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく、親シリーズ グループに属します。[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) をグループに対して一度設定します。大きい値はクラスタ間のスペースを広げ、小さい値は密にします。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定は同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズ タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のあるバーまたは列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて到達したグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すると、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、各ポイントが意図したカテゴリの下にプロットされるよう、カテゴリ行とシリーズ値行を整合させてください。

**シリーズ全体ではなく 1 ポイントだけをクリアする方法は？**

該当する値セルを `None` に設定すれば、ポイントのカテゴリ位置は保持したまま空のポイントになります。シリーズ全体のポイントを削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示結果はチャート タイプと [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較は、[空セルの表示を制御](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされているバー、列、バブル シリーズの場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値用色を設定します。個別のポイントについては、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) で動作を上書きできます。これらのプロパティは書式設定に影響しますが、保存された数値は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイント書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が未定義の場合は自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ属性はレイアウトに影響し、ポイントレベルの書式設定の上書きとはなりません。

**チャートが保持できるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーション ファイルの制限、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な制限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループで [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) を設定してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタが近づきます。