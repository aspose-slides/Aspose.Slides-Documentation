---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 60
url: /it/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- presentazione
- Python via .NET
- Python
- Aspose.Slides
description: "Correggi il ridimensionamento imprevisto del grafico in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Python via .NET. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del riquadro OLE."
---
## **Panoramica**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando i componenti Aspose possono cambiare dimensione dopo la loro prima attivazione. Ciò può provocare una differenza evidente nell’aspetto del grafico prima e dopo l’attivazione. Questo articolo spiega perché avviene il ridimensionamento e mostra come prevenirlo facendo corrispondere le dimensioni fisse del grafico al riquadro OLE.

In [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per Python via .NET e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per Python via .NET. Per affrontare il [problema dell'anteprima dell'oggetto](/slides/it/python-net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l’immagine del grafico al riquadro OLE del grafico. Nella presentazione di output, facendo doppio‑click sul riquadro OLE che visualizza l’immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro attivata. La dimensione del riquadro OLE cambia quando l’utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del riquadro OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel tenta di conservare quando l’oggetto viene attivato per la prima volta. Il riquadro OLE sulla diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro è attivata, Excel e PowerPoint negoziano la dimensione dell’oggetto per mantenere le proporzioni durante il processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il riquadro OLE possono quindi provocare il ridimensionamento dell’oggetto.

## **Soluzione funzionante**

Fai corrispondere le dimensioni del grafico al riquadro OLE sulla diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L’esempio richiede Aspose.Cells per Python via .NET e Aspose.Slides per Python via .NET. Crea un semplice grafico a colonne su un foglio grafico attivo e incorpora la cartella di lavoro in formato XLS. Nessuna immagine di anteprima del grafico viene assegnata; il grafico diventa visibile quando l’oggetto OLE è attivato in PowerPoint.

L’esempio crea una nuova presentazione con un riquadro OLE di 9.5 × 4 pollici posizionato a 0.5 pollici dal margine sinistro e a 1 pollice dall’alto. Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice). Per una presentazione esistente, vedere [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) su false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni di [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) tramite [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) e [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), convertendo i punti in pixel usando 96 pixel per pollice: un riquadro che misura 684 × 288 punti corrisponde a un grafico che misura 912 × 384 pixel. Imposta [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) sul valore CUSTOM di [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). L’esempio incorpora la cartella di lavoro con [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) e salva una presentazione con un riquadro OLE di 9.5 × 4 pollici.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
    width = 684.0  # 9,5 pollici.
    height = 288.0  # 4 pollici.

    chart.size_with_window = False
    # Converti i punti in pixel del grafico usando 96 pixel per pollice.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Usa un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l’esempio:

1. Carica la presentazione modello invece di creare una presentazione vuota.  
1. Verifica che la prima diapositiva contenga almeno tre forme, quindi utilizza la forma all’indice 2 come segnaposto.  
1. Prendi la larghezza e l’altezza del riquadro da quella forma invece di usare i valori fissi 684 e 288. Mantieni inalterati i calcoli delle dimensioni.  
1. Aggiungi il riquadro OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.  
1. Rimuovi il segnaposto prima di salvare la presentazione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo l’attivazione in PowerPoint?**  
Questo accade perché Excel tenta di ripristinare le dimensioni originali della finestra al primo avvio, mentre il riquadro OLE in PowerPoint ha dimensioni proprie. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d’aspetto, il che può provocare il ridimensionamento.

**Come posso mantenere le dimensioni del grafico e del riquadro OLE coerenti?**  
Imposta dimensioni fisse del grafico che corrispondano al riquadro OLE e utilizza una dimensione di stampa personalizzata del grafico prima di incorporare la cartella di lavoro. L’esempio sopra mostra le impostazioni necessarie e le conversioni di unità.

**Il fatto di far corrispondere la dimensione della finestra della cartella di lavoro è sufficiente?**  
Far corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile al riquadro OLE di cambiare dimensione dopo l’attivazione. Usa dimensioni fisse per il grafico come mostrato nell’esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**  
Sì. Per un modello, utilizza le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del riquadro.

**Posso usare questo esempio con grafici creati in altri programmi di foglio di calcolo?**  
L’esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di foglio di calcolo.

## **Sezioni correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Aggiornare gli oggetti OLE automaticamente usando un componente aggiuntivo PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)