---
title: Optimera diagramberäkningar för presentationer på Android
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/androidjava/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underordnat element
- föräldraelement
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för Android för PPT och PPTX, med praktiska Java‑kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Den här artikeln visar hur man hämtar de faktiska värdena för diagramelement, inklusive den verkliga positionen och storleken på element som implementerar `IActualLayout` samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayout.

Dessutom visar artikeln hur man får den faktiska positionen för föräldra‑diagramelement och hur man döljer diagramkomponenter såsom titel, axlar, legend och rutnät. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och programatiskt kontrollera synligheten för diagramelement i PowerPoint‑presentationer.

## **Beräkna faktiska värden för diagramelement**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i gränssnittet [IAxis](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis) ger information om den faktiska positionen för diagramaxelns element ([IAxis.getActualMaxValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)). Det är nödvändigt att anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#validateChartLayout--) i förväg för att fylla egenskaperna med faktiska värden.

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

## **Beräkna faktisk position för föräldra‑diagramelement**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i gränssnittet [IActualLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IActualLayout) ger information om den faktiska positionen för föräldra‑diagramelementet ([IActualLayout.getActualX](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). Det är nödvändigt att anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#validateChartLayout--) i förväg för att fylla egenskaperna med faktiska värden.

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
Detta ämne hjälper dig att förstå hur du döljer information i ett diagram. Med Aspose.Slides för Android via Java kan du dölja **Titel, Vertikal axel, Horisontell axel** och **Rutnät** i diagrammet. Koden nedan visar hur du använder dessa egenskaper.

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Döljer diagramtitel
    chart.setTitle(false);

    ///Döljer värdeaxel
    chart.getAxes().getVerticalAxis().setVisible(false);

    //Kategorisk axel synlighet
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //Döljer legend
    chart.setLegend(false);

    //Döljer stora rutnätlinjer
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

**Fungerar externa Excel‑arbetsböcker som datakälla, och hur påverkar det omberäkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet reflekterar uppdateringarna under öppnings‑/redigeringsoperationer. API:et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) sökväg och hantera de länkade data.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlines](/slides/sv/androidjava/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar beräknas om automatiskt från seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag kontrollera vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.