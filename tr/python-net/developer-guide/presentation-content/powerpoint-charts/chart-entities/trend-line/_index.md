---
title: Python’da Sunum Grafiklerine Trend Çizgileri Ekle
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
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument grafiklerine Aspose.Slides for Python via .NET ile trend çizgilerini hızlı bir şekilde ekleyin ve özelleştirin — tahmin doğruluğunu artırmak ve izleyicilerinizi etkilemek için pratik bir kılavuz ve kod örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemenin nasıl yapılacağını açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek bir grafa özel bir çizgi eklemenin nasıl yapılacağını açıklar ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG olarak dışa aktarılırken ve grafiklerin görüntü olarak işlenirken korunup korunmadığına dair kısa bir SSS içerir.

## **Trend Çizgisi Ekle**

Aspose.Slides for Python via .NET, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Presentation sınıfının bir örneğini oluşturun.
1. Bir slaytın referansını indeksine göre elde edin.
1. İstediğiniz türde (bu örnek ChartType.CLUSTERED_COLUMN kullanır) varsayılan verilerle bir grafik ekleyin.
1. Grafik serisi 1 için üstel trend çizgisi ekleme.
1. Grafik serisi 1 için doğrusal trend çizgisi ekleme.
1. Grafik serisi 2 için logaritmik trend çizgisi ekleme.
1. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme.
1. Grafik serisi 3 için polinom trend çizgisi ekleme.
1. Grafik serisi 3 için güç trend çizgisi ekleme.
1. Değiştirilen sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileriyle bir grafik oluşturmak için kullanılır.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Boş sunum oluşturma
with slides.Presentation() as pres:

    # Kümeleme sütun grafiği oluşturma
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Grafik serisi 1 için üstel trend çizgisi ekleme
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Grafik serisi 1 için Doğrusal trend çizgisi ekleme
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Grafik serisi 2 için Logaritmik trend çizgisi ekleme
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Grafik serisi 2 için Hareketli Ortalama trend çizgisi ekleme
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Grafik serisi 3 için Polinom trend çizgisi ekleme
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Grafik serisi 3 için Güç trend çizgisi ekleme
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Sunumu kaydetme
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Çizgi Ekle**

Aspose.Slides for Python via .NET, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçili bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaytın referansını indeksini kullanarak elde edin
- Shapes nesnesi tarafından sağlanan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sağlanan AddAutoShape yöntemiyle Çizgi tipi bir AutoShape ekleyin
- Şekil çizgilerinin Rengini ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir trend çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geri yönde projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler kabul edilir.

**Sunumu PDF veya SVG olarak dışa aktarırken veya bir slaytı görüntüye işlerken trend çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/python-net/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerini görüntülere işler; trend çizgileri, grafiğin bir parçası olarak bu işlemler sırasında korunur. Aynı zamanda grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/python-net/create-shape-thumbnails/) için bir yöntem de mevcuttur.