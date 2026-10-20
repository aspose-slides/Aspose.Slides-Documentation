---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento inatteso dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Python via Java. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del frame OLE."
---
## **Contesto**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando i componenti Aspose possono cambiare dimensione dopo la prima attivazione. Questo può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché avviene il ridimensionamento e mostra come impedirlo facendo corrispondere le dimensioni fisse del grafico al frame OLE.

In [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells for Python via Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides for Python via Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, facendo doppio clic sul frame OLE che visualizza l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro attivata. Le dimensioni del frame OLE cambiano quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Cause del ridimensionamento**

La cartella di lavoro Excel incorporata ha le proprie dimensioni della finestra, che Excel tenta di mantenere quando l'oggetto viene attivato per la prima volta. Il frame OLE nella diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano le dimensioni dell'oggetto per mantenere le proporzioni come parte del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il frame OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere le dimensioni del grafico al frame OLE nella diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells for Python via Java e Aspose.Slides for Python via Java. Crea un semplice grafico a colonne su un foglio di grafico attivo e incorpora la cartella di lavoro in formato XLS. Non viene assegnata alcuna immagine di anteprima del grafico; il grafico diventa visibile quando l'oggetto OLE viene attivato in PowerPoint.

L'esempio crea una nuova presentazione con un frame OLE di 9,5 × 4 pollici posizionato a 0,5 pollici dal bordo sinistro e a 1 pollice dall'alto. Le coordinate e le dimensioni della diapositiva sono espresse in punti (72 punti per pollice). Per una presentazione esistente, vedere [Usare un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) su false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni del [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) tramite [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) e [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), convertendo i punti in pixel usando 96 pixel per pollice: un frame di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) al valore CUSTOM di [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). L'esempio incorpora la cartella di lavoro con [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) e salva una presentazione con un frame OLE di 9,5 × 4 pollici.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
        width = 684.0  # 9.5 pollici.
        height = 288.0  # 4 pollici.

        chart.setSizeWithWindow(False)
        # Converti i punti in pixel del grafico usando 96 pixel per pollice.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Usare un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello anziché creare una presentazione vuota.
1. Verifica che la prima diapositiva contenga almeno tre forme, quindi utilizza la forma all'indice 2 come segnaposto.
1. Prendi la larghezza e l'altezza del frame da quella forma invece di usare i valori fissi 684 e 288. Mantieni inalterati i calcoli di dimensionamento.
1. Aggiungi il frame OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.
1. Rimuovi il segnaposto prima di salvare la presentazione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo l'attivazione in PowerPoint?**

Questo accade perché Excel tenta di ripristinare la dimensione originale della finestra alla prima attivazione, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può provocare il ridimensionamento.

**Come posso mantenere coerenti le dimensioni del grafico e del frame OLE?**

Imposta dimensioni fisse del grafico che corrispondano al frame OLE e utilizza una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni richieste e le conversioni di unità.

**È sufficiente far corrispondere la dimensione della finestra della cartella di lavoro?**

Far corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile al frame OLE di cambiare dimensione dopo l'attivazione. Usa dimensioni fisse del grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**

Sì. Per un modello, usa le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del frame.

**Posso usare questo esempio con grafici creati in altri programmi di fogli di calcolo?**

L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di fogli di calcolo.

## **Sezioni correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)