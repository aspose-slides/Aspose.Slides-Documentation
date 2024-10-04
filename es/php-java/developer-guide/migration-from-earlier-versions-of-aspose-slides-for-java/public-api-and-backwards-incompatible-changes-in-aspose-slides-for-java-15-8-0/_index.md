---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP vía Java 15.8.0
type: docs
weight: 160
url: /es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc., [agregados](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) o [eliminados](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/), y otros cambios introducidos con la API de Aspose.Slides para PHP vía Java 15.8.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Los métodos getDoughnutHoleSize(), setDoughnutHoleSize(byte) han sido agregados a IChartSeries y ChartSeries**
Especifica el tamaño del agujero en un gráfico de dona.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```