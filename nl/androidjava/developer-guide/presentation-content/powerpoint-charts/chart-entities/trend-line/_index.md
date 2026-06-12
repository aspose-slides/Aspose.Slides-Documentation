---
title: Voeg trendlijnen toe aan presentatiediagrammen op Android
linktitle: Trendlijn
type: docs
url: /nl/androidjava/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- macht trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg snel trendlijnen toe aan en pas ze aan in PowerPoint-diagrammen met Aspose.Slides voor Android via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met Aspose.Slides. Het toont hoe u een diagram maakt, trendlijnen aan diagramreeksen toevoegt, en werkt met verschillende soorten trendlijnen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnelement in te voegen, en bevat een korte FAQ over vooruit- en terugwerkende projectiewaarden van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**
Aspose.Slides for Android via Java biedt een eenvoudige API voor het beheren van verschillende diagram‑Trend Lines:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType.ClusteredColumn gebruikt).
1. Exponentiële trendlijn toevoegen voor diagramreeks 1.
1. Lineaire trendlijn toevoegen voor diagramreeks 1.
1. Logaritmische trendlijn toevoegen voor diagramreeks 2.
1. Voortschrijdend‑gemiddelde trendlijn toevoegen voor diagramreeks 2.
1. Polynomiale trendlijn toevoegen voor diagramreeks 3.
1. Macht‑trendlijn toevoegen voor diagramreeks 3.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

De volgende code wordt gebruikt om een diagram met trendlijnen te maken.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Maak een gegroepeerde kolomdiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Toevoegen exponentiële trendlijn voor diagramreeks 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Toevoegen lineaire trendlijn voor diagramreeks 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Toevoegen logaritmische trendlijn voor diagramreeks 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Toevoegen voortschrijdend gemiddelde trendlijn voor diagramreeks 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Toevoegen polynomiale trendlijn voor diagramreeks 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Toevoegen machttrendlijn voor diagramreeks 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Presentatie opslaan
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aangepaste lijn toevoegen**
Aspose.Slides for Android via Java biedt een eenvoudige API om aangepaste lijnen in een diagram toe te voegen. Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volg de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse
- Verkrijg de referentie van een dia via de index
- Maak een nieuw diagram met de AddChart‑methode van het Shapes‑object
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode van het Shapes‑object
- Stel de kleur van de vormlijnen in.
- Schrijf de aangepaste presentatie naar een PPTX‑bestand

De volgende code wordt gebruikt om een diagram met aangepaste lijnen te maken.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Dit zijn de lengtes van de trendlijn die respectievelijk vooruit‑ en terugwerkend worden geprojecteerd: voor spreidings‑ (XY‑) diagrammen in eenheid van de assen; voor niet‑spreidings‑ diagrammen in het aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides zet presentaties om naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/androidjava/create-shape-thumbnails/).