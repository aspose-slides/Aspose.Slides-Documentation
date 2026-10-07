---
title: .NET'te Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/net/chart-series/
keywords:
- grafik serisi
- seri üst üste geçme
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
description: "C# ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, üst üste geçmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) bir dizi ilişkili değeri temsil eder ve serideki her bir [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca ekranda gösterilen metin olarak değil, [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreler seri değerleri için kullanılır. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Üst‑üst geçme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde grup, [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) üzerinden elde edilir.

Açıkça bir nokta ya da seri dolgu ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Üst Üst Geçmesini Ayarlama**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 2B bir grafikte çubukların ya da sütunların ne kadar üst‑üst geçtiğini -%100 ile %100 arasında rapor eder. Bu, ebeveyn seri grubundaki ayarın salt okunur bir izdüşümüdür. [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ayarlanarak aynı gruptaki tüm uyumlu seriler güncellenir. Bu seçenek, gruplanmış çubuk ya da sütun gösteren grafik türlerine uygulanır; birleşik bir grafikteki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için üst‑üst geçmeyi ayarlar:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Yeni grafik, örnek serileri, kategorileri ve değerleri içerir.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Sonuç:

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Bir bütün seri için varsayılan doldurmayı ayarlamak üzere [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) kullanın. Bir noktanın zaten açık bir dolgu ayarı varsa, onun [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) ayarı o nokta için serinin dolgusunu geçersiz kılar.

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

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejanda görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı netleştirir:

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

Ayrıca [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ya da sütun varsayımını önler:

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

### **Birden Çok Hücreden Oluşan Adla Seri Oluşturma**

Ürün adı ve raporlama dönemi ayrı hücrelerde saklanıyorsa birleşik bir seri adı faydalı olur. Örneğin, B1 hücresindeki `Product A` ve C1 hücresindeki `2026` değerlerini birleştirerek hem iki bölümü kaynak hücrelerine bağlı tutar hem tek bir seri adı oluşturabilirsiniz.

Ad aralığını elde etmek için [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) kullanın, ardından bu koleksiyonu [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) yöntemiyle ekleyin. `skipHiddenCells` argümanı gizli hücrelerin dahil edilip edilmemesini kontrol eder: `true` gizlileri dışlar, `false` dahil eder. Bu örnek, ad aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 yalnızca seri adını, A2:A3 kategori etiketlerini ve B2:B3 sayısal değerleri sağlar.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Bu iki hücre seri adını sağlar.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Separate cells supply the categories and numeric data points.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Oluşan seri adı `Product A 2026` şeklindedir; iki hücre değeri arasında bir boşluk bulunur. Lejanda bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel, kaydedilen sunumdan oluşturulmuştur:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmadığında kullanılan renktir. Yöntem, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

## **Bir Grafik Serisi İçin Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve balon serileri için [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için terslemeyi [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır ve yalnızca seçili nokta için etkinleştirilir. Etkiyi görmek için nokta negatif bir değer alır:

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

Bir noktayı diğerlerini silmeden boş bırakmak için arka plan hücresini `null` olarak ayarlayın. Bir sütun grafiğinde çizilen değer [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değeri boş olarak kabul eder (grafiğin boş‑değer ayarlarına göre).

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

Saçılma (scatter) grafikler ayrı X ve Y hücreleri, balon grafikler ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değere karşılık gelen hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek ya da hariç tutmak için [Hidden Rows and Columns](/slides/tr/net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen bir sayısal değeri temsil eder. Hücreyi boş yapmak için [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) özelliğini `null` olarak ayarlayın. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

Boş hücrelerin grafik içinde nasıl gösterileceğini seçmek için [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) kullanın. Bu ayar tüm grafik için geçerlidir ve boş değerleri doldurmak yerine boş hücrelerin nasıl çizileceğini belirler.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün değerini temizler ve her bir modu ayrı dosyaya kaydeder. Giriş dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` şeklindedir:

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

// 3. Günü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz istediğiniz modu atayın ve sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünüm etkisi grafik türüne bağlıdır. Satır grafiği üç modu kolayca karşılaştırır. Çubuk ve sütun grafiklerde eksik bir kategori için bağlanacak bir çizgi olmadığı için `Span` üstteki gibi bir bağlama segmenti üretmez; eksik bir sütun ve sıfır‑yükseklikte bir sütun da benzer görünebilir. Benzer şekilde sadece işaretçi (marker) içeren bir saçılma grafiği de bağlayıcı çizgi içermez. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız türdeki çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk ya da sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzde olarak ifadesidir. Üst‑üst geçme gibi, bu ayar bireysel seriden değil, ebeveyn seri grubundan gelir. Grubun boşluk genişliğini ayarlamak için [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) bir kez ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıkı hâle getirir.

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

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enum’u tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serilerinin değer yapısı ya da ayarları aynı değildir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılma grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Üst‑üst geçme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) aynı grup‑düzeyindeki çizim ayarlarını paylaşan uyumlu serileri içerir. Kombine bir grafik birden fazla grup içerebilir; bir seriden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir ya da tamamen özelleştirilmiş bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yük de varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken kategori satırları ile seri‑değer satırlarının hizalı olmasına dikkat edin; böylece her nokta istenen kategori altında çizilir.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu boş bir nokta olarak tutabilirsiniz. [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) metodunu yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, değerlerin kategori koleksiyonuyla hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ayarına bağlıdır. Desteklenen grafikler boşlukları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) etkinleştirilebilir ve [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ile negatif değer rengi atanabilir. Bireysel bir nokta için davranışı [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile geçersiz kılabilirsiniz. Bu özellikler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerleri değiştirmez.

**Hem seri hem de nokta biçimlendirilmişse hangi biçimleme kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar ya açık seri biçimini, ya da seri biçimi tanımlanmamışsa otomatik grafik stilini ve temasını kullanır. Üst‑üst geçme ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder ve nokta‑düzeyi biçimlendirme üzerine bir geçersiz kılma sağlamaz.

**Bir grafik kaç seriyi barındırabilir?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtları, mevcut bellek, işleme süresi ve grafiğin okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapmalıyım?**

Uygun ebeveyn seri grubunda [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine yaklaştırabilirsiniz.