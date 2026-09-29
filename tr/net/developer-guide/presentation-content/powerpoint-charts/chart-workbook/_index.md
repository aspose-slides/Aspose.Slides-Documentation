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
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitap akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yollarını gösterir.

Ayrıca grafik veri kaynakları olarak harici çalışma kitaplarıyla çalışmayı da kapsar. Örnekler, bir harici çalışma kitabı oluşturup atamanın, bir grafikle ilişkilendirilmiş harici çalışma kitabı yolunu almanın ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemenin nasıl yapılacağını göstermektedir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının satır grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol etmek için [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) kullanın. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez ya da göstertmez.

İndirilen [hidden-source-data.pptx](hidden-source-data.pptx) dosyasını çalışma dizinine koyun. İlk slaytı, ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını içerir: `A1:C4`. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/chartdataworkbook/) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.IsHidden](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/ishidden/) okuyun. Bu özellik yalnızca okunabilir. Bu dosyada, B2 görünür, B3 gizli satıra, C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/readworkbookstream/) ile koruyun ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisi de dahil olmak üzere tam aralığı geri yüklemek için [SetRange](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/setrange/) kullanın. Bayrağı sadece değiştirmek, bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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
            // Gizli kategoriler dahil tam kaynak aralığını geri yükleyin.
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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren `hidden_cells_True.pptx` ve bütün altı değeri içeren `hidden_cells_False.pptx` dosyalarını kaydeder. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanmış çizim ayarını korur. Satır 3 ve sütun C, her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/displayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verilerini içermez ya da dışlamaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/net/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for .NET, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini) okumanıza ve yazmanıza izin veren [ReadWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sunar. **Not** grafik verilerinin aynı şekilde düzenlenmiş olması ya da kaynağa benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü çalışma kitabını bir akışa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değiştirilmeden Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir çalışma kitabı ile değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.ValidateChartLayout](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/validatechartlayout/) yönteminin indeks dışı hatası vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `chart.pptx` dosyasını gerektirir. Yorum, çalışma kitabı düzenlemesinin nerede yapılacağını işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

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

    // Burada, örneğin Aspose.Cells kullanarak, çalışma kitabı akışını değiştirin.

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

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Grafiği kullanmadan önce güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz. Aşağıdaki adımlar, bir balon grafikindeki etiketleri veri çalışma kitabındaki hücrelere nasıl bağlayacağınızı gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayta sıfır tabanlı indeksiyle erişin.
3. Varsayılan veriyle bir balon grafik ekleyin.
4. Grafik serisine erişin.
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
6. Sunumu kaydedin.

Bu örnek, en az bir slayt içeren `chart2.pptx` dosyasını açar ve varsayılan veriyle bir balon grafik ekler. Çalışma sayfası 0'da A10:A12 hücrelerini ilk serideki ilk üç etiket için kullanır, hücrelerden etiketleri etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve her bir çalışma sayfasının adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirleme**

Bu örnek, varsayılan veriyle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti kullanır; ikincisi çalışma sayfası 0'da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/datasourcetype/) enumarasyonu, her bir ad için kaynağı seçer. Sonuç `pres.pptx` olarak kaydedilir.

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları tespit etmek ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/) üzerindeki [EmbeddedWorkbookType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) özelliğini, [WorkbookType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/workbooktype/) enumarasyonu ile birlikte kullanabilirsiniz. Bu örnek, `sample.pptx` dosyasının ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve gömülü .xlsb çalışma kitabına sahip her grafik için bir tanı mesajı yazdırır.

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

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Bir Çalışma Kitabı Oluşturma**

Gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarmak ve grafiği bu harici çalışma kitabına bağlamak için [ReadWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanın.

Bu örnek, varsayılan veriyle bir pasta grafik oluşturur, çalışma kitabını `externalWorkbook1.xlsx` dosyasına yazar ve dosyayı grafik veri kaynağı olarak atamadan önce çıktıyı kapatır. Bağlantılı sunumu `externalWorkbook.pptx` olarak kaydeder.

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

### **Harici Bir Çalışma Kitabı Ayarlama**

[SetExternalWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemiyle, bir harici çalışma kitabını grafik veri kaynağı olarak atayabilirsiniz. Bu yöntem ayrıca harici çalışma kitabının yolunu güncellemek için de kullanılabilir (eğer çalışma kitabı taşınmışsa).

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemesiniz de, bu tür çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` dosyasını gerektirir. `Sheet1` adlı çalışma sayfası B1'de bir seri adı, A2:A4'te kategori adları ve B2:B4'te sayısal değerler içermelidir. Örnek bir pasta grafik oluşturur, çalışma kitabını bağlar ve A1:B4'ü bir seri ve üç kategoriye eşlemek için [SetRange](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/setrange/) kullanır. Sonucu `Presentation_with_externalWorkbook.pptx` olarak kaydeder.

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

[SetExternalWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/setexternalworkbook/) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` değeri `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verilerini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

Bir grafikle ilişkilendirilmiş çalışma kitabını belirlemek için, önce grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek çalışma kitabı yolunu alabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayta sıfır tabanlı indeksiyle erişin.
3. İlk şeklin bir grafik olduğunu kontrol edin.
4. Grafik veri kaynağı türünü okuyun.
5. Kaynak bir harici çalışma kitabı ise, yolunu okuyun.

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slaydın ilk şekline bakar. Eğer bu şekil bir harici çalışma kitabına bağlanmış bir grafik ise, örnek [ExternalWorkbookPath](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/externalworkbookpath/) değerini konsola yazar. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğini değiştirmeniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse, bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik içeren `presentation.pptx` ve erişilebilir bir harici çalışma kitabı gerektirir. İlk serideki ilk veri noktasının hücre temelli değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek, bağlantılı harici XLSX dosyasını güncelleyebilir; bu nedenle orijinalin değişmemesi gerekiyorsa bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabı Kurtarma**

Bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış veriden grafik çalışma kitabını yeniden oluşturabilir. Sunumu açmadan önce [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) oluşturun, onun [SpreadsheetOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` olarak ayarlayın.

Aşağıdaki C# örneği, ilk slaydın ilk şekli olarak mevcut olmayan bir harici çalışma kitabına başvuran bir grafik içeren `presentation.pptx` dosyasını açar ve kurtarılan verilere [IChart.ChartData](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/chartdata/) ve [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/chartdataworkbook/) aracılığıyla erişir:

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

Harici çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) fırlatır. Önbelleğe alınmış grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise kurtarmayı etkinleştirin; çünkü önbellek, sunumun son güncellenmesinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak bir harici çalışma kitabı ise, harici bir dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde, otomatik olarak mutlak bir yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar, bu yüzden çalışma kitabını taşımak bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici bir veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides'dan düzenlemek desteklenmez—sadece bir kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, [link to the external file](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) kaydeder. Hücre temelli grafik verilerini düzenlemek, bağlanmış yerel XLSX dosyasını da güncelleyebilir. Orijinalin değişmemesi gerekiyorsa, çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında bir şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da çözümlenmiş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/net/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafik de yansıtılacaktır.