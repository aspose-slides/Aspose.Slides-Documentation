---
title: Diagrammunkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadatok
- munkafüzetcella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for PHP via Java-t: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagramkönyvtárakkal dolgozni az Aspose.Slides-ban. Megmutatja, hogyan kell beolvasni és írni a diagramadatokat könyvtár adatfolyamokon keresztül, a munkafüzet cellákat diagramadatcímkékként használni, elérni a munkalapgyűjteményeket, és megadni az adatforrás típusát a diagramértékekhez.

A cikk továbbá tárgyalja a külső munkafüzetek diagramadatforrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet rendelkezésre áll.

Hiányzó adatot képviselő munkafüzetcellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/php-java/chart-series/) cikket, ahol megtudhatja a különbséget az üres cella és a nulla között, valamint egy vonaldiagram-összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) elemet annak szabályozására, hogy a diagram a rejtett munkalap sorokból és oszlopokból származó adatokat is ábrázolja-e. Állítsa `true`-ra, ha csak a látható cellákat kívánja ábrázolni, vagy `false`-ra, ha a látható és a rejtett cellákat is bele szeretné foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorokat vagy oszlopokat.

A [példa előadás](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első dián az első alakzat. A beágyazott munkalap, `Sheet1`, a következő forrásintervallumot tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik még mindig tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákhoz a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével férhet hozzá, és a [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) metódussal ellenőrizheti a rejtettségi állapotukat. Ez a metódus megjeleníti a rejtettségi állapotot anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, `true` értékeket ír ki.

Ehhez a példához frissítse a diagramadatokat a kirajzolási beállítás megváltoztatása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) használatával, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) elemet is, hogy helyreállítsa a teljes tartományt, beleértve a rejtett februári kategóriát. A jelző egyszerű módosítása nem elegendő a mintában tárolt diagramadatok és kategóriacímkék frissítéséhez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Frissítsd a diagramadatokat a beágyazott munkafüzetről.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Állítsd vissza a teljes forrásintervallumot, beleértve a rejtett kategóriákat.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A példa két változatban menti a prezentációt: az egyik csak a látható Kiskereskedelem értékeket (10 és 20) tartalmazza, a másik pedig mind a hat értéket. Az alábbi képek illusztrálják a két ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/php-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adatintervallumának lekérése**

A meglévő prezentációban a munkafüzet adatainak frissítése előtt ellenőrizze a forrásintervallumokat, hogy meghatározza, mely munkalapcellákat használja a diagram. A [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) metódus visszaadja a jelenlegi adatintervallumot munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli (beleértve). A dollárjelek abszolút sor‑ és oszlopreferenciákat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy a munkafüzetet. Ha a diagram nem használ munkafüzetet adatforrásként, kivételt dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül a formákat ellenőrzi, hogy diagramok vannak‑e. Kiírja minden diagram nevét és forrásintervallumát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra tovább lép.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Diagramadatok beolvasása és írása munkafüzettel**

