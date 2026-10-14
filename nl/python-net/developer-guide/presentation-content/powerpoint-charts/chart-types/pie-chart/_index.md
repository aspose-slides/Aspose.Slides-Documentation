---
title: Aangepaste taartdiagrammen in presentaties met Python
linktitle: Taartdiagram
type: docs
url: /nl/python-net/pie-chart/
keywords:
- taartdiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas taartdiagrammen aan in Python met Aspose.Slides. Configureer secundaire plotten, toon gegevenslabels en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe u met taartdiagrammen in Aspose.Slides kunt werken. Het toont hoe u secundaire plot‑opties voor Pie of Pie‑ en Bar of Pie‑diagrammen kunt configureren en hoe u automatische kleuring van segmenten kunt inschakelen voor een standaard taartdiagram.

De voorbeelden richten zich op taken voor het aanpassen van diagrammen, zoals een diagram toevoegen aan een dia, de series‑ en labelinstellingen aanpassen, de standaard diagramgegevens vervangen door aangepaste categorieën en waarden, en de bijgewerkte presentatie opslaan.

## **Opties voor secundaire plot voor Pie of Pie en Bar of Pie grafieken**

Aspose.Slides voor Python via .NET ondersteunt secundaire plot‑opties voor Pie of Pie‑ en Bar of Pie‑diagrammen. Deze opties bepalen de grootte van de secundaire plot en hoe gegevenspunten tussen de twee plots worden verdeeld.

Het volgende voorbeeld maakt een Pie of Pie‑diagram in een nieuwe presentatie en toont de waarden van gegevenspunten als labels. De [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) eigenschap stelt de grootte van de secundaire plot in op 149% van de hoofdplot. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) selecteert procentgebaseerde splitsing, en [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) stelt de drempel in op 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Waarde weergeven en de secundaire plot configureren.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer u specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun procentuele waarden. Bijvoorbeeld, een verkooprapport kan Online en Evenementen samen weergeven zodat lezers deze twee kanalen kunnen vergelijken, hoewel ze respectievelijk 35% en 10% van de totale verkoop uitmaken.

Stel [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) in op [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) en selecteer de punten via [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). De [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) methode van de collectie accepteert ofwel een nul‑gebaseerde index in de serie of een gegevenspuntobject. In dit voorbeeld selecteert index 1 Online en selecteert het punt op index 3 Events. Partners wordt ook tijdelijk toegevoegd, waarna het wordt uitgesloten met [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Vervang de standaardgegevens door verkopen per kanaal.
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

    # Selecteer Online via zijn nulgebaseerde index en Events via zijn gegevenspuntobject.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Sluit Partners uit de selectie zonder de brongegevens te verwijderen.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) en Events (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven door één gecombineerd segment met een waarde van 45, samen met Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie houdt het in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De volgende afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie-diagram met Online en Events in de secundaire plot en hun gecombineerde waarde van 45 in de primaire plot](pie_of_pie_custom.png)

## **Stel automatische kleuren voor taartdiagramsegmenten in**

Aspose.Slides voor Python via .NET kan automatisch verschillende kleuren toewijzen aan segmenten van een taartdiagram. Het volgende voorbeeld maakt een taartdiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategorieën en hun waarden. De [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) eigenschap toont de waarden 20, 50 en 30 als labels, terwijl [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) een verschillende kleur voor elk segment inschakelt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Voeg een gecentreerde diagramtitel toe.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Vervang de standaardgegevens met het eerste werkblad.
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

    # Toon waarden en ken verschillende kleuren toe aan de segmenten.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Worden de varianten Pie of Pie en Bar of Pie ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) een secundaire plot voor taartdiagrammen, inclusief de Pie of Pie‑ en Bar of Pie‑typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [exporteer het diagram zelf als afbeelding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (bijvoorbeeld PNG) zonder de volledige presentatie te exporteren.