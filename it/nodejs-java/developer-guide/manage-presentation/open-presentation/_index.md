---
title: Aprire presentazioni in JavaScript
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/nodejs-java/open-presentation/
keywords:
- apri PowerPoint
- apri OpenDocument
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apri presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) senza sforzo con Aspose.Slides per Node.js tramite Java—veloce, affidabile, completa."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, è possibile recuperare informazioni al riguardo, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e molto altro.

## **Aprire presentazioni**

Per aprire una presentazione esistente, istanzia la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e passa il percorso del file al suo costruttore.

Il seguente esempio JavaScript mostra come aprire una presentazione e ottenerne il conteggio delle diapositive:

```js
// Istanziate la classe Presentation e passate un percorso file al suo costruttore.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Stampa il numero totale di diapositive nella presentazione.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni protette da password**

Quando è necessario aprire una presentazione protetta da password, passa la password tramite il metodo [setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword) della classe [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/) per decrittare e caricarla. Il seguente codice JavaScript dimostra questa operazione:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Esegui operazioni sulla presentazione decrittata.
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides fornisce opzioni—in particolare il metodo [getBlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) nella classe [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/)—per aiutarti a caricare presentazioni di grandi dimensioni.

Il seguente codice JavaScript dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Scegli il comportamento KeepLocked — il file della presentazione rimarrà bloccato per tutta la durata di
// l'istanza Presentation, ma non è necessario caricarlo in memoria o copiarlo in un file temporaneo.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // La grande presentazione è stata caricata e può essere usata, mentre il consumo di memoria rimane basso.
    
    // Apporta modifiche alla presentazione.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Salva la presentazione in un altro file. Il consumo di memoria rimane basso durante questa operazione.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Non farlo! Verrà sollevata un'eccezione I/O perché il file è bloccato fino a quando l'oggetto presentation non viene eliminato.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// È OK farlo qui. Il file sorgente non è più bloccato dall'oggetto presentation.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Per aggirare alcune limitazioni quando si lavora con gli stream, Aspose.Slides può copiare il contenuto di uno stream. Caricare una presentazione di grandi dimensioni da uno stream comporta la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché uno stream.

Quando si crea una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), è possibile utilizzare la [BLOB management](/slides/it/nodejs-java/manage-blob/) per ridurre il consumo di memoria.
{{%/alert %}}

## **Gestire risorse esterne**

Aspose.Slides fornisce l'interfaccia [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/) che consente di gestire risorse esterne. Il seguente codice JavaScript mostra come utilizzare l'interfaccia `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Carica un'immagine sostitutiva.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Imposta un URL sostitutivo.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Ignora tutte le altre immagini.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- Progetto VBA (accessibile tramite [Presentation.getVbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getVbaProject));
- Dati incorporati di oggetti OLE (accessibili tramite [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Dati binari di controlli ActiveX (accessibili tramite [Control.getActiveXControlBinary](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Utilizzando il metodo [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questo metodo è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice JavaScript dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Esegui operazioni sulla presentazione.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Ottieni un'eccezione di parsing/validazione del formato durante il caricamento. Tali errori spesso indicano una struttura ZIP non valida o record PowerPoint corrotti.

**Cosa succede se i font richiesti sono mancanti durante l'apertura?**

Il file verrà aperto, ma in seguito il [rendering/export](/slides/it/nodejs-java/convert-presentation/) potrebbe sostituire i font. [Configure font substitutions](/slides/it/nodejs-java/font-substitution/) o [add the required fonts](/slides/it/nodejs-java/custom-font/) all'ambiente di runtime.

**Cosa succede ai media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono referenziati tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti il [rendering/export](/slides/it/nodejs-java/convert-presentation/) potrebbe omettere i media.