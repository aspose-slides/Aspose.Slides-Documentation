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
- legnagyobb érték
- legkisebb érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for PHP via Java-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet testre szabni a diagram tengelyeket az Aspose.Slides for PHP via Java segítségével. Bemutatja a számított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke és a jelölőjelközök intervallumait, a dátum kategóriákat és formázást, a cím forgását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus skálázást.

## **A diagramok függőleges tengelyének legnagyobb értékeinek lekérése**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot az alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) hívását a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) és a [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) metódusokat a tengelyhatárokhoz, illetve a [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) és a [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) metódusokat a jelölőközök intervallumához. A [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) időegység-skálákat ad vissza, amelyek dátum tengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókba tárolja, majd elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagramadatokban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatcsoportosítás módját; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Ez egy diagramot hoz létre négy sorozattal és három kategóriával.

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

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) metódust egy kategória vagy érték tengely megfordításához. Például egy vízszintes oszlopdiagram megjelenítheti a projekt fázisait fentről lefele ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása megváltoztatja a rajzolási irányt; nem rendez vagy átrendezi a munkafüzet adatait. Ezzel szemben a [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) a sorozatok és kategóriák szerepét cseréli fel.

Az alábbi példa egy vízszintes oszlopdiagramot hoz létre három fázissal és egy sorozattal. Három diát ment el: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    // 2. dia: az első kategóriát a tetején jeleníti meg.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // A vízszintes értéktengelyt alul tartja.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 3. dia: csak a vízszintes numerikus skálát fordítja meg.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A tengely megfordítása a merőleges tengelyt is az ábra ellenkező oldalára helyezheti. A [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) vezérli, hogy a másik tengely hol metszze a konfigurálandó tengelyt. A 2. dián a `CrossesType::Maximum` értékkel hívva a megfordított kategória tengelyen, a vízszintes érték tengely alul marad. Egy konkrét metszéspont meghatározásához használja a [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metódust. Ellenőrizze a metszési beállításokat irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni metszésponttal. A `setPlotOrderReversed` hívása `false` értékkel visszaállítja a normál rajzolási irányt; a metszési beállítások önállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes oszlopdiagram normál kategória‑ és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes oszlopdiagram a kategóriákkal felülről lefelé megjelenítve](axis-order-categories-reversed.png) | ![Vízszintes oszlopdiagram megfordított értéktengellyel, nullával a jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé futnak; az értékek balról jobbra növekednek. | A Tervezés, Fejlesztés és Tesztelés fentről lefele fut. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra növekednek. A kategória tengely a jobb oldalon, a nullánál metszi a függőleges tengelyt. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, majd elmenti a függőleges tengely elrejtésével.

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

## **A vízszintes tengely letiltása vonaldiagramoknál**

Hívja meg a [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, majd elmenti a vízszintes tengely elrejtésével.

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

## **Diagramrácsvonalak megjelenítése vagy elrejtése**

Hívja meg a [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) és a [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) metódusokat, hogy ellenőrizze, mely rácsvonalakat jeleníti meg egy tengely. A kisebb rácsvonalak megjelenítéséhez használja a [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) metódust, és állítsa a vonal kitöltését szilárd, látható színre. A rejtéshez állítsa a kitöltést a [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) értékre. A fő rácsvonalak kitöltésének módosításához használja a [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) metódust ugyanígy. A kitöltés módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a klaszteres oszlopdiagramnak a függőleges tengelye kezdetben csak a fő rácsvonalakat jeleníti meg. A példa sötét narancssárga színnel jeleníti meg a kisebb rácsvonalakat, majd újra elrejti őket, mielőtt elmenti a prezentációt. Minden lépésnél kiírja a rácsvonalak láthatóságát.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak rejtve |
| --- | --- |
| ![Narancssárga kisebb rácsvonalak a fő rácsvonalak között a függőleges tengelyen](minor-gridlines-enabled.png) | ![Ugyanaz a oszlopdiagram csak a fő rácsvonalakkal látható](minor-gridlines-hidden.png) |

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metódust dátum vagy szöveg kategória tengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dián az első alakzat, a kategóriacellák pedig numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) `false`, a [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) `TimeUnitType::Months` hívása egy hónapos intervallummal helyezi el a fő jelölőket.

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

### **A kategória tengely típusának meghatározása adat alapján**

A kategóriák feltöltése után hívja meg a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) metódust, majd olvassa ki a [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) értékét a kiválasztás ellenőrzéséhez. Ez akkor hasznos, ha ugyanaz a diagram vagy szöveges címkéket, vagy numerikus dátumértékeket kap. A metódus a híváskor határozza meg a típust; nem aktivál tartós módot, amely későbbi adatváltozásokat vizsgálna újra. Hívja meg újra a kategóriák cseréje után.

