---
title: Chart
type: docs
weight: 60
url: /python-net/examples/elements/chart/
keywords:
- chart
- add chart
- access chart
- remove chart
- update chart
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create and customize charts in Python with Aspose.Slides: add data, format series, axes and labels, change types, and export—works with PPT, PPTX and ODP."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for Python via .NET**. The snippets below demonstrate basic chart operations.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a simple column chart to the first slide.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Chart**

The following code retrieves a chart from the shape collection.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first chart on the slide.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Remove a Chart**

The following code removes a chart from a slide.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a chart.
        chart = slide.shapes[0]

        # Remove the chart.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Chart Data**

You can change chart properties such as the title.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a chart.
        chart = slide.shapes[0]

        # Change the chart title.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```
