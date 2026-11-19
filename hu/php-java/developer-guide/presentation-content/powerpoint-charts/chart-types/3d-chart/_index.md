---
title: 3D diagramok testreszabása bemutatókban PHP-val
linktitle: 3D diagram
type: docs
url: /hu/php-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "3D diagramokat hozhat létre PowerPoint bemutatókban az Aspose.Slides for PHP via Java segítségével. A forgást, a magasságarányokat, a diagram mélységét és a sorozatok közti távolságot állíthatja PHP példákkal."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy testreszabja egy 3D diagram nézetét a [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorozatok közötti távolság, majd hogyan menthető a bemutató PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) és a [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) segítségével hozzáad egy halmozott 3D oszlopdiagramot az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A `0` munkalap‑index azonosítja a diagram első adatmunkalapját; a `0` sor a sorozatneveket, az `0` oszlop a kategóriacímkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) és a [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) metódusok a diagram forgását 40 és 270 fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) jobb szögű tengelyeket engedélyez a perspektíva helyett. Az eredményül kapott bemutató a feltöltött diagramot tartalmazza ezekkel a 3D nézeti beállításokkal.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **A 3D diagram magasságarányainak beállítása**

A [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) segítségével állítható be egy 3D diagram magassága a szélesség százalékában. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a dián lévő diagram objektumot.

Az alábbi példa egy [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50%, 100% és 200% magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok közti távolság és a formázás minden három fájlban azonos; csak a magasság százaléka változik.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Az alábbi képek bemutatják ugyanazokat a magasságbeállításokat az ekvivalens .NET példában, és a Microsoft PowerPoint segítségével exportálták. Egy kisebb százaléklaposabb jelenetet eredményez, míg egy nagyobb százalék magasabb jelenetet hoz létre az ugyanazon diagramobjektumban. A PowerPoint ezenkívül módosíthatja a tengelyjelölések intervallumát és a címkék elhelyezését, hogy illeszkedjen a jelenethez.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, melynek magassága a szélesség 50 százalékára van beállítva](height_percent_50.png) | ![3D oszlopdiagram, melynek magassága a szélesség 100 százalékára van beállítva](height_percent_100.png) | ![3D oszlopdiagram, melynek magassága a szélesség 200 százalékára van beállítva](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | A 3D jelenet magassága a szélesség százalékában. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | A diagram objektum magassága a dián, pontban. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | A 3D jelenet mélysége a szélesség százalékában. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasságbeállítás hatással van 3D oszlop- és sávdiagramokra, beleértve a henger-, kúp- és piramisvariánsokat, valamint a 3D vonal-, terület-, kör- és felületi diagramokra. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztály tagjai. Más diagrammegjelenítési beállításokért lásd a [Diagramformázás](/slides/hu/php-java/chart-formatting/) oldalt.

## **A sorozatok közti rés beállítása**

Használja a [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) metódust a 3D diagram adat-sorozatai közti távolság szabályozásához a mélységi tengely mentén, a jelölő szélességének százalékában kifejezve. Használjon értékeket **0-500**, beleértve: `0` eltávolítja a rést, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélység esetén a rés növelése a jelölőket vékonyabbá teszi a mélységi tengelyen.

A csoportot a [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el. A beállítás az adott csoport minden sorozatára vonatkozik, nem csak arra, amelyen keresztül elérte. A [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) visszaadja a mélységi rést, és tükrözi a szülőcsoport beállítását.

Ez a beállítás 3D oszlop- és sávdiagramokra, beleértve a henger-, kúp- és piramisvariánsokat, valamint a 3D vonal- és területdiagramokra hat. A megjelenés attól függ, hogy a sorozatok mélységben, kluszterben vagy halmozottan vannak-e rendezve. A különböző sorozatok közti rés tiszta összehasonlításához használja a `ChartType::Column3D` típust a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | A szomszédos sávok vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | A diagram teljes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adat, forgatás, részszélesség és diagrammélység mellett; csak a résmélység változik.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Az alábbi képek bemutatják ugyanazt a réstmélység-beállítást az ekvivalens .NET példában, és a Microsoft PowerPoint segítségével exportálták.

| Rés mélysége: 0% | Rés mélysége: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs rés a sorozatok között a mélységi tengely mentén](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 százalékos rés van a sorozatok között a mélységi tengely mentén](gap_depth_500.png) |

## **A 3D sorozattípus és sávalak megváltoztatása**

Egy csoportos hengerdiagram első sorozata henger alakú sávval kezdődik. A példa kiírja a [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) és a [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) által visszaadott egész értékeket a módosítások előtt és után. A táblázat a megfelelő állandó neveket adja meg.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Változtatás az első sorozaton | Sorozattípus | Sáv alak |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alakra való beállítás szintén megváltoztatja a sorozattípust `ClusteredColumn3D`‑re. Ha a kódja a sorozattípustól függ, hívja meg a [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) metódust a forma megváltoztatása után. A hozzárendelés előtt cache‑elt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot henger, kúp és téglalap alakú oszlopként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ben?**

Az Aspose.Slides támogatja a 3D oszlopdiagram változatokat, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) tagjait az API‑referenciában a telepített verzióhoz.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. Exportálhatja a diagramot képként a [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) vagy a [render the entire slide](/slides/hu/php-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumban. Ez akkor hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot be szeretné ágyazni dokumentumokba, műszerfalakba vagy weboldalakba anélkül, hogy a PowerPointra lenne szükség.

**Mennyire teljesítményhatékony nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsa minimalizáltan a 3D hatásokat, kerüljön el nehéz textúrákat a falakon és a diagramterületen, korlátozza sorozatonként a pontok számát, ahol lehetséges, és rendereljen a célnak megfelelő felbontású és méretű kimenetre, legyen szó képernyőn megjelenítésről vagy nyomtatásról.