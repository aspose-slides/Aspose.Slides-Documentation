---
title: Spara presentationer i PHP
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/php-java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strikt Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparningsförlopp
- PHP
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i PHP med Aspose.Slides, och konfigurera PPTX-utdata samt rapportering av framsteg."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppnat en befintlig](/slides/sv/php-java/open-presentation/), använd metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att skriva resultatet. Aspose.Slides för PHP via Java kan spara en presentation till en fil eller ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt täcker de standardlagringsoperationerna och de alternativ som finns för PPTX‑utmatning.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka filvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/)‑värde till metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save). Formatvärdet bestämmer vilken typ av fil som Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Lägg till eller ändra presentationsinnehåll här.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nyss skapade presentationer och skillnaden mellan käll‑ och utskriftsformat, se [Bestäm det ursprungliga presentationsformatet](/slides/sv/php-java/detect-presentation-source-format/).

I ett batch‑behandlingsprogram kan indataformatet vara okänt i förväg. Efter att en fil har lästs in, läs dess ursprungliga format från metoden [Presentation::getSourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSourceFormat). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sourceformat/)‑värdet till [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#toSaveFormat) för att få motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/)‑värde, och använd sedan [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) för att skriva den modifierade presentationen.

Följande kompletta exempel bearbetar alla filer i en indatakatalog, uppdaterar dess titel och sparar den till en utdata‑katalog i det format som den laddades i:

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

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#toSaveFormat) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint XML till deras motsvarande presentations‑sparformat. Den mappar endast presentationskällformat; den är inte avsedd att välja exportformat som PDF, HTML, TIFF eller bilder. Att skicka ett icke‑stött eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sourceformat/)‑värde resulterar i ett [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Äldre PPT‑, PPS‑ och POT‑filer använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om det krävs att bevara dessa äldre undertyper, behåll det ursprungliga filnamnet eller formatmetadata separat och använd dem när du väljer utskriftsfilnamn och -format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita dig på en slutgiltig filsökväg, skicka en skrivbar ström och ett [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/)‑värde till metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save). Detta tillvägagångssätt är användbart när utskriften måste returneras från en webb‑tjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

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

## **Spara presentationer med en fördefinierad vystyper**

Du kan ange den vy som PowerPoint öppnar en sparad presentation i initialt. Använd metoden [ViewProperties::setLastView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/#setLastView) med ett [ViewType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewtype/)‑värde innan du sparar.

Följande exempel konfigurerar Slide Master‑vyn som den initiala vyn:

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

## **Spara presentationer i strikt Office Open XML‑format**

För att skapa en PPTX‑fil som följer den strikta profilen av Office Open XML, skapa en instans av [PptxOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/) och använd dess metod [PptxOptions::setConformance](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setConformance) med [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Skicka sedan alternativena till metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save).

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

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överskrida dessa gränser. ZIP64‑tillägg höjer de tillämpliga storleks‑ och post‑antal‑gränserna.

Använd metoden [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setZip64Mode) för att styra om Aspose.Slides skriver ZIP64‑tillägg:

- [IfNecessary](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#IfNecessary) använder ZIP64 endast när presentationen överskrider standard‑ZIP‑gränserna. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Never) inaktiverar ZIP64‑tillägg.
- [Always](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Always) skriver alltid ZIP64‑tillägg.

Följande exempel aktiverar alltid ZIP64‑tillägg för den utgående presentationen:

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
Om [Zip64Mode::Never](https://reference.aspose.com/slides/sv/php-java/aspose.slides/zip64mode/#Never) används och presentationen inte får plats inom standard‑ZIP‑gränserna, kastar sparoperationen ett [PptxException](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

För PPTX‑utmatning kan du balansera sparhastigheten mot filstorleken genom att använda metoden [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Klassen [CompressionLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/) tillhandahåller följande värden:

- [None](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#None) lagrar data utan kompression.
- [Level1](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level1) ger den snabbaste kompressionen och den största komprimerade utdata.
- [Level2](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level2) till [Level5](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level5) favoriserar gradvis mindre utdata framför sparhastighet.
- [Level6](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level6) balanserar sparhastighet och filstorlek. Detta är standardnivån.
- [Level7](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level7) och [Level8](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level8) favoriserar ytterligare mindre utdata framför sparhastighet.
- [Level9](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compressionlevel/#Level9) ger den starkaste kompressionen och kräver mest bearbetningstid.

Följande exempel sparar en presentation utan kompression:

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

Följande exempel använder maximal komprimeringsnivå:

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

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr metoden [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) dess dokumentminiatyr:

- `true` regenererar miniatyren under sparoperationen. Detta är standardvärdet.
- `false` bevarar den befintliga miniatyren. Om presentationen saknar miniatyr genererar Aspose.Slides ingen.

Följande exempel sparar en presentation utan att uppdatera dess miniatyr:

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
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Spara förloppsuppdateringar i procent**

För att övervaka en sparoperation, tillhandahåll en Java‑proxy som implementerar gränssnittet [IProgressCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/) och skicka proxyn till metoden [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides anropar sedan metoden [IProgressCallback::reporting](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iprogresscallback/#reporting-double-) med förloppsvärden under exporten.

Följande exempel rapporterar förloppet för en PDF‑export till konsolen:

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
Aspose erbjuder en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:et. Den sparar valda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides inkrementell eller “snabb sparning”?**

Nej. Varje sparoperation skriver en komplett utdatafil istället för att endast uppdatera de förändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/php-java/multithreading/). Åtkomst och sparning av varje instans får endast göras från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlinks](/slides/sv/php-java/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata som författare, titel, företag och skapelsedatum?**

Ja. Ställ in lämpliga [dokumentegenskaper](/slides/sv/php-java/presentation-properties/) innan sparning, så skriver Aspose.Slides dem till utdatafilen.