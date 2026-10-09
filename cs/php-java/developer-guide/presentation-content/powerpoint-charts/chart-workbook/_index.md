---
title: Správa knihoven grafů v prezentacích pomocí PHP
linktitle: Grafová knihovna
type: docs
weight: 70
url: /cs/php-java/chart-workbook/
keywords:
- grafová knihovna
- data grafu
- buňka knihovny
- popisek dat
- list
- zdroj dat
- externí knihovna
- externí data
- mezipaměť grafu
- obnova knihovny
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte Aspose.Slides pro PHP via Java: snadno spravujte grafové knihovny v formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s knihovnami grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů knihovny, používat buňky knihovny jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími knihovnami jako zdroji dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí knihovnu, získat cestu k externí knihovně propojené s grafem a upravit data grafu, když je knihovna k dispozici.

Pro buňky knihovny, které představují chybějící data, viz [Ovládání zobrazení prázdných buněk](/slides/cs/php-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a pro srovnání liniového grafu dostupných režimů zobrazení.

## **Zahrnutí dat ze skrytých řádků a sloupců**

Použijte [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `true`, aby se vykreslovaly jen viditelné buňky, nebo na `false`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neskryje ani neodkryje řádky či sloupce listu.

[Vzorová prezentace](hidden-source-data.pptx) obsahuje sloupcový graf jako první tvar na první snímku. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte pomocí [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) a přečtete [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) pro kontrolu jejich skrytého stavu. Tato metoda vrací stav skrytí, aniž by jej měnila. V tomto souboru je B2 viditelný, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vytiskne `false`, `true` a `true`.

Pro tento příklad po změně nastavení vykreslování obnovte data grafu: zachovejte vloženou knihovnu pomocí [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) a načtěte ji zpět pomocí [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) k obnovení celého rozsahu, včetně skryté kategorie únor. Pouze změna příznaku nestačí k obnovení cache dat a popisků kategorií v tomto vzorku.

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

            // Obnovte data grafu z vložené pracovní knihy.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Obnovte celý zdrojový rozsah, včetně skrytých kategorií.
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

Příklad ukládá dvě verze prezentace: jednu pouze s viditelnými hodnotami Maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených knihovnách.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: Maloobchodní hodnoty 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Maloobchodní a velkoobchodní hodnoty pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) řídí, jak se zobrazují chybějící hodnoty; nezahrnuje ani nevynechává skryté zdrojové údaje. Viz [Ovládání zobrazení prázdných buněk](/slides/cs/php-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získání rozsahu dat grafu**

Před aktualizací dat knihovny v existující prezentaci zkontrolujte zdrojové rozsahy, abyste identifikovali, které buňky listu každému grafu používá. Metoda [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) vrací aktuální datový rozsah jako formulář kvalifikovaný listem, například `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znak `$` označuje absolutní odkazy na řádky a sloupce.

Metoda čte aktuální rozsah, aniž by měnila graf nebo jeho knihovnu. Pokud graf nepoužívá knihovnu jako zdroj dat, vyvolá výjimku. Další informace naleznete v [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Tento příklad otevře prezentaci a zkontroluje tvary přímo na každém snímku, zda jsou grafy. Vytiskne název každého grafu a jeho zdrojový rozsah. Pokud graf nepoužívá knihovnu, vytiskne zprávu a pokračuje dalším grafem.

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

## **Čtení a zápis dat grafu z knihovny**

Aspose.Slides for PHP via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) a [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/), které umožňují číst a zapisovat knihovny dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

Tento příklad použije prezentaci s grafem jako první tvar na první snímku. Načte vloženou knihovnu do pole bajtů, vymaže existující řady a kategorie a zapíše stejnou knihovnu zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověření rozvržení grafu po úpravě knihovny**

Když nahradíte vloženou knihovnu upravenou knihovnou, graf si zachová původní řady a kolekce kategorií. Tento nesoulad může způsobit, že [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) selže s chybou indexu mimo rozsah. Vymažte existující řady a kategorie před zápisem aktualizované knihovny zpět do grafu. Tento příklad použije graf, který je první tvar na první snímku. Komentář označuje místo, kde by úprava knihovny proběhla; spustitelný příklad zapíše původní knihovnu zpět a ověří rozvržení v paměti.

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

        // Upravte zde bajty pracovního sešitu, například pomocí Aspose.Cells.

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

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem knihovny. Přestavte jakékoli požadované mapování řad a kategorií pro aktualizovanou knihovnu před použitím grafu.

## **Nastavení buňky knihovny jako popisku dat grafu**

Můžete použít text z buněk knihovny jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

Metoda [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) poskytuje přístup k listům v knihovně grafu. Tento příklad vytvoří výsečový graf s výchozími daty a vypíše název každého listu do konzole.

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

## **Určení typu zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název použije řetězcový literál; druhý použije buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

## **Detekce nepodporovaných formátů vložených knihoven**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad prozkoumá tvary na prvním snímku existující prezentace, přeskočí tvary, které nejsou grafy, a vytiskne diagnostickou zprávu pro každý graf s vloženou knihovnou .xlsb.

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

        // Přečtěte nebo upravte podporovaná data pracovního sešitu grafu zde.
    }
} finally {
    $presentation->dispose();
}
```

## **Externí knihovna**

Aspose.Slides podporuje používání externích knihoven jako zdroje dat pro grafy.

### **Vytvoření externí knihovny**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) a [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) k exportu vložené knihovny grafu do souboru a propojení grafu s touto externí knihovnou.

Tento příklad vytvoří výsečový graf s výchozími daty a exportuje jeho knihovnu. Dokončí zápis souboru před přiřazením externí knihovny jako zdroje dat grafu, poté uloží propojenou prezentaci.

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

### **Nastavení externí knihovny**

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) můžete přiřadit externí knihovnu grafu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externí knihovně (pokud byla přesunuta).

Ačkoliv nemůžete upravovat data v knihovnách uložených na vzdálených místech nebo v prostředcích, můžete takové knihovny nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externí knihovně, automaticky se převede na úplnou cestu.

Tento příklad použije externí knihovnu, jejíž list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří výsečový graf, propojí knihovnu a použije [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) řídí, zda se knihovna načte.

* Když je `updateChartData` `false`, aktualizuje se pouze cesta k souboru knihovny. Data grafu nejsou načtena ani aktualizována ze cílové knihovny, takže knihovna může být nedostupná.
* Když je `updateChartData` `true`, data grafu jsou aktualizována ze cílové knihovny.

Následující příklad přiřadí zástupný URL s `updateChartData` nastaveným na `false`. Zachová výchozí data výsečového grafu a uloží prezentaci, aniž by načetl nedostupnou knihovnu.

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

### **Získání cesty ke zdrojové externí knihovně grafu**

Pro identifikaci knihovny propojené s grafem zkontrolujte, zda graf používá externí zdroj dat, a získejte její cestu.

Tento příklad zkoumá první tvar na první snímku prezentace s propojenou externí knihovnou. Pokud se jedná o graf propojený s externí knihovnou, vytiskne [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) do konzole. Poté uloží kopii prezentace.

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

### **Úprava dat grafu**

Můžete upravovat data v externích knihovnách stejným způsobem, jako měníte obsah interních knihoven. Když není externí knihovna načtena, vyvolá se výjimka.

Tento příklad použije graf, který je první tvar na první snímku a je propojen s přístupnou externí knihovnou. Nastaví hodnotu na buňce pro první datový bod v první řadě na 100 a uloží aktualizovanou prezentaci. Úpravy hodnot buněk mohou aktualizovat propojený externí soubor XLSX, takže použijte kopii, pokud potřebujete zachovat původní knihovnu.

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

### **Obnovení knihovny z mezipaměti grafu**

Pokud graf používá externí knihovnu, která chybí nebo není dostupná, Aspose.Slides může rekonstruovat knihovnu grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), zavolejte [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) a nastavte [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) na `true` před otevřením prezentace.

