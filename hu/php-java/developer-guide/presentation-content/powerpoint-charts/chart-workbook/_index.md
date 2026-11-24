---
title: Diagramm munkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagramm munkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagramm munkafüzet
- diagramm adat
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
description: "Fedezze fel az Aspose.Slides for PHP via Java megoldást: könnyedén kezelje a diagramm munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációs adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell dolgozni diagramm munkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan lehet olvasni és írni diagrammadatokat munkafüzetfolyamok segítségével, munkafüzetcellákat használni diagrammadatok címkéiként, elérni a munkalap-gyűjteményeket, és megadni az adatforrás típusát a diagram értékekhez.

Emellett tárgyalja a külső munkafüzetek diagramadat-forrásként való használatát. A példák bemutatják, hogyan kell létrehozni és hozzárendelni egy külső munkafüzetet, hogyan lehet lekérni egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan lehet szerkeszteni a diagramadatokat, ha a munkafüzet elérhető.

A munkafüzetcellák, amelyek hiányzó adatot képviselnek, tekinthetők a [Üres cellák megjelenítésének vezérlése](/slides/hu/php-java/chart-series/) cikkben, ahol megtalálható az üres cella és a nulla közti különbség, valamint egy vonaldiagram‑összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használd a [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust annak szabályozására, hogy a diagram a rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázoljon‑e. Állítsd `true`‑ra, ha csak a látható cellákat szeretnéd ábrázolni, vagy `false`‑ra, ha mind a látható, mind a rejtett cellákat bele akarod venni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz az első dián lévő első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás‑cellák eléréséhez használd a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) metódust, és ellenőrizd a [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) értékét a rejtett állapot megállapításához. Ez a metódus a rejtett állapotot jelzi anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa sorban a `false`, `true` és `true` értékeket írja ki.

Ehhez a példához frissíteni kell a diagramadatokat a megjelenítési beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) segítségével, és töltsd újra a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)‑val. Ha minden cellát beleveszel, használd még a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)‑t a teljes tartomány, beleértve a rejtett februári kategóriát, visszaállításához. A flag egyszerű módosítása önmagában nem elegendő a minta gyorsítótárazott diagramadatai és kategóriacímkéinek frissítéséhez.

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

            // Frissítse a diagram adatát a beágyazott munkafüzetből.
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

A példa két változatban menti a prezentációt: az egyik csak a látható kiskereskedelmi értékekkel (10 és 20), a másik minden hat értékkel. Az alábbi képek szemléltetik a két ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella eltér egy üres cellától. A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) szabályozza, hogyan jelenjenek meg a hiányzó értékek; ez nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/php-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt egy meglévő prezentációban módosítanád a munkafüzet adatait, ellenőrizd a forrás‑tartományokat, hogy megtudd, mely munkalap‑cellákat használja a diagram. A [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) metódus visszaadja a jelenlegi adat‑tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, mindkettő beleértve. A dollárjelek abszolút sor‑ és oszlophivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, kivételt dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) oldalát.

Ez a példa megnyit egy prezentációt, és közvetlenül a diákon lévő alakzatok között keresi a diagramokat. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet ír ki, és folytatja a következő diagrammal.

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

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for PHP via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Aspose.Cells‑vel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diájának első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változattal helyettesítesz, a diagram megőrzi az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem‑egyezés a [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) hibát okozhat index‑túl‑tartomány‑kivétellel. Töröld a meglévő sorozatokat és kategóriákat, mielőtt visszaírnád a frissített munkafüzetet a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése elavult adat‑hivatkozásokat szüntet meg, mielőtt a munkafüzet visszaíródna. Építsd újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használnád.

## **Kategória címkék tárolásának módjának kiválasztása**

