---
title: Exportar Gráfico
type: docs
weight: 90
url: /php-java/export-chart/
---

## **Obtener Imagen del Gráfico**
Aspose.Slides para PHP a través de Java proporciona soporte para extraer la imagen de un gráfico específico. A continuación se presenta un ejemplo de muestra.

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