Az Aspose.Slides for PHP via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyekkel be‑ és kiolvashatók a diagramadatokat tartalmazó munkafüzetek (amelyek az Aspose.Cells‑el szerkesztett adatokat tartalmazzák). **Note** hogy a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezetűeknek kell lenniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, kitörli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megőrzi az eredeti sorozat‑ és kategóriagyűjteményeket. Ez az eltérés a [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, amely index‑túl‑hatókörű hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramra. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelöli, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Módosítsd a munkafüzet bájtjait itt, például az Aspose.Cells használatával.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A gyűjtemények törlése eltávolítja a régi adatreferenciákat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Egyedi számformátumok beállítása munkafüzetcellákhoz**

Használja a [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) elemet annak szabályozására, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzeteiben. Például egy jelentésben a konverziós arányt százalékosan, négy tizedesjeggyel, a koefficienst pedig öt tizedesjeggyel kell megjeleníteni. Tartsa mindkét értéket numerikus formában, hogy elérhetőek maradjanak a számításokhoz és a diagramábrázoláshoz.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑et `12.5000%`‑ként jeleníti meg; nem helyettesíti a tárolt számot `12.5`‑tel. Hasonlóképpen, a `0.00000` formátum a `0.1234567`‑et `0.12346`‑ként jeleníti meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyedi formátum üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátumot használja.

Az alábbi példa egy oszlopdiagramot hoz létre, és celláihoz a [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével fér hozzá. A 0‑s indexű munkalapon a B2 tartalmazza a konverziós arányt, a C2 a koefficienst. Mindkét cella diagramértékeket szolgáltat. A példa továbbá engedélyezi az értékcímkéket, amelyek a forrásformátumokhoz vannak kapcsolva.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A munkafüzet cellaformátumai különállóak a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellája értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a forrás számformátumát követi, mert a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true`. A prezentáció mentése és újbóli megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább is látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) `0.00` értékkel ad meg, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`.

Az adatcímke önálló formázásához állítsa a forrásra hivatkozó jelzőt `false`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) segítségével. Ez nem módosítja a munkafüzet cellaformátumát. Például egy önálló címkeformátum `0.00` a első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a közvetlen címkeformázáshoz.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek `12.5000%` és `0.12346` értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzetcellát diagramadatcímkeként beállítása**

Szöveget használhat munkafüzetcellákból diagramadatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. A 0‑s indexű munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Munkalapok kezelése**

A [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzeteiben lévő munkalapokhoz. Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Az adatforrás típusának megadása**

A sorozatpont értékeket közvetlenül numerikus literálokként is tárolhatja. Lásd a [Set Series Values Using Numeric Literals](/slides/hu/php-java/chart-series/#set-series-values-using-numeric-literals) oldalt a teljes példáért, amely menti és beolvassa ezeket. A pontértékek adatforrás‑típusa elkülönül a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy alapértelmezett adatokkal rendelkező 3D‑oszlopdiagramot hoz létre, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál; a második a 0‑s indexű munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) felsorolás az egyes nevek forrását választja ki. A példa a frissített sorozatnevekkel menti a prezentációt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nem támogatott beágyazott munkafűzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzetet (.xlsb) formátumot, amely egyes diagramokban beágyazható. A [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) felsorolással együtt használva észlelheti a nem támogatott formátumokat, és kihagyhatja azokat a diagramokat. Ez a példa a meglévő prezentáció első diáján lévő alakzatokat ellenőrzi, a nem‑diagram alakzatokat kihagyja, és minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramhoz diagnosztikai üzenetet ír ki.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatait itt.
    }
} finally {
    $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) elemeket a beágyazott diagram munkafüzete fájlba exportálásához és a diagram külső munkafüzethez való csatolásához.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és exportálja a munkafüzettét. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet diagramadat‑forrásként, majd menti a kapcsolt prezentációt.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódus segítségével külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzettek adatait nem szerkesztheti, továbbra is használhatja ezeket mint külső adatforrást. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá lesz konvertálva.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben tartalmaz egy sorozatnevet, A2:A4‑ben kategórianéveket, B2:B4‑ben numerikus értékeket. A példa egy kördiagramot hoz létre, csatolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) segítségével az A1:B4‑et egy sorozatra és három kategóriára képezi le. A diagramot a kapcsolt prezentációban menti.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A `updateChartData` paraméter a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódusban szabályozza, hogy a munkafüzet be legyen‑töltve.

* Amikor `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a cél‑munkafüzetről, így a munkafüzet hiányozhat.
* Amikor `updateChartData` **true**, a diagramadatok frissülnek a cél‑munkafüzetről.

Az alábbi példa egy helyőrző URL‑t ad meg, a `updateChartData` **false**‑ra állítva. Megőrzi a kördiagram alapértelmezett adatait, és a prezentációt a nem‑betöltött munkafüzet nélkül menti.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Diagram külső adatforrás‑munkafüzet‑útvonalának lekérése**

Annak meghatározásához, hogy melyik munkafüzet van a diagramhoz csatlakoztatva, ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa a prezentáció első diájának első alakzatát vizsgálja, amely egy külső munkafüzettel van összekapcsolva. Ha ez egy külső munkafüzethez kötött diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét írja ki a konzolra, majd ment egy másolatot a prezentációról.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Diagramadatok szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez van csatlakoztatva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, majd menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX‑fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Munkafüzet helyreállítása a diagram‑gyorsítótárból**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides rekonstruálhatja a diagram munkafüzettét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) metódust, és a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) elemet **true**‑ra állítsa, mielőtt megnyitná a prezentációt.

Az alábbi PHP‑példa helyreállítja a munkafűzet‑adatokat egy diagramra, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével érheti el:

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) attribútuma; ha a forrás egy külső munkafüzet, a teljes útvonalat beolvashatja, hogy megbizonyosodjon arról, valóban külső fájlt használ.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonallá konvertálódik. A prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatok munkafüzetet hálózati erőforrásokban/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredetit változatlanul kell hagyni, használjon másolatot a munkafüzetről.

**Mit tegyek, ha a külső fájl jelszóval van védve?**

Az Aspose.Slides nem fogad el jelszót a csatlakoztatáskor. Egy gyakori megoldás, hogy a védelmet előzetesen eltávolítja, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzettel?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.