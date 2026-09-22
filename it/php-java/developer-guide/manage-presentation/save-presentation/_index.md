---
title: Salva presentazioni in PHP
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/php-java/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinito
- Formato Strict di Office Open XML
- modalità Zip64
- aggiornamento miniatura
- salvataggio del progresso
- PHP
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in PHP con Aspose.Slides, e configura l'output PPTX e la segnalazione del progresso."
---
## **Panoramica**

Dopo aver creato una presentazione o [apri una presentazione esistente](/slides/it/php-java/open-presentation/), usa il metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per scrivere il risultato. Aspose.Slides per PHP tramite Java può salvare una presentazione su file o stream in formati PowerPoint, OpenDocument, PDF e altri formati. Le sezioni seguenti descrivono le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva presentazioni su file**

Per salvare una presentazione su un file, passa il percorso di output e un valore [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) al metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save). Il valore del formato determina il tipo di file che Aspose.Slides crea.

Il seguente esempio crea una presentazione e la salva come file PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Aggiungi o modifica il contenuto della presentazione qui.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni appena create e la distinzione tra i formati di origine e di destinazione, vedere [Determina il formato originale della presentazione](/slides/it/php-java/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dal metodo [Presentation::getSourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSourceFormat). Passa il valore [SourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/sourceformat/) risultante a [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#toSaveFormat) per ottenere il corrispondente valore [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/), e quindi utilizza [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per scrivere la presentazione modificata.

Il seguente esempio completo elabora tutti i file in una cartella di input, aggiorna il titolo e lo salva in una cartella di output nel formato da cui è stato caricato:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideutil/#toSaveFormat) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML ai loro corrispondenti formati di salvataggio della presentazione. Mappa solo i formati di origine della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/sourceformat/) non supportato o non valido genera un [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una presentazione di questo tipo viene caricata da uno stream senza estensione di file, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conserva separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di output.

## **Salva presentazioni su stream**

Per scrivere una presentazione senza fare affidamento su un percorso di file definitivo, passa uno stream scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) al metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su uno stream di file:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

È possibile specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Usa il metodo [ViewProperties::setLastView](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#setLastView) con un valore [ViewType](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio configura la visualizzazione Slide Master come visualizzazione iniziale:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni nel formato Strict di Office Open XML**

Per creare un file PPTX conforme al profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/) e usa il suo metodo [PptxOptions::setConformance](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setConformance) con [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/it/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Quindi passa le opzioni al metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ciascuna voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e di conteggio delle voci applicabili.

Usa il metodo [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setZip64Mode) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo quando la presentazione supera i limiti ZIP standard. Questo è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Never) disabilita le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Always) scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Se [Zip64Mode::Never](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Never) è usato e la presentazione non può rientrare nei limiti ZIP standard, l'operazione di salvataggio genera una [PptxException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva presentazioni in formato Office Open XML con livelli di compressione**

Per l'output PPTX, è possibile bilanciare la velocità di salvataggio rispetto alla dimensione del file usando il metodo [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/) fornisce questi valori:

- [None](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#None) memorizza i dati senza compressione.
- [Level1](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level1) fornisce la compressione più veloce e l'output compresso più grande.
- [Level2](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level2) fino a [Level5](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level5) privilegiano progressivamente un output più piccolo rispetto alla velocità di salvataggio.
- [Level6](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level6) bilancia la velocità di salvataggio e la dimensione del file. Questo è il livello predefinito.
- [Level7](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level8) favoriscono ulteriormente un output più piccolo rispetto alla velocità di salvataggio.
- [Level9](https://reference.aspose.com/slides/it/php-java/aspose.slides/compressionlevel/#Level9) fornisce la compressione più forte e richiede più tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Il seguente esempio utilizza il livello di compressione massimo:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni senza aggiornare la miniatura**

Quando una presentazione viene salvata come PPTX, il metodo [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la miniatura del documento:

- `true` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `false` conserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Salva aggiornamenti di progresso in percentuale**

Per monitorare un'operazione di salvataggio, fornisci un proxy Java che implementa l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/) e passa il proxy al metodo [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides quindi chiama il metodo [IProgressCallback::reporting](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/#reporting-double-) con i valori di progresso durante l'esportazione.

Il seguente esempio segnala il progresso di un'esportazione PDF sulla console:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose fornisce gratuitamente un [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) costruito con l'API Aspose.Slides. Salva le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo anziché aggiornare solo le parti modificate.

**Possono più thread salvare la stessa istanza di Presentation?**

No. Un'istanza [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) [non è thread-safe](/slides/it/php-java/multithreading/). Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/php-java/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve comunque poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le appropriate [document properties](/slides/it/php-java/presentation-properties/) prima del salvataggio, e Aspose.Slides le scrive nel file di output.