---
title: Python を使用したプレゼンテーションのチャート データ ラベルの管理
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **概要**

データ ラベルはチャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの読み取り、カテゴリ 軸ラベルの間隔調整、円グラフラベルの位置設定方法について説明します。

## **チャート データ ラベルのデータ精度を設定する**

シリーズの値を書式設定するには、[number_format_of_values](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/number_format_of_values/) を使用します。この例では、デフォルト データで折れ線グラフを作成し、データ テーブルを表示し、最初の系列に値ラベルを有効にします。書式 `#,##0.00` は千位区切りと小数点以下 2 桁を表示し、基になる値は変更しません。

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

## **ラベルとしてパーセンテージを表示する**

積み上げ縦棒グラフでは、各値をカテゴリ合計に対するパーセンテージとして計算し、テキストを[text_frame_for_overriding](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) に割り当てます。この例ではデフォルトのチャート データを使用し、8 ポイントのフォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外され、ゼロ除算を防ぎます。チャート データが変更された場合は、カスタム ラベル テキストを再計算してください。

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

## **チャート データ ラベルでパーセンテージ記号を設定する**

値が分数として格納されている場合、[number_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabelformat/number_format/) を使用してパーセンテージを表示します。[is_number_format_linked_to_source](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) を `False` に設定すると、ラベルの書式が元のセルとは独立して適用されます。

この例では、4 つのカテゴリにわたる赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両方の系列は白色の 10 ポイント ラベル テキストを使用します。

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

## **データ ラベルの実際のテキストを取得する**

データ ラベルの設定で生成されるテキストを取得するには、[get_actual_label_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) を使用します。これは、レポート用にラベルを抽出したり、プレゼンテーションの内容を検索したり、生成されたチャートを検証したりする場合に便利です。以下の例では、デフォルトの[data label format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabelformat/) が各カテゴリ名、系列名、値を組み合わせています。あるポイントは値をパーセンテージとして書式設定し、別のポイントは[text_frame_for_overriding](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) からカスタム テキストを使用します。

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

データ ポイントに格納されている数値は `0.75` のままです。ラベルがカテゴリ名と系列名とともに `75%` を表示していてもです。カスタム テキストは生成されたラベル テキストを置き換えます。[get_actual_label_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) はいずれの場合でも結果のラベル文字列を返します。表示ラベルのみを抽出したい場合は、上記のように[is_visible](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/is_visible/) を個別に確認してください。

## **ラベルと軸の距離を設定する**

[label_offset](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/axis/label_offset/) を使用して、カテゴリ軸ラベルと軸との間の距離を制御します。この値は軸ラベルの最大フォントサイズのパーセンテージです。この例では、集合縦棒グラフを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

円グラフでは、データ ラベルの位置を調整して間隔を改善し、リーダー ラインのスペースを確保します。

この例では、最初のデータ ポイントの値を表示し、そのラベルをスライスの外側に配置し、[x](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/x/) と[y](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/datalabel/y/) のオフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対して相対的です。

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

![調整されたデータ ラベル位置の円グラフ](pie-chart-adjusted-label.png)

## **よくある質問**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォントサイズの縮小を組み合わせます。必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントのラベルのみを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の場合は表示をオフにします。

**PDF/画像にエクスポートする際にラベルスタイルの一貫性を保つにはどうすればよいですか？**

フォントファミリとサイズを明示的に設定し、フォントがレンダリング環境で利用可能であることを確認してフォールバックを防ぎます。