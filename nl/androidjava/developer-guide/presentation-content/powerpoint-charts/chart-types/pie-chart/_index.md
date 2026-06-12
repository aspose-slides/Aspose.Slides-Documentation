---
title: Aanpassen van taartdiagrammen in presentaties op Android
linktitle: Taartdiagram
type: docs
url: /nl/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u taartdiagrammen kunt maken en aanpassen in Java met Aspose.Slides voor Android, exporteerbaar naar PowerPoint, waardoor u in enkele seconden uw dataverhaal kunt versterken."
---
## **Overzicht**

Dit artikel legt uit hoe u met taartdiagrammen in Aspose.Slides werkt. Het laat zien hoe u secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen configureert en hoe u automatische segmentkleuring voor een standaard taartdiagram inschakelt.

De voorbeelden richten zich op praktische stappen voor diagramaanpassing, zoals het toevoegen van een diagram aan een dia, het aanpassen van serie‑ en labelinstellingen, het vervangen van standaarddiagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Tweede plotopties voor Pie of Pie- en Bar of Pie-diagrammen**
Aspose.Slides voor Android via Java ondersteunt nu tweede plotopties voor Pie of Pie‑ of Bar of Pie‑diagrammen. In dit onderwerp laten we u zien hoe u die opties specificeert met Aspose.Slides. Om de eigenschappen te specificeren, doet u het volgende:

1. Instantieer het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse‑object.
1. Voeg een diagram toe aan de dia.
1. Geef de tweede plotopties van het diagram op.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie‑diagram ingesteld.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Voeg een diagram toe aan de dia
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Stel verschillende eigenschappen in
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Schrijf de presentatie naar schijf
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Stel automatische kleuren voor taartdiagramsegmenten in**
Aspose.Slides voor Android via Java biedt een eenvoudige API om automatische kleuren voor taartdiagramsegmenten in te stellen. De voorbeeldcode past de bovengenoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de titel van het diagram in.
1. Stel de eerste serie in om waarden weer te geven.
1. Stel de index van het diagramdatablad in.
1. Haal het werkblad met diagramgegevens op.
1. Verwijder de automatisch gegenereerde series en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg een nieuwe serie toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Voeg een diagram toe met standaardgegevens
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Instellen van diagramtitel
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Stel de eerste serie in om waarden weer te geven
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Instellen van de index van het diagramdatablad
    int defaultWorksheetIndex = 0;

    // Het diagramdatablad ophalen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Verwijder standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Nieuwe categorieën toevoegen
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Nieuwe serie toevoegen
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Nu de seriesgegevens vullen
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Worden de 'Pie of Pie' en 'Bar of Pie' varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/) een secundaire plot voor taartdiagrammen, inclusief de 'Pie of Pie' en 'Bar of Pie'-typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (bijvoorbeeld PNG) zonder de volledige presentatie.