---
title: Beheer grafiekgegevensmarkeringen in presentaties met Python
linktitle: Gegevensmarkering
type: docs
url: /nl/python-net/chart-data-marker/
keywords:
- grafiek
- gegevenspunt
- markering
- markeeropties
- markergrootte
- vultype
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekgegevensmarkeringen in Aspose.Slides kunt aanpassen, waardoor de impact van presentaties in PPT-, PPTX- en ODP-formaten wordt vergroot met duidelijke code-voorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met gegevensmarkeringen van grafieken in Aspose.Slides werkt. Het laat zien hoe u een grafiek maakt, toegang krijgt tot een serie en de bijbehorende gegevenspunten, picture fills toepast op markeringen op het niveau van het gegevenspunt, de markergrootte aanpast en de bijgewerkte presentatie opslaat. Het vermeldt tevens dat standaard markervormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat het uiterlijk van de markeringen behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Grafiekmarkeeropties instellen**
De markeringen kunnen worden ingesteld op grafiekgegevenspunten binnen een bepaalde serie. Volg de onderstaande stappen om grafiekmarkeeropties in te stellen:

- Instantieser de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
- Maak de standaardgrafiek aan.
- Stel de afbeelding in.
- Haal de eerste grafiekreeks op.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we de grafiekmarkeeropties op het niveau van de gegevenspunten ingesteld.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Maak de standaardgrafiek aan
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Haal de index van de standaardgrafiek‑gegevensworksheet op
    defaultWorksheetIndex = 0

    # Haal de grafiek‑gegevensworksheet op
    fact = chart.chart_data.chart_data_workbook

    # Verwijder demo‑reeks
    chart.chart_data.series.clear()

    # Voeg een nieuwe reeks toe
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Stel de afbeelding in
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Stel de afbeelding in
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Neem de eerste grafiekreeks
    series = chart.chart_data.series[0]

    # Voeg een nieuw punt (1:3) toe daar.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Wijzig de markering van de grafiekreeks
    series.marker.size = 15

    # Schrijf de presentatie naar schijf
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welke markervormen zijn er standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt gedefinieerd door de [MarkerStyleType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/markerstyletype/)‑enumeratie. Als u een niet‑standaard vorm nodig heeft, gebruik dan een markering met een picture fill om aangepaste visuele elementen te emuleren.

**Worden markeringen behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [rasterformaten](/slides/nl/python-net/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/), behouden markeringen hun uiterlijk en instellingen, inclusief grootte, vulling en omtrek.