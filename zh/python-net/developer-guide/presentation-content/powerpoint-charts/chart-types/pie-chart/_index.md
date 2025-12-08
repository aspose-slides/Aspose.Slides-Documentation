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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中创建和自定义饼图，支持导出为 PowerPoint 和 OpenDocument，秒级提升您的数据叙事能力。"
---

## **饼图的 Pie of Pie 与 Bar of Pie 二次绘图选项**
Aspose.Slides for Python via .NET 现在支持对 Pie of Pie 或 Bar of Pie 图表的二次绘图选项。 在本主题中，我们将通过示例演示如何使用 Aspose.Slides 指定这些选项。 请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的二次绘图选项。
1. 将演示文稿写入磁盘。

下面的示例中，我们已设置 Pie of Pie 图表的不同属性。
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 在幻灯片上添加图表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # 设置不同的属性
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # 将演示文稿写入磁盘
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```





## **设置自动饼图切片颜色**
Aspose.Slides for Python via .NET 提供了一个简便的 API，用于设置自动饼图切片颜色。 示例代码演示了上述属性的设置。

1. 创建 Presentation 类的实例。
1. 访问第一张幻灯片。
1. 添加带默认数据的图表。
1. 设置图表标题。
1. 将第一系列设置为显示数值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as presentation:
	# 访问第一张幻灯片
	slide = presentation.slides[0]

	# 添加默认数据的图表
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# 设置图表标题
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# 将第一系列设为显示数值
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# 设置图表数据表的索引
	defaultWorksheetIndex = 0

	# 获取图表数据工作表
	fact = chart.chart_data.chart_data_workbook

	# 删除默认生成的系列和类别
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# 添加新类别
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# 添加新系列
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# 现在填充系列数据
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**是否支持 'Pie of Pie' 和 'Bar of Pie' 变体？**

是的，库 [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 支持饼图的二次绘图，包括 'Pie of Pie' 和 'Bar of Pie' 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/)（例如 PNG），而无需导出整个演示文稿。