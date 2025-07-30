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
- 树状图
- 股票图
- 箱线图
- 漏斗图
- 旭日图
- 直方图
- 雷达图
- 多类别图
- PowerPoint 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义图表。内容涵盖在演示文稿中添加、格式化和编辑图表，并提供 Python 代码示例。"
---

## **创建图表**

图表帮助人们快速可视化数据并获取见解，这些见解可能无法从表格或电子表格中立即显现。

**为什么要创建图表？**

使用图表，你可以：

* 在演示文稿的一张幻灯片上聚合、浓缩或总结大量数据
* 揭示数据中的模式和趋势
* 推断数据随时间或相对于特定测量单位的方向和Momentum
* 找出异常值、偏差、差错、无意义的数据等
* 传达或展示复杂数据

在 PowerPoint 中，你可以通过插入功能创建图表，该功能提供用于设计多种类型图表的模板。使用 Aspose.Slides，你可以创建常规图表（基于流行的图表类型）和自定义图表。

{{% alert color="primary" %}} 

为了让你创建图表，Aspose.Slides 在 [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) 命名空间下提供了 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举。该枚举下的成员对应于不同的图表类型。

{{% /alert %}} 

### **创建普通图表**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有一些数据的图表，并指定你喜欢的图表类型。
1. 为图表添加标题。
1. 访问图表数据工作表。
1. 清除所有默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加一些新的图表数据。
1. 为图表系列添加填充颜色。
1. 为图表系列添加标签。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建普通图表：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:

    # 访问第一张幻灯片
    sld = pres.slides[0]

    # 添加具有默认数据的图表
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # 设置图表标题
    chart.chart_title.add_text_frame_for_overriding("示例标题")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # 设置第一个系列显示值
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 设置图表数据工作表的索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 删除默认生成的系列和类别
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # 添加新系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.type)

    # 添加新类别
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "类别 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "类别 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "类别 3"))

    # 获取第一个图表系列
    series = chart.chart_data.series[0]

    # 现在填充系列数据

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # 设置系列的填充颜色
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # 获取第二个图表系列
    series = chart.chart_data.series[1]

    # 现在填充系列数据
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 设置系列的填充颜色
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # 第一个标签将显示类别名称
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # 显示第三个标签的值
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # 保存包含图表的演示文稿
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **创建散点图**
散点图（也称为散点图或 x-y 图）常用于检查模式或演示两个变量之间的相关性。

当你：

* 有成对的数值数据时
* 有两个良好配对的变量时
* 想确定两个变量是否相关时
* 有一个独立变量对多个值的依赖变量时

这段 Python 代码向你展示如何创建带有不同系列标记的散点图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # 创建默认图表
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # 获取默认图表数据工作表索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 删除演示系列
    chart.chart_data.series.clear()

    # 添加新系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.type)

    # 获取第一个图表系列
    series = chart.chart_data.series[0]

    # 在此添加新点（1:3）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # 添加新点（2:10）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # 编辑系列类型
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # 更改图表系列标记
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # 获取第二个图表系列
    series = chart.chart_data.series[1]

    # 在此添加新点（5:2）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # 添加新点（3:1）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # 添加新点（2:2）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # 添加新点（5:1）
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # 更改图表系列标记
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **创建饼图**

饼图最佳用于显示数据中的部分与整体关系，特别是当数据包含带有数值的类别标签时。 但是，如果你的数据包含了许多部分或标签，你可能想考虑使用条形图。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（在这种情况下为 `ChartType.PIE`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 为图表的各个部分设置自定义颜色。
1. 为系列设置标签。
1. 为系列标签设置引导线。
1. 设置饼图切片的旋转角度。
1. 将修改后的演示文稿写入 PPTX 文件

以下 Python 代码向你展示如何创建饼图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as presentation:

    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 添加具有默认数据的图表
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # 设置图表标题
    chart.chart_title.add_text_frame_for_overriding("示例标题")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # 设置第一个系列显示值
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # 设置图表数据工作表的索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 删除默认生成的系列和类别
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 添加新类别
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "第一季度"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "第二季度"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "第三季度"))

    # 添加新系列
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "系列 1"), chart.type)

    # 现在填充系列数据
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # 在新版本中无法使用
    # 添加新点并设置扇区颜色
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # 设置扇区边框
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # 设置扇区边框
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # 设置扇区边框
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # 为每个类别创建自定义标签
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # 显示图表的引导线
    series.labels.default_data_label_format.show_leader_lines = True

    # 设置饼图扇区的旋转角度
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # 保存包含图表的演示文稿
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **创建折线图**

折线图（也称为折线图）最佳用于展示随时间变化的值。在使用折线图时，你可以同时比较大量数据，跟踪随时间的变化和趋势，突出数据系列中的异常点等。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（在这种情况下，`ChartType.Line`）。
1. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/)。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建折线图：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

