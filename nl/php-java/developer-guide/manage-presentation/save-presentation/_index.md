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
- Strikt Office Open XML-formaat
- Zip64-modus
- thumbnail verversen
- voortgang bij opslaan
- PHP
- Aspose.Slides
description: "Ontdek hoe u presentaties kunt opslaan met Aspose.Slides voor PHP via Java — exporteer naar PowerPoint of OpenDocument terwijl lay-outs, lettertypen en effecten behouden blijven."
---
## **Overzicht**

[Open presentaties in PHP](/slides/nl/php-java/open-presentation/) beschrijft hoe je de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse gebruikt om een presentatie te openen. Dit artikel legt uit hoe je presentaties maakt en opslaat. De [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse bevat de inhoud van een presentatie. Of je nu een presentatie vanaf nul maakt of een bestaande wijzigt, je wilt deze opslaan wanneer je klaar bent. Met Aspose.Slides voor PHP kun je opslaan naar een **bestand** of **stream**. Dit artikel legt de verschillende manieren uit om een presentatie op te slaan.

## **Presentaties opslaan naar bestanden**

Sla een presentatie op naar een bestand door de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse aan te roepen. Geef de bestandsnaam en het opslagformaat door aan de methode. Het volgende voorbeeld toont hoe je een presentatie opslaat met Aspose.Slides.

```php
// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
$presentation = new Presentation();
try {
    // Voer hier wat werk uit...

    // Sla de presentatie op naar een bestand.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan naar streams**

Je kunt een presentatie opslaan naar een stream door een output‑stream door te geven aan de `save`‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse. Een presentatie kan naar verschillende stream‑typen worden geschreven. In het onderstaande voorbeeld maken we een nieuwe presentatie en slaan we deze op naar een bestands‑stream.

```php
// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

Aspose.Slides stelt je in staat de initiële weergave die PowerPoint gebruikt wanneer de gegenereerde presentatie wordt geopend, in te stellen via de [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/)‑klasse. Gebruik de `setLastView`‑methode met een waarde uit de [ViewType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewtype/)‑enumeratie.

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

Aspose.Slides maakt het mogelijk een presentatie op te slaan in het Strict Office Open XML‑formaat. Gebruik de [PptxOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxoptions/)‑klasse en stel bij het opslaan de `conformance`‑eigenschap in. Als je `Conformance.Iso29500_2008_Strict` instelt, wordt het uitvoerbestand opgeslagen in het Strict Office Open XML‑formaat.

Het onderstaande voorbeeld maakt een presentatie en slaat die op in het Strict Office Open XML‑formaat.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instantieer de Presentation‑klasse die een presentatiedocument vertegenwoordigt.
$presentation = new Presentation();
try {
    // Sla de presentatie op in het Strikte Office Open XML‑formaat.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Presentaties opslaan in Office Open XML‑formaat in Zip64‑modus**

Een Office Open XML‑bestand is een ZIP‑archief dat limieten van 4 GB (2^32 bytes) oplegt aan de ongecomprimeerde grootte van elk bestand, de gecomprimeerde grootte en de totale grootte van het archief, en het beperkt het archief tot 65 535 (2^16−1) bestanden. ZIP64‑formatextensies verhogen deze limieten tot 2^64.

De `PptxOptions.setZip64Mode`‑methode stelt je in staat te kiezen wanneer ZIP64‑formatextensies te gebruiken bij het opslaan van een Office Open XML‑bestand.

Deze methode kan met de volgende modi worden gebruikt:

- `IfNecessary` gebruikt ZIP64‑formatextensies alleen als de presentatie de bovenstaande limieten overschrijdt. Dit is de standaardmodus.
- `Never` gebruikt nooit ZIP64‑formatextensies.
- `Always` gebruikt altijd ZIP64‑formatextensies.

De volgende code demonstreert hoe je een presentatie als PPTX opslaat met ZIP64‑formatextensies ingeschakeld:

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

{{% alert title="NOTE" color="warning" %}}
Wanneer je opslaat met `Zip64Mode.Never`, wordt een `PptxException` gegooid als de presentatie niet kan worden opgeslagen in ZIP32‑formaat.
{{% /alert %}}

## **Presentaties opslaan zonder de thumbnail te vernieuwen**

De `PptxOptions.setRefreshThumbnail`‑methode regelt de thumbnail‑generatie bij het opslaan van een presentatie naar PPTX:

- Als ingesteld op `true`, wordt de thumbnail tijdens het opslaan vernieuwd. Dit is de standaard.
- Als ingesteld op `false`, wordt de huidige thumbnail behouden. Als de presentatie geen thumbnail heeft, wordt er geen gegenereerd.

In de onderstaande code wordt de presentatie opgeslagen naar PPTX zonder de thumbnail te vernieuwen.

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
Deze optie helpt de tijd die nodig is om een presentatie in PPTX‑formaat op te slaan te verkorten.
{{% /alert %}}

## **Voortgangsupdates bij opslaan in percentage**

Het rapporteren van voortgang bij opslaan wordt geconfigureerd via de `setProgressCallback`‑methode op [SaveOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveoptions/) en de subklassen. Geef een Java‑proxy die de [IProgressCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprogresscallback/)‑interface implementeert; tijdens export ontvangt de callback periodieke percentage‑updates.

De volgende code‑fragmenten tonen hoe je `IProgressCallback` gebruikt.

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
Aspose heeft een gratis PowerPoint‑Splitter‑app ontwikkeld met behulp van zijn eigen API. De app stelt je in staat een presentatie te splitsen in meerdere bestanden door geselecteerde dia's op te slaan als nieuwe PPTX‑ of PPT‑bestanden.
{{% /alert %}}

## **FAQ**

**Wordt “fast save” (incrementeel opslaan) ondersteund zodat alleen wijzigingen worden weggeschreven?**

Nee. Bij elke opslaan wordt het volledige doelbestand aangemaakt; incrementeel “fast save” wordt niet ondersteund.

**Is het thread‑safe om dezelfde Presentation‑instantie vanaf meerdere threads op te slaan?**

Nee. Een Presentation‑instantie is niet thread‑safe; sla deze op vanuit één thread.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden bij het opslaan?**

Hyperlinks worden behouden. Extern gelinkte bestanden (bijv. video’s via relatieve paden) worden niet automatisch gekopieerd — zorg ervoor dat de verwezen paden toegankelijk blijven.

**Kan ik documentmetadata (Auteur, Titel, Bedrijf, Datum) instellen/opslaan?**

Ja. Standaard documenteigenschappen worden ondersteund en bij het opslaan in het bestand weggeschreven.