---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für PHP über Java 15.8.0
type: docs
weight: 160
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) oder [entfernten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für PHP über Java 15.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen an der öffentlichen API**
#### **Methoden getDoughnutHoleSize(), setDoughnutHoleSize(byte) wurden zu IChartSeries und ChartSeries hinzugefügt**
Spezifiziert die Größe des Lochs in einem Donut-Diagramm.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
  $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
  $pres->save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat::Pptx);

```