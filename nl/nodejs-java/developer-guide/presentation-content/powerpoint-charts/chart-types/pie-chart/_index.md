---
title: "Pas cirkeldiagrammen aan in presentaties met JavaScript"
linktitle: "Cirkeldiagram"
type: docs
url: /nl/nodejs-java/pie-chart/
keywords:
- "cirkeldiagram"
- "diagram beheren"
- "diagram aanpassen"
- "diagramopties"
- "diagraminstellingen"
- "plotopties"
- "segmentkleur"
- "PowerPoint"
- "presentatie"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Leer hoe je cirkeldiagrammen kunt maken en aanpassen in JavaScript met Aspose.Slides voor Node.js, exporteerbaar naar PowerPoint, en zo je dataverhaal in enkele seconden verbetert."
---
## **Overzicht**

Dit artikel legt uit hoe je met cirkeldiagrammen werkt in Aspose.Slides. Het laat zien hoe je secundaire plotopties configureert voor Pie of Pie- en Bar of Pie-diagrammen, en hoe je automatische kleurtoekenning van segmenten inschakelt voor een standaard cirkeldiagram.

De voorbeelden richten zich op praktische stappen voor diagramaanpassing, zoals een diagram toevoegen aan een dia, instellingen voor series en labels aanpassen, standaarddiagramgegevens vervangen door aangepaste categorieën en waarden, en de bijgewerkte presentatie opslaan.

## **Secundaire plotopties voor Pie of Pie- en Bar of Pie-diagram**

Aspose.Slides for Node.js via Java ondersteunt nu secundaire plotopties voor Pie of Pie‑ of Bar of Pie‑diagrammen. In dit onderwerp laten we zien hoe je die opties specificeert met Aspose.Slides. Om de eigenschappen te specificeren, doe je het volgende:

1. Instantiseer een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasseobject.  
1. Voeg een diagram toe aan de dia.  
1. Specificeer de secundaire plotopties van het diagram.  
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie‑diagram ingesteld.

```javascript
// Maak een instantie van de Presentation‑klasse
var pres = new aspose.slides.Presentation();
try {
    // Voeg een diagram toe aan de dia
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Stel verschillende eigenschappen in
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Schrijf de presentatie naar schijf
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Stel automatische kleuren voor cirkeldiagramsegmenten in**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het instellen van automatische kleuren voor cirkeldiagramsegmenten. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.  
1. Verkrijg de eerste dia.  
1. Voeg een diagram toe met standaardgegevens.  
1. Stel de diagramtitel in.  
1. Stel de eerste serie in op Waarden weergeven.  
1. Stel de index van het diagramdatavelder in.  
1. Verkrijg het werkblad met diagramgegevens.  
1. Verwijder de standaard gegenereerde series en categorieën.  
1. Voeg nieuwe categorieën toe.  
1. Voeg nieuwe series toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Voeg een diagram toe met standaardgegevens
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Instellen van de diagramtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Stel de eerste serie in op Waarden weergeven
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Instellen van de index van het diagramdatavelder
    var defaultWorksheetIndex = 0;
    // Het diagramdatavelder ophalen
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijder standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Nieuwe categorieën toevoegen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Nieuwe series toevoegen
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Series nu vullen met gegevens
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Worden de varianten 'Pie of Pie' en 'Bar of Pie' ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de typen 'Pie of Pie' en 'Bar of Pie'.

**Kan ik alleen het diagram exporteren als een afbeelding (bijvoorbeeld PNG)?**

Ja, je kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de hele presentatie.