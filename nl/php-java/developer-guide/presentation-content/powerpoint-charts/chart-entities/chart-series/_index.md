---
title: Beheer grafiekreeksen in presentaties met PHP
linktitle: Gegevensreeksen
type: docs
url: /nl/php-java/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- reeksnaam
- datapunt
- werkboekcel
- reeksgat
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunt, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties met PHP kunt beheren."
---
## **Overzicht**

Een grafiek kan zijn getekende waarden opslaan in werkboekcellen of rechtstreeks als numerieke literal. Een [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) vertegenwoordigt een set gerelateerde waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) vertegenwoordigt een punt in die reeks. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) objecten leveren de labels of groepeerwaarden die door de reeksen worden gedeeld. In grafieken die met standaardgegevens zijn gemaakt, gebruiken reeksnamen, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) objecten uit het werkboek van de grafiek.

Voor een typische categorie‑grafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswaarden. Werkblad‑, rij‑ en kolomindexen die aan [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is bruikbaar wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek dit gebruikt. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat u werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), bepalen de standaardweergave voor alle punten in één reeks.
- Instellingen op datapuntniveau, zoals [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), overschrijven de reeksweergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) behoren. Toegang tot de groep via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) wanneer u opties zoals overlap of gatbreedte moet instellen.

Wanneer er geen expliciete vulling voor punt of reeks is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntopmaak aanwezig zijn, heeft de puntopmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

Voor een gekloonde cilindergrafiek, zie hoe [het wijzigen van het 3D-reeks‑type of de balkvorm](/slides/nl/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) de eerste reeks beïnvloedt.

## **Reekswaarden instellen met numerieke literal**

Gebruik numerieke literal wanneer reekswaarden afkomstig zijn van toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) aan met [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) voordat u het resultaat van elk punt's [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) toewijst via [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

