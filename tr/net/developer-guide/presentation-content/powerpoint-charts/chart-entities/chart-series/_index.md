---
title: .NET'te Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/net/chart-series/
keywords:
- grafik serisi
- seri üst üste gelme
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
description: "C# ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, üst üste gelmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) bir dizi ilgili değeri temsil eder ve her [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) o serideki bir noktayı temsil eder. [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan verilerle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri grafik çalışma kitabındaki [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) metoduna iletilen çalışma sayfası, satır ve sütun indeksleri sıfır‑bazlıdır. Bu düzen, varsayılan veriyle bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Bir serinin tüm noktaları için varsayılan görünümü sağlayan, [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) gibi seri‑seviyesi ayarlar.
- Tek bir nokta için serinin görünümünü geçersiz kılan, [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) gibi veri‑nokta ayarları.
- Aynı [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanan grup ayarları. Üst üste gelme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, bu grubu [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) üzerinden erişin.

Açıkça bir nokta veya seri doldurması ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

Kümelenmiş silindir grafik için, [changing the 3D series type or bar shape](/slides/tr/net/3d-chart/#change-the-3d-series-type-and-bar-shape) bağlantısının ilk seriyi nasıl etkilediğine bakın.

## **Seri Değerlerini Sayısal Sabitlerle Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalardan geliyorsa ve çalışma sayfası hücre başvurularına ihtiyaç duymuyorsa sayısal sabitler kullanın. Her noktanın [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) özelliğini [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) aracılığıyla atamadan önce [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) özelliğini [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) olarak ayarlayın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak türünü kontrol eder. Her noktanın [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) seçilen türü raporlar; koleksiyon ayarıyla değiştirin. `Worksheet` ile başvurulan hücreye erişmek için [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) kullanın. `DoubleLiterals` ile sayıyı doğrudan okumak veya yazmak için `AsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seri ve kategorilere sahip bir sütun grafiği oluşturur, ardından ilk serinin mevcut noktalarına 10, 20 vb. hesaplanmış değerleri atar. Sunumu kaydeder, tekrar açar ve saklanan değerleri yazdırır.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Nokta değeri kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasını belirten [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) özelliğinden bağımsızdır. Sayısal sabitler kullanmak, yerleşik çalışma kitabını yalnız başına kaldırmaz. Bu örnekte, çalışma kitabı hâlâ kategori etiketleri, seri adları ve diğer seriler için kullanılabilir. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/net/chart-workbook/) bölümüne bakın.

Dağılım ve baloncuk grafikler için, [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) ve [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) kaynaklarını seçmek üzere sırasıyla [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) ve [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) ayarlayın. Baloncuk grafikler ayrıca [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) için [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) kullanır. Her uygulanabilir kaynağı `DoubleLiterals` olarak ayarlayın ve sayıları ilgili değerin `AsLiteralDouble` özelliği üzerinden atayın.

## **Grafik Serisi Üst Üste Gelme Ayarı**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 2D bir grafikte çubuk ya da sütunların ne kadar üst üste geldiğini –% -100’den % 100’e kadar – raporlar. Bu, üst grup üzerindeki ayarın yalnızca okunabilir bir yansımasıdır. Tüm uyumlu serileri güncellemek için [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türleri için geçerlidir; birleşik bir grafikte bağımsız seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grubun üst üste gelme değerini ayarlar:

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

Tüm bir seri için varsayılan dolguyu ayarlamak üzere [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) kullanın. Bir noktanın açıkça bir dolgusu varsa, onun [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) ayarı seri dolgusunu o nokta için geçersiz kılar.

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

Seri adı grafik veri çalışma kitabında tutulur ve genellikle lejanda görüntülenir. Kümelenmiş sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki isimlendirilmiş sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) tarafından zaten başvurulan hücreyi doğrudan güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını ortadan kaldırır:

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

### **Birden Fazla Hücreden Oluşan Seri Adı Oluşturma**

Ürün adı ve raporlama dönemi ayrı hücrelerde tutulurken birleşik bir seri adı oluşturmak faydalı olabilir. Örneğin B1 hücresindeki `Product A` ve C1 hücresindeki `2026` değerlerini tek bir seri adı olarak birleştirip her iki kısmın da kaynak hücrelerine bağlı kalabilirsiniz.

[ IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) ile ad aralığını alın, ardından bu koleksiyonu [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) metoduna gönderin. `skipHiddenCells` argümanı gizli hücrelerin dahil edilip edilmediğini kontrol eder: `true` hariç tutar, `false` dahil eder. Bu örnek, ad aralığındaki her hücreyi dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 yalnızca seri adını sağlar; A2:A3 kategori etiketlerini, B2:B3 sayısal değerleri sağlar.

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

// Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
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

Ortaya çıkan seri adı, iki hücre değerinin arasına bir boşluk koyularak `Product A 2026` olur. Lejanda bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel, kaydedilen sunumdan oluşturulmuştur:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) yöntemi, seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgusu açıkça tanımlanmamışsa kullanılan renktir. Yöntem, renk değerini okur; yeni bir dolgu atamaz.

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

Tam renkler, grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Negatif Durumda Dolgu Rengini Ters Çevirme**

Çubuk, sütun ve baloncuk serileri için, negatif değerler farklı bir dolgu ile gösterilebilsin diye [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) özelliği kullanılabilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengine [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) üzerinden atayın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca gösterim rengi değişir.

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

