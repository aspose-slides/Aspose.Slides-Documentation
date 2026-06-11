---
title: Anpassa diagrammens plotområden i presentationer i Python
linktitle: Plotområde
type: docs
url: /sv/python-net/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdesbredd
- plotområdeshöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Förbättra dina bildspelsvisualiseringar enkelt."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plotområdet genom att validera diagramlayouten och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur man konfigurerar plotområdets layoutläge när layouten ställs in manuellt, med `LayoutTargetType` för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för diagrammets plotområde**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för . 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Anropa metoden IChart.ValidateChartLayout() innan för att få de faktiska värdena.
1. Hämtar det faktiska X‑läget (vänster) för diagramobjektet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska toppen för diagramobjektet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska bredden för diagramobjektet.
1. Hämtar den faktiska höjden för diagramobjektet.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Spara presentation med diagram
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in layoutläge för diagrammets plotområde**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Egenskapen **LayoutTargetType** har lagts till i klasserna **ChartPlotArea** och **IChartPlotArea**. Om layouten för plotområdet definieras manuellt anger den här egenskapen om plotområdet ska läggas ut av sin insida (exkluderar axlar och axelrubriker) eller av sin utsida (inkluderar axlar och axelrubriker). Det finns två möjliga värden som definieras i enumen **LayoutTargetType**.

- **LayoutTargetType.Inner** – anger att plotområdets storlek ska bestämma storleken på plotområdet, utan att inkludera tick‑markeringar och axelrubriker.
- **LayoutTargetType.Outer** – anger att plotområdets storlek ska bestämma storleken på plotområdet, tick‑markeringar och axelrubriker.

Exempelkod ges nedan.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**I vilka enheter returneras actual_x, actual_y, actual_width och actual_height?**

I punkter; 1 tum = 72 punkter. Detta är Aspose.Slides koordinatenheter.

**Hur skiljer sig Plot Area från Chart Area när det gäller innehåll?**

Plot Area är det område där data ritas (serier, rutnät, trendlinjer osv.); Chart Area innefattar de omgivande elementen (titel, legend osv.). I 3D-diagram inkluderar Plot Area också väggarna/golvet och axlarna.

**Hur tolkas Plot Areas X, Y, Width och Height när layouten är manuell?**

De är bråk (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråk du anger används.

**Varför ändrades Plot Areas position efter att legend har lagts till/flyttats?**

Legenden sitter i diagramområdet utanför Plot Area men påverkar layouten och det tillgängliga utrymmet, så Plot Area kan förflyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint-diagram.)