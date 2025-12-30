---
title: Trendlinien zu Präsentationsdiagrammen in PHP hinzufügen
linktitle: Trendlinie
type: docs
url: /de/php-java/trend-line/
keywords:
- diagramm
- trendlinie
- exponentielle trendlinie
- lineare trendlinie
- logarithmische trendlinie
- gleitender durchschnitt trendlinie
- polynomialtrendlinie
- potenztrendlinie
- benutzerdefinierte trendlinie
- PowerPoint
- präsentation
- PHP
- Aspose.Slides
description: "Trendlinien schnell zu PowerPoint-Diagrammen hinzufügen und anpassen mit Aspose.Slides für PHP via Java – ein praktischer Leitfaden, um Ihr Publikum zu fesseln."
---

## **Trendlinie hinzufügen**
Aspose.Slides für PHP via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie die Referenz einer Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType::ClusteredColumn verwendet).
4. Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1.
5. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
6. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
7. Hinzufügen einer Trendlinie für gleitenden Durchschnitt für Diagrammreihe 2.
8. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
9. Hinzufügen einer Potenz‑Trendlinie für Diagrammreihe 3.
10. Speichern Sie die geänderte Präsentation in einer PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Erstellen eines gruppierten Säulendiagramms
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Exponentielle Trendlinie für Diagrammreihe 1 hinzufügen
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Lineare Trendlinie für Diagrammreihe 1 hinzufügen
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Gleitender Durchschnitt Trendlinie für Diagrammreihe 2 hinzufügen
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Polynomialtrendlinie für Diagrammreihe 3 hinzufügen
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Potenztrendlinie für Diagrammreihe 3 hinzufügen
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Präsentation speichern
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für PHP via Java bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die nachstehenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse
- Holen Sie die Referenz einer Folie anhand ihres Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode des Shapes‑Objekts
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape‑Methode des Shapes‑Objekts hinzu
- Legen Sie die Farbe der Formlinien fest.
- Speichern Sie die geänderte Präsentation als PPTX‑Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. hinten projiziert werden: Für Streudiagramme (XY) – in Achseneinheiten; für Nicht‑Streudiagramme – in Anzahl der Kategorien. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie in ein Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/) und rendert Diagramme in Bilder; Trendlinien, als Teil des Diagramms, bleiben bei diesen Vorgängen erhalten. Außerdem steht eine Methode zum [Exportieren eines Bildes des Diagramms](/slides/de/php-java/create-shape-thumbnails/) selbst zur Verfügung.