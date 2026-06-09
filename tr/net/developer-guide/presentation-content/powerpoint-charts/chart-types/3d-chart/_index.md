---
title: .NET'te Sunumlarda 3B Grafikleri Özelleştirme
linktitle: 3B Grafik
type: docs
url: /tr/net/3d-chart/
keywords:
- 3B grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te 3B grafikler oluşturmayı ve özelleştirmeyi öğrenin, PPT ve PPTX dosyalarını destekler—sunumlarınızı bugün güçlendirin."
---
## **Genel Bakış**

Bu makale, `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` gibi `Rotation3D` ayarlarını yapılandırarak Aspose.Slides içinde 3B bir grafiği nasıl özelleştireceğinizi açıklar. Bir sunum oluşturmayı, varsayılan veriyle 3B bir grafik eklemeyi, gerekli 3B görünüm ayarlarını uygulamayı ve değiştirilmiş sunumu PPTX dosyası olarak kaydetmeyi adım adım gösterir.

## **3B Grafiğin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**
Aspose.Slides for .NET, bu özellikleri ayarlamak için basit bir API sunar. Aşağıdaki makale, X, Y dönüşümleri ve **DepthPercents** gibi farklı özellikleri nasıl ayarlayacağınızı gösterir. Örnek kod, söz konusu özelliklerin ayarlanmasını uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İlk slayda erişin.  
3. Varsayılan veriyle bir grafik ekleyin.  
4. Rotation3D özelliklerini ayarlayın.  
5. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

```c#
// Presentation sınıfının bir örneğini oluşturma
Presentation presentation = new Presentation();
           
// İlk slayta erişme
ISlide slide = presentation.Slides[0];

// Varsayılan veriyle grafik ekleme
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Grafik veri sayfasının indeksini ayarlama
int defaultWorksheetIndex = 0;

// Grafik veri çalışma sayfasını alma
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Seri ekleme
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Kategorileri ekleme
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D özelliklerini ayarlama
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// İkinci grafik serisini al
IChartSeries series = chart.ChartData.Series[1];

// Şimdi seri verileri dolduruluyor
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Overlap değerini ayarlama
series.ParentSeriesGroup.Overlap = 100;         

// Sunumu diske kaydetme
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Aspose.Slides'te hangi grafik türleri 3B modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3B varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) enum'ı aracılığıyla sunulan ilgili 3B tipleri destekler. Tam ve güncel liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) üyelerine bakın.

**Rapor veya web için bir 3B grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [chart API](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) ile bir görüntüye aktarabilir veya tüm slaytı [tüm slaytı render et](/slides/tr/net/convert-powerpoint-to-png/) gibi PNG veya JPEG formatlarına dönüştürebilirsiniz. Bu, piksel mükemmel bir önizleme gerektiğinde veya grafiği PowerPoint gerektirmeden belgeler, gösterge panelleri veya web sayfalarına yerleştirmek istediğinizde faydalıdır.

**Büyük 3B grafiklerin oluşturulması ve render edilmesi ne kadar performanslıdır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3B efektleri minimal tutun, duvar ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri nokta sayısını sınırlayın ve hedef ekran ya da baskı ihtiyaçlarına uygun bir çıktı (çözünürlük ve boyutlar) üretmek için doğru boyutta render edin.