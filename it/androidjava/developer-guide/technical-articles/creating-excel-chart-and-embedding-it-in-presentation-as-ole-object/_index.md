---
title: Crea grafici Excel e incorporali nelle presentazioni come oggetti OLE
type: docs
weight: 30
url: /it/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Grafico Excel
- Incorpora grafico
- Oggetto OLE
- PowerPoint
- Presentazione
- Android
- Java
- Aspose.Slides
description: "Crea un grafico Excel con Aspose.Cells per Android via Java e incorpora la cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per Android via Java, includendo un'anteprima del grafico."
---
## **Panoramica**

Questo articolo mostra come creare un grafico a colonne Excel con Aspose.Cells per Android via Java e incorporare la sua cartella di lavoro in una presentazione PowerPoint con Aspose.Slides per Android via Java. La cartella di lavoro incorporata contiene sia i dati di origine sia il grafico. Un'anteprima PNG separata visualizza il grafico sulla diapositiva prima che l'oggetto OLE venga attivato.

Il risultato è un oggetto Excel incorporato, non un grafico PowerPoint nativo. Modificare la cartella di lavoro tramite OLE richiede un'applicazione desktop che supporti l'attivazione OLE e un'installazione compatibile di Excel.

## **Prerequisiti**

Aggiungi Aspose.Cells per Android via Java e Aspose.Slides per Android via Java alle dipendenze del tuo progetto. Chiama `ExcelChartEmbedding.createPresentation(getFilesDir())` da un'attività Android. Microsoft Office non è necessario per generare la presentazione con queste librerie.

Non sono richiesti file di input: l'esempio crea i dati e il grafico in memoria, quindi scrive `OutputChart.pptx` nella directory dei file interni dell'applicazione. Applica le licenze per entrambi i prodotti quando si esegue al di fuori della modalità di valutazione.

## **Come funziona l'incorporamento**

1. Crea una cartella di lavoro con un foglio dati e un foglio grafico.  
1. Imposta il foglio grafico come attivo affinché la cartella di lavoro si apra sul grafico.  
1. Imposta l'intervallo di visualizzazione OLE della cartella di lavoro e renderizza il grafico in PNG.  
1. Salva la cartella di lavoro come XLSX in memoria e incorpora quei byte in una diapositiva.  
1. Assegna il PNG come anteprima dell'oggetto OLE e salva la presentazione come PPTX.

L'intervallo di visualizzazione della cartella di lavoro e il riquadro sulla diapositiva hanno ruoli diversi. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) accetta indici di riga e colonna di inizio/fine basati su zero. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) invece accetta la riga superiore, la colonna sinistra, la riga inferiore e la colonna destra. L'esempio utilizza l'indice di riga 55 e l'indice di colonna 25 come limiti in basso a destra; questi valori sono scelte di layout, non il numero di righe o colonne di dati.

Il riquadro della diapositiva utilizza i punti. L'esempio lo adatta all'interno della diapositiva e lo centra mantenendo le proporzioni del PNG, anziché allungare l'anteprima per riempire la diapositiva.

## **Crea e incorpora il grafico**

L'esempio completo seguente popola `DataSheet` con quattro righe e cinque colonne di valori. Ogni riga diventa una serie del grafico. `ChartSheet` è selezionato come foglio attivo prima di salvare la cartella di lavoro.

La cartella di lavoro è salvata esplicitamente come XLSX, corrispondente all'estensione `xlsx` passata a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). Il PNG è caricato direttamente dai suoi byte senza una conversione bitmap intermedia. Assegnandolo tramite [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) sostituisce il segnaposto OLE predefinito.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // Renderizza l'anteprima del grafico e serializza separatamente la cartella di lavoro modificabile.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // Adatta l'anteprima all'interno della diapositiva senza modificare le sue proporzioni.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```


## **Risultato previsto**

`OutputChart.pptx` contiene una diapositiva con una cartella di lavoro Excel incorporata e un'anteprima del grafico. La cartella di lavoro contiene i dati originali e un grafico a colonne con quattro serie. L'anteprima è centrata sulla diapositiva e ne conserva le proporzioni.

![Grafico a colonne Excel visualizzato come anteprima di una cartella di lavoro incorporata](excel-chart-ole-preview.png)

In un ambiente PowerPoint desktop compatibile con Excel disponibile, fai doppio clic sull'oggetto per attivare e modificare la cartella di lavoro incorporata. L'attivazione e la modifica dipendono dal supporto OLE dell'applicazione host e dalle impostazioni di sicurezza.

## **FAQ**

**Perché è necessaria un'immagine di anteprima?**

La cartella di lavoro incorporata e la sua anteprima sulla diapositiva sono contenuti separati. Fornisci un'immagine del grafico affinché la diapositiva mostri il grafico invece del segnaposto predefinito "EMBEDDED OLE OBJECT". Vedi [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**L'anteprima si aggiorna automaticamente quando modifico la cartella di lavoro nel codice?**

Considera l'anteprima come un'istantanea. Quando si aggiornano i dati della cartella di lavoro programmaticamente, rigenera l'immagine del grafico e sostituisci l'anteprima così come i dati della cartella di lavoro incorporata.

**Posso usare XLS invece di XLSX?**

Sì. Salva la cartella di lavoro in formato XLS e usa `xls` come estensione dei dati incorporati. L'estensione deve corrispondere al formato reale della cartella di lavoro; cambiare solo l'estensione non converte i dati.

**Perché l'oggetto potrebbe cambiare dimensione dopo l'attivazione?**

L'applicazione host può aggiornare la presentazione dell'oggetto OLE quando attiva la cartella di lavoro. L'intervallo di visualizzazione OLE della cartella di lavoro e le dimensioni del riquadro della diapositiva sono entrambi importanti. Vedi [Soluzione funzionante per il ridimensionamento dei fogli di lavoro](/slides/it/androidjava/working-solution-for-worksheet-resizing/).

## **Sezioni correlate**

- [Soluzione funzionante per il ridimensionamento dei fogli di lavoro](/slides/it/androidjava/working-solution-for-worksheet-resizing/)
- [Problema di anteprima dell'oggetto quando si aggiunge OleObjectFrame](/slides/it/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Gestisci OLE](/slides/it/androidjava/manage-ole/)