---
title: Chart Workbook
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "Chart workbook, chart data, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Chart workbook in PowerPoint presentation in Python"
---

## **Set Chart Data from Workbook**

Aspose.Slides provides some methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This Python code demonstrates a sample operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiates a Presentation class that represents a presentation file 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "Label 0 cell value")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "Label 1 cell value")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "Label 2 cell value")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Set WorkBook Cell as Chart DataLabel**

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This Python code shows you to set a workbook cell as a chart data label: xxx

```python

```

## **Manage Worksheets**

This Python code demonstrates an operation where the `worksheets` property is used to access a worksheet collection:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **Specify Data Source Type**

This Python code shows you how to specify a type for a data source: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data._series
    
    point = series[0].data_points.get_or_create_data_point_by_idx(2)
    point = series[0].data_points.get_or_create_data_point_by_idx(4)

    # set data source type as "double literals"
    point.value._data_source_type = slides.charts.DataSourceType.DOUBLE_LITERALS
    point.value.as_literal_double = 5

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides for .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**

Using some methods from **`IChartData`**, you can either create an external workbook from scratch or make an internal workbook external.

This Python code demonstrates the external workbook creation process:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **Set External Workbook**

Using the **`chartData.set_external_workbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This Python code shows you how to set an external workbook:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# The path to the documents directory.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

The `chart_data` parameter (under the `set_external_workbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `chart_data` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `chart_data` value is set to `true` , the chart data gets updated from the target workbook.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Get Chart External Data Source Workbook Path**

1. Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Create an object for the chart shape.
1. Create an object for the source (`ChartDataSourceType`) type that represents the chart's data source.
1. Specify the relevant condition based on the source type being the same as the external workbook data source type.

This Python code demonstrates the operation:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This Python code is an implementation of the described process:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```