---
title: JavaScript Kullanarak Sunumlarda Pasta Grafikleri Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/nodejs-java/pie-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ile Aspose.Slides for Node.js kullanarak pasta grafikleri oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint'e aktarılabilir, verilerinizi saniyeler içinde hikayeleştirmenizi artırır."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seriler ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafiği için İkincil Çizim Seçenekleri**

Aspose.Slides for Node.js via Java artık Pie of Pie ya da Bar of Pie grafiği için ikincil çizim seçeneklerini destekliyor. Bu başlıkta, bu seçenekleri Aspose.Slides kullanarak nasıl belirteceğinizi göstereceğiz. Özellikleri belirtmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı nesnesini örnekleyin.  
2. Slayta bir grafik ekleyin.  
3. Grafiğin ikincil çizim seçeneklerini belirtin.  
4. Sunumu diske yazın.  

Aşağıdaki örnekte, Pie of Pie grafiğinin farklı özelliklerini ayarladık.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Slayta grafik ekle
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Farklı özellikleri ayarla
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Sunumu diske kaydet
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarlama**

Aspose.Slides for Node.js via Java, otomatik pasta grafiği dilim renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda belirtilen özelliklerin uygulanmasını gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayta erişin.  
3. Varsayılan verilerle bir grafik ekleyin.  
4. Grafiğin başlığını ayarlayın.  
5. İlk seriyi Değerleri Göster olarak ayarlayın.  
6. Grafik veri sayfasının indeksini ayarlayın.  
7. Grafik veri çalışma sayfasını alın.  
8. Varsayılan oluşturulan serileri ve kategorileri silin.  
9. Yeni kategoriler ekleyin.  
10. Yeni seri ekleyin.  

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Varsayılan veriyle grafik ekle
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Grafik başlığını ayarlama
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // İlk seriyi Değerleri Göster olarak ayarla
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Grafik veri sayfasının indeksini ayarlama
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alma
    var fact = chart.getChartData().getChartDataWorkbook();
    // Varsayılan oluşturulan serileri ve kategorileri sil
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Yeni kategoriler ekleme
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Yeni seri ekleme
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Şimdi seri verilerini dolduruyoruz
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane pasta grafikleri için ikincil bir çizimi, 'Pie of Pie' ve 'Bar of Pie' tipleri dahil, [destekler](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/).

**Grafiği yalnızca bir görüntü (örneğin PNG) olarak dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı almadan grafiği kendisini bir görüntü olarak (örneğin PNG) [dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage).