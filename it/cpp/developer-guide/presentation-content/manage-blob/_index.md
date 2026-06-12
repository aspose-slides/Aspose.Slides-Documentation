---
title: Gestire i BLOB di presentazione in C++ per un uso efficiente della memoria
linktitle: Gestisci BLOB
type: docs
weight: 10
url: /it/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per C++ per semplificare le operazioni sui file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce la gestione basata su BLOB per grandi dati binari nelle presentazioni per contribuire a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come i file temporanei possono essere utilizzati durante l'elaborazione e come modificare la cartella utilizzata per memorizzarli.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è solitamente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formati binari.

Aspose.Slides per C++ consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

## **Utilizzare BLOB per ridurre il consumo di memoria**

### **Aggiungere un file di grandi dimensioni tramite BLOB a una presentazione**

[Aspose.Slides](/slides/it/cpp/) per C++ consente di aggiungere file di grandi dimensioni (in questo caso, un file video di grandi dimensioni) tramite un processo che coinvolge BLOB per ridurre il consumo di memoria.

Questo codice C++ mostra come aggiungere un file video di grandi dimensioni tramite il processo BLOB a una presentazione:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// Crea una nuova presentazione a cui verrà aggiunto il video
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// Aggiungiamo il video alla presentazione - abbiamo scelto il comportamento KeepLocked perché noi
//non intendiamo accedere al file "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// Salva la presentazione. Mentre una presentazione di grandi dimensioni viene creata, il consumo di memoria
// rimane basso per l'intero ciclo di vita dell'oggetto pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **Esportare un file di grandi dimensioni tramite BLOB da una presentazione**

Aspose.Slides per C++ consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) tramite un processo che coinvolge BLOB dalle presentazioni. Ad esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione ma non desideri che il file venga caricato nella memoria del tuo computer. Esportando il file tramite il processo BLOB, mantieni basso il consumo di memoria.

Questo codice C++ dimostra l'operazione descritta:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Crea un'istanza di Presentation, blocca il file "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// Salviamo ogni video in un file. Per evitare un alto consumo di memoria, abbiamo bisogno di un buffer che sarà usato
// per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Scorre tutti i video
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// Apre lo stream video della presentazione. Nota, per favore, che abbiamo evitato intenzionalmente di accedere ai metodi
	// come video->get_BinaryData - perché questo metodo restituisce un array di byte contenente l'intero video, il che
	// comporta il caricamento dei byte in memoria. Utilizziamo video->GetStream, che restituisce uno Stream - e NON
	// richiede di caricare l'intero video in memoria.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// Il consumo di memoria rimarrà basso indipendentemente dalle dimensioni del video o della presentazione,
}

// Se necessario, è possibile applicare gli stessi passaggi ai file audio.
```

### **Aggiungere un'immagine come BLOB a una presentazione**

Con i metodi dell'interfaccia [**IImageCollection**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_image_collection) e della classe [**ImageCollection**](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.image_collection), è possibile aggiungere un'immagine di grandi dimensioni come stream per farla trattare come un BLOB.

Questo codice C++ mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// crea una nuova presentazione a cui verrà aggiunta l'immagine.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// Aggiungiamo l'immagine alla presentazione - scegliamo il comportamento KeepLocked perché noi
// NON intendiamo accedere al file "largeImage.png" file.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// Salva la presentazione. Mentre una presentazione di grandi dimensioni viene prodotta, il consumo di memoria 
// rimane basso per l'intero ciclo di vita dell'oggetto pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **Memoria e presentazioni di grandi dimensioni**

In genere, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file (da cui è stata caricata la presentazione) smette di essere utilizzato.

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un file video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

Ma questo metodo consuma circa 1,6 GB di memoria temporanea.

### **Caricare una presentazione di grandi dimensioni come BLOB**

Attraverso il processo che coinvolge un BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice C++ descrive l'implementazione in cui il processo BLOB è usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **Modificare la cartella per i file temporanei**

Quando si utilizza il processo BLOB, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei vengano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione usando `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
Quando utilizzi `TempFilesRootPath`, Aspose.Slides non crea automaticamente una cartella per memorizzare i file temporanei. Devi creare la cartella manualmente.
{{% /alert %}}

### **Rilasciare gli oggetti Presentation per liberare memoria**

Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) venga eliminata correttamente in modo che la memoria occupata venga rilasciata. Chiama `Dispose()` dopo aver terminato di utilizzare la presentazione per liberare le risorse non gestite.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides vengono trattati come BLOB e controllati dalle opzioni BLOB?**

Gli oggetti binari di grandi dimensioni come immagini, audio e video vengono trattati come BLOB. Anche l'intero file di presentazione coinvolge la gestione BLOB quando viene caricato o salvato. Questi oggetti sono soggetti alle politiche BLOB che ti consentono di gestire l'uso della memoria e di ricorrere a file temporanei quando necessario.

**Dove posso configurare le regole di gestione BLOB durante il caricamento di una presentazione?**

Utilizza [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/blobmanagementoptions/). Qui imposti il limite in memoria per i BLOB, consenti o vieti i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della sorgente.

**Le impostazioni BLOB influenzano le prestazioni e come bilanciare velocità vs memoria?**

Sì. Mantenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; abbassare il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a costo di ulteriori operazioni I/O. Usa il metodo [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) per trovare il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Le opzioni BLOB aiutano quando si aprono presentazioni estremamente grandi (ad esempio gigabyte)?**

Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/blobmanagementoptions/) sono progettate per questi scenari: abilitare i file temporanei e utilizzare il blocco della sorgente può ridurre significativamente l'uso di RAM di picco e stabilizzare l'elaborazione di presentazioni molto grandi.

**Posso utilizzare le politiche BLOB quando carico da stream anziché da file su disco?**

Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di input (a seconda della modalità di blocco scelta), e i file temporanei vengono utilizzati quando consentiti, mantenendo prevedibile l'uso della memoria durante l'elaborazione.