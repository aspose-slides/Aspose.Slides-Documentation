---
title: Voeg rechthoeken toe aan presentaties in Java
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/java/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met Aspose.Slides voor Java—ontwerp en wijzig vormen moeiteloos programmatisch."
---
## **Overzicht**

Dit artikel laat zien hoe je rechthoekvormen aan PowerPoint‑dia's kunt toevoegen met behulp van Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek, en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

Je ziet ook hoe je basisopmaak voor een rechthoek toepast, zoals een effen vulkleur, lijnkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen.

## **Een rechthoek aan een dia toevoegen**
Om een eenvoudige rechthoek aan een geselecteerde dia van de presentatie toe te voegen, volg je de onderstaande stappen:

- Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) class.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) van het type Rectangle toe met de [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode die beschikbaar is via het [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek aan de eerste dia van de presentatie toegevoegd.

```java
// Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van ellips‑type toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een opgemaakte rechthoek aan een dia toevoegen**
Om een opgemaakte rechthoek aan een dia toe te voegen, volg je de onderstaande stappen:

- Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) class.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAutoShape) van het type Rectangle toe met de [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode die beschikbaar is via het [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection) object.
- Stel het **Fill Type** van de rechthoek in op **Solid**.
- Stel de kleur van de rechthoek in met de **SolidFillColor.setColor**‑methode van het [IFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFillFormat) object dat gekoppeld is aan het [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape) object.
- Stel de kleur van de lijnen van de rechthoek in.
- Stel de breedte van de lijnen van de rechthoek in.
- Schrijf de gewijzigde presentatie weg als PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het voorbeeld hieronder.

```java
// Instantieer de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van ellips‑type toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Pas enige opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Pas enige opmaak toe op de lijn van de ellips
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schrijf het PPTX‑bestand naar schijf
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het vormtype met afgeronde hoeken en pas de hoekradius aan in de eigenschapsinstellingen van de vorm; afronding kan ook per hoek worden toegepast via geometrische aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het vultype picture, geef de afbeeldingsbron op en configureer de stretch‑/tiling‑modi.

**Kan een rechthoek schaduw en gloed hebben?**

Ja. Outer/inner shadow, glow en soft edges zijn beschikbaar met instelbare parameters.

**Kan ik een rechthoek omvormen tot een knop met een hyperlink?**

Ja. Wijs een hyperlink toe aan het klikken op de vorm (naar een dia, bestand, webadres of e‑mail springen).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

Gebruik shape locks: je kunt verplaatsen, grootte wijzigen, selectie of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek converteren naar een rasterafbeelding of SVG?**

Ja. Je kunt de vorm renderen naar een afbeelding met een opgegeven grootte/schaal of exporteren als SVG voor vectorgebruik.

**Hoe krijg ik snel de werkelijke (effectieve) eigenschappen van een rechthoek met inachtneming van thema en overerving?**

Gebruik de effectieve eigenschappen van de vorm: de API geeft berekende waarden terug die rekening houden met themastijlen, lay‑out en lokale instellingen, waardoor analyse van opmaak wordt vereenvoudigd.