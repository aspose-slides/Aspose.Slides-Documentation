---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento del grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento inatteso dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Java. Scopri due metodi con codice per mantenere le dimensioni coerenti."
---
## **Contesto**

È stato osservato che i grafici Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non specificata dopo la prima attivazione. Questo comportamento provoca una evidente differenza visiva nella presentazione tra lo stato pre‑attivazione e quello post‑attivazione del grafico. Il team di Aspose ha investigato il problema in dettaglio e ha trovato una soluzione. Questo articolo descrive le cause del problema e la relativa correzione.

Nell'[articolo precedente](/slides/it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per Java. Per affrontare il [problema di anteprima dell'oggetto](/slides/it/java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l'immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l'immagine del grafico, il grafico Excel viene attivato. Gli utenti finali possono apportare tutte le modifiche desiderate al workbook Excel sottostante e poi tornare alla diapositiva corrispondente facendo clic al di fuori del workbook attivato. La dimensione del frame OLE cambia quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia del workbook Excel incorporato.

## **Causa del ridimensionamento**

Poiché il workbook Excel ha una propria dimensione della finestra, cerca di mantenere la sua dimensione originale alla prima attivazione. Il frame dell'oggetto OLE, tuttavia, ha una sua dimensione. Secondo Microsoft, quando il workbook Excel viene attivato, Excel e PowerPoint negoziano la dimensione e mantengono le proporzioni corrette come parte del processo di incorporamento. A seconda delle differenze tra la dimensione della finestra di Excel e la dimensione o la posizione del frame OLE, si verifica il ridimensionamento.

## **Soluzione funzionante**

Esistono due possibili scenari per creare presentazioni PowerPoint utilizzando Aspose.Slides per Java.

**Scenario 1:** Crea una presentazione basata su un modello esistente.  
**Scenario 2:** Crea una presentazione da zero.

La soluzione che forniamo qui si applica a entrambi gli scenari. Il principio di tutti gli approcci è lo stesso: **la dimensione della finestra dell'oggetto OLE incorporato deve corrispondere al frame OLE nella diapositiva PowerPoint**. Discuteremo ora dei due approcci a questa soluzione.

## **Primo approccio**

In questo approccio, impareremo come impostare la dimensione della finestra del workbook Excel incorporato in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Presumiamo che nel modello ci sia una forma all'indice 2 dove desideriamo inserire un frame OLE contenente un workbook Excel incorporato. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 del modello. Tutto ciò che dobbiamo fare è impostare la dimensione della finestra del workbook uguale a quella della forma. Il seguente frammento di codice serve a questo scopo:

```java
// Imposta la larghezza della finestra del workbook in pollici (divisa per 576 poiché PowerPoint utilizza 576 pixel per pollice).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Imposta l'altezza della finestra del workbook in pollici.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Salva il workbook in un flusso di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame OLE con i dati Excel incorporati.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Diciamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con un workbook Excel incorporato. Nel frammento di codice seguente, creiamo un frame OLE alto 4 pollici e largo 9,5 pollici con coordinate x = 0,5 pollici e y = 1 pollice sulla diapositiva. Impostiamo quindi la finestra del workbook Excel alla stessa dimensione — 4 pollici di altezza e 9,5 pollici di larghezza.

```java
// Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 72)
 
// Larghezza desiderata.
int desiredWidth = 684; // 9.5 pollici (9.5 * 72)
 
// Definisci la dimensione del grafico con una finestra.
chart.setSizeWithWindow(true);
 
// Imposta la larghezza della finestra del workbook in pollici (divisa per 576 poiché PowerPoint utilizza 576 pixel per pollice).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Imposta l'altezza della finestra del workbook in pollici.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Salva il workbook in un flusso di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame OLE con i dati Excel incorporati.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Secondo approccio**

In questo approccio, impareremo come impostare la dimensione del grafico nel workbook Excel incorporato in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint. Questo approccio è utile quando la dimensione del grafico è nota in anticipo e non cambierà mai.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Presumiamo che nel modello ci sia una forma all'indice 2 dove intendiamo inserire un frame OLE contenente un workbook Excel incorporato. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 del modello. Tutto ciò che dobbiamo fare è impostare la dimensione del grafico nel workbook uguale a quella della forma. Il seguente frammento di codice serve a questo scopo:

```java
// Definisci la dimensione del grafico senza una finestra.
chart.setSizeWithWindow(false);
 
// Imposta la larghezza del grafico in pixel (moltiplica per 96 poiché Excel utilizza 96 pixel per pollice).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Imposta l'altezza del grafico in pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definisci la dimensione di stampa del grafico.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Salva il workbook in un flusso di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame OLE con i dati Excel incorporati.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con un workbook Excel incorporato. Nel frammento di codice seguente, creiamo un frame OLE con un'altezza di 4 pollici e una larghezza di 9,5 pollici sulla diapositiva con coordinate x = 0,5 pollici e y = 1 pollice. Impostiamo anche la dimensione del grafico corrispondente alle stesse dimensioni: un'altezza di 4 pollici e una larghezza di 9,5 pollici.

```java
// Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 72)
 
// Larghezza desiderata.
int desiredWidth = 684; // 9.5 pollici (9.5 * 72)
 
// Definisci la dimensione del grafico senza una finestra.
chart.setSizeWithWindow(false);
 
// Imposta la larghezza del grafico in pixel (moltiplica per 96 poiché Excel utilizza 96 pixel per pollice).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Imposta l'altezza del grafico in pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Salva il workbook in un flusso di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame OLE con i dati Excel incorporati.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Conclusione**

Esistono due approcci per risolvere il problema del ridimensionamento del grafico. La scelta dell'approccio dipende dai requisiti e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo sia che le presentazioni siano create da un modello sia che siano create da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**  
Ciò accade perché Excel tenta di ripristinare la dimensione originale della finestra alla prima attivazione, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile prevenire completamente questo problema di ridimensionamento?**  
Sì. Facendo corrispondere la dimensione della finestra del workbook Excel o la dimensione del grafico alla dimensione del frame OLE prima dell'incorporamento, è possibile mantenere le dimensioni del grafico coerenti.

**Quale approccio dovrei adottare, impostare la dimensione della finestra del workbook o impostare la dimensione del grafico?**  
Utilizza **Approccio 1 (dimensione della finestra)** se desideri mantenere le proporzioni del workbook e possibilmente consentire ridimensionamenti successivi.  
Utilizza **Approccio 2 (dimensione del grafico)** se le dimensioni del grafico sono fisse e non cambieranno dopo l'incorporamento.

**Questi metodi funzioneranno sia con presentazioni basate su modello sia con nuove presentazioni?**  
Sì. Entrambi gli approcci funzionano allo stesso modo per le presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE?**  
No. È possibile impostare il frame OLE a qualsiasi dimensione purché si adatti opportunamente alla dimensione del workbook o del grafico.

**Posso utilizzare questi metodi con grafici creati in altri programmi di fogli di calcolo?**  
Gli esempi sono progettati per grafici Excel creati con Aspose.Cells, ma i principi si applicano ad altri programmi di fogli di calcolo compatibili con OLE purché supportino opzioni di dimensionamento simili.

## **Sezioni correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE in presentazioni](/slides/it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Aggiornare automaticamente gli oggetti OLE usando un Add-In PowerPoint](/slides/it/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)