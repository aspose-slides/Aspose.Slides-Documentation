---
title: Anpassa plotområden för presentationsdiagram i Python
linktitle: Plotområde
type: docs
url: /sv/python-java/chart-plot-area/
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
- Java
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för Python via Java. Förbättra dina bilders visuella utseende utan ansträngning."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett diagrammes plotområde i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plotområdet genom att validera diagrammets layout och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur man konfigurerar plotområdets layoutläge när layouten ställs in manuellt, med hjälp av LayoutTargetType för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för ett diagramplotsområde**

Aspose.Slides for Python via Java erbjuder ett enkelt API för att läsa den faktiska positionen och storleken på ett diagramplotsområde.

1. Skapa en instans av Presentation-klassen.
2. Få åtkomst till den första bilden.
3. Lägg till ett diagram med standarddata.
4. Anropa metoden Chart.validateChartLayout innan du hämtar de faktiska värdena.
5. Hämta den faktiska X-positionen (vänster) för diagrammetelementet relativt diagrammets övre vänstra hörn.
6. Hämta den faktiska Y-positionen (top) för diagrammetelementet relativt diagrammets övre vänstra hörn.
7. Hämta den faktiska bredden på diagrammetelementet.
8. Hämta den faktiska höjden på diagrammetelementet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Ställ in layoutläget för ett diagramplotsområde**

Aspose.Slides for Python via Java erbjuder ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Metoderna setLayoutTargetType och getLayoutTargetType finns i ChartPlotArea-klassen. Om layouten för plotområdet definieras manuellt anger denna inställning om plotområdet ska läggas ut av dess insida (exklusive axlar och axelrubriker) eller av dess utsida (inklusive axlar och axelrubriker). Det finns två möjliga värden definierade i LayoutTargetType‑enumerationen.

- [Inner](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layouttargettype/#Inner) anger att plotområdets storlek exkluderar tick marks och axelrubriker.
- [Outer](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layouttargettype/#Outer) anger att plotområdets storlek inkluderar tick marks och axelrubriker.

Exempelkod ges nedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**I vilka enheter returneras faktiska X, faktiska Y, faktisk bredd och faktisk höjd?**

I punkter; 1 tum = 72 punkter. Detta är koordinatenheter för Aspose.Slides.

**Hur skiljer sig Plot Area från Chart Area när det gäller innehåll?**

Plot Area är det område där data ritas (serier, rutnätslinjer, trendlina osv.); Chart Area inkluderar de omgivande elementen (titel, legend osv.). I 3D-diagram inkluderar Plot Area också väggarna/golvet och axlarna.

**Hur tolkas Plot Areas X, Y, bredd och höjd när layouten är manuell?**

De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades Plot Area:s position efter att legenden lagts till eller flyttats?**

Legenden placeras i diagramområdet utanför Plot Area men påverkar layout och tillgängligt utrymme, så Plot Area kan flyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint-diagram.)