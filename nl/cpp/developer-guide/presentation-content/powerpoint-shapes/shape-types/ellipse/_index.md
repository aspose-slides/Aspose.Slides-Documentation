---
title: Ellipsen toevoegen aan presentaties in C++
linktitle: Ellips
type: docs
weight: 30
url: /nl/cpp/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en manipuleren in Aspose.Slides voor C++ in PPT- en PPTX-presentaties — C++-codevoorbeelden inbegrepen."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen aan PowerPoint‑dia’s kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Daarnaast worden gerelateerde vragen behandeld, zoals werken met de positie en grootte van een ellips, de stapelvolgorde regelen en animatie‑effecten toepassen.

## **Een ellips maken**
In dit onderwerp introduceren we ontwikkelaars aan het toevoegen van ellipsvormen aan hun dia’s met Aspose.Slides for C++. Aspose.Slides for C++ biedt een eenvoudigere set API’s om verschillende vormen te tekenen met slechts een paar regels code. Om een eenvoudige ellips aan een geselecteerde presentatie‑dia toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation-klasse](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)
1. Verkrijg de referentie van een dia door gebruik te maken van de Index
1. Voeg een AutoShape van het type Ellipse toe via de AddAutoShape‑methode van het IShapes‑object
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we een ellips toegevoegd aan de eerste dia.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Een opgemaakte ellips maken**
Om een beter opgemaakte ellips aan een dia toe te voegen, volgt u de onderstaande stappen:

1. Maak een instantie van [Presentation-klasse](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Verkrijg de referentie van een dia door gebruik te maken van de Index.
1. Voeg een AutoShape van het type Ellipse toe via de AddAutoShape‑methode van het IShapes‑object.
1. Stel het vultype van de Ellipse in op Solid.
1. Stel de kleur van de Ellipse in via de SolidFillColor.Color‑eigenschap van het FillFormat‑object dat bij het IShape‑object hoort.
1. Stel de kleur van de lijnen van de Ellipse in.
1. Stel de breedte van de lijnen van de Ellipse in.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips toegevoegd aan de eerste dia van de presentatie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **Veelgestelde vragen**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans **in points** opgegeven. Voor voorspelbare resultaten baseert u uw berekeningen op de dia‑grootte en converteert u de benodigde millimeters of inches naar points voordat u waarden toewijst.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar voren te halen of naar achteren te sturen. Hierdoor kan de ellips andere objecten overlappen of die eronder onthullen.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Apply](/slides/nl/cpp/shape-animation/)‑invoeg‑, nadruk‑ of uitgangseffecten op de vorm, en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.