---
title: Gestisci i BLOB della presentazione in PHP per un uso efficiente della memoria
linktitle: Gestisci BLOB
type: docs
weight: 10
url: /it/php-java/manage-blob/
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
- PHP
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per PHP via Java per semplificare le operazioni sui file PowerPoint e OpenDocument, garantendo una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides offre una gestione basata su BLOB per grandi dati binari nelle presentazioni per contribuire a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come i file temporanei possono essere utilizzati durante l'elaborazione e come modificare la cartella utilizzata per archiviarli.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formati binari. 

Aspose.Slides per PHP via Java consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

{{% alert title="Info" color="info" %}}
Per aggirare alcune limitazioni quando si interagisce con gli stream, Aspose.Slides può copiare il contenuto dello stream. Caricare una presentazione di grandi dimensioni tramite il suo stream provocherà la copia del contenuto della presentazione e rallenterà il caricamento. Pertanto, quando intendi caricare una presentazione di grandi dimensioni, ti consigliamo vivamente di utilizzare il percorso del file di presentazione e non il suo stream.
{{% /alert %}}

## **Usa BLOB per Ridurre il Consumo di Memoria**

### **Aggiungi un File di Grandi Dimensioni tramite BLOB a una Presentazione**

[Aspose.Slides](/slides/it/php-java/) per Java consente di aggiungere file di grandi dimensioni (in questo caso, un file video di grandi dimensioni) tramite un processo che coinvolge BLOB per ridurre il consumo di memoria.

Questo esempio Java mostra come aggiungere un file video di grandi dimensioni tramite il processo BLOB a una presentazione:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Crea una nuova presentazione a cui verrà aggiunto il video
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Aggiungiamo il video alla presentazione - abbiamo scelto il comportamento KeepLocked perché noi
      # non intendiamo accedere al file "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Salva la presentazione. Mentre una presentazione di grandi dimensioni viene generata, il consumo di memoria
      # rimane basso per tutta la durata dell'oggetto pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Esporta un File di Grandi Dimensioni tramite BLOB da una Presentazione**
Aspose.Slides per PHP via Java consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) tramite un processo che coinvolge BLOB dalle presentazioni. Ad esempio, potresti aver bisogno di estrarre un file multimediale di grandi dimensioni da una presentazione ma non vuoi che il file venga caricato nella memoria del tuo computer. Esportando il file tramite il processo BLOB, mantieni basso il consumo di memoria.

Questo codice dimostra l'operazione descritta:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Blocca il file sorgente e NON lo carica in memoria
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # crea l'istanza di Presentation, blocca il file "hugePresentationWithAudiosAndVideos.pptx".
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Salviamo ogni video in un file. Per evitare un alto utilizzo di memoria, abbiamo bisogno di un buffer che sarà usato
    # per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video creato.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Itera attraverso i video
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Apre lo stream video della presentazione. Si prega di notare che abbiamo intenzionalmente evitato l'accesso alle proprietà
      # come video.BinaryData - perché questa proprietà restituisce un array di byte contenente l'intero video, il che
      # fa sì che i byte vengano caricati in memoria. Usiamo video.GetStream, che restituirà uno Stream - e NON
      # richiederà di caricare l'intero video nella memoria.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Il consumo di memoria rimarrà basso indipendentemente dalla dimensione del video o della presentazione.
    }
    # Se necessario, è possibile applicare gli stessi passaggi per i file audio.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Aggiungi un'Immagine come BLOB a una Presentazione**
Con i metodi della classe [ImageCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/imagecollection/), è possibile aggiungere un'immagine di grandi dimensioni come stream per farla trattare come un BLOB.

Questo codice PHP mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # crea una nuova presentazione a cui verrà aggiunta l'immagine.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Aggiungiamo l'immagine alla presentazione - scegliamo il comportamento KeepLocked perché noi
      # NON intendiamo accedere al file "largeImage.png".
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Salva la presentazione. Mentre una presentazione di grandi dimensioni viene generata, il consumo di memoria
      # rimane basso per tutta la durata dell'oggetto pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Memoria e Presentazioni di Grandi Dimensioni**

Tipicamente, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. L'intero contenuto della presentazione viene caricato in memoria e il file (da cui è stata caricata la presentazione) non viene più utilizzato. 

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un file video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice PHP:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ma questo metodo consuma circa 1,6 GB di memoria temporanea. 

### **Carica una Presentazione di Grandi Dimensioni come BLOB**

Attraverso il processo che coinvolge un BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice PHP descrive l'implementazione in cui il processo BLOB viene usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Modifica la Cartella per i File Temporanei**

Quando viene utilizzato il processo BLOB, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei siano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione utilizzando `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Quando utilizzi `setTempFilesRootPath`, Aspose.Slides non crea automaticamente una cartella per archiviare i file temporanei. Devi creare la cartella manualmente. 
{{% /alert %}}

### **Elimina gli Oggetti Presentation per Rilasciare la Memoria**

Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) sia correttamente eliminata in modo che la memoria occupata venga rilasciata. Chiama `dispose()` dopo aver terminato l'uso della presentazione per liberare le risorse non gestite.

```php
$presentation = new Presentation("large.pptx");

# ...processa la presentazione...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Rilascia esplicitamente le risorse.
$presentation->dispose();
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides vengono trattati come BLOB e controllati dalle opzioni BLOB?**

Gli oggetti binari di grandi dimensioni come immagini, audio e video vengono trattati come BLOB. L'intero file di presentazione coinvolge anche la gestione BLOB quando viene caricato o salvato. Questi oggetti sono regolati dalle politiche BLOB che consentono di gestire l'uso della memoria e di ricorrere a file temporanei quando necessario.

**Where do I configure BLOB handling rules during presentation loading?**  
Utilizza [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/blobmanagementoptions/). Qui imposti il limite in memoria per i BLOB, consenti o vieti i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della sorgente.

**Do BLOB settings affect performance, and how do I balance speed vs memory?**  
Sì. Mantenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; abbassare il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a costo di I/O aggiuntivo. Usa il metodo [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) per ottenere il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**  
Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/blobmanagementoptions/) sono progettate per tali scenari: abilitare i file temporanei e utilizzare il blocco della sorgente può ridurre significativamente l'uso di RAM massimo e stabilizzare l'elaborazione per deck molto grandi.

**Can I use BLOB policies when loading from streams instead of disk files?**  
Sì. Le stesse regole si applicano agli stream: l'istanza di presentazione può possedere e bloccare lo stream di input (a seconda della modalità di blocco scelta), e i file temporanei vengono usati quando consentiti, mantenendo l'uso della memoria prevedibile durante l'elaborazione.