---
title: ".NET'te Sunumlarda Grafik Çalışma Kitaplarını Yönetme"
linktitle: "Grafik Çalışma Kitabı"
type: docs
weight: 70
url: /tr/net/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verileri
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
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını kolayca yönetin ve sunum verilerinizi basitleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazabileceğinizi, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanabileceğinizi, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirtileceğini gösterir.

Ayrıca grafik veri kaynakları olarak harici çalışma kitaplarıyla çalışma konusunu da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafiğe bağlı harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki fark ve mevcut görüntüleme modlarının bir çizgi grafik karşılaştırması için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[İChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) özelliğini kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `true`, görünür ve gizli hücreleri birlikte dahil etmek için `false` olarak ayarlayın. Bu ayar grafiğin çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez ya da göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma Sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [İChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişin ve [İChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) özelliğini okuyarak gizli durumlarını inceleyin. Bu özellik yalnızca okuma içindir. Bu dosyada B2 görünür, B3 gizli satıra, C2 ise gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için çizim ayarını değiştirdikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ile koruyun ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için ayrıca [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) kullanın. Sadece işareti değiştirmek bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm olmak üzere iki sunum kaydeder. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanmış çizim ayarını korur. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Sadece görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Sadece görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içerən gizli bir hücre, boş bir hücreden farklıdır. [İChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verileri dahil etmez veya hariç tutmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Grafiğin Veri Aralığını Al**

Var olan bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek için kaynak aralıklarını inceleyin. [İChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) yöntemi, mevcut veri aralığını `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar (dahil) hücreleri belirtir. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik, veri kaynağı olarak bir çalışma kitabı kullanmıyorsa, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) hatası fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını belirler. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafik ile devam eder.

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

## **Bir Çalışma Kitabından Grafik Verisini Oku ve Yaz**

Aspose.Slides for .NET, grafik verisi çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okuyup yazmanıza izin veren [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sağlar. **Not** grafik verisinin aynı biçimde düzenlenmiş veya kaynağa benzer bir yapıya sahip olması gerekir.

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

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [İChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) çağrısının indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellekte doğrular.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve grafiği kullanın.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verilerle bir balon grafik ekler. Çalışma sayfası 0’da A10:A12 aralığını ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

## **Çalışma Sayfalarını Yönet**

[İChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirle**

Bu örnek, varsayılan verilerle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti kullanırken, ikincisi çalışma sayfası 0’da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [İChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) üzerindeki [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) özelliğini, [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) enumu ile birlikte kullanarak desteklenmeyen biçimleri tespit edebilir ve o grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaytındaki şekilleri inceler, grafik olmayanları atlar ve gömülü bir .xlsb çalışma kitabı içeren her grafik için tanılayıcı bir mesaj yazar.

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

Aspose.Slides, harici çalışma kitaplarını grafik veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluştur**

[Gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarmak ve grafiği bu harici çalışma kitabına bağlamak] için [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanın.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dışa aktarılan akışı kapatır, harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlanmış sunumu kaydeder.

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

### **Harici Çalışma Kitabı Ayarla**

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemini kullanarak bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının konumu (dosya taşınmışsa) güncellenmek istendiğinde de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri doğrudan düzenlenemez, ancak bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlanmış grafikle sunumu kaydeder.

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

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verilerini korur ve kullanılabilir olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğe bağlı çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bir harici çalışma kitabına bağlanmış bir sunumun ilk slaytındaki ilk şekli inceler. Grafik dışa bağlanmış bir çalışma kitabına sahipse, [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) değerini konsola yazar. Ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verisini Düzenle**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanmıştır. İlk serinin ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanmış harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabına bağlıysa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve sunumu açmadan önce [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` olarak ayarlayın.

Aşağıdaki C# örneği, ilk slayttaki ilk şekil olarak bir grafik için, kullanılamayan bir harici çalışma kitabına referans veren durumlarda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [İChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) ve [İChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişilir:

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

Harici çalışma kitabı kullanılamıyorsa ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Öncelikle önbellekten grafik verisini kullanmanın kabul edilebilir bir geri dönüş olduğunu düşündüğünüzde kurtarmayı etkinleştirin; önbellek, sunum son güncellendiğinden bu yana harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [harici çalışma kitabının yolu](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak harici bir dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak tam yola dönüştürülür. Sunum, tam yolu PPTX dosyasında saklar; bu yüzden çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar. Hücre tabanlı grafik verisini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalin değişmemesi gerekiyorsa, çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresi çözülmüş bir kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/net/)) hazırlamak ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyadaki bir güncelleme her grafiğin bir sonraki veri yüklemesinde yansıtılır.