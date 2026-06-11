---
title: Optimera diagramberäkningar för presentationer i JavaScript
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/nodejs-java/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underordnat element
- överordnat element
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för Node.js för PPT och PPTX, med praktiska JavaScript-kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Denna artikel visar hur du hämtar de faktiska värdena för diagramelement, inklusive den faktiska positionen och storleken på element samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayout.

Dessutom demonstrerar artikeln hur du får den faktiska positionen för överordnade diagramelement och hur du döljer diagramkomponenter såsom titel, axlar, förklaring och rutnätslinjer. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och kontrollera synligheten för diagramelement i PowerPoint-presentationer programatiskt.

## **Beräkna faktiska värden för diagramelement**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaper i klassen [Axis](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis) ger information om den faktiska positionen för diagrammets axel ([Axis.getActualMaxValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). Det är nödvändigt att tidigare anropa metoden [Chart.validateChartLayout()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#validateChartLayout--) för att fylla egenskaperna med faktiska värden.

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

## **Beräkna faktisk position för överordnade diagramelement**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaper i klassen `ActualLayout` ger information om den faktiska positionen för överordnat diagramelement `ActualLayout.getActualX`, `ActualLayout.getActualY`, `ActualLayout.getActualWidth`, `ActualLayout.getActualHeight`. Det är nödvändigt att tidigare anropa metoden [Chart.validateChartLayout()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#validateChartLayout--) för att fylla egenskaperna med faktiska värden.

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

## **Dölj information från diagram**

Detta ämne hjälper dig att förstå hur du döljer information från diagram. Med Aspose.Slides for Node.js via Java kan du dölja **Titel, vertikal axel, horisontell axel** och **rutnätslinjer** från diagrammet. Nedanstående kodexempel visar hur du använder dessa egenskaper.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // Dölja diagramtitel
    chart.setTitle(false);
    // /Dölja värdeaxel
    chart.getAxes().getVerticalAxis().setVisible(false);
    // Synlighet för kategoriaxel
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // Dölja legend
    chart.setLegend(false);
    // Dölja huvudrutnätslinjer
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // Ställer in linjefärg för serie
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

**Fungerar externa Excel-arbetsböcker som datakälla, och hur påverkar det omräkningen?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings-/redigeringsoperationer. API:et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlines](/slides/sv/nodejs-java/trend-line/) (linjära, exponentiella med flera) läggs till och uppdateras av Aspose.Slides; deras parametrar beräknas om automatiskt utifrån seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.