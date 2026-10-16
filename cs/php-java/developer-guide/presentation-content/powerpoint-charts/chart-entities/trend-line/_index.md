---
title: Přidání čar trendu do grafů v prezentaci v PHP
linktitle: Čára trendu
type: docs
url: /cs/php-java/trend-line/
keywords:
- graf
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- klouzavý průměr čáry trendu
- polynomiální čára trendu
- mocninná čára trendu
- vlastní čára trendu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte čáry trendu v grafech PowerPointu s Aspose.Slides pro PHP pomocí Javy — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak přidat čáry trendu do grafů v prezentacích pomocí Aspose.Slides. Ukazuje, jak vytvořit graf, přidat čáry trendu do řad grafu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninné.

Také popisuje, jak přidat vlastní čáru do grafu vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázky.

## **Přidat čáru trendu**

Použijte [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) k přidání čáry trendu do řady grafu a vyberte její typ pomocí [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě čáry trendu do každé ze tří řad.

Exponenciální čára trendu skryje svou rovnici a hodnotu R‑čtverce pomocí [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) a [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), zatímco lineární čára trendu je červená. Logaritmická čára trendu používá [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) pro vlastní štítek. Klouzavý průměr používá [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) se třemi datovými body a vlastní [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Polynomiální čára trendu má řád tři, nastavený pomocí [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), a prodlužuje jednu kategorii dopředu pomocí [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Mocninná čára trendu prodlužuje jednu kategorii dozadu pomocí [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

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

## **Nastavit průsečík čáry trendu**

Použijte [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) k upoutání hodnoty Y čáry trendu při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomiální čáry trendu.

Například model výrobních nákladů může potřebovat začít se známými pevnými náklady 100, i když měření při nenulových objemech výroby naznačují jiný základ. Pro lineární čáru trendu upoutání průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejde jen o posunutí již přizpůsobené čáry. Nastavení průsečíku os řídí, kde se setkají osy grafu, nikoli koeficienty přizpůsobené čáry trendu.

Následující příklad vytvoří rozptylový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečíkem, nastaví průsečík na 100 a uloží druhý soubor PPTX. Tyto dva soubory se liší pouze nastavením průsečíku. Čára trendu zobrazuje svou rovnici a prodlužuje se zpět k X = 0.

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

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavení průsečíku na 100 místo toho přibližně dává `y = 43.33x + 100`: přizpůsobená hodnota při nule odpovídá známému základu, zatímco čára už neprochází všemi datovými body.

| Automatický průsečík | Pevný průsečík 100 |
| --- | --- |
| ![Lineární čára trendu s automaticky vypočítaným průsečíkem 140](intercept-automatic.png) | ![Lineární čára trendu s pevným průsečíkem 100](intercept-fixed.png) |

Oba obrázky používají stejná data a měřítka os. Čáry trendu jsou prodlouženy zpět k X = 0, aby ukázaly své průsečíky.

Ve výchozím nastavení [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) vrací `NaN`, což představuje nespecifikovaný průsečík místo nuly. Průsečík je pak automaticky vypočítán z dat.

## **Přidat vlastní čáru**

Vlastní čára je tvar nakreslený nad grafem, nikoli čára trendu vypočítaná z dat řady. Tento příklad používá [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) k přidání vodorovné čáry na snímek nad grafem. Pozice čáry je zadána ve souřadnicích snímku, měřených v bodech, takže začíná na levém okraji grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) dává čáře plnou červenou barvu.

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

## **Často kladené otázky**

**Co znamenají ‚dopředu‘ a ‚dozadu‘ u čáry trendu?**

Jedná se o délky čáry trendu projektované dopředu/dozadu: u rozptylových (XY) grafů — v jednotkách os; u jiných grafů — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; čáry trendu, jako součást grafu, jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/php-java/create-shape-thumbnails/).