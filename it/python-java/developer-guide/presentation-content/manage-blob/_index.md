---
title: Gestire i BLOB di presentazione in Python via Java per un uso efficiente della memoria
linktitle: Gestisci BLOB
type: docs
weight: 10
url: /it/python-java/manage-blob/
keywords:
- oggetto grande
- elemento grande
- file grande
- aggiungi BLOB
- esporta BLOB
- aggiungi immagine come BLOB
- riduci memoria
- consumo di memoria
- presentazione grande
- file temporaneo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per Python via Java per semplificare le operazioni sui file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce la gestione basata su BLOB per grandi dati binari nelle presentazioni per contribuire a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come utilizzare i file temporanei durante l'elaborazione e come modificare la cartella usata per memorizzarli.

## **Informazioni su BLOB**

Un **BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formato binario.

Aspose.Slides for Python via Java consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

{{% alert color="info" title="Note" %}}
Per aggirare alcune limitazioni nell'interazione con gli stream, Aspose.Slides potrebbe copiare il contenuto dello stream. Caricare una presentazione di grandi dimensioni tramite il suo stream comporta la copia del contenuto della presentazione e provoca un caricamento lento. Pertanto, quando si intende caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione e non il suo stream.
{{% /alert %}}

## **Utilizzare i BLOB per ridurre il consumo di memoria**

### **Aggiungere un file di grandi dimensioni a una presentazione usando i BLOB**

[Aspose.Slides](/slides/it/python-java/) for Python via Java consente di aggiungere file di grandi dimensioni (in questo caso, un video di grandi dimensioni) mediante un processo basato su BLOB per ridurre il consumo di memoria.

Questo codice Python mostra come aggiungere un video di grandi dimensioni tramite il processo BLOB a una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Crea una nuova presentazione a cui verrà aggiunto il video.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Mantieni lo stream bloccato perché non intendiamo accedere al file video.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Salva la presentazione mantenendo basso il consumo di memoria.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Esportare un file di grandi dimensioni da una presentazione usando i BLOB**

Aspose.Slides for Python via Java consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) mediante un processo basato su BLOB dalle presentazioni. Ad esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione ma non vuoi che il file venga caricato nella memoria del tuo computer. Esportando il file tramite il processo BLOB, mantieni basso il consumo di memoria.

Questo codice Python dimostra l'operazione descritta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Blocca il file di origine invece di caricarlo in memoria.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Trasferisci i dati video tramite un buffer per mantenere basso il consumo di memoria.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Usa lo stream invece di caricare l'intero video in un array di byte.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Se necessario, applica gli stessi passaggi ai file audio.
finally:
    presentation.dispose()
```

### **Aggiungere un'immagine come BLOB a una presentazione**

Con i metodi della classe [ImageCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/) è possibile aggiungere un'immagine di grandi dimensioni come stream in modo che sia trattata come BLOB.

Questo codice Python mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Crea una nuova presentazione a cui verrà aggiunta l'immagine.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Mantieni lo stream bloccato perché non intendiamo accedere al file immagine.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Salva la presentazione mantenendo basso il consumo di memoria.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Memoria e presentazioni di grandi dimensioni**

Tipicamente, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file (da cui la presentazione è stata caricata) smette di essere utilizzato.

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Ma questo metodo consuma circa 1,6 GB di memoria temporanea.

### **Caricare una presentazione di grandi dimensioni come BLOB**

Utilizzando la gestione dei BLOB, è possibile caricare una presentazione di grandi dimensioni usando poca memoria. Questo codice Python mostra come usare la gestione dei BLOB per caricare un file di presentazione di grandi dimensioni (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Modificare la cartella per i file temporanei**

Quando viene utilizzato il processo BLOB, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei vengano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione usando [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
Quando utilizzi [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/it/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides non crea automaticamente una cartella per memorizzare i file temporanei. Devi creare la cartella manualmente.
{{% /alert %}}

### **Rilasciare gli oggetti Presentation per liberare memoria**

Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) venga correttamente rilasciata in modo che la memoria occupata venga liberata. Chiama [Presentation.dispose](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#dispose) dopo aver terminato l'uso della presentazione per liberare le risorse non gestite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...elabora la presentazione...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Rilascia esplicitamente le risorse.
    presentation.dispose()
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides sono trattati come BLOB e controllati dalle opzioni BLOB?**

Oggetti binari di grandi dimensioni come immagini, audio e video sono trattati come BLOB. L'intero file della presentazione coinvolge anche la gestione dei BLOB quando viene caricato o salvato. Questi oggetti sono governati dalle politiche BLOB che consentono di gestire l'uso della memoria e lo spostamento su file temporanei quando necessario.

**Dove configuro le regole di gestione dei BLOB durante il caricamento della presentazione?**

Usa [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/blobmanagementoptions/). Lì imposti il limite di memoria per i BLOB, consenti o meno file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della sorgente.

**Le impostazioni BLOB influiscono sulle prestazioni e come bilanciare velocità vs memoria?**

Sì. Mantenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; ridurre il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a costo di I/O aggiuntivo. Usa il metodo [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) per trovare il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Le opzioni BLOB aiutano quando si aprono presentazioni estremamente grandi (ad esempio gigabyte)?**

Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/blobmanagementoptions/) è progettato per tali scenari: abilitare i file temporanei e usare il blocco della sorgente può ridurre significativamente l'uso di RAM di picco e stabilizzare l'elaborazione per deck molto grandi.

**Posso usare le politiche BLOB quando carico da stream anziché da file su disco?**

Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di input (a seconda della modalità di blocco scelta) e i file temporanei vengono utilizzati quando consentiti, mantenendo prevedibile l'uso della memoria durante l'elaborazione.