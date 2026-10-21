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
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenin, böylece daha etkileyici slaytlar oluşturun."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde gösterme, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafik etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) kullanın. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir, ancak temel değerleri değiştirmez.

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

Grafiğin gömülü çalışma kitabındaki sayısal hücreleri biçimlendirmek için [Çalışma Kitabı Hücreleri için Özel Sayı Biçimlerini Ayarla](/slides/tr/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells) bölümüne bakın. Bu örnek ayrıca, depolanan sayısal değerleri korurken, değer etiketlerinin kaynak hücre biçimlerini izlediğini gösterir.

## **Yüzdeyi Etiket Olarak Göster**

Yığılmış sütun grafik için, her değeri kategorisinin toplamına göre yüzde olarak hesaplayın ve metni [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) tarafından döndürülen metin çerçevesine atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzdeyi iki ondalık basamakla 8 punto yazı tipinde gösterir. Toplamı sıfır olan kategoriler, bölme hatasından kaçınmak için atlanır. Grafik verileri değişirse, özel etiket metnini yeniden hesaplayın.

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

## **Grafik Veri Etiketleriyle Yüzde İşaretini Ayarla**

Değerler kesir olarak saklandığında, yüzde olarak göstermek için [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) metoduna `False` geçirin.

Bu örnek, dört kategori üzerinde kırmızı ve mavi serilerle %100 yığılmış sütun grafiği oluşturur. Her değer çifti 1'e eşittir. Etiket biçimi `0.0%`, 0.30 değerini 30.0% olarak gösterir, dikey eksen ise iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

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

## **Veri Etiketlerinin Gerçek Metnini Oku**

Bir veri etiketinin ayarları tarafından üretilen metni almak için [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) kullanın. Bu, raporlar için etiketleri çıkarmak, sunum içeriğini aramak veya oluşturulan grafikleri doğrulamak istediğinizde yararlıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) her kategori adı, seri adı ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, diğeri ise [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) üzerinden özel metin kullanır.

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

Sayı, etiketi `75%` ve kategori ile seri adlarını gösterse bile `0.75` olarak kalır. Özel metin, üretilen etiket metninin yerini alır. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) her iki durumda da ortaya çıkan etiket dizesini döndürür. Yalnızca görünen etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Et**

