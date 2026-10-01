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
## **概述**

本文说明如何使用 Aspose.Slides for Python via .NET 自定义图表坐标轴。它涵盖了计算坐标轴值、交换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式化、标题旋转、坐标轴定位以及显示单位。

## **在图表上获取垂直坐标轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)并添加一个带默认数据的面积图。在读取计算后的坐标轴值之前调用[validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)，以确保图表布局为最新。

读取[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/)和[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)以获取坐标轴的上下限，读取[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/)和[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)以获取刻度间隔。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/)和[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)提供时间单位比例，适用于日期坐标轴。示例将这些值存储在局部变量中并保存图表。

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

## **在坐标轴之间交换数据**

使用[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)来交换图表数据中系列和类别的角色。每个原来的类别会变为系列，每个原来的系列会变为类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例在交换行列之前，使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)将默认数据绑定到`Sheet1!A1:D5`，包括标题行和类别列。它保存了一个包含四个系列和三个类别的图表。

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

## **禁用折线图的垂直坐标轴**

将垂直坐标轴的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)设为`False`即可隐藏它。示例创建一个带默认数据的折线图，并在垂直坐标轴隐藏的情况下保存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **禁用折线图的水平坐标轴**

将水平坐标轴的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)设为`False`即可隐藏它。示例创建一个带默认数据的折线图，并在水平坐标轴隐藏的情况下保存。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **更改类别坐标轴**

使用[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)来选择日期或文本类别坐标轴。此示例需要`ExistingChart.pptx`，其中第一张幻灯片的第一形状是图表，且类别单元格包含 Excel 数字日期值。它将水平坐标轴更改为日期坐标轴。将[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)设为`False`，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)设为`1`，并将[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)设为月份，可使主刻度以一个月为间隔。

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

## **控制类别坐标轴标签间隔**

当图表拥有大量类别时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。将[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)设为`False`，然后将[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)设为所需的类别间隔。对于按正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

间隔为`3`时会每隔三个标签显示一次，在显示的标签之间隐藏两个标签。它不会删除对应的列。自动间距会根据可用空间选择间隔；未必会显示每个标签。

刻度线有单独的控制。将[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)设为`False`并使用[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)设置其间隔。例如，`1`会在每个类别间隔处保留刻度线，而标签仅每隔三个类别显示一次。将[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)设为可见样式以便观察结果。将任一自动间距属性重新设为`True`，图表将再次自行选择间隔。

下面的独立示例创建 24 个类别和一个系列，然后在`CategoryAxisIntervals.pptx`中保存三张幻灯片：自动间距、带独立刻度线的手动标签间距以及恢复的自动间距。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

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

    # 幻灯片 2：显示每第三个标签，但为每个类别保留刻度线。
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 幻灯片 3：让图表再次自行选择两个间隔。
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**自动间距（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。自动结果可能随图表大小、字体和渲染器而变化。

![自动类别标签间距，显示所有 24 列可见](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每隔三个标签在一行显示，而刻度线仍保持在每个类别间隔。所有 24 列，包括没有标签的列，仍以相同的数值可见。幻灯片 3 恢复了上图所示的自动外观。

![手动类别标签间隔为三，显示所有 24 列可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对文本类别坐标轴（例如柱形图、折线图、面积图或条形图的类别坐标轴）使用此类别计数间隔。在柱形图中，它是水平坐标轴。在水平条形图中，类别坐标轴是垂直的，因此将这些设置应用于[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度间距同样适用于具有系列坐标轴的图表。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)指定数值间隔，例如，当坐标轴从零开始时，`10`的主单位会在 0、10、20 等位置产生刻度。而类别标签间隔`3`则是按类别位置计数， 与其数据值无关。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请使用基于时间的主单位和比例， 如[更改类别坐标轴](#change-a-category-axis) 中所述。

## **设置类别坐标轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引`0`）中。将[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)设为日期坐标轴，禁用[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，并将`yyyy`赋给[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，使类别标签独立于单元格格式显示四位年份。

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

## **为图表坐标轴标题设置旋转角度**

在垂直坐标轴上启用[has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供标题文本，并设置[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)以旋转标题。角度以度为单位；本示例保存了一个列图，其数值坐标轴标题旋转了 90 度。

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

## **设置类别或数值坐标轴的位置**

使用[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/)来控制数值坐标轴是穿过类别坐标轴的类别之间还是在类别刻度标记处。此属性适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为`True`并保存结果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **在图表数值坐标轴上设置显示单位**

将[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)设定可在不更改底层数据的情况下缩放数值坐标轴的标签。将[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/)设为`MILLIONS`时，60000000 的值会显示为 60。示例创建了一个柱形图并将其垂直坐标轴的显示单位设为百万。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何设置坐标轴的交叉值（坐标轴交叉）？**

使用[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)选择交叉行为。若要指定数值交叉点，设置[cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。这些设置可让您将坐标轴交叉移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**

使用[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)（`LOW`、`HIGH`、`NEXT_TO`或`NONE`）通过[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/)设置刻度标签位置。若要控制刻度线本身，请使用[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)或[minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)；它们与标签位置独立。