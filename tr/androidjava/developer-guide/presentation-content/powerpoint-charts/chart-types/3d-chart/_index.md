---
title: Android'de Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/androidjava/3d-chart/
keywords:
- 3D Grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PPT ve PPTX dosyalarını destekleyen 3D grafiklerin nasıl oluşturulacağını ve özelleştirileceğini öğrenin—sunumlarınızı bugün güçlendirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir 3D grafiği, `Rotation3D` ayarları olan `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` yapılandırılarak nasıl özelleştirileceğini açıklar. Bir sunum oluşturma, varsayılan verilerle bir 3D grafik ekleme, gerekli 3D görünüm ayarlarını uygulama ve değiştirilmiş sunumu PPTX dosyası olarak kaydetme adımlarını gösterir.

## **Bir 3D Grafiğin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**
Aspose.Slides for Android via Java, bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki makale, **X,Y Rotasyonu, DepthPercents** gibi farklı özellikleri nasıl ayarlayacağınızı gösterir. Örnek kod, yukarıda bahsedilen özelliklerin ayarlanmasını uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Rotation3D özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
Presentation pres = new Presentation();
try {
    // İlk slayta erişim
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Varsayılan veriyle grafik ekle
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Grafik veri sayfasının indeksini ayarlama
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alma
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Seri ekle
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategorileri ekle
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D özelliklerini ayarla
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // İkinci grafik serisini al
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Şimdi seri verilerini dolduruyoruz
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Overlap değerini ayarla
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Sunumu diske kaydet
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Aspose.Slides içinde hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D türlerini destekler. Kesin ve güncel bir liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [chart API](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) aracılığıyla bir görüntüye dışa aktarabilir veya [render the entire slide](/slides/tr/androidjava/convert-powerpoint-to-png/) gibi PNG veya JPEG formatlarına dönüştürebilirsiniz. Bu, piksel mükemmel bir önizleme gerektiğinde veya grafiği belgeler, gösterge panoları ya da PowerPoint gerektirmeyen web sayfalarına yerleştirmeniz gerektiğinde faydalıdır.

**Büyük 3D grafikler oluşturma ve render etme performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimal tutun, duvarlar ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef görüntüleme veya baskı ihtiyaçlarıyla eşleşecek şekilde uygun çözünürlük ve boyutlarda bir çıktı üretin.