---
title: Trendlijnen toevoegen aan presentatiediagrammen in JavaScript
linktitle: Trendlijn
type: docs
url: /nl/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-diagrammen met JavaScript en Aspose.Slides voor Node.js via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen aan presentatiediagrammen kunt toevoegen met Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen en werkt met verschillende typen trendlijnen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over de betekenis van 'forward' en 'backward' voor een trendlijn, en of trendlijnen behouden blijven bij export naar PDF of SVG en wanneer diagrammen als afbeeldingen worden gerenderd.

## **Trendlijn toevoegen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het beheren van verschillende diagram‑trendlijnen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType.ClusteredColumn gebruikt).
1. Exponentiële trendlijn toevoegen voor diagramreeks 1.
1. Lineaire trendlijn toevoegen voor diagramreeks 1.
1. Logaritmische trendlijn toevoegen voor diagramreeks 2.
1. Voortschrijdend‑gemiddelde trendlijn toevoegen voor diagramreeks 2.
1. Polynomiale trendlijn toevoegen voor diagramreeks 3.
1. Machtig‑trendlijn toevoegen voor diagramreeks 3.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De volgende code wordt gebruikt om een diagram met trendlijnen te maken.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Een gegroepeerde kolomdiagram maken
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Exponentiële trendlijn toevoegen voor diagramreeks 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Lineaire trendlijn toevoegen voor diagramreeks 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Logaritmische trendlijn toevoegen voor diagramreeks 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Voortschrijdend gemiddelde trendlijn toevoegen voor diagramreeks 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Polynomiale trendlijn toevoegen voor diagramreeks 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Machts trendlijn toevoegen voor diagramreeks 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Presentatie opslaan
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aangepaste lijn toevoegen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API om aangepaste lijnen aan een diagram toe te voegen. Volg de onderstaande stappen om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse
- Verkrijg de referentie van een dia door de Index te gebruiken
- Maak een nieuw diagram met de AddChart‑methode van het Shapes‑object
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode van het Shapes‑object
- Stel de kleur van de vormlijnen in.
- Schrijf de gewijzigde presentatie als een PPTX‑bestand

De volgende code wordt gebruikt om een diagram met aangepaste lijnen te maken.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/achteruit worden geprojecteerd: voor spreidings‑(XY‑)diagrammen — in eenheid van de assen; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/nodejs-java/create-shape-thumbnails/).