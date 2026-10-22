---
title: Hantera diagramarbetsböcker i presentationer med PHP
linktitle: Diagramarbetsbok
type: docs
weight: 70
url: /sv/php-java/chart-workbook/
keywords:
- diagramarbetsbok
- diagramdata
- arbetsbokscell
- datatetikett
- kalkylblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck Aspose.Slides för PHP via Java: hantera enkelt diagramarbetsböcker i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatatetiketter, får åtkomst till kalkylbladsinsamlingar och anger datakälltyp för diagramvärden.

Den täcker också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboksceller som representerar saknad data, se [Styr visning av tomma celler](/slides/sv/php-java/chart-series/) för skillnaden mellan en tom cell och noll samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) för att styra om ett diagram plotar data från dolda kalkylbladsrader och -kolumner. Sätt den till `true` för att plotta endast synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagramplotting; den döljer eller visar inte rader eller kolumner i kalkylbladet.

Den [sample presentation](hidden-source-data.pptx) innehåller ett stapeldiagram som den första formen på den första bilden. Det inbäddade kalkylbladet, `Sheet1`, innehåller följande källområde, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Kalkylbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dold kolumn) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (dold rad) | februari | 40 | 60 |
| 4 | mars | 20 | 50 |

Få åtkomst till källcellerna via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) och läs [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) för att inspektera deras dolda status. Denna metod rapporterar den dolda statusen utan att ändra den. I det här exemplet är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `false`, `true` och `true` respektive.

För det här exemplet, uppdatera diagramdata efter att du ändrat plotinställningen: behåll den inbäddade arbetsboken med [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) och läs in den igen med [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). När du inkluderar alla celler, använd även [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) för att återställa det kompletta området, inklusive den dolda februari-kategorin. Att bara ändra flaggan är otillräckligt för att uppdatera detta exempels cachade diagramdata och kategorietiketter.

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

            // Uppdatera diagramdata från den inbäddade arbetsboken.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Återställ det kompletta källområdet, inklusive dolda kategorier.
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

