---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 60
url: /it/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Correggi il ridimensionamento imprevisto dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per .NET. Imposta dimensioni fisse del grafico per mantenere coerenti le dimensioni del grafico e del frame OLE."
---
## **Contesto**

I grafici Excel incorporati come oggetti OLE nelle presentazioni PowerPoint utilizzando componenti Aspose possono cambiare dimensione dopo la prima attivazione. Ciò può provocare una differenza evidente nell'aspetto del grafico prima e dopo l'attivazione. Questo articolo spiega perché avviene il ridimensionamento e mostra come evitarlo facendo corrispondere le dimensioni fisse del grafico al frame OLE.

In [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per .NET e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per .NET. Per risolvere il [problema di anteprima dell'oggetto](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del grafico, il grafico Excel viene attivato. Gli utenti possono modificare la cartella di lavoro Excel incorporata e poi tornare alla diapositiva facendo clic al di fuori della cartella di lavoro attivata. Le dimensioni del frame OLE cambiano quando l'utente torna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

La cartella di lavoro Excel incorporata ha proprie dimensioni della finestra, che Excel tenta di mantenere quando l'oggetto viene attivato per la prima volta. Il frame OLE nella diapositiva ha dimensioni definite in modo indipendente. Quando la cartella di lavoro Excel è attivata, Excel e PowerPoint negoziano la dimensione dell'oggetto per mantenere le proporzioni come parte del processo di incorporamento. Le differenze tra la finestra della cartella di lavoro e il frame OLE possono quindi causare il ridimensionamento dell'oggetto.

## **Soluzione funzionante**

Fai corrispondere le dimensioni del grafico al frame OLE nella diapositiva e mantieni le dimensioni del grafico indipendenti dalla finestra della cartella di lavoro. Questa soluzione funziona con una nuova presentazione o con un modello esistente.

L'esempio richiede Aspose.Cells per .NET e Aspose.Slides per .NET. Crea un semplice grafico a colonne su un foglio di grafico attivo e incorpora la cartella di lavoro in formato XLS. Non viene assegnata alcuna immagine di anteprima del grafico; il grafico diventa visibile quando l'oggetto OLE viene attivato in PowerPoint.

L'esempio crea una nuova presentazione con un frame OLE di 9,5 × 4 pollici posizionato a 0,5 pollici dal bordo sinistro e 1 pollice dall'alto. Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice). Per una presentazione esistente, vedi [Usa un modello](#use-a-template).

## **Imposta una dimensione fissa del grafico**

Imposta [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) a false in modo che le dimensioni del grafico siano indipendenti dalla finestra della cartella di lavoro. Imposta le dimensioni del [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) tramite [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) e [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), convertendo i punti in pixel usando 96 pixel per pollice: un frame di 684 × 288 punti corrisponde a un grafico di 912 × 384 pixel. Imposta [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) sul valore Custom di [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). L'esempio incorpora la cartella di lavoro con [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) e salva una presentazione con un frame OLE di 9,5 × 4 pollici.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Le coordinate e le dimensioni della diapositiva sono in punti (72 punti per pollice).
var width = 684f; // 9,5 pollici.
var height = 288f; // 4 pollici.

chart.SizeWithWindow = false;
// Converti i punti in pixel del grafico usando 96 pixel per pollice.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Usa un modello**

La logica di dimensionamento è la stessa per una presentazione esistente. Per adattare l'esempio:

1. Carica la presentazione modello invece di creare una presentazione vuota.
1. Verifica che la prima diapositiva contenga almeno tre forme, quindi usa la forma all'indice 2 come segnaposto.
1. Prendi la larghezza e l'altezza del frame da quella forma invece di usare i valori fissi 684 e 288. Mantieni inalterati i calcoli delle dimensioni.
1. Aggiungi il frame OLE nella posizione del segnaposto invece delle coordinate fisse 36 e 72.
1. Rimuovi il segnaposto prima di salvare la presentazione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo l'attivazione in PowerPoint?**

Ciò avviene perché Excel tenta di ripristinare le dimensioni originali della finestra quando viene attivato per la prima volta, mentre il frame dell'oggetto OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può provocare il ridimensionamento.

**Come posso mantenere coerenti le dimensioni del grafico e del frame OLE?**

Imposta dimensioni fisse per il grafico che corrispondano al frame OLE e utilizza una dimensione di stampa del grafico personalizzata prima di incorporare la cartella di lavoro. L'esempio sopra mostra le impostazioni necessarie e le conversioni di unità.

**È sufficiente far corrispondere la dimensione della finestra della cartella di lavoro?**

Far corrispondere solo la dimensione della finestra della cartella di lavoro non impedisce in modo affidabile che il frame OLE cambi dimensione dopo l'attivazione. Usa dimensioni fisse per il grafico come mostrato nell'esempio.

**Questa soluzione funziona sia con presentazioni basate su modello sia con nuove presentazioni?**

Sì. Per un modello, utilizza le dimensioni e la posizione del segnaposto. Per una nuova presentazione, specifica direttamente le dimensioni e la posizione del frame.

**Posso usare questo esempio con grafici creati in altri programmi di foglio di calcolo?**

L'esempio utilizza una cartella di lavoro Excel creata con Aspose.Cells. Non dimostra il comportamento di attivazione per altri programmi di foglio di calcolo.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Aggiorna automaticamente gli oggetti OLE usando un componente aggiuntivo PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)