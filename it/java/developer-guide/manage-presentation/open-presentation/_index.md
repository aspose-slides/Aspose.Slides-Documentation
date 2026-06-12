---
title: Aprire le presentazioni in Java
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/java/open-presentation/
keywords:
- aprire PowerPoint
- aprire OpenDocument
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
- Java
- Aspose.Slides
description: "Apri presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) senza sforzo con Aspose.Slides per Java—rapido, affidabile, completo."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides ti consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, puoi recuperare informazioni su di essa, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e altro ancora.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, istanzia la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e passa il percorso del file al suo costruttore.

Il seguente esempio Java mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```java
// Istanzia la classe Presentation e passa un percorso file al suo costruttore.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Stampa il numero totale di diapositive nella presentazione.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni protette da password**

Quando devi aprire una presentazione protetta da password, passa la password tramite il metodo [setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) della classe [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) per decrittarla e caricarla. Il seguente codice Java dimostra questa operazione:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Esegui operazioni sulla presentazione decifrata.
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides fornisce opzioni—in particolare il metodo [getBlobManagementOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) nella classe [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/)—per aiutarti a caricare presentazioni di grandi dimensioni.

Il seguente codice Java dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Scegli il comportamento KeepLocked—il file della presentazione rimarrà bloccato per tutta la durata di
// l'istanza Presentation, ma non è necessario caricarlo in memoria o copiarlo in un file temporaneo.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // La grande presentazione è stata caricata e può essere usata, mentre il consumo di memoria rimane basso.

    // Apporta modifiche alla presentazione.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Salva la presentazione in un altro file. Il consumo di memoria rimane basso durante questa operazione.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Non farlo! Verrà lanciata un'eccezione I/O perché il file è bloccato finché l'oggetto presentation non viene eliminato.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Va bene farlo qui. Il file sorgente non è più bloccato dall'oggetto presentation.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Per aggirare alcune limitazioni quando si lavora con i flussi, Aspose.Slides può copiare il contenuto di un flusso. Caricare una presentazione di grandi dimensioni da un flusso provoca la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché un flusso.

Quando crei una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), puoi usare la [gestione BLOB](/slides/it/java/manage-blob/) per ridurre il consumo di memoria.
{{%/alert %}}

## **Controllare le risorse esterne**

Aspose.Slides fornisce l'interfaccia [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/) che ti permette di gestire le risorse esterne. Il seguente codice Java mostra come utilizzare l'interfaccia `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```
```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Carica un'immagine sostitutiva.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Imposta un URL sostitutivo.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Ignora tutte le altre immagini.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- Progetto VBA (accessibile tramite [IPresentation.getVbaProject](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Dati incorporati dell'oggetto OLE (accessibili tramite [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Dati binari del controllo ActiveX (accessibili tramite [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/it/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Utilizzando il metodo [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questo metodo è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice Java dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Esegui operazioni sulla presentazione.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Riceverai un'eccezione di convalida del parsing/formato durante il caricamento. Questo tipo di errore spesso indica una struttura ZIP non valida o record PowerPoint corrotti.

**Cosa succede se i font richiesti sono mancanti durante l'apertura?**

Il file si aprirà, ma in seguito il [rendering/export](/slides/it/java/convert-presentation/) potrebbe sostituire i font. [Configura le sostituzioni dei font](/slides/it/java/font-substitution/) o [aggiungi i font richiesti](/slides/it/java/custom-font/) all'ambiente di runtime.

**Cosa succede ai media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono riferiti tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti il [rendering/export](/slides/it/java/convert-presentation/) potrebbe omettere i media.