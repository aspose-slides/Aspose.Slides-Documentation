---
title: Kelola Callout dalam Grafik Presentasi Menggunakan Python
linktitle: Callout
type: docs
url: /id/python-java/callout/
keywords:
- callout grafik
- menggunakan callout
- label data
- format label
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan gaya callout di Aspose.Slides untuk Python via Java dengan contoh kode singkat, kompatibel dengan PPT dan PPTX untuk mengotomatisasi alur kerja presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data grafik di Aspose.Slides. Artikel ini menunjukkan cara menggunakan metode [setShowLabelAsDataCallout](https://reference.aspose.com/slides/id/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label terkait callout untuk grafik donat, dan mencatat bahwa callout serta tampilannya dipertahankan ketika presentasi diekspor ke format PDF, HTML5, SVG, dan gambar raster.

## **Menggunakan Callout**

Metode [getShowLabelAsDataCallout](https://reference.aspose.com/slides/id/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) dan [setShowLabelAsDataCallout](https://reference.aspose.com/slides/id/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) dari kelas [DataLabelFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/datalabelformat/) menentukan apakah label data grafik ditampilkan sebagai callout atau sebagai label data biasa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengatur Callout untuk Grafik Donat**

Aspose.Slides untuk Python via Java mendukung pengaturan bentuk callout label data seri untuk grafik donat. Contoh berikut menunjukkan hal tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari proses rendering grafik, sehingga ketika Anda mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/id/python-java/export-to-html5/), [SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/), atau [raster images](/slides/id/python-java/convert-powerpoint-to-png/), mereka dipertahankan bersama dengan pemformatan slide.

**Apakah font khusus dapat digunakan di dalam callout, dan apakah tampilannya dapat dipertahankan pada saat ekspor?**

Ya. Aspose.Slides mendukung [embedding fonts](/slides/id/python-java/embedded-font/) ke dalam presentasi dan mengontrol penyertaan font selama ekspor seperti [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.