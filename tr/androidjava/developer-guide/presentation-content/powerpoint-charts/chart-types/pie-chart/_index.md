---
title: Android'de Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafik
type: docs
url: /tr/androidjava/pie-chart/
keywords:
- pasta grafik
- grafiği yönet
- grafiği özelleştir
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Java ile Aspose.Slides for Android kullanarak pasta grafiklerini oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint'e aktarılabilir, verilerinizi saniyeler içinde anlatmanızı hızlandırır."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikler İçin İkinci Çizim Seçenekleri**
Aspose.Slides for Android via Java şimdi Pie of Pie veya Bar of Pie grafiği için ikinci çizim seçeneklerini destekliyor. Bu konuda, bu seçenekleri Aspose.Slides kullanarak nasıl belirteceğinizi göstereceğiz. Özellikleri belirtmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir nesnesini oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikinci çizim seçeneklerini belirtin.
1. Sunumu diske yazın.

Aşağıda verilen örnekte, Pie of Pie grafiğinin farklı özelliklerini ayarladık.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Slayta grafik ekle
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Farklı özellikleri ayarla
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Sunumu diske kaydet
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**
Aspose.Slides for Android via Java, otomatik pasta grafik slayt renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda belirtilen özelliklerin uygulanmasını gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. İlk seriyi Değerleri Göster olarak ayarlayın.
1. Grafik veri sayfasının dizinini ayarlayın.
1. Grafik veri çalışma sayfasını alın.
1. Varsayılan oluşturulan serileri ve kategorileri silin.
1. Yeni kategoriler ekleyin.
1. Yeni seriler ekleyin.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Varsayılan verilerle grafik ekle
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Grafik başlığını ayarlama
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // İlk seriyi Değerleri Göster olarak ayarla
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Grafik veri sayfasının dizinini ayarlama
    int defaultWorksheetIndex = 0;

    // Grafik veri çalışma sayfasını alma
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Varsayılan oluşturulan serileri ve kategorileri sil
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Yeni kategoriler ekleme
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Yeni seriler ekleme
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Şimdi seri verilerini dolduruyoruz
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane [supports](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) bir ikincil çizimi pasta grafikler için, 'Pie of Pie' ve 'Bar of Pie' tiplerini içerir.

**Grafiği yalnızca bir görüntü olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı almadan grafiği doğrudan bir görüntü olarak (örneğin PNG) [export the chart itself as an image](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) dışa aktarabilirsiniz.