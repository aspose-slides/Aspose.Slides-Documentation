---
title: Doughnut Chart
type: docs
weight: 30
url: /pythonnet/doughnut-chart/
keywords: "Doughnut chart, center gap, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Specify center gap in doughnut chart in PowerPoint presentation in Python"
---

## **Specify Center Gap in Doughnut Chart**
In order to specify the size of the hole in a doughnut chart. Please follow the steps below:

- Instantiate [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

