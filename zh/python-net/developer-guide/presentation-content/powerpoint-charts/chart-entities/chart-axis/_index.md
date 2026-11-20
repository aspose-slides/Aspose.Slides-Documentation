---
title: 使用 Python 在演示文稿中自定义图表坐标轴
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
## **概述**

本文介绍如何使用 Aspose.Slides for Python via .NET 自定义图表坐标轴。内容涉及计算得到的坐标轴值、交换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、坐标轴定位、显示单位以及对数缩放。

## **获取图表纵向轴的最大值**

创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 并添加一个带默认数据的面积图。读取计算后的坐标轴值之前，请先调用 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 以确保图表布局是最新的。

读取坐标轴限制的 [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) 和 [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)，以及刻度间隔的 [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) 和 [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) 和 [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) 提供时间单位刻度，适用于日期坐标轴。示例将这些值存入本地变量并保存图表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **交换坐标轴之间的数据**

使用 [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 交换系列和类别在图表数据中的角色。每个原来的类别会变成系列，每个原来的系列会变成类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例在切换行列之前，使用 [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) 将默认数据绑定到 `Sheet1!A1:D5`（包含标题行和类别列），并生成一个拥有四个系列和三个类别的图表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **反转坐标轴的绘制顺序**

使用 [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) 可反转类别轴或数值轴。例如，水平条形图可以按照工作表中的顺序从上到下显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向，但不会对工作簿数据进行排序或重新排列。相比之下，[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) 交换的是系列和类别的角色。

下面的示例创建一个包含三个阶段和一个系列的水平条形图，并保存包含三张幻灯片的演示文稿：正常顺序、类别反转、数值反转。每个副本使用相同的数据集，仅在对应的副本中反转一个坐标轴。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # 幻灯片 2：在顶部显示第一个类别。
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # 保持水平数值轴在底部。
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 幻灯片 3：仅反转水平数值刻度。
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

反转坐标轴还可以将垂直坐标轴移动到绘图区域的另一侧。[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，将其设置为 `MAXIMUM`，则在反转的类别轴上保持水平数值轴位于底部。若需指定特定交叉点，请使用 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。在更改方向时请检查交叉设置，尤其是图表已经拥有自定义交叉点的情况。将 `is_plot_order_reversed` 设回 `False` 可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别轴和数值轴顺序正常](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值轴反转且零位于右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部；数值从左向右递增。 | Planning、Development、Testing 从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左递增。类别轴在右侧零点交叉。 |

## **为折线图禁用纵向坐标轴**

将垂直坐标轴的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 设置为 `False` 即可隐藏。示例创建一个默认数据的折线图并保存为隐藏纵向坐标轴的演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **为折线图禁用水平坐标轴**

将水平坐标轴的 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) 设置为 `False` 即可隐藏。示例创建一个默认数据的折线图并保存为隐藏水平坐标轴的演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **显示或隐藏图表网格线**

读取 [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) 和 [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) 可判断坐标轴显示哪些网格线。这两个属性为只读。要显示次要网格线，请在 [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) 中将线条填充设置为实体填充并选择可见颜色。要隐藏，將填充类型设为 `FillType.NO_FILL`。对主要网格线使用 [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`。更改填充不会影响坐标轴的可见性和刻度标记。

此聚类柱形图的垂直坐标轴默认显示主要网格线、隐藏次要网格线。示例先将次要网格线显示为橙色，随后再次隐藏后保存演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| 次要网格线已启用 | 次要网格线已隐藏 |
| --- | --- |
| ![橙色次要网格线位于垂直坐标轴的主要网格线之间](minor-gridlines-enabled.png) | ![仅显示主要网格线的同一柱形图](minor-gridlines-hidden.png) |

## **更改类别坐标轴**

将 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 设置为日期或文本类别坐标轴。本示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一形状是图表，类别单元格包含 Excel 数字日期值。示例将水平坐标轴改为日期坐标轴。将 [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) 设为 `False`，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 设为 `1`，并将 [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) 设为月份，可将主刻度设置为每月一次。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

### **根据数据确定类别坐标轴类型**

在填充类别后调用 [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/)，随后读取 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 以检查选择。该方法在调用时确定类型；不会启用后续数据更改时重新评估的持久模式。替换类别后请再次调用。

下面的示例创建一个文本类别的图表并打印 `TEXT`。随后将类别单元格的值替换为日期并再次调用该方法，打印 `DATE`。日期以 OLE Automation 数值存储，这里计算为自 1899 年 12 月 30 日起的天数，而不是日期字符串。使用 [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) 控制这些值的显示方式；它不会把文本转换为数值日期。更多类别单元格信息请参见 [Chart Workbook](/slides/zh/python-net/chart-workbook/)。

在已知输入包含文本类别或数值日期时使用自动确定；如本示例所示。对于普通数值标签、混合类别或空数据，请显式设置 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 以匹配预期含义。仅数值本身并不能确定类别代表日期。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 文本

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # 日期

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **控制类别坐标轴标签间隔**

当图表包含大量类别时，可通过减少可见标签数量来提升可读性，而不删除类别或数据点。将 [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) 设为 `False`，随后将 [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) 设为所需的类别间隔。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

间隔为 `3` 时每隔两个标签显示一次标签，但对应列仍然存在。自动间隔会根据可用空间选择间隔，未必显示所有标签。

刻度线有独立的控制。将 [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) 设为 `False`，并使用 [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) 设置其间隔。例如，将 `1` 保持在每个类别间隔都有刻度线，而标签仅每第三个类别显示一次。将 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 设为可见样式以便观察效果。将任一自动间隔属性恢复为 `True`，图表会重新选择间隔。

下面的独立示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、手动标签间隔（刻度线独立）以及恢复自动间隔。两个副本保留原始图表数据。无需输入演示文稿。水平标签文字使密度差异一目了然。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # 幻灯片 2：显示每三个标签，但保持每个类别都有刻度线。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 幻灯片 3：让图表再次选择两个间隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自动间隔（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行显示两行。自动结果会随图表尺寸、字体和渲染器而变化。

![自动类别标签间隔，所有 24 列均可见](category-axis-automatic.png)

**手动间隔（幻灯片 2）：** 每隔三个标签显示一次，且刻度线仍保持在每个类别间隔。所有 24 列（包括未标记的列）仍然可见且值保持不变。幻灯片 3 恢复为上图所示的自动外观。

![手动标签间隔为三，所有 24 列均可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

此类别计数间隔适用于文本类别坐标轴，如柱形图、折线图、面积图或条形图的类别轴。在柱形图中，它是水平轴；在水平条形图中，类别轴是垂直的，因此请将这些设置应用于 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度间隔同样适用于拥有系列坐标轴的图表。

请勿使用类别标签间隔来设置数值轴的数值尺度。在数值轴上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) 指定数值差，例如 `10` 在从零开始的轴上产生 0、10、20…的刻度。类别标签间隔 `3` 仅计数类别位置，与数据值无关。散点图和气泡图使用数值轴而非文本类别轴。对于日期轴，请参考 [更改类别坐标轴](#更改类别坐标轴) 中的基于时间的主单位和尺度。

## **设置类别坐标轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中。将 [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) 设为日期轴，禁用 [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，并将 `yyyy` 赋给 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，从而使类别标签独立于单元格格式显示四位数年份。

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **为坐标轴标题设置旋转角度**

在垂直坐标轴上启用 [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供标题文本，并将 [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 设置为所需角度。角度以度数计；本示例将列形图的数值轴标题旋转 90 度后保存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **在类别轴或数值轴上设置坐标轴位置**

使用 [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) 控制数值轴是跨越类别之间还是在类别刻度处与类别轴相交。此属性适用于类别轴。示例将在柱形图的水平类别轴上将其设为 `True` 并保存结果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **在数值轴上设置显示单位**

将 [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) 设置为在不改变底层数据的情况下对数值轴标签进行缩放。配合 [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) 为 `MILLIONS`，60,000,000 将显示为 60。示例创建柱形图并将其垂直轴的显示单位设为百万。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **配置对数数值轴**

当正值跨越多个数量级时，对数数值轴非常有用。例如，某服务在五个时间段内的请求量分别为 10、100、1,000、10,000、100,000。线性尺度下，较小的值会聚集在靠近零的位置。对数尺度使相对增长更易比较：相等的距离代表相等的比例而非相等的差值。

在数值轴上将 [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) 设为 `True`，并使用 [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) 选择基数。这仅改变现有值的显示方式，不会改动数据或添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值轴和基数**

对于折线图或柱形图，数值轴为 [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。对于水平条形图，则为 [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)。散点图和气泡图拥有两个数值轴，分别对应 X 轴（水平）和 Y 轴（垂直），或两者皆可。请勿在类别轴上应用对数缩放。

默认对数基数为 `10`。对于 PPTX 图表，基数可取 `2` 至 `1000`（含），亦支持小数基数如 `2.5`。使用基数 `10` 时，10、100、1,000、10,000 等幂次等距分布。

### **对比线性和对数缩放**

下面的独立示例在第一张幻灯片创建包含五个请求计数的折线图，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值轴。两张幻灯片保留相同数据。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 保持第一张幻灯片为线性，仅更改副本的数值轴比例。
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**线性尺度（幻灯片 1）：** 等距的垂直距离代表请求计数的等差。最大值主导图表，导致较小值难以辨认。

![折线图在 PowerPoint 中使用线性数值轴显示五个请求计数](value-axis-linear.png)

**对数尺度（幻灯片 2）：** 等距的垂直距离代表等比例。每个周期的请求量是前一个的十倍，因而在基数为 10 的尺度上形成一条直线上升线。轴标签仍显示原始的请求计数。

![相同的五个请求计数在 PowerPoint 中使用基数为 10 的对数数值轴](value-axis-logarithmic.png)

### **处理零值和负值**

对数尺度只能显示严格正数。启用前请检查数据。如零或负值具有意义，请保留线性尺度或单独显示。若在分析中排除这些值，请说明原因。不要悄悄将其替换为小的正数，因为这会改变数据含义。对数轴的手动最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴跨越另一个坐标轴的数值（坐标轴交叉）？**

使用 [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) 选择交叉行为。若要指定数值交叉点，请设置 [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。这些设置可将坐标轴交叉位置移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**

使用 [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) 并结合 [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)：`LOW`、`HIGH`、`NEXT_TO` 或 `NONE`。若要控制刻度线本身，请使用 [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) 或 [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，它们与标签位置独立。