---
title: Beheer van diagramseries in presentaties met Python
linktitle: Gegevensseries
type: docs
url: /nl/python-net/chart-series/
keywords:
- diagramserie
- serie overlapping
- serie kleur
- categorie kleur
- serie naam
- datapunt
- serie gat
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u diagramseries, datapunt, werkboekcellen, opmaak, overlapping, gatbreedte en negatieve waarden in presentaties met Python kunt beheren."
---
## **Overzicht**

Een diagram kan zijn uitgeplotte waarden opslaan in werkboekcellen of rechtstreeks als numerieke literals. Een [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) vertegenwoordigt een punt in die serie. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/)-objecten bieden de labels of groeperingswaarden die door de series gedeeld worden. In diagrammen die met standaardgegevens zijn gemaakt, gebruiken serienaam, categorieën en puntwaarden [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)‑objecten uit het diagramwerkboek.

Voor een typisch categorie‑diagram gebruikt het standaardwerkboek rij 0 voor serienamen, kolom 0 voor categorienamen en de resterende cellen voor serie‑waarden. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) worden doorgegeven, zijn null‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga er niet vanuit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie inspecteert u de cellen die door de series, categorieën en datapunt‑waarden worden gerefereerd voordat u werkboekwaarden wijzigt.

Instellingen voor diagrammen hebben drie verschillende scopes:

- Instellingen op serie‑niveau, zoals [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), bepalen de standaardweergave voor alle punten in één serie.
- Instellingen per datapunt, zoals [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), overschrijven de serie‑weergave voor één punt.
- Groepsinstellingen zijn van toepassing op compatibele series die tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) behoren. Toegang tot de groep krijgt u via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) wanneer u opties zoals overlapping of gat breedte wilt instellen.

Wanneer er geen expliciete punt‑ of serie‑opvulling is ingesteld, bepalen de diagramstijl en het thema de automatische weergave. Wanneer zowel serie‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Seriewaarden instellen met numerieke literals**

