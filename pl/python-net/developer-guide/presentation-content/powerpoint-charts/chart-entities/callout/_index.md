---
title: Zarządzanie dymkami w wykresach prezentacji przy użyciu Pythona
linktitle: Dymek
type: docs
url: /pl/python-net/callout/
keywords:
- dymek wykresu
- użycie dymka
- etykieta danych
- format etykiety
- Python
- Aspose.Slides
description: "Twórz i stylizuj dymki w Aspose.Slides dla Pythona .NET za pomocą zwięzłych przykładów kodu, kompatybilnych z PPT, PPTX i ODP, aby automatyzować procesy pracy z prezentacjami."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z dymkami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać właściwości `show_label_as_data_callout`, aby wyświetlać etykiety jako dymki, jak konfigurować ustawienia etykiet związane z dymkami dla wykresu pierścieniowego oraz informuje, że dymki i ich wygląd są zachowywane podczas eksportu prezentacji do formatów PDF, HTML5, SVG i formatów obrazów rastrowych.

## **Używanie dymków**

Nowa właściwość **show_label_as_data_callout** została dodana do klasy **DataLabelFormat**, która określa, czy etykieta danych określonego wykresu będzie wyświetlana jako dymek danych, czy jako zwykła etykieta. W poniższym przykładzie ustawiliśmy dymki.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawienie dymka dla wykresu pierścieniowego**

Aspose.Slides for Python via .NET zapewnia obsługę ustawiania kształtu dymka etykiety danych serii dla wykresu pierścieniowego. Poniżej podano przykładowy kod.

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

**Czy dymki są zachowywane przy konwertowaniu prezentacji do PDF, HTML5, SVG lub obrazów?**

Tak. Dymki są częścią renderowania wykresu, więc przy eksporcie do [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/pl/python-net/export-to-html5/), [SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/), lub [obrazów rastrowych](/slides/pl/python-net/convert-powerpoint-to-png/), są zachowywane razem z formatowaniem slajdu.

**Czy niestandardowe czcionki działają w dymkach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [osadzanie czcionek](/slides/pl/python-net/embedded-font/) w prezentacji i kontroluje osadzanie czcionek podczas eksportu, takiego jak [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), zapewniając, że dymki wyglądają tak samo na różnych systemach.