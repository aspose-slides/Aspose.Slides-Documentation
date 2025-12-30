---
title: Anpassen von Bubble-Diagrammen in Präsentationen mit PHP
linktitle: Bubble-Diagramm
type: docs
url: /de/php-java/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Skalierung der Größe
- Darstellung der Größe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen leistungsstarker Bubble-Diagramme in PowerPoint mit Aspose.Slides for PHP via Java, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Bubble-Chart Größenskalierung**
Aspose.Slides for PHP via Java bietet Unterstützung für die Skalierung der Größe von Bubble‑Charts. In Aspose.Slides for PHP via Java wurden die Methoden [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--) , [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) und [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) hinzugefügt. Unten wird ein Beispiel angegeben.  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Daten als Bubble‑Chart‑Größen darstellen**
Den Schnittstellen [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries) und [IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) sowie den zugehörigen Klassen wurden die Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Chart dargestellt werden. Mögliche Werte sind: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) und [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Entsprechend wurde das Aufzählungs‑Element [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) hinzugefügt, um die möglichen Darstellungsarten zu definieren. Beispielcode ist unten angegeben.  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wird ein „bubble chart with 3‑D effect“ unterstützt und wie unterscheidet es sich von einem regulären Diagramm?**

Ja. Es gibt einen separaten Diagrammtyp, „Bubble with 3‑D“. Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Klasse verfügbar.

**Gibt es eine Begrenzung für die Anzahl von Serien und Punkten in einem Bubble‑Chart?**

Es gibt keine feste Begrenzung auf API‑Ebene; Einschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Anzahl der Punkte für Lesbarkeit und Rendering‑Geschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Charts aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering wird von der Aspose.Slides‑Engine durchgeführt. Für Raster‑/Vektor‑Formate gelten die allgemeinen Regeln für Diagramm‑Grafik‑Rendering (Auflösung, Anti‑Aliasing), wählen Sie daher eine ausreichende DPI für den Druck.