De collectie‑instelling bepaalt het brontype van alle puntwaarden in die reeks. De [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) methode van elke puntwaarde meldt het geselecteerde type; wijzig het via de collectie‑instelling. Met `Worksheet` gebruikt u [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) om de referentiecel te benaderen. Met `DoubleLiterals` gebruikt u [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) of `setAsLiteralDouble` om het getal rechtstreeks te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomgrafiek met standaardreeksen en -categorieën, en kent vervolgens berekende waarden van 10, 20, enzovoort toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw, en drukt de opgeslagen waarden af.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Het brontype van de puntwaarde staat los van [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), dat de interne of externe werkboekconfiguratie van de grafiek identificeert. Het gebruik van numerieke literal verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, reeksnamen en de andere reeksen. Zie [Chart Workbook](/slides/nl/php-java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbelfiguren gebruikt u [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) om de bronnen voor [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) en [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) te kiezen. Bubbelfiguren gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) voor [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Stel elke toepasbare bron in op `DoubleLiterals` voordat u getallen toewijst via de `setAsLiteralDouble`‑methode van die waarde.

## **Overlap van de grafiekrreeks instellen**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Gebruik [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op grafiektypes die gegroepeerde balken of kolommen tonen; hij beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

![The series overlap](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) instelling de reeksvulling voor dat punt.

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

![The color of the series](series_color.png)

## **De naam van de reeks wijzigen**

Een reeksnaam wordt opgeslagen in het grafiek‑werkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gekloonde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt verwezen door [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Deze aanpak voorkomt dat u een specifieke rij en kolom in een bestaande grafiek moet aannemen:

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

### **Een reeks maken met een naam uit meerdere cellen**

Een samengestelde reeksnamen is nuttig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen staan. Bijvoorbeeld, u kunt `Product A` in B1 en `2026` in C1 combineren tot één reeksnamen terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) om het naam‑bereik op te halen, en geef die collectie vervolgens door aan [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapunten. Cellen B1:C1 leveren alleen de reeksnamen; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

    // Deze twee cellen leveren de reeksnaam.
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

De resulterende reeksnamen is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één invoer voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **De automatische vulkleur van een reeks ophalen**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) retourneert de kleur die is berekend op basis van het reeks‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeks‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijzigt geen vulling.

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Omgekeerde vulkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelsreeks kan [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de gewone reeksvulling in op effen, schakel inversie in, en wijs de negatieve‑kleur toe via [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnamen, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

U kunt inversie voor één punt inschakelen via [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de achterliggende werkboekcel in op `null`. Voor een kolomgrafiek is de getekende waarde beschikbaar via [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Het datapunt blijft op dezelfde categorielocatie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden.

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

Spreidingsgrafieken gebruiken afzonderlijke X‑ en Y‑cellen, en bubbelfiguren gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten zijn een ander geval dan lege cellen. Zie [Gegevens opnemen uit verborgen rijen en kolommen](/slides/nl/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) om data uit verborgen werkbladrijen en -kolommen op te nemen of uit te sluiten.

Een lege werkboekcel staat voor ontbrekende data; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Ze verandert hoe lege punten worden getekend, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elk modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke data is `10, 20, leeg, 30, 40`.

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

    // Laat Dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
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

Elke uitvoer‑bestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt het makkelijk om alle drie de modi te vergelijken. Balk‑ en kolomgrafieken hebben geen lijn om over een ontbrekende categorie te verbinden, zodat `Span` geen verbindingssegment kan produceren zoals hierboven getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook vergelijkbaar uitzien. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht geen drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat u gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort dit tot de bovenliggende reeksgroep en niet tot een enkele reeks. Roep [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) eenmaal aan voor de groep. Een grotere waarde maakt meer ruimte tussen clusters; een kleinere waarde maakt ze dichter op elkaar.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

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

## **Reeks‑lijnen weergeven of verbergen**

Reeks‑lijnen verbinden visueel gerelateerde delen van een grafiek. Gebruik [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) om ze in ondersteunde gestapelde balk‑ en OfPie‑grafieken te tonen of te verbergen. In tweedimensionale gestapelde balk‑ en kolomgrafieken verbinden ze overeenkomstige stapelgrenzen over categorieën. In Pie‑of‑Pie‑ en Bar‑of‑Pie‑grafieken verbinden ze de hoofd‑plot met de secundaire plot. Deze instelling is geen algemene connector voor andere grafiektypes.

Krijg toegang tot de groep via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/). De instelling geldt voor elke reeks in die groep. [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) is alleen‑lezen en weerspiegelt de instelling van de bovenliggende groep; roep de setter van de groep aan om deze bij te werken.

Het volgende voorbeeld maakt één [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) grafiek met standaarddata. Het slaat dezelfde grafiek op met reeks‑lijnen ingeschakeld en vervolgens uitgeschakeld, waardoor twee presentaties voor vergelijking ontstaan.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Reeks‑lijnen ingeschakeld | Reeks‑lijnen uitgeschakeld |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| De twee lijnen verbinden de hoofd‑pie met de secundaire pie. | Beide pies blijven zichtbaar, maar de verbindingslijnen zijn verborgen. |

Reeks‑lijnen verschillen van “leader lines” van gegevenslabels, die labels met hun datapunten verbinden; van rasterlijnen, die intervallen langs de assen markeren; en van de lijnen in een lijngrafiek, die data‑waarden representeren. Deze instelling bestuurt die elementen niet.

## **FAQ**

**Welke grafiektypes ondersteunen reeksen?**

Alle grafiektypes die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) enumeratie gebruiken grafiekdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑grafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelfiguren voegen bubbelaantallen toe. Gebruik de methode voor datapuntcreatie die overeenkomt met het type reeks. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiek‑reeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatie‑grafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet per se elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaarddata?**

Ja. Standaard maakt [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeksen‑ als categoricollecties wissen voordat u een volledig eigen dataset toevoegt. Een overload kan ook een grafiek zonder standaarddata aanmaken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en datapuntwaarden verwijzen naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Het wijzigen van een verwezen cel werkt het overeenkomstige grafiekelement bij. Wanneer u eigen data opbouwt, houd dan categorie‑rijen en reeks‑waarde‑rijen op één lijn zodat elk punt onder de juiste categorie wordt getekend.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waarde‑cel in op `null` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden nog steeds op één lijn staan met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en de waarde die is geconfigureerd via [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Ondersteunde grafieken kunnen lege punten weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende data in uw presentatie. Zie [Weergave van lege cellen beheren](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelsreeksen, roep [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) aan en stel de kleur in die wordt geretourneerd door [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Deze methoden beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en -thema. Groepsinstellingen zoals overlap en gatbreedte regelen de lay‑out en zijn geen vervangende opmaak op puntniveau.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal reeksen. In de praktijk bepalen beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht of te ver uit elkaar staan?**

Roep [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) aan op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag hem om de clusters dichter bij elkaar te brengen.