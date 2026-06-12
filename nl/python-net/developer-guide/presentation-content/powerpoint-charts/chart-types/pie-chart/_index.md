---
title: Cirkeldiagrammen aanpassen in presentaties met Python
linktitle: Cirkeldiagram
type: docs
url: /nl/python-net/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u cirkeldiagrammen kunt maken en aanpassen in Python met Aspose.Slides, exporteerbaar naar PowerPoint en OpenDocument, waardoor u uw dataverhaal in enkele seconden versterkt."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen in Aspose.Slides kunt werken. Het toont hoe u secundaire plot‑opties kunt configureren voor Pie of Pie‑ en Bar of Pie‑diagrammen, en hoe u automatische kleuring van segmenten inschakelt voor een standaard cirkeldiagram.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van series‑ en labelinstellingen, het vervangen van de standaard diagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Secundaire plotopties voor Pie of Pie‑ en Bar of Pie‑diagram**
Aspose.Slides voor Python via .NET ondersteunt nu secundaire plotopties voor Pie of Pie‑ of Bar of Pie‑diagrammen. In dit onderwerp laten we met een voorbeeld zien hoe u deze opties kunt specificeren met Aspose.Slides. Volg hiervoor de onderstaande stappen:

1. Maak een object van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Voeg een diagram toe op de dia.
1. Specificeer de secundaire plotopties van het diagram.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie‑diagram ingesteld.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse
with slides.Presentation() as presentation:
    # Voeg een diagram toe aan de dia
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Stel verschillende eigenschappen in
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Schrijf de presentatie naar schijf
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Automatische kleuring van cirkeldiagramsegmenten instellen**
Aspose.Slides voor Python via .NET biedt een eenvoudige API voor het automatisch kleuren van segmenten in een cirkeldiagram. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de Presentatie‑klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaarddata.
1. Stel de diagramtitel in.
1. Zet de eerste serie op Waarden tonen.
1. Stel de index van het diagram‑datablad in.
1. Verkrijg het werkblad met diagramdata.
1. Verwijder de standaardgegenereerde series en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg een nieuwe serie toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation‑klasse die een PPTX‑bestand representeert
with slides.Presentation() as presentation:
	# Open de eerste dia
	slide = presentation.slides[0]

	# Voeg een diagram toe met standaarddata
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Instellen van de diagramtitel
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Stel de eerste serie in om waarden weer te geven
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Instellen van de index van het diagram‑datablad
	defaultWorksheetIndex = 0

	# Het ophalen van het werkblad met diagramdata
	fact = chart.chart_data.chart_data_workbook

	# Verwijder de standaardgegenereerde series en categorieën
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Nieuwe categorieën toevoegen
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Nieuwe serie toevoegen
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Nu de seriedata vullen
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Worden de varianten 'Pie of Pie' en 'Bar of Pie' ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de typen 'Pie of Pie' en 'Bar of Pie'.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/get_image/) (bijvoorbeeld PNG) zonder de volledige presentatie.