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
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerkedjen meg azzal, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézagszélességet és negatív értékeket a prezentációkban PHP segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadatok munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartcategory/) objektumok biztosítják a címkéket vagy a sorozatok által megosztott csoportosítási értékeket. A sorozat neve, a kategóriák és a pontértékek ezért a [ChartDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként vannak tárolva.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, a 0‑s oszlopot a kategória nevekhez, a többi cellát pedig a sorozatértékekhez. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getCell)‑nek átadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés hasznos, ha egy diagramot alapértelmezett adatokkal hoz létre, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző hatókörben léteznek:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat), amely az összes pont alapértelmezett megjelenését biztosít egy sorozaton belül.
- Adatpont szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat), amely egy pont esetén felülírja a sorozat megjelenését.
- Csoportbeállítások, amelyek kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedést vagy hézagszélességet szeretne beállítani.

Ha nincs kifejezetten beállítva pont- vagy sorozattöltés, a diagram stílusa és sablonja határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása élvez elsőbbséget az adott pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getOverlap) jelzi, hogy a 2D diagramon a sávok vagy oszlopok mennyire fedik át egymást, -100‑tól 100‑ig terjedő százalékban. Ez csak olvasható leképezése a szülő sorozatcsoport beállításának. Használja a [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setOverlap) metódust, hogy frissítse a csoport összes kompatibilis sorozatát. Ez a lehetőség olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; a kombinált diagramokban a nem kapcsolódó sorozatcsoportokat nem befolyásolja.

Az alábbi példa beállítja az átfedést arra a csoportra, amely az első sorozatot tartalmazza:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
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

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat) metódust, hogy az egész sorozatra alapértelmezett kitöltést állítson be. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adatmunka könyvben van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely egy csoportos oszlopdiagramhoz jön létre, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a változók egyértelművé teszik ezt a szerkezetet:

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

A cellát már a [ChartSeries.getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getName) által hivatkozott helyen is frissítheti. Ez a megközelítés elkerüli a meglévő diagram egy adott sor és oszlop feltételezését:

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

![A sorozat neve](series_name.png)

## **Az automatikus sorozatkitöltő szín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak kiolvassa a számított színt; nem állít be új kitöltést.

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

Példa kimenet az alapértelmezett diagramstílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és sablonjától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buboréksorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) segítségével negatív értékekhez másik kitöltés jeleníthető meg. Állítsa a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, majd adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színnel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa a alapértelmezett diagramadatot egy sorozatra cseréli. A munkalap 0‑s sorában a sorozat neve, a 0‑s oszlopban a kategória nevek, az 1‑s oszlopban az értékek vannak:

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

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Az invertálást egy pont esetén a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével is engedélyezheti. Az alábbi példában az invertálás le van tiltva a sorozaton, de csak a kiválasztott pontnál van engedélyezve. A pont negatív értéket is kap, hogy a hatás látható legyen:

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

Egy pont üresre állításához a többi pont eltávolítása nélkül állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont a ugyanabban a kategóriapozícióban marad, de a diagram a értékét üresnek tekinti a diagram üres‑érték beállítása szerint.

Az alábbi példa csak a második pontot törli az első sorozatban:

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékgrafikonok pedig méretcellát is. Törölje csak azt a cellát, amely a törlendő értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

Egy üres munkafüzetcellát hiányzó adatként kezelünk; a `0` értékű cella ismert numerikus értéket jelent. Hívja meg a [ChartDataCell::setValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setValue) metódust `null`‑val, hogy egy cellát üresre állítson. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cella beállítástól.

Használja a [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#setDisplayBlanksAs) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogy a hiányosságok hogyan legyenek ábrázolva, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3‑as nap értékét, majd ugyanazt a diagramot elmenti minden módhoz. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, 0‑s oszlopot használja a kategóriacímkékhez, és 1‑s oszlopot az értékekhez; a 0‑s sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriát és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ismétlése helyett.

Az alábbi összehasonlítás három fájl azonos adatát mutatja. A 3‑as nap üres a munkafüzetben minden esetben:

![Vonaldiagramok azonos adatokkal: A Gap a vonalat szaggatja a 3‑as napnál, a Zero a vonalat nullához viszi, a Span pedig összeköti a 2‑es és a 4‑es napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagramnál a három mód könnyen összehasonlítható. Sáv‑ és oszlopdiagramoknál nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem tudja előállítani a fent látható összekötő szegmenst; egy hiányzó oszlop és egy nullmagasságú oszlop is hasonlóan nézhet ki. Hasonlóan, egy pontdiagram csak jelölőkkel nem rendelkezik összekötő vonallal. Ne számítson három különböző eredményre minden diagramtípus esetén; ellenőrizze a kimenetet a használt típusnál.

## **A sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszlopcsoportok közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a csoportra. Egy nagyobb érték több helyet hoz létre a csoportok között; egy kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a hézagszélességet, és csak a végső prezentációt menti el:

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

![A hézagszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, azonban sorozataik nem minden esetben rendelkeznek azonos értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a pontdiagramok X és Y értékeket, a buborékgrafikonok pedig buborékméreteket adnak hozzá. A sorozattípusnak megfelelő adatpont‑létrehozó módszert kell alkalmazni. Az olyan opciók, mint az átfedés és a hézagszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Egy frissen létrehozott diagram alapértelmezett adatokat tartalmaz?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addChart) minta sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatépítéskor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat igazítva, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a releváns értékcellát `null`‑ra, hogy a pont kategóriapozícióját üres pontként megtartsa. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is törli, frissítse az összes sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#setDisplayBlanksAs) által beállított értéktől függ. A támogatott diagramok megjeleníthetik az üresek helyét hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely a hiányzó adatok jelentését a prezentációjában legjobban tükrözi. Lásd a **Az üres cellák megjelenítésének szabályozása** részt a teljes példa és vizuális összehasonlítás miatt.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv‑, oszlop‑ és buboréksorozatok esetén hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy adott pont viselkedését a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal is felülírhatja. Ezek a módszerek a formázásra, nem a tárolt numerikus értékekre hatnak.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

A kifejezett adatpont‑formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is a kifejezett sorozat‑formázást vagy, ha az nincs definiálva, az automatikus diagramstílust és sablont használja. A csoportbeállítások, mint az átfedés és a hézagszélesség, a layoutot szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem határoz meg különálló rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl mérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg az ésszerű felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti tér növeléséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.