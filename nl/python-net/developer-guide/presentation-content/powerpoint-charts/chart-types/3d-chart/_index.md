---
title: 3D-diagrammen aanpassen in presentaties met Python
linktitle: 3D-diagram
type: docs
url: /nl/python-net/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak 3D-diagrammen in PowerPoint-presentaties met Aspose.Slides voor Python via .NET. Pas rotatie, hoogteratio's, diagramdiepte en de afstand tussen reeksen aan met Python-voorbeelden."
---
## **Overzicht**

Aspose.Slides voor Python via .NET laat u de weergave van een 3D-diagram aanpassen via de [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) eigenschap. Dit artikel laat zien hoe u rotatie, hoogteratio’s, diepte, rechthoekige assen en de afstand tussen reeksen kunt aanpassen, en vervolgens de presentatie opslaat in PPTX-formaat.

## **Stel de rotatie en diepte van een 3D-diagram in**

Het voorbeeld hieronder maakt een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en gebruikt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een gestapeld 3D-kolomdiagram toe te voegen aan de eerste dia. Het vervangt de standaardreeksen en -categorieën door twee reeksen met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevenswerkblad van het diagram; rij `0` bevat de reeksnamen, en kolom `0` bevat de categorie‑labels.

De [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/)‑ en [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/)‑eigenschappen stellen de rotatie van het diagram in op respectievelijk 40 en 270 graad. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) stelt de diepte in op 150 % van de breedte, terwijl [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) rechthoekige assen inschakelt in plaats van perspectief. De resulterende presentatie bevat het gevulde diagram met deze 3D‑weergave‑instellingen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Pas de hoogteratio’s van een 3D-diagram aan**

Gebruik [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) om de hoogte van een 3D-diagram in te stellen als een percentage van de breedte. Hiermee verandert u de verhoudingen van de 3D‑scene zonder de diagramobjectgrootte op de dia te wijzigen.

Het volgende voorbeeld maakt een [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) diagram met de standaardgegevens: drie reeksen en vier categorieën. Het slaat drie presentaties op met hoogteratio’s van 50 %, 100 % en 200 %. De positie, breedte en hoogte van het diagram blijven gelijk. De gegevens, rotatie, diepte, reeksen­afstand en opmaak zijn identiek in alle drie de bestanden; alleen het hoogte‑percentage verandert.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

De volgende afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint. Een lager percentage levert een plattere scène op, een hoger percentage een hogere scène binnen hetzelfde diagramobject. PowerPoint kan ook de interval­instellingen van de assen en de plaatsing van labels aanpassen om de scène te laten passen.

| Hoogte: 50% | Hoogte: 100% | Hoogte: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

Deze eigenschappen regelen verschillende aspecten van het diagram:

| Eigenschap | Effect |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Hoogte van de 3D‑scene als percentage van de breedte. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Hoogte van het diagramobject op de dia, in points. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Diepte van de 3D‑scene als percentage van de breedte. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Afstand tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief cilindrische, kegel‑ en piramidevarianten, evenals 3D‑lijn‑, gebieds‑, taart‑ en oppervlakteschema’s. De vergelijking hierboven maakt gebruik van het geverifieerde `COLUMN_3D`‑type. De instelling verandert niet het uiterlijk van een 2D `CLUSTERED_COLUMN`‑diagram of een `BUBBLE_WITH_3D`‑diagram; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie. Zie voor andere diagram‑opmaak‑instellingen [Chart Formatting](/slides/nl/python-net/chart-formatting/).

## **Pas de afstand tussen reeksen aan**

Gebruik [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) om de afstand tussen gegevensreeksen langs de diepte‑as van een 3D-diagram te regelen, uitgedrukt als percentage van de markerbreedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de kloof, terwijl hogere waarden de afstand vergroten. Bij een vaste diagramdiepte maakt een grotere kloof de markers dunner langs de diepte‑as.

Toegang tot de groep gebeurt via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). De instelling geldt voor elke reeks in die groep, niet alleen voor de reeks die wordt gebruikt om toegang te krijgen. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) is alleen‑lezen en geeft de instelling van de bovenliggende groep weer.

Deze instelling beïnvloedt 3D‑kolom‑ en staafdiagrammen, inclusief hun cilindrische, kegel‑ en piramidevarianten, evenals 3D‑lijn‑ en gebiedsdiagrammen. Het uiterlijk hangt af van of de reeksen in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van kloven tussen afzonderlijke reeksen, gebruik `ChartType.COLUMN_3D` uit de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie.

Deze eigenschappen regelen verschillende aspecten van het diagram:

| Eigenschap | Effect |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Afstand tussen reeksen langs de diepte‑as, als percentage van de markerbreedte. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Afstand tussen aangrenzende staaf‑ of kolomclusters, als percentage van de staaf‑ of kolombreedte. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Totale diagramdiepte, als percentage van de diagrambreedte. |

Het volgende zelf‑containende voorbeeld gebruikt de standaarddiagramgegevens, die drie reeksen en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, kloofbreedte en diagramdiepte; alleen de kloofdiepte wijzigt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

De volgende afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint.

| Kloofdiepte: 0% | Kloofdiepte: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Wijzig het 3D‑reeks‑type en de staafvorm**

In een gegroepeerd cilindrisch diagram begint de eerste reeks met cilindrische staven. Het voorbeeld leest [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) en [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) vóór en na elke wijziging.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Wijziging voor de eerste reeks | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Maak het diagram | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Stel `type` in op `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Stel `bar_3d_shape` in op `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Het instellen van de vorm op `BOX` wijzigt ook het reekstype naar `CLUSTERED_COLUMN_3D`. Als uw code vertakt op het reekstype, lees dan `series.type` na het wijzigen van de vorm. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `CLUSTERED_CONE`‑tak selecteren.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Welke grafiektype ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, inclusief Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, naast gerelateerde 3D‑typen die worden blootgelegd via de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie. Voor een exacte, up‑to‑date lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding met [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) of [render the entire slide](/slides/nl/python-net/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is nuttig wanneer u een raster‑preview nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑diagrammen?**

De prestaties hangen af van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten minimaal, vermijdt zware texturen op wanden en plot‑gebieden, beperkt het aantal gegevenspunten per reeks waar mogelijk, en rendert naar een geschikt formaat (resolutie en afmetingen) dat aansluit bij de beoogde weergave‑ of afdrukbehoeften.