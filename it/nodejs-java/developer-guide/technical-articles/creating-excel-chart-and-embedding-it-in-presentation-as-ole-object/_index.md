---
title: Crea grafici Excel e incorporali in presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- incorporare grafico
- oggetto OLE
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per Node.js tramite Java e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne di Excel con Aspose.Cells per Node.js tramite Java e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per Node.js tramite Java. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un’anteprima PNG separata visualizza il grafico sulla diapositiva prima che l’oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un’applicazione desktop che supporti l’attivazione OLE e un’installazione compatibile di Excel.

## **Prerequisiti**

Installa i pacchetti Node.js `aspose.cells`, `aspose.slides.via.java` e `java`. Esegui gli esempi come due script CommonJS in processi Node.js separati: prima `create-chart.js`, poi `embed-chart.js`, usando la stessa cartella di lavoro. Entrambi i pacchetti Aspose inizializzano il bridge Java durante il caricamento, quindi questi esempi li mantengono in processi separati. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non è necessaria alcuna cartella di lavoro o immagine esistente. Il primo script crea `ChartWorkbook.xlsx` e `ChartPreview.png`; il secondo legge quei file e scrive `OutputChart.pptx` nella cartella di lavoro corrente. Applica le licenze per entrambi i prodotti quando li esegui fuori dalla modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio di dati e un foglio grafico.  
1. Rendi attivo il foglio grafico in modo che la cartella di lavoro si apra sul grafico.  
1. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e rendi il grafico in PNG.  
1. Salva la cartella di lavoro come XLSX e incorpora i suoi byte in una diapositiva in un processo Node.js separato.  
1. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) utilizza indici di riga e colonna iniziali/finali basati su zero. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) richiede invece la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio usa l'indice di riga 55 e l'indice di colonna 25 come limiti in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza punti. L'esempio lo adatta all'interno della diapositiva e lo centra mantenendo le proporzioni del PNG, invece di allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

Salva il primo esempio come `create-chart.js`. Popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima che la cartella di lavoro venga salvata.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Renderizza l'anteprima del grafico e serializza separatamente la cartella di lavoro modificabile.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Tutto il lavoro sincrono è completato; interrompi il processo del bridge Java.
process.exit(0);
```

Salva il seguente esempio come `embed-chart.js`. Eseguilo dopo che `create-chart.js` ha creato entrambi i file di input. Centra il riquadro OLE e preserva le proporzioni dell'immagine di anteprima.

Il secondo script incorpora la cartella di lavoro salvata e utilizza il PNG come sua anteprima. La cartella di lavoro è salvata esplicitamente come XLSX, corrispondente all’estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). Il PNG è caricato direttamente dai suoi byte senza una conversione intermedia in bitmap. Il bridge Java richiede array di byte Java espliciti per l’immagine e i dati della cartella di lavoro, e valori float Java per le coordinate del riquadro della diapositiva. Assegnarlo tramite [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) sostituisce il segnaposto OLE predefinito.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Adatta l'anteprima all'interno della diapositiva senza modificare le proporzioni.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Tutto il lavoro sincrono è completato; interrompi il processo del bridge Java.
process.exit(0);
```

## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un’anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne conserva le proporzioni.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In un ambiente desktop PowerPoint compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L’attivazione e la modifica dipendono dal supporto OLE dell’applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima sulla diapositiva sono contenuti separati. Fornisci un'immagine del grafico affinché la diapositiva mostri il grafico invece del segnaposto predefinito “EMBEDDED OLE OBJECT”. Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

Considera l'anteprima come un'istantanea. Quando aggiorni i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e utilizza `xls` come estensione dei dati incorporati. L’estensione deve corrispondere al formato reale della cartella di lavoro; cambiare solo l’estensione non converte i dati.

**Perché l'oggetto può cambiare dimensione dopo l’attivazione?**

L’applicazione host può aggiornare la presentazione dell’oggetto OLE quando attiva la cartella di lavoro. L’intervallo di visualizzazione OLE della cartella di lavoro e le dimensioni del riquadro della diapositiva contano entrambe. Vedi [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/java/working-solution-for-chart-resizing-in-pptx/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento del grafico in PPTX](/slides/it/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)