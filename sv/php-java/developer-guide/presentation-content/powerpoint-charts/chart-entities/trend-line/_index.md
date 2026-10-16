---
title: Lägg till trendlinjer i presentationsdiagram i PHP
linktitle: Trendlinje
type: docs
url: /sv/php-java/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- trendlinje för glidande medelvärde
- polynomisk trendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för PHP via Java - en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer till diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjeposition, och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjeprojektioner samt om trendlinjer bevaras vid export till PDF eller SVG och när diagram renderas som bilder.

## **Lägg till en trendlinje**

Använd [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) för att lägga till en trendlinje till en diagramserie, och välj dess typ med [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Exemplet skapar ett staplat kolumndiagram med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R²-värde via [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) och [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) för en anpassad etikett. Glidande medelvärde använder ett [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) på tre datapunkter och ett anpassat [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Den polynomiska trendlinjen har en ordning på tre, inställd via [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), och sträcker sig en kategori framåt genom [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Potenslinjen sträcker sig en kategori bakåt genom [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in ett trendlinjeintercept**

Använd [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) för att fixera en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Till exempel kan en modell för produktionskostnader behöva börja med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktion volymer antyder en annan baslinje. För en linjär trendlinje, begränsar fastställandet av intercept ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningarna för axelöverskridning styr var diagramaxlarna möts, inte koefficienterna i den anpassade trendlinjen.

Följande exempel skapar ett spridnings‑ (XY)‑diagram med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardinterceptet, ställer in interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i interceptinställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Med automatisk beräkning ger dessa data `y = 30x + 140`. Om interceptet istället sätts till 100 får du ungefär `y = 43.33x + 100`: det anpassade värdet vid noll matchar den kända baslinjen, medan linjen inte längre passerar genom varje datapunkt.

| Automatiskt intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med ett automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med ett fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axelskala. Trendlinjerna sträcks tillbaka till X = 0 för att visa deras intercept.

Som standard returnerar [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) `NaN`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från data.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas över diagrammet snarare än en trendlinje beräknad från seriedata. Detta exempel använder [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) för att lägga till en horisontell linje på bilden över diagrammet. Linjens position anges i bildkoordinater, mätt i punkter, så den startar vid diagrammets vänstra kant och ligger halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) ger linjen en solid röd färg.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Vad betyder 'framåt' och 'bakåt' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt eller bakåt: för spridnings‑ (XY)‑diagram — i axelenheter; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/php-java/create-shape-thumbnails/) självt.