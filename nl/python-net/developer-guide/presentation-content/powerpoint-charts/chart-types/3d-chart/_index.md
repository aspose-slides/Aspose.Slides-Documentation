---
title: Pas 3D-grafieken aan in presentaties met Python
linktitle: 3D-grafiek
type: docs
url: /nl/python-net/3d-chart/
keywords:
- 3D-grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak 3D-grafieken in PowerPoint-presentaties met Aspose.Slides voor Python via .NET. Pas rotatie, hoogteverhoudingen, grafiekdiepte en de afstand tussen series aan met Python-voorbeelden."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt u in staat de weergave van een 3D‑grafiek aan te passen via de [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) eigenschap. Dit artikel laat zien hoe u rotatie, hoogteverhoudingen, diepte, haakse assen en de afstand tussen series kunt aanpassen, en vervolgens de presentatie opslaat in PPTX‑formaat.

## **Stel de rotatie en diepte van een 3D‑grafiek in**

Het onderstaande voorbeeld maakt een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en gebruikt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een gestapelde 3D‑kolomgrafiek toe te voegen aan de eerste dia. Het vervangt de standaard series en categorieën door twee series met elk drie waarden. Werkblad‑index `0` identificeert het eerste gegevenswerkblad van de grafiek; rij `0` bevat de serienamen, en kolom `0` de categorielabels.

De eigenschappen [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) en [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) stellen de rotatie van de grafiek in op respectievelijk 40 en 270 graden. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) zet de diepte op 150 % van de breedte, terwijl [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) haakse assen inschakelt in plaats van perspectief. De resulterende presentatie bevat de gevulde grafiek met deze 3D‑weergave‑instellingen.

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

## **Pas een afbeeldingsvulling toe op een 3D‑grafiekoppervlak**

U kunt de [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) en [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) van een 3D‑grafiek onafhankelijk vullen. Stel het [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) van het oppervlak in op `PICTURE` en wijs een afbeelding toe. Om één kopie van de afbeelding over het oppervlak te passen, stelt u zowel de [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) als het [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) van het oppervlak in op `STRETCH`.

Sla [arrow.png](arrow.png) op in de werkmap. Het voorbeeld roteert de grafiek en verhoogt de maximale waarde op de verticale as zodat de vloer zichtbaar is tussen de kolommen. Het dupliceert de dia twee keer en past de pijl toe op een ander oppervlak op elke dia. Alle drie de grafieken delen dezelfde gegevens, kijkhoek en achtergrond.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint toont de drie dia’s als volgt.

| Zijkant | Achterwand | Vloer |
| --- | --- | --- |
| ![Pijl die naar de grafiek wijst langs de zijkant](side-wall.png) | ![Pijl die naar rechts wijst over de achterwand](back-wall.png) | ![Pijl die naar rechts wijst over de vloer tussen de kolommen](floor.png) |

## **Pas de hoogteverhoudingen van een 3D‑grafiek aan**

Gebruik [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) om de hoogte van een 3D‑grafiek in te stellen als een percentage van de breedte. Dit wijzigt de verhoudingen van de 3D‑scene zonder het grafiekobject op de dia te herschalen.

Het volgende voorbeeld maakt een [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) grafiek met de standaardgegevens: drie series en vier categorieën. Het slaat drie presentaties op met hoogteverhoudingen van 50 %, 100 % en 200 %. De positie, breedte en hoogte van de grafiek blijven gelijk. De gegevens, rotatie, diepte, seriesafstand en opmaak zijn in alle drie de bestanden identiek; alleen het hoogte‑percentage wijzigt.

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

De onderstaande afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint. Een kleiner percentage levert een plattere scène op, terwijl een groter percentage een hogere scène oplevert binnen hetzelfde grafiekobject. PowerPoint kan ook de intervalwaarde van de as‑tikken en de plaatsing van de labels aanpassen om de scène te laten passen.

| Hoogte: 50 % | Hoogte: 100 % | Hoogte: 200 % |
| --- | --- | --- |
| ![3D‑kolomgrafiek met een hoogte van 50 % van de breedte](height_percent_50.png) | ![3D‑kolomgrafiek met een hoogte van 100 % van de breedte](height_percent_100.png) | ![3D‑kolomgrafiek met een hoogte van 200 % van de breedte](height_percent_200.png) |

Deze eigenschappen regelen verschillende aspecten van de grafiek:

| Eigenschap | Effect |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Hoogte van de 3D‑scene als een percentage van de breedte. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Hoogte van het grafiekobject op de dia, in punten. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Diepte van de 3D‑scene als een percentage van de breedte. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Ruimte tussen series langs de diepte‑as, als een percentage van de marker‑breedte. |

