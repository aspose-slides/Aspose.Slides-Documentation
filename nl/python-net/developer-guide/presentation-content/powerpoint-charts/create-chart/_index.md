---
title: Grafieken in PowerPoint‑presentaties maken of bijwerken in Python
linktitle: Grafieken maken of bijwerken
type: docs
weight: 10
url: /nl/python-net/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- spreidingsgrafiek
- taartgrafiek
- lijngrafiek
- boomkaartgrafiek
- aandelen‑grafiek
- box‑en‑whisker‑grafiek
- trechtergrafiek
- sunburst‑grafiek
- histogramgrafiek
- radargrafiek
- multi‑categorie‑grafiek
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas grafieken aan in PowerPoint‑presentaties met Aspose.Slides voor Python via .NET. Voeg grafieken toe, formatteer ze en bewerk ze met praktische code‑voorbeelden in Python."
---
## **Overzicht**

Dit artikel biedt een uitgebreide handleiding voor het maken en aanpassen van grafieken met Aspose.Slides voor Python via .NET. Je leert hoe je programmatically een grafiek toevoegt aan een dia, deze van gegevens voorziet en verschillende opmaakopties toepast om te voldoen aan je specifieke ontwerpvereisten. Door het artikel heen illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en grafiekobject tot het configureren van series, assen en legendes. Door deze gids te volgen krijg je een solide begrip van hoe je dynamische grafiekgeneratie integreert in je Python‑applicaties, waardoor het proces van het maken van data‑gedreven presentaties wordt gestroomlijnd.

## **Een grafiek maken**

Grafieken helpen mensen snel data te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn uit een tabel of spreadsheet.

**Waarom grafieken maken?**

Met grafieken kun je:

* grote hoeveelheden data aggregeren, comprimeren of samenvatten op één dia in een presentatie;
* patronen en trends in data blootleggen;
* de richting en momentum van data over tijd of ten opzichte van een specifieke meeteenheid afleiden;
* uitschieters, afwijkingen, fouten en onzinnige data opsporen;
* complexe data communiceren of presenteren.

In PowerPoint kun je grafieken maken via de *Insert*-functie, die sjablonen biedt voor het ontwerpen van vele grafiektype­n. Met Aspose.Slides kun je zowel reguliere grafieken (gebaseerd op populaire grafiektype­n) als aangepaste grafieken maken.

{{% alert color="info" title="Note" %}}
Gebruik de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑enumeratie onder de [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/)‑module. De waarden in deze enumeratie komen overeen met verschillende grafiektype­n.
{{% /alert %}}

### **Clustered Column‑grafieken maken**

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een clustered column‑grafiek te maken die twee series over drie categorieën vergelijkt. De series gebruiken rode en groene vullingen, en individuele labels tonen categorienamen, serienamen en waarden. Werkblad‑index 0 verwijst naar het eerste blad in de ingesloten grafiek‑werkmap.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De clustered column‑grafiek](clustered_column_chart.png)

### **Scatter‑grafieken maken**

Scatter‑grafieken (ook wel scatter‑plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te onderzoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een scatter‑grafiek wanneer:

* je gepaarde numerieke data hebt;
* je twee variabelen hebt die goed bij elkaar passen;
* je wilt bepalen of de twee variabelen gerelateerd zijn;
* je een onafhankelijke variabele hebt met meerdere waarden voor een afhankelijke variabele.

Dit voorbeeld plot twee sets x‑y‑waarden. De eerste serie gebruikt rechte lijnen met ster‑markers, terwijl de tweede vloeiende lijnen met cirkel‑markers gebruikt; beide gebruiken een [size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) van 10. De [symbol](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/)‑eigenschap bepaalt de marker‑vorm.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De scatter‑grafiek](scatter_chart.png)

### **Taartgrafieken maken**

Taartgrafieken zijn het meest geschikt om de deel‑tot‑geheel‑relatie in data te tonen, vooral wanneer de data categorische labels met numerieke waarden bevat. Als je data echter veel delen of labels bevat, kun je beter een staafgrafiek overwegen.

