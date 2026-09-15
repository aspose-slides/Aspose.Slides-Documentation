---
title: Soluzione funzionante per il ridimensionamento dei grafici in PPTX
type: docs
weight: 40
url: /it/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- ridimensionamento grafico
- grafico Excel
- oggetto OLE
- incorporare grafico
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Correggi il ridimensionamento inatteso dei grafici in PPTX quando si utilizzano oggetti OLE Excel incorporati con Aspose.Slides per Python via Java. Scopri due metodi con codice per mantenere le dimensioni coerenti."
---
## **Contesto**

È stato osservato che i grafici Excel incorporati come oggetti OLE in una presentazione PowerPoint tramite componenti Aspose vengono ridimensionati a una scala non specificata dopo la loro prima attivazione. Questo comportamento provoca una differenza visiva evidente nella presentazione tra gli stati precedente e successivo all’attivazione del grafico. Il team di Aspose ha analizzato il problema in dettaglio e ha trovato una soluzione. Questo articolo descrive le cause del problema e la relativa correzione.

Nell'[articolo precedente](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), abbiamo spiegato come creare un grafico Excel con Aspose.Cells per Python via Java e incorporarlo in una presentazione PowerPoint usando Aspose.Slides per Python via Java. Per affrontare il [problema di anteprima oggetto](/slides/it/python-java/object-preview-issue-when-adding-oleobjectframe/), abbiamo assegnato l’immagine del grafico al frame OLE del grafico. Nella presentazione di output, quando si fa doppio clic sul frame OLE che mostra l’immagine del grafico, il grafico Excel viene attivato. Gli utenti finali possono apportare le modifiche desiderate alla cartella di lavoro Excel sottostante e poi tornare alla diapositiva corrispondente facendo clic fuori dalla cartella di lavoro attivata. La dimensione del frame OLE cambia quando l’utente ritorna alla diapositiva, e il fattore di ridimensionamento varia a seconda delle dimensioni originali sia del frame OLE sia della cartella di lavoro Excel incorporata.

## **Causa del Ridimensionamento**

Poiché la cartella di lavoro Excel ha una sua dimensione della finestra, tenta di mantenere la dimensione originale alla prima attivazione. Tuttavia, il frame OLE ha una sua dimensione. Secondo Microsoft, quando la cartella di lavoro Excel viene attivata, Excel e PowerPoint negoziano la dimensione e mantengono le proporzioni corrette come parte del processo di incorporamento. A seconda delle differenze tra la dimensione della finestra di Excel e la dimensione o la posizione del frame OLE, avviene il ridimensionamento.

## **Soluzione Operativa**

Esistono due scenari possibili per creare presentazioni PowerPoint utilizzando Aspose.Slides per Python via Java.

**Scenario 1:** Creare una presentazione basata su un modello esistente.

**Scenario 2:** Creare una presentazione da zero.

La soluzione che forniamo qui si applica a entrambi gli scenari. La base di tutti gli approcci è la stessa: **la dimensione della finestra dell’oggetto OLE incorporato deve corrispondere al frame OLE nella diapositiva PowerPoint**. Discuteremo ora i due approcci a questa soluzione.

## **Primo Approccio**

In questo approccio, impareremo come impostare la dimensione della finestra della cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Si presume che nel modello ci sia una forma all’indice 2 dove vogliamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all’indice 2 nel modello. Tutto ciò che dobbiamo fare è impostare la dimensione della finestra della cartella di lavoro pari a quella della forma. Il seguente frammento di codice serve a questo scopo:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carica la cartella di lavoro Excel contenente il grafico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Imposta la dimensione della finestra della cartella di lavoro in pollici (PowerPoint usa 72 punti per pollice).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Salva la cartella di lavoro in un flusso di memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crea un frame OLE con i dati Excel incorporati.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Diciamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE alto 4 pollici e largo 9,5 pollici con coordinate x = 0,5 pollici e y = 1 pollice sulla diapositiva. Quindi impostiamo la finestra della cartella di lavoro Excel alla stessa dimensione — 4 pollici di altezza e 9,5 pollici di larghezza.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carica la cartella di lavoro Excel contenente il grafico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pollici (4 * 72).
    desired_width = 684  # 9.5 pollici (9.5 * 72).

    # Definisci la dimensione del grafico con una finestra.
    chart.setSizeWithWindow(True)

    # Imposta la dimensione della finestra della cartella di lavoro in pollici (PowerPoint usa 72 punti per pollice).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Salva la cartella di lavoro in un flusso di memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crea un frame OLE con i dati Excel incorporati.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Secondo Approccio**

