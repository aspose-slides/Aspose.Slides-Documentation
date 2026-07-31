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

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen aan diagramreeksen toevoegt, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynoom en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over de projectiewaarden ‘forward’ en ‘backward’ van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**
Aspose.Slides for C++ provides a simple API for managing different chart Trend Lines:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType.ClusteredColumn gebruikt).
4. Voeg de exponentiële trendlijn toe voor diagramreeks 1.
5. Voeg een lineaire trendlijn toe voor diagramreeks 1.
6. Voeg een logaritmische trendlijn toe voor diagramreeks 2.
7. Voeg een voortschrijdend gemiddelde trendlijn toe voor diagramreeks 2.
8. Voeg een polynomiale trendlijn toe voor diagramreeks 3.
9. Voeg een machts trendlijn toe voor diagramreeks 3.
10. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

The following code is used to create a chart with Trend Lines.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Aangepaste lijn toevoegen**
Aspose.Slides for C++ provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Maak een instantie van de Presentation‑klasse
- Verkrijg de verwijzing naar een dia via de Index
- Maak een nieuw diagram met de AddChart‑methode van het Shapes‑object
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode van het Shapes‑object
- Stel de kleur van de vormlijnen in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/achteren wordt geprojecteerd: voor spreidings‑(XY‑)diagrammen in as‑eenheden; voor niet‑spreidings‑diagrammen in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om [een afbeelding van het diagram](/slides/nl/cpp/create-shape-thumbnails/) zelf te exporteren.