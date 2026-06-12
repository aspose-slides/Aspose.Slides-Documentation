---
title: "Aanpassen van Donutgrafieken in Presentaties in .NET"
linktitle: "Donutgrafiek"
type: docs
weight: 30
url: /nl/net/doughnut-chart/
keywords:
- donutgrafiek
- centrale opening
- gatgrootte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen in Aspose.Slides voor .NET, met ondersteuning voor PowerPoint-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u met een donutgrafiek in Aspose.Slides kunt werken door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de instelling `DoughnutHoleSize` en toont de basisstappen die nodig zijn om dit type grafiek in code aan te passen.

Het bevat tevens een korte FAQ over gerelateerde donutgrafiekscenario's, zoals het gebruik van meerdere series om meerdere ringen te maken, werken met geëxplodeerde donutgrafieken, en het exporteren van een grafiek als rasterafbeelding of SVG.

## **Specificeer de centrale opening in een donutgrafiek**
Om de grootte van het gat in een donutgrafiek op te geven, volgt u onderstaande stappen:

- Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation).
- Voeg een donutgrafiek toe aan de dia.
- Specificeer de grootte van het gat in een donutgrafiek.
- Schrijf de presentatie naar schijf.

```c#
// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Schrijf de presentatie naar schijf
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutgrafiek — elke serie wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een “geëxplodeerde” donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [grafiektype](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/) en een explosie‑eigenschap op datapoints; u kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport krijgen?**

Een grafiek is een vorm; u kunt deze renderen naar een [rasterafbeelding](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/) of de grafiek exporteren naar een [SVG‑afbeelding](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/).