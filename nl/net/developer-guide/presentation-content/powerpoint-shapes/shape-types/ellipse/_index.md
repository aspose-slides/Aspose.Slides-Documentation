---
title: Ellipsen toevoegen aan presentaties in .NET
linktitle: Ellips
type: docs
weight: 30
url: /nl/net/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en manipuleren in Aspose.Slides voor .NET in PPT- en PPTX-presentaties, inclusief C#-codevoorbeelden."
---
## **Overzicht**

Dit artikel laat zien hoe je ellipsvormen aan PowerPoint‑dia’s toevoegt met behulp van Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Het raakt ook gerelateerde vragen aan, zoals werken met de positie en grootte van een ellips, de stapelvolgorde regelen en animatie‑effecten toepassen.

## **Maak een ellips**
Om een eenvoudige ellips aan een geselecteerde dia van de presentatie toe te voegen, volg je de onderstaande stappen:

1. Maak een instantie van [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)class
1. Haal de referentie van een dia op door gebruik te maken van de Index
1. Voeg een AutoShape van het type Ellipse toe met de AddAutoShape‑methode die beschikbaar is via het IShapes‑object
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we een ellips toegevoegd aan de eerste dia.

```c#
    // Maak een instantie van de Presentation class die de PPTX vertegenwoordigt
    using (Presentation pres = new Presentation())
    {
        // Haal de eerste dia op
        ISlide sld = pres.Slides[0];

        // Voeg een autoshape van het type ellips toe
        sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

        //Schrijf het PPTX-bestand naar de schijf
        pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
    }
```



## **Maak een opgemaakte ellips**
Om een beter opgemaakte ellips aan een dia toe te voegen, volg je de onderstaande stappen:

1. Maak een instantie van [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)class.
1. Haal de referentie van een dia op door gebruik te maken van de Index.
1. Voeg een AutoShape van het type Ellipse toe met de AddAutoShape‑methode die beschikbaar is via het IShapes‑object.
1. Stel het opvultype van de ellips in op Solid.
1. Stel de kleur van de ellips in via de SolidFillColor.Color‑eigenschap die beschikbaar is via het FillFormat‑object gekoppeld aan het IShape‑object.
1. Stel de kleur van de lijnen van de ellips in.
1. Stel de breedte van de lijnen van de ellips in.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips toegevoegd aan de eerste dia van de presentatie.

```c#
 // Maak een instantie van de Presentation‑klasse die de PPTX vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haal de eerste dia op
    ISlide sld = pres.Slides[0];

    // Voeg een autoshape van het type ellips toe
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Pas enige opmaak toe op de ellipsvorm
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Pas enige opmaak toe op de lijn van de ellips
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Schrijf het PPTX‑bestand naar de schijf
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **Veelgestelde vragen**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans opgegeven **in points**. Voor voorspelbare resultaten baseer je je berekeningen op de dia‑grootte en converteer je de benodigde millimeters of inches naar points voordat je waarden toewijst.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (de stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar de voorgrond te brengen of naar de achtergrond te sturen. Dit laat de ellips andere objecten overlappen of die eronder laten zien.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Apply](/slides/nl/net/shape-animation/) ingang, nadruk of uitgangseffecten toepassen op de vorm, en triggers en timing configureren om te bepalen wanneer en hoe de animatie wordt afgespeeld.