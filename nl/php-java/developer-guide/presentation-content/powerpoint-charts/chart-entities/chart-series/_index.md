---
title: Beheer grafiekgegevensreeksen in presentaties met PHP
linktitle: Gegevensreeksen
type: docs
url: /nl/php-java/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datapunt
- werkboekcel
- reeksgatbreedte
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties kunt beheren met PHP."
---
## **Overzicht**

Een grafiek slaat de weergegeven gegevens op in een grafiek‑databoek. Een [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [ChartCategory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartcategory/)‑objecten bieden de labels of groepeer‑waarden die door de reeksen gedeeld worden. De naam van de reeks, de categorieën en de puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/#getCell) worden doorgegeven, zijn nul‑gebaseerd. Deze opzet is handig wanneer je een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek dit gebruikt. Voor een geladen presentatie, inspecteer de cellen die door de reeksen, categorieën en datapunten worden aangeduid voordat je werkboekwaarden wijzigt.

Grafiek‑instellingen hebben drie verschillende bereikniveaus:

- Instellingen op reeksniveau, zoals [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat), bieden de standaarduitstraling voor alle punten in één reeks.
- Instellingen per datapunt, zoals [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat), overschrijven de reeks‑uitstraling voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die behoren tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/). Benader de groep via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getParentSeriesGroup) wanneer je opties wilt instellen zoals overlapping of gat‑breedte.

Wanneer geen expliciete punt‑ of reeks‑vulling is ingesteld, bepalen de grafiek‑stijl en het thema de automatische uitstraling. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![grafiekreeks-powerpoint](chart-series-powerpoint.png)

## **De overlapping van de grafiekreeks instellen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getOverlap) geeft weer hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeks‑groep. Gebruik [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setOverlap) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiek‑typen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde reeks‑groepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlapping in voor de groep die de eerste reeks bevat:

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

![De overlapping van de reeks](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [ChartSeries.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getFormat) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getFormat) instelling de reeks‑vulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

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

## **De naam van de reeks wijzigen**

Een reekstenaam wordt opgeslagen in het grafiek‑databoek en normaal weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomgrafiek, staat cel B1 op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt aangeduid door [ChartSeries.getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getName). Deze aanpak vermijdt een aanname over een bepaalde rij of kolom in een bestaande grafiek:

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

![De naam van de reeks](series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) retourneert de kleur die wordt berekend op basis van de reeks‑index en de grafiek‑stijl. Dit is de kleur die wordt gebruikt wanneer de reeks‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij wijst geen nieuwe vulling toe.

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

Voorbeeldoutput voor de standaardgrafiek‑stijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiek‑stijl en het thema.

## **Inverteer de vulkleur voor een grafiekreeks**

Voor balk‑, kolom‑ en bubbel‑reeksen kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatieve waarden met een andere vulling weergeven. Stel de gewone reeks‑vulling in op effen, schakel inversie in en ken de negatieve‑waarde‑kleur toe via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergave‑kleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiek‑gegevens door één reeks. Werkblad‑rij 0 bevat de reekstenaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Je kunt inversie voor één punt inschakelen via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `null`. Voor een kolomgrafiek is de weergegeven waarde beschikbaar via [ChartDataPoint.getValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getValue). Het datapunt blijft op dezelfde categoriep­ositie, maar de grafiek behandelt zijn waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

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

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubbel‑grafieken gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **De gat‑breedte van de reeks instellen**

Gat‑breedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort het tot de bovenliggende reeks‑groep in plaats van tot één reeks. Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) eenmaal aan voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gat‑breedte en slaat alleen de uiteindelijke presentatie op:

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

![De gat‑breedte](gap_width.png)

## **FAQ**

**Welke grafiek‑typen ondersteunen dataseries?**

Alle grafiek‑typen die door de [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken grafiek‑data, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, scatter‑grafieken gebruiken X‑ en Y‑waarden, en bubbel‑grafieken voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlapping en gat‑breedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑level plot‑instellingen delen. Een combinatie‑grafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaarddata?**

Ja. Standaard creëert [ShapeCollection.addChart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addChart) voorbeeldreeksen, -categorieën en -waarden. Je kunt die cellen bewerken of zowel de reeksen‑ als de categorie‑collecties wissen voordat je een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaarddata maken.

**Hoe zijn grafiek‑objecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en datapunt‑waarden verwijzen naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/). Het veranderen van een aangeduide cel werkt het overeenkomstige grafiekelement bij. Wanneer je aangepaste data bouwt, houd je rijen met categorieën en rijen met reeks‑waarden uitgelijnd zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointcollection/#clear) alleen wanneer je alle punten uit die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiek‑type en de waarde die is geconfigureerd via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setDisplayBlanksAs). Ondersteunde grafieken kunnen lege punten weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende data in je presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑reeksen, roep [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setInvertIfNegative) aan en stel de kleur in die wordt geretourneerd door [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Je kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet gedefinieerd is, de automatische grafiek‑stijl en het thema. Groepsinstellingen zoals overlapping en gat‑breedte bepalen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal reeksen. In de praktijk bepalen bestands‑beperkingen van de presentatie, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Roep [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) aan op de betreffende bovenliggende reeks‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag de waarde om de clusters dichter bij elkaar te brengen.