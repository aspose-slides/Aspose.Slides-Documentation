---
title: Java Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/java/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java ile Aspose.Slides kullanarak pasta grafiklerini nasıl oluşturup özelleştireceğinizi, PowerPoint'e aktarılabilir şekilde öğrenin ve saniyeler içinde veri anlatımınızı güçlendirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklerinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafiklerinin İkincil Grafik Seçenekleri**
Aspose.Slides for Java artık Pie of Pie veya Bar of Pie grafiği için ikincil grafik seçeneklerini destekliyor. Bu konuda, bu seçenekleri Aspose.Slides kullanarak nasıl belirteceğinizi göstereceğiz. Özellikleri belirtmek için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıf nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikincil grafik seçeneklerini belirtin.
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
Aspose.Slides for Java, otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. İlk seriyi Değerleri Göster olarak ayarlayın.
1. Grafik veri sayfasının indeksini ayarlayın.
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

    // Grafik Başlığını ayarla
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // İlk seriyi Değerleri Göster olarak ayarla
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Grafik veri sayfasının indeksini ayarla
    int defaultWorksheetIndex = 0;

    // Grafik veri çalışma sayfasını al
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Varsayılan oluşturulan serileri ve kategorileri sil
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Yeni kategoriler ekle
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Yeni seriler ekle
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Şimdi seri verilerini doldur
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

Evet, kütüphane [destekliyor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) pasta grafikler için ikincil bir grafik, 'Pie of Pie' ve 'Bar of Pie' türleri dahil.

**Grafiği sadece bir resim olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, [grafiği kendisini bir resim olarak dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) (örneğin PNG) tüm sunumu dışarı almadan.