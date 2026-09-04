---
title: Aprire presentazioni in PHP
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "Impara come aprire presentazioni PowerPoint e OpenDocument in PHP, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso della memoria con Aspose.Slides per PHP via Java."
---
## **Introduzione**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/it/php-java/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari al di fuori della memoria heap di Java, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire presentazioni**

Per aprire una presentazione esistente, passare il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Disporre della presentazione dopo l'uso affinché i handle dei file, i dati temporanei e le altre risorse vengano rilasciati tempestivamente.

Il seguente esempio PHP mostra come aprire una presentazione e ottenere il numero di diapositive:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Aprire presentazioni protette da password**

Una password di apertura crittografa il contenuto della presentazione. Per caricare l'intera presentazione, passare la password corretta a [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword) e fornire le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Il caricamento fallisce se la password è mancante o errata.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Per i flussi di lavoro di rilevamento, convalida e crittografia delle password, vedere [Password-Protect Presentations](/slides/it/php-java/password-protected-presentation/). Se una presentazione crittografata è stata salvata deliberatamente con proprietà documento pubbliche, tali proprietà possono essere lette senza password; vedere [Manage Presentation Properties](/slides/it/php-java/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) restituisce le opzioni che controllano come Aspose.Slides gestisce i large binary objects (BLOB) come immagini, audio e video. È possibile mantenere il file di origine bloccato, consentire file temporanei e limitare la quantità di dati BLOB mantenuti in memoria.

Il seguente codice PHP dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Con [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), il file di origine rimane bloccato finché l'istanza della presentazione non viene eliminata. Non spostare, sovrascrivere o eliminare il file di origine mentre quell'istanza è attiva.

Aspose.Slides può copiare il contenuto di un flusso di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso file è generalmente più efficiente di un flusso. Vedere [Manage BLOBs](/slides/it/php-java/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare risorse esterne**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accetta un'implementazione dell'interfaccia Java [IResourceLoadingCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iresourceloadingcallback/) tramite PHP/Java Bridge. Il callback può fornire dati di sostituzione, reindirizzare una risorsa, utilizzare il caricatore predefinito o saltare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o archiviazione specifiche dell'applicazione.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole conservare. Esempi includono:

- progetti VBA, disponibili tramite [Presentation::getVbaProject](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getVbaProject);
- dati OLE incorporati, disponibili tramite [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/it/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dati di controllo ActiveX, disponibili tramite [Control::getActiveXControlBinary](https://reference.aspose.com/slides/it/php-java/aspose.slides/control/#getActiveXControlBinary).

Impostare [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) su `true` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per conservare il risultato sanitizzato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanitizzazione dei contenuti.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Come posso capire che un file è corrotto e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da quello di password errata in modo che l'applicazione possa segnalare correttamente la causa.

**Cosa succede se i caratteri richiesti sono mancanti?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i caratteri. È possibile [configure font substitution](/slides/it/php-java/font-substitution/) o [provide custom fonts](/slides/it/php-java/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

Audio e video incorporati diventano disponibili attraverso il modello di oggetti della presentazione. Le risorse esterne vengono risolte secondo il comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non sono accessibili.