---
title: PowerPoint Sunum Grafiklerini .NET'te Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/net/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağılım grafik
- pasta grafik
- çizgi grafik
- ağaç harita grafik
- hisse senedi grafik
- kutu ve bıyık grafik
- huni grafik
- güneş patlaması grafik
- histogram grafik
- radar grafik
- çok kategorili grafik
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Grafikleri ekleyin, biçimlendirin ve C#'ta pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir grafik eklemeyi, verileri doldurmayı ve belirli tasarım gereksinimlerinize uygun biçimlendirme seçeneklerini uygulamayı programlı olarak öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve lejandları yapılandırmaya kadar her adımı detaylı kod örnekleriyle gösterir. Bu rehberi izleyerek, .NET uygulamalarınıza dinamik grafik oluşturmayı entegre etme ve veri odaklı sunumlar oluşturma sürecini kolaylaştırma konusunda sağlam bir anlayış kazanacaksınız.

## **Grafik Oluşturma**

Grafikler, insanların verileri hızlı bir şekilde görselleştirmesine ve bir tablo veya elektronik tabloyla hemen fark edilemeyen içgörüler elde etmesine yardımcı olur.

**Grafik Oluşturmanın Nedenleri?**

Grafikler kullanarak şunları yapabilirsiniz:

* büyük miktardaki veriyi tek bir slaytta birleştirebilir, özetleyebilir veya yoğunlaştırabilirsiniz;
* veri içindeki kalıpları ve eğilimleri ortaya çıkarabilirsiniz;
* zaman içinde ya da belirli bir ölçüm birimiyle veri yönünü ve ivmesini çıkarabilirsiniz;
* aykırı değerleri, sapmaları, hataları ve anlamsız verileri fark edebilirsiniz;
* karmaşık verileri iletişim kurabilir veya sunabilirsiniz.

PowerPoint’te *Insert* işleviyle birçok grafik türü için şablonlar sunan grafikler oluşturabilirsiniz. Aspose.Slides kullanarak hem popüler grafik türlerine dayalı normal grafikler hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" %}} 
ChartType sayımını [Aspose.Slides.Charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/) ad alanı altında kullanın. Bu sayımdaki değerler farklı grafik türlerine karşılık gelir. 
{{% /alert %}} 

### **Küme Sütun Grafiklerini Oluşturma**

Bu bölüm, Aspose.Slides for .NET ile küme sütun grafiği oluşturmayı açıklar. Sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir küme sütun grafiğinin nasıl oluşturulduğunu görebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bazı veriyle bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.  
1. Grafik için bir başlık ekleyin.  
1. Grafiğin veri çalışma sayfasına erişin.  
1. Varsayılan tüm serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Grafik serilerine dolgu rengi uygulayın.  
1. Grafik serilerine etiketler ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir küme sütun grafiğinin nasıl oluşturulacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verileriyle bir küme sütun grafiği ekleyin.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Grafik başlığını ayarlayın.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Grafik veri sayfasının dizinini ayarlayın.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını alın.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan oluşturulan serileri ve kategorileri silin.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Yeni seriler ekleyin.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Yeni kategoriler ekleyin.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // İlk grafik serisini alın.
    IChartSeries series = chart.ChartData.Series[0];

    // Seri verilerini doldurun.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Serinin dolgu rengini ayarlayın.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // İkinci grafik serisini alın.
    series = chart.ChartData.Series[1];

    // Seri verilerini doldurun.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Serinin dolgu rengini ayarlayın.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // İlk etiketi kategori adını gösterecek şekilde ayarlayın.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Seriyi üçüncü etiket için değeri gösterecek şekilde ayarlayın.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Sunumu diske PPTX dosyası olarak kaydedin.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Küme Sütun Grafiği](clustered_column_chart.png)

### **Dağılım Grafiklerini Oluşturma**

Dağılım grafikleri (scatter plot veya x‑y grafiği olarak da bilinir) genellikle iki değişken arasındaki kalıpları kontrol etmek veya korelasyonları göstermek için kullanılır.