Gebruik numerieke literals wanneer seriewaarden afkomstig zijn uit toepassingsdata of berekeningen en geen verwijzingen naar werkbladcellen nodig hebben. Stel [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) in op [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) vóór het toewijzen van elke punt‑[value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) via [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

De collectiesetting bepaalt het brontype van alle puntwaarden in die serie. Elke punt‑[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) geeft het geselecteerde type weer; wijzig het via de collectiesetting. Met `WORKSHEET` gebruikt u [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) om de gerefereerde cel te benaderen. Met `DOUBLE_LITERALS` gebruikt u `as_literal_double` om het getal rechtstreeks te lezen of te schrijven.

Het volgende voorbeeld maakt een kolomdiagram met standaard series en categorieën, en kent vervolgens berekende waarden 10, 20, enz. toe aan de bestaande punten van de eerste serie. Het slaat de presentatie op, opent deze opnieuw en drukt de opgeslagen waarden af.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Het brontype van de puntwaarde staat los van [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), dat de interne of externe werkboekconfiguratie van het diagram identificeert. Het gebruik van numerieke literals verwijdert niet automatisch het ingebedde werkboek. In dit voorbeeld blijft het werkboek beschikbaar voor categorielabels, serienamen en de andere series. Zie [Diagramwerkboek](/slides/nl/python-net/chart-workbook/) voor beheer van werkboeken.

Voor spreidings‑ en bubbel‑diagrammen stelt u [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) en [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) in om de bronnen voor [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) en [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) te kiezen. Bubbel‑diagrammen gebruiken ook [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) voor [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Stel elke toepasselijke bron in op `DOUBLE_LITERALS` vóór het toewijzen van getallen via de eigenschap `as_literal_double` van die waarde.

## **Overlap van de diagramserie instellen**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van -100 tot 100 procent. Het is een alleen‑lezen projectie van de instelling op de bovenliggende serie‑groep. Stel [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) in om elke compatibele serie in die groep bij te werken. Deze optie is van toepassing op diagramtypen die gegroepeerde balken of kolommen tonen; hij heeft geen invloed op niet‑gerelateerde seriegroepen in een combinatiediagram.

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

Resultaat:

![The series overlap](series_overlap.png)

## **Kleur van de serie‑opvulling wijzigen**

Gebruik [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) om de standaardopvulling voor een hele serie in te stellen. Als een punt al een expliciete opvulling heeft, overschrijft de [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) instelling de serie‑opvulling voor dat punt.

Het volgende voorbeeld past een egale blauwe opvulling toe op de eerste serie:

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

Resultaat:

![The color of the series](series_color.png)

## **Naam van de serie wijzigen**

Een serienaam wordt opgeslagen in het diagram‑werkboek en wordt normaal weergegeven in de legenda. In het standaardwerkboek dat voor een gegroepeerd kolomdiagram wordt aangemaakt, bevindt cel B1 zich op rij 0, kolom 1 en bevat de naam van de eerste serie. De benoemde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel die al wordt gerefereerd door [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) bijwerken. Deze aanpak vermijdt aannames over een specifieke rij en kolom in een bestaand diagram:

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

Resultaat:

![The series name](series_name.png)

### **Een serie maken met een naam uit meerdere cellen**

Een samengestelde serienaam is handig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen zijn opgeslagen. Bijvoorbeeld, u kunt `Product A` in B1 en `2026` in C1 combineren tot één serienaam terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) om het naam‑bereik op te halen, en geef die collectie door aan [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Het argument `skip_hidden_cells` bepaalt of verborgen cellen worden meegenomen: `True` sluit ze uit, `False` neemt ze op. In dit voorbeeld wordt `False` gebruikt om elke cel in het naam‑bereik op te nemen.

Het volgende voorbeeld maakt een presentatie met één serie en twee datapunt‑waarden. Cellen B1:C1 leveren alleen de serienaam; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Deze twee cellen leveren de serienaam.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Aparte cellen leveren de categorieën en numerieke datapunten.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

De resulterende serienaam is `Product A 2026`, met een spatie tussen de twee celwaarden. De legenda toont dit als één invoer voor beide kolommen. De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatische serie‑opvulkleur ophalen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) retourneert de kleur die is berekend op basis van de serie‑index en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de serie‑opvulling niet expliciet is gedefinieerd. Het aanroepen van de methode leest de berekende kleur; het wijst geen nieuwe opvulling toe.

Het volgende voorbeeld drukt de automatische kleur van elke standaardserie af:

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

Voorbeeldoutput voor de standaarddiagramstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren hangen af van de diagramstijl en het thema.

## **Inversie‑opvulkleur voor een diagramserie instellen**

Voor balk‑, kolom‑ en bubbel‑series kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatieve waarden weergeven met een andere opvulling. Stel de reguliere serie‑opvulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen hun weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramgegevens door één serie. Werkblad‑rij 0 bevat de serienaam, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

Resultaat:

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). In het volgende voorbeeld is inversie uitgeschakeld voor de serie en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt ook een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke datapunt‑waarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `None`. Voor een kolomdiagram is de uitgeplotte waarde beschikbaar via [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Het datapunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de leeg‑waarde‑instellingen van het diagram.

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

Spreidingsdiagrammen gebruiken afzonderlijke X‑ en Y‑cellen, en bubbel‑diagrammen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk datapunt uit de collectie.

## **Weergave van lege cellen regelen**

Verborgen cellen die waarden bevatten vormen een apart geval ten opzichte van lege cellen. Zie [Gegevens opnemen uit verborgen rijen en kolommen](/slides/nl/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) voor het opnemen of uitsluiten van gegevens uit verborgen werkbladrijen en -kolommen.

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Stel [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) in op `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Hij verandert hoe leegtes worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één serie, wist de waarde voor Dag 3, en slaat hetzelfde diagram op in elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels en kolom 1 voor waarden; rij 0 bevat de serienaam. De uiteindelijke data zijn `10, 20, leeg, 30, 40`.

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

Elk uitvoerbestand bevat de modus die is toegekend vóór opslaan: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, kent u de gewenste modus toe en slaat u de presentatie één keer op in plaats van te itereren over de modi.

De vergelijking hieronder toont dezelfde data in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect hangt af van het diagramtype. Een lijndiagram maakt het gemakkelijk om alle drie de modi te vergelijken. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie heen te verbinden, dus `SPAN` kan het verbindingssegment niet produceren; een ontbrekende kolom en een nul‑hoogte kolom kunnen er ook op lijken. Evenzo heeft een spreidingsdiagram met alleen markers geen verbindingslijn. Verwacht niet drie verschillende resultaten voor elk diagramtype; controleer de output voor het type dat u gebruikt.

## **Gat‑breedte van de serie instellen**

Gat‑breedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlapping behoort deze instelling tot de bovenliggende serie‑groep in plaats van tot één serie. Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) één keer in voor de groep. Een hogere waarde creëert meer ruimte tussen clusters; een lagere waarde maakt ze dichter opeen.

Het volgende voorbeeld wijzigt de gat‑breedte en slaat alleen de uiteindelijke presentatie op:

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

Resultaat:

![The gap width](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen dataseries?**

Alle diagramtypen die worden weergegeven door de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie gebruiken diagramdata, maar hun series hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categorie‑diagrammen gebruiken categorieën en waarden, spreidings‑diagrammen gebruiken X‑ en Y‑waarden, en bubbel‑diagrammen voegen bubbelgroottes toe. Gebruik de datapunt‑aanmaakmethode die overeenkomt met het serietype. Opties zoals overlapping en gat‑breedte zijn alleen van toepassing op compatibele balk‑ of kolomgroepen.

**Wat is een diagram‑seriegroep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) bevat compatibele series die groeps‑niveau plotinstellingen delen. Een combinatiediagram kan meer dan één groep bevatten, dus het wijzigen van de groep die via één serie wordt bereikt, verandert niet per se elke serie in het diagram.

**Bevat een nieuw aangemaakt diagram standaarddata?**

Ja. Standaard maakt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) voorbeeld‑series, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de series‑ als categoricollecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaarddata creëren.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Serienamen, categorielabels en datapuntwaarden refereren naar cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste data opbouwt, houdt u de categorierijen en serie‑waardereeksen uitgelijnd zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe kan ik één punt wissen in plaats van de hele serie?**

Stel de betreffende waardecel in op `None` om de positie van het punt in de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die serie wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke serie bij zodat hun waarden blijven overeenkomen met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Ondersteunde diagrammen kunnen leegtes weergeven als gaten, als nul‑waarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie. Zie [Weergave van lege cellen regelen](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visuele vergelijking.

**Hoe worden negatieve waarden opgemaakt?**

Voor ondersteunde balk‑, kolom‑ en bubbel‑series schakelt u [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) in en stelt u [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) in. U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Deze eigenschappen beïnvloeden de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een serie als een punt zijn opgemaakt?**

Expliciete datapunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete serie‑opmaak gebruiken of, wanneer de serie‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepseigenschappen zoals overlapping en gat‑breedte regelen de lay‑out en zijn geen punt‑niveau opmaak‑overriding.

**Is er een limiet aan het aantal series dat een diagram kan bevatten?**

Aspose.Slides legt geen afzonderlijke vaste limiet op voor het aantal series. In de praktijk bepalen bestandsbeperkingen, beschikbaar geheugen, render‑tijd en leesbaarheid van het diagram een bruikbare limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver van elkaar staan?**

Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in op de betreffende bovenliggende serie‑groep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag hem om de clusters dichter bij elkaar te brengen.