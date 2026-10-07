---
title: Diagramadat-sorozatok kezelése prezentációkban PHP-ben
linktitle: Adatsorozatok
type: docs
url: /hu/php-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat név
- adatpont
- munkafüzet cella
- sorozat rés
- negatív érték
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, sávszélességet és negatív értékeket prezentációkban PHP segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) egy összefüggő értékcsoportot képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenített szövegként tárolódnak.

A tipikus kategória-diagramhoz az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, a 0‑s oszlopot a kategória-nevekhez, a maradék cellákat pedig a sorozatértékekhez. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap‑, sor‑ és oszlopszámok nullától indulnak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden létező diagram ezt a struktúrát használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) metódus, az egész sorozatra vonatkozó alapértelmezett megjelenést adja meg.
- Adatpont‑szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) metódus, felülírja a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) metódussal érheti el, ha például átfedés vagy sávszélesség beállítására van szüksége.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind sorozati, mind pontformázás jelen van, a pontformázás felülírja a sorozati beállítást az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) megadja, hogy egy 2D diagramon a sávok vagy oszlopok milyen mértékben fedik át egymást, -100 és 100 százalék között. Ez a beállítás csak olvasható nézet a szülő sorozatcsoport beállításáról. Használja a [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) metódust a csoportba tartozó minden kompatibilis sorozat frissítéséhez. Ez az opció azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; a kombinációs diagramok önálló sorozatcsoportjait nem befolyásolja.

Az alábbi példa beállítja az átfedést a csoportban, amely az első sorozatot tartalmazza:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
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

Az eredmény:

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) metódussal állítható be az egész sorozat alapértelmezett kitöltése. Ha egy pont már rendelkezik explicit kitöltéssel, annak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

Az eredmény:

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adatmunkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy csoportosított oszlopdiagramhoz jön létre, a B1 cella a 0‑s sorban, 1‑s oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példában a változók egyértelművé teszik ezt a struktúrát:

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

A cellát közvetlenül is frissítheti a [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) metódus által már hivatkozott helyen. Ez a megközelítés elkerüli, hogy egy meglévő diagramra egy adott sor‑ vagy oszlopindexre támaszkodjon:

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

Az eredmény:

