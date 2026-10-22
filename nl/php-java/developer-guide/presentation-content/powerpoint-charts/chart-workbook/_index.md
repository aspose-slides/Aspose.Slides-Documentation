---
title: Beheer grafiekwerkboeken in presentaties met PHP
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/php-java/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek Aspose.Slides voor PHP via Java: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides werkt. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑datacontroles, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt specificeren.

Het behandelt ook het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen regelen](/slides/nl/php-java/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Gegevens van verborgen rijen en kolommen opnemen**

Gebruik [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) om te bepalen of een grafiek gegevens plot uit verborgen werkblad‑rijen en -kolommen. Zet deze op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling regelt het plotten van de grafiek; ze verbergt of maakt werkblad‑rijen of -kolommen niet zichtbaar.

De [sample presentation](hidden-source-data.pptx) bevat een kolomgrafiek als het eerste object op de eerste dia. Het ingesloten werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) en lees [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) om hun verborgen status te inspecteren. Deze methode rapporteert de verborgen status zonder deze te wijzigen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld geeft respectievelijk `false`, `true` en `true` weer.

Voor dit voorbeeld ververst u de grafiekgegevens nadat u de plotinstelling hebt gewijzigd: behoud het ingesloten werkboek met [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en laad het opnieuw met [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Wanneer u alle cellen opneemt, gebruik dan ook [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is niet voldoende om de gecachete grafiekgegevens en categorielabels van dit voorbeeld te verversen.

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

            // Vernieuw de grafiekgegevens van het ingesloten werkboek.
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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelswaarden (10 en 20), en een andere met alle zes waarden. De afbeeldingen hieronder tonen de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingesloten werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels- en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) bepaalt hoe ontbrekende waarden worden weergegeven; ze neemt geen verborgen brongegevens op of sluit ze uit. Zie [De weergave van lege cellen regelen](/slides/nl/php-java/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Bereik van de grafiekgegevens ophalen**

Voordat u werkboekgegevens bijwerkt in een bestaande presentatie, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elke grafiek gebruikt. De methode [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` identificeert de cellen A1 tot en met D5, inclusief. De dollartekens duiden absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder de grafiek of het werkboek te wijzigen. Als de grafiek geen werkboek als gegevensbron gebruikt, wordt er een uitzondering gegenereerd. Zie voor meer informatie de [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Dit voorbeeld opent een presentatie en controleert de objecten direct op elke dia voor grafieken. Het geeft de naam en het bronbereik van elke grafiek weer. Als een grafiek geen werkboek gebruikt, wordt er een bericht weergegeven en wordt doorgegaan met de volgende grafiek.

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

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for PHP via Java biedt de [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) methoden waarmee u grafiekgegevens‑werkboeken kunt lezen en schrijven (bevat grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Dit voorbeeld gebruikt een presentatie met een grafiek als het eerste object op de eerste dia. Het leest het ingesloten werkboek in een byte‑array, wist de bestaande series en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafiekindeling valideren na werkboekwijziging**

Wanneer u een ingesloten werkboek vervangt door een gewijzigd exemplaar, behoudt de grafiek haar oorspronkelijke series‑ en categoriecollecties. Deze discrepantie kan ervoor zorgen dat [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkboek terugschrijft naar de grafiek. Dit voorbeeld gebruikt een grafiek die het eerste object op de eerste dia is. Het commentaar markeert waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkboek terug en valideert de indeling in het geheugen.

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

        // Wijzig de werkboekbytes hier, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde gegevensreferenties voordat het werkboek wordt weggeschreven. Herbouw eventuele vereiste series‑ en categorietoewijzingen voor het bijgewerkte werkboek voordat u de grafiek gebruikt.

## **Aangepaste getalnotaties instellen voor werkboekcellen**

Gebruik [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) om te bepalen hoe numerieke waarden worden weergegeven in het ingesloten werkboek van een grafiek. Bijvoorbeeld, een rapport kan een conversieratio weergeven als een percentage met vier decimalen en een coëfficiënt met vijf decimalen. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en grafiekplotting.

Een getalnotatie wijzigt de weergave, niet de opgeslagen waarde. De notatie `0.0000%` toont `0.125` als `12.5000%`; het vervangt niet het opgeslagen getal door `12.5`. Op dezelfde manier toont `0.00000` `0.1234567` als `0.12346` zonder het opgeslagen getal af te ronden. Als de aangepaste notatie een lege tekenreeks (`""`) is, wordt de notatie die wordt teruggegeven door [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) gebruikt.

Het volgende voorbeeld maakt een kolomgrafiek en benadert haar cellen via [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren grafiekwaarden. Het voorbeeld schakelt ook waardelabels in die gekoppeld zijn aan de bronnotaties.

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

Werkboekcel‑notaties staan los van notaties die direct op grafiekassen of datalabels worden ingesteld. In dit voorbeeld toont elk label de waarde van de broncel omdat [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) is ingesteld op `true`, en de brongetalnotatie volgt omdat [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) is ingesteld op `true`. Na het opslaan en heropenen van de presentatie tonen de labels `12.5000%` en `0.12346`, zoals hieronder weergegeven. De verticale as gebruikt haar eigen getalnotatie, toegewezen met [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) als `0.00`, met [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) ingesteld op `false`.

Om een datalabel onafhankelijk te formatteren, stelt u de bron‑koppeling in op `false` en kent u een notatie toe met [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Dit verandert de notatie van de werkboekcel niet. Bijvoorbeeld, een onafhankelijke label‑notatie van `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` toont. Zie [Chart Data Labels](/slides/nl/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) voor directe label‑formattering.

De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie na het heropenen:

![Kolomgrafiek met bron‑gelinkte labels die 12.5000% en 0.12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkboekcel als grafiekdatacontrole gebruiken**

U kunt tekst uit werkboekcellen gebruiken als grafiekdatacontroles.

Dit voorbeeld voegt een bubbelgrafiek met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels vanuit cellen in, en slaat de bijgewerkte presentatie op.

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

De methode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) geeft toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld maakt een taartgrafiek met standaardgegevens en geeft elke werkbladnaam weer in de console.

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

## **Gegevenstype van de bron specificeren**

Seriespuntwaarden kunnen ook rechtstreeks als numerieke literals worden opgeslagen. Zie [Set Series Values Using Numeric Literals](/slides/nl/php-java/chart-series/#set-series-values-using-numeric-literals) voor een volledig voorbeeld dat ze opslaat en leest. Het brontype van puntwaarden staat los van de interne of externe werkboekconfiguratie van de grafiek; het gebruik van numerieke literals verwijdert het ingesloten werkboek niet automatisch.

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee serienamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienamen.

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet dat in sommige grafieken kan worden ingesloten. U kunt de methode `getEmbeddedWorkbookType` op [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) combineren met de enumeratie [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de objecten op de eerste dia van een bestaande presentatie, slaat niet‑grafiekobjecten over, en geeft een diagnostisch bericht weer voor elke grafiek met een ingesloten .xlsb‑werkboek.

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

        // Lees of wijzig ondersteunde grafiekwerkboekgegevens hier.
    }
} finally {
    $presentation->dispose();
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor grafieken.

### **Een extern werkboek maken**

Gebruik [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) en [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) om een ingesloten grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens en exporteert het werkboek. Het voltooit het bestands­schrijven voordat het externe werkboek als gegevensbron aan de grafiek wordt toegewezen, en slaat vervolgens de gekoppelde presentatie op.

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

Met de methode [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of bronnen bevinden niet kunt bewerken, kunt u dergelijke werkboeken toch als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad met de naam `Sheet1` een serienaam bevat in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een taartgrafiek, koppelt het werkboek, en gebruikt [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) om A1:B4 te koppelen aan één serie en drie categorieën. Het slaat de presentatie op met de gekoppelde grafiek.

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

* Wanneer `updateChartData` `false` is, wordt alleen het werkboekpad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek niet beschikbaar hoeft te zijn.
* Wanneer `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld wijst een placeholder‑URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de taartgrafiek en slaat de presentatie op zonder het niet‑beschikbare werkboek te laden.

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

### **Het pad van het externe gegevensbron‑werkboek van een grafiek ophalen**

Om het werkboek te identificeren dat aan een grafiek is gekoppeld, controleert u of de grafiek een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspekteert het eerste object op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een grafiek is die aan een extern werkboek is gekoppeld, geeft het voorbeeld [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) weer in de console. Vervolgens wordt een kopie van de presentatie opgeslagen.

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

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Dit voorbeeld gebruikt een grafiek die het eerste object op de eerste dia is en die is gekoppeld aan een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste datapunten in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het oorspronkelijke werkboek wilt behouden.

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

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren uit de in de presentatie gecachede gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) aan, roep [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) aan, en stel [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) in op `true` voordat u de presentatie opent.

Het volgende PHP‑voorbeeld herstelt werkboekgegevens voor een grafiek die het eerste object op de eerste dia is en verwijst naar een niet‑beschikbaar extern werkboek. Het benadert de herstelde gegevens via [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) en [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een uitzondering. Schakel herstel alleen in wanneer het gebruik van de gecachede grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste presentatie‑update in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen/share‑s bevinden?**

Ja, zulke werkboeken kunnen als externe gegevensbron worden gebruikt. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) op. Het bewerken van cel‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een ontsleutelde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/java/)) en die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat haar eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt het bijwerken van dat bestand in elke grafiek weergegeven de volgende keer dat de gegevens worden geladen.