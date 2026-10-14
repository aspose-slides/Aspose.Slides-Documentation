---
title: Anpassa pajdiagram i presentationer med PHP
linktitle: Pajdiagram
type: docs
url: /sv/php-java/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- grafalternativ
- segmentfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa pajdiagram i PHP med Aspose.Slides. Konfigurera sekundära diagram, visa dataetiketter och tillämpa automatiska segmentfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar alternativ för sekundär graf för Pie of Pie‑ och Bar of Pie‑diagram samt hur man aktiverar automatisk färgläggning av segment för ett standardpajdiagram.

Exemplen fokuserar på anpassningsuppgifter för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden samt spara den uppdaterade presentationen.

## **Alternativ för sekundär graf för Pie of Pie‑ och Bar of Pie‑diagram**

Aspose.Slides för PHP via Java stöder alternativ för sekundär graf för Pie of Pie‑ och Bar of Pie‑diagram. Dessa alternativ styr storleken på den sekundära grafen och hur datapunkter fördelas mellan de två graferna.

Följande exempel skapar ett Pie of Pie‑diagram i en ny presentation och visar datapunktvärden som etiketter. Metoden [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ställer in storleken på den sekundära grafen till 149% av huvudgrafen. Metoden [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) väljer procentbaserad uppdelning, och [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) sätter tröskeln till 53%.

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

    // Visa värden och konfigurera den sekundära grafen.
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

### **Välj kategorier för den sekundära grafen**

Använd anpassad uppdelning när du vill gruppera specifika kategorier i den sekundära grafen oavsett deras procentsatser. Till exempel kan en försäljningsrapport visa Online och Evenemang tillsammans så att läsarna kan jämföra dessa två kanaler, även om de står för 35% respektive 10% av den totala försäljningen.

Anropa [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) med [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) och välj punkterna via [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Kollektionsmetoden [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) accepterar ett nollbaserat index i serien; använd [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) för att lägga till ett datapunktobjekt. I det här exemplet väljer index 1 Online, och punkten vid index 3 väljer Evenemang. Partners läggs också till tillfälligt och tas sedan bort med [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Ersätt standarddata med försäljning per kanal.
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

    // Välj Online med dess nollbaserade index och Events med dess datapunktobjekt.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Exkludera Partners från urvalet utan att radera dess källdata.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) och Evenemang (10) visas som separata segment i den sekundära grafen. I huvudgrafen representeras de av ett kombinerat segment med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller det i huvudgrafen; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie‑diagram med Online och Evenemang i den sekundära grafen och deras kombinerade värde 45 i huvudgrafen](pie_of_pie_custom.png)

## **Ställ in automatiska färger för pajdiagramsegment**

Aspose.Slides för PHP via Java kan automatiskt tilldela olika färger till segment i ett pajdiagram. Följande exempel skapar ett pajdiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Metoden [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) visar värdena 20, 50 och 30 som etiketter, medan [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) aktiverar en distinkt färg för varje segment.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Lägg till en centrerad diagramrubrik.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Ersätt standarddata med hjälp av det första kalkylbladet.
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

    // Visa värden och tilldela olika färger till segmenten.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Stöds variationerna Pie of Pie och Bar of Pie?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) en sekundär graf för pajdiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera endast diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (t.ex. PNG) utan att exportera hela presentationen.