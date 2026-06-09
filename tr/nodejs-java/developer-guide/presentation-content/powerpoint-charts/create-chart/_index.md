---
title: JavaScript'te PowerPoint Sunum Grafikleri Oluşturma veya Güncelleme
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
- dağılım grafiği
- pasta grafiği
- çizgi grafiği
- ağaç harita grafiği
- hisse senedi grafiği
- kutu ve whisker grafiği
- huni grafiği
- sunburst grafiği
- histogram grafiği
- radar grafiği
- çok kategorili grafik
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint sunumlarında grafik oluşturun ve özelleştirin. JavaScript'te pratik kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir grafiği slayta programlı olarak eklemeyi, verilerle doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu rehberi izleyerek, dinamik grafik oluşturmayı uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini hızlandıracaksınız.

## **Grafik Oluşturma**
Grafikler, verileri hızlı bir şekilde görselleştirmenize ve tablolar ya da elektronik tablolar üzerinden hemen fark edilmeyen içgörüler elde etmenize yardımcı olur. 


**Neden Grafik Oluşturmalısınız?**

Grafikler sayesinde

* bir sunumdaki tek bir slaytta büyük miktarda veriyi toplar, özetler veya sentezlersiniz
* verideki kalıpları ve eğilimleri ortaya çıkarırsınız
* zaman içinde ya da belirli bir ölçüm birimine göre verinin yönünü ve ivmesini çözümlersiniz
* aykırı değerleri, sapmaları, hataları, mantıksız verileri vb. tespit edersiniz
* karmaşık verileri iletişim kurar ya da sunarsınız

PowerPoint’te, çeşitli grafik türlerini tasarlamak için şablonlar sunan ekleme işlevi aracılığıyla grafik oluşturabilirsiniz. Aspose.Slides kullanarak, popüler grafik türlerine dayalı normal grafikler ve özel grafikler oluşturabilirsiniz. 

{{% alert color="primary" %}} 
Grafik oluşturmanıza olanak tanımak için Aspose.Slides, [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType) sınıfını sağlar. Bu sınıfın altındaki alanlar farklı grafik türlerine karşılık gelir. 
{{% /alert %}} 

### **Normal Grafik Oluşturma**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Grafiği Oluştur</em></strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Adımlar: JavaScript’te Sunum Grafiği Oluştur</em></strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Grafiği Oluştur</em></strong></a>

_Code Steps:_

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. Bazı verilerle bir grafik ekleyin ve tercih ettiğiniz grafik tipini belirtin. 
4. Grafik için bir başlık ekleyin. 
5. Grafik veri çalışma sayfasına erişin.
6. Varsayılan tüm serileri ve kategorileri temizleyin.
7. Yeni seriler ve kategoriler ekleyin.
8. Grafik serileri için yeni veri ekleyin.
9. Grafik serileri için bir dolgu rengi ekleyin.
10. Grafik serileri için etiketler ekleyin. 
11. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Bu JavaScript kodu, normal bir grafik oluşturmayı gösterir:

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Varsayılan verileriyle bir grafik ekler
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Grafik başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // İlk seriyi değerleri gösterecek şekilde ayarlar
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Grafik veri sayfası için indeksi ayarlar
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alır
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
    // Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Yeni seri için her kategoriye özel etiketler oluşturur
    // İlk etiketi kategori adını gösterecek şekilde ayarlar
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

### **Dağılım Grafikleri Oluşturma**
Dağılım grafikleri (scatter plot ya da x‑y grafikleri olarak da bilinir) genellikle iki değişken arasındaki kalıpları kontrol etmek veya korelasyonları göstermek için kullanılır. 

Aşağıdaki durumlarda dağılım grafiği kullanmak isteyebilirsiniz

* eşleştirilmiş sayısal verileriniz olduğunda
* birlikte iyi eşleşen 2 değişkeniniz olduğunda
* 2 değişkenin ilişkili olup olmadığını belirlemek istediğinizde
* bağımlı bir değişken için birden çok değer içeren bağımsız bir değişkeniniz olduğunda

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Adımlar: JavaScript’te Dağılım Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Dağılım Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Dağılım Grafiği Oluştur</em></strong></a>

1. Yukarıda **Normal Grafik Oluşturma** bölümünde belirtilen adımları izleyin
2. Üçüncü adımda, bir grafik ekleyin ve grafik tipini aşağıdakilerden biri olarak belirtin
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Dağılım Grafiği temsil eder._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğrilerle bağlanmış, veri işaretçileri olan Dağılım Grafiği temsil eder._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğrilerle bağlanmış, veri işaretçileri olmayan Dağılım Grafiği temsil eder._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Çizgilerle bağlanmış, veri işaretçileri olan Dağılım Grafiği temsil eder._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Çizgilerle bağlanmış, veri işaretçileri olmayan Dağılım Grafiği temsil eder._

