---
title: PowerPoint-presentaties naar Markdown converteren in PHP
linktitle: PowerPoint naar Markdown
type: docs
weight: 140
url: /nl/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar MD
- presentatie naar MD
- dia naar MD
- PPT naar MD
- PPTX naar MD
- PowerPoint opslaan als Markdown
- presentatie opslaan als Markdown
- dia opslaan als Markdown
- PPT opslaan als MD
- PPTX opslaan als MD
- PPT exporteren naar MD
- PPTX exporteren naar MD
- Markdown-afbeeldingsexport
- CDN-afbeeldingskoppelingen
- PowerPoint
- presentatie
- Markdown
- PHP
- Aspose.Slides
description: "Converteer PPT- en PPTX-presentaties naar Markdown in PHP en beheer waar geëxporteerde bitmap-, metafile- en SVG-afbeeldingen worden opgeslagen en verwezen."
---
## **Overzicht**

Aspose.Slides for PHP via Java kan PPT- en PPTX‑presentaties converteren naar Markdown voor documentatie, statische sites, contentmigratie en versie‑beheersworkflows. U kunt een Markdown‑smaak kiezen, bepalen hoe slide‑inhoud wordt gerenderd en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown‑verwijzingen ernaar eruitzien.

Standaard gebruikt Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stelt u het exporttype in met de [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑methode op de `Sequential`‑ of `Visual`‑waarde uit de [MarkdownExportType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownexporttype/)‑enumeratie. `Sequential` rendert slide‑items apart en in volgorde, terwijl `Visual` gegroepeerde items samenhoudt om hun visuele relatie te bewaren. De `TextOnly`‑waarde geeft geen afbeeldingsbronnen uit, zodat de afbeeldings‑opsla‑callbacks in die modus niet worden aangeroepen.

## **Converteer een presentatie naar Markdown**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en roep vervolgens de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑methode aan met de `Md`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/)‑enumeratie.

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

## **Selecteer een Markdown‑smaak**

De [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑methode bepaalt de Markdown‑specificatie die voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/flavor/)‑enumeratie bevat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

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

## **Exporteer afbeeldingen met het standaard lokaal opslaan‑gedrag**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑klasse biedt twee methoden om lokaal opgeslagen afbeeldingen te configureren:

- [setBasePath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) specificeert de basismap voor het Markdown‑document en de bijbehorende bronnen.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) specificeert de submap voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsverwijzingen aan in het Markdown‑document:

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

Dit gedrag fungeert ook als fallback wanneer een aangepaste afbeelding‑opsla‑handler `false` retourneert.

## **Pas afbeeldingsopslag en Markdown‑links aan**

