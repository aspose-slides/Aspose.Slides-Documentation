---
title: Gestire i BLOB della presentazione in .NET per un uso efficiente della memoria
linktitle: Gestisci BLOB
type: docs
weight: 10
url: /it/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Gestisci i dati BLOB in Aspose.Slides per .NET per semplificare le operazioni su file PowerPoint e OpenDocument per una gestione efficiente delle presentazioni."
---
## **Panoramica**

Aspose.Slides fornisce una gestione basata su BLOB per dati binari di grandi dimensioni nelle presentazioni, aiutando a ridurre il consumo di memoria quando si lavora con immagini, audio, video e file di presentazione di grandi dimensioni.

Questo articolo mostra come utilizzare l'elaborazione basata su BLOB per aggiungere media di grandi dimensioni a una presentazione, esportare media di grandi dimensioni da una presentazione e caricare presentazioni di grandi dimensioni in modo più efficiente. Spiega inoltre come i file temporanei possono essere utilizzati durante l'elaborazione e come modificare la cartella usata per archiviarli.

## **Informazioni su BLOB**

**BLOB** (**Binary Large Object**) è generalmente un elemento di grandi dimensioni (foto, presentazione, documento o media) salvato in formati binari.  

Aspose.Slides for .NET consente di utilizzare i BLOB per gli oggetti in modo da ridurre il consumo di memoria quando sono coinvolti file di grandi dimensioni.

## **Utilizzare BLOB per ridurre il consumo di memoria**

### **Aggiungere un file di grandi dimensioni tramite BLOB a una presentazione**

[Aspose.Slides](/slides/it/net/) for .NET consente di aggiungere file di grandi dimensioni (in questo caso, un file video di grandi dimensioni) attraverso un processo che utilizza i BLOB per ridurre il consumo di memoria.

Questo C# mostra come aggiungere un file video di grandi dimensioni tramite il processo BLOB a una presentazione:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// Crea una nuova presentazione a cui verrà aggiunto il video
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // Aggiungiamo il video alla presentazione - abbiamo scelto il comportamento KeepLocked perché 
        //non intendiamo accedere al file "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria 
        //rimane basso per tutta la durata dell'oggetto pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **Esportare un file di grandi dimensioni tramite BLOB da una presentazione**
Aspose.Slides for .NET consente di esportare file di grandi dimensioni (in questo caso, un file audio o video) attraverso un processo che utilizza i BLOB dalle presentazioni. Ad esempio, potresti dover estrarre un file multimediale di grandi dimensioni da una presentazione ma non vuoi che il file venga caricato nella memoria del tuo computer. Esportando il file tramite il processo BLOB, mantieni basso il consumo di memoria.