Bir eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2B kümelenmiş sütun grafiği oluşturur. Dikey eksende [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) metoduna `False` geçirir ve maksimumu 100 olarak [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) ile ayarlar. İlk slayt, maksimumun ötesinde etiketlere izin verir; bu slaydın bir kopyası ise bunları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` içinde kaydedilir.

Değer etiketlerini [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ile etkinleştirin. Grafik düzeyindeki ayar, kendi başına değer gösterimini etkinleştirmez ve bireysel bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve etiketleri her sütunun dış ucuna yerleştirmek için [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) kullanır.

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

Aşağıdaki görseller, Microsoft PowerPoint tarafından render edilen kaydedilmiş slaytları gösterir. `True` ile etiket **120** üst sınırda görünür; `False` ile gizlenir. Etiket **60** görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olur.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Eksen maksimumu 100 iken değer etiketi 120'yi gösteren PowerPoint grafiği](data-labels-over-maximum-true.png) | ![Eksen maksimumu 100 iken değer etiketi 120'yi gizleyen PowerPoint grafiği](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2B sütun grafiği kullanır. Değer ekseni olmayan grafikler, örneğin pasta ve halka grafikler, bu şekilde sınırlanacak bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Eksenden Etiket Mesafesini Ayarla**

[setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun yüzdesidir. Bu örnek, kümelenmiş bir sütun grafiği oluşturur ve yatay eksen etiket ofsetini 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına eklenen etiketlerden ziyade kategori ekseni etiketlerini etkiler.

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

## **Etiket Konumunu Ayarla**

Bir pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve lider çizgileri için alan oluşturun.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve yatay ve dikey ofsetlerini [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) ve [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) kullanarak ayarlar. Bu ofsetler, sırasıyla grafiğin genişliği ve yüksekliğine göre oranlanır.

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

![Etiketi ayarlanmış bir pasta grafiği](pie-chart-adjusted-label.png)

## **Lider Çizgileri Biçimlendir**

Bir pasta grafiği etiketleri dilimlerin dışına konumlandığında, lider çizgileri okuyucuların her değeri doğru dilimle eşleştirmesine yardımcı olur. Zıt bir renk ve biraz daha kalın bir çizgi bu bağlantıları takip etmeyi kolaylaştırırken, şeffaflık ve kesikli stil çizgileri görsel olarak göze batmaz.

[getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) kullanarak serinin veri etiketi koleksiyonu seviyesinde lider çizgileri biçimlendirin. `series.getLabels().getLeaderLinesFormat().getLine()` içindeki ayarlar bireysel bir etiketten ziyade koleksiyona uygulanır.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur, değerleri dilimlerin dışına gösterir ve [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) etkinleştirir. İki etiketi dilimlerinden daha uzak konuma taşımak için grafik genişliği ve yüksekliğinin kesirleri olarak ifade edilen [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) ve [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ofsetleri kullanılır. Girdi sunumu gerekli değildir.

Çizginin [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) 255 üzerinden 191 alfa değerine sahip katı bir mavi renk ayarlar, bu yaklaşık %25 şeffaflık sağlar. [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) kalınlığı 2 puan olarak ayarlar ve [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) çizgiyi kesikli yapar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # Etiketleri dilimlerinden daha uzakta konumlandır.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lider çizgileri etkinleştirmek, her etiket için bir çizgi oluşacağını garanti etmez. Görünürlük, etiket yerleşimine ve grafiğin düzen davranışına bağlıdır. Bu örnekte, iki yerinden uzaklaştırılmış etiketin görünür lider çizgileri vardır; dilimlerine yakın kalan etiketlerin ise buna ihtiyacı yoktur.

Aşağıdaki görsel, Aspose.Slides ile render edilen kaydedilmiş `FormattedLeaderLines.pptx` dosyasını gösterir:

![İki dış etiket ile dilimlerini birleştiren mavi, yarı şeffaf kesikli lider çizgili bir pasta grafiği](formatted-leader-lines.png)

## **Sütun Grafiğinin Üzerine Birden Fazla Satır Veri Etiketi Ekle**

Bu örnek, çizim alanının üstünde iki satır veri etiketi bulunan bir sütun grafiği oluşturur. Seri A görünen sütunları gösterirken, Seri B ve Seri C ek etiketleri sağlar. Bu serilerin sütunları dolgu ve kenarlık kaldırılarak gizlenir. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) metodu, üç seriyi aynı kategori merkezleriyle hizalar.

[ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) ayarları etiket satırları için alan ayırır. [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) varsayılan konumları hesapladıktan sonra, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) ve [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) yatay hizalamayı korur ve etiketleri iki satırda düzenlemek için dikey ofsetler uygular. Sayılar, serinin değerlerine bağlı veri etiketleri olarak kalır; sadece satır başlıkları ayrı metin şekilleridir.

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
                # B ve C sütunlarını gizle, ancak veri etiketlerini tut.
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

    # Çizim alanının üstünde iki satır veri etiketi için yer ayır.
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
            # Varsayılan yatay konumu tut.
            # Y, varsayılan etiket konumundan bir ofsettir, grafik yüksekliği kesri olarak ifade edilir.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Satır başlığı yalnızca ayrı bir metin şeklidir.
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

![Çizim alanının üstünde iki satır veri etiketi bulunan sütun grafiği](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin birbirine temas etmesini nasıl önleyebilirim?**  
Otomatik etiket yerleşimini, lider çizgilerini ve daha küçük yazı tipini birleştirin; gerekirse bazı alanları (örneğin, kategori) gizleyin veya yalnızca uç değerler veya ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için görüntülemeyi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**  
Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve geri dönüşüm (fallback) olmaması için yazı tipinin render ortamında mevcut olduğunu doğrulayin.