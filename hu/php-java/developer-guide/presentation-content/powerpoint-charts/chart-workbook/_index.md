---
title: Diagrammunkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
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
description: "Fedezze fel az Aspose.Slides for PHP via Java-t: egyszerűen kezelheti a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzeteivel az Aspose.Slides‑ben. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzet‑adatfolyamokon keresztül, hogyan használhat munkafüzet‑cellákat diagramcímkékként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Továbbá bemutatja a külső munkafüzetekkel való munkát diagramadat‑forrásként. A példák azt demonstrálják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet‑cellákra lásd a [Control the Display of Empty Cells](/slides/hu/php-java/chart-series/) cikket, ahol megtalálja az üres cella és a nulla közötti különbséget, valamint egy vonaldiagram‑összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak bevonása**

Használja a [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust annak szabályozására, hogy a diagram csak látható munkalap‑sorok és -oszlopok adatait ábrázolja‑e. Állítsa `true`‑ra, hogy csak a látható cellákat ábrázolja, vagy `false`‑ra, hogy a látható és rejtett cellákat egyaránt vegye figyelembe. Ez a beállítás a diagram rajzolását irányítja; nem rejti el vagy jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze a munkakönyvtárba. Az első dia egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig tartalmaznak értékeket.

| Munkalap‑sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás‑cellák elérése a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getchartdataworkbook/) útján, és a [ChartDataCell::isHidden](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/ishidden/) használata a rejtett állapot vizsgálatához. Ez a módszer a rejtett állapotot jelzi anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatát a rajzolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/readworkbookstream/) használatával, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/writeworkbookstream/)‑el. Az összes cella bevonásakor használja a [setRange](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setrange/)‑t a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. A flag egyszerű módosítása nem elegendő a mintában lévő gyorsítótárazott diagramadatok és kategória‑címkék frissítéséhez.

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

            // Frissítse a diagram adatait a beágyazott munkafüzetből.
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

A példa a `hidden_cells_true.pptx`‑t csak a látható Kiskereskedelem értékekkel (10 és 20) menti, a `hidden_cells_false.pptx`‑t pedig a hat értékkel. Az alábbi képek a két rajzolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Összes cella (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik egy üres cellától. A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setdisplayblanksas/) szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/php-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for PHP via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyekkel diagramadat‑munkafüzeteket (az Aspose.Cells‑szel szerkesztett diagramadatokat) olvashat és írhat. **Megjegyzés:** a diagramadatoknak ugyanolyan módon kell felépülniük, vagy hasonló szerkezetűnek kell lenniük, mint a forrás.

Ez a példa megnyitja a `chart.pptx`‑t, amelynek az első diáján első alakzatként diagramot kell tartalmaznia. A beágyazott munkafüzetet bájttömbbe olvassa, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti a bemutatót.

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

### **A diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet módosított változattal cserél, a diagram megtartja eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés a [Chart::validateChartLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/validatechartlayout/) hibához vezethet index‑túl‑range kivétellel. Írja ki a meglévő sorozatokat és kategóriákat a módosított munkafüzet visszaírása előtt. Ez a példa `chart.pptx`‑t igényel egy diagrammal az első diáján első alakzatként. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a régi adat‑referenciákat a munkafüzet visszaírása előtt. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzet‑cellának beállítása diagramadat‑címkeként**

A munkafüzet‑cellákból származó szöveget is használhatja diagramadat‑címkeként. Az alábbi lépések mutatják, hogyan kapcsolja össze a felhődiagram címkéit a munkafüzet celláival.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Érje el az első diát a null‑alapú indexével.  
1. Adjon hozzá egy felhődiagramot alapértelmezett adatokkal.  
1. Érje el a diagram sorozatát.  
1. Állítsa be a munkafüzet‑cellát adatcímkének.  
1. Mentse a bemutatót.

Ez a példa megnyitja a `chart2.pptx`‑t, amelynek legalább egy diája kell legyen, és hozzáad egy felhődiagramot alapértelmezett adatokkal. A 0‑s munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a címkék cellákból való felvételét, és a `resultchart.pptx`‑be menti az eredményt.

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

