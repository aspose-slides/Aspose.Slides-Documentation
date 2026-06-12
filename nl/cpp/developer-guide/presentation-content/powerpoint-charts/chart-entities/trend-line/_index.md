---
title: Trendlijnen toevoegen aan presentatiediagrammen in C++
linktitle: Trendlijn
type: docs
url: /nl/cpp/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-diagrammen met Aspose.Slides voor C++ — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynoom en machts.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnelement in te voegen, en bevat een korte FAQ over de waarden voor vooruit- en achterwaartse projectie van trendlijnen en of trendlijnen behouden blijven bij het exporteren naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Een trendlijn toevoegen**
Aspose.Slides for C++ biedt een eenvoudige API voor het beheren van verschillende diagramtrendlijnen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en een van de gewenste typen (in dit voorbeeld wordt ChartType.ClusteredColumn gebruikt).
4. Een exponentiële trendlijn toevoegen voor diagramreeks 1.
5. Een lineaire trendlijn toevoegen voor diagramreeks 1.
6. Een logaritmische trendlijn toevoegen voor diagramreeks 2.
7. Een trendlijn voor voortschrijdend gemiddelde toevoegen voor diagramreeks 2.
8. Een polynomiale trendlijn toevoegen voor diagramreeks 3.
9. Een machts‑trendlijn toevoegen voor diagramreeks 3.
10. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Een aangepaste lijn toevoegen**
Aspose.Slides for C++ biedt een eenvoudige API om aangepaste lijnen toe te voegen aan een diagram. Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de klasse Presentation
- Verkrijg de referentie van een dia via de Index
- Maak een nieuw diagram met behulp van de AddChart‑methode die beschikbaar is via het Shapes‑object
- Voeg een AutoShape van het type Lijn toe met behulp van de AddAutoShape‑methode die beschikbaar is via het Shapes‑object
- Stel de kleur van de lijnelementen in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die vooruit/achterwaarts geprojecteerd wordt: voor spreidings‑(XY‑)diagrammen — in eenheid van de assen; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/cpp/create-shape-thumbnails/).