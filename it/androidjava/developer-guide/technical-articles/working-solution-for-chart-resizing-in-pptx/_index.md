---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento inatteso dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Android via Java. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del frame OLE."
---
## **Panoramica**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando i componenti Aspose possono cambiare dimensione dopo la prima attivazione. Ciò può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché si verifica il ridimensionamento e mostra come prevenirlo facendo corrispondere le dimensioni fisse del grafico al frame OLE.

In [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per Android tramite Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per Android tramite Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/androidjava/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro attivata. La dimensione del frame OLE cambia quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Cause del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel cerca di mantenere quando l'oggetto viene attivato per la prima volta. Il frame OLE sulla diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano la dimensione dell'oggetto per mantenere le sue proporzioni come parte del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il frame OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere la dimensione del grafico al frame OLE sulla diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells per Android tramite Java e Aspose.Slides per Android tramite Java. Crea un semplice grafico a colonne su un foglio di grafico attivo e incorpora la cartella di lavoro in formato XLS. Chiama `FixedChartSize.createPresentation(getFilesDir())` da un'attivita' Android per salvare l'output nella directory dei file interni dell'applicazione. L'attivazione OLE richiede PowerPoint desktop e un'installazione compatibile di Excel. Non viene assegnata alcuna immagine di anteprima del grafico; il grafico diventa visibile quando l'oggetto OLE viene attivato in PowerPoint.

L'esempio crea una nuova presentazione con un frame OLE di 9,5 × 4 pollici posizionato a 0,5 pollici dal bordo sinistro e a 1 pollice dalla parte superiore. Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice). Per una presentazione esistente, vedere [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) a false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni di [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) tramite [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) e [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), convertendo i punti in pixel usando 96 pixel per pollice: un frame di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) al valore CUSTOM di [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). L'esempio incorpora la cartella di lavoro con [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) e salva una presentazione con un frame OLE di 9,5 × 4 pollici.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
                    float width = 684f; // 9,5 pollici.
                    float height = 288f; // 4 pollici.

                    chart.setSizeWithWindow(false);
                    // Converti i punti in pixel del grafico usando 96 pixel per pollice.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Usa un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello anziche' creare una presentazione vuota.
1. Verifica che la prima diapositiva contenga almeno tre forme, quindi usa la forma all'indice 2 come segnaposto.
1. Prendi la larghezza e l'altezza del frame da quella forma invece di utilizzare i valori fissi 684 e 288. Mantieni inalterati i calcoli delle dimensioni.
1. Aggiungi il frame OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.
1. Rimuovi il segnaposto prima di salvare la presentazione.

## **Domande frequenti**

**Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**

Questo accade perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può provocare il ridimensionamento.

**Come posso mantenere coerenti le dimensioni del grafico e del frame OLE?**

Imposta dimensioni fisse per il grafico che corrispondano al frame OLE e usa una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni richieste e le conversioni di unità.

**E' sufficiente far corrispondere la dimensione della finestra della cartella di lavoro?**

Far corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile al frame OLE di cambiare dimensione dopo l'attivazione. Usa dimensioni fisse per il grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**

Si. Per un modello, usa le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del frame.

**Posso usare questo esempio con grafici creati in altri programmi di fogli di calcolo?**

L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di fogli di calcolo.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)