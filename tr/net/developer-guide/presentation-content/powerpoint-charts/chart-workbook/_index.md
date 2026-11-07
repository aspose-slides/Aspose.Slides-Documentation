---
title: ".NET'te Sunumlarda Grafik Çalışma Kitaplarını Yönetme"
linktitle: "Grafik Çalışma Kitabı"
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
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı ele alır. Örnekler, harici bir çalışma kitabı nasıl oluşturulur ve atanır, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolu nasıl alınır ve çalışma kitabı mevcut olduğunda grafik verileri nasıl düzenlenir gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut gösterim modlarının bir satır grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri İçerme**

Gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol etmek için [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) özelliğini kullanın. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez ya da göstermez.

[Örnek sunum](hidden-source-data.pptx), ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma Sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) özelliğini okuyun. Bu özellik yalnızca okunur. Bu dosyada B2 görünür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ile koruyun ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken gizli Şubat kategorisini geri yüklemek için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) da kullanın. Sadece bayrağı değiştirmek bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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

        // Gömülü çalışma kitabından grafik verilerini yenile.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Gizli kategorileri içeren tam kaynak aralığını geri yükle.
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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sunum ve tüm altı değeri içeren başka bir sunum olmak üzere iki sürüm kaydeder. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanmış çizim ayarını korur. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren gizli bir hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl gösterileceğini kontrol etmek için [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) kullanılır; bu, gizli kaynak verileri eklemez ya da çıkarmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, hangi çalışma sayfası hücrelerinin her grafik tarafından kullanıldığını belirlemek amacıyla kaynak aralıklarını inceleyin. [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) yöntemi, örneğin `Sheet1!$A$1:$D$5` gibi, çalışma sayfası nitelikli bir formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar (dahil) hücreleri tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) bölümüne bakın.

Bu örnek, bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını belirler. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa, bir mesaj yazdırır ve bir sonraki grafiğe geçer.

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

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for .NET, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenen) okuma ve yazma olanağı sağlayan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sunar. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir akıma okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek, orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

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

    // Burada, örneğin Aspose.Cells kullanarak çalışma kitabı akışını değiştirin.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemeleri yeniden oluşturulmalı ve daha sonra grafik kullanılmalıdır.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Ayarlama**

[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) kullanarak sayısal değerlerin gömülü çalışma kitabındaki grafikte nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını dört ondalık basamaklı yüzde biçiminde ve bir katsayıyı beş ondalık basamaklı biçimde gösterebilir. Her iki değeri de sayısal tutarak hesaplamalar ve grafik çizimi için kullanılabilir tutun.

