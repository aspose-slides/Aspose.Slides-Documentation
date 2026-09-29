---
title: Beheer diagramgegevensreeksen in presentaties in PHP
linktitle: Datareeksen
type: docs
url: /nl/php-java/chart-series/
keywords:
- diagramreeks
- reeks overlap
- reeks kleur
- reeksnaam
- datapunt
- werkmapcel
- reeks tussenruimte
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkmapcellen, opmaak, overlap, tussenruimte en negatieve waarden in presentaties kunt beheren met PHP."
---
## **Overzicht**

Een diagram slaat de weergegeven gegevens op in een chart‑data‑werkmap. Een [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/) in de reeks verwijst naar één of meer werkmapcellen. [ChartCategory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartcategory/)‑objecten leveren de labels of groepeerwaarden die door de reeksen gedeeld worden. De reeksnaam, categorieën en puntwaarden zijn daardoor gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categorie‑diagram gebruikt de standaardwerkmap rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is bruikbaar wanneer je een diagram met standaardgegevens maakt, maar ga niet ervan uit dat elk bestaand diagram het gebruikt. Voor een geladen presentatie inspecteer je de cellen die door de reeksen, categorieën en gegevenspunten worden geraadpleegd voordat je werkmapwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat), bieden de standaardweergave voor alle punten in één reeks.
- Instellingen per gegevenspunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de reeksweergave voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep krijg je via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer je opties moet instellen zoals overlap of tussenruimte.

Wanneer er geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![diagram‑reeks‑powerpoint](chart-series-powerpoint.png)

## **Overlap van de diagramreeks instellen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling in de bovenliggende reeksgroep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatie‑diagram.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

![De reeks‑overlap](series_overlap.png)

## **Kleur van de reeksvulling wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een gehele reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de reeksvulling voor dat punt.

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

![De kleur van de reeks](series_color.png)

## **Naam van de reeks wijzigen**

Een reeksnaam wordt opgeslagen in de diagram‑datwerkmap en normaal weergegeven in de legenda. In de standaardwerkmap die voor een gegroepeerde kolomdiagram wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getName). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

![De reeksnaam](series_name.png)

## **Automatische reeksvulkleur ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de reeks‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeks‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

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

## **Invulkleur omkeren voor een diagramreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere reeksvulling in op egaal, schakel inversie in en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één reeks. Werkbladrij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

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

![De omgekeerde egale vulling](inverted_solid_fill_color.png)

Je kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Specifieke gegevenspuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkmapcel in op `null`. Voor een kolomdiagram is de weergegeven waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getValue). Het gegevenspunt blijft op dezelfde categorielocatie staan, maar het diagram behandelt de waarde als leeg volgens de instelling voor lege waarden van het diagram.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

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

Scatter‑diagrammen gebruiken aparte X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde representeert die je wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de collectie.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een ander geval dan lege cellen. Zie [Include Data from Hidden Rows and Columns](/slides/nl/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) om gegevens uit verborgen werkbladrijen en –kolommen op te nemen of uit te sluiten.

Een lege werkmapcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell::setValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setValue) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Hij verandert hoe lege waarden worden geplot, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3 en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
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

Elk uitvoerbestand slaat de vóór het opslaan toegewezen modus op: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, wijs je de gewenste modus toe en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elke werkmap leeg:

![Lijndiagrammen met identieke gegevens: Gap onderbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomdiagrammen hebben geen lijn die over een ontbrekende categorie kan verbinden, dus `Span` kan het verbindingssegment niet produceren dat hierboven wordt getoond; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑diagram met alleen markeringen geen verbindingslijn. Verwacht geen drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat je gebruikt.

## **Tussenruimte (gap width) van de reeks instellen**

De tussenruimte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze aan de bovenliggende reeksgroep en niet aan één reeks. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer aan voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de tussenruimte en slaat alleen de uiteindelijke presentatie op:

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

![De tussenruimte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die door de [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, scatter‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het maken van gegevenspunten die past bij het type reeks. Opties zoals overlap en tussenruimte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een diagramreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatie‑diagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, wijzigt niet noodzakelijk elke reeks in het diagram.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard creëert [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addChart) voorbeeldreeksen,‑categorieën en -waarden. Je kunt die cellen bewerken of zowel de reeks‑ als de categorieverzamelingen wissen voordat je een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens maken.

**Hoe zijn diagramobjecten gekoppeld aan werkmapcellen?**

Reeksnamen, categorielabels en waarden van gegevenspunten refereren aan cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/). Het veranderen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer je aangepaste gegevens bouwt, houd je de rijen met categorieën en de rijen met reeks‑waarden op één lijn zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de betreffende waarde‑cel in op `null` om de positie van het punt in de categorie behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden blijven aansluiten op de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setDisplayBlanksAs) geconfigureerde waarde. Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nul‑waarden of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in je presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen roep je [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stel je de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Je kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete punt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepsinstellingen zoals overlap en tussenruimte regelen de layout en vormen geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet voor het aantal reeksen op. In de praktijk bepalen bestands‑beperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij of te ver van elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.