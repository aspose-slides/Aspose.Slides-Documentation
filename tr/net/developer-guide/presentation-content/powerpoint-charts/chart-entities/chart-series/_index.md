---
title: GrafiK Veri Serilerini .NET Sunumlarında Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/net/chart-series/
keywords:
- grafik serileri
- seri çakışması
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
description: "C# ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/) bir dizi ilgili değeri temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanır. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/getcell/)'a geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) gibi, bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) gibi, bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/)'a ait uyumlu serilere uygulanır. Bir grup üzerine, [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/parentseriesgroup/) aracılığıyla, çakışma veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde erişin.

Açık bir nokta veya seri dolgu ayarı belirlenmemişse, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Seri Çakışmasını Ayarlama**

[IChartSeries.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/overlap/) 2D bir grafikte çubukların veya sütunların ne kadar çakıştığını -%100 ile %100 arasında rapor eder. Bu, üst grup üzerindeki ayarın yalnızca okunabilir bir yansımasıdır. [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/overlap/) ayarlanarak o gruptaki uyumlu tüm seriler güncellenir. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik tiplerine uygulanır; bir kombinasyon grafiğindeki diğer seri gruplarını etkilemez.

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

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

[IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) kullanarak bir serinin tamamı için varsayılan dolgu ayarlanabilir. Bir noktanın zaten açık bir dolgusu varsa, onun [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) ayarı, o nokta için seri dolgusunu geçersiz kılar.

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

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı, grafik veri çalışma kitabında saklanır ve genellikle lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi, satır 0, sütun 1 konumunda bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [IChartSeries.Name](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

![The series name](series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) seri dizini ve grafik stilinden hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Tam renkler grafik stili ve temaya bağlıdır.

## **Grafik Serisi için Ters Çevirme Dolgu Rengini Ayarla**

Bar, sütun ve balon serileri için, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengi için [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) atayın. Negatif sayılar çalışma kitabında değişmez; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için ters çevirme, [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) aracılığıyla etkinleştirilebilir. Aşağıdaki örnekte seri için ters çevirme devre dışı bırakılmış, yalnızca seçilen nokta için etkinleştirilmiştir. Etkinin görülmesi için nokta ayrıca negatif bir değer almıştır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, o noktanın arka plan çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiği için çizilen değer, [IChartDataPoint.YValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/yvalue/) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini, grafiğin boş-değer ayarlarına göre boş olarak işler.

Aşağıdaki örnek, ilk seride yalnızca ikinci noktayı temizler:

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

Dağılım (scatter) grafikler ayrı X ve Y hücreleri kullanır, balon grafikler ayrıca bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri gösterir. Bir hücreyi boş yapmak için [IChartDataCell.Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) değerini `null` olarak ayarlayın. Sayısal sıfır, boş hücre ayarından bağımsız olarak sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresi sıfır ya da ara bir değerle doldurulmaz.

Aşağıdaki bağımsız örnek, bir serili bir çizgi grafik oluşturur, 3. Gün için değeri temizler ve grafiği her modda kaydeder. Girdi dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Her çıktı dosyası, kaydetmeden önce atanan modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görsel etki grafik tipine bağlıdır. Çizgi grafiği, üç modu da karşılaştırmayı kolaylaştırır. Bar ve sütun grafiklerde eksik bir kategori için bağlayıcı bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır yükseklikte bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçiler içeren bir dağılım grafiğinde de bağlayıcı çizgi yoktur. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Çakışma gibi, bu da tek bir seriye değil üst grup serisine aittir. Grup için [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) bir kez ayarlanır. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun yapar.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) enum'ı tarafından temsil edilen tüm grafik tipleri veri kullanır, ancak serilerinin değer yapısı veya ayarları aynı değildir. Örneğin, kategori grafikler kategori ve değer, dağılım grafikler X ve Y değer, balon grafikler ise balon boyutları kullanır. Serinin tipine uygun veri noktası oluşturma yöntemi kullanılmalıdır. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu bar veya sütun gruplarına uygulanır.

**Bir grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/) aynı grup düzeyinde çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bu yüzden bir seri üzerinden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak [IShapeCollection.AddChart](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri noktası değerleri, bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizilebilmesi için kategori satırları ile seri‑değer satırlarının hizalı olduğundan emin olun.

**Tüm seriyi değil sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak tutabilirsiniz. [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanılmalıdır. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutmak için güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik tipi ve [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) ayarına bağlıdır. Desteklenen grafikler boşlukları, sıfır değerleri olarak gösterir veya komşu noktaları bağlayabilir. Eksik verinin sunumunuzdaki anlamına uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen bar, sütun ve balon serileri için, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) etkinleştirildikten sonra [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ile negatif değer rengi atanabilir. Bireysel bir nokta için davranış, [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile geçersiz kılınabilir. Bu özellikler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerler değişmez.

**Hem seri hem de nokta biçimlendirilmişse hangi format geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık seri formatı kullanmaya devam eder veya seri formatı tanımlı değilse otomatik grafik stili ve teması uygulanır. Çakışma ve boşluk genişliği gibi grup özellikleri yerleşimi kontrol eder ve nokta‑düzeyi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içinde kaç serinin bulunabileceği konusunda bir limit var mı?**

Aspose.Slides ayrı bir sabit seri sayısı limiti getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafiğin okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapmalıyım?**

Uygun üst seri grubunda [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.