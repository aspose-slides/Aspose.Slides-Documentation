---
title: Sunumlarda .NET ile Grafik Veri Serilerini Yönetme
linktitle: Veri Serisi
type: docs
url: /tr/net/chart-series/
keywords:
- grafik serisi
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için C#'ta grafik serilerini nasıl yöneteceğinizi, pratik kod örnekleri ve en iyi uygulamalarla veri sunumlarınızı geliştirecek şekilde öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET içinde [ChartSeries](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartseries/) rolünü, verilerin sunumlarda nasıl yapılandırıldığına ve görselleştirildiğine odaklanarak açıklar. Bu nesneler, bir grafikte tek tek veri noktası, kategori ve görünüm parametrelerini tanımlayan temel öğeleri sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartseries/) ile çalışarak geliştiriciler, temel veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl gösterileceği üzerinde tam kontrol sağlayabilir, böylece içgörü ve analizleri net bir şekilde ileten dinamik, veri odaklı sunumlar oluşturabilir.

Bir seri, bir grafikte çizilen sayıların satır veya sütunudur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

Bu [IChartSeriesOverlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/properties/overlap) özelliği, çubukların ve sütunların -100 ile 100 arasında bir aralık belirterek 2D bir grafikte nasıl çakıştığını kontrol eder. Bu özellik, bireysel grafik serisi yerine seri grubuyla ilişkili olduğundan seri seviyesinde yalnızca okunur durumdadır. Çakışma değerlerini yapılandırmak için, bu gruptaki tüm serilere belirtilen çakışmayı uygulayan `ParentSeriesGroup.Overlap` okunabilir/yazılabilir özelliğini kullanın.

Aşağıda, bir sunum oluşturmayı, kümelenmiş sütun grafiği eklemeyi, ilk grafik serisine erişmeyi, çakışma ayarını yapılandırmayı ve ardından sonucu PPTX dosyası olarak kaydetmeyi gösteren bir C# örneği bulunmaktadır:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Varsayılan veriyle bir kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Serinin çakışmasını ayarla.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Sunum dosyasını diske kaydet.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Aspose.Slides, grafik serilerinin dolgu renklerini özelleştirmeyi son derece basitleştirir; böylece belirli veri noktalarını vurgulayabilir ve görsel olarak çekici grafikler oluşturabilirsiniz. Bu, çeşitli dolgu türlerini, renk yapılandırmalarını ve diğer gelişmiş stil seçeneklerini destekleyen [IFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/iformat/) nesnesi aracılığıyla gerçekleştirilir. Bir slayta grafik ekledikten ve istediğiniz seriye eriştikten sonra, bir seriyi alıp uygun dolgu rengini uygulamanız yeterlidir. Katı dolgulara ek olarak, tasarım esnekliğini artırmak için degrade veya desen dolgularını da kullanabilirsiniz. Renkleri gereksinimlerinize göre ayarladıktan sonra sunumu kaydederek güncellenmiş görünümü tamamlayın.

Aşağıdaki C# kod örneği, ilk serinin rengini nasıl değiştireceğinizi gösterir:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Varsayılan veriyle bir kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // İlk serinin rengini ayarla.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Sunum dosyasını diske kaydet.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Aspose.Slides, grafik serilerinin adlarını değiştirmek için basit bir yol sunar; bu sayede verileri açık ve anlamlı bir şekilde etiketlemek kolaylaşır. Grafik verisindeki ilgili çalışma sayfası hücresine erişerek geliştiriciler, verinin nasıl sunulacağını özelleştirebilir. Bu değişiklik, serinin adı veri bağlamına göre güncellenmesi veya netleştirilmesi gerektiğinde özellikle yararlıdır. Serinin adı değiştirildikten sonra, sunumu kaydederek değişiklikleri kalıcı hâle getirebilirsiniz.

Aşağıda bu süreci gösteren bir C# kod parçacığı bulunmaktadır:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Varsayılan veriyle bir kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // İlk serinin adını ayarla.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Sunum dosyasını diske kaydet.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Aşağıdaki C# kodu, seri adını değiştirmenin alternatif bir yolunu gösterir:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Varsayılan veriyle bir kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // İlk serinin adını ayarla.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Sunum dosyasını diske kaydet.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Seri adı](series_name.png)

