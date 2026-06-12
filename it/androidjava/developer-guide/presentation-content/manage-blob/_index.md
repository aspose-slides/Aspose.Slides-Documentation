---
title: Gestire i BLOB di presentazione su Android per un uso efficiente della memoria
linktitle: Gestire BLOB
type: docs
weight: 10
url: /it/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per Android tramite Java per semplificare le operazioni sui file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce una gestione basata su BLOB per i dati binari di grandi dimensioni nelle presentazioni, contribuendo a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come utilizzare i file temporanei durante l'elaborazione e come modificare la cartella in cui vengono memorizzati.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formati binari.

Aspose.Slides per Android via Java consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

{{% alert title="Info" color="info" %}}
Per aggirare alcune limitazioni nell'interazione con gli stream, Aspose.Slides potrebbe copiare il contenuto dello stream. Caricare una presentazione di grandi dimensioni tramite il suo stream comporta la copia del contenuto della presentazione e rallenta il caricamento. Pertanto, quando si intende caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione e non il suo stream.
{{% /alert %}}

## **Usare BLOB per ridurre il consumo di memoria**

### **Aggiungere un file di grandi dimensioni tramite BLOB a una presentazione**

[Aspose.Slides](/slides/it/androidjava/) per Java consente di aggiungere file di grandi dimensioni (in questo caso, un video di grandi dimensioni) mediante un processo basato su BLOB per ridurre il consumo di memoria.

Questo esempio Java mostra come aggiungere un video di grandi dimensioni tramite il processo BLOB a una presentazione:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nuova presentazione a cui verrà aggiunto il video
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Aggiungiamo il video alla presentazione - abbiamo scelto il comportamento KeepLocked perché non
        // intendiamo accedere al file "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria
        // rimane basso per tutto il ciclo di vita dell'oggetto pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Esportare un file di grandi dimensioni tramite BLOB da una presentazione**
Aspose.Slides per Android via Java consente di esportare file di grandi dimensioni (ad esempio un file audio o video) mediante un processo basato su BLOB dalle presentazioni. Per esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione senza caricarlo nella memoria del computer. Esportando il file tramite il processo BLOB, il consumo di memoria rimane basso.

Questo codice Java dimostra l'operazione descritta:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Blocca il file sorgente e NON lo carica in memoria
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// crea l'istanza di Presentation, blocca il file "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Salviamo ciascun video in un file. Per evitare un elevato consumo di memoria, abbiamo bisogno di un buffer che verrà usato
    // per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video.
    byte[] buffer = new byte[8 * 1024];

    // Itera tra i video
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Apre lo stream video della presentazione. Si noti che abbiamo intenzionalmente evitato di accedere alle proprietà
        // come video.BinaryData - perché questa proprietà restituisce un array di byte contenente l'intero video, il che
        // fa sì che i byte vengano caricati in memoria. Usiamo video.GetStream, che restituisce uno Stream - e NON
        //  richiede di caricare l'intero video nella memoria.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
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
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Aggiungere un'immagine come BLOB in una presentazione**
Con i metodi dell'interfaccia [**IImageCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IImageCollection) e della classe [**ImageCollection**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ImageCollection), è possibile aggiungere un'immagine di grandi dimensioni come stream per trattarla come BLOB.

Questo codice Java mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// crea una nuova presentazione a cui verrà aggiunta l'immagine.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Aggiungiamo l'immagine alla presentazione - scegliamo il comportamento KeepLocked perché noi
		// NON intendiamo accedere al file "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria
		// rimane basso per l'intero ciclo di vita dell'oggetto pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Memoria e presentazioni di grandi dimensioni**

Di norma, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file da cui è stata caricata la presentazione non viene più utilizzato.

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un video da 1,5 GB. Il metodo standard per caricare la presentazione è mostrato in questo codice Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Tuttavia, questo metodo consuma circa 1,6 GB di memoria temporanea.

### **Caricare una presentazione di grandi dimensioni come BLOB**

Attraverso un processo BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice Java descrive l'implementazione in cui il processo BLOB è usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Modificare la cartella per i file temporanei**

Quando il processo BLOB è in uso, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei vengano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione utilizzando `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Quando utilizzi `TempFilesRootPath`, Aspose.Slides non crea automaticamente una cartella per i file temporanei. È necessario creare la cartella manualmente.
{{% /alert %}}

### **Eliminare gli oggetti Presentation per rilasciare la memoria**

Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) venga eliminata correttamente in modo che la memoria occupata venga rilasciata. Chiama `dispose()` dopo aver terminato l'uso della presentazione per liberare le risorse non gestite.

```java
Presentation presentation = new Presentation("large.pptx");

// ...elabora la presentazione...
presentation.save("large.pdf", SaveFormat.Pdf);

// Rilascia esplicitamente le risorse.
presentation.dispose();
```

## **Domande frequenti**

**Quali dati in una presentazione Aspose.Slides sono trattati come BLOB e controllati dalle opzioni BLOB?**

Oggetti binari di grandi dimensioni come immagini, audio e video sono trattati come BLOB. Anche l'intero file di presentazione coinvolge la gestione BLOB quando viene caricato o salvato. Questi oggetti sono soggetti alle politiche BLOB che consentono di gestire l'uso della memoria e di spostare i dati su file temporanei quando necessario.

**Dove configuro le regole di gestione BLOB durante il caricamento della presentazione?**

Utilizza [LoadOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/blobmanagementoptions/). Qui imposti il limite di memoria per i BLOB, consenti o vieti i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della fonte.

**Le impostazioni BLOB influenzano le prestazioni e come bilanciare velocità e memoria?**

Sì. Mantenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; ridurre il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a scapito di un maggiore I/O. Usa il metodo [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) per trovare il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Le opzioni BLOB aiutano ad aprire presentazioni estremamente grandi (ad es., gigabyte)?**

Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/blobmanagementoptions/) sono progettate per questi scenari: abilitare i file temporanei e usare il blocco della fonte può ridurre significativamente l'uso di RAM al picco e stabilizzare l'elaborazione di presentazioni molto grandi.

**Posso utilizzare le politiche BLOB quando carico da stream anziché da file su disco?**

Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di ingresso (a seconda della modalità di blocco scelta) e i file temporanei vengono utilizzati quando consentiti, mantenendo prevedibile l'uso della memoria durante l'elaborazione.