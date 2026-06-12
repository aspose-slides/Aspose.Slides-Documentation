---
title: "Bubbelgrafieken aanpassen in presentaties met Python"
linktitle: "Bubbelgrafiek"
type: docs
url: /nl/python-net/bubble-chart/
keywords:
- bubbelgrafiek
- bubbelgrootte
- grootte schaling
- grootte representatie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas krachtige bubbelgrafieken aan in PowerPoint en OpenDocument met Aspose.Slides for Python via .NET om uw gegevensvisualisatie eenvoudig te verbeteren."
---
## **Overzicht**

Dit artikel laat zien hoe je met bubbelgrafieken in Aspose.Slides werkt. Het behandelt twee specifieke aanpassingsopties: het schalen van bubbelgroottes via de `bubble_size_scale` eigenschap en het bepalen hoe bubbelgrootte‑waarden worden weergegeven via de `bubble_size_representation` eigenschap.

De voorbeelden tonen hoe je een bubbelgrafiek maakt, de schaal van de grootte aanpast en de weergave van de bubbelgrootte wijzigt naar breedte. Het artikel bevat ook een korte FAQ‑sectie die verduidelijkt dat het “Bubble with 3‑D” grafiektype wordt ondersteund, aangeeft dat praktische limieten afhangen van prestaties en de doelformaatversie van PowerPoint, en uitlegt dat export de weergave van de grafiek behoudt via de rendering‑engine van Aspose.Slides.

## **Grootte‑schaling van bubbelgrafiek**

Aspose.Slides for Python via .NET biedt ondersteuning voor het schalen van de grootte van bubbelgrafieken. In Aspose.Slides for Python via .NET zijn de eigenschappen **ChartSeries.bubble_size_scale** en **ChartSeriesGroup.bubble_size_scale** toegevoegd. Hieronder staat een voorbeeld.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Gegevens weergeven als bubbelgrafiekgroottes**

De eigenschap **bubble_size_representation** is toegevoegd aan de klassen ChartSeries en ChartSeriesGroup. **bubble_size_representation** geeft aan hoe de bubbelgrootte‑waarden in de bubbelgrafiek worden weergegeven. Mogelijke waarden zijn: **BubbleSizeRepresentationType.AREA** en **BubbleSizeRepresentationType.WIDTH**. Daarom is de enum **BubbleSizeRepresentationType** toegevoegd om de mogelijke manieren te specificeren waarop gegevens als bubbelformaten in een grafiek worden weergegeven. Voorbeeldcode staat hieronder.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wordt een “bubble chart with 3‑D effect” ondersteund, en hoe verschilt deze van een standaardgrafiek?**

Ja. Er is een afzonderlijk grafiektype, “Bubble with 3‑D.” Het past 3‑D‑styling toe op de bubbels, maar voegt geen extra as toe; de gegevens blijven X‑Y‑S (grootte). Het type is beschikbaar in de [grafiektype](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/) enumeratie.

**Is er een limiet aan het aantal series en punten in een bubbelgrafiek?**

Er is geen harde limiet op API‑niveau; beperkingen worden bepaald door prestaties en de doelformaatversie van PowerPoint. Het wordt aanbevolen om het aantal punten redelijk te houden voor leesbaarheid en rendering‑snelheid.

**Hoe beïnvloedt export de weergave van een bubbelgrafiek (PDF, afbeeldingen)?**

Export naar ondersteunde formaten behoudt de weergave van de grafiek; de rendering wordt uitgevoerd door de Aspose.Slides‑engine. Voor raster‑/vector‑formaten gelden de algemene regels voor grafiek‑rendering (resolutie, anti‑aliasing), kies dus een voldoende DPI voor afdrukken.