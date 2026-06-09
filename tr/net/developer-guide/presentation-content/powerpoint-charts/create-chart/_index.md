---
title: PowerPoint Sunumu Grafiklerini .NET’te Oluşturma veya Güncelleme
linktitle: Grafiklerini Oluşturma veya Güncelleme
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
- ağaç haritası grafik
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
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında grafikler oluşturun ve özelleştirin. Grafikleri ekleyin, biçimlendirin ve C# içinde pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak grafikler oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir slayta programlı olarak grafik eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve açıklama kutularını yapılandırmaya kadar her adımı ayrıntılı kod örnekleriyle gösterilmektedir. Bu rehberi izleyerek, .NET uygulamalarınıza dinamik grafik üretimini entegre etme ve veri odaklı sunumlar oluşturma sürecini kolaylaştırma konusunda sağlam bir anlayış kazanacaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirmenize ve bir tablo ya da elektronik tablodan hemen fark edilmeyen içgörüler elde etmenize yardımcı olur.

**Grafik Oluşturmanın Nedenleri**

Grafiklerle şunları yapabilirsiniz:

* büyük miktarda veriyi tek bir slaytta özetlemek, sıkıştırmak veya derlemek;
* veri içindeki kalıpları ve eğilimleri ortaya çıkarmak;
* zaman içinde ya da belirli bir ölçü birimiyle veri yönünü ve ivmesini belirlemek;
* aykırı değerleri, sapmaları, hataları ve mantıksız verileri tespit etmek;
* karmaşık verileri iletişim kurmak veya sunmak.

PowerPoint’te, *Insert* işlevi aracılığıyla pek çok grafik türü tasarlamak için şablonlar sağlar. Aspose.Slides kullanarak hem yaygın grafik türlerine dayalı normal grafikler hem de özel grafikler oluşturabilirsiniz.

{{% alert color="primary" %}} 
[ChartType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) adlı sayım türünü, [Aspose.Slides.Charts](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/) ad alanı altında kullanın. Bu sayım türündeki değerler farklı grafik türlerine karşılık gelir.
{{% /alert %}} 

### **Kümelenmiş Sütun Grafikleri Oluşturma**

Bu bölüm, Aspose.Slides for .NET kullanarak kümelenmiş sütun grafikleri oluşturmayı açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir kümelenmiş sütun grafiğinin nasıl oluşturulduğunu görebilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bir grafik ekleyin, bazı veri ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.  
1. Grafik için bir başlık ekleyin.  
1. Grafiğin veri çalışma sayfasına erişin.  
1. Varsayılan tüm serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Grafik serilerine dolgu rengi uygulayın.  
1. Grafik serilerine etiket ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir kümelenmiş sütun grafiği oluşturmayı gösterir:

