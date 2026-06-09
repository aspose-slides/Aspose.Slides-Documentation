---
title: Python ile Sunum Grafiklerinde Çağrı Kutularını Yönetme
linktitle: Çağrı Kutusu
type: docs
url: /tr/python-net/callout/
keywords:
- grafik çağrı kutusu
- çağrı kutusu kullanımı
- veri etiketi
- etiket formatı
- Python
- Aspose.Slides
description: "Aspose.Slides for Python .NET'de çağrı kutularını oluşturun ve biçimlendirin, PPT, PPTX ve ODP ile uyumlu, sunum iş akışlarını otomatikleştiren özlü kod örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri etiketleri için çağrı kutularının nasıl kullanılacağını açıklar. `show_label_as_data_callout` özelliğini kullanarak etiketlerin çağrı kutusu olarak görüntülenmesini, bir halka grafik için çağrı kutusu ile ilgili etiket ayarlarının nasıl yapılandırılacağını ve çağrı kutularının ve görünümlerinin sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarıldığında korunduğunu gösterir.

## **Çağrı Kutularını Kullanma**
Yeni **show_label_as_data_callout** özelliği **DataLabelFormat** sınıfına eklenmiştir; bu, belirtilen grafiğin veri etiketinin veri çağrı kutusu olarak mı yoksa veri etiketi olarak mı görüntüleneceğini belirler. Aşağıdaki örnekte, Çağrı Kutuları ayarlanmıştır.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Halka Grafik İçin Çağrı Kutusu Ayarlama**
Aspose.Slides for Python via .NET, bir Halka grafik için seri veri etiketi çağrı kutusu şekli ayarlamayı destekler. Aşağıda örnek bir kod parçası verilmiştir.

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

## **SSS**

**Sunumu PDF, HTML5, SVG veya görüntülere dönüştürürken çağrı kutuları korunur mu?**

Evet. Çağrı kutuları grafik oluşturmanın bir parçasıdır, bu yüzden [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/python-net/export-to-html5/), [SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) veya [raster images](/slides/tr/python-net/convert-powerpoint-to-png/) dışa aktarıldığında slayt biçimlendirmesiyle birlikte korunur.

**Özel yazı tipleri çağrı kutularında çalışıyor mu ve dışa aktarımda görünüşleri korunabilir mi?**

Evet. Aspose.Slides, sunuma [embedding fonts](/slides/tr/python-net/embedded-font/) eklemeyi destekler ve [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) gibi dışa aktarımlarda yazı tipi gömülmesini kontrol eder, böylece çağrı kutuları farklı sistemlerde aynı şekilde görünür.