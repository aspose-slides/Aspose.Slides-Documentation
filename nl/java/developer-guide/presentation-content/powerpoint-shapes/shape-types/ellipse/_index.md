---
title: Ellipsen toevoegen aan presentaties in Java
linktitle: Ellips
type: docs
weight: 30
url: /nl/java/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en manipuleren in Aspose.Slides voor Java in PPT- en PPTX-presentaties — Java-codevoorbeelden inbegrepen."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen aan PowerPoint‑dia's kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Het gaat ook in op verwante vragen, zoals werken met de positie en grootte van een ellips, het regelen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Een ellips maken**
Om een eenvoudige ellips aan een geselecteerde dia van de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
- Haal de referentie van een dia op door zijn Index te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) die wordt blootgesteld door het object [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection).
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een ellips aan de eerste dia toegevoegd

```java
// Instantie van de Presentation klasse die de PPTX representeert
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voeg een AutoShape van ellips type toe
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Schrijf het PPTX bestand naar de schijf
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een opgemaakte ellips maken**
Om een beter opgemaakte ellips aan een dia toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation).
- Haal de referentie van een dia op door zijn Index te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met behulp van de methode [addAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) die wordt blootgesteld door het object [IShapeCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection).
- Stel het opvultype van de ellips in op Solid.
- Stel de kleur van de ellips in via de eigenschap SolidFillColor.Color die wordt blootgesteld door het object [FillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IFillFormat) dat is gekoppeld aan het object [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape).
- Stel de kleur van de lijnen van de ellips in.
- Stel de breedte van de lijnen van de ellips in.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips aan de eerste dia van de presentatie toegevoegd.

```java
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van ellipstype toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Pas enige opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Pas enige opmaak toe op de lijn van de ellips
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schrijf het PPTX-bestand naar de schijf
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe stel ik de exacte positie en grootte van een ellips in ten aanzien van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans gespecificeerd **in points**. Voor voorspelbare resultaten baseert u uw berekeningen op de dia‑grootte en converteert u benodigde millimeters of inches naar points voordat u waarden toewijst.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (de stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te sturen. Hierdoor kan de ellips andere objecten overlappen of die eronder zichtbaar maken.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Apply](/slides/nl/java/shape-animation/) binnenkomst-, nadruk‑ of uitgangseffecten op de vorm, en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.