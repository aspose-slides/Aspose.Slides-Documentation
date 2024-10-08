---
title: 图表坐标轴
type: docs
url: /zh/python-net/chart-axis/
keywords: "PowerPoint 图表坐标轴, 演示文稿图表, Python, 操作图表坐标轴, 图表数据"
description: "在 Python 中编辑 PowerPoint 图表坐标轴"
---

## **获取图表垂直坐标轴的最大值**
Aspose.Slides for Python via .NET 允许您获取垂直坐标轴的最小值和最大值。请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 获取坐标轴上的实际最大值。
1. 获取坐标轴上的实际最小值。
1. 获取坐标轴上的实际主要单位。
1. 获取坐标轴上的实际次要单位。
1. 获取坐标轴上的实际主要单位刻度。
1. 获取坐标轴上的实际次要单位刻度。

以下示例代码—上述步骤的实现—向您展示如何在 Python 中获取所需值：

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
	
	# 保存演示文稿
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **在坐标轴之间交换数据**
Aspose.Slides 允许您快速交换坐标轴之间的数据—垂直坐标轴（y 轴）上的数据移动到水平坐标轴（x 轴），反之亦然。

以下 Python 代码向您展示如何在图表的坐标轴之间执行数据交换任务：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建空演示文稿
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # 切换行和列
    chart.chart_data.switch_row_column()
            
    # 保存演示文稿
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **禁用线图的垂直坐标轴**

以下 Python 代码向您展示如何隐藏线图的垂直坐标轴：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **禁用线图的水平坐标轴**

以下代码向您展示如何隐藏线图的水平坐标轴：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **更改类别坐标轴**

使用 **CategoryAxisType** 属性，您可以指定所需的类别坐标轴类型（**日期**或**文本**）。以下 Python 代码演示了该操作：

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

## **设置类别坐标轴值的日期格式**
Aspose.Slides for Python via .NET 允许您为类别坐标轴值设置日期格式。该操作在以下 Python 代码中演示：

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
Aspose.Slides for Python via .NET 允许您设置图表坐标轴标题的旋转角度。该 Python 代码演示该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **在类别或数值坐标轴中设置位置坐标轴**
Aspose.Slides for Python via .NET 允许您在类别或数值坐标轴中设置位置坐标轴。以下 Python 代码展示了如何执行该任务：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **启用图表数值坐标轴的显示单位标签**
Aspose.Slides for Python via .NET 允许您配置图表以在其图表数值坐标轴上显示单位标签。该 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```