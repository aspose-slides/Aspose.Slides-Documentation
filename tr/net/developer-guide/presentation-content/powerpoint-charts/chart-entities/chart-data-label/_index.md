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
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarına grafik veri etiketleri eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar elde edin."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde görüntüleme, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafiği etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) kullanın. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir, temel değerleri değiştirmez.

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

Grafiğin gömülü çalışma kitabındaki sayısal hücreleri biçimlendirmek için [Set Custom Number Formats for Workbook Cells](/slides/tr/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) sayfasına bakın. Bu örnek aynı zamanda, değer etiketlerinin kaynak hücre biçimlerine uyarak saklanan sayısal değerleri koruduğunu gösterir.

## **Yüzdeyi Etiket Olarak Görüntüleme**

Yığılmış sütun grafik için, her değeri kategori toplamının yüzde olarak hesaplayın ve metni [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) aracılığıyla atayın. Bu örnek varsayılan grafik verilerini kullanır ve yüzdeyi iki ondalık basamakla 8 punto yazı tipinde gösterir. Sıfır toplamlı kategoriler sıfıra bölmeyi önlemek için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

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

## **Grafik Veri Etiketlerinde Yüzde Simgesini Ayarlama**

Değerler kesir olarak saklandığında, yüzdeyi görüntülemek için [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) özelliğini `false` olarak ayarlayın.

Bu örnek, dört kategori boyunca kırmızı ve mavi serilerle %100 yığılmış bir sütun grafik oluşturur. Her değer çifti 1’e toplamaktadır. `0.0%` etiket biçimi, 0.30 değerini 30.0% olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

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

Bir veri etiketinin ayarları tarafından üretilen metni almak için [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) kullanın. Bu, raporlar için etiketleri çıkarmak, sunum içeriğinde arama yapmak veya oluşturulan grafikleri doğrulamak için yararlıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimlendirir, bir diğeri ise [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) aracılığıyla özel metin kullanır.

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

