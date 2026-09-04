---
title: Aprire presentazioni in JavaScript
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aprire presentazioni PowerPoint e OpenDocument in JavaScript, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso della memoria con Aspose.Slides per Node.js via Java."
---
## **Introduzione**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/it/nodejs-java/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari al di fuori della memoria di Node.js, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire presentazioni**

Per aprire una presentazione esistente, passare il suo percorso file al costruttore [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Rilasciare la presentazione dopo l'uso in modo che i handle dei file, i dati temporanei e le altre risorse vengano rilasciati prontamente.

Il seguente esempio JavaScript mostra come aprire una presentazione e ottenere il numero di diapositive:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Aprire presentazioni protette da password**

Una password di apertura crittografa il contenuto della presentazione. Per caricare l'intera presentazione, passare la password corretta a [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword) e fornire le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Il caricamento fallisce quando la password è mancante o errata.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Per il rilevamento, la convalida e i flussi di lavoro di crittografia delle password, vedere [Password-Protect Presentations](/slides/it/nodejs-java/password-protected-presentation/). Se una presentazione crittografata è stata deliberatamente salvata con proprietà di documento pubbliche, tali proprietà possono essere lette senza password; vedere [Manage Presentation Properties](/slides/it/nodejs-java/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) restituisce opzioni che controllano come Aspose.Slides gestisce gli oggetti binari di grandi dimensioni come immagini, audio e video. È possibile mantenere il file sorgente bloccato, consentire file temporanei e limitare la quantità di dati BLOB trattenuti in memoria.

Il seguente codice JavaScript dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Con [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked), il file sorgente rimane bloccato fino a quando l'istanza della presentazione non viene rilasciata. Non spostare, sovrascrivere o eliminare il file sorgente mentre quell'istanza è viva.

Aspose.Slides può copiare il contenuto di uno stream di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso file è quindi generalmente più efficiente di uno stream. Vedere [Manage BLOBs](/slides/it/nodejs-java/manage-blob/) per opzioni aggiuntive di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare le risorse esterne**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accetta un'implementazione di [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/). Il callback può fornire dati sostitutivi, reindirizzare una risorsa, utilizzare il loader predefinito o saltare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o di archiviazione specifiche dell'applicazione.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole mantenere. Esempi includono:

- Progetti VBA, disponibili tramite [Presentation.getVbaProject](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getVbaProject);
- dati OLE incorporati, disponibili tramite [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dati di controllo ActiveX, disponibili tramite [Control.getActiveXControlBinary](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Impostare [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) su `true` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per preservare il risultato sanificato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanificazione del contenuto.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Come posso capire che un file è danneggiato e non può essere aperto?**

Aspose.Slides lancia un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da un errore di password errata, così l'applicazione può segnalare la causa in modo accurato.

**Cosa succede se i font richiesti sono mancanti?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. È possibile [configure font substitution](/slides/it/nodejs-java/font-substitution/) o [provide custom fonts](/slides/it/nodejs-java/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

L'audio e il video incorporati diventano disponibili tramite il modello a oggetti della presentazione. Le risorse esterne vengono risolte secondo il comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non possono essere raggiunte.