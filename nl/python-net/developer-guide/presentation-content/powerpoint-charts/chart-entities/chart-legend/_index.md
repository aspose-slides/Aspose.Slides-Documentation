---
title: Grafieklegenda's aanpassen in presentaties met Python
linktitle: Grafieklegenda
type: docs
url: /nl/python-net/chart-legend/
keywords:
- grafieklegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides voor Python via .NET om PowerPoint-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides for Python via .NET biedt opties om de legenda's van diagrammen in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe u een legenda kunt positioneren en de grootte kunt instellen, de lettergrootte voor de hele legenda kunt bepalen, een individuele legenda‑vermelding kunt opmaken en geselecteerde vermeldingen kunt verbergen of herstellen.

De FAQ behandelt gerelateerde functionaliteiten, waaronder het reserveren van ruimte voor de legenda, het weergeven van meerregelige labels en het overnemen van opmaak van het presentatiethema.

## **Legenda positionering**

Gebruik de eigenschappen [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), en [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) van de legenda om de positie en grootte als breuken van de afmetingen van het diagram op te geven.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerde kolomgrafiek met standaardgegevens toe aan de eerste dia. Door de gewenste offset en afmetingen van de legenda te delen door de breedte en hoogte van het diagram, worden ze naar relatieve waarden omgezet: de legenda wordt 50 punten verschoven vanaf de linkerbovenhoek van het diagram en heeft een grootte van 100 bij 100 punten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Druk de positie en grootte van de legenda uit relatief ten opzichte van het diagram.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Stel de lettergrootte van een legenda in**

Gebruik de [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) van de legenda om de tekstopmaak te benaderen en stel [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in punten in.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legendartekst in op 20 punten. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot en met 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Stel de lettergrootte van een individuele legendarvermelding in**

Gebruik de [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) collectie van de legenda om de opmaak van een specifieke vermelding te benaderen. Vermeldingsindexen beginnen bij nul, dus index `1` verwijst naar de tweede vermelding.

Dit voorbeeld maakt een gegroepeerde kolomgrafiek waarvan de standaardgegevens minstens twee series bevatten. Het formatteert de tweede legendarvermelding met vet, cursief en blauwe tekst van 20 punten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Individuele legendarvermeldingen verbergen**

Om een extra serie uit de legenda te halen terwijl de gegevens zichtbaar blijven, stelt u [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) in op `True` via [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Dit verbergt alleen de geselecteerde legendarvermelding; het verwijdert de serie of haar gegevenspunten niet. Het instellen van [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) op `False` verbergt daarentegen de volledige legenda.

Het onderstaande voorbeeld maakt een gegroepeerde kolomgrafiek met meerdere series aan op basis van standaardgegevens. Het verbergt de legendarvermelding van de tweede serie (index `1`) en slaat de presentatie op. Vervolgens wordt de vermelding hersteld door [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) op `False` te zetten en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Herstel dezelfde entry zonder de diagramgegevens te wijzigen.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

De vergelijking hieronder toont hetzelfde diagram met alle vermeldingen zichtbaar en met de tweede vermelding verborgen. De kolommen van de tweede serie blijven ongewijzigd.

![Vergelijking van een diagram met alle legendarvermeldingen zichtbaar en met Serie 2 verborgen uit de legenda; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom-, staaf- en lijndiagrammen geven legendarvermeldingen de series aan. Bij taartdiagrammen geven ze individuele datapunten (segmenten) aan, dus gebruik [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) op het geselecteerde segment. De API documenteert deze datapunt‑eigenschap voor de diagramtypes `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` en `BAR_OF_PIE`. Ga er niet van uit dat dit geldt voor ringdiagrammen, die niet in die lijst staan.

## **FAQ**

**Kan ik het diagram ruimte laten reserveren voor de legenda in plaats van deze te overlappen?**

Ja. Stel [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) in op `False` om ruimte voor de legenda te reserveren in plaats van deze te laten overlappen met het plotgebied.

**Kan ik meerregelige legendarlabels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. U kunt ook regeleinde‑tekens in serienamen gebruiken om een nieuwe regel af te dwingen.

**Hoe laat ik de legenda het kleurenschema van het presentatiethema volgen?**

Laat de kleuren, vullingen en lettertypen van de legenda onaangewezen zodat deze de thematische opmaak kan overnemen. Expliciete opmaak overschrijft de overeenkomstige themainstellingen.