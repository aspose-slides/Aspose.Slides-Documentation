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
- vooraf gedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- miniatuur vernieuwen
- voortgang opslaan
- PHP
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan met Aspose.Slides voor PHP via Java — exporteer naar PowerPoint of OpenDocument terwijl de lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open Presentaties in PHP](/slides/nl/php-java/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt hem opslaan als je klaar bent. Met Aspose.Slides voor PHP kun je opslaan naar een **bestand** of **stroom**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse aan te roepen. Geef de bestandsnaam en het opslaan‑formaat door aan de methode. Het volgende voorbeeld toont hoe je een presentatie opslaat met Aspose.Slides.

```php
// Instantieer de Presentation-klasse die een presentiebestand vertegenwoordigt.
$presentation = new Presentation();
try {
    // Doe hier wat werk...

    // Sla de presentatie op naar een bestand.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een uitvoer‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse. Een presentatie kan naar verschillende stream‑typen geschreven worden. In het onderstaande voorbeeld maken we een nieuwe presentatie aan en slaan die op naar een bestands‑stream.

```php
// Instantieer de Presentation-klasse die een presentiebestand vertegenwoordigt.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Sla de presentatie op naar de stream.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan met een vooraf gedefinieerde weergavetype**

Aspose.Slides stelt je in staat om de initiële weergave in te stellen die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend via de [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/) klasse. Gebruik de [setLastView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#setLastView) methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewtype/) enumeratie.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan in het Strict Office Open XML‑formaat**

Met Aspose.Slides kun je een presentatie opslaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/) klasse en stel de eigenschap `conformance` in bij het opslaan. Als je [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat die op in het Strict Office Open XML‑formaat.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instantieer de Presentation-klasse die een presentiebestand vertegenwoordigt.
$presentation = new Presentation();
try {
    // Sla de presentatie op in het Strict Office Open XML-formaat.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat een limiet van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte van elk bestand en de totale grootte van het archief, en tevens een limiet van 65 535 (2^16‑1) bestanden. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setZip64Mode) methode laat je kiezen wanneer je ZIP64‑formatextensies wilt gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan worden gebruikt met de volgende modi:

- [IfNecessary](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande beperkingen overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Never) gebruikt nooit ZIP64‑formatextensies.
- [Always](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Always) gebruikt altijd ZIP64‑formatextensies.

De volgende code demonstreert hoe je een presentatie opslaat als een PPTX‑bestand met ZIP64‑formatextensies ingeschakeld:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="OPMERKING" color="warning" %}}
Wanneer je opslaat met [Zip64Mode.Never](https://reference.aspose.com/slides/nl/php-java/aspose.slides/zip64mode/#Never), wordt er een [PptxException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxexception/) opgegooid als de presentatie niet opgeslagen kan worden in ZIP32‑formaat.
{{% /alert %}}

## **Presentaties opslaan in Office Open XML‑formaat met compressieniveaus**

Wanneer je werkt met grote presentaties, kun je het compressieniveau aanpassen om een balans te vinden tussen bestandsgrootte en verwerkingstijd. Afhankelijk van je eisen kun je sneller verwerken of kleinere uitvoerbestanden verkrijgen.

Aspose.Slides biedt de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setCompressionLevel) methode, waarmee je het compressieniveau kunt opgeven dat gebruikt wordt bij het opslaan van een presentatie in Office Open XML‑formaat.

De volgende compressieniveaus zijn beschikbaar:

- **None**: Er wordt geen compressie toegepast. Bestanden blijven ongewijzigd.
- **Level1**: De snelste compressie met de laagste compressieverhouding.
- **Level2**: Snellere compressie met een iets betere compressieverhouding dan **Level1**.
- **Level3**: Biedt betere compressie dan **Level2** met een matige impact op de verwerkingstijd.
- **Level4**: Biedt betere compressie dan **Level3**.
- **Level5**: Biedt verbeterde compressie ten opzichte van **Level4** met extra verwerkingstijd.
- **Level6**: Standaardcompressie die een goede balans biedt tussen verwerkingssnelheid en bestandsgrootte. Dit is het *standaard compressieniveau*.
- **Level7**: Biedt betere compressie dan **Level6** maar met tragere verwerking.
- **Level8**: Biedt betere compressie dan **Level7**.
- **Level9**: Maximale compressie. Produceert de kleinste bestandsgrootte ten koste van de langste verwerkingstijd.

Het volgende voorbeeld demonstreert hoe je een presentatie opslaat als een PPTX‑bestand *zonder compressie*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Dit voorbeeld laat zien hoe je een presentatie opslaat als een PPTX‑bestand met *maximale compressie*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan zonder de miniatuur te vernieuwen**

De [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) methode regelt het genereren van miniaturen bij het opslaan van een presentatie naar PPTX:

- Als `true`, wordt de miniatuur vernieuwd tijdens het opslaan. Dit is de standaardwaarde.
- Als `false`, blijft de huidige miniatuur behouden. Als de presentatie geen miniatuur heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de miniatuur te vernieuwen.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Deze optie helpt de tijd te verkorten die nodig is om een presentatie op te slaan in PPTX‑formaat.
{{% /alert %}}

## **Opslaan voortgangs‑updates in percentage**

Rapportage van de voortgang tijdens opslaan wordt geconfigureerd via de [setProgressCallback](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/#setProgressCallback) methode op [SaveOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/) en zijn subklassen. Lever een Java‑proxy die de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/) interface implementeert; tijdens de export ontvangt de callback periodieke percentage‑updates.

De volgende codefragmenten tonen hoe je `IProgressCallback` gebruikt.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Gebruik hier de voortgangspercentage‑waarde.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose heeft een gratis PowerPoint Splitter‑app ontwikkeld via haar eigen API. De app laat je een presentatie splitsen in meerdere bestanden door geselecteerde dia’s op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “fast save” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Opslaan maakt elke keer een volledig doelbestand; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑veilig om dezelfde Presentation‑instantie vanuit meerdere threads op te slaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) instantie is [niet thread‑veilig](/slides/nl/php-java/multithreading/); sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

[Hyperlinks](/slides/nl/php-java/manage-hyperlinks/) blijven behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd – zorg ervoor dat de verwijzende paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard [documenteigenschappen](/slides/nl/php-java/presentation-properties/) worden ondersteund en bij het opslaan in het bestand geschreven.