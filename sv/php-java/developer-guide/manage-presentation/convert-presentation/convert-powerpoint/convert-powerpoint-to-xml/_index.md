---
title: Konvertera PowerPoint-presentationer till XML i PHP
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/php-java/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML-presentation
- SaveFormat.Xml
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i PHP med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides for PHP via Java kan konvertera PowerPoint‑presentationer till PowerPoint XML Presentation‑formatet. XML‑utdata är användbart när du behöver en textbaserad representation för att inspektera presentationsstruktur, felsöka genererade dokument, jämföra resultat i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd metoden [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) med `Xml`‑värdet från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Obs" %}}

`SaveFormat::Xml` skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakta PPTX‑paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera själva PPTX‑paketet.

{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), och skicka sedan utgångssökvägen och `SaveFormat::Xml` till [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, såsom PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX‑presentation till en XML‑fil:

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

## **Skriv XML‑utdata till en ström**

Använd ström‑överladdningen av [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) när XML‑data måste ligga i minnet eller överföras till en annan komponent, till exempel en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) och får den genererade XML‑filen som en byte‑array:

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

        // Skicka $xmlBytes till nästa komponent i arbetsflödet.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

En `ByteArrayOutputStream` lagrar all genererad data i minnet, så ingen positionsåterställning behövs innan `toByteArray` anropas.

## **Jämför XML med presentations‑ och exportformat**

Välj utdataformat enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Inspektera struktur, felsöka, jämföra genererad utdata och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket med flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Sidor med fast layout eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrbilder, förhandsvisningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Webbläsarvisning och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och data‑orienterade arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/php-java/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart‑spara‑format, så använd den inte när ett arbetsflöde måste läsa in den exporterade filen igen i Aspose.Slides för fortsatt redigering.

## **Vanliga frågor**

**Är `SaveFormat::Xml` detsamma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat::Xml` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disk?**

Ja. Skicka en skrivbar ström till [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/). Till exempel, använd en [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande endast för sparande, inte för inläsning. Använd PPTX eller ett annat stödt presentationsformat när rundresediting krävs.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sidorienterad utdata, eller PNG, JPEG och SVG för enskilda bild‑bilder.