```c#
// Presentation sınıfını örnekle.
using (Presentation presentation = new Presentation())
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verileriyle kümelenmiş sütun grafiği ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Grafik başlığını ayarla.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // İlk serinin değerleri göstermesini ayarla.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Grafik veri sayfasının indeksini ayarla.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını al.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan oluşturulan serileri ve kategorileri sil.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Yeni seriler ekle.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Yeni kategoriler ekle.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // İlk grafik serisini al.
    IChartSeries series = chart.ChartData.Series[0];

    // Seri verilerini doldur.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Serinin dolgu rengini ayarla.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // İkinci grafik serisini al.
    series = chart.ChartData.Series[1];

    // Seri verilerini doldur.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Serinin dolgu rengini ayarla.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // İlk etiketi kategori adını gösterecek şekilde ayarla.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Üçüncü etiket için serinin değerini göstermesini ayarla.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Sunumu diske PPTX dosyası olarak kaydet.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Kümelenmiş Sütun Grafiği](clustered_column_chart.png)

### **Dağılım (Scatter) Grafikleri Oluşturma**

Dağılım grafikleri (scatter plot ya da x‑y grafiği olarak da bilinir), iki değişken arasındaki kalıpları kontrol etmek veya korelasyonları göstermek için sıkça kullanılır.

Aşağıdaki durumlarda dağılım grafiklerini kullanın:

* Eşlenmiş sayısal veriniz olduğunda.  
* İyi bir şekilde eşleşen iki değişkeniniz olduğunda.  
* İki değişkenin ilişkili olup olmadığını belirlemek istediğinizde.  
* Bağımlı bir değişken için birden çok değer içeren bağımsız bir değişkeniniz olduğunda.  

Bu C# kodu, farklı işaretçi serileri içeren bir dağılım grafiği oluşturmayı gösterir:

```c#
// Presentation sınıfını örnekle.
using (Presentation presentation = new Presentation())
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    // Varsayılan dağılım grafiğini oluştur.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Grafik veri sayfasının indeksini ayarla.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını al.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan seriyi sil.
    chart.ChartData.Series.Clear();

    // Yeni seriler ekle.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // İlk grafik serisini al.
    IChartSeries series = chart.ChartData.Series[0];

    // Seriye yeni bir nokta (1:3) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Yeni bir nokta (2:10) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Seri tipini değiştir.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Grafik serisi işaretçisini değiştir.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // İkinci grafik serisini al.
    series = chart.ChartData.Series[1];

    // Grafik serisine yeni bir nokta (5:2) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Yeni bir nokta (3:1) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Yeni bir nokta (2:2) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Yeni bir nokta (5:1) ekle.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Grafik serisi işaretçisini değiştir.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Sunumu diske PPTX dosyası olarak kaydet.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Dağılım Grafiği](scatter_chart.png)

### **Pasta (Pie) Grafikleri Oluşturma**

Pasta grafikler, özellikle sayısal değerlerle kategorik etiketleri içeren verilerde, parçanın bütünle ilişkisini göstermek için en iyisidir. Ancak veriniz çok fazla parçaya ya da etikete sahipse, bir çubuk grafik kullanmayı düşünebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.Pie` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Grafiğin dilimlerine yeni puanlar ekleyin ve özel renkler uygulayın.  
1. Seriler için etiketleri ayarlayın.  
1. Seri etiketleri için lider çizgileri etkinleştirin.  
1. Pasta grafiği için dönüş açısını ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir pasta grafiği oluşturmayı gösterir:

```c#
// Presentation sınıfını örnekle.
using (Presentation presentation = new Presentation())
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verileriyle bir grafik ekle.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Grafik başlığını ayarla.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // İlk serinin değerleri göstermesini ayarla.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Grafik veri sayfasının indeksini ayarla.
    int worksheetIndex = 0;

    // Grafik veri çalışma kitabını al.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Varsayılan oluşturulan serileri ve kategorileri sil.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Yeni kategoriler ekle.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Yeni seriler ekle.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Seri verilerini doldur.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Dilimin rengini ayarla.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Dilimin kenarlığını ayarla.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Dilimin kenarlığını ayarla.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Dilimin kenarlığını ayarla.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Yeni serideki her kategori için özel etiketler oluştur.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Serinin grafik için lider çizgileri göstermesini ayarla.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Pasta dilimlerinin dönüş açısını ayarla.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Sunumu diske PPTX dosyası olarak kaydet.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Pasta Grafiği](pie_chart.png)

### **Çizgi (Line) Grafikleri Oluşturma**

Çizgi grafikler (line graphs), değerlerin zaman içindeki değişimini göstermek istediğiniz durumlarda en iyisidir. Çizgi grafiği kullanarak büyük miktarda veriyi bir defada karşılaştırabilir, zaman içinde değişimleri ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.Line` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir çizgi grafiği oluşturmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Varsayılan olarak, çizgi grafiğindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların kesikli çizgilerle birleştirilmesini istiyorsanız, tercih ettiğiniz tire tipini aşağıdaki gibi belirtebilirsiniz:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Sonuç:

![Çizgi Grafiği](line_chart.png)

### **Ağaç Haritası (Tree Map) Grafikleri Oluşturma**

Ağaç haritası grafikleri, satış verilerini göstermek ve her kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek istediğinizde en iyisidir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.Treemap` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Dal 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Dal 2
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

