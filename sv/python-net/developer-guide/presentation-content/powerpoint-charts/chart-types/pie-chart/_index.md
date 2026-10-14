---
title: Anpassa pajdiagram i presentationer med Python
linktitle: Pajdiagram
type: docs
url: /sv/python-net/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- sektorfärg
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa pajdiagram i Python med Aspose.Slides. Konfigurera sekundära diagram, visa datalabels och tillämpa automatiska sektorfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar alternativ för sekundära diagram för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av sektorer för ett standardpajdiagram.

Exemplen fokuserar på anpassningsuppgifter för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden, samt spara den uppdaterade presentationen.

## **Alternativ för sekundärt diagram för Pie of Pie och Bar of Pie-diagram**

Aspose.Slides för Python via .NET stöder alternativ för sekundära diagram för Pie of Pie- och Bar of Pie-diagram. Dessa alternativ styr storleken på det sekundära diagrammet och hur datapunkter fördelas mellan de två diagrammen.

Följande exempel skapar ett Pie of Pie-diagram i en ny presentation och visar datapunkternas värden som etiketter. Egenskapet [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) anger storleken på det sekundära diagrammet till 149 % av huvuddiagrammet. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) väljer procentbaserad uppdelning, och [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) sätter tröskeln till 53 %.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Visa värden och konfigurera sekundärt diagram.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Välj kategorier för det sekundära diagrammet**

Använd anpassad uppdelning när du vill gruppera specifika kategorier i det sekundära diagrammet oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35 % respektive 10 % av den totala försäljningen.

Ställ in [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) till [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) och välj punkterna via [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Samlingens [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/)‑metod accepterar antingen ett nollbaserat index i serien eller ett datapunktobjekt. I det här exemplet väljer index 1 Online och punkten på index 3 väljer Events. Partners läggs också till tillfälligt och tas sedan bort med [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Ersätt standarddata med försäljning per kanal.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Välj Online med sitt nollbaserade index och Events med sitt datapunktobjekt.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Exkludera Partners från urvalet utan att ta bort dess källdata.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) och Events (10) visas som separata sektorer i det sekundära diagrammet. I huvuddiagrammet representeras de av en kombinerad sektor med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller den i huvuddiagrammet; den tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie-diagram med Online och Events i det sekundära diagrammet och deras kombinerade värde 45 i huvuddiagrammet](pie_of_pie_custom.png)

## **Ställ in automatiska färger för sektorer i pajdiagram**

Aspose.Slides för Python via .NET kan automatiskt tilldela olika färger till sektorer i ett pajdiagram. Följande exempel skapar ett pajdiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Egenskapen [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) visar värdena 20, 50 och 30 som etiketter, medan [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) aktiverar en unik färg för varje sektor.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Lägg till en centrerad diagramrubrik.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Ersätt standarddata med användning av det första kalkylbladet.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Visa värden och tilldela olika färger till sektorerna.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Stöds variationerna Pie of Pie och Bar of Pie?**

Ja, biblioteket [supports](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ett sekundärt diagram för pajdiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera bara diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [export the chart itself as an image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (t.ex. PNG) utan att exportera hela presentationen.