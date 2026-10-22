---
title: Beheer diagramreeksgegevens in presentaties in PHP
linktitle: Gegevensreeks
type: docs
url: /nl/php-java/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- reeksnaam
- datumpunt
- werkboekcel
- reeks gatbreedte
- negatieve waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u diagramreeksen, datapunten, werkboekcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties met PHP kunt beheren."
---
## **Overzicht**

Een diagram kan zijn uitgevoerde waarden opslaan in werkboekcellen of direct als numerieke lettertekens. Een [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) vertegenwoordigt één reeks gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) vertegenwoordigt een punt in die reeks. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen worden gedeeld. In diagrammen die met standaardgegevens zijn aangemaakt, gebruiken reeksnamen, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/)‑objecten uit het diagram‑werkboek.

Voor een typische categorie‑diagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet van uit dat elk bestaand diagram die indeling gebruikt. Voor een geladen presentatie, inspecteer de cellen waarnaar de reeksen, categorieën en datapunten verwijzen voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), bieden het standaard uiterlijk voor alle punten in één reeks.
- Instellingen per datumpunt, zoals [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), overschrijven het reeks‑uithoudingspatroon voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) behoren. Gebruik [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) wanneer u opties wilt instellen zoals overlapping of gatbreedte.

Wanneer er geen expliciete punt‑ of reeks‑opvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![grafiek-serie-powerpoint](chart-series-powerpoint.png)

## **Reekswaarden instellen met numerieke lettertekens**

