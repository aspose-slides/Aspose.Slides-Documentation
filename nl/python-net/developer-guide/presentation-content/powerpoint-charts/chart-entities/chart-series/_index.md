---
title: Beheer diagramreeksen in presentaties met Python
linktitle: Gegevensreeksen
type: docs
url: /nl/python-net/chart-series/
keywords:
  - grafiekreeks
  - reeks overlap
  - reeks kleur
  - categorie kleur
  - reeksnaam
  - gegevenspunt
  - reeks gat
  - PowerPoint
  - presentatie
  - Python
  - Aspose.Slides
description: "Leer hoe u grafiekreeksen, gegevenspunten, werkboekcellen, opmaak, overlap, gatbreedte en negatieve waarden in presentaties kunt beheren met Python."
---
## **Overzicht**

Een diagram slaat zijn weergegeven gegevens op in een diagramdataboek. Een [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) vertegenwoordigt één set gerelateerde waarden, en elke [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) in de reeks verwijst naar één of meer cellen in het werkboek. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/)‑objecten leveren de labels of groepeeringswaarden die door de reeksen worden gedeeld. De reeksnaam, categorieën en puntwaarden zijn daarom gekoppeld aan [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)‑objecten in plaats van alleen als weergavetekst opgeslagen te worden.

Voor een typisch categoriediagram gebruikt het standaardwerkboek rij 0 voor reeksnamen, kolom 0 voor categorienamen en de overige cellen voor reekswerte. Werkblad‑, rij‑ en kolom‑indexen die aan [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) worden doorgegeven, zijn nul‑gebaseerd. Deze indeling is handig wanneer u een diagram met standaardgegevens maakt, maar ga niet uit van het feit dat elk bestaand diagram dit gebruikt. Voor een geladen presentatie dient u de cellen die door de reeksen, categorieën en gegevenspunten worden gerefereerd te inspecteren voordat u werkboekwaarden wijzigt.

Diagraminstellingen hebben drie verschillende scopes:

- Instellingen op reeksniveau, zoals [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), bieden de standaardopmaak voor alle punten in één reeks.
- Instellingen per gegevenspunt, zoals [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), overschrijven de reeksopmaak voor één punt.
- Groepsinstellingen gelden voor compatibele reeksen die behoren tot dezelfde [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Toegang tot de groep via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) wanneer u opties wilt instellen zoals overlap of gatbreedte.

Wanneer er geen expliciete punt‑ of reeksvulling is ingesteld, bepalen de diagramstijl en het thema het automatische uiterlijk. Wanneer zowel reeks‑ als punt‑opmaak aanwezig zijn, heeft de punt‑opmaak voorrang voor dat punt.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Overlap van de grafiekserie instellen**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) geeft aan hoeveel balken of kolommen overlappen in een 2D‑diagram, van –100 tot 100 percent. Het is een uitsluitend‑lezen projectie van de instelling op de bovenliggende reeksgroep. Stel [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) in om elke compatibele reeks in die groep bij te werken. Deze optie geldt voor diagramtypen die gegroepeerde balken of kolommen weergeven; hij heeft geen invloed op niet‑gerelateerde reeksgroepen in een gecombineerde diagram.

Het volgende voorbeeld stelt de overlap in voor de groep die de eerste reeks bevat:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Het nieuwe diagram bevat voorbeeldreeksen, categorieën en waarden.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![The series overlap](series_overlap.png)

## **De vullingkleur van de reeks wijzigen**

Gebruik [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) om de standaardvulling voor een volledige reeks in te stellen. Als een punt al een expliciete vulling heeft, overschrijft de [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)‑instelling de reeksvulling voor dat punt.

Het volgende voorbeeld past een effen blauwe vulling toe op de eerste reeks:

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

![The color of the series](series_color.png)

## **De reeksnaam wijzigen**

Een reeksnamen wordt opgeslagen in het diagramdataboek en wordt normaal weergegeven in de legende. In het standaardwerkboek dat wordt aangemaakt voor een gegroepeerde kolomdiagram, staat cel B1 op rij 0, kolom 1 en bevat de naam van de eerste reeks. De genummerde constanten in het volgende voorbeeld maken die structuur expliciet:

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

