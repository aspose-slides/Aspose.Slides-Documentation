---
title: Diagram adatcímkék kezelése prezentációkban PHP használatával
linktitle: Adatcímke
type: docs
url: /hu/php-java/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével, hogy a diák még vonzóbbak legyenek."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk elmagyarázza, hogyan formázhatja az értékeket, jelenítheti meg a százalékokat, olvashatja a címkeszöveget, vezérelheti a címkéket a tengely maximumán túl, állíthatja a kategória tengely címke távolságát, és elhelyezheti a kördiagram címkéket.

## **Adatpontosság beállítása a diagram adatcímkéiben**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) függvényt a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozathoz. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

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

A diagram beágyazott munkafüzetben lévő numerikus cellák formázásához tekintse meg az [Egyéni számformátumok beállítása a munkafüzet celláiban](/slides/hu/php-java/chart-workbook/#set-custom-number-formats-for-workbook-cells) cikket. Az a példa azt is mutatja, hogy az értékcímkék a forráscellák formátumát követik, miközben megőrzik a tárolt numerikus értékeket.

## **Százalék megjelenítése címkeként**

Egy halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje hozzá a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagramadatokat használja, és a százalékokat két tizedesjeggyel, 8 pontos betűmérettel jeleníti meg. A nullával egyenlő összegű kategóriákat kihagyja, hogy elkerülje a nulla osztását. Számolja újra az egyéni címkeszöveget, ha a diagram adatai megváltoznak.

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

## **Százalékjel beállítása diagram adatcímkékkel**

Ha az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) függvényt a százalékok megjelenítéséhez. Adjon át `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) függvénynek, hogy a címkeformátumot a forráscelláktól függetlenül alkalmazza.

Ez a példa egy 100%-os halmozott oszlopdiagramot hoz létre piros és kék sorozattal négy kategórián keresztül. Minden értéppár összegződik 1-re. A címkeformátum `0.0%` a 0.30-at 30.0%-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

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

## **Adatcímkék tényleges szövegének olvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) függvényt az adatcímke beállításai által előállított szöveg lekérésére. Ez hasznos címkék jelentésekhez való kinyerésekor, a prezentáció tartalmának keresésekor vagy a generált diagramok ellenőrzésekor. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) egyesíti a kategória nevét, a sorozat nevét és az értéket. Egy pont az értékét százalékban formázza, egy másik egyéni szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) függvényből.

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

A adatpontban tárolt szám `0.75` marad, még akkor is, ha a címkéje `75%`-ot mutat a kategória és a sorozat nevével együtt. Az egyéni szöveg felülírja a generált címkeszöveget. A [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) bármely esetben a kapott címke karakterláncát adja vissza. Ellenőrizze külön a [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) függvényt, ahogy fent bemutattuk, ha csak a látható címkéket szeretné kinyerni.

## **Adatcímkék vezérlése a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) függvényt annak vezérlésére, hogy a címkék megjelenjenek-e. Ez a beállítás a címke láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. `false` értéket ad át a [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) függvénynek, és a függőleges tengelyen a [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) segítségével 100-ra állítja a maximumot. Az első dia lehetővé teszi a címkék megjelenését a maximumon túl; egy másolat letiltja őket. Mindkét diát a `DataLabelsOverMaximum.pptx` fájlba menti.

Engedélyezze az értékcímkéket a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) függvénnyel. A diagram szintű beállítás önmagában nem jeleníti meg az értékeket, és nem írja felül egy adott címke letiltott értékmegjelenítését. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) segítségével a címkéket az egyes oszlopok külső végére helyezi.

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

Az alábbi képek a Microsoft PowerPoint által renderelt mentett diákat mutatják. `true` esetén a **120** címke látható a felső határon; `false` esetén rejtve van. A **60** címke továbbra is látható, a tengely maximum **100** marad, és a második adatpont **120** mindkét esetben.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Diagram típusa" %}}
Ez a példa egy 2D oszlopdiagramot használ értéktengellyel. Az értéktengellyel nem rendelkező diagramok, például a kör- és gyűrűdiagramok, nem rendelkeznek tengelymaximumsal, amit ilyen módon korlátozni lehetne.
{{% /alert %}}

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) függvényt a kategória tengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengely címkéire vonatkozik, nem az egyedi adatpontokhoz kapcsolt címkékre.

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

## **Címke helyének beállítása**

Kördiagramon állítsa be az adatcímkék pozícióját a térköz javítása és a vezetővonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, címkéjét a szelet kívülre helyezi, és a vízszintes és függőleges eltolásokat a [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és a [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) függvényekkel állítja be. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva értendők.

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

![Kördiagram az állított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **Vezetővonalak formázása**

Ha a kördiagram címkéi a szeleteken kívül helyezkednek el, a vezetővonalak segítik az olvasót az egyes értékek a megfelelő szeletekhez való párosításában. Egy kontrasztos szín és egy kissé vastagabb vonal megkönnyítheti ezeknek a kapcsolatoknak a követését, míg a átlátszóság és a szaggatott stílus a vonalakat kevésbé zavaróvá teszi.

Használja a [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) függvényt a vezetővonalak formázásához a sorozat adatcímke-gyűjtemény szintjén. A `$series->getLabels()->getLeaderLinesFormat()->getLine()` beállításai a gyűjteményre, nem egyéni címkékre vonatkoznak.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a szeleteken kívül jeleníti meg az értékeket, és engedélyezi a [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/) függvényt. Két címkét távolabb helyez a szeleteitől a [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és a [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) eltolásokkal, amelyek a diagram szélességének és magasságának törtjelei. Bemeneti prezentáció nem szükséges.

A vonal [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) függvénye egy átlátszatlan kék színt állít be 191 alfaértékkel a 255-ből, ami körülbelül 25% átlátszóságot eredményez. A [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) a vastagságot 2 pontra, a [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) pedig szaggatottá teszi a vonalat.

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

    // Két címkét a szeletektől távolabb helyezünk.
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

A vezetővonalak engedélyezése nem garantálja, hogy minden címkéhez vonal jelenik meg. A láthatóság a címke elhelyezkedésétől és a diagram elrendezési viselkedésétől függ. Ebben a példában a két eltolódott címkének látható vezetővonalai vannak; a szeletekhez közel maradó címkének nincs szükségük.

Az alábbi kép a mentett `FormattedLeaderLines.pptx` fájlt mutatja, amely az Aspose.Slides segítségével lett renderelve:
![Kördiagram kék, félig átlátszó szaggatott vezetővonalakkal, amelyek két külső címkét összekötnek a szeletekkel](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, amely a grafikon terület felett két sor adatcímkét tartalmaz. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Az ő oszlopaikat a kitöltés és a keret eltávolításával rejtik el. A [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) metódus az összes három sorozatot azonos kategóriaközéppontokba illeszti.

A [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) beállításai helyet biztosítanak a címkesorok számára. Miután a [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) kiszámítja az alapértelmezett pozíciókat, a [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) és a [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) megőrzik a vízszintes igazítást, és függőleges eltolásokat alkalmaznak a címkék két sorba rendezéséhez. A számok adatcímkék maradnak, amelyek a sorozatértékekhez kapcsolódnak; csak a sorfejlécek külön szövegobjektumok.

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
            // Rejtse el a B és C oszlopokat, de tartsa meg az adatcímkéket.
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

    // Igazítsa a három sorozatot ugyanabban a kategóriaközéppontban.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Használjon kevesebb rácsvonalat ebben a kompakt példában.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Tartson helyet a diagram felett két sor adatcímke számára.
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
            // az alapértelmezett címkepozíciótól, a diagrammagasság törtjeként kifejezve.
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

![Oszlopdiagram két sor adatcímkével a grafikon terület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan kerülhetem el, hogy az adatcímkék átfedjék egymást zsúfolt diagramokon?**  
Kombinálja az automatikus címke elhelyezést, a vezetővonalakat és a kisebb betűméretet; ha szükséges, rejtse el egyes mezőket (például a kategóriát), vagy csak a szélső értékek vagy kulcspontok esetén jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak a nulla, negatív vagy üres értékeknél?**  
Szűrje le az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékekre egy meghatározott szabály szerint.

**Hogyan biztosíthatom a címkék egységes stílusát PDF/képek exportálásakor?**  
Állítsa be kifeexplicit módon a betűcsaládot és méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje a helyettesítést.