Aşağıdaki durumlarda dağılım grafiği kullanın:

* eşleştirilmiş sayısal verileriniz olduğunda;  
* iki değişken birlikte iyi eşleştiğinde;  
* iki değişkenin ilişkili olup olmadığını belirlemek istediğinizde;  
* bağımsız bir değişkenin bağımlı bir değişken için birden fazla değeri olduğunda.  

Bu C# kodu, farklı işaretçi serileriyle bir dağılım grafiği oluşturmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    // Varsayılan dağılım grafiğini oluşturun.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Grafik veri sayfasının dizinini ayarlayın.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını alın.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan seriyi silin.
    chart.ChartData.Series.Clear();

    // Yeni seriler ekleyin.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // İlk grafik serisini alın.
    IChartSeries series = chart.ChartData.Series[0];

    // Seriye yeni bir nokta (1:3) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Yeni bir nokta (2:10) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Seri tipini değiştirin.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Grafik serisi işaretçisini değiştirin.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // İkinci grafik serisini alın.
    series = chart.ChartData.Series[1];

    // Seriye yeni bir nokta (5:2) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Yeni bir nokta (3:1) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Yeni bir nokta (2:2) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Yeni bir nokta (5:1) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Grafik serisi işaretçisini değiştirin.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Sunumu diske PPTX dosyası olarak kaydedin.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Dağılım Grafiği](scatter_chart.png)

### **Pasta Grafiklerini Oluşturma**

Pasta grafikleri, özellikle kategorik etiketlerle sayısal değerlerin bulunduğu verilerde, parçanın bütüne oranını göstermek için en uygunudur. Ancak veriniz çok sayıda parça veya etiket içeriyorsa, çubuk grafiği tercih edebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.Pie` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Pasta grafik dilimlerine özel renkler uygulayın.  
1. Seriler için etiketler ayarlayın.  
1. Seri etiketleri için lider çizgileri etkinleştirin.  
1. Pasta grafiğinin dönüş açısını ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir pasta grafiğinin nasıl oluşturulacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verileriyle bir grafik ekleyin.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Grafik başlığını ayarlayın.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // İlk seriyi değerleri gösterecek şekilde ayarlayın.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Grafik veri sayfasının dizinini ayarlayın.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını alın.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan oluşturulan serileri ve kategorileri silin.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Yeni kategoriler ekleyin.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Yeni seriler ekleyin.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Seri verilerini doldurun.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Dilimin rengini ayarlayın.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Dilim kenarlığını ayarlayın.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Dilim kenarlığını ayarlayın.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Dilim kenarlığını ayarlayın.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Yeni serideki her kategori için özel etiketler oluşturun.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Seriyi grafik için lider çizgileri gösterecek şekilde ayarlayın.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Pasta grafik dilimlerinin dönüş açısını ayarlayın.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Sunumu diske PPTX dosyası olarak kaydedin.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Pasta Grafiği](pie_chart.png)

### **Çizgi Grafiklerini Oluşturma**

Çizgi grafikler (line graph) zaman içinde değer değişimlerini göstermek istediğiniz durumlar için en uygunudur. Çizgi grafiği kullanarak büyük miktarda veriyi aynı anda karşılaştırabilir, zaman içindeki değişim ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.Line` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir çizgi grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Varsayılan olarak, çizgi grafiğindeki noktalar kesintisiz düz çizgilerle birleştirilir. Noktaların tireli çizgilerle birleştirilmesini istiyorsanız, tercih ettiğiniz tire tipini aşağıdaki gibi belirtebilirsiniz:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Sonuç:

![Çizgi Grafiği](line_chart.png)

### **Ağaç Haritası Grafiklerini Oluşturma**