Dit voorbeeld maakt een taartgrafiek met drie kwartaalwaarden. Elk segment heeft een aangepaste vulling en rand, en de labels tonen verschillende combinaties van waarden, percentages en series‑informatie. De [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/)‑eigenschap zet de eerste sector op 180 graden.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De taartgrafiek](pie_chart.png)

Om de leesbaarheid van labels buiten de taart te verbeteren, zie [Format Leader Lines](/slides/nl/python-net/chart-data-label/#format-leader-lines) voor een voorbeeld dat labels positioneert en de kleur, breedte, transparantie en streep‑stijl van de lijnen aanpast.

### **Lijngrafieken maken**

Lijngrafieken (ook wel line‑graphs genoemd) zijn ideaal wanneer je veranderingen in waarde over tijd wilt aantonen. Met een lijngrafiek kun je veel data tegelijk vergelijken, veranderingen en trends over tijd volgen, afwijkingen in dataseries benadrukken, en meer.

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een lijngrafiek te maken met de standaard series en categorieën, en slaat vervolgens de presentatie op als PPTX.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Standaard worden punten op een lijngrafiek verbonden door rechte, continue lijnen. Als je wilt dat de punten worden verbonden door stippellijnen, stel dan [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) in op een waarde uit [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

Het resultaat:

![De lijngrafiek](line_chart.png)

### **Tree‑map‑grafieken maken**

Tree‑map‑grafieken zijn het meest geschikt voor verkoopdata wanneer je de relatieve grootte van datacategorieën wilt tonen en snel aandacht wilt vestigen op items die grote bijdragen leveren binnen elke categorie.

Dit voorbeeld maakt een tree‑map met acht bladeren gegroepeerd in vier stammen en twee takken. De [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/)‑methode wijst stammen toe op groeperingsniveau 1 en takken op niveau 2. Waarden bepalen de relatieve rechthoek‑groottes, terwijl categorielabels en overlappende bovenliggende labels de hiërarchie identificeren.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Tak 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Tak 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De tree‑map‑grafiek](treemap_chart.png)

### **Waterval‑grafieken maken**

Een waterval‑grafiek toont hoe positieve en negatieve veranderingen bijdragen aan een eindwaarde. Bijvoorbeeld, een winst‑opdeling kan beginnen met omzet, kosten aftrekken en andere inkomsten toevoegen. Veranderingskolommen zweven tussen de vorige en nieuwe lopende waarden, terwijl totaal‑kolommen van nul tot de geaccumuleerde waarde reiken.

Het volgende voorbeeld gebruikt bedragen in duizenden Amerikaanse dollars:

| Categorie | Werkbladwaarde | Kolomtype |
| --- | ---: | --- |
| Omzet | 1000 | Toename |
| Kosten van verkoop | -400 | Afneming |
| Brutowinst | 600 | Tussentotaal |
| Bedrijfskosten | -200 | Afneming |
| Overige inkomsten | 50 | Toename |
| Nettowinst | 450 | Eindtotaal |

Om een punt als tussentotaal of eindtotaal te markeren, stel je de [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/)‑eigenschap in op `True`. Geef het feitelijke geaccumuleerde bedrag op in de werkbladcel van dat punt: `600` voor brutowinst (`1000 - 400`) en `450` voor nettowinst (`600 - 200 + 50`). De eigenschap markeert de kolom als totaal; hij berekent of vult de celwaarde niet. Gebruik geen nul als tijdelijke aanduiding en voeg geen andere verandering toe voor een totaal‑punt. Een totaal‑kolom toont de geaccumuleerde waarde zonder deze opnieuw bij de lopende waarde op te tellen.

Dit volledige C#‑voorbeeld maakt een grafiek met het `Waterfall`‑lid van [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/), wist de standaarddata en vult de ingesloten werkmap. Werkblad‑index `0` selecteert het eerste werkblad; kolom A bevat categorienamen en kolom B bevat waarden. Elke waardecel wordt toegevoegd met [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/). De nul‑gebaseerde punt‑indices `2` en `5` identificeren respectievelijk de tussentotaal‑ en eindtotaal‑punten. Het inschakelen van [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) toont de bedragen op de kolommen. Er is geen invoerpresentatie of werkmap vereist.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # De derde en zesde punten vertegenwoordigen totalen, geen extra wijzigingen.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

Stel de series‑niveau‑eigenschap [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) in op `True` om lijnen te tonen die opeenvolgende kolommen verbinden en de lopende waarde beter volgbaar maken. Om deze lijnen te verbergen, vervang je de toewijzing in het voorbeeld door `series.show_connector_lines = False` vóór het opslaan. Dit wijzigt alleen de zichtbaarheid van de lijnen, niet de data of totalen.

De opgeslagen presentatie toont een brutowinst van 600 en een nettowinst van 450, waarbij beide totalen uit nul worden getekend:

![Waterval‑grafiek met omzet, kosten, brutowinst van 600 en nettowinst van 450, met waardelabels en verbindinglijnen](waterfall_chart.png)

### **Aandelen‑grafieken maken**

Aandelen‑grafieken worden gebruikt om financiële data zoals open, high, low en close prijzen weer te geven, waardoor markttrends en volatiliteit geanalyseerd kunnen worden. Ze bieden essentiële inzichten in de aandelenprestaties en helpen beleggers en analisten weloverwogen beslissingen te nemen.

Dit voorbeeld maakt een open‑high‑low‑close‑grafiek met vier series in die volgorde en drie categorieën. De [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/)‑eigenschap schakelt up/down‑bars in, en [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) regelt de high‑low‑lijnen die de prijsbereiken tonen, terwijl de individuele series‑lijnen en kleine horizontale rasterlijnen verborgen blijven.

De [up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/up_down_bars/)‑manager biedt aparte [up_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/up_bars_format/)‑ en [down_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/down_bars_format/)‑objecten. Gebruik de [fill](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/fill/)‑ en [line](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/line/)‑eigenschappen van elk object om de vulling en contour onafhankelijk in te stellen. Dit voorbeeld gebruikt groene balken met donker‑groene contouren voor stijgende intervallen en oranje‑rode balken met donker‑rode contouren voor dalende intervallen.

Voor elke categorie moet je numerieke waarden opgeven voor alle vier series, waarbij High en Low Open en Close omsluiten. De balken vergelijken Close met Open **binnen dezelfde categorie**, niet met de vorige categorie: A daalt van 72 naar 25, terwijl B stijgt van 25 naar 38 en C stijgt van 38 naar 50. Gelijke Open‑ en Close‑waarden geven geen zichtbaar gevuld interval. Up/down‑bars beslaan Open‑Close; high‑low‑lijnen beslaan Low‑High. Deze balken behoren tot de series‑groep en zijn geen gewone staaf‑grafiek‑series.

Deze opmaak werkt ook met [LINE and LINE_WITH_MARKERS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑grafieken die minstens twee series in dezelfde groep bevatten en bijbehorende numerieke waarden per categorie hebben. Voor deze niet‑gestapelde lijngrafieken vergelijken up/down‑bars de eerste en laatste serie: een hoger laatste punt geeft een up‑bar, een lager laatste punt een down‑bar. Het omkeren van die series keert de classificatie om. Het onderstaande voorbeeld gebruikt [OPEN_HIGH_LOW_CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/); ga er niet van uit dat andere stock‑, stacked‑line‑ of 3D‑varianten dezelfde gegevensindeling of intervalinterpretatie hanteren.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 150, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    up_down_bars = chart.chart_data.series_groups[0].up_down_bars
    up_down_bars.has_up_down_bars = True

    up_down_bars.up_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.fill.solid_fill_color.color = draw.Color.lime_green
    up_down_bars.up_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_green
    up_down_bars.up_bars_format.line.width = 2

    up_down_bars.down_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.fill.solid_fill_color.color = draw.Color.orange_red
    up_down_bars.down_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_red
    up_down_bars.down_bars_format.line.width = 2
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat, geëxporteerd uit PowerPoint:

![Aandelen‑grafiek met een oranje‑rode dalende interval voor A en groene stijgende intervallen voor B en C](stock_chart.png)

### **Box‑en‑whisker‑grafieken maken**

Box‑en‑whisker‑grafieken worden gebruikt om de verdeling van data weer te geven door belangrijke statistische maten te samenvatten, zoals de mediaan, kwartielen en mogelijke uitschieters. Ze zijn bijzonder nuttig in verkennende data‑analyse en statistische studies om snel variabiliteit te begrijpen en eventuele anomalieën te identificeren.

Dit voorbeeld maakt een box‑en‑whisker‑grafiek van zes waarden. De [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/)‑eigenschap kiest de exclusieve kwartiel‑berekening. Het voorbeeld schakelt ook gemiddelde‑lijnen, gemiddelde‑markers, interne punten en uitschieter‑punten in.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **Funnel‑grafieken maken**

Funnel‑grafieken visualiseren processen met opeenvolgende fasen, waarbij het volume data afneemt naarmate het van de ene stap naar de volgende gaat. Ze zijn zeer nuttig voor het analyseren van conversieratio’s, het identificeren van knelpunten en het volgen van de efficiëntie van verkoop‑ of marketingprocessen.

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een funnel‑grafiek toe te voegen aan de eerste dia van een bestaande presentatie. Het vervangt de standaarddata door zes categorieën en waarden variërend van 50 tot 500, en slaat vervolgens de bijgewerkte presentatie op. De invoerpresentatie moet minstens één dia bevatten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De funnel‑grafiek](funnel_chart.png)

### **Sunburst‑grafieken maken**

Sunburst‑grafieken visualiseren hiërarchische data door niveaus als concentrische ringen weer te geven. Ze helpen deel‑tot‑geheel‑relaties te illustreren en zijn ideaal voor het weergeven van geneste categorieën en subcategorieën in een duidelijk, compact formaat.

Dit voorbeeld maakt een sunburst‑grafiek met acht bladeren gegroepeerd in vier stammen en twee takken. De [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/)‑methode wijst stammen toe op groeperingsniveau 1 en takken op niveau 2. Categorielabels identificeren de segmenten en de waarden bepalen hun relatieve grootte.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Tak 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # Tak 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De sunburst‑grafiek](sunburst_chart.png)

### **Histogram‑grafieken maken**

Histogram‑grafieken tonen hoe numerieke waarden verdeeld zijn over intervallen (bins). Voor maandelijkse rapporten over verwerkingstijden van bestellingen kun je dezelfde bin‑breedte en drempels hanteren om intervallen consistent te houden en verdelingen makkelijker te vergelijken.

Stel de horizontale as‑[aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) in op een modus uit [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/). [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) werkt alleen bij `BY_BIN_WIDTH`; [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) werkt alleen bij `BY_NUMBER_OF_BINS`. Gebruik `AUTOMATIC` om de grafiek de bins te laten bepalen.

#### **Vaste bin‑breedte gebruiken**

Dit voorbeeld groepeert verwerkingstijden in 10‑minuten‑intervallen, met aparte bins voor tijden ≤ 10 minuten en > 40 minuten. Schakel deze bins in met [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) en [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/). Wanneer je expliciete [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/)‑ en [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/)‑drempels opgeeft, stel dan [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) en [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) in op `False`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```

De presentatie in PowerPoint toont bin‑aantallen van **3, 4, 4, 4 en 2**. De underflow‑bin bevat `5, 10, 10`, dus de drempel is inclusief. De overflow‑bin bevat alleen `41, 50`, dus de drempel is exclusief; beide waarden gelijk aan `40` blijven in het voorgaande interval. De binnenste bins bevatten waarden groter dan hun ondergrens en kleiner of gelijk aan hun bovengrens.

![Histogram met 10‑minuten‑bins en expliciete under‑ en overflow‑drempels](histogram_bin_width.png)

#### **Aantal bins specificeren**

Voor een vaste detail‑graad in plaats van vaste intervallen, vraag je vijf bins aan voor dezelfde data. Dit voorbeeld laat under‑ en overflow‑bins uitgeschakeld. De grafiek bepaalt de breedte uit het gegevensbereik, zodat grenzen kunnen veranderen tussen rapporten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```

De vijf bins hebben aantallen van **4, 4, 4, 4 en 1**. Vergelijk deze verdeling met het resultaat van vaste breedte hierboven: de invoerwaarden zijn identiek, maar de grenzen verschillen.

![Histogram met vijf bins berekend uit dezelfde data](histogram_bin_count.png)

### **Radar‑grafieken maken**

Radar‑grafieken tonen multivariate data in een tweedimensionaal formaat, waardoor meerdere variabelen tegelijk gemakkelijk te vergelijken zijn. Ze zijn bijzonder nuttig om patronen, sterktes en zwaktes over verschillende prestatiemetrics of attributen te identificeren.

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een radar‑grafiek te maken met de standaard series en categorieën, en slaat vervolgens de presentatie op als PPTX.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De radar‑grafiek](radar_chart.png)

