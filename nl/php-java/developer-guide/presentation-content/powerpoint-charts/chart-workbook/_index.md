---
title: Beheer diagramwerkboeken in presentaties met PHP
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/php-java/chart-workbook/
keywords:
- diagramwerkboek
- diagramgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- diagramcache
- herstel van werkboek
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek Aspose.Slides voor PHP via Java: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagram‑werkboeken in Aspose.Slides kunt werken. Het toont hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als diagramgegevenslabels, toegang kunt krijgen tot werkbladcollecties, en het type gegevensbron kunt opgeven voor diagramwaarden.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld, kunt ophalen, en diagramgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Controleren van de weergave van lege cellen](/slides/nl/php-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens opnemen uit verborgen rijen en kolommen**

Gebruik [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setplotvisiblecellsonly/) om te bepalen of een diagram gegevens plot uit verborgen werkbladrijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling beïnvloedt alleen het plotten van het diagram; het verbergt of maakt geen verborgen werkbladrijen of -kolommen zichtbaar.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkmap. De eerste dia bevat een kolomdiagram als eerste vorm. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Krijg toegang tot broncellen via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getchartdataworkbook/) en lees [ChartDataCell::isHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatacell/ishidden/) om hun verborgen status te inspecteren. Deze methode rapporteert de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld drukt respectievelijk `false`, `true` en `true` af.

Voor dit voorbeeld moet u de diagramgegevens vernieuwen nadat de plot‑instelling is gewijzigd: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/readworkbookstream/) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/writeworkbookstream/). Wanneer alle cellen worden opgenomen, gebruik ook [setRange](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setrange/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in dit voorbeeld gecachte diagramgegevens en categorielabels te vernieuwen.

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

Het voorbeeld slaat `hidden_cells_true.pptx` op met alleen de zichtbare detailhandelswaarden (10 en 20), en `hidden_cells_false.pptx` met alle zes waarden. De afbeeldingen hieronder illustreren de twee plot‑modi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: Detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: Detailhandels‑ en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setdisplayblanksas/) bepaalt hoe ontbrekende waarden worden weergegeven; het omvat of sluit geen verborgen brongegevens uit. Zie [Controleren van de weergave van lege cellen](/slides/nl/php-java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for PHP via Java biedt de methoden [readWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/readworkbookstream/) en [writeWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/writeworkbookstream/) die u in staat stellen werkboek‑diagramgegevens (bevatten diagramgegevens bewerkt met Aspose.Cells) te lezen en te schrijven. **Note** dat de diagramgegevens op dezelfde manier moeten worden georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, dat een diagram moet bevatten als eerste vorm op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

Wanneer u een ingesloten werkboek vervangt door een aangepast werkboek, behoudt het diagram de oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ertoe leiden dat [Chart::validateChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/validatechartlayout/) faalt met een “index‑out‑of‑range”‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld vereist `chart.pptx` met een diagram als eerste vorm op de eerste dia. De commentaarregel geeft aan waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkboek terug en valideert de lay‑out in het geheugen.

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

        // Pas hier de bytes van het werkboek aan, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde dataverwijzingen voordat het werkboek wordt weggeschreven. Bouw eventuele vereiste series‑ en categorietoewijzingen opnieuw op voor het aangepaste werkboek voordat u het diagram gebruikt.

## **Een werkboekcel instellen als diagramgegevenslabel**

U kunt tekst uit werkboekcellen gebruiken als diagramgegevenslabels. De volgende stappen tonen hoe u de labels in een bubbel‑diagram koppelt aan cellen in het bijbehorende gegevens‑werkboek.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de eerste dia op basis van de nul‑gebaseerde index.
3. Voeg een bubbel‑diagram toe met standaardgegevens.
4. Open de diagramserie.
5. Stel de werkboekcel in als een gegevenslabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, dat minstens één dia moet bevatten, en voegt een bubbel‑diagram met standaardgegevens toe. Het gebruikt de cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat het resultaat op als `resultchart.pptx`.

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

De methode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/getworksheets/) biedt toegang tot de werkbladen in een diagram‑werkboek. Dit voorbeeld maakt een cirkeldiagram met standaardgegevens en drukt elke werkbladnaam af op de console.

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

