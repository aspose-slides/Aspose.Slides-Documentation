---
title: Správa pracovnic grafů v prezentacích pomocí PHP
linktitle: Grafová pracovní kniha
type: docs
weight: 70
url: /cs/php-java/chart-workbook/
keywords:
- pracovní kniha grafu
- data grafu
- buňka pracovnice
- popisek dat
- list
- zdroj dat
- externí pracovní kniha
- externí data
- mezipaměť grafu
- obnova pracovní knihy
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte Aspose.Slides pro PHP via Java: snadno spravujte pracovní knihy grafů v PowerPoint a OpenDocument formátech a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s pracovnicemi grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů pracovnic, používat buňky pracovnice jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími pracovnicemi jako zdroji dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí pracovnici, získat cestu k externí pracovnici propojené s grafem a upravit data grafu, když je pracovnice k dispozici.

Pro buňky pracovnice, které představují chybějící data, viz [Řízení zobrazování prázdných buněk](/slides/cs/php-java/chart-series/) ohledně rozdílu mezi prázdnou buňkou a nulou a porovnání režimů zobrazení v čárovém grafu.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setplotvisiblecellsonly/) k řízení, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `true`, pokud má vykreslovat jen viditelné buňky, nebo na `false`, pokud má zahrnout jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neskrývá ani nezobrazuje řádky nebo sloupce listu.

Stáhněte [hidden-source-data.pptx](hidden-source-data.pptx) a umístěte jej do pracovního adresáře. Jeho první snímek obsahuje sloupcový graf jako první objekt. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte pomocí [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getchartdataworkbook/) a přečtěte [ChartDataCell::isHidden](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/ishidden/) k prozkoumání jejich skrytého stavu. Tato metoda vrací skrytý stav, aniž by jej měnila. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vypíše `false`, `true` a `true`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vloženou pracovní knihu pomocí [readWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/readworkbookstream/) a načtěte ji znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/writeworkbookstream/). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setrange/) k obnovení úplného rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostačující k aktualizaci cache dat grafu a popisků kategorií v tomto vzorku.

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

            // Obnovit data grafu z vložené pracovní knihy.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Obnovit úplný zdrojový rozsah, včetně skrytých kategorií.
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

Příklad uloží `hidden_cells_true.pptx` pouze s viditelnými hodnotami Maloobchod (10 a 20) a `hidden_cells_false.pptx` se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených pracovnicích.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: hodnoty Maloobchod 10 a 20 pro Leden a Březen.](hidden_cells_True.png) | ![Všechny buňky: hodnoty Maloobchod a Velkoobchod pro Leden, Únor a Březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/setdisplayblanksas/) řídí, jak jsou zobrazovány chybějící hodnoty; nezahrnuje ani nevynechává skrytá zdrojová data. Viz [Řízení zobrazování prázdných buněk](/slides/cs/php-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Číst a zapisovat data grafu z pracovnice**

Aspose.Slides for PHP via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/readworkbookstream/) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/writeworkbookstream/), které umožňují číst a zapisovat pracovní knihy grafů (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

Tento příklad otevře `chart.pptx`, který musí na svém prvním snímku obsahovat graf jako první objekt. Načte vloženou pracovní knihu do pole bajtů, vymaže existující řady a kategorie a zapíše zpět stejnou pracovní knihu. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověřit rozvržení grafu po úpravě pracovnice**

Když nahradíte vloženou pracovní knihu upravenou, graf si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [Chart::validateChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/validatechartlayout/) s chybou index mimo rozsah. Před zápisem aktualizované pracovní knihy zpět do grafu vymažte existující řady a kategorie. Tento příklad vyžaduje `chart.pptx` s grafem jako první objekt na prvním snímku. Komentář označuje místo, kde by se úprava pracovní knihy měla provést; spustitelný příklad zapíše původní pracovní knihu zpět a ověří rozvržení v paměti.

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

        // Zde upravte bajty pracovní knihy, například pomocí Aspose.Cells.

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

Vyprázdnění kolekcí odstraní zastaralé odkazy na data před zápisem pracovní knihy zpět. Před použitím grafu obnovte potřebné mapování řad a kategorií pro aktualizovanou pracovní knihu.

## **Nastavit buňku pracovnice jako popisek dat grafu**

Můžete použít text z buněk pracovnice jako popisky dat grafu. Následující kroky ukazují, jak propojit popisky v bublinovém grafu s buňkami v jeho datové pracovnici.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte první snímek pomocí nulového indexu.
3. Přidejte bublinový graf s výchozími daty.
4. Získejte řadu grafu.
5. Nastavte buňku pracovnice jako popisek dat.
6. Uložte prezentaci.

Tento příklad otevře `chart2.pptx`, který musí obsahovat alespoň jeden snímek, a přidá bublinový graf s výchozími daty. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a výsledek uloží do `resultchart.pptx`.

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

## **Správa listů**

Metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/getworksheets/) poskytuje přístup k listům v pracovnici grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše název každého listu do konzole.

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

## **Určit typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčet [DataSourceType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Výsledek je uložen do `pres.pptx`.

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

