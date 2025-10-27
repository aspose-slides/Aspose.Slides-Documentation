---
title: 在演示文稿中使用 Python 自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/python-net/chart-axis/
keywords:
- 图表坐标轴
- 垂直坐标轴
- 水平坐标轴
- 自定义坐标轴
- 操作坐标轴
- 管理坐标轴
- 坐标轴属性
- 最大值
- 最小值
- 坐标轴线
- 日期格式
- 坐标轴标题
- 坐标轴位置
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---

## **获取图表中垂直坐标轴的最大值**

Aspose.Slides for Python via .NET 允许您获取垂直坐标轴的最小值和最大值。请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 访问第一张幻灯片。  
3. 添加一个带有默认数据的图表。  
4. 获取坐标轴的实际最大值。  
5. 获取坐标轴的实际最小值。  
6. 获取坐标轴的实际主单位。  
7. 获取坐标轴的实际次单位。  
8. 获取坐标轴的实际主单位比例。  
9. 获取坐标轴的实际次单位比例。  

下面的示例代码实现了上述步骤，展示了如何在 Python 中获取所需的值：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Saves the presentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在坐标轴之间交换数据**

Aspose.Slides 允许您快速交换坐标轴之间的数据——垂直坐标轴（y 轴）上的数据会移动到水平坐标轴（x 轴），反之亦然。

下面的 Python 代码展示了如何在图表上执行坐标轴之间的数据交换任务：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Creates empty presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Switches rows and columns
    chart.chart_data.switch_row_column()
            
    # Saves presentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在折线图中禁用垂直坐标轴**

下面的 Python 代码展示了如何隐藏折线图的垂直坐标轴：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **在折线图中禁用水平坐标轴**

下面的代码展示了如何隐藏折线图的水平坐标轴：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **更改分类坐标轴**

使用 **CategoryAxisType** 属性，您可以指定首选的分类坐标轴类型（**date** 或 **text**）。下面的 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **为分类坐标轴值设置日期格式**

Aspose.Slides for Python via .NET 允许您为分类坐标轴值设置日期格式。下面的 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图表坐标轴标题的旋转角度**

Aspose.Slides for Python via .NET 允许您设置图表坐标轴标题的旋转角度。下面的 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **在分类轴或数值轴中设置位置轴**

Aspose.Slides for Python via .NET 允许您在分类轴或数值轴中设置位置轴。下面的 Python 代码展示了如何执行此任务：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **在图表数值轴上启用显示单位标签**

Aspose.Slides for Python via .NET 允许您配置图表，在其数值轴上显示单位标签。下面的 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何设置坐标轴交叉的数值（坐标轴交叉点）？**

坐标轴提供了一个[交叉设置](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)，您可以选择在零、最大分类/数值或特定数值处交叉。这对于上下移动 X 轴或强调基准线很有用。

**如何相对于坐标轴定位刻度标签（旁边、外侧、内侧）？**

将[label position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 设置为 “cross”、“outside” 或 “inside”。这会影响可读性，并有助于节省空间，尤其是在小型图表上。