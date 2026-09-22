---
title: Aprire presentazioni in Java
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/java/open-presentation/
keywords:
- apri PowerPoint
- apri presentazione
- apri PPTX
- apri PPT
- apri ODP
- carica presentazione
- carica PPTX
- carica PPT
- carica ODP
- presentazione protetta
- presentazione di grandi dimensioni
- risorsa esterna
- oggetto binario
- Java
- Aspose.Slides
description: "Impara come aprire presentazioni PowerPoint e OpenDocument in Java, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso di memoria con Aspose.Slides per Java."
---
## **Introduzione**

[Aspose.Slides per Java](https://products.aspose.com/slides/it/java/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionare la sua struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari fuori dalla memoria heap di Java, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire presentazioni**

Dopo aver caricato un file o un flusso, è possibile [determinare il formato originale della presentazione](/slides/it/java/detect-presentation-source-format/) per scegliere come l'applicazione lo elaborerà.

Per aprire una presentazione esistente, passare il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Disporre della presentazione dopo l'uso in modo che i handle dei file, i dati temporanei e le altre risorse vengano rilasciati prontamente.

Il seguente esempio Java mostra come aprire una presentazione e ottenere il numero di diapositive:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni protette da password**

Una password di apertura cripta il contenuto della presentazione. Per caricare l'intera presentazione, passare la password corretta a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) e fornire le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Il caricamento fallisce se la password è mancante o errata.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Per il rilevamento, la convalida e i flussi di lavoro di crittografia delle password, vedere [Proteggere le presentazioni con password](/slides/it/java/password-protected-presentation/). Se una presentazione crittografata è stata salvata deliberatamente con proprietà del documento pubbliche, tali proprietà possono essere lette senza password; vedere [Gestire le proprietà della presentazione](/slides/it/java/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) restituisce le opzioni che controllano come Aspose.Slides gestisce i binary large objects (BLOB) come immagini, audio e video. È possibile mantenere il file di origine bloccato, consentire file temporanei e limitare la quantità di dati BLOB mantenuti in memoria.

Il seguente codice Java dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked), il file di origine rimane bloccato finché l'istanza della presentazione non viene eliminata. Non spostare, sovrascrivere o eliminare il file di origine mentre quell'istanza è attiva.

Aspose.Slides può copiare il contenuto di un flusso di input durante il caricamento. Per le presentazioni di grandi dimensioni, un percorso di file è quindi generalmente più efficiente di un flusso. Vedere [Gestire i BLOB](/slides/it/java/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare le risorse esterne**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) accetta un'implementazione di [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/). Il callback può fornire dati di sostituzione, reindirizzare una risorsa, utilizzare il caricatore predefinito o ignorare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o di archiviazione specifiche dell'applicazione.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole conservare. Esempi includono:

- Progetti VBA, disponibili tramite [IPresentation.getVbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getVbaProject--);
- Dati OLE incorporati, disponibili tramite [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- Dati di controllo ActiveX, disponibili tramite [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/it/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Impostare [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) su `true` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per conservare il risultato sanificato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanificazione dei contenuti.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Domande frequenti**

**Come posso capire se un file è corrotto e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da un errore di password errata in modo che l'applicazione possa segnalare la causa in modo preciso.

**Cosa succede se i font richiesti mancano?**

La presentazione può ancora essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. È possibile [configurare la sostituzione dei font](/slides/it/java/font-substitution/) o [fornire font personalizzati](/slides/it/java/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

L'audio e il video incorporati diventano disponibili tramite il modello a oggetti della presentazione. Le risorse esterne vengono risolte in base al comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non possono essere raggiunte.