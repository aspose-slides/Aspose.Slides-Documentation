---
title: .NET'te Sunumlarda Grafik Veri Serilerini Yönetme
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
description: "C# ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, çakışma, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında depolar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/) bir ilgili değer kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Seri adı, kategoriler ve nokta değerleri bu nedenle yalnızca gösterim metni olarak saklanmaz, [IChartDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreler seri değerleri için kullanılır. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/getcell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut tüm grafiklerin bu düzeni kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarları, örneğin [IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) gibi, bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) gibi, bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır; [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/parentseriesgroup/) üzerinden gruba erişerek çakışma (overlap) veya boşluk genişliği (gap width) gibi seçenekleri ayarlayabilirsiniz.

Açık bir nokta veya seri dolgu ayarı belirlenmemişse, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi varsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

[IChartSeries.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/overlap/) 2B bir grafikte çubukların veya sütunların %‑100 ‑ 100 aralığında ne kadar çakıştığını bildirir. Bu, üst‑serisi grubundaki ayarın salt okunur bir izdüşümüdür. [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/overlap/) ayarlanarak aynı gruptaki tüm uyumlu serilerin çakışması güncellenir. Bu seçenek, gruplanmış çubuk veya sütun görüntüleyen grafik türlerine uygulanır; kombinasyon grafiğindeki ilişkili olmayan seri gruplarını etkilemez.

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

Tam bir seri için varsayılan dolguyu ayarlamak amacıyla [IChartSeries.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/format/) kullanın. Bir nokta zaten açık bir dolgu içeriyorsa, o noktanın [IChartDataPoint.Format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/format/) ayarı seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi dolgu uygular:

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

Bir seri adı, grafik veri çalışma kitabında saklanır ve genellikle legend (açıklama) kısmında görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [IChartSeries.Name](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte sabit bir satır ve sütun varsayımından kaçınmanızı sağlar:

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

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) yöntemi, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu, seri dolgusu açıkça tanımlanmamışsa kullanılan renktir. Yöntem, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Varsayılan grafik stiline ait örnek çıktı:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Kesin renkler grafik stili ve temasına bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, negatif değerleri farklı bir dolgu ile gösterebilen [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) özelliği bulunur. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengi için [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini bir seriye değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Tek bir nokta için ters çevirme, [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için ters çevirme devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkinliği görmek için nokta negatif bir değer alır:

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

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun destekleyici çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafiği için çizilen değer, [IChartDataPoint.YValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/yvalue/) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak işler.

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

Dağılım grafikleri ayrı X ve Y hücreleri, baloncuk grafikleri ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız, [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu çağırmayın; bu yöntem serideki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir konudur. Gizli çalışma sayfası satırları ve sütunlarından veri eklemek veya çıkarmak için [Include Data from Hidden Rows and Columns](/slides/tr/net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Hücreyi boş hâle getirmek için [IChartDataCell.Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) özelliğini `null` yapın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) kullanın. Bu ayar tüm grafik için geçerlidir ve boşlukların nasıl çizileceğini değiştirir; boş hücreyi sıfır ya da interpolasyonla doldurmaz.

Aşağıdaki bağımsız örnek, bir çizgi grafiği oluşturur, bir seri ekler, 3. Gün değerini temizler ve her mod için aynı grafiği kaydeder. Giriş dosyasına ihtiyaç yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) çalışma sayfası 0’da kategori etiketleri için sütun 0, değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

Her çıktı dosyası, kaydetmeden önce atanan modu yansıtır: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırmanıza izin verir. Çubuk ve sütun grafiklerinde eksik bir kategoriye bağlanacak bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti üretemez; eksik bir sütun ve sıfır‑yüksekliğindeki bir sütun da benzer görünebilir. Benzer şekilde, sadece işaretçileri olan bir dağılım grafiği de çizgi bağlamaz. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk ya da sütun kümeleri arasındaki boşluğu, çubuk ya da sütun genişliğinin yüzde olarak ifadesidir. Çakışma gibi, bu da tek bir seriye değil, üst‑seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

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

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) enumü tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip olmayabilir. Örneğin, kategori grafiklerinde kategoriler ve değerler, dağılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Serinin türüne uygun veri‑nokta oluşturma yöntemini kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup içerebilir; bir seriden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.AddChart](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken kategori satırları ile seri‑değer satırlarının hizalı olduğundan emin olun; böylece her nokta istenen kategori altında çizilir.

**Tüm seriyi değil sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointcollection/clear/) yöntemini yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) seçeneğine bağlıdır. Desteklenen grafikler boşlukları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Control the Display of Empty Cells](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertifnegative/) etkinleştirip [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) üzerinden negatif değer rengi atanabilir. Bireysel bir nokta için davranışı [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile geçersiz kılabilirsiniz. Bu özellikler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık seri biçimi varsa onu, yoksa otomatik grafik stili ve temasını kullanır. Çakışma ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersizliği sağlamaz.

**Bir grafikte kaç seri bulunabilir?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, mevcut bellek, işleme süresi ve grafik okunurluğu kullanılabilir sınırı belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapmalıyım?**

Uygun üst‑seri grubunda [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yakınlaştırın.