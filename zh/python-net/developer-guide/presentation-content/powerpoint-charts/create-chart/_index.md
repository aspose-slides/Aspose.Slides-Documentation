---
title: 在 Python 中创建或更新 PowerPoint 演示文稿图表
linktitle: 创建或更新图表
type: docs
weight: 10
url: /zh/python-net/create-chart/
keywords:
- 添加图表
- 创建图表
- 编辑图表
- 更改图表
- 更新图表
- 散点图
- 饼图
- 折线图
- 树图
- 股票图
- 箱线图
- 漏斗图
- 旭日图
- 直方图
- 雷达图
- 多分类图
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义图表。内容涵盖在演示文稿中添加、格式化和编辑图表，并提供实用的 Python 代码示例。"
---

## **概述**

本文提供了使用 Aspose.Slides for Python via .NET 创建和自定义图表的完整指南。您将学习如何以编程方式向幻灯片添加图表、填充数据，并应用各种格式选项以满足特定的设计需求。文章中通过详细的代码示例展示了每一步骤，从初始化演示文稿和图表对象到配置系列、轴和图例。遵循本指南，您将能够将动态图表生成集成到应用程序中，简化数据驱动演示文稿的创建过程。

## **创建图表**

图表帮助人们快速可视化数据，发现表格或电子表格中不易察觉的洞察。

**为什么要创建图表？**

使用图表，您可以：

* 在单个幻灯片上汇总、压缩或概括大量数据；
* 显示数据中的模式和趋势；
* 推断数据随时间或特定计量单位的方向和动量；
* 发现异常值、偏差、错误和不合理的数据；
* 传达或展示复杂数据。

在 PowerPoint 中，可以通过 *Insert* 功能创建图表，该功能提供了多种图表模板。使用 Aspose.Slides，您既可以创建常规图表（基于流行的图表类型），也可以创建自定义图表。

{{% alert color="primary" %}} 

使用位于 [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) 命名空间下的 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举。此枚举的值对应不同的图表类型。

{{% /alert %}} 

### **创建簇状柱形图**

本节说明如何使用 Aspose.Slides for Python via .NET 创建簇状柱形图。您将学习初始化演示文稿、添加图表以及自定义标题、数据、系列、分类和样式等元素。按照以下步骤查看标准簇状柱形图的生成过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有数据的图表，并指定 `ChartType.CLUSTERED_COLUMN` 类型。  
1. 为图表添加标题。  
1. 访问图表的数据工作表。  
1. 清除所有默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 为图表系列设置填充颜色。  
1. 为图表系列添加标签。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码演示了如何创建簇状柱形图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化代表 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个默认数据的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # 设置图表标题。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 设置第一系列显示数值。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 设置图表数据工作表的索引。
    worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.chart_data.chart_data_workbook

    # 删除默认生成的系列和分类。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 添加新系列。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # 添加新分类。
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # 获取第一条图表系列。
    series = chart.chart_data.series[0]

    # 填充系列数据。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 设置系列的填充颜色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # 获取第二条图表系列。
    series = chart.chart_data.series[1]

    # 填充系列数据。
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # 设置系列的填充颜色。
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 设置第一个标签显示分类名称。
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # 设置系列在第三个标签上显示数值。
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # 将演示文稿保存为 PPTX 文件。
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![簇状柱形图](clustered_column_chart.png)

### **创建散点图**

散点图（亦称散点图或 x‑y 图）常用于检查模式或展示两个变量之间的相关性。

使用散点图的情形：

* 您拥有成对的数值数据。  
* 您有两个相互匹配的变量。  
* 您想确定这两个变量是否相关。  
* 您有一个自变量对应多个因变量的取值。

下面的 Python 代码展示了如何使用不同标记系列创建散点图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 创建默认散点图。
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # 设置图表数据工作表的索引。
    worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.chart_data.chart_data_workbook

    # 删除默认系列。
    chart.chart_data.series.clear()

    # 添加新系列。
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # 获取第一条图表系列。
    series = chart.chart_data.series[0]

    # 向系列添加新点 (1:3)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # 添加新点 (2:10)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # 更改系列类型。
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # 更改图表系列标记。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 获取第二条图表系列。
    series = chart.chart_data.series[1]

    # 向图表系列添加新点 (5:2)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # 添加新点 (3:1)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # 添加新点 (2:2)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # 添加新点 (5:1)。
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # 更改图表系列标记。
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![散点图](scatter_chart.png)

