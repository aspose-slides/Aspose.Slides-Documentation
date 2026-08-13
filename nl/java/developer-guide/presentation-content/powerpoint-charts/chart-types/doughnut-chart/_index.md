---
title: Aanpassen van donutgrafieken in presentaties met Java
linktitle: Donutgrafiek
type: docs
weight: 30
url: /nl/java/doughnut-chart/
keywords:
- donutgrafiek
- middengat
- grootte van het gat
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe je donutgrafieken maakt en aanpast in Aspose.Slides voor Java, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe je met een donutgrafiek in Aspose.Slides werkt door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`‑methode en toont de basisstappen die nodig zijn om dit type grafiek in code aan te passen.

Het bevat ook een korte FAQ over gerelateerde donut‑grafiekscenario's, zoals het gebruiken van meerdere reeksen om meerdere ringen te maken, werken met geëxplodeerde donutgrafieken en het exporteren van een grafiek als rasterafbeelding of SVG.

## **Geef de middengat op in een donutgrafiek**
{{% alert color="info" %}} 

Aspose.Slides voor Java ondersteunt nu het specificeren van de grootte van het gat in een donutgrafiek. In dit onderwerp laten we met een voorbeeld zien hoe je de grootte van het gat in een donutgrafiek opgeeft.

{{% /alert %}} 

Om de grootte van het gat in een donutgrafiek op te geven, volg je de onderstaande stappen:

1. Instantieer een [Presentatie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑object.
1. Voeg een donutgrafiek toe aan de dia.
1. Geef de grootte van het gat in de donutgrafiek op.
1. Schrijf de presentatie naar schijf.

In het hieronder gegeven voorbeeld hebben we de grootte van het gat in een donutgrafiek ingesteld.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Schrijf de presentatie naar schijf
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Kan ik een gelaagde donut maken met meerdere ringen?

Ja. Voeg meerdere reeksen toe aan één donutgrafiek — elke reeks wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de reeksen in de collectie.

### Wordt een “geëxplodeerde” donut (gescheiden segmenten) ondersteund?

Ja. Er is een Exploded Doughnut‑[chart type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; je kunt individuele segmenten scheiden.

### Hoe krijg ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport?

Een grafiek is een vorm; je kunt deze renderen naar een [rasterafbeelding](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) of de grafiek exporteren naar een [SVG‑afbeelding](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).