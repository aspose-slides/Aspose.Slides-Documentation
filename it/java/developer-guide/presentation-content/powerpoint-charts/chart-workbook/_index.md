---
title: Gestisci le cartelle di lavoro dei grafici nelle presentazioni usando Java
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/java/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dei dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Java: gestisci facilmente le cartelle di lavoro dei grafici in formato PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite i flussi di cartella di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Tratta anche l'utilizzo di cartelle di lavoro esterne come fonti dati per i grafici. Gli esempi mostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedi [Controlla la visualizzazione delle celle vuote](/slides/it/java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto con grafico a linee delle modalità di visualizzazione disponibili.

## **Includi dati da righe e colonne nascoste**

Utilizza [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla la visualizzazione del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

Scarica [hidden-source-data.pptx](hidden-source-data.pptx) e posizionalo nella directory di lavoro. La sua prima diapositiva contiene un grafico a colonne come prima forma. Il foglio di lavoro incorporato, `Sheet1`, contiene l'intervallo di origine seguente, `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Worksheet row | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) e leggi [IChartDataCell.isHidden](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdatacell/#isHidden--) per ispezionare il loro stato di nascondimento. Questo metodo restituisce lo stato di nascondimento senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l'esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l'impostazione di tracciatura: conserva la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e ricaricala con [writeWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Quando si includono tutte le celle, utilizza anche [setRange](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per ripristinare l'intervallo completo, inclusa la categoria di febbraio nascosta. Modificare semplicemente il flag non è sufficiente per aggiornare i dati del grafico memorizzati nella cache e le etichette delle categorie di questo esempio.

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

            // Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
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

L'esempio salva `hidden_cells_true.pptx` con solo i valori di vendita al dettaglio visibili (10 e 20), e `hidden_cells_false.pptx` con tutti e sei i valori. Le immagini sotto illustrano i due modi di tracciatura. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di vendita al dettaglio e all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controlla la visualizzazione delle celle vuote](/slides/it/java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Leggi e scrivi dati del grafico da una cartella di lavoro**

Aspose.Slides per Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile alla sorgente.

Questo esempio apre `chart.pptx`, che deve contenere un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, cancella le serie e le categorie esistenti, e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l'esempio non salva la presentazione.

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

### **Convalida layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può far fallire [IChart.validateChartLayout](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#validateChartLayout--) con un errore di indice fuori dall'intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio richiede `chart.pptx` con un grafico come prima forma nella sua prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l'esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

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

        // Modifica i byte della cartella di lavoro qui, ad esempio, usando Aspose.Cells.

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

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappature di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Imposta una cella della cartella di lavoro come etichetta dei dati del grafico**

Puoi usare il testo delle celle della cartella di lavoro come etichette dei dati del grafico. I passaggi seguenti mostrano come collegare le etichette in un grafico a bolle alle celle del suo foglio di dati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) .
2. Accedi alla prima diapositiva tramite il suo indice basato su zero.
3. Aggiungi un grafico a bolle con dati predefiniti.
4. Accedi alle serie del grafico.
5. Imposta la cella della cartella di lavoro come etichetta dei dati.
6. Salva la presentazione.

Questo esempio apre `chart2.pptx`, che deve contenere almeno una diapositiva, e aggiunge un grafico a bolle con dati predefiniti. Usa le celle A10:A12 nel foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva il risultato in `resultchart.pptx`.

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

## **Gestisci fogli di lavoro**

Il metodo [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fornisce l'accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro nella console.

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

## **Specifica il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse fonti dati. Il primo nome usa un literal string; il secondo usa la cella C1 nel foglio 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/it/java/com.aspose.slides/datasourcetype/) seleziona la sorgente per ciascun nome. Il risultato è salvato in `pres.pptx`.

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

## **Rileva formati di cartelle di lavoro incorporate non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) su [IChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/java/com.aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di `sample.pptx`, ignora le forme non grafico e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

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

        // Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come fonte dati per i grafici.

### **Crea una cartella di lavoro esterna**

Usa [readWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [setExternalWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) per esportare una cartella di lavoro di grafico incorporata in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti, scrive la sua cartella di lavoro in `externalWorkbook1.xlsx` e completa la scrittura del file prima di assegnare il file come fonte dati del grafico. Salva la presentazione collegata in `externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Imposta una cartella di lavoro esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), puoi assegnare una cartella di lavoro esterna a un grafico come sua fonte dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati in cartelle di lavoro archiviate in posizioni o risorse remote, è comunque possibile usarle come fonte dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso assoluto.

Questo esempio richiede `externalWorkbook.xlsx` nella directory di lavoro. Il suo foglio di lavoro denominato `Sheet1` deve contenere un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L'esempio crea un grafico a torta, collega la cartella di lavoro e usa [setRange](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per mappare A1:B4 a una serie e tre categorie. Salva il risultato in `Presentation_with_externalWorkbook.pptx`.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controlla se la cartella di lavoro viene caricata.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

Il seguente esempio assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

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

### **Ottieni il percorso della cartella di lavoro della fonte dati esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, prima verifica se il grafico utilizza una fonte dati esterna. Se lo fa, puoi recuperare il percorso della cartella di lavoro seguendo questi passaggi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) .
2. Accedi alla prima diapositiva tramite il suo indice basato su zero.
3. Verifica che la prima forma sia un grafico.
4. Leggi il tipo di fonte dati del grafico.
5. Se la fonte è una cartella di lavoro esterna, leggi il suo percorso.

Questo esempio apre `externalWorkbook.pptx`, creato nell'esempio precedente, e ispeziona la prima forma nella prima diapositiva. Se è un grafico collegato a una cartella di lavoro esterna, l'esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) nella console. Quindi salva una copia della presentazione in `Result.pptx`.

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

### **Modifica dati del grafico**

Puoi modificare i dati in cartelle di lavoro esterne nello stesso modo in cui apporti modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo esempio richiede `presentation.pptx` con un grafico come prima forma nella sua prima diapositiva e una cartella di lavoro esterna accessibile. Imposta il valore basato su cella del primo punto dati nella prima serie a 100 e salva la presentazione in `presentation_out.pptx`. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare la cartella di lavoro originale.

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

### **Recupera una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e imposta [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) su `true` prima di aprire la presentazione.

Il seguente esempio Java apre `presentation.pptx`, la cui prima forma nella prima diapositiva deve essere un grafico che fa riferimento a una cartella di lavoro esterna non disponibile, e accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Leggi o modifica i dati della cartella di lavoro recuperata qui.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se la cartella di lavoro esterna è non disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilita il recupero solo quando l'uso dei dati del grafico nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--) e un [path to an external workbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento della cartella di lavoro potrebbe richiedere l'aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse/condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come fonte dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere usate solo come fonte.

**Aspose.Slides sovrascrive l'XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l'originale deve rimanere invariato.

** Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.