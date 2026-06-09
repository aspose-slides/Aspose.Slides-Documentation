---
title: Android'de Sunum Grafiklerine Eğilim Çizgileri Ekle
linktitle: Eğilim Çizgisi
type: docs
url: /tr/androidjava/trend-line/
keywords:
- grafik
- eğilim çizgisi
- üstel eğilim çizgisi
- lineer eğilim çizgisi
- logaritmik eğilim çizgisi
- hareketli ortalama eğilim çizgisi
- polinom eğilim çizgisi
- güç eğilim çizgisi
- özel eğilim çizgisi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint grafiklerine hızlıca eğilim çizgileri ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğilim çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine eğilim çizgileri eklemeyi ve üssel, lineer, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğilim çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi ekleme yöntemini anlatır ve ileri ve geri eğilim çizgisi projeksiyon değerleri ile eğilim çizgilerinin PDF veya SVG'ye dışa aktarılırken ve grafikler görüntü olarak render edildiğinde korunup korunmadığına dair kısa bir SSS içerir.

## **Eğilim Çizgisi Ekleme**
Aspose.Slides for Android via Java, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Bir slaytın referansını indeksine göre alın.
1. İstediğiniz türde (bu örnekte ChartType.ClusteredColumn kullanılır) varsayılan verilerle bir grafik ekleyin.
1. Grafik serisi 1 için üssel eğilim çizgisi ekleme.
1. Grafik serisi 1 için lineer eğilim çizgisi ekleme.
1. Grafik serisi 2 için logaritmik eğilim çizgisi ekleme.
1. Grafik serisi 2 için hareketli ortalama eğilim çizgisi ekleme.
1. Grafik serisi 3 için polinom eğilim çizgisi ekleme.
1. Grafik serisi 3 için güç eğilim çizgisi ekleme.
1. Değiştirilen sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileri ile bir grafik oluşturmak için kullanılır.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Kümelenmiş sütun grafiği oluşturma
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Seri 1 için üstel eğilim çizgisi ekleme
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Seri 1 için lineer eğilim çizgisi ekleme
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Seri 2 için logaritmik eğilim çizgisi ekleme
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Seri 2 için hareketli ortalama eğilim çizgisi ekleme
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Seri 3 için polinom eğilim çizgisi ekleme
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Seri 3 için güç eğilim çizgisi ekleme
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Sunumu kaydetme
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Çizgi Ekleme**
Aspose.Slides for Android via Java, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumdaki seçili slayta basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun
- Bir slaydın referansını indeksini kullanarak alın
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi türünde bir AutoShape ekleyin
- Şekil çizgilerinin rengini ayarlayın.
- Değiştirilen sunumu bir PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir eğilim çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, eğilim çizgisinin ileri/geri projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Sadece negatif olmayan değerler izin verilir.

**Sunumu PDF veya SVG'ye dışa aktarırken ya da bir slaytı görüntü olarak render ederken eğilim çizgisi korunacak mı?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/androidjava/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerini görüntülere render eder; eğilim çizgileri, grafiklerin bir parçası olarak bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [export](/slides/tr/androidjava/create-shape-thumbnails/) etmek için bir yöntem de mevcuttur.