Ağaç haritası grafikler, satış verileri gibi kategorilerin göreli boyutlarını göstermek ve her kategori içinde büyük katkıda bulunan öğelere dikkat çekmek için en uygundur.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.Treemap` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir ağaç haritası grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Şube 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Şube 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Ağaç Haritası Grafiği](treemap_chart.png)

### **Hisse Senedi Grafiklerini Oluşturma**

Hisse senedi grafikler, açılış, yüksek, düşük ve kapanış fiyatları gibi finansal verileri göstererek piyasa eğilimlerini ve dalgalanmaları analiz etmeye yardımcı olur. Yatırımcılara ve analistlere, hisse performansı hakkında kritik içgörüler sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.OpenHighLowClose` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. HiLowLines biçimini belirtin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir hisse senedi grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Hisse Senedi Grafiği](stock_chart.png)

### **Kutu ve Bıyık Grafiklerini Oluşturma**

Kutu ve bıyık grafikler, medyan, çeyrekler ve olası aykırı değerler gibi temel istatistiksel ölçümleri özetleyerek veri dağılımını gösterir. Keşifsel veri analizi ve istatistiksel çalışmalar için veri değişkenliğini hızlıca anlamak ve anormallikleri tanımlamak açısından çok yararlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.BoxAndWhisker` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir kutu ve bıyık grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Huni Grafiklerini Oluşturma**

Huni grafikler, bir sürecin ardışık aşamalarını görselleştirir; veri hacmi bir adımdan bir sonraki adıma geçerken azalır. Dönüşüm oranlarını analiz etmek, darboğazları tespit etmek ve satış ya da pazarlama süreçlerinin verimliliğini izlemek için özellikle faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.Funnel` türünü belirtin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir huni grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Huni Grafiği](funnel_chart.png)

### **Güneş Patlaması Grafiklerini Oluşturma**

