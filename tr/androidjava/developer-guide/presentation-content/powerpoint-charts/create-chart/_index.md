---
title: Android'de PowerPoint Sunum Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/androidjava/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağılmış grafik
- pasta grafik
- çizgi grafik
- ağaç harita grafik
- hisse senedi grafik
- kutu ve bıyık grafik
- huni grafik
- güneş patlaması grafik
- histogram grafik
- radar grafik
- çoklu kategori grafik
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides kullanarak PowerPoint sunumlarında grafikler oluşturun ve özelleştirin. Pratik Java kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafikler oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Bir slayta programlı olarak grafik eklemeyi, veri doldurmayı ve belirli tasarım gereksinimlerinize uyması için çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, ayrıntılı kod örnekleri, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve açıklamaları yapılandırmaya kadar her adımı gösterir. Bu rehberi izleyerek, uygulamalarınıza dinamik grafik üretimini entegre etme konusunda sağlam bir anlayış elde edecek ve veri odaklı sunumlar oluşturma sürecini hızlandıracaksınız.

## **Grafik Oluşturma**
Grafikler, insanların veriyi hızlıca görselleştirip içgörü elde etmelerine yardımcı olur; bu, bir tablo veya elektronik tablodan hemen anlaşılmayabilir. 


**Neden Grafik Oluşturmalısınız?**

Grafik kullanarak

* büyük miktarda veriyi tek bir sunum slaytında toplamak, sıkıştırmak veya özetlemek
* verideki kalıpları ve eğilimleri ortaya çıkarmak
* verinin zaman içindeki yönünü ve momentumunu ya da belirli bir ölçü birimiyle ilişkisini çıkarmak
* aykırı değerleri, sapmaları, hataları, anlamsız verileri vb. tespit eder
* karmaşık verileri iletmek veya sunmak

PowerPoint'te, birçok grafik tipini tasarlamak için kullanılan şablonları sağlayan ekleme işlevi aracılığıyla grafikler oluşturabilirsiniz. Aspose.Slides kullanarak, popüler grafik tiplerine dayalı normal grafikler ve özel grafikler oluşturabilirsiniz. 

{{% alert color="info" %}} 
Grafik oluşturmanıza olanak sağlamak için Aspose.Slides, [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType) sınıfını sunar. Bu sınıftaki alanlar farklı grafik tiplerine karşılık gelir.
{{% /alert %}} 

### **Normal Grafikler Oluşturma**

_Adımlar: Grafik Oluştur_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Grafiği Oluştur</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Adımlar:</em> Java'da Sunum Grafiği Oluştur</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Grafiği Oluştur</strong></a>

**Kod Adımları:**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. Bir grafik ekleyin, bazı verilerle ve istediğiniz grafik tipini belirterek.  
4. Grafiğe bir başlık ekleyin.  
5. Grafik veri çalışma sayfasına erişin.  
6. Tüm varsayılan serileri ve kategorileri temizleyin.  
7. Yeni seriler ve kategoriler ekleyin.  
8. Grafik serileri için yeni grafik verileri ekleyin.  
9. Grafik serileri için bir dolgu rengi ekleyin.  
10. Grafik serileri için etiketler ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, normal bir grafik oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bir PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Varsayılan verileriyle bir grafik ekler
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Grafik başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Grafiğin veri sayfası için dizini ayarlar
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Yeni seriler ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Yeni kategoriler ekler
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // İlk grafik serisini alır
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Şimdi seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Yeni seri için her kategoriye özel etiketler oluşturur
    // İlk etiketi kategori adını gösterecek şekilde ayarlar
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Üçüncü etiket için değeri gösterir
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Sunumu grafikle birlikte kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Dağılmış Grafikler Oluşturma**
Dağılmış grafikler (dağılmış çizimler veya x-y grafikleri olarak da bilinir) genellikle iki değişken arasındaki kalıpları kontrol etmek veya korelasyonları göstermek için kullanılır. 

