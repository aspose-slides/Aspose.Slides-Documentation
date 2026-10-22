---
title: Hantera diagramserier i presentationer i PHP
linktitle: Dataserier
type: docs
url: /sv/php-java/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- serienamn
- datapunkt
- arbetsbokscell
- seriegap
- negativt värde
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, gapbredd och negativa värden i presentationer med PHP."
---
## **Översikt**

Ett diagram kan lagra sina plottade värden i arbetsbokens celler eller direkt som numeriska litteraler. En [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) representerar en uppsättning relaterade värden, och varje [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) representerar en punkt i den serien. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/)-objekt tillhandahåller etiketter eller grupperingsvärden som delas av serierna. I diagram som skapats med standarddata används [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/)-objekt från diagrammets arbetsbok för serienamn, kategorier och punktvärden.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn, och de återstående cellerna för seriesärden. Index för kalkylblad, rad och kolumn som skickas till [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsboksvärden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på seriesnivå, såsom [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), tillhandahåller standardutseendet för alla punkter i en serie.
- Inställningar på datapunktnivå, såsom [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), åsidosätter serieutseendet för en punkt.
- Gruppinställningar gäller kompatibla serier som tillhör samma [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Åtkomst till gruppen via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) när du behöver ställa in alternativ som överlappning eller gapbredd.

När ingen explicit punkt- eller seriefyllning är angiven bestämmer diagramstil och tema det automatiska utseendet. När både serie- och punktformatering finns, har punktformateringen företräde för den punkten.

![diagram-serie-powerpoint](chart-series-powerpoint.png)

## **Ange seriesvärden med numeriska litteraler**

Använd numeriska litteraler när seriesärden kommer från applikationsdata eller beräkningar och inte kräver referenser till kalkylblads-celler. Anropa [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) med [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) innan du tilldelar varje punkts [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) resultat via [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Samlingsinställningen styr källtypen för alla punktvärden i den serien. Varje punktvärdes [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/)‑metod rapporterar den valda typen; ändra den via samlingsinställningen. Med `Worksheet` använder du [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) för att komma åt den refererade cellen. Med `DoubleLiterals` använder du [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) eller `setAsLiteralDouble` för att läsa eller skriva talet direkt.

Följande exempel skapar ett stapeldiagram med standardserier och -kategorier, och tilldelar sedan beräknade värden 10, 20 osv. till de befintliga punkterna i dess första serie. Det sparar presentationen, öppnar den igen och skriver ut de lagrade värdena.

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

Punktvärdets källtyp är separat från [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), som identifierar diagrammets interna eller externa arbetsboks‑konfiguration. Att använda numeriska litteraler tar inte i sig själva bort den inbäddade arbetsboken. I detta exempel förblir arbetsboken tillgänglig för kategorietiketter, serienamn och de andra serierna. Se [Chart Workbook](/slides/sv/php-java/chart-workbook/) för arbetsboks‑hantering.

För spridnings‑ och bubbeldiagram, använd [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) och [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) för att välja källorna för [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) och [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Bubbeldiagram använder också [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) för [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Sätt varje tillämplig källa till `DoubleLiterals` innan du tilldelar siffror via den värdets `setAsLiteralDouble`‑metod.

## **Ställ in överlappning för diagramserier**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriesgruppen. Använd [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriesgrupper i ett kombinationsdiagram.

Följande exempel sätter överlappning för gruppen som innehåller den första serien:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Det nya diagrammet innehåller exempelserier, kategorier och värden.
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

Resultatet:

![Seriernas överlappning](series_overlap.png)

## **Ändra series fyllningsfärg**

Använd [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) inställning series fyllning för den punkten.

Följande exempel applicerar en solid blå fyllning på den första serien:

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

Resultatet:

![Seriens färg](series_color.png)

## **Ändra series namn**

Ett series namn lagras i diagrammets dataarbetsbok och visas normalt i legenden. I standardarbetsboken som skapas för ett gruppstapeldiagram ligger cell B1 i rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna variablerna i följande exempel gör den strukturen explicit:

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

Du kan också uppdatera den cell som redan refereras av [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Detta tillvägagångssätt undviker att anta en viss rad och kolumn i ett befintligt diagram:

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

Resultatet:

![Series namn](series_name.png)

### **Skapa en serie med namn från flera celler**

Ett sammansatt series namn är användbart när ett produktnamn och en rapportperiod lagras i separata arbetsboks‑celler. Till exempel kan du kombinera `Product A` i B1 och `2026` i C1 till ett enda series namn samtidigt som båda delarna hålls länkade till sina källceller.

Använd [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) för att hämta namnintervallet, och skicka sedan den samlingen till [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Argumentet `skipHiddenCells` styr om dolda celler inkluderas: `true` exkluderar dem, medan `false` inkluderar dem. Detta exempel använder `false` för att inkludera varje cell i namnintervallet.

Följande exempel skapar en presentation med en serie och två datapunkter. Cellern B1:C1 levererar endast series namnet; A2:A3 levererar kategorietiketter, och B2:B3 levererar de numeriska värdena.

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

    // Dessa två celler levererar seriesnamnet.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Separata celler levererar kategorierna och numeriska datapunkter.
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

Det resulterande series namnet är `Product A 2026`, med ett mellanslag mellan de två cellvärdena. Legenden visar detta som ett enda objekt för båda kolumnerna. Bilden nedan illustrerar resultatet:

![Kolumndiagram med norr‑ och sydvärden samt det sammansatta series namnet Product A 2026 i legenden](composite_series_name.png)

## **Hämta den automatiska series fyllningsfärgen**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) returnerar färgen beräknad från series index och diagramstil. Detta är färgen som används när series fyllning inte har definierats explicit. Att anropa metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

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

Exempelutdata för standarddiagramstilen:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exakta färgerna beror på diagramstil och tema.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbelsekvenser kan [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) visa negativa värden med en annan fyllning. Ställ in den vanliga series fyllning till solid, aktivera inversion och tilldela färgen för negativa värden via [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Kalkylbladsrad 0 innehåller series namnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Resultatet:

![Den inverterade solida fyllningsfärgen](inverted_solid_fill_color.png)

Du kan aktivera inversion för en punkt via [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten blir synlig:

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

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks‑cell till `null`. För ett kolumndiagram är det plottade värdet tillgängligt via [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Datapunkten förblir på samma kategori­position, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

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

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder även en storlekscell. Rensa endast den cell som representerar det värde du avser att ta bort. Anropa inte [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter i samlingen.

## **Styr visning av tomma celler**

Dolda celler som innehåller värden är ett separat fall från tomma celler. För att inkludera eller exkludera data från dolda kalkylbladsrader och -kolumner, se [Include Data from Hidden Rows and Columns](/slides/sv/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

En tom arbetsboks‑cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) med `null` för att göra en cell tom. En numerisk nolla förblir en nolla oavsett inställning för tomma celler.

Använd [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks‑cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) använder kalkylblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller series namnet. Slutdata är `10, 20, empty, 30, 40`.

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

    // Lämna Dag 3 riktigt tom, men behåll dess kategori och datapunkt.
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

Varje utdatafil lagrar läget som tilldelats innan sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara endast en version, ange önskat läge och spara presentationen en gång i stället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i varje fall:

![Linjediagram med identisk data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtyp. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel‑ och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte skapa den anslutande segmentet som visas ovan; en saknad kolumn och en kolumn med nollhöjd kan också se lika ut. På liknande sätt har ett spridningsdiagram med endast markörer ingen anslutande linje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ställ in series gapbredd**

Gapbredd är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som en procentandel av stapel‑ eller kolumnbredden. Liksom överlappning tillhör den den överordnade seriesgruppen snarare än en enskild serie. Anropa [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) en gång för gruppen. Ett högre värde skapar mer utrymme mellan klustren; ett lägre värde gör dem tätare.

Följande exempel ändrar gapbredden och sparar endast den slutgiltiga presentationen:

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

Resultatet:

![Gapbredden](gap_width.png)

## **FAQ**

**Vilka diagramtyper stödjer dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)-enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram X‑ och Y‑värden, och bubbeldiagram lägger till bubbelformer. Använd datapunkt‑skapningsmetoden som matchar serietypen. Alternativ som överlappning och gapbredd gäller endast kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriesgrupp?**

En [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) innehåller kompatibla serier som delar gruppnivåinställningar för plottring. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie förändrar inte nödvändigtvis alla serier i diagrammet.

**Inkluderar ett nyskapat diagram standarddata?**

Ja. Som standard skapar [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) exempelserier, -kategorier och -värden. Du kan redigera dessa celler eller rensa både series‑ och kategorikollektionerna innan du lägger till ett helt eget dataset. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks‑celler?**

Series namn, kategorietiketter och datapunktvärden refererar celler i en [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagram‑element. När du bygger egna data, håll kategorirader och series‑värderader inriktade så att varje punkt plottas under rätt kategori.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategori­position som en tom punkt. Använd [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du även tar bort kategorier, uppdatera alla serier så att deras värden förblir i linje med kategori‑kollektionen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtyp och värdet som konfigurerats via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Stödda diagram kan visa tomrum som luckor, som nollvärden eller genom att ansluta närliggande punkter. Välj den inställning som matchar innebörden av saknad data i din presentation. Se [Control the Display of Empty Cells](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbelsekvenser, anropa [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) och ange färgen som returneras av [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Du kan åsidosätta beteendet för en enskild punkt med [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Dessa metoder påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering vinner när både en serie och en punkt är formaterade?**

Explicit datapunktformatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita series‑formaten eller, när series‑formatet inte är definierat, det automatiska diagramstilen och temat. Gruppinställningar såsom överlappning och gapbredd styr layout och är inte punkt‑nivåformateringsöverskrivningar.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides pålägger ingen separat fast gräns för antalet serier. I praktiken bestäms en användbar gräns av presentationsfilens begränsningar, tillgängligt minne, renderingstid och diagrammets läsbarhet.

**Vad ska jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Anropa [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) på den lämpliga föräldragroupsen. Öka värdet för att bredda utrymmet mellan klustren, eller minska det för att föra klustren närmare varandra.