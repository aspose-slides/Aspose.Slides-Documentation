---
title: Exporter le graphique
type: docs
weight: 90
url: /fr/php-java/export-chart/
---

## **Obtenir l'image du graphique**
Aspose.Slides pour PHP via Java prend en charge l'extraction de l'image d'un graphique spécifique. Un exemple de code est donné ci-dessous.

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