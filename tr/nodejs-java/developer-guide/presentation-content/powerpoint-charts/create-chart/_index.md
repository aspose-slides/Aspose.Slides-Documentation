---
title: JavaScript ile PowerPoint Sunumu Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/nodejs-java/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- saçılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç haritası grafiği
- hisse senedi grafiği
- kutu ve bıyık grafiği
- huni grafiği
- güneş patlaması grafiği
- histogram grafiği
- radar grafiği
- çoklu kategori grafiği
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint sunumlarında grafikler oluşturun ve özelleştirin. Grafikleri ekleyin, biçimlendirin ve JavaScript'te pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir slayta programlı olarak nasıl grafik ekleyeceğinizi, verileri nasıl dolduracağınızı ve belirli tasarım gereksinimlerinize uyması için çeşitli biçimlendirme seçeneklerini nasıl uygulayacağınızı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu rehberi izleyerek, uygulamalarınıza dinamik grafik oluşturmayı entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlıca görselleştirmenizi ve bir tablo ya da elektronik tablodan hemen ortaya çıkmayabilecek içgörüler elde etmenizi sağlar.

**Neden Grafik Oluşturmalısınız?**

Grafikleri kullanarak:

* tek bir slaytta büyük miktarda veriyi toplu, sıkıştırılmış ya da özet bir şekilde gösterebilirsiniz
* verilerdeki desen ve eğilimleri ortaya çıkarabilirsiniz
* zaman içinde ya da belirli bir ölçüm birimine göre verilerin yönünü ve momentumunu çıkarabilirsiniz
* aykırı değerleri, sapmaları, hataları, mantıksız verileri vb. tespit edebilirsiniz
* karmaşık verileri iletişim kurmak ya da sunmak için kullanabilirsiniz

PowerPoint'te, birçok grafik türü tasarlamak için şablonlar sunan *Insert* işlevi aracılığıyla grafikler oluşturabilirsiniz. Aspose.Slides kullanarak hem standart grafikler (popüler grafik türlerine dayalı) hem de özelleştirilmiş grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Grafikler oluşturmak için [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) sınıfını kullanın. Bu sınıftaki alanlar farklı grafik türlerine karşılık gelir.
{{% /alert %}}

### **Kümelenmiş Sütun Grafikleri Oluşturma**

Bu bölüm, Aspose.Slides ile kümelenmiş sütun grafikleri oluşturmayı açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir kümelenmiş sütun grafiğinin nasıl üretildiğini görebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Dizini kullanarak bir slayta referans alın.
1. Bazı veriyle bir grafik ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.
1. Grafiğe bir başlık ekleyin.
1. Grafiğin veri çalışma sayfasına erişin.
1. Tüm varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni grafik verileri ekleyin.
1. Grafik serilerine dolgu rengi uygulayın.
1. Grafik serilerine etiketler ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu bir kümelenmiş sütun grafiği oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX dosyasını temsil eden bir sunum sınıfı örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Varsayılan verileriyle bir grafik ekler
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Grafik başlığını ayarlar
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // İlk serinin değerleri göstermesini ayarlar
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Grafik veri sayfası için dizini ayarlar
    var defaultWorksheetIndex = 0;
    // Grafik veri Çalışma Sayfasını alır
    var fact = chart.getChartData().getChartDataWorkbook();
    // Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Yeni seriler ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Yeni kategoriler ekler
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // İlk grafik serisini alır
    var series = chart.getChartData().getSeries().get_Item(0);
    // Şimdi seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Seri için doldurma rengini ayarlar
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Seri için doldurma rengini ayarlar
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Yeni seri için her kategoriye özel etiketler oluşturur
    // İlk etiketi kategori adını göstermesi için ayarlar
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Üçüncü etiket için değeri gösterir
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Grafikli sunumu kaydeder
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Saçılım (Scatter) Grafikler Oluşturma**

Saçılım grafikler (scatter plot veya x‑y grafikleri olarak da bilinir) genellikle iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için kullanılır.

Bir saçılım grafiği şu durumlarda kullanılır:

* eşleşmiş sayısal verileriniz olduğunda
* birlikte iyi eşleşen iki değişkeniniz olduğunda
* iki değişkenin ilişkili olup olmadığını belirlemek istediğinizde
* bağımsız bir değişkenin bağımlı bir değişken için birden çok değeri olduğunda

