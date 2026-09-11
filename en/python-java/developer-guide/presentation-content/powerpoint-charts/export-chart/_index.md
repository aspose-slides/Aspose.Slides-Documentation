---
title: Export Presentation Charts in Python via Java
linktitle: Export Chart
type: docs
weight: 90
url: /python-java/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for Python via Java, supporting PPT and PPTX formats, and streamline reporting into any workflow."
---

## **Overview**

Aspose.Slides allows you to export a chart from a presentation as an image. This article shows how to get an image from a chart and save it, which is useful when you need to reuse chart visuals outside a PowerPoint presentation.

In addition to the basic image export workflow, the article also addresses common export-related questions, including saving chart content to SVG, controlling output size through rendering options, loading fonts to preserve label and legend appearance, and keeping the original presentation formatting such as themes, styles, fills, and effects during rendering.

## **Get a Chart Image**
Aspose.Slides for Python via Java supports extracting an image of a specific chart. The following example demonstrates how to do this.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/python-java/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the [API](https://reference.aspose.com/slides/python-java/aspose.slides/)/[documentation](/slides/python-java/convert-powerpoint/) for output targets ([PDF](/slides/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/python-java/convert-powerpoint-to-xps/), [HTML](/slides/python-java/convert-powerpoint-to-html/), etc.) and related rendering options.
