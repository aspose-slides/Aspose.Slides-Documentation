---
title: 在演示文稿中使用 Python 管理图表数据标签
linktitle: 数据标签
type: docs
url: /zh/python-net/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **介绍**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并了解图表。本文解释如何格式化数值、显示百分比、读取标签文本、控制超出坐标轴最大值的标签、调整类别坐标轴标签间距，以及定位饼图标签。

## **在图表数据标签中设置数值精度**

使用 [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) 对系列数值进行格式化。此示例创建一个默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，而不改变底层数值。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

要格式化图表嵌入工作簿中的数字单元格，请参阅 [设置工作簿单元格的自定义数字格式](/slides/zh/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells)。该示例还展示了标签遵循其来源单元格的格式，同时保留存储的数值。

## **将百分比显示为标签**

对于堆叠柱形图，计算每个数值占其类别总和的百分比，并将文本分配给 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)。此示例使用默认图表数据，并以 8 磅字体显示两位小数的百分比。总计为零的类别将被跳过，以避免除以零。若图表数据更改，请重新计算自定义标签文本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **使用图表数据标签设置百分号**

当数值以分数形式存储时，使用 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) 显示百分比。将 [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) 设置为 `False`，即可使标签格式独立于来源单元格。

此示例创建一个 100% 堆叠柱形图，四个类别中包含红色和蓝色系列。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而垂直坐标轴使用两位小数。两个系列均使用白色、10 磅的标签文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **读取数据标签的实际文字**

使用 [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 检索由数据标签设置生成的文字。当提取标签用于报告、搜索演示文稿内容或验证生成的图表时，这非常有用。在下面的示例中，默认的 [数据标签格式](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) 将每个类别名称、系列名称和数值组合。一个点将其数值格式化为百分比，另一个使用来自 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) 的自定义文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

数据点中存储的数字仍为 `0.75`，即使其标签显示为 `75%` 并带有类别和系列名称。自定义文字会替换生成的标签文字。无论哪种情况，[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 都返回最终的标签字符串。如上所示，在仅想提取可见标签时，请单独检查 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/)。

## **控制坐标轴最大值之外的数据标签**

当手动限制坐标轴范围时，某些数据点可能超出其最大值。使用 [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) 控制是否显示这些数据标签。此设置仅更改标签可见性，不会改变坐标轴范围或底层数据值。

下面的示例创建一个二维簇状柱形图，数值为 60 和 120。它将垂直坐标轴的 [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) 设置为 `False`，并将 [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) 设置为 100。第一张幻灯片允许标签超出最大值；其复制版禁用此功能。两个幻灯片均保存在 `DataLabelsOverMaximum.pptx` 中。

使用 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 启用数值标签。图表级设置本身并不会启用数值显示，也不会覆盖单个标签已禁用的数值显示。此示例为整个系列启用数值，并使用 [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) 将标签放置在每列的外侧末端。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

以下图像显示了 Microsoft PowerPoint 渲染的已保存幻灯片。`True` 时，标签 **120** 在上边界可见；`False` 时则隐藏。标签 **60** 保持可见，坐标轴最大值保持在 **100**，第二个数据点在两种情况下均为 **120**。

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此示例使用带值坐标轴的二维柱形图。没有值坐标轴的图表（如饼图和环形图）没有可用于此方式限制的坐标轴最大值。
{{% /alert %}}

## **设置标签距离坐标轴的距离**

使用 [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) 控制类别坐标轴标签与坐标轴之间的距离。该值是坐标轴标签最大字体大小的百分比。此示例创建一个簇状柱形图，并将水平坐标轴标签偏移设置为 500。此设置影响类别坐标轴标签，而不是附加到单个数据点的标签。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为引导线留出空间。

此示例显示第一个数据点的数值，将其标签放置在切片外部，并调整其 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 偏移。这些偏移相对于图表的宽度和高度。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **格式化引导线**

当饼图标签位于切片外部时，引导线帮助读者将每个数值对应到正确的切片。对比色和稍粗的线条可以使这些连接更易于辨认，而透明度和虚线样式则让线条视觉上不显突兀。

使用 [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) 在系列数据标签集合层面格式化引导线。`series.labels.leader_lines_format.line` 中的设置适用于整个集合，而不是单个标签。

此示例创建一个默认数据的饼图，在切片外显示数值，并启用 [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/)。它使用 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 偏移，将两个标签进一步移离其切片，偏移量以图表宽高的比例表示。无需输入演示文稿。

线条的 [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) 设置为具有 191/255 透明度的纯蓝色，约为 25% 透明度。[width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 将粗细设为 2 磅，[dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 将线条设为虚线。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # 将两个标签从切片向外移动更远。
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

启用引导线并不保证每个标签都会出现线条。可见性取决于标签位置和图表的布局行为。在本例中，两个被移动的标签具有可见的引导线；靠近切片的标签则不需要。

以下图片显示了使用 Aspose.Slides 渲染的已保存 `FormattedLeaderLines.pptx`：

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **在柱形图上方添加多行数据标签**

此示例创建一个柱形图，在绘图区域上方放置两行数据标签。系列 A 显示可见的柱形，系列 B 和系列 C 提供额外的标签。通过移除填充和轮廓，将它们的柱形隐藏。[overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 属性使三个系列在同一类别中心对齐。

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) 设置为标签行预留空间。调用 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 计算默认位置后， [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 保持水平对齐并应用垂直偏移，以将标签排列为两行。数字仍然是链接到系列数值的数据标签；只有行标题是单独的文本形状。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # 隐藏 B 和 C 系列的柱形，但保留它们的数据标签。
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # 将所有三个系列对齐到相同的类别中心。
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # 在此紧凑示例中使用更少的网格线。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # 为绘图区上方保留两行数据标签的空间。
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # 保持默认的水平位置。Y 是相对于
            # 默认标签位置的偏移量，以图表高度的比例表示。
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # 仅行标题是单独的文本形状。
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **常见问题解答**

**如何防止在密集图表上标签重叠？**

结合自动标签布局、引导线和缩小字体大小；必要时隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零值、负值或空值禁用标签？**

在启用标签前过滤数据点，并根据定义的规则关闭对值为 0、负值或缺失值的显示。

**如何在导出为 PDF/图像时确保标签样式一致？**

显式设置字体族和大小，并验证渲染环境中已安装该字体，以避免回退。