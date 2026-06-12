---
title: Optimaliseer grafiekberekeningen voor presentaties in Python
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/python-net/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- werkelijke positie
- kindelement
- ouderelement
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisie‑controle in Aspose.Slides for Python via .NET voor PPT, PPTX en ODP, met praktische codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en lay-outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafiekelementen kunt ophalen, inclusief de feitelijke positie en grootte van elementen die `ActualLayout` implementeren en de werkelijke waarden van grafiekassen. Het legt ook uit dat deze waarden worden ingevuld na validatie van de grafieklay-out.

Daarnaast toont het artikel hoe u de werkelijke positie van bovenliggende grafiekelementen kunt verkrijgen en hoe u grafiekonderdelen zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om informatie over de grafieklay-out te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmatically te regelen.

## **Bereken werkelijke waarden van grafiekelementen**
Aspose.Slides for Python via .NET biedt een eenvoudige API om deze eigenschappen op te halen. Dit helpt u bij het berekenen van de werkelijke waarden van grafiekelementen. De werkelijke waarden omvatten de positie van elementen die de [IActualLayout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/iactuallayout/)‑klasse erven (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) en de werkelijke aswaarden (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Bereken werkelijke positie van bovenliggende grafiekelementen**
Aspose.Slides for Python via .NET biedt een eenvoudige API om deze eigenschappen op te halen. Eigenschappen van IActualLayout geven informatie over de werkelijke positie van het bovenliggende grafiekelement. Het is noodzakelijk om vooraf de methode IChart.ValidateChartLayout() aan te roepen om de eigenschappen met werkelijke waarden te vullen.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Informatie verbergen in grafiek**
Dit onderwerp helpt u te begrijpen hoe u informatie uit een grafiek kunt verbergen. Met Aspose.Slides for Python via .NET kunt u de **Titel, verticale as, horizontale as** en **rasterlijnen** uit een grafiek verbergen. De onderstaande code‑voorbeeld toont hoe u deze eigenschappen kunt gebruiken.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Grafiektitel verbergen
    chart.has_title = False

    # Waarde-as verbergen
    chart.axes.vertical_axis.is_visible = False

    # Categorie-as zichtbaarheid
    chart.axes.horizontal_axis.is_visible = False

    # Legenda verbergen
    chart.has_legend = False

    # Grote rasterlijnen verbergen
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Instellen van de lijnekleur van de reeks
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Werken externe Excel‑werkboeken als gegevensbron, en hoe beïnvloedt dat de herberekening?**

Ja. Een grafiek kan naar een extern werkboek verwijzen: wanneer u de externe bron aansluit of ververst, worden formules en waarden uit dat werkboek gehaald, en past de grafiek de updates toe tijdens open‑/bewerkingsbewerkingen. De API laat u het pad van het [externe werkboek](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) opgeven en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlijnen](/slides/nl/python-net/trend-line/) (lineair, exponentieel en andere) worden toegevoegd en bijgewerkt door Aspose.Slides; hun parameters worden automatisch opnieuw berekend op basis van de seriedata, zodat u geen eigen berekeningen hoeft te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar zijn eigen [externe werkboek](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/set_external_workbook/) verwijzen, of u kunt per grafiek een extern werkboek maken/vervangen, onafhankelijk van de andere.