### **Multi‑category‑grafieken maken**

Multi‑category‑grafieken tonen data die meer dan één categorische groepering omvatten, zodat je waarden over meerdere dimensies tegelijk kunt vergelijken. Ze zijn vooral nuttig wanneer je trends en relaties binnen complexe, meerlagige datasets moet analyseren.

Dit voorbeeld maakt een clustered column‑grafiek met acht categorieën verdeeld over vier paren. De [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/)‑methode geeft elk paar een gedeeld label op groeperingsniveau 1, wat resulteert in een categorische as met zowel individuele als groepslabels.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De multi‑category‑grafiek](multi_category_chart.png)

#### **Een kwartaal‑label verwijderen**

Download [quarters.pptx](quarters.pptx) en plaats het in de werkmap. De grafiek toont negen maanden en één verkoop‑serie met waarden van 10 tot 18. De categorische as heeft drie kwartaal‑labels: Q1 beslaat jan‑mrt, Q2 apr‑jun, en Q3 jul‑sep.

April is de vierde categorie en degene waarvoor Q2 expliciet werd ingesteld. Roep [delete_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/delete_grouping_item/) aan op April's [grouping_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/grouping_levels/)‑collectie. Het niveau is relatief ten opzichte van april: niveau 1 is het kwartaal, niveau 0 is de maand zelf. De methode kan de blad‑categorie op niveau 0 niet verwijderen.

