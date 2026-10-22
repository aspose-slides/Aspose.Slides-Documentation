---
title: .NET'te Sunularda Grafik Çalışma Kitaplarını Yönetme
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
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarındaki grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanma konusunu da kapsar. Örnekler, dış bir çalışma kitabı oluşturma ve atama, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verilerini düzenleme yollarını gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Etme**

Gizli çalışma sayfası satır ve sütunlarındaki verilerin bir grafik tarafından çizilip çizilmeyeceğini kontrol etmek için [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) kullanın. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) değerini okuyun. Bu özellik sadece okuma içindir. Bu dosyada B2 görünür, B3 gizli satıra, C2 ise gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ile tutun ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de geri yüklemek için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) kullanın. Yalnızca bayrağı değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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

        // Grafiği gömülü çalışma kitabından yenileyin.
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

Örnek, sunumu iki sürüm olarak kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanmış çizim ayarını korur. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl görüntüleneceğini kontrol eden [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) gizli kaynak veriyi eklemez veya çıkartmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek üzere kaynak aralıkları inceleyin. [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) yöntemi, mevcut veri aralığını `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak döndürür. Burada `Sheet1` çalışma sayfasının adı, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1‑D5 hücrelerini kapsar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazar. Bir grafik çalışma kitabı kullanmıyorsa, bir mesaj yazdırıp bir sonraki grafikle devam eder.

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

Aspose.Slides for .NET, grafik verisi çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okuma ve yazma imkanı sağlayan [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sunar. **Not**: grafik verileri aynı düzen içinde olmalı veya kaynakla benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir akıma okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) yönteminin indeks‑dışına‑kapsam hatası vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik üzerine yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellekte doğrular.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Ayarlama**

Grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol etmek için [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) kullanın. Örneğin, bir raporda dönüşüm oranı yüzde olarak dört ondalık basamakla, bir katsayı ise beş ondalık basamakla gösterilebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir.

Sayı biçimi görüntüyü değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` değerini `12.5000%` olarak gösterir; sayıyı `12.5` ile değiştirmez. Benzer şekilde, `0.00000` `0.1234567` değerini `0.12346` olarak gösterir, saklanan değer yuvarlanmaz. Özel biçim boş bir dize (`""`) ise, yerine [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişir. 0. çalışma sayfasında B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerleri sağlar. Örnek ayrıca kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, doğrudan grafik eksenlerine veya veri etiketlerine uygulanan biçimlerden ayrıdır. Bu örnekte, her etiket [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) etkin olduğu için kaynak hücrenin değerini gösterir ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` olduğu için kaynak sayı biçimini izler; sunum kaydedilip yeniden açıldığında etiketler `12.5000%` ve `0.12346` olarak görünür. Dikey eksen, `0.00` biçimli kendi [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) değerini kullanır ve [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false` olarak ayarlanmıştır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterir, B2 hâlen `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Grafik Veri Etiketleri](/slides/tr/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunum kaydedilip yeniden açıldıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketleri gösteren sütun grafik, 12.5000% ve 0.12346, ayrıca bağımsız biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Grafik veri etiketleri olarak çalışma kitabı hücrelerindeki metni kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verilere sahip bir balon grafik ekler. İlk serinin ilk üç etiketi için 0. çalışma sayfasındaki A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek bir pasta grafik oluşturur, varsayılan veri ekler ve her çalışma sayfasının adını konsola yazar.

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

Seri nokta değerleri doğrudan sayısal sabitler olarak da saklanabilir. Kaydedip okuyabileceğiniz tam bir örnek için [Sayısal Sabitler Kullanarak Seri Değerlerini Ayarlama](/slides/tr/net/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasından bağımsızdır; sayısal sabitler kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz.

Bu örnek, varsayılan veriye sahip bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti, ikincisi 0. çalışma sayfasındaki C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) enum’ı her adın kaynağını seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) üzerindeki [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) özelliğini ve [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) enum’ını birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayanları atlar ve .xlsb gömülü çalışma kitabı içeren her grafik için bir tanılayıcı mesaj yazar.

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

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikleri için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitabı Oluşturma**

Gömülü grafik çalışma kitabını bir dosyaya dışa aktarmak ve grafiği o dış çalışma kitabına bağlamak için [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanın.

Bu örnek, varsayılan veri ile bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dış çalışma kitabını grafik veri kaynağı olarak atamadan önce çıktı akışını kapatır, ardından bağlı sunumu kaydeder.

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

### **Dış Çalışma Kitabı Atama**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemiyle bir grafiğe dış bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının yolu (dosya taşındıysa) güncellenmek istendiğinde de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içeren bir dış çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafiği içeren sunumu kaydeder.

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve erişilemeyen çalışma kitabı yüklenmeden sunum kaydedilir.

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

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğe bağlı çalışma kitabını belirlemek için, grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bağlanmış bir dış çalışma kitabı içeren bir sunumun ilk slaydındaki ilk şekli inceler. Eğer bir grafik dış çalışma kitabına bağlıysa, [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) değerini konsola yazar ve ardından sunumun bir kopyasını kaydeder.

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

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki verileri düzenlediğiniz gibi değiştirebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olan ve erişilebilir bir dış çalışma kitabına bağlı bir grafik kullanır. İlk serideki ilk veri noktasının hücre‑tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı dış XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılabilir olmayan bir dış çalışma kitabına bağlıysa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve açmadan önce [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` yapın.

Aşağıdaki C# örneği, ilk slaydın ilk şekli olan ve mevcut olmayan bir dış çalışma kitabına başvuran bir grafik için çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) ve [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişilir:

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

Dış çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; önbellek, dış çalışma kitabında sunum en son güncellendiğinden sonra yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [dış çalışma kitabına yolu](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirlerseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, PPTX dosyasında mutlak yolu saklar; bu nedenle çalışma kitabını taşımak bağlantıyı güncellemenizi gerektirebilir.

**Ağ kaynakları/paylaşımlardaki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides’dan uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar. Hücre‑tabanlı grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinali değişmeden kalmalıysa çalışma kitabının bir kopyasını kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlama sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir kopyasını (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/net/)) şifresiz hazırlayıp ona bağlamaktır.

**Birden çok grafik aynı dış çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, bu dosyayı güncellemek her grafiğin bir sonraki veri yüklemesinde yansır.