---
title: "Grafiekberekeningen optimaliseren voor presentaties op Android"
linktitle: "Grafiekberekeningen"
type: docs
weight: 50
url: /nl/androidjava/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- werkelijke positie
- onderliggend element
- bovenliggend element
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiebeheersing in Aspose.Slides voor Android voor PPT en PPTX, met praktische Java-codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API’s voor het werken met grafiekberekeningen en lay‑outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafiekelementen kunt ophalen, inclusief de feitelijke positie en grootte van elementen die `IActualLayout` implementeren en de werkelijke waarden van de assen van de grafiek. Het legt ook uit dat deze waarden worden ingevuld na de validatie van de grafieklay‑out.

Daarnaast toont het artikel hoe u de feitelijke positie van bovenliggende grafiekelementen kunt achterhalen en hoe u grafiekonderdelen zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om informatie over de grafieklay‑out te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmatisch te beheren.

## **Bereken werkelijke waarden van grafiekelementen**
Aspose.Slides voor Android via Java biedt een eenvoudige API om deze eigenschappen op te halen. De eigenschappen van de interface [IAxis](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis) geven informatie over de werkelijke positie van een as‑grafiekelement ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Het is noodzakelijk om eerder de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#validateChartLayout--) aan te roepen om de eigenschappen met werkelijke waarden te vullen.

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

## **Bereken feitelijke positie van bovenliggende grafiekelementen**
Aspose.Slides voor Android via Java biedt een eenvoudige API om deze eigenschappen op te halen. De eigenschappen van de interface [IActualLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IActualLayout) geven informatie over de feitelijke positie van een bovenliggend grafiekelement ([IActualLayout.getActualX](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Het is noodzakelijk om eerder de methode [IChart.validateChartLayout()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#validateChartLayout--) aan te roepen om de eigenschappen met werkelijke waarden te vullen.

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
Dit onderwerp helpt u te begrijpen hoe u informatie in een grafiek kunt verbergen. Met Aspose.Slides voor Android via Java kunt u **Titel, verticale as, horizontale as** en **rasterlijnen** uit een grafiek verbergen. Het onderstaande code‑voorbeeld laat zien hoe u deze eigenschappen gebruikt.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Verbergen van grafiektitel
    chart.setTitle(false);

    ///Verbergen van waardenas
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Zichtbaarheid van categorie-as
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Verbergen van legende
    chart.setLegend(false);

    //Verbergen van hoofdroosterlijnen
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

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Werken externe Excel‑werkboeken als gegevensbron, en hoe beïnvloedt dat de herberekening?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron verbindt of ververst, worden formules en waarden uit dat werkboek gehaald, en de grafiek geeft de updates weer tijdens open‑/bewerk‑bewerkingen. Met de API kunt u het pad van het [externe werkboek](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) opgeven en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlijnen](/slides/nl/androidjava/trend-line/) (lineair, exponentieel en andere) worden door Aspose.Slides toegevoegd en bijgewerkt; hun parameters worden automatisch herberekend op basis van de seriedata, dus u hoeft geen eigen berekeningen te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar een eigen [extern werkboek](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) verwijzen, of u kunt per grafiek een extern werkboek aanmaken/vervangen, onafhankelijk van de anderen.