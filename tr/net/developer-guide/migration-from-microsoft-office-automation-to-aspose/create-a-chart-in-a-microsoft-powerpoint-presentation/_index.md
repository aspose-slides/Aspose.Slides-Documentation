---
title: VSTO ve Aspose.Slides for .NET Kullanarak Grafik Oluşturma
linktitle: Grafik Oluştur
type: docs
weight: 80
url: /tr/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- grafik oluştur
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "C# ile PowerPoint grafik oluşturmayı nasıl otomatikleştireceğinizi öğrenin. Bu adım adım kılavuz, Aspose.Slides for .NET'in Microsoft.Office.Interop'e göre daha hızlı ve daha güçlü bir alternatif olduğunu gösterir."
---
## **Genel Bakış**

Bu makale, C# kullanarak Microsoft PowerPoint sunumlarında grafiklerin programlı olarak oluşturulmasını ve özelleştirilmesini göstermektedir. Aspose.Slides for .NET ile Microsoft Office veya Interop kütüphanelerine bağımlı olmadan profesyonel, veri odaklı grafiklerin otomatik olarak oluşturulmasını sağlayabilirsiniz. API, sütun grafikler, pasta grafikler, çizgi grafikler ve daha fazlasını oluşturmak için zengin bir özellik seti sunar — görünüm, veri ve düzen üzerinde tam kontrol sağlar. Raporlar, gösterge tabloları veya iş sunumları oluşturuyor olun, Aspose.Slides .NET uygulamalarınızdan doğrudan yüksek kaliteli görselleştirmeler sunmanıza yardımcı olur.

## **VSTO Örneği**

Bu bölüm, **VSTO (Visual Studio Tools for Office)** kullanarak bir Microsoft PowerPoint sunumunda grafik oluşturmayı göstermektedir. VSTO ile PowerPoint ve Excel otomasyonunu birleştirerek programlı bir şekilde grafikler oluşturabilir ve özelleştirebilirsiniz. Verilen örnek, **3D clustered column chart** eklemeyi, verileri bir Excel çalışma sayfasından doldurmayı, biçimlendirme ve düzeni ayarlamayı ve nihai sunumu kaydetmeyi — tüm bunları bir .NET uygulaması içinde gösterir.

1. Microsoft PowerPoint sunumunun bir örneğini oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. 3D clustered column chart ekleyin ve ona erişin.
1. Yeni bir Microsoft Excel çalışma kitabı örneği oluşturun ve grafik verilerini yükleyin.
1. Excel çalışma kitabı örneğini kullanarak grafik veri çalışma sayfasına erişin.
1. Çalışma sayfasındaki grafik aralığını ayarlayın ve grafikten 2. ve 3. serileri kaldırın.
1. Grafik veri çalışma sayfasında grafik kategori verilerini değiştirin.
1. Grafik veri çalışma sayfasında 1. serinin verilerini değiştirin.
1. Grafik başlığına erişin ve yazı tipi ile ilgili özelliklerini ayarlayın.
1. Grafiğin değer eksenine erişin ve ana birim, yan birim, maksimum değer ve minimum değeri ayarlayın.
1. Grafiğin derinlik (seri) eksenine erişin ve kaldırın — bu örnekte yalnızca bir seri kullanılmıştır.
1. Grafiğin X ve Y yönlerindeki dönüş açılarını ayarlayın.
1. Sunumu kaydedin.
1. Microsoft Excel ve PowerPoint örneklerini kapatın.

