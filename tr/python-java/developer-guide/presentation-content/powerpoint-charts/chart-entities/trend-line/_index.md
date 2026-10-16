---
title: Python'da Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/python-java/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint grafiklerine trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğri çizgileri nasıl ekleyeceğinizi açıklar. Bir grafik oluşturmayı, grafik serilerine eğri çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğri çizgi tipleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi nasıl ekleneceğini açıklar ve ileri ve geri eğri çizgi projeksiyon değerleri ve eğri çizgilerin PDF veya SVG olarak dışa aktarılırken ve grafikler görüntülere dönüştürülürken korunup korunmadığı konularında kısa bir SSS içerir.

## **Eğri Çizgi Ekle**

Bir grafik serisine eğri çizgi eklemek için [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) kullanın ve türünü [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur ve her üç serisine iki eğri çizgi ekler.

Üstel eğri çizgi, denklemini ve R‑kare değerini [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) ve [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue) ile gizler, doğrusal eğri çizgi kırmızıdır. Logaritmik eğri çizgi, özel bir etiket için [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) kullanır. Hareketli ortalama, üç veri noktası için [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) ve özel bir [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) kullanır.

Polinom eğri çizginin derecesi üçtür, [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) ile ayarlanır ve bir kategori ileriye [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward) ile uzatılır. Güç eğri çizgi ise bir kategori geriye [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward) ile uzatılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eğri Çizgi Kesişimini Ayarla**

[setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) kullanarak bir eğri çizginin Y değerini X = 0’da sabitleyin. Bu ayar, doğrusal, üstel ve polinom eğri çizgileri için desteklenir.

Örneğin, bir üretim maliyeti modeli, sıfır olmayan üretim hacimlerinde ölçümler farklı bir temel çizgi önerse bile, 100'lük bilinen sabit maliyetlerle başlamalıdır. Doğrusal bir eğri çizgi için, kesişimin sabitlenmesi `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uyar. Bu, zaten uydurulmuş bir çizgiyi sadece kaydırmak değildir. Ekseni kesiştirme ayarları, grafik eksenlerinin nerede buluştuğunu kontrol eder, uydurulmuş eğri çizginin katsayılarını değil.

Aşağıdaki örnek, 1 ila 4 arasındaki üretim hacimleri ve 170, 200, 230 ve 260 maliyetleriyle bir dağılım (XY) grafiği oluşturur. Grafik, varsayılan otomatik kesişimle kaydedilir, kesişim 100 olarak ayarlanır ve ikinci bir PPTX kaydedilir. İki dosya sadece kesişim ayarında farklılık gösterir. Eğri çizgi denklemini gösterir ve X = 0’a kadar uzanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otomatik hesaplama ile bu veriler `y = 30x + 140` üretir. Kesişimi 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` verir: sıfırdaki uydurulmuş değer bilinen temel çizgiyle eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesişim | 100 sabit kesişim |
| --- | --- |
| ![Doğrusal eğri çizgi, otomatik olarak hesaplanan 140 kesişim ile](intercept-automatic.png) | ![Doğrusal eğri çizgi, 100 sabit kesişim ile](intercept-fixed.png) |

Her iki görüntü aynı veri ve eksen ölçeklerini kullanır. Eğri çizgiler, kesişimlerini göstermek için X = 0’a kadar uzatılmıştır.

Varsayılan olarak, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) `NaN` döndürür; bu, sıfır yerine belirtilmemiş bir kesişimi temsil eder. Kesişim daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Bir Çizgi Ekle**

Özel bir çizgi, serilerden hesaplanan bir eğri çizgi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) kullanarak grafiğin üzerindeki slayta yatay bir çizgi ekler. Çizginin konumu, nokta cinsinden ölçülen slayt koordinatlarıyla belirtilir; bu yüzden grafiğin sol kenarından başlar ve grafiğin ortasına kadar oturur. Genişliği grafiğin genişliğiyle aynı olur. [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) metodu, katı kırmızı renk uygulamak için kullanılan çizgi biçimlendirmesine erişim sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**'İleri' ve 'geriye' bir eğri çizgi için ne anlama gelir?**

Bunlar, eğri çizginin ileri/geriye projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı cinsinden. Yalnızca negatif olmayan değerler izin verilir.

**Sunum PDF veya SVG olarak dışa aktarılırken ya da bir slayt görüntüye dönüştürülürken eğri çizgi korunur mu?**

Evet. Aspose.Slides, sunumları [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere renderlar; grafiklerin bir parçası olan eğri çizgiler bu işlemler sırasında korunur. Ayrıca, grafiğin kendisinin bir görüntüsünü [grafiğin bir görüntüsünü dışa aktar](/slides/tr/python-java/create-shape-thumbnails/) için bir yöntem mevcuttur.