```python
import aspose.slides as slides

with slides.Presentation("quarters.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    april = chart.chart_data.categories[3]
    april.grouping_levels.delete_grouping_item(1)
    
    presentation.save("quarters-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("quarters-updated.pptx") as reopened:
    data = reopened.slides[0].shapes[0].chart_data
    print(", ".join(str(month.as_cell.value) for month in data.categories))
    print(", ".join(str(point.value.data) for point in data.series[0].data_points))
```

De heropende grafiek print de oorspronkelijke maanden (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) en verkoopwaarden (`10, 11, 12, 13, 14, 15, 16, 17, 18`) in dezelfde volgorde. Open `quarters-updated.pptx` in PowerPoint om de as‑labels te vergelijken. Het Q2‑label en de groepsgrens vóór april verdwijnen, zodat Q1 van januari tot en met juni loopt. Q3 begint nog steeds in juli.

![Kwartaal‑labels voor en na verwijdering. Links bestrijkt Q2 april‑tot‑juni. Rechts bestrijkt Q1 januari‑tot‑juni.](quarter-label-comparison.png)

### **Kaart‑grafieken maken**

Kaart‑grafieken visualiseren geografische data door informatie te verbinden met specifieke locaties zoals landen, provincies of steden. Ze zijn vooral nuttig voor het analyseren van regionale trends, demografische data en ruimtelijke verdelingen in een duidelijke, visueel aantrekkelijke vorm.

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een kaart‑grafiek te maken met de standaard geografische data en slaat deze op voor weergave in PowerPoint.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De kaart‑grafiek](map_chart.png)

