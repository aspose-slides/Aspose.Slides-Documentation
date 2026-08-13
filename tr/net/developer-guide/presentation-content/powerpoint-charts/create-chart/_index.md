---
title: .NET'te PowerPoint Sunumu Grafiklerini Oluştur veya Güncelle
linktitle: Grafik Oluştur veya Güncelle
type: docs
weight: 10
url: /tr/net/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç haritası grafiği
- hisse senedi grafiği
- kutu ve kıllı grafik
- huni grafiği
- güneş patlaması grafiği
- histogram grafiği
- radar grafiği
- çok kategorili grafik
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. C#'ta pratik kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir kılavuz sunar. Bir slayta programlı olarak grafik eklemeyi, verileri doldurmayı ve belirli tasarım gereksinimlerinize uyması için çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu kılavuzu izleyerek, .NET uygulamalarınıza dinamik grafik oluşturmayı entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturmayı kolaylaştıracaksınız.

## **Grafik Oluştur**

Grafikler, verileri hızlı bir şekilde görselleştirmenize ve tablodan veya elektronik tablodan hemen fark edilmeyen içgörüleri elde etmenize yardımcı olur.

**Grafik Oluşturmanın Nedenleri?**

Grafikleri kullanarak:

* büyük miktarda veriyi tek bir slaytta özetleyebilir,
* veri içindeki desen ve trendleri ortaya çıkarabilir,
* zaman içinde veya belirli bir ölçüm birimine göre verinin yönünü ve ivmesini çıkarabilirsiniz,
* aykırı değerleri, sapmaları, hataları ve mantıksız verileri tespit edebilirsiniz,
* karmaşık verileri iletişim kurarak veya sunarak aktarabilirsiniz.

PowerPoint’te, *Ekle* işlevi aracılığıyla birçok grafik türü için şablonlar sunar. Aspose.Slides kullanarak hem standart grafikler (popüler grafik türlerine dayalı) hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" %}} 
[ChartType] enumeration under the [Aspose.Slides.Charts] namespace kullanarak. Bu enumerasyonun değerleri farklı grafik türlerine karşılık gelir.
{{% /alert %}} 

### **Küme Sütun Grafiği Oluştur**

Bu bölüm, Aspose.Slides for .NET ile küme sütun grafiği oluşturmayı açıklar. Sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir küme sütun grafiğinin nasıl oluşturulduğunu görebilirsiniz:

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Bazı veri ile bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.
1. Grafik’e bir başlık ekleyin.
1. Grafiğin veri çalışma sayfasına erişin.
1. Varsayılan tüm serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Grafik serilerine dolgu rengi uygulayın.
1. Grafik serilerine etiket ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir küme sütun grafiği oluşturmayı gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    // Varsayılan verileriyle bir kümelenmiş sütun grafiği ekleyin.
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

    // Seri için dolgu rengini ayarlayın.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // İkinci grafik serisini alın.
    series = chart.ChartData.Series[1];

    // Seri verilerini doldurun.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Seri için dolgu rengini ayarlayın.
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

    // Sunumu bir PPTX dosyası olarak diske kaydedin.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Küme Sütun Grafiği](clustered_column_chart.png)

### **Saçılım Grafiği Oluştur**

Saçılım grafikleri (diğer adıyla dağılım grafiği veya x‑y grafiği), iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için sıklıkla kullanılır.

Bir saçılım grafiği şu durumlarda tercih edilir:

* Eşleştirilmiş sayısal verileriniz varsa,
* Birbirine iyi eşleşen iki değişkeniniz varsa,
* İki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız,
* Bağımlı bir değişken için birden çok değere sahip bağımsız bir değişkeniniz varsa.

