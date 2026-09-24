---
title: Hantera diagramdataserier i presentationer i Python
linktitle: Dataserier
type: docs
url: /sv/python-net/chart-series/
keywords:
- diagramserie
- seriens överlapp
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlapp, gapbredd och negativa värden i presentationer med Python."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdatabok. En [ChartSeries](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/) representerar ett set av relaterade värden, och varje [ChartDataPoint](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [ChartCategory](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartcategory/)‑objekt tillhandahåller etiketter eller grupperingsvärden som delas av serierna. Serienamn, kategorier och punktvärden är därför kopplade till [ChartDataCell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatacell/)‑objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de återstående cellerna för serievärden. Arbetsblad, rad‑ och kolumnindex som skickas till [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar värden i arbetsboken.

Diagraminställningar har tre olika omfång:

- Inställningar på serienivå, såsom [ChartSeries.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/format/), ger standardutseendet för alla punkter i en serie.
- Punktinställningar, såsom [ChartDataPoint.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/format/), åsidosätter serieutseendet för en enskild punkt.
- Gruppinställningar gäller kompatibla serier som tillhör samma [ChartSeriesGroup](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/). Åtkomst till gruppen sker via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/parent_series_group/) när du behöver ange alternativ som överlapp eller gapbredd.

När ingen explicit fyllning för punkt eller serie har angetts, bestäms det automatiska utseendet av diagramstilen och temat. När både serie‑ och punktformatering finns, har punktformateringen företräde för den punkten.

![Diagramserie PowerPoint](chart-series-powerpoint.png)

## **Ställ in överlapp för diagramserien**

[ChartSeries.overlap](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/overlap/) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriesgruppen. Ställ in [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/overlap/) för att uppdatera varje kompatibel serie i den gruppen. Detta alternativ gäller diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriesgrupper i ett kombinationsdiagram.

Följande exempel anger överlapp för gruppen som innehåller den första serien:

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

![Seriens överlapp](series_overlap.png)

## **Ändra fyllningsfärg för serien**

Använd [ChartSeries.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/format/) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning, åsidosätter dess [ChartDataPoint.format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/format/) inställning serie­fyllningen för den punkten.

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

![Seriens färg](series_color.png)

## **Ändra serienamnet**

Ett serienamn lagras i diagramdataboken och visas normalt i förklaringen. I standardarbetsboken som skapas för ett grupperat kolumndiagram ligger cell B1 i rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen tydlig:

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

Du kan också uppdatera den cell som redan refereras av [ChartSeries.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/name/). Detta förfarande undviker antagandet om en specifik rad och kolumn i ett befintligt diagram:

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

![Seriens namn](series_name.png)

## **Hämta den automatiska fyllningsfärgen för serien**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) returnerar färgen som beräknas utifrån serie‑indexet och diagramstilen. Detta är färgen som används när serie­fyllningen inte har definierats explicit. Metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

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

De exakt färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbelserier kan [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/invert_if_negative/) visa negativa värden med en annan fyllning. Ställ in den vanliga serie­fyllningen till solid, aktivera inversion och tilldela färgen för negativa värden via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg förändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladsrad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Du kan aktivera inversion för en enskild punkt via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten får också ett negativt värde så att effekten syns:

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

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess bakgrundscell i arbetsboken till `None`. För ett kolumndiagram är det plottade värdet tillgängligt via [ChartDataPoint.value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/value/). Datapunkten förblir på samma kategoriposition, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

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

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder dessutom en storlekscell. Rensa bara den cell som representerar det värde du avser att ta bort. Anropa inte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapointcollection/clear/) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter i samlingen.

## **Styr visning av tomma celler**

En tom cell i arbetsboken representerar saknade data; en cell som innehåller `0` representerar ett känt numeriskt värde. Sätt [ChartDataCell.value](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatacell/value/) till `None` för att göra en cell tom. En numerisk nolla förblir noll oavsett inställningen för tomma celler.

Använd [Chart.display_blanks_as](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/display_blanks_as/) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas utan att fylla den tomma arbetsboks‑cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [ChartDataWorkbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller serienamnet. De slutgiltiga data är `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Lämna dag 3 verkligen tom, samtidigt som du behåller dess kategori och datapunkt.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Varje utdatafil lagrar det läge som tilldelats före sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara bara en version, ange önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i alla fall:

![Linjediagram med identiska data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör det enkelt att jämföra alla tre lägen. Stapel‑ och kolumndiagram har ingen linje att koppla över en saknad kategori, så `SPAN` kan inte skapa den förbindelse som visas ovan; en saknad kolumn och en noll‑höjd kolumn kan också se lika ut. På samma sätt har ett spridningsdiagram med enbart markörer ingen anslutande linje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ställ in seriegap‑bredd**

Gap‑bredd är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som procent av stapel‑ eller kolumnbredden. Liksom överlapp tillhör den överordnade seriesgruppen snarare än en enskild serie. Sätt [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) en gång för gruppen. Ett högre värde skapar mer utrymme mellan klustren; ett lägre värde gör dem tätare.

Följande exempel ändrar gap‑bredden och sparar endast den slutgiltiga presentationen:

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

![Gap‑bredden](gap_width.png)

## **FAQ**

**Vilka diagramtyper stöder dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/)‑enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelstorlekar. Använd den datapunkt‑skapande metod som matchar serietypen. Alternativ som överlapp och gap‑bredd gäller endast kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegupp?**

En [ChartSeriesGroup](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/) innehåller kompatibla serier som delar gruppnivå‑plot‑inställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie inte nödvändigtvis ändrar varje serie i diagrammet.

**Innehåller ett nyss skapat diagram standarddata?**

Ja. Som standard skapar [ShapeCollection.add_chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_chart/) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till en helt anpassad datamängd. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks‑celler?**

Serienamn, kategorietiketter och datapunktvärden refererar celler i en [ChartDataWorkbook](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramdel. När du bygger anpassade data, håll kategorirader och serie‑värderader i takt så att varje punkt plottas under avsedd kategori.

**Hur rensar jag en punkt utan att ta bort hela serien?**

Sätt den relevanta värdecellen till `None` för att behålla punktens kategoriposition som en tom punkt. Använd [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapointcollection/clear/) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategori‑samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtypen och [Chart.display_blanks_as](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/display_blanks_as/). Stödda diagram kan visa tomma värden som gap, som nollvärden eller genom att koppla ihop närliggande punkter. Välj den inställning som motsvarar betydelsen av saknade data i din presentation. Se [Styr visning av tomma celler](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbelserier, aktivera [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/invert_if_negative/) och sätt [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Du kan åsidosätta beteendet för en enskild punkt med [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Dessa egenskaper påverkar formateringen, inte de lagrade numeriska värdena.

**Vilken formatering vinner när både en serie och en punkt är formaterade?**

Explicit datapunkt‑formatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita serie‑formatet eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Grupp‑egenskaper som överlapp och gap‑bredd styr layout och är inte punkt‑nivå‑formateringsåsidosättningar.

**Finns det någon gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides inför inget separat fast maxantal serier. I praktiken bestäms den användbara gränsen av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån?**

Ställ in [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) på den relevanta överordnade seriesgruppen. Öka värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.