### **Hisse Senedi (Stock) Grafikleri Oluşturma**

Hisse senedi grafikleri, açılış, yüksek, düşük ve kapanış fiyatları gibi finansal verileri göstermek için kullanılır; piyasa eğilimlerini ve volatiliteyi analiz etmeye yardımcı olur. Yatırımcıların ve analistlerin bilinçli kararlar almasını sağlayan temel içgörüler sunar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.OpenHighLowClose` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. HiLowLines biçimini belirtin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir hisse senedi grafiği oluşturmayı gösterir:

```c#
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

### **Kutu ve Bıyık (Box and Whisker) Grafikleri Oluşturma**

Kutu ve bıyık grafikleri, medyan, çeyrekler ve olası aykırı değerler gibi temel istatistikleri özetleyerek veri dağılımını gösterir. Keşifsel veri analizi ve istatistiksel çalışmalarda veri değişkenliğini hızlıca anlamak ve anormallikleri tespit etmek için özellikle yararlıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.BoxAndWhisker` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir kutu ve bıyık grafiği oluşturmayı gösterir:

```c#
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

### **Huni (Funnel) Grafikleri Oluşturma**

Huni grafikler, her aşamada veri hacminin azaldığı sıralı süreçleri görselleştirmek için kullanılır. Dönüşüm oranlarını analiz etme, darboğazları belirleme ve satış ya da pazarlama süreçlerinin verimliliğini izleme konusunda özellikle faydalıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.Funnel` türünü belirtin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir huni grafiği oluşturmayı gösterir:

```c#
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

### **Güneş Patlaması (Sunburst) Grafikleri Oluşturma**

Güneş patlaması grafikleri, katmanları iç içe halkalar olarak gösteren hiyerarşik verileri görselleştirmek için kullanılır. Parçanın bütünle ilişkisini göstermeye yardımcı olur ve iç içe geçmiş kategorileri kompakt bir biçimde temsil eder.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.Sunburst` türünü belirtin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Dal 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Dal 2
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

### **Histogram Grafikleri Oluşturma**

Histogram grafikler, sayısal verileri aralıklara (bin) bölerek dağılımı gösterir. Veri sıklığı, çarpıklık, yayılım gibi kalıpları tanımlamak ve aykırı değerleri tespit etmek için özellikle yararlıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bazı veriyle bir grafik ekleyin ve `ChartType.Histogram` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir histogram grafiği oluşturmayı gösterir:

```c#
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

### **Radar Grafikleri Oluşturma**

Radar grafikler, çok değişkenli verileri iki boyutlu bir formatta göstererek birden çok değişkeni aynı anda karşılaştırmayı kolaylaştırır. Performans ölçütleri veya özellikler arasındaki kalıpları, güçlü yanları ve zayıf yönleri belirlemek için özellikle uygundur.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Bazı veriyle bir grafik ekleyin ve `ChartType.Radar` türünü belirtin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir radar grafiği oluşturmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Radar Grafiği](radar_chart.png)

### **Çok Kategorili Grafikler Oluşturma**

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstermek için kullanılır; böylece değerleri aynı anda birden fazla boyutta karşılaştırabilirsiniz. Karmaşık, çok katmanlı veri setlerinde eğilimleri ve ilişkileri analiz etmek istediğinizde özellikle faydalıdır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizini kullanarak bir slayta referans alın.  
1. Varsayılan verilerle bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.  
1. Grafiğin veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişin.  
1. Varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni grafik verileri ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir çok kategorili grafik oluşturmayı gösterir:

```c#
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

    // Bir seri ekle.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Grafikle birlikte sunumu kaydet.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Çok Kategorili Grafik](multi_category_chart.png)

### **Harita Grafikleri Oluşturma**

Harita grafikleri, ülkeler, eyaletler veya şehirler gibi belirli konumlara veri eşleştirerek coğrafi verileri görselleştirir. Bölgesel eğilimleri, demografik bilgileri ve mekânsal dağılımları açık ve görsel açıdan çekici bir şekilde analiz etmenize yardımcı olur.

Bu C# kodu, bir harita grafiği oluşturmayı gösterir:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Harita Grafiği](map_chart.png)

### **Kombinasyon (Combination) Grafikleri Oluşturma**

Kombinasyon grafiği (combo chart), tek bir grafikte iki veya daha fazla grafik tipini birleştirir. Bu grafik, birden çok veri seti arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır; böylece ilişkileri daha rahat tanımlayabilirsiniz.

![Kombinasyon Grafiği](combination_chart.png)

Aşağıdaki C# kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda oluşturmayı gösterir:

```c#
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

    // Grafiğin açıklama kutusunu ayarlar
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

    // Dikey ana ızgara çizgilerinin rengini ayarlar
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

Aspose.Slides for .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu işlevsellik, sunumların dinamik içerikle güncel kalmasını kolaylaştırır ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını sağlar.

1. Bir grafik içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfını örnekleyin.  
1. Dizini kullanarak bir slayta referans alın.  
1. Tüm şekiller arasında dolaşarak grafiği bulun.  
1. Grafiğin veri çalışma sayfasına erişin.  
1. Seri değerlerini değiştirerek grafik veri serisini düzenleyin.  
1. Yeni bir seri ekleyin ve verilerini doldurun.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir grafiği güncellemeyi gösterir:

```c#
const string chartName = "My chart";

// PPTX dosyasını temsil eden Presentation sınıfını örnekle.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // İlk slayta eriş.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Grafik veri sayfasının indeksini ayarla.
            int worksheetIndex = 0;

            // Grafik veri çalışma kitabını al.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Grafik kategori adlarını değiştir.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // İlk grafik serisini al.
            IChartSeries series = chart.ChartData.Series[0];

            // Seri verilerini güncelle.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Seri adını değiştirerek.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // İkinci grafik serisini al.
            series = chart.ChartData.Series[1];

            // Seri verilerini güncelle.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Seri adını değiştirerek.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Yeni bir seri ekle.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Seri verilerini doldur.
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

## **Grafik İçin Veri Aralığını Ayarlama**

Aspose.Slides for .NET, bir grafik için veri kaynağı olarak çalışma sayfasından belirli bir veri aralığını tanımlama esnekliği sağlar. Bu, çalışma sayfanızın yalnızca bir bölümünü grafikle eşlemenize, hangi hücrelerin seri ve kategorilere katkıda bulunduğunu kontrol etmenize olanak tanır. Sonuç olarak, grafiklerinizi en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilirsiniz; böylece PowerPoint sunumlarınız güncel ve doğru bilgiler içerir.

1. Bir grafik içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfını örnekleyin.  
1. Dizini kullanarak bir slayta referans alın.  
1. Tüm şekiller arasında dolaşarak grafiği bulun.  
1. Grafik verisine erişin ve aralığı ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu C# kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```c#
const string chartName = "My chart";

// PPTX dosyasını temsil eden Presentation sınıfını örnekle.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // İlk slayta eriş.
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

## **Grafiklerde Varsayılan İşaretçiler Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisine otomatik olarak farklı bir varsayılan işaretçi sembolü atanır.

Bu C# kodu, bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

```c#
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

    // Serinin verilerini doldur.
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

Aspose.Slides for .NET, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik tipini seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturur, istenen slayta diziniyle erişir ve ardından grafik tipini ve başlangıç verilerini belirterek grafik ekleme yöntemini çağırırsınız. Bu süreç, grafiği doğrudan sunumunuza entegre eder.

**Grafikte görüntülenen veriler nasıl güncellenir?**

Grafiğin verisini, veri kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip, kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Bu sayede grafik, en son verileri yansıtacak şekilde programlı olarak yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides for .NET kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, açıklama kutuları ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü belirli tasarım gereksinimlerinize göre uyarlayabilirsiniz.