Aşağıdaki durumlarda dağılmış grafik kullanmak isteyebilirsiniz  

* eşleştirilmiş sayısal verileriniz varsa  
* birlikte iyi eşleşen 2 değişkeniniz varsa  
* 2 değişkenin ilişkili olup olmadığını belirlemek istiyorsanız  
* bağımlı bir değişken için birden fazla değere sahip bağımsız bir değişkeniniz varsa  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Adımlar:</em> Java'da Dağılmış Grafik Oluştur</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Dağılmış Grafik Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Dağılmış Grafik Oluştur</strong></a>

1. Lütfen yukarıda [Normal Grafikler Oluşturma](#creating-normal-charts) adımlarını izleyin.  
2. Üçüncü adım için, bazı verilerle bir grafik ekleyin ve grafik tipinizi aşağıdakilerden biri olarak belirleyin  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Dağılmış grafiği temsil eder._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğrilerle bağlanan, veri işaretleyicileri olan dağılmış grafiği temsil eder._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğrilerle bağlanan, veri işaretleyicileri olmayan dağılmış grafiği temsil eder._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Çizgilerle bağlanan, veri işaretleyicileri olan dağılmış grafiği temsil eder._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Çizgilerle bağlanan, veri işaretleyicileri olmayan dağılmış grafiği temsil eder._  

Bu Java kodu, farklı işaretleyici serileriyle dağılmış grafikler oluşturmayı gösterir: 

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide slide = pres.getSlides().get_Item(0);

    // Varsayılan grafiği oluşturur
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Varsayılan grafik veri çalışma sayfası dizinini alır
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo serisini siler
    chart.getChartData().getSeries().clear();
    
    // Yeni seriler ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // İlk grafik serisini alır
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Seriye yeni bir nokta (1:3) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Yeni bir nokta (2:10) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Serinin tipini değiştirir
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Grafik serisi işaretleyicisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Oraya yeni bir nokta (5:2) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Yeni bir nokta (3:1) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Yeni bir nokta (2:2) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Yeni bir nokta (5:1) ekler
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Grafik serisi işaretleyicisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Pasta Grafiklerini Oluşturma**

Pasta grafikleri, özellikle veride kategorik etiketler ve sayısal değerler olduğunda, parçadan bütüne ilişkiyi göstermek için en iyisidir. Ancak, verinizde çok fazla parça veya etiket varsa, bunun yerine çubuk grafik kullanmayı düşünebilirsiniz.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Adımlar:</em> Java'da Pasta Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Pasta Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Pasta Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip (bu örnekte [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).Pie) ile varsayılan veri içeren bir grafik ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni grafik verileri ekleyin.  
8. Pasta dilimlerinin bölümlerine özel renkler ekleyerek yeni puanlar ekleyin.  
9. Seriler için etiketleri ayarlayın.  
10. Seri etiketleri için gösterge çizgilerini ayarlayın.  
11. Pasta grafik slaytları için döndürme açısını ayarlayın.  
12. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir pasta grafik oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Varsayılan verilerle bir grafik ekler
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Grafiğin başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Grafiğin veri sayfası dizinini ayarlar
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Yeni kategoriler ekler
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Yeni seriler ekler
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Seri verilerini doldurur
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Yeni sürümde çalışmıyor
    // Yeni noktalar ekleyip sektör rengini ayarlar
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Sektör kenarlığını ayarlar
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Sektör kenarlığını ayarlar
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Sektör kenarlığını ayarlar
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Yeni seri için her kategoriye özel etiketler oluşturur
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Grafik için gösterge çizgilerini gösterir
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Pasta grafik dilimleri için döndürme açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Grafikli sunumu kaydeder
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Çizgi Grafiklerini Oluşturma**

Çizgi grafikler (çizgi grafikleri olarak da bilinir), zaman içinde değer değişimini göstermek istediğiniz durumlarda en iyisidir. Çizgi grafiği kullanarak, çok fazla veriyi aynı anda karşılaştırabilir, zaman içinde değişimleri ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın indeks aracılığıyla referansını alın.  
1. İstenilen tip (`ChartType.Line`) ile varsayılan veri içeren bir grafik ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir çizgi grafik oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Varsayılan olarak, çizgi grafik üzerindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların kesikli çizgilerle birleştirilmesini istiyorsanız, tercih ettiğiniz kesik çizgi tipini şu şekilde belirtebilirsiniz:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ağaç Haritası Grafiklerini Oluşturma**

Ağaç haritası grafikleri, satış verilerinde veri kategorilerinin göreceli boyutunu göstermek ve aynı anda her kategoriye büyük katkı sağlayan öğelere hızlıca dikkat çekmek için en iyisidir. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Adımlar:</em> Java'da Ağaç Haritası Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Ağaç Haritası Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Ağaç Haritası Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip (bu örnekte [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).TreeMap) ile varsayılan veri içeren bir grafik ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni grafik verileri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //dal 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //dal 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hisse Senedi Grafiklerini Oluşturma**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Adımlar:</em> Java'da Hisse Senedi Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Hisse Senedi Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Hisse Senedi Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).OpenHighLowClose) ile varsayılan veri içeren bir grafik ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. HiLowLines biçimini belirtin.  
9. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Hisse senedi grafiği oluşturmak için kullanılan örnek Java kodu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kutu ve Bıyık Grafiklerini Oluşturma**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Adımlar:</em> Java'da Kutu ve Bıyık Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Kutu ve Bıyık Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Kutu ve Bıyık Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).BoxAndWhisker) ile varsayılan veri içeren bir grafik ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir kutu ve bıyık grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Huni Grafiklerini Oluşturma**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Adımlar:</em> Java'da Huni Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Huni Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Huni Grafiği Oluştur</strong></a>


