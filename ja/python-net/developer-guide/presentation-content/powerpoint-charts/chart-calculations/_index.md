---
title: チャート計算
type: docs
weight: 50
url: /ja/python-net/chart-calculations/
keywords: "チャート計算, チャート要素, 要素位置, チャート値 Python, Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointチャート計算と値"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for Python via .NETは、これらのプロパティを取得するためのシンプルなAPIを提供します。これにより、チャート要素の実際の値を計算することができます。実際の値には、IActualLayoutインターフェイスを実装する要素の位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）や実際の軸の値（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）が含まれます。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **親チャート要素の実際の位置を計算する**
Aspose.Slides for Python via .NETは、これらのプロパティを取得するためのシンプルなAPIを提供します。IActualLayoutのプロパティは、親チャート要素の実際の位置に関する情報を提供します。プロパティに実際の値を設定するためには、事前にIChart.ValidateChartLayout()メソッドを呼び出す必要があります。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **チャートから情報を隠す**
このトピックは、チャートから情報を隠す方法を理解するのに役立ちます。Aspose.Slides for Python via .NETを使用すると、**タイトル、縦軸、横軸**、および**グリッド線**をチャートから隠すことができます。以下のコード例は、これらのプロパティの使用方法を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # チャートタイトルを隠す
    chart.has_title = False

    # 値軸を隠す
    chart.axes.vertical_axis.is_visible = False

    # カテゴリアクシスの可視性
    chart.axes.horizontal_axis.is_visible = False

    # 凡例を隠す
    chart.has_legend = False

    # MajorGridLinesを隠す
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # データ系列の線の色を設定する
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```