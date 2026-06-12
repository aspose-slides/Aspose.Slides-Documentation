---
title: Aangepaste donutgrafieken in presentaties met JavaScript
linktitle: Donutgrafiek
type: docs
weight: 30
url: /nl/nodejs-java/doughnut-chart/
keywords:
- donutgrafiek
- centraal gat
- grootte van het gat
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen met JavaScript en Aspose.Slides voor Node.js, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe je met een donutgrafiek in Aspose.Slides kunt werken door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`‑methode en toont de basisstappen die nodig zijn om dit grafiektype in code aan te passen.

Het bevat ook een korte FAQ met gerelateerde scenario’s voor donutgrafieken, zoals het gebruik van meerdere reeksen om meerdere ringen te creëren, werken met geëxplodeerde donutgrafieken en het exporteren van een grafiek als raster‑afbeelding of SVG.

## **Gat in het centrum wijzigen in donutgrafiek**

Om de grootte van het gat in een donutgrafiek op te geven, volg je de onderstaande stappen:

1. Maak een Presentation‑object aan.
1. Voeg een donutgrafiek toe aan de dia.
1. Geef de grootte van het gat in een donutgrafiek op.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een donutgrafiek ingesteld.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Schrijf de presentatie naar schijf
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere reeksen toe aan één donutgrafiek — elke reeks wordt een afzonderlijke ring. De volgorde van de ringen wordt bepaald door de volgorde van de reeksen in de collectie.

**Wordt een “exploded” donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; je kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) verkrijgen voor een rapport?**

Een grafiek is een vorm; je kunt deze renderen naar een [raster image](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage) of de grafiek exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/).