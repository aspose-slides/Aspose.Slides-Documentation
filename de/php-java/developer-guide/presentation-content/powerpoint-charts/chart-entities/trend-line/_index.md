---
title: Trendlinien zu Präsentationsdiagrammen in PHP hinzufügen
linktitle: Trendlinie
type: docs
url: /de/php-java/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- Trendlinie für gleitenden Durchschnitt
- polynomiale Trendlinie
- Potenztrendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Fügen Sie Trendlinien in PowerPoint-Diagrammen schnell hinzu und passen Sie sie mit Aspose.Slides für PHP via Java an – ein praktischer Leitfaden, um Ihr Publikum zu fesseln."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Trendlinien zu Präsentationsdiagrammen mithilfe von Aspose.Slides hinzufügen. Er zeigt, wie ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzugefügt und mit verschiedenen Trendlinientypen gearbeitet wird, darunter exponentiell, linear, logarithmisch, gleitender Durchschnitt, polynomial und Potenz.

Er beschreibt außerdem, wie Sie eine benutzerdefinierte Linie zu einem Diagramm hinzufügen, indem Sie eine Linienform einfügen, und enthält ein kurzes FAQ zu Vorwärts‑ und Rückwärtsprojektionen von Trendlinien sowie zur Frage, ob Trendlinien beim Export in PDF oder SVG und beim Rendern von Diagrammen als Bilder erhalten bleiben.

## **Trendlinie hinzufügen**

Verwenden Sie [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/), um einer Diagrammserie eine Trendlinie hinzuzufügen, und wählen Sie deren Typ mit [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Das Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten und fügt jeder seiner drei Serien zwei Trendlinien hinzu.

Die exponentielle Trendlinie blendet ihre Gleichung und den Bestimmtheitsmaßwert über [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) und [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/) aus, während die lineare Trendlinie rot ist. Die logarithmische Trendlinie verwendet [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) für ein benutzerdefiniertes Beschriftungsfeld. Der gleitende Durchschnitt nutzt ein [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) von drei Datenpunkten und einen benutzerdefinierten [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Die polynomiale Trendlinie hat die Ordnung drei, festgelegt über [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), und erstreckt sich eine Kategorie vorwärts über [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Die Potenz‑Trendlinie erstreckt sich eine Kategorie rückwärts über [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Trendlinien‑Achsenabschnitt festlegen**

Verwenden Sie [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/), um den Y‑Wert einer Trendlinie bei X = 0 zu fixieren. Diese Einstellung wird für lineare, exponentielle und polynomial Trendlinien unterstützt.

Ein Beispiel: Ein Produktionskostenmodell muss bei bekannten Fixkosten von 100 beginnen, selbst wenn Messungen bei nicht‑null Produktionsvolumina eine andere Basislinie nahelegen. Für eine lineare Trendlinie zwingt das Fixieren des Achsenabschnitts die Gleichung `y = ax + b` zu `b = 100`; die Steigung wird unter dieser Vorgabe an die Daten angepasst. Es wird nicht einfach eine bereits angepasste Linie verschoben. Achsenkreuzungs‑Einstellungen bestimmen, wo die Diagrammachsen sich treffen, nicht die Koeffizienten der angepassten Trendlinie.

Das folgende Beispiel erstellt ein Streudiagramm (XY) mit Produktionsvolumina von 1 bis 4 und Kosten von 170, 200, 230 und 260. Es speichert das Diagramm mit dem automatisch berechneten Achsenabschnitt, setzt den Achsenabschnitt auf 100 und speichert ein zweites PPTX. Die beiden Dateien unterscheiden sich nur durch die Achsenabschnitt‑Einstellung. Die Trendlinie zeigt ihre Gleichung und erstreckt sich zurück zu X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bei automatischer Berechnung ergeben diese Daten `y = 30x + 140`. Das Festlegen des Achsenabschnitts auf 100 liefert etwa `y = 43,33x + 100`: Der angepasste Wert bei Null stimmt mit der bekannten Basislinie überein, während die Linie nicht mehr durch jeden Datenpunkt verläuft.

| Automatischer Achsenabschnitt | Fester Achsenabschnitt von 100 |
| --- | --- |
| ![Lineare Trendlinie mit automatisch berechnetem Achsenabschnitt von 140](intercept-automatic.png) | ![Lineare Trendlinie mit festem Achsenabschnitt von 100](intercept-fixed.png) |

Beide Bilder verwenden dieselben Daten und Achsenskalierungen. Die Trendlinien wurden zurück zu X = 0 erweitert, um ihre Achsenabschnitte zu zeigen.

Standardmäßig gibt [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) **NaN** zurück, was einen nicht spezifizierten Achsenabschnitt anzeigt und nicht Null bedeutet. Der Achsenabschnitt wird dann automatisch aus den Daten berechnet.

## **Benutzerdefinierte Linie hinzufügen**

Eine benutzerdefinierte Linie ist eine Form, die über das Diagramm gezeichnet wird, anstatt eine aus den Seriendaten berechnete Trendlinie zu sein. Dieses Beispiel verwendet [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/), um eine horizontale Linie zur Folie über dem Diagramm hinzuzufügen. Die Position der Linie wird in Folienkoordinaten angegeben, gemessen in Punkten, sodass sie am linken Rand des Diagramms beginnt und halbwegs in der Höhe liegt. Ihre Breite entspricht der Diagrammbreite. Mit [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) erhält die Linie eine einheitliche rote Farbe.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Was bedeuten „vorwärts“ und „rückwärts“ bei einer Trendlinie?**

Sie geben die Länge der Trendlinie an, die vorwärts bzw. rückwärts projiziert wird: Bei Streudiagrammen (XY) in Achseneinheiten; bei Nicht‑Streudiagrammen in Kategorien. Nur nichtnegative Werte sind zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild erhalten bleiben?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/) oder [SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien bleiben als Teil des Diagramms bei diesen Vorgängen erhalten. Es gibt außerdem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/php-java/create-shape-thumbnails/).