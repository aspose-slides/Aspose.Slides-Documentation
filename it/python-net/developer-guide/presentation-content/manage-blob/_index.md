---
title: Gestire i BLOB nelle presentazioni con Python per un uso efficiente della memoria
linktitle: Gestire BLOB
type: docs
weight: 10
url: /it/python-net/manage-blob/
keywords:
- oggetto grande
- elemento grande
- file grande
- aggiungere BLOB
- esportare BLOB
- aggiungere immagine come BLOB
- ridurre la memoria
- consumo di memoria
- presentazione grande
- file temporaneo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per Python via .NET per semplificare le operazioni sui file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce una gestione basata su BLOB per i dati binari di grandi dimensioni nelle presentazioni, aiutando a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come utilizzare file temporanei durante l'elaborazione e come modificare la cartella utilizzata per memorizzarli.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formato binario.  

Aspose.Slides for Python via .NET consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

## **Utilizzare BLOB per ridurre il consumo di memoria**

### **Aggiungere un file di grandi dimensioni tramite BLOB a una presentazione**

[Aspose.Slides](/slides/it/python-net/) per .NET consente di aggiungere file di grandi dimensioni (in questo caso, un file video di grandi dimensioni) attraverso un processo basato su BLOB per ridurre il consumo di memoria.

Questo esempio Python mostra come aggiungere un file video di grandi dimensioni tramite il processo BLOB a una presentazione:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Crea una nuova presentazione a cui verrà aggiunto il video
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Aggiungiamo il video alla presentazione - abbiamo scelto il comportamento KeepLocked perché noi
        # non intendiamo accedere al file "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Salva la presentazione. Mentre una presentazione grande viene generata, il consumo di memoria
        # rimane basso per tutta la durata dell'oggetto pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **Esportare un file di grandi dimensioni tramite BLOB da una presentazione**
Aspose.Slides for Python via .NET consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) attraverso un processo basato su BLOB dalle presentazioni. Ad esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione ma non vuoi che il file venga caricato nella memoria del computer. Esportando il file tramite il processo BLOB, mantieni il consumo di memoria ridotto.

Questo codice Python dimostra l'operazione descritta:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# Salviamo ogni video in un file. Per evitare un elevato consumo di memoria, abbiamo bisogno di un buffer che verrà usato
	# per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# Itera attraverso i video
    index = 0
    # Se necessario, puoi applicare gli stessi passaggi ai file audio. 
    for video in pres.videos:
		# Apre lo stream video della presentazione. Si noti che abbiamo evitato intenzionalmente di accedere alle proprietà
		# come video.BinaryData - perché questa proprietà restituisce un array di byte contenente l'intero video, il che
		# porta al caricamento dei byte in memoria. Usiamo video.GetStream, che restituirà uno Stream - e NON
		#  richiede di caricare l'intero video in memoria.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **Aggiungere un'immagine come BLOB in una presentazione**
Con i metodi della classe [**ImageCollection**](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) è possibile aggiungere un'immagine di grandi dimensioni come stream per farla trattare come BLOB.  

Questo codice Python mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```py
import aspose.slides as slides

# crea una nuova presentazione a cui verrà aggiunta l'immagine.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Memoria e presentazioni di grandi dimensioni**

Tipicamente, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file (da cui la presentazione è stata caricata) non viene più utilizzato.  

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

Tuttavia, questo metodo consuma circa 1,6 GB di memoria temporanea.  

### **Caricare una presentazione di grandi dimensioni come BLOB**
Attraverso il processo basato su BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice Python descrive l'implementazione in cui il processo BLOB è usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **Modificare la cartella per i file temporanei**
Quando viene usato il processo BLOB, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei vengano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione utilizzando `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
Quando utilizzi `temp_files_root_path`, Aspose.Slides non crea automaticamente una cartella per memorizzare i file temporanei. È necessario creare la cartella manualmente. 
{{% /alert %}}

### **Rilasciare gli oggetti Presentation per liberare la memoria**
Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) venga correttamente eliminata in modo che la memoria occupata venga rilasciata. Il metodo consigliato è utilizzare il gestore di contesto (`with slides.Presentation(...) as presentation:`) come mostrato negli esempi sopra; chiude automaticamente la presentazione e libera le risorse non gestite all'uscita del blocco.

Se crei una presentazione senza un blocco `with`, chiama esplicitamente `presentation.dispose()` dopo aver terminato l'uso e rimuovi eventuali riferimenti residui affinché il garbage collector di Python possa recuperare la memoria.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...processa la presentazione...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# Rilascia esplicitamente le risorse.
presentation.dispose()
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides vengono trattati come BLOB e controllati dalle opzioni BLOB?**  
Oggetti binari di grandi dimensioni come immagini, audio e video vengono trattati come BLOB. L'intero file della presentazione coinvolge anch'esso la gestione BLOB quando viene caricato o salvato. Questi oggetti sono regolati dalle politiche BLOB che consentono di gestire l'uso della memoria e di scrivere su file temporanei quando necessario.  

**Dove configuro le regole di gestione BLOB durante il caricamento di una presentazione?**  
Utilizza [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/blobmanagementoptions/). Qui imposti il limite di memoria per i BLOB, consenti o vieti i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della sorgente.  

**Le impostazioni BLOB influiscono sulle prestazioni e come bilanciare velocità e memoria?**  
Sì. Tenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; ridurre il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a scapito di I/O aggiuntivo. Regola la soglia [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/it/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) per ottenere il giusto equilibrio per il tuo carico di lavoro e ambiente.  

**Le opzioni BLOB aiutano quando si aprono presentazioni estremamente grandi (ad es. gigabyte)?**  
Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/blobmanagementoptions/) sono progettate per tali scenari: abilitare i file temporanei e usare il blocco della sorgente può ridurre significativamente l'uso di RAM massimo e stabilizzare l'elaborazione di presentazioni molto grandi.  

**Posso usare le politiche BLOB quando carico da stream anziché da file su disco?**  
Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di input (in base al modo di blocco scelto) e i file temporanei vengono usati quando consentiti, mantenendo l'uso della memoria prevedibile durante l'elaborazione.