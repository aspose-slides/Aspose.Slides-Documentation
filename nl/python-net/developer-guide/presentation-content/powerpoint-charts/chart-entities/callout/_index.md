---
title: Beheer callouts in presentatiediagrammen met Python
linktitle: Callout
type: docs
url: /nl/python-net/callout/
keywords:
- grafiek-callout
- callout gebruiken
- gegevenslabel
- labelindeling
- Python
- Aspose.Slides
description: "Maak en style callouts in Aspose.Slides voor Python .NET met beknopte code-voorbeelden, compatibel met PPT, PPTX en ODP om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe u callouts voor gegevenslabels in een diagram in Aspose.Slides kunt gebruiken. Het laat zien hoe u de eigenschap `show_label_as_data_callout` gebruikt om labels als callouts weer te geven, hoe u callout‑gerelateerde labelinstellingen voor een donuts‑diagram kunt configureren, en merkt op dat callouts en hun uiterlijk behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Callouts gebruiken**
Nieuwe eigenschap **show_label_as_data_callout** is toegevoegd aan de klasse **DataLabelFormat**, die bepaalt of het gegevenslabel van het opgegeven diagram wordt weergegeven als data‑callout of als gegevenslabel. In het onderstaande voorbeeld hebben we de callouts ingesteld.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Callout instellen voor donuts‑diagram**
Aspose.Slides for Python via .NET biedt ondersteuning voor het instellen van de callout‑vorm van de gegevenslabels voor een donuts‑diagram. Hieronder staat een voorbeeld.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Ja. Callouts maken deel uit van de rendering van het diagram, dus wanneer u exporteert naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/nl/python-net/export-to-html5/), [SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/), of [rasterafbeeldingen](/slides/nl/python-net/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Ja. Aspose.Slides ondersteunt het [inbedden van lettertypen](/slides/nl/python-net/embedded-font/) in de presentatie en regelt het inbedden van lettertypen tijdens exporten zoals [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), waardoor de callouts er op verschillende systemen hetzelfde uitzien.