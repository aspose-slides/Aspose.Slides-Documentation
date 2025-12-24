---
title: Export Presentation Charts in PHP
linktitle: Export Chart
type: docs
weight: 90
url: /php-java/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for PHP via Java, supporting PPT and PPTX formats, and streamline reporting into any workflow."
---

## **Get a Chart Image**
Aspose.Slides for PHP via Java provides support for extracting image of specific chart. Below sample example is given. 

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I export a chart as a vector (SVG) instead of a raster image?**

Yes. A chart is a shape, and its contents can be saved to SVG using the [shape-to-SVG saving method](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/).

**How can I set the exact size of the exported chart in pixels?**

Use the image-rendering overloads that let you specify size or scale—the library supports rendering objects with given dimensions/scale.

**What should I do if fonts in labels and the legend look wrong after export?**

[Load the required fonts](/slides/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) so the chart rendering preserves metrics and text appearance.

**Does export honor the PowerPoint theme, styles, and effects?**

Yes. Aspose.Slides’ renderer follows the presentation’s formatting (themes, styles, fills, effects), so the chart’s appearance is preserved.

**Where can I find available rendering/export capabilities beyond chart images?**

See the [API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[documentation](/slides/php-java/convert-powerpoint/) for output targets ([PDF](/slides/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/php-java/convert-powerpoint-to-xps/), [HTML](/slides/php-java/convert-powerpoint-to-html/), etc.) and related rendering options.
