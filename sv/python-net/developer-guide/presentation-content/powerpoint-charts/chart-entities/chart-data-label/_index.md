---
title: Hantera diagramdatamärkningar i presentationer med Python
linktitle: Datamärkning
type: docs
url: /sv/python-net/chart-data-label/
keywords:
- diagram
- datamärkning
- dataprecision
- procent
- etikettavstånd
- etikettplacering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdatamärkningar i PowerPoint-presentationer med Aspose.Slides för Python via .NET för mer engagerande bilder."
---
## **Introduction**

Datamärkningar visar information om diagramserier och enskilda datapunkter, vilket hjälper läsarna att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procenttal, läser etiketttext, justerar avståndet mellan etiketter på kategoriaxeln och placerar pajdiagrametiketter.

## **Ställ in dataprecision i diagrammets datamärkningar**

Använd [number_format_of_values](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/number_format_of_values/) för att formatera serievärden. Detta exempel skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdeetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsavgränsare och två decimaler utan att ändra de underliggande värdena.

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

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentsats av dess kategori‑total och texten tilldelas [text_frame_for_overriding](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Detta exempel använder standarddiagramdata och visar procent med två decimaler i en 8‑punkts teckensnitt. Kategorier med en total på noll hoppas över för att undvika division med noll. Beräkna om den anpassade etikettttexten om diagramdata ändras.

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

## **Ange procenttecken med diagrammets datamärkningar**

När värden lagras som bråk, använd [number_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabelformat/number_format/) för att visa procent. Ställ in [is_number_format_linked_to_source](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) till `False` för att tillämpa etiketformatet oberoende av källcellerna.

Detta exempel skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje par av värden summerar till 1. Etiketformatet `0.0%` visar 0.30 som 30.0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit, 10‑punkts etikettext.

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

## **Läs den faktiska texten för datamärkningar**

Använd [get_actual_label_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) för att hämta den text som genereras av en datamärknings inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard‑[data label format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabelformat/) varje kategorinamn, serienamn och värde. En datapunkt formaterar sitt värde som procent, och en annan använder anpassad text från [text_frame_for_overriding](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Talet som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75%` tillsammans med kategori‑ och serienamnen. Anpassad text ersätter den genererade etiketttexten. [get_actual_label_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) returnerar den resulterande etikettssträngen i båda fallen. Kontrollera [is_visible](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/is_visible/) separat, som visas ovan, när du bara vill extrahera synliga etiketter.

## **Ställ in etikettavstånd från en axel**

Använd [label_offset](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/axis/label_offset/) för att styra avståndet mellan etiketter på kategori‑axeln och själva axeln. Värdet är en procentsats av den största teckenstorleken för axel­etiketterna. Detta exempel skapar ett grupperat stapeldiagram och sätter den horisontella axelns etikettoffset till 500. Denna inställning påverkar kategori‑axelns etiketter snarare än etiketter som är knutna till enskilda datapunkter.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera etikettplacering**

I ett pajdiagram justeras datamärkningspositionerna för att förbättra avståndet och göra plats för ledare‑linjer.

Detta exempel visar värdet för den första datapunkten, placerar dess etikett utanför sektorn och justerar dess [x](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/x/) och [y](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datalabel/y/) offset. Dessa offset är relativa till diagrammets bredd respektive höjd.

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

![Pajdiagram med en justerad datamärkningsposition](pie-chart-adjusted-label.png)

## **Vanliga frågor**

**Hur kan jag förhindra att datamärkningar överlappar på täta diagram?**

Kombinera automatisk etikettplacering, ledare‑linjer och minskad teckenstorlek; vid behov dölja vissa fält (till exempel kategori) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek samt verifiera att teckensnittet är tillgängligt i renderingsmiljön för att undvika reservteckensnitt.