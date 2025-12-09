---
title: Export Presentation Charts in С++
linktitle: Export Chart
type: docs
weight: 90
url: /cpp/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for С++, supporting PPT and PPTX formats, and streamline reporting into any workflow."
---

## **Get a Chart Image**
Aspose.Slides for C++ provides support for extracting image of specific chart. Below sample example is given. 

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the export section of the [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[documentation](/slides/cpp/convert-powerpoint/) for output targets ([PDF](/slides/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/cpp/convert-powerpoint-to-xps/), [HTML](/slides/cpp/convert-powerpoint-to-html/), etc.) and related rendering options.
