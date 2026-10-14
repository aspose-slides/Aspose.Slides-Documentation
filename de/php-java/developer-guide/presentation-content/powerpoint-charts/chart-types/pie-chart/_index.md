---
title: Anpassen von Kuchendiagrammen in Präsentationen mit PHP
linktitle: Kuchendiagramm
type: docs
url: /de/php-java/pie-chart/
keywords:
- Kuchendiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und anpassen von Kuchendiagrammen in PHP mit Aspose.Slides. Sekundäre Plots konfigurieren, Datenbeschriftungen anzeigen und automatische Segmentfarben in PowerPoint anwenden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kuchendiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Plot-Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme konfiguriert und wie man die automatische Färbung von Segmenten für ein Standard‑Kuchendiagramm aktiviert.

Die Beispiele konzentrieren sich auf Aufgaben zur Diagrammanpassung, wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen der Standard‑Diagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für sekundäre Plots bei Pie of Pie‑ und Bar of Pie‑Diagrammen**

Aspose.Slides for PHP via Java unterstützt sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme. Diese Optionen steuern die Größe des sekundären Plots und wie Datenpunkte zwischen den beiden Plots aufgeteilt werden.

Das folgende Beispiel erstellt ein Pie of Pie‑Diagramm in einer neuen Präsentation und zeigt die Werte der Datenpunkte als Beschriftungen an. Die [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize)-Methode setzt die Größe des sekundären Plots auf 149% des Hauptplots. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) wählt eine prozentbasierte Aufteilung, und [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) setzt den Schwellenwert auf 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Werte anzeigen und den sekundären Plot konfigurieren.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Kategorien für den sekundären Plot auswählen**

Verwenden Sie benutzerdefinierte Aufteilung, wenn Sie bestimmte Kategorien im sekundären Plot zusammenfassen möchten, ungeachtet ihrer prozentualen Werte. Beispielsweise könnte ein Verkaufsbericht Online und Events gemeinsam anzeigen, damit die Leser diese beiden Kanäle vergleichen können, obwohl sie 35% bzw. 10% des Gesamtumsatzes ausmachen.

Rufen Sie [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) mit [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) auf und wählen Sie die Punkte über [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) aus. Die [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add)-Methode der Sammlung akzeptiert einen nullbasierten Index in der Reihe; verwenden Sie [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem), um ein Datenpunktobjekt hinzuzufügen. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls vorübergehend hinzugefügt und anschließend mit [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) ausgeschlossen.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Ersetzen Sie die Standarddaten durch Verkäufe nach Kanal.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Wählen Sie Online anhand seines nullbasierten Index und Events anhand seines Datenpunktobjekts aus.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Schließen Sie Partner von der Auswahl aus, ohne deren Quelldaten zu löschen.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Plot. Im primären Plot werden sie durch ein kombiniertes Segment mit einem Wert von 45 dargestellt, zusammen mit Einzelhandel (40) und Partner (15). Das Entfernen von Partnern aus der benutzerdefinierten Auswahl lässt sie im primären Plot bestehen; die Kategorie oder ihr Wert werden nicht aus den Quelldaten des Diagramms entfernt.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:
![Pie of Pie-Diagramm mit Online und Events im sekundären Plot und ihrem kombinierten Wert von 45 im primären Plot](pie_of_pie_custom.png)

## **Automatische Farben für Kuchen‑Diagramm‑Segmente festlegen**

Aspose.Slides for PHP via Java kann einem Kuchendiagramm automatisch unterschiedliche Farben für die Segmente zuweisen. Das folgende Beispiel erstellt ein Kuchendiagramm mit einem zentrierten Titel und ersetzt die Standarddaten durch drei vierteljährliche Kategorien und deren Werte. Die [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue)-Methode zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) für jedes Segment eine eigene Farbe aktiviert.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Zentrierten Diagrammtitel hinzufügen.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Ersetzen Sie die Standarddaten mit dem ersten Arbeitsblatt.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Werden die Pie of Pie‑ und Bar of Pie‑Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) einen sekundären Plot für Kuchendiagramme, einschließlich der Pie of Pie‑ und Bar of Pie‑Typen.

**Kann ich nur das Diagramm als Bild exportieren (zum Beispiel PNG)?**

Ja, Sie können [das Diagramm selbst als Bild exportieren](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (z. B. PNG), ohne die gesamte Präsentation zu exportieren.