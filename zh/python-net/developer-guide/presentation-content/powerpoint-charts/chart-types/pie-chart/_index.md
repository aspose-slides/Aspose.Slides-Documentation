---
title: 使用 Python 在演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/python-net/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建并自定义饼图。配置次要绘图区、显示数据标签，并在 PowerPoint 中自动应用切片颜色。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用饼图。演示了如何为 “Pie of Pie” 与 “Bar of Pie” 图表配置次要绘图区选项，以及如何为标准饼图启用自动切片着色。

示例侧重于图表自定义任务，例如向幻灯片添加图表、调整系列和标签设置、使用自定义类别和值替换默认图表数据，以及保存更新后的演示文稿。

## **Pie of Pie 与 Bar of Pie 图表的次要绘图区选项**

Aspose.Slides for Python via .NET 支持 “Pie of Pie” 与 “Bar of Pie” 图表的次要绘图区选项。这些选项控制次要绘图区的大小以及数据点在两个绘图区之间的划分方式。

以下示例在新演示文稿中创建一个 “Pie of Pie” 图表，并将数据点值显示为标签。[second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) 属性将次要绘图区大小设置为主绘图区的 149%。[pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) 选择基于百分比的划分方式，且 [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) 将阈值设为 53%。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # 显示数值并配置次要绘图区。
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **为次要绘图区选择类别**

当您希望在次要绘图区中对特定类别进行分组，而不考虑它们的百分比值时，请使用自定义划分。例如，销售报告可能希望将 “Online” 与 “Events” 放在一起，以便读者比较这两个渠道，尽管它们分别占总销售额的 35% 和 10%。

将 [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) 设置为 [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/)，并通过 [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) 选择点。该集合的 [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) 方法接受系列中的零基索引或数据点对象。在本例中，索引 1 选中 “Online”，索引 3 选中 “Events”。随后临时添加 “Partners”，再使用 [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) 将其排除。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # 将默认数据替换为按渠道的销售数据。
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # 通过零基索引选择 Online 并通过数据点对象选择 Events。
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # 在不删除源数据的情况下将 Partners 排除在选择之外。
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

“Online”(35) 与 “Events”(10) 在次要绘图区中显示为独立切片。主绘图区则将它们合并为一个值为 45 的切片，并与 “Retail”(40) 和 “Partners”(15) 一同显示。将 “Partners” 从自定义选择中移除后，它仍保留在主绘图区；并未从图表的源数据中删除该类别或其数值。

下图展示了在 PowerPoint 中保存的演示文稿：

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **设置自动饼图切片颜色**

Aspose.Slides for Python via .NET 可以自动为饼图切片分配不同颜色。以下示例创建了一个带居中标题的饼图，并用三个季度类别及其数值替换默认数据。[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) 属性将数值 20、50、30 显示为标签，而 [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) 则为每个切片启用不同颜色。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # 添加居中的图表标题。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 使用第一个工作表替换默认数据。
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # 显示数值并为切片分配不同颜色。
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**是否支持 Pie of Pie 和 Bar of Pie 变体？**

是的，库 [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 为饼图提供次要绘图区，包括 Pie of Pie 和 Bar of Pie 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

可以，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)（如 PNG），而无需导出整个演示文稿。