Exemplet sparar två versioner av presentationen: en med endast de synliga detaljhandelsvärdena (10 och 20), och en annan med alla sex värden. Bilden nedan illustrerar de två plottningslägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för januari och mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandel- och partihandelsvärden för januari, februari och mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Styr visning av tomma celler](/slides/sv/php-java/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta diagrammets dataområde**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källområdena för att identifiera vilka kalkylblads‑celler varje diagram använder. Metoden [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) returnerar det aktuella dataområdet som en kalkylblads‑kvalificerad formel, exempelvis `Sheet1!$A$1:$D$5`. Här är `Sheet1` kalkylbladsnamnet, `!` separerar det från cellområdet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusive. Dollartecknen indikerar absoluta rad‑ och kolumnreferenser.

Metoden läser det aktuella området utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla kastar den ett undantag. För mer information, se [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagrams namn och källområde. Om ett diagram inte använder en arbetsbok skriver det ut ett meddelande och fortsätter till nästa diagram.

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

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides for PHP via Java tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) och [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerade med Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

Detta exempel använder en presentation med ett diagram som den första formen på dess första bild. Det läser den inbäddade arbetsboken till en byte‑array, rensar befintliga serier och kategorier och skriver tillbaka samma arbetsbok. Ändringarna finns kvar i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategori‑samlingar. Denna mismatch kan få [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) att misslyckas med ett index‑out‑of‑range‑fel. Rensa befintliga serier och kategorier innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel använder ett diagram som är den första formen på den första bilden. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

        // Ändra arbetsbokens byte här, till exempel med Aspose.Cells.

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

Att rensa samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Bygg om eventuella nödvändiga serie‑ och kategorimappningar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange anpassade talformat för arbetsboks‑celler**

Använd [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) för att styra hur numeriska värden visas i ett diagrams inbäddade arbetsbok. Till exempel kan en rapport behöva en konverteringsgrad som visas som procent med fyra decimaler och en koefficient med fem decimaler. Behåll båda värdena som numeriska så att de förblir tillgängliga för beräkningar och diagramplotting.

Ett talformat ändrar endast visningen, inte det lagrade värdet. Formatet `0.0000%` visar `0.125` som `12.5000%`; det ersätter inte det lagrade talet med `12.5`. På samma sätt visar `0.00000` `0.1234567` som `0.12346` utan att runda det lagrade värdet. Om det anpassade formatet är en tom sträng (`""`) används formatet som returneras av [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

Följande exempel skapar ett stapeldiagram och får åtkomst till dess celler via [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). På kalkylblad 0 innehåller B2 konverteringsgraden och C2 koefficienten. Båda cellerna levererar diagramvärden. Exemplet aktiverar även värdetiketter kopplade till källformaten.

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

Arbetsboks‑celformat är separata från format som sätts direkt på diagramaxlar eller datatetiketter. I detta exempel visar varje etikett värdet från sin källcell eftersom [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) är satt till `true`, och följer källans talformat eftersom [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) är satt till `true`. Efter sparande och återöppning av presentationen visar etiketterna `12.5000%` och `0.12346`, som visas nedan. Den vertikala axeln använder sitt eget talformat, tilldelat med [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) som `0.00`, med [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) satt till `false`.

För att formatera en datatetikett oberoende, sätt dess käll‑länkningsflagga till `false` och tilldela ett format med [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Detta ändrar inte arbetsbokens cellformat. Till exempel visar ett oberoende etikettformat `0.00` det första värdet som `0.13`, medan B2 fortfarande visar `12.5000%`. Se [Chart Data Labels](/slides/sv/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) för direkt etikettformatering.

Bilden nedan renderades från den sparade presentationen efter att den återöppnats:

![Stapeldiagram med käll‑länkade etiketter som visar 12.5000% och 0.12346 samt en oberoende formaterad numerisk axel.](custom-cell-formats.png)

## **Ange en arbetsboks‑cell som diagramdatatetikett**

Du kan använda text från arbetsboks‑celler som diagramdatatetiketter.

Detta exempel lägger till ett bubbeldiagram med standarddata på den första bilden i en befintlig presentation. Det använder cellerna A10:A12 på kalkylblad 0 för de tre första etiketterna i den första serien, aktiverar etiketter från celler och sparar den uppdaterade presentationen.

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

## **Hantera kalkylblad**

Metoden [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) ger åtkomst till kalkylbladen i ett diagramarbetsbok. Detta exempel skapar ett sektordiagram med standarddata och skriver ut varje kalkylblads namn till konsolen.

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

## **Ange datakälltyp**

Serievärden kan också lagras direkt som numeriska litteraler. Se [Set Series Values Using Numeric Literals](/slides/sv/php-java/chart-series/#set-series-values-using-numeric-literals) för ett fullständigt exempel som sparar och läser dem. Datakälltypen för punktvärden är separerad från diagrammets interna eller externa arbetsboks‑konfiguration; att använda numeriska litteraler tar i sig självt inte bort den inbäddade arbetsboken.

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och sätter två serie‑namn med olika datakällor. Det första namnet använder en sträng‑litteral; det andra använder cell C1 på kalkylblad 0. Uppräkningen [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

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

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över de diagrammen. Detta exempel inspekterar formerna på den första bilden i en befintlig presentation, hoppar över icke‑diagramformer och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

        // Läs eller ändra stödd diagramarbetsboksdata här.
    }
} finally {
    $presentation->dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stöder att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) och [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett sektordiagram med standarddata och exporterar dess arbetsbok. Det slutför filskrivningen innan den tilldelar den externa arbetsboken som diagrammets datakälla, och sparar sedan den länkade presentationen.

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

### **Ange en extern arbetsbok**

Genom att använda metoden [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera en sökväg till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan sådana arbetsböcker fortfarande användas som extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok där kalkylbladet `Sheet1` innehåller ett serienamn i B1, kategorinamnen i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett sektordiagram, länkar arbetsboken och använder [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) för att kartlägga A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

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

Parametern `updateChartData` för [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) styr om arbetsboken läses in.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata läses inte in eller uppdateras från mål‑arbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från mål‑arbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller sektordiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

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

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsboksökväg.

Detta exempel inspekterar den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om det är ett diagram som är länkat till en extern arbetsbok skriver exemplet ut [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) till konsolen. Det sparar sedan en kopia av presentationen.

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

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör förändringar i interna arbetsböcker. När en extern arbetsbok inte kan läsas in kastas ett undantag.

Detta exempel använder ett diagram som är den första formen på den första bilden och som är länkat till en åtkomlig extern arbetsbok. Det sätter det cell‑stödda värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Redigering av cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du behöver bevara den ursprungliga arbetsboken.

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarboken från de data som cachas i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), anropa [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) och sätt [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) till `true` innan du öppnar presentationen.

Följande PHP‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar en otillgänglig extern arbetsbok. Det får åtkomst till den återställda datan via [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) och [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Läs eller ändra den återställda arbetsboksdatan här.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av den cachade diagramdatan är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller förändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) och en [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytt av arbetsboken kan kräva att länken uppdateras.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte — de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Redigering av cell‑stödd diagramdata kan även uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad bör jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkningsprocessen. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång datan läses in.