![The series name](series_name.png)

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév hasznos, ha a termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` a B1‑ben és a `2026` a C1‑ben egyetlen sorozatnévvé kombinálható, miközben mindkét rész továbbra is a forráscellához kapcsolódik.

Használja a [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add) metódusnak. A `skipHiddenCells` argumentum szabályozza, hogy a rejtett cellák is bekerülnek‑e: `true` kizárja őket, `false` pedig belefoglalja. Ez a példa `false`‑t használ, hogy a névtartomány minden cellája bekerüljön.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét adják, az A2:A3 a kategóriacímkéket, a B2:B3 a numerikus értékeket.

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

    // Ez a két cella adja a sorozat nevét.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték közti szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép szemlélteti az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozatkitöltő szín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) metódus visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus csak a számított színt olvassa; új kitöltést nem állít be.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és a témától függnek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék-sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) metódus használható a negatív értékek külön kitöltéssel való megjelenítésére. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metódus visszatérési értékével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

Az alábbi példa felülírja az alapértelmezett diagramadatokat egy sorozattal. A munkalap 0‑s sora tartalmazza a sorozat nevét, az 0‑s oszlop a kategória-neveket, az 1‑s oszlop az értékeket:

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

Az eredmény:

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverziót egyetlen pontra a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal is engedélyezheti. Az alábbi példában a inverzió a sorozatra ki van kapcsolva, és csak a kiválasztott pontra van bekapcsolva. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

## **Egy adott adatpont értékének törlése**

Egy pontot üresen hagyhat anélkül, hogy a többi pontot eltávolítaná, ha a mögöttes munkafüzetcellát `null`‑ra állítja. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont a ugyanabban a kategóriahelyen marad, de a diagram a beállított üres‑érték szabályok szerint a pontot üresként kezeli.

Az alábbi példa csak a második pontot tisztítja az első sorozatban:

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

Szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Tisztítsa csak azt a cellát, amely az eltávolítani kívánt értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha meg akarja tartani a többi pontot, mivel ez a metódus az összes adatpontot törli a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett, de értékkel rendelkező cellák külön esetet képeznek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak fel‑ vagy letiltásához lásd az [Include Data from Hidden Rows and Columns](/slides/hu/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) dokumentumot.

Egy üres munkafüzetcellát a hiányzó adat jelölésére használunk; egy `0` értékű cella ismert numerikus értéket jelent. Hívja a [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) metódust `null`‑lal, hogy a cellát üresre állítsa. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja a [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) metódust annak kiválasztására, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. A beállítás megváltoztatja, hogy a hiányzó értékek hogyan kerülnek ábrázolásra, anélkül hogy a munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa létrehoz egy vonaldiagramot egy sorozattal, kitörli a 3. nap értékét, és minden módot külön fájlba ment. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategóriacímkékhez, az 1‑s oszlopot az értékekhez használja; a 0‑s sor a sorozat nevet tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megőrzi a kategóriát és az adatpontot.
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

Minden kimeneti fájl az előzőleg mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus bejárása helyett.

Az alábbi összehasonlítás mutatja a három fájl azonos adatát. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. A vonaldiagram jól szemlélteti mindhárom módot. Sáv‑ és oszlopdiagramok esetén nincs vonal a hiányzó kategória összekötésére, így a `Span` opció nem hoz létre ebből a szegmensből. Hasonlóképpen, egy csak marker‑ekkel rendelkező szórt diagram sem rendelkezik összekötő vonallal. Ne várjon három eltérő eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típusnál.

## **A sorozat sávszélességének beállítása**

A sávszélesség a szomszédos sáv‑ vagy oszloppárok közötti távolságot jelöli, a sáv vagy oszlop szélességének százalékában megadva. Az átfedéshez hasonlóan ez a beállítás a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a csoporton. A nagyobb érték nagyobb távolságot eredményez a csoportok között; a kisebb érték sűrűbb elrendezést hoz létre.

Az alábbi példa módosítja a sávszélességet, és csak a végleges prezentációt menti:

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

Az eredmény:

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) felsorolt diagramtípus diagramadatot használ, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállítása. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípushoz illeszkedő adatpont‑létrehozó metódust kell használni. Az olyan opciók, mint az átfedés és a sávszélesség, csak kompatibilis sáv‑ vagy oszlopsorozatokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**A frissen létrehozott diagram tartalmaz alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezek a cellák szerkeszthetők, vagy a sorozat‑ és kategória‑gyűjteményeket is törölheti, mielőtt teljesen egyedi adatot adna hozzá. Túlterheléssel egy diagramot alapértelmezett adat nélkül is létrehozhat.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória‑címkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat igazítva, hogy minden pont a kívánt kategória alá legyen ábrázolva.

**Hogyan töröthetek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, hogy a pont kategóriapozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha minden pontot el akar távolítani az adott sorozatból. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összhangban.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) metódus által beállított értéktől függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza a jelentésének leginkább megfelelő beállítást. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékek?**

A támogatott sáv-, oszlop- és buborék‑sorozatoknál hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy egyedi pont viselkedését a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal felülírhatja. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás felülírja a sorozati formázást az adott pontnál. A többi pont továbbra is az explicit sorozati formátumot vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoportbeállítások (pl. átfedés, sávszélesség) elrendezést szabályoznak, és nem pont‑szintű formázási felülírások.

**Van korlátozás a diagramban szereplő sorozatok számára?**

Az Aspose.Slides nem állít fel különálló, rögzített sorozatszám‑korlátot. A gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos limitet.

**Mit kell változtatni, ha a oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság szélesítéséhez, vagy csökkentse a közelebbi elhelyezkedéshez.