Gebruik numerieke lettertekens wanneer reekswaarden afkomstig zijn van toepassingsgegevens of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Roep [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) aan met [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) vóór het toewijzen van elk punt’s [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)‑resultaat via [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

De collectie‑instelling regelt het bron‑type van alle puntwaarden in die reeks. Elke puntwaarde’s [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/)‑methode meldt het geselecteerde type; wijzig het via de collectie‑instelling. Met `Worksheet` gebruikt u [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) om toegang te krijgen tot de verwezen cel. Met `DoubleLiterals` gebruikt u [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) of `setAsLiteralDouble` om het getal direct te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaardreeksen en -categorieën, en wijst vervolgens berekende waarden 10, 20, enz. toe aan de bestaande punten van de eerste reeks. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

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

Het bron‑type van de puntwaarde staat los van [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke lettertekens verwijdert op zichzelf het ingesloten werkboek niet. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, reeksnamen en de andere reeksen. Zie [Chart Workbook](/slides/nl/php-java/chart-workbook/) voor werkboekbeheer.

Voor spreidings‑ en bubbel‑diagrammen gebruikt u [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) en [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) om de bronnen voor [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) en [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) te kiezen. Bubbel‑diagrammen gebruiken ook [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) voor [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Stel elke toepasselijke bron in op `DoubleLiterals` vóór het toewijzen van getallen via de `setAsLiteralDouble`‑methode van die waarde.

## **Overlap van de diagramreeks instellen**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) meldt hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeks‑groepsreeks. Gebruik [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde reeks‑groepen in een combinatiediagram.

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

![De reeks‑overlap](series_overlap.png)

## **De vulkleur van de reeks wijzigen**

Gebruik [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) instelling de reeksvulling voor dat punt.

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

## **De reeksnaam wijzigen**

Een reeksnaam wordt opgeslagen in het diagram‑werkboek en wordt normaal gesproken in de legenda weergegeven. In het standaardwerkboek dat voor een gegroepeerde kolomdiagram wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde variabelen in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt verwezen door [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

### **Een reeks maken met een naam uit meerdere cellen**

Een samengestelde reeksnaam is handig wanneer een productnaam en een rapportage‑periode in aparte werkboekcellen zijn opgeslagen. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één reeksnaam, terwijl beide delen gekoppeld blijven aan hun bron‑cellen.

Gebruik [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) om het naam‑bereik op te halen, en geef die collectie vervolgens door aan [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Het argument `skipHiddenCells` bepaalt of verborgen cellen worden meegenomen: `true` sluit ze uit, `false` neemt ze op. Dit voorbeeld gebruikt `false` om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee datapunten. Cellen B1:C1 leveren alleen de reeksnaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

De resulterende reeksnaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één vermelding voor beide kolommen. De afbeelding hieronder illustreert het resultaat:

![Kolomdiagram met Noord‑ en Zuid‑waarden en de samengestelde reeksnaam Product A 2026 in de legenda](composite_series_name.png)

## **De automatische vulkleur van de reeks ophalen**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) retourneert de kleur die wordt berekend op basis van de reeksenindex en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeks‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; hij kent geen nieuwe vulling toe.

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

## **Inverted‑vulkleur voor een diagramreeks instellen**

Voor balk‑, kolom‑ en bubbel‑reeksen kan [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) negatieve waarden met een andere vulling weergeven. Stel de gewone reeks​vulling in op effen, activeer inversie en wijs de negatieve‑waarde‑kleur toe via [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

U kunt inversie voor één punt activeren via [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke datumpuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `null`. Voor een kolomdiagram is de uitgevoerde waarde beschikbaar via [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Het datumpunt blijft op dezelfde categorie‑positie, maar het diagram beschouwt de waarde als leeg volgens de leeg‑waarde‑instellingen van het diagram.

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

Spreidingsdiagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken tevens een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **Weergave van lege cellen beheersen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen werkbladrijen en -kolommen wel of niet op te nemen, zie [Include Data from Hidden Rows and Columns](/slides/nl/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Roep [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) aan met `null` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het gehele diagram. Hij wijzigt hoe leemtes worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    // Laat dag 3 echt leeg, terwijl de categorie en het datumpunt behouden blijven.
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

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in het werkboek in elk geval leeg:

![Lijndiagrammen met identieke gegevens: Gap verbreekt de lijn bij Dag 3, Zero laat de lijn naar nul zakken, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt alle drie de modi gemakkelijk te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie heen te verbinden, waardoor `Span` niet het verbindingssegment kan produceren dat hierboven wordt getoond; een missende kolom en een kolom met nulhoogte kunnen er ook vergelijkbaar uitzien. Evenzo heeft een spreidingsdiagram met alleen markeringen geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de uitvoer voor het type dat u gebruikt.

## **Gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort het tot de bovenliggende reeks‑groepsreeks in plaats van tot één reeks. Roep [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) één keer voor de groep aan. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter opeen.

Het volgende voorbeeld wijzigt de gatbreedte en slaat vervolgens alleen de definitieve presentatie op:

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

![De gatbreedte](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)‑enumeratie gebruiken diagramgegevens, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de methode voor het aanmaken van datapunten die overeenkomt met het type reeks. Opties zoals overlapping en gatbreedte gelden alleen voor compatibele balk‑ of kolom‑groepen.

**Wat is een diagramreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één reeks wordt bereikt, niet noodzakelijkerwijs elke reeks in het diagram wijzigt.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeksen‑ als categorie‑collecties wissen voordat u een volledig aangepaste gegevensset toevoegt. Een overload kan ook een diagram zonder standaardgegevens aanmaken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en datumpuntwaarden verwijzen naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Het wijzigen van een verwezen cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste gegevens bouwt, houdt u de rijen voor categorieën en de rijen voor reeks‑waarden op één lijn, zodat elk punt onder de bedoelde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `null` om de positie van de punt‑categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden blijven aansluiten op de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en de waarde die via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) is geconfigureerd. Ondersteunde diagrammen kunnen leemtes weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visueel overzicht.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑reeksen roept u [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) aan en stelt u de kleur in die wordt geretourneerd door [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Deze methoden beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datumpunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische diagramstijl en het thema gebruiken. Groepsinstellingen zoals overlapping en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet voor het aantal reeksen op. In de praktijk bepalen bestands‑beperkingen, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een praktisch limiet.

**Wat moet ik wijzigen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Roep [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) aan op de juiste bovenliggende reeks‑groepsreeks. Verhoog de waarde om de ruimte tussen clusters uit te breiden, of verlaag deze om de clusters dichter bij elkaar te brengen.