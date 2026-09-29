---
title: Diagram adat sorozatok kezelése prezentációkban PHP-ben
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
description: "Ismerkedjen meg a diagram sorozatok, adatpontok, munkafüzet cellák, formázás, átfedés, hézag szélesség és negatív értékek kezelésével prezentációkban PHP segítségével."
---
## **Áttekintés**

Egy diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekhez, az 0. oszlopot a kategórianévhez, a maradék cellákat pedig a sorozatértékekhez. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap-, sor- és oszlopindexek nullával kezdődnek. Ez a felépítés akkor hasznos, amikor alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden létező diagram ezt a felépítést használja. Betöltött prezentáció esetén ellenőrizze a sorozat, a kategóriák és az adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagram beállításainak három különböző hatóköre van:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat) alapértelmezett megjelenést biztosítanak egy sorozat összes pontjának.
- Adatpont beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat) felülírják a sorozat megjelenését egy adott pont esetén.
- Csoport beállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha olyan opciókat szeretne beállítani, mint az átfedés vagy a hézag szélessége.

Ha nincs kifejezett pont vagy sorozat kitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha a sorozat és a pont formázása is jelen van, a pont formázása élvez elsőbbséget az adott pont esetén.

![diagram-sorozat PowerPoint](chart-series-powerpoint.png)

## **Állítsa be a diagram sorozatok átfedését**

[A ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a sávok vagy oszlopok mennyire fedik át egymást egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti az adott csoport minden kompatibilis sorozatát. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinációs diagramokhoz nem tartozó sorozatcsoportokat.

A következő példa beállítja az átfedést ahhoz a csoporthoz, amely az első sorozatot tartalmazza:

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

![A sorozat átfedése](series_overlap.png)

## **Módosítsa a sorozat kitöltőszínét**

[A ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat) használatával állíthatja be egy teljes sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor annak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

## **Módosítsa a sorozat nevét**

Egy sorozat neve a diagramadat-munkafüzetben van tárolva, és általában a legendában jelenik meg. Egy klaszterelt oszlopdiagramhoz létrehozott alapértelmezett munkafüzetben a B1 cella a 0. sorban, 1. oszlopban található, és az első sorozat nevét tartalmazza. A következő példában a nevű változók egyértelművé teszik ezt a felépítést:

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

A [ChartSeries.getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getName) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagram egy adott sorát és oszlopát feltételezze:

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

## **Szerezze meg a sorozat automatikus kitöltőszínét**

[A ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) a sorozat indexéből és a diagram stílusából számított színt adja vissza. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten megadva. A metódus hívása a kiszámított színt olvassa, nem állít be új kitöltést.

A következő példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

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

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Állítsa be a fordított kitöltőszínt egy diagram sorozathoz**

Sáv, oszlop és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) segítségével negatív értékek másik kitöltéssel jeleníthetők meg. Állítsa be a normál sorozat kitöltést szilárdra, engedélyezze a fordítást, és a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) használatával adja meg. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

A következő példa az alapértelmezett diagram adatot egy sorozattal helyettesíti. A munkalap 0. sora a sorozat nevét, a 0. oszlop a kategórianéveket, az 1. oszlop pedig az értékeket tartalmazza:

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

![A fordított szilárd kitöltés színe](inverted_solid_fill_color.png)

A [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével egyetlen pontnál engedélyezheti a fordítást. A következő példában a fordítás ki van kapcsolva a sorozatra, és csak a kiválasztott pontnál van engedélyezve. A ponthoz negatív értéket is hozzárendelünk, hogy hatása látható legyen:

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

## **Specifikus adatpont érték törlése**

Egy pont kiürítéséhez a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzetcellát `null`-ra. Egy oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont a ugyanazon kategóriahelyen marad, de a diagram a beállított üres-érték beállítások szerint üresnek tekinti az értékét.

A következő példa csak a második pontot törli az első sorozatban:

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Törölje csak azt a cellát, amely az eltávolítani kívánt értéket képviseli. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus a sorozat minden adatpontját eltávolítja.

## **Üres cellák megjelenítésének vezérlése**

A rejtett, értéket tartalmazó cellák külön helyzetet jelentenek az üres celláktól. A rejtett munkalap-sorokból és -oszlopokból származó adatok felvételéhez vagy kizárásához tekintse meg a [Rejtett sorokból és oszlopokból származó adatok bevonása](/slides/hu/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalát.

Egy üres munkafüzetcell a hiányzó adatot jelöli; egy `0` értéket tartalmazó cella egy ismert numerikus értéket jelent. Hívja a [ChartDataCell::setValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setValue) metódust `null` paraméterrel, hogy a cellát üressé tegye. A numerikus nulla továbbra is nulla marad, függetlenül az üres-cellá beállítástól.

A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#setDisplayBlanksAs) használatával választhatja ki, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja az üres helyek ábrázolását anélkül, hogy a munkafüzet üres celláját nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módban elmenti ugyanazt a diagramot. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) a 0. munkalapot, az 0. oszlopot használja a kategória címkékhez, az 1. oszlopot az értékekhez; a 0. sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja annak kategóriáját és adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és mentse a prezentációt egyszer a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap szünetet okoz a vonalon a 3. napon, a Zero a vonalat nullára taszítja, a Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram könnyen összehasonlítható mindhárom módot. A sáv- és oszlopdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, ezért a `Span` nem képes előállítani a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlónak tűnhet. Hasonlóképpen egy csak markeres szórt diagramnak sincs összekötő vonala. Ne számítson három különböző eredményre minden diagramtípus esetén; ellenőrizze a kimenetet a használt típushoz.

## **Állítsa be a sorozat hézag szélességét**

A hézag szélessége a szomszédos sáv- vagy oszlopcsoportok közötti tér, amely a sáv vagy oszlop szélességének százalékában van kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer kell meghívni a csoportnál. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbbé teszi azokat.

A következő példa megváltoztatja a hézag szélességét, és csak a végső prezentációt menti:

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Az adatpont létrehozási metódust a sorozat típusához kell választani. Az átfedés és a hézag szélesség beállításai csak a kompatibilis sáv- vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport megváltoztatása nem feltétlenül módosítja a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheti ezeket a cellákat, vagy törölheti a sorozat- és kategória-gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, a kategória címkék és az adatpont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adatok építésekor tartsa összehangoltan a kategória sorokat és a sorozat-érték sorokat, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan törlök egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`-ra, hogy a pont kategóriahelye üres pontként megmaradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek illeszkedjenek a kategóriagyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#setDisplayBlanksAs) által beállított értéktől függ. A támogatott diagramok megjeleníthetik az üres helyeket hézagként, nulláértékekként vagy a szomszédos pontok összekapcsolásával. Válassza azt a beállítást, amely megfelel a hiányzó adatok jelentésének a prezentációban. Tekintse meg az [Üres cellák megjelenítésének vezérlése](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázottak a negatív értékek?**

Támogatott sáv-, oszlop- és buborék sorozatok esetén hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Az egyedi pontok viselkedését felülírhatja a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont egyaránt formázva van?**

A kifejezett adatpont formázás elsőbbséget élvez az adott pont esetén. A többi pont továbbra is az explicit sorozat formátumot vagy, ha a sorozat formátuma nincs meghatározva, az automatikus diagram stílust és témát használja. A csoportbeállítások, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pontszintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem állít be külön rögzített sorozatszám korlátot. Gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos limitet.

**Mit változtassak, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a megfelelő szülő sorozatcsoporton a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust. Növelje az értéket a klaszterek közti tér növeléséhez, vagy csökkentse, hogy a klaszterek közelebb kerüljenek egymáshoz.