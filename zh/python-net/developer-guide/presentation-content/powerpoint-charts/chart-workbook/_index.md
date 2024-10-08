---
title: 图表工作簿
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "图表工作簿, 图表数据, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python中的PowerPoint演示文稿图表工作簿"
---

## **从工作簿设置图表数据**

Aspose.Slides提供了一些方法，可以让您读取和写入图表数据工作簿（包含用Aspose.Cells编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或必须具有类似于源的结构。

以下Python代码演示了一个示例操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation类 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "标签0单元格值")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "标签1单元格值")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "标签2单元格值")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **将工作簿单元格设置为图表数据标签**

1. 创建[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有一些数据的气泡图表。
1. 访问图表系列。
1. 将工作簿单元格设置为数据标签。
1. 保存演示文稿。

以下Python代码显示了如何将工作簿单元格设置为图表数据标签：xxx

```python

```

## **管理工作表**

以下Python代码演示了使用`worksheets`属性访问工作表集合的操作：

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **指定数据源类型**

以下Python代码显示了如何为数据源指定类型：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "文本字符串"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "新单元格")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **外部工作簿**

{{% alert color="primary" %}} 
在[Aspose.Slides for .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/)中，我们实现了将外部工作簿作为图表数据源的支持。
{{% /alert %}} 

### **创建外部工作簿**

使用**`IChartData`**的一些方法，您可以从头开始创建外部工作簿或使内部工作簿外部化。

以下Python代码演示了外部工作簿创建过程：

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

### **设置外部工作簿**

使用**`chartData.set_external_workbook`**方法，您可以将外部工作簿分配给图表作为其数据源。此方法还可用于更新外部工作簿的路径（如果后者已被移动）。

虽然您无法编辑存储在远程位置或资源中的工作簿中的数据，但仍然可以将这些工作簿用作外部数据源。如果提供了外部工作簿的相对路径，则会自动转换为完整路径。

以下Python代码显示了如何设置外部工作簿：

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# 文档目录的路径。
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

`chart_data`参数（在`set_external_workbook`方法下）用于指定是否加载Excel工作簿。

* 当`chart_data`值设置为`false`时，仅更新工作簿路径——图表数据将不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时，您可能希望使用此设置。
* 当`chart_data`值设置为`true`时，图表数据将从目标工作簿更新。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **获取图表外部数据源工作簿路径**

1. 创建[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)类的实例。
1. 通过索引获取幻灯片的引用。
1. 为图表形状创建一个对象。
1. 创建一个表示图表数据源的源（`ChartDataSourceType`）类型的对象。
1. 根据源类型与外部工作簿数据源类型相同的相关条件指定。

以下Python代码演示了该操作：

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **编辑图表数据**

您可以像更改内部工作簿内容一样编辑外部工作簿中的数据。当无法加载外部工作簿时，会抛出异常。

以下Python代码是描述的过程的实现：

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```