1. [Kümelenmiş Sütun Grafikleri Oluşturma](#create-clustered-column-charts) bölümündeki adımları izleyin.
2. Üçüncü adımda, bir grafik ekleyin ve grafik türünü aşağıdakilerden biri olarak belirleyin:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Saçılım grafiği temsil eder._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğrilerle bağlanmış, veri işaretçileri olan saçılım grafiği temsil eder._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğrilerle bağlanmış, veri işaretçileri olmayan saçılım grafiği temsil eder._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Çizgilerle bağlanmış, veri işaretçileri olan saçılım grafiği temsil eder._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Çizgilerle bağlanmış, veri işaretçileri olmayan saçılım grafiği temsil eder._

Bu JavaScript kodu, her seri için farklı işaretçileri olan bir saçılım grafiği oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX dosyasını temsil eden bir sunum sınıfı örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan grafiği oluşturur
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Varsayılan grafik veri çalışma sayfası dizinini alır
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alır
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demo serileri siler
    chart.getChartData().getSeries().clear();
    // Yeni seriler ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // İlk grafik serisini alır
    var series = chart.getChartData().getSeries().get_Item(0);
    // Seriye yeni bir nokta (1:3) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Yeni bir nokta (2:10) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Seri tipini değiştirir
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Grafik serisi işaretçisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);
    // Orada yeni bir nokta (5:2) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Yeni bir nokta (3:1) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Yeni bir nokta (2:2) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Yeni bir nokta (5:1) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Grafik serisi işaretçisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Pasta (Pie) Grafikler Oluşturma**

Pasta grafikler, özellikle veriler kategori etiketleriyle sayısal değerler içerdiğinde, veri bütün içindeki bölümü göstermek için en uygunudur. Ancak, verileriniz çok fazla parça veya etiket içeriyorsa, bunun yerine bir çubuk grafik kullanmayı düşünebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Pie](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Pie) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Pasta dilimlerine özel renkler uygulayarak yeni puanlar ekleyin.
9. Seriler için etiketler ayarlayın.
10. Seri etiketleri için kılavuz çizgilerini etkinleştirin.
11. Pasta dilimlerinin dönüş açısını ayarlayın.
12. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir pasta grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX dosyasını temsil eden bir sunum sınıfı örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slides = pres.getSlides().get_Item(0);
    // Varsayılan verilerle bir grafik ekler
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Grafiğin başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // İlk serinin değerleri göstermesini ayarlar
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Grafik veri sayfası için dizini ayarlar
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alır
    var fact = chart.getChartData().getChartDataWorkbook();
    // Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Yeni kategoriler ekler
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Yeni seriler ekler
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Yeni sürümde çalışmıyor
    // Yeni puanlar ekleyerek dilim renklerini ayarlar
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Dilim kenarını ayarlar
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Dilim kenarını ayarlar
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Dilim kenarını ayarlar
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Yeni seri için her kategoriye özel etiketler oluşturur
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Grafik için Lider Çizgileri gösterir
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Pasta Grafik Dilimlerinin Dönüş Açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Grafikli sunumu kaydeder
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Çizgi (Line) Grafikler Oluşturma**

Çizgi grafikler (line graph) zaman içinde değer değişimlerini göstermek istediğiniz durumlarda en uygunudur. Çizgi grafik kullanarak aynı anda büyük miktarda veriyi karşılaştırabilir, zaman içinde değişiklik ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilir ve daha fazlasını yapabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizini kullanarak bir slayta referans alın.
1. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Line](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Line) türünü belirtin.
1. Grafik veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/)) erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni grafik verileri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir çizgi grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların tirelerle birleştirilmesini istiyorsanız, tercih ettiğiniz tire türünü aşağıdaki gibi belirtebilirsiniz:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ağaç Haritası (Tree Map) Grafikler Oluşturma**

