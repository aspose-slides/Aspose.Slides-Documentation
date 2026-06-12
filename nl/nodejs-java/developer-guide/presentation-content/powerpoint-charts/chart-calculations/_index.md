---
title: Optimaliseer grafiekberekeningen voor presentaties in JavaScript
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/nodejs-java/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- werkelijke positie
- kindelement
- bovenelement
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiecontrole in Aspose.Slides voor Node.js voor PPT en PPTX, met praktische JavaScript codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en lay-outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafiekelementen kunt opvragen, inclusief de daadwerkelijke positie en grootte van elementen en de werkelijke waarden van grafiekassen. Het legt ook uit dat deze waarden worden ingevuld na de validatie van de grafieklay-out.

Daarnaast toont het artikel hoe u de daadwerkelijke positie van bovenliggende grafiekelementen kunt verkrijgen en hoe u grafiekcomponenten zoals de titel, assen, legende en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om de lay-outinformatie van grafieken te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmatisch te beheersen.

## **Werkelijke waarden van grafiekelementen berekenen**

Aspose.Slides voor Node.js via Java biedt een eenvoudige API om deze eigenschappen op te halen. De eigenschappen van de [Axis](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis)‑klasse geven informatie over de werkelijke positie van een as‑grafiekelement ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Het is noodzakelijk om vooraf de methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#validateChartLayout--) aan te roepen zodat de eigenschappen worden gevuld met de werkelijke waarden.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Werkelijke positie van bovenliggende grafiekelementen berekenen**

Aspose.Slides voor Node.js via Java biedt een eenvoudige API om deze eigenschappen op te halen. De eigenschappen van de `ActualLayout`‑klasse geven informatie over de werkelijke positie van het bovenliggende grafiekelement `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Het is noodzakelijk om vooraf de methode [Chart.validateChartLayout()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#validateChartLayout--) aan te roepen zodat de eigenschappen worden gevuld met de werkelijke waarden.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Informatie uit grafiek verbergen**

Dit onderwerp helpt u te begrijpen hoe u informatie uit een grafiek kunt verbergen. Met Aspose.Slides voor Node.js via Java kunt u **Titel, verticale as, horizontale as** en **rasterlijnen** uit een grafiek verbergen. De onderstaande code‑voorbeeld toont hoe u deze eigenschappen kunt gebruiken.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Grafiektitel verbergen
    chart.setTitle(false);
    // /Waardenas verbergen
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Zichtbaarheid van categorieas
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Legenda verbergen
    chart.setLegend(false);
    // Hoofdrasterlijnen verbergen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Kleur van serielijn instellen
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Werken externe Excel-werkboeken als gegevensbron en hoe beïnvloedt dat de herberekening?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron verbindt of ververst, worden formules en waarden uit dat werkboek gehaald, en de grafiek reflecteert de updates tijdens openen/bewerken. Met de API kunt u het pad van het [externe werkboek](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) opgeven en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlines](/slides/nl/nodejs-java/trend-line/) (lineair, exponentieel en andere) worden toegevoegd en bijgewerkt door Aspose.Slides; hun parameters worden automatisch opnieuw berekend op basis van de seriedata, zodat u geen eigen berekeningen hoeft te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar zijn eigen [externe werkboek](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) wijzen, of u kunt per grafiek een extern werkboek aanmaken/vervangen, onafhankelijk van de andere grafieken.