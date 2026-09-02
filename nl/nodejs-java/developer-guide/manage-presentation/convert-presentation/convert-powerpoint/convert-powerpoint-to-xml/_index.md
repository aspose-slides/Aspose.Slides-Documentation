---
title: PowerPoint-presentaties converteren naar XML in JavaScript
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument-presentaties naar PowerPoint XML-bestanden of -streams in JavaScript met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatieformaat. XML‑output is handig wanneer u een tekstgebaseerde weergave nodig heeft om de presentatiestructuur te inspecteren, gegenereerde documenten te probleemoplossen, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiemodule.

Gebruik de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save)‑methode met de `Xml`‑waarde van de [SaveFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/)‑enumeratie. U kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` maakt een PowerPoint XML‑presentatie aan. Het extraheert niet de afzonderlijke Office Open XML‑onderdelen die zich in een PPTX‑pakket bevinden. Als u de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of individuele slide‑XML‑bestanden, inspecteer dan zelf het PPTX‑pakket.
{{% /alert %}}

## **Een presentatie naar een XML‑bestand converteren**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat.Xml` door aan [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save). De bron kan elk presentatieformaat zijn dat wordt ondersteund voor het laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML‑output naar een stream schrijven**

Gebruik de stream‑overload van [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het volgende voorbeeld schrijft het resultaat naar een Java `ByteArrayOutputStream` en kopieert de gegenereerde gegevens naar een Node.js `Buffer`:

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

        // Geef xmlBuffer door aan de volgende component in de workflow.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML vergelijken met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat zal worden gebruikt:

| Format | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Structuur inspecteren, probleemoplossing, gegenereerde output vergelijken en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedocument | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Reguliere PowerPoint‑bewerking en presentatiewisseling |
| PDF or TIFF | Vaste‑layout pagina's of een meer‑pagina afbeelding | Bekijken, afdrukken en archiveren |
| PNG, JPEG, or SVG | Een gerenderde weergave van een individuele slide | Miniaturen, voorbeelden en beeldmaterialen |
| HTML or HTML5 | Web‑gerichte presentatie‑output | Weergave in browser en publicatie op het web |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en slide‑afbeeldingsformaten vertegenwoordigt het presentatiedata in plaats van het renderen van slides als pagina’s of visuele assets. De tabel met [ondersteunde bestandsformaten](/slides/nl/nodejs-java/supported-file-formats/) vermeldt PowerPoint XML Presentation als een alleen‑opslaan‑formaat, dus gebruik het niet wanneer een workflow het geëxporteerde bestand moet laden in Aspose.Slides voor verdere bewerking.

## **FAQ**

**Is `SaveFormat.Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat.Xml` een PowerPoint XML‑presentatiebestand maakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf aan te maken?**

Ja. Geef een beschrijfbare stream door aan [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save). Bijvoorbeeld, gebruik een Java `ByteArrayOutputStream` en kopieer de data naar een Node.js `Buffer` voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML Presentation wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatietype wanneer round‑trip bewerking vereist is.

**Renderen XML‑conversies elke slide als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor pagina‑georiënteerde output, of PNG, JPEG en SVG voor individuele slide‑afbeeldingen.