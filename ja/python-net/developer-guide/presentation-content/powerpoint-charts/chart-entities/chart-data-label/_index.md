---
title: チャートデータラベル
type: docs
url: /python-net/chart-data-label/
keywords: "チャートデータラベル, ラベル距離, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointのチャートデータラベルと距離を設定する"
---

チャートのデータラベルは、チャートデータ系列や個々のデータポイントの詳細を示します。これにより、読者はデータ系列をすぐに識別でき、チャートの理解が容易になります。

## **チャートデータラベルのデータ精度を設定する**

このPythonコードは、チャートデータラベルにおけるデータ精度を設定する方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
	chart.has_data_table = True
	chart.chart_data.series[0].number_format_of_values = "#,##0.00"

	pres.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **パーセンテージをラベルとして表示する**
Aspose.Slides for Python via .NETでは、表示されたチャートにパーセンテージラベルを設定できます。このPythonコードはその操作を示します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# プレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)
    series = chart.chart_data.series[0]
    total_for_Cat = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        cat = chart.chart_data.categories[k]
        for i in range(len(chart.chart_data.series)):
            total_for_Cat[k] += chart.chart_data.series[i].data_points[k].value.data

dataPontPercent = 0

for x in range(len(chart.chart_data.series)):
    series = chart.chart_data.series[x]
    series.labels.default_data_label_format.show_legend_key = False

    for j in range(len(series.data_points)):
        lbl = series.data_points[j].label
        dataPontPercent = series.data_points[j].value.data / total_for_Cat[j] * 100

        port = slides.Portion()
        port.text = "{0:.2f} %".format(dataPontPercent)
        port.portion_format.font_height = 8
        lbl.text_frame_for_overriding.text = ""
        para = lbl.text_frame_for_overriding.paragraphs[0]
        para.portions.add(port)

        lbl.data_label_format.show_series_name = False
        lbl.data_label_format.show_percentage = False
        lbl.data_label_format.show_legend_key = False
        lbl.data_label_format.show_category_name = False
        lbl.data_label_format.show_bubble_size = False

# チャートを含むプレゼンテーションを保存
presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **チャートデータラベルにパーセンテージ符号を設定する**
このPythonコードは、チャートデータラベルにパーセンテージ符号を設定する方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# プレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as presentation:

    # スライドのインデックスを通じて参照を取得
    slide = presentation.slides[0]

    # スライドにパーセントスタックカラムチャートを作成
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    # NumberFormatLinkedToSourceをfalseに設定
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    defaultWorksheetIndex = 0

    # チャートデータワークシートを取得
    workbook = chart.chart_data.chart_data_workbook

    # 新しい系列を追加
    series = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 1, 0.65))

    # 系列の塗りつぶし色を設定
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # LabelFormatプロパティを設定
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # 新しい系列を追加
    series2 = chart.chart_data.series.add(workbook.get_cell(defaultWorksheetIndex, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(defaultWorksheetIndex, 4, 2, 0.35))

    # 塗りつぶしタイプと色を設定
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # プレゼンテーションをディスクに書き込む
    presentation.save("SetDatalabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **軸からのラベル距離を設定する**
このPythonコードは、軸からのカテゴリ軸のラベル距離を設定する方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

	# プレゼンテーションクラスのインスタンスを作成
with slides.Presentation() as presentation:
    # スライドの参照を取得
    sld = presentation.slides[0]
    
    # スライドにチャートを作成
    ch = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 軸からのラベル距離を設定
    ch.axes.horizontal_axis.label_offset = 500

    # プレゼンテーションをディスクに書き込む
    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ラベルの位置を調整する**

軸に依存しないチャート（例：円グラフ）を作成すると、チャートのデータラベルが端に近すぎる場合があります。そのような場合、リーダー線が明確に表示されるようにデータラベルの位置を調整する必要があります。

このPythonコードは、円グラフのラベル位置を調整する方法を示しています。

```python
import aspose.slides as slides


with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 200, 200)

    series = chart.chart_data.series
    label = series[0].labels[0]

    label.data_label_format.show_value = True
    label.data_label_format.position = slides.charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)