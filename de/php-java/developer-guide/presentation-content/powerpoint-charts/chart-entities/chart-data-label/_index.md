---
title: Diagrammdatenbeschriftungen in Präsentationen mit PHP verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/php-java/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mithilfe von Aspose.Slides für PHP via Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen über Diagrammserien und einzelne Datenpunkte an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie Werte formatiert, Prozentsätze angezeigt, Beschriftungstexte gelesen, Beschriftungen über das Achsenmaximum hinaus gesteuert, der Abstand der Kategorienachsenbeschriftungen angepasst und Beschriftungen von Kreisdiagrammen positioniert werden.

## **Datenpräzision in Diagrammdbeschriftungen festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertebeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu verändern.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um die numerischen Zellen in der eingebetteten Arbeitsmappe eines Diagramms zu formatieren, siehe [Set Custom Number Formats for Workbook Cells](/slides/de/php-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Dieses Beispiel zeigt außerdem, dass Wertebeschriftungen den Formaten ihrer Quellzelle folgen, während die gespeicherten numerischen Werte erhalten bleiben.

## **Prozentsatz als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz seiner Gesamtkategorie und weisen den Text dem Textfeld zu, das von [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8-Punkt-Schrift an. Kategorien mit einer Gesamtsumme von null werden übersprungen, um eine Division durch null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Prozentzeichen mit Diagrammbeschriftungen festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/), um Prozentsätze anzuzeigen. Übergeben Sie `false` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/), um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jedes Wertepaar summiert sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0,30 als 30,0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Beschriftungen mit 10 Punkten.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Den tatsächlichen Text von Datenbeschriftungen lesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/), um den von den Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich beim Extrahieren von Beschriftungen für Berichte, beim Durchsuchen von Präsentationsinhalten oder beim Validieren erzeugter Diagramme. Im folgenden Beispiel kombiniert das Standard-[Datenbeschriftungsformat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) jeden Kategorienamen, Seriennamen und Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, und ein anderer verwendet benutzerdefinierten Text von [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn seine Beschriftung `75%` zusammen mit dem Kategorien‑ und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den erzeugten Beschriftungstext. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) gibt in beiden Fällen die resultierende Beschriftungszeichenfolge zurück. Prüfen Sie [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Datenbeschriftungen über das Achsenmaximum hinaus steuern**

Wenn Sie einen Achsenbereich manuell begrenzen, können einige Datenpunkte ihr Maximum überschreiten. Verwenden Sie [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/), um zu steuern, ob ihre Datenbeschriftungen angezeigt werden. Diese Einstellung ändert die Sichtbarkeit der Beschriftungen; sie ändert weder den Achsenbereich noch die zugrunde liegenden Datenwerte.

Das nachstehende Beispiel erstellt ein 2D gruppiertes Säulendiagramm mit den Werten 60 und 120. Es übergibt `false` an [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) und setzt das Maximum auf 100 mit [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) auf der vertikalen Achse. Die erste Folie erlaubt Beschriftungen über dem Maximum; eine Kopie dieser Folie deaktiviert sie. Beide Folien werden in `DataLabelsOverMaximum.pptx` gespeichert.

Aktivieren Sie Wertebeschriftungen mit [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Die Diagrammebene-Einstellung aktiviert die Anzeige von Werten nicht von selbst und überschreibt nicht die deaktivierte Wertanzeige einer einzelnen Beschriftung. Dieses Beispiel aktiviert Werte für die gesamte Serie und verwendet [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/), um die Beschriftungen am äußeren Ende jeder Spalte zu platzieren.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die folgenden Bilder zeigen die gespeicherten Folien, die von Microsoft PowerPoint gerendert wurden. Bei `true` ist die Beschriftung **120** an der oberen Grenze sichtbar; bei `false` ist sie ausgeblendet. Die Beschriftung **60** bleibt sichtbar, das Achsenmaximum bleibt bei **100** und der zweite Datenpunkt bleibt in beiden Fällen **120**.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint‑Diagramm, das die Wertebeschriftung 120 bei einem Achsenmaximum von 100 zeigt](data-labels-over-maximum-true.png) | ![PowerPoint‑Diagramm, das die Wertebeschriftung 120 bei einem Achsenmaximum von 100 ausblendet](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dieses Beispiel verwendet ein 2D Säulendiagramm mit einer Wertachse. Diagramme ohne Wertachse, wie Kreis- und Donutdiagramme, haben kein Achsenmaximum, das auf diese Weise begrenzt werden kann.
{{% /alert %}}

## **Beschriftungsabstand von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/), um den Abstand zwischen den Beschriftungen der Kategorienachse und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den Beschriftungsversatz der Horizontalen Achse auf 500. Diese Einstellung wirkt sich auf die Kategorienachsenbeschriftungen aus, nicht auf Beschriftungen, die einzelnen Datenpunkten zugeordnet sind.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Beschriftungsposition anpassen**

Bei einem Kreisdiagramm passen Sie die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Verbindungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Segments und passt seine horizontalen und vertikalen Versätze mit [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) und [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) an. Diese Versätze beziehen sich jeweils auf die Diagrammbreite bzw. -höhe.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Kreisdiagramm mit angepasster Datenbeschriftungsposition](pie-chart-adjusted-label.png)

