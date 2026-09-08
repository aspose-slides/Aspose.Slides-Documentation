---
title: Gestire OLE nelle presentazioni usando Python
linktitle: Gestire OLE
type: docs
weight: 40
url: /it/python-java/manage-ole/
keywords:
- Oggetto OLE
- Collegamento e incorporamento di oggetti
- Aggiungere OLE
- Incorporare OLE
- Aggiungere oggetto
- Incorporare oggetto
- Aggiungere file
- Incorporare file
- Oggetto collegato
- File collegato
- Modificare OLE
- Icona OLE
- Titolo OLE
- Estrarre OLE
- Estrarre oggetto
- Estrarre file
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Ottimizza la gestione degli oggetti OLE in PowerPoint e nei file OpenDocument con Aspose.Slides for Python via Java. Incorpora, aggiorna ed esporta i contenuti OLE senza problemi."
---
## **Introduzione**

{{% alert color="info" title="Nota" %}}
OLE (Object Linking & Embedding) è una tecnologia Microsoft che consente a dati e oggetti creati in un’applicazione di essere inseriti in un’altra tramite collegamento o incorporamento.
{{% /alert %}}

Considera un grafico creato in MS Excel. Il grafico viene quindi inserito in una diapositiva PowerPoint. Quel grafico Excel è considerato un oggetto OLE.

- Un oggetto OLE può apparire come icona. In questo caso, facendo doppio clic sull’icona, il grafico si apre nell’applicazione associata (Excel) oppure ti viene chiesto di selezionare un’applicazione per aprire o modificare l’oggetto.
- Un oggetto OLE può mostrare i propri contenuti reali, ad esempio i dati di un grafico. In questo caso, il grafico viene attivato in PowerPoint, l’interfaccia del grafico si carica e puoi modificare i dati del grafico direttamente in PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/it/python-java/) consente di inserire OLE Objects nelle diapositive come frame OLE ([OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/)).

## **Aggiungere frame OLE Object alle diapositive**

Supponendo di aver già creato un grafico in Microsoft Excel e di volerlo incorporare in una diapositiva come frame OLE usando Aspose.Slides for Python via Java, puoi procedere così:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Leggi il file Excel come array di byte.
4. Aggiungi il [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) alla diapositiva contenente l’array di byte e le altre informazioni sull’oggetto OLE.
5. Scrivi la presentazione modificata in un file PPTX.

Nell’esempio seguente, abbiamo aggiunto un grafico da un file Excel a una diapositiva come frame OLE usando Aspose.Slides for Python via Java. **Nota** che il costruttore [OleEmbeddedDataInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleembeddeddatainfo/) accetta come secondo parametro l’estensione dell’oggetto incorporabile. Questa estensione permette a PowerPoint di interpretare correttamente il tipo di file e di scegliere l’applicazione giusta per aprire l’oggetto OLE.

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

### **Aggiungere frame OLE Object collegati**

Aspose.Slides for Python via Java consente di aggiungere un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) senza incorporare dati ma solo con un collegamento al file.

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

    # Aggiungi un frame oggetto OLE con un file Excel collegato.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere ai frame OLE Object**

Se un oggetto OLE è già incorporato in una diapositiva, puoi trovarlo o accedervi facilmente in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottieni il riferimento alla diapositiva usando il suo indice.
3. Accedi alla forma [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) .
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una sola forma nella prima diapositiva. Abbiamo poi verificato che l’oggetto fosse un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) . Questo era il frame OLE desiderato da accedere.
4. Una volta ottenuto il frame OLE, puoi eseguire qualsiasi operazione su di esso.

Nel esempio sotto, un frame OLE (un oggetto grafico Excel incorporato in una diapositiva) e i suoi dati di file vengono acceduti.

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

### **Accedere alle proprietà del frame OLE collegato**

Aspose.Slides consente di accedere alle proprietà dei frame OLE collegati.

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
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Modificare i dati dell’oggetto OLE**

{{% alert color="info" title="Nota" %}}
In questa sezione, l’esempio di codice sotto utilizza [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Se un oggetto OLE è già incorporato in una diapositiva, puoi accedere facilmente a quell’oggetto e modificarne i dati in questo modo:

1. Carica una presentazione con l’oggetto OLE incorporato creando un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottieni il riferimento alla diapositiva tramite il suo indice.
3. Accedi alla forma del frame OLE.
   Nel nostro esempio, abbiamo usato il PPTX creato in precedenza che ha una forma nella prima diapositiva. Abbiamo poi verificato che l’oggetto fosse un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) . Questo era il frame OLE desiderato da accedere.