## **Detekce nepodporovaných formátů vložených pracovnic**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad prozkoumá objekty na prvním snímku `sample.pptx`, přeskočí objekty, které nejsou grafy, a vypíše diagnostickou zprávu pro každý graf s vloženou pracovnicí .xlsb.

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

        // Zde načtěte nebo upravte podporovaná data pracovnice grafu.
    }
} finally {
    $presentation->dispose();
}
```

## **Externí pracovní kniha**

Aspose.Slides podporuje používání externích pracovnic jako zdrojů dat pro grafy.

### **Vytvořit externí pracovní knihu**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/readworkbookstream/) a [setExternalWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setexternalworkbook/) k exportu vložené pracovnice grafu do souboru a propojení grafu s touto externí pracovnicí.

Tento příklad vytvoří koláčový graf s výchozími daty, zapíše jeho pracovní knihu do `externalWorkbook1.xlsx` a dokončí zápis souboru před přiřazením souboru jako zdroje dat grafu. Uloží propojenou prezentaci do `externalWorkbook.pptx`.

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

### **Nastavit externí pracovní knihu**

Při použití metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setexternalworkbook/) můžete přiřadit externí pracovní knihu k grafu jako zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externí pracovní knize (pokud byla přesunuta).

I když nemůžete upravovat data v pracovnicích uložených na vzdálených místech nebo zdrojích, můžete takové pracovní knihy stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externí pracovní knize, automaticky se převede na úplnou cestu.

Tento příklad vyžaduje `externalWorkbook.xlsx` v pracovním adresáři. Jeho list s názvem `Sheet1` musí obsahovat název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí pracovní knihu a použije [setRange](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setrange/) k mapování A1:B4 na jednu řadu a tři kategorie. Výsledek uloží do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setexternalworkbook/) určuje, zda se pracovní kniha načte.

* Když je `updateChartData` `false`, aktualizuje se pouze cesta k pracovní knize. Data grafu nejsou načtena ani aktualizována ze cílové pracovní knihy, takže může být neexistující.
* Když je `updateChartData` `true`, data grafu jsou aktualizována ze cílové pracovní knihy.

Následující příklad přiřadí zástupnou URL s nastaveným `updateChartData` na `false`. Zachová výchozí data koláčového grafu a uloží prezentaci bez načtení nedostupné pracovní knihy.

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

### **Získat cestu externí pracovní knihy zdroje dat grafu**

Aby bylo možné zjistit pracovní knihu připojenou ke grafu, nejprve ověřte, zda graf používá externí zdroj dat. Pokud ano, můžete získat cestu k pracovní knize podle následujících kroků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte první snímek pomocí nulového indexu.
3. Zkontrolujte, že první objekt je graf.
4. Přečtěte typ zdroje dat grafu.
5. Pokud je zdroj externí pracovní kniha, přečtěte její cestu.

Tento příklad otevře `externalWorkbook.pptx`, vytvořený v předchozím příkladu, a prověří první objekt na prvním snímku. Pokud je to graf propojený s externí pracovní knihou, příklad vypíše [getExternalWorkbookPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/) do konzole. Poté uloží kopii prezentace do `Result.pptx`.

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

### **Upravit data grafu**

Můžete upravovat data v externích pracovnicích stejným způsobem, jako provádíte změny v obsahu interních pracovnic. Když není externí pracovní kniha načtena, je vyvolána výjimka.

Tento příklad vyžaduje `presentation.pptx` s grafem jako první objekt na prvním snímku a přístupnou externí pracovní knihu. Nastaví hodnotu buňky odpovídající prvnímu datovému bodu v první řadě na 100 a uloží prezentaci do `presentation_out.pptx`. Úprava buněk v grafu může také aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat původní pracovní knihu.

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

### **Obnovit pracovní knihu z mezipaměti grafu**

Pokud graf používá externí pracovní knihu, která chybí nebo není dostupná, Aspose.Slides může rekonstruovat pracovní knihu grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/), zavolejte [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) a nastavte [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` před otevřením prezentace.

Následující PHP příklad otevře `presentation.pptx`, jehož první objekt na prvním snímku musí být graf odkazující na nedostupnou externí pracovní knihu, a přistoupí k obnoveným datům prostřednictvím [Chart::getChartData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/getchartdata/) a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Načtěte nebo upravte obnovená data pracovnice zde.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pokud je externí pracovní kniha nedostupná a obnova je vypnuta, Aspose.Slides vyvolá výjimku. Povolení obnovy použijte jen v případě, že je použití dat z mezipaměti grafu přijatelným řešením, protože mezipaměť nemusí obsahovat změny provedené v externí pracovní knize po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externí nebo vloženou pracovnicí?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externí pracovní knize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí pracovní kniha, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím pracovnicím a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže při přesunu pracovní knihy může být nutné aktualizovat odkaz.

**Mohu používat pracovní knihy umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové pracovní knihy lze použít jako externí zdroj dat. Úprava vzdálených pracovnic přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Úprava buněk v grafu může také aktualizovat propojený lokální soubor XLSX. Použijte kopii pracovní knihy, pokud musí zůstat originál nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejnou externí pracovní knihu?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.