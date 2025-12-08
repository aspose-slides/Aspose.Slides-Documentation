---
title: Customize Chart Data Tables in Python
linktitle: Data Table
type: docs
url: /python-net/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Customize chart data tables in Python for PPT, PPTX and ODP with Aspose.Slides to boost efficiency and appeal in presentations."
---

## **Set Font Properties for Chart Data Table**
Aspose.Slides for Python via .NET provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class object.
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

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/python-net/convert-powerpoint-to-html/)/[image](/slides/python-net/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) and iterate through the slides to identify the charts where it is enabled.