Gebruik de [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑methode om een callback te registreren voor niet‑SVG‑bitmap‑ en metafile‑bronnen die tijdens Markdown‑export worden uitgegeven. De `MarkdownImageSavingHandler`‑callback ontvangt het [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)‑object, de [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/)‑waarde en de gegenereerde Markdown‑link als een eélelementige Java‑string‑array. Sla de afbeelding op of upload deze met het opgegeven formaat en vervang `$link[0]` door de verwijzing die in de Markdown‑output moet verschijnen.

Bronnen die in SVG‑formaat worden uitgegeven, worden afzonderlijk afgehandeld. Registreer een callback met de [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/)‑methode. De `MarkdownSvgImageSavingHandler`‑callback ontvangt een [ISvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/isvgimage/)‑object en de eélelementige Java‑string‑array `$link`. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑data via de [ISvgImage::getSvgData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/isvgimage/)‑methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere inhoud worden; de resulterende niet‑SVG‑bron wordt dan doorgegeven aan de afbeelding‑opsla‑callback. Registreer beide callbacks wanneer elke geëxporteerde visuele bron aangepaste verwerking vereist.

In PHP via Java implementeert u elke callback in een PHP‑klasse en gebruikt u `java_closure` om dat object bloot te stellen als de overeenkomstige Java‑interface.

{{% alert color="info" title="Opmerking" %}}
Initialiseer de PHP/Java‑Bridge met `JAVA_PREFER_VALUES` ingeschakeld voordat u `Java.inc` laadt. De [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑methode retourneert `void`, en de standaard‑streammodus van de bridge kan geen PHP‑callback aanroepen tijdens die wachtrij‑aanroep. Het volledige voorbeeld hieronder bevat de vereiste initialisatie.
{{% /alert %}}

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `true` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde heeft toegewezen aan `$link[0]`. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert de standaard‑lokale opslaan‑actie niet uit.
- Retourneer `false` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren volgens de waarden die zijn ingesteld met [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Belangrijk" %}}
Een handler die `true` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als deze `true` retourneert zonder een geldige, niet‑lege link toe te wijzen, mislukt de export met een `InvalidOperationException`.
{{% /alert %}}

### **Sla afbeeldingen op in een CDN‑origin‑directory en gebruik externe URL’s**

Het volgende voorbeeld behandelt `cdn-origin/presentations/quarterly-report` als een aangekoppelde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste map en vervangt de gegenereerde lokale referentie door een publieke CDN‑URL. Het voorbeeld zelf voert geen netwerk‑upload uit: de URL wordt pas geldig zodra de map is aangekoppeld als CDN‑origin of de bestanden zijn gepubliceerd naar het CDN. Voor object‑opslag vervangt u de bestands‑systeem‑schrijfbewerking door de upload‑operatie van de opslag‑SDK en kent u `$link[0]` pas toe nadat de upload geslaagd is.

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

De bitmap‑handler retourneert bewust `false` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen naar `output/fallback-images` opslaat met het standaardgedrag. Grotere bitmap‑ en metafile‑bronnen, evenals SVG‑bronnen, worden door de aangepaste code afgehandeld. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen paden van het besturingssysteem bij het schrijven van bestanden; links die in Markdown worden geschreven gebruiken schuine strepen en URL‑geëncodeerde bestandsnamen. Pas dezelfde regel toe bij het opbouwen van relatieve links: gebruik `/`, niet het platform‑specifieke scheidingsteken.

## **FAQ**

**Kan één handler zowel rasterafbeeldingen als SVG-afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) voor uitgegeven bitmap‑ en metafile‑bronnen en [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) voor bronnen die als SVG worden uitgegeven. De eerste biedt een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)‑object en een [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/)‑waarde; de tweede biedt een [ISvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/isvgimage/)‑object waarvan de SVG‑data kan worden gelezen met [ISvgImage::getSvgData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/isvgimage/). Een bron‑SVG die tijdens export wordt gerasterd, wordt door de afbeelding‑opsla‑callback verwerkt.

**Wat gebeurt er als een afbeelding‑opsla‑handler `false` retourneert?**

Aspose.Slides gebruikt zijn standaard lokaal‑opsla‑gedrag. De afbeeldingslocatie en de gegenereerde verwijzing worden beheerst door de waarden die zijn ingesteld met [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/) en [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/markdownsaveoptions/).

**Kan een handler een URL verstrekken zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar object‑opslag of doorgeven aan een andere service, de resulterende URL toewijzen aan `$link[0]` en `true` retourneren. De handler moet de verwerking zelf voltooien; het retourneren van `true` voorkomt de standaard‑lokale opslaan‑actie.

**Waarom gooit Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `true` retourneert maar geen geldige link verstrekt. Ken het relatieve pad of de externe URL toe die in Markdown moet worden geschreven voordat u `true` retourneert.

**Welke pad‑scheidingsteken moet worden gebruikt in afbeeldings‑links?**

Gebruik schuine strepen (`/`) in Markdown‑links en URL’s. Gebruik `DIRECTORY_SEPARATOR` alleen voor besturingssysteem‑paden en bouw of normaliseer de Markdown‑referentie apart.

**Worden hyperlinks behouden tijdens Markdown‑export?**

Ja. Tekst [hyperlinks](/slides/nl/php-java/manage-hyperlinks/) wordt bewaard als standaard Markdown‑links. Slide‑[transities](/slides/nl/php-java/slide-transition/) en [animaties](/slides/nl/php-java/powerpoint-animation/) worden niet geconverteerd.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

U kunt verschillende presentatie‑bestanden parallel verwerken, maar deel **niet** dezelfde [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie tussen threads. Volg de [multithreading guidelines](/slides/nl/php-java/multithreading/) en gebruik een aparte instantie per bestand.