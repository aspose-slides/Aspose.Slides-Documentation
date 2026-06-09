---
title: JavaScript Kullanarak Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/nodejs-java/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da 3-B'li grafikleri oluşturmayı ve özelleştirmeyi öğrenin, PPT ve PPTX dosyalarını destekleyerek—sunumlarınızı bugün geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir 3D grafik nasıl özelleştirileceğini, `Rotation3D` ayarları olan `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` yapılandırarak açıklar. Bir sunum oluşturmayı, varsayılan veri ile bir 3D grafik eklemeyi, gerekli 3D görünüm ayarlarını uygulamayı ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi adım adım gösterir.

## **3D Grafiğin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**

Aspose.Slides for Node.js via Java, bu özellikleri ayarlamak için basit bir API sunar. Aşağıdaki makale, **X,Y Dönüş, DepthPercents** gibi farklı özellikleri nasıl ayarlayacağınız konusunda size yardımcı olacaktır. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan veri ile bir grafik ekleyin.
4. Rotation3D özelliklerini ayarlayın.
5. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta eriş
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan veri ile grafik ekle
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Grafik veri sayfasının indeksini ayarlama
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alıyor
    var fact = chart.getChartData().getChartDataWorkbook();
    // Seri ekle
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Kategorileri ekle
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Rotation3D özelliklerini ayarla
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // İkinci grafik serisini al
    var series = chart.getChartData().getSeries().get_Item(1);
    // Şimdi seri verileri dolduruluyor
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Overlap değerini ayarla
    series.getParentSeriesGroup().setOverlap(100);
    // Sunumu diske kaydet
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Aspose.Slides içinde hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) enumu aracılığıyla sunulan ilgili 3D türlerini destekler. Tam ve güncel liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Grafiği, [chart API](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) aracılığıyla bir görüntüye dışa aktarabilir veya [tüm slaytı renderlayarak](/slides/tr/nodejs-java/convert-powerpoint-to-png/) PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, piksel mükemmel bir önizleme gerektiğinde veya grafiği PowerPoint gerektirmeden belgeler, gösterge tabloları veya web sayfalarına yerleştirmek istediğinizde kullanışlıdır.

**Büyük 3D grafikler oluşturma ve renderlama performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimal tutun, duvar ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri nokta sayısını sınırlayın ve hedef ekran veya baskı ihtiyacına uygun çözünürlük ve boyutlarda bir çıktı üretmek için renderlayın.