---
title: Anpassa plotområden för presentationsdiagram i C++
linktitle: Plotområde
type: docs
url: /sv/cpp/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdesbredd
- plotområdeshöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för C++. Förbättra dina bilders visuella utseende enkelt."
---
## **Översikt**

Den här artikeln visar hur du arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur du får den faktiska positionen och storleken på plotområdet genom att validera diagramlayouten och sedan läsa dess X-, Y-, bredd- och höjdförhållanden.

Den visar också hur du konfigurerar plotområdets layoutläge när layouten anges manuellt, med hjälp av `LayoutTargetType` för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för ett diagrammets plotområde**
Aspose.Slides för C++ tillhandahåller ett enkelt API för .

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Anropa metoden IChart::ValidateChartLayout() innan för att få faktiska värden.
1. Hämtar den faktiska X‑positionen (vänster) för diagrammetlementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska toppen för diagrammetlementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska bredden på diagrammetlementet.
1. Hämtar den faktiska höjden på diagrammetlementet.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Spara presentationen med diagram
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Ställ in layoutläge för ett diagrammets plotområde**
Aspose.Slides för C++ tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Egenskapen **LayoutTargetType** har lagts till i klasserna **ChartPlotArea** och **IChartPlotArea**. Om layouten för plotområdet definieras manuellt anger denna egenskap om plotområdet ska läggas ut av dess inre del (utan axlar och axelrubriker) eller av dess yttre del (inklusive axlar och axelrubriker). Det finns två möjliga värden som definieras i enumen **LayoutTargetType**.

- **LayoutTargetType.Inner** – anger att plotområdets storlek bestämmer storleken på plotområdet, utan att inkludera tickmarkeringar och axelrubriker.
- **LayoutTargetType.Outer** – anger att plotområdets storlek bestämmer storleken på plotområdet, tickmarkeringarna och axelrubrikerna.

Exempelkod ges nedan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **Vanliga frågor**

**I vilka enheter returneras ActualX, ActualY, ActualWidth och ActualHeight?**

I punkter; 1 tum = 72 punkter. Detta är Aspose.Slides koordinatenheter.

**Hur skiljer sig Plot Area från Chart Area när det gäller innehåll?**

Plot Area är det område där data ritas (serier, rutnätslinjer, trendlinjer osv.); Chart Area inkluderar de omgivande elementen (titel, legend osv.). I 3D‑diagram inkluderar Plot Area även väggar/golv och axlarna.

**Hur tolkas Plot Area:s X, Y, Width och Height när layouten är manuell?**

De är bråktal (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråktal du anger används.

**Varför ändrades Plot Area:s position efter att legend har lagts till/flyttats?**

Legenden placerar sig i diagramområdet utanför Plot Area men påverkar layouten och tillgängligt utrymme, så Plot Area kan förskjutas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint‑diagram.)