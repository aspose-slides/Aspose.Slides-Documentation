---
title: Beheer grafiekreeks in presentaties in PHP
linktitle: Gegevensreeksen
type: docs
url: /nl/php-java/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkmapcel
- reeks gat
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunt, werkmapcellen, opmaak, overlapping, rasterbreedte en negatieve waarden in presentaties kunt beheren met PHP."
---
## **Overzicht**

Een grafiek slaat zijn geplotte gegevens op in een grafiek‑gegevenswerkmap. Een [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/) in de serie verwijst naar één of meer werkmapcellen. [ChartCategory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartcategory/)‑objecten leveren de labels of groeperingswaarden die door de series worden gedeeld. De serienaam, categorieën en puntwaarden zijn dus gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categoriemodelgrafiek gebruikt de standaardwerkmap rij 0 voor serienaam, kolom 0 voor categorienamen en de resterende cellen voor serie‑waarden. Werkblad‑, rij‑ en kolomindexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling hanteert. Voor een geladen presentatie moet u de cellen die door de series, categorieën en datapunten worden gerefereerd inspecteren voordat u werkmapwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende bereikniveaus:

- Instellingen op serieniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat), bieden de standaardweergave voor alle punten in één serie.
- Instellingen per datapunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen gelden voor compatibele series die behoren tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/). Toegang tot de groep krijgt u via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer u opties zoals overlap of rasterbreedte moet instellen.

Wanneer er geen expliciete vulling voor punt of serie is ingesteld, bepalen de grafiekstijl en het thema het automatisch uiterlijk. Wanneer zowel serie‑ als puntopmaak aanwezig zijn, heeft de puntopmaak de voorkeur voor dat punt.

![grafiekreeks-powerpoint](chart-series-powerpoint.png)

## **Instellen van de serie‑overlap**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getOverlap) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende serie‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele serie in die groep bij te werken. Deze optie geldt voor grafiektype die gegroepeerde balken of kolommen weergeven; het beïnvloedt geen ongerelateerde serie‑groepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
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

![De serie‑overlap](series_overlap.png)

## **De vulkleur van de serie wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een gehele serie in te stellen. Als een punt al een expliciete vulling heeft, dan overschrijft de [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat)‑instelling de serie‑vulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

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

![De kleur van de serie](series_color.png)

## **De serienaam wijzigen**

Een serienaam wordt opgeslagen in de grafiek‑gegevenswerkmap en wordt normaal weergegeven in de legenda. In de standaardwerkmap die wordt aangemaakt voor een gegroepeerde kolomgrafiek bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getName). Deze aanpak voorkomt dat u een specifieke rij en kolom aanneemt in een bestaande grafiek:

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

![De serienaam](series_name.png)

## **De automatische vulkleur van de serie ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die berekend wordt op basis van de serie‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld drukt de automatische kleur af van elke standaardserie:

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Negatieve vullingkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelreeksen kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de reguliere serie‑vulling in op effen, schakel inversie in, en ken de kleur voor negatieve waarden toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde effen vulkleur](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde, zodat het effect zichtbaar is:

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

## **Een specifieke datapuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkmapcel in op `null`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

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

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen beheren**

Een lege werkmapcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell::setValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/#setValue) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setDisplayBlanksAs) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Het verandert hoe lege waarden worden geplot, zonder de lege werkmapcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met één serie, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke gegevens zijn `10, 20, leeg, 30, 40`.

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

    // Laat dag 3 echt leeg, maar behoud de categorie en het datapunt.
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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in de werkmap:

![Lijngrafieken met identieke data: Gap verbreekt de lijn op Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi goed vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie heen te verbinden, zodat `Span` de verbindingssegment niet kan produceren zoals hierboven weergegeven; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook gelijk uitzien. Evenzo heeft een scatter‑grafiek met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de uitvoer voor het type dat u gebruikt.

## **De rasterbreedte van de serie instellen**

Rasterbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort het tot de bovenliggende serie‑groep in plaats van tot één serie. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) één keer aan voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de rasterbreedte en slaat alleen de uiteindelijke presentatie op:

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

![De rasterbreedte](gap_width.png)

## **FAQ**

**Welke grafiektype ondersteunen dataseries?**

Alle grafiektype die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun series hebben niet allemaal dezelfde waardestruktuur of instellingen. Bijvoorbeeld, categoriemodellen gebruiken categorieën en waarden, scatter‑grafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de methode voor het maken van datapunt die overeenkomt met het serietype. Opties zoals overlap en rasterbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiek‑serie‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep via één serie verandert niet noodzakelijk elke serie in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addChart) voorbeeld‑series, categorieën en waarden aan. U kunt die cellen bewerken of zowel de serie‑ als categorieverzamelingen wissen voordat u een volledig eigen gegevensset toevoegt. Een overload kan ook een grafiek maken zonder standaardgegevens.

**Hoe zijn grafiekobjecten verbonden met werkmapcellen?**

Serienamen, categorielabels en datapuntwaarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens opstelt, houd de rijen voor categorieën en de rijen voor serie‑waarden op elkaar afgestemd zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe verwijder ik één punt in plaats van de hele serie?**

Stel de betreffende waarde‑cel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden blijven afgestemd op de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde grafieken kunnen leems weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series roept u [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische grafiekstijl en het thema. Groepsinstellingen zoals overlap en rasterbreedte bepalen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan hoeveel series een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatiedocument, beschikbare geheugen, render‑tijd en de leesbaarheid van de grafiek een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar staan of te ver uit elkaar liggen?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de juiste bovenliggende serie‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.