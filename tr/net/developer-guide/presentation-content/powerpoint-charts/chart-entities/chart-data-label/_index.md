---
title: .NET'te Sunumlarda Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/net/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint sunumlarında daha etkileyici slaytlar için Aspose.Slides for .NET kullanarak grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktalarıyla ilgili bilgileri gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde görüntüleme, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiket boşluğunu ayarlama ve pasta grafiği etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [NumberFormatOfValues](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/numberformatofvalues/) kullanılabilir. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi binlik ayırıcı ve iki ondalık basamak gösterir, temel değerleri değiştirmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **Yüzdeyi Etiket Olarak Görüntüleme**

Yığılmış sütun grafik için, her değeri kategori toplamının yüzde olarak hesaplayın ve metni [TextFrameForOverriding](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) üzerinden atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzdeyi 8 puanlık bir yazı tipinde iki ondalık basamakla gösterir. Toplamı sıfır olan kategoriler, bölme hatasını önlemek için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarlama**

Değerler kesir olarak saklandığında, yüzdeyi görüntülemek için [NumberFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/numberformat/) kullanılabilir. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) özelliğini `false` olarak ayarlayın.

Bu örnek, dört kategori boyunca kırmızı ve mavi seriler içeren %100 yığılmış bir sütun grafik oluşturur. Her değer çifti 1’e toplar. `0.0%` etiket biçimi 0.30 değerini 30.0% olarak gösterir, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 puanlık etiket metni kullanır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Veri Etiketlerinin Gerçek Metnini Okuma**

[GetActualLabelText](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabel/getactuallabeltext/) kullanarak bir veri etiketinin ayarlarıyla üretilen metni alın. Bu, raporlar için etiketleri çıkarmak, sunum içeriğini aramak veya oluşturulan grafikleri doğrulamak istediğinizde faydalıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, bir diğeri ise [TextFrameForOverriding](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) üzerinden özel metin kullanır.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

Bir veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde kategori ve seri adlarıyla birlikte `%75` gösterse bile. Özel metin oluşturulan etiket metninin yerini alır. [GetActualLabelText](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabel/getactuallabeltext/) her iki durumda da sonuç etiket dizesini döndürür. Yalnızca görünen etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi [IsVisible](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabel/isvisible/) ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu veri etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) kullanılabilir. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2B kümelenmiş bir sütun grafik oluşturur. Dikey eksende [IsAutomaticMaxValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) özelliğini `false`, [MaxValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/iaxis/maxvalue/) özelliğini ise 100 olarak ayarlar. İlk slayt maksimumun ötesindeki etiketlere izin verir; bu slaytın bir kopyası ise bunları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` dosyasında kaydedilir.

[ShowValue](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/showvalue/) ile değer etiketlerini etkinleştirin. Grafik seviyesi ayarı tek başına değer gösterimini açmaz ve bireysel bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve etiketleri her sütunun dış ucuna yerleştirmek için [Position](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatalabelformat/position/) kullanır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

Aşağıdaki görseller, Microsoft PowerPoint tarafından render edilen kaydedilmiş slaytları gösterir. `true` olduğunda, **120** etiketi üst sınırda görünür; `false` olduğunda gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olarak kalır.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint grafiği, eksen maksimumu 100 iken değer etiketi 120'yi gösteriyor](data-labels-over-maximum-true.png) | ![PowerPoint grafiği, eksen maksimumu 100 iken değer etiketi 120'yi gizliyor](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2B sütun grafiği kullanır. Değer ekseni olmayan grafikler, örneğin pasta ve halka grafikler, bu şekilde sınırlandırılabilecek bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Bir Eksenden Etiket Mesafesini Ayarlama**

[LabelOffset](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/iaxis/labeloffset/) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun yüzdesidir. Bu örnek, kümelenmiş bir sütun grafik oluşturur ve yatay eksen etiket kaymasını 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına bağlı etiketlerden ziyade kategori ekseni etiketlerini etkiler.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Etiket Konumunu Ayarlama**

Pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşluğu iyileştirin ve nokta çizgileri için alan oluşturun.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [X](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ilayoutable/x/) ve [Y](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ilayoutable/y/) kaymalarını ayarlar. Bu kaymalar, sırasıyla grafiğin genişliği ve yüksekliğiyle orantılıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![Ayarlanmış veri etiketi konumlu pasta grafiği](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste gelmesini nasıl önleyebilirim?**

Otomatik etiket yerleşimini, nokta çizgilerini ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca aşırı değerler veya ana noktalar için etiketleri gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerlerin gösterimini kapatın.

**PDF/görüntülere aktarırken tutarlı bir etiket stili nasıl sağlanır?**

Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve yedekleme olmaması için yazı tipinin render ortamında mevcut olduğunu doğrulaylayın.