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

本文介绍如何使用 Aspose.Slides for Python via .NET 自定义图表坐标轴。内容包括计算坐标轴值、交换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、坐标轴位置、显示单位以及对数缩放。

## **获取图表垂直轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)并添加一个带默认数据的面积图。读取计算坐标轴值之前，请先调用[validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)，以确保图表布局是最新的。

读取[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/)和[actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/)以获取坐标轴的上下限，读取[actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/)和[actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/)以获取刻度间隔。[actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/)和[actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/)提供时间单位比例，适用于日期坐标轴。示例将这些值存入本地变量并保存图表。

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

## **在轴之间交换数据**

使用[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/)交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。此操作改变数据的分组方式，但不会交换水平和垂直坐标轴。示例使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)将默认数据绑定到`Sheet1!A1:D5`（包括标题行和类别列），然后再交换行列。最终保存的图表包含四个系列和三个类别。

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

## **禁用折线图的垂直轴**

将垂直坐标轴的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)设为`False`即可隐藏它。示例创建一个带默认数据的折线图，并在保存时隐藏垂直轴。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **禁用折线图的水平轴**

将水平坐标轴的[is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/)设为`False`即可隐藏它。示例创建一个带默认数据的折线图，并在保存时隐藏水平轴。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **更改类别轴**

通过设置[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)来选择日期或文本类别轴。该示例需要`ExistingChart.pptx`，其中第一张幻灯片的第一张形状为图表，类别单元格包含 Excel 数字日期值。示例将水平轴更改为日期轴。将[is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/)设为`False`，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)设为`1`，并将[major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/)设为`months`，即可在每个月的间隔放置主刻度线。

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

## **控制类别轴标签间隔**

当图表拥有大量类别时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。将[is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/)设为`False`，随后将[tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/)设为所需的类别间隔。对于保持正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

间隔为 `3` 时每隔两个标签显示一个标签，未显示的标签仍然保留对应的列。自动间距会根据可用空间选择间隔，并不一定显示所有标签。

刻度线有独立的控制方式。将[is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/)设为`False`，并使用[tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/)设置其间隔。例如，`1` 在每个类别间隔放置刻度线，而标签仅每隔三个类别显示一次。将[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)设为可见样式即可看到效果。将任一自动间距属性恢复为`True`，图表将重新选择间隔。

以下独立示例创建 24 个类别和一个系列，然后在`CategoryAxisIntervals.pptx`中保存三张幻灯片：自动间距、手动标签间距（刻度线独立）以及恢复自动间距。两个副本保留原始图表数据，无需输入演示文稿。水平标签文本使密度差异一目了然。

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

    # 幻灯片 2：显示每三个标签，但为每个类别保留刻度线。
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

**自动间距（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。自动结果会随图表尺寸、字体和渲染器而变化。

![自动类别标签间距，显示所有 24 列](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每隔三个标签显示一次，且刻度线仍然在每个类别间隔。所有 24 列（包括未标记的列）保持可见且数值相同。幻灯片 3 恢复了上面的自动外观。

![手动类别标签间隔为三，显示所有 24 列](category-axis-manual.png)

### **选择正确的轴和间隔**

在文本类别轴（如柱形图、折线图、面积图或条形图的类别轴）上使用此类别计数间隔。在柱形图中，它是水平轴；在水平条形图中，类别轴是垂直的，因此应将这些设置应用于[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。刻度间隔同样适用于拥有系列轴的图表。

请勿使用类别标签间隔来设置数值轴的数值刻度。在数值轴上，[major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/)指定值的差异，例如 `10` 的主单位将在轴从零开始时产生 0、10、20 等刻度。而类别标签间隔 `3` 则仅计数类别位置，与数据值无关。散点图和气泡图使用数值轴而非文本类别轴。对于日期轴，请参阅[更改类别轴](#更改类别轴)中描述的基于时间的主单位和比例。

## **设置类别轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存放在第一个工作表（索引 `0`）中。将[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/)设为日期轴，关闭[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/)，并将`yyyy`赋给[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，使类别标签显示四位数年份，且独立于单元格的格式。

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

## **设置图表轴标题的旋转角度**

在垂直轴上启用[has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/)，提供标题文本，并将[rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)设为所需角度以旋转标题。角度以度数计；本示例保存的柱形图的数值轴标题旋转了 90 度。

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

## **设置类别轴或数值轴的位置**

使用[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/)控制数值轴是跨越类别轴的类别之间还是在类别刻度线上交叉。此属性适用于类别轴。示例在柱形图的水平类别轴上将其设为`True`，并保存结果。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **在图表数值轴上设置显示单位**

将[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)设为相应的单位，可在不更改底层数据的情况下缩放数值轴标签。使用[DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/)设为`MILLIONS`时，60000000 将显示为 60。示例创建一个柱形图并将其垂直轴的显示单位设置为“百万”。

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

当正数值跨越多个数量级时，对数数值轴非常有用。例如，某服务在五个周期内可能收到 10、100、1 000、10 000 和 100 000 次请求。在线性尺度下，较小的值会聚集在接近零的位置。对数尺度使它们的相对增长更易比较：等距代表等比例而非等差。

在数值轴上将[is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/)设为`True`，并使用[log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/)选择基数。这仅改变现有值的显示方式，不会修改数据或添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值轴和基数**

对于折线图或柱形图，数值轴为[vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)。对于水平条形图，则为[horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/)。散点图和气泡图拥有两个数值轴，分别用于 X 值的水平轴和 Y 值的垂直轴，或两者兼用。不要对类别轴使用对数缩放。

默认对数基数为 `10`。对于 PPTX 图表，基数可取 `2` 到 `1000`（含），也支持小数基数如 `2.5`。基数为 `10` 时，10、100、1 000、10 000 等连续幂等距分布。

### **比较线性和对数缩放**

以下独立示例在第一张幻灯片上创建一个包含五个请求计数的折线图，然后复制该幻灯片并在第二张上启用基数为 10 的对数数值轴。两张幻灯片保持相同数据。

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

**线性尺度（幻灯片 1）：** 等距的垂直距离代表相等的请求计数差异。最大值主导图表，导致较小的值难以辨认。

![PowerPoint 中的折线图，显示五个请求计数的线性数值轴](value-axis-linear.png)

**对数尺度（幻灯片 2）：** 等距的垂直距离代表等比例。每个周期的请求量是前一个周期的十倍，因此在基数为 10 的尺度上点呈现一条直线上升线。坐标轴标签仍显示原始请求计数。

![PowerPoint 中的相同五个请求计数的基数为 10 的对数数值轴](value-axis-logarithmic.png)

### **处理零和负值**

对数尺度只能显示严格正数。启用前请检查数据。如果零或负值有意义，请保持线性尺度或单独显示它们。若在分析中排除这些值，请说明原因。不要悄悄用小的正数替代，因为这会改变数据含义。对数坐标轴的手动最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴与另一个坐标轴交叉的数值（坐标轴交叉）？**

使用[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/)选择交叉行为。若要指定数值交叉点，请设置[cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/)。这些设置可将坐标轴交叉点移动到合适的基准位置。

**如何相对于坐标轴定位刻度标签？**

使用[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/)并结合[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)的 `LOW`、`HIGH`、`NEXT_TO` 或 `NONE`。若要控制刻度线本身，请使用[major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/)或[minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/)，它们与标签位置独立。