---
title: Rechthoeken toevoegen aan presentaties in JavaScript
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/nodejs-java/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met JavaScript en Aspose.Slides voor Node.js — ontwerp en wijzig vormen eenvoudig via code."
---
## **Overzicht**

Dit artikel laat zien hoe u rechthoekvormen aan PowerPoint-dia's kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

U ziet ook hoe u basisopmaak van rechthoeken toepast, zoals een effen vulkleur, lijnkleur en lijndikte. Daarnaast verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen. 

## **Rechthoek toevoegen aan dia**

Net als eerdere onderwerpen gaat dit ook over het toevoegen van een vorm en deze keer is de vorm die we bespreken een Rechthoek. In dit onderwerp hebben we beschreven hoe ontwikkelaars eenvoudige of opgemaakte rechthoeken aan hun dia's kunnen toevoegen met Aspose.Slides. 

Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) van het type Rechthoek toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection)‑object.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

```javascript
// Maak een instantie van de Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type ellips toe
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Opgemaakte rechthoek toevoegen aan dia**
Om een opgemaakte rechthoek aan een dia toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/AutoShape) van het type Rechthoek toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection)‑object.
- Stel het [Fill Type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FillType) van de Rechthoek in op Solid.
- Stel de kleur van de Rechthoek in met behulp van de [SolidFillColor.setColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) methode van het [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FillFormat)‑object dat is gekoppeld aan het [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape)‑object.
- Stel de kleur van de lijnen van de Rechthoek in.
- Stel de breedte van de lijnen van de Rechthoek in.
- Schrijf de aangepaste presentatie weg als PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het onderstaande voorbeeld.

```javascript
// Maak een instantie van de Presentation-klasse die de PPTX voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type ellips toe
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Pas wat opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Pas wat opmaak toe op de lijn van de ellips
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Schrijf het PPTX-bestand naar schijf
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het [shape type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapetype/) met afgeronde hoeken en pas de hoekradius aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het afbeelding-[fill type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/), geef de afbeeldingsbron op en configureer de [stretching/tiling modes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillmode/).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/nodejs-java/shape-effect/) zijn beschikbaar met instelbare parameters.

**Kan ik een rechthoek omzetten in een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/nodejs-java/manage-hyperlinks/) aan de klik van de vorm (spring naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

Gebruik vormvergrendelingen: u kunt verplaatsen, grootte wijzigen, selecteren of tekst bewerken verbieden om de lay-out te behouden.

**Kan ik een rechthoek converteren naar een rasterafbeelding of SVG?**

Ja. U kunt de vorm [renderen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) naar een afbeelding met een opgegeven grootte/schaal of [exporteren als SVG](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) voor vectorgebruik.

**Hoe krijg ik snel de daadwerkelijke (effectieve) eigenschappen van een rechthoek, rekening houdend met thema en overerving?**

[Gebruik de effectieve eigenschappen van de vorm](/slides/nl/nodejs-java/shape-effective-properties/): de API retourneert berekende waarden die rekening houden met themastijlen, lay-out en lokale instellingen, waardoor de opmaak‑analyse wordt vereenvoudigd.