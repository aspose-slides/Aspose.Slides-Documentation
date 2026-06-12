---
title: "Gestire i BLOB di presentazione in JavaScript per un uso efficiente della memoria"
linktitle: "Gestire BLOB"
type: docs
weight: 10
url: /it/nodejs-java/manage-blob/
keywords:
- "oggetto di grandi dimensioni"
- "elemento di grandi dimensioni"
- "file grande"
- "aggiungere BLOB"
- "esportare BLOB"
- "aggiungere immagine come BLOB"
- "ridurre la memoria"
- "consumo di memoria"
- "presentazione grande"
- "file temporaneo"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Gestire i dati BLOB in JavaScript con Aspose.Slides per Node.js per semplificare le operazioni sui file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce una gestione basata su BLOB per grandi dati binari nelle presentazioni, contribuendo a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come utilizzare file temporanei durante l'elaborazione e come modificare la cartella utilizzata per memorizzarli.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formati binari.  

Aspose.Slides for Node.js via Java consente di usare i BLOB per gli oggetti in un modo che riduce il consumo di memoria quando sono coinvolti file di grandi dimensioni.

{{% alert title="Info" color="info" %}}
Per aggirare alcune limitazioni nell'interazione con gli stream, Aspose.Slides può copiare il contenuto dello stream. Il caricamento di una presentazione di grandi dimensioni attraverso il suo stream comporta la copia del contenuto della presentazione e provoca un caricamento lento. Pertanto, quando si intende caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione e non il suo stream.
{{% /alert %}}

## **Usa BLOB per ridurre il consumo di memoria**

### **Aggiungi file di grandi dimensioni tramite BLOB a una presentazione**

[Aspose.Slides](/slides/it/nodejs-java/) for Node.js via Java consente di aggiungere file di grandi dimensioni (in questo caso, un file video di grandi dimensioni) attraverso un processo che coinvolge i BLOB per ridurre il consumo di memoria.

Questo JavaScript mostra come aggiungere un file video di grandi dimensioni tramite il processo BLOB a una presentazione:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Crea una nuova presentazione a cui verrà aggiunto il video
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Aggiungiamo il video alla presentazione – abbiamo scelto il comportamento KeepLocked perché
        // non intendiamo accedere al file "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria
        // rimane basso per tutto il ciclo di vita dell'oggetto pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Esporta file di grandi dimensioni tramite BLOB da una presentazione**

Aspose.Slides for Node.js via Java consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) attraverso un processo che coinvolge i BLOB dalle presentazioni. Ad esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione ma non vuoi che il file venga caricato nella memoria del tuo computer. Esportando il file tramite il processo BLOB, mantieni basso il consumo di memoria.

Questo codice in JavaScript dimostra l'operazione descritta:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Blocca il file di origine e NON lo carica in memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// crea l'istanza della Presentation, blocca il file "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Salviamo ogni video in un file. Per evitare un elevato utilizzo della memoria, abbiamo bisogno di un buffer che sarà usato
    // per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video.
    var buffer = new byte[8 * 1024];
    // Itera attraverso i video
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Apre lo stream video della presentazione. Si noti che abbiamo evitato intenzionalmente l'accesso alle proprietà
        // come video.BinaryData – poiché questa proprietà restituisce un array di byte contenente l'intero video, il che
        // causa il caricamento dei byte in memoria. Usiamo video.GetStream, che restituisce uno Stream – e NON
        // richiede di caricare l'intero video nella memoria.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Il consumo di memoria rimarrà basso indipendentemente dalla dimensione del video o della presentazione.
    }
    // Se necessario, è possibile applicare gli stessi passaggi per i file audio.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Aggiungi immagine come BLOB in una presentazione**

Con i metodi della classe [**ImageCollection**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ImageCollection) e della classe [**ImageCollection** ](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ImageCollection) è possibile aggiungere un'immagine di grandi dimensioni come stream per farla trattare come BLOB.

Questo codice JavaScript mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// crea una nuova presentazione a cui verrà aggiunta l'immagine.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Aggiungiamo l'immagine alla presentazione – scegliamo il comportamento KeepLocked perché noi
        // NON intendiamo accedere al file "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria
        // rimane basso per tutto il ciclo di vita dell'oggetto pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Memoria e presentazioni di grandi dimensioni**

Tipicamente, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file (da cui è stata caricata la presentazione) smette di essere usato.  

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice JavaScript:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ma questo metodo consuma circa 1,6 GB di memoria temporanea.  

### **Carica una presentazione di grandi dimensioni come BLOB**

Attraverso il processo che coinvolge un BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice JavaScript descrive l'implementazione in cui il processo BLOB è usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Modifica la cartella per i file temporanei**

Quando il processo BLOB è utilizzato, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei siano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione usando `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Quando utilizzi `setTempFilesRootPath`, Aspose.Slides non crea automaticamente una cartella per memorizzare i file temporanei. Devi creare la cartella manualmente.
{{% /alert %}}

### **Elimina gli oggetti Presentation per liberare la memoria**

Quando si elaborano presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) sia correttamente eliminata in modo che la memoria occupata venga rilasciata. Chiama `dispose()` dopo aver terminato l'uso della presentazione per liberare le risorse non gestite.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...elabora la presentazione...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Rilascia esplicitamente le risorse.
presentation.dispose();
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides sono trattati come BLOB e controllati dalle opzioni BLOB?**  
Oggetti binari di grandi dimensioni come immagini, audio e video sono trattati come BLOB. Anche l'intero file di presentazione coinvolge la gestione BLOB quando viene caricato o salvato. questi oggetti sono governati da politiche BLOB che consentono di gestire l'uso della memoria e di ricorrere a file temporanei quando necessario.

**Dove configuro le regole di gestione BLOB durante il caricamento della presentazione?**  
Usa [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/blobmanagementoptions/). Lì imposti il limite in‑memoria per i BLOB, consenti o meno i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di lock della sorgente.

**Le impostazioni BLOB influenzano le prestazioni e come bilanciare velocità vs memoria?**  
Sì. Tenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; abbassare il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM al costo di I/O aggiuntivo. Usa il metodo [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) per trovare il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Le opzioni BLOB aiutano quando si aprono presentazioni estremamente grandi (ad esempio gigabyte)?**  
Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/blobmanagementoptions/) sono progettate per questi scenari: abilitare i file temporanei e usare il lock della sorgente può ridurre significativamente l'uso di RAM di picco e stabilizzare l'elaborazione per deck molto grandi.

**Posso usare le politiche BLOB quando carico da stream invece che da file su disco?**  
Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di input (a seconda della modalità di lock scelta) e i file temporanei vengono usati quando consentiti, mantenendo prevedibile l'uso della memoria durante l'elaborazione.