---
title: .NET'te Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/net/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "C# ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/) ilgili değerlerin bir kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartcategory/) nesneleri, seri tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak depolanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanır. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/getcell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluştururken faydalıdır, ancak mevcut tüm grafiklerin bunu kullandığını varsaymayın. Yüklü bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Bir serideki tüm noktalar için varsayılan görünümü sağlayan, [IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) gibi seri‑seviyesi ayarlar.
- Tek bir nokta için serinin görünümünü geçersiz kılan, [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) gibi veri‑nokta ayarları.
- Aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/) içinde yer alan uyumlu serilere uygulanan grup ayarları. Örtüşme ya da boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/parentseriesgroup/) aracılığıyla gruba erişin.

Açık bir nokta veya seri dolgusunun ayarlanmamış olması durumunda, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

[IChartSeries.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/overlap/) 2B bir grafikte çubukların ya da sütunların birbirine ne kadar çakıştığını –%100 ile %100 arasında rapor eder. Bu, üst seriler grubundaki ayarın yalnızca okunabilir bir yansımasıdır. O gruptaki tüm uyumlu serileri güncellemek için [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk ya da sütun gösteren grafik türlerine uygulanır; bir kombinasyon grafiğindeki diğer seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Yeni grafik örnek seriler, kategoriler ve değerler içerir.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Sonuç:

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

[IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) kullanarak bir bütün serinin varsayılan dolgusunu ayarlayabilirsiniz. Bir noktanın açık bir dolgu ayarı varsa, o nokta için [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) ayarı serinin dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Sonuç:

![Serinin rengi](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı, grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnek, bu yapıyı açıkça gösteren adlandırılmış sabitleri içerir:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Ayrıca, zaten [IChartSeries.Name](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/name/) tarafından başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Sonuç:

![Seri adı](series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) yöntemi, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu, seri dolgu renkleri açıkça tanımlanmadığında kullanılan renktir. Yöntemi çağırmak sadece hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Kesin renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve balon serileri için, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) atayın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 serinin adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Sonuç:

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkinin görülmesi için nokta negatif bir değer almıştır:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Belirli Bir Veri Noktası Değerini Temizleme**

Bir noktayı diğerlerini kaldırmadan boş bırakmak için, arka plan çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafiğinde, çizilen değer [IChartDataPoint.YValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/yvalue/) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, boş‑değer ayarlarına göre bu değeri boş olarak işler.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Dağılım grafikleri ayrı X ve Y hücreleri kullanır, balon grafikler ayrıca bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk ya da sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzde olarak ifadesidir. Örtüşme gibi, bu da tek bir seriye değil, üst seriler grubuna aittir. Grup için bir kez [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca nihai sunumu kaydeder:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) enum’unda yer alan tüm grafik tipleri veri kullanır, ancak serilerinin değer yapısı ya da ayarları aynı değildir. Örneğin, kategori grafikleri kategori ve değer, dağılım grafikleri X ve Y değerleri, balon grafikleri ise balon boyutlarını kullanır. Seri tipine uygun veri‑nokta oluşturma yöntemini seçin. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup barındırabilir; bir seri aracılığıyla ulaşılan grup ayarlarını değiştirmek, grafiğin diğer gruplarını otomatik olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.AddChart](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategorileri temizleyebilirsiniz. Aşırı yükleme (overload) ile varsayılan veri olmadan da grafik oluşturulabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın amaçlanan kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Tüm seriyi silmek yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak tutun. [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanılmalıdır. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutacak şekilde güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik tipine ve [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) ayarına bağlıdır. Desteklenen grafikler boşları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) etkinleştirin ve [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ile negatif değer rengini belirleyin. Tek bir nokta için bu davranışı [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile geçersiz kılabilirsiniz. Bu özellikler yalnızca görsel biçimlendirmeyi etkiler; saklanan sayısal değerler değişmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar ya açık seri biçimini kullanır ya da seri biçimi tanımlı değilse otomatik grafik stili ve teması devreye girer. Örtüşme ve boşluk genişliği gibi grup özellikleri yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içinde kaç seri bulunabileceği konusunda bir sınırlama var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafiğin okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne değiştirilmelidir?**

Uygun üst seri grubunda [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarını değiştirin. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.