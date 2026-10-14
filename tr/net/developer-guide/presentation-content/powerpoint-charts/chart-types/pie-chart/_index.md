---
title: Sunumlarda .NET ile Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/net/pie-chart/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te pasta grafiklerini oluşturun ve özelleştirin. İkincil çizimleri yapılandırın, veri etiketlerini gösterin ve PowerPoint'te otomatik dilim renklerini uygulayın."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafiklerinin ikincil çizim seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmenin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını ayarlama, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafikler İçin İkinci Çizim Seçenekleri**

Aspose.Slides for .NET, Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini destekler. Bu seçenekler, ikincil çizimin boyutunu ve veri noktalarının iki çizim arasında nasıl bölüneceğini kontrol eder.

Aşağıdaki örnek yeni bir sunumda Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) özelliği ikincil çizim boyutunu ana çizimin %149’una ayarlar. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) yüzde tabanlı bölmeyi seçer ve [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) eşik değerini %53’e ayarlar.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **İkincil Çizim İçin Kategorileri Seçme**

Yüzde değerlerinden bağımsız olarak belirli kategorileri ikincil çizimde gruplamak istediğinizde özel bölmeyi kullanın. Örneğin bir satış raporu, Online ve Etkinlikler’i birlikte göstererek okuyucuların bu iki kanalı karşılaştırmasını sağlayabilir; bunlar toplam satışın %35 ve %10’una sahiptir.

[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) özelliğini [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) olarak ayarlayın ve noktaları [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) ile seçin. Koleksiyonun [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) yöntemi serideki sıfır‑tabanlı bir indeks ya da bir veri noktası nesnesi kabul eder. Bu örnekte indeks 1 Online’ı, indeks 3 ise Etkinlikler’i seçer. Partners da geçici olarak eklenir, ardından [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) ile çıkarılır.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Varsayılan verileri kanal bazında satışlarla değiştir.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Online'ı sıfır tabanlı indeksiyle ve Events'i veri noktası nesnesiyle seç.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Partners'ı seçimden çıkar, kaynak verisini silmeden.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) ve Etkinlikler (10) ikincil çizimde ayrı dilimler olarak görünür. Birincil çizimde ise 45 değerinde birleşik bir dilim, Retail (40) ve Partners (15) ile birlikte gösterilir. Partners’ın özel seçimden çıkarılması, onu birincil çizimde tutar; kategori ya da değeri grafik kaynağından kaldırmaz.

Aşağıdaki görsel, PowerPoint’te kaydedilmiş sunumu gösterir:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Otomatik Pasta Grafik Dilimi Renklerini Ayarla**

Aspose.Slides for .NET, pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla bir pasta grafiği oluşturur ve varsayılan verileri üç çeyrek kategorisi ve değerleriyle değiştirir. [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) özelliği 20, 50 ve 30 değerlerini etiket olarak gösterirken, [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) her dilim için ayrı bir renk etkinleştirir.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Ortalanmış bir grafik başlığı ekle.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// İlk çalışma sayfasını kullanarak varsayılan verileri değiştir.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Değerleri göster ve dilimlere farklı renkler ata.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) pasta grafikleri için ikincil çizimi, Pie of Pie ve Bar of Pie türleri dahil.

**Grafiği yalnızca bir görüntü olarak (ör. PNG) dışa aktarabilir miyim?**

Evet, [grafiği doğrudan görüntü olarak dışa aktar](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (ör. PNG) tüm sunumu dışa aktarmadan yapabilirsiniz.