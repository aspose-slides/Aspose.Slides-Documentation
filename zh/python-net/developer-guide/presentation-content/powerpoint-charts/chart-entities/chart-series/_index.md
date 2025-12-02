---
title: 在 Python 中管理图表数据系列
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
description: "了解如何在 Python 中使用实用代码示例和最佳实践管理 PowerPoint (PPT/PPTX) 的图表数据系列，以提升数据演示效果。"
---

## **概述**

本文描述了 Aspose.Slides for Python 中 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) 的作用，重点关注数据在演示文稿中的结构化和可视化方式。这些对象提供了定义图表中各个数据点、类别和外观参数的基础要素。通过使用 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)，开发人员可以无缝集成底层数据源，并完全控制信息的显示方式，从而生成动态、数据驱动的演示文稿，清晰传达洞察和分析。

系列是一行或一列在图表中绘制的数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置系列重叠**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) 属性通过指定 -100 到 100 的范围来控制 2D 图表中柱形和条形的重叠方式。由于此属性关联的是系列组而非单个图表系列，它在系列层面上为只读。若要配置重叠值，请使用 `parent_series_group.overlap` 读写属性，该属性会将指定的重叠值应用于该组中的所有系列。

下面是一个 Python 示例，演示如何创建演示文稿、添加簇状柱形图、访问第一个图表系列、配置重叠设置，然后将结果保存为 PPTX 文件：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # 设置系列重叠。
        series.parent_series_group.overlap = series_overlap

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

Aspose.Slides 使自定义图表系列的填充颜色变得直观，帮助您突出特定数据点并创建视觉上悦目的图表。这是通过 [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/) 对象实现的，该对象支持多种填充类型、颜色配置和其他高级样式选项。向幻灯片添加图表并访问所需系列后，只需获取该系列并应用相应的填充颜色。除了纯色填充外，您还可以利用渐变或图案填充以获得更大的设计灵活性。根据需求设置颜色后，保存演示文稿即可完成更新。

以下 Python 代码示例展示了如何更改第一个系列的颜色：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 设置第一系列的颜色。
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![The color of the series](series_color.png)

## **重命名系列**

Aspose.Slides 提供了简便的方式修改图表系列的名称，使数据标记更加清晰且有意义。通过访问图表数据中的相应工作表单元格，开发人员可以自定义数据的呈现方式。当需要根据数据上下文更新或澄清系列名称时，此修改尤为有用。重命名系列后，保存演示文稿即可保留更改。

下面的 Python 代码片段演示了此过程的实际操作。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加默认数据的簇状柱形图。
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

    # 添加默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 设置第一系列的名称。
    series.name.as_cells[0].value = series_name

    # 将演示文稿文件保存到磁盘。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


结果：

![The series name](series_name.png)

## **获取系列的自动填充颜色**

Aspose.Slides for Python 允许您获取绘图区域内图表系列的自动填充颜色。创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例后，您可以按索引获取所需幻灯片，然后使用首选类型（如 `ChartType.CLUSTERED_COLUMN`）添加图表。通过访问图表中的系列，即可获取自动填充颜色。

下面的 Python 代码详细演示了此过程。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加默认数据的簇状柱形图。
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

当数据系列同时包含正值和负值时，使用相同颜色为所有柱形或条形着色会使图表难以阅读。Aspose.Slides for Python 允许您指定反转填充颜色——对低于零的数据点自动应用的独立填充，使负值一目了然。本节将教您如何启用此选项、选择合适的颜色并保存更新后的演示文稿。

以下代码示例演示了该操作：
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

    # 设置系列的颜色属性。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以仅为单个数据点而非整个系列反转填充颜色。只需访问所需的 `ChartDataPoint` 并将其 `invert_if_negative` 属性设为 `True`。

以下代码示例展示了如何实现：
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

有时图表中会包含测试值、异常值或已废弃的条目，需要在不重建整条系列的情况下将其移除。Aspose.Slides for Python 让您可以按索引定位任意数据点，清除其内容，并立即刷新绘图，以便其余点自动移动、坐标轴自动重新缩放。

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

间隙宽度控制相邻柱形或条形之间的空白量——更大的间隙强调各个类别，而更小的间隙则呈现更密集、更紧凑的外观。通过 Aspose.Slides for Python，您可以为整个系列微调此参数，实现演示文稿所需的视觉平衡，而无需更改底层数据。

以下代码示例展示了如何为系列设置间隙宽度：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 创建一个空的演示文稿。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个默认数据的堆积柱形图。
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

![The gap width](gap_width.png)

## **FAQ**

**单个图表能包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际限制取决于图表的可读性以及应用程序可用的内存。

**如果簇内的柱形之间过于接近或过于分散怎么办？**

调整该系列（或其父系列组）的 [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) 设置。增大数值会扩大柱形之间的间距，减小数值则会使它们更靠近。