{{% alert color="info" title="Note" %}}
Afbeelding hierboven toont de opgeslagen presentatie geopend in PowerPoint. Aspose.Slides schrijft de kaart‑grafiek en de data correct, maar tekent zelf geen kaart‑grafieken: wanneer een dia die er één bevat wordt gerenderd naar een afbeelding of geconverteerd naar PDF of SVG, blijft het grafiekgebied leeg. Andere vormen op dezelfde dia blijven onveranderd.
{{% /alert %}}

### **Combinatie‑grafieken maken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiek‑type­n in één afbeelding. Deze grafiek laat je toe om verschillen tussen twee of meer data‑sets te accentueren, vergelijken of onderzoeken, waardoor relaties tussen hen duidelijker worden.

![De combinatie‑grafiek](combination_chart.png)

Dit voorbeeld combineert twee clustered column‑series met een lijn‑serie over vier categorieën. De kolommen gebruiken de primaire verticale as, terwijl [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) de lijn op een secundaire verticale as aan de rechterkant plaatst. De hulpfuncties configureren de titel, legenda, as‑labels en rasterlijnen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **Grafieken bijwerken**

Aspose.Slides voor Python via .NET stelt je in staat om PowerPoint‑grafieken bij te werken door grafiek‑data, opmaak en stijl te wijzigen. Deze functionaliteit vereenvoudigt het up‑daten van presentaties met dynamische inhoud en zorgt ervoor dat grafieken nauwkeurig de huidige data en visuele standaarden weerspiegelen.

