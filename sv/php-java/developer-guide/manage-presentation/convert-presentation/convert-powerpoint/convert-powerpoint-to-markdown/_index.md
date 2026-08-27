---
title: Konvertera PowerPoint-presentationer till Markdown i PHP
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/php-java/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown bildexport
- CDN bildlänkar
- PowerPoint
- presentation
- Markdown
- PHP
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i PHP och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides för PHP via Java kan konvertera PPT‑ och PPTX‑presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigrering och versionskontrollarbetsflöden. Du kan välja en Markdown‑variant, styra hur bildinnehåll renderas och bestämma var exporterade bilder sparas och hur den genererade Markdown‑referensen ser dem.

Som standard använder Markdown‑export text‑endast‑utdata. För att exportera visuellt innehåll, ange exporttypen med metoden [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) till `Sequential`‑ eller `Visual`‑värdet från uppräkningen [MarkdownExportType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownexporttype/). `Sequential` renderar bildobjekt separat och i sekvens, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. `TextOnly`‑värdet avger inga bildresurser, så bild‑sparande‑återanrop körs inte i det läget.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), och anropa sedan metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) med `Md`‑värdet från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/).

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

## **Välj en Markdown‑variant**

Metoden [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) styr vilken Markdown‑specifikation som används för utskriften. Uppräkningen [Flavor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödda varianter.

Följande exempel exporterar en presentation som CommonMark:

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

## **Exportera bilder med standard lokala sparbeteendet**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) erbjuder två metoder för att konfigurera lokalt sparade bilder:

- [setBasePath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) anger basmappen för Markdown‑dokumentet och dess resurser.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) anger bildens undermapp. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

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

Detta beteende fungerar också som reserv när en anpassad bild‑sparande‑hanterare returnerar `false`.

## **Anpassa bildsparande och Markdown‑länkar**

Använd metoden [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) för att registrera ett återanrop för icke‑SVG‑bitmap‑ och metafilresurser som avges under Markdown‑export. Dess `MarkdownImageSavingHandler`‑återanrop får [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)‑objektet, dess [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/)‑värde och den genererade Markdown‑länken som en endastelement Java‑strängarray. Spara eller ladda upp bilden med det angivna formatet och ersätt `$link[0]` med referensen som ska förekomma i Markdown‑utdata.

Resurser som avges i SVG‑format hanteras separat. Registrera ett återanrop med metoden [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/). Dess `MarkdownSvgImageSavingHandler`‑återanrop får ett [ISvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/isvgimage/)‑objekt och den endastelement Java‑strängarrayen `$link`. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data via metoden [ISvgImage::getSvgData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/isvgimage/) istället. Beroende på exportläge och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas sedan till bild‑sparande‑återanropet. Registrera båda återanropen när varje exporterad visuell resurs kräver anpassad behandling.

I PHP via Java implementerar du varje återanrop i en PHP‑klass och använder `java_closure` för att exponera det objektet som motsvarande Java‑gränssnitt.

{{% alert color="info" title="Note" %}}
Initiera PHP/Java‑bron med `JAVA_PREFER_VALUES` aktiverat innan `Java.inc` laddas. Metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) returnerar `void`, och bryggans standardström‑läge kan inte anropa ett PHP‑återanrop under det köade anropet. Det kompletta exemplet nedan innehåller den erforderliga initieringen.
{{% /alert %}}

Återanropsvärdet bestämmer vem som bearbetar bilden:

- Return `true` efter att återanropet har sparat, laddat upp, omvandlat eller på annat sätt bearbetat bilden och tilldelat ett giltigt värde till `$link[0]`. Aspose.Slides skriver det värdet till Markdown‑dokumentet och utför inte sin standard‑lokala sparning.
- Return `false` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt de värden som satts med [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Ett återanrop som returnerar `true` tar ansvar för bilden. Om det returnerar `true` utan att tilldela en giltig, icke‑tom länk misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

### **Spara bilder till en CDN‑ursprungsmapp och använd externa URL:er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungsmapp. Varje återanrop extraherar det genererade filnamnet, sparar bilden i den anpassade mappen och ersätter den genererade lokala referensen med en offentlig CDN‑URL. Exemplet utför ingen nätverksuppladdning: URL:en blir giltig först när mappen är monterad som CDN‑ursprung eller dess filer har publicerats till CDN. För objektslagring, ersätt fil‑systemskrivningen med lagrings‑SDK:ns uppladdningsoperation och tilldela `$link[0]` först när uppladdningen lyckas.

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

Bitmap‑återanropet returnerar medvetet `false` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder till `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser, liksom SVG‑resurser, hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` till `https://cdn.example.com/presentations/quarterly-report/image1.png`. Återanropen använder operativsystemets sökvägar endast vid filskrivning; länkar som skrivs till Markdown använder snedstreck och URL‑kodade filnamn. Tillämpa samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorer.

## **FAQ**

**Kan ett återanrop bearbeta både rasterbilder och SVG‑bilder?**

Nej. Använd [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) för bitmap‑ och metafilresurser som avges, och [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) för resurser som avges som SVG. Det förra ger ett [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)‑objekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/)‑värde; det senare ger ett [ISvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/isvgimage/)‑objekt vars SVG‑data kan läsas med [ISvgImage::getSvgData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/isvgimage/). En käll‑SVG som rasteriseras under export bearbetas av bild‑sparande‑återanropet istället.

**Vad händer när ett bild‑sparande‑återanrop returnerar `false`?**

Aspose.Slides använder sitt standard‑lokala sparbeteende. Bildens plats och den genererade referensen styrs av de värden som satts med [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/) och [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markdownsaveoptions/).

**Kan ett återanrop tillhandahålla en URL utan att spara bilden lokalt?**

Ja. Återanropet kan ladda upp bilden till objektslagring eller skicka den till en annan tjänst, tilldela den resulterande URL:en till `$link[0]` och returnera `true`. Återanropet måste slutföra behandlingen själv; att returnera `true` förhindrar den standard‑lokala sparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från ett återanrop?**

Detta undantag uppstår när återanropet returnerar `true` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL:en som ska skrivas till Markdown innan du returnerar `true`.

**Vilken sökvägsseparator ska bildlänkar använda?**

Använd snedstreck (`/`) i Markdown‑länkar och URL:er. Använd `DIRECTORY_SEPARATOR` endast för filsystempå‑ sökvägar, och bygg eller normalisera Markdown‑referensen separat.

**Behålls hyperlänkar under Markdown‑export?**

Ja. Text [hyperlinks](/slides/sv/php-java/manage-hyperlinks/) bevaras som vanliga Markdown‑länkar. Bild [transitions](/slides/sv/php-java/slide-transition/) och [animations](/slides/sv/php-java/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**

Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans mellan trådar. Följ [multithreading guidelines](/slides/sv/php-java/multithreading/) och använd en separat instans för varje fil.