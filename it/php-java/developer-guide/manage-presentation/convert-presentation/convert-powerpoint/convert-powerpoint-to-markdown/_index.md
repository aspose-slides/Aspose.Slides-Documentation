---
title: Converti presentazioni PowerPoint in Markdown in PHP
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/php-java/convert-powerpoint-to-markdown/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salvare PowerPoint come Markdown
- salvare presentazione come Markdown
- salvare diapositiva come Markdown
- salvare PPT come MD
- salvare PPTX come MD
- esportare PPT in MD
- esportare PPTX in MD
- esportazione immagini Markdown
- link immagine CDN
- PowerPoint
- presentazione
- Markdown
- PHP
- Aspose.Slides
description: "Converti presentazioni PPT e PPTX in Markdown in PHP e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides for PHP via Java può convertire presentazioni PPT e PPTX in Markdown per la documentazione, siti statici, migrazione di contenuti e flussi di lavoro di controllo versione. È possibile scegliere un flavor Markdown, controllare come viene resa il contenuto delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le riferisce.

Per impostazione predefinita, l'esportazione Markdown utilizza solo testo. Per esportare contenuti visivi, impostare il tipo di esportazione con il metodo [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) al valore `Sequential` o `Visual` dell'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownexporttype/). `Sequential` rende gli elementi della diapositiva separatamente e in ordine, mentre `Visual` mantiene insieme gli elementi raggruppati per preservare la loro relazione visiva. Il valore `TextOnly` non emette risorse immagine, quindi i callback di salvataggio immagine non vengono invocati in tale modalità.

## **Convertire una presentazione in Markdown**

Carica il file sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e quindi chiama il metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) con il valore `Md` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Seleziona una variante Markdown**

Il metodo [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) controlla la specifica Markdown utilizzata per l'output. L'enumerazione [Flavor](https://reference.aspose.com/slides/it/php-java/aspose.slides/flavor/) include CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione come CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Esporta le immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) fornisce due metodi per configurare le immagini salvate localmente:

- [setBasePath](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) specifica la directory base per il documento Markdown e le sue risorse.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) specifica la sottodirectory delle immagini. Il valore predefinito è `Images`.

