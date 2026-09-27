---
title: Presentaties openen in Node.js via .NET
linktitle: Presentatie openen
type: docs
weight: 20
url: /nl/nodejs-net/open-presentation/
keywords:
- open presentatie
- open PowerPoint
- open PPTX
- open PPT
- open ODP
- presentatie laden
- presentatie uit buffer
- aantal dia's
- presentatie converteren
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Open PPTX-, PPT- en ODP‑presentaties in JavaScript met Aspose.Slides for Node.js via .NET: laad vanuit een bestandspad of een Buffer, lees het aantal dia's en sla op in een ander formaat."
---
## **Overzicht**

Aspose.Slides for Node.js via .NET opent PowerPoint- en OpenDocument-presentaties, zoals PPTX-, PPT- en ODP-bestanden, vanuit een bestandsnaam of vanuit een Node.js `Buffer`. Dit artikel toont beide methoden, leest het aantal dia's en slaat een geopende presentatie op in een ander formaat.

De voorbeelden gaan uit van een presentatie met de naam `sample.pptx` in de projectmap die je hebt opgezet in [Installation](/slides/nl/nodejs-net/installation/). Elke PowerPoint-presentatie is geschikt. Sla elk voorbeeld op als een `.js`‑bestand in de projectmap en voer het vanuit die map uit met `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET heeft geen eigen API‑referentie. Het spiegelt de Aspose.Slides for .NET‑API met camelCase‑namen, dus de API‑links in dit artikel verwijzen naar de overeenkomende klassen en leden in de [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/nl/net/).
{{% /alert %}}

## **Een presentatie openen vanuit een bestand**

Om een presentatie te openen, geef je het pad door aan de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/presentation/)‑constructor. Aspose.Slides detecteert het formaat uit de bestandsinhoud in plaats van uit de extensie, zodat dezelfde code PPTX-, PPT- en ODP‑bestanden kan openen. Een relatief pad wordt opgelost ten opzichte van de huidige werkmap, die de projectmap is wanneer je het script daar uitvoert.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Het script geeft het aantal dia's in `sample.pptx` weer, bijvoorbeeld `Slide count: 9`. De `count`‑eigenschap van de [slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/)‑collectie omvat verborgen dia's. Roep `dispose` aan in een `finally`‑blok, zoals getoond, zodat de .NET‑resources achter de presentatie worden vrijgegeven, zelfs als je code faalt.

## **Een presentatie openen vanuit een buffer**

Wanneer een presentatie afkomstig is van een database, een HTTP‑upload of een andere bron die je bytes geeft in plaats van een bestandsnaam, geef je een Node.js `Buffer` door als tweede argument van de constructor en `null` als eerste. Het volgende voorbeeld leest `sample.pptx` in een buffer als voorbeeld van zo'n bron:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Het script geeft hetzelfde aantal dia's weer als het vorige voorbeeld. Het tweede argument moet een `Buffer` zijn. Voor elk ander type, zoals een `Uint8Array`, meldt de constructor geen fout; hij maakt in plaats daarvan een nieuwe presentatie met één lege dia. Converteer andere binaire types eerst met `Buffer.from`.

## **Een presentatie opslaan in een ander formaat**

Om een presentatie naar een ander presentatiefomaat te converteren, open je deze en sla je hem op met een andere [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)-waarde. Het volgende voorbeeld geeft het formaat weer dat Aspose.Slides heeft gedetecteerd, dat de [sourceFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sourceformat/)‑eigenschap retourneert, en slaat de presentatie op als een OpenDocument‑presentatie:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Het script geeft `Source format: Pptx` weer en schrijft `sample.odp`, die dezelfde dia's bevat. `sourceFormat` retourneert `Ppt`, `Pptx` of `Odp`. Om in plaats daarvan op te slaan als PDF of als afbeeldingen, zie [Convert PowerPoint to PDF](/slides/nl/nodejs-net/convert-powerpoint-to-pdf/) en [Convert Slides to Images](/slides/nl/nodejs-net/convert-slide/).

## **FAQ**

**Hoe open ik een met wachtwoord beveiligde presentatie?**

Maak een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑object aan, stel de eigenschap [password](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/password/) in, en geef het object door als derde argument van de constructor: `new Presentation("protected.pptx", null, loadOptions)`. Zonder het juiste wachtwoord werpt de constructor een fout.

**Waarom gooit de constructor een `Error` met een leeg bericht?**

Wanneer de `Presentation`‑constructor in .NET faalt, bijvoorbeeld omdat het bestand ontbreekt, geen presentatie is, of een ander wachtwoord vereist, ontvangt JavaScript een `Error` waarvan het bericht leeg is. Controleer vóór het openen van een bestand of het bestaat ten opzichte van de werkmap, bijvoorbeeld met `fs.existsSync`.

**Welke formaten kan ik openen?**

PowerPoint- en OpenDocument-presentatieformaten, waaronder PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP en FODP.