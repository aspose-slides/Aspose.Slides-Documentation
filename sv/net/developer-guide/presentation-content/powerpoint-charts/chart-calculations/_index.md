---
title: Optimera diagramberäkningar för presentationer i .NET
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/net/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underelement
- överordnat element
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionskontroll i Aspose.Slides för .NET för PPT och PPTX, med praktiska C#‑kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Denna artikel visar hur man hämtar de faktiska värdena för diagramelement, inklusive den verkliga positionen och storleken på element som implementerar `IActualLayout` samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayout.

Dessutom demonstrerar artikeln hur man får den faktiska positionen för överordnade diagramelement och hur man döljer diagramkomponenter såsom titel, axlar, legend och rutnät. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och styra synligheten för diagramelement i PowerPoint-presentationer programmässigt.

## **Beräkna faktiska värden för diagramelement**
Aspose.Slides för .NET tillhandahåller ett enkelt API för att hämta dessa egenskaper. Detta hjälper dig att beräkna de faktiska värdena för diagramelement. De faktiska värdena inkluderar positionen för element som implementerar IActualLayout‑gränssnittet (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) samt de faktiska axelvärdena (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Sparar presentation
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Beräkna faktisk position för överordnade diagramelement**
Aspose.Slides för .NET tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i IActualLayout ger information om den faktiska positionen för det överordnade diagramelementet. Det är nödvändigt att tidigare anropa metoden IChart.ValidateChartLayout() för att fylla egenskaperna med faktiska värden.

```c#
// Skapar tom presentation
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Dölj diagramelement**
Det här ämnet hjälper dig att förstå hur du döljer information i ett diagram. Med Aspose.Slides för .NET kan du dölja **Titel, Vertikal axel, Horisontell axel** och **Rutlinjer** i diagrammet. Nedanstående kodexempel visar hur du använder dessa egenskaper.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Döljer diagramtitel
    chart.HasTitle = false;

    ///Döljer värdeaxel
    chart.Axes.VerticalAxis.IsVisible = false;

    //Kategoripaxelns synlighet
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Döljer legend
    chart.HasLegend = false;

    //Döljer huvudrutnät
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Ställer in färg för serielinje
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Fungerar externa Excel-arbetsböcker som datakälla, och hur påverkar det omberäkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan tas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings-/redigeringsoperationer. API‑et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/setexternalworkbook/) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlinjer](/slides/sv/net/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar beräknas om från seriedatan automatiskt, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/setexternalworkbook/), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.