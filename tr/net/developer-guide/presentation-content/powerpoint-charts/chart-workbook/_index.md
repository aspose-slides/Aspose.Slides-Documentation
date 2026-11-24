---
title: .NET'te Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/net/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafik ile ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki fark ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırması için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmediğini kontrol etmek için [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) kullanın. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

Bu [örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını içerir: `A1:C4`. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer taşır.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) okuyun. Bu özellik salt okunurdur. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ile tutun ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de geri yüklemek için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) kullanın. Sadece bayrağı değiştirmek, bu örneğin önbelleklenmiş grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Gömülü çalışma kitabından grafik verilerini yenileyin.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükleyin.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Örnek, sunumu iki sürümde kaydeder: yalnızca görünür Perakende değerlerini (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanmış çizim ayarını korur. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Gizli bir hücrede değer bulunması, boş bir hücreden farklıdır. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verilerini eklemez veya çıkartmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Getirme**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek üzere kaynak aralıklarını inceleyin. [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) yöntemi, mevcut veri aralığını `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak döndürür. Burada `Sheet1` çalışma sayfası adı, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar (dahil) hücreleri tanımlar. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikleri için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj yazar ve bir sonraki grafa geçer.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for .NET, grafik verilerini (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okuma ve yazma imkanı sağlayan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sunar. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir akısa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik özgün seriler ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) yönteminin indeks dışı hata vermesine yol açabilir. Güncellenmiş çalışma kitabını geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Burada çalışma kitabı akışını değiştirin, örneğin Aspose.Cells kullanarak.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Kategori Etiketlerini Nasıl Depolayacağınızı Seçin**

Boş kategori koleksiyonunda etiket eklemeden önce [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) özelliğini ayarlayın. Çalışma kitabı hücrelerini, workbook verilerine başvuran veya yıl bazında gruplanmış çeyrekler gibi hiyerarşik etiketler için kullanın. Tek seviyeli ve hücre başvurusu gerektirmeyen etiketler için dize sabitleri kullanın. Bu ayar yalnızca kategorilere uygulanır. Aşağıdaki iki grafik, sayısal seri değerleri için çalışma kitabı hücrelerini kullanır.

Örnek iki sütun grafik oluşturur ve her biri için `Q1 Q2 Q3 Q4` etiketlerini ve depolama modunu yazar. Çalışma kitabı destekli etiketler için [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) temel hücreye erişim sağlar ve [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) etiketini döndürür. Sabit etiketler için ise [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/) doğrudan dizeyi verir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimleri Ayarlama**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) kullanarak, grafik gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamak ve katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutarak hesaplamalar ve grafik çizimi için kullanılabilir halde bırakın.

Sayı biçimi yalnızca gösterimi değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayı `12.5` ile değiştirilmez. Benzer şekilde, `0.00000` biçimi `0.1234567` sayısını `0.12346` olarak gösterir ancak saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise yerine [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerlerini sağlar. Örnek aynı zamanda kaynak biçimlere bağlı değer etiketlerini etkinleştirir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Çalışma kitabı hücre biçimleri, doğrudan eksenlere veya veri etiketlerine uygulanan biçimlerden ayrı tutulur. Bu örnekte, her etiket [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) etkin olduğu için kaynak hücrenin değerini gösterir ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` olduğu için kaynak sayı biçimini izler. Sunum kaydedilip yeniden açıldıktan sonra etiketler `12.5000%` ve `0.12346` olarak görüntülenir. Dikey eksen ise kendi [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` biçimini kullanır ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` olarak ayarlanmıştır.

Bağımsız bir veri etiketi biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Chart Data Labels](/slides/tr/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunum kaydedilip yeniden açıldıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346, bağımsız biçimlendirilmiş sayısal eksen gösterdiği bir sütun grafik.](custom-cell-formats.png)

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Kullanma**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. İlk serinin ilk üç etiketi için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden gelen etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Çalışma Sayfalarını Yönetme**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Veri Kaynağı Tipini Belirtme**

Seri nokta değerleri doğrudan sayısal sabitler olarak da depolanabilir. Kaydedip okuyan tam bir örnek için [Set Series Values Using Numeric Literals](/slides/tr/net/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin kaynak tipi, grafiğin iç / dış çalışma kitabı yapılandırmasından ayrıdadır; sayısal sabitler kullanmak tek başına gömülü çalışma kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti; ikincisi ise çalışma sayfası 0'da C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) enumu, her isim için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) özelliğini [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) ile birlikte [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) enumu ile kullanarak desteklenmeyen biçimleri tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı olan her grafik için tanı mesajı yazar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için harici çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanarak gömülü grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Çıktı akışını kapatır, harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlanmış sunumu kaydeder.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Harici Çalışma Kitabı Atama**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemiyle bir grafiğe harici bir çalışma kitabı veri kaynağı olarak atanabilir. Bu yöntem aynı zamanda harici çalışma kitabının yolunu (dosya taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak yine de kullanabilirsiniz. Göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Bir pasta grafik oluşturur, çalışma kitabını bağlar ve [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafikle birlikte sunumu kaydeder.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metodundaki `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini belirler.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, böylece çalışma kitabı bulunmayabilir.
* `updateChartData` `true` olduğunda grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve bulunamayan çalışma kitabı yüklenmeden sunum kaydedilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğe bağlanmış çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici çalışma kitabına bağlanmış bir sunumun ilk slaydındaki ilk şekli inceler. Eğer şekil bir grafik ve harici bir çalışma kitabına bağlıysa, [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) değerini konsola yazar. Ardından sunumun bir kopyasını kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanmıştır. İlk serinin ilk veri noktasının hücre‑temelli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanmış dış XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

## **Kaynak Çalışma Kitaplarından Grafik Verilerini Yenileme**

Aspose.Slides for .NET 26.11, tek bir grafik için [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) ve sunum için [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) ekler. Kaynak çalışma kitabı değerleri değiştiğinde bunları kullanın. Harici çalışma kitapları erişilebilir ve destekleniyor olmalıdır.

[Aspose.Slides for .NET](/slides/tr/net/installation/) 26.11 veya daha yeni bir sürüm yüklü ise, bu örnek `charts.pptx` dosyasının ilk slaydındaki ilk grafik için yenileme yapar. Kaynak çalışma kitabı erişilebilir olmalıdır. Sonucu kaydedin, böylece güncellenmiş grafik verileri korunur.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

Tüm grafikleri yenilemek için ayrı bir sunum örneği aşağıdaki gibi kullanılır. `false` geçirilmesi, yenileme hatasının çağırıcıya yayılmasını sağlar; zaten yenilenmiş grafikler geri alınmaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

Parametre varsayılan olarak `true`dır: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) başarısız bir grafiği atlar ve diğerlerine devam eder. Her grafik için ayrı bir sonuç döndürmez; başarılı bir çağrı tüm grafiklerin yenilendiğini kanıtlamaz. Hangi grafiğin başarısız olduğunu bilmek istiyorsanız ayrı ayrı [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) çağrıları yapın.

Yenileme, kaynak veriyi yeniden yükler. Formül hesabı, grafik düzeni doğrulaması ve OLE ön izleme güncellemesinden ayrıdır. Bellekteki yenilemeyi kontrol etmek için canlı hücre‑temelli değerlere bakın. Bir [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) sunumu kaydedip yeniden açana kadar önceki kaydedilmiş grafiği tanımlamaya devam edebilir.

### **Bir Çalışma Kitabsı Olmadan Önbelleklenmiş Grafik Değerlerini Okuma**

.NET 26.11'de, önbellek‑değer erişicileri, çalışma kitabını açmadan grafik ile birlikte kaydedilen değerleri okur. Bağlı dosya kullanılamadığında ve yalnızca grafiğin son kaydedilen verisine ihtiyacınız olduğunda faydalıdır. Bu, aşağıdaki kurtarma seçeneğiyle bir çalışma kitabı yeniden oluşturmakla farklıdır.

| Nesne | Önbellek erişicisi |
| --- | --- |
| Normal seri veri noktası | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| Dağılım veya balon veri noktası | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| Balon veri noktası | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| Grafik kategorisi | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

Her erişici, [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) döndürür. [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) saklanan nesneyi ortaya koyar; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) metni verir; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) yoksa veya sayısal olmayan bir değerse `NaN` döndürür. Önbellek eksik ya da eski olabilir; yeni oluşturulmuş fakat kaydedilmemiş bir grafik de önbellek içermeyebilir. Her alanın mevcut olduğunu ya da bir sayı içerdiğini varsaymayın.

