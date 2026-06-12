---
title: Pas donutdiagrammen aan in presentaties op Android
linktitle: Donutdiagram
type: docs
weight: 30
url: /nl/androidjava/doughnut-chart/
keywords:
- donutdiagram
- centrale opening
- gatgrootte
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe u donutdiagrammen maakt en aanpast in Aspose.Slides voor Android via Java, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u werkt met een donutdiagram in Aspose.Slides door het diagram aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de `setDoughnutHoleSize`-methode en toont de basisstappen die nodig zijn om dit diagramtype in code aan te passen.

Het bevat ook een korte FAQ met gerelateerde scenario's voor donutdiagrammen, zoals het gebruiken van meerdere series om meerdere ringen te maken, werken met uitgeplode donutdiagrammen, en het exporteren van een diagram als rasterafbeelding of SVG.

## **Specificeer de centrale opening in een donutdiagram**
{{% alert color="primary" %}} 

Aspose.Slides voor Android via Java ondersteunt nu het specificeren van de grootte van het gat in een donutdiagram. In dit onderwerp laten we aan de hand van een voorbeeld zien hoe u de grootte van het gat in een donutdiagram specificeert.

{{% /alert %}} 

Om de grootte van het gat in een donutdiagram te specificeren, volgt u de onderstaande stappen:

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)-object.
1. Voeg een donutdiagram toe aan de dia.
1. Specificeer de grootte van het gat in een donutdiagram.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een donutdiagram ingesteld.

```java
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

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutdiagram—elke serie wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een "exploded" donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/) en een explosie-eigenschap op datapunten; u kunt afzonderlijke segmenten scheiden.

**Hoe kan ik een afbeelding van een donutdiagram (PNG/SVG) voor een rapport verkrijgen?**

Een diagram is een vorm; u kunt het renderen naar een [raster image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) of het diagram exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).