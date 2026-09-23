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
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenbeschriftungen zeigen Informationen zu Diagrammserien und einzelnen Datenpunkten an und helfen den Lesern, Werte zu erkennen und das Diagramm zu verstehen. Dieser Artikel erklärt, wie man Werte formatiert, Prozentsätze anzeigt, Beschriftungstext ausliest, den Abstand von Achsenbeschriftungen der Kategorie anpasst und Beschriftungen von Kreisdiagrammen positioniert.

## **Präzision der Daten in Diagrammbeschriftungen festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#setNumberFormatOfValues), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertebeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

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

## **Prozentsätze als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsumme seiner Kategorie und weisen den Text dem Textfeld zu, das von [getTextFrameForOverriding](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8-Punkt-Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

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

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabelformat/#setNumberFormat), um Prozentsätze anzuzeigen. Übergeben Sie `false` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jede Wertepaarung summiert sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0.30 als 30.0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Beschriftungen mit 10 Punkt Schriftgröße.

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

## **Den tatsächlichen Text von Datenbeschriftungen auslesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#getActualLabelText), um den Text abzurufen, der durch die Einstellungen einer Datenbeschriftung erzeugt wird. Dies ist nützlich, wenn Beschriftungen für Berichte extrahiert, Präsentationsinhalte durchsucht oder erzeugte Diagramme validiert werden. Im nachstehenden Beispiel kombiniert das Standard-[Datenbeschriftungsformat](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabelformat/) jeden Kategorienamen, Seriennamen und Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, und ein anderer verwendet benutzerdefinierten Text aus [getTextFrameForOverriding](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn ihre Beschriftung `75%` zusammen mit dem Kategorienamen und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den generierten Beschriftungstext. [getActualLabelText](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#getActualLabelText) gibt in beiden Fällen die resultierende Beschriftungszeichenfolge zurück. Prüfen Sie [isVisible](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#isVisible) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Abstand der Beschriftung von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/de/php-java/aspose.slides/axis/#setLabelOffset), um den Abstand zwischen den Achsenbeschriftungen der Kategorie und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den Beschriftungsversatz der Horizontalachse auf 500. Diese Einstellung wirkt sich auf die Achsenbeschriftungen der Kategorie aus, nicht auf Beschriftungen, die einzelnen Datenpunkten zugeordnet sind.

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

In einem Kreisdiagramm passen Sie die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Führungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Segmentes und passt seine horizontalen sowie vertikalen Versätze mit [setX](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#setX) und [setY](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabel/#setY) an. Diese Versätze sind relativ zur Diagrammbreite bzw. -höhe.

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

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Führungslinien und kleinere Schriftgröße; bei Bedarf können Sie einige Felder (z.B. die Kategorie) ausblenden oder Beschriftungen nur für Extremwerte bzw. Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für Null-, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Legen Sie die Schriftfamilie und -größe explizit fest und überprüfen Sie, dass die Schrift in der Renderumgebung verfügbar ist, um einen Rückgriff zu vermeiden.