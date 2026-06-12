---
title: Donutgrafieken aanpassen in presentaties met Java
linktitle: Donutgrafiek
type: docs
weight: 30
url: /nl/java/doughnut-chart/
keywords:
- donutgrafiek
- centrale opening
- grootte van de opening
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken maakt en aanpast in Aspose.Slides for Java, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u werkt met een donutgrafiek in Aspose.Slides door de grafiek aan een dia toe te voegen, de grootte van de centrale opening in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`-methode en toont de basisstappen die nodig zijn om dit grafiektype in code aan te passen.

Het bevat ook een korte FAQ die gerelateerde donutgrafiek‑scenario's behandelt, zoals het gebruik van meerdere series om meerdere ringen te creëren, werken met explodeerde donutgrafieken en het exporteren van een grafiek als rasterafbeelding of SVG.

## **Specificeer de centrale opening in een donutgrafiek**
{{% alert color="primary" %}} 
Aspose.Slides for Java ondersteunt nu het specificeren van de grootte van de opening in een donutgrafiek. In dit onderwerp laten we met een voorbeeld zien hoe u de grootte van de opening in een donutgrafiek kunt specificeren.
{{% /alert %}} 

Om de grootte van de opening in een donutgrafiek te specificeren, volgt u de onderstaande stappen:

1. Instantieser een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)-object.
2. Voeg een donutgrafiek toe aan de dia.
3. Specificeer de grootte van de opening in een donutgrafiek.
4. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van de opening in een donutgrafiek ingesteld.

```java
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

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutgrafiek – elke serie wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een "exploded" donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut-[grafiektype](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; u kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport verkrijgen?**

Een grafiek is een vorm; u kunt deze renderen naar een [rasterafbeelding](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getImage-int-float-float-) of de grafiek exporteren naar een [SVG‑afbeelding](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).