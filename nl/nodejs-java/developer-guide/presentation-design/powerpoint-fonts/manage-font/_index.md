---
title: Lettertypen beheren in presentaties met JavaScript
linktitle: Lettertypen beheren
type: docs
weight: 10
url: /nl/nodejs-java/manage-fonts/
keywords:
- lettertypen beheren
- lettertype-eigenschappen
- alinea
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer lettertypen met Aspose.Slides voor Node.js via Java: integreer, vervang en laad aangepaste lettertypen om PPT-, PPTX- en ODP-presentaties helder en consistent te houden."
---
## **Inleiding**

Presentaties bevatten meestal zowel tekst als afbeeldingen. De tekst kan op verschillende manieren worden opgemaakt, bijvoorbeeld om specifieke secties en woorden te benadrukken of om te voldoen aan de bedrijfsstijlen. Tekstopmaak helpt gebruikers het uiterlijk en de beleving van de presentatietekst te variëren. Dit artikel toont hoe u Aspose.Slides voor Node.js via Java gebruikt om de lettertype‑eigenschappen van alinea’s tekst op dia’s te configureren.

## **Beheer van lettertypegerelateerde eigenschappen**

Om de lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides voor Node.js via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Verkrijg een referentie naar een dia door gebruik te maken van de index.
1. Ga naar de [Placeholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/)‑vormen in de dia en cast ze naar [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) dat wordt blootgesteld door de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
1. Uitvullen van de alinea.
1. Open de tekst‑[Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) van een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/).
1. Definieer het lettertype met [FontData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontdata/) en stel de **Font** van de tekst‑[Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) overeenkomstig in.
   1. Maak het lettertype vet.
   1. Maak het lettertype cursief.
1. Stel de letterkleur in met behulp van de [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/) die beschikbaar is via het [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/)-object.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder. Het neemt een onbewerkte presentatie en formatteert de lettertypen op één van de dia’s. De screenshots die volgen tonen het invoerbestand en hoe de code‑fragmenten dit veranderen. De code wijzigt het lettertype, de kleur en de stijl van het lettertype.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```javascript
// Instantieer een Presentation‑object dat een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Toegang tot een dia via de positie van de dia
    var slide = pres.getSlides().get_Item(0);
    // Toegang tot de eerste en tweede placeholder in de dia en casten naar AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Toegang tot de eerste alinea
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Uitvullen van de alinea
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Toegang tot de eerste portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Nieuwe lettertypen definiëren
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Nieuwe lettertypen toewijzen aan de portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Lettertype vet maken
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Lettertype cursief maken
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Letterkleur instellen
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX opslaan naar schijf
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettertype‑eigenschappen van tekst instellen**
{{% alert color="primary" %}} 

Zoals vermeld in **Beheer van lettertypegerelateerde eigenschappen**, wordt een [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) gebruikt om tekst met een vergelijkbare opmaakstijl in een alinea vast te houden. Dit artikel toont hoe u Aspose.Slides voor Node.js via Java gebruikt om een tekstvak met enige tekst te maken en vervolgens een specifiek lettertype en diverse andere eigenschappen van de lettertype‑familie te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en de lettertype‑eigenschappen van de tekst erin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een dia door de index te gebruiken.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) van het type **Rectangle** toe aan de dia.
1. Verwijder de opvulstijl die gekoppeld is aan de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
1. Open het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
1. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).
1. Open het [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/)‑object dat aan het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) is gekoppeld.
1. Definieer het lettertype dat gebruikt wordt voor de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/).
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en hoogte, met behulp van de relevante eigenschappen die beschikbaar zijn via het [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/)-object.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met enkele lettertype‑eigenschappen ingesteld door Aspose.Slides voor Node.js via Java**|

```javascript
// Instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type Rectangle toe
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Verwijder eventuele opvulstijl die gekoppeld is aan de AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Toegang tot het TextFrame dat gekoppeld is aan de AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Toegang tot de Portion die gekoppeld is aan het TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Stel het lettertype in voor de Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Stel de vet-eigenschap van het lettertype in
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Stel de cursief-eigenschap van het lettertype in
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Stel de onderstreep-eigenschap van het lettertype in
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Stel de hoogte van het lettertype in
    port.getPortionFormat().setFontHeight(25);
    // Stel de kleur van het lettertype in
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Sla de presentatie op naar schijf
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```