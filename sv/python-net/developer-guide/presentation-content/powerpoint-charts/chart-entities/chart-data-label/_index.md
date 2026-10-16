---
title: Hantera diagrammets datalabeler i presentationer med Python
linktitle: Datalabel
type: docs
url: /sv/python-net/chart-data-label/
keywords:
- diagram
- datalabel
- dataprecision
- procent
- etikettavstånd
- etikettplacering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagrammets datalabeler i PowerPoint-presentationer med Aspose.Slides för Python via .NET för mer engagerande bildspel."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsare att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procent, läser etiketttext, styr etiketter utanför axelns maximum, justerar avståndet mellan kategoriaxelns etiketter och placerar cirkeldiagrametiketter.

## **Ange dataprecision i diagrammets datalabeler**

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

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procent av dess kategori‑total och tilldelas texten till [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Detta exempel använder standarddiagramdata och visar procent med två decimaler i ett teckensnitt på 8 punkter. Kategorier med totalen noll hoppas över för att undvika division med noll. Beräkna om den anpassade etiketttexten om diagramdata ändras.

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

## **Ställ in procenttecken med diagrammets datalabeler**

När värden lagras som bråk, använd [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) för att visa procent. Sätt [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) till `False` för att tillämpa etikettformatet oberoende av källcellerna.

Detta exempel skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje värdepar summerar till 1. Etikettformatet `0.0%` visar 0,30 som 30,0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit etiketttext på 10 punkter.

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

## **Läs den faktiska texten för datalabeler**

Använd [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) för att hämta den text som produceras av en datalabels inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard‑[data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som procent, och en annan använder anpassad text från [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Det tal som lagras i en datapunkt är fortfarande `0.75`, även när dess etikett visar `75 %` tillsammans med kategori‑ och serienamnen. Anpassad text ersätter den genererade etiketttexten. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) returnerar den resulterande etikettsträngen i båda fallen. Kontrollera [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) separat, som visat ovan, när du bara vill extrahera synliga etiketter.

## **Styr datalabeler utanför axelns maximum**

När du manuellt begränsar ett axelintervall kan vissa datapunkter överskrida dess maximum. Använd [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) för att bestämma om deras datalabeler ska visas. Denna inställning påverkar etikettens synlighet; den ändrar inte axelintervallet eller de underliggande datavärdena.

Exemplet nedan skapar ett 2D‑klustrat stapeldiagram med värdena 60 och 120. Det sätter [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) till `False` och [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) till 100 på den vertikala axeln. Den första bilden tillåter etiketter utanför maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdeetiketter med [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Diagramnivåinställningen aktiverar inte värdevisning i sig och åsidosätter inte en enskild etiketts inaktiverade värdevisning. Detta exempel aktiverar värden för hela serien och använder [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) för att placera etiketter vid varje kolumns yttre ände.

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

Följande bilder visar de sparade bilderna som renderats av Microsoft PowerPoint. Med `True` är etiketten **120** synlig vid den övre gränsen; med `False` är den dold. Etiketten **60** förblir synlig, axelmaximum förblir **100**, och den andra datapunkten förblir **120** i båda fallen.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint‑diagram som visar värdeetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-true.png) | ![PowerPoint‑diagram som döljer värdeetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Diagramtyp" %}}
Detta exempel använder ett 2D‑stapeldiagram med en värdeaxel. Diagram utan värdeaxel, såsom paj‑ och donutdiagram, har inget axelmaximum att begränsa på detta sätt.
{{% /alert %}}

## **Ställ in etiketavstånd från en axel**

Använd [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) för att styra avståndet mellan kategoriaxelns etiketter och axeln. Värdet är en procentsats av den största teckenstorleken för axelns etiketter. Detta exempel skapar ett klustrat stapeldiagram och sätter den horisontella axelns etikett‑offset till 500. Inställningen påverkar kategoriaxelns etiketter snarare än etiketter kopplade till enskilda datapunkter.

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

På ett pajdiagram justeras datalabelernas placering för att förbättra avståndet och ge plats för ledlinjer.

Detta exempel visar värdet för den första datapunkten, placerar dess etikett utanför segmentet och justerar dess [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑offsetar. Dessa offsetar är relativa till diagrammets bredd respektive höjd.

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

![Pajdiagram med justerad datalabelposition](pie-chart-adjusted-label.png)

## **Formatera ledlinjer**

När pajdiagrametiketter sitter utanför sina segment hjälper ledlinjer läsaren att matcha varje värde med rätt segment. En kontrasterande färg och en något tjockare linje kan göra dessa kopplingar lättare att följa, medan transparens och streckad stil håller linjerna visuellt diskreta.

Använd [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) för att formatera ledlinjer på seriens datalabel‑samlingsnivå. Inställningarna i `series.labels.leader_lines_format.line` gäller för samlingen snarare än för en enskild etikett.

Detta exempel skapar ett pajdiagram med standarddata, visar värden utanför segmenten och aktiverar [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Det flyttar två etiketter längre bort från sina segment med hjälp av [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑offsetar, uttryckt som bråkdelar av diagrammets bredd och höjd. Ingen inmatningspresentation krävs.

Linjen's [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ställer in en solid blå färg med ett alfavärde på 191 av 255, vilket ger cirka 25 % transparens. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) sätter tjockleken till 2 punkter, och [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) gör linjen streckad.

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

    # Flytta två etiketter längre bort från deras segment.
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

Att aktivera ledlinjer garanterar inte att en linje visas för varje etikett. Synligheten beror på etikettens placering och diagrammets layoutbeteende. I detta exempel har de två förskjutna etiketterna synliga ledlinjer; etiketterna som förblir nära sina segment behöver dem inte.

Följande bild visar den sparade `FormattedLeaderLines.pptx` som renderats med Aspose.Slides:

![Pajdiagram med blå, semitransparenta streckade ledlinjer som kopplar två externa etiketter till deras segment](formatted-leader-lines.png)

## **Lägg till flera rader med datalabeler ovanför ett stapeldiagram**

Detta exempel skapar ett stapeldiagram med två rader av datalabeler ovanför plot‑ytan. Serie A visar de synliga staplarna, medan Serie B och Serie C tillhandahåller de extra etiketterna. Deras staplar döljs genom att ta bort fyllning och kontur. Egenskapen [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) justerar alla tre serier så att de har samma kategori­centrum.

[plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/)-inställningarna reserverar utrymme för etikettraderna. Efter att [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) beräknat standardpositionerna bevarar [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/)‑ och [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/)‑offsetarna horisontell justering och applicerar vertikala offsetar för att arrangera etiketterna i två rader. Siffrorna förblir datalabeler länkade till serievärdena; endast radrubrikerna är separata textformer.

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
            # Dölj kolumnerna för B och C, men behåll deras datalabeler.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Rikta in alla tre serierna på samma kategori­center.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Använd färre rutnätlinjer för detta kompakta exempel.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Reservera utrymme ovanför diagramområdet för två rader med datalabeler.
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
            # standardetikettpositionen, uttryckt som en andel av diagramhöjden.
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

![Stapeldiagram med två rader av datalabeler ovanför plot‑ytan](multiple-rows-of-labels.png)

## **FAQ**

**Hur kan jag förhindra att datalabeler överlappar i täta diagram?**

Kombinera automatisk etikettplacering, ledlinjer och minskad teckenstorlek; vid behov dölja vissa fält (t.ex. kategori) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter bara för noll, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa eller saknade enligt en definierad regel.

**Hur säkerställer jag en enhetlig etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek samt verifiera att teckensnittet är tillgängligt i renderingsmiljön för att undvika reservteckensnitt.