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
description: "Correggi il ridimensionamento imprevisto dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Java. Scopri due metodi con codice per mantenere le dimensioni coerenti."
---
## **Contesto**

È stato osservato che i grafici Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non specificata dopo la prima attivazione. Questo comportamento provoca una differenza visiva notevole nella presentazione tra gli stati del grafico prima e dopo l'attivazione. Il team di Aspose ha esaminato il problema in dettaglio e ha trovato una soluzione. Questo articolo descrive le cause del problema e la relativa correzione.

Nel [previous article](/slides/it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per Java. Per risolvere il [object preview issue](/slides/it/java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l’immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che visualizza l’immagine del grafico, il grafico Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate nella cartella di lavoro Excel sottostante e poi tornare alla diapositiva corrispondente facendo clic al di fuori della cartella di lavoro attivata. La dimensione del frame OLE cambia quando l'utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Causa del ridimensionamento**

Poiché la cartella di lavoro Excel ha una propria dimensione della finestra, cerca di mantenere la sua dimensione originale al primo avvio. Il frame OLE, tuttavia, ha una dimensione propria. Secondo Microsoft, quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano la dimensione e mantengono le proporzioni corrette come parte del processo di incorporamento. A seconda delle differenze tra la dimensione della finestra di Excel e la dimensione o la posizione del frame OLE, avviene il ridimensionamento.

## **Soluzione funzionante**

Esistono due scenari possibili per creare presentazioni PowerPoint utilizzando Aspose.Slides per Java.

**Scenario 1:** Creare una presentazione basata su un modello esistente.

**Scenario 2:** Creare una presentazione da zero.

La soluzione che forniamo qui si applica a entrambi gli scenari. Il principio di tutti gli approcci di soluzione è lo stesso: **la dimensione della finestra dell'oggetto OLE incorporato deve corrispondere al frame OLE nella diapositiva PowerPoint**. Ora discuteremo i due approcci a questa soluzione.

## **Primo approccio**

In questo approccio, impareremo come impostare la dimensione della finestra della cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint.

**Scenario 1**

Supponiamo di aver definito un modello e voler creare presentazioni basate su di esso. Supponiamo che nel modello ci sia una forma all'indice 2 dove vogliamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 del modello. Tutto ciò che dobbiamo fare è impostare la dimensione della finestra della cartella di lavoro uguale alla dimensione di quella forma. Il seguente frammento di codice serve a questo scopo:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Imposta la larghezza della finestra della cartella di lavoro in pollici (divisa per 72 poiché PowerPoint usa 72 punti per pollice).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Salva la cartella di lavoro in uno stream di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame oggetto OLE con i dati Excel incorporati.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Diciamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE alto 4 pollici e largo 9,5 pollici a x = 0,5 pollici e y = 1 pollice sulla diapositiva. Impostiamo quindi la finestra della cartella di lavoro Excel alla stessa dimensione — 4 pollici di altezza e 9,5 pollici di larghezza.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 72)
 
// Larghezza desiderata.
int desiredWidth = 684; // 9,5 pollici (9,5 * 72)
 
// Definisci la dimensione del grafico con una finestra.
chart.setSizeWithWindow(true);
 
// Imposta la larghezza della finestra della cartella di lavoro in pollici (divisa per 72 poiché PowerPoint usa 72 punti per pollice).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Imposta l'altezza della finestra della cartella di lavoro in pollici.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Salva la cartella di lavoro in uno stream di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame oggetto OLE con i dati Excel incorporati.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 pollici (0,5 * 72)
    72,  // y = 1 pollice (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Secondo approccio**

In questo approccio, impareremo come impostare la dimensione del grafico nella cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint. Questo approccio è utile quando la dimensione del grafico è nota in anticipo e non cambierà.

**Scenario 1**

Supponiamo di aver definito un modello e voler creare presentazioni basate su di esso. Supponiamo che nel modello ci sia una forma all'indice 2 dove intendiamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all'indice 2 del modello. Tutto ciò che dobbiamo fare è impostare la dimensione del grafico nella cartella di lavoro uguale alla dimensione di quella forma. Il seguente frammento di codice serve a questo scopo:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Definisci la dimensione del grafico senza una finestra.
chart.setSizeWithWindow(false);
 
// Imposta la larghezza del grafico in pixel (moltiplica per 96 poiché Excel usa 96 pixel per pollice).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Imposta l'altezza del grafico in pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definisci la dimensione di stampa del grafico.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Salva la cartella di lavoro in uno stream di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame oggetto OLE con i dati Excel incorporati.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE con un’altezza di 4 pollici e una larghezza di 9,5 pollici sulla diapositiva a x = 0,5 pollici e y = 1 pollice. Impostiamo anche la dimensione del grafico corrispondente alle stesse dimensioni: altezza di 4 pollici e larghezza di 9,5 pollici.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Altezza desiderata.
int desiredHeight = 288; // 4 pollici (4 * 72)
 
// Larghezza desiderata.
int desiredWidth = 684; // 9,5 pollici (9,5 * 72)
 
// Definisci la dimensione del grafico senza una finestra.
chart.setSizeWithWindow(false);
 
// Imposta la larghezza del grafico in pixel (dividi per 72 per ottenere pollici, moltiplica per 96 poiché Excel usa 96 pixel per pollice).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Imposta l'altezza del grafico in pixel.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Salva la cartella di lavoro in uno stream di memoria.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Crea un frame oggetto OLE con i dati Excel incorporati.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 pollici (0,5 * 72)
    72,  // y = 1 pollice (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Conclusione**

Esistono due approcci per risolvere il problema del ridimensionamento del grafico. La scelta dell'approccio dipende dai requisiti e dal caso d'uso. Entrambi gli approcci funzionano allo stesso modo sia quando le presentazioni sono create da un modello sia quando vengono create da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

## **FAQ**

### Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?

Questo accade perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

### È possibile evitare completamente questo problema di ridimensionamento?

Sì. Facendo corrispondere la dimensione della finestra della cartella di lavoro Excel o la dimensione del grafico alla dimensione del frame OLE prima dell'incorporamento, è possibile mantenere le dimensioni del grafico coerenti.

### Quale approccio devo scegliere, impostare la dimensione della finestra della cartella di lavoro o impostare la dimensione del grafico?

Utilizzare **Approccio 1 (dimensione della finestra)** se si desidera mantenere il rapporto d'aspetto della cartella di lavoro e possibilmente consentire il ridimensionamento successivo.  
Utilizzare **Approccio 2 (dimensione del grafico)** se le dimensioni del grafico sono fisse e non cambieranno dopo l'incorporamento.

### Questi metodi funzioneranno sia con presentazioni basate su modello sia con nuove presentazioni?

Sì. Entrambi gli approcci funzionano allo stesso modo per le presentazioni create da modelli e da zero.

### Esiste un limite alla dimensione del frame OLE?

No. È possibile impostare il frame OLE a qualsiasi dimensione, purché si scala in modo appropriato alla dimensione della cartella di lavoro o del grafico.

### Posso utilizzare questi metodi con grafici creati in altri programmi di foglio di calcolo?

Gli esempi sono progettati per grafici Excel creati con Aspose.Cells, ma i principi si applicano ad altri programmi di foglio di calcolo compatibili con OLE, purché supportino opzioni di dimensionamento simili.

## **Sezioni correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)