### **创建饼图**

饼图最适合展示数据的部分与整体的关系，尤其是当数据包含带数值的分类标签时。但如果您的数据包含众多部分或标签，建议使用柱状图。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.PIE` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 为饼图的扇区添加新点并自定义颜色。  
1. 为系列设置标签。  
1. 为系列标签启用指引线。  
1. 设置饼图的旋转角度。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建饼图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化代表 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加默认数据的图表。
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # 设置图表标题。
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # 设置第一系列显示数值。
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 设置图表数据工作表的索引。
    worksheet_index = 0

    # 获取图表数据工作簿。
    workbook = chart.chart_data.chart_data_workbook

    # 删除默认生成的系列和分类。
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 添加新分类。
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # 添加新系列。
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 填充系列数据。
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # 设置扇区颜色。
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # 设置扇区边框。
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # 设置扇区边框。
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # 设置扇区边框。
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 为新系列中的每个类别创建自定义标签。
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # 设置系列在图表中显示引导线。
    series.labels.default_data_label_format.show_leader_lines = True

    # 设置饼图扇区的旋转角度。
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![饼图](pie_chart.png)

### **创建折线图**

折线图（亦称折线图）最适用于展示随时间变化的数值。在折线图中，您可以一次比较大量数据、跟踪随时间的变化趋势、突出数据系列中的异常等。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.LINE` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建折线图：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


默认情况下，折线图的点由直线连续相连。如果希望点之间使用虚线相连，可按如下方式指定所需的虚线类型：
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


结果：

![折线图](line_chart.png)

### **创建树图**

树图最适合用于销售数据，能够显示各数据类别的相对大小，并快速突出每个类别中贡献大的项目。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.TREEMAP` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建树图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 分支 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # 分支 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![树图](treemap_chart.png)

### **创建股票图**

股票图用于显示开盘价、最高价、最低价和收盘价等金融数据，帮助分析市场趋势和波动性，为投资者和分析师提供关键的股票表现洞察。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.OPEN_HIGH_LOW_CLOSE` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 指定 HiLowLines 格式。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建股票图：
{{6dcfb1d4-cf41-4728-b312-78dd749033e}}

结果：

![股票图](stock_chart.png)

### **创建箱线图**

箱线图用于通过汇总关键统计量（如中位数、四分位数和潜在异常值）来显示数据的分布情况。它们在探索性数据分析和统计研究中尤为有用，可快速了解数据的变异性并识别异常。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.BOX_AND_WHISKER` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建箱线图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **创建漏斗图**

漏斗图用于可视化包含多个阶段的过程，数据量随阶段逐步递减。它们有助于分析转化率、识别瓶颈并跟踪销售或营销过程的效率。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.FUNNEL` 类型。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建漏斗图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![漏斗图](funnel_chart.png)

### **创建旭日图**

