---
title: Anpassa diagrammens plotområden i C++
linktitle: Plotområde
type: docs
url: /sv/cpp/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdets bredd
- plotområdets höjd
- plotområdets storlek
- layoutläge
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för C++. Förbättra dina bilders visuella intryck utan ansträngning."
---
## **Översikt**

Denna artikel visar hur man arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plotområdet genom att validera diagrammets layout och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur man konfigurerar plotområdets layoutläge när layouten är inställd manuellt, genom att använda `LayoutTargetType` för att ange om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för ett diagramplotområde**
Aspose.Slides för C++ tillhandahåller ett enkelt API för . 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
2. Åtkomst till den första bilden.
3. Lägg till ett diagram med standarddata.
4. Anropa metoden IChart::ValidateChartLayout() innan för att få de faktiska värdena.
5. Hämtar den faktiska X-positionen (vänster) för diagramobjektet relativt diagrammets vänstra övre hörn.
6. Hämtar den faktiska överkanten för diagramobjektet relativt diagrammets vänstra övre hörn.
7. Hämtar den faktiska bredden på diagramobjektet.
8. Hämtar den faktiska höjden på diagramobjektet.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Spara presentationen med diagrammet
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **Ställ in layoutläget för ett diagramplotområde**
Aspose.Slides för C++ tillhandahåller ett enkelt API för att ange layoutläget för diagrammets plotområde. Egenskapen **LayoutTargetType** har lagts till i klasserna **ChartPlotArea** och **IChartPlotArea**. Om layouten för plotområdet definieras manuellt anger denna egenskap om plotområdet ska läggas ut efter dess insida (utan axlar och axelrubriker) eller utanför (med axlar och axelrubriker). Det finns två möjliga värden som definieras i enum‑typen **LayoutTargetType**.

- **LayoutTargetType.Inner** - anger att plotområdets storlek ska bestämma storleken på plotområdet, utan tick‑markeringar och axelrubriker.
- **LayoutTargetType.Outer** - anger att plotområdets storlek ska bestämma storleken på plotområdet, tick‑markeringarna och axelrubrikerna.

Exempelkod ges nedan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **FAQ**

**I vilka enheter returneras ActualX, ActualY, ActualWidth och ActualHeight?**

I punkter; 1 tum = 72 punkter. Detta är koordinatenheter för Aspose.Slides.

**Hur skiljer sig Plot Area från Chart Area när det gäller innehåll?**

Plot Area är det område där data ritas (serier, rutnät, trendlinjer osv.); Chart Area inkluderar de omgivande elementen (titel, legend osv.). I 3D‑diagram inkluderar Plot Area också väggar/golv och axlarna.

**Hur tolkas Plot Area:s X, Y, Width och Height när layouten är manuell?**

De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades Plot Area:s position efter att legenden lades till/fördes?**

Legenden placeras i diagramområdet utanför Plot Area men påverkar layouten och det tillgängliga utrymmet, så Plot Area kan flyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint‑diagram.)