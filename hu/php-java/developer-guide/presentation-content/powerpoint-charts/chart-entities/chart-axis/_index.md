---
title: Diagram tengelyek testreszabása prezentációkban PHP használatával
linktitle: Diagram tengely
type: docs
url: /hu/php-java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for PHP via Java-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és visualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeket az Aspose.Slides for PHP via Java segítségével. Tárgyalja a számított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke- és jelölőközök intervallumait, a dátumkategóriákat és formázást, a cím forgatását, a tengely pozicionálását, a megjelenítési egységeket és a logaritmikus skálázást.

## **A függőleges tengely maximális értékeinek lekérése a diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) metódust a számított tengelyértékek beolvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) értékeket a tengely határértékekhez, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) értékeket a jelölőközökhez. A [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) időegység skálákat adnak, amelyek a dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba menti, és elmenti a diagramot.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adatában. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává alakul. Ez megváltoztatja az adatok csoportosításának módját; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metódust használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományra kössön, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatos és három kategóriás diagramot ment el.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **A tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) metódust egy kategória- vagy értéktengely megfordításához. Például egy vízszintes sávdiagram felülről lefelé jelenítheti meg a projekt szakaszait ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása megváltoztatja a rajzolási irányt; nem rendez vagy átrendezi a munkafüzet adatokat. Ezzel szemben a [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) felcseréli a sorozatok és kategóriák szerepét.

Az alábbi példa egy vízszintes sávdiagramot hoz létre három szakasz és egy sorozat felhasználásával. A prezentáció három diát tartalmaz: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // 2. dia: jelenítse meg az első kategóriát felül.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Tartsa a vízszintes értéktengelyt alul.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 3. dia: csak a vízszintes numerikus skálát fordítsa meg.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram ellenkező oldalára. A [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) határozza meg, hogy a másik tengely hol metszi a beállított tengelyt. A 2. dián a `CrossesType::Maximum` értékkel a megfordított kategóriatengelyen a vízszintes értéktengely alul marad. Egy adott metszéspont meghatározásához használja a [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metódust. Ellenőrizze a metszés beállításait az irányváltáskor, különösen ha a diagram már egyedi metszésponttal rendelkezik. A `setPlotOrderReversed` hívása `false` értékkel visszaállítja a normál rajzolási irányt; a metszési beállítások külön kezelendők.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes sávdiagram normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel és nullával jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé futnak; az értékek balról jobbra növekednek. | A tervezés, fejlesztés és tesztelés felülről lefelé fut. Az értékek és a munkafüzet sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra növekednek. A kategóriatengely a jobboldali nullánál metsződik. |

## **A függőleges tengely letiltása vonaldiagramok esetén**

Hívja meg a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a függőleges tengely elrejtése után menti el.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **A vízszintes tengely letiltása vonaldiagramok esetén**

Hívja meg a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a vízszintes tengely elrejtése után menti el.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metódust dátum vagy szöveges kategória tengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dia első alakja, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType::Months` beállítása egyhónapos fő jelölőket helyez el.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategória tengely címkeintervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metódust `false` értékkel, majd adja át a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metódusnak. Szöveges kategóriák normál sorrendjében a számozás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, két címke marad rejtve a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

Az jelölőjeleknek külön vezérlése van. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metódust `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) metódust az intervallum beállításához. Például a `1` minden kategória intervallumban egy jelölőjelet hagy, míg a címkék csak minden harmadik kategóriánál jelennek meg. A [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) látható stílusával láthatóvá teheti az eredményt. Az automatikus beállítót `true`-ra állítva a diagram újra kiválasztja az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke távolság független jelölőjelekkel, és visszaállított automatikus távolság. A két másolat megtartja az eredeti diagram adatokat. Bemeneti prezentáció nem szükséges. A vízszintes címkék szövege megkönnyíti a sűrűség észlelését.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // 2. dia: jelenítse meg minden harmadik címkét, de tartsa meg a jelölőjelet minden kategóriához.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 3. dia: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatikus térköz (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, a betűtípusoktól és a renderertől függően változhat.

![Automatikus kategória címke távolság, az összes 24 oszlop látható](category-axis-automatic.png)

