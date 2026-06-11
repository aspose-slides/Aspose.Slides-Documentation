---
title: Optimera diagramberäkningar för presentationer i Java
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/java/chart-calculations/
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
- Java
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för Java för PPT och PPTX, med praktiska Java‑kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Denna artikel visar hur du hämtar de faktiska värdena för diagramelement, inklusive den verkliga positionen och storleken på element som implementerar `IActualLayout` samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayouten.

Dessutom visar artikeln hur du får den faktiska positionen för överordnade diagramelement och hur du döljer diagramkomponenter som titel, axlar, förklaring och rutnätlinjer. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och kontrollera synligheten för diagramelement i PowerPoint-presentationer programmässigt.

## **Beräkna faktiska värden för diagramelement**
Aspose.Slides for Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i gränssnittet [IAxis](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis) ger information om den faktiska positionen för diagrammets axel ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Det är nödvändigt att först anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart#validateChartLayout--) för att fylla egenskaperna med faktiska värden.

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

## **Beräkna faktisk position för överordnade diagramelement**
Aspose.Slides for Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i gränssnittet [IActualLayout](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IActualLayout) ger information om den faktiska positionen för överordnade diagramelement ([IActualLayout.getActualX](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IActualLayout#getActualHeight--)). Det är nödvändigt att först anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart#validateChartLayout--) för att fylla egenskaperna med faktiska värden.

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

## **Dölj diagramelement**
Detta ämne hjälper dig att förstå hur du döljer information i ett diagram. Med Aspose.Slides for Java kan du dölja **Titel, Vertikal axel, Horisontell axel** och **Rutnätlinjer** i diagrammet. Nedanstående kodexempel visar hur du använder dessa egenskaper.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Döljer diagramtitel
    chart.setTitle(false);

    ///Döljer värdeaxel
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Synlighet för kategoriaxel
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Döljer förklaring
    chart.setLegend(false);

    //Döljer huvudrutnätslinjer
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

    //Ställer in serielinjens färg
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Fungerar externa Excel-arbetsböcker som datakälla, och hur påverkar det omräkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings- och redigeringsoperationer. API:et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlines](/slides/sv/java/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar omräknas automatiskt från seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.