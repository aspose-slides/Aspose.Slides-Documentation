---
title: Hantera diagramdataetiketter i presentationer med Python
linktitle: Dataetikett
type: docs
url: /sv/python-net/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettavstånd
- etikettposition
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för Python via .NET för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsare att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procentsatser, läser etiketttext, styr etiketter utanför axelns maximum, justerar avståndet mellan kategori-axelns etiketter och placerar cirkeldiagrametiketter.

## **Ställ in dataprecision i diagrammets dataetiketter**

Använd [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) för att formatera serievärden. Detta exempel skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdeetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsavgränsare och två decimaler utan att ändra de underliggande värdena.

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

## **Visa procentsats som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentsats av sin kategoris totala summa och texten tilldelas [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Detta exempel använder diagrammets standarddata och visar procentsatser med två decimaler i en 8‑punkts teckensnitt. Kategorier med en total på noll hoppas över för att undvika division med noll. Beräkna om den anpassade etiketttexten om diagramdata ändras.

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

## **Ställ in procenttecken med diagrammets dataetiketter**

När värden lagras som bråktal, använd [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) för att visa procent. Sätt [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) till `False` för att tillämpa etikettformatet oberoende av källcellerna.

Det här exemplet skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje par av värden summeras till 1. Etikettformatet `0.0%` visar 0.30 som 30,0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit etiketttext i 10 punkter.

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

## **Läs den faktiska texten för dataetiketter**

Använd [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) för att hämta den text som produceras av en dataetiketts inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som en procentsats, och en annan använder anpassad text från [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Numret som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75 %` tillsammans med kategori- och serienamnen. Anpassad text ersätter den genererade etiketttexten. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) returnerar den resulterande etikettssträngen i båda fallen. Kontrollera [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) separat, som visas ovan, när du bara vill extrahera synliga etiketter.

## **Styr dataetiketter bortom axelns maximum**

När du begränsar ett axelintervall manuellt kan vissa datapunkter överstiga dess maximum. Använd [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) för att styra om deras dataetiketter visas. Denna inställning ändrar etikettens synlighet; den ändrar inte axelintervallet eller de underliggande datavärdena.

Exemplet nedan skapar ett 2D grupperat stapeldiagram med värdena 60 och 120. Det sätter [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) till `False` och [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) till 100 på den vertikala axeln. Den första bilden tillåter etiketter bortom maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdeetiketter med [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Diagramnivåinställningen aktiverar inte värdevisning i sig eller överskrider en individuell etikett som har inaktiverad värdevisning. Detta exempel aktiverar värden för hela serien och använder [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) för att placera etiketter vid den yttre änden av varje stapel.

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

Följande bilder visar de sparade bilderna renderade av Microsoft PowerPoint. Med `True` är etiketten **120** synlig vid den övre gränsen; med `False` är den dold. Etiketten **60** förblir synlig, axelmaximum förblir **100**, och den andra datapunkten förblir **120** i båda fallen.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Diagramtyp" %}}
Det här exemplet använder ett 2D stapeldiagram med en värdeaxel. Diagram utan en värdeaxel, såsom paj- och munkdiagram, har inget axelmaximum att begränsa på detta sätt.
{{% /alert %}}

## **Ställ in etikettavstånd från en axel**

Använd [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) för att kontrollera avståndet mellan kategori-axelns etiketter och axeln. Värdet är en procentsats av den maximala teckenstorleken för axelns etiketter. Detta exempel skapar ett grupperat stapeldiagram och sätter den horisontella axelns etikettavstånd till 500. Denna inställning påverkar kategori‑axelns etiketter snarare än etiketter som är fästa vid enskilda datapunkter.

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

I ett pajdiagram justeras positionerna för dataetiketter för att förbättra avståndet och skapa utrymme för ledarlinjer.

Detta exempel visar värdet för den första datapunkten, placerar dess etikett utanför segmentet och justerar dess [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑offsets. Dessa offset är relativa till diagrammets bredd respektive höjd.

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

![Pajdiagram med justerad dataetikettposition](pie-chart-adjusted-label.png)

## **Lägg till flera rader med dataetiketter ovanför ett stapeldiagram**

Detta exempel skapar ett stapeldiagram med två rader dataetiketter ovanför plotområdet. Serie A visar de synliga staplarna, medan Serie B och Serie C tillhandahåller de extra etiketterna. Deras staplar döljs genom att ta bort fyllning och kontur. Egenskapen [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) justerar alla tre serier med samma kategoricentrum.

Inställningarna för [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) reserverar utrymme för etikettraderna. Efter att [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) beräknat standardpositionerna bevarar [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) och [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) horisontell justering och tillämpar vertikala offset för att placera etiketterna i två rader. siffrorna förblir dataetiketter kopplade till serievärdena; endast radrubrikerna är separata textformer.

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
            # Dölj kolumnerna för B och C, men behåll deras dataetiketter.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Justera alla tre serier så att de har samma kategori­centrum.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Använd färre rutnätlinjer för detta kompakta exempel.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Reservera utrymme ovanför diagrammet för två rader med dataetiketter.
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
            # Behåll standard horisontell position. Y är en offset från
            # standardetikettens position, uttryckt som en bråkdel av diagramhöjden.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Endast radrubriken är en separat textform.
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

![Stapeldiagram med två rader dataetiketter ovanför plotområdet](multiple-rows-of-labels.png)

## **FAQ**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk placering av etiketter, ledarlinjer och minskad teckenstorlek; vid behov dölja vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden som är 0, negativa eller saknade enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit typsnittsfamilj och storlek och verifiera att typsnittet är tillgängligt i renderingsmiljön för att undvika fallback.