A [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram‑munkafüzet munkalapjaihoz. Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrások használatával. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datasourcetype/) felsorolás választja ki az egyes nevek forrását. Az eredményt a `pres.pptx`‑be menti.

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

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amely bizonyos diagramokba beágyazható. A [ChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/workbooktype/) felsorolással együtt használva észlelheti a nem támogatott formátumokat, és kihagyhatja az ilyen diagramokat. Ez a példa a `sample.pptx` első diáján lévő alakzatokat vizsgálja, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramra.

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

        // Olvassa vagy módosítsa a támogatott diagram munkafüzettel kapcsolatos adatokat itt.
    }
} finally {
    $presentation->dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetelek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat egy beágyazott diagram‑munkafüzet exportálásához fájlba, majd a diagram összekapcsolásához ezzel a külső munkafüzettel.

Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, a munkafüzettét a `externalWorkbook1.xlsx`‑be írja, és a fájl írása befejeződik, mielőtt a fájlt a diagram adatforrásaként beállítaná. A linkelt bemutatót a `externalWorkbook.pptx`‑ben menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setexternalworkbook/) metódussal egy külső munkafüzettet rendelhet a diagram adatforrásaként. Ezzel a módszerrel frissíthető a külső munkafüzet útvonala is (ha az át lett helyezve).

Bár a távoli helyen vagy erőforráson tárolt munkafüzettek adatait nem szerkesztheti, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, azt automatikusan teljes útra konvertálja a rendszer.

Ez a példa a `externalWorkbook.xlsx`‑t igényli a munkakönyvtárban. Az `Sheet1` munkalapon a B1‑ben sorozat‑nevet, az A2:A4‑ben kategória‑neveket, a B2:B4‑ben numerikus értékeket kell tartalmaznia. A példa kördiagramot hoz létre, összekapcsolja a munkafüzettet, és a [setRange](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setrange/) metódussal az A1:B4 tartományt egy sorozatra és három kategóriára map‑olja. A `Presentation_with_externalWorkbook.pptx`‑be menti az eredményt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzettel, így a munkafüzet hiányzó is lehet.  
* Ha `updateChartData` **true**, a diagramadatok frissülnek a célmunkafüzettel.

A következő példa egy helyettesítő URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a munkafüzet betöltése nélkül menti a bemutatót.

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

### **A diagram külső adatforrás‑munkafüzete útvonalának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához először ellenőrizze, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépések szerint lekérheti a munkafüzet útvonalát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Érje el az első diát a null‑alapú indexével.  
1. Ellenőrizze, hogy az első alakzat diagram‑e.  
1. Olvassa be a diagram adatforrás‑típusát.  
1. Ha a forrás egy külső munkafüzet, olvassa be annak útvonalát.

Ez a példa megnyitja az előző példában létrehozott `externalWorkbook.pptx`‑t, és vizsgálja az első diáján az első alakzatot. Ha ez egy külső munkafüzettel összekapcsolt diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/)‑t írja ki a konzolra. Ezután egy `Result.pptx` másolatot ment a bemutatóból.

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

A külső munkafüzettek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzettekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy `presentation.pptx`‑t igényel, amelynek első diáján első alakzatként diagramnak kell lennie, valamint egy hozzáférhető külső munkafüzettel. A példa az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és a `presentation_out.pptx`‑be menti a bemutatót. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg szeretné őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzettel dolgozik, az Aspose.Slides a diagram munkafüzettét rekonstruálhatja a bemutatóban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)‑t, és állítsa a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)‑t **true**‑ra a bemutató megnyitása előtt.

Az alábbi PHP példa megnyitja a `presentation.pptx`‑t, amelynek első diáján első alakzatként egy olyan diagramnak kell lennie, amely egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatot a [Chart::getChartData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/getchartdata/) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzetben történt módosításokat a bemutató legutóbbi frissítése óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak-e relatív útvonalak a külső munkafüzettekhez, és hogyan vannak tárolva?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonalra konvertálja. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatók‑e hálózati erőforrásokon/megosztott mappákon lévő munkafüzettek?**

Igen, ilyen munkafüzettek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a bemutató mentésekor?**

A bemutató tárol egy [link to the external file](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdata/getexternalworkbookpath/). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Ha az eredetit érintetlenül kell hagyni, használjon másolatot a munkafüzetről.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy visszafejtett példány előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat‑e ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramra kihat a következő adatbetöltéskor.