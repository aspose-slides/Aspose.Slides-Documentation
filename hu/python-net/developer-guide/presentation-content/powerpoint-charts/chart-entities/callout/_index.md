---
title: "Felhívások kezelése a prezentációs diagramokban Pythonban"
linktitle: "Felhívás"
type: docs
url: /hu/python-net/callout/
keywords:
- "diagram felhívás"
- "felhívás használata"
- "adatcímke"
- "címkeformátum"
- "Python"
- "Aspose.Slides"
description: "Készítsen és formázzon felhívásokat az Aspose.Slides for Python .NET-ben tömör kódrészletekkel, kompatibilis PPT, PPTX és ODP formátumokkal, a prezentációs munkafolyamatok automatizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet használni a felhívásokat a diagram adatcímkéinél az Aspose.Slides-ban. Megmutatja, hogyan kell használni a `show_label_as_data_callout` tulajdonságot a címkék felhívásként való megjelenítéséhez, hogyan kell konfigurálni a felhívással kapcsolatos címke‑beállításokat egy gyűrűdiagramhoz, és megjegyzi, hogy a felhívások és megjelenésük megmaradnak, amikor a bemutatókat PDF, HTML5, SVG és raszteres képformátumokra exportálják.

## **Felhívások használata**
Az **DataLabelFormat** osztályhoz új **show_label_as_data_callout** tulajdonságot adtunk hozzá, amely meghatározza, hogy a megadott diagram adatcímkéje felhívásként vagy adatcímkéként jelenik meg. Az alább bemutatott példában beállítottuk a felhívásokat.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Felhívás beállítása gyűrűdiagramhoz**
Az Aspose.Slides for Python via .NET támogatja a sorozat adatcímke felhívás alakjának beállítását egy gyűrűdiagramhoz. Az alábbi minta példát láthatja.

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

**Megmaradnak a felhívások, amikor a prezentációt PDF‑re, HTML5‑re, SVG‑re vagy képekre konvertálják?**

Igen. A felhívások a diagram renderelésének részei, ezért amikor a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/python-net/export-to-html5/), [SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/), vagy [raszteres képek](/slides/hu/python-net/convert-powerpoint-to-png/) formátumba exportálsz, megmaradnak a dia formázásával együtt.

**Működnek az egyedi betűtípusok a felhívásokban, és megőrizhető-e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/python-net/embedded-font/) a prezentációba, és szabályozza a betűtípus‑beágyazást az exportálások során, például a [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) esetén, biztosítva, hogy a felhívások minden rendszerben egységesen jelenjenek meg.