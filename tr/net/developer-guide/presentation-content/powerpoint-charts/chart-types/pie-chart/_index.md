---
title: ".NET'te Sunumlarda Pasta Grafiklerini Özelleştirme"
linktitle: "Pasta Grafiği"
type: docs
url: /tr/net/pie-chart/
keywords:
- pasta grafik
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te pasta grafiklerini nasıl oluşturup özelleştireceğinizi öğrenin, PowerPoint'e aktarılabilir, verilerinizi saniyeler içinde hikayeleştirmenizi sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkincil Grafik Seçenekleri**
Aspose.Slides for .NET artık Pie of Pie veya Bar of Pie grafiği için ikincil grafik seçeneklerini destekliyor. Bu konuda, Aspose.Slides kullanarak bu seçenekleri nasıl belirleyeceğimizi örnekle göreceğiz. Özellikleri belirtmek için lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıf nesnesi oluşturun.
2. Slayta bir grafik ekleyin.
3. Grafiğin ikincil grafik seçeneklerini belirtin.
4. Sunumu diske yazın.

Aşağıda verilen örnekte, Pie of Pie grafiğinin farklı özelliklerini ayarladık.

```c#
// Presentation sınıfının bir örneğini oluştur
Presentation presentation = new Presentation();

// Slayta grafik ekle
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Farklı özellikleri ayarla
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Sunumu diske kaydet
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**
Aspose.Slides for .NET, otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sunar. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Grafik başlığını ayarlayın.
5. İlk seriyi Değerleri Göster olarak ayarlayın.
6. Grafik veri sayfasının indeksini ayarlayın.
7. Grafik veri çalışma sayfasını alın.
8. Varsayılan oluşturulan serileri ve kategorileri silin.
9. Yeni kategoriler ekleyin.
10. Yeni seriler ekleyin.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```c#
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur
using (Presentation presentation = new Presentation())
{
	// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur
	Presentation presentation = new Presentation();

	// İlk slayta eriş
	ISlide slides = presentation.Slides[0];

	// Varsayılan verilerle grafik ekle
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Grafik Başlığını ayarlama
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// İlk seriyi Değerleri Göster olarak ayarla
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Grafik veri sayfasının indeksini ayarlama
	int defaultWorksheetIndex = 0;

	// Grafik veri çalışma sayfasını alma
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Varsayılan oluşturulan serileri ve kategorileri sil
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Yeni kategoriler ekleme
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Yeni seriler ekleme
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Şimdi seri verilerini dolduruyoruz
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane, 'Pie of Pie' ve 'Bar of Pie' tipleri dahil, pasta grafikleri için ikincil bir grafiği [destekler](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/).

**Sadece grafiği bir resim olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı almadan grafiği doğrudan bir resim (örneğin PNG) olarak [dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/).