---
title: Export Chart
type: docs
weight: 90
url: /net/export-chart/
keywords:
- chart
- chart image
- extract chart image
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Get chart images from PowerPoint presentations in C# or .NET"
---

## **Get Chart Image**
Aspose.Slides for .NET provides support for extracting image of specific chart. Below sample example is given. 

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the export section of the [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[documentation](/slides/net/convert-powerpoint/) for output targets ([PDF](/slides/net/convert-powerpoint-to-pdf/), [SVG](/slides/net/render-a-slide-as-an-svg-image/), [XPS](/slides/net/convert-powerpoint-to-xps/), [HTML](/slides/net/convert-powerpoint-to-html/), etc.) and related rendering options.
