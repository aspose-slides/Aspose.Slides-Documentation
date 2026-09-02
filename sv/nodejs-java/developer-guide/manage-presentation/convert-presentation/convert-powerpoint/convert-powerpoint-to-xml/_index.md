---
title: Konvertera PowerPoint-presentationer till XML i JavaScript
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i JavaScript med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan konvertera PowerPoint-presentationer till PowerPoint XML Presentation-formatet. XML-utdata är användbart när du behöver en textbaserad representation för att inspektera presentationsstrukturen, felsöka genererade dokument, jämföra utdata i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd metoden [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) med värdet `Xml` från enumerationen [SaveFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/). Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Obs" %}}
`SaveFormat.Xml` skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML-delarna som lagras i ett PPTX-paket. Om du behöver de exakta PPTX-paketdelarna, såsom `ppt/presentation.xml` eller enskilda slide‑XML‑filer, inspektera själva PPTX-paketet.
{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/), och skicka sedan utdata‑sökvägen och `SaveFormat.Xml` till [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, såsom PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX-presentation till en XML‑fil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Skriv XML‑utdata till en ström**

Använd ström‑överkörningen av [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) när XML måste behållas i minnet eller skickas till en annan komponent, såsom en webbtjänst, lagringsleverantör eller XML‑bearbetningspipeline. Följande exempel skriver resultatet till en Java `ByteArrayOutputStream` och kopierar de genererade data till en Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Skicka xmlBuffer till nästa komponent i arbetsflödet.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Jämför XML med presentations‑ och exportformat**

Välj utdataformat enligt hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Inspektion av struktur, felsökning, jämförelse av genererat resultat och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF or TIFF | Fasta sidlayouter eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG, or SVG | En renderad representation av en enskild slide | Miniatyrer, förhandsvisningar och bildresurser |
| HTML or HTML5 | Webb‑orienterad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata främst avsedd för inspektion och datadrivna arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för slides representerar den presentationsdata snarare än att rendera slides som sidor eller visuella resurser. Tabellen [stödda filformat](/slides/sv/nodejs-java/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart spara‑format, så använd det inte när ett arbetsflöde måste läsa in den exporterade filen tillbaka i Aspose.Slides för fortsatt redigering.

## **Vanliga frågor**

**Är `SaveFormat.Xml` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat.Xml` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disken?**

Ja. Skicka en skrivbar ström till [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save). Till exempel, använd en Java `ByteArrayOutputStream` och kopiera dess data till en Node.js `Buffer` för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande endast för att sparas, inte för att läsas in. Använd PPTX eller något annat stödformat när redigering i båda riktningarna krävs.

**Renderar XML‑konvertering varje slide som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sid‑orienterad utdata, eller PNG, JPEG och SVG för enskilda slide‑bilder.