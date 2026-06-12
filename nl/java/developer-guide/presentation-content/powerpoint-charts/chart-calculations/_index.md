---
title: Optimaliseer grafiekberekeningen voor presentaties in Java
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/java/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- feitelijke positie
- kindelement
- ouder element
- grafiekwaarden
- feitelijke waarde
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiebereik in Aspose.Slides for Java voor PPT en PPTX, met praktische Java‑codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en lay-outgegevens in presentaties. Dit artikel laat zien hoe u de feitelijke waarden van grafiekelementen kunt ophalen, inclusief de werkelijke positie en grootte van elementen die `IActualLayout` implementeren en de feitelijke waarden van grafiekassen. Het legt ook uit dat deze waarden pas worden ingevuld nadat de grafieklay-out is gevalideerd.

Daarnaast laat het artikel zien hoe u de feitelijke positie van bovenliggende grafiekelementen kunt verkrijgen en hoe u grafiekonderdelen zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om grafieklay-outinformatie te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmatisch te regelen.

## **Feitelijke waarden van grafiekelementen berekenen**
Aspose.Slides for Java biedt een eenvoudige API om deze eigenschappen op te vragen. Eigenschappen van de [IAxis](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis)‑interface geven informatie over de feitelijke positie van een grafiekas‑element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Het is noodzakelijk om eerst de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart#validateChartLayout--) aan te roepen zodat de eigenschappen met feitelijke waarden worden gevuld.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Feitelijke positie van bovenliggende grafiekelementen berekenen**
Aspose.Slides for Java biedt een eenvoudige API om deze eigenschappen op te vragen. Eigenschappen van de [IActualLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IActualLayout)‑interface geven informatie over de feitelijke positie van een bovenliggend grafiekelement ([IActualLayout.getActualX](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IActualLayout#getActualHeight--)). Het is noodzakelijk om eerst de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart#validateChartLayout--) aan te roepen zodat de eigenschappen met feitelijke waarden worden gevuld.

```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafiekelementen verbergen**
Dit onderwerp helpt u te begrijpen hoe u informatie in een grafiek kunt verbergen. Met Aspose.Slides for Java kunt u **Titel, Verticale as, Horizontale as** en **Rasterlijnen** in de grafiek verbergen. De onderstaande code‑voorbeeld laat zien hoe u deze eigenschappen gebruikt.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Verbergen van grafiektitel
    chart.setTitle(false);

    ///Waardenas verbergen
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Categorie-as zichtbaarheid
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Legenda verbergen
    chart.setLegend(false);

    //Hoofd rasterlijnen verbergen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Instellen lijnkleur van serie
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Werkt een extern Excel‑werkblad als gegevensbron, en hoe beïnvloedt dat herberekening?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron verbindt of ververst, worden formules en waarden uit dat werkboek gehaald, en de grafiek geeft de updates weer tijdens openen/bewerken. De API laat u het pad van het [externe werkboek](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) specificeren en beheert de gekoppelde gegevens.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlines](/slides/nl/java/trend-line/) (lineair, exponentieel en andere) worden door Aspose.Slides toegevoegd en geüpdatet; hun parameters worden automatisch opnieuw berekend op basis van de seriedata, zodat u geen eigen berekeningen hoeft te maken.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan wijzen naar zijn eigen [externe werkboek](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), of u kunt per grafiek onafhankelijk een extern werkboek aanmaken/vervangen.