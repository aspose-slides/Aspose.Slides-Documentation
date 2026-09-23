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

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文介绍如何格式化数值、显示百分比、读取标签文本、调整类目轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用[number_format_of_values](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/number_format_of_values/)来格式化系列值。此示例创建一个带默认数据的折线图，显示其数据表，并为第一系列启用数值标签。格式`#,##0.00`显示千位分隔符和两位小数，而不更改底层数值。

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

## **显示百分比为标签**

对于堆积柱形图，计算每个值相对于其类别总计的百分比，并将文本分配给[text_frame_for_overriding](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)。此示例使用默认图表数据，并以8磅字体显示两位小数的百分比。总计为零的类别将被跳过，以避免除以零。如果图表数据更改，需要重新计算自定义标签文本。

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

当数值以分数形式存储时，使用[number_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabelformat/number_format/)显示百分比。将[is_number_format_linked_to_source](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)设置为`False`，以使标签格式独立于源单元格。

此示例创建一个100%堆积柱形图，包含红色和蓝色系列，跨越四个类别。每对数值相加为1。标签格式`0.0%`将0.30显示为30.0%，而垂直轴使用两位小数。两个系列的标签文本均为白色、10磅。

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

使用[get_actual_label_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)检索数据标签设置产生的文本。这在提取报告标签、搜索演示内容或验证生成的图表时非常有用。在下面的示例中，默认[data label format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabelformat/)将每个类别名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个使用来自[text_frame_for_overriding](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)的自定义文本。

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

数据点中存储的数值仍为`0.75`，即使其标签显示`75%`并附带类别和系列名称。自定义文本会替换生成的标签文本。[get_actual_label_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)在两种情况下都会返回相应的标签字符串。正如上文所示，当只想提取可见标签时，需要单独检查[is_visible](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/is_visible/)。

## **设置标签相对于坐标轴的距离**

使用[label_offset](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/axis/label_offset/)控制类目轴标签与坐标轴之间的距离。该值是轴标签最大字体大小的百分比。此示例创建一个簇状柱形图，并将水平轴标签偏移设置为500。此设置影响类目轴标签，而不是附加到单个数据点的标签。

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

在饼图中，调整数据标签位置以改善间距并为引线留出空间。

此示例显示第一个数据点的数值，将其标签置于切片外部，并调整其[x](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/x/)和[y](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabel/y/)偏移。这些偏移分别相对于图表的宽度和高度。

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

![调整数据标签位置的饼图](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止在密集图表上数据标签重叠？**  
结合自动标签布局、引线和减小字体大小；必要时隐藏某些字段（例如类别），或仅对极值或关键点显示标签。

**如何仅对零、负数或空值禁用标签？**  
在启用标签前过滤数据点，并根据定义的规则关闭对值为0、负数或缺失值的显示。

**在导出为 PDF/图像时，如何确保标签样式一致？**  
明确设置字体族和字号，并确认渲染环境中存在该字体，以避免回退。