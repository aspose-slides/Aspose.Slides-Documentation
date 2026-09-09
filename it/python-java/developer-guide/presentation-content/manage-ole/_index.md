---
title: Gestire OLE nelle presentazioni usando Python
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/python-java/manage-ole/
keywords:
- oggetto OLE
- collegamento e incorporamento di oggetti
- aggiungi OLE
- incorpora OLE
- aggiungi oggetto
- incorpora oggetto
- aggiungi file
- incorpora file
- oggetto collegato
- file collegato
- modifica OLE
- icona OLE
- titolo OLE
- estrai OLE
- estrai oggetto
- estrai file
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides per Python via Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente di posizionare dati e oggetti creati in un'applicazione all'interno di un'altra applicazione mediante collegamento o incorporamento.

{{% /alert %}}

Considera un grafico creato in MS Excel. Il grafico viene poi inserito all'interno di una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE.

- Un oggetto OLE può apparire come un'icona. In questo caso, quando fai doppio clic sull'icona, il grafico si apre nell'applicazione associata (Excel), oppure ti viene chiesto di selezionare un'applicazione per aprire o modificare l'oggetto.
- Un oggetto OLE può visualizzare i propri contenuti effettivi, come i dati di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l'interfaccia del grafico si carica e puoi modificare i dati del grafico all'interno di PowerPoint.

[Aspose.Slides per Python via Java](https://products.aspose.com/slides/it/python-java/) consente di inserire oggetti OLE nelle diapositive come frame di oggetti OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/)).

## **Aggiungi frame di oggetti OLE alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame di oggetto OLE usando Aspose.Slides per Python via Java, puoi procedere così:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Leggi il file Excel come array di byte.
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) alla diapositiva contenente l'array di byte e le altre informazioni sull'oggetto OLE.
5. Scrivi la presentazione modificata in un file PPTX.

Nell'esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame di oggetto OLE usando Aspose.Slides per Python via Java.  
**Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleembeddeddatainfo/) accetta un'estensione di oggetto incorporabile come secondo parametro. Questa estensione consente a PowerPoint di interpretare correttamente il tipo di file e scegliere l'applicazione giusta per aprire questo oggetto OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Prepara i dati per l'oggetto OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Aggiungi il frame dell'oggetto OLE alla diapositiva.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Aggiungi frame di oggetti OLE collegati**

Aspose.Slides per Python via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) con un collegamento al file invece di dati incorporati.

Questo codice Python mostra come aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) con un file Excel collegato a una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un frame di oggetto OLE con un file Excel collegato.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedi ai frame di oggetti OLE**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/). Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva. Abbiamo quindi verificato che l'oggetto fosse un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/). Questo era il frame di oggetto OLE desiderato da accedere.
4. Una volta accesso il frame di oggetto OLE, puoi eseguire qualsiasi operazione su di esso.

Nell'esempio seguente, viene acceduto un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Ottieni i dati del file incorporato.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Ottieni l'estensione del file incorporato.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Accedi alle proprietà del frame di oggetto OLE collegato**

Aspose.Slides consente di accedere alle proprietà del frame di oggetto OLE collegato.

Questo codice Python mostra come verificare se un oggetto OLE è collegato e poi ottenere il percorso del file collegato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Verifica se l'oggetto OLE è collegato.
        if ole_frame.isObjectLink():
            # Stampa il percorso completo del file collegato.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Stampa il percorso relativo del file collegato se presente.
            # Solo le presentazioni PPT possono contenere il percorso relativo.
            relative_path = ole_frame.getLinkPathRelative()
finally:
    presentation.dispose()
