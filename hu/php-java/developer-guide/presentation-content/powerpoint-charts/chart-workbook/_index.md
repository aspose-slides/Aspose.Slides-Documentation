---
title: Diagram munkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
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
description: "Fedezze fel az Aspose.Slides for PHP via Java megoldást: könnyedén kezelheti a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk leírja, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides‑ben. Bemutatja, hogyan olvassuk és írjuk a diagram adatokat munkafüzet‑adatfolyamok segítségével, hogyan használjuk a munkafüzet cellákat diagram adatcímkeként, hogyan érjük el a munkalap‑gyűjteményeket, és hogyan határozzuk meg az adatforrás típusát a diagram értékekhez.

A cikk kitér a külső munkafüzetek diagram adatforrásként történő használatára is. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolódó külső munkafüzet útvonalát, valamint hogyan szerkeszthetjük a diagram adatokat, amikor a munkafüzet elérhető.

A hiányzó adatokat tartalmazó munkafüzet‑cellákhoz lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/php-java/chart-series/) cikket, amely a különbséget mutatja az üres cella és a nulla között, valamint egy vonaldiagramot a rendelkezésre álló megjelenítési módok összehasonlítására.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust, hogy szabályozza, a diagram a rejtett munkalap‑sorok és -oszlopok adatait is felhasználja‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és rejtett cellákat egyaránt fel kívánja venni. Ez a beállítás a diagram ábrázolását vezérli; nem rejti el vagy jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

A [mintaprezentáció](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás‑cellák eléréséhez használja a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) metódust, és olvassa a [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) értékét a rejtett állapot vizsgálatához. Ez a metódus a rejtett állapotot jelzi anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban `false`, `true`, és `true` értékeket ír ki.

E példához a diagram adatainak frissítése a beállítás módosítása után szükséges: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) metódussal, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) metódussal. Az összes cella belefoglalásakor használja még a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző módosítása nem elegendő a minta gyorsítótárazott diagram adatainak és kategória‑címkéinek frissítéséhez.

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

            // Frissítse a diagram adatokat a beágyazott munkafüzetről.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
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

A példa két változatban menti a prezentációt: egyben csak a látható Kiskereskedelem értékek (10 és 20) szerepelnek, a másikban mind a hat érték. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 Január és Március számára.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és Nagykereskedelmi értékek Január, Február és Március számára.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) metódus szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatot. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/php-java/chart-series/#control-the-display-of-empty-cells) cikket példáért.

## **Diagram adatcímének lekérése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) metódus a jelenlegi adatcímkét adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, a dollárjelek pedig abszolút sor‑ és oszlop‑hivatkozást mutatnak.

