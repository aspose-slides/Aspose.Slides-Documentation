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
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarına daha etkileyici slaytlar eklemek için grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi göstererek okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde gösterimi, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafik etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) kullanın. Bu örnek, varsayılan veriyle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir; temel değerleri değiştirmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yüzdeyi Etiket Olarak Görüntüleme**

Yığılmış bir sütun grafik için, her değeri kategori toplamının yüzde olarak hesaplayın ve metni [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) tarafından döndürülen metin çerçevesine atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzdeyi 8 puanlık bir yazı tipinde iki ondalık basamakla gösterir. Toplamı sıfır olan kategoriler, sıfıra bölmeyi önlemek için atlanır. Grafik verileri değiştiğinde özel etiket metnini yeniden hesaplayın.

```python
import jpide
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
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Veri Etiketlerinde Yüzde Simgesini Ayarlama**

Değerler kesir olarak saklandığında, yüzde göstermek için [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) metoduna `False` geçirin.

Bu örnek, dört kategori boyunca kırmızı ve mavi seriler içeren %100 yığılmış bir sütun grafik oluşturur. Her değer çifti 1’e toplar. `0.0%` etiket biçimi 0.30’u %30.0 olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 puanlık etiket metni kullanır.

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
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veri Etiketlerinin Gerçek Metnini Okuma**

[getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) metodunu kullanarak bir veri etiketinin ayarlarından üretilen metni alın. Bu, raporlar için etiket çıkarırken, sunum içeriği ararken veya oluşturulan grafikleri doğrularken faydalıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, diğeri ise [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) metodundan alınan özel metni kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Bir veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde ise kategori ve seri adlarıyla birlikte `75%` gösterilir. Özel metin, oluşturulan etiket metninin yerine geçer. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) her iki durumda da sonuç etiket dizesini döndürür. Yalnızca görünür etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) metodunu ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu noktaların veri etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) metodunu kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2D bir kümelenmiş sütun grafik oluşturur. Dikey eksende `False` olarak [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) metoduna geçilir ve maksimum 100 olarak [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) ile ayarlanır. İlk slayt, maksimumun ötesindeki etiketlere izin verir; bu slaydın bir kopyası ise bunları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` içinde kaydedilir.

[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ile değer etiketlerini etkinleştirin. Grafik düzeyindeki bu ayar tek başına değer gösterimini etkinleştirmez ve bireysel bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) ile etiketleri her sütunun dış ucuna yerleştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki görseller, Microsoft PowerPoint tarafından oluşturulan kaydedilmiş slaytları gösterir. `True` olduğunda **120** etiketi üst sınırda görünür; `False` olduğunda gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olarak kalır.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, bir değer ekseni içeren 2D sütun grafik kullanır. Değer ekseni olmayan grafikler (örneğin pasta ve halka grafikler) bu şekilde sınırlanacak bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Etiketi Bir Eksenden Uzaklık Olarak Ayarlama**

[setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) metodunu kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun bir yüzdesidir. Bu örnek, bir kümelenmiş sütun grafik oluşturur ve yatay eksen etiketi kaydırmasını 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına bağlı etiketlerden ziyade kategori ekseni etiketlerini etkiler.

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

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Etiket Konumunu Ayarlama**

Bir pasta grafikte, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve gösterge hatları için alan oluşturun.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) ve [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) metodlarıyla yatay ve dikey kaydırmalarını ayarlar. Bu kaydırmalar, sırasıyla grafiğin genişliği ve yüksekliğiyle orantılıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Sütun Grafiğin Üstünde Birden Çok Satır Veri Etiketi Ekleme**

Bu örnek, çizim alanının üzerinde iki satır veri etiketi olan bir sütun grafik oluşturur. Seri A, görünür sütunları gösterirken, Seri B ve Seri C ek etiketleri sağlar. Bu serilerin sütunları, dolgu ve anahat kaldırılarak gizlenir. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) metodu, üç seriyi aynı kategori merkezleriyle hizalar.

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) ayarları, etiket satırları için alan ayırır. [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) varsayılan konumları hesapladıktan sonra, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) ve [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) yatay hizalamayı korur ve dikey kaydırmalar uygulayarak etiketleri iki satırda düzenler. Sayılar, serilerin değerlerine bağlı veri etiketleri olarak kalır; yalnızca satır başlıkları ayrı metin şekilleridir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # B ve C sütunlarını gizle, ancak veri etiketlerini koru.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Üç seriyi aynı kategori merkezleriyle hizala.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Bu kompakt örnek için daha az ızgara çizgisi kullan.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Grafiğin üstünde iki satır veri etiketi için alan ayır.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Varsayılan yatay konumu koru. Y,
            # varsayılan etiket konumundan gelen bir ofsettir, grafik yüksekliği oranı olarak ifade edilir.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Yalnızca satır başlığı ayrı bir metin şeklidir.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste gelmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirme, gösterge hatları ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca uç değerler ve ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve 0, negatif değerler veya eksik değerler için gösterimi tanımlı bir kurala göre kapatın.

**PDF/görüntülere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**

Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve render ortamında yazı tipinin mevcut olduğunu doğrulayarak yedekleme sorunlarından kaçının.