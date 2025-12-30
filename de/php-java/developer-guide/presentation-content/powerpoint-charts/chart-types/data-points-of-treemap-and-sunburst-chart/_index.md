---
title: Datenpunkte in Treemap- und Sunburst-Diagrammen mit PHP anpassen
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Zweigfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für PHP via Java verwalten, kompatibel mit PowerPoint-Formaten."
---

Unter den verschiedenen PowerPoint‑Diagrammtypen gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Chart, Radial‑Graph oder Mehrstufiges‑Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten an, die als Baum strukturiert sind – von den Blättern bis hin zur Spitze des Astes. Die Blätter werden durch die Datenpunkte der Reihe definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für PHP via Java ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und der Treemap.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Beginnen wir damit, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # …
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen von Sunburst‑Diagrammen**](/slides/de/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Falls es nötig ist, Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)‑Klassen 
und [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--)‑Methode 
bieten Zugriff zum Formatieren von Datenpunkten der Treemap‑ und Sunburst‑Diagramme. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)
wird zum Zugriff auf mehrstufige Kategorien verwendet – er stellt den Container für 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)‑Objekte dar.
Im Grunde ist er ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) mit
den für Datenpunkte spezifisch hinzugefügten Eigenschaften. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)‑Klasse besitzt
zwei Methoden: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) und 
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) , die
Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Wert eines Datenpunkts anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunkt‑Beschriftung und -Farbe festlegen**
Beschriftung des Datenpunkts „Branch 1“ so einstellen, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Anschließend die Textfarbe auf Gelb setzen:
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe eines Datenpunkt‑Zweiges festlegen**
Farbe des Zweiges „Steam 4“ ändern:
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

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert Segmente automatisch (in der Regel absteigend, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Die Reihenfolge kann nicht direkt geändert werden; sie wird durch Vorverarbeitung der Daten erreicht.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben erben das [Theme/Palette](/slides/de/php-java/presentation-theme/) der Präsentation, sofern nicht explizit Füllungen/Schriften gesetzt werden. Für konsistente Ergebnisse sollten feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festgelegt werden.

**Bleiben benutzerdefinierte Zweig‑Farben und Beschriftungseinstellungen beim Export in PDF/PNG erhalten?**

Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabeformaten erhalten, da Aspose.Slides das Diagramm mit den angewandten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um benutzerdefinierte Overlays über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen die tatsächlichen *x*- und *y*-Werte für Elemente (z. B. ein [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)) zur Verfügung, was eine präzise Platzierung von Overlays ermöglicht.