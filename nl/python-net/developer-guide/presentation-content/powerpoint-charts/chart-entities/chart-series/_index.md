---
title: Beheer grafiekgegevensreeksen in presentaties met Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-net/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- categorie kleur
- reeks naam
- datapunt
- reeksafstand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlap, breedte van de ruimte en negatieve waarden in presentaties kunt beheren met Python."
---
## **Overzicht**

Een grafiek slaat zijn geplaatste gegevens op in een grafiek‑databoek. Een [ChartSeries](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elk [ChartDataPoint](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [ChartCategory](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartcategory/)‑objecten leveren de labels of groeperingswaarden die door de reeksen gedeeld worden. De reeksnaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reekswaarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze indeling gebruikt. Voor een geladen presentatie, inspecteer de cellen die door de reeksen, categorieën en datapunten worden gerefereerd voordat u werkboekwaarden wijzigt.

Instellingen voor grafieken hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/), bepalen de standaardweergave voor alle punten in één reeks.
- Instellingen op datapunt‑niveau, zoals [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/), overschrijven de reeksweergave voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) behoren. Open de groep via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/parent_series_group/) wanneer u opties wilt instellen, zoals overlap of breedte van de ruimte tussen reeksen.

Wanneer geen expliciete punt‑ of reeks‑opvulling is ingesteld, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntformattering aanwezig zijn, heeft de puntformattering voorrang voor dat punt.

![grafiek-reeks-powerpoint](chart-series-powerpoint.png)

## **Stel de overlap van de grafiekreeks in**

[ChartSeries.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van -100 tot 100 percent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Stel [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/overlap/) in om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor grafiektype‑s die gegroepeerde balken of kolommen tonen; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een combinatiegrafiek.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

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

![De reeksoverlap](series_overlap.png)

## **Wijzig de opvulkleur van de reeks**

Gebruik [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/) om de standaardopvulling voor een volledige reeks in te stellen. Als een punt al een expliciete opvulling heeft, overschrijft zijn [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/) instelling de reeksopvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe opvulling toe op de eerste reeks:

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

![De kleur van de reeks](series_color.png)

## **Wijzig de naam van de reeks**

Een reeksnaam wordt opgeslagen in het grafiek‑databoek en normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al door [ChartSeries.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/name/) wordt gerefereerd. Deze aanpak vermijdt het aannemen van een specifieke rij en kolom in een bestaande grafiek:

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

![De reeksnaam](series_name.png)

## **Haal de automatische opvulkleur van de reeks op**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) retourneert de kleur die wordt berekend op basis van de reeksindex en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeksopvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe opvulling toe.

Het volgende voorbeeld print de automatische kleur van elke standaardreeks:

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

Voorbeeldoutput voor de standaardgrafiekstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de grafiekstijl en het thema.

## **Stel omgekeerde opvulkleur in voor een grafiekreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatieve waarden weergeven met een andere opvulling. Stel de reguliere reeksopvulling in op effen, schakel omkering in, en ken de negatieve‑waarde‑kleur toe via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkbladrij 0 bevat de reeksnaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![De omgekeerde effen opvulkleur](inverted_solid_fill_color.png)

U kunt omkering voor één punt inschakelen via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). In het volgende voorbeeld is omkering uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde toegewezen zodat het effect zichtbaar is:

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

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `None`. Voor een kolomgrafiek is de geplaatste waarde beschikbaar via [ChartDataPoint.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/value/). Het datapunt blijft op dezelfde categorielocatie staan, maar de grafiek behandelt zijn waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

Het volgende voorbeeld wist alleen het tweede punt in de eerste reeks:

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

Scatter‑grafieken gebruiken aparte X‑ en Y‑cellen, en bubbelgrafieken gebruiken ook een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) niet aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Stuur de weergave van lege cellen aan**

Een lege werkboekcel staat voor missende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Stel [ChartDataCell.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/value/) in op `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de gehele grafiek. Hij wijzigt hoe lege waarden worden uitgebeeld, zonder de lege werkboekcel met nul of een geïnterpoleerde waarde te vullen.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Laat Dag 3 echt leeg, terwijl de categorie en het datapunt behouden blijven.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijngrafieken met identieke gegevens: Gap onderbreekt de lijn op Dag 3, Zero laat de lijn naar nul dalen, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om over een missende categorie heen te verbinden, dus `SPAN` kan het verbindingssegment hierboven niet produceren; een missende kolom en een kolom met nul‑hoogte kunnen er ook vergelijkbaar uitzien. Evenzo heeft een scatter‑grafiek met alleen markers geen verbindingslijn. Verwacht geen drie onderscheidende resultaten voor elk grafiektype; controleer de uitvoer voor het type dat u gebruikt.

## **Stel de breedte van de ruimte tussen reeksen in**

De breedte van de ruimte (gap width) is de afstand tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze eigenschap tot de bovenliggende reeksgroep en niet tot één enkele reeks. Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) eenmaal in voor de groep. Een grotere waarde creëert meer ruimte tussen de clusters; een kleinere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de breedte van de ruimte en slaat alleen de uiteindelijke presentatie op:

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

![De breedte van de ruimte](gap_width.png)

## **FAQ**

**Welke grafiektype‑s ondersteunen reeksen?**

Alle grafiektype‑s die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/)‑enumeratie gebruiken grafiekdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, scatter‑grafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de methode voor het aanmaken van datapunt die overeenkomt met het type reeks. Opties zoals overlap en breedte van de ruimte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) bevat compatibele reeksen die groeps‑level plotinstellingen delen. Een combinatiegrafiek kan meer dan één groep bevatten, dus het wijzigen van de groep die via één reeks wordt bereikt, verandert niet noodzakelijkerwijs elke reeks in de grafiek.

**Bevat een nieuw aangemaakte grafiek standaarddata?**

Ja. Standaard maakt [ShapeCollection.add_chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_chart/) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als de categorieverzamelingen leegmaken voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een grafiek zonder standaarddata creëren.

**Hoe worden grafiekobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en datapuntwaarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer u aangepaste data bouwt, houdt u de rijen voor categorieën en de rijen voor reeks‑waarden op één lijn zodat elk punt onder de bedoelde categorie wordt uitgezet.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `None` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) alleen wanneer u alle punten van die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden uitgelijnd blijven met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/). Ondersteunde grafieken kunnen lege waarden tonen als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die overeenkomt met de betekenis van missende data in uw presentatie. Zie [Stuur de weergave van lege cellen aan](#control-the-display-of-empty-cells) voor een compleet voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen, schakel [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) in en stel [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) in. U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepseigenschappen zoals overlap en breedte van de ruimte regelen de lay‑out en zijn geen punt‑level opmaak‑overschrijvingen.

**Is er een limiet aan het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op het aantal reeksen. In de praktijk bepalen de beperkingen van het presentatiebestand, beschikbaar geheugen, render‑tijd en leesbaarheid van de grafiek een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te verbreden, of verlaag hem om de clusters dichter bij elkaar te brengen.