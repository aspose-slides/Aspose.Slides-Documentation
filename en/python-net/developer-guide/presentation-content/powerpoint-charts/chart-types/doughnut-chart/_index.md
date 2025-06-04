---
title: Customize Doughnut Charts in Presentations with Python
linktitle: Doughnut Chart
type: docs
weight: 30
url: /python-net/doughnut-chart/
keywords:
- doughnut chart
- center gap
- hole size
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Discover how to create and customize doughnut charts in Aspose.Slides for Python via .NET, supporting PowerPoint and OpenDocument formats for dynamic presentations."
---

## **Specify Center Gap in Doughnut Chart**
In order to specify the size of the hole in a doughnut chart. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
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

