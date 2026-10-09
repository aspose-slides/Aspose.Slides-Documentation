---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni usando PHP
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
description: "Scopri Aspose.Slides per PHP via Java: gestisci facilmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite stream di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'uso di cartelle di lavoro esterne come fonti di dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/php-java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei vari modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra le righe o le colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella sua prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l'intervallo di origine seguente, `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono comunque valori.

| Righe del foglio | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) e leggi [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) per ispezionare lo stato di nascondimento. Questo metodo restituisce lo stato di nascondimento senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l'esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l'impostazione di tracciamento: conserva la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e ricaricala con [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Quando si includono tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) per ripristinare l'intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente per aggiornare i dati del grafico memorizzati nella cache di questo esempio e le etichette delle categorie.

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

            // Aggiorna i dati del grafico dal workbook incorporato.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Ripristina l'intervallo di origine completo, comprese le categorie nascoste.
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

L'esempio salva due versioni della presentazione: una con solo i valori di Vendita al dettaglio visibili (10 e 20) e un'altra con tutti e sei i valori. Le immagini sottostanti illustrano i due modi di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di Vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di Vendita al dettaglio e Vendita all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/php-java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l'intervallo di dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, esamina gli intervalli di origine per identificare quali celle del foglio di lavoro utilizza ciascun grafico. Il metodo [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) restituisce l'intervallo di dati corrente come formula qualificata dal foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall'intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusa. I segni di dollaro indicano riferimenti assoluti di riga e colonna.

Il metodo legge l'intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, lancia un'eccezione. Per ulteriori informazioni, consulta il [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Questo esempio apre una presentazione e verifica le forme direttamente su ogni diapositiva per trovare grafici. Stampa il nome di ciascun grafico e il suo intervallo di origine. Se un grafico non utilizza una cartella di lavoro, stampa un messaggio e prosegue con il grafico successivo.

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

Aspose.Slides per PHP via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella di origine.

Questo esempio utilizza una presentazione con un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, cancella le serie e le categorie esistenti e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l'esempio non salva la presentazione.

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

Quando sostituisci una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni di serie e categorie originali. Questa incongruenza può far fallire [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l'esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

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

        // Modifica i byte della cartella di lavoro qui, ad esempio usando Aspose.Cells.

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

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappature di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare una cella della cartella di lavoro come etichetta dati del grafico**

Puoi utilizzare il testo delle celle della cartella di lavoro come etichette dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Utilizza le celle A10:A12 del foglio di lavoro 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

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

Il metodo [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) fornisce l'accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ogni foglio di lavoro sulla console.

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

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse origini dati. Il primo nome utilizza una stringa letterale; il secondo utilizza la cella C1 del foglio di lavoro 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) seleziona l'origine per ciascun nome. L'esempio salva la presentazione con i nomi di serie aggiornati.

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

Aspose.Slides non supporta il formato di cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio analizza le forme nella prima diapositiva di una presentazione esistente, salta le forme non grafico e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

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

        // Leggi o modifica i dati della cartella di lavoro supportata del grafico qui.
    }
} finally {
    $presentation->dispose();
}
```

## **External Workbook**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come fonte di dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) per esportare una cartella di lavoro del grafico incorporata in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Completa la scrittura del file prima di assegnare la cartella di lavoro esterna come fonte dati del grafico, quindi salva la presentazione collegata.

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

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), puoi assegnare una cartella di lavoro esterna a un grafico come sua fonte dati. Questo metodo può essere usato anche per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni o risorse remote, puoi comunque usarle come fonte di dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso completo.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L'esempio crea un grafico a torta, collega la cartella di lavoro e usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

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

L'esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

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

### **Ottenere il percorso della cartella di lavoro della fonte dati esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica se il grafico utilizza una fonte dati esterna e recupera il suo percorso.

Questo esempio analizza la prima forma nella prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se è un grafico collegato a una cartella di lavoro esterna, l'esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) sulla console. Quindi salva una copia della presentazione.

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

Puoi modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui apporti modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene sollevata un'eccezione.

Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva ed è collegato a una cartella di lavoro esterna accessibile. Imposta il valore basato su cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi conservare la cartella di lavoro originale.

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

Se un grafico usa una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), chiama [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) e imposta [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

L'esempio PHP seguente recupera i dati della cartella di lavoro per un grafico che è la prima forma nella prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides lancia un'eccezione. Abilita il recupero solo quando utilizzare i dati del grafico nella cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se l'origine è una cartella di lavoro esterna, puoi leggere il percorso completo per assicurarti che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare la cartella di lavoro potrebbe richiedere l'aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come fonte di dati esterna. Tuttavia, la modifica di cartelle di lavoro remote direttamente da Aspose.Slides non è supportata — possono essere usate solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l'originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password al momento del collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegare a quella copia.

**Possono più grafici fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.