Bir veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde kategori ve seri adlarıyla birlikte `%75` gösterse bile. Özel metin, oluşturulan etiket metninin yerini alır. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) her iki durumda da sonuç etiket dizesini döndürür. Yalnızca görünür etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi, [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) ayrı olarak kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Bir eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu veri etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerlerine sahip 2D kümelenmiş bir sütun grafik oluşturur. Dikey eksende [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) özelliğini `false`, [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) özelliğini ise 100 olarak ayarlar. İlk slayt, maksimumun üzerindeki etiketlere izin verir; o slaytın bir kopyası ise bunları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` dosyasına kaydedilir.

[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) ile değer etiketlerini etkinleştirin. Grafik düzeyindeki bu ayar, tek başına değer gösterimini açmaz veya bireysel bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve etiketleri her sütunun dış ucuna konumlandırmak için [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) kullanır.

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

Aşağıdaki görüntüler, Microsoft PowerPoint tarafından oluşturulan kaydedilmiş slaytları gösterir. `true` olduğunda, **120** etiketi üst sınırda görünür; `false` olduğunda gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olur.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint grafiği, eksen maksimumu 100 ile değer etiketi 120'yi gösteriyor](data-labels-over-maximum-true.png) | ![PowerPoint grafiği, eksen maksimumu 100 ile değer etiketi 120'yi gizliyor](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2D sütun grafiği kullanır. Değer ekseni olmayan grafikler, örneğin pasta ve halka grafikler, bu şekilde sınırlandırılabilecek bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Etiketlerin Eksenle Olan Mesafesini Ayarlama**

[LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun yüzde olarak ifade edilmesidir. Bu örnek, kümelenmiş bir sütun grafik oluşturur ve yatay eksen etiketi kaymasını 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına eklenmiş etiketlerden ziyade kategori ekseni etiketlerini etkiler.

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

Pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve lider hatlar için yer açın.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) ve [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) kaydırmalarını ayarlar. Bu kaydırmalar sırasıyla grafiğin genişliği ve yüksekliğine göre orantılıdır.

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

![Ayarlanmış veri etiketi konumlu pasta grafik](pie-chart-adjusted-label.png)

## **Lider Çizgileri Biçimlendirme**

Pasta grafiği etiketleri dilimlerin dışına yerleştirildiğinde, lider çizgileri okuyucuların her değeri doğru dilime eşleştirmesine yardımcı olur. Zıt bir renk ve biraz daha kalın bir çizgi bu bağlantıları daha izlenebilir kılar, şeffaflık ve kesikli stil ise çizgileri görsel olarak rahatsız etmeyici tutar.

Lider çizgileri, serinin veri etiketi koleksiyonu seviyesinde biçimlendirmek için [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) kullanın. `series.Labels.LeaderLinesFormat.Line` içindeki ayarlar, bireysel bir etiketten ziyade koleksiyona uygulanır.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur, değerleri dilimlerin dışına gösterir ve [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) işlevini etkinleştirir. İki etiketi dilimlerinden daha uzağa taşımak için [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) ve [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) kaydırmaları, grafiğin genişliği ve yüksekliğinin kesirleri olarak ifade eder. Giriş sunumu gerekmez.

Çizginin [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) özelliği, 255 üzerinden 191 alfa değeriyle %25 civarında şeffaflık sağlayan katı mavi bir renk ayarlar. [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) kalınlığı 2 puan olarak belirler ve [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) çizgiyi kesikli yapar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// İki etiketi dilimlerinden daha uzağa taşı.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

Lider çizgileri etkinleştirildiğinde, her etiket için bir çizgi görünür olacağı garanti değildir. Görünürlük, etiket yerleşimine ve grafiğin düzen davranışına bağlıdır. Bu örnekte, iki uzaklaştırılmış etiketin görünür lider çizgileri vardır; dilimlerine yakın kalan etiketlerin ise buna ihtiyacı yoktur.

Aşağıdaki görüntü, Aspose.Slides ile oluşturulan kaydedilmiş `FormattedLeaderLines.pptx` dosyasını gösterir:

![İki dış etiketi dilimlerine bağlayan mavi, yarı saydam kesikli lider çizgileriyle pasta grafiği](formatted-leader-lines.png)

## **Sütun Grafiğinin Üstüne Birden Çok Veri Etiketi Satırı Ekleme**

Bu örnek, çizim alanının üstünde iki satır veri etiketi bulunan bir sütun grafik oluşturur. A Serisi görünür sütunları gösterirken, B ve C Serileri ek etiketleri sağlar. Bu sütunlar dolgu ve kenarlık kaldırılarak gizlenir. [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) özelliği, üç seriyi aynı kategori merkezleriyle hizalar.

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) ayarları, etiket satırları için alan ayırır. [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) varsayılan konumları hesapladıktan sonra, [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) ve [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) yatay hizalamayı korur ve etiketleri iki satırda düzenlemek için dikey kaydırmalar uygular. Sayılar, seri değerlerine bağlı veri etiketleri olarak kalır; yalnızca satır başlıkları ayrı metin şekilleridir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // B ve C sütunlarını gizle, ancak veri etiketlerini tut.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// Üç seriyi aynı kategori merkezleriyle hizala.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Bu kompakt örnek için daha az ızgara çizgisi kullan.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Çizim alanının üstünde iki satır veri etiketi için alan ayır.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // Varsayılan yatay konumu koru. Y, 
        // varsayılan etiket konumundan, grafik yüksekliğinin bir kesri olarak ifade edilen.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // Sadece satır başlığı ayrı bir metin şeklidir.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![Çizim alanının üstünde iki satır veri etiketi olan sütun grafik](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin çakışmasını nasıl önleyebilirim?**  
Otomatik etiket yerleşimi, lider çizgileri ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin kategori) gizleyin veya yalnızca ekstrem değerler ya da ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri yalnızca nasıl devre dışı bırakabilirim?**  
Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için gösterimi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**  
Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve geri dönüşümden kaçınmak için yazı tipinin render ortamında mevcut olduğunu doğrulayın.