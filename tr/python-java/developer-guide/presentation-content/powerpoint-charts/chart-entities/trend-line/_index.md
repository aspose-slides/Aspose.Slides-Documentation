---
title: Python'da Sunum Grafiklerine Eğilim Çizgileri Ekle
linktitle: Eğilim Çizgisi
type: docs
url: /tr/python-java/trend-line/
keywords:
- grafik
- eğilim çizgisi
- üstel eğilim çizgisi
- doğrusal eğilim çizgisi
- logaritmik eğilim çizgisi
- hareketli ortalama eğilim çizgisi
- polinom eğilim çizgisi
- güç eğilim çizgisi
- özel eğilim çizgisi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint grafiklerine Aspose.Slides for Python via Java ile hızlıca eğilim çizgileri ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğilim çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine eğilim çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğilim çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemeyi açıklar ve ileri ve geri eğilim çizgisi projeksiyon değerleri ile eğilim çizgilerinin PDF veya SVG'ye dışa aktarılırken veya grafikler görüntü olarak oluşturulurken korunup korunmadığı hakkında kısa bir SSS içerir.

## **Eğilim Çizgisi Ekle**

Aspose.Slides for Python via Java, farklı grafik eğilim çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksiyle bir slayta referans alın.  
3. İstenen tipte (bu örnek [ChartType.ClusteredColumn](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/#ClusteredColumn) kullanır) varsayılan verilerle bir grafik ekleyin.  
4. Grafik serisi 1'e üstel bir eğilim çizgisi ekleyin.  
5. Grafik serisi 1'e doğrusal bir eğilim çizgisi ekleyin.  
6. Grafik serisi 2'ye logaritmik bir eğilim çizgisi ekleyin.  
7. Grafik serisi 2'ye hareketli ortalama bir eğilim çizgisi ekleyin.  
8. Grafik serisi 3'e polinom bir eğilim çizgisi ekleyin.  
9. Grafik serisi 3'e güç bir eğilim çizgisi ekleyin.  
10. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, eğilim çizgileri içeren bir grafik oluşturur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # Kümelenmiş sütun grafiği oluştur.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Grafik serisi 1'e üstel bir eğilim çizgisi ekle.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Grafik serisi 1'e doğrusal bir eğilim çizgisi ekle.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Grafik serisi 2'ye logaritmik bir eğilim çizgisi ekle.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Grafik serisi 2'ye hareketli ortalama bir eğilim çizgisi ekle.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Grafik serisi 3'e polinom bir eğilim çizgisi ekle.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Grafik serisi 3'e güç bir eğilim çizgisi ekle.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Sunumu kaydet.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Özel Çizgi Ekle**

Aspose.Slides for Python via Java, bir grafik'e özel çizgi eklemek için basit bir API sağlar. Seçilen bir slaytta bir grafik'e düz bir çizgi eklemek için şu adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
- İndeksiyle bir slayta referans alın.  
- Yeni bir grafik oluşturmak için [ShapeCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/) sınıfının [addChart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addChart) metodunu kullanın.  
- [ShapeType.Line](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapetype/#Line) ile [addAutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak bir çizgi şekli ekleyin.  
- Şeklin çizgi rengini ayarlayın.  
- Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, özel bir çizgi içeren bir grafik oluşturur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Eğilim çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, eğilim çizgisinin ileriye veya geriye projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde eksen birimlerinde ölçülür; dağılım olmayan grafiklerde kategori sayısı olarak ölçülür. Sadece negatif olmayan değerler kabul edilir.

**Sunum PDF veya SVG'ye dışa aktarılırken veya bir slayt görüntüye render edildiğinde eğilim çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerin resimlerini render eder; grafiklerin bir parçası olan eğilim çizgileri bu işlemler sırasında korunur. Ayrıca grafiklerin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/python-java/create-shape-thumbnails/) için bir yöntem de mevcuttur.