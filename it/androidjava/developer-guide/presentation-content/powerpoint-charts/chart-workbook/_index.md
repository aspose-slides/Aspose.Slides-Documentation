---
title: Gestire i workbook dei grafici nelle presentazioni su Android
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/androidjava/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dei dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Android via Java: gestisci facilmente i workbook dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di workbook, utilizzare le celle del workbook come etichette di dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Il documento tratta anche l'uso di workbook esterni come fonti di dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

Per le celle del workbook che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/androidjava/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee delle modalità di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) per controllare se un grafico traccia i dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili che quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra le righe o le colonne del foglio.

Scarica [hidden-source-data.pptx](hidden-source-data.pptx) e posizionalo nella directory di lavoro. La sua prima diapositiva contiene un grafico a colonne come prima forma. Il foglio di lavoro incorporato, `Sheet1`, contiene l'intervallo di origine seguente, `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono comunque dei valori.

| Riga del foglio | A: Mese | B: Vendita al dettaglio | C: All'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) e leggi [IChartDataCell.isHidden](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) per verificare il loro stato di nascondimento. Questo metodo restituisce lo stato di nascondimento senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l'esempio stampa `false`, `true` e `true` rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l'impostazione di tracciamento: conserva il workbook incorporato con [readWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e ricaricalo con [writeWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Quando si includono tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per ripristinare l'intervallo completo, inclusa la categoria di febbraio nascosta. Modificare semplicemente il flag non è sufficiente per aggiornare i dati del grafico memorizzati nella cache e le etichette delle categorie di questo esempio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Aggiorna i dati del grafico dal workbook incorporato.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

L'esempio salva `hidden_cells_true.pptx` con solo i valori di Vendita al dettaglio visibili (10 e 20), e `hidden_cells_false.pptx` con tutti e sei i valori. Le immagini sotto illustrano le due modalità di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambi i workbook incorporati.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di Vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di Vendita al dettaglio e All'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/androidjava/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Leggere e scrivere dati del grafico da un workbook**

Aspose.Slides for Android tramite Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile all'origine.

Questo esempio apre `chart.pptx`, che deve contenere un grafico come prima forma nella sua prima diapositiva. Legge il workbook incorporato in un array di byte, cancella le serie e le categorie esistenti e riscrive lo stesso workbook. Le modifiche rimangono in memoria; l'esempio non salva la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Convalidare il layout del grafico dopo la modifica del workbook**

