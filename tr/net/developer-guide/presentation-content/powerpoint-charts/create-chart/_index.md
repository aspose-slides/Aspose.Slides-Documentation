---
title: .NET'te PowerPoint Sunumu Grafiklerini Oluşturma veya Güncelleme
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
- dağılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç haritası grafiği
- hisse senedi grafiği
- kutu ve bıyık grafiği
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
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Grafik ekleyin, biçimlendirin ve C#'ta pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Slayta programlı olarak bir grafik eklemeyi, verileri doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve lejandları yapılandırmaya kadar her adımı gösteren detaylı kod örnekleri bulunur. Bu rehberi izleyerek, .NET uygulamalarınıza dinamik grafik oluşturmayı entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek bir tablo ya da çalışma sayfasından hemen anlaşılmayan içgörüleri ortaya çıkarmaya yardımcı olur.

**Grafikler Neden Oluşturulmalı?**

Grafikler kullanarak:

* bir sunumdaki tek bir slayta büyük miktarda veriyi toplulaştırabilir, sıkıştırabilir veya özetleyebilirsiniz;
* verilerdeki kalıpları ve eğilimleri ortaya çıkarabilirsiniz;
* belirli bir ölçü birimiyle zaman içinde veya karşılaştırmalı olarak verinin yönünü ve ivmesini belirleyebilirsiniz;
* aykırı değerleri, sapmaları, hataları ve mantıksız verileri tespit edebilirsiniz;
* karmaşık verileri iletişim kurmak veya sunmak için kullanabilirsiniz.

PowerPoint'te, birçok grafik türü tasarlamak için şablonlar sunan *Insert* işleviyle grafik oluşturabilirsiniz. Aspose.Slides kullanarak hem popüler grafik türlerine dayalı normal grafikler hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Use the [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration under the [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) namespace. The values in this enumeration correspond to different chart types.
{{% /alert %}}

### **Kümelenmiş Sütun Grafikler Oluşturma**

Bu örnek, iki seriyi üç kategori boyunca karşılaştıran bir kümelenmiş sütun grafiği oluşturmak için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır. Seriler kırmızı ve yeşil dolgu renklerine sahiptir ve bireysel etiketler kategori adlarını, seri adlarını ve değerleri gösterir. Çalışma sayfası indeksi 0, gömülü grafik çalışma kitabındaki ilk sayfayı ifade eder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Kümelenmiş Sütun grafiği](clustered_column_chart.png)

### **Dağılım Grafikler Oluşturma**

Dağılım grafikler (diğer adıyla scatter plot veya x‑y grafiği), iki değişken arasındaki kalıpları kontrol etmek veya korelasyonları göstermek için sıkça kullanılır.

Aşağıdaki durumlarda dağılım grafiği kullanın:

* Eşleştirilmiş sayısal verileriniz varsa.
* Birlikte iyi çalışan iki değişkeniniz varsa.
* İki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız.
* Bağımlı bir değişken için birden çok değer içeren bağımsız bir değişkeniniz varsa.

Bu örnek iki x‑y değer seti çizer. İlk seri yıldız işaretçili düz çizgiler kullanırken, ikinci seri yuvarlak işaretçili yumuşak çizgiler kullanır; her ikisi de 10 [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) değerine sahiptir. [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) özelliği işaretçi şeklinin kontrolünü sağlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Dağılım grafiği](scatter_chart.png)

### **Pasta Grafikler Oluşturma**

Pasta grafikler, özellikle veri kategorik etiketler ile sayısal değerler içerdiğinde, parça‑bütün ilişkisini göstermek için en uygunudur. Ancak veri çok sayıda parça ya da etiket içeriyorsa, çubuk grafik kullanmayı düşünmelisiniz.

Bu örnek, üç çeyrek değeri içeren bir pasta grafiği oluşturur. Her dilim özelleştirilmiş dolgu ve kenarlığa sahiptir; etiketler değer, yüzde ve seri bilgilerini farklı kombinasyonlarda gösterir. [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) özelliği ilk dilimin 180 derece başlamasını sağlar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Pasta grafiği](pie_chart.png)

