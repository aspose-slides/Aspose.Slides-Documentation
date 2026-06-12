---
title: Aanpassen van Doughnut-diagrammen in presentaties met Python
linktitle: Doughnut-diagram
type: docs
weight: 30
url: /nl/python-net/doughnut-chart/
keywords:
- doughnut-diagram
- centraal gat
- gatgrootte
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u doughnut-diagrammen maakt en aanpast in Aspose.Slides voor Python via .NET, met ondersteuning voor PowerPoint- en OpenDocument-formaten voor dynamische presentaties."
---
## **Overzicht**

Dit artikel toont hoe u werkt met een doughnut-diagram in Aspose.Slides door het diagram aan een dia toe te voegen, de grootte van het centrale gat in te stellen en de presentatie op te slaan. Het richt zich op de instelling `doughnut_hole_size` en laat de basisstappen zien die nodig zijn om dit diagramtype te aanpassen in code.

Het bevat ook een korte FAQ die gerelateerde doughnut-diagramscenario's behandelt, zoals het gebruik van meerdere series om meerdere ringen te maken, werken met geëxplodeerde doughnut-diagrammen, en het exporteren van een diagram als rasterafbeelding of SVG.

## **Specificeer het centrale gat in een doughnut-diagram**
Om de grootte van het gat in een doughnut-diagram op te geven, volg de onderstaande stappen:

- InstantIEer de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
- Voeg een doughnut-diagram toe aan de dia.
- Geef de grootte van het gat in een doughnut-diagram op.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grootte van het gat in een doughnut-diagram ingesteld.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Schrijf de presentatie naar schijf
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik een meerlagige doughnut met meerdere ringen maken?**

Ja. Voeg meerdere series toe aan één doughnut-diagram — elke serie wordt een aparte ring. De volgorde van de ringen wordt bepaald door de volgorde van de series in de verzameling.

**Wordt een “geëxplodeerde” doughnut (gescheiden segmenten) ondersteund?**

Ja. Er is een Exploded Doughnut [chart type](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/) en een explosie‑eigenschap op gegevenspunten; u kunt individuele segmenten scheiden.

**Hoe kan ik een afbeelding van een doughnut-diagram (PNG/SVG) krijgen voor een rapport?**

Een diagram is een vorm; u kunt het renderen naar een [raster image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/) of het diagram exporteren naar een [SVG image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/write_as_svg/).