---
title: Presentaties opslaan in PHP
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/php-java/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur verversen
- voortgang opslaan
- PHP
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams in PHP met Aspose.Slides, en de PPTX-output en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of [een bestaande opent](/slides/nl/php-java/open-presentation/), gebruikt u de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) methode om het resultaat weg te schrijven. Aspose.Slides voor PHP via Java kan een presentatie opslaan naar een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslaoperaties en de beschikbare opties voor PPTX‑uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) waarde door aan de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) methode. De formaatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie aan en slaat deze op als een PPTX‑bestand:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Voeg hier presentatie-inhoud toe of wijzig deze.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

Voor voorbeelden van bestands- en streamdetectie, het gedrag van nieuw aangemaakte presentaties en het onderscheid tussen bron- en uitvoerformaten, zie [Determine the Original Presentation Format](/slides/nl/php-java/detect-presentation-source-format/).

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand, lees u het oorspronkelijke formaat via de [Presentation::getSourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSourceFormat) methode. Geef de resulterende [SourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sourceformat/) waarde door aan [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#toSaveFormat) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) om de gewijzigde presentatie weg te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij en slaat het op in een uitvoermap in het formaat waarin het werd geladen:

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

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/#toSaveFormat) zet PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint XML om naar de bijbehorende presentatie‑opslaformaten. Het zet alleen presentatiesbronformaten om; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sourceformat/) waarde resulteert in een [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT, PPS en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie uit een stream zonder bestandsextensie wordt geladen, kan een PPS‑ of POT‑bestand daarom worden geïdentificeerd als PPT. Als het behoud van deze legacy‑subtypes vereist is, bewaar dan de oorspronkelijke bestandsnaam of formatmetadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en het formaat.

## **Presentaties opslaan naar streams**

Om een presentatie weg te schrijven zonder een definitief bestandspad te gebruiken, geeft u een schrijfbare stream en een [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) waarde door aan de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) methode. Deze aanpak is nuttig wanneer de output moet worden geretourneerd vanuit een webservice, opgeslagen in een database of in het geheugen wordt verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestandsstream:

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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie initieel opent. Gebruik de [ViewProperties::setLastView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#setLastView) methode met een [ViewType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld configureert de Slide Master‑weergave als de initiële weergave:

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

## **Presentaties opslaan in het strikte Office Open XML‑formaat**

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/) instantie aan en gebruikt u de [PptxOptions::setConformance](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setConformance) methode met [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Geef vervolgens de opties door aan de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) methode.

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

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een standaard‑ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk item, de totale archiefgrootte en het aantal items. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie die limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en item‑limieten.

Gebruik de [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setZip64Mode) methode om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- [IfNecessary](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Never) schakelt ZIP64‑extensies uit.
- [Always](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Always) schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

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
Als [Zip64Mode::Never](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Never) wordt gebruikt en de presentatie past niet binnen de standaard ZIP‑limieten, gooit de opslaan‑operatie een [PptxException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Voor PPTX‑output kunt u de opslagsnelheid afwegen tegen de bestandsgrootte door de [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setCompressionLevel) methode te gebruiken. De [CompressionLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/) klasse biedt de volgende waarden:

- [None](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#None) slaat gegevens op zonder compressie.
- [Level1](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level1) biedt de snelste compressie en het grootste gecomprimeerde resultaat.
- [Level2](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level2) tot en met [Level5](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level5) geven geleidelijk de voorkeur aan een kleiner resultaat boven opslagsnelheid.
- [Level6](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level6) balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- [Level7](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level7) en [Level8](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level8) geven nog meer de voorkeur aan een kleiner resultaat boven opslagsnelheid.
- [Level9](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compressionlevel/#Level9) biedt de sterkste compressie en vereist de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

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

Het volgende voorbeeld gebruikt het maximale compressieniveau:

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

## **Presentaties opslaan zonder het miniatuurbeeld te verversen**

Wanneer een presentatie wordt opgeslagen als PPTX, regelt de [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) methode het document‑miniatuurbeeld:

- `true` genereert het miniatuurbeeld opnieuw tijdens de opslaan‑operatie. Dit is de standaardwaarde.
- `false` behoudt het bestaande miniatuurbeeld. Als de presentatie geen miniatuurbeeld heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder het miniatuurbeeld te verversen:

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
Het uitschakelen van het verversen van het miniatuurbeeld kan de tijd die nodig is om een PPTX‑bestand op te slaan, verminderen.
{{% /alert %}}

## **Voortgangsupdates bij opslaan in procenten**

Om een opslaan‑operatie te monitoren, biedt u een Java‑proxy die de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface implementeert en geeft u de proxy door aan de [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setProgressCallback) methode. Aspose.Slides roept vervolgens de [IProgressCallback::reporting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/#reporting-double-) methode aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld rapporteert de voortgang van een PDF‑export naar de console:

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
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) gebouwd met de Aspose.Slides API. Het slaat geselecteerde dia's uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaan‑operatie schrijft een volledig uitvoerbestand in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie [is not thread-safe](/slides/nl/php-java/multithreading/). Toegang en opslaan van elke instantie mag slechts door één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gekoppelde bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/php-java/manage-hyperlinks/) blijven in de presentatie. Aspose.Slides kopieert geen extern gekoppelde bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/php-java/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.