Sayı biçimi, gösterimi değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi, `0.125` değerini `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde, `0.00000` biçimi `0.1234567` değerini `0.12346` olarak gösterir ancak saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, bunun yerine [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) kullanılır.

Aşağıdaki örnek, bir sütun grafik oluşturur ve hücrelerine [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişir. Çalışma sayfası 0’da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, grafik eksenleri veya veri etiketleri üzerinde doğrudan ayarlanan biçimlerden ayrıdır. Bu örnekte, her etiket kaynak hücresinin değerini gösterir çünkü [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) etkinleştirilmiştir ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` olarak ayarlanmıştır. Sunum kaydedilip yeniden açıldıktan sonra etiketler `12.5000%` ve `0.12346` olarak görüntülenir. Dikey eksen ise kendi [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` biçimini kullanır ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` olarak ayarlanmıştır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken, B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Grafik Veri Etiketleri](/slides/tr/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunum kaydedilip yeniden açıldıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346 gösterdiği, bağımsız biçimlendirilmiş sayısal ekseni olan sütun grafik.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Kullanma**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. İlk serideki ilk üç etiket için çalışma sayfası 0’da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenen sunumu kaydeder.

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfası adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirtme**

Seri nokta değerleri doğrudan sayısal sabitler olarak da depolanabilir. Kaydetme ve okuma örnekleri için [Seri Değerlerini Sayısal Sabitlerle Ayarlama](/slides/tr/net/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin veri kaynağı türü, grafiğin dahili veya harici çalışma kitabı yapılandırmasından ayrı olur; sayısal sabitlerin kullanılması tek başına gömülü çalışma kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve farklı veri kaynaklarıyla iki seri adı ayarlar. İlk ad bir dize sabiti, ikincisi ise çalışma sayfası 0’da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenen seri adlarıyla sunumu kaydeder.

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) üzerindeki [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) özelliğini, [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) enumu ile birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı bulunan her grafik için tanısal bir mesaj yazar.

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

    // Burada desteklenen grafik çalışma kitabı verilerini okuyun veya değiştirin.
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarının kullanılmasını destekler.

### **Harici Çalışma Kitabı Oluşturma**

[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafik ile bu harici çalışma kitabını ilişkilendirebilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dışa aktarma akışını kapatır, ardından harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlantılı sunumu kaydeder.

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

### **Harici Çalışma Kitabı Ayarlama**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemiyle bir grafik için harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolu (taşınmışsa) güncellenmek istendiğinde de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki veriler düzenlenemez, ancak bu çalışma kitapları hâlâ harici veri kaynağı olarak kullanılabilir. Harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfası içinde B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafikle sunumu kaydeder.

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metodundaki `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olacak şekilde bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve bulunmayan çalışma kitabı yüklenmeden sunum kaydedilir.

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

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici bir çalışma kitabına bağlanan bir grafiğin olduğu bir sunumun ilk slaydındaki ilk şekli inceler. Grafik harici bir çalışma kitabına bağlanmışsa, [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) değerini konsola yazar ve ardından sunumun bir kopyasını kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki değişiklikler gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olan ve erişilebilir bir harici çalışma kitabına bağlanan bir grafik kullanır. İlk serideki ilk veri noktasının hücre‑destekli değerini 100 yapar ve güncellenen sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanan harici XLSX dosyasını da güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

[Aspose.Slides for .NET](/slides/tr/net/installation/) 26.11 veya daha yeni sürüm yüklüyse, bu örnek `charts.pptx` dosyasının ilk slaydındaki ilk grafiği yeniler. Kaynak çalışma kitabının mevcut olması gerekir. Güncellenen grafik verilerini korumak için sonucu kaydedin.

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

Tüm grafikleri yenilemek için ayrı bir sunum örneği şu şekilde kullanılır. `false` geçirilmesi, bir yenileme hatasının çağırıcıya yayılmasını sağlar; önceden yenilen grafikler geri alınmaz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

Parametrenin varsayılanı `true`dır: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) başarısız bir grafiği atlar ve diğerlerine devam eder. Her grafik için sonuç döndürmez; dolayısıyla tamamlanmış bir çağrı, tüm grafiklerin yenilendiğini kanıtlamaz. Her bir başarısız grafiği tespit etmeniz gerekiyorsa, ayrı ayrı [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) çağrıları yapın.

Yenileme, kaynak verileri yeniden yükler. Formül hesaplaması, grafik düzeni doğrulaması ve OLE ön izlemesi güncellemelerinden ayrı bir işlemdir. Bellekteki yenilemeyi kontrol etmek için canlı hücre‑destekli değerleri inceleyin. [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) hâlâ kaydedilmiş grafik açıklamasını tanımlayabilir; ancak sunumu kaydedip yeniden açtığınızda geçerli olur.

### **Bir Çalışma Kitabı Olmadan Önbelleklenen Grafik Değerlerini Okuma**

.NET 26.11’de, önbellek‑değer erişicileri, çalışma kitabını açmadan grafiğe kaydedilen değerleri okur. Bağlı dosya kullanılabilir değilse ve yalnızca grafiğin son kaydedilmiş verilerine ihtiyacınız varsa kullanışlıdır. Bu, aşağıdaki kurtarma seçeneğiyle bir çalışma kitabı yeniden oluşturmakla farklıdır.

| Nesne | Önbellek erişicisi |
| --- | --- |
| Normal seri veri noktası | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| Dağılım veya balon veri noktası | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| Balon veri noktası | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| Grafik kategorisi | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

Her erişici, [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) döndürür. [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) saklanan nesneyi ortaya çıkarır; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) metni sağlar; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) eksik veya sayısal olmayan bir değer için `NaN` döndürür. Önbellek eksik veya eski olabilir; yeni oluşturulmuş ve henüz kaydedilmemiş bir grafikte de bulunabilir. Her alanın mevcut olduğunu veya bir sayı içerdiğini varsaymayın.

Bu örnek, grafikler içeren kaydedilmiş bir sunum `cached-chart.pptx` dosyasındaki tüm bu alanları okur. Harici bir çalışma kitabının eksik olması sorun teşkil etmez çünkü kod [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) veya canlı çalışma kitabı hücrelerine erişmez.

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

Mevcut kaynak veriye ihtiyacınız olduğunda yenilemeyi, saklanan anlık görüntü yeterli olduğunda önbellek okumalarını kullanın. Önbellek, çalışma kitabının tam bir kopyası değildir ve son güncellemeden sonraki değişiklikleri sağlayamaz.

### **Grafik Önbelleğinden Bir Çalışma Kitabı Kurtarma**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve sunumu açmadan önce [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` olarak ayarlayın.

Aşağıdaki C# örneği, ilk slaydın ilk şekli olan ve kullanılamayan bir harici çalışma kitabına başvuran bir grafik için çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) ve [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) aracılığıyla erişilir:

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

Kod, harici çalışma kitabına erişmeye çalışırken ve kurtarma devre dışı bırakıldığında [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Önbellekli grafik verilerinin kabul edilebilir bir geri dönüş olması durumunda yalnızca o zaman kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendikten sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak harici bir çalışma kitabı ise tam yolu okuyarak dış dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında depolar; bu yüzden çalışma kitabını taşımak, bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides’dan uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez—sadece veri kaynağı olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar. Hücre‑destekli grafik verileri, bağlanan yerel XLSX dosyasını da güncelleyebilir. Orijinal çalışma kitabının değiştirilmemesini istiyorsanız bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya bir kopyasını (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/net/)) şifresiz olarak hazırlayıp ona bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncelleme tüm grafiklerde bir sonraki veri yüklemesinde yansır.