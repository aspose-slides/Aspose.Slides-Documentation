---
title: Donutgrafieken aanpassen in presentaties met Python via Java
linktitle: Donutgrafiek
type: docs
weight: 30
url: /nl/python-java/doughnut-chart/
keywords:
- donutgrafiek
- middengap
- grootte van het gat
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe u donutgrafieken kunt maken en aanpassen in Aspose.Slides voor Python via Java, met ondersteuning voor PowerPoint-formats voor dynamische presentaties."
---
## **Overzicht**

Dit artikel toont hoe je met een donutgrafiek in Aspose.Slides kunt werken door de grafiek aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de [setDoughnutHoleSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) methode en laat de basisstappen zien die nodig zijn om dit grafiektype in code aan te passen.

Het bevat ook een korte FAQ die verwante scenario's voor donutgrafieken behandelt, zoals het gebruik van meerdere series om meerdere ringen te creëren, werken met geëxplodeerde donutgrafieken, en het exporteren van een grafiek als rasterafbeelding of SVG.

## **Specificeer de middengap in een donutgrafiek**

{{% alert color="info" title="Note" %}}
Aspose.Slides voor Python via Java ondersteunt het specificeren van de grootte van het gat in een donutgrafiek. Deze sectie toont hoe je de gatgrootte kunt specificeren aan de hand van een voorbeeld.
{{% /alert %}}

Om de grootte van het gat in een donutgrafiek te specificeren, volg je deze stappen:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) object.
1. Voeg een donutgrafiek toe aan de dia.
1. Specificeer de grootte van het gat in de donutgrafiek.
1. Schrijf de presentatie naar schijf.

Het volgende voorbeeld stelt de grootte van het gat in een donutgrafiek in.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Schrijf de presentatie naar schijf.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een meerlagige donut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één donutgrafiek — elke serie wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de collectie.

**Wordt een "geëxplodeerde" donut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/) en een explosie‑eigenschap op datapunten; je kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een donutgrafiek (PNG/SVG) voor een rapport krijgen?**

Een grafiek is een [shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/); je kunt deze renderen naar een [raster image](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) of de grafiek exporteren naar een SVG‑afbeelding.