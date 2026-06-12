---
title: Rechthoeken toevoegen aan presentaties op Android
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/androidjava/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met Aspose.Slides voor Android via Java—ontwerp en wijzig vormen eenvoudig via code."
---
## **Overzicht**

Dit artikel laat zien hoe je rechthoekvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

Je ziet ook hoe je basisopmaak voor rechthoeken toepast, zoals een effen vulkleur, lijnkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingvullingen, visuele effecten, hyperlinks, shape‑vergrendelingen, exportopties en effectieve eigenschappen.

## **Een rechthoek toevoegen aan een dia**
Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [IAutoShape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape van het type Rectangle toe met de [addAutoShape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float- methode van het [IShapeCollection]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

```java
// Instantieer Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van ellipstype toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Schrijf het PPTX-bestand naar schijf
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een opgemaakte rechthoek toevoegen aan een dia**
Om een opgemaakte rechthoek toe te voegen aan een dia, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation klasse.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [IAutoShape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAutoShape van het type Rectangle toe met de [addAutoShape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float- methode van het [IShapeCollection]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection object.
- Stel het [Fill Type]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/FillType van de rechthoek in op Solid.
- Stel de kleur van de rechthoek in met de [SolidFillColor.setColor]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color- methode die wordt blootgesteld door het [IFillFormat]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFillFormat object dat aan het [IShape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape object is gekoppeld.
- Stel de kleur van de lijnen van de rechthoek in.
- Stel de breedte van de lijnen van de rechthoek in.
- Schrijf de gewijzigde presentatie weg als PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het onderstaande voorbeeld.

```java
// Instantieer de Presentation-klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van ellipstype toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Pas enige opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Pas enige opmaak toe op de lijn van de ellips
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schrijf het PPTX-bestand naar schijf
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het [shape type]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapetype/ met afgeronde hoeken en pas de radius van de hoek aan in de eigenschappen van de shape; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het afbeeldings‑[fill type]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/filltype/, geef de afbeeldingsbron op en configureer de [stretching/tiling modes]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturefillmode/.

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/androidjava/shape-effect/) zijn beschikbaar met instelbare parameters.

**Kan ik een rechthoek omzetten in een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/androidjava/manage-hyperlinks/) aan de klik op de shape (spring naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

Gebruik shape‑locks: je kunt verplaatsen, formaat wijzigen, selectie of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek omzetten naar een rasterafbeelding of SVG?**

Ja. Je kunt de [render the shape]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float- naar een afbeelding met een opgegeven grootte/schaal renderen of [export it as SVG]https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions- voor vectorgebruik.

**Hoe krijg ik snel de werkelijke (effectieve) eigenschappen van een rechthoek gezien thema en overerving?**

[Use the shape’s effective properties](/slides/nl/androidjava/shape-effective-properties/): de API geeft berekende waarden terug die rekening houden met themastijlen, lay‑out en lokale instellingen, waardoor formatteeranalyse wordt vereenvoudigd.