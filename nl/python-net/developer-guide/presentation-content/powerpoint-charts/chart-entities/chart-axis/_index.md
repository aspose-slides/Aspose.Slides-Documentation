---
title: Grafiekassen in presentaties aanpassen met Python
linktitle: Grafiekas
type: docs
url: /nl/python-net/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximumwaarde
- minimumwaarde
- aslijn
- datumformaat
- as titel
- aspositie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor Python via .NET kunt gebruiken om grafiekassen in PowerPoint- en OpenDocument-presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen kunt aanpassen in Aspose.Slides. Het laat zien hoe u de werkelijke aswaarden kunt ophalen, gegevens tussen assen kunt uitwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categorieas kunt wijzigen, het datumformaat voor categorieaswaarden kunt instellen, een as‑titel kunt draaien, de aspositie kunt instellen en een eenheidslabel op de waardenas kunt weergeven.

## **De maximale waarden op de verticale as van grafieken ophalen**
Aspose.Slides voor Python via .NET maakt het mogelijk om de minimum‑ en maximumwaarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Haal de werkelijke maximumwaarde van de as op.
1. Haal de werkelijke minimumwaarde van de as op.
1. Haal de werkelijke hoofd‑eenheid van de as op.
1. Haal de werkelijke sub‑eenheid van de as op.
1. Haal de werkelijke schaal van de hoofd‑eenheid van de as op.
1. Haal de werkelijke schaal van de sub‑eenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—laat zien hoe u de vereiste waarden in Python kunt verkrijgen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Slaat de presentatie op
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gegevens tussen assen uitwisselen**
Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen uit te wisselen — de gegevens die op de verticale as (y‑as) worden weergegeven, verplaatsen zich naar de horizontale as (x‑as) en vice versa.

Deze Python‑code toont hoe u de gegevensuitwisseling tussen assen in een grafiek kunt uitvoeren:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Maakt lege presentatie
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # Verwisselt rijen en kolommen
    chart.chart_data.switch_row_column()
            
    # Slaat presentatie op
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Verticale as uitschakelen voor lijndiagrammen**

Deze Python‑code toont hoe u de verticale as voor een lijndiagram kunt verbergen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Horizontale as uitschakelen voor lijndiagrammen**

Deze code toont hoe u de horizontale as voor een lijndiagram kunt verbergen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Categorieas wijzigen**

Met de eigenschap **CategoryAxisType** kunt u het gewenste type categorieas opgeven (**date** of **text**). Deze Python‑code demonstreert de bewerking:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Het datumformaat voor een categorieaswaarde instellen**
Aspose.Slides voor Python via .NET maakt het mogelijk om het datumformaat voor een categorieaswaarde in te stellen. De bewerking wordt gedemonstreerd in deze Python‑code:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **De rotatiehoek voor een grafiektitel van de as instellen**
Aspose.Slides voor Python via .NET maakt het mogelijk om de rotatiehoek voor een grafiektitel van de as in te stellen. Deze Python‑code demonstreert de bewerking:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **De positie van de as instellen in een categorie‑ of waardenas**
Aspose.Slides voor Python via .NET maakt het mogelijk om de aspositie in een categorie‑ of waardenas in te stellen. Deze Python‑code laat zien hoe u deze taak kunt uitvoeren:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Weergave van een eenheidslabel op de waardenas van de grafiek inschakelen**
Aspose.Slides voor Python via .NET maakt het mogelijk om een grafiek zo te configureren dat er een eenheidslabel op de waardenas wordt weergegeven. Deze Python‑code demonstreert de bewerking:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/cross_type/); u kunt kiezen om bij nul, bij de maximale categorie/waarde of bij een specifieke numerieke waarde te kruisen. Dit is nuttig om de X‑as omhoog of omlaag te verschuiven of om een basislijn te benadrukken.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as (naast, buiten, binnen)?**

Stel de [label position](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/axis/major_tick_mark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine grafieken.