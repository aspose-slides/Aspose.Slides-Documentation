---
title: "Aanpassen van donutgrafieken in presentaties op Android"
linktitle: "Donutgrafiek"
type: docs
weight: 30
url: /nl/androidjava/doughnut-chart/
keywords:
- donutgrafiek
- centrale opening
- gatgrootte
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen in Aspose.Slides voor Android via Java, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe je met een donutgrafiek in Aspose.Slides kunt werken door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`‑methode en toont de basisstappen die nodig zijn om dit type grafiek in code aan te passen.

Het bevat ook een korte FAQ die gerelateerde donut‑grafiekscenario’s behandelt, zoals het gebruik van meerdere series om meerdere ringen te maken, werken met geëxplodeerde donutgrafieken, en het exporteren van een grafiek als rasterafbeelding of SVG.

## **Specificeer de centrale opening in een donutgrafiek**
{{% alert color="info" %}} 

Aspose.Slides voor Android via Java ondersteunt nu het specificeren van de grootte van het gat in een donutgrafiek. In dit onderwerp laten we, aan de hand van een voorbeeld, zien hoe je de grootte van het gat in een donutgrafiek kunt specificeren.

{{% /alert %}} 

Om de grootte van het gat in een donutgrafiek te specificeren, volg je de onderstaande stappen:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) object.
1. Voeg een donutgrafiek toe aan de dia.
1. Specificeer de grootte van het gat in een donutgrafiek.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een donutgrafiek ingesteld.

```java
import com.aspose.slides.*;

// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Schrijf presentatie naar schijf
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Kan ik een meerlagige donut met meerdere ringen maken?

Ja. Voeg meerdere series toe aan één donutgrafiek — elke serie wordt een afzonderlijke ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

### Wordt een “geëxplodeerde” donut (gescheiden partjes) ondersteund?

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; je kunt afzonderlijke partjes scheiden.

### Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport krijgen?

Een grafiek is een vorm; je kunt deze renderen naar een [raster image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) of de grafiek exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).