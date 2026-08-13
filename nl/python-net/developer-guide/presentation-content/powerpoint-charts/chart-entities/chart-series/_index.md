---
title: Beheer grafiekdataseries in presentaties met Python
linktitle: Dataseries
type: docs
url: /nl/python-net/chart-series/
keywords:
- grafiekserie
- serie-overlap
- serie-kleur
- categorie-kleur
- serie-naam
- datapunt
- serie-gat
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekseries, datapunten, werkmapcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met Python."
---
## **Overzicht**

Een grafiek slaat zijn geplotte gegevens op in een grafiekgegevens‑werkmap. Een [ChartSeries](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/) in de serie verwijst naar één of meer cellen in de werkmap. [ChartCategory](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartcategory/)‑objecten leveren de labels of groepeerwaarden die door de series worden gedeeld. De serienaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categorie‑grafiek gebruikt de standaard werkmap rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor seriewaarden. Werkblad‑, rij‑ en kolomindexen die worden doorgegeven aan [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) zijn nul‑gebaseerd. Deze lay‑out is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze gebruikt. Voor een geladen presentatie inspecteert u de cellen die door de series, categorieën en datapunten worden gerefereerd voordat u werkmap‑waarden wijzigt.

Grafiekinstellingen hebben drie verschillende reikwijdtes:

- Instellingen op serieniveau, zoals [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/), bieden de standaardopmaak voor alle punten in één serie.
- Instellingen voor datapunt, zoals [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/), overschrijven de serie‑opmaak voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) behoren. Open de groep via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/parent_series_group/) wanneer u opties zoals overlap of gatbreedte wilt instellen.

Wanneer er geen expliciete punt‑ of serie‑vulling is ingesteld, bepalen het grafiek‑stijl en het thema de automatische weergave. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![grafiek-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlap van de grafiekserie in**

[ChartSeries.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/overlap/) geeft weer hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 procent. Het is een alleen‑lezen weergave van de instelling op de bovenliggende seriegroep. Stel [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/overlap/) in om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op grafiektype die gegroepeerde balken of kolommen weergeven; het beïnvloedt geen niet‑gerelateerde seriegroepen in een combinatie‑grafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste serie bevat:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # De nieuwe grafiek bevat voorbeeldreeksen, categorieën en waarden.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De serie‑overlap](series_overlap.png)

## **Wijzig de vullingkleur van de serie**

Gebruik [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/) om de standaardvulling voor een volledige serie in te stellen. Als een punt al een expliciete vulling heeft, overschrijft zijn [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/)‑instelling de serievulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste serie:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De kleur van de serie](series_color.png)

## **Wijzig de serienaam**

Een serienaam wordt opgeslagen in de grafiekgegevens‑werkmap en wordt normaal weergegeven in de legenda. In de standaard werkmap die wordt aangemaakt voor een gegroepeerde kolomgrafiek, bevindt cel B1 zich in rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

U kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/name/). Deze aanpak vermijdt het aannemen van een specifieke rij en kolom in een bestaande grafiek:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De serienaam](series_name.png)

## **Haal de automatische serievullingskleur op**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) retourneert de kleur die is berekend op basis van de seriële index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de serievulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe vulling toe.

Het volgende voorbeeld print de automatische kleur van elke standaard serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Voorbeeldoutput voor de standaard grafiekstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Stel omgekeerde vullingskleur in voor een grafiekserie**

Voor balk‑, kolom‑ en bubbel‑series kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatieve waarden weergeven met een andere vulling. Stel de reguliere serievulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negatieve getallen blijven ongewijzigd in de werkmap; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaard grafiekgegevens door één serie. Rij 0 van het werkblad bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De omgekeerde effen vullingskleur](inverted_solid_fill_color.png)

U kunt inversie inschakelen voor één punt via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Wis een specifieke datapuntwaarde**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkmapcel in op `None`. Voor een kolomgrafiek is de geplotte waarde beschikbaar via [ChartDataPoint.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/value/). Het datapunt blijft op dezelfde categorische positie, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubbel‑grafieken gebruiken bovendien een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, omdat die methode elk datapunt uit de collectie verwijdert.

## **Stel de gatbreedte van de serie in**

De gatbreedte is de ruimte tussen aangrenzende balk‑ of kolom‑clusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze tot de bovenliggende seriegroep en niet tot één serie. Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) één keer in voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de uiteindelijke presentatie op:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De gatbreedte](gap_width.png)

## **FAQ**

**Welke grafiektypen ondersteunen dataseries?**

Alle grafiektypen die worden weergegeven door de [ChartType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/)‑enumeratie gebruiken grafiekgegevens, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑grafieken gebruiken categorieën en waarden, scatter‑grafieken gebruiken X‑ en Y‑waarden, en bubbel‑grafieken voegen bubbelgroottes toe. Gebruik de datapunt‑creatiemethode die overeenkomt met het serietype. Opties zoals overlap en gatbreedte zijn alleen van toepassing op compatibele balk‑ of kolom‑groepen.

**Wat is een grafiekserie‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatie‑grafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, betekent niet noodzakelijk dat elke serie in de grafiek wordt aangepast.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.add_chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_chart/) voorbeeld‑series, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de serie‑ als categoricollecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek maken zonder standaardgegevens.

**Hoe zijn grafiekobjecten verbonden met werkmapcellen?**

Serienamen, categorielabels en datapuntwaarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste gegevens opbouwt, houd dan categorierijen en seriewaarde‑rijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele serie?**

Stel de betreffende waardecel in op `None` om de categorische positie van het punt te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden uitgelijnd blijven met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nul‑waarden, of door aangrenzende punten te verbinden. Kies de instelling die overeenkomt met de betekenis van ontbrekende gegevens in uw presentatie.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series schakelt u [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) in en stelt u [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) in. U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groeps‑eigenschappen zoals overlap en gatbreedte bepalen de lay‑out en zijn geen overschrijvingen op puntniveau.

**Is er een limiet aan hoeveel series een grafiek kan bevatten?**

Aspose.Slides legt geen aparte vaste limiet op voor het aantal series. In de praktijk bepalen de beperkingen van het presentatie‑bestand, beschikbaar geheugen, render‑tijd en de leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in op de juiste bovenliggende seriegroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.