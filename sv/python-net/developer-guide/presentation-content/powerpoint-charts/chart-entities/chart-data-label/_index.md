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
- etikettsavstånd
- etikettposition
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET för mer engagerande bilder."
---
## **Översikt**

Dataetiketter i ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De gör det möjligt för läsarna att snabbt identifiera dataserier och de underlättar även förståelsen av diagrammen. I Aspose.Slides för Python kan du aktivera, anpassa och formatera dataetiketter för vilket diagram som helst—genom att välja vad som ska visas (värden, procenttal, serie- eller kategorinamn), var etiketter ska placeras och hur de ser ut (teckensnitt, talformat, avgränsare, ledlinjer med mera). Denna artikel beskriver de viktigaste API:erna och exemplen du behöver för att lägga till tydliga, informativa etiketter i dina diagram.

## **Ange precision för dataetiketter**

Diagrammets dataetiketter visar ofta numeriska värden som kräver konsekvent precision. Detta avsnitt visar hur du styr antalet decimaler för dataetiketter i Aspose.Slides genom att tillämpa ett lämpligt talformat.

Följande Python-exempel visar hur du anger den numeriska precisionen för diagrammets dataetiketter:

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

## **Visa procenttal som etiketter**

Med Aspose.Slides kan du visa procenttal som dataetiketter i diagram. Exemplet nedan beräknar varje punkts andel inom sin kategori och formaterar etiketten så att procenttalet visas.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Skapa en instans av Presentation-klassen.
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

    # Spara presentationen som innehåller diagrammet.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Visa procenttecken med diagrammets dataetiketter**

Detta avsnitt visar hur du visar procenttal i diagrammets dataetiketter och inkluderar procenttecknet med hjälp av Aspose.Slides. Du lär dig hur du aktiverar procentvärden för hela serier eller enskilda punkter (idealiskt för paj-, doughnut- och 100% staplade diagram) och hur du styr formateringen via etikettalternativ eller ett anpassat talformat.

Följande Python-exempel visar hur du lägger till ett procenttecken i diagrammets dataetikett:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta en bildreferens med index.
    slide = presentation.slides[0]

    # Skapa ett PercentsStackedColumn-diagram på bilden.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Hämta diagrammets dataarbetsbok.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Lägg till en ny serie.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Ställ in seriens fyllningsfärg.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Ställ in etikettformatets egenskaper.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Lägg till en ny serie.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Ställ in fyllningstyp och färg.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Spara presentationen.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange etikettavstånd från axel**

Detta avsnitt visar hur du styr avståndet mellan dataetiketter och diagrammets axel i Aspose.Slides. Att justera detta avstånd hjälper till att undvika överlappningar och förbättrar läsbarheten i täta visualiseringar.

Följande Python-kod visar hur du anger etikettavståndet från kategoraxeln när du arbetar med ett axelbaserat diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    # Hämta en bildreferens.
    slide = presentation.slides[0]

    # Skapa ett grupperat stapeldiagram på bilden.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Ställ in etikettavståndet från kategorins (horisontella) axel.
    chart.axes.horizontal_axis.label_offset = 500

    # Spara presentationen.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera etikettposition**

När du skapar ett diagram som inte använder axlar, till exempel ett pajdiagram, kan dataetiketterna ligga för nära kanten. I så fall justerar du etikettpositionen så att ledlinjerna visas tydligt.

Följande Python-kod visar hur du justerar etikettpositionen i ett pajdiagram:

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

![Ändrad etikettposition](changed_label_position.png)

## **FAQ**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, ledlinjer och mindre teckensnitt; om nödvändigt, dölja vissa fält (till exempel kategorin) eller visa etiketter endast för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnitt (familj, storlek) och verifiera att teckensnittet finns tillgängligt på renderingssidan för att undvika reservteckensnitt.