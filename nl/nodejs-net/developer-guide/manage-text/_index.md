---
title: Beheer Presentatietekst in Node.js via .NET
linktitle: Beheer Tekst
type: docs
weight: 50
url: /nl/nodejs-net/manage-text/
keywords:
- tekst
- tekstvak
- tekst toevoegen
- tekst wijzigen
- tekst opmaken
- lettergrootte
- vette tekst
- tekstvak
- alinea
- deel
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg een tekstvak toe aan een dia, wijzig vervolgens de tekst, lettergrootte en vette stijl in JavaScript met Aspose.Slides voor Node.js via .NET."
---
## **Overzicht**

In Aspose.Slides behoort de tekst op een dia tot een vorm. Een automatische vorm, zoals een rechthoek, heeft een tekstvak; het tekstvak bevat alinea’s, en elke alinea bevat delen, dit zijn reeksen tekst met dezelfde opmaak. U wijzigt de tekst via het tekstvak en het lettertype via de opmaak van een deel.

Dit artikel voegt een tekstvak toe aan een dia en slaat de presentatie op. Vervolgens wordt het opgeslagen bestand geopend en wordt de tekst, lettergrootte en vette stijl van het tekstvak aangepast.

De voorbeelden hebben een project nodig zoals beschreven in [Installation](/slides/nl/nodejs-net/installation/). Sla elk voorbeeld op als een `.js`‑bestand in de projectmap en voer het vanuit die map uit met `node`.

{{% alert color="info" title="Opmerking" %}}
Aspose.Slides for Node.js via .NET heeft geen eigen API‑referentie. Het spiegelt de Aspose.Slides for .NET API met camelCase‑namen, dus de API‑links in dit artikel leiden naar de overeenkomstige klassen en leden in de [Aspose.Slides for .NET API‑referentie](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Een Tekstvak Toevoegen**

Om een tekstvak toe te voegen, voegt u een automatische vorm toe aan een dia met de [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/)‑methode en geeft u deze tekst met de [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/)‑methode. Het volgende voorbeeld voegt een rechthoek toe aan de eerste dia van een nieuwe presentatie en slaat de presentatie op als `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // De positie (x, y) en de afmeting (breedte, hoogte) zijn in punten.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

De dia in `text-box.pptx` bevat een rechthoek, 500 punten breed en 80 punten hoog, met de tekst “Quarterly report” in het standaard lettertype en grootte. Het volgende voorbeeld wijzigt dit tekstvak.

## **De Tekst en Opmaak Wijzigen**

Het volgende voorbeeld opent `text-box.pptx`, dat door het vorige voorbeeld is gemaakt, en krijgt de eerste vorm op de eerste dia. Vormen zoals afbeeldingen en tabellen hebben geen tekstvak, dus het voorbeeld controleert of de vorm een [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) is voordat het de [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) van de vorm gebruikt. Daarna gebeurt het volgende:

1. Het vervangt de tekst via de [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/)‑eigenschap van het tekstvak. Daarna bevat het tekstvak één alinea met één deel.
2. Het haalt dat deel op uit de [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/)‑ en [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/)‑collecties en leest de [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).
3. Het stelt [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in, de lettergrootte in punten, en [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), die een [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)‑waarde accepteert.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

In `text-box-updated.pptx` toont het tekstvak “Quarterly report: third quarter” in vet 32‑punt type. Omdat de nieuwe tekst één enkel deel is, gelden de twee opmaak‑eigenschappen op het gehele deel. Zonder licentie voegt elke opslag een evaluatiewatermerk toe. Omdat `text-box.pptx` zelf al in evaluatiemodus is opgeslagen, bevat `text-box-updated.pptx` er twee; zie [Evaluate Aspose.Slides](/slides/nl/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Waarom accepteert `fontBold` een `NullableBool`‑waarde in plaats van `true` of `false`?**

Een deel kan een eigenschap ongedefinieerd laten en deze erven van de alinea, de vorm, of de lay‑out en master van de dia. `NullableBool.NotDefined` betekent “erven”, terwijl `NullableBool.True` en `NullableBool.False` de geërfde waarde overschrijven. Het toewijzen van `true` of `false` veroorzaakt een fout. Om dezelfde reden geeft `fontHeight` `NaN` terug wanneer het deel de lettergrootte erft.

**Hoe wijzig ik de tekstkleur?**

Stel het vultype van de deelopmaak in: wijs `FillType.Solid` toe aan `portionFormat.fillFormat.fillType`, en wijs vervolgens een kleur toe, bijvoorbeeld `"#FF0000"`, aan `portionFormat.fillFormat.solidFillColor.color`. Voeg `FillType` toe aan de namen die u uit het pakket importeert.

**Hoe formatteer ik slechts een deel van de tekst?**

Opmaak behoort tot delen, dus plaats dat deel van de tekst in een eigen deel. Maak het deel aan met `Portion.CreatePortionFromText`, voeg het toe aan een alinea met de `add`‑methode van de `portions`‑collectie van de alinea, en stel vervolgens de `portionFormat` van het nieuwe deel in. Voeg `Portion` toe aan de namen die u uit het pakket importeert.

**Waarom geeft het lezen van tekst “… text has been truncated due to evaluation version limitation”?**

Zonder licentie geeft Aspose.Slides alleen de eerste vijf tekens van elke langere tekst die u leest, zoals `textFrame.text`, gevolgd door deze melding. Tekst die u schrijft, wordt volledig opgeslagen. Pas een licentie toe zoals beschreven in [Licensing](/slides/nl/nodejs-net/licensing/) om de volledige tekst te lezen.