De hoogte‑instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑, vlak‑, taart‑ en oppervlakgrafieken. De vergelijking hierboven gebruikt het geverifieerde type `COLUMN_3D`. De instelling verandert de weergave van een 2D‑`CLUSTERED_COLUMN`‑grafiek of een `BUBBLE_WITH_3D`‑grafiek; deze namen zijn leden van de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie. Voor andere grafiek‑opmaak‑instellingen, zie [Grafiekopmaak](/slides/nl/python-net/chart-formatting/).

## **Pas de ruimte tussen series aan**

Gebruik [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) om de afstand tussen dataseries langs de diepte‑as van een 3D‑grafiek te regelen, uitgedrukt als een percentage van de marker‑breedte. Gebruik waarden van **0 tot 500**, inclusief: `0` verwijdert de ruimte, terwijl grotere waarden de afstand vergroten. Bij een vaste grafiekdiepte maakt een grotere ruimte de markers dunner langs de diepte‑as.

Benader de groep via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). De instelling geldt voor elke serie in die groep, niet alleen voor de serie waarmee u toegang kreeg. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) is alleen-lezen en weerspiegelt de instelling van de bovenliggende groep.

Deze instelling beïnvloedt 3D‑kolom‑ en staafgrafieken, inclusief hun cilindrische, kegel‑ en piramide‑varianten, evenals 3D‑lijn‑ en vlakgrafieken. Het uiterlijk hangt af van of de series in diepte, gegroepeerd of gestapeld zijn. Voor een duidelijke vergelijking van ruimtes tussen afzonderlijke series, gebruik `ChartType.COLUMN_3D` uit de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie.

Deze eigenschappen regelen verschillende aspecten van de grafiek:

| Eigenschap | Effect |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Ruimte tussen series langs de diepte‑as, als een percentage van de marker‑breedte. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Ruimte tussen aangrenzende staaf‑ of kolomclusters, als een percentage van de staaf‑ of kolombreedte. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Totale grafiekdiepte, als een percentage van de grafiekbreedte. |

Het volgende zelfstandige voorbeeld gebruikt de standaardgrafiekgegevens, die drie series en vier categorieën bevatten. Het slaat twee presentaties op met identieke gegevens, rotatie, breedte‑ruimte en grafiekdiepte; alleen de ruimte‑diepte wijzigt.

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

De onderstaande afbeeldingen zijn geëxporteerd uit de gegenereerde presentaties met Microsoft PowerPoint.

| Ruimte‑diepte: 0 % | Ruimte‑diepte: 500 % |
| --- | --- |
| ![3D‑kolomgrafiek zonder ruimte tussen series langs de diepte‑as](gap_depth_0.png) | ![3D‑kolomgrafiek met een ruimte van 500 % tussen series langs de diepte‑as](gap_depth_500.png) |

## **Wijzig het 3D‑serietype en de staafvorm**

In een gegroepeerde cilindergrafiek start de eerste serie met cilindrische staafjes. Het voorbeeld leest [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) en [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) vóór en na elke wijziging.

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

| Wijzig voor de eerste serie | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Maak de grafiek | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Stel `type` in op `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Stel `bar_3d_shape` in op `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Het instellen van de vorm op `BOX` wijzigt ook het serietype naar `CLUSTERED_COLUMN_3D`. Als uw code vertakt op basis van het serietype, lees dan `series.type` nadat u de vorm heeft veranderd. Een waarde die vóór de toewijzing is gecached, zou nog steeds de `CLUSTERED_CONE`‑tak selecteren.

![PowerPoint‑vergelijking die de eerste serie toont als cilinders, kegels en rechthoekige kolommen van links naar rechts](series-shapes.png)

## **FAQ**

**Welke grafiektypen ondersteunen 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomgrafieken, inclusief Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals verwante 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie. Voor een exacte, up‑to‑date lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek verkrijgen voor een rapport of het web?**

Ja. U kunt een grafiek exporteren naar een afbeelding met [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) of [render the entire slide](/slides/nl/python-net/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een raster‑preview nodig heeft of de grafiek wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het genereren en renderen van grote 3D‑grafieken?**

De prestaties hangen af van de gegevensomvang en visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten tot een minimum, vermijdt u zware texturen op wanden en plot‑gebieden, beperkt u het aantal datapunten per serie waar mogelijk, en rendert u naar een passend geschaalde uitvoer (resolutie en afmetingen) die aansluit bij het beoogde beeldscherm‑ of afdrukdoel.