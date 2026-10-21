---
title: Beheer grafiekdatatags in presentaties met Python
linktitle: Gegevenslabel
type: docs
url: /nl/python-net/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekdatatags kunt toevoegen en opmaken in PowerPoint‑presentaties met Aspose.Slides voor Python via .NET voor boeiendere dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekseries en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek beter begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, labels buiten de asmaximum kunt beheren, de afstand tussen categorieaslabels kunt aanpassen en taartgrafieklabels kunt positioneren.

## **Precisie van gegevens instellen in grafiekdatatags**

Gebruik [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) om serieswaarden op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waarde‑labels in voor de eerste serie. Het format `#,##0.00` geeft een duizendtallen‑scheidingsteken en twee decimalen weer zonder de onderliggende waarden te wijzigen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

Om de numerieke cellen in het ingesloten werkboek van een grafiek op te maken, zie [Set Custom Number Formats for Workbook Cells](/slides/nl/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells). Dat voorbeeld toont ook waarde‑labels die de opmaak van hun broncellen volgen, terwijl de opgeslagen numerieke waarden behouden blijven.

## **Percentage weergeven als labels**

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het totaalaantal van de categorie en kent u de tekst toe aan [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Percentage‑teken instellen met grafiekdatatags**

Wanneer waarden als breuken zijn opgeslagen, gebruik dan [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) . Stel [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) in op `False` om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100% gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0,30 als 30,0%, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst van 10 punten.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **De feitelijke tekst van datalabels uitlezen**

Gebruik [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) om de tekst te verkrijgen die door de instellingen van een datalabel wordt gegenereerd. Dit is handig bij het extraheren van labels voor rapporten, zoeken in presentatie‑inhoud of valideren van gegenereerde grafieken. In het voorbeeld hieronder combineert de standaard [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst van [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Het getal dat in een datapunten is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` toont samen met de categorie‑ en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) retourneert in beide gevallen de resulterende label‑string. Controleer [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) afzonderlijk, zoals hierboven getoond, wanneer u uitsluitend zichtbare labels wilt extraheren.

## **Data‑labels buiten de asmaximum beheren**

Wanneer u handmatig een asbereik beperkt, kunnen sommige gegevenspunten de maximumwaarde overschrijden. Gebruik [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) om te bepalen of hun datalabels worden weergegeven. Deze instelling wijzigt de zichtbaarheid van labels; ze verandert de aslimiet of de onderliggende gegevenswaarden niet.

Het voorbeeld hieronder maakt een 2D gegroepeerde kolomgrafiek met waarden van 60 en 120. Het stelt [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) in op `False` en [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) op 100 voor de verticale as. De eerste dia staat labels toe die de maximumwaarde overschrijden; een kopie van die dia schakelt ze uit. Beide dia’s worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waarde‑labels in met [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). De instelling op grafiekniveau activeert niet automatisch de weergave van waarden en overschrijft geen individuele labelinstelling. Dit voorbeeld activeert waarden voor de volledige serie en gebruikt [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) om labels aan het buitenste uiteinde van elke kolom te plaatsen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

De onderstaande afbeeldingen tonen de opgeslagen dia’s zoals gerenderd door Microsoft PowerPoint. Met `True` is het label **120** zichtbaar aan de bovengrens; met `False` is het verborgen. Het label **60** blijft zichtbaar, de asmaximum blijft **100**, en het tweede gegevenspunt blijft in beide gevallen **120**.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutsgrafieken, hebben geen asmaximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand vanaf een as instellen**

Gebruik [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) om de afstand tussen categorieas‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de aslabels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt categorieas‑labels in plaats van labels die aan individuele gegevenspunten zijn gekoppeld.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Labellocatie aanpassen**

Op een taartgrafiek past u de positie van datalabels aan om de afstand te verbeteren en ruimte te maken voor leidlijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de sector en past de [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ en [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑offsets aan. Deze offsets zijn respectievelijk relatief ten opzichte van de grafiek‑breedte en -hoogte.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Taartgrafiek met een aangepaste labelpositie](pie-chart-adjusted-label.png)

## **Leidlijnen opmaken**

Wanneer datalabels van een taartgrafiek buiten hun sectoren staan, helpen leidlijnen de lezer elke waarde aan de juiste sector te koppelen. Een contrasterende kleur en een iets dikkere lijn kunnen deze verbindingen makkelijker leesbaar maken, terwijl transparantie en een gestreepte stijl de lijnen visueel onopvallend houden.

Gebruik [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) om leidlijnen te formatteren op het niveau van de series‑datalabel‑collectie. De instellingen in `series.labels.leader_lines_format.line` gelden voor de collectie, niet voor een individueel label.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens, toont waarden buiten de sectoren en schakelt [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) in. Het verplaatst twee labels verder van hun sectoren met behulp van [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) en [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) offsets, uitgedrukt als fracties van de grafiekbreedte en -hoogte. Er is geen invoerpresentatie nodig.

De regel’s [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) stelt een solide blauwe kleur in met een alfa‑waarde van 191 van de 255, wat ongeveer 25 % transparantie oplevert. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) bepaalt de dikte op 2 punten, en [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) maakt de lijn gestreept.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Verplaats twee labels verder van hun sectoren.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Het inschakelen van leidlijnen garandeert niet dat er voor elk label een lijn verschijnt. De zichtbaarheid hangt af van de labelplaatsing en het lay‑outgedrag van de grafiek. In dit voorbeeld hebben de twee verplaatste labels zichtbare leidlijnen; de labels die dicht bij hun sectoren blijven, hebben ze niet nodig.

De volgende afbeelding toont de opgeslagen `FormattedLeaderLines.pptx` zoals gerenderd met Aspose.Slides:

![Taartgrafiek met blauwe, halftransparante, gestreepte leidlijnen die twee buitenste labels verbinden met hun sectoren](formatted-leader-lines.png)

## **Meerdere rijen datalabels boven een kolomgrafiek toevoegen**

Dit voorbeeld maakt een kolomgrafiek met twee rijen datalabels boven het plotgebied. Serie A toont de zichtbare kolommen, terwijl Serie B en Serie C de extra labels leveren. Hun kolommen worden verborgen door de vulling en de contour te verwijderen. De [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)‑eigenschap uitlijnt alle drie de series op dezelfde categoricenters.

De [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/)‑instellingen reserveren ruimte voor de labelrijen. Na [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) de standaardposities berekent, behouden [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) en [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) de horizontale uitlijning en passen ze verticale offsets toe om de labels in twee rijen te rangschikken. De nummers blijven datalabels die gekoppeld zijn aan de seriewaarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Verberg de kolommen van B en C, maar behoud hun datalabels.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Lijn alle drie series uit op dezelfde categoricentra.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Reserveer ruimte boven het plot voor twee rijen datalabels.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Houd de standaard horizontale positie. Y is een offset ten opzichte van
            # de standaard labelpositie, uitgedrukt als een fractie van de grafiekhoogte.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Alleen de rij‑kop is een afzonderlijke tekstvorm.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Kolomgrafiek met twee rijen datalabels boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat datalabels overlappen in dichte grafieken?**

Combineer automatische labelplaatsing, leidlijnen en een kleiner lettertype; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen alleen voor nul‑, negatieve‑ of lege waarden?**

Filter gegevenspunten vóór het inschakelen van labels en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij export naar PDF/afbeeldingen?**

Stel expliciet de lettertypefamilie en -grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om een fallback te vermijden.