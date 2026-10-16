---
title: Diagram adatcímkék kezelése előadásokban PHP használatával
linktitle: Adatcímke
type: docs
url: /hu/php-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke elhelyezés
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint előadásokhoz az Aspose.Slides for PHP via Java segítségével, hogy vonzóbbak legyenek a diák."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk elmagyarázza, hogyan formázhatja az értékeket, jelenítheti meg a százalékokat, olvashatja el a címke szövegét, szabályozhatja a címkéket a tengely maximumán túl, állíthatja a kategória tengely címke távolságát, és pozicionálhatja a kördiagram címkéit.

## **Az adatcímkék adatpontoságának beállítása a diagramon**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) függvényt a sorozatértékek formázásához. Ez a példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, megjeleníti az adat tábláját, és engedélyezi az értékcímkéket az első sorozat számára. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Százalék megjelenítése címkeként**

Halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriák ki vannak hagyva a nulla osztás elkerülése érdekében. Számolja újra az egyedi címke szöveget, ha a diagram adatai megváltoznak.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Százalékjel beállítása a diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) függvényt a százalékok megjelenítéséhez. Adja át a `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) függvénynek, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értékpár összege 1. A `0.0%` címkeformátum 0.30-at 30.0%-ként jelenít meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címke szöveget használ.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Az adatcímkék tényleges szövegének beolvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) függvényt egy adatcímke beállításai által előállított szöveg lekéréséhez. Ez akkor hasznos, amikor címkéket von le jelentésekhez, a prezentáció tartalmát keresik, vagy a generált diagramokat ellenőrzik. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) minden kategórianév, sorozatnév és érték kombinációját jeleníti meg. Egy pont az értékét százalékként formázza, egy másik pedig egyedi szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) segítségével.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Az adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot mutat a kategória és sorozat nevével együtt. Az egyedi szöveg felülírja a generált címke szöveget. A [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) mindkét esetben a kapott címke karakterláncot adja vissza. Ellenőrizze külön a [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) függvényt, ahogy fent látható, ha csak a látható címkéket szeretné kinyerni.

## **Az adatcímkék szabályozása a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) függvényt annak szabályozására, hogy megjelenjenek-e az adatcímkéik. Ez a beállítás a címke láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportos oszlopdiagramot hoz létre 60 és 120 értékekkel. `false` értéket ad át a [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) függvénynek, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) függvénnyel 100-ra állítja a maximumot. Az első dián a címkék a maximumon túl is engedélyezettek; egy másolat letiltja őket. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

Az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) függvénnyel kapcsolhatja be. A diagram szintű beállítás önmagában nem engedélyezi az érték megjelenítését, és nem írja felül egy adott címke letiltott értékmegjelenítését. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) függvényt használja a címkék minden oszlop külső végére helyezéséhez.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A következő képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtett. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont mindkét esetben **120**.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint diagram, amely a 120 értékcímkét mutatja 100-as tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét 100-as tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az olyan diagramok, amelyeknek nincs értéktengelye, mint a kör- és gyűrűdiagramok, nem rendelkeznek tengelymaximumszámmal, amelyet így korlátozni lehetne.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) függvényt a kategória tengely címkéi és a tengely közötti távolság szabályozására. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportos oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengely címkékre hat, nem az egyes adatpontokhoz csatolt címkékre.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Címke helyének módosítása**

Egy kördiagramon módosítsa az adatcímkék pozícióját a térköz javítása és a vezető vonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívül helyezi, és a horizontális valamint vertikális eltolásokat a [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) függvényekkel állítja be. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva értendők.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Kördiagram a módosított adatcímke elhelyezésével](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Amikor a kördiagram címkéi a szeleteken kívül helyezkednek el, a vezető vonalak segítik az olvasót, hogy minden értéket a megfelelő szelethez társítsa. Egy kontrasztos szín és egy enyhén vastagabb vonal megkönnyítheti a követést, míg az átlátszóság és a szaggatott stílus kevésbé zavaróvá teszi a vonalakat.

Használja a [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) függvényt a vezető vonalak formázásához a sorozat adatcímke-gyűjtemény szintjén. A `$series->getLabels()->getLeaderLinesFormat()->getLine()` beállításai a gyűjteményre vonatkoznak, nem egyetlen címkére.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, a szeleteken kívül jeleníti meg az értékeket, és engedélyezi a [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/) függvényt. Két címkét távolabb helyez a szeletektől a [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és a [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) eltolásokkal, amelyeket a diagram szélességének és magasságának hányadosaként ad meg. Nem szükséges bemeneti prezentáció.

A vonal [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) függvénye szilárd kék színt állít be 191 alfa értékkel a 255-ből, ami körülbelül 25%-os átlátszóságot eredményez. A [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) a vastagságot 2 pontra állítja, a [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) pedig szaggatottá teszi a vonalat.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // Mozgassa el a két címkét távolabb a szeleteiktől.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A vezető vonalak engedélyezése nem garantálja, hogy minden címkéhez vonal jelenik meg. A láthatóság a címke elhelyezésétől és a diagram elrendezésétől függ. Ebben a példában a két eltolt címke látható vezető vonalakkal rendelkezik; a szeletekhez közel maradt címkéknek nincs szükségük rá.

A következő kép a mentett `FormattedLeaderLines.pptx` Aspose.Slides által renderelt változatát mutatja:

![Kördiagram kék, félig átlátszó, szaggatott vezető vonalakkal, amelyek két külső címkét a szeletekhez kapcsolják](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása egy oszlopdiagram felett**

Ez a példa egy oszlopdiagramot hoz létre, amelynek a grafikonterület felett két sor adatcímkéje van. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Oszlopaikat a kitöltés és a kontúr eltávolításával rejtik. A [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) metódus az összes három sorozatot ugyanabba a kategóriaközéppontba igazítja.

A [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) beállítások helyet tartanak a címkesoroknak. A [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) az alapértelmezett pozíciókat kiszámítja, majd a [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és a [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) megőrzik a vízszintes igazítást és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok továbbra is a sorozatértékekhez kapcsolt adatcímkék maradnak; csak a sorfejek külön szöveges alakzatok.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // Rejtse el a B és C oszlopait, de tartsa meg az adatcímkéiket.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // Igazítsa mindhárom sorozatot ugyanazokhoz a kategóriaközéppontokhoz.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Használjon kevesebb rácsvonalat ebben a kompakt példában.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Tartson fenn helyet a diagram felett két sor adatcímkének.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // Tartsa meg az alapértelmezett vízszintes pozíciót. Az Y egy eltolás a
            // alapértelmezett címkepozíciótól, amely a diagram magasságának hányadosaként van kifejezve.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Csak a sorfejléc egy külön szöveg alakzat.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Oszlopdiagram két sor adatcímkével a grafikonterület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan előzhetem meg az adatcímkék átfedését sűrű diagramoknál?**

Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a csökkentett betűméretet; szükség esetén rejtsen el néhány mezőt (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok címkéit jelenítse meg.

**Hogyan kapcsolhatom ki a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje ki az adatpontokat a címkék engedélyezése előtt, és a meghatározott szabály szerint kapcsolja ki a megjelenítést a 0, a negatív vagy a hiányzó értékeknél.

**Hogyan biztosíthatom a következetes címkestílust PDF/képek exportálásakor?**

Explicit módon állítsa be a betűcsaládot és a méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben a helyettesítés elkerülése érdekében.