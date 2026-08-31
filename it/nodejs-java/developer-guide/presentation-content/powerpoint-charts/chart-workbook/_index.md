---
title: Gestire le Cartelle di Lavoro dei Grafici nelle Presentazioni con JavaScript
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
description: "Scopri Aspose.Slides per Node.js tramite Java: gestisci senza sforzo le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati delle tue presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere Dati del Grafico da una Cartella di Lavoro**

Aspose.Slides fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella della sorgente.

Questo codice JavaScript dimostra un'operazione di esempio:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Convalidare il Layout del Grafico Dopo la Modifica della Cartella di Lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le sue serie e le collezioni di categorie originali. Questa discrepanza può causare il fallimento di [Chart.validateChartLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Chart#validateChartLayout--) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico.

```javascript
// Dopo aver modificato lo stream della cartella di lavoro (ad esempio, usando Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Cancella i riferimenti ai dati esistenti.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

La cancellazione delle collezioni garantisce che la struttura dei dati del grafico sia coerente con la nuova cartella di lavoro, consentendo a `validateChartLayout` di completarsi senza errori.

## **Impostare la Cella della Cartella di Lavoro come Etichetta Dati del Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico a bolle con alcuni dati.
1. Accedere alle serie del grafico.
1. Impostare la cella della cartella di lavoro come etichetta dati.
1. Salvare la presentazione.

Questo codice JavaScript mostra come impostare una cella della cartella di lavoro come etichetta dati del grafico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Istanzia una classe di presentazione che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestire i Fogli di Lavoro**

Questo codice JavaScript dimostra un'operazione in cui il metodo [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) viene utilizzato per accedere a una raccolta di fogli di lavoro:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Specificare il Tipo di Origine Dati**

Questo codice JavaScript mostra come specificare un tipo per un'origine dati:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rilevare Formati di Cartelle di Lavoro Incorporate Non Supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [ChartData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/workbooktype/) per rilevare formati non supportati e ignorare quei grafici.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // La cartella di lavoro incorporata è in formato .xlsb, che non è supportato.
            continue;
        }

        // Leggi o modifica i dati della cartella di lavoro del grafico qui.
    }
} finally {
    presentation.dispose();
}
```

## **Cartella di Lavoro Esterna**

Aspose.Slides supporta cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una Cartella di Lavoro Esterna**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero o rendere esterna una cartella di lavoro interna.

Questo codice JavaScript dimostra il processo di creazione della cartella di lavoro esterna:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream restituisce i byte della cartella di lavoro come Buffer Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Impostare la Cartella di Lavoro Esterna**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Pur non potendo modificare i dati nelle cartelle di lavoro memorizzate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, esso viene convertito automaticamente in un percorso completo.

Questo codice JavaScript mostra come impostare una cartella di lavoro esterna:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Il secondo parametro del metodo `setExternalWorkbook`, `updateChartData`, specifica se la cartella di lavoro Excel verrà caricata o meno.

* Quando `updateChartData` è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro — i dati del grafico non verranno caricati o aggiornati dalla cartella di lavoro di destinazione. È consigliabile usare questa impostazione quando la cartella di lavoro di destinazione non esiste o non è disponibile.
* Quando `updateChartData` è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ottenere il Percorso della Cartella di Lavoro di Origine Dati Esterna del Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Creare un oggetto per la forma del grafico.
1. Creare un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
1. Specificare la condizione pertinente in base al fatto che il tipo di origine sia lo stesso del tipo di origine dati della cartella di lavoro esterna.

Questo codice JavaScript dimostra l'operazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Salva la presentazione
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Modificare i Dati del Grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne nello stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene sollevata un'eccezione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea un'istanza della classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Recuperare una Cartella di Lavoro dalla Cache del Grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Creare [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/), configurarlo con [SpreadsheetOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/spreadsheetoptions/), e chiamare [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `true` prima di aprire la presentazione.

Il seguente esempio JavaScript apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leggi o modifica i dati della cartella di lavoro recuperata qui.
} finally {
    presentation.dispose();
}
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides solleva un'eccezione. Abilitare il recupero solo quando l'uso dei dati del grafico nella cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, esso viene convertito automaticamente in un percorso assoluto. Ciò è comodo per la portabilità del progetto; tuttavia, è necessario sapere che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere utilizzate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata — possono essere usate solo come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/nodejs-java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.