Il seguente esempio rende il contenuto visivo, scrive le immagini in `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Questo comportamento funge anche da fallback quando un handler personalizzato di salvataggio immagine restituisce `false`.

## **Personalizzare il salvataggio delle immagini e i collegamenti Markdown**

Usa il metodo [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) per registrare un callback per le risorse bitmap e metafile non SVG emesse durante l'esportazione Markdown. Il suo callback `MarkdownImageSavingHandler` riceve l'oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/), il suo valore [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/) e il collegamento Markdown generato come array Java di stringhe a un elemento. Salva o carica l'immagine con il formato fornito e sostituisci `$link[0]` con il riferimento che deve comparire nell'output Markdown.

Le risorse emesse in formato SVG vengono gestite separatamente. Registra un callback con il metodo [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/). Il suo callback `MarkdownSvgImageSavingHandler` riceve un oggetto [ISvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/isvgimage/) e l'array Java di stringhe a un elemento `$link`. Un SVG non ha argomento `ImageFormat`; scrivi o carica i suoi dati XML dal metodo [ISvgImage::getSvgData](https://reference.aspose.com/slides/it/php-java/aspose.slides/isvgimage/). A seconda della modalità di esportazione e del raggruppamento visivo, un SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non SVG risultante viene quindi passata al callback di salvataggio immagine. Registra entrambi i callback quando ogni risorsa visiva esportata richiede una elaborazione personalizzata.

In PHP via Java, implementa ogni callback in una classe PHP e usa `java_closure` per esporre quell'oggetto come l'interfaccia Java corrispondente.

{{% alert color="info" title="Note" %}}
Initializza il PHP/Java Bridge con `JAVA_PREFER_VALUES` abilitato prima di caricare `Java.inc`. Il metodo [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) restituisce `void` e la modalità di stream predefinita del bridge non può invocare un callback PHP durante quella chiamata in coda. L'esempio completo qui sotto include l'inizializzazione richiesta.
{{% /alert %}}

Il valore di ritorno dell'handler determina chi elabora l'immagine:

- Restituisci `true` dopo che l'handler ha salvato, caricato, trasformato o altrimenti elaborato l'immagine e ha assegnato un valore valido a `$link[0]`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituisci `false` per permettere ad Aspose.Slides di salvare l'immagine localmente e generare il suo collegamento secondo i valori impostati con [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Un handler che restituisce `true` si assume la responsabilità dell'immagine. Se restituisce `true` senza assegnare un collegamento valido e non vuoto, l'esportazione fallisce con un `InvalidOperationException`.
{{% /alert %}}

### **Salvare le immagini in una directory di origine CDN e utilizzare URL esterni**

Il seguente esempio tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni handler estrae il nome file generato, salva l'immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L'esempio stesso non esegue alcun upload di rete: l'URL diventa valido solo dopo che la directory è montata come origine CDN o i suoi file sono pubblicati sul CDN. Per lo storage di oggetti, sostituisci la scrittura sul file system con l'operazione di upload dell'SDK di storage e assegna `$link[0]` solo dopo che l'upload ha avuto successo.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Il gestore bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, quindi Aspose.Slides salva tali immagini in `output/fallback-images` usando il comportamento predefinito. Le risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Per esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. Gli handler usano percorsi del sistema operativo solo quando scrivono file; i collegamenti scritti nel Markdown usano barre oblique e nomi file URL‑escaped. Applica la stessa regola quando costruisci collegamenti relativi: usa `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un singolo handler può elaborare sia immagini raster che immagini SVG?**

No. Usa [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) per le risorse bitmap e metafile emesse e [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) per le risorse emesse come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) e un valore [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/); il secondo fornisce un oggetto [ISvgImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/isvgimage/) il cui dato SVG può essere letto con [ISvgImage::getSvgData](https://reference.aspose.com/slides/it/php-java/aspose.slides/isvgimage/). Un SVG di origine rasterizzato durante l'esportazione è elaborato dal callback di salvataggio immagine invece.

**Cosa succede quando un handler di salvataggio immagine restituisce `false`?**

Aspose.Slides usa il suo comportamento predefinito di salvataggio locale. La posizione dell'immagine e il riferimento generato sono controllati dai valori impostati con [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/) e [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/it/php-java/aspose.slides/markdownsaveoptions/).

**Un handler può fornire un URL senza salvare l'immagine localmente?**

Sì. L'handler può caricare l'immagine su storage di oggetti o passarla a un altro servizio, assegnare l'URL risultante a `$link[0]` e restituire `true`. L'handler deve completare l'elaborazione da solo; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l'esportazione Markdown genera un `InvalidOperationException` da un handler?**

Questa eccezione si verifica quando l'handler restituisce `true` ma non fornisce un collegamento valido. Assegna il percorso relativo o l'URL esterno che deve essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso devono usare i collegamenti immagine?**

Usa le barre oblique nei collegamenti Markdown e negli URL. Usa `DIRECTORY_SEPARATOR` solo per i percorsi del file system, quindi costruisci o normalizza il riferimento Markdown separatamente.

**I collegamenti ipertestuali vengono preservati durante l'esportazione Markdown?**

Sì. I [collegamenti ipertestuali](/slides/it/php-java/manage-hyperlinks/) del testo vengono preservati come normali collegamenti Markdown. Le [transizioni](/slides/it/php-java/slide-transition/) e le [animazioni](/slides/it/php-java/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

Puoi elaborare file di presentazione diversi in parallelo, ma non condividere la stessa istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) tra thread. Segui le [linee guida sul multithreading](/slides/it/php-java/multithreading/) e usa un'istanza separata per ogni file.