Bu JavaScript kodu, farklı işaretçi serileriyle dağılım grafikleri oluşturmayı gösterir:

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slide = pres.getSlides().get_Item(0);
    // Varsayılan grafiği oluşturur
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Varsayılan grafik veri çalışma sayfası indeksini alır
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını alır
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demo serisini siler
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
    // Serinin tipini değiştirir
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

### **Pasta Grafikleri Oluşturma**

Pasta grafikleri, özellikle veriler kategorik etiketler ve sayısal değerler içerdiğinde, bütün‑parça ilişkisini göstermek için en uygunudur. Ancak, veriniz çok sayıda parça ya da etiket içeriyorsa, bunun yerine çubuk grafik kullanmayı düşünebilirsiniz.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Adımlar: JavaScript’te Pasta Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Pasta Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Pasta Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre edinin.
3. İstenilen tip (bu durumda [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).Pie) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verisi ekleyin.
8. Pasta dilimlerine özel renkler ekleyerek yeni noktalar ekleyin.
9. Seriler için etiketler ayarlayın.
10. Seriler etiketleri için yönlendirme çizgileri ayarlayın.
11. Pasta grafik slaytları için döndürme açısını ayarlayın.
12. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu JavaScript kodu, pasta grafiği oluşturmayı gösterir:

```javascript
// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var slides = pres.getSlides().get_Item(0);
    // Varsayılan veriyle bir grafik ekler
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Grafik başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // İlk seriyi değerleri gösterecek şekilde ayarlar
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Grafiğin veri sayfası için indeksi ayarlar
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
    // Yeni noktalar ekleniyor ve sektör rengi ayarlanıyor
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Sektör kenarlığını ayarlar
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Sektör kenarlığını ayarlar
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Sektör kenarlığını ayarlar
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
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
    // Pasta Grafik Sektörleri için Dönüş Açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Grafikli sunumu kaydeder
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Çizgi Grafikleri Oluşturma**

Çizgi grafikleri (line graph) zaman içinde değer değişimlerini göstermek istediğiniz durumlarda en uygun olanlardır. Çizgi grafiği kullanarak, aynı anda çok fazla veriyi karşılaştırabilir, zaman içindeki değişim ve trendleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Bir slaytın referansını indeksine göre alın.
1. İstenilen tip (`ChartType.Line`) ile varsayılan veri içeren bir grafik ekleyin.
1. Grafik veri IChartDataWorkbook ’a erişin.
1. Varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni veri ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu JavaScript kodu, çizgi grafiği oluşturmayı gösterir:

```javascript
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

Varsayılan olarak, çizgi grafiğindeki noktalar düz kesintisiz çizgilerle birleştirilir. Noktaların noktalı çizgilerle birleştirilmesini istiyorsanız, tercih ettiğiniz dash tipini aşağıdaki şekilde belirtebilirsiniz:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Ağaç Harita Grafikleri Oluşturma**

Ağaç harita grafikleri, satış verileri gibi kategori boyutlarını göstermek ve aynı anda her kategoriye büyük katkı sağlayan öğelere hızlıca dikkat çekmek istediğinizde en uygunudur. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Adımlar: JavaScript’te Ağaç Harita Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Ağaç Harita Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Ağaç Harita Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).TreeMap) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Bu JavaScript kodu, ağaç harita grafiği oluşturmayı gösterir:

```javascript
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

### **Hisse Senedi Grafikleri Oluşturma**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Adımlar: JavaScript’te Hisse Senedi Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Hisse Senedi Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Hisse Senedi Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre edinin.
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).OpenHighLowClose) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. HiLowLines biçimini belirleyin.
9. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Hisse senedi grafiği oluşturmak için kullanılan örnek JavaScript kodu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

### **Kutu ve Whisker Grafikleri Oluşturma**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Adımlar: JavaScript’te Kutu ve Whisker Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Kutu ve Whisker Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Kutu ve Whisker Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).BoxAndWhisker) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Bu JavaScript kodu, kutu ve whisker grafiği oluşturmayı gösterir:

```javascript
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

### **Huni Grafikleri Oluşturma**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Adımlar: JavaScript’te Huni Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Huni Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Huni Grafiği Oluştur</em></strong></a>


1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).Funnel) ile varsayılan veri içeren bir grafik ekleyin.
4. Değiştirilmiş sunumu bir PPTX dosyasına yazın

JavaScript kodu, huni grafiği oluşturmayı gösterir:

```javascript
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

### **Sunburst Grafikleri Oluşturma**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Adımlar: JavaScript’te Sunburst Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunburst Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Sunburst Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenilen tip (bu durumda [ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).sunburst) ile varsayılan veri içeren bir grafik ekleyin.
4. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Bu JavaScript kodu, sunburst grafiği oluşturmayı gösterir:

```javascript
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

### **Histogram Grafikleri Oluşturma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Adımlar: JavaScript’te Histogram Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Histogram Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Histogram Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).Histogram) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Bu JavaScript kodu, histogram grafiği oluşturmayı gösterir:

```javascript
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

### **Radar Grafikleri Oluşturma**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Adımlar: JavaScript’te Radar Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Radar Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Radar Grafiği Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın. 
3. Bazı veri ekleyerek ve tercih ettiğiniz grafik tipini (`ChartType.Radar`) belirterek bir grafik ekleyin.
4. Değiştirilmiş sunumu bir PPTX dosyasına yazın

Bu JavaScript kodu, radar grafiği oluşturmayı gösterir:

```javascript
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

### **Çok Kategorili Grafikler Oluşturma**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Adımlar: JavaScript’te Çok Kategorili Grafik Oluştur</em></strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Çok Kategorili Grafik Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Çok Kategorili Grafik Oluştur</em></strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın. 
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartType).ClusteredColumn) ile varsayılan veri içeren bir grafik ekleyin.
4. Grafik veri [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) ’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni veri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu JavaScript kodu, çok kategorili grafik oluşturmayı gösterir:

```javascript
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

### **Harita Grafiklerini Oluşturma**

Harita grafiği, veri içeren bir alanın görselleştirilmesidir. Coğrafi bölgeler arasında veri ya da değerleri karşılaştırmak için en uygunudur.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Adımlar: JavaScript’te Harita Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Harita Grafiği Oluştur</em></strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Harita Grafiği Oluştur</em></strong></a>

Bu JavaScript kodu, harita grafiği oluşturmayı gösterir:

```javascript
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

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik tipini birleştirir. Bu grafik, iki veya daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri tanımlamanıza yardımcı olur.

![The combination chart](combination_chart.png)

Aşağıdaki JavaScript kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda nasıl oluşturacağınızı gösterir:

```js
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

    // Grafiğin başlığını ayarla.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Grafiğin lejandını ayarla.
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

    // Dikey ana ızgara çizgileri rengini ayarla.
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

## **Grafik Güncelleme**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Grafiği Güncelle</em></strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Adımlar: JavaScript’te Sunum Grafiği Güncelle</em></strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Adımlar: JavaScript’te PowerPoint Sunum Grafiği Güncelle</em></strong></a>

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Index kullanarak bir slaytın referansını alın.
3. İstenen grafiği bulmak için tüm şekiller arasında dolaşın.
4. Grafik veri çalışma sayfasına erişin.
5. Seri değerlerini değiştirerek grafik veri serisini düzenleyin.
6. Yeni bir seri ekleyin ve verileri doldurun.
7. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Bu JavaScript kodu, bir grafiği güncellemeyi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // İlk slayt işaretleyicisine eriş
    var sld = pres.getSlides().get_Item(0);
    // Varsayılan verilerle grafiği al
    var chart = sld.getShapes().get_Item(0);
    // Grafik veri sayfasının indeksini ayarlama
    var defaultWorksheetIndex = 0;
    // Grafik veri çalışma sayfasını elde et
    var fact = chart.getChartData().getChartDataWorkbook();
    // Grafik kategori adını değiştir
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // İlk grafik serisini al
    var series = chart.getChartData().getSeries().get_Item(0);
    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Seri adını değiştir
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // İkinci grafik serisini al
    series = chart.getChartData().getSeries().get_Item(1);
    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Seri adını değiştir
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
    // Grafikli sunumu kaydet
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafikler İçin Veri Aralığını Ayarlama**

Bir grafik için veri aralığını ayarlamak için şunları yapın:

1. Grafiği içeren bir sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstenen grafiği bulmak için tüm şekiller arasında dolaşın.
4. Grafik verisine erişin ve aralığı ayarlayın.
5. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu JavaScript kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
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
Grafiklerde varsayılan bir işaretçi kullandığınızda, her grafik serisi otomatik olarak farklı varsayılan işaretçi sembolleri alır.

Bu JavaScript kodu, bir grafik serisine otomatik olarak işaretçi atamayı gösterir:

```javascript
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

**Aspose.Slides hangi grafik tiplerini destekliyor?**

Aspose.Slides, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha fazlası dahil olmak üzere geniş bir grafik tipi yelpazesini destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınız için en uygun grafik tipini seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Bir grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturur, istediğiniz slaytı indeksine göre alır ve ardından grafik tipini ve başlangıç verilerini belirterek grafiği ekleyen yöntemi çağırırsınız. Bu süreç, grafiği doğrudan sunumunuza entegre eder.

**Grafikte gösterilen veriler nasıl güncellenir?**

Grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip ardından kendi verilerinizi ekleyerek güncelleyebilirsiniz. Bu, grafiği programlı olarak en son verileri yansıtacak şekilde yenilemenizi sağlar.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer biçimlendirme öğelerini ihtiyacınıza göre değiştirerek grafiğin görünümünü tasarım gereksinimlerinize uyacak şekilde özelleştirebilirsiniz.