Etiketlerin dışarıda okunabilirliğini artırmak için, etiketleri konumlandıran ve çizgi renk, genişlik, şeffaflık ve kesikli stilini özelleştiren bir örnek için [Format Leader Lines](/slides/tr/net/chart-data-label/#format-leader-lines) bölümüne bakın.

### **Çizgi Grafikler Oluşturma**

Çizgi grafikler (diğer adıyla çizgi grafikleri), değer değişimlerini zaman içinde göstermek istediğiniz durumlarda en uygunudur. Çizgi grafik kullanarak büyük miktarda veriyi aynı anda karşılaştırabilir, zaman içindeki değişimleri ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

Bu örnek, varsayılan seri ve kategorilere sahip bir çizgi grafiği oluşturmak için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır ve sunumu PPTX olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar kesintisiz düz çizgilerle bağlanır. Noktaların tireli çizgilerle bağlanmasını isterseniz, [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) özelliğini [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) içindeki bir değere ayarlayın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Sonuç:

![Çizgi grafiği](line_chart.png)

### **Ağaç Haritası Grafikler Oluşturma**

Ağaç haritası grafikler, satış verileri gibi kategori boyutlarını göreceli olarak göstermek ve her kategoride büyük katkı sağlayan öğelere hızlıca dikkat çekmek istediğinizde en uygunudur.

Bu örnek, dört sap ve iki dal içinde gruplanmış sekiz yaprak içeren bir ağaç haritası oluşturur. [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) yöntemi, 1. seviyedeki sapları ve 2. seviyedeki dalları atar. Değerler, göreceli dikdörtgen boyutlarını belirler; kategori etiketleri ve üst etiketler hiyerarşiyi gösterir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Dal 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Dal 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Sonuç:

![Ağaç haritası grafiği](treemap_chart.png)

### **Şelale Grafikler Oluşturma**

Şelale grafik, pozitif ve negatif değişikliklerin nihai değere nasıl katkıda bulunduğunu gösterir. Örneğin, bir kar dağılımı gelirle başlayıp maliyetleri çıkararak ve diğer gelirleri ekleyerek ilerleyebilir. Değişim sütunları önceki ve yeni çalışan değerler arasında süzülürken, toplam sütunlar sıfırdan birikimli değere uzanır.

Aşağıdaki örnek, bin ABD doları cinsinden tutarları kullanır:

| Kategori | Çalışma kitabı değeri | Sütun tipi |
| --- | ---: | --- |
| Gelir | 1000 | Artış |
| Satış maliyeti | -400 | Azalış |
| Brüt kar | 600 | Ara toplam |
| Faaliyet giderleri | -200 | Azalış |
| Diğer gelir | 50 | Artış |
| Net kar | 450 | Son toplam |

Bir noktayı ara toplam ya da son toplam olarak işaretlemek için, [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) özelliğini `true` olarak ayarlayın. O noktaya ait çalışma kitabı hücresine gerçek birikimli tutarı girin: brüt kar için `600` (`1000 - 400`) ve net kar için `450` (`600 - 200 + 50`). Özellik, sütunu toplam olarak işaretler; hücre değerini hesaplamaz ya da doldurmaz. Sıfırı yer tutucu olarak kullanmayın ya da toplam noktasına başka bir değişim eklemeyin. Toplam sütun, birikimli değeri ek bir kez daha eklemeden gösterir.

Bu tam C# örneği, [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) üyesi `Waterfall` kullanarak bir grafik oluşturur, varsayılan verileri temizler ve gömülü çalışma kitabını doldurur. Çalışma sayfası indeksi `0` ilk sayfayı seçer; A sütunu kategori adlarını, B sütunu değerleri içerir. Her değer hücresi, [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) ile eklenir. Sıfır‑tabanlı nokta indeksleri `2` ve `5` ara ve son toplamları tanımlar. [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) etkinleştirildiğinde, tutarlar sütunlarda gösterilir. Giriş sunumu ya da çalışma kitabı gerekmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// Üçüncü ve altıncı noktalar toplamları temsil eder, ek değişiklikler değildir.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Seri‑seviyesi [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) özelliğini `true` yaparak ardışık sütunları bağlayan çizgileri gösterin ve çalışan değerin takibini kolaylaştırın. Bu çizgileri gizlemek için örnekteki atamayı `series.ShowConnectorLines = false;` olarak değiştirip kaydedin. Bu yalnızca çizgi görünürlüğünü değiştirir, veri ya da toplamları etkilemez.

Kaydedilen sunum, 600 brüt kar ve 450 net karı, her iki toplamın da sıfırdan çizildiğini gösterir:

![Gelir, maliyetler, 600 brüt kar ve 450 net karı gösteren şelale grafiği, değer etiketleri ve bağlayıcı çizgilerle](waterfall_chart.png)

### **Hisse Senedi Grafikler Oluşturma**

Hisse senedi grafikleri, açılış, yüksek, düşük ve kapanış fiyatları gibi finansal verileri göstererek piyasa eğilimlerini ve volatiliteyi analiz etmeye yardımcı olur. Bu grafikler, hisse performansı hakkında kritik içgörüler sunarak yatırımcı ve analistlerin bilinçli kararlar almasını sağlar.

Bu örnek, sırasıyla dört seri ve üç kategori içeren bir açık‑yüksek‑düşük‑kapanış (OHLC) grafiği oluşturur. [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) özelliği yukarı/ayrı çubuklarını etkinleştirir, [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) fiyat aralıklarını gösteren yüksek‑düşük çizgileri kontrol eder; bireysel seri çizgileri ve ince yatay ızgara çizgileri gizlenir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Hisse senedi grafiği](stock_chart.png)

