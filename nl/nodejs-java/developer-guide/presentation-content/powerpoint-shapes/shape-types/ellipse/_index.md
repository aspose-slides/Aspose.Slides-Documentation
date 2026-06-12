---
title: Ellipsen toevoegen aan presentaties in JavaScript
linktitle: Ellips
type: docs
weight: 30
url: /nl/nodejs-java/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u ellipsvormen maakt, opmaakt en bewerkt in Aspose.Slides voor Node.js in PPT‑ en PPTX‑presentaties—JavaScript‑codevoorbeelden inbegrepen."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de gewijzigde presentatie als een PPTX‑bestand. Het behandelt ook gerelateerde vragen zoals het werken met de positie en grootte van een ellips, het beheersen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Ellips maken**
Om een eenvoudige ellips toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
- Haal de referentie van een dia op door gebruik te maken van de Index.
- Voeg een AutoShape van het type Ellipse toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) die beschikbaar is via het object [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een ellips aan de eerste dia toegevoegd

```javascript
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type ellips toe
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Schrijf het PPTX-bestand naar de schijf
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Opgemaakte ellips maken**
Om een beter opgemaakte ellips aan een dia toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation).
- Haal de referentie van een dia op door gebruik te maken van de Index.
- Voeg een AutoShape van het type Ellipse toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) die beschikbaar is via het object [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection).
- Stel het opvultype van de ellips in op Solid.
- Stel de kleur van de ellips in via de eigenschap SolidFillColor.Color van het object [FillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/FillFormat) dat gekoppeld is aan het object [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape).
- Stel de kleur van de lijnen van de ellips in.
- Stel de breedte van de lijnen van de ellips in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips aan de eerste dia van de presentatie toegevoegd.

```javascript
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Voeg een AutoShape van het type ellips toe
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Pas enige opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Pas enige opmaak toe op de lijn van de ellips
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Schrijf het PPTX-bestand naar de schijf
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden meestal gespecificeerd **in points**. Voor voorspelbare resultaten baseert u uw berekeningen op de dia‑grootte en zet u de vereiste millimeters of inches om naar points voordat u waarden toekent.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (de stapelvolgorde beheren)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te verzenden. Hierdoor kan de ellips andere objecten overlappen of die eronder liggen zichtbaar maken.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Apply](/slides/nl/nodejs-java/shape-animation/) ingang-, nadruk‑ of uitgangseffecten op de vorm, en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.