Quando si sostituisce un workbook incorporato con uno modificato, il grafico conserva le sue collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [IChart.validateChartLayout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#validateChartLayout--) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere il workbook aggiornato nel grafico. Questo esempio richiede `chart.pptx` con un grafico come prima forma nella sua prima diapositiva. Il commento indica dove avverrebbe la modifica del workbook; l'esempio eseguibile scrive nuovamente il workbook originale e convalida il layout in memoria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifica i byte del workbook qui, ad esempio usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che il workbook venga riscritto. Ricostruisci eventuali mappature di serie e categorie necessarie per il workbook aggiornato prima di utilizzare il grafico.

## **Impostare una cella del workbook come etichetta dei dati del grafico**

È possibile utilizzare il testo delle celle del workbook come etichette dei dati del grafico. I passaggi seguenti mostrano come collegare le etichette in un grafico a bolle alle celle del suo workbook dati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Accedi alla prima diapositiva tramite il suo indice zero-based.
1. Aggiungi un grafico a bolle con dati predefiniti.
1. Accedi alle serie del grafico.
1. Imposta la cella del workbook come etichetta dei dati.
1. Salva la presentazione.

Questo esempio apre `chart2.pptx`, che deve contenere almeno una diapositiva, e aggiunge un grafico a bolle con dati predefiniti. Utilizza le celle A10:A12 nel foglio di lavoro 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva il risultato in `resultchart.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestire i fogli di lavoro**

Il metodo [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fornisce l'accesso ai fogli di lavoro in un workbook del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro sulla console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Specificare il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie utilizzando diverse origini dati. Il primo nome utilizza una stringa letterale; il secondo utilizza la cella C1 nel foglio di lavoro 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/datasourcetype/) seleziona la sorgente per ciascun nome. Il risultato viene salvato in `pres.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rilevare formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato di workbook Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) su [IChartData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di `sample.pptx`, salta le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con un workbook .xlsb incorporato.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Leggi o modifica i dati del workbook del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook esterno**

Aspose.Slides supporta l'uso di workbook esterni come fonte di dati per i grafici.

### **Creare un workbook esterno**

Usa [readWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e [setExternalWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) per esportare un workbook di grafico incorporato in un file e collegare il grafico a quel workbook esterno.

Questo esempio crea un grafico a torta con dati predefiniti, scrive il suo workbook in `externalWorkbook1.xlsx` e completa la scrittura del file prima di assegnare il file come fonte dei dati del grafico. Salva la presentazione collegata in `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Impostare un workbook esterno**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), è possibile assegnare un workbook esterno a un grafico come sua fonte di dati. Questo metodo può anche essere usato per aggiornare il percorso al workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook archiviati in posizioni remote o risorse, è comunque possibile utilizzare tali workbook come fonte di dati esterna. Se viene fornito un percorso relativo per un workbook esterno, viene automaticamente convertito in un percorso completo.

Questo esempio richiede `externalWorkbook.xlsx` nella directory di lavoro. Il suo foglio di lavoro chiamato `Sheet1` deve contenere un nome di serie in B1, i nomi delle categorie in A2:A4 e valori numerici in B2:B4. L'esempio crea un grafico a torta, collega il workbook e usa [setRange](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per mappare A1:B4 a una serie e tre categorie. Salva il risultato in `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controlla se il workbook viene caricato.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso del workbook. I dati del grafico non vengono caricati o aggiornati dal workbook di destinazione, quindi il workbook può non essere disponibile.  
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

Il seguente esempio assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare il workbook non disponibile.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ottenere il percorso del workbook della fonte dati esterna di un grafico**

Per identificare il workbook collegato a un grafico, verifica innanzitutto se il grafico utilizza una fonte dati esterna. Se è così, puoi recuperare il percorso del workbook seguendo questi passaggi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).  
1. Accedi alla prima diapositiva tramite il suo indice zero-based.  
1. Verifica che la prima forma sia un grafico.  
1. Leggi il tipo di origine dati del grafico.  
1. Se l'origine è un workbook esterno, leggi il suo percorso.

Questo esempio apre `externalWorkbook.pptx`, creato nell'esempio precedente, e ispeziona la prima forma nella prima diapositiva. Se si tratta di un grafico collegato a un workbook esterno, l'esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) sulla console. Successivamente salva una copia della presentazione in `Result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Modificare i dati del grafico**

È possibile modificare i dati nei workbook esterni allo stesso modo in cui si apportano modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un'eccezione.

Questo esempio richiede `presentation.pptx` con un grafico come prima forma nella prima diapositiva e un workbook esterno accessibile. Imposta il valore basato sulla cella del primo punto dati nella prima serie a 100 e salva la presentazione in `presentation_out.pptx`. Modificare i valori delle celle può aggiornare il file XLSX locale collegato, quindi utilizza una copia se devi preservare il workbook originale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperare un workbook dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e imposta [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) su `true` prima di aprire la presentazione.

Il seguente esempio Java apre `presentation.pptx`, la cui prima forma nella prima diapositiva deve essere un grafico che fa riferimento a un workbook esterno non disponibile, e accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leggi o modifica i dati del workbook recuperato qui.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se il workbook esterno non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilita il recupero solo quando l'uso dei dati del grafico nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e un [path to an external workbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se la sorgente è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni, e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare il workbook potrebbe richiedere l'aggiornamento del collegamento.

**Posso utilizzare i workbook ubicati su risorse/condivisioni di rete?**

Sì, tali workbook possono essere utilizzati come fonte di dati esterna. Tuttavia, la modifica di workbook remoti direttamente da Aspose.Slides non è supportata: possono solo essere utilizzati come sorgente.

**Aspose.Slides sovrascrive l'XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia del workbook se l'originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.