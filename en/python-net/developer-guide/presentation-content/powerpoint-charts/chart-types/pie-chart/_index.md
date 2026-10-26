---
title: Customize Pie Charts in Presentations with Python
linktitle: Pie Chart
type: docs
url: /python-net/pie-chart/
keywords:
- pie chart
- manage chart
- customize chart
- chart options
- chart settings
- plot options
- slice color
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create and customize pie charts in Python with Aspose.Slides. Configure secondary plots, display data labels, and apply automatic slice colors in PowerPoint."
---

## **Overview**

This article explains how to work with pie charts in Aspose.Slides. It shows how to configure secondary plot options for Pie of Pie and Bar of Pie charts, and how to enable automatic slice coloring for a standard pie chart.

The examples focus on chart customization tasks such as adding a chart to a slide, adjusting series and label settings, replacing default chart data with custom categories and values, and saving the updated presentation.

## **Second Plot Options for Pie of Pie and Bar of Pie Charts**

Aspose.Slides for Python via .NET supports secondary plot options for Pie of Pie and Bar of Pie charts. These options control the size of the secondary plot and how data points are split between the two plots.

The following example creates a Pie of Pie chart in a new presentation and displays data point values as labels. The [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) property sets the secondary plot size to 149% of the main plot. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) selects percentage-based splitting, and [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) sets the threshold to 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Display values and configure the secondary plot.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

To show or hide the lines connecting the main and secondary plots in Pie of Pie and Bar of Pie charts, see [Show or Hide Series Lines](/slides/python-net/chart-series/#show-or-hide-series-lines). The setting applies to the entire series group.

### **Select Categories for the Secondary Plot**

Use custom splitting when you want to group specific categories in the secondary plot regardless of their percentage values. For example, a sales report might show Online and Events together so readers can compare these two channels, even though they account for 35% and 10% of total sales.

Set [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) to [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) and select the points through [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). The collection's [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) method accepts either a zero-based index in the series or a data point object. In this example, index 1 selects Online, and the point at index 3 selects Events. Partners is also added temporarily, then excluded using [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Replace the default data with sales by channel.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Select Online by its zero-based index and Events by its data point object.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Exclude Partners from the selection without deleting its source data.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) and Events (10) appear as separate slices in the secondary plot. In the primary plot, they are represented by one combined slice with a value of 45, alongside Retail (40) and Partners (15). Removing Partners from the custom selection keeps it in the primary plot; it does not remove the category or its value from the chart's source data.

The following image shows the saved presentation in PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Set Automatic Pie Chart Slice Colors**

Aspose.Slides for Python via .NET can automatically assign different colors to pie chart slices. The following example creates a pie chart with a centered title and replaces the default data with three quarterly categories and their values. The [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) property displays the values 20, 50, and 30 as labels, while [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) enables a distinct color for each slice.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Add a centered chart title.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Replace the default data using the first worksheet.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Show values and assign different colors to the slices.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Are the Pie of Pie and Bar of Pie variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) a secondary plot for pie charts, including the Pie of Pie and Bar of Pie types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (such as PNG) without exporting the entire presentation.