U kunt ook de cel bijwerken die al wordt gerefereerd door [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Deze aanpak voorkomt dat u gaat uit van een bepaalde rij en kolom in een bestaand diagram:

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

![The series name](series_name.png)

### **Een reeks met een naam uit meerdere cellen maken**

Een samengestelde reeksnamen is nuttig wanneer een productnaam en een rapportageperiode in afzonderlijke werkboekcellen staan. U kunt bijvoorbeeld `Product A` in B1 en `2026` in C1 combineren tot één reeksnamen, terwijl beide delen gekoppeld blijven aan hun broncellen.

Gebruik [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) om het naamgebied op te halen, en geef die collectie vervolgens door aan [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Het argument `skip_hidden_cells` bepaalt of verborgen cellen worden meegenomen: `True` sluit ze uit, `False` neemt ze op. Dit voorbeeld gebruikt `False` om elke cel in het naamgebied op te nemen.

Het volgende voorbeeld maakt een presentatie met één reeks en twee gegevenspunten. Cellen B1:C1 leveren alleen de reeksnamen; A2:A3 leveren de categorielabels, en B2:B3 leveren de numerieke waarden.

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

    # Deze twee cellen leveren de reeksnaam.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Aparte cellen leveren de categorieën en numerieke gegevenspunten.
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

De resulterende reeksnamen is `Product A 2026`, met een spatie tussen de twee celwaarden. De legende toont dit als één invoer voor beide kolommen. De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **De automatische vullingkleur van de reeks ophalen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) retourneert de kleur die berekend wordt op basis van de reeksindex en de diagramstijl. Dit is de kleur die wordt gebruikt wanneer de reeksvulling niet expliciet gedefinieerd is. Het aanroepen van de methode leest de berekende kleur; het kent geen nieuwe vulling toe.

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

Voorbeelduitvoer voor de standaarddiagramstijl:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exacte kleuren zijn afhankelijk van de diagramstijl en het thema.

## **Omgekeerde vullingkleur voor een grafiekreeks instellen**

Voor balk‑, kolom‑ en bubbelformules kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatieve waarden met een andere vulling weergeven. Stel de gewone reeksvulling in op effen, schakel inversie in, en wijs de negatieve‑waarde‑kleur toe via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negatieve getallen blijven ongewijzigd in het werkboek; alleen de weergavekleur verandert.

Het volgende voorbeeld vervangt de standaarddiagramdata door één reeks. Werkblad‑rij 0 bevat de reeksnamen, kolom 0 bevat categorienamen, en kolom 1 bevat de waarden:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

U kunt inversie voor één punt inschakelen via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). In het volgende voorbeeld is inversie uitgeschakeld voor de reeks en alleen ingeschakeld voor het geselecteerde punt. Het punt krijgt bovendien een negatieve waarde zodat het effect zichtbaar is:

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

## **Een specifieke gegevenspuntwaarde wissen**

Om één punt leeg te maken zonder de andere punten te verwijderen, stelt u de onderliggende werkboekcel in op `None`. Voor een kolomdiagram is de weergegeven waarde beschikbaar via [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Het gegevenspunt blijft op dezelfde categorielocatie, maar het diagram behandelt de waarde als leeg volgens de instellingen voor lege waarden van het diagram.

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

Spreidingsdiagrammen gebruiken aparte X‑ en Y‑cellen, en bellen gebruiken ook een grootte‑cel. Wis alleen de cel die de waarde vertegenwoordigt die u wilt verwijderen. Roep niet [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) aan wanneer u de andere punten wilt behouden, want die methode verwijdert elk gegevenspunt uit de collectie.

## **Weergave van lege cellen beheren**

Verborgen cellen die waarden bevatten vormen een aparte situatie ten opzichte van lege cellen. Om gegevens uit verborgen rijen en kolommen op te nemen of uit te sluiten, zie [Include Data from Hidden Rows and Columns](/slides/nl/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Een lege werkboekcel staat voor ontbrekende gegevens; een cel met `0` staat voor een bekende numerieke waarde. Stel [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) in op `None` om een cel leeg te maken. Een numerieke nul blijft een nul, ongeacht de instelling voor lege cellen.

Gebruik [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) om te kiezen hoe het diagram lege cellen weergeeft. Deze instelling geldt voor het hele diagram. Hij verandert hoe lege plekken worden geplot, zonder de lege werkboekcel te vullen met nul of een geïnterpoleerde waarde.

Het volgende zelfstandige voorbeeld maakt een lijndiagram met één reeks, wist de waarde voor Dag 3, en slaat hetzelfde diagram op met elke modus. Er is geen invoerbestand vereist. De [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) gebruikt werkblad 0, kolom 0 voor categorielabels, en kolom 1 voor waarden; rij 0 bevat de reeksnamen. De uiteindelijke gegevens zijn `10, 20, empty, 30, 40`.

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

    # Laat Dag 3 echt leeg, terwijl de categorie en het gegevenspunt behouden blijven.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Elk uitvoerbestand slaat de modus op die vóór het opslaan is ingesteld: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` en `empty_cells_Span.pptx`. Om slechts één versie op te slaan, stelt u de gewenste modus in en slaat u de presentatie één keer op in plaats van over de modi te itereren.

De vergelijking hieronder toont dezelfde gegevens in alle drie de bestanden. Dag 3 is in elk geval leeg in het werkboek:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Het zichtbare effect is afhankelijk van het diagramtype. Een lijndiagram maakt het vergelijken van alle drie de modi eenvoudig. Balk‑ en kolomdiagrammen hebben geen lijn om over een ontbrekende categorie te verbinden, dus `SPAN` kan niet het verbindingssegment produceren dat hierboven wordt getoond; een ontbrekende kolom en een kolom met nulhoogte kunnen er ook op lijken. Evenzo heeft een spreidingsdiagram met alleen markers geen verbindingslijn. Verwacht niet dat elke diagramtype drie verschillende resultaten oplevert; controleer de uitvoer voor het type dat u gebruikt.

## **Gatbreedte van de reeks instellen**

Gatbreedte is de ruimte tussen aangrenzende balk‑ of kolomclusters, uitgedrukt als een percentage van de balk‑ of kolombreedte. Net als overlap behoort hij tot de bovenliggende reeksgroep en niet tot één enkele reeks. Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) één keer in voor de groep. Een grotere waarde creëert meer ruimte tussen clusters; een kleinere waarde maakt ze dichter bij elkaar.

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

![The gap width](gap_width.png)

## **FAQ**

**Welke diagramtypen ondersteunen gegevensreeksen?**

Alle diagramtypen die worden vertegenwoordigd door de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie gebruiken diagramdata, maar hun reeksen hebben niet allemaal dezelfde waardestructuur of instellingen. Bijvoorbeeld, categoriendiagrammen gebruiken categorieën en waarden, spreidingsdiagrammen gebruiken X‑ en Y‑waarden, en bellen voegen bubbelaantallen toe. Gebruik de gegevenspunt‑creatiemethode die overeenkomt met het type reeks. Opties zoals overlap en gatbreedte gelden alleen voor compatibele balk‑ of kolomgroepen.

**Wat is een grafiekreeks‑groep?**

Een [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) bevat compatibele reeksen die groeps‑niveau plotinstellingen delen. Een gecombineerde diagram kan meer dan één groep bevatten, zodat het wijzigen van de groep die via één reeks wordt bereikt niet per se alle reeksen in het diagram wijzigt.

**Bevat een nieuw aangemaakt diagram standaardgegevens?**

Ja. Standaard maakt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) voorbeeldreeksen, -categorieën en -waarden aan. U kunt die cellen bewerken of zowel de reeks‑ als de categoricollecties wissen voordat u een volledig aangepaste dataset toevoegt. Een overload kan ook een diagram zonder standaardgegevens aanmaken.

