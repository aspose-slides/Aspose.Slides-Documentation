---
title: Converteer PowerPoint-presentaties naar XML in PHP
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint naar XML converteren
- presentatie naar XML converteren
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML-presentatie
- SaveFormat.Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stream
- PHP
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties naar PowerPoint XML-bestanden of -streams in PHP met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides voor PHP via Java kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑Presentatie‑formaat. XML‑output is handig wanneer u een tekstgebaseerde weergave nodig heeft om de presentatiestructuur te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiepakket.

Gebruik de [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑methode met de `Xml`‑waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/)‑enumeratie. U kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Opmerking" %}}

`SaveFormat::Xml` maakt een PowerPoint XML‑presentatie aan. Het extraheert niet de afzonderlijke Office Open XML‑onderdelen die in een PPTX‑pakket opgeslagen zijn. Als u de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of afzonderlijke slide‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.

{{% /alert %}}

## **Een presentatie naar een XML‑bestand converteren**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat::Xml` door aan [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/). De bron kan elk presentatie‑formaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML‑output naar een stream schrijven**

Gebruik de stream‑overload van [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) en verkrijgt de gegenereerde XML als een byte‑array:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Geef $xmlBytes door aan de volgende component in de workflow.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Een `ByteArrayOutputStream` slaat alle gegenereerde data in het geheugen op, zodat er geen positie‑reset nodig is vóór het aanroepen van `toByteArray`.

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat wordt gebruikt:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Inspectie van de structuur, foutopsporing, vergelijken van gegenereerde output en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedocument | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Gewoon bewerken van PowerPoint en uitwisseling van presentaties |
| PDF of TIFF | Pagina’s met vaste layout of een meer‑paginas afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een individuele slide | Miniaturen, voorbeeldweergaven en afbeeldings‑assets |
| HTML of HTML5 | Web‑gerichte presentatie‑output | Weergave in browsers en publicatie op het web |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en slide‑afbeeldingsformaten representeert het presentatie‑data in plaats van slides te renderen als pagina’s of visuele assets. De [supported file formats](/slides/nl/php-java/supported-file-formats/)‑tabel vermeldt PowerPoint XML‑Presentatie als een alleen‑opslaan‑formaat, dus gebruik het niet wanneer een workflow het geëxporteerde bestand moet kunnen laden in Aspose.Slides voor vervolg‑bewerking.

## **FAQ**

**Is `SaveFormat::Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat::Xml` een PowerPoint XML‑presentatie‑bestand aanmaakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf aan te maken?**

Ja. Geef een beschrijfbare stream door aan [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/). Gebruik bijvoorbeeld een [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML‑presentatie wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatief­formaat wanneer round‑trip bewerking vereist is.

**Rendeert XML‑conversie elke slide als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor afzonderlijke slide‑afbeeldingen.