```c#
EnsurePowerPointIsRunning(true, true);

// Bir slayt nesnesi oluştur.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// İlk sunum slaydına eriş.
objSlide = objPres.Slides[1];

// İlk slaytı seç ve düzenini ayarla.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Slayta varsayılan bir grafik ekle.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Eklenen grafige eriş.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Grafik verisine eriş.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Grafik verisiyle çalışmak için bir Excel çalışma kitabı örneği oluştur.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Grafik için veri çalışma sayfasına eriş.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Grafik için veri aralığını ayarla.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Belirtilen aralığı grafik veri tablosuna uygula.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Kategoriler ve ilgili seri verileri için değerleri ayarla.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Grafik başlığını ayarla.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Grafik değer eksenine eriş.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Eksen birimleri için değerleri ayarla.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Grafik derinlik eksenine eriş.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Grafik dönüşünü ayarla.
ppChart.Rotation = 20;   // Y-Değeri
ppChart.Elevation = 15;  // X-Değeri
ppChart.RightAngleAxes = false;

// Sunumu PPTX dosyası olarak kaydet.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Çalışma kitabını ve sunumu kapat.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Name özelliğine erişmeye çalış. Eğer bir istisna fırlatırsa, yeni bir PowerPoint örneği başlat.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation, bir sunumun yüklendiğinden emin olmak için kullanılır.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide, sunumda en az bir slayt olduğundan emin olmak için kullanılır.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Sonuç:

![VSTO kullanılarak oluşturulan grafik](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET Örneği**

Aşağıdaki örnek, Aspose.Slides for .NET kullanarak bir PowerPoint sunumunda basit bir grafik oluşturmanın nasıl yapılacağını göstermektedir. Bu kod, **3D clustered column chart** eklemeyi, örnek verilerle doldurmayı ve görünümünü özelleştirmeyi gösterir. Sadece birkaç satır kodla, grafikleri dinamik olarak oluşturabilir ve Microsoft Office kullanmadan sunumlarınıza entegre edebilirsiniz.

1. [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta bir referans alın.
1. 3D clustered column chart ekleyin ve ona erişin.
1. Grafik verilerine erişin.
1. Kullanılmayan Series 2 ve Series 3'ü kaldırın.
1. Etiketleri güncelleyerek grafik kategorilerini değiştirin.
1. Series 1 değerlerini güncelleyin.
1. Grafik başlığına erişin ve yazı tipi özelliklerini ayarlayın.
1. Grafiğin değer eksenini yapılandırın; ana birim, yan birim, maksimum ve minimum değerler dahil.
1. X ve Y eksenlerindeki grafik dönüş açılarını ayarlayın.
1. Sunumu PPTX formatında kaydedin.

```cs
// Boş bir sunum oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    // Varsayılan bir grafik ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Grafik verisini al.
    IChartData chartData = chart.ChartData;

    // Fazladan varsayılan seriyi kaldır.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Grafik kategori adlarını değiştir.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Grafik veri çalışma sayfasının indeksini ayarla.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını al.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Grafik seri değerlerini değiştir.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Grafik başlığını ayarla.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Eksen seçeneklerini ayarla.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Grafik dönüşünü ayarla.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Sunumu PPTX dosyası olarak kaydet.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Aspose.Slides for .NET kullanılarak oluşturulan grafik](chart-created-using-aspose-slides.png)

## **SSS**

**Aspose.Slides ile pasta, çizgi veya çubuk gibi diğer grafik türlerini oluşturabilir miyim?**

Evet. Aspose.Slides for .NET, pasta grafikleri, çizgi grafikleri, çubuk grafikleri, dağılım grafikleri, balon grafikleri ve daha fazlasını içeren geniş bir [chart types](/slides/tr/net/create-chart/) yelpazesini destekler. Bir grafik eklerken istediğiniz grafik türünü [ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) sayımını kullanarak belirtebilirsiniz.

**Grafiğe özel stiller veya temalar uygulayabilir miyim?**

Evet. Grafiğin görünümünü renkler, yazı tipleri, doldurmalar, hatlar, ızgara çizgileri ve düzen dahil olmak üzere tamamen özelleştirebilirsiniz. Ancak, PowerPoint'te görülen Office temalarını tam olarak uygulamak, bireysel stilleri manuel olarak ayarlamayı gerektirir.

**Grafiği slayttan ayrı bir görüntü olarak dışa aktarabilir miyim?**

Evet, Aspose.Slides, grafikler dahil herhangi bir şekli `GetImage` yöntemiyle ayrı bir görüntü (ör. PNG, JPEG) olarak dışa aktarmanıza olanak tanır.