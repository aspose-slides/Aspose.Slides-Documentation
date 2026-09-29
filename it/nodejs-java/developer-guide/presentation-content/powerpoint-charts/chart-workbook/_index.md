---
title: Gestisci i workbook dei grafici nelle presentazioni usando JavaScript
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/nodejs-java/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri Aspose.Slides per Node.js via Java: gestisci facilmente i workbook dei grafici nei formati PowerPoint e OpenDocument per ottimizzare i dati delle tue presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

Per le celle del workbook che rappresentano dati mancanti, vedi [Controllare la visualizzazione delle celle vuote](/slides/it/nodejs-java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee delle modalità di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o `false` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde o mostra righe o colonne del foglio di lavoro.

Scarica [hidden-source-data.pptx](hidden-source-data.pptx) e posizionalo nella directory di lavoro. La sua prima diapositiva contiene un grafico a colonne come prima forma. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo sorgente `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono comunque valori.

| RIGA FOGLIO DI LAVORO | A: Mese | B: Retail | C: Wholesale (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (riga nascosta) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Accedi alle celle di origine tramite [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) e leggi [ChartDataCell.isHidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdatacell/#isHidden) per ispezionare lo stato di nascondimento. Questo metodo segnala lo stato senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver cambiato l’impostazione di tracciamento: conserva il workbook incorporato con [readWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e ricaricalo con [writeWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Quando includi tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#setRange) per ripristinare l’intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati nella cache di questo esempio né le etichette delle categorie. L’esempio converte il buffer Node.js restituito in un array di byte Java prima di passarlo al metodo di scrittura.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Aggiorna i dati del grafico dal workbook incorporato.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

L’esempio salva `hidden_cells_true.pptx` con solo i valori Retail visibili (10 e 20), e `hidden_cells_false.pptx` con tutti e sei i valori. Le immagini sotto illustrano le due modalità di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambi i workbook incorporati.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori Retail 10 e 20 per gennaio e marzo.](hidden_cells_True.png) | ![Tutte le celle: valori Retail e Wholesale per gennaio, febbraio e marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/nodejs-java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Leggere e scrivere dati del grafico da un workbook**

Aspose.Slides for Node.js via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella di origine.

Questo esempio apre `chart.pptx`, che deve contenere un grafico come prima forma della sua prima diapositiva. Legge il workbook incorporato in un array di byte, cancella le serie e le categorie esistenti, e riscrive lo stesso workbook. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Convalidare il layout del grafico dopo la modifica del workbook**

Quando sostituisci un workbook incorporato con uno modificato, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può far fallire [Chart.validateChartLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#validateChartLayout) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere nuovamente il workbook aggiornato nel grafico. Questo esempio richiede `chart.pptx` con un grafico come prima forma della sua prima diapositiva. Il commento indica dove avverrebbe la modifica del workbook; l’esempio eseguibile riscrive il workbook originale e convalida il layout in memoria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Modifica i byte del workbook qui, ad esempio, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

La cancellazione delle collezioni rimuove i riferimenti a dati obsoleti prima che il workbook venga riscritto. Ricostruisci eventuali mappature di serie e categorie necessarie per il workbook aggiornato prima di utilizzare il grafico.

## **Impostare una cella del workbook come etichetta dati del grafico**

Puoi usare il testo delle celle del workbook come etichette dati del grafico. I passaggi seguenti mostrano come collegare le etichette in un grafico a bolle alle celle del suo workbook dati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva mediante il suo indice basato su zero.
3. Aggiungi un grafico a bolle con dati predefiniti.
4. Accedi alla serie del grafico.
5. Imposta la cella del workbook come etichetta dati.
6. Salva la presentazione.

Questo esempio apre `chart2.pptx`, che deve contenere almeno una diapositiva, e aggiunge un grafico a bolle con dati predefiniti. Usa le celle A10:A12 sul foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva il risultato in `resultchart.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestire i fogli di lavoro**

Il metodo [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) consente l’accesso ai fogli di lavoro in un workbook di grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro sulla console.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Specificare il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse origini dati. Il primo nome utilizza un literal string; il secondo utilizza la cella C1 sul foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. Il risultato è salvato in `pres.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rilevare i formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato workbook binario Excel (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) su [ChartData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di `sample.pptx`, salta le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con un workbook .xlsb incorporato.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Leggi o modifica i dati del workbook del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook esterno**

Aspose.Slides supporta l’utilizzo di workbook esterni come origine dati per i grafici.

### **Creare un workbook esterno**

Usa [readWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) per esportare un workbook di grafico incorporato in un file e collegare il grafico a quel workbook esterno.

Questo esempio crea un grafico a torta con dati predefiniti, scrive il suo workbook in `externalWorkbook1.xlsx`, e completa la scrittura del file prima di assegnare il file come origine dati del grafico. Salva la presentazione collegata in `externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Impostare un workbook esterno**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), puoi assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso del workbook esterno (se quest’ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook archiviati in posizioni remote o risorse, è comunque possibile usarli come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, viene convertito automaticamente in un percorso assoluto.

Questo esempio richiede `externalWorkbook.xlsx` nella directory di lavoro. Il suo foglio di lavoro denominato `Sheet1` deve contenere un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega il workbook e usa [setRange](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#setRange) per mappare A1:B4 a una serie e tre categorie. Salva il risultato in `Presentation_with_externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) controlla se il workbook viene caricato.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso del workbook. I dati del grafico non sono caricati né aggiornati dal workbook di destinazione, quindi il workbook può risultare non disponibile.
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

Il seguente esempio assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare il workbook non disponibile.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ottenere il percorso del workbook sorgente dati esterno di un grafico**

Per identificare il workbook collegato a un grafico, verifica prima se il grafico utilizza una fonte dati esterna. Se lo fa, puoi recuperare il percorso del workbook seguendo questi passaggi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla prima diapositiva mediante il suo indice basato su zero.
3. Verifica che la prima forma sia un grafico.
4. Leggi il tipo di origine dati del grafico.
5. Se l’origine è un workbook esterno, leggi il suo percorso.

Questo esempio apre `externalWorkbook.pptx`, creato nell’esempio precedente, e ispeziona la prima forma della prima diapositiva. Se è un grafico collegato a un workbook esterno, l’esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) sulla console. Poi salva una copia della presentazione in `Result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Modificare i dati del grafico**

Puoi modificare i dati nei workbook esterni allo stesso modo in cui apporti modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene sollevata un’eccezione.

Questo esempio richiede `presentation.pptx` con un grafico come prima forma della prima diapositiva e un workbook esterno accessibile. Imposta il valore basato sulla cella del primo punto dati della prima serie a 100 e salva la presentazione in `presentation_out.pptx`. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare il workbook originale.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperare un workbook dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) e imposta [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) su `true` prima di aprire la presentazione.

Il seguente esempio JavaScript apre `presentation.pptx`, la cui prima forma della prima diapositiva deve essere un grafico che fa riferimento a un workbook esterno non disponibile, e accede ai dati recuperati tramite [Chart.getChartData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leggi o modifica i dati del workbook recuperato qui.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se il workbook esterno non è disponibile e il recupero è disabilitato, Aspose.Slides genera un’eccezione. Abilita il recupero solo quando l’uso dei dati del grafico nella cache è un’alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getDataSourceType) e un [path to an external workbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); se l’origine è un workbook esterno, puoi leggere il percorso completo per assicurarti che venga utilizzato un file esterno.

**I percorsi relativi ai workbook esterni sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento del workbook potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare workbook situati su risorse o condivisioni di rete?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata: possono essere usati solo come fonte.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia del workbook se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password quando crea il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio con [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file si rifletterà in ciascun grafico al successivo caricamento dei dati.