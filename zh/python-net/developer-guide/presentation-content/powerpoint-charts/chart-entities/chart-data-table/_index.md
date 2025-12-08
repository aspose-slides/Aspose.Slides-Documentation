---
title: 在 Python 中自定义图表数据表
linktitle: 图表数据表
type: docs
url: /zh/python-net/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自定义 PPT、PPTX 和 ODP 的图表数据表，以提升演示文稿的效率和吸引力。"
---

## **为图表数据表设置字体属性**
Aspose.Slides for Python via .NET 提供了更改系列颜色中类别颜色的支持。

1. 实例化[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

以下示例给出。  
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**我可以在图表的数据表中在数值旁显示小的图例键吗？**

是的。数据表支持[legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/)，您可以打开或关闭它们。

**导出演示文稿为 PDF、HTML 或图像时，数据表会被保留吗？**

会的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的[PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/python-net/convert-powerpoint-to-html/)/[image](/slides/zh/python-net/convert-powerpoint-to-png/)包含带有数据表的图表。

**来自模板文件的图表支持数据表吗？**

支持。对于从现有演示文稿或模板加载的任何图表，您可以使用图表的属性检查并更改数据表[是否显示](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)。

**如何快速找到文件中哪些图表启用了数据表？**

检查每个图表指示数据表[是否显示](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/)的属性，并遍历幻灯片以识别已启用的数据表图表。