---
title: Anpassa diagrammens plotområden i presentationer med JavaScript
linktitle: Plotområde
type: docs
url: /sv/nodejs-java/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdesbredd
- plotområdeshöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du kan anpassa diagrammens plotområden i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js. Förbättra dina bilders visuella intryck enkelt."
---
## **Översikt**

Denna artikel visar hur man arbetar med ett diagrammets plotområde i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plotområdet genom att validera diagrammets layout och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur man konfigurerar plotområdets layoutläge när layouten ställs in manuellt, med `LayoutTargetType` för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd, höjd för diagrammets plotområde**

Aspose.Slides för Node.js via Java tillhandahåller ett enkelt API för . 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta den första bilden.
3. Lägg till ett diagram med standarddata.
4. Anropa metoden [Chart.validateChartLayout()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#validateChartLayout--) innan för att få de faktiska värdena.
5. Hämtar den faktiska X‑positionen (vänster) för diagramelementet relativt diagrammets vänstra övre hörn.
6. Hämtar den faktiska toppen av diagramelementet relativt diagrammets vänstra övre hörn.
7. Hämtar den faktiska bredden på diagramelementet.
8. Hämtar den faktiska höjden på diagramelementet.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in layoutläge för diagrammets plotområde**

Aspose.Slides för Node.js via Java tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Metoderna [**setLayoutTargetType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) och [**getLayoutTargetType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) har lagts till i klassen [**ChartPlotArea**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartPlotArea) och [**ChartPlotArea**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartPlotArea). Om layouten för plotområdet definieras manuellt anger den här egenskapen huruvida plotområdet ska layoutas av dess insida (utan axlar och axelrubriker) eller utsida (med axlar och axelrubriker). Det finns två möjliga värden som definieras i uppräkningen [**LayoutTargetType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**] - anger att plotområdets storlek ska bestämma plotområdets storlek, utan att inkludera tick-märkena och axelrubrikerna.
- [**LayoutTargetType.Outer**] - anger att plotområdets storlek ska bestämma plotområdet, tick-märkena och axelrubrikerna.

Exempelkod ges nedan.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**I vilka enheter returneras faktisk X, faktisk Y, faktisk bredd och faktisk höjd?**  
I punkter; 1 tum = 72 punkter. Detta är Aspose.Slides koordinatenheter.

**Hur skiljer sig plotområdet från diagramområdet avseende innehåll?**  
Plotområdet är det område där data ritas (serier, rutnät, trendlinjer osv.); diagramområdet inkluderar de omgivande elementen (titel, legend osv.). I 3D-diagram inkluderar plotområdet också väggarna/golvet och axlarna.

**Hur tolkas plotområdets X, Y, bredd och höjd när layouten är manuell?**  
De är bråkdelar (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråkdelar du anger används.

**Varför ändrades plotområdets position efter att legend har lagts till/flyttats?**  
Legenden placeras i diagramområdet utanför plotområdet men påverkar layout och tillgängligt utrymme, så plotområdet kan flyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint‑diagram.)