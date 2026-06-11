---
title: Hantera anrop i presentationsdiagram med Python
linktitle: Anrop
type: docs
url: /sv/python-net/callout/
keywords:
- diagramanrop
- använd anrop
- dataetikett
- etikettformat
- Python
- Aspose.Slides
description: "Skapa och formatera anrop i Aspose.Slides för Python .NET med korta kodexempel, kompatibla med PPT, PPTX och ODP för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med anrop för diagramdataetiketter i Aspose.Slides. Den visar hur man använder egenskapen `show_label_as_data_callout` för att visa etiketter som anrop, hur man konfigurerar anropsrelaterade etikettinställningar för ett donutdiagram, och noterar att anrop och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Användning av anrop**
Ny egenskap **show_label_as_data_callout** har lagts till i **DataLabelFormat**-klassen, som avgör om den angivna diagrammets dataetikett ska visas som dataanrop eller som dataetikett. I exemplet nedan har vi ställt in anropen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in anrop för donutdiagram**
Aspose.Slides for Python via .NET erbjuder stöd för att ställa in serie‑dataetikett‑anropsformen för ett donutdiagram. Nedanstående exempel ges.

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

## **Vanliga frågor**

**Bevaras anrop när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Anrop är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/),[HTML5](/slides/sv/python-net/export-to-html5/),[SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/), eller [rasterbilder](/slides/sv/python-net/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar anpassade teckensnitt i anrop, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stödjer [inbäddning av teckensnitt](/slides/sv/python-net/embedded-font/) i presentationen och styr teckensnittsinbäddning vid export såsom [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), vilket säkerställer att anrop ser likadana ut på olika system.