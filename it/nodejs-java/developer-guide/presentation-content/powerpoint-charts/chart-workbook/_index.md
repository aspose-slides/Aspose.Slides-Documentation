---
title: Gestisci le Cartelle di Lavoro dei Grafici nelle Presentazioni con JavaScript
linktitle: Cartella di Lavoro del Grafico
type: docs
weight: 70
url: /it/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri Aspose.Slides per Node.js via Java: gestisci facilmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come fonti di dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/nodejs-java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei diversi modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) per controllare se un grafico traccia dati da righe e colonne di foglio di lavoro nascoste. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili che quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne di foglio di lavoro.

La [sample presentation](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella sua prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo di origine `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) e leggi [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) per ispezionare il loro stato di visibilità. Questo metodo restituisce lo stato di visibilità senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l’impostazione di tracciamento: mantieni la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e ricaricala con [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). Quando includi tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) per ripristinare l’intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati in cache di questo esempio e le etichette di categoria. L’esempio converte il buffer Node.js restituito in un array di byte Java prima di passarlo al metodo di scrittura.

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

L’esempio salva due versioni della presentazione: una con solo i valori di Vendita al dettaglio visibili (10 e 20) e un’altra con tutti e sei i valori. Le immagini sotto illustrano i due modi di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori Retail 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori Retail e Wholesale per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) controlla come vengono visualizzati i valori mancanti; non include né esclude dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/nodejs-java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l'intervallo di dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, ispeziona gli intervalli di origine per identificare quali celle di foglio di lavoro utilizza ogni grafico. Il metodo [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) restituisce l’intervallo di dati corrente come formula qualificata dal foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio di lavoro, `!` lo separa dall’intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusi. I simboli del dollaro indicano riferimenti assoluti di riga e colonna.

Il metodo legge l’intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, genera `InvalidOperationException`. Per ulteriori informazioni, vedere la [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Questo esempio apre una presentazione e controlla le forme direttamente su ogni diapositiva alla ricerca di grafici. Stampa il nome di ciascun grafico e il suo intervallo di origine. Se un grafico non usa una cartella di lavoro, stampa un messaggio e continua con il grafico successivo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides for Node.js via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati allo stesso modo o avere una struttura simile a quella di origine.

Questo esempio usa una presentazione con un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, elimina le serie e le categorie esistenti e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

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

### **Validare il layout del grafico dopo la modifica della cartella di lavoro**

Quando sostituisci una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento evidenzia dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile riscrive la cartella di lavoro originale e valida il layout in memoria.

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

Cancellare le collezioni rimuove riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappature di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare formati numerici personalizzati per le celle della cartella di lavoro**

Usa [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) per controllare come appaiono i valori numerici nella cartella di lavoro incorporata del grafico. Per esempio, un report potrebbe necessitare di un tasso di conversione visualizzato come percentuale con quattro decimali e di un coefficiente visualizzato con cinque decimali. Mantieni entrambi i valori numerici affinché rimangano disponibili per i calcoli e il tracciamento del grafico.

Un formato numerico modifica la visualizzazione, non il valore memorizzato. Il formato `0.0000%` visualizza `0.125` come `12.5000%`; non sostituisce il numero memorizzato con `12.5`. Analogamente, `0.00000` visualizza `0.1234567` come `0.12346` senza arrotondare il valore memorizzato. Se il formato personalizzato è una stringa vuota (`""`), viene utilizzato il formato restituito da [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/).

L’esempio seguente crea un grafico a colonne e accede alle sue celle tramite [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). Nel foglio di lavoro 0, B2 contiene il tasso di conversione e C2 contiene il coefficiente. Entrambe le celle forniscono valori al grafico. L’esempio abilita anche le etichette dei valori collegate ai formati di origine.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I formati delle celle della cartella di lavoro sono separati dai formati impostati direttamente sugli assi del grafico o sulle etichette dei dati. In questo esempio, ogni etichetta visualizza il valore della cella di origine perché [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) è impostato su `true` e segue il formato numerico di origine perché [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) è impostato su `true`. Dopo aver salvato e riaperto la presentazione, le etichette mostrano `12.5000%` e `0.12346`, come mostrato sotto. L’asse verticale utilizza il proprio formato numerico, assegnato con [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) come `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) impostato su `false`.

Per formattare un’etichetta dei dati in modo indipendente, imposta il flag di collegamento alla sorgente su `false` e assegna un formato con [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Questo non modifica il formato della cella della cartella di lavoro. Per esempio, un formato etichetta indipendente di `0.00` visualizza il primo valore come `0.13`, mentre B2 continua a mostrare `12.5000%`. Vedi [Chart Data Labels](/slides/it/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) per la formattazione diretta delle etichette.

L’immagine sotto è stata renderizzata dalla presentazione salvata dopo averla riaperta:

![Diagramma a colonne con etichette collegate alla sorgente che mostrano 12.5000% e 0.12346 e un asse numerico formattato in modo indipendente.](custom-cell-formats.png)

## **Impostare una cella della cartella di lavoro come etichetta dati del grafico**

È possibile utilizzare il testo delle celle della cartella di lavoro come etichette dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Usa le celle A10:A12 sul foglio di lavoro 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

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

Il metodo [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) fornisce l’accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ogni foglio di lavoro nella console.

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

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie utilizzando diverse origini dati. Il primo nome utilizza un literal string; il secondo utilizza la cella C1 sul foglio di lavoro 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi di serie aggiornati.

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

## **Rilevare formati di cartelle di lavoro incorporate non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafico e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

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

        // Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l’utilizzo di cartelle di lavoro esterne come fonte di dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) e [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) per esportare una cartella di lavoro di grafico incorporata in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Completa la scrittura del file prima di assegnare la cartella di lavoro esterna come origine dati del grafico, quindi salva la presentazione collegata.

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

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), puoi assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Anche se non è possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile usarle come fonte di dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso completo.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio di lavoro denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e usa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

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

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) controlla se la cartella di lavoro viene caricata.

* Quando `updateChartData` è `false`, solo il percorso della cartella di lavoro viene aggiornato. I dati del grafico non sono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può risultare non disponibile.  
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

L’esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

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

### **Ottenere il percorso della cartella di lavoro sorgente esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica se il grafico utilizza una fonte dati esterna e recupera il suo percorso.

Questo esempio ispeziona la prima forma nella prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se è un grafico collegato a una cartella di lavoro esterna, l’esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) nella console. Quindi salva una copia della presentazione.

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

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si modificano i contenuti delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva e collegato a una cartella di lavoro esterna accessibile. Imposta il valore basato su cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare la cartella di lavoro originale.

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

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), e imposta [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio JavaScript recupera i dati della cartella di lavoro per un grafico che è la prima forma nella prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilita il recupero solo quando l’utilizzo dei dati del grafico in cache è una soluzione accettabile, perché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); se l'origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che sia stato utilizzato un file esterno.

**Sono supportati percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento della cartella di lavoro potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come fonte di dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere usate solo come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Modificare i dati del grafico basati su cella può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file sarà riflesso in ogni grafico al prossimo caricamento dei dati.