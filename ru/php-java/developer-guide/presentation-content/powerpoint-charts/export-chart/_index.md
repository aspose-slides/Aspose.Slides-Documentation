---
title: Экспорт диаграммы
type: docs
weight: 90
url: /php-java/export-chart/
---

## **Получить изображение диаграммы**
Aspose.Slides для PHP через Java предоставляет поддержку для извлечения изображения конкретной диаграммы. Ниже приведен пример кода.

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