Bu C# kodu, farklı işaretçi serileri ile bir saçılım grafiği oluşturmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation())
{
    // İlk slayta erişin.
    ISlide slide = presentation.Slides[0];

    // Varsayılan saçılım grafiğini oluşturun.
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

    // Grafik seri işaretçisini değiştirin.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // İkinci grafik serisini alın.
    series = chart.ChartData.Series[1];

    // Grafik serisine yeni bir nokta (5:2) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Yeni bir nokta (3:1) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Yeni bir nokta (2:2) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Yeni bir nokta (5:1) ekleyin.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Grafik seri işaretçisini değiştirin.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Sunumu bir PPTX dosyası olarak diske kaydedin.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Saçılım Grafiği](scatter_chart.png)

### **Pasta Grafiği Oluştur**

Pasta grafikler, özellikle veriler kategorik etiketlerle sayısal değerler içerdiğinde, parçanın bütüne oranını göstermek için en iyi tercih edilen grafiktir. Ancak, verinizde çok fazla parça veya etiket varsa, çubuk grafik kullanmayı düşünebilirsiniz.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.Pie` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Pasta grafiğinin dilimlerine özel renkler uygulayın.
1. Seriler için etiketler ayarlayın.
1. Seri etiketleri için lider çizgileri etkinleştirin.
1. Pasta grafiği için dönüş açısını ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir pasta grafiği oluşturmayı gösterir:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin.
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

    // Sektör rengini ayarlayın.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Sektör kenarlığını ayarlayın.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Sektör kenarlığını ayarlayın.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Sektör kenarlığını ayarlayın.
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

    // Pasta grafiği dilimlerinin dönüş açısını ayarlayın.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Sunumu bir PPTX dosyası olarak diske kaydedin.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Pasta Grafiği](pie_chart.png)

### **Çizgi Grafiği Oluştur**

Çizgi grafikler (diğer adıyla çizgi diyagramları), zaman içindeki değer değişimlerini göstermek istediğiniz durumlar için en uygunudur. Çizgi grafiği kullanarak, aynı anda büyük bir veri kümesini karşılaştırabilir, zaman içinde değişimleri ve trendleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.Line` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir çizgi grafiği oluşturmayı gösterir:

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

Varsayılan olarak, çizgi grafiğindeki noktalar düz sürekli çizgilerle bağlanır. Noktaların kesik çizgilerle bağlanmasını isterseniz, tercih ettiğiniz kesik tipini aşağıdaki gibi belirtebilirsiniz:

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

### **Ağaç Haritası Grafiği Oluştur**

Ağaç haritası grafikleri, satış verilerinde veri kategorilerinin göreceli boyutlarını göstermek ve her kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek için idealdir.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.Treemap` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

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

### **Hisse Senedi Grafiği Oluştur**

Hisse senedi grafikleri, açılış, yüksek, düşük ve kapanış fiyatları gibi finansal verileri göstererek piyasa trendlerini ve oynaklığı analiz etmenize yardımcı olur. Bu grafikler, hisse performansı hakkında kritik içgörüler sunarak yatırımcı ve analistlerin bilinçli kararlar almasını sağlar.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.OpenHighLowClose` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. HiLowLines biçimini belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir hisse senedi grafiği oluşturmayı gösterir:

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

### **Kutu ve Kıllı Grafiği Oluştur**

Kutu ve Kıllı grafikleri, medyan, çeyrekler ve olası uç değerler gibi temel istatistiksel ölçümleri özetleyerek veri dağılımını gösterir. Keşifsel veri analizi ve istatistiksel çalışmalar için veri değişkenliğini hızlıca anlamak ve anormallikleri tanımlamak açısından çok yararlıdır.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.BoxAndWhisker` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir kutu ve kılı grafik oluşturmayı gösterir:

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

### **Huni Grafiği Oluştur**

Huni grafikleri, bir sürecin ardışık aşamalarını görselleştirir; veri hacmi bir adımdan diğerine ilerledikçe azalır. Bu grafikler, dönüşüm oranlarını analiz etmek, darboğazları belirlemek ve satış ya da pazarlama süreçlerinin verimliliğini izlemek için özellikle faydalıdır.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.Funnel` türünü belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir huni grafiği oluşturmayı gösterir:

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

### **Güneş Patlaması Grafiği Oluştur**

Güneş patlaması grafikleri, hiyerarşik verileri dairesel halkalar halinde göstererek parçanın bütüne ilişkisini görselleştirir. İç içe kategorileri ve alt kategorileri net ve kompakt bir formatta temsil etmek için idealdir.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.Sunburst` türünü belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

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

### **Histogram Grafiği Oluştur**

Histogram grafikler, sayısal verileri aralıklara ya da kutulara gruplayarak dağılımını gösterir. Frekans, çarpıklık ve yayılım gibi veri desenlerini tanımlamak ve veri setindeki aykırı değerleri tespit etmek için özellikle yararlıdır.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Bazı veri ile bir grafik ekleyin ve `ChartType.Histogram` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir histogram grafiği oluşturmayı gösterir:

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

### **Radar Grafiği Oluştur**

Radar grafikleri, çok değişkenli verileri iki boyutlu bir formatta göstererek birden fazla değişkeni aynı anda karşılaştırmanıza olanak tanır. Performans ölçütleri veya özellikler arasında desen, güçlü yön ve zayıf yönleri tanımlamak için özellikle faydalıdır.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Bazı veri ile bir grafik ekleyin ve `ChartType.Radar` türünü belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir radar grafiği oluşturmayı gösterir:

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

### **Çok Kategorili Grafik Oluştur**

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstermek için kullanılır; bu sayede değerleri aynı anda birden çok boyutta karşılaştırabilirsiniz. Karmaşık, çok katmanlı veri setlerinde trend ve ilişkileri analiz etmek gerektiğinde özellikle yararlıdır.

1. [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Varsayılan veri ile bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.
1. Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, çok kategorili bir grafik oluşturmayı gösterir:

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

    // Grafikli sunumu kaydet.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Sonuç:

![Çok Kategorili Grafik](multi_category_chart.png)

### **Harita Grafiği Oluştur**

Harita grafikleri, ülkeler, eyaletler veya şehirler gibi belirli konumlara bilgi eşleştirerek coğrafi verileri görselleştirir. Bölgesel trendleri, demografik verileri ve mekânsal dağılımları net ve görsel olarak etkileyici bir biçimde analiz etmek için özellikle uygundur.

Bu C# kodu, bir harita grafiği oluşturmayı gösterir:

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
Yukarıdaki resim, kaydedilen sunumun PowerPoint’te açılmış hâlini gösterir. Aspose.Slides harita grafiğini ve verilerini doğru bir şekilde yazar, ancak harita grafiğini kendisi çizmeyi desteklemez: bir slayt bu grafiği bir görüntüye render edildiğinde ya da PDF ya da SVG’ye dönüştürüldüğünde grafik alanı boş çıkar. Aynı slayttaki diğer şekiller etkilenmez.
{{% /alert %}} 

### **Kombinasyon Grafiği Oluştur**

Kombinasyon (combo) grafiği, tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki ya da daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri tanımlamanıza yardımcı olur.

![Kombinasyon Grafiği](combination_chart.png)

Aşağıdaki C# kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda nasıl oluşturacağınızı gösterir:

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

    // Grafik başlığını ayarlar
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Grafik lejantını ayarlar
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

## **Grafikleri Güncelle**

Aspose.Slides for .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu özellik, sunumları dinamik içerikle güncel tutmayı ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını kolaylaştırır.

1. Grafik içeren sunumu temsil eden [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Tüm şekiller arasında dolaşarak grafiği bulun.
1. Grafiğin veri çalışma sayfasına erişin.
1. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.
1. Yeni bir seri ekleyin ve verilerini doldurun.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir grafiği güncellemeyi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Bir PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
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

            // Grafik kategori adlarını değiştirin.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // İlk grafik serisini alın.
            IChartSeries series = chart.ChartData.Series[0];

            // Seri verilerini güncelleyin.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Seri adını değiştirerek.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // İkinci grafik serisini alın.
            series = chart.ChartData.Series[1];

            // Seri verilerini güncelleyin.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Seri adını değiştirerek.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Yeni bir seri ekleyin.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Seri verilerini doldurun.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Grafikli sunumu kaydedin.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Grafik İçin Veri Aralığı Ayarla**

Aspose.Slides for .NET, bir çalışma sayfasındaki belirli bir veri aralığını grafik veri kaynağı olarak tanımlama esnekliği sunar. Bu sayede, çalışma sayfanızın yalnızca bir bölümünü grafiğe eşleyebilir, hangi hücrelerin grafik serileri ve kategorilerine katkıda bulunduğunu kontrol edebilirsiniz. Sonuç olarak, grafiklerinizi çalışma sayfanızdaki en son veri değişiklikleriyle kolayca güncelleyebilir ve senkronize edebilirsiniz; böylece PowerPoint sunumlarınız güncel ve doğru bilgi içerir.

1. Grafik içeren sunumu temsil eden [Presentation] sınıfının bir örneğini oluşturun.
1. İndeksini kullanarak bir slayta referans alın.
1. Tüm şekiller arasında dolaşarak grafiği bulun.
1. Grafik verisine erişin ve aralığı ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir grafik için veri aralığını nasıl ayarlayacağınızı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Bir PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
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

## **Grafiklerde Varsayılan İşaretçiler Kullan**

Grafiklerde varsayılan işaretçiler kullandığınızda, her grafik serisine otomatik olarak farklı bir varsayılan işaretçi sembolü atanır.

Bu C# kodu, bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

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

### Aspose.Slides for .NET hangi grafik türlerini destekliyor?

Aspose.Slides for .NET, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyacınıza en uygun grafik türünü seçmenizi sağlar.

### Yeni bir grafiği bir slayta nasıl eklerim?

Bir grafik eklemek için önce [Presentation] sınıfının bir örneğini oluşturur, istenen slaytı indeksle alır ve ardından grafik ekleme yöntemini çağırarak grafik türünü ve başlangıç verilerini belirtirsiniz. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

### Bir grafiğin gösterdiği verileri nasıl güncellerim?

Grafiğin veri çalışma kitabına ([IChartDataWorkbook]) erişerek, varsayılan serileri ve kategorileri temizleyebilir ve ardından kendi özel verilerinizi ekleyebilirsiniz. Böylece grafiği programatik olarak en son verileri yansıtacak şekilde yenileyebilirsiniz.

### Grafiğin görünümünü özelleştirmek mümkün mü?

Evet, Aspose.Slides for .NET kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre şekillendirebilirsiniz.