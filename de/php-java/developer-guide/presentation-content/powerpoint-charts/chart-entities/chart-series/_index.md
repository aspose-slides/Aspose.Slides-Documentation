---
title: Diagrammdatenserien in Präsentationen mit PHP verwalten
linktitle: Datenserien
type: docs
url: /de/php-java/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsmappenzelle
- Serienabstand
- Negativer Wert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Abstandsbreiten und negative Werte in Präsentationen mit PHP verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Eine [ChartSeries](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/) stellt einen Satz zusammenhängender Werte dar, und jeder [ChartDataPoint](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/) in der Serie verweist auf eine oder mehrere Zellen der Arbeitsmappe. [ChartCategory](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartcategory/)‑Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [ChartDataCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatacell/)‑Objekten verknüpft und nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriediagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#getCell) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation prüfen Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serienebene, wie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getFormat), legen das Standard‑Aussehen für alle Punkte einer Serie fest.
- Einstellungen für einzelne Datenpunkte, wie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getFormat), überschreiben das Serien‑Aussehen für einen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [ChartSeriesGroup](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseriesgroup/) gehören. Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Abstandsbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serien‑Füllung festgelegt ist, bestimmen Diagramm‑Stil und -Design das automatische Aussehen. Wenn sowohl Serien‑ als auch Punkt‑Formatierungen vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Festlegen der Überlappung von Diagrammserien**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getOverlap) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von –100 bis 100 Prozent. Es handelt sich um eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Verwenden Sie [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseriesgroup/#setOverlap), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst nicht nicht zugehörige Seriengruppen in einem Kombinationsdiagramm.

Das folgende Beispiel legt die Überlappung für die Gruppe fest, die die erste Serie enthält:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
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

## **Ändern der Füllfarbe einer Serie**

Verwenden Sie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getFormat), um die Standard‑Füllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getFormat) die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einheitliche blaue Füllung auf die erste Serie an:

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

## **Ändern des Seriennamens**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Variablen im folgenden Beispiel machen diese Struktur explizit:

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

Sie können auch die bereits von [ChartSeries.getName](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getName) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über bestimmte Zeilen und Spalten in einem vorhandenen Diagramm:

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

## **Abrufen der automatischen Serien‑Füllfarbe**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) gibt die Farbe zurück, die aus dem Serien‑Index und dem Diagramm‑Stil berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standard‑Serie aus:

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

## **Invertieren der Füllfarbe für eine Diagrammserie**

Für Balken‑, Säulen‑ und Blasendiagramme kann [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#setInvertIfNegative) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serien‑Füllung auf einfarbig, aktivieren Sie die Inversion und weisen Sie die Farbe für negative Werte über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

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

Sie können die Inversion für einen einzelnen Punkt über [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) aktivieren. Im folgenden Beispiel ist die Inversion für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar wird:

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

## **Löschen eines bestimmten Datenpunktwerts**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [ChartDataPoint.getValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getValue) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, das Diagramm behandelt seinen Wert jedoch als leer gemäß den Einstellungen für leere Werte.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

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

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapointcollection/#clear) auf, wenn Sie die übrigen Punkte behalten wollen, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Festlegen der Abstandsbreite einer Serie**

Die Abstandsbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, angegeben als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseriesgroup/#setGapWidth) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

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

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/)‑Aufzählung repräsentiert werden, verwenden Diagrammdaten, jedoch haben ihre Serien nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Bubble‑Größen. Verwenden Sie die Daten‑Punkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Abstandsbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Serien‑Gruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseriesgroup/) enthält kompatible Serien, die gruppen‑bezogene Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe, die über eine Serie erreicht wird, nicht zwingend jede Serie im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [ShapeCollection.addChart](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addChart) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl Serien‑ als auch Kategoriensammlungen leeren, bevor Sie einen vollständig benutzerdefinierten Datensatz hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappen‑Zellen verknüpft?**

Serien‑Namen, Kategorien‑Beschriftungen und Daten‑Punkt‑Werte referenzieren Zellen in einem [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie Kategorie‑Zeilen und Serien‑Wert‑Zeilen ausrichten, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen Punkt anstatt der gesamten Serie?**

Setzen Sie die zugehörige Wert‑Zelle auf `null`, um die Kategorienposition des Punkts als leeren Punkt zu behalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapointcollection/#clear) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Wenn Sie zusätzlich Kategorien entfernen, aktualisieren Sie jede Serie, damit deren Werte mit der Kategorien‑Sammlung ausgerichtet bleiben.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und von der über [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/#setDisplayBlanksAs) konfigurierten Einstellung ab. Unterstützte Diagramme können Leerräume als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme rufen Sie [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#setInvertIfNegative) auf und setzen die Farbe, die über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zurückgegeben wird. Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Daten‑Punkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serien‑Format oder, wenn das Serien‑Format nicht definiert ist, den automatischen Diagramm‑Stil und das Design. Gruppeneinstellungen wie Überlappung und Abstandsbreite steuern das Layout und sind keine punkt‑bezogenen Formatierungs‑Überschreibungen.

**Gibt es ein Limit für die Anzahl der Serien, die ein Diagramm enthalten kann?**

Aspose.Slides legt kein separates festes Serien‑Zahlen‑Limit fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Render‑Zeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseriesgroup/#setGapWidth) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.