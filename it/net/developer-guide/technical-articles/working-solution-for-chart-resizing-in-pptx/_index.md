---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 60
url: /it/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Correggi il ridimensionamento imprevisto dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per .NET. Scopri due metodi con codice per mantenere le dimensioni coerenti."
---
## **Contesto**

E' stato osservato che i grafici Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite i componenti Aspose vengono ridimensionati a una scala non specificata dopo la loro prima attivazione. Questo comportamento provoca una notevole differenza visiva nella presentazione tra gli stati pre-attivazione e post-attivazione del grafico. Il team di Aspose ha investigato il problema in dettaglio e ha trovato una soluzione. Questo articolo descrive le cause del problema e la relativa correzione.

Nell'[articolo precedente](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per .NET e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per .NET. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/net/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l'immagine del grafico, il grafico Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate nella cartella di lavoro Excel sottostante e quindi tornare alla diapositiva corrispondente facendo clic al di fuori della cartella di lavoro attivata. La dimensione del frame OLE cambia quando l'utente torna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Cause del ridimensionamento**

Poiche' la cartella di lavoro Excel ha una sua dimensione della finestra, cerca di mantenere la dimensione originale al primo avvio. Il frame OLE, tuttavia, ha una sua dimensione. Secondo Microsoft, quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano la dimensione e mantengono le proporzioni corrette come parte del processo di incorporamento. A seconda delle differenze tra la dimensione della finestra Excel e la dimensione o posizione del frame OLE, si verifica il ridimensionamento.

## **Soluzione funzionante**

Esistono due scenari possibili per creare presentazioni PowerPoint usando Aspose.Slides per .NET.

**Scenario 1:** Creare una presentazione basata su un modello esistente.

**Scenario 2:** Creare una presentazione da zero.

La soluzione che forniamo qui si applica a entrambi gli scenari. La base di tutti gli approcci alla soluzione e' la stessa: **la dimensione della finestra dell'oggetto OLE incorporato deve corrispondere al frame OLE nella diapositiva PowerPoint**. Ora discuteremo i due approcci a questa soluzione.

## **Primo approccio**

In questo approccio, impareremo come impostare la dimensione della finestra della cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Assume che ci sia una forma all'indice 2 nel modello dove vogliamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE e' predefinita -- corrisponde alla dimensione della forma all'indice 2 nel modello. Tutto quello che dobbiamo fare e' impostare la dimensione della finestra della cartella di lavoro pari a quella della forma. Il seguente frammento di codice serve a questo scopo:

```cs
// Definisci la dimensione del grafico con una finestra. 
chart.SizeWithWindow = true;

// Imposta la larghezza della finestra della cartella di lavoro in pollici (divisa per 72 poiché PowerPoint usa 72 pixel per pollice).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Salva la cartella di lavoro in un flusso di memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crea un frame oggetto OLE con i dati Excel incorporati.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE alto 4 pollici e largo 9,5 pollici a x = 0,5 pollici e y = 1 pollice sulla diapositiva. Poi impostiamo la finestra della cartella di lavoro Excel alla stessa dimensione -- 4 pollici di altezza e 9,5 pollici di larghezza.

```cs
// Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 72)

// Larghezza desiderata.
int desiredWidth = 684;//9,5 pollici (9.5 * 72)

// Definisci la dimensione del grafico con una finestra.
chart.SizeWithWindow = true;

// Imposta la larghezza della finestra della cartella di lavoro in pollici.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Salva la cartella di lavoro in un flusso di memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crea un frame oggetto OLE con i dati Excel incorporati.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Secondo approccio**

In questo approccio, impareremo come impostare la dimensione del grafico nella cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint. Questo approccio e' utile quando la dimensione del grafico e' nota in anticipo e non cambiera' mai.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Assume che ci sia una forma all'indice 2 nel modello dove intendiamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE e' predefinita -- corrisponde alla dimensione della forma all'indice 2 nel modello. Tutto quello che dobbiamo fare e' impostare la dimensione del grafico nella cartella di lavoro pari a quella della forma. Il seguente frammento di codice serve a questo scopo:

```cs
// Definisci la dimensione del grafico senza una finestra. 
chart.SizeWithWindow = false;

// Imposta la larghezza del grafico in pixel (moltiplica per 96 poiché Excel usa 96 pixel per pollice).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Imposta l'altezza del grafico in pixel.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definisci la dimensione di stampa del grafico.
chart.PrintSize = PrintSizeType.Custom;

// Salva la cartella di lavoro in un flusso di memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crea un frame oggetto OLE con i dati Excel incorporati.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE con un'altezza di 4 pollici e una larghezza di 9,5 pollici sulla diapositiva a x = 0,5 pollici e y = 1 pollice. Impostiamo anche la dimensione corrispondente del grafico alle stesse dimensioni: un'altezza di 4 pollici e una larghezza di 9,5 pollici.

```cs
 // Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 576)

 // Larghezza desiderata.
int desiredWidth = 684; // 9,5 pollici (9.5 * 576)

// Definisci la dimensione del grafico senza una finestra. 
chart.SizeWithWindow = false;

// Imposta la larghezza del grafico in pixel.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Imposta l'altezza del grafico in pixel.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Salva la cartella di lavoro in un flusso di memoria.
MemoryStream workbookStream = workbook.SaveToStream();

// Crea un frame oggetto OLE con i dati Excel incorporati.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Conclusione**

Esistono due approcci per risolvere il problema di ridimensionamento del grafico. La scelta dell'approccio dipende dai requisiti e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo sia che le presentazioni siano create da un modello sia da zero. Inoltre, non c'e' alcun limite alla dimensione del frame OLE in questa soluzione.

## **FAQ**

**Perche' il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**  
Ciò avviene perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il frame OLE in PowerPoint ha le proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere il rapporto d'aspetto, il che può causare il ridimensionamento.

**E' possibile prevenire completamente questo problema di ridimensionamento?**  
Sì. Abbattendo la dimensione della finestra della cartella di lavoro Excel o la dimensione del grafico alla dimensione del frame OLE prima dell'incorporamento, è possibile mantenere le dimensioni del grafico coerenti.

**Quale approccio dovrei adottare, impostare la dimensione della finestra della cartella di lavoro o impostare la dimensione del grafico?**  
Usa **Approccio 1 (dimensione della finestra)** se desideri mantenere il rapporto d'aspetto della cartella di lavoro e possibilmente consentire il ridimensionamento successivo.  
Usa **Approccio 2 (dimensione del grafico)** se le dimensioni del grafico sono fisse e non cambieranno dopo l'incorporamento.

**Questi metodi funzioneranno sia con presentazioni basate su modello sia con nuove presentazioni?**  
Sì. Entrambi gli approcci funzionano allo stesso modo per le presentazioni create da modelli e da zero.

**C'e' un limite alla dimensione del frame OLE?**  
No. Puoi impostare il frame OLE a qualsiasi dimensione purché si scala correttamente alla dimensione della cartella di lavoro o del grafico.

**Posso usare questi metodi con grafici creati in altri programmi di foglio di calcolo?**  
Gli esempi sono progettati per grafici Excel creati con Aspose.Cells, ma i principi si applicano ad altri programmi di foglio di calcolo compatibili OLE purché supportino opzioni di dimensionamento simili.

## **Sezioni correlate**

- [Crea grafici Excel e incorporali come oggetti OLE nelle presentazioni](/slides/it/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Aggiorna oggetti OLE automaticamente usando un add-in di PowerPoint](/slides/it/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)