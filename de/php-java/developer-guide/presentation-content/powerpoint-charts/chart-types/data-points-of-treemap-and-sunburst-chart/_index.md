---
title: Datenpunkte von Treemap- und Sunburst-Diagramm
type: docs
url: /de/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Sunburst-Diagramm in Aspose.Slides für PHP über Java"
description: "Sunburst-Diagramm, Sunburst-Diagramm, Sunburst-Chart, Radialdiagramm, Radialgraph oder Mehrstufiges Tortendiagramm mit Aspose.Slides für PHP über Java."
---

Unter den anderen Arten von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst-Diagramm, Sunburst-Diagramm, Radialdiagramm, Radialgraph oder Mehrstufiges Tortendiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind - von den Blättern bis zur Spitze des Zweigs. Blätter werden durch die Serien-Datenpunkte definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für PHP über Java ermöglicht das Formatieren der Datenpunkte von Sunburst-Diagramm und Treemap.

Hier ist ein Sunburst-Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lass uns mit dem Hinzufügen eines neuen Sunburst-Diagramms zur Präsentation beginnen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sunburst-Diagramms**](/slides/de/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Falls es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) Klassen 
und [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) Methode 
stellen den Zugriff zum Formatieren der Datenpunkte von Treemap- und Sunburst-Diagrammen bereit. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)
wird verwendet, um auf mehrstufige Kategorien zuzugreifen - es repräsentiert den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) Objekten.
Im Grunde genommen ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) mit
den spezifischen Eigenschaften für Datenpunkte. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) hat
zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) die
Zugriff auf die entsprechenden Einstellungen bereitstellen.
## **Datenpunktwert anzeigen**
Wert des "Blatt 4" Datenpunkts anzeigen:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktetikett und -farbe festlegen**
Datenetikett für "Zweig 1" so einstellen, dass stattdessen der Serienname ("Series1") angezeigt wird. Dann die Textfarbe auf Gelb setzen:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Datenpunkt-Zweigfarbe festlegen**
Farbe des "Dampfer 4"-Zweigs ändern:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)