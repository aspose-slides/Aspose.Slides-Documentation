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
description: "Megtanulhatja, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban PHP-vel."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagram adat munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/) egy kapcsolódó értékek halmazát képviseli, és a sorozat minden egyes [ChartDataPoint](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Ezért a sorozat neve, a kategóriák és az adatpont értékek a [ChartDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, és a maradék cellákat a sorozatértékeknek. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap, sor és oszlop indexek **nulla alapúak**. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagram beállításainak három különböző hatóköre van:

- Sorozat szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat), az adott sorozat összes pontjára vonatkozó alapértelmezett megjelenést biztosítják.  
- Adatpont szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat), felülbírálják a sorozat megjelenését egy adott pontnál.  
- Csoport beállítások kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) csoporthoz tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedési vagy hézag szélességi beállításokat szeretne megadni.

Ha nem állít be kifejezett pont- vagy sorozat kitöltést, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása lesz előnyben a adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. Használja a [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setOverlap) metódust a csoport **minden** kompatibilis sorozatának frissítéséhez. Ez a lehetőség a csoportos sávokat vagy oszlopokat megjelenítő diagramtípusokra vonatkozik; a kombinált diagramon lévő nem kapcsolódó sorozatcsoportokra nincs hatása.

A következő példa beállítja az átfedést annak a csoportra, amely az első sorozatot tartalmazza:

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

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getFormat) metódust egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülbírálja a sorozat kitöltését az adott pontnál.

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

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy klaszterezett oszlopdiagramhoz jön létre, a B1 cella a 0. sorban, 1. oszlopban található, és az első sorozat nevét tartalmazza. A következő példa elnevezett változói egyértelművé teszik ezt a struktúrát:

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

Frissítheti azt a cellát is, amelyre a [ChartSeries.getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getName) már hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

## **Az automatikus sorozat kitöltőszín lekérése**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak kiolvassa a kiszámított színt; nem állít be új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színét:

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

## **Invertált kitöltőszín beállítása diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatoknál a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) különböző kitöltéssel jelenítheti meg a negatív értékeket. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az invertálást, és rendelje hozzá a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

A következő példa lecseréli az alapértelmezett diagram adatokat egy sorozatra. A munkalap 0. sora a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

Az invertálást egy pontnál a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal engedélyezheti. A következő példában a sorozatnál le van tiltva az invertálás, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresre állításához a többi pont eltávolítása nélkül állítsa be a mögöttes munkafüzetcellát `null`-ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont a ugyanazon kategória pozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresként kezeli.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig méret cellát is. Csak azt a cellát törölje, amely a eltávolítani kívánt értéket képviseli. Ne hívja meg a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus a gyűjtemény minden adatpontját eltávolítja.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv vagy oszlop csoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a csoport számára. A nagyobb érték nagyobb távolságot hoz létre a csoportok között; a kisebb érték sűrűbbé teszi őket.

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
Minden, a [ChartType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/charttype/) felsorolás által képviselt diagramtípus használ diagram adatot, de a sorozataik nem mindegyike rendelkezik ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborék méreteket adnak hozzá. Használja az adatpont létrehozásához a sorozattípussal megegyező metódust. Az olyan opciók, mint az átfedés és a hézag szélesség, csak a kompatibilis sáv vagy oszlop csoportokra vonatkoznak.

**Mi az a diagram sorozat csoport?**  
A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram **összes** sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**  
Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addChart) minta sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat- és kategória gyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) képes diagramot létrehozni alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**  
A sorozatnevek, a kategória címkék és az adatpont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adatok építésekor tartsa a kategória sorokat és a sorozat‑érték sorokat igazítva, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan török egy pontot a teljes sorozat helyett?**  
Állítsa a megfelelő érték cellát `null`-ra, hogy a pont kategória pozíciója megmaradjon üres pontként. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha az adott sorozat **összes** pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is azonos sorban legyenek a kategória gyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**  
Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/#setDisplayBlanksAs) beállítástól függ. A támogatott diagramok üres helyeket jeleníthetnek meg **hézagként**, **null értékként** vagy a **szomszédos pontok összekapcsolásával**. Válassza ki azt a beállítást, amely a prezentációjában a hiányzó adatok jelentésének leginkább megfelel.

**Hogyan formázódnak a negatív értékek?**  
A támogatott sáv, oszlop és buborék sorozatoknál hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy egyedi pont viselkedését felülírhatja a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**  
A kifejezett adatpont formázás lesz az előnyben az adott pontnál. A többi pont továbbra is a kifejezett sorozat formátumot használja, vagy ha a sorozat formátum nincs definiálva, akkor az **automatikus diagram stílus** és **téma**. A csoport beállítások, mint például az átfedés és a hézag szélesség, a **elrendezést** szabályozzák, és nem pont szintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**  
Az Aspose.Slides nem szab ki külön, rögzített sorozatszám korlátot. Gyakorlatban a prezentáció fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos korlátot.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**  
Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti távolság bővítéséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.