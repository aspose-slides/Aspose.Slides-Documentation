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
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor Python via .NET voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekseries en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, de afstand tussen labels op de categorische as kunt aanpassen en labels op een taartgrafiek kunt positioneren.

## **Precisie van gegevens instellen in grafieklabels**

Gebruik [number_format_of_values](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/number_format_of_values/) om reeksenwaarden op te maken. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de gegevens tabel en schakelt waardelabels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen-scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

Voor een gestapelde kolomgrafiek berekent u elke waarde als een percentage van het totale aantal binnen de categorie en wijst u de tekst toe aan [text_frame_for_overriding](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te vermijden. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑teken instellen met grafieklabels**

Wanneer waarden als breuken worden opgeslagen, gebruikt u [number_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/number_format/) om percentages weer te geven. Stel [is_number_format_linked_to_source](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) in op `False` om het labelopmaak onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0.30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

## **De feitelijke tekst van gegevenslabels lezen**

Gebruik [get_actual_label_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) om de tekst op te halen die door een gegevenslabel wordt gegenereerd op basis van zijn instellingen. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatiewaarde of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als percentage, en een ander gebruikt aangepaste tekst uit [text_frame_for_overriding](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs als het label `75 %` toont samen met de categorie‑ en reeksenamen. Aangepaste tekst vervangt de automatisch gegenereerde labeltekst. [get_actual_label_text](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) retourneert de resulterende labelreeks in beide gevallen. Controleer [is_visible](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/is_visible/) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Labelafstand ten opzichte van een as instellen**

Gebruik [label_offset](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/label_offset/) om de afstand tussen de labels van de categorische as en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de categorie‑as‑labels in plaats van de labels die aan individuele gegevenspunten zijn gekoppeld.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Labelpositie aanpassen**

Bij een taartgrafiek past u de posities van gegevenslabels aan om de afstand te verbeteren en ruimte te maken voor leidende lijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten het segment en past de [x](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/x/)‑ en [y](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabel/y/)‑offsets aan. Deze offsets zijn respectievelijk relatief aan de breedte en hoogte van de grafiek.

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

## **Veelgestelde vragen**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in dichte grafieken?**

Combineer automatische labelplaatsing, leidende lijnen en een verkleinde lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen alleen voor nul‑, negatieve of lege waarden?**

Filter de gegevenspunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of missende waarden volgens een vaste regel.

**Hoe kan ik een consistente labelstijl garanderen bij het exporteren naar PDF/afbeeldingen?**

Stel de lettertypefamilie en -grootte expliciet in en controleer dat het lettertype beschikbaar is in de renderomgeving om een terugval te voorkomen.