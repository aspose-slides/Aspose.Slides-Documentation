---
title: 管理 Python 中的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/python-net/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Python 中管理 PowerPoint（PPT/PPTX）的图表数据系列，提供实用代码示例和最佳实践，以提升您的数据演示效果。"
---

## **概述**

本文介绍了 Aspose.Slides for Python 中 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) 的作用，重点说明了数据在演示文稿中的结构化和可视化方式。这些对象提供了定义图表中各个数据点、类别和外观参数的基础元素。通过使用 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)，开发人员可以无缝集成底层数据源并完全控制信息的显示方式，从而生成动态、数据驱动的演示文稿，清晰呈现洞察和分析。

系列是一行或一列在图表中绘制的数字。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置系列重叠**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 属性通过指定 -100 到 100 的范围，控制 2D 图表中柱形和条形的重叠程度。由于此属性关联于系列组而非单个图表系列，在系列层面上为只读。若要配置重叠值，请使用 `parent_series_group.overlap` 可读写属性，将指定的重叠应用于该组中的所有系列。

下面的 Python 示例演示了如何创建演示文稿、添加簇状柱形图、访问第一个图表系列、配置重叠设置，然后将结果保存为 PPTX 文件：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # 设置系列重叠。
        series.parent_series_group.overlap = series_overlap

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

Aspose.Slides 简化了图表系列填充颜色的自定义，帮助您突出特定数据点并创建视觉上更具吸引力的图表。这通过 [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/) 对象实现，支持多种填充类型、颜色配置和其他高级样式选项。在将图表添加到幻灯片并获取所需系列后，只需获取系列并应用相应的填充颜色。除纯色填充外，您还可以利用渐变或图案填充，以获得更灵活的设计方案。根据需求设置颜色后，保存演示文稿即可完成更新。

下面的 Python 示例展示了如何更改第一系列的颜色：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个带有默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 设置第一系列的颜色。
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![系列颜色](series_color.png)

## **重命名系列** 

Aspose.Slides 提供了简便的方法修改图表系列的名称，使数据标记更加清晰且富有意义。通过访问图表数据中的相应工作表单元格，开发人员可以自定义数据的呈现方式。当需要根据数据上下文更新或澄清系列名称时，此操作尤为有用。重命名系列后，保存演示文稿即可持久化更改。

下面的 Python 代码片段演示了该过程：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 设置第一系列的名称。
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # 将演示文稿文件保存到磁盘。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


以下 Python 代码展示了另一种更改系列名称的方式：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 设置第一系列的名称。
    series.name.as_cells[0].value = series_name

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

Aspose.Slides for Python 允许您获取绘图区域内图表系列的自动填充颜色。创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例后，可按索引获取目标幻灯片，然后使用所需类型（如 `ChartType.CLUSTERED_COLUMN`）添加图表。通过访问图表中的系列，即可获取自动填充颜色。

下面的 Python 代码详细演示了此过程：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个带默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # 获取系列的填充颜色。
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


示例输出：
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **为系列设置反转填充颜色**

当数据系列包含正负值时，所有柱形或条形使用相同颜色会导致图表难以阅读。Aspose.Slides for Python 允许您为负值自动分配反转填充颜色，使负值一目了然。本节将介绍如何启用该选项、选择合适的颜色并保存更新后的演示文稿。

下面的代码示例演示了该操作：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 添加新类别。
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # 添加新系列。
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 填充系列数据。
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # 设置系列的颜色设置。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![反转实心填充颜色](inverted_solid_fill_color.png)

您也可以仅对单个数据点而非整条系列进行颜色反转。只需访问目标 `ChartDataPoint` 并将其 `invert_if_negative` 属性设为 `True`。

下面的代码示例展示了具体做法：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **清除特定数据点的数据**

有时图表中会出现测试值、离群点或已废弃的条目，需要在不重建整个系列的情况下将其移除。Aspose.Slides for Python 允许您按索引定位任意数据点，清除其内容，并立即刷新绘图，使其余点自动迁移并重新缩放坐标轴。

下面的代码示例演示了该操作：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **设置系列间隙宽度**

间隙宽度控制相邻柱形或条形之间的空白程度——更宽的间隙突出单个类别，而更窄的间隙则呈现更紧凑的外观。通过 Aspose.Slides for Python，您可以为整条系列微调此参数，实现演示文稿所需的视觉平衡，而无需更改底层数据。

下面的代码示例展示了如何为系列设置间隙宽度：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 创建一个空的演示文稿。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个带默认数据的堆叠柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # 将演示文稿保存到磁盘。
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # 设置 gap_width 值。
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # 将演示文稿保存到磁盘。
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![间隙宽度](gap_width.png)

## **常见问题**

**单个图表可以包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际限制取决于图表的可读性以及应用程序可用的内存。

**如果簇内的柱形之间间距过近或过远怎么办？**

调整该系列（或其父系列组）的 [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) 设置。增大数值会扩大柱形之间的空间，减小数值则会使它们靠得更近。