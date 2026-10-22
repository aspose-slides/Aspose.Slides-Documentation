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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézagszélességet és negatív értékeket a prezentációkban PHP segítségével."
---
## **Áttekintés**

Egy diagram tárolhatja a kirajzolt értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. Egy [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) egy kapcsolódó értékkészletet képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) egy pontot jelent abban a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) objektumok biztosítják a címkéket vagy a sorozatok által megosztott csoportosítási értékeket. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek a [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) objektumokat használják a diagram munkafüzetéből.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sorban tárolja a sorozatneveket, a 0‑s oszlopban a kategória neveket, a maradék cellákban pedig a sorozatértékeket. A [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/)‑nek átadott munkalap‑, sor‑ és oszlopindexek nullával kezdődnek. Ez a felépítés akkor hasznos, amikor alapértelmezett adatokkal hoz létre egy diagramot, de nem szabad azt feltételezni, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző hatókörrel rendelkeznek:

- Sorozat‑szintű beállítások, mint például a [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), az adott sorozat összes pontjának alapértelmezett megjelenését biztosítják.
- Adatpont‑szintű beállítások, mint például a [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), egy pont számára felülbírálják a sorozat megjelenését.
- Csoportbeállítások vonatkoznak a kompatibilis sorozatokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) csoporthoz tartoznak. A csoportot a [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/)‑nél érheti el, ha például átfedés vagy hézagszélesség beállítására van szükség.

Ha nincs kifejezetten beállítva sem pont, sem sorozat kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása előnyt élvez a ponton.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek az alkalmazás adataiból vagy számításából származnak, és nem igényelnek munkalap‑cellahivatkozásokat. Hívja meg a [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)‑t a [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/)‑vel, mielőtt az egyes pontok [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)‑on keresztül rendeli volna hozzá.

A gyűjtemény beállítása szabályozza az adott sorozat összes pontértékének forrástípust. Az egyes pontértékek [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) metódusa jelzi a kiválasztott típust; ezt a gyűjtemény beállításával módosíthatja. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/)‑t használja a hivatkozott cella eléréséhez. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) vagy a `setAsLiteralDouble` segítségével olvashatja vagy írhatja a számot közvetlenül.

Az alábbi példa oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a saját sorozata első sorozatának meglévő pontjaihoz rendeli a 10, 20 stb. számolt értékeket. A prezentációt menti, újra megnyitja, és kiírja a tárolt értékeket.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

