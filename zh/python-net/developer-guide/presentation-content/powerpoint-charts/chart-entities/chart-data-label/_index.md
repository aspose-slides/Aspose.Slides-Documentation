---
title: 使用 Python 在演示文稿中管理图表数据标签
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **介绍**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并了解图表。本文解释了如何格式化数值、显示百分比、读取标签文本、控制轴最大值之外的标签、调整类别轴标签间距以及定位饼图标签。

## **计数可见数据标签**

使用 [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) 检查在发布演示文稿之前有多少数据标签被启用显示。不同于返回集合中标签总数的 `len(labels)`，它会考虑系列默认设置和各标签的单独设置。

此示例创建了一个具有一个系列和三个数据点的柱形图。它访问系列的 [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) 集合，并在设置更改时打印可见计数：**0, 3, 2, 3**。总计数保持为 **3**。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # 总计: 3; 可见: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # 可见: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # 可见: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # 可见: 3
```

系列的 [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) 提供默认设置。启用其中的 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 会显示所有三个标签的数值。通过某个标签的 [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) 将其设为 `False` 会覆盖该标签的设置。启用 [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) 则使该标签再次计为可见，即使其数值仍被隐藏。

可见计数反映可见性设置。它不衡量标签是否重叠、被裁剪或在渲染的图表中是否可读。

## **在图表数据标签中设置数据精度**

使用 [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) 来格式化系列值。此示例创建了一个具有默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，而不更改底层数值。

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

要格式化图表嵌入工作簿中的数字单元格，请参阅 [为工作簿单元格设置自定义数字格式](/slides/zh/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells)。该示例还展示了数值标签遵循其源单元格格式，同时保留存储的数字值。

## **以百分比显示标签**

对于堆积柱形图，计算每个数值占其类别总和的百分比，并将文本分配给 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)。此示例使用默认图表数据，并以 8 磅字体显示两位小数的百分比。总和为零的类别会被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

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

## **在图表数据标签中设置百分号**

当数值以分数形式存储时，使用 [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) 来显示百分比。将 [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) 设置为 `False`，即可使标签格式独立于源单元格。

此示例创建了一个 100% 堆积柱形图，包含红色和蓝色系列，跨四个类别。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而纵轴使用两位小数。两个系列均使用白色、10 磅的标签文本。

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

## **读取数据标签的实际文本**

使用 [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 检索数据标签设置生成的文本。这在为报告提取标签、搜索演示文稿内容或验证生成的图表时非常有用。在下面的示例中，默认的 [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) 将每个类别名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个则使用来自 [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) 的自定义文本。

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

数据点中存储的数值仍为 `0.75`，即使其标签显示为 `75%` 并附带类别和系列名称。自定义文本会替换生成的标签文本。无论哪种情况，[get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) 都返回生成的标签字符串。正如上文所示，如需仅提取可见标签，请单独检查 [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/)。

## **控制轴最大值之外的数据标签**

当手动限制轴范围时，某些数据点可能超过其最大值。使用 [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) 来控制是否显示这些数据标签。此设置仅改变标签可见性；不会改变轴范围或底层数据值。

下面的示例创建了一个值为 60 和 120 的 2D 群集柱形图。它在纵轴上将 [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) 设置为 `False`，并将 [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) 设置为 100。第一张幻灯片允许标签超出最大值；该幻灯片的副本则禁用此功能。两张幻灯片均保存为 `DataLabelsOverMaximum.pptx`。

使用 [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 启用数值标签。图表级别的设置本身并不会启用数值显示，也不会覆盖单个标签已禁用的数值显示。此示例为整个系列启用数值，并使用 [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) 将标签放置在每个柱形的外侧末端。

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

下图显示了 Microsoft PowerPoint 渲染的已保存幻灯片。`True` 时，标签 **120** 在上边界可见；`False` 时，它被隐藏。标签 **60** 保持可见，轴最大值仍为 **100**，第二个数据点在两种情况下均保持为 **120**。

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint 图表显示轴最大值为 100 时的数值标签 120](data-labels-over-maximum-true.png) | ![PowerPoint 图表隐藏轴最大值为 100 时的数值标签 120](data-labels-over-maximum-false.png) |

{{% alert color="info" title="图表类型" %}}
此示例使用带数值轴的 2D 柱形图。没有数值轴的图表，例如饼图和环形图，无法以此方式限制轴最大值。
{{% /alert %}}

## **设置标签与轴的距离**

使用 [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) 来控制类别轴标签与轴之间的距离。该值是轴标签最大字体大小的百分比。此示例创建了一个群集柱形图，并将水平轴标签偏移设置为 500。此设置影响类别轴标签，而非附加到单个数据点的标签。

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

在饼图上，调整数据标签位置以改善间距并为引导线腾出空间。

此示例显示第一个数据点的数值，将其标签放置在扇区外部，并调整其 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 偏移。这些偏移分别相对于图表的宽度和高度。

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

![已调整数据标签位置的饼图](pie-chart-adjusted-label.png)

## **格式化引导线**

当饼图标签位于扇区外部时，引导线帮助读者将每个数值与相应的扇区对应。对比色和稍粗的线条可以让这些连接更易辨认，而透明度和虚线样式则使线条在视觉上不显突兀。

使用 [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) 在系列的数据标签集合级别格式化引导线。`series.labels.leader_lines_format.line` 中的设置适用于整个集合，而非单个标签。

此示例创建了一个默认数据的饼图，在扇区外部显示数值，并启用 [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/)。它使用 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 偏移（以图表宽高的比例表示）将两个标签移动得更远。无需输入演示文稿。

线条的 [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) 设置为纯蓝色，透明度为 191/255，约为 25% 透明。 [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 将粗细设为 2 磅，且 [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 使线条为虚线。

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

    # 将两个标签远离它们的扇区。
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

启用引导线并不保证每个标签都有对应的线。可见性取决于标签位置和图表的布局行为。在本例中，两个被移开的标签有可见的引导线；靠近扇区的标签则不需要。

下图显示了使用 Aspose.Slides 渲染的已保存 `FormattedLeaderLines.pptx`：

![带有蓝色、半透明虚线引导线，将两个外部标签连接到其扇区的饼图](formatted-leader-lines.png)

## **在柱形图上方添加多行数据标签**

此示例创建了一个柱形图，在绘图区域上方添加两行数据标签。Series A 显示可见柱形，而 Series B 和 Series C 提供额外的标签。通过移除填充和轮廓来隐藏它们的柱形。[overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) 属性使三个系列在同一类别中心对齐。

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) 设置为标签行预留空间。在 [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) 计算默认位置后，[x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) 保持水平对齐并应用垂直偏移，以将标签排列成两行。数字仍然是链接到系列数值的数据标签；只有行标题是单独的文本形状。

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
            # 隐藏 B 和 C 的柱形，但保留它们的数据标签。
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

    # 在绘图区上方预留空间用于两行数据标签。
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
            # 默认标签位置的偏移，以图表高度的比例表示。
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # 只有行标题是单独的文本形状。
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

![绘图区域上方有两行数据标签的柱形图](multiple-rows-of-labels.png)

## **常见问题**

**如何防止在密集图表上数据标签重叠？**  
结合自动标签布局、引导线和减小字体大小；必要时，可以隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零、负值或空值禁用标签？**  
在启用标签之前过滤数据点，并根据定义的规则关闭对 0、负值或缺失值的显示。

**如何在导出为 PDF/图像时确保标签样式一致？**  
明确设置字体族和大小，并确认渲染环境中已安装该字体，以避免回退。