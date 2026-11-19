---
title: Diagram adatsorok kezelése bemutatókban PHP-ben
linktitle: Adatsorok
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
- bemutató
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzetcellákat, formázást, átfedést, hézag szélességet és negatív értékeket bemutatókban PHP-vel."
---
## **Áttekintés**

A diagram tárolhatja a megjelenített értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. A [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) egy kapcsolódó értékkészletet képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) egy pontot jelent ebben a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek a diagram munkafüzetéből származó [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) objektumokat használják.

A tipikus kategória diagram esetén az alapértelmezett munkafüzet az 0. sort a sorozatneveknek, a 0. oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek használja. A [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) metódusnak átadott munkalap-, sor- és oszlopszámok nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden létező diagram ezt használja. Betöltött bemutató esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) adja meg az alapértelmezett megjelenést egy sorozat összes pontjához.
- Adatpont szintű beállítások, például a [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) felülírja a sorozat megjelenését egyetlen pontra.
- Csoport beállítások olyan kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) metódussal érheti el, ha például az átfedés vagy a réstávolság beállítására van szüksége.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása felülbírálja a sorozatét az adott pont esetén.

![chart-series-powerpoint](chart-series-powerpoint.png)

Csoportos hengerdiagram esetén tekintse meg, hogy a [changing the 3D series type or bar shape](/slides/hu/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, amikor a sorozatértékek az alkalmazás adatából vagy számításából származnak, és nem szükséges munkalap‑cellahivatkozás. Hívja a [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) metódust a [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) értékével, mielőtt minden pont [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) segítségével állítaná be.

A gyűjtemény beállítása a sorozat összes pontértékének forrástípusát szabályozza. Az egyes pontértékek [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) metódusa jelentést készít a kiválasztott típusról; ezt a gyűjtemény beállításával módosíthatja. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) hívható a hivatkozott cella eléréséhez. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) vagy a `setAsLiteralDouble` használható a szám közvetlen olvasásához vagy írásához.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a meglévő első sorozat pontjainak értékeit 10, 20 és így tovább számított értékekkel tölti fel. A bemutatót elmenti, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa elkülönül a [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) beállítástól, amely a diagram belső vagy külső munkafüzet‑konfigurációját jelöli. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is rendelkezésre áll a kategóriacímkékhez, sorozatnevekhez és a többi sorozathoz. Lásd a [Chart Workbook](/slides/hu/php-java/chart-workbook/) részt a munkafüzet‑kezeléshez.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) metódusokat a [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) és a [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) forrásainak kiválasztásához. A buborék diagramok a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) metódust is használják a [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) esetén. Minden alkalmazandó forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble` metódussal számokat rendelnél hozzá.

## **Diagram sorozat átfedés beállítása**

A [ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) megadja, hogy egy 2D diagramban a sávok vagy oszlopok mennyire átfedik egymást, -100 és 100 százalék között. Ez a szülő sorozatcsoport beállításának csak olvasható leképezése. A [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) segítségével frissítheti a csoport minden kompatibilis sorozatát. Ez a lehetőség azokban a diagramtípusokban érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; a kombinációs diagramokban lévő egyéb sorozatcsoportokra nincs hatása.

Az alábbi példa a csoport átfedését állítja be, amely az első sorozatot tartalmazza:

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

## **Sorozat kitöltőszín módosítása**

Használja a [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) metódust egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy kék szilárd kitöltést alkalmaz az első sorozatra:

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

## **Sorozat név módosítása**

A sorozat neve a diagram adatmunkafüzetében tárolódik, és általában a jelmagyarázatban jelenik meg. Egy csoportos oszlopdiagram alapértelmezett munkafüzetében a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a változónevek a struktúrát explicit módon tükrözik:

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

A [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli a meglévő diagram sor és oszlop konkrét pozíciójára való támaszkodást:

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

### **Sorozat létrehozása több cellából álló névvel**

Kompozit sorozatnév akkor hasznos, ha egy terméknév és egy jelentési időszak külön munkafüzet‑cellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévvé kombinálhatja, miközben mindkét rész hivatkozik a forráscellákra.

Használja a [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepeljenek‑e: `true` kizárja őket, `false` pedig belefoglalja. Ebben a példában `false`‑t használunk, hogy a névtartomány minden celláját felvegyük.

Az alábbi példa egy bemutatót hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét biztosítják; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

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

    // Ez a két cella biztosítja a sorozat nevét.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Külön cellák biztosítják a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cellaérték között. A jelmagyarázat ezt egy bejegyzésként jeleníti meg mindkét oszlopra. Az alábbi kép mutatja az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatikus sorozat kitöltőszín lekérése**

A [ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) visszaadja a sorozatindex és a diagram stílusa alapján számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus csak kiolvassa a számított színt; nem állít be új kitöltést.

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

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függnek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv, oszlop és buborék sorozatok esetén a [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) segítségével megjeleníthető a negatív értékek eltérő kitöltéssel. Állítsa be a szabályos sorozat kitöltését szilárd színre, engedélyezze az inverziót, és adja meg a negatív értékek színét a [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagram adatot. A munkalap 0‑s sora a sorozat nevét, a 0‑s oszlopa a kategória neveket, az 1‑s oszlopa pedig az értékeket tartalmazza:

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

Inverziót egy ponton is engedélyezhet a [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) segítségével. Az alábbi példában a sorozatra vonatkozó inverzió ki van kapcsolva, csak a kiválasztott ponton be van kapcsolva. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) segítségével érhető el. Az adatpont a kategóriahelyen marad, de a diagram a értékét üresnek tekinti a diagram üres‑érték beállításai szerint.

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

Szórt diagramok külön X és Y cellákat használnak, a buborék diagramok továbbá egy méretcellát is. Csak azt a cellát törölje, amely a törlendő értéket reprezentálja. Ne hívja a [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus az összes adatpontot eltávolítja a sorozatból.

## **Üres cellák megjelenésének szabályozása**

A rejtett, értékkel rendelkező cellák külön esetet képeznek az üres cellákkal szemben. A rejtett munkalap‑sorok és -oszlopok adatainak fel‑ vagy le­vonásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzet‑cellá a hiányzó adatot jelzi; egy `0`‑t tartalmazó cella ismert numerikus értéket jelent. A [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) metódussal `null`‑t adjon meg, hogy a cella üres legyen. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellák beállításától.

A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) metódussal választhatja ki, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik, és megváltoztatja, hogyan vannak ábrázolva a hiányzó értékek, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi, önálló példában egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, majd minden mód szerint menti a diagramot. Bemeneti fájl nem szükséges. A [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategóriacímkéknek, az 1‑s oszlopot az értékeknek használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

    // A 3. napot valóban üresen hagyja, miközben megtartja a kategóriát és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót akar menteni, állítsa be a kívánt módot, és egyszer mentse a bemutatót a módok ismétlése helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram egyszerűen összehasonlítható mindhárom móddal. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely a hiányzó kategória felett összekötné a pontokat, így a `Span` nem hozhat létre összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop hasonlóan nézhet ki. Hasonlóképpen egy szórt diagram csak jelölőkkel nem rendelkezik vonallal. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a saját típusában.

## **Sorozat réstávolság beállítása**

A réstávolság a szomszédos sáv‑ vagy oszlopcsoportok közötti helyköz, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) metódust egyszer a csoportra. Nagyobb érték nagyobb hézagot eredményez a csoportok között; kisebb érték sűrűbb elrendezést.

Az alábbi példa módosítja a réstávolságot, és csak a végleges bemutatót menti el:

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

## **Sorozatvonalak megjelenítése vagy elrejtése**

A sorozatvonalak vizuálisan összekötik a diagram kapcsolódó részeit. Használja a [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) metódust a támogatott rétegelt sáv‑ és OfPie diagramokban történő megjelenítésükre vagy elrejtésükre. Két dimenziós rétegelt sáv‑ és oszlopdiagramokban a vonalak a megfelelő réteghatárokat kötik össze a kategóriák között. Pie of Pie és Bar of Pie diagramokban a fő diagramot kötik a másodlagos diagramhoz. Ez a beállítás nem általános csatlakozó más diagramtípusok számára.

A csoportot a [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) metódussal érheti el. A beállítás minden sorozatra hat a csoportban. A [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) csak olvasható, és a szülőcsoport beállítását tükrözi; a csoport beállítóját kell meghívni a módosításhoz.

Az alábbi példa egy [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) diagramot hoz létre alapértelmezett adatokkal. Elmenti ugyanazt a diagramot a sorozatvonalak engedélyezésével, majd letiltásával, így két bemutatót kap összehasonlításra.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Sorozatvonalak engedélyezve | Sorozatvonalak letiltva |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| A két vonal a fő tortát köti a másodlagos tortához. | Mindkét torta látható, de a csatlakozó vonalak rejtve vannak. |

A sorozatvonalak különböznek az adatcímke vezetővonalaitól, amelyek a címkéket kötik az adatpontokhoz; a rácsvonalaktól, amelyek a diagram tengelye mentén jelzik az intervallumokat; és a vonaldiagram vonalaitól, amelyek az adatértékeket ábrázolják. Ez a beállítás nem irányítja ezeket az elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagram adatokat, de a sorozataik nem mindegyiknek azonos értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípusnak megfelelő adatpont‑létrehozó metódust kell használni. Az olyan opciók, mint az átfedés és a réstávolság, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket is törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés szintén létrehozhat diagramot alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a megfelelő kategória alá kerüljön.

**Hogyan törölhetem egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcella `null`‑ra, hogy a pont kategóriahelye üres pontként maradjon. A [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) metódust csak akkor használja, ha az összes pontot el akarja távolítani a sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek a kategóriagyűjteménnyel továbbra is összeilljenek.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusa és a [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) konfigurált értéke szerint alakul. A támogatott diagramok a hiányzó pontokat megszakításként, nullaként vagy a szomszédos pontok összekapcsolásával jeleníthetik meg. Válassza ki a beállítást, amely a hiányzó adatok jelentésének leginkább megfelel a prezentációjában. Lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén hívja a [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) metódust, és állítsa be a [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) által visszaadott színt. Egy egyedi pontra a [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) segítségével felülírhatja a viselkedést. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás felülbírálja a sorozat formázását az adott pontnál. A többi pont továbbra is a kifejezett sorozatformátumot vagy, ha az nincs definiálva, a automatikus diagramstílust és témát használja. A csoport beállításai, mint az átfedés és a réstávolság, az elrendezést szabályozzák, és nem pont‑szintű formázási felülbírálásként működnek.

**Van korlátozás arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem szab ki különálló fix sorozatszám‑korlátot. Gyakorlatilag a bemutató‑fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell módosítanom, ha a oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti hézag szélesítéséhez, vagy csökkentse, ha közelebb szeretné őket hozni.