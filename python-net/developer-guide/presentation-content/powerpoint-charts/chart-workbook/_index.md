---
title: Chart Workbook
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "Chart workbook, chart data, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Chart workbook in PowerPoint presentation in Python"
---

## **Chart Workbook**
### **Set WorkBook Cell as Chart DataLabel**
Aspose.Slides for Python via .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate Presentation class that represents a presentation file 
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


### **Get Chart External Data Source Workbook Path**
Aspose.Slides for Python via .NET provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Manage Worksheets**

To gain access to a worksheet collection, use the [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) property. See the Python code below. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```


## **External Workbook**
{{% alert color="primary" %}} 
Aspose.Slides for Python via .NET for 19.4 supports external workbooks as a data source for charts.
{{% /alert %}} 
### **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for Python via .NET. **ChartData.set_external_workbook()** method can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

```py
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
Using Aspose.Slides for Python via .NET, an external workbook can be assigned to a chart as a data source. For this purpose **ChartData.set_external_workbook** method has been added.

**set_external_workbook()** method can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

```py
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

The **set_external_workbook(String workbookPath, bool updateChartData)** method has been added with **updateChartData** parameter to the **ChartData** class.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***False*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **True** chart data will be updated from the target workbook as the **set_external_workbook(System::String)** method does.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```


### **Edit Chart Data**
Using Aspose.Slides for Python via .NET, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```