Bu örnek, grafik içeren kaydedilmiş bir sunum `cached-chart.pptx`'deki tüm bu alanları okur. Harici bir çalışma kitabının eksik olması sorun oluşturmaz çünkü kod [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) ya da canlı çalışma kitabı hücrelerine erişmez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

Kaynak veriye ihtiyaç duyduğunuzda yenilemeyi, yalnızca saklanmış anlık görüntünün yeterli olduğu durumlarda önbellek okumasını kullanın. Önbellek, çalışma kitabının tam bir kopyası değildir ve son güncellemeden sonra yapılan değişiklikleri sağlayamaz.

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabına bağlıysa, Aspose.Slides sunumda önbellekteki veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve sunumu açmadan önce [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` yapın.

Aşağıdaki C# örneği, ilk slaydın ilk şekli olarak bir grafik için dış çalışma kitabı eksik olduğunda çalışma kitabı verilerini kurtarır. Kurtarılan veriye [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) ve [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişir:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Kod, dış çalışma kitabına erişmeye çalışırken ve kurtarma devre dışı bırakıldığında [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Önbellekli grafik verilerini bir geri dönüş seçeneği olarak kabul edebiliyorsanız kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabındaki sunum son güncellendikten sonra yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [external workbook path](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazıyor mu?**

Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar. Hücre‑temelli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal çalışma kitabının değiştirilmemesi gerekiyorsa bir kopya kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir şifresiz kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/net/)) hazırlamak ve o kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde her grafik bir sonraki veri yüklemesinde bu değişikliği yansıtır.