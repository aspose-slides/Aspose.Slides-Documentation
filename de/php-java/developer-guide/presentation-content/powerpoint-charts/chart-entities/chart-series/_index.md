---
title: Diagrammdatenreihen in Präsentationen mit PHP verwalten
linktitle: Datenreihen
type: docs
url: /de/php-java/chart-series/
keywords:
- Diagrammreihe
- Reihenüberlappung
- Reihenfarbe
- Reihenname
- Datenpunkt
- Arbeitsmappenzelle
- Reihenabstand
- Negativwert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammreihen, Datenpunkte, Arbeitsmappendateien, Formatierung, Überlappung, Abstandsbreite und negative Werte in Präsentationen mit PHP verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Ein [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) in der Reihe bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/)‑Objekte liefern die Bezeichnungen oder Gruppierungswerte, die von den Reihen gemeinsam genutzt werden. Der Reihen‑Name, die Kategorien und die Punktwerte sind daher mit [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/)‑Objekten verknüpft und nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategorien‑Diagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Reihen‑Namen, Spalte 0 für Kategorienamen und die übrigen Zellen für Reihen‑Werte. Arbeitsblatt‑, Zeilen‑ und Spalten‑Indizes, die an [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation prüfen Sie die von den Reihen, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsmappen‑Werte ändern.

Diagramm‑Einstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Reihen‑Ebene, wie [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), legen das Standard‑Aussehen für alle Punkte einer Reihe fest.
- Daten‑Punkt‑Einstellungen, wie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat), überschreiben das Reihen‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Reihen, die derselben [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) angehören. Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Abstandsbreite festlegen müssen.

Wenn kein expliziter Punkt‑ oder Reihen‑Füllwert gesetzt ist, bestimmen Diagramm‑Stil und -Design das automatische Aussehen. Wenn sowohl Reihen‑ als auch Punkt‑Formatierung vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Festlegen der Überlappung von Diagramm‑Reihen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von –100 bis 100 Prozent. Es handelt sich um eine schreibgeschützte Projektion der Einstellung in der übergeordneten Reihen‑Gruppe. Verwenden Sie [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap), um jede kompatible Reihe in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst keine nicht zugehörigen Reihen‑Gruppen in einem Kombinations‑Diagramm.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Reihe enthält:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Das neue Diagramm enthält Beispielsreihen, Kategorien und Werte.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The series overlap](series_overlap.png)

## **Ändern der Füllfarbe einer Reihe**

Verwenden Sie [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), um die Standard‑Füllung für eine gesamte Reihe festzulegen. Wenn ein Punkt bereits eine explizite Füllung besitzt, überschreibt dessen [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) die Reihen‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine durchgehende blaue Füllung auf die erste Reihe an:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The color of the series](series_color.png)

## **Ändern des Reihen‑Namens**

Ein Reihen‑Name wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulen‑Diagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Reihe. Die benannten Variablen im folgenden Beispiel machen diese Struktur explizit:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sie können auch die Zelle aktualisieren, die bereits von [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) referenziert wird. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The series name](series_name.png)

### **Erstellen einer Reihe mit einem Namen aus mehreren Zellen**

Ein zusammengesetzter Reihen‑Name ist nützlich, wenn ein Produktname und ein Berichtszeitraum in separaten Arbeitsmappen‑Zellen gespeichert sind. Beispielsweise können Sie `Product A` in B1 und `2026` in C1 zu einem einzigen Reihen‑Namen kombinieren, wobei beide Teile mit ihren Quellzellen verknüpft bleiben.

Verwenden Sie [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection), um den Namens‑Bereich abzurufen, und übergeben Sie diese Sammlung an [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add). Das Argument `skipHiddenCells` steuert, ob versteckte Zellen einbezogen werden: `true` schließt sie aus, `false` schließt sie ein. Dieses Beispiel verwendet `false`, um jede Zelle im Namens‑Bereich einzubeziehen.

Das folgende Beispiel erzeugt eine Präsentation mit einer Reihe und zwei Datenpunkten. Die Zellen B1:C1 liefern ausschließlich den Reihen‑Namen; A2:A3 liefern die Kategorienamen, und B2:B3 liefern die numerischen Werte.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Diese beiden Zellen liefern den Namen der Reihe.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Separate Zellen liefern die Kategorien und numerischen Datenpunkte.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der resultierende Reihen‑Name lautet `Product A 2026`, mit einem Leerzeichen zwischen den beiden Zellwerten. Die Legende zeigt dies als einen Eintrag für beide Spalten an. Das Bild unten veranschaulicht das Ergebnis:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Abrufen der automatischen Reihen‑Füllfarbe**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) gibt die aus dem Reihen‑Index und dem Diagramm‑Stil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Reihen‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standard‑Reihe aus:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Beispielausgabe für den Standard‑Diagramm‑Stil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagramm‑Stil und -Design ab.

## **Invertierte Füllfarbe für eine Diagramm‑Reihe festlegen**

