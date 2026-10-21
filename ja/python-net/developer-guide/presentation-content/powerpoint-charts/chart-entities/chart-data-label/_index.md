---
title: Python でプレゼンテーションのチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/python-net/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、スライドをより魅力的にする方法を学びます。"
---
## **概要**

データ ラベルは、チャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、および円グラフラベルの配置方法について説明します。

## **チャート データ ラベルの数値精度の設定**

シリーズの値の書式設定には [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) を使用します。この例では、デフォルト データで折れ線グラフを作成し、データ テーブルを表示し、最初の系列に値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示しますが、基になる値は変更しません。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

チャートに埋め込まれたワークブックの数値セルの書式設定については、[Set Custom Number Formats for Workbook Cells](/slides/ja/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells) を参照してください。その例では、格納された数値を保持しながら、元のセル書式に従った値ラベルも示しています。

## **パーセンテージをラベルとして表示**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対する割合として計算し、そのテキストを [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) に割り当てます。この例ではデフォルトのチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外して除算ゼロを回避します。チャート データが変更された場合は、カスタム ラベル テキストを再計算してください。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート データ ラベルにパーセンテージ記号を設定**

値が分数として格納されている場合は、[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) を使用してパーセンテージを表示します。[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) を `False` に設定すると、ラベルの書式が元セルとは独立して適用されます。

この例では、4 つのカテゴリに対して赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値は合計で 1 になります。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両系列とも白色でフォントサイズ 10 ポイントのラベル テキストを使用します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **データ ラベルの実際のテキストを取得**

[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) を使用して、データ ラベル設定によって生成されたテキストを取得します。これは、レポート用にラベルを抽出したり、プレゼンテーションの内容を検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) が各カテゴリ名、系列名、値を組み合わせています。あるデータ ポイントは値をパーセンテージとして書式設定し、別のポイントは [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) からカスタム テキストを使用しています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

データ ポイントに格納されている数値は `0.75` のままで、ラベルがカテゴリ名と系列名とともに `75%` と表示されても変わりません。カスタム テキストは生成されたラベル テキストを置き換えます。[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) はいずれの場合でも結果のラベル文字列を返します。表示されているラベルのみを抽出したい場合は、上記のように [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) を別途確認してください。

## **軸の最大値を超えるデータ ラベルの制御**

軸範囲を手動で制限すると、いくつかのデータ ポイントが最大値を超えることがあります。[show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの可視性を変更しますが、軸範囲や基になるデータ値は変更しません。

以下の例では、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。縦軸の [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) を `False` に、[max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) を 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、同じスライドのコピーではそれらを無効にします。両スライドは `DataLabelsOverMaximum.pptx` に保存されます。

[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) で値ラベルを有効にします。チャートレベルの設定だけでは値の表示が自動的に有効になるわけでも、個々のラベルの非表示設定を上書きするわけでもありません。この例では、シリーズ全体の値を有効にし、[position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) を使用して各列の外側端にラベルを配置します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

以下の画像は、Microsoft PowerPoint でレンダリングされた保存されたスライドを示しています。`True` の場合、ラベル **120** が上部境界に表示され、`False` の場合は非表示になります。ラベル **60** は引き続き表示され、軸の最大値は **100** のままで、2 番目のデータ ポイントはどちらの場合も **120** のままです。

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は、値軸を持つ 2D 縦棒グラフを使用しています。値軸を持たない円グラフやドーナツ グラフなどのチャートには、このように軸の最大値を制限する概念がありません。
{{% /alert %}}

## **軸からのラベル距離の設定**

[label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) を使用して、カテゴリ軸ラベルと軸との間隔を制御します。値は軸ラベルの最大フォントサイズのパーセンテージです。この例では、クラスタ化縦棒グラフを作成し、横軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随したラベルではなく、カテゴリ軸ラベルに影響します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ラベル位置の調整**

円グラフでは、データ ラベルの位置を調整して間隔を改善し、リーダーラインのスペースを確保します。

この例では、最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) と [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) のオフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **リーダーラインの書式設定**

円グラフのラベルがスライスの外側にある場合、リーダーラインは各値と対応するスライスを結び付けるのに役立ちます。対照的な色とやや太めの線にすると、接続が把握しやすくなり、透明度と破線スタイルにすると線が目立ちにくくなります。

シリーズのデータ ラベル コレクションレベルでリーダーラインを書式設定するには、[leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) を使用します。`series.labels.leader_lines_format.line` の設定は個々のラベルではなく、コレクション全体に適用されます。

この例では、デフォルト データの円グラフを作成し、スライスの外側に値を表示し、[show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) を有効にします。[x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) と [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) のオフセットを使用して、2 つのラベルをスライスからさらに離すように移動させます。オフセットはチャートの幅と高さの比率で表されます。入力プレゼンテーションは必要ありません。

ラインの [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) は、255 のうち 191 のアルファ値を持つ不透明度約 25% の単色ブルーを設定します。[width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) は太さを 2 ポイントにし、[dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) で破線にします。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # ラベル2つをスライスからさらに離す
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

リーダーラインを有効にしても、すべてのラベルにラインが表示されるわけではありません。可視性はラベルの配置やチャートのレイアウト動作に依存します。この例では、離れた位置にある 2 つのラベルにはリーダーラインが表示され、スライスに近いラベルには不要です。

以下の画像は、Aspose.Slides でレンダリングされた保存された `FormattedLeaderLines.pptx` を示しています。

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **縦棒グラフの上部に複数行のデータ ラベルを追加**

この例では、プロット領域の上部に 2 行のデータ ラベルを持つ縦棒グラフを作成します。Series A は可視列を表示し、Series B と Series C が追加のラベルを提供します。これらの列は塗りつぶしとアウトラインを削除して非表示にします。[overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) プロパティにより、3 つの系列が同じカテゴリ中心に揃えられます。

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) の設定でラベル行のスペースを確保します。[validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) がデフォルト位置を計算した後、[x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) と [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) は水平揃えを保持し、垂直オフセットを適用してラベルを 2 行に配置します。数値は系列の値にリンクしたデータ ラベルのままで、行見出しだけが別個のテキスト シェイプです。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # B と C の列を非表示にしますが、データ ラベルは保持します。
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # すべての系列を同じカテゴリ中心に揃えます。
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # このコンパクトな例ではグリッド線を減らします。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # プロット上部に 2 行のデータ ラベル用スペースを確保します。
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # デフォルトの水平位置を保持します。Y は次からのオフセットです
            # デフォルトのラベル位置で、チャートの高さの比率で表されます。
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # 行見出しだけが別個のテキスト シェイプです。
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**  
自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、いくつかの項目（例：カテゴリ）を非表示にするか、極端な値や重要なポイントのみラベルを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**  
ラベルを有効にする前にデータポイントをフィルタリングし、定義したルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際にラベルのスタイルを一貫させるにはどうすればよいですか？**  
フォントファミリーとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防ぎます。