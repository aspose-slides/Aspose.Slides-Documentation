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
- labelpositie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides for Python via .NET voor meer boeiende dia's."
---
## **Overzicht**

Gegevenslabels op een diagram geven details weer over de gegevensreeksen van het diagram of individuele datapunten. Ze stellen lezers in staat om snel gegevensreeksen te identificeren en ze maken diagrammen bovendien beter begrijpelijk. In Aspose.Slides for Python kun je gegevenslabels voor elk diagram inschakelen, aanpassen en opmaken – je kunt kiezen wat er moet worden weergegeven (waarden, percentages, namen van reeksen of categorieën), waar de labels moeten worden geplaatst en hoe ze eruitzien (lettertype, getalnotatie, scheidingstekens, koppellijnen en meer). Dit artikel geeft een overzicht van de essentiële API's en voorbeelden die je nodig hebt om duidelijke, informatieve labels aan je diagrammen toe te voegen.

## **Precisie van gegevenslabels instellen**

Diagramgegevenslabels tonen vaak numerieke waarden die een consistente precisie vereisen. In dit gedeelte wordt getoond hoe je in Aspose.Slides het aantal decimalen voor gegevenslabels kunt bepalen door een geschikt getalformaat toe te passen.

De volgende Python‑voorbeeld toont hoe je de numerieke precisie voor diagramgegevenslabels kunt instellen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Percentages weergeven als labels**

Met Aspose.Slides kun je percentages als gegevenslabels op diagrammen tonen. Het voorbeeld hieronder berekent het aandeel van elk punt binnen zijn categorie en formatteert het label om het percentage weer te geven.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Maak een instantie van de Presentation‑klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Sla de presentatie met het diagram op.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Procenttekens weergeven bij diagramgegevenslabels**

Dit gedeelte laat zien hoe je percentages in diagramgegevenslabels weergeeft en het procentteken toevoegt met Aspose.Slides. Je leert hoe je percentage‑waarden kunt inschakelen voor volledige reeksen of specifieke punten (ideaal voor taart‑, ring‑ en 100 % gestapelde diagrammen) en hoe je de opmaak kunt controleren via labelopties of een aangepast getalformaat.

De volgende Python‑voorbeeld toont hoe je een procentteken aan een diagram‑gegevenslabel kunt toevoegen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse.
with slides.Presentation() as presentation:

    # Haal een slide‑referentie op via index.
    slide = presentation.slides[0]

    # Maak een PercentsStackedColumn‑diagram op de slide.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Haal het werkboek met diagramgegevens op.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Voeg een nieuwe serie toe.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Stel de vulkleur van de serie in.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Stel de labelopmaak‑eigenschappen in.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Voeg een nieuwe serie toe.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Stel het vultype en de kleur in.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Sla de presentatie op.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Afstand van label tot as instellen**

Dit gedeelte laat zien hoe je in Aspose.Slides de afstand tussen gegevenslabels en de diagramas kunt regelen. Het aanpassen van deze offset helpt overlappingen te voorkomen en verbetert de leesbaarheid bij dichte visualisaties.

De volgende Python‑code toont hoe je de labelafstand tot de categorie‑as kunt instellen bij het werken met een as‑gebaseerd diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    # Haal een slide-referentie op.
    slide = presentation.slides[0]

    # Maak een gegroepeerd kolomdiagram op de slide.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Stel de labelafstand van de categorie (horizontale) as in.
    chart.axes.horizontal_axis.label_offset = 500

    # Sla de presentatie op.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Labelpositie aanpassen**

Wanneer je een diagram maakt dat geen assen gebruikt, zoals een taartdiagram, kunnen de gegevenslabels te dicht bij de rand staan. Pas in dat geval de labelpositie aan zodat de koppellijnen duidelijk zichtbaar zijn.

De volgende Python‑code toont hoe je de labelpositie op een taartdiagram kunt aanpassen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Aangepaste labelpositie](changed_label_position.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen bij drukke diagrammen?**

Combine automatische labelplaatsing, koppellijnen en verkleind lettertype; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor uiterste/sleutelpunten.

**Hoe kan ik labels uitschakelen alleen voor nul, negatieve of lege waarden?**

Filter datapunten voordat je labels inschakelt en schakel weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij exporteren naar PDF/beelden?**

Stel lettertypen (familie, grootte) expliciet in en controleer of het lettertype beschikbaar is aan de renderkant om terugval te voorkomen.