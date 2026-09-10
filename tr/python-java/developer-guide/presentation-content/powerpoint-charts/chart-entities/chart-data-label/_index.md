---
title: Python Kullanarak Sunumlarda Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/python-java/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar için."
---
## **Giriş**

Bir grafikteki veri etiketleri, grafik veri serileri veya tek tek veri noktaları hakkında ayrıntılar gösterir. Okuyucuların veri serilerini hızlıca tanımlamasını sağlar ve grafiklerin daha kolay anlaşılmasını da sağlar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Bu Python kodu, bir grafik veri etiketinde veri hassasiyetinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yüzdeyi Etiket Olarak Görüntüleme**

Aspose.Slides for Python via Java, görüntülenen grafiklere yüzde etiketleri ayarlamanıza olanak tanır. Bu Python kodu işlemi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)
    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Veri Etiketleriyle Yüzde İşaretini Ayarlama**

Bu Python kodu, bir grafik veri etiketi için yüzde işaretinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")
    chart.getChartData().getSeries().clear()
    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Kırmızı seriyi ekle.
    series_cell = workbook.getCell(worksheet_index, 0, 1, "Reds")
    red_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.30, 0.50, 0.80, 0.65], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 1, jpype.JDouble(value))
        red_series.getDataPoints().addDataPointForBarSeries(data_cell)

    red_series.getFormat().getFill().setFillType(FillType.Solid)
    red_series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    red_label_format = red_series.getLabels().getDefaultDataLabelFormat()
    red_label_format.setShowValue(True)
    red_label_format.setNumberFormatLinkedToSource(False)
    red_label_format.setNumberFormat("0.0%")
    red_portion_format = red_label_format.getTextFormat().getPortionFormat()
    red_portion_format.setFontHeight(10)
    red_portion_format.getFillFormat().setFillType(FillType.Solid)
    red_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    # Mavi seriyi ekle.
    series_cell = workbook.getCell(worksheet_index, 0, 2, "Blues")
    blue_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.70, 0.50, 0.20, 0.35], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 2, jpype.JDouble(value))
        blue_series.getDataPoints().addDataPointForBarSeries(data_cell)

    blue_series.getFormat().getFill().setFillType(FillType.Solid)
    blue_series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)
    blue_label_format = blue_series.getLabels().getDefaultDataLabelFormat()
    blue_label_format.setShowValue(True)
    blue_label_format.setNumberFormatLinkedToSource(False)
    blue_label_format.setNumberFormat("0.0%")
    blue_portion_format = blue_label_format.getTextFormat().getPortionFormat()
    blue_portion_format.setFontHeight(10)
    blue_portion_format.getFillFormat().setFillType(FillType.Solid)
    blue_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Etiketi Bir Eksenden Uzaklığa Ayarlama**

Bu Python kodu, eksenlerden çizilen bir grafikle çalışırken kategori ekseninden etiket mesafesinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Etiket Konumunu Ayarlama**

Herhangi bir eksene dayanmadığınız bir grafik oluşturduğunuzda, örneğin bir pasta grafiği, grafik veri etiketleri kenara çok yakın olabilir. Böyle bir durumda, veri etiketinin konumunu ayarlamanız gerekir ki çizgi doğru görüntülensin.

Bu Python kodu, bir pasta grafiğinde etiket konumunun nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirme, çizgi ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategoriyi) gizleyin veya sadece uç/ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerlerin gösterimini kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stilini nasıl garanti edebilirim?**

Yazı tiplerini (aile, boyut) açıkça ayarlayın ve geri dönüşümün önlenmesi için render tarafında yazı tipinin mevcut olduğunu doğrulayın.