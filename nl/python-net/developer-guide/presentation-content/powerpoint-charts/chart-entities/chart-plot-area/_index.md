---
title: Pas plotgebieden van presentatiediagrammen aan in Python
linktitle: Plotgebied
type: docs
url: /nl/python-net/chart-plot-area/
keywords:
- diagram
- plotgebied
- breedte van plotgebied
- hoogte van plotgebied
- grootte van plotgebied
- lay-outmodus
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u plotgebieden van diagrammen in PowerPoint- en OpenDocument-presentaties kunt aanpassen met Aspose.Slides for Python via .NET. Verbeter moeiteloos de visuele weergave van uw dia's."
---
## **Overzicht**

Dit artikel laat zien hoe u met het plotgebied van een grafiek in Aspose.Slides kunt werken. Het legt uit hoe u de werkelijke positie en afmeting van het plotgebied kunt verkrijgen door de lay‑out van de grafiek te valideren en vervolgens de X‑, Y‑, breedte‑ en hoogte‑waarden uit te lezen.

Het toont ook hoe u de lay‑outmodus van het plotgebied kunt configureren wanneer de lay‑out handmatig wordt ingesteld, met behulp van `LayoutTargetType` om te bepalen of het plotgebied wordt berekend aan de hand van de binnen‑ of buitenregio, inclusief assen en as‑labels.

## **Breedte en hoogte van het grafiek‑plotgebied ophalen**
Aspose.Slides for Python via .NET biedt een eenvoudige API voor .

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Roep de methode IChart.ValidateChartLayout() aan voordat u de werkelijke waarden opvraagt.
1. Haalt de werkelijke X‑locatie (links) van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haalt de werkelijke bovenkant van het grafiekelement op ten opzichte van de linkerbovenhoek van de grafiek.
1. Haalt de werkelijke breedte van het grafiekelement op.
1. Haalt de werkelijke hoogte van het grafiekelement op.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Presentatie opslaan met diagram
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Lay‑outmodus van het grafiek‑plotgebied instellen**
Aspose.Slides for Python via .NET biedt een eenvoudige API om de lay‑outmodus van het grafiek‑plotgebied in te stellen. Eigenschap **LayoutTargetType** is toegevoegd aan de klassen **ChartPlotArea** en **IChartPlotArea**. Als de lay‑out van het plotgebied handmatig wordt gedefinieerd, bepaalt deze eigenschap of het plotgebied wordt gelayout door de binnenkant (exclusief assen en as‑labels) of de buitenkant (inclusief assen en as‑labels). Er zijn twee mogelijke waarden, gedefinieerd in de **LayoutTargetType**‑enum.

- **LayoutTargetType.Inner** – geeft aan dat de grootte van het plotgebied de afmeting van het plotgebied bepaalt, exclusief de tickmarks en as‑labels.
- **LayoutTargetType.Outer** – geeft aan dat de grootte van het plotgebied de afmeting van het plotgebied, de tickmarks en de as‑labels bepaalt.

Voorbeeldcode staat hieronder.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**In welke eenheden worden actual_x, actual_y, actual_width en actual_height geretourneerd?**

In points; 1 inch = 72 points. Dit zijn de coördinaten eenheden van Aspose.Slides.

**Hoe verschilt het Plot Area van het Chart Area qua inhoud?**

Het Plot Area is het tekengebied voor de gegevens (series, rasterlijnen, trendlijnen, enz.); het Chart Area omvat de omliggende elementen (titel, legenda, enz.). Bij 3D‑grafieken omvat het Plot Area ook de wanden/vloer en de assen.

**Hoe worden de X, Y, Width en Height van het Plot Area geïnterpreteerd wanneer de lay‑out handmatig is?**

Ze zijn fracties (0–1) van de totale grootte van de grafiek; in deze modus is automatische positionering uitgeschakeld en worden de door u ingestelde fracties gebruikt.

**Waarom veranderde de positie van het Plot Area nadat de legenda werd toegevoegd/verplaatst?**

De legenda bevindt zich in het chart‑gebied buiten het Plot Area, maar beïnvloedt de lay‑out en de beschikbare ruimte, waardoor het Plot Area kan verschuiven wanneer automatische positionering actief is. (Dit is het standaardgedrag van PowerPoint‑grafieken.)