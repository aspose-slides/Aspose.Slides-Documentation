---
title: Anpassa plotområden för presentationsdiagram på Android
linktitle: Plotområde
type: docs
url: /sv/androidjava/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdesbredd
- plotområdeshöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för Android via Java. Förbättra dina bilders visuella uttryck enkelt."
---
## **Översikt**

Denna artikel visar hur du arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur du får den faktiska positionen och storleken på plotområdet genom att validera diagrammets layout och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur du konfigurerar plotområdets layoutläge när layouten ställs in manuellt, genom att använda `LayoutTargetType` för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för ett diagramplotområde**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för . 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#validateChartLayout--) innan du får de faktiska värdena.
1. Hämtar den faktiska X‑positionen (vänster) för diagrammetlementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska översta positionen för diagrammetlementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska bredden på diagrammetlementet.
1. Hämtar den faktiska höjden på diagrammetlementet.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in layoutläget för ett diagramplotområde**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Metoderna [**setLayoutTargetType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) och [**getLayoutTargetType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) har lagts till i klassen [**ChartPlotArea**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ChartPlotArea) och i gränssnittet [**IChartPlotArea**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartPlotArea). Om layouten för plotområdet definieras manuellt anger den här egenskapen om plotområdet ska läggas ut av dess insida (utan axlar och axelrubriker) eller av dess utsida (inklusive axlar och axelrubriker). Det finns två möjliga värden som definieras i enumet [**LayoutTargetType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LayoutTargetType#Inner) – anger att plotområdets storlek bestämmer plotområdets storlek, utan att inkludera markeringar och axelrubriker.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LayoutTargetType#Outer) – anger att plotområdets storlek bestämmer plotområdets storlek, markeringarna och axelrubrikerna.

Exempel på kod finns nedan.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**I vilka enheter returneras faktiska x, faktiska y, faktisk bredd och faktisk höjd?**

I punkter; 1 tum = 72 punkter. Detta är koordinatenheter för Aspose.Slides.

**Hur skiljer sig plotområdet från diagramområdet vad gäller innehåll?**

Plotområdet är det område där data ritas (serier, rutnät, trendlådar osv.); diagramområdet inkluderar de omgivande elementen (titel, legend osv.). I 3D-diagram ingår även väggar/golv och axlar i plotområdet.

**Hur tolkas plotområdets x, y, bredd och höjd när layouten är manuell?**

De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades plotområdets position efter att legenden lagts till/flyttats?**

Legenden placeras i diagramområdet utanför plotområdet men påverkar layouten och tillgängligt utrymme, så plotområdet kan flyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint-diagram.)