### **Kutu ve Bıyık Grafikler Oluşturma**

Kutu ve bıyık grafikler, medyan, çeyrekler ve olası aykırı değerler gibi temel istatistiksel ölçümleri özetleyerek veri dağılımını göstermeye yarar. Keşifsel veri analizi ve istatistiksel çalışmalar için veri değişkenliğini hızlıca anlamak ve anormallikleri belirlemek açısından özellikle faydalıdır.

Bu örnek, altı değerden oluşan bir kutu ve bıyık grafiği oluşturur. [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) özelliği dışsal çeyrek hesaplamasını seçer. Örnek ayrıca ortalama çizgileri, ortalama işaretçileri, iç noktalar ve aykırı değer noktalarını da etkinleştirir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Huni Grafikler Oluşturma**

Huni grafikler, veri hacminin bir adımdan diğerine geçerken azaldığı süreçleri görselleştirmek için kullanılır. Dönüşüm oranlarını analiz etmek, darboğazları belirlemek ve satış ya da pazarlama süreçlerinin verimliliğini izlemek için özellikle yararlıdır.

Bu örnek, mevcut bir sunumun ilk slaytına bir huni grafik eklemek için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır. Varsayılan veriyi altı kategori ve 50‑500 arasında değişen değerlerle değiştirir, ardından güncellenmiş sunumu kaydeder. Giriş sunumu en az bir slayt içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Sonuç:

![Huni grafiği](funnel_chart.png)

### **Güneş Patlaması Grafikler Oluşturma**

Güneş patlaması grafikler, katmanları dairesel halkalar olarak göstererek hiyerarşik verileri görselleştirir. Parça‑bütün ilişkilerini açıklamaya yardımcı olur ve iç içe geçmiş kategorileri net, kompakt bir formatta temsil etmek için idealdir.

Bu örnek, sekiz yaprağı dört sap ve iki dal içinde gruplayan bir güneş patlaması grafiği oluşturur. [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) yöntemi, 1. seviyedeki sapları ve 2. seviyedeki dalları atar. Kategori etiketleri segmentleri tanımlar; değerler ise göreceli boyutlarını belirler.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Dal 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Dal 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Sonuç:

![Güneş patlaması grafiği](sunburst_chart.png)

### **Histogram Grafikler Oluşturma**

Histogram grafikler, sayısal değerlerin aralıklar (bin) içinde nasıl dağıldığını gösterir. Sipariş işleme süreleri gibi aylık raporlar için aynı bin genişliğini ve eşik değerlerini kullanarak aralıkları tutarlı tutabilir ve dağılımları karşılaştırmayı kolaylaştırabilirsiniz.

