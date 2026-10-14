---
title: Kördiagramok testreszabása bemutatókban PHP használatával
linktitle: Kördiagram
type: docs
url: /hu/php-java/pie-chart/
keywords:
- kördiagram
- diagramkezelés
- diagram testreszabása
- diagram beállításai
- diagram beállítások
- ábrázolási beállítások
- szelet színe
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Készítsen és testreszabjon kördiagramokat PHP-ben az Aspose.Slides segítségével. Állítson be másodlagos ábrákat, jelenítse meg az adatcímkéket, és alkalmazzon automatikus szeletszíneket a PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk kördiagramokkal az Aspose.Slides-ben. Megmutatja, hogyan konfiguráljuk a másodlagos diagrambeállításokat a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan engedélyezzük az automatikus szelet-színezést egy szabványos kördiagram esetén.

A példák a diagram testreszabási feladatokra fókuszálnak, mint például diagram hozzáadása egy diára, sorozatok és címkék beállításainak módosítása, az alapértelmezett diagramadatok cseréje egyedi kategóriákra és értékekre, valamint a frissített bemutató mentése.

## **Másodlagos diagram beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for PHP via Java támogatja a másodlagos diagram beállításait a Pie of Pie és Bar of Pie diagramokhoz. Ezek a beállítások a másodlagos diagram méretét és az adatpontok két diagram közötti felosztását szabályozzák.

Az alábbi példa egy Pie of Pie diagramot hoz létre egy új bemutatóban, és az adatpont értékeket címkeként jeleníti meg. A [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) metódus a másodlagos diagram méretét a fő diagram 149%-ára állítja. A [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) százalékos felosztást választ, és a [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) a küszöböt 53%-ra állítja.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Értékek megjelenítése és a másodlagos diagram beállítása.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Kategóriák kiválasztása a másodlagos diagramhoz**

Használj egyedi felosztást, ha bizonyos kategóriákat szeretnél a másodlagos diagramba csoportosítani a százalékos értékeiktől függetlenül. Például egy értékesítési jelentésben az Online és az Events kategóriákat együtt jelenítheted meg, hogy az olvasók össze tudják hasonlítani ezt a két csatornát, még akkor is, ha a teljes eladások 35%-át és 10%-át teszik ki.

Hívd meg a [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) metódust a [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) értékkel, és válaszd ki a pontokat a [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) segítségével. A gyűjtemény [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) metódusa sorozaton belüli nulla alapú indexet fogad; használj [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) metódust egy adatpont objektum hozzáadásához. Ebben a példában az 1-es index az Online-ot választja, a 3-as index pedig az Events-et. A Partners is ideiglenesen hozzá van adva, majd a [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) segítségével kizárásra kerül.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Cserélje le az alapértelmezett adatokat csatornánkénti értékesítésre.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Válassza ki az Online-ot a nulla alapú indexével, az Events-et pedig az adatpont objektummal.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Zárja ki a Partners-t a kiválasztásból anélkül, hogy törölné a forrásadatait.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az Online (35) és az Events (10) külön szeletekként jelenik meg a másodlagos diagramon. Az elsődleges diagramon egy összevont szeletként 45 értékkel, a Retail (40) és a Partners (15) mellett látható. A Partners eltávolítása az egyedi kiválasztásból csak az elsődleges diagramon marad, nem távolítja el a kategóriát vagy az értékét a diagram forrásadataiból.

A következő kép mutatja a PowerPointban mentett bemutatót:

![Pie of Pie diagram Online és Events kategóriákkal a másodlagos diagramon és a kombinált 45 értékkel az elsődleges diagramon](pie_of_pie_custom.png)

## **Automatikus kördiagram szelet színek beállítása**

Az Aspose.Slides for PHP via Java automatikusan különböző színeket rendelhet a kördiagram szeletekhez. Az alábbi példa egy kördiagramot hoz létre középre helyezett címmel, és lecseréli az alapértelmezett adatokat három negyedéves kategóriára és azok értékeire. A [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) metódus 20, 50 és 30 értékeket jeleníti meg címkeként, míg a [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) engedélyezi, hogy minden szelet más színű legyen.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Adjunk középre igazított diagramcímet.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Cserélje le az alapértelmezett adatokat az első munkalap használatával.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Mutassa az értékeket, és rendeljen különböző színeket a szeletekhez.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) egy másodlagos diagramot a kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a [exportálja a diagramot képként](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (például PNG) anélkül, hogy az egész bemutatót exportálnád.