Für Balken‑, Säulen‑ und Blasen‑Reihen kann [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) negative Werte mit einer anderen Füllung anzeigen. Legen Sie die reguläre Reihen‑Füllung auf durchgehend fest, aktivieren Sie die Invertierung und setzen Sie die Farbe für negative Werte über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur die Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Reihe. Arbeitsblatt‑Zeile 0 enthält den Reihen‑Namen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Invertierung für einen einzelnen Punkt über [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) aktivieren. Im folgenden Beispiel ist die Invertierung für die Reihe deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar wird:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Löschen eines spezifischen Datenpunkt‑Werts**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugrunde liegende Arbeitsmappen‑Zelle auf `null`. Für ein Säulen‑Diagramm ist der geplottete Wert über [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue) verfügbar. Der Datenpunkt bleibt an derselben Kategorien‑Position, aber das Diagramm behandelt seinen Wert gemäß den Einstellungen für leere Werte als leer.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Reihe:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasen‑Diagramme benötigen zudem eine Größen‑Zelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert repräsentiert. Rufen Sie nicht [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Steuerung der Anzeige leerer Zellen**

Versteckte Zellen, die Werte enthalten, stellen einen anderen Fall dar als leere Zellen. Um Daten aus versteckten Arbeitsblatt‑Zeilen und -Spalten ein‑ bzw. auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappen‑Zelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Rufen Sie [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) mit `null` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs), um zu wählen, wie das Diagramm leere Zellen anzeigt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Reihe, löscht den Wert für Tag 3 und speichert das gleiche Diagramm in jedem Modus. Keine Eingabedatei ist erforderlich. Das [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Reihen‑Namen. Die endgültigen Daten sind `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Lassen Sie Tag 3 wirklich leer, während Sie seine Kategorie und den Datenpunkt beibehalten.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal statt über alle Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagramm‑Typ ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulen‑Diagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das oben gezeigte Verbindungssegment erzeugen kann; eine fehlende Säule und eine Null‑Höhen‑Säule können ebenfalls ähnlich aussehen. Ebenso hat ein Scatter‑Diagramm nur Marker und keine verbindende Linie. Erwarten Sie nicht für jeden Diagramm‑Typ drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen genutzten Typ.

## **Festlegen der Abstandsbreite von Reihen**

Die Abstandsbreite ist der Raum zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulen‑Breite. Wie bei der Überlappung gehört sie zur übergeordneten Reihen‑Gruppe und nicht zu einer einzelnen Reihe. Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Raum zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Abstandsbreite und speichert nur die endgültige Präsentation:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenreihen?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑Aufzählung dargestellt werden, verwenden Diagrammdaten, jedoch haben ihre Reihen nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Zum Beispiel verwenden Kategorien‑Diagramme Kategorien und Werte, Scatter‑Diagramme X‑ und Y‑Werte und Blasen‑Diagramme zusätzlich Blasengrößen. Verwenden Sie die Daten‑Punkt‑Erstellungsmethode, die zum Reihen‑Typ passt. Optionen wie Überlappung und Abstandsbreite gelten nur für kompatible Balken‑ oder Säulen‑Gruppen.

**Was ist eine Diagramm‑Reihen‑Gruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) enthält kompatible Reihen, die gruppenweite Plot‑Einstellungen teilen. Ein Kombinations‑Diagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Reihe nicht zwingend alle Reihen im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) Beispiel‑Reihen, -Kategorien und -Werte. Sie können diese Zellen bearbeiten oder sowohl die Reihen‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein vollständig benutzerdefiniertes Datenset hinzufügen. Eine Überladung kann ebenfalls ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagramm‑Objekte mit Arbeitsmappen‑Zellen verknüpft?**

Reihen‑Namen, Kategorien‑Beschriftungen und Daten‑Punkt‑Werte referenzieren Zellen in einem [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagramm‑Element. Wenn Sie eigene Daten erstellen, halten Sie die Kategorie‑Zeilen und Reihen‑Werte‑Zeilen ausgerichtet, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen Punkt, ohne die gesamte Reihe zu entfernen?**

Setzen Sie die entsprechende Werte‑Zelle auf `null`, um die Kategorie‑Position des Punktes als leeren Punkt zu behalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) nur, wenn Sie alle Punkte dieser Reihe entfernen möchten. Entfernen Sie zudem nicht die Kategorien, ohne die Reihen so zu aktualisieren, dass ihre Werte weiterhin mit der Kategorien‑Sammlung übereinstimmen.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagramm‑Typ und der über [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) konfigurierten Einstellung ab. Unterstützte Diagramme können Lücken als Lücken, als Null‑Werte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Steuerung der Anzeige leerer Zellen](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasen‑Reihen rufen Sie [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) auf und setzen die über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zurückgegebene Farbe. Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welches Format gewinnt, wenn sowohl eine Reihe als auch ein Punkt formatiert sind?**

Explizite Daten‑Punkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Reihen‑Format oder, wenn das Reihen‑Format nicht definiert ist, den automatischen Diagramm‑Stil und das Design. Gruppeneinstellungen wie Überlappung und Abstandsbreite steuern das Layout und sind keine Punkt‑Level‑Formatierungs‑Overrides.

**Gibt es ein Limit für die Anzahl der Reihen in einem Diagramm?**

Aspose.Slides legt kein separates festes Limit für die Reihen‑Anzahl fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Render‑Zeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu nah beieinander oder zu weit auseinander liegen?**

Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) für die entsprechende übergeordnete Reihen‑Gruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.