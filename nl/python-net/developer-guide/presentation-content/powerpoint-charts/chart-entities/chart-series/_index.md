---
title: Beheer grafiekreeksen in presentaties met Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-net/chart-series/
keywords:
- grafiekreeks
- overlapping van reeksen
- reekskleur
- categoriekleur
- reeksnaam
- datumpunt
- reeksafstand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekreeksen, datapunten, werkboekcellen, opmaak, overlapping, gatbreedte en negatieve waarden kunt beheren in presentaties met Python."
---
## **Overzicht**

Een grafiek slaat zijn getekende gegevens op in een grafiek‑databoek. Een [ChartSeries](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/) vertegenwoordigt één set verwante waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [ChartCategory](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartcategory/)‑objecten leveren de labels of groepeerwaarden die door de reeksen worden gedeeld. De naam van de reeks, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/)‑objecten in plaats van alleen als weergavetekst te worden opgeslagen.

Voor een typische categoriegrafiek gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de resterende cellen voor reeksen‑waarden. Werkblad‑, rij‑ en kolom‑indices die aan [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer je een grafiek met standaardgegevens maakt, maar ga er niet van uit dat elke bestaande grafiek deze structuur hanteert. Bij een geladen presentatie moet je de cellen die door de reeksen, categorieën en datapunten worden gerefereerd, inspecteren voordat je werkboekwaarden wijzigt.

Grafiekinstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/), bepalen de standaarduiterlijk voor alle punten in één reeks.
- Instellingen per datumpunt, zoals [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/), overschrijven het reeks‑uiterlijk voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) behoren. Benader de groep via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/parent_series_group/) wanneer je opties zoals overlapping of gatbreedte moet instellen.

Wanneer er geen expliciete punt‑ of reeks‑vulling is opgegeven, bepalen de grafiekstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als puntformattering aanwezig zijn, heeft de puntformattering voorrang voor dat punt.

![Grafiekreeks PowerPoint](chart-series-powerpoint.png)

## **Instellen van de overlap van de grafiekreeks**

[ChartSeries.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑grafiek, van –100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende reeksgroep. Stel [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/overlap/) in om elke compatibele reeks in die groep bij te werken. Deze optie is van toepassing op grafiektype­n die gegroepeerde balken of kolommen weergeven; hij beïnvloedt geen niet‑gerelateerde reeksgroepen in een combinatie‑grafiek.

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

![De reeks‑overlap](series_overlap.png)

## **De vullingkleur van de reeks wijzigen**

Gebruik [ChartSeries.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/format/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/format/)‑instelling de reeks‑vulling voor dat punt.

Het volgende voorbeeld past een egale blauwe vulling toe op de eerste reeks:

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

## **De naam van de reeks wijzigen**

Een reeksnaam wordt opgeslagen in het grafiek‑databoek en normaal gesproken weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerde kolomgrafiek wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste reeks. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

Je kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/name/). Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaande grafiek:

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

## **De automatische vullingkleur van de reeks opvragen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) retourneert de kleur die wordt berekend op basis van de reeks‑index en de grafiekstijl. Dit is de kleur die wordt gebruikt wanneer de reeks‑vulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijzigt geen vulling.

Het volgende voorbeeld drukt de automatische kleur van elke standaardreeks af:

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

De precieze kleuren hangen af van de grafiekstijl en het thema.

## **Negatieve vullingkleur omkeren voor een grafiekreeks**

Voor balk‑, kolom‑ en bubbelreeksen kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatieve waarden weergeven met een andere vulling. Stel de normale reeks‑vulling in op egaal, schakel de inversie in en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaardgrafiekgegevens door één reeks. Werkblad‑rij 0 bevat de reeksnaam, kolom 0 bevat categorienamen en kolom 1 bevat de waarden:

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

![De omgekeerde egale vullingkleur](inverted_solid_fill_color.png)

Je kunt de inversie voor één punt inschakelen via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). In het volgende voorbeeld is de inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke datumpuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stel je de onderliggende werkboekcel in op `None`. Voor een kolomgrafiek is de getekende waarde beschikbaar via [ChartDataPoint.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/value/). Het datumpunt blijft op dezelfde categorielocatie staan, maar de grafiek behandelt de waarde als leeg volgens de instellingen voor lege waarden van de grafiek.

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