默认情况下，折线图上的点由直线相连。如果你想让点由虚线连接，可以通过以下方式指定你喜欢的虚线类型：

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **创建树状图**
树状图最佳用于销售数据，当你想展示数据类别的相对大小，并快速引起对每个类别的大贡献者的注意时。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（在这种情况下，`ChartType.TREEMAP`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建树状图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branch 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "叶子1"))
    leaf.grouping_levels.set_grouping_item(1, "树干1")
    leaf.grouping_levels.set_grouping_item(2, "分支1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "叶子2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "叶子3"))
    leaf.grouping_levels.set_grouping_item(1, "树干2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "叶子4"))


    #branch 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "叶子5"))
    leaf.grouping_levels.set_grouping_item(1, "树干3")
    leaf.grouping_levels.set_grouping_item(2, "分支2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "叶子6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "叶子7"))
    leaf.grouping_levels.set_grouping_item(1, "树干4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "叶子8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```

### **创建股票图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（ChartType.OPEN_HIGH_LOW_CLOSE）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 指定 HiLowLines 格式。
1. 将修改后的演示文稿写入 PPTX 文件。

用于创建股票图的示例 Python 代码：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "开盘"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "最高"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "最低"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "收盘"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```

### **创建箱线图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（ChartType.BOX_AND_WHISKER）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建箱线图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "类别 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```

### **创建漏斗图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（ChartType.Funnel）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建漏斗图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "类别 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "类别 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "类别 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "类别 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "类别 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "类别 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **创建日晕图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（在这种情况下，`ChartType.SUNBURST`）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建日晕图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #branch 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "叶子1"))
    leaf.grouping_levels.set_grouping_item(1, "树干1")
    leaf.grouping_levels.set_grouping_item(2, "分支1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "叶子2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "叶子3"))
    leaf.grouping_levels.set_grouping_item(1, "树干2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "叶子4"))

    #branch 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "叶子5"))
    leaf.grouping_levels.set_grouping_item(1, "树干3")
    leaf.grouping_levels.set_grouping_item(2, "分支2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "叶子6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "叶子7"))
    leaf.grouping_levels.set_grouping_item(1, "树干4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "叶子8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```

### **创建直方图**
1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一些具有数据的图表并指定你喜欢的图表类型（在这种情况下为 `ChartType.HISTOGRAM`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建直方图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **创建雷达图**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一些数据的图表并指定你喜欢的图表类型（在这种情况下为 `ChartType.RADAR`）。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建雷达图：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **创建多类别图**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加具有默认数据的图表以及所需的类型（ChartType.ClusteredColumn）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何创建多类别图：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "组1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "组2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "组3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "组4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # 添加系列
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "系列 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # 保存包含图表的演示文稿
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **创建地图图表**

地图图表是对包含数据区域的可视化。 地图图表最佳用于比较地理区域的数据显示或值。

以下 Python 代码向你展示如何创建地图图表：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **创建组合图表**

组合图表（或组合图）是将两种或更多图表组合在同一图形上的图表。这种图表允许你突出显示、比较或审查两组（或更多）数据之间的差异。通过这种方式，你可以看到数据集之间的关系（如果有的话）。

![组合图表](combination-chart-ppt.png)

以下 Python 代码向你展示如何在 PowerPoint 中创建组合图表：

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "系列 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "类别 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "类别 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "类别 3"))

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

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "系列 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "系列 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **更新图表**

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，表示包含图表的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据。
6. 添加新系列并填充数据。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何更新图表：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # 访问第一张幻灯片和添加具有默认数据的图表
    sld = pres.slides[0]

    # 添加图表
    chart = sld.shapes[0]

    # 设置图表数据工作表的索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook


    # 更改图表类别名称
    fact.get_cell(defaultWorksheetIndex, 1, 0, "修改类别 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "修改类别 2")


    # 获取第一个图表系列
    series = chart.chart_data.series[0]

    # 现在更新系列数据
    fact.get_cell(defaultWorksheetIndex, 0, 1, "新系列1")# 修改系列名称
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # 获取第二个图表系列
    series = chart.chart_data.series[1]

    # 现在更新系列数据
    fact.get_cell(defaultWorksheetIndex, 0, 2, "新系列2")# 修改系列名称
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # 现在，添加新系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "系列 3"), chart.type)

    # 获取第三个图表系列
    series = chart.chart_data.series[2]

    # 现在填充系列数据
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # 保存包含图表的演示文稿
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **为图表设置数据范围**

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，表示包含图表的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向你展示如何为图表设置数据范围：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 访问第一张幻灯片并添加具有默认数据的图表
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **在图表中使用默认标记**
当你在图表中使用默认标记时，每个图表系列会自动获得不同的默认标记符号。

以下 Python 代码向你展示如何在图表系列中自动设置标记：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "系列 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "系列 2"), chart.type)
    #获取第二个图表系列
    series2 = chart.chart_data.series[1]

    #现在填充系列数据
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```