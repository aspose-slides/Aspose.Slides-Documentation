---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni con PHP
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/php-java/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri Aspose.Slides per PHP via Java: gestisci facilmente le cartelle di lavoro dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Tratta anche l'uso di cartelle di lavoro esterne come origine dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/php-java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei diversi modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Utilizzare [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostarlo su `true` per tracciare solo le celle visibili, oppure su `false` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

La [sample presentation](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo di origine `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono comunque valori.

| Riga del foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (riga nascosta) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Accedere alle celle di origine tramite [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) e leggere [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) per verificare lo stato di nascondimento. Questo metodo restituisce lo stato di nascondimento senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiornare i dati del grafico dopo aver modificato l’impostazione di tracciamento: mantenere la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e ricaricarla con [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Quando si includono tutte le celle, utilizzare anche [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) per ripristinare l’intervallo completo, inclusa la categoria di febbraio nascosta. Modificare semplicemente il flag non è sufficiente a aggiornare i dati del grafico memorizzati nella cache di questo esempio e le etichette delle categorie.

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

            // Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Ripristina l'intero intervallo di origine, includendo le categorie nascoste.
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

L’esempio salva due versioni della presentazione: una con solo i valori di vendita al dettaglio visibili (10 e 20) e un’altra con tutti e sei i valori. Le immagini sotto illustrano le due modalità di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controlla come vengono visualizzati i valori mancanti; non include né esclude dati di origine nascosti. Vedere [Controllare la visualizzazione delle celle vuote](/slides/it/php-java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l’intervallo di dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, ispezionare gli intervalli di origine per identificare quali celle del foglio di lavoro utilizza ciascun grafico. Il metodo [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) restituisce l’intervallo di dati corrente come formula qualificata per il foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall’intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusi. I segni di dollaro indicano riferimenti assoluti a riga e colonna.

Il metodo legge l’intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, genera un’eccezione. Per ulteriori informazioni, vedere il [Riferimento API di ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Questo esempio apre una presentazione e controlla le forme direttamente su ciascuna diapositiva per i grafici. Stampa il nome di ogni grafico e l’intervallo di origine. Se un grafico non usa una cartella di lavoro, stampa un messaggio e continua con il grafico successivo.

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

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides for PHP via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella di origine.

Questo esempio utilizza una presentazione con un grafico come prima forma nella prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, cancella le serie e le categorie esistenti e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

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

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa incompatibilità può far fallire [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) con un errore di indice fuori intervallo. Cancellare le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

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

        // Modifica i byte della cartella di lavoro qui, ad esempio, usando Aspose.Cells.

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

La cancellazione delle collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruire eventuali mappature di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare formati numerici personalizzati per le celle della cartella di lavoro**

Utilizzare [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) per controllare come i valori numerici appaiono nella cartella di lavoro incorporata del grafico. Ad esempio, un report può richiedere di mostrare un tasso di conversione come percentuale con quattro decimali e un coefficiente con cinque decimali. Mantenere entrambi i valori numerici affinché rimangano disponibili per calcoli e tracciamento del grafico.

Un formato numerico cambia la visualizzazione, non il valore memorizzato. Il formato `0.0000%` visualizza `0.125` come `12.5000%`; non sostituisce il numero memorizzato con `12.5`. Analogamente, `0.00000` visualizza `0.1234567` come `0.12346` senza arrotondare il valore memorizzato. Se il formato personalizzato è una stringa vuota (`""`), viene utilizzato il formato restituito da [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

L’esempio seguente crea un grafico a colonne e accede alle sue celle tramite [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Nel foglio 0, B2 contiene il tasso di conversione e C2 contiene il coefficiente. Entrambe le celle forniscono valori per il grafico. L’esempio abilita inoltre le etichette dei valori collegate ai formati di origine.

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

I formati delle celle della cartella di lavoro sono separati dai formati impostati direttamente sugli assi del grafico o sulle etichette dei dati. In questo esempio, ogni etichetta visualizza il valore della cella di origine perché [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) è impostato su `true`, e segue il formato numerico di origine perché [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) è impostato su `true`. Dopo aver salvato e riaperto la presentazione, le etichette mostrano `12.5000%` e `0.12346`, come mostrato sotto. L’asse verticale utilizza un proprio formato numerico, assegnato con [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) come `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) impostato su `false`.