In questo approccio, impareremo come impostare la dimensione del grafico nella cartella di lavoro Excel incorporata in modo che corrisponda alla dimensione del frame OLE nella diapositiva PowerPoint. Questo approccio è utile quando la dimensione del grafico è nota in anticipo e non cambierà mai.

**Scenario 1**

Supponiamo di aver definito un modello e di voler creare presentazioni basate su di esso. Si presume che nel modello ci sia una forma all’indice 2 dove intendiamo posizionare un frame OLE contenente una cartella di lavoro Excel incorporata. In questo scenario, la dimensione del frame OLE è predefinita — corrisponde alla dimensione della forma all’indice 2 nel modello. Tutto ciò che dobbiamo fare è impostare la dimensione del grafico nella cartella di lavoro pari a quella della forma. Il seguente frammento di codice serve a questo scopo:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carica la cartella di lavoro Excel contenente il grafico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definisci la dimensione del grafico senza una finestra.
    chart.setSizeWithWindow(False)

    # Imposta la dimensione del grafico in pixel (Excel usa 96 pixel per pollice).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definisci la dimensione di stampa del grafico.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Salva la cartella di lavoro in un flusso di memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crea un frame OLE con i dati Excel incorporati.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Supponiamo di voler creare una presentazione da zero e includere un frame OLE di qualsiasi dimensione con una cartella di lavoro Excel incorporata. Nel frammento di codice seguente, creiamo un frame OLE con altezza 4 pollici e larghezza 9,5 pollici sulla diapositiva con coordinate x = 0,5 pollici e y = 1 pollice. Impostiamo inoltre la dimensione corrispondente del grafico alle stesse dimensioni: altezza 4 pollici e larghezza 9,5 pollici.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Carica la cartella di lavoro Excel contenente il grafico.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 pollici (4 * 72).
    desired_width = 684  # 9.5 pollici (9.5 * 72).

    # Definisci la dimensione del grafico senza una finestra.
    chart.setSizeWithWindow(False)

    # Imposta la dimensione del grafico in pixel (Excel usa 96 pixel per pollice).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Salva la cartella di lavoro in un flusso di memoria.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Crea un frame OLE con i dati Excel incorporati.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Conclusione**

Esistono due approcci per risolvere il problema del ridimensionamento del grafico. La scelta dell’approccio dipende dai requisiti e dal caso d’uso. Entrambi gli approcci funzionano allo stesso modo sia quando le presentazioni sono create da un modello sia quando sono create da zero. Inoltre, non vi è alcun limite alla dimensione del frame OLE in questa soluzione.

## **FAQ**

**Perché il mio grafico Excel incorporato cambia dimensione dopo averlo attivato in PowerPoint?**

Questo avviene perché Excel tenta di ripristinare la dimensione originale della finestra al primo avvio, mentre il frame OLE in PowerPoint ha proprie dimensioni. PowerPoint ed Excel negoziano la dimensione per mantenere le proporzioni, il che può causare il ridimensionamento.

**È possibile prevenire completamente questo problema di ridimensionamento?**

Sì. Abbattendo la dimensione della finestra della cartella di lavoro Excel o la dimensione del grafico alla dimensione del frame OLE prima dell’incorporamento, è possibile mantenere le dimensioni del grafico coerenti.

**Quale approccio dovrei usare, impostare la dimensione della finestra della cartella di lavoro o impostare la dimensione del grafico?**

Utilizza **Approccio 1 (dimensione della finestra)** se desideri mantenere le proporzioni della cartella di lavoro e possibilmente consentire il ridimensionamento successivo.  
Utilizza **Approccio 2 (dimensione del grafico)** se le dimensioni del grafico sono fisse e non cambieranno dopo l’incorporamento.

**Questi metodi funzioneranno sia con presentazioni basate su modello sia con presentazioni nuove?**

Sì. Entrambi gli approcci funzionano allo stesso modo per le presentazioni create da modelli e da zero.

**Esiste un limite alla dimensione del frame OLE?**

No. È possibile impostare il frame OLE a qualsiasi dimensione, purché scala correttamente con la dimensione della cartella di lavoro o del grafico.

**Posso usare questi metodi con grafici creati in altri programmi di foglio di calcolo?**

Gli esempi sono progettati per grafici Excel creati con Aspose.Cells, ma i principi si applicano ad altri programmi di foglio di calcolo compatibili con OLE, purché supportino opzioni di dimensionamento simili.

## **Sezioni Correlate**

- [Creare grafici Excel e incorporarli come oggetti OLE nelle presentazioni](/slides/it/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)