---
title: Beheer diagramreeksgegevens in presentaties in PHP
linktitle: Gegevensreeksen
type: docs
url: /nl/php-java/chart-series/
keywords:
- diagramreeks
- reeks overlapping
- reeks kleur
- reeks naam
- datapunt
- werkboekcel
- reeks tussenruimte
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkboekcellen, opmaak, overlapping, tussenruimtebreedte en negatieve waarden in presentaties met PHP kunt beheren."
---
## **Overzicht**

Een diagram slaat zijn weergegeven gegevens op in een chart‑data‑werkboek. Een [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) in de reeks verwijst naar één of meer werkboekcellen. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/)-objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. De reeksennaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/)-objecten in plaats van alleen als weergavetekst opgeslagen.

Voor een typische categorie‑grafiek gebruikt het standaard‑werkboek rij 0 voor reeksenamen, kolom 0 voor categorienamen en de resterende cellen voor reeksenwaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram deze indeling hanteert. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeks, categorieën en datapunten verwijzen voordat u werkboekwaarden wijzigt.

Instellingen voor diagrammen hebben drie verschillende scopes:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), bieden de standaardweergave voor alle punten in één reeks.  
- Instellingen op datapuntniveau, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de weergave van de reeks voor één punt.  
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer u opties zoals overlapping of tussenruimtebreedte moet instellen.

Wanneer geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑formattering aanwezig zijn, heeft de punt‑formattering voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van de Overlapping van de Grafiekreeks**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatiediagram.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste reeks bevat:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
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

Het resultaat:

![The series overlap](series_overlap.png)

## **Wijzig de Opvulkleur van de Reeks**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat)-instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste reeks:

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

Het resultaat:

![The color of the series](series_color.png)

## **Wijzig de Naam van de Reeks**

Een reeksennaam wordt opgeslagen in het diagram‑data‑werkboek en wordt normaal gesproken in de legenda weergegeven. In het standaard‑werkboek dat wordt aangemaakt voor een gegroepeerd kolomdiagram, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt verwezen door [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName). Deze benadering voorkomt dat u een bepaalde rij en kolom in een bestaand diagram aanneemt:

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

Het resultaat:

![The series name](series_name.png)

### **Maak een Reeks met een Naam uit Meerdere Cellen**

Een samengestelde reeksennaam is handig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen zijn opgeslagen. Bijvoorbeeld, u kunt `Product A` in B1 en `2026` in C1 combineren tot één reeksennaam terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) om het naam‑bereik op te halen en geef die collectie door aan [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapunten. Cellen B1:C1 leveren alleen de reeksennaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

    // Deze twee cellen leveren de reeksennaam.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Aparte cellen leveren de categorieën en numerieke datapunten.
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

De resulterende reeksennaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één vermelding voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Haal de Automatische Opvulkleur van de Reeks Op**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die is berekend op basis van de reeksenindex en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld geeft de automatische kleur van elke standaardreeks weer:

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

Voorbeeldoutput voor de standaarddiagramstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Stel Inverterende Opvulkleur In voor een Grafiekreeks**

Voor balk‑, kolom‑ en bubbelformats kunnen [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op egaal, schakel inversie in en ken de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één reeks. Werkblad‑rij 0 bevat de reeksennaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Het resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt tevens een negatieve waarde, zodat het effect zichtbaar is:

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

## **Verwijder een Specifieke Datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de weergegeven waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorielocatie, maar het diagram behandelt zijn waarde als leeg volgens de instellingen voor lege waarden van het diagram.

Het volgende voorbeeld verwijdert alleen het tweede punt in de eerste reeks:

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

Spreidingsdiagrammen gebruiken aparte X‑ en Y‑cellen, en bubbeldiagrammen gebruiken ook een groottecel. Verwijder alleen de cel die de waarde vertegenwoordigt die u wilt weghalen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Beheer de Weergave van Lege Cellen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Include Data from Hidden Rows and Columns](/slides/nl/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) voor het opnemen of uitsluiten van gegevens uit verborgen rijen en kolommen.

Een lege werkboekcel vertegenwoordigt ontbrekende gegevens; een cel met `0` vertegenwoordigt een bekende numerieke waarde. Roep [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Hij verandert hoe lege waarden worden uitgezet, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, maakt de waarde voor Dag 3 leeg en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksennaam. De uiteindelijke gegevens zijn `10, 20, leeg, 30, 40`.

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

    // Laat dag 3 werkelijk leeg, terwijl de categorie en het datapunt behouden blijven.
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

Elke uitvoerbestand slaat de modus op die vóór het opslaan is toegewezen: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs de gewenste modus toe en sla de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt het makkelijk om de drie modi te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om te verbinden over een ontbrekende categorie, dus `Span` kan het verbindingssegment niet genereren zoals hierboven weergegeven; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook gelijk uitzien. Evenzo heeft een spreidingsdiagram met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat u gebruikt.

## **Stel de Tussenruimtebreedte van de Reeks In**

Tussenruimtebreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort deze instelling tot de bovenliggende reeksgroep in plaats van tot één reeks. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer aan voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimtebreedte en slaat alleen de uiteindelijke presentatie op:

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

Het resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)-enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriediagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bubbeldiagrammen voegen bubbelgroottes toe. Gebruik de methode voor het maken van datapunten die overeenkomt met het type reeks. Opties zoals overlapping en tussenruimtebreedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plot‑instellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet noodzakelijk elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeksen‑ als de categorie‑collecties wissen voordat u een volledig aangepast gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Reeksenamen, categorielabels en datapuntwaarden verwijzen naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Het wijzigen van een verwijzende cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens bouwt, houd dan de categorierijen en reeksen‑waardereeksen op elkaar afgestemd zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waarde‑cel in op `null` om de positie van de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden op één lijn blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die is geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visueel vergelijk.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelformats, roep [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stel de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlapping en tussenruimtebreedte regelen de lay‑out en zijn geen point‑level opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestandsbeperkingen van de presentatie, beschikbare geheugen, render‑tijd en leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende reeksgroep. Vergroot de waarde om de ruimte tussen clusters te verbreden, of verklein de waarde om de clusters dichter bij elkaar te brengen.