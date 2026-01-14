---
title: Optimize Chart Calculations for Presentations in Python
linktitle: Chart Calculations
type: docs
weight: 50
url: /python-net/chart-calculations/
keywords:
- chart calculations
- chart elements
- element position
- actual position
- child element
- parent element
- chart values
- actual value
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Understand chart calculations, data updates, and precision control in Aspose.Slides for Python via .NET for PPT, PPTX and ODP, with practical code examples."
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for Python via .NET provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that inherit [IActualLayout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/iactuallayout/) class (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

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



## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for Python via .NET provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

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



## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Python via .NET you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Hiding chart Title
    chart.has_title = False

    # Hiding Values axis
    chart.axes.vertical_axis.is_visible = False

    # Category Axis visibility
    chart.axes.horizontal_axis.is_visible = False

    # Hiding Legend
    chart.has_legend = False

    # Hiding MajorGridLines
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Setting series line color
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Do external Excel workbooks work as a data source, and how does that affect recalculation?**

Yes. A chart can reference an external workbook: when you connect or refresh the external source, formulas and values are taken from that workbook, and the chart reflects the updates during open/edit operations. The API lets you [specify the external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) path and manage the linked data.

**Can I compute and display trendlines without implementing regression myself?**

Yes. [Trendlines](/slides/python-net/trend-line/) (linear, exponential, and others) are added and updated by Aspose.Slides; their parameters are recalculated from the series data automatically, so you don’t need to implement your own calculations.

**If a presentation has multiple charts with external links, can I control which workbook each chart uses for computed values?**

Yes. Each chart can point to its own [external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), or you can create/replace an external workbook per chart independently of the others.
