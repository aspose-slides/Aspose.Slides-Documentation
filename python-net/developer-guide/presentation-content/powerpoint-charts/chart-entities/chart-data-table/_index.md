---
title: Chart Data Table
type: docs
url: /python-net/chart-data-table/
keywords: "Font properties, chart data table, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Set font properties for chart database table in PowerPoint presentations in Python"
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Python via .NET provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

 Below sample example is given. 

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

