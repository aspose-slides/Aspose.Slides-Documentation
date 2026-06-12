---
title: Aangepaste 3D-grafieken in presentaties met Python
linktitle: 3D-grafiek
type: docs
url: /nl/python-net/3d-chart/
keywords:
- 3d grafiek
- rotatie
- diepte
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u 3-D-grafieken kunt maken en aanpassen in Aspose.Slides voor Python via .NET, met ondersteuning voor PPT, PPTX en ODP-bestanden - verbeter uw presentaties vandaag nog."
---
## **Overzicht**

Dit artikel legt uit hoe u een 3D‑grafiek in Aspose.Slides kunt aanpassen door de instellingen van `rotation_3d` te configureren, zoals `rotation_x`, `rotation_y`, `depth_percents` en `right_angle_axes`. Het doorloopt het maken van een presentatie, het toevoegen van een 3D‑grafiek met standaardgegevens, het toepassen van de vereiste 3D‑beeldinstellingen en het opslaan van de aangepaste presentatie als een PPTX‑bestand.

## **Stel RotationX, RotationY en DepthPercents‑eigenschappen van 3D‑grafiek in**

Aspose.Slides for Python via .NET biedt een eenvoudige API om deze eigenschappen in te stellen. Dit artikel helpt u bij het instellen van verschillende eigenschappen zoals X‑, Y‑rotatie, **DepthPercents**, enzovoort. De voorbeeldcode past de eerder genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Stel Rotation3D‑eigenschappen in.
5. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse
with slides.Presentation() as presentation:
            
    # Open de eerste dia
    slide = presentation.slides[0]

    # Voeg een grafiek toe met standaardgegevens
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Stel de index van het grafiek-gegevensblad in
    defaultWorksheetIndex = 0

    # Haal het werkblad met grafiekgegevens op
    fact = chart.chart_data.chart_data_workbook

    # Voeg series toe
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Voeg categorieën toe
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Stel Rotation3D-eigenschappen in
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Neem de tweede grafiekserie
    series = chart.chart_data.series[1]

    # Vul nu de serie-gegevens in
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Stel OverLap-waarde in
    series.parent_series_group.overlap = 100         

    # Schrijf de presentatie naar schijf
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welke grafiektype‑s ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, samen met gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/)‑enumeratie beschikbaar zijn. Voor een nauwkeurige, actuele lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/) in de API‑referentie van de geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek verkrijgen voor een rapport of voor het web?**

Ja. U kunt een grafiek exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/get_image/) of de [render the entire slide](/slides/nl/python-net/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een pixel‑perfecte preview nodig heeft of de grafiek wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint nodig is.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

De prestaties hangen af van het volume aan gegevens en de visuele complexiteit. Voor optimale resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plotgebieden, beperk waar mogelijk het aantal gegevenspunten per serie, en render naar een output met een passende grootte (resolutie en afmetingen) die overeenkomt met het beoogde scherm of de afdrukbehoeften.