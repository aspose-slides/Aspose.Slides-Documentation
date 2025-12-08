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

## **Get Chart Image**
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
