---
title: Hantera diagramdataserier i Python
linktitle: Dataserier
type: docs
url: /sv/python-net/chart-series/
keywords:
- diagramserier
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
description: "Lär dig hur du hanterar diagramdataserier i Python för PowerPoint (PPT/PPTX) med praktiska kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Den här artikeln beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/) i Aspose.Slides för Python, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt tillhandahåller de grundläggande elementen som definierar enskilda uppsättningar av datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/) kan utvecklare sömlöst integrera underliggande datakällor och behålla full kontroll över hur information visas, vilket resulterar i dynamiska, datadrivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med tal som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ställ in serieöverlappning**

[ChartSeries.overlap](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/overlap/)‑egenskapen styr hur staplar och kolumner överlappar i ett 2D‑diagram genom att ange ett intervall från -100 till 100. Eftersom denna egenskap är associerad med seriegruppen snarare än enskilda diagramserier är den skrivskyddad på serienivå. För att konfigurera överlappningsvärden, använd den läs/skriv‑egenskap `parent_series_group.overlap`, som tillämpar den angivna överlappningen på alla serier i den gruppen.

Nedan följer ett Python‑exempel som visar hur du skapar en presentation, lägger till ett grupperat kolumndiagram, får åtkomst till den första diagramserien, konfigurerar överlappningsinställningen och sedan sparar resultatet som en PPTX‑fil:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till ett grupperat kolumndiagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Ställ in serieöverlappningen.
        series.parent_series_group.overlap = series_overlap

    # Spara presentationsfilen till disk.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Serieöverlappning](series_overlap.png)

## **Ändra seriefyllningsfärg**

Aspose.Slides gör det enkelt att anpassa fyllningsfärgerna för diagramserier, så att du kan markera specifika datapunkter och skapa visuellt tilltalande diagram. Detta uppnås via [Format](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/format/)-objektet, som stöder olika fyllningstyper, färgkonfigurationer och andra avancerade stilalternativ. Efter att ha lagt till ett diagram på en bild och fått åtkomst till önskad serie, hämta helt enkelt serien och tillämpa den lämpliga fyllningsfärgen. Förutom solida fyllningar kan du även utnyttja gradient‑ eller mönsterfyllningar för ökad designflexibilitet. När du har ställt in färgerna enligt dina krav, spara presentationen för att slutföra den uppdaterade utformningen.

Följande Python‑kodexempel visar hur du ändrar färgen på den första serien:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till ett grupperat kolumndiagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Ställ in färgen på den första serien.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Spara presentationsfilen till disk.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Färgen på serien](series_color.png)

## **Byt namn på en serie**

Aspose.Slides erbjuder ett enkelt sätt att förändra namnen på diagramserier, vilket underlättar att märka data på ett tydligt och meningsfullt sätt. Genom att få åtkomst till den relevanta arbetsblads-cellen i diagramdata kan utvecklare anpassa hur data presenteras. Denna ändring är särskilt användbar när serienamn måste uppdateras eller förtydligas utifrån dataens kontext. Efter att ha bytt namn på serien kan presentationen sparas för att bevara ändringarna.

Nedan följer ett Python‑kodsnutt som demonstrerar processen i praktiken.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till ett grupperat kolumndiagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Ställ in namnet på den första serien.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Spara presentationsfilen till disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Följande Python‑kod visar ett alternativt sätt att ändra serienamnet:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till ett grupperat kolumndiagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Ställ in namnet på den första serien.
    series.name.as_cells[0].value = series_name

    # Spara presentationsfilen till disk.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Resultatet:

![Seriens namn](series_name.png)

## **Hämta automatisk seriefyllningsfärg**

Aspose.Slides för Python låter dig hämta den automatiska fyllningsfärgen för diagramserier inom ett plot‑område. Efter att ha skapat en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen kan du erhålla en referens till önskad bild genom index, sedan lägga till ett diagram med den typ du föredrar (t.ex. `ChartType.CLUSTERED_COLUMN`). Genom att få åtkomst till serierna i diagrammet kan du hämta den automatiska fyllningsfärgen.

Python‑koden nedan demonstrerar processen i detalj.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till ett grupperat kolumndiagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Hämta fyllningsfärgen för serien.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Exempelutdata:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Ställ in inverterade fyllningsfärger för en serie**

När din dataserie innehåller både positiva och negativa värden kan det göra diagrammet svårt att läsa om varje stapel eller kolumn får samma färg. Aspose.Slides för Python låter dig tilldela en inverterad fyllningsfärg – en separat fyllning som automatiskt appliceras på datapunkter som ligger under noll – så att negativa värden framträder tydligt. I det här avsnittet lär du dig hur du aktiverar alternativet, väljer en lämplig färg och sparar den uppdaterade presentationen.

Följande kodexempel demonstrerar operationen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Lägg till nya kategorier.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Lägg till en ny serie.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Fyll i seriedatan.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Ställ in färginställningarna för serien.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den inverterade solida fyllningsfärgen](inverted_solid_fill_color.png)

Du kan invertera fyllningsfärgen för en enskild datapunkt istället för hela serien. Hämta helt enkelt den önskade `ChartDataPoint` och sätt dess egenskap `invert_if_negative` till `True`.

Följande kodexempel visar hur du gör detta:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Rensa data för specifika datapunkter**

Ibland innehåller ett diagram testvärden, avvikelser eller föråldrade poster som du måste ta bort utan att bygga om hela serien. Aspose.Slides för Python låter dig rikta in dig på vilken datapunkt som helst via index, rensa dess innehåll och omedelbart uppdatera plot‑området så att återstående punkter flyttas och axlarna skalas automatiskt.

Följande kodexempel demonstrerar operationen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in serieavståndsbredd**

Avståndsbredd styr mängden tomt utrymme mellan intilliggande kolumner eller staplar – bredare mellanrum betonar individuella kategorier, medan smalare mellanrum ger ett tätare, mer kompakt utseende. Genom Aspose.Slides för Python kan du finjustera denna parameter för en hel serie och uppnå exakt den visuella balansen din presentation kräver utan att ändra den underliggande datan.

Följande kodexempel visar hur du ställer in avståndsbredden för en serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Skapa en tom presentation.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till ett diagram med standarddata.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Spara presentationen till disk.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Ställ in värdet för gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Spara presentationen till disk.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Avståndsbredden](gap_width.png)

## **Vanliga frågor**

**Finns det en gräns för hur många serier ett enda diagram kan innehålla?**

Aspose.Slides har ingen fast gräns för hur många serier du kan lägga till. Den praktiska takgränsen bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**Vad händer om kolumnerna inom en grupp är för nära varandra eller för långt ifrån varandra?**

Justera inställningen [gap_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartseries/gap_width/) för den serien (eller dess föräldragrupp). Att öka värdet breddar avståndet mellan kolumnerna, medan ett minskat värde för minskar avståndet och får dem att komma närmare varandra.