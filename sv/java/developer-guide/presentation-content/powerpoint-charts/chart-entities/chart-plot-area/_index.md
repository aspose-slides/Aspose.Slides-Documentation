---
title: Anpassa plotområden för presentationsdiagram i Java
linktitle: Plotområde
type: docs
url: /sv/java/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdebredd
- plotområdehöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du kan anpassa diagrammens plotområden i PowerPoint-presentationer med Aspose.Slides för Java. Förbättra dina bildvisningar enkelt."
---
## **Översikt**

Denna artikel visar hur man arbetar med ett diagram­områdes plot‑område i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plot‑området genom att validera diagrammets layout och sedan läsa dess X‑, Y‑, brett‑ och höjdvärden.

Den visar också hur man konfigurerar plot‑områdets layoutläge när layouten sätts manuellt, med hjälp av `LayoutTargetType` för att definiera om plot‑området beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd för ett diagram‑plot‑område**

Aspose.Slides för Java tillhandahåller ett enkelt API för .

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Öppna den första bilden.
3. Lägg till ett diagram med standarddata.
4. Anropa metoden [IChart.validateChartLayout()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart#validateChartLayout--) innan för att få faktiska värden.
5. Hämtar den faktiska X‑platsen (vänster) för diagram‑elementet i förhållande till diagrammets vänstra övre hörn.
6. Hämtar den faktiska toppen av diagram‑elementet i förhållande till diagrammets vänstra övre hörn.
7. Hämtar den faktiska bredden på diagram‑elementet.
8. Hämtar den faktiska höjden på diagram‑elementet.

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

## **Ställ in layoutläget för ett diagram‑plot‑område**

Aspose.Slides för Java tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plot‑område. Metoderna [**setLayoutTargetType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) och [**getLayoutTargetType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) har lagts till i klassen [**ChartPlotArea**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ChartPlotArea) och i gränssnittet [**IChartPlotArea**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartPlotArea). Om layouten för plot‑området definieras manuellt anger denna egenskap huruvida plot‑området ska layoutas av dess insida (utan axlar och axelrubriker) eller utsida (inklusive axlar och axelrubriker). Det finns två möjliga värden som definieras i enumen [**LayoutTargetType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LayoutTargetType#Inner) - anger att plot‑områdets storlek bestämmer plot‑områdets storlek, utan att inkludera tick‑markeringar och axelrubriker.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LayoutTargetType#Outer) - anger att plot‑områdets storlek bestämmer plot‑områdets storlek, tick‑markeringarna och axelrubrikerna.

Exempel på kod ges nedan.

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

**I vilka enheter returneras faktiskt x, faktiskt y, faktisk bredd och faktisk höjd?**

I punkter; 1 tum = 72 punkter. Detta är Aspose.Slides koordinatenheter.

**Hur skiljer sig Plot‑området från Diagram‑området i innehåll?**

Plot‑området är det område där data ritas (serier, rutnät, trendlinjer osv.); Diagram‑området inkluderar de omgivande elementen (titel, legend osv.). I 3D‑diagram inkluderar Plot‑området även väggar/golv och axlarna.

**Hur tolkas Plot‑områdets x, y, bredd och höjd när layouten är manuell?**

De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades Plot‑områdets position efter att legenden lagts till/flyttats?**

Legend­en sitter i diagram­området utanför Plot‑området men påverkar layouten och tillgängligt utrymme, så Plot‑området kan förskjutas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint‑diagram.)