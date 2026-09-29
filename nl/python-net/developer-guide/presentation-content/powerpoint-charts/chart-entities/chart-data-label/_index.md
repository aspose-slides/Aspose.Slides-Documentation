---
title: Beheer grafiekgegevenslabels in presentaties met Python
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
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor Python via .NET voor boeiendere dia's."
---
## **Introductie**

Gegevenslabels geven informatie weer over grafiekseries en individuele datapunten, zodat lezers waarden kunnen identificeren en de grafiek beter kunnen begrijpen. Dit artikel legt uit hoe je waarden opmaakt, percentages weergeeft, labeltekst uitleest, labels buiten de as‑maximum regelt, de afstand tussen categorie‑as‑labels aanpast en labels in een cirkeldiagram positioneert.

## **Precisie van gegevens instellen in grafiek‑gegevenslabels**

Gebruik [number_format_of_values](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/number_format_of_values/) om de waarden van een serie op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt waardelabels in voor de eerste serie. Het formaat `#,##0.00` geeft een duizendtallen‑scheidingsteken en twee decimale plaatsen weer zonder de onderliggende waarden te wijzigen.

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

## **Percentage weergeven als labels**

Voor een gestapelde kolomgrafiek calculate je elke waarde als een percentage van het totale aantal in die categorie en wijs je de tekst toe aan [text_frame_for_overriding](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te vermijden. Herbereken de aangepaste labeltekst wanneer de grafiekgegevens veranderen.

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

## **Percentage‑teken instellen met grafiek‑gegevenslabels**

Wanneer waarden als breuken worden opgeslagen, gebruik je [number_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/number_format/) om percentages weer te geven. Stel [is_number_format_linked_to_source](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) in op `False` om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elk paar waarden telt op tot 1. Het label‑formaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst van 10 punten.

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

## **De werkelijke tekst van gegevenslabels uitlezen**

Gebruik [get_actual_label_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert de waarde als percentage, en een ander gebruikt aangepaste tekst vanuit [text_frame_for_overriding](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Het getal dat in een datapunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75 %` toont samen met de categorie‑ en serienamen. Aangepaste tekst vervangt de automatisch gegenereerde labeltekst. [get_actual_label_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) geeft de resulterende label‑string in beide gevallen terug. Controleer [is_visible](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/is_visible/) apart, zoals hierboven getoond, wanneer je alleen zichtbare labels wilt extraheren.

## **Gegevenslabels buiten de as‑maximum regelen**

Wanneer je een asbereik handmatig limiteert, kunnen sommige datapunten de maximumwaarde overschrijden. Gebruik [show_data_labels_over_maximum](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) om te bepalen of hun gegevenslabels getoond worden. Deze instelling wijzigt de zichtbaarheid van het label; hij verandert niet het asbereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D‑gegroepeerde kolomgrafiek met waarden van 60 en 120. Het stelt [is_automatic_max_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/is_automatic_max_value/) in op `False` en [max_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/max_value/) op 100 voor de verticale as. De eerste dia laat labels buiten het maximum toe; een kopie van die dia schakelt ze uit. Beide dia’s worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [show_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/show_value/). De instelling op grafiekniveau activeert niet automatisch de weergave van waarden en overschrijft ook niet de individuele instelling die de weergave van een label uitschakelt. Dit voorbeeld activeert waarden voor de hele serie en gebruikt [position](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/position/) om labels aan het buitenste eind van elke kolom te plaatsen.

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

De onderstaande afbeeldingen tonen de opgeslagen dia's zoals gerenderd door Microsoft PowerPoint. Met `True` is het label **120** zichtbaar bij de bovenste grens; met `False` wordt het verborgen. Het label **60** blijft zichtbaar, de as‑maximum blijft **100**, en het tweede datapunt blijft **120** in beide gevallen.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D‑kolomgrafiek met een waardenas. Grafieken zonder waardenas, zoals taart‑ en donutgrafieken, hebben geen as‑maximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand tot een as instellen**

Gebruik [label_offset](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/label_offset/) om de afstand tussen de labels van de categorie‑as en de as zelf te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑label‑offset in op 500. Deze instelling heeft invloed op de categorie‑as‑labels in plaats van op labels die aan individuele datapunten zijn gekoppeld.

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

In een taartgrafiek kun je de positie van gegevenslabels aanpassen om de afstand te verbeteren en ruimte te maken voor leidende lijnen.

Dit voorbeeld toont de waarde van het eerste datapunt, plaatst het label buiten de sector en past de [x](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/x/)‑ en [y](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/y/)‑verschuivingen aan. Deze verschuivingen zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in dichtbevolkte grafieken?**

Combineer automatische labelplaatsing, leidende lijnen en een kleinere lettergrootte; schakel indien nodig enkele velden (bijvoorbeeld de categorie) uit of toon alleen labels voor extreme of belangrijke punten.

**Hoe kan ik labels uitschakelen alleen voor nul‑, negatieve of lege waarden?**

Filter de datapunten voordat je labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of missende waarden volgens een gedefinieerde regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet de lettertype‑familie en -grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om een fallback te voorkomen.