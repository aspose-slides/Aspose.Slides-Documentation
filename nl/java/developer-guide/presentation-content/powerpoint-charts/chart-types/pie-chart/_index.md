---
title: Pas taartdiagrammen aan in presentaties met Java
linktitle: Taartdiagram
type: docs
url: /nl/java/pie-chart/
keywords:
- taartdiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u taartdiagrammen maakt en aanpast in Java met Aspose.Slides, exporteerbaar naar PowerPoint, waardoor u uw gegevensverhaal in enkele seconden versterkt."
---
## **Overzicht**

Dit artikel legt uit hoe u met taartdiagrammen werkt in Aspose.Slides. Het toont hoe u secundaire plotopties configureert voor Pie of Pie- en Bar of Pie-diagrammen, en hoe u automatische kleuring van segmenten inschakelt voor een standaard taartdiagram.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van reeksen en labelinstellingen, het vervangen van standaarddiagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Tweede plotopties voor Pie of Pie en Bar of Pie diagrammen**
Aspose.Slides for Java ondersteunt nu tweede plotopties voor Pie of Pie- of Bar of Pie-diagrammen. In dit onderwerp laten we zien hoe u die opties specificeert met Aspose.Slides. Om de eigenschappen te specificeren, doet u het volgende:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse‑object aan.
1. Voeg een diagram toe op de dia.
1. Specificeer de tweede plotopties van het diagram.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van het Pie of Pie-diagram ingesteld.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Voeg diagram toe op dia
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Stel verschillende eigenschappen in
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Schrijf presentatie naar schijf
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Automatische taartdiagramsegmentkleuren instellen**
Aspose.Slides for Java biedt een eenvoudige API voor het instellen van automatische kleuren voor taartdiagramsegmenten. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de titel van het diagram in.
1. Stel de eerste reeks in op Show Values.
1. Stel de index van het diagramgegevensblad in.
1. Verkrijg het werkblad met diagramgegevens.
1. Verwijder de standaard gegenereerde reeksen en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg een nieuwe reeks toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Voeg diagram toe met standaardgegevens
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Instellen van diagramtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Stel eerste reeks in om waarden te tonen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Instellen van de index van het diagramdatablad
    int defaultWorksheetIndex = 0;

    // Het ophalen van het diagramdatablad
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Verwijder standaard gegenereerde reeksen en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Nieuwe categorieën toevoegen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Nieuwe reeks toevoegen
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Nu wordt de reeksen data gevuld
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veelgestelde vragen**

**Worden de 'Pie of Pie'- en 'Bar of Pie'-varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/) een secundaire plot voor taartdiagrammen, inclusief de 'Pie of Pie'‑ en 'Bar of Pie'‑typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf exporteren als afbeelding](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) (bijvoorbeeld PNG) zonder de volledige presentatie.