A [ChartCategoryCollection::setUseCells](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorycollection/setusecells/) hívását az üres kategória‑gyűjteményen kell végrehajtani, mielőtt címkéket adnál hozzá. Használj munkalap‑cellákat, ha a címkék munkafüzet‑adatokra hivatkoznak vagy hierarchiát alkotnak (például évenként csoportosított negyedévek). Használj karakter‑literals‑t egyetlen szintű címkékhez, amelyeknek nincs szükségük cellahivatkozásokra. Ez a beállítás csak a kategóriákra vonatkozik. A példában a diagramok numerikus sorozat‑értékekhez munkalap‑cellákat használnak.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot, majd `Q1 Q2 Q3 Q4` címkéket minden diagramra. Munkalapon alapuló címkék esetén a [ChartCategory::getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getascell/) visszaadja az alapszintű cellát, a [ChartDataCell::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getvalue/) pedig a címkét. Literális címkék esetén a [ChartCategory::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getvalue/) adja vissza a szöveget.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    foreach ([true, false] as $useCells) {
        $x = $useCells ? 20 : 360;
        $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, 20, 320, 250);
        $data = $chart->getChartData();
        $data->getSeries()->clear();
        $categories = $data->getCategories();
        $categories->clear();
        $categories->setUseCells($useCells);

        $workbook = $data->getChartDataWorkbook();
        $seriesName = $workbook->getCell(0, 0, 1, "Sales");
        $series = $data->getSeries()->add($seriesName, $chart->getType());
        for ($row = 1; $row <= 4; $row++) {
            $label = "Q" . $row;
            if ($useCells) {
                $labelCell = $workbook->getCell(0, $row, 0, $label);
                $categories->add($labelCell);
            } else {
                $categories->add($label);
            }

            $valueCell = $workbook->getCell(0, $row, 1, $row * 10);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $storedInCells = java_values($categories->getUseCells());
        echo "UseCells = ", ($storedInCells ? "true" : "false"), ":";
        $categoryCount = java_values($categories->size());
        for ($i = 0; $i < $categoryCount; $i++) {
            $category = $categories->get_Item($i);
            $label = $storedInCells ? $category->getAsCell()->getValue() : $category->getValue();
            echo " ", java_values($label);
        }
        echo PHP_EOL;
    }

    $presentation->save("category-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Egyéni számformátumok beállítása munkafüzetcellákhoz**

Használd a [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/)‑t a numerikus értékek megjelenésének szabályozására a diagram beágyazott munkafüzetében. Például egy jelentéshez szükség lehet a konverziós arányra, amelyet százalékban négy tizedesjeggyel, illetve egy koefficiensre, amelyet öt tizedesjeggyel kívánunk megjeleníteni. Mindkét értéket tartsd számmá, hogy továbbra is elérhetőek legyenek a számítások és a diagram ábrázolása számára.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; a tárolt szám nem változik `12.5`‑re. Hasonlóképpen, a `0.00000` a `0.1234567`‑et `0.12346`‑ként mutatja, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) által visszaadott formátum lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)‑on keresztül éri el. Az 0‑s munkalapon a B2 tartalmazza a konverziós arányt, a C2 a koefficienst. Mindkét cella a diagramértékeket szolgáltatja. A példa továbbá engedélyezi a forrás‑formátumhoz kapcsolt értékcímkéket.

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

A munkafüzet‑cellák formátumai különböznek a diagram tengelyein vagy adatcímkéin közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellájuk értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑ra van állítva, és a forrás‑számformátumot követi, mivel a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját számformátumot használ, amely a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)‑val `0.00`‑ra van állítva, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) pedig `false`.

Egy adatcímke önálló formázásához állítsd a forrás‑link zászlót `false`‑ra, és rendelj hozzá egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/)‑val. Ez nem változtatja meg a munkafüzet‑cellához tartozó formátumot. Például egy független `0.00` formátumú címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a közvetlen címke‑formázáshoz.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, és egy függetlenül formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzetcellát beállítani diagram adatcímkeként**

A munkafüzetcellák szövegét használhatod diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal az első diához egy meglévő prezentációban. A 0‑s munkalap A10:A12 tartományát használja az első sorozat három első címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

