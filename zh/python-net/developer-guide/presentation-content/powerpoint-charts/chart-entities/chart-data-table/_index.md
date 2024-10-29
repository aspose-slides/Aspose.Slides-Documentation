---
title: 图表数据表
type: docs
url: /zh/python-net/chart-data-table/
keywords: "字体属性, 图表数据表, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中为PowerPoint演示文稿中的图表数据库表设置字体属性"
---

## **为图表数据表设置字体属性**
Aspose.Slides for Python via .NET支持更改系列颜色中的类别颜色。

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出了示例代码。

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