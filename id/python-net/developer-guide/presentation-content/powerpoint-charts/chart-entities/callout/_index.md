---
title: Kelola Callout dalam Grafik Presentasi dengan Python
linktitle: Callout
type: docs
url: /id/python-net/callout/
keywords:
- callout grafik
- gunakan callout
- label data
- format label
- Python
- Aspose.Slides
description: "Buat dan beri gaya callout di Aspose.Slides untuk Python .NET dengan contoh kode singkat, kompatibel dengan PPT, PPTX, dan ODP untuk mengotomatiskan alur kerja presentasi."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data grafik di Aspose.Slides. Artikel ini memperlihatkan cara menggunakan properti `show_label_as_data_callout` untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label terkait callout untuk grafik donat, serta mencatat bahwa callout dan tampilannya dipertahankan ketika presentasi diekspor ke PDF, HTML5, SVG, dan format gambar raster.

## **Menggunakan Callout**
Properti baru **show_label_as_data_callout** telah ditambahkan ke kelas **DataLabelFormat**, yang menentukan apakah label data grafik yang ditentukan akan ditampilkan sebagai data callout atau sebagai label data. Pada contoh di bawah, kami telah mengatur Callout.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Mengatur Callout untuk Grafik Donat**
Aspose.Slides untuk Python via .NET menyediakan dukungan untuk mengatur bentuk callout label data seri untuk grafik Donat. Contoh sampel diberikan di bawah.

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

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari perenderan grafik, sehingga ketika Anda mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/id/python-net/export-to-html5/), [SVG](/slides/id/python-net/render-a-slide-as-an-svg-image/), atau [gambar raster](/slides/id/python-net/convert-powerpoint-to-png/), mereka dipertahankan bersama dengan pemformatan slide.

**Apakah font khusus berfungsi dalam callout, dan dapatkah tampilannya dipertahankan saat diekspor?**

Ya. Aspose.Slides mendukung [penyematan font](/slides/id/python-net/embedded-font/) ke dalam presentasi dan mengontrol penyematan font selama ekspor seperti [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.