旭日图用于可视化层级数据，以同心环的形式展示各层级。它们帮助说明部分与整体的关系，适合以紧凑的方式展示嵌套的类别和子类别。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.SUNBURST` 类型。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建旭日图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 分支 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # 分支 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![旭日图](sunburst_chart.png)

### **创建直方图**

直方图用于通过将数值数据分组为区间（或箱）来表示其分布。它们有助于识别频率、偏斜、离散程度等模式，并检测数据集中的异常值。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有数据的图表，并指定 `ChartType.HISTOGRAM` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建直方图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![直方图](histogram_chart.png)

### **创建雷达图**

雷达图用于在二维平面上展示多变量数据，便于同时比较多个变量。它们特别适用于识别多个绩效指标或属性之间的模式、优势和劣势。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有数据的图表，并指定 `ChartType.RADAR` 类型。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建雷达图：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![雷达图](radar_chart.png)

### **创建多分类图**

多分类图用于展示涉及多个分类分组的数据，能够在多个维度上同时比较数值。它们在分析复杂、多层次数据集的趋势和关系时特别有用。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用索引获取幻灯片的引用。  
1. 添加带有默认数据的图表，并指定 `ChartType.CLUSTERED_COLUMN` 类型。  
1. 访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))。  
1. 清除默认的系列和分类。  
1. 添加新的系列和分类。  
1. 为图表系列添加新数据。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何创建多分类图：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # 添加系列。
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # 保存包含图表的演示文稿。
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![多分类图](multi_category_chart.png)

### **创建地图图表**

地图图表用于通过将信息映射到国家、州或城市等具体位置来可视化地理数据。它们在分析区域趋势、人口统计数据和空间分布时非常有帮助，能够以直观且具吸引力的方式呈现。

下面的 Python 代码展示了如何创建地图图表：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


结果：

![地图图表](map_chart.png)

### **创建组合图表**

组合图（或称 combo 图）将两种或多种图表类型合并在同一坐标系中。此类图表可突出、比较或审视多组数据之间的差异，帮助识别它们之间的关联性。

![组合图表](combination_chart.png)

下面的 Python 代码展示了如何在 PowerPoint 演示文稿中创建组合图表：
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **更新图表**

Aspose.Slides for Python via .NET 允许通过修改图表数据、格式和样式来更新 PowerPoint 图表。此功能简化了保持演示文稿与动态内容同步的过程，确保图表准确反映当前数据和视觉标准。

1. 实例化表示包含图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。  
1. 使用索引获取幻灯片的引用。  
1. 遍历所有形状以查找图表。  
1. 访问图表的数据工作表。  
1. 通过更改系列值来修改图表数据系列。  
1. 添加新系列并填充其数据。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何更新图表：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # 设置图表数据工作表的索引。
            worksheet_index = 0

            # 获取图表数据工作簿。
            workbook = chart.chart_data.chart_data_workbook

            # 更改图表分类名称。
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # 获取第一条图表系列。
            series = chart.chart_data.series[0]

            # 更新系列数据。
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # 修改系列名称。
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # 获取第二条图表系列。
            series = chart.chart_data.series[1]

            # 更新系列数据。
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # 修改系列名称。
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # 添加新系列。
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # 填充系列数据。
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # 保存包含图表的演示文稿。
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **为图表设置数据范围**

Aspose.Slides for Python via .NET 提供了将工作表中特定数据范围设为图表数据源的灵活性。这意味着您可以直接映射工作表的某一部分到图表，以控制哪些单元格参与图表的系列和分类。这样，您可以轻松更新并同步图表与工作表的最新数据，更好地确保 PowerPoint 演示文稿反映当前且准确的信息。

1. 实例化表示包含图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。  
1. 使用索引获取幻灯片的引用。  
1. 遍历所有形状以查找图表。  
1. 访问图表数据并设置范围。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的 Python 代码展示了如何为图表设置数据范围：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation("ExistingChart.pptx") as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **在图表中使用默认标记**

使用默认标记时，每个图表系列会自动获取不同的默认标记符号。

下面的 Python 代码展示了如何自动为图表系列设置标记：
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # 填充系列数据。
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**Aspose.Slides for Python via .NET 支持哪些图表类型？**

Aspose.Slides for Python via .NET 支持多种图表类型，包括柱形图、折线图、饼图、面积图、散点图、直方图、雷达图等。该灵活性使您能够根据数据可视化需求选择最合适的图表类型。

**如何向幻灯片添加新图表？**

要添加图表，首先创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，使用索引获取目标幻灯片，然后调用添加图表的方法，指定图表类型和初始数据。此过程可直接将图表嵌入演示文稿。

**如何更新图表中显示的数据？**

您可以通过访问图表的数据工作簿 ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))，清除默认的系列和分类，然后添加自定义数据，从而以编程方式刷新图表以反映最新数据。

**是否可以自定义图表的外观？**

可以，Aspose.Slides for Python via .NET 提供了丰富的自定义选项。您可以修改颜色、字体、标签、图例以及其他格式元素，以满足特定的设计需求。