A pontérték forrástípusa különbözik a [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)‑tól, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. Numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sorozatnevek és a többi sorozat számára. Lásd a [Chart Workbook](/slides/hu/php-java/chart-workbook/) oldalt a munkafüzet‑kezeléshez.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) metódusokat a [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) és [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) forrásainak kiválasztásához. Buborék diagramok esetén a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) is használható a [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) számára. Minden releváns forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble`‑el számot rendelne hozzá.

## **Diagram sorozat átfedésének beállítása**

A [ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) megadja, hogy a 2D diagram sávjai vagy oszlopai milyen mértékben fednek át egymást, -100 és 100 százalék között. Ez csak olvasható leképezése a szülő sorozatcsoport beállításának. A [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) segítségével frissítheti az összes kompatibilis sorozatot az adott csoporton belül. Ez a lehetőség a csoportosított sávokat vagy oszlopokat megjelenítő diagramtípusokra vonatkozik; kombinált diagramok esetén a nem kapcsolódó sorozatcsoportok nem érintettek.

Az alábbi példa beállítja az átfedést azon a csoporton, amely az első sorozatot tartalmazza:

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

## **Sorozat kitöltőszín módosítása**

Használja a [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)‑t az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) beállítása felülbírálja a sorozat kitöltését az adott ponton.

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

![A sorozat színe](series_color.png)

## **Sorozat nevének módosítása**

A sorozat neve a diagram adatmunkafüzetében van tárolva, és általában a jelmagyarázatban jelenik meg. Egy csoportosított oszlopdiagram alapértelmezett munkafüzetében a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában szereplő változók ezt a szerkezetet explicit módon tükrözik:

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

Frissítheti azt a cellát is, amelyre már a [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) hivatkozik. Ez a megközelítés elkerüli a konkrét sor és oszlop feltételezését egy meglévő diagramon:

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

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév hasznos, ha egy termék neve és egy jelentési időszak külön cellákban van tárolva. Például a `Product A` a B1‑ben, a `2026` a C1‑ben kombinálható egyetlen sorozatnévvé, miközben mindkét rész továbbra is a forráscelláira hivatkozik.

A [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) segítségével lekérheti a névtartományt, majd azt a [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/)‑nek adja át. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepeljenek‑e: `true` kizárja, `false` belefoglalja őket. Ez a példa `false`‑t használ, hogy minden cellát felvegye a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozatnevet szolgáltatják; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cellaérték között. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép mutatja az eredményt:

![Oszlopdiagram Észak és Dél értékekkel, valamint a kompozit sorozatnév Product A 2026 a jelmagyarázatban](composite_series_name.png)

## **Automatikus sorozat kitöltőszín lekérdezése**

A [ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

Az alábbi példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

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

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv, oszlop és buborék sorozatok esetén a [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) segítségével negatív értékek megjeleníthetők egy másik kitöltéssel. Állítsa be a normál sorozatkitöltést szilárdra, aktiválja az invertálást, és adja meg a negatív érték színét a [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)‑nel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagram adatokat. A munkalap 0‑s sora a sorozatnevet, a 0‑s oszlop a kategória neveket, az 1‑s oszlop pedig az értékeket tartalmazza:

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

Inverziót egyetlen pontnál is engedélyezhet a [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) segítségével. Az alábbi példában a inverzió a sorozatra le van tiltva, csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresre állításához anélkül, hogy a többi pont eltűnne, állítsa a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a kirajzolt érték a [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)‑n keresztül érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresként kezeli.

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

A szórt diagramok X és Y cellákat, a buborék diagramok pedig egy méretcellát használnak. Csak azt a cellát törölje, amelyik az eltávolítani kívánt értéket tartalmazza. Ne hívja a [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)‑t, ha a többi pontot megtartja, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének vezérlése**

A rejtett cellák, amelyek értéket tartalmaznak, különböznek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak fel- vagy letiltásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzet‑cellát a `null`‑val a [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/)‑vel jelölhet meg. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellák beállításától.

A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) segítségével választhatja ki, hogyan jelenjenek meg az üres cellák a diagramon. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan jelennek meg a hiányzó értékek, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3‑ik nap értékét, és minden mód esetén elmenti ugyanazt a diagramot. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, a 0‑s oszlopot a kategóriacímkéknek, az 1‑s oszlopot az értékeknek használja; a 0‑s sor a sorozatnevét tartalmazza. A végső adat: `10, 20, empty, 30, 40`.

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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a ciklikus mentés helyett.

Az alábbi összehasonlítás mindhárom fájlban azonos adatot mutat. A 3‑ik nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap szünetet okoz a vonalon a 3‑ik napnál, Zero a vonalat nullához húzza, és Span összeköti a 2‑ik napot a 4‑ikkel.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Sáv‑ és oszlopdiagramok nem rendelkeznek vonallal, amely a hiányzó kategória felett összekötné a szegmenseket, ezért a `Span` nem tudja előállítani a fenti kapcsolódó szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy szórt diagram csak jelölőkkel nem rendelkezik vonallal. Ne számítson három különböző eredményre minden diagramtípus esetén; ellenőrizze a kimenetet a használt típusnál.

## **Sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszlopháromok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoport szintjén van, nem egyes sorozatnál. Hívja meg a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)‑t egyszer a csoporton. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a hézagszélességet, és csak a végleges prezentációt menti:

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

**Milyen diagramtípusok támogatják az adat sorozatokat?**

Az összes diagramtípus, amelyet a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) felsorolás képvisel, használ diagram adatot, de sorozataik nem mindegyiknél rendelkeznek ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípusnak megfelelő adatpont‑létrehozó metódust használja. Az olyan beállítások, mint az átfedés és a hézagszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) olyan kompatibilis sorozatokat tartalmaz, amelyek csoportszintű ábrázolási beállításokat osztanak meg. Kombinált diagram esetén több csoport is lehet, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket kitörölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy overload segítségével diagramot hozhat létre alapértelmezett adat nélkül is.

**Hogyan vannak a diagram objektumok kapcsolva a munkafüzet celláihoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat felépítésekor tartsa a kategóriasorokat és a sorozat‑érték sorokat igazított állapotban, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a releváns értékcellát `null`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/)‑t csak akkor használja, ha az adott sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse az összes sorozatot, hogy értékeik a kategória‑gyűjteménnyel igazodjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusa és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)‑ben konfigurált érték függvénye. A támogatott diagramok megjeleníthetik az üresek a hézagok, nulla értékek vagy a szomszédos pontok összekapcsolása formájában. Válassza ki a beállítást, amely a hiányzó adat jelentésének leginkább megfelel a prezentációjában. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) szakaszt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv‑, oszlop‑ és buborék sorozatok esetén hívja a [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/)‑t, és állítsa be a színt, amelyet a [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) visszaad. Egy egyedi pont viselkedését a [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)‑vel felülbírálhatja. Ezek a módszerek a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás élvez elsőbbséget, ha a sorozat és a pont is formázva van?**

A kifejezett adatpont‑formázás elsőbbséget élvez az adott ponton. A többi pont továbbra is a kifejezett sorozatformátumot, vagy ha a sorozatformátum nincs definiálva, az automatikus diagram stílust és témát használja. A csoportbeállítások, mint az átfedés és a hézagszélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájl‑korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos korlátot.

**Mit módosítsak, ha a oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti tér szélesítéséhez, vagy csökkentse, ha a csoportok közelebb szeretnék kerülni egymáshoz.