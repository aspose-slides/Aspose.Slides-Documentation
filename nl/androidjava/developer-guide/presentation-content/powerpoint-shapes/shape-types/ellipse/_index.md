---
title: Ellipsen toevoegen aan presentaties op Android
linktitle: Ellipse
type: docs
weight: 30
url: /nl/androidjava/ellipse/
keywords:
- ellipse
- vorm
- ellipse toevoegen
- ellipse maken
- ellipse tekenen
- opgemaakte ellipse
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en bewerken in Aspose.Slides voor Android in zowel PPT- en PPTX-presentaties -- inclusief Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Daarnaast wordt ingegaan op gerelateerde vragen, zoals werken met de positie en grootte van een ellips, het beheersen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Een ellips maken**
Om een eenvoudige ellips toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
- Verkrijg de referentie van een dia door het indexnummer te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection)‑object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een ellips toegevoegd aan de eerste dia

```java
// Maak een instantie van de Presentation‑klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voeg een AutoShape van het type ellipse toe
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Schrijf het PPTX‑bestand naar schijf
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Een opgemaakte ellips maken**
Om een beter opgemaakte ellips aan een dia toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
- Verkrijg de referentie van een dia door het indexnummer te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met de [addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑methode van het [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection)‑object.
- Stel het vultype van de Ellipse in op Solid.
- Stel de kleur van de Ellipse in met de SolidFillColor.Color‑eigenschap van het [FillFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IFillFormat)‑object dat gekoppeld is aan het [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape)‑object.
- Stel de kleur van de lijnen van de Ellipse in.
- Stel de breedte van de lijnen van de Ellipse in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips toegevoegd aan de eerste dia van de presentatie.

```java
// Maak een instantie van de Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Voeg een AutoShape van het type ellipse toe
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Pas enige opmaak toe op de ellipsvorm
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Pas enige opmaak toe op de lijn van de ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Schrijf het PPTX-bestand naar schijf
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans opgegeven **in points**. Voor voorspelbare resultaten baseer je berekeningen op de grootte van de dia en converteer je benodigde millimeters of inches naar points voordat je waarden toekent.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (stapelvolgorde beheersen)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te verzenden. Hierdoor kan de ellips andere objecten overlappen of die eronder onthullen.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Toepassen](/slides/nl/androidjava/shape-animation/) ingang-, nadruk- of uitgangseffecten op de vorm en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.