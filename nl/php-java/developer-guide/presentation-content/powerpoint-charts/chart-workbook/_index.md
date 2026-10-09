---
title: Beheer diagram-werkboeken in presentaties met PHP
linktitle: Diagram-werkboek
type: docs
weight: 70
url: /nl/php-java/chart-workbook/
keywords:
- diagram-werkboek
- diagramgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- diagramcache
- werkboekherstel
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek Aspose.Slides voor PHP via Java: beheer eenvoudig diagram‑werkboeken in PowerPoint‑ en OpenDocument‑formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramwerkboeken in Aspose.Slides werkt. Het laat zien hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen als diagramgegevenslabels kunt gebruiken, werkbladcollecties kunt benaderen en het gegevenstype van de gegevensbron voor diagramwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een diagram is gekoppeld opvraagt, en diagramgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen beheren](/slides/nl/php-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) om te bepalen of een diagram gegevens uit verborgen werkbladrijen en -kolommen plot. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling bepaalt het plotten van het diagram; het verbergt of toont geen werkbladrijen of -kolommen.

De [voorbeeldpresentatie](hidden-source-data.pptx) bevat een kolomdiagram als eerste vorm op de eerste dia. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Benader broncellen via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) en lees [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) om hun verborgen status te inspecteren. Deze methode rapporteert de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld print respectievelijk `false`, `true` en `true`.

Voor dit voorbeeld moet u de diagramgegevens vernieuwen nadat u de plotinstelling hebt gewijzigd: behoud het ingebedde werkboek met [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Wanneer u alle cellen opneemt, gebruik dan ook [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in dit voorbeeld gecachete diagramgegevens en categorielabels te vernieuwen.

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

            // Vernieuw de diagramgegevens vanuit het ingebedde werkboek.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Herstel het volledige bronbereik, inclusief verborgen categorieën.
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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelswaarden (10 en 20), en een andere met alle zes waarden. De onderstaande afbeeldingen illustreren de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels- en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) bepaalt hoe ontbrekende waarden worden weergegeven; het neemt geen verborgen brongegevens op of sluit ze uit. Zie [De weergave van lege cellen beheren](/slides/nl/php-java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Het gegevensbereik van een diagram ophalen**

Voordat u werkboekgegevens in een bestaande presentatie bijwerkt, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elk diagram gebruikt. De methode [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens geven absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder het diagram of het werkboek te wijzigen. Als het diagram geen werkboek als gegevensbron gebruikt, wordt er een exceptie gegooid. Zie voor meer informatie de [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen direct op elke dia op diagrammen. Het print de naam en het bronbereik van elk diagram. Als een diagram geen werkboek gebruikt, print het een bericht en gaat verder met het volgende diagram.

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

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides voor PHP via Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) waarmee u diagramgegevens‑werkboeken (met diagramgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Let op** dat de diagramgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een diagram als eerste vorm op de eerste dia. Het leest het ingebedde werkboek naar een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Diagramlay-out valideren na wijziging van werkboek**

Wanneer u een ingebed werkboek vervangt door een aangepast, behoudt het diagram zijn oorspronkelijke series‑ en categoriecollecties. Deze mismatch kan ervoor zorgen dat [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is. Het commentaar markeert waar de werkboekbewerking zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de lay‑out in het geheugen.

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

        // Wijzig hier de werkboekbytes, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Bouw eventuele vereiste series‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkboek voordat u het diagram gebruikt.

## **Een werkboekcel gebruiken als diagramgegevenslabel**

U kunt tekst uit werkboekcellen gebruiken als diagramgegevenslabels.

Dit voorbeeld voegt een bubbel‑diagram met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

## **Werkbladen beheren**

De methode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) geeft toegang tot de werkbladen in een diagramwerkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en print elke werkbladnaam naar de console.

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

## **Gegevenstype van de gegevensbron opgeven**

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee serienaam­instellingen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienaam­instellingen.

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

## **Niet‑ondersteunde ingebedde werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige diagrammen kan worden ingebed niet. U kunt de methode `getEmbeddedWorkbookType` op [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) gebruiken samen met de enumeratie [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑diagramvormen over, en print een diagnostisch bericht voor elk diagram met een ingebed .xlsb‑werkboek.

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

        // Lees of wijzig ondersteunde diagram-werkboekgegevens hier.
    }
} finally {
    $presentation->dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) om een ingebed diagramwerkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en exporteert het werkboek. Het voltooit het bestandsschrijven voordat het externe werkboek als diagramgegevensbron wordt toegewezen, en slaat vervolgens de gekoppelde presentatie op.

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

### **Een extern werkboek instellen**

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kunt u een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt deze automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad met de naam `Sheet1` een serienaam in B1 bevat, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om A1:B4 te koppelen aan één serie en drie categorieën. Het slaat de presentatie met het gekoppelde diagram op.

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

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het werkboek‑pad bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, dus het werkboek kan niet beschikbaar zijn.  
* Wanneer `updateChartData` `true` is, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke‑URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van het cirkeldiagram en slaat de presentatie op zonder het niet‑beschikbare werkboek te laden.

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

### **Het pad van het externe gegevensbron‑werkboek van een diagram opvragen**

Om het werkboek te identificeren dat aan een diagram is gekoppeld, controleer of het diagram een externe gegevensbron gebruikt en haal het werkboek‑pad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een diagram is dat is gekoppeld aan een extern werkboek, print het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) naar de console. Vervolgens slaat het een kopie van de presentatie op.

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

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een exceptie gegooid.

Dit voorbeeld gebruikt een diagram dat de eerste vorm op de eerste dia is en gekoppeld is aan een toegankelijk extern werkboek. Het stelt de celgebaseerde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het originele werkboek wilt behouden.

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

### **Een werkboek herstellen vanuit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagramwerkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) aan, roep [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) aan, en stel [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) in op `true` voordat u de presentatie opent.

Het volgende PHP‑voorbeeld herstelt werkboekgegevens voor een diagram dat de eerste vorm op de eerste dia is en verwijst naar een niet‑beschikbaar extern werkboek. Het krijgt de herstelde gegevens via [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) en [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Lees of wijzig hier de herstelde werkboekgegevens.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een exceptie. Schakel herstel alleen in wanneer het gebruik van de gecachete diagramgegevens een aanvaardbare fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [gebruiks­type van gegevenbron](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te controleren dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus bij het verplaatsen van het werkboek moet de koppeling mogelijk worden bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen / gedeelde locaties bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Schrijft Aspose.Slides het externe XLSX‑bestand over bij het opslaan van de presentatie?**

De presentatie slaat een [koppeling naar het externe bestand](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) op. Het bewerken van celgebaseerde diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een gedecodeerde kopie te maken (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en naar die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand verwijzen, zal een update van dat bestand in elk diagram worden weergegeven zodra de gegevens opnieuw worden geladen.