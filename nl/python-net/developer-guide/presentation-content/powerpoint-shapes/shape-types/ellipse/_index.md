---
title: Ellipsen toevoegen aan presentaties in Python
linktitle: Ellips
type: docs
weight: 30
url: /nl/python-net/ellipse/
keywords:
  - ellips
  - vorm
  - ellips toevoegen
  - ellips maken
  - ellips tekenen
  - opgemaakte ellips
  - PowerPoint
  - OpenDocument
  - presentatie
  - Python
  - Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en manipuleren in Aspose.Slides for Python via .NET in PPT-, PPTX- en ODP‑presentaties—code‑voorbeelden inbegrepen."
---
## **Overzicht**

Dit artikel toont hoe ellipsvormen aan PowerPoint‑dia’s toe te voegen met Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, een opgemaakte ellips, en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Daarnaast worden verwante vragen behandeld, zoals het werken met de positie en grootte van een ellips, het regelen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Ellips maken**
In dit onderwerp introduceren we ontwikkelaars aan het toevoegen van ellipsvormen aan hun dia’s met Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET biedt een eenvoudigere reeks API’s om verschillende soorten vormen te tekenen met slechts een paar regels code. Om een eenvoudige ellips toe te voegen aan een geselecteerde dia van de presentatie, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)klasse
1. Verkrijg de referentie van een dia door zijn Index te gebruiken
1. Voeg een AutoShape van het type Ellipse toe met de AddAutoShape‑methode die door het IShapes‑object wordt aangeboden
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

In het voorbeeld hieronder hebben we een ellips toegevoegd aan de eerste dia.

```py
import aspose.slides as slides

# Instantie van Presentation class die de PPTX vertegenwoordigt
    # Haal de eerste dia op
    sld = pres.slides[0]

    # Voeg autoshape van type ellips toe
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Schrijf het PPTX bestand naar schijf
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Opgemaakte ellips maken**
Om een beter opgemaakte ellips aan een dia toe te voegen, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)klasse.
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.
1. Voeg een AutoShape van het type Ellipse toe met de AddAutoShape‑methode die door het IShapes‑object wordt aangeboden.
1. Stel het vultype van de ellips in op Solid.
1. Stel de kleur van de ellips in via de SolidFillColor.Color‑eigenschap die door het FillFormat‑object van het IShape‑object wordt aangeboden.
1. Stel de kleur van de lijnen van de ellips in.
1. Stel de breedte van de lijnen van de ellips in.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een opgemaakte ellips toegevoegd aan de eerste dia van de presentatie.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die de PPTX vertegenwoordigt
with slides.Presentation() as pres:
    # Haal de eerste dia op
    sld = pres.slides[0]

    # Voeg een autoshape van het type ellips toe
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Pas enige opmaak toe op de ellipsvorm
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Pas enige opmaak toe op de lijn van de ellips
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Schrijf het PPTX-bestand naar schijf
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans **in points** opgegeven. Voor voorspelbare resultaten baseer je berekeningen op de dia‑grootte en converteer je benodigde millimeters of inches naar points voordat je waarden toewijst.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te sturen. Hierdoor kan de ellips andere objecten overlappen of de onderliggende objecten onthullen.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Toepassen](/slides/nl/python-net/shape-animation/) van binnenkomst‑, nadruk‑ of uitgangseffecten op de vorm, en triggers en timing configureren om te bepalen wanneer en hoe de animatie wordt afgespeeld.