Questo codice in C# dimostra l'operazione descritta:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// Blocca il file di origine e NON lo carica in memoria
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Crea un'istanza di Presentation, blocca il file "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// Salviamo ogni video in un file. Per evitare un alto utilizzo di memoria, abbiamo bisogno di un buffer che sarà usato
	// per trasferire i dati dallo stream video della presentazione a uno stream per un nuovo file video.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// Apre lo stream video della presentazione. Si noti che abbiamo evitato intenzionalmente l'accesso alle proprietà
		// come video.BinaryData - perché questa proprietà restituisce un array di byte contenente il video completo, il che
		// causa il caricamento dei byte in memoria. Usiamo video.GetStream, che restituisce uno Stream - e NON
		//  richiede di caricare l'intero video in memoria.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// Il consumo di memoria rimarrà basso indipendentemente dalla dimensione del video o della presentazione,
	}

	// Se necessario, è possibile applicare gli stessi passaggi per i file audio. 
}
```

### **Aggiungere un'immagine come BLOB a una presentazione**
Con i metodi dell'interfaccia [**IImageCollection**](https://reference.aspose.com/slides/it/net/aspose.slides/iimagecollection) e della classe [**ImageCollection** ](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection), è possibile aggiungere un'immagine di grandi dimensioni come stream per farla trattare come BLOB.  

Questo codice C# mostra come aggiungere un'immagine di grandi dimensioni tramite il processo BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

//	Crea una nuova presentazione a cui verrà aggiunta l'immagine.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		//	Aggiungiamo l'immagine alla presentazione - scegliamo il comportamento KeepLocked perché noi
		//	NON intendiamo accedere al file "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		//	Salva la presentazione. Mentre viene generata una presentazione di grandi dimensioni, il consumo di memoria 
		//	rimane basso per tutta la durata dell'oggetto pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **Memoria e presentazioni di grandi dimensioni**

Tipicamente, per caricare una presentazione di grandi dimensioni, i computer richiedono molta memoria temporanea. Tutto il contenuto della presentazione viene caricato in memoria e il file (da cui è stata caricata la presentazione) smette di essere utilizzato.  

Considera una presentazione PowerPoint di grandi dimensioni (large.pptx) che contiene un video da 1,5 GB. Il metodo standard per caricare la presentazione è descritto in questo codice C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

Ma questo metodo consuma circa 1,6 GB di memoria temporanea.  

### **Caricare una presentazione di grandi dimensioni come BLOB**
Attraverso il processo che coinvolge un BLOB, è possibile caricare una presentazione di grandi dimensioni utilizzando poca memoria. Questo codice C# descrive l'implementazione in cui il processo BLOB è usato per caricare un file di presentazione di grandi dimensioni (large.pptx):

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **Modificare la cartella per i file temporanei**
Quando il processo BLOB è usato, il computer crea file temporanei nella cartella predefinita per i file temporanei. Se desideri che i file temporanei vengano conservati in una cartella diversa, puoi modificare le impostazioni di archiviazione usando `TempFilesRootPath`:

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
Quando usi `TempFilesRootPath`, Aspose.Slides non crea automaticamente una cartella per archiviare i file temporanei. Devi creare la cartella manualmente.  
{{% /alert %}}

### **Eliminare gli oggetti Presentation per liberare la memoria**
Durante l'elaborazione di presentazioni di grandi dimensioni, assicurati che l'istanza [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) sia correttamente eliminata in modo che la memoria occupata venga rilasciata. Il metodo consigliato è utilizzare una dichiarazione `using` o una dichiarazione esplicita come mostrato negli esempi precedenti; essa elimina automaticamente la presentazione e libera le risorse non gestite quando il blocco termina.

Se crei una presentazione senza un blocco `using`, chiama esplicitamente `Dispose()` dopo aver terminato l'utilizzo.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...elabora la presentazione...
presentation.Save("large.pdf", SaveFormat.Pdf);

// Rilascia esplicitamente le risorse.
presentation.Dispose();
```

## **FAQ**

**Quali dati in una presentazione Aspose.Slides sono trattati come BLOB e controllati dalle opzioni BLOB?**  
Gli oggetti binari di grandi dimensioni come immagini, audio e video sono trattati come BLOB. L'intero file della presentazione coinvolge anche la gestione BLOB quando viene caricato o salvato. Questi oggetti sono governati da politiche BLOB che consentono di gestire l'uso della memoria e di ricorrere a file temporanei quando necessario.

**Dove posso configurare le regole di gestione BLOB durante il caricamento della presentazione?**  
Usa [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/) con [BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/blobmanagementoptions/). Qui imposti il limite in‑memoria per i BLOB, consenti o vieti i file temporanei, scegli il percorso radice per i file temporanei e selezioni il comportamento di blocco della sorgente.

**Le impostazioni BLOB influenzano le prestazioni e come bilanciare velocità e memoria?**  
Sì. Mantenere i BLOB in memoria massimizza la velocità ma aumenta il consumo di RAM; ridurre il limite di memoria sposta più lavoro sui file temporanei, riducendo la RAM a costo di I/O aggiuntivo. Regola la soglia [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/it/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) per trovare il giusto equilibrio per il tuo carico di lavoro e ambiente.

**Le opzioni BLOB aiutano quando si aprono presentazioni estremamente grandi (ad esempio, gigabyte)?**  
Sì. [BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/blobmanagementoptions/) sono progettate per tali scenari: abilitare i file temporanei e usare il blocco della sorgente può ridurre significativamente l'uso di RAM ai picchi e stabilizzare l'elaborazione di deck molto grandi.

**Posso usare le politiche BLOB quando carico da stream invece che da file su disco?**  
Sì. Le stesse regole si applicano agli stream: l'istanza della presentazione può possedere e bloccare lo stream di input (a seconda della modalità di blocco scelta) e i file temporanei sono usati quando consentiti, mantenendo prevedibile l'uso della memoria durante l'elaborazione.