Güneş patlaması grafikler, hiyerarşik verileri dairesel halkalar halinde görselleştirir. Parçanın bütüne oranını göstermek ve iç içe geçmiş kategorileri kompakt bir biçimde temsil etmek için idealdir.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.Sunburst` türünü belirtin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir güneş patlaması grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Şube 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Şube 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Güneş Patlaması Grafiği](sunburst_chart.png)

### **Histogram Grafiklerini Oluşturma**

Histogram grafikler, sayısal verilerin dağılımını belirli aralıklara (bin) ayırarak gösterir. Veri frekansı, çarpıklık ve yayılım gibi kalıpları tanımlamak ve veri setindeki aykırı değerleri tespit etmek için özellikle yararlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bazı veriyle bir grafik ekleyin ve `ChartType.Histogram` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir histogram grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Histogram Grafiği](histogram_chart.png)

### **Radar Grafiklerini Oluşturma**

Radar grafikler, çok değişkenli verileri iki boyutlu bir formatta göstererek birden fazla değişkeni aynı anda karşılaştırmayı kolaylaştırır. Performans ölçütleri ya da nitelikler arasındaki güçlü ve zayıf yönleri ve kalıpları belirlemede özellikle etkilidir.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bazı veriyle bir grafik ekleyin ve `ChartType.Radar` türünü belirtin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir radar grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Radar Grafiği](radar_chart.png)

### **Çok Kategorili Grafikler Oluşturma**

Çok kategorili grafikler, birden fazla kategori grubu içeren verileri aynı anda birden çok boyutta karşılaştırmak için kullanılır. Karmaşık, çok katmanlı veri setlerinde eğilimleri ve ilişkileri analiz etmeniz gerektiğinde özellikle faydalıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan veriyle bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.  
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir çok kategori grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Bir seri ekleyin.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Grafikli sunumu kaydedin.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Çok Kategori Grafiği](multi_category_chart.png)

### **Harita Grafiklerini Oluşturma**

Harita grafikler, ülkeler, eyaletler veya şehirler gibi belirli konumlara bilgi eşleştirerek coğrafi verileri görselleştirir. Bölgesel eğilimleri, demografik verileri ve mekansal dağılımları net ve görsel olarak çekici bir şekilde analiz etmek için idealdir.

Bu C# kodu, bir harita grafiğinin nasıl oluşturulacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Harita Grafiği](map_chart.png)

{{% alert color="info" %}} 
Yukarıdaki resim, kaydedilen sunumun PowerPoint’te açılmış halini gösterir. Aspose.Slides harita grafiğini ve verilerini doğru olarak yazar, ancak harita grafiklerini kendisi çizmez: bir slayt harita grafiği içeriyorsa, bu slayt bir görüntüye dönüştürüldüğünde veya PDF ya da SVG’ye çevrildiğinde grafik alanı boş çıkar. Aynı slayttaki diğer şekiller etkilenmez. 
{{% /alert %}} 

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon (combo) grafiği, tek bir grafikte iki ya da daha fazla grafik türünü birleştirir. Bu grafik, iki ya da daha fazla veri seti arasındaki farklılıkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri tanımlamanıza yardımcı olur.

![Kombinasyon Grafiği](combination_chart.png)

Aşağıdaki C# kodu, PowerPoint sunumunda yukarıda gösterilen kombinasyon grafiğinin nasıl oluşturulacağını gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Grafiğin başlığını ayarlar
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Grafiğin lejandını ayarlar
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Varsayılan oluşturulan serileri ve kategorileri siler
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Yeni kategoriler ekler
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekle
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Yatay ekseni ayarlar
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Dikey ekseni ayarlar
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Dikey ana ızgara çizgileri rengini ayarlar
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // İkincil yatay ekseni ayarlar
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // İkincil dikey ekseni ayarlar
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Grafikleri Güncelleme**

Aspose.Slides for .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu özellik, sunumları dinamik içerikle güncel tutma sürecini basitleştirir ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını garanti eder.

1. Grafik içeren bir sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Tüm şekiller arasında gezerek grafiği bulun.  
1. Grafiğin veri çalışma sayfasına erişin.  
1. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.  
1. Yeni bir seri ekleyin ve verilerini doldurun.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir grafiğin nasıl güncelleneceğini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Grafik veri sayfasının dizinini ayarlayın.
            int worksheetIndex = 0;

            // Grafik veri çalışma kitabını alın.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Grafik kategori adlarını değiştir.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // İlk grafik serisini alın.
            IChartSeries series = chart.ChartData.Series[0];

            // Serinin verilerini güncelle.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Seri adını değiştiriyor.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // İkinci grafik serisini alın.
            series = chart.ChartData.Series[1];

            // Serinin verilerini güncelle.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Seri adını değiştiriyor.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Yeni bir seri ekle.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Serinin verilerini doldur.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Grafikli sunumu kaydet.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Aspose.Slides for .NET, bir çalışma sayfasındaki belirli bir veri aralığını, grafiğinizin veri kaynağı olarak tanımlamanıza esneklik sağlar. Bu, çalışma sayfanızın yalnızca bir bölümünü doğrudan grafiğe eşlemenize, grafiğin serileri ve kategorileri için hangi hücrelerin katkıda bulunacağını kontrol etmenize imkan tanır. Sonuç olarak, grafiğinizi çalışma sayfanızdaki en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilir, PowerPoint sunumlarınızın güncel ve doğru bilgi içermesini sağlayabilirsiniz.

1. Grafik içeren bir sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Tüm şekiller arasında gezerek grafiği bulun.  
1. Grafik verisine erişin ve aralığı ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir grafik için veri aralığının nasıl ayarlanacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisine otomatik olarak farklı bir varsayılan işaretçi sembolü atanır.

Bu C# kodu, bir grafik serisi işaretçisinin otomatik olarak nasıl ayarlanacağını gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Seri verilerini doldur.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Aspose.Slides for .NET hangi grafik türlerini destekliyor?**

Aspose.Slides for .NET, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturur, istenen slaytı indeksine göre alır ve ardından grafik ekleme metodunu çağırarak grafik türünü ve başlangıç verilerini belirtirsiniz. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafikte gösterilen veri nasıl güncellenir?**

Grafiğin veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyebilir ve kendi özel verilerinizi ekleyebilirsiniz. Böylece grafiği programlı olarak en son verileri yansıtacak şekilde yenileyebilirsiniz.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides for .NET kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, lejandlar ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü belirli tasarım gereksinimlerinize göre uyarlayabilirsiniz.