A következő példa egy szöveges kategóriákkal rendelkező diagramot hoz létre, és `true` értéket nyomtat, amikor a kiválasztott típus `CategoryAxisType::Text`. Ezután a kategória cellaértékeket dátumokra cseréli, újra meghívja a metódust, és szintén `true`‑t nyomtat, amikor a kiválasztott típus `CategoryAxisType::Date`. A dátumok numerikus OLE Automation értékekként vannak tárolva, amely a 1899. december 30. óta eltelt napok számát adja meg, nem dátum karakterláncként. A [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) meghatározza, hogyan jelennek meg ezek az értékek; nem konvertál szöveget numerikus dátumokká. További információkért a kategória cellákról lásd a [Chart Workbook](/slides/hu/php-java/chart-workbook/) oldalt.

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, mint ebben a példában. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén hívja meg kifejezetten a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metódust a kívánt jelentésnek megfelelően. Csak a numerikus értékek önmagukban nem bizonyítják, hogy a kategóriák dátumokat jelentenek.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategória tengely címkeintervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metódust `false` értékkel, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metódussal. Szöveges kategóriák esetén, normál sorrendben, a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenő címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a többi két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság az elérhető hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőjeleknek külön vezérlése van. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metódust `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) metódust az intervallum beállításához. Például az `1` érték minden kategória intervallumnál egy jelölőjelet helyez el, míg a címkék csak minden harmadik kategóriánál jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) metódust látható stílussal, hogy lássa az eredményt. Bármelyik automatikus távolság-beállítót `true`‑ra állítva a diagram újra kiválasztja az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címkeintervallum független jelölőjelekkel, és visszaállított automatikus távolság. A két másolat megőrzi az eredeti diagramadatokat. Bemutató bemenet nem szükséges. A vízszintes címkeszöveg könnyen láthatóvá teszi a sűrűségkülönbséget.

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

    // 2. dia: minden harmadik címkét mutassa, de minden kategóriához tartson meg egy jelölőjelet.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 3. dia: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba tördelődik. Az automatikus eredmény a diagram méretétől, betűtípusaiktól és a renderelőtől függően változhat.

![Automatikus kategória címke távolság mind a 24 oszlop láthatóvá tétele esetén](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölőjelek minden kategória intervallumnál megmaradnak. Mind a 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális kategória címke intervallum háromra állítva, mind a 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑számláló intervallumot szöveges kategória tengely esetén, például egy oszlop, vonal, terület vagy oszlopdiagram kategória tengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Víszintes oszlopdiagram esetén a kategória tengely függőleges, ezért a [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) által visszaadott tengelyen alkalmazza ezeket a beállításokat. A jelölőjelek távolsága a sorozat tengelyre is vonatkozik olyan diagramoknál, amelyek rendelkeznek ilyennel.

Ne használja a kategória címke intervallumot az érték tengely numerikus skálájának beállítására. Érték tengelyen a [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) határozza meg az értékek közti különbséget: például a `10` fő egység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely a nullánál kezdődik. A `3` kategória címke intervallum helyette kategória pozíciókat számol, függetlenül azok adatértékétől. Szórt és buborék diagramok érték tengelyeket használnak, nem szöveges kategória tengelyt. Dátum tengely esetén használjon időalapú fő egységeket és skálákat, ahogyan a [Kategória tengely módosítása](#change-a-category-axis) részben le van írva.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagramadatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metódust `CategoryAxisType::Date` értékkel, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` értékével, valamint a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metódusban, hogy a kategória címkék négyjegyű évet jelenítsenek meg a cella formázásától függetlenül.

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

## **A diagram tengelycím forgatási szögének beállítása**

Hívja meg a [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metódust `true` értékkel a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím forgatásához. A szög fokokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címe 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy érték tengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) metódust annak szabályozására, hogy az érték tengely a kategória tengelyt a kategóriák között vagy a kategória jelölőpontoknál metszze. Ez a beállítás a kategória tengelyekre vonatkozik. A példa `true` értékkel állítja be a vízszintes kategória tengelyen egy oszlopdiagram esetén, majd elmenti az eredményt.

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

## **Megjelenítési egység beállítása diagram érték tengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) metódust az érték tengely címkéinek méretezésére anélkül, hogy az underlying adatot megváltoztatná. A [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` értéke esetén a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliók megjelenítési egységét alkalmazza.

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

## **Logaritmikus érték tengely konfigurálása**

A logaritmikus érték tengely akkor hasznos, ha a pozitív értékek több nagyságrendi rendet fednek le. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel a nullához helyezkednek el. A logaritmikus skála megkönnyíti a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) metódust `true` értékkel az érték tengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) metódust az alap kiválasztásához. Ez csak a meglévő értékek megjelenítését változtatja; nem változtatja az adatot vagy ad logaritmikus trendvonalat hozzá. A trendvonal egy adatokra illesztett kapcsolat, és külön funkció.

### **Az érték tengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az érték tengely a [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) metódussal érhető el. Víszintes oszlopdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) metódus adja vissza. Szórt és buborék diagramok két érték tengellyel rendelkeznek, ezért az X értékekhez a vízszintes, az Y értékekhez a függőleges tengelyt, vagy mindkettőt kell kiválasztani. Ne alkalmazzon logaritmikus skálázást kategória tengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén az alap lehet `2`‑tól `1000`‑ig, beleértve a tört értékeket is, például `2.5`. A `10` alap esetén a 10, 100, 1 000 és 10 000 hatványok egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérés-számmal az első dián, majd klónozza azt, és a második dián engedélyezi a tízes alapú logaritmikus érték tengelyt. Mindkét dia ugyanazt az adatot tartja meg.

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

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérés-számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban öt kérés-számmal lineáris érték tengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak a előzőnél tízszer nagyobb kérésszámot tartalmaz, ezért a pontok egy egyenesen emelkedő vonalat alkotnak a tízes alapú skálán. A tengelycímkék továbbra is az eredeti kérés-számokat mutatják.

![Ugyanaz az öt kérés-szám PowerPointban tízes alapú logaritmikus érték tengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket képes megjeleníteni. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha a kizárásuk megfelelő az elemzéshez, magyarázza el az elhagyást. Ne cserélje őket titokban kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum a logaritmikus tengelyen is pozitívnak kell lennie.

## **GYIK**

**Hogyan állíthatom be az értéket, ahol egy tengely a másikat keresztezi (tengelykereszteződés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metódust a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metódust. Ezek a beállítások lehetővé teszik a tengelykereszt elhelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) használatával: `Low`, `High`, `NextTo` vagy `None`. A jelölőjelek magának vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) vagy a [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) metódusokat; ezek különállóak a címke pozicionálásától.