A [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetben lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

A sorozat‑pont értékek közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/php-java/chart-series/#set-series-values-using-numeric-literals) példát a teljes mentéshez és olvasáshoz. A pontértékek forrás‑típusa különálló a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakter‑literál, a második a 0‑s munkalap C1 cellájára hivatkozik. A [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) felsorolás kiválasztja a forrást minden névhez. A példa elmenti a prezentációt a frissített sorozat‑nevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) felsorolással együtt használva észlelheted a nem támogatott formátumokat, és kihagyhatod az érintett diagramokat. Ez a példa a meglévő prezentáció első diáján lévő alakzatokat vizsgálja, a nem‑diagram alakzatokat kihagyja, és minden, .xlsb beágyazott munkafüzettel rendelkező diagramra diagnosztikai üzenetet ír ki.

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

        // Olvassa vagy módosítsa itt a támogatott diagramm munkafüzet adatait.
    }
} finally {
    $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetet. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet diagramadat‑forrásként, majd menti a linkelt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhetsz egy diagramhoz adatforrásként. Ezzel a metódussal frissítheted a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetek adatait nem szerkesztheted, továbbra is használhatod ezeket külső adatforrásként. Ha relatív útvonalat adsz meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapjában a B1 cella egy sorozat nevet, az A2:A4 cellák kategórianéveket, a B2:B4 cellák pedig numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)‑val A1:B4 tartományt egy sorozatra és három kategóriára térképezi. A prezentációt a linkelt diagrammal menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődik‑e.

* Ha az `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a cél‑munkafüzetről, így a munkafüzet elérhetetlen is lehet.
* Ha az `updateChartData` **true**, a diagramadatok frissülnek a cél‑munkafüzetről.

Az alábbi példa egy helyőrző URL‑t rendeli hozzá, az `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy betöltené a nem elérhető munkafüzetet.

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

Ha meg akarod állapítani, melyik munkafüzet van egy diagramhoz kapcsolva, ellenőrizd, hogy a diagram külső adatforrást használ‑e, és kérd le a munkafüzet útvonalát.

Ez a példa a prezentáció első diájának első alakzatát vizsgálja, amely egy külső munkafüzettel összekapcsolt diagram. Ha ez egy ilyen diagram, a [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét a konzolra írja. Ezután a prezentáció egy másolatát menti.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheted, ahogy a belső munkafüzetek tartalmát módosítanád. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Az első sorozat első adatpontjának cellából származó értékét 100‑ra állítja, majd menti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért ha az eredeti munkafüzetet meg akarod őrizni, használj másolatot.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárból**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzettel dolgozik, az Aspose.Slides képes helyreállítani a diagram munkafüzetét a prezentáció gyorsítótárában tárolt adatokból. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) objektumot, hívd meg a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)‑t, és állítsd a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)‑t **true**‑ra, mielőtt megnyitnád a prezentációt.

Az alábbi PHP példa helyreállítja a munkafüzet‑adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetet hivatkozik. A helyreállított adatokat a [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

        // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadott megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után végrehajtott módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. Egy diagram rendelkezik egy [adatforrás típussal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [úttal egy külső munkafüzethez](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás egy külső munkafüzet, a teljes útvonalat leolvashatod, hogy biztosan külső fájlt használsz.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatók-e a munkafüzetek hálózati erőforrásokon/megosztott meghajtókon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott — csak forrásként használhatók.

**Az Aspose.Slides felülírja-e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást a külső fájlra](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol. A cellákból származó diagramadatok módosítása frissítheti a kapcsolt helyi XLSX fájlt is. Használj másolatot a munkafüzetről, ha az eredetit változatlanul szeretnéd megtartani.

**Mit kell tenni, ha a külső fájl jelszóval van védve?**

Az Aspose.Slides nem fogad el jelszót a kapcsolódáskor. Egy gyakori megoldás, hogy előre eltávolítod a védelmet, vagy egy visszafejtett másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)‑ segítségével) készítesz, majd arra hivatkozol.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.