**Kézi térköz (2. dia):** Minden harmadik címke egy sorban jelenik meg, míg a jelölőjelek minden kategória intervallumban maradnak. Az összes 24 oszlop, beleértve a címkék nélküli oszlopokat is, látható marad ugyanazzal az értékkel. A 3. dia visszaállítja a fent bemutatott automatikus megjelenést.

![Kézi háromas kategória címke intervallum, az összes 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategóriaszám-intervallumot szöveges kategória tengelyhez, például oszlop, vonal, terület vagy sáv diagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyre. Jelölőjelek távolsága egy sorozat tengelyre is vonatkozik azokban a diagramokban, amelyek ilyen tengelyt tartalmaznak.

Ne használja a kategória címke távolságát az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) a játékos egységkülönbséget határozza meg: például a `10` fő egység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely nulláról indul. A `3` kategória címke intervallum ezzel szemben a kategória pozíciókat számolja, függetlenül az adatértékektől. Szórt és buborék diagramok értéktengelyeket használnak, nem szöveges kategória tengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Kategória tengely módosítása](#change-a-category-axis) részben le van írva.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagram adatot négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként tárolódnak az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként számítva. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metódust `CategoryAxisType::Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) metódust `false` értékkel, és adja át a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metódusnak, hogy a kategória címkék négy számjegyű évet jelenítsenek meg a cella formázásától függetlenül.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tengelycím forgatási szögének beállítása**

Hívja meg a [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek értéktengely címe 90 fokban van elforgatva.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) metódust annak szabályozásához, hogy az értéktengely a kategóriatengely közötti kategóriák vagy a kategória jelölőjelek között metsze-e. Ez a beállítás a kategóriatengelyekre vonatkozik. A példa a vízszintes kategóriatengelyen `true` értékkel állítja be, egy oszlopdiagramon, és elmenti az eredményt.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) metódust a címkék skálázásához egy értéktengelyen anélkül, hogy az alapadatok változnának. A [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a millió egységet alkalmazza a függőleges tengelyén.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Logaritmikus értéktengely beállítása**

Egy logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést kaphat. Lineáris skálán a kisebb értékek közel jelennek meg a nullához. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányokat, nem egyenlő különbségeket jelentenek.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) metódust `true` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem változtatja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal az adatokban illeszkedő kapcsolatot ábrázolja, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonall vagy oszlop diagram esetén az értéktengelyt a [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) metódus adja vissza. Vízszintes sávdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) adja vissza. Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza a vízszintes tengelyt az X értékekhez, a függőleges tengelyt a Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategóriatengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén az `2`‑tól `1000`‑ig terjedő értéket használhat, a tört alapok, például a `2.5` is támogatott. A `10` alappal a sorozatos hatványok, mint 10, 100, 1 000 és 10 000 egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az öt kérésszámmal az első dián, majd lemásolja azt, és a második dián a 10‑es alapú logaritmikus értéktengelyt engedélyezi. Mindkét dia azonos adatot tartalmaz.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Tartsa az első diát lineárisnak, és csak a másolat értéktengelyének skáláját változtassa meg.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérésszámok között. A legnagyobb érték uralja a diagramot, ezért a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérésszámot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak a előzőnél tízszer több kérést kap, ezért a pontok egyenes, emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérésszámokat mutatják.

![Ugyanaz az öt kérésszám PowerPointban, alap-10 logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Egy logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy a negatív értékek jelentősek, tartsa meg a lineáris skálát, vagy jelenítse meg őket külön. Ha a kizárásuk megfelelő az elemzéshez, magyarázza meg az elhagyást. Ne cserélje őket néma módon kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum logaritmikus tengelyen szintén pozitívnak kell lennie.

## **FAQ**

**Hogyan állíthatom be, hogy egy tengely hol metszéssel a másikhoz (tengelymetszés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metódust a metszés viselkedésének kiválasztásához. Numerikus metszéspont megadásához használja a [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelymetszést megfelelő alapvonalra helyezze.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) segítségével: `Low`, `High`, `NextTo` vagy `None`. A jelölőjelek saját beállításához használja a [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) metódusokat; ezek különállóak a címke pozicionálásától.