## **Otomatik Seri Dolgu Rengini Alın**

Aspose.Slides for .NET, bir grafik alanı içinde seri dolgu renginin otomatik olarak alınmasını sağlar. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturduktan sonra, indeksle istediğiniz slayta referans alabilir, ardından tercih ettiğiniz tipte bir grafik ekleyebilirsiniz (ör. `ChartType.ClusteredColumn`). Grafikteki seriye erişerek otomatik dolgu rengini alabilirsiniz.

Aşağıdaki C# kodu bu süreci ayrıntılı olarak gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Varsayılan veriyle bir kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Serinin dolgu rengini al.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Çıktı:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Bir Grafik Serisi İçin Ters Dolgu Rengini Ayarlama**

Veri seriniz pozitif ve negatif değerler içeriyorsa, tüm sütunları veya çubukları aynı renkle doldurmak grafiği okunması zor hale getirebilir. Aspose.Slides for .NET, negatif değerler için otomatik olarak uygulanan ayrı bir dolgu—ters dolgu rengi—atayarak negatif değerlerin anında öne çıkmasını sağlar. Bu bölümde bu seçeneği nasıl etkinleştireceğinizi, uygun bir renk seçip güncellenmiş sunumu nasıl kaydedeceğinizi öğreneceksiniz.

Aşağıdaki kod örneği işlemi gösterir:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Yeni kategoriler ekle.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Yeni bir seri ekle.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Serinin verilerini doldur.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Serinin renk ayarlarını belirle.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Ters çevrilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Tek bir veri noktası için tüm seri yerine dolgu rengini ters çevirebilirsiniz. İlgili `IChartDataPoint` nesnesine erişip `InvertIfNegative` özelliğini **true** olarak ayarlamanız yeterlidir.

Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Veri noktasının 2. indeksindeki değer negatif ise rengi ters çevir.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Belirli Veri Noktası Değerlerini Temizleme**

Bazen bir grafikte test değerleri, aykırı noktalar veya artık kullanılmayan girdiler bulunur ve bunları tüm seriyi yeniden oluşturmak zorunda kalmadan kaldırmanız gerekir. Aspose.Slides for .NET, herhangi bir veri noktasını indeksle hedef almanıza, içeriğini temizlemenize ve kalan noktaların kaymasını, eksenlerin otomatik olarak yeniden ölçeklenmesini sağlar.

Aşağıdaki kod örneği işlemi gösterir:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana gelen sütunlar veya çubuklar arasındaki boş alan miktarını kontrol eder—daha geniş boşluklar bireysel kategorileri vurgularken, daha dar boşluklar daha yoğun ve kompakt bir görünüm yaratır. Aspose.Slides for .NET sayesinde bu parametreyi tüm seri için ince ayar yapabilir, veri setinizi değiştirmeden sunumunuzun görsel dengesini tam olarak elde edebilirsiniz.

Aşağıdaki kod örneği bir serinin boşluk genişliğini nasıl ayarlayacağını gösterir:

```cs
ushort gapWidth = 30;

// Boş bir sunum oluştur.
using (Presentation presentation = new Presentation())
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verilerle bir grafik ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Sunumu diske kaydet.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // GapWidth değerini ayarla.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Sunumu diske kaydet.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **SSS**

**Bir tek grafikte kaç seri olabileceği konusunda bir sınırlama var mı?**

Aspose.Slides, eklediğiniz seri sayısı için sabit bir üst sınır koymaz. Pratik sınırlama, grafiğin okunabilirliği ve uygulamanızın sahip olduğu bellek miktarıyla belirlenir.

**Küme içindeki sütunlar çok yaklaştıysa veya çok uzaklaştıysa ne olur?**

O serinin (veya üst seri grubunun) `GapWidth` ayarını değiştirin. Değeri artırmak sütunlar arasındaki boşluğu genişletir, azaltmak ise onları daha yakın hâle getirir.