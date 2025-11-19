---
title: Export Presentation Charts with Python
linktitle: Export Chart
type: docs
weight: 90
url: /python-net/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for Python via .NET, supporting PPT, PPTX and ODP formats, and streamline reporting into any workflow."
---

## **Get Chart Image**
Aspose.Slides for Python via .NET provides support for extracting image of specific chart. Below sample example is given. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the export section of the [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[documentation](/slides/python-net/convert-powerpoint/) for output targets ([PDF](/slides/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/python-net/convert-powerpoint-to-xps/), [HTML](/slides/python-net/convert-powerpoint-to-html/), etc.) and related rendering options.
