---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorpora grafico
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Correggi il ridimensionamento imprevisto dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Node.js via Java. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del riquadro OLE."
---
## **Panoramica**

I grafici Excel incorporati come oggetti OLE in presentazioni PowerPoint usando i componenti Aspose possono cambiare dimensione dopo la prima attivazione. Ciò può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché si verifica il ridimensionamento e mostra come evitarlo facendo corrispondere le dimensioni fisse del grafico al riquadro OLE.

In [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells for Node.js via Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides for Node.js via Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al riquadro OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul riquadro OLE che mostra l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva cliccando al di fuori della cartella di lavoro attivata. Le dimensioni del riquadro OLE cambiano quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del riquadro OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel tenta di conservare quando l'oggetto viene attivato per la prima volta. Il riquadro OLE sulla diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro Excel è attivata, Excel e PowerPoint negoziano la dimensione dell'oggetto per mantenere le proporzioni come parte del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il riquadro OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere le dimensioni del grafico al riquadro OLE sulla diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells for Node.js via Java e Aspose.Slides for Node.js via Java. Installa i pacchetti Node.js `aspose.cells`, `aspose.slides.via.java` e `java`. Esegui i due script CommonJS di seguito in processi Node.js separati, utilizzando la stessa directory di lavoro, poiché entrambi i pacchetti Aspose inizializzano il bridge Java durante il caricamento. Crea un semplice grafico a colonne su un foglio di grafico attivo e incorpora la cartella di lavoro in formato XLS. Non viene assegnata alcuna immagine di anteprima del grafico; il grafico diventa visibile quando l'oggetto OLE viene attivato in PowerPoint.

L'esempio crea una nuova presentazione con un riquadro OLE di 9,5 × 4 pollici posizionato a 0,5 pollici dal bordo sinistro e a 1 pollice dalla parte superiore. Le coordinate e le dimensioni della diapositiva sono espresse in punti (72 punti per pollice). Per una presentazione esistente, vedere [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) a false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni di [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) tramite [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) e [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), convertendo i punti in pixel usando 96 pixel per pollice: un riquadro di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) sul valore CUSTOM di `PrintSizeType`. L'esempio incorpora la cartella di lavoro con [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva una presentazione con un riquadro OLE di 9,5 × 4 pollici.

Salva questo primo script come `create-fixed-chart.js`. Crea `chart-fixed-size.xls` con un grafico di 912 × 384 pixel, corrispondente al riquadro di 684 × 288 punti utilizzato dal secondo script. Non è necessaria alcuna cartella di lavoro di input.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Corrispondi le dimensioni del riquadro OLE in punti (72 punti per pollice).
    const width = 684; // 9,5 pollici.
    const height = 288; // 4 pollici.

    chart.setSizeWithWindow(false);
    // Converti i punti in pixel del grafico usando 96 pixel per pollice.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Tutto il lavoro sincrono è completato; arresta il processo del bridge Java.
process.exit(0);
```

Salva il secondo script come `embed-fixed-chart.js` ed eseguilo dopo `create-fixed-chart.js`. Legge la cartella di lavoro XLS generata e salva `chart-fixed-size.pptx`. Il bridge Java richiede un array di byte Java esplicito per i dati della cartella di lavoro e valori float Java per le coordinate e le dimensioni del riquadro. L'estensione `xls` corrisponde al formato di salvataggio della cartella di lavoro.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
    const width = 684; // 9,5 pollici.
    const height = 288; // 4 pollici.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Tutto il lavoro sincrono è completato; arresta il processo del bridge Java.
process.exit(0);
```

## **Usare un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello invece di creare una presentazione vuota.  
1. Verifica che la prima diapositiva contenga almeno tre forme, quindi usa la forma all'indice 2 come segnaposto.  
1. Prendi la larghezza e l'altezza del riquadro da quella forma invece di usare i valori fissi 684 e 288. Usa le stesse dimensioni nello script di creazione della cartella di lavoro, mantenendo inalterati i calcoli delle dimensioni, e rigenera la cartella di lavoro XLS prima di incorporarla.  
1. Aggiungi il riquadro OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.  
1. Rimuovi il segnaposto prima di salvare la presentazione.

## **Domande frequenti**

**Perché il mio grafico Excel incorporato cambia dimensione dopo l'attivazione in PowerPoint?**

Ciò avviene perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il riquadro dell'oggetto OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto di aspetto, il che può causare il ridimensionamento.

**Come posso mantenere le dimensioni del grafico e del riquadro OLE coerenti?**

Imposta dimensioni fisse per il grafico che corrispondano al riquadro OLE e utilizza una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni necessarie e le conversioni di unità.

**È sufficiente far corrispondere la dimensione della finestra della cartella di lavoro?**

Far corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile il cambiamento di dimensione del riquadro OLE dopo l'attivazione. Usa dimensioni fisse del grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**

Sì. Per un modello, utilizza le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del riquadro.

**Posso utilizzare questo esempio con grafici creati in altri programmi di foglio di calcolo?**

L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di foglio di calcolo.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)