Následující PHP příklad obnoví data knihovny pro graf, který je první tvar na první snímku a odkazuje na nedostupnou externí knihovnu. Přístup k obnoveným datům získáte pomocí [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) a [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Přečtěte nebo upravte zde obnovená data pracovního sešitu.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pokud je externí knihovna nedostupná a obnova je zakázána, Aspose.Slides vyvolá výjimku. Povolení obnovy použijte pouze tehdy, když je použití cache dat přijatelnou náhradou, protože cache nemusí obsahovat změny provedené v externí knihovně po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externí nebo vloženou knihovnou?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) a [cestu k externí knihovně](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); pokud je zdroj externí knihovna, můžete přečíst úplnou cestu a ujistit se, že se používá externí soubor.

**Jsou relativní cesty k externím knihovnám podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace uloží absolutní cestu v souboru PPTX, takže při přesunu knihovny může být nutné aktualizovat odkaz.

**Mohu použít knihovny umístěné na síťových zdrojích/ sdíleních?**

Ano, takové knihovny lze použít jako externí zdroj dat. Úprava vzdálených knihoven přímo z Aspose.Slides však není podporována — mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Úpravy dat grafu založených na buňkách mohou také aktualizovat propojený lokální soubor XLSX. Použijte kopii knihovny, pokud musí originál zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Obvyklý postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat se na tuto kopii.

**Může více grafů odkazovat na stejnou externí knihovnu?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při dalším načtení dat.