1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).Funnel) ile varsayılan veri içeren bir grafik ekleyin.  
4. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Java kodu, bir huni grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Güneş Patlaması Grafiklerini Oluşturma**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Adımlar:</em> Java'da Güneş Patlaması Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Güneş Patlaması Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Güneş Patlaması Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip (bu örnekte [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).sunburst) ile varsayılan veri ekleyin.  
4. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //dal 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //dal 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Histogram Grafiklerini Oluşturma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Adımlar:</em> Java'da Histogram Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Histogram Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Histogram Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).Histogram) ile varsayılan veri ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir histogram grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Radar Grafiklerini Oluşturma**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Adımlar:</em> Java'da Radar Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Radar Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Radar Grafiği Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. Bazı veri ile bir grafik ekleyin ve tercih ettiğiniz grafik tipini (`ChartType.Radar`) belirtin.  
4. Değiştirilmiş sunumu PPTX dosyasına kaydedin  

Bu Java kodu, bir radar grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Çok Kategorili Grafikler Oluşturma**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Adımlar:</em> Java'da Çok Kategorili Grafik Oluştur</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Çok Kategorili Grafik Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Çok Kategorili Grafik Oluştur</strong></a>

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen tip ([ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ChartType).ClusteredColumn) ile varsayılan veri ekleyin.  
4. Grafik veri [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) öğesine erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyasına kaydedin.  

Bu Java kodu, bir çok kategori grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Grafikli sunumu kaydet
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Harita Grafiklerini Oluşturma**

Harita grafiği, veri içeren bir alanın görselleştirmesidir. Harita grafikleri, coğrafi bölgeler arasındaki veri veya değerleri karşılaştırmak için en iyisidir.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Adımlar:</em> Java'da Harita Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Harita Grafiği Oluştur</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Harita Grafiği Oluştur</strong></a>

