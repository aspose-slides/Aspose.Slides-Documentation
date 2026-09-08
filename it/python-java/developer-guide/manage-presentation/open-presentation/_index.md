---
title: Aprire presentazioni in Python via Java
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/python-java/open-presentation/
keywords:
- aprire PowerPoint
- aprire presentazione
- aprire PPTX
- aprire PPT
- aprire ODP
- caricare presentazione
- caricare PPTX
- caricare PPT
- caricare ODP
- presentazione protetta
- presentazione di grandi dimensioni
- risorsa esterna
- oggetto binario
- Python
- Java
- Aspose.Slides
description: "Scopri come aprire presentazioni PowerPoint e OpenDocument in Python via Java, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso della memoria con Aspose.Slides per Python via Java."
---
## **Introduzione**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/it/python-java/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/) . Per esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari fuori dalla memoria heap di Java, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, passare il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) . Disporre della presentazione dopo l'uso affinché i handle dei file, i dati temporanei e altre risorse vengano rilasciati prontamente.

Il seguente esempio Python mostra come aprire una presentazione e ottenere il numero di diapositive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Aprire presentazioni protette da password**

Una password di apertura crittografa il contenuto della presentazione. Per caricare l'intera presentazione, passare la password corretta a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setPassword) e fornire le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) . Il caricamento fallisce se la password è mancante o errata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Per i flussi di lavoro di rilevamento, convalida e crittografia delle password, vedere [Password-Protect Presentations](/slides/it/python-java/password-protected-presentation/). Se una presentazione crittografata è stata deliberatamente salvata con proprietà del documento pubbliche, tali proprietà possono essere lette senza password; vedere [Manage Presentation Properties](/slides/it/python-java/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) restituisce le opzioni che controllano come Aspose.Slides gestisce i grandi oggetti binari come immagini, audio e video. È possibile mantenere il file sorgente bloccato, consentire file temporanei e limitare la quantità di dati BLOB mantenuti in memoria.

Il seguente codice Python dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), il file sorgente rimane bloccato fino a quando l'istanza della presentazione non viene disposta. Non spostare, sovrascrivere o eliminare il file sorgente mentre quell'istanza è attiva.

Aspose.Slides può copiare il contenuto di un flusso di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso file è quindi generalmente più efficiente di un flusso. Vedere [Manage BLOBs](/slides/it/python-java/manage-blob/) per opzioni aggiuntive di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare le risorse esterne**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accetta un proxy JPype che implementa l'interfaccia Java di callback per il caricamento delle risorse. Il callback può fornire dati di sostituzione, reindirizzare una risorsa, utilizzare il caricatore predefinito o saltare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o di archiviazione specifiche dell'applicazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole conservare. Esempi includono:

- progetti VBA, disponibili tramite [Presentation.getVbaProject](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getVbaProject);
- dati OLE incorporati, disponibili tramite [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dati di controllo ActiveX, disponibili tramite [Control.getActiveXControlBinary](https://reference.aspose.com/slides/it/python-java/aspose.slides/control/#getActiveXControlBinary).

Impostare [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) su `True` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per mantenere il risultato sanificato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanificazione dei contenuti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Come posso capire se un file è danneggiato e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da un errore di password errata in modo che l'applicazione possa segnalare con precisione la causa.

**Cosa succede se i font richiesti sono mancanti?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. È possibile [configure font substitution](/slides/it/python-java/font-substitution/) o [provide custom fonts](/slides/it/python-java/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

L'audio e il video incorporati diventano disponibili tramite il modello oggetto della presentazione. Le risorse esterne vengono risolte secondo il comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non possono essere raggiunte.