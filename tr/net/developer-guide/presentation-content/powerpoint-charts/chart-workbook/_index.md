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
description: "Aspose.Slides for .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi sadeleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yollarını gösterir.

Ayrıca, harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, bir harici çalışma kitabının nasıl oluşturulup atanacağını, bir grafik ile ilişkilendirilmiş harici çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verisinin nasıl düzenleneceğini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, grafik verileri (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) çalışma kitaplarını okumanıza ve yazmanıza izin veren [ReadWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sağlar. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu C# kodu bir örnek işlemi göstermektedir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Bir gömülü çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.ValidateChartLayout](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/validatechartlayout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik üzerine geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```csharp
// Çalışma kitabı akışı değiştirildikten sonra (ör. Aspose.Cells kullanarak)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Mevcut veri referanslarını temizle.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar ve `ValidateChartLayout` hatasız tamamlanır.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden slayt referansını alın.  
1. Bazı verilerle bir Bubble (Balon) grafiği ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.

Bu C# kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleştirir

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Çalışma Sayfalarını Yönetme**

Bu C# kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) özelliği kullanılarak bir çalışma sayfası koleksiyonuna erişilen bir işlemi gösterir:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Veri Kaynağı Türünü Belirleme**

Bu C# kodu, bir veri kaynağı için tür nasıl belirleneceğini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/) üzerindeki `EmbeddedWorkbookType` özelliği ile [WorkbookType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/workbooktype/) enum değerini birlikte kullanabilirsiniz.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya düzenleyebilirsiniz.
    }
}
```

## **Harici Çalışma Kitabı**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/net/aspose-slides-for-net-19-4-release-notes/) sürümünde, grafikler için veri kaynağı olarak harici çalışma kitapları desteği ekledik.
{{% /alert %}} 

### **Harici Çalışma Kitabı Oluşturma**
**`ReadWorkbookStream`** ve **`SetExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da içsel bir çalışma kitabını harici hâle getirebilirsiniz.

Bu C# kodu, harici çalışma kitabı oluşturma sürecini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Harici Çalışma Kitabını Ayarlama**
**`SetExternalWorkbook`** yöntemiyle bir harici çalışma kitabını grafiğin veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda (harici çalışma kitabı taşındıysa) yol güncellemesi için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak yine de kullanabilirsiniz. Bir harici çalışma kitabı için göreceli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu C# kodu, harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Belgeler dizininin yolu.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

`SetExternalWorkbook` yöntemi altındaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır. 

* `ChartData` değeri **false** olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayar, hedef çalışma kitabı mevcut değilse veya erişilemezse tercih edilebilir.  
* `ChartData` değeri **true** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeks üzerinden slayt referansını alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) kaynak nesnesini oluşturun.  
1. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olması durumuna göre ilgili koşulu belirtin.

Bu C# kodu, işlemi göstermektedir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Sunumu kaydeder
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Grafik Verisini Düzenleme**

Harici çalışma kitaplarındaki veriyi, içsel çalışma kitaplarındaki gibi düzenleyebilirsiniz. Bir harici çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu C# kodu, açıklanan sürecin bir uygulamasıdır:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Grafikten Çalışma Kitabını Önbellekten Kurtarma**

Bir grafik, eksik veya kullanılabilir olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbellekte tutulan veriden grafik çalışma kitabını yeniden oluşturabilir. **LoadOptions** oluşturun, **SpreadsheetOptions** yapılandırın ve **ISpreadsheetOptions.RecoverWorkbookFromChartCache** özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki C# örneği, kullanılabilir olmayan bir harici çalışma kitabına başvuran bir sunumu açar ve kurtarılan verilere **IChart.ChartData** ve **IChartData.ChartDataWorkbook** üzerinden erişir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Kurtarılan çalışma kitabı verilerini burada okuyabilir veya değiştirebilirsiniz.
```

Harici çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir `InvalidOperationException` fırlatır. Önbellekten kurtarma yalnızca önbellekteki grafik verisinin kabul edilebilir bir geri dönüş olduğu durumlarda etkinleştirilmelidir; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**  
Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) ve bir [external workbook path](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu, nasıl depolanıyor?**  
Evet. Göreceli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunum, PPTX dosyasında mutlak yolu saklar.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**  
Hayır. Sunum, dış dosyaya bir [link](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar ve veri okuma için bu linki kullanır. Sunum kaydedildiğinde harici dosya değişmez.

**Harici dosya şifreli ise ne yapmalıyım?**  
Aspose.Slides bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak veya şifresiz bir kopya (örneğin, [Aspose.Cells](/cells/net/) kullanarak) hazırlayıp ona bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**  
Evet. Her grafik kendi linkini saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafiğe yansır.