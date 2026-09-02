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

Bu makale Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerinin nasıl okunup yazılacağını, çalışma kitabı hücrelerinin grafik veri etiketi olarak nasıl kullanılacağını, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı tipinin nasıl belirtileceğini gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynakları olarak nasıl kullanılacağını kapsar. Örnekler, harici bir çalışma kitabının nasıl oluşturulup atanacağını, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, grafik verileri (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metodlarını sağlar. **Not** grafik verilerinin aynı düzenle organize edilmiş olması veya kaynağa benzer bir yapıya sahip olması gerekir.

Bu C# kodu örnek bir işlemi gösterir:

```c#
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


## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Kaydırmanın referansını indeks üzerinden alın.  
1. Bir Bubble grafiği bazı verilerle ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.  

Bu C# kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Bir sunum dosyasını temsil eden sunum sınıfının bir örneğini oluşturur

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

Bu C# kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) özelliği kullanılarak bir çalışma sayfası koleksiyonuna nasıl erişileceğini gösterir:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Veri Kaynağı Türünü Belirleme**

Bu C# kodu veri kaynağı için bir türün nasıl belirleneceğini gösterir:

```c#
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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/) üzerindeki `EmbeddedWorkbookType` özelliğini ve [WorkbookType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/workbooktype/) sayımını kullanabilirsiniz.

```csharp
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
            // Gömülü çalışma kitabı .xlsb formatındadır ve desteklenmez.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
    }
}
```

## **Harici Çalışma Kitabı**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/net/aspose-slides-for-net-19-4-release-notes/) sürümünde grafikler için veri kaynağı olarak harici çalışma kitapları desteği ekledik. 
{{% /alert %}} 

### **Harici Bir Çalışma Kitabı Oluşturma**
**`ReadWorkbookStream`** ve **`SetExternalWorkbook`** metodlarını kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da dahili bir çalışma kitabını harici hâle getirebilirsiniz.

Bu C# kodu harici çalışma kitabı oluşturma sürecini gösterir:

```c#
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


### **Harici Bir Çalışma Kitabını Ayarlama**
**`SetExternalWorkbook`** metodunu kullanarak bir harici çalışma kitabını grafiğin veri kaynağı olarak atayabilirsiniz. Bu metod ayrıca harici çalışma kitabının yolunu (eğer taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Harici çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu C# kodu harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

```c#
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

`SetExternalWorkbook` metodunun altındaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirlemek için kullanılır. 

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayar, hedef çalışma kitabı mevcut değilse veya erişilemezse kullanılabilir.  
* `ChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Kaydırmanın referansını indeks üzerinden alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) kaynak tipine bir nesne oluşturun.  
1. Kaynak tipi harici çalışma kitabı veri kaynağı tipiyle aynı olduğunda ilgili koşulu belirtin.  

Bu C# kodu işlemi gösterir:

```c#
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

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, dahili çalışma kitaplarındaki içeriklerde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu C# kodu tanımlanan sürecin bir uygulamasıdır:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya erişilemez bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/spreadsheetoptions/) yapılandırın ve sunumu açmadan önce [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) özelliğini `true` olarak ayarlayın.

Aşağıdaki C# örneği, grafiklerinin erişilemez bir harici çalışma kitabına referans verdiği bir sunumu açar ve kurtarılan verilere [IChart.ChartData](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/chartdata/) ve [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/chartdataworkbook/) aracılığıyla erişir:

```csharp
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

// Read or modify the recovered workbook data here.
```

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir `InvalidOperationException` fırlatır. Önbellekten kurtarma yalnızca önbellekteki grafik verilerinin kullanılmasının kabul edilebilir bir geri dönüş olduğu durumlarda etkinleştirilmelidir; çünkü önbellek, sunumun son güncellemesinden sonraki harici çalışma kitabı değişikliklerini içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/datasourcetype/) ve [path to an external workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) vardır; kaynak harici bir çalışma kitabı ise tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği açısından avantaj sağlar; ancak sunum, PPTX dosyasında mutlak yolu depolar.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak uzak çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez; sadece veri kaynağı olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, harici dosyaya bir [link](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/externalworkbookpath/) saklar ve veri okuma amacıyla bu bağlantıyı kullanır. Sunum kaydedildiğinde harici dosya değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya (örneğin [Aspose.Cells](/cells/net/) ile) hazırlayıp o kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan bir güncelleme bir sonraki veri yüklemede her grafiğe yansır.