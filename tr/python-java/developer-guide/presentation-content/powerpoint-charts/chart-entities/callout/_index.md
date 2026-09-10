---
title: Python Kullanarak Sunum Grafiklerinde Çağrı Balonlarını Yönetme
linktitle: Çağrı Balonu
type: docs
url: /tr/python-java/callout/
keywords:
- grafik çağrı balonu
- çağrı balonu kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java içinde çağrı balonlarını oluşturun ve biçimlendirin, kısa kod örnekleriyle, PPT ve PPTX ile uyumlu, sunum iş akışlarını otomatikleştirmek için."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri etiketleri için çağrı balonları (callouts) ile nasıl çalışılacağını açıklar. [setShowLabelAsDataCallout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) yöntemini kullanarak etiketlerin çağrı balonu olarak görüntülenmesini, bir halka grafik için çağrı balonuyla ilgili etiket ayarlarının nasıl yapılandırılacağını ve çağrı balonları ile görünümlerinin sunum PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarıldığında korunduğunu gösterir.

## **Çağrı Balonlarını Kullanma**

[DataLabelFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datalabelformat/) sınıfının [getShowLabelAsDataCallout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) ve [setShowLabelAsDataCallout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) yöntemleri, bir grafik veri etiketinin çağrı balonu olarak mı yoksa normal bir veri etiketi olarak mı görüntüleneceğini belirler.

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

## **Halka Grafik için Çağrı Balonu Ayarlama**

Aspose.Slides for Python via Java, bir halka grafik için seri veri etiketi çağrı balonu şeklini ayarlamayı destekler. Aşağıdaki örnek bunu göstermektedir.

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

## **SSS**

**Çağrı balonları, bir sunum PDF, HTML5, SVG veya görüntülere dönüştürüldüğünde korunur mu?**

Evet. Çağrı balonları grafik render işleminin bir parçasıdır, bu nedenle [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/python-java/export-to-html5/), [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) veya [raster görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/) olarak dışa aktardığınızda, slayt biçimlendirmesiyle birlikte korunur.

**Özel yazı tipleri çağrı balonlarında çalışır mı ve dışa aktarımda görünümleri korunur mu?**

Evet. Aspose.Slides, sunuma [gömülü yazı tipleri](/slides/tr/python-java/embedded-font/) eklemeyi destekler ve [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) gibi dışa aktarımlarda yazı tipi gömmeyi kontrol eder, böylece çağrı balonları farklı sistemlerde aynı şekilde görünür.