Bu Java kodu, bir harita grafiği oluşturmayı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik tipini birleştirir. Bu grafik, birden fazla veri seti arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve bu sayede ilişkileri tanımlamanıza yardımcı olur.

![The combination chart](combination_chart.png)

Aşağıdaki Java kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Grafiğin başlığını ayarlar.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Grafiğin açıklama kutusunu ayarlar.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Varsayılan oluşturulan serileri ve kategorileri siler.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Yeni kategoriler ekler.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekler.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Yatay ekseni ayarlar.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Dikey ekseni ayarlar.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Dikey ana ızgara çizgilerinin rengini ayarlar.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // İkincil yatay ekseni ayarlar.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // İkincil dikey ekseni ayarlar.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Grafikleri Güncelleme**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Grafiği Güncelle</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Adımlar:</em> Java'da Sunum Grafiği Güncelle</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Adımlar:</em> Java'da PowerPoint Sunum Grafiği Güncelle</strong></a>

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun.  
2. İndeksini kullanarak bir slaytın referansını alın.  
3. İstenilen grafiği bulmak için tüm şekiller arasında dolaşın.  
4. Grafik veri çalışma sayfasına erişin.  
5. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.  
6. Yeni bir seri ekleyin ve verilerini doldurun.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, bir grafiği güncellemeyi gösterir:

```java
import com.aspose.slides.*;

// Güncellenecek grafiği içeren sunumu açar
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // İlk slayta erişir
    ISlide sld = pres.getSlides().get_Item(0);

    // Slayttan grafiği alır
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Grafik veri sayfasının dizinini ayarlar
    int defaultWorksheetIndex = 0;

    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Grafik kategori adını değiştirir
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // İlk grafik serisini al
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Seri adını değiştiriyor
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // İkinci grafik serisini al
    series = chart.getChartData().getSeries().get_Item(1);

    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Seri adını değiştiriyor
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

    chart.setType(ChartType.ClusteredCylinder);

    // Grafikli sunumu kaydediyor
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Grafik İçin Veri Aralığını Belirleme**

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafik içeren bir sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun.  
2. Slaytın indeks aracılığıyla referansını alın.  
3. İstenilen grafiği bulmak için tüm şekiller arasında dolaşın.  
4. Grafik verisine erişin ve aralığı ayarlayın.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu Java kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```java
import com.aspose.slides.*;

// Grafiği içeren sunumu açar
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafiklerde Varsayılan İşaretleyicileri Kullanma**
Grafiklerde varsayılan bir işaretleyici kullandığınızda, her grafik serisi otomatik olarak farklı varsayılan işaretleyici sembolleri alır.

Bu Java kodu, bir grafik serisi işaretleyicisini otomatik olarak ayarlamayı gösterir:

```java
import com.aspose.slides.*;

// Grafiği içeren sunumu açar
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Şimdi seri verilerini dolduruyor
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### Aspose.Slides hangi grafik tiplerini destekliyor?

Aspose.Slides, çubuk, çizgi, pasta, alan, dağılım, histogram, radar ve daha birçok [grafik tipi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) dahil olmak üzere geniş bir yelpazeyi destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik tipini seçmenizi sağlar.

### Bir slayta yeni bir grafik nasıl eklenir?

Grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturur, istediğiniz slaytı indeksine göre alır ve ardından grafik tipini ve başlangıç verilerini belirterek grafik ekleme metodunu çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

### Bir grafikte gösterilen veriler nasıl güncellenir?

Bir grafiğin verileri, veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/)) erişilerek, varsayılan seriler ve kategoriler temizlenip, ardından özel veriler eklenerek güncellenebilir. Bu, grafiği en son verileri yansıtacak şekilde yenilemenizi sağlar.

### Grafiğin görünümü özelleştirilebilir mi?

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, açıklamalar ve diğer [biçimlendirme öğeleri](/slides/tr/androidjava/chart-entities/) gibi unsurları değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre uyarlayabilirsiniz.