A metódus a jelenlegi tartományt olvassa anélkül, hogy megváltoztatná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, kivételt dob. További információkért tekintse meg a [ChartData API Referenciát](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Ez a példa megnyit egy prezentációt, és közvetlenül minden dián ellenőrzi az alakzatokat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép.

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

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for PHP via Java a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat kínálja, amelyek lehetővé teszik a diagram adat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés**, hogy a diagram adatokat ugyanúgy kell felépíteni, vagy szerkezetüknek hasonlónak kell lennie a forráshoz.

Ez a példa egy prezentációt használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, és visszaírja ugyanazt a munkafüzetet. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez a nem‑összhang a [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, ha a sorozat‑ vagy kategória‑gyűjtemények nem egyeznek. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramhoz. Ez a példa egy diagramot használ, amely az első dia első alakzata. A megjegyzés azt jelöli, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

        // Módosítsa a munkafüzet bájtjait itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a régi adat‑referenciákat, mielőtt a munkafüzet visszaírásra kerül. Az új munkafüzethez szükséges sorozat‑ és kategória‑leképezéseket építse újra, mielőtt a diagramot használja.

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

Használja a [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) metódust, hogy szabályozza, a numerikus értékek hogyan jelenjenek meg egy diagram beágyazott munkafüzetében. Például egy jelentésnek a konverziós arányt százalékban, négy tizedesjeggyel, a koefficienst pedig öt tizedesjeggyel kell megjelenítenie. Tartsa mindkét értéket számmá, hogy számításokhoz és diagramrajzoláshoz továbbra is elérhetők legyenek.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; a tárolt szám nem lesz `12.5`‑re cserélve. Hasonlóképpen a `0.00000` a `0.1234567` értéket `0.12346`‑ként jeleníti meg, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátumot használja.

Az alábbi példa létrehoz egy oszlopdiagramot, és a [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével eléri a cellákat. Az 0‑s indexű munkalapon a B2 a konverziós arányt, a C2 a koefficienst tartalmazza. Mindkét cella a diagram értékeit szolgáltatja. A példa továbbá engedélyezi a forrásformátumhoz linkelt értékcímkéket.

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

A munkafüzet‑cellák formátumai különböznek a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a forrás számformátumát követi a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true`‑nak köszönhetően. A prezentáció mentése és újbóli megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogyan alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) `0.00` értékre állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`‑ra van állítva.

Egy adatcímke önálló formázásához állítsa a forrás‑link zászlót `false`‑ra, és rendelje hozzá a formátumot a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) segítségével. Ez nem változtatja meg a munkafüzet cellájának formátumát. Például egy `0.00` önálló címkeformátum az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑ot mutat. Lásd a [Diagram adatcímkék](/slides/hu/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) cikket a közvetlen címkeformázáshoz.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint egy függetlenül formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkének**

A munkafüzet cellák szövegét felhasználhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal az első dia első alakzatához egy meglévő prezentációban. Az 0‑s indexű munkalap A10:A12 tartományát használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és elmenti a frissített prezentációt.

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

A [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetében lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

## **Adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első nevet egy karakterlánc‑literál adja; a másodikat a 0‑s indexű munkalap C1 cellája biztosítja. A [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) felsorolás adja meg a forrást minden névhez. A példa a frissített sorozatnevekkel menti a prezentációt.

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amelyet egyes diagramokba be lehet ágyazni. A [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusával és a [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) felsorolással felismerhető a nem támogatott formátum, és kihagyhatók az ilyen diagramok. Ez a példa a meglévő prezentáció első dia alakzatait vizsgálja, kihagyja a nem diagram alakzatokat, és minden .xlsb beágyazott munkafüzettel rendelkező diagramra diagnosztikai üzenetet ír ki.

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

        // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
    }
} finally {
    $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat, hogy egy beágyazott diagram munkafüzetet exportáljon egy fájlba, és a diagramot erre a külső munkafüzetre hivatkoztassa.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után állítja be a külső munkafüzetet diagram adatforrásként, majd menti a hivatkozott prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet elérési útja is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet közvetlenül szerkeszteni, továbbra is felhasználhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapján a B1‑ben egy sorozatnév, az A2:A4‑ben kategórianév, a B2:B4‑ben numerikus értékek szerepelnek. A példa kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. A hivatkozott diagrammal menti a prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adatai nem kerülnek be‑ vagy frissítésre a célmunkafüzetből, így a munkafüzet nem is elérhető.
* Ha `updateChartData` **true**, a diagram adatai frissülnek a célmunkafüzetből.

Az alábbi példa egy helyőrző URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem‑elérhető munkafüzet betöltődne.

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

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

A diagramhoz kapcsolódó munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián található első alakzatot vizsgálja egy hivatkozott külső munkafüzettel rendelkező prezentációban. Ha a diagram külső munkafüzethez kapcsolódik, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét a konzolra, majd ment egy másolatot a prezentációból.

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

### **Diagram adatainak szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dia első alakzata, és egy elérhető külső munkafüzethez kapcsolódik. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd elmenti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a hivatkozott külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides a prezentációban gyorsítótárazott adatokból rekonstruálhatja a diagram munkafüzetét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) metódust, és állítsa a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) értékét **true**‑ra, mielőtt megnyitná a prezentációt.

Az alábbi PHP példa helyreállítja a munkafüzet adatokat egy diagramhoz, amely az első dia első alakzata, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

        // Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzeten végzett módosításokat a prezentáció legutóbbi frissítése óta.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik-e?**

Igen. A diagram rendelkezik egy [adatforrás típusával](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [útvonallal egy külső munkafüzethez](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás külső munkafüzet, akkor a teljes útvonal lekérdezésével ellenőrizhető, hogy külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezésekor a hivatkozás frissítése szükségessé válhat.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Ha az eredetit változatlanul kell hagyni, használjon másolatot a munkafüzetről.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozás létrehozásakor. Általános megközelítés, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.