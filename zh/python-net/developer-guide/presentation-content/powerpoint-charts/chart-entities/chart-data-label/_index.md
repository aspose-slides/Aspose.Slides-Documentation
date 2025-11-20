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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中添加和格式化图表数据标签，以制作更具吸引力的幻灯片。"
---

## **概述**

图表上的数据标签显示有关图表数据系列或单个数据点的详细信息。它们使读者能够快速识别数据系列，并使图表更易于理解。在 Aspose.Slides for Python 中，您可以为任何图表启用、定制和格式化数据标签——选择显示的内容（值、百分比、系列或类别名称）、标签的位置以及外观（字体、数字格式、分隔符、指示线等）。本文概述了向图表添加清晰、信息丰富标签所需的关键 API 和示例。

## **设置数据标签精度**

图表数据标签通常显示需要保持一致精度的数值。本节展示如何通过应用适当的数字格式来控制 Aspose.Slides 中数据标签的小数位数。

以下 Python 示例展示了如何设置图表数据标签的数值精度：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```


## **将百分比显示为标签**

使用 Aspose.Slides，您可以在图表上将百分比显示为数据标签。下面的示例计算每个点在其类别中的占比，并将标签格式化为显示百分比。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # 保存包含图表的演示文稿。
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```


## **在图表数据标签中显示百分号**

本节展示如何在图表数据标签中显示百分比并包含百分号，使用 Aspose.Slides。您将学习如何为整个系列或特定数据点启用百分比值（适用于饼图、环形图和 100% 堆积图），以及如何通过标签选项或自定义数字格式来控制格式。

以下 Python 示例展示了如何在图表的数据标签中添加百分号：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    # 通过索引获取幻灯片引用。
    slide = presentation.slides[0]

    # 在幻灯片上创建 PercentsStackedColumn 图表。
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # 获取图表数据工作簿。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # 添加新系列。
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # 设置系列填充颜色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 设置标签格式属性。
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # 添加新系列。
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # 设置填充类型和颜色。
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # 保存演示文稿。
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```


## **设置标签与坐标轴的距离**

本节展示如何在 Aspose.Slides 中控制数据标签与图表坐标轴之间的距离。调整此偏移量有助于防止重叠并提升密集可视化的可读性。

以下 Python 代码展示了在基于坐标轴的图表中设置标签与类别轴的距离：
```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:
    # 获取幻灯片引用。
    slide = presentation.slides[0]

    # 在幻灯片上创建聚簇柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 设置标签与类别（水平）轴的距离。
    chart.axes.horizontal_axis.label_offset = 500

    # 保存演示文稿。
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```


## **调整标签位置**

当您创建不使用坐标轴的图表（例如饼图）时，数据标签可能会靠得太近边缘。这种情况下，需要调整标签位置以使指示线清晰显示。

以下 Python 代码展示了如何在饼图上调整标签位置：
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


![更改后的标签位置](changed_label_position.png)

## **常见问题**

**如何防止在密集图表上出现标签重叠？**

结合自动标签布局、指示线和减小字体大小；如有必要，隐藏某些字段（例如类别），或仅对极端/关键点显示标签。

**如何仅对零值、负值或空值禁用标签？**

在启用标签之前筛选数据点，并根据定义的规则关闭对值为 0、负数或缺失值的显示。

**如何确保导出为 PDF/图片时标签样式保持一致？**

显式设置字体（字体族、大小），并确认渲染端已安装该字体，以避免回退。