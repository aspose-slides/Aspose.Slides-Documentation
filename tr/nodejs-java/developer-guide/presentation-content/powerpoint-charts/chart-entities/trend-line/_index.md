---
title: Sunum Grafiklerine JavaScript ile Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js via Java kullanarak PowerPoint grafiklerine trend çizgileri hızlı bir şekilde ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç dahil olmak üzere çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca bir çizgi şekli ekleyerek grafiğe özel bir çizgi ekleme yöntemini açıklar ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG'ye dışa aktarım sırasında ve grafikler görüntülere render edildiğinde korunup korunmadığına dair kısa bir SSS içerir.

## **Trend Çizgisi Ekle**

Aspose.Slides for Node.js via Java, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeksine göre elde edin.
3. İstenilen tipte (bu örnek ChartType.ClusteredColumn kullanır) varsayılan veriyle bir grafik ekleyin.
4. Grafik serisi 1 için üstel trend çizgisi ekleme.
5. Grafik serisi 1 için doğrusal trend çizgisi ekleme.
6. Grafik serisi 2 için logaritmik trend çizgisi ekleme.
7. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme.
8. Grafik serisi 3 için polinom trend çizgisi ekleme.
9. Grafik serisi 3 için güç trend çizgisi ekleme.
10. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileriyle bir grafik oluşturmak için kullanılır.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Küme sütun grafiği oluşturuluyor
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Grafik serisi 1 için üstel trend çizgisi ekleniyor
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Grafik serisi 1 için doğrusal trend çizgisi ekleniyor
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Grafik serisi 2 için logaritmik trend çizgisi ekleniyor
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Grafik serisi 2 için hareketli ortalama trend çizgisi ekleniyor
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Grafik serisi 3 için polinom trend çizgisi ekleniyor
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Grafik serisi 3 için güç trend çizgisi ekleniyor
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Sunum kaydediliyor
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özel Çizgi Ekle**

Aspose.Slides for Node.js via Java, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun
- Kaydırmanın indeksini kullanarak bir slaydın referansını elde edin
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin
- Şekil çizgilerinin rengini ayarlayın.
- Değiştirilmiş sunumu bir PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**'Forward' ve 'backward' bir trend çizgisi için ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geri yönünde projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı cinsinden. Yalnızca negatif olmayan değerler izin verilir.

**Sunumu PDF veya SVG'ye dışa aktarırken veya bir slaytı görüntüye render ederken trend çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerin görüntülere render edilmesini sağlar; trend çizgileri, grafiğin bir parçası olarak bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [export an image of the chart](/slides/tr/nodejs-java/create-shape-thumbnails/) için bir yöntem de mevcuttur.