## **Gegevensbrontype opgeven**

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee series‑namen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het resultaat wordt opgeslagen als `pres.pptx`.

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

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige diagrammen kan zijn ingebed. U kunt de methode `getEmbeddedWorkbookType` op [ChartData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/) gebruiken in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, slaat niet‑diagram‑vormen over, en drukt een diagnostisch bericht af voor elk diagram met een ingebed .xlsb‑werkboek.

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

### **Extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/readworkbookstream/) en [setExternalWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setexternalworkbook/) om een ingebed diagram‑werkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een cirkeldiagram met standaardgegevens, schrijft het werkboek naar `externalWorkbook1.xlsx`, en voltooit het bestandsschrijven voordat het bestand wordt toegewezen als diagram‑gegevensbron. Het slaat de gekoppelde presentatie op als `externalWorkbook.pptx`.

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

### **Extern werkboek instellen**

Met behulp van de methode [setExternalWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setexternalworkbook/) kunt u een extern werkboek toewijzen aan een diagram als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het bestand is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken wel gebruiken als externe gegevensbron. Als er een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkmap. Het werkblad `Sheet1` moet een serienaam bevatten in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een cirkeldiagram, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setrange/) om A1:B4 te koppelen aan één serie en drie categorieën. Het slaat het resultaat op als `Presentation_with_externalWorkbook.pptx`.

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

De parameter `updateChartData` van [setExternalWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setexternalworkbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het pad van het werkboek bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek afwezig kan zijn.
* Wanneer `updateChartData` `true` is, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van het cirkeldiagram en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Pad van het externe gegevensbron‑werkboek van een diagram ophalen**

Om het werkboek te identificeren dat aan een diagram is gekoppeld, controleer eerst of het diagram een externe gegevensbron gebruikt. Indien ja, kunt u het pad van het werkboek ophalen door de volgende stappen te volgen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de eerste dia op basis van de nul‑gebaseerde index.
3. Controleer of de eerste vorm een diagram is.
4. Lees het diagram‑gegevensbrontype.
5. Als de bron een extern werkboek is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, dat in het eerdere voorbeeld is aangemaakt, en inspecteert de eerste vorm op de eerste dia. Als het een diagram is dat gekoppeld is aan een extern werkboek, drukt het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) af op de console. Vervolgens slaat het een kopie van de presentatie op als `Result.pptx`.

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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een diagram als eerste vorm op de eerste dia en een toegankelijk extern werkboek. Het stelt de cel‑ondersteunde waarde van het eerste gegevenspunt in de eerste serie in op 100 en slaat de presentatie op als `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het originele werkboek moet behouden.

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

### **Werkboek herstellen vanuit de diagramcache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de gegevens die in de presentatie zijn gecached. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/) aan, roep [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) aan, en stel [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) in op `true` vóór het openen van de presentatie.

Het volgende PHP‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een diagram moet zijn dat verwijst naar een onbeschikbaar extern werkboek, en krijgt toegang tot de herstelde gegevens via [Chart::getChartData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/getchartdata/) en [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Lees of wijzig de herstelde werkboekgegevens hier.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachte diagramgegevens een aanvaardbare fallback is, omdat de cache mogelijk niet de wijzigingen bevat die later in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifiek diagram gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te zijn dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/‑shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als een externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund; ze kunnen alleen als bron dienen.

**Schrijft Aspose.Slides het externe XLSX‑bestand overschrijven bij het opslaan van de presentatie?**

De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getexternalworkbookpath/) op. Het bewerken van cel‑ondersteunde diagramgegevens kan het gekoppelde lokale XLSX‑bestand ook bijwerken. Gebruik een kopie van het werkboek als het origineel onveranderd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een gedecrypteerde kopie (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) te maken en naar die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, zal een wijziging van dat bestand in elk diagram worden weerspiegeld de volgende keer dat de gegevens worden geladen.