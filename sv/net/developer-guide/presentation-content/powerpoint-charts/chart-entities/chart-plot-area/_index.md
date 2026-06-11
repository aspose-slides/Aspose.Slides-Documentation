---
title: Anpassa plotområden i presentationsdiagram i .NET
linktitle: Plotområde
type: docs
url: /sv/net/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområde bredd
- plotområde höjd
- plotområde storlek
- layoutläge
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för .NET. Förbättra dina bildvisualiseringar utan ansträngning."
---
## **Overview**

Den här artikeln visar hur du arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur du får den faktiska positionen och storleken på plotområdet genom att validera diagrammets layout och sedan läsa av dess X-, Y-, bredd- och höjd‑värden.

Den demonstrerar också hur du konfigurerar plotområdets layoutläge när layouten anges manuellt, med hjälp av `LayoutTargetType` för att definiera om plotområdet beräknas av sitt inre område eller av sitt yttre område tillsammans med axlar och axelrubriker.

## **Get Width and Height of a Chart Plot Area**
Aspose.Slides för .NET tillhandahåller ett enkelt API för .

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassen.
1. Åtkomst till första bilden.
1. Lägg till ett diagram med standarddata.
1. Anropa metoden IChart.ValidateChartLayout() innan du hämtar faktiska värden.
1. Hämtar den faktiska X‑platsen (vänster) för diagramelementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska toppen för diagramelementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska bredden på diagramelementet.
1. Hämtar den faktiska höjden på diagramelementet.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Spara presentation med diagram
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Set the Layout Mode of a Chart Plot Area**
Aspose.Slides för .NET tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Egenskapen **LayoutTargetType** har lagts till i klasserna **ChartPlotArea** och **IChartPlotArea**. Om layouten för plotområdet definieras manuellt anger den här egenskapen om plotområdet ska läggas ut av sin inre del (utan axlar och axelrubriker) eller av sin yttre del (inklusive axlar och axelrubriker). Det finns två möjliga värden som definieras i enum‑en **LayoutTargetType**.

- **LayoutTargetType.Inner** – anger att plotområdets storlek bestämmer storleken på plotområdet, utan att inkludera tick‑markeringar och axelrubriker.
- **LayoutTargetType.Outer** – anger att plotområdets storlek bestämmer storleken på plotområdet, tick‑markeringarna och axelrubrikerna.

Exempelkod finns nedan.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**I vilka enheter returneras ActualX, ActualY, ActualWidth och ActualHeight?**

I punkter; 1 tum = 72 punkter. Detta är koordinatenheter för Aspose.Slides.

**Hur skiljer sig Plot Area från Chart Area när det gäller innehåll?**

Plot Area är det område där data ritas (serier, rutnät, trendlinjer osv.); Chart Area omfattar de omgivande elementen (titel, legend osv.). I 3D‑diagram inkluderar Plot Area även väggar/golv och axlarna.

**Hur tolkas Plot Areas X, Y, Width och Height när layouten är manuell?**

De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades Plot Areas position efter att legend har lagts till eller flyttats?**

Legenden placeras i diagramområdet utanför Plot Area men påverkar layouten och det tillgängliga utrymmet, så Plot Area kan förskjutas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint‑diagram.)