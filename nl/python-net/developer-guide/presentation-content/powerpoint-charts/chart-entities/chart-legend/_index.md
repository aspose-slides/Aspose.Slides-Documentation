---
title: Aangepaste diagramlegenda's in presentaties met Python
linktitle: Diagramlegenda
type: docs
url: /nl/python-net/chart-legend/
keywords:
- diagramlegenda
- positie van de legenda
- lettergrootte
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas diagramlegenda's aan met Aspose.Slides voor Python via .NET om PowerPoint- en OpenDocument-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides for Python biedt volledige controle over diagramlegenda's, zodat u gegevenslabels duidelijk en klaar voor presentatie kunt maken. U kunt de legenda weergeven of verbergen, de positie op de dia kiezen en de lay-out aanpassen om overlapping met het plotgebied te voorkomen. De API stelt u in staat om tekst en markers op te maken, de opvulling en achtergrond nauwkeurig af te stellen, en randen en opvullingen te formatteren zodat ze bij uw thema passen. Ontwikkelaars kunnen ook individuele legenda-items benaderen om ze te hernoemen of te filteren, zodat alleen de meest relevante series worden weergegeven. Met deze mogelijkheden blijven uw grafieken leesbaar, consistent en afgestemd op de ontwerpnormen van uw presentatie.

## **Positie van de legenda**

Met Aspose.Slides kunt u snel bepalen waar de legenda van het diagram verschijnt en hoe deze in uw dia-indeling past. Leer hoe u de legenda nauwkeurig kunt plaatsen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal een verwijzing naar de dia op.
1. Voeg een diagram toe aan de dia.
1. Stel de legenda‑eigenschappen in.
1. Sla de presentatie op als een PPTX‑bestand.

In het voorbeeld hieronder stellen we de positie en grootte van de diagramlegenda in:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:

    # Verkrijg een referentie naar de dia.
    slide = presentation.slides[0]

    # Voeg een gegroepeerde kolomgrafiek toe aan de dia.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Stel de legenda-eigenschappen in.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Sla de presentatie op naar schijf.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Legenda‑lettergrootte instellen**

De legenda van een diagram moet net zo leesbaar zijn als de gegevens die het verklaart. Deze sectie laat zien hoe u de lettergrootte van de legenda kunt aanpassen zodat deze overeenkomt met de typografie van uw presentatie en de toegankelijkheid verbetert.

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Maak een diagram.
1. Stel de lettergrootte in.
1. Sla de presentatie op naar schijf.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Lettergrootte voor een legenda‑item instellen**

Aspose.Slides stelt u in staat het uiterlijk van diagramlegenda's nauwkeurig af te stemmen door individuele items te formatteren. Het voorbeeld hieronder laat zien hoe u een specifiek legenda‑item kunt selecteren en de eigenschappen ervan kunt instellen zonder de rest van de legenda te veranderen.

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Maak een diagram.
1. Benader een legenda‑item.
1. Stel de eigenschappen van het item in.
1. Sla de presentatie op naar schijf.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
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

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik de legenda inschakelen zodat het diagram automatisch ruimte voor de legenda vrijmaakt in plaats van deze te overlappen?**

Ja. Gebruik de niet‑overlapmodus ([overlay](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/legend/overlay/) = `false`); in dit geval zal het plotgebied verkleinen om de legenda te huisvesten.

**Kan ik meerregelige legenda‑labels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via nieuwe‑regel‑tekens in de seriesnaam.

**Hoe laat ik de legenda het kleurschema van het presentatiethema volgen?**

Stel geen expliciete kleuren/opvullingen/lettertypen in voor de legenda of de tekst ervan. Ze erven dan van het thema en worden correct bijgewerkt wanneer het ontwerp verandert.