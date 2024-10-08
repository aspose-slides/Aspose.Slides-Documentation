---
title: Trendlinie
type: docs
url: /de/php-java/trend-line/
---

## **Trendlinie hinzufügen**
Aspose.Slides für PHP über Java bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet ChartType::ClusteredColumn).
1. Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
1. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
1. Hinzufügen einer gleitenden Durchschnitts-Trendlinie für Diagrammreihe 2.
1. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
1. Hinzufügen einer potenziellen Trendlinie für Diagrammreihe 3.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Erstellen eines gruppierten Säulendiagramms
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Hinzufügen einer exponentiellen Trendlinie für Diagrammreihe 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Hinzufügen einer linearen Trendlinie für Diagrammreihe 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("Neue log-Trendlinie");
    # Hinzufügen einer gleitenden Durchschnitts-Trendlinie für Diagrammreihe 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("Neuer Trendlinienname");
    # Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Hinzufügen einer potenziellen Trendlinie für Diagrammreihe 3
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
Aspose.Slides für PHP über Java bietet eine einfache API, um benutzerdefinierte Linien in ein Diagramm einzufügen. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden
- Erstellen Sie ein neues Diagramm mit der Methode AddChart, die vom Shapes-Objekt bereitgestellt wird
- Fügen Sie eine AutoShape vom Typ Linie mit der Methode AddAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird
- Setzen Sie die Farbe der Linien des Shapes.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
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