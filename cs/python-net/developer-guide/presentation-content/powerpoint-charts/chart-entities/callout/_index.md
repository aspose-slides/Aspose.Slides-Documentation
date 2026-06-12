---
title: Správa calloutů v grafech prezentací pomocí Pythonu
linktitle: Callout
type: docs
url: /cs/python-net/callout/
keywords:
- callout grafu
- použití calloutu
- popisek dat
- formát popisku
- Python
- Aspose.Slides
description: "Vytvářejte a formátujte callouty v Aspose.Slides pro Python .NET pomocí stručných ukázek kódu, kompatibilních s formáty PPT, PPTX a ODP, pro automatizaci pracovních postupů prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s callouty pro popisky dat v grafech v Aspose.Slides. Ukazuje, jak použít vlastnost `show_label_as_data_callout` k zobrazení popisků jako callouty, jak nastavit související nastavení popisků pro prstencový graf a upozorňuje, že callouty a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrázků.

## **Používání calloutů**
Do třídy **DataLabelFormat** byla přidána nová vlastnost **show_label_as_data_callout**, která určuje, zda bude popisek grafu zobrazen jako callout nebo jako běžný popisek. V níže uvedeném příkladu jsme nastavili callouty.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Nastavení calloutu pro prstencový graf**
Aspose.Slides pro Python via .NET poskytuje podporu pro nastavení tvaru calloutu popisku řady pro prstencový graf. Níže je uveden ukázkový příklad.

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

**Zůstávají callouty zachovány při převodu prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Callouty jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/python-net/export-to-html5/), [SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/) nebo [rastrových obrázků](/slides/cs/python-net/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní fonty v calloutech a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/python-net/embedded-font/) do prezentace a řídí vkládání fontů během exportu, například do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), což zajišťuje, že callouty vypadají stejně na různých systémech.