Bir nokta için ters çevirme, [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için ters çevirme devre dışı bırakılmış, sadece seçilen nokta için etkinleştirilmiştir. Etkiyi göstermek amacıyla nokta negatif bir değer alır:

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

Diğer noktaları silmeden bir noktayı boş bırakmak için, onun arka plan hücresini `null` olarak ayarlayın. Sütun grafiğinde, çizilen değer [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarına göre değeri boş olarak işler.

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

Dağılım grafiklerinde X ve Y hücreleri ayrı, baloncuk grafiklerinde ise ek bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) yöntemini çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görünümünü Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden farklı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri eklemek ya da çıkarmak için [Include Data from Hidden Rows and Columns](/slides/tr/net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen bir sayısal değeri temsil eder. Hücreyi boş yapmak için [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) özelliğini `null` olarak ayarlayın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin grafik üzerinde nasıl gösterileceğini seçmek için [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) özelliğini kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresini sıfır ya da ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir çizgi grafiği oluşturur, 3. Gün değerini temizler ve her modu ayrı ayrı kaydeder. Girdi dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0, değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

// 3. Günü gerçekten boş bırakın, ancak kategori ve veri noktasını koruyun.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek için istediğiniz modu ayarlayıp sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünüm etkisi grafik türüne bağlıdır. Çizgi grafiği, üç modu da kolayca karşılaştırmanıza olanak tanır. Çubuk ve sütun grafiklerinde eksik bir kategoriye bağlanacak bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır‑yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca belirteçleri olan dağılım grafiğinde bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tipe göre çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Üst üste gelme gibi, bu da tek bir seriye değil, üst grup seviyesine aittir. Grup için bir kez [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarlayın. Daha büyük bir değer kümeler arasındaki alanı artırır; daha küçük bir değer onları daha sık hâle getirir.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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

## **Seri Çizgilerini Gösterme veya Gizleme**

Seri çizgileri, bir grafiğin ilgili bölümlerini görsel olarak birbirine bağlar. Desteklenen yığılmış çubuk ve OfPie grafiklerinde göstermek veya gizlemek için [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) kullanın. İki boyutlu yığılmış çubuk ve sütun grafiklerinde, kategoriler arasında ilgili yığın sınırlarını bağlar. Pie of Pie ve Bar of Pie grafiklerinde, ana grafiği ikincil grafiğe bağlar. Bu ayar, diğer grafik türleri için genel bir bağlayıcı değildir.

Gruba, [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) üzerinden erişin. Ayar, gruptaki tüm serileri etkiler. [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) yalnızca okuma amaçlıdır ve üst grup ayarını yansıtır; güncellemek için grup özelliğini değiştirin.

Aşağıdaki örnek, varsayılan veriye sahip bir [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) grafiği oluşturur. Aynı grafiği, seri çizgileri etkinleştirilmiş ve devre dışı bırakılmış olarak kaydeder; karşılaştırma için iki sunum oluşturur.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| Seri çizgileri etkin | Seri çizgileri devre dışı |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| İki çizgi, ana pasta ile ikincil pastayı bağlar. | Her iki pasta da görünür, ancak bağlayıcı çizgiler gizlenir. |

Seri çizgileri, etiket lider çizgileri (etiketleri veri noktalarına bağlayan), eksen ızgaraları (grafik eksenlerinde aralıkları işaretleyen) ve veri değerlerini temsil eden çizgi grafik çizgileri gibi öğelerden farklıdır. Bu ayar, bu öğeleri kontrol etmez.

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumu tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin kategori grafikler kategori ve değer, dağılım grafikler X ve Y değeri, baloncuk grafikler ise baloncuk boyutları kullanır. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Üst üste gelme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun grupları için geçerlidir.

**Bir grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup içerebilir; bir seri üzerinden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak değiştirmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir başka aşırı yük, varsayılan veri olmadan grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri, bir [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir seri yerine yalnızca bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak, noktanın kategori konumunu boş bir nokta olarak koruyabilirsiniz. Diğer noktaları tutmak istediğinizde, sadece bu hücreyi temizleyin. [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) yalnızca tüm noktaları kaldırmak istediğinizde kullanılmalıdır; aksi takdirde seri içindeki diğer noktalar da silinir. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ayarına bağlıdır. Desteklenen grafikler, boşlukları boşluk olarak, sıfır değeri olarak ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Control the Display of Empty Cells](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) özelliğini etkinleştirip [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ile negatif değer rengini ayarlayın. Bireysel bir nokta için davranışı [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ile geçersiz kılabilirsiniz. Bu özellikler biçimlendirmeyi etkiler, saklanan sayısal değeri değiştirmez.

**Seri ve nokta her ikisi de biçimlendirilmişse hangi biçimlendirme geçerli olur?**

Açıkça ayarlanmış veri‑nokta biçimlendirmesi, o nokta için önceliklidir. Diğer noktalar, açıkça bir seri biçimi tanımlanmadıysa otomatik grafik stili ve teması kullanır. Üst üste gelme ve boşluk genişliği gibi grup özellikleri düzeni kontrol eder; nokta‑seviyesi biçimlendirme geçersiz kılmaz.

**Bir grafiğin içerebileceği seri sayısı için bir sınır var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı uygulamaz. Pratik olarak, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapmalıyım?**

Uygun üst grup serisi üzerinde [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ayarını değiştirin. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine daha yakın hâle getirin.