Per formattare un’etichetta dei dati in modo indipendente, impostare il flag di collegamento alla sorgente su `false` e assegnare un formato con [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Questo non cambia il formato della cella della cartella di lavoro. Ad esempio, un formato indipendente di etichetta `0.00` visualizza il primo valore come `0.13`, mentre B2 continua a mostrare `12.5000%`. Vedere [Chart Data Labels](/slides/it/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) per la formattazione diretta delle etichette.

L’immagine sotto è stata generata dalla presentazione salvata dopo averla riaperta:

![Grafico a colonne con etichette collegate all’origine che mostrano 12.5000% e 0.12346 e un asse numerico formattato in modo indipendente.](custom-cell-formats.png)

## **Impostare una cella della cartella di lavoro come etichetta dati del grafico**

È possibile utilizzare il testo delle celle della cartella di lavoro come etichette dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Utilizza le celle A10:A12 nel foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

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

## **Gestire i fogli di lavoro**

Il metodo [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) fornisce l’accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ogni foglio di lavoro nella console.

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

## **Specificare il tipo di origine dati**

I valori dei punti della serie possono anche essere memorizzati direttamente come letterali numerici. Vedere [Impostare i valori della serie usando letterali numerici](/slides/it/php-java/chart-series/#set-series-values-using-numeric-literals) per un esempio completo che li salva e li legge. Il tipo di origine dei valori dei punti è separato dalla configurazione della cartella di lavoro interna o esterna del grafico; l’uso di letterali numerici non rimuove, di per sé, la cartella di lavoro incorporata.

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse origini dati. Il primo nome usa un letterale stringa; il secondo usa la cella C1 nel foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi delle serie aggiornati.

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

## **Rilevare formati di cartelle di lavoro incorporate non supportati**

Aspose.Slides non supporta il formato della cartella di lavoro Excel binaria (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) per rilevare i formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

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

        // Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
    }
} finally {
    $presentation->dispose();
}
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l’uso di cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una cartella di lavoro esterna**

Utilizzare [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) per esportare una cartella di lavoro di un grafico incorporato su un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Completa la scrittura del file prima di assegnare la cartella di lavoro esterna come origine dati del grafico, quindi salva la presentazione collegata.

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

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati in cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come fonte dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso completo.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio denominato `Sheet1` contiene un nome di serie in B1, i nomi di categoria in A2:A4 e i valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e utilizza [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

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

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) controlla se la cartella di lavoro viene caricata.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

L’esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

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

### **Ottenere il percorso del foglio di lavoro sorgente esterno di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verificare se il grafico utilizza una fonte dati esterna e recuperare il suo percorso di cartella di lavoro.

Questo esempio ispeziona la prima forma sulla prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se è un grafico collegato a una cartella di lavoro esterna, l’esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) nella console. Quindi salva una copia della presentazione.

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

### **Modificare i dati del grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si modificano i contenuti delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un’eccezione.

Questo esempio utilizza un grafico che è la prima forma sulla prima diapositiva e è collegato a una cartella di lavoro esterna accessibile. Imposta il valore supportato dalla cella del primo punto dati nella prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi utilizzare una copia se è necessario preservare la cartella di lavoro originale.

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

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna che manca o non è disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Creare [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), chiamare [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), e impostare [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio PHP recupera i dati della cartella di lavoro per un grafico che è la prima forma sulla prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Leggi o modifica i dati della cartella di lavoro recuperata qui.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Se la cartella di lavoro esterna non è disponibile e il ripristino è disabilitato, Aspose.Slides genera un’eccezione. Abilitare il ripristino solo quando l’uso dei dati del grafico memorizzati nella cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se l’origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per assicurarsi che sia stato utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento della cartella di lavoro può richiedere l’aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come fonte dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata — possono essere utilizzate solo come fonte.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Modificare i dati del grafico supportati da celle può anche aggiornare il file XLSX locale collegato. Utilizzare una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file si rifletterà in ciascun grafico al successivo caricamento dei dati.