Yatay eksenin [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) özelliğini [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/) içindeki bir moda ayarlayın. [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) yalnızca `ByBinWidth` için, [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) yalnızca `ByNumberOfBins` için geçerlidir. `Automatic` seçeneği, binlerin otomatik seçilmesini sağlar.

#### **Sabit Bir Bini Genişliği Kullanma**

Bu örnek, işleme zamanlarını 10 dakikalık aralıklara gruplar; 10 dakikadan az veya eşit ve 40 dakikadan fazla zamanlar için ayrı binler oluşturur. Bu binleri [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) ve [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/) ile etkinleştirin. Açıkça [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) ve [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) eşiklerini belirlerken, [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) ve [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) özelliklerini `false` yapın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

PowerPoint’te gösterilen sunum, **3, 4, 4, 4 ve 2** bin sayısını gösterir. Alt bin, `5, 10, 10` değerlerini içerdiği için eşik dahil edicidir. Üst bin yalnızca `41, 50` değerlerini içerir; eşik dışlayıcıdır; `40` değerleri önceki aralıkta kalır. İç binler, alt sınırdan büyük ve üst sınırdan küçük ya da eşit değerleri barındırır.

![10 dakikalık binler ve açık alt/üst eşik değerleriyle histogram](histogram_bin_width.png)

#### **Bin Sayısını Belirleme**

Sabit aralıklar yerine sabit bir veri ayrıntısı seviyesi isterseniz, aynı veriler için beş bin isteyin. Bu örnek, alt ve üst binleri devre dışı bırakır. Grafik, genişliği veri aralığından belirler, bu yüzden sınırlar raporlar arasında değişebilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Beş binin sayısı **4, 4, 4, 4 ve 1**’dir. Yukarıdaki sabit‑genişlik sonucu ile karşılaştırın: girdi değerleri aynı, ancak sınırlar farklı.

![Aynı veriden hesaplanan beş binli histogram](histogram_bin_count.png)

### **Radar Grafikler Oluşturma**

Radar grafikler, çok değişkenli verileri iki boyutlu bir formatta göstererek birkaç değişkeni aynı anda karşılaştırmayı kolaylaştırır. Performans ölçütleri veya özellikler gibi birden fazla metriği analiz ederken kalıpları, güçlü ve zayıf yönleri belirlemek için özellikle yararlıdır.

Bu örnek, varsayılan seri ve kategorilerle bir radar grafiği oluşturmak için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır ve sunumu PPTX olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Radar grafiği](radar_chart.png)

### **Çok Kategorili Grafikler Oluşturma**

Çok kategorili grafikler, birden fazla kategorik gruplamayı içeren verileri göstermek için kullanılır; böylece birden çok boyutta değerleri aynı anda karşılaştırabilirsiniz. Karmaşık, çok katmanlı veri setlerinde eğilimleri ve ilişkileri analiz etmek gerektiğinde özellikle faydalıdır.

Bu örnek, dört çift halinde düzenlenmiş sekiz kategoriye sahip bir kümelenmiş sütun grafiği oluşturur. [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) yöntemi, her çifti grup seviyesi 1’de ortak bir etiketle işaretler; böylece hem bireysel hem de grup etiketlerini içeren bir kategori ekseni elde edilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Çok kategorili grafik](multi_category_chart.png)

### **Harita Grafikler Oluşturma**

Harita grafikler, ülkeler, eyaletler veya şehirler gibi belirli konumlara bilgi eşleyerek coğrafi verileri görselleştirir. Bölgesel eğilimleri, demografik verileri ve mekânsal dağılımları net ve görsel açıdan çekici bir şekilde analiz etmek için özellikle uygundur.

Bu örnek, varsayılan coğrafi verilerle bir harita grafiği oluşturmak için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır ve PowerPoint’te görüntülenmek üzere kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Sonuç:

![Harita grafiği](map_chart.png)

{{% alert color="info" title="Note" %}}
Yukarıdaki resim, PowerPoint’te açılmış kaydedilmiş bir sunumu gösterir. Aspose.Slides, harita grafiğini ve verilerini doğru şekilde yazar, ancak harita grafiklerini kendisi çizmez: bir slayt görüntüye dönüştürüldüğünde ya da PDF veya SVG’ye çevrildiğinde grafik alanı boş çıkar. Aynı slayttaki diğer şekiller etkilenmez.
{{% /alert %}}