```

## **Modifica i dati dell'oggetto OLE**

{{% alert color="info" title="Note" %}}

In questa sezione, l'esempio di codice mostrato utilizza [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedere facilmente a quell'oggetto e modificare i suoi dati in questo modo:

1. Carica una presentazione con l'oggetto OLE incorporato creando un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva tramite il suo indice.
3. Accedi alla forma del frame di oggetto OLE. Nel nostro esempio, abbiamo utilizzato il PPTX creato in precedenza che ha una forma nella prima diapositiva. Abbiamo quindi verificato che l'oggetto fosse un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/). Questo era il frame dell'oggetto OLE desiderato da accedere.
4. Una volta accesso il frame dell'oggetto OLE, puoi eseguire qualsiasi operazione su di esso.
5. Crea un oggetto [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) e accedi ai dati OLE.
6. Accedi al [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) desiderato e modifica i dati.
7. Salva il [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) aggiornato in uno stream.
8. Modifica i dati dell'oggetto OLE dallo stream.

Nell'esempio seguente, viene acceduto un frame di oggetto OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati file vengono modificati per aggiornare i dati del grafico.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Leggi i dati dell'oggetto OLE come oggetto Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modifica i dati del workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Cambia i dati dell'oggetto frame OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Incorpora altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides per Python via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, è possibile inserire file HTML, PDF e ZIP come oggetti. Quando l'utente fa doppio clic sull'oggetto inserito, esso si apre automaticamente nel programma pertinente, oppure viene chiesto all'utente di selezionare un programma appropriato per aprirlo.

Questo codice Python mostra come incorporare HTML e ZIP in una diapositiva:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta i tipi di file per gli oggetti incorporati**

Durante il lavoro con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides per Python via Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

Questo codice Python mostra come impostare il tipo di file per un oggetto OLE incorporato su `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Cambia il tipo di file in ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta immagini icona e titoli per gli oggetti incorporati**

Dopo che un oggetto OLE è stato incorporato, viene aggiunta automaticamente un'anteprima costituita da un'immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l'oggetto OLE. Se vuoi utilizzare un'immagine e un testo specifici come elementi dell'anteprima, puoi impostare l'immagine icona e il titolo usando Aspose.Slides per Python via Java.

Questo codice Python mostra come impostare l'immagine icona e il titolo per un oggetto incorporato:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Aggiungi un'immagine alle risorse della presentazione.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Imposta un titolo e l'immagine per l'anteprima OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impedisci il ridimensionamento e lo spostamento dei frame di oggetti OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva della presentazione, quando apri la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccare il pulsante “Update Links” può modificare le dimensioni e la posizione del frame dell'oggetto OLE perché PowerPoint aggiorna i dati dall'oggetto OLE collegato e rinfresca l'anteprima dell'oggetto. Per evitare che PowerPoint chieda di aggiornare i dati dell'oggetto, imposta il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) della classe [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) su `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Estrai file incorporati**

Aspose.Slides per Python via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) contenente gli oggetti OLE che desideri estrarre.
2. Scorri tutte le forme nella presentazione e accedi alle forme [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/).
3. Accedi ai dati dei file incorporati dai frame OLE e scrivili su disco.

Questo codice Python mostra come estrarre i file incorporati in una diapositiva come oggetti OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Il contenuto OLE verrà renderizzato durante l'esportazione delle diapositive in PDF/immagini?**

Viene renderizzata solo la parte visibile nella diapositiva—l'icona/immagine sostitutiva (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta un'immagine di anteprima personalizzata per garantire l'aspetto desiderato nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/python-java/applying-protection-to-presentation/). Non si tratta di crittografia, ma limita efficacemente le modifiche accidentali e lo spostamento.

**Perché un oggetto Excel collegato “salta” o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l'anteprima dell'OLE collegato. Per un aspetto stabile, segui le pratiche indicate nella [Soluzione funzionante per il ridimensionamento del foglio di lavoro](/slides/it/python-java/working-solution-for-worksheet-resizing/) — oppure adatta il frame all'intervallo, oppure scala l'intervallo a un frame fisso e imposta un'immagine sostitutiva appropriata.

**I percorsi relativi per gli oggetti OLE collegati saranno conservati nel formato PPTX?**

In PPTX le informazioni sul “percorso relativo” non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel formato PPT più vecchio. Per la portabilità, è preferibile usare percorsi assoluti affidabili/URI accessibili o incorporare i file.