Spreidingsgrafieken gebruiken gescheiden X‑ en Y‑cellen, en bubbelgrafieken gebruiken bovendien een groottecel. Wis alleen de cel die de waarde vertegenwoordigt die je wilt verwijderen. Roep [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) niet aan wanneer je de andere punten wilt behouden, want die methode verwijdert elk datumpunt uit de collectie.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Om gegevens uit verborgen werkblad‑rijen en -kolommen al dan niet mee te nemen, zie [Include Data from Hidden Rows and Columns](/slides/nl/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Stel [ChartDataCell.value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatacell/value/) in op `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/) om te kiezen hoe de grafiek lege cellen weergeeft. Deze instelling geldt voor de hele grafiek. Ze verandert hoe lege waarden worden uitgezet, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met één reeks, wist de waarde voor Dag 3, en slaat dezelfde grafiek op in elke modus. Er is geen invoer‑bestand nodig. De [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnaam. De einddata zijn `10, 20, empty, 30, 40`.

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

    # Laat Dag 3 echt leeg, terwijl de categorie en het datumpunt behouden blijven.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stel je de gewenste modus in en sla je de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Lijngrafieken met identieke data: Gap onderbreekt de lijn bij Dag 3, Zero laat de lijn naar nul dalen, en Span verbindt Dag 2 met Dag 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het grafiektype. Een lijngrafiek maakt alle drie de modi gemakkelijk vergelijkbaar. Balk‑ en kolomgrafieken hebben geen lijn om een ontbrekende categorie te verbinden, dus `SPAN` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook op lijken. Evenzo heeft een spreidingsgrafiek met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk grafiektype; controleer de output voor het type dat je gebruikt.

## **De gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort deze aan de bovenliggende reeksgroep en niet aan één enkele reeks. Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) eenmaal in voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter.

Het volgende voorbeeld wijzigt de gatbreedte en slaat alleen de definitieve presentatie op:

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

**Welke grafiektype­n ondersteunen datumsreeksen?**

Alle grafiektype­n die door de [ChartType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/)‑enumeratie worden vertegenwoordigd, gebruiken grafiekdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriegrafieken gebruiken categorieën en waarden, spreidingsgrafieken gebruiken X‑ en Y‑waarden, en bubbelgrafieken voegen bubbelgroottes toe. Gebruik de datumpunt‑creatiemethode die overeenkomt met het reekstype. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een combinatie‑grafiek kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één reeks wordt bereikt, niet per se elke reeks in de grafiek wijzigt.

**Bevat een nieuw aangemaakte grafiek standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.add_chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_chart/) voorbeeldreeksen, -categorieën en -waarden aan. Je kunt die cellen bewerken of zowel de reeksen‑ als categorieverzamelingen wissen voordat je een volledig aangepast gegevens‑set toevoegt. Een overload kan ook een grafiek zonder standaardgegevens aanmaken.

**Hoe zijn grafiekobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en datumpunt‑waarden refereren aan cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige grafiekelement bij. Wanneer je aangepaste gegevens opbouwt, houd je categorie‑rijen en reeks‑waarde‑rijen uitgelijnd zodat elk punt onder de beoogde categorie wordt uitgezet.

**Hoe kan ik één punt wissen in plaats van de hele reeks?**

Stel de betreffende waarde‑cel in op `None` om de positie van de categorie van het punt te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointcollection/clear/) alleen wanneer je alle punten van die reeks wilt verwijderen. Als je ook categorieën verwijdert, werk je elke reeks bij zodat hun waarden blijven overeenkomen met de categorieverzameling.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het grafiektype en van [Chart.display_blanks_as](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/display_blanks_as/). Ondersteunde grafieken kunnen lege waarden weergeven als gaten, als nulwaarden, of door aangrenzende punten te verbinden. Kies de instelling die het best overeenkomt met de betekenis van ontbrekende gegevens in je presentatie. Zie [Weergave van lege cellen regelen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbelreeksen kun je [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/invert_if_negative/) inschakelen en [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) instellen. Je kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Deze eigenschappen beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak wint wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete datumpunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet is gedefinieerd, de automatische grafiekstijl en het thema. Groepseigenschappen zoals overlap en gatbreedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overschrijvingen.

**Is er een limiet voor het aantal reeksen dat een grafiek kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal reeksen. In de praktijk bepalen de beperkingen van het presentatiedocument, het beschikbare geheugen, de render‑tijd en de leesbaarheid van de grafiek een praktisch limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag deze om de clusters dichter bij elkaar te brengen.