---
title: Diagram munkafüzetek kezelése prezentációkban PHP használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/php-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
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
description: "Fedezze fel az Aspose.Slides for PHP via Java-t: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan kell dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet diagram adatokat olvasni és írni munkafüzet adatfolyamokon keresztül, hogyan lehet a munkafüzet cellákat diagram adatcímkeként használni, hogyan lehet hozzáférni a munkalap gyűjteményekhez, és hogyan kell megadni az adatforrás típusát a diagram értékekhez.

Továbbá tárgyalja a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan lehet külső munkafüzetet létrehozni és hozzárendelni, hogyan lehet lekérni egy diagramhoz csatolt külső munkafüzet elérési útját, és hogyan lehet szerkeszteni a diagram adatokat, ha a munkafüzet elérhető.

Hiányzó adatot reprezentáló munkafüzet cellák esetén lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/php-java/chart-series/) az üres cella és a nulla közti különbségért, valamint egy vonaldiagram összehasonlításért a rendelkezésre álló megjelenítési módok között.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) metódust, hogy szabályozza, a diagram rejtett munkalap sorokból és oszlopokból származó adatokat is ábrázoljon‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha mind a látható, mind a rejtett cellákat bele kívánja foglalni. Ez a beállítás a diagram ábrázolását befolyásolja; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, mint az első alakzatot az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forráscellákhoz a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével férhet hozzá, és a [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) olvasásával ellenőrizheti azok rejtett státuszát. Ez a metódus jelentést ad a rejtett státuszról anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatot a diagramrajzolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)‑nel, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)‑nel. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)‑t is a teljes tartomány helyreállításához, beleértve a rejtett februári kategóriát is. A jelző egyszerű módosítása önmagában nem elegendő a minta gyorsítótárazott diagram adatainak és kategória címkéinek frissítéséhez.

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

            // Frissítse a diagram adatot a beágyazott munkafüzetből.
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

A példa két verzióban menti a bemutatót: az egyik csak a látható Kiskereskedelem értékekkel (10 és 20), a másik minden hat értékkel. Az alábbi képek illusztrálják a két ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett, értékkel rendelkező cella különbözik az üres cellától. A [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja bele vagy hagyja ki a rejtett forrás adatokat. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/php-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő bemutatóban, ellenőrizze a forrás tartományokat, hogy mely munkalap cellákat használja egy diagram. A [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) metódus visszaadja az aktuális adat tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlopreferenciákat jeleznek.

Ez a metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem munkafüzetet használ adatforrásként, kivételt dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)‑t.

Ez a példa megnyit egy bemutatót, és közvetlenül a diákon ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki és folytatja a következő diagrammal.

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

## **Diagram adat olvasása és írása munkafüzetből**

Aspose.Slides for PHP via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik diagram adat munkafüzetek (a diagram adatokat Aspose.Cells‑sel szerkesztve tartalmazó fájlok) olvasását és írását. **Megjegyzés**: a diagram adatokat ugyanúgy kell szervezni, vagy a forráshoz hasonló struktúrával kell rendelkezniük.

Ez a példa egy olyan bemutatót használ, amelynek első alakzata az első dián egy diagram. A beágyazott munkafüzetet bájt‑tömbbe olvassa, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások a memóriában maradnak; a példa nem menti a bemutatót.

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

Ha egy beágyazott munkafüzetet módosított változattal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a eltérés a [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) hibához vezethet, index‑túl‑hatókör‑hiba esetén. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelöli, hol történne a munkafüzet szerkesztése; a futtatható példa az eredeti munkafüzetet visszaírja, és a memóriában ellenőrzi az elrendezést.

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

        // Módosítsa itt a munkafüzet bájtjait, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adatreferenciákat, mielőtt a munkafüzet visszaírásra kerül. Újraépítse a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Munkafüzet cella beállítása diagram adatcímkeként**

Használhatja a munkafüzet cellák szövegét diagram adatcímkeként.

Ez a példa habdiagramot ad hozzá alapértelmezett adatokkal a meglévő bemutató első diájához. Az 0‑ás munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített bemutatót.

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

A [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) metódus hozzáférést biztosít a diagram munkafüzetében található munkalapokhoz. Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Adatforrás típusának megadása**

Ez a példa 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokból. Az első nevet karakterlánc‑literálként, a másodikat a 0‑ás munkalap C1 cellájaként állítja be. A [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa menti a bemutatót a frissített sorozatnevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusával és a [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) felsorolással fel lehet ismerni a nem támogatott formátumokat, és kihagyhatók azok a diagramok. Ez a példa az első dián lévő alakzatokat vizsgálja, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzettel rendelkező diagramra.

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

Használja a [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) és a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódusokat a beágyazott diagram munkafüzet exportálásához egy fájlba, majd a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet a diagram adatforrásaként, majd menti a hivatkozott bemutatót.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet elérési útját is frissítheti (ha az áthelyezésre került).

Miközben nem szerkesztheti a távoli helyen vagy erőforráson tárolt munkafüzetek adatait, ilyen munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapján B1‑ben sorozatnév, A2:A4‑ben kategória‑nevek, B2:B4‑ben numerikus értékek vannak. A példa kördiagramot hoz létre, összekapcsolja a munkafüzettel, és a [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) segítségével az A1:B4‑et egy sorozatra és három kategóriára képezi le. A diagrammal együtt menti a bemutatót.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑e töltve.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adat nem töltődik be vagy frissül a cél‑munkafüzettől, így a munkafüzet hiányozhat.
* Ha `updateChartData` **true**, a diagram adat frissül a cél‑munkafüzettől.

A következő példa egy helyettesítő URL‑t ad meg, `updateChartData` értéke **false**. A kördiagram alapértelmezett adatait megtartja, és a bemutatót úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

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

Annak meghatározásához, hogy melyik munkafüzet van csatolva egy diagramhoz, ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafűzet útvonalát.

Ez a példa az első dián lévő első alakzatot vizsgálja, amely egy külső munkafüzettel kapcsolt diagram. Ha ez egy külső munkafüzettel kapcsolt diagram, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) értékét a konzolra. Ezután egy másolatot ment a bemutatóról.

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

### **Diagram adat szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzettel dolgozik, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) objektumot, hívja a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)‑t, és állítsa a [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)‑t **true**‑ra, mielőtt megnyitná a bemutatót.

Az alábbi PHP példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatot a [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) és a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. Egy diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) attribútummal; ha az adatforrás egy külső munkafüzet, a teljes útvonal beolvasásával ellenőrizhető, hogy külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott — csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [linket a külső fájlra](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredeti munkafüzetet érintetlenül kell hagyni, használjon másolatot.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozás létrehozásakor. Általános megoldás a védettség előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd erre a másolatra hivatkozni.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mind ugyanarra a fájlra mutat, a fájl frissítése minden diagramot érint a következő adatbetöltéskor.