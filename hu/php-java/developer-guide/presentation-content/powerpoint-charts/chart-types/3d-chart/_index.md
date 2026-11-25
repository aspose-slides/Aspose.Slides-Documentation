---
title: 3D diagramok testreszabása prezentációkban PHP használatával
linktitle: 3D diagram
type: docs
url: /hu/php-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készíts 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével. Állítsd be a forgást, a magasságarányokat, a diagram mélységét és a sorozatok közti távolságot PHP példákkal."
---
## **Áttekintés**

Aspose.Slides for PHP via Java lehetővé teszi, hogy testreszabd egy 3D diagram nézetét a [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorok közti távolság, majd hogyan menthető a prezentáció PPTX formátumban.

## **Állítsd be a forgást és a mélységet egy 3D diagramon**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) és a [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) segítségével egy halmozott 3D oszlopdiagramot ad hozzá az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, a `0` oszlop pedig a kategóriacímkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) és a [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) metódusok a diagram forgását 40 illetve 270 fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) beállítja a mélységet a szélesség 150%-ára, míg a [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) engedélyezi a derékszögű tengelyeket a perspektíva helyett. Az eredményül kapott prezentáció a kitöltött diagramot ezeket a 3D nézetbeállításokat tartalmazza.

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

## **Alkalmazz képkitöltést egy 3D diagram felületére**

A 3D diagram [oldalfal](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [háttérfal](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/), és [padló](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) felületét külön-külön töltheted ki. Állítsd be a felület [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) értékét `Picture`-re, és rendelj hozzá egy képet. Állítsd be a [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) és a felület [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) értékét is `Stretch`-re, hogy a kép egy példánya illeszkedjen a felülethez.

Mentsd el az [arrow.png](arrow.png) fájlt a PHP szkript mellé. A példa elforgatja a diagramot és megnöveli a függőleges tengely maximális értékét, hogy a padló látható legyen az oszlopok között. Ezután kétszer lemásolja a diát, és minden dián más felületre alkalmazza a nyilat. A három diagram ugyanazt az adatot, nézeti szöget és hátteret tartja meg.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Háttérfal | Padló |
| --- | --- | --- |
| ![Nyíl, amely a diagramra mutat az oldalfalon](side-wall.png) | ![Nyíl, amely jobbra mutat a háttérfalon](back-wall.png) | ![Nyíl, amely jobbra mutat a padlón az oszlopok között](floor.png) |

## **Állítsd be a magasság arányait egy 3D diagramnál**

Használd a [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) metódust, hogy a 3D diagram magasságát a szélességének százalékában állítsd be. Ez megváltoztatja a 3D jelenet arányait a diagram objektum átméretezése nélkül a dián.

Az alábbi példa létrehoz egy [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) diagramot az alapértelmezett adatokkal: három sorozattal és négy kategóriával. Három prezentációt ment 50%, 100% és 200% magasság arányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, forgatás, mélység, sorozatok közti távolság és formázás minden három fájlban azonos; csak a magasság százaléka változik.

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

Az alábbi képek bemutatják ugyanazt a magasságbeállítást a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet a ugyanabban a diagram objektumban. A PowerPoint esetleg módosíthatja a tengelyjelölések intervallumát és a feliratok elhelyezését, hogy a jelenethez illeszkedjen.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | A 3D jelenet magassága a szélességének százalékában. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | A diagram objektum magassága a dián pontban. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | A 3D jelenet mélysége a szélességének százalékában. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasság beállítás a 3D oszlop- és oszlopdiagramokat érinti, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, torta- és felületdiagramokat. A fenti összehasonlítás a vérifikált `Column3D` típust használja. A beállítás nem változtatja meg a 2D `ClusteredColumn` diagram vagy a `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztály tagjai. Más diagram megjelenítési beállításokért lásd a [Diagram formázása](/slides/hu/php-java/chart-formatting/) oldalt.

## **Állítsd be a sorozatok közti hézagot**

Használd a [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) metódust a 3D diagram mélységi tengelyén lévő adat sorozatok közti távolság vezérléséhez, a jelölő szélességének százalékában kifejezve. Használj értékeket **0 és 500** között, beleértve: a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Fix diagrammélységnél a hézag növelése a jelölőket vékonyabbá teszi a mélységi tengelyen.

A csoporthoz a [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével férhetsz hozzá. A beállítás az adott csoport minden sorozatára vonatkozik, nem csak arra, amelyen keresztül elérted. A [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) visszaadja a mélységi hézagot és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop- és oszlopdiagramokat érinti, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal- és területdiagramokat. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy halmozva vannak-e elrendezve. A különálló sorozatok közti hézagok tiszta összehasonlításához használd a `ChartType::Column3D` típust a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | A sorozatok közti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | A szomszédos oszlop- vagy oszlopcsoportok közti távolság a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | A diagram teljes mélysége a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két prezentációt ment, amelyek adatai, forgatása, hézag szélessége és diagrammélysége azonos; csak a hézag mélysége változik.

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

Az alábbi képek bemutatják ugyanazt a hézagmélység beállítást a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták.

| Hézag mélység: 0% | Hézag mélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 százalékos hézagja van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **Módosítsd a 3D sorozat típusát és az oszlop alakját**

Egy csoportosított henger diagram esetén az első sorozat hengeres oszlop alakjával kezdődik. A példa kiírja a [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) és a [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) által visszaadott egész értékeket minden módosítás előtt és után. A táblázat a megfelelő állandó neveket mutatja.

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

| Változás az első sorozatra | Sorozat típusa | Bar alak |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása a sorozat típusát is `ClusteredColumn3D`-re módosítja. Ha a kódod a sorozat típusán alapuló elágazást tartalmaz, hívd meg a [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) metódust a forma módosítása után. A hozzárendelés előtt tárolt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely az első sorozatot hengerként, kúpként és téglalap alakú oszlopként mutatja balról jobbra](series-shapes.png)

## **Gyakran Ismételt Kérdések**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész lista számára ellenőrizd a [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) tagjait a telepített verziód API hivatkozásában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatod képként a [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) vagy a [az egész dia renderelése](/slides/hu/php-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumba. Ez akkor hasznos, ha raszteres előnézetre van szükséged, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretnéd beágyazni anélkül, hogy a PowerPointra lenne szükség.

**Mennyire hatékony a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsd minimálisra a 3D hatásokat, kerüld a nehéz textúrákat a falakon és a diagramterületeken, korlátozd a sorozatonkénti adatpontok számát, amennyiben lehetséges, és renderelj megfelelő méretű (felbontású és dimenziós) kimenetre, hogy megfeleljen a célkijelző vagy nyomtatási igényeknek.