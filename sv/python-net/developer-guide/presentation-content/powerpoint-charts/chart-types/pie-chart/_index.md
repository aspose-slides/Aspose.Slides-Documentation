---
title: Anpassa cirkeldiagram i presentationer med Python
linktitle: Cirkeldiagram
type: docs
url: /sv/python-net/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar cirkeldiagram i Python med Aspose.Slides, exportbart till PowerPoint och OpenDocument, vilket stärker din datapresentation på sekunder."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med cirkeldiagram i Aspose.Slides. Den visar hur du konfigurerar sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram, samt hur du aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, och spara den uppdaterade presentationen.

## **Sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram**

Aspose.Slides för Python via .NET stödjer nu sekundära plotalternativ för Pie of Pie- eller Bar of Pie-diagram. I det här avsnittet kommer vi med ett exempel att visa hur du specificerar dessa alternativ med Aspose.Slides. För att ange egenskaperna, följ stegen nedan:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Lägg till ett diagram på bilden.
1. Specificera diagrammets sekundära plotalternativ.
1. Skriv presentationen till disk.

I exemplaret nedan har vi ställt in olika egenskaper för Pie of Pie-diagrammet.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapa en instans av Presentation-klassen
with slides.Presentation() as presentation:
    # Lägg till diagram på bilden
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Ställ in olika egenskaper
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Skriv presentationen till disk
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in automatiska segmentfärger för cirkeldiagram**

Aspose.Slides för Python via .NET erbjuder ett enkelt API för att sätta automatiska färger för segment i cirkeldiagram. Exempelkoden tillämpar inställningarna som nämns ovan.

1. Skapa en instans av Presentation-klassen.
1. Få åtkomst till den första bilden.
1. Lägg till ett diagram med standarddata.
1. Ange diagrammets titel.
1. Ställ in den första serien på Visa värden.
1. Ange indexet för diagrammets datasblad.
1. Hämta diagrammets dataarbetsblad.
1. Ta bort standardgenererade serier och kategorier.
1. Lägg till nya kategorier.
1. Lägg till nya serier.

Skriv den modifierade presentationen till en PPTX-fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation-klassen som representerar PPTX-fil
with slides.Presentation() as presentation:
	# Åtkomst till första bilden
	slide = presentation.slides[0]

	# Lägg till diagram med standarddata
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Ställ in diagramtitel
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Ställ in första serien på Visa värden
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Ställ in indexet för diagrammets datablad
	defaultWorksheetIndex = 0

	# Hämtar diagrammets dataarbetsblad
	fact = chart.chart_data.chart_data_workbook

	# Ta bort standardgenererade serier och kategorier
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Lägger till nya kategorier
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Lägger till ny serie
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Fyller nu i seriedata
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Stöds 'Pie of Pie' och 'Bar of Pie'-varianterna?**

Ja, biblioteket [stödjer](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/) ett sekundärt plot för cirkeldiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera endast diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/get_image/) (t.ex. PNG) utan hela presentationen.