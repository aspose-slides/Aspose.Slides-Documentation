---
title: Export Chart
type: docs
weight: 90
url: /java/export-chart/
---

## **Get Chart Image**
Aspose.Slides for .NET provides support for extracting image of specific $chart-> Below sample example is given. 

```php
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 50, 50, 600, 400);

    $img = $chart->getThumbnail();
    
    Java("javax.imageio.ImageIO")->write($img, "PNG", new Java("java.io.File", "image.png"));
} catch (JavaException $e) {
} finally {
    if ($pres != null) $pres->dispose();
}
```