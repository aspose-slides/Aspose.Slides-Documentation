---
title: Aprire presentazioni in PHP
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/php-java/open-presentation/
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
- presentazione grande
- risorsa esterna
- oggetto binario
- PHP
- Aspose.Slides
description: "Apri presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) senza sforzo con Aspose.Slides per PHP tramite Java — veloce, affidabile, completamente funzionale."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides ti consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, puoi recuperare informazioni su di essa, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e altro ancora.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, istanzia la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e passa il percorso del file al suo costruttore.

Il seguente esempio PHP mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```php
// Istanzia la classe Presentation e passa un percorso file al suo costruttore.
$presentation = new Presentation("Sample.pptx");
try {
    // Stampa il numero totale di diapositive nella presentazione.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Aprire presentazioni protette da password**

Quando è necessario aprire una presentazione protetta da password, passa la password attraverso il metodo [setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword) della classe [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/) per decifrarla e caricarla. Il seguente codice PHP dimostra questa operazione:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Esegui operazioni sulla presentazione decrittata.
} finally {
    $presentation->dispose();
}
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides offre opzioni—in particolare il metodo [getBlobManagementOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) nella classe [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/)—per aiutarti a caricare presentazioni di grandi dimensioni.

Il seguente codice PHP dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Per aggirare alcune limitazioni quando si lavora con gli stream, Aspose.Slides può copiare il contenuto di uno stream. Caricare una presentazione di grandi dimensioni da uno stream provoca la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché uno stream.

Quando si crea una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), è possibile utilizzare la [gestione BLOB](/slides/it/php-java/manage-blob/) per ridurre il consumo di memoria.
{{%/alert %}}

## **Controllare le risorse esterne**

Aspose.Slides fornisce l'interfaccia [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/) che consente di gestire le risorse esterne. Il seguente codice PHP mostra come utilizzare l'interfaccia `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Carica un'immagine sostitutiva.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Imposta un URL sostitutivo.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Ignora tutte le altre immagini.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- progetto VBA (accessibile tramite [Presentation.getVbaProject](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getVbaProject));
- dati incorporati di oggetti OLE (accessibili tramite [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- dati binari di controlli ActiveX (accessibili tramite [Control.getActiveXControlBinary](https://reference.aspose.com/slides/it/php-java/aspose.slides/control/#getActiveXControlBinary)).

Utilizzando il metodo [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questo metodo è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice PHP dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Esegui operazioni sulla presentazione.
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Durante il caricamento riceverai un'eccezione di validazione del parsing/formato. Tali errori spesso indicano una struttura ZIP non valida o record PowerPoint corrotti.

**Cosa succede se i caratteri richiesti mancano durante l'apertura?**

Il file si aprirà, ma in seguito la [renderizzazione/esportazione](/slides/it/php-java/convert-presentation/) potrebbe sostituire i caratteri. [Configura le sostituzioni dei caratteri](/slides/it/php-java/font-substitution/) o [aggiungi i caratteri richiesti](/slides/it/php-java/custom-font/) all'ambiente di runtime.

**E per quanto riguarda i media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono referenziati tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti la [renderizzazione/esportazione](/slides/it/php-java/convert-presentation/) potrebbe omettere i media.