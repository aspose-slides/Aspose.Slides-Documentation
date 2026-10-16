---
title: Dodaj linie trendu do wykresów w prezentacji w PHP
linktitle: Linia trendu
type: docs
url: /pl/php-java/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- linia trendu liniowa
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- niestandardowa linia trendu
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint za pomocą Aspose.Slides dla PHP poprzez Java — praktyczny przewodnik, który zaangażuje Twoją publiczność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z kilkoma rodzajami linii trendu, w tym wykładniczą, liniową, logarytmiczną, średnią kroczącą, wielomianową i potęgową.

Opisuje również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, i zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG oraz przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**

Użyj [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) aby dodać linię trendu do serii wykresu, wybierając jej typ za pomocą [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Przykład tworzy wykres kolumnowy grupowy z domyślnymi danymi i dodaje po dwie linie trendu do każdej z trzech serii.

Wykładnicza linia trendu ukrywa swoje równanie i wartość R‑kwadrat za pomocą [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) i [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), natomiast liniowa linia trendu jest czerwona. Logarytmiczna linia trendu używa [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) do niestandardowej etykiety. Średnia krocząca używa [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) ustawionego na trzy punkty danych oraz niestandardowego [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

Wielomianowa linia trendu ma rząd równy trzem, ustawiany za pomocą [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), i rozszerza się o jedną kategorię do przodu za pomocą [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). Potęgowa linia trendu rozszerza się o jedną kategorię do tyłu za pomocą [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

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

## **Ustaw przecięcie linii trendu**

Użyj [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/), aby ustawić wartość Y linii trendu przy X = 0. To ustawienie jest obsługiwane dla linii trendu liniowych, wykładniczych i wielomianowych.

Na przykład model kosztów produkcji może wymagać rozpoczęcia od znanych stałych kosztów równych 100, nawet gdy pomiary przy niezerowych wolumenach produkcji sugerują inną wartość bazową. Dla liniowej linii trendu, ustalenie przecięcia ogranicza równanie `y = ax + b` do `b = 100`; nachylenie jest dopasowywane do danych przy tym ograniczeniu. Nie powoduje to jedynie przesunięcia już dopasowanej linii. Ustawienia przecięcia osi określają, gdzie osie wykresu się spotykają, a nie współczynniki dopasowanej linii trendu.

Poniższy przykład tworzy wykres punktowy (XY) z wolumenami produkcji od 1 do 4 oraz kosztami 170, 200, 230 i 260. Zapisuje wykres z domyślnym automatycznym przecięciem, ustawia przecięcie na 100 i zapisuje drugi plik PPTX. Dwa pliki różnią się jedynie ustawieniem przecięcia. Linia trendu wyświetla swoje równanie i rozszerza się do X = 0.

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

Przy automatycznym obliczeniu te dane dają `y = 30x + 140`. Ustawienie przecięcia na 100 zamiast tego daje przybliżenie `y = 43.33x + 100`: dopasowana wartość przy zerze odpowiada znanej wartości bazowej, podczas gdy linia nie przechodzi już przez każdy punkt danych.

| Automatyczne przecięcie | Stałe przecięcie 100 |
| --- | --- |
| ![Liniowa linia trendu z automatycznie obliczonym przecięciem 140](intercept-automatic.png) | ![Liniowa linia trendu ze stałym przecięciem 100](intercept-fixed.png) |

Oba obrazy używają tych samych danych i skal osi. Linie trendu są rozszerzone do X = 0, aby pokazać ich przecięcia.

Domyślnie, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) zwraca `NaN`, co oznacza nieokreślone przecięcie, a nie zero. Przecięcie jest wtedy obliczane automatycznie na podstawie danych.

## **Dodaj własną linię**

Własna linia to kształt narysowany nad wykresem, a nie linia trendu obliczona na podstawie danych serii. Ten przykład używa [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/), aby dodać poziomą linię do slajdu nad wykresem. Pozycja linii jest określona w współrzędnych slajdu, mierzonych w punktach, więc zaczyna się ona od lewej krawędzi wykresu i znajduje się w połowie wysokości wykresu. Jej szerokość odpowiada szerokości wykresu. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) nadaje linii jednolity czerwony kolor.

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

**Co oznaczają „forward” i „backward” w odniesieniu do linii trendu?**

Są to długości linii trendu projekowane w przód lub w tył: dla wykresów punktowych (XY) — w jednostkach osi; dla wykresów nie‑punktowych — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksporcie prezentacji do PDF lub SVG, albo przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) lub [SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/) i renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane podczas tych operacji. Dostępna jest również metoda do [eksportu obrazu wykresu](/slides/pl/php-java/create-shape-thumbnails/).