Dit voorbeeld werkt de grafiek met de naam "My chart" op de eerste dia van een bestaande presentatie bij. Het vereist twee kolom‑series met elk drie datapunten, met categorielabels in kolom A en serienamen in de eerste rij van het eerste werkblad. Het voorbeeld gebruikt [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) om werkbladcellen te wijzigen, werkt series‑waarden bij, voegt een derde serie toe, en verandert de grafiek naar clustered cylinders via [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **Gegevensbereik voor een grafiek instellen**

Om het bereik dat al door een bestaande grafiek wordt gebruikt te inspecteren, zie [Retrieve a Chart's Data Range](/slides/nl/python-net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides voor Python via .NET biedt de flexibiliteit om een specifiek gegevensbereik uit een werkblad als bron voor je grafiek‑data te definiëren. Dit betekent dat je direct een gedeelte van je werkblad kunt mappen naar de grafiek, waardoor je kunt bepalen welke cellen bijdragen aan de series en categorieën van de grafiek. Als gevolg kun je je grafieken gemakkelijk updaten en synchroniseren met de laatste wijzigingen in je werkblad, zodat je PowerPoint‑presentaties actuele en nauwkeurige informatie weergeven.

Dit voorbeeld gebruikt [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) om de gegevensbron van de grafiek met de naam "My chart" op de eerste dia van een bestaande presentatie in te stellen op `Sheet1!A1:B4`. De grafiek‑werkmap moet dat werkblad en een gevulde range bevatten met een series‑kop in de eerste rij, categorielabels in kolom A en drie waarden in kolom B.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaard‑markers in grafieken gebruiken**

Wanneer je standaard‑markers in grafieken gebruikt, krijgt elke grafiek‑serie automatisch een ander standaard‑marker‑symbool toegewezen.

Dit voorbeeld gebruikt [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) om een grafiek te maken met twee lijn‑series en een legenda. De [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/)‑instellingen behouden de automatisch toegewezen marker‑symbolen. De eerste serie bevat een negatieve waarde en een ontbrekende waarde, weergegeven door `None`, terwijl de tweede een waarde heeft voor elke categorie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Welke grafiek‑type­n worden ondersteund door Aspose.Slides voor Python via .NET?**

Aspose.Slides voor Python via .NET ondersteunt een breed scala aan grafiek‑type­n, waaronder staaf, lijn, taart, gebied, scatter, histogram, radar en vele meer. Deze flexibiliteit stelt je in staat het meest geschikte grafiek‑type te kiezen voor je data‑visualisatie‑behoeften.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑klasse, haal je de gewenste dia op via zijn index, en roep je vervolgens de methode aan om een grafiek toe te voegen, waarbij je het grafiek‑type en de initiële data opgeeft. Dit proces integreert de grafiek direct in je presentatie.

**Hoe kan ik de weergegeven data in een grafiek bijwerken?**

Je kunt de data van een grafiek bijwerken door toegang te krijgen tot de data‑werkmap ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), eventuele standaard series en categorieën te wissen, en vervolgens je eigen data toe te voegen. Hiermee kun je de grafiek programmatically verversen zodat deze de nieuwste data weergeeft.

**Is het mogelijk om het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides voor Python via .NET biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legendes en andere opmaakelementen wijzigen om het uiterlijk van de grafiek af te stemmen op je specifieke ontwerpvereisten.

Gerelateerde functie: [Create editable charts](/slides/nl/features/create-charts/).