4. Una volta ottenuto il frame OLE, puoi eseguire qualsiasi operazione su di esso.
5. Crea un oggetto [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) e accedi ai dati OLE.
6. Accedi al [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) desiderato e modifica i dati.
7. Salva il [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) aggiornato in uno stream.
8. Cambia i dati dell’oggetto OLE dallo stream.

Nel esempio sotto, un frame OLE (un oggetto grafico Excel incorporato in una diapositiva) viene accesso e i suoi dati di file vengono modificati per aggiornare i dati del grafico.

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

## **Incorporare altri tipi di file nelle diapositive**

Oltre ai grafici Excel, Aspose.Slides for Python via Java consente di incorporare altri tipi di file nelle diapositive. Ad esempio, puoi inserire file HTML, PDF e ZIP come oggetti. Quando l’utente fa doppio clic sull’oggetto inserito, questo si apre automaticamente nel programma appropriato, oppure all’utente viene chiesto di selezionare un programma adatto.

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

## **Impostare i tipi di file per gli oggetti incorporati**

Quando lavori con le presentazioni, potresti dover sostituire vecchi oggetti OLE con nuovi o sostituire un oggetto OLE non supportato con uno supportato. Aspose.Slides for Python via Java consente di impostare il tipo di file per un oggetto incorporato, permettendo di aggiornare i dati del frame OLE o la sua estensione.

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

## **Impostare immagini icona e titoli per gli oggetti incorporati**

Dopo aver incorporato un oggetto OLE, viene aggiunta automaticamente un’anteprima costituita da un’immagine icona. Questa anteprima è ciò che gli utenti vedono prima di accedere o aprire l’oggetto OLE. Se desideri utilizzare un’immagine e del testo specifici come elementi dell’anteprima, puoi impostare l’immagine icona e il titolo usando Aspose.Slides for Python via Java.

Questo codice Python mostra come impostare l’immagine icona e il titolo per un oggetto incorporato:

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

## **Impedire il ridimensionamento e il riposizionamento di un frame OLE**

Dopo aver aggiunto un oggetto OLE collegato a una diapositiva, aprendo la presentazione in PowerPoint potresti vedere un messaggio che ti chiede di aggiornare i collegamenti. Cliccando sul pulsante “Update Links” la dimensione e la posizione del frame OLE potrebbero cambiare perché PowerPoint aggiorna i dati dall’oggetto OLE collegato e aggiorna l’anteprima. Per impedire a PowerPoint di chiedere l’aggiornamento dei dati dell’oggetto, impostare il metodo [setUpdateAutomatic](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) della classe [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) su `False`:

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

## **Estrarre i file incorporati**

Aspose.Slides for Python via Java consente di estrarre i file incorporati nelle diapositive come oggetti OLE in questo modo:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) contenente gli oggetti OLE da estrarre.
2. Scorri tutte le forme della presentazione e accedi alle forme [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) .
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

**Il contenuto OLE verrà renderizzato durante l’esportazione delle diapositive in PDF/immagini?**

Viene renderizzata ciò che è visibile nella diapositiva—l’icona/immagine di sostituzione (anteprima). Il contenuto OLE “live” non viene eseguito durante il rendering. Se necessario, imposta una tua immagine di anteprima per garantire l’aspetto previsto nel PDF esportato.

**Come posso bloccare un oggetto OLE su una diapositiva in modo che gli utenti non possano spostarlo/modificarlo in PowerPoint?**

Blocca la forma: Aspose.Slides fornisce [blocchi a livello di forma](/slides/it/python-java/applying-protection-to-presentation/). Non è una crittografia, ma impedisce efficacemente modifiche e spostamenti accidentali.

**Perché un oggetto Excel collegato “salta” o cambia dimensione quando apro la presentazione?**

PowerPoint potrebbe aggiornare l’anteprima dell’OLE collegato. Per un aspetto stabile, segui le pratiche della [Soluzione operativa per il ridimensionamento del foglio di lavoro](/slides/it/python-java/working-solution-for-worksheet-resizing/)—adatta il frame all’intervallo o scala l’intervallo a un frame fisso e imposta un’immagine di sostituzione appropriata.

**I percorsi relativi per gli oggetti OLE collegati vengono conservati nel formato PPTX?**

Nel PPTX le informazioni sui “percorsi relativi” non sono disponibili—solo il percorso completo. I percorsi relativi sono presenti nel vecchio formato PPT. Per la portabilità, preferisci percorsi assoluti affidabili/URI accessibili o l’incorporamento.