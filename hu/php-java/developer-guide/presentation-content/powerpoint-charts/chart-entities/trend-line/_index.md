---
title: Trendvonalak hozzáadása bemutató diagramokhoz PHP-ben
linktitle: Trendvonal
type: docs
url: /hu/php-java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyedi trendvonal
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Gyorsan adjon hozzá és testre szabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for PHP via Java segítségével — egy praktikus útmutató, amely segít bevonni a közönséget."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk trendvonalakat a bemutatók diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhatunk létre diagramot, hogyan adhatunk trendvonalakat a diagram sorozataihoz, és hogyan dolgozhatunk többféle trendvonal típussal, többek között exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány.

Emellett leírja, hogyan adhatunk egyedi vonalat a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-ot a trendvonal előre és hátra vetített értékeiről, valamint arról, hogy a trendvonalak megőrződnek-e PDF vagy SVG exportálásakor, illetve a diagramok képként való renderelésekor.

## **Trendvonal hozzáadása**

Használja a [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) linket trendvonal hozzáadásához egy diagram sorozatához, a típus kiválasztásához a [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/) használatával. A példa egy klaszterezett oszlopdiagramot hoz létre alapértelmezett adatokkal, és minden három sorozatához két trendvonalat ad hozzá.

Az exponenciális trendvonal elrejti egyenletét és az R-négyzet értékét a [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) és a [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/)‑t használja egy egyedi címke számára. A mozgó átlag egy három adatpontból álló [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) értéket és egy egyedi [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/)‑t használ.

A polinomiális trendvonal harmadik rendű, a [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/) segítségével állítva, és egy kategóriával előre nyúlik a [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/) segítségével. A hatvány trendvonal egy kategóriával hátra nyúlik a [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/) segítségével.

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

## **Trendvonal metszéspont beállítása**

Használja a [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) metódust a trendvonal Y értékének X = 0‑nál rögzítéséhez. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalaknál.

Például egy termelési költségmodellnek 100 egység ismert fix költségnél kellene indulnia, még akkor is, ha a nem nulla termelési mennyiségek mérései más kiindulási értéket sugallnak. Egy lineáris trendvonal esetén a metszéspont rögzítése úgy korlátozza az `y = ax + b` egyenletet, hogy `b = 100`; a meredekség az adatokhoz illeszkedik ezen korlátozás mellett. Ez nem egyszerűen csak eltol egy már illesztett vonalat. A tengelykereszteződés beállítások azt szabályozzák, hogy hol találkoznak a diagram tengelyei, nem a trendvonal illesztett együtthatóit.

A következő példa egy szórt (XY) diagramot hoz létre, ahol a termelési mennyiségek 1‑től 4‑ig terjednek, és a költségek 170, 200, 230 és 260. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100‑ra, és elment egy második PPTX‑et. A két fájl csak a metszéspont beállításában tér el. A trendvonal megjeleníti egyenletét, és visszanyúlik X = 0‑ig.

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

Automatikus számítás esetén ezek az adatok `y = 30x + 140` egyenletet eredményeznek. A metszéspont 100‑ra állítása helyette körülbelül `y = 43.33x + 100`‑at ad: a nulla pontban illesztett érték egyezik az ismert kiindulási értékkel, míg a vonal már nem halad minden adatponton.

| Automatikus metszéspont | Fixált metszéspont 100‑nál |
| --- | --- |
| ![Lineáris trendvonal automatikusan kiszámított 140‑es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal fixált 100‑as metszéssel](intercept-fixed.png) |

Mindkét kép ugyanazokat az adatokat és tengelyskálákat használja. A trendvonalak visszanyúlnak X = 0‑ig, hogy megmutassák metszéspontjaikat.

Alapértelmezés szerint a [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) `NaN` értéket ad vissza, ami meghatározatlan metszéspontot jelöl, nem nullát. A metszéspont ezután automatikusan számítódik ki az adatokból.

## **Egyedi vonal hozzáadása**

Az egyedi vonal egy a diagram fölött rajzolt alakzat, nem a sorozat adataiból számított trendvonal. Ez a példa a [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) segítségével egy vízszintes vonalat ad hozzá a diára a diagram felett. A vonal pozíciója a diakoordinátákban, pontokban van megadva, így a diagram bal szélénél kezdődik és a diagram feléig helyezkedik el. Szélessége megegyezik a diagram szélességével. A [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) egy szilárd piros színt ad a vonalnak.

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

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetében?**

A trendvonal előre vagy hátra vetített hossza: szórt (XY) diagramok esetén – tengelyegységekben; nem szórt diagramok esetén – kategóriák számában. Csak nem negatív értékek engedélyezettek.

**Megmarad‑e a trendvonal a prezentáció PDF vagy SVG exportálásakor, illetve egy dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/php-java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, ezen műveletek során megmaradnak. Egy metódus is elérhető a diagram képként való [exportálásához](/slides/hu/php-java/create-shape-thumbnails/) saját magához.