## **Verbindungslinien formatieren**

Wenn Kreisdiagrammbeschriftungen außerhalb ihrer Segmente liegen, helfen Verbindungslinien den Lesern, jeden Wert dem richtigen Segment zuzuordnen. Eine kontrastierende Farbe und eine etwas dickere Linie können diese Verbindungen leichter nachvollziehbar machen, während Transparenz und ein gestrichelter Stil die Linien visuell unauffällig halten.

Verwenden Sie [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/), um Verbindungslinien auf Ebene der Datenbeschriftungssammlung einer Serie zu formatieren. Die Einstellungen in `$series->getLabels()->getLeaderLinesFormat()->getLine()` gelten für die Sammlung und nicht für eine einzelne Beschriftung.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten, zeigt Werte außerhalb der Segmente an und aktiviert [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Es verschiebt zwei Beschriftungen weiter von ihren Segmenten weg, indem es [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) und [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) Versätze verwendet, ausgedrückt als Bruchteile der Diagrammbreite und -höhe. Keine Eingabepräsentation ist erforderlich.

Das [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) der Linie legt eine durchgehend blaue Farbe mit einem Alpha‑Wert von 191 von 255 fest, was etwa 25 % Transparenz ergibt. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) setzt die Dicke auf 2 Punkte, und [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) macht die Linie gestrichelt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // Verschieben Sie zwei Beschriftungen weiter von ihren Segmenten entfernt.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Aktivieren von Verbindungslinien garantiert nicht, dass für jede Beschriftung eine Linie erscheint. Die Sichtbarkeit hängt von der Platzierung der Beschriftung und dem Layoutverhalten des Diagramms ab. In diesem Beispiel haben die beiden versetzten Beschriftungen sichtbare Verbindungslinien; die Beschriftungen, die nahe ihren Segmenten bleiben, benötigen keine.

Das folgende Bild zeigt die gespeicherte `FormattedLeaderLines.pptx`, die mit Aspose.Slides gerendert wurde:

![Kreisdiagramm mit blauen, halbtransparenten, gestrichelten Verbindungslinien, die zwei externe Beschriftungen mit ihren Segmenten verbinden](formatted-leader-lines.png)

## **Mehrere Zeilen von Datenbeschriftungen über einem Säulendiagramm hinzufügen**

Dieses Beispiel erstellt ein Säulendiagramm mit zwei Zeilen von Datenbeschriftungen über dem Plot‑Bereich. Serie A zeigt die sichtbaren Spalten, während Serie B und Serie C die zusätzlichen Beschriftungen bereitstellen. Ihre Spalten werden ausgeblendet, indem Füllung und Kontur entfernt werden. Die Methode [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) richtet alle drei Serien an den gleichen Kategorienzentren aus.

Die Einstellungen des [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) reservieren Platz für die Beschriftungszeilen. Nachdem [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) die Standardpositionen berechnet hat, bewahren [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) und [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) die horizontale Ausrichtung und wenden vertikale Versätze an, um die Beschriftungen in zwei Zeilen anzuordnen. Die Zahlen bleiben Datenbeschriftungen, die mit den Serienwerten verknüpft sind; nur die Zeilenüberschriften sind separate Textformen.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // Verstecke die Spalten von B und C, aber behalte ihre Datenbeschriftungen bei.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // Alle drei Serien an den gleichen Kategorienzentren ausrichten.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Weniger Gitternetzlinien für dieses kompakte Beispiel verwenden.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Platz über dem Diagrammbereich für zwei Zeilen Datenbeschriftungen reservieren.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // Behalte die Standard‑Horizontposition bei. Y ist ein Versatz von der
            // Standard‑Beschriftungsposition, ausgedrückt als Bruchteil der Diagrammhöhe.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Nur die Zeilenüberschrift ist eine separate Textform.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Säulendiagramm mit zwei Zeilen von Datenbeschriftungen über dem Plot‑Bereich](multiple-rows-of-labels.png)


## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Verbindungslinien und reduzierte Schriftgröße; bei Bedarf Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für Extremwerte bzw. Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für Null-, Negative‑ oder Leere‑Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Setzen Sie explizit die Schriftfamilie und -größe und stellen Sie sicher, dass die Schrift im Rendering‑Umfeld verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.