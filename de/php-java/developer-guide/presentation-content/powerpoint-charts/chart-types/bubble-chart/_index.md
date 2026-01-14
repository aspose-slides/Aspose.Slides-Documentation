---
title: Bubble-Diagramme in Präsentationen mit PHP anpassen
linktitle: Bubble-Diagramm
type: docs
url: /de/php-java/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Größenskalierung
- Größenrepräsentation
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Bubble-Diagramme in PowerPoint mit Aspose.Slides für PHP via Java an, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Skalierung der Bubble-Chart-Größe**
Aspose.Slides for PHP via Java bietet Unterstützung für die Skalierung der Bubble-Chart-Größe. In Aspose.Slides for PHP via Java wurden die Methoden [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) und [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) hinzugefügt. Nachfolgend ein Beispiel.
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


## **Daten als Bubble-Chart-Größen darstellen**
Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) wurden zu den Klassen [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) und verwandten Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Chart dargestellt werden. Mögliche Werte sind: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) und [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Dementsprechend wurde das Aufzählungselement [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) hinzugefügt, um die möglichen Darstellungsweisen von Daten als Bubble‑Chart‑Größen zu spezifizieren. Beispielcode ist unten angegeben.
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

**Wird ein "Bubble-Chart mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem normalen?**

Ja. Es gibt einen eigenen Diagrammtyp „Bubble mit 3‑D“. Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Klasse [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) verfügbar.

**Gibt es eine Begrenzung für die Anzahl von Serien und Datenpunkten in einem Bubble‑Chart?**

Auf API‑Ebene gibt es keine feste Obergrenze; Einschränkungen ergeben sich aus der Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit angemessen zu halten.

**Wie wirkt sich ein Export auf das Aussehen eines Bubble‑Charts aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering wird von der Aspose.Slides‑Engine durchgeführt. Für Raster‑/Vektor‑Formate gelten allgemeine Rendering‑Regeln für Diagramme (Auflösung, Kantenglättung), daher sollte für den Druck ein ausreichender DPI‑Wert gewählt werden.