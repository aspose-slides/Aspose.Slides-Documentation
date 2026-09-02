---
title: Hantera diagramdataserier i presentationer i Python
linktitle: Dataserier
type: docs
url: /sv/python-net/chart-series/
keywords:
- diagramserie
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, glappbredd och negativa värden i presentationer med Python."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdatabok. En [ChartSeries](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/) representerar en uppsättning relaterade värden, och varje [ChartDataPoint](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/) i serien hänvisar till en eller flera celler i arbetsboken. [ChartCategory](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartcategory/)-objekt tillhandahåller etiketter eller gruppvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [ChartDataCell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatacell/)-objekt snarare än att bara lagras som displaytext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn, och de återstående cellerna för serievärden. Arbetsblad, rad- och kolumnindex som skickas till [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsbokens värden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [ChartSeries.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/format/), tillhandahåller standardutseendet för alla punkter i en serie.
- Inställningar för datapunkt, såsom [ChartDataPoint.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/format/), åsidosätter serieutseendet för en punkt.
- Gruppinställningar gäller för kompatibla serier som tillhör samma [ChartSeriesGroup](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/). Åtkomst till gruppen sker via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/parent_series_group/) när du behöver sätta alternativ som överlappning eller glappbredd.

När ingen explicit punkt- eller seriefyllning är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie- och punktformatering finns, har punktformateringen företräde för den punkten.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ställ in överlappning för diagramserier**

[ChartSeries.overlap](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/overlap/) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D-diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriegruppen. Sätt [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/overlap/) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller för diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriegrupper i ett kombinationsdiagram.

Följande exempel sätter överlappningen för den grupp som innehåller den första serien:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Det nya diagrammet innehåller exempelserier, kategorier och värden.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Series överlappning](series_overlap.png)

## **Ändra fyllningsfärgen för serien**

Använd [ChartSeries.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/format/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [ChartDataPoint.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/format/) inställning seriefyllningen för den punkten.

Följande exempel tillämpar en solid blå fyllning på den första serien:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Färgen på serien](series_color.png)

## **Ändra serienamnet**

Ett serienamn lagras i diagrammets datarbok och visas normalt i förklaringen. I standardarbetsboken som skapas för ett grupperat kolumnDiagram är cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen explicit:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Du kan även uppdatera cellen som redan refereras av [ChartSeries.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/name/). Detta tillvägagångssätt undviker att anta en viss rad och kolumn i ett befintligt diagram:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Serienamnet](series_name.png)

## **Hämta den automatiska fyllningsfärgen för serien**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) returnerar färgen som beräknas utifrån serieindexet och diagramstilen. Detta är färgen som används när seriefyllningen inte har definierats explicit. Att anropa metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Exempelutdata för standarddiagramstilen:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

De exakta färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel-, kolumn- och bubbelseerer kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/invert_if_negative/) visa negativa värden med en annan fyllning. Ställ in den vanliga seriefyllningen till solid, aktivera invertering och tilldela färgen för negativa värden via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladets rad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den inverterade solida fyllningsfärgen](inverted_solid_fill_color.png)

Du kan aktivera invertering för en punkt via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). I följande exempel är invertering inaktiverad för serien och aktiverad endast för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten syns:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsbokscell till `None`. För ett kolumndiagram är det plottade värdet tillgängligt via [ChartDataPoint.value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/value/). Datapunkten förblir på samma kategori‑position, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder också en storlekscell. Rensa endast den cell som representerar det värde du vill ta bort. Anropa inte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom metoden tar bort varje datapunkt från samlingen.

## **Ställ in glappbredd för serien**

Glappbredd är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som en procentandel av stapel‑ eller kolumnbredden. Liksom överlappning tillhör den den överordnade seriegruppen snarare än en enskild serie. Sätt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) en gång för gruppen. Ett större värde skapar mer utrymme mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar glappbredden och sparar endast den slutgiltiga presentationen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Glappbredden](gap_width.png)

## **FAQ**

**Vilka diagramtyper stödjer dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/)-enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelformer. Använd den datapunkt‑skapande metoden som matchar serietypen. Alternativ som överlappning och glappbredd gäller endast för kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegrupp?**

En [ChartSeriesGroup](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/) innehåller kompatibla serier som delar gruppnivå‑plottinginställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen via en serie förändrar inte nödvändigtvis varje serie i diagrammet.

**Innehåller ett nyskapat diagram standarddata?**

Ja. Som standard skapar [ShapeCollection.add_chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_chart/) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till ett helt anpassat datumset. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks-celler?**

Serienamn, kategorietiketter och datapunktvärden refererar till celler i en [ChartDataWorkbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagram‑element. När du bygger anpassad data, håll kategorirader och serie‑värderader i linje så att varje punkt plottas under den avsedda kategorin.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `None` för att behålla punktens kategori‑position som en tom punkt. Använd [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategori‑samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtypen och [Chart.display_blanks_as](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/display_blanks_as/). Stödda diagram kan visa tomma värden som glapp, som nollvärden eller genom att ansluta närliggande punkter. Välj den inställning som motsvarar innebörden av saknad data i din presentation.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbelseerer, aktivera [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/invert_if_negative/) och sätt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Du kan åsidosätta beteendet för en enskild punkt med [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Dessa egenskaper påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering har företräde när både en serie och en punkt är formaterade?**

Explicit datapunkt‑formatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita serieformaten eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Grupp‑egenskaper såsom överlappning och glappbredd styr layouten och är inte formateringsöverskrivningar på punkt‑nivå.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides pålägger ingen separat fast gräns för antalet serier. I praktiken avgör presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet en användbar gräns.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Ställ in [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) på lämplig föräldraseriegrupp. Öka värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.