Ağaç haritası grafikleri, her kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek ve veri kategorilerinin göreceli boyutunu göstermek istediğiniz satış verileri için en uygundur.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Treemap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Treemap) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir ağaç haritası grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // dal 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // dal 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Hisse Senedi (Stock) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Yüksek‑düşük hatları formatını belirtin.
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir hisse senedi grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kutu ve Bıyık (Box and Whisker) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir kutu ve bıyık grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Huni (Funnel) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Funnel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Funnel) türünü belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir huni grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Güneş Patlaması (Sunburst) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Sunburst](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Sunburst) türünü belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir güneş patlaması grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // dal 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // dal 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Histogram Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Histogram](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Histogram) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir histogram grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Radar Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Biraz veriyle bir grafik ekleyin ve tercih ettiğiniz grafik türünü ([ChartType.Radar](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#Radar) bu örnekte) belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir radar grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Çoklu Kategori Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.ClusteredColumn](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ClusteredColumn) türünü belirtin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir çoklu kategori grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Seri ekleme
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Grafikli sunumu kaydet
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Harita (Map) Grafikler Oluşturma**

Harita grafikler coğrafi verileri görselleştirir ve bölgeler arasındaki değerleri karşılaştırmanıza yardımcı olur.

Bu JavaScript kodu bir harita grafik oluşturmayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kombinasyon (Combination) Grafikler Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki veya daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri tanımlamanıza yardımcı olur.

![The combination chart](combination_chart.png)

Aşağıdaki JavaScript kodu, PowerPoint sunumunda yukarıda gösterilen kombinasyon grafiğini oluşturur:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Grafik başlığını ayarla.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Grafik lejandını ayarla.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Varsayılan oluşturulan serileri ve kategorileri sil.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Yeni kategoriler ekle.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekle.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Yatay ekseni ayarla.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Dikey ekseni ayarla.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Dikey büyük ızgara çizgileri rengini ayarla.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // İkincil yatay ekseni ayarla.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // İkincil dikey ekseni ayarla.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Grafikleri Güncelleme**

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. İstenen grafiği bulmak için tüm şekillerde gezinin.
4. Grafik veri çalışma sayfasına erişin.
5. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.
6. Yeni bir seri ekleyin ve verilerini doldurun.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir grafiği güncellemeyi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // İlk slayt işaretçisine eriş
    var sld = pres.getSlides().get_Item(0);
    // Varsayılan verilerle grafiği al
    var chart = sld.getShapes().get_Item(0);
    // Grafik veri sayfasının dizinini ayarlama
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alıyor
    var fact = chart.getChartData().getChartDataWorkbook();
    // Grafik kategori adını değiştiriyor
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // İlk grafik serisini al
    var series = chart.getChartData().getSeries().get_Item(0);
    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Seri adını değiştiriyor
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // İkinci grafik serisini al
    series = chart.getChartData().getSeries().get_Item(1);
    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Seri adını değiştiriyor
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Şimdi yeni bir seri ekliyor
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Üçüncü grafik serisini al
    series = chart.getChartData().getSeries().get_Item(2);
    // Şimdi seri verilerini dolduruyor
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Grafikle sunumu kaydet
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik İçin Veri Aralığını Ayarlama**

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. İstenen grafiği bulmak için tüm şekillerde gezinin.
4. Grafiğin verilerine erişin ve aralığı ayarlayın.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu JavaScript kodu bir grafiğin veri aralığını ayarlamayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisine otomatik olarak farklı bir işaretçi sembolü atanır.

Bu JavaScript kodu bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // İkinci grafik serisini al
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Şimdi seri verilerini dolduruyor
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Aspose.Slides hangi grafik türlerini destekliyor?**

Aspose.Slides, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok [grafik türünü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenize olanak tanır.

**Bir slayta yeni bir grafik nasıl eklenir?**

Bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneği oluşturur, istenen slaytı diziniyle alır ve ardından grafik ekleme metodunu çağırarak grafik türünü ve başlangıç verilerini belirtirsiniz. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafikte gösterilen veriler nasıl güncellenir?**

Grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Böylece grafik, en son verileri yansıtacak şekilde programlı olarak yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, lejandlar ve diğer [biçimlendirme öğeleri](/slides/tr/nodejs-java/chart-entities/) gibi öğeleri değiştirerek grafiğin görünümünü belirli tasarım gereksinimlerinize göre uyarlayabilirsiniz.