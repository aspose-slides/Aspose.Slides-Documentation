---
title: Python'da Sunum Grafiklerine Trend Çizgileri Ekleme
linktitle: Trend Çizgisi
type: docs
url: /tr/python-net/trend-line/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint grafiklerine trend çizgilerini hızlı bir şekilde ekleyin ve özelleştirin — izleyicilerinizi etkilemek için uygulamalı bir rehber."
---
## **Overview**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemenin nasıl yapılacağını açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemenin nasıl yapılacağını açıklar ve PDF veya SVG'ye dışa aktarım sırasında trend çizgilerinin korunup korunmadığı ve grafiklerin görüntülere dönüştürülürken trend çizgilerinin durumuna dair kısa bir SSS içerir.

## **Add a Trend Line**

[TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) kullanarak bir grafik serisine trend çizgisi ekleyin ve türünü [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur ve üç serisinin her birine iki trend çizgisi ekler.

Üstel trend çizgisi, denklemini ve R‑kare değerini [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) ve [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/) aracılığıyla gizler, doğrusal trend çizgisi ise kırmızıdır. Logaritmik trend çizgisi, özel bir etiket için [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) kullanır. Hareketli ortalama, üç veri noktasından oluşan bir [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) ve özel bir [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) kullanır. Polinom trend çizgisi, üç [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) değerine sahiptir ve bir kategori ileriye [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/) ile uzatılır. Güç trend çizgisi, bir kategori geriye [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/) ile uzatılır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Set a Trend Line Intercept**

[intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) kullanarak bir trend çizgisinin Y değerini X = 0'da sabitleyin. Bu ayar doğrusal, üstel ve polinom trend çizgileri için desteklenir.

Örneğin, bir üretim maliyeti modeli, sıfır olmayan üretim hacimlerinde ölçümler farklı bir temel değer gösterse bile, bilinen 100 sabit maliyetiyle başlamalıdır. Doğrusal bir trend çizgisi için kesiti sabitlemek, `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uydurulur. Bu, zaten uydurulmuş bir çizgiyi sadece kaydırmaz. Eksen kesişim ayarları, grafik eksenlerinin nerede buluştuğunu kontrol eder, uydurulmuş trend çizgisinin katsayılarını değil.

Aşağıdaki örnek, 1'den 4'e kadar üretim hacimleri ve 170, 200, 230 ve 260 maliyetleri ile bir dağılım (XY) grafiği oluşturur. Grafiği varsayılan otomatik kesitle kaydeder, kesiti 100 olarak ayarlar ve ikinci bir PPTX kaydeder. İki dosya yalnızca kesit ayarında farklıdır. Trend çizgisi denklemini gösterir ve X = 0'a kadar geri uzanır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik hesaplamayla, bu veriler `y = 30x + 140` üretir. Kesiti 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` verir: sıfırdaki uydurulmuş değer bilinen temel değerle eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik Kesit | 100'lik Sabit Kesit |
| --- | --- |
| ![Otomatik olarak hesaplanmış 140 kesitli doğrusal trend çizgisi](intercept-automatic.png) | ![100 sabit kesitli doğrusal trend çizgisi](intercept-fixed.png) |

Her iki görüntü aynı veri ve eksen ölçeklerini kullanır. Trend çizgileri kesitlerini göstermek için X = 0'a kadar geri uzatılmıştır.

Varsayılan olarak, özellik `float("nan")` içerir; bu, sıfır yerine belirlenmemiş bir kesiti temsil eder. Kesit daha sonra veriden otomatik olarak hesaplanır.

## **Add a Custom Line**

Özel bir çizgi, seri verilerinden hesaplanan bir trend çizgisi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) kullanarak grafiğin üzerine bir yatay çizgi ekler. Çizginin konumu, puan cinsinden ölçülen slayt koordinatlarıyla belirtilir; bu nedenle çizgi grafiğin sol kenarından başlar ve grafiğin ortasına kadar yer alır. Genişliği grafiğin genişliğiyle aynıdır. [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) çizgiye katı kırmızı bir renk verir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Trend çizgisi için 'forward' ve 'backward' ne anlam ifade eder?**

Bunlar, trend çizgisinin ileri/geriye doğru uzatılan uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım dışı grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler izin verilir.

**Sunumu PDF veya SVG olarak dışa aktarırken veya bir slaytı görüntüye render ederken trend çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [grafiğin bir görüntüsünü dışa aktar](/slides/tr/python-net/create-shape-thumbnails/) için bir yöntem de mevcuttur.