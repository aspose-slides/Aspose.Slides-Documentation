---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /php-java/export-chart/
---

## **الحصول على صورة الرسم البياني**
توفر Aspose.Slides لـ PHP عبر Java دعمًا لاستخراج صورة لرسم بياني محدد. إليك مثال بسيط أدناه.

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