### **Kombinasyon Grafikler Oluşturma**

Kombinasyon (veya combo) grafiği, tek bir grafikte iki ya da daha fazla grafik türünü birleştirir. Bu grafik, birden çok veri seti arasındaki ilişkileri belirlemenize, karşılaştırmanıza ve farklılıkları incelemenize yardımcı olur.

![Kombinasyon grafiği](combination_chart.png)

Bu örnek, dört kategori üzerinde iki kümelenmiş sütun serisini bir çizgi serisiyle birleştirir. Sütunlar birincil dikey ekseni, [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) ise çizgi serisini sağdaki ikincil dikey eksene yerleştirir. Yardımcı işlevler başlık, lejand, eksen etiketleri ve ızgara çizgilerini yapılandırır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Grafikleri Güncelleme**

Aspose.Slides for .NET, grafik verilerini, biçimlendirmesini ve stilini değiştirerek PowerPoint grafiklerini güncellemenizi sağlar. Bu işlevsellik, sunumları dinamik içerikle güncel tutmayı basitleştirir ve grafiklerin mevcut veri ve görsel standartları doğru yansıtmasını sağlar.

Bu örnek, mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiği günceller. Her biri üç veri noktasına sahip iki sütun serisi, A sütununda kategori etiketleri ve ilk çalışma sayfasının ilk satırında seri adları gerektirir. Örnek, [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) ile çalışma kitabı hücrelerini değiştirir, seri değerlerini günceller, üçüncü bir seri ekler ve grafiği [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/) aracılığıyla kümelenmiş silindirlere dönüştürür.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Mevcut bir grafik tarafından zaten kullanılan aralığı incelemek için [Retrieve a Chart's Data Range](/slides/tr/net/chart-workbook/#retrieve-a-charts-data-range) bölümüne bakın.

Aspose.Slides for .NET, grafik verilerinizin kaynağı olarak bir çalışma sayfasındaki belirli bir veri aralığını tanımlama esnekliği sağlar. Bu, çalışma sayfanızın yalnızca bir bölümünü grafiğe eşlemenize, seriler ve kategoriler için hangi hücrelerin katkıda bulunduğunu kontrol etmenize olanak tanır. Sonuç olarak, grafiğinizin veri kaynaklarını en güncel çalışma sayfası verileriyle kolayca güncelleyebilir ve senkronize edebilirsiniz.

Bu örnek, [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) kullanarak mevcut bir sunumun ilk slaydındaki "My chart" adlı grafiğin veri kaynağını `Sheet1!A1:B4` olarak ayarlar. Grafik çalışma kitabının bu çalışma sayfasını ve birinci satırda seri başlığı, A sütununda kategori etiketleri ve B sütununda üç değer içeren bir aralık barındırması gerekir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisi otomatik olarak farklı bir varsayılan işaretçi sembolü alır.

Bu örnek, iki çizgi serisi ve bir lejand içeren bir grafik oluşturmak için [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanır. [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) ayarları, otomatik atanan işaretçi sembollerini korur. İlk seri negatif bir değer ve eksik bir değer (`null` ile temsil edilir) içerirken, ikinci seri her kategori için bir değer barındırır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **SSS**

**Aspose.Slides for .NET hangi grafik türlerini destekliyor?**

Aspose.Slides for .NET, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok grafik türünü destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Yeni bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) sınıfının bir örneğini oluşturur, istediğiniz slaytı indeksine göre alır ve ardından grafik tipini ve başlangıç verilerini belirterek grafik ekleme metodunu çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Bir grafikte gösterilen veriler nasıl güncellenir?**

Bir grafiğin verilerini, veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Bu, grafiği programlı olarak en son verileri yansıtacak şekilde yenilemenizi sağlar.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides for .NET kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer biçimlendirme öğelerini değiştirerek grafiğin görünümünü belirli tasarım gereksinimlerinize göre uyarlayabilirsiniz.