**Hoe zijn diagramobjecten gekoppeld aan werkboekcellen?**

Reeksnamen, categorielabels en gegevenspuntwaarden refereren cellen in een [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Het wijzigen van een gerefereerde cel werkt het overeenkomstige diagramonderdeel bij. Wanneer u aangepaste data opbouwt, houdt u de categorierijen en reeks‑waardrijen op één lijn zodat elk punt onder de beoogde categorie wordt geplot.

**Hoe wis ik één punt in plaats van de hele reeks?**

Stel de relevante waardecel in op `None` om de positie van het punt binnen de categorie te behouden als een leeg punt. Gebruik [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) alleen wanneer u alle punten uit die reeks wilt verwijderen. Als u ook categorieën verwijdert, werk dan elke reeks bij zodat hun waarden blijven overeenstemmen met de categoricollectie.

**Hoe worden lege punten weergegeven?**

Het resultaat hangt af van het diagramtype en [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Ondersteunde diagrammen kunnen lege waarden weergeven als gaten, als nulwaarden, of door naburige punten te verbinden. Kies de instelling die past bij de betekenis van ontbrekende gegevens in uw presentatie. Zie [Control the Display of Empty Cells](#control-the-display-of-empty-cells) voor een volledig voorbeeld en visueel vergelijk.

**Hoe worden negatieve waarden geformatteerd?**

Voor ondersteunde balk‑, kolom‑ en bubbelformules kunt u [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) activeren en [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) instellen. U kunt het gedrag voor een individueel punt overschrijven met [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Deze eigenschappen beïnvloeden alleen de opmaak, niet de opgeslagen numerieke waarden.

**Welke opmaak heeft voorrang wanneer zowel een reeks als een punt zijn opgemaakt?**

Expliciete gegevenspunt‑opmaak heeft voorrang voor dat punt. Andere punten blijven de expliciete reeks‑opmaak gebruiken of, wanneer de reeks‑opmaak niet gedefinieerd is, de automatische diagramstijl en het thema. Groepseigenschappen zoals overlap en gatbreedte regelen de lay‑out en zijn geen overrides op puntniveau.

**Is er een limiet aan het aantal reeksen dat een diagram kan bevatten?**

Aspose.Slides stelt geen apart vaste limiet voor het aantal reeksen. In de praktijk bepalen bestands‑beperkingen van de presentatie, beschikbaar geheugen, render‑tijd en de leesbaarheid van het diagram een praktische limiet.

**Wat moet ik aanpassen wanneer kolommen te dicht bij elkaar of te ver uit elkaar staan?**

Stel [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in op de juiste bovenliggende reeksgroep. Verhoog de waarde om de ruimte tussen clusters te vergroten, of verlaag hem om de clusters dichter bij elkaar te brengen.