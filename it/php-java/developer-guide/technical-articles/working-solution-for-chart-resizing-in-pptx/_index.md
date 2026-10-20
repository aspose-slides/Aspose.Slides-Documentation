---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento grafico
- grafico Excel
- oggetto OLE
- incorpora grafico
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Correggi il ridimensionamento inaspettato dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per PHP via Java. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del frame OLE."
---
## **Panoramica**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando i componenti Aspose possono cambiare dimensione dopo la prima attivazione. Ciò può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché avviene il ridimensionamento e mostra come evitarlo facendo corrispondere le dimensioni fisse del grafico al frame OLE.

Nella [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per PHP via Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per PHP via Java. Per affrontare il [problema dell'anteprima dell'oggetto](/slides/it/php-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro attivata. La dimensione del frame OLE cambia quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Cause del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel cerca di mantenere quando l'oggetto viene attivato per la prima volta. Il frame OLE sulla diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro Excel è attivata, Excel e PowerPoint negoziano la dimensione dell'oggetto per mantenere le proporzioni come parte del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il frame OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere la dimensione del grafico al frame OLE sulla diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells per PHP via Java e Aspose.Slides per PHP via Java. Configura entrambi i prodotti con la stessa istanza di PHP/Java Bridge, carica entrambi i wrapper PHP e rendi entrambe le librerie Java disponibili per il bridge. Non sono necessari file di input. Crea un semplice grafico a colonne su un foglio di grafico attivo e incorpora la cartella di lavoro in formato XLS. Nessuna immagine di anteprima del grafico è assegnata; il grafico diventa visibile quando l'oggetto OLE è attivato in PowerPoint.

L'esempio crea una nuova presentazione con un frame OLE di 9.5 × 4 pollici posizionato a 0.5 pollici dal bordo sinistro e 1 pollice dall'alto. Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice). Per una presentazione esistente, vedi [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) su false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni di [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) tramite [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) e [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), convertendo i punti in pixel usando 96 pixel per pollice: un frame di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) sul valore CUSTOM di [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). L'esempio incorpora la cartella di lavoro con [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva una presentazione con un frame OLE di 9.5 × 4 pollici.

I risultati numerici Java sono convertiti con `java_values` prima di essere usati come indici PHP. I byte della cartella di lavoro rimangono in un array di byte Java quando vengono passati a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
        $width = 684; // 9,5 pollici.
        $height = 288; // 4 pollici.

        $chart->setSizeWithWindow(false);
        // Converti i punti in pixel del grafico usando 96 pixel per pollice.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Usa un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello invece di creare una presentazione vuota.  
2. Verifica che la prima diapositiva contenga almeno tre forme, quindi usa la forma all'indice 2 come segnaposto.  
3. Prendi la larghezza e l'altezza del frame da quella forma invece di usare i valori fissi 684 e 288. Mantieni invariate le calcolazioni delle dimensioni.  
4. Aggiungi il frame OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.  
5. Rimuovi il segnaposto prima di salvare la presentazione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo l'attivazione in PowerPoint?**

Accade perché Excel tenta di ripristinare le dimensioni originali della finestra quando viene attivato per la prima volta, mentre il frame dell'oggetto OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**Come posso mantenere le dimensioni del grafico e del frame OLE coerenti?**

Imposta dimensioni fisse del grafico che corrispondano al frame OLE e utilizza una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni richieste e le conversioni di unità.

**Il fare corrispondere la dimensione della finestra della cartella di lavoro è sufficiente?**

Fare corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile che il frame OLE cambi dimensione dopo l'attivazione. Usa dimensioni fisse del grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**

Sì. Per un modello, usa le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del frame.

**Posso usare questo esempio con grafici creati in altri programmi di fogli di calcolo?**

L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di fogli di calcolo.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)