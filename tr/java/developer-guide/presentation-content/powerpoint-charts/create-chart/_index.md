---
title: Java'da PowerPoint Sunum Grafiklerini Oluşturma veya Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/java/create-chart/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint sunumlarında grafikler oluşturun ve özelleştirin. Java'da pratik kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak nasıl grafik oluşturulacağını ve özelleştirileceğini kapsamlı bir şekilde anlatır. Bir slayda programlı olarak nasıl grafik ekleyeceğinizi, verileri nasıl dolduracağınızı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini nasıl uygulayacağınızı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmadan serileri, eksenleri ve lejantları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunmaktadır. Bu rehberi izleyerek, dinamik grafik oluşturmayı uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlıca görselleştirmenize ve bir tablo ya da elektronik tablodan hemen anlaşılmayan içgörüleri elde etmenize yardımcı olur.

**Grafik Oluşturmanın Nedenleri?**

Grafiklerle şunları yapabilirsiniz:

* büyük miktarda veriyi tek bir slaytta özetlemek, yoğunlaştırmak veya toplamak
* verideki desen ve eğilimleri ortaya çıkarmak
* zaman içinde ya da belirli bir ölçü birimine göre verinin yönünü ve ivmesini belirlemek
* aykırı değerleri, sapmaları, hataları, mantıksız verileri vb. tespit etmek
* karmaşık verileri iletmek veya sunmak

PowerPoint’te, birçok grafik tipini tasarlamak için şablonlar sunan *Ekle* işleviyle grafikler oluşturabilirsiniz. Aspose.Slides kullanarak hem popüler grafik tiplerine dayalı normal grafikler hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}

Grafik oluşturmak için [ChartType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) sınıfını kullanın. Bu sınıftaki alanlar farklı grafik tiplerine karşılık gelir.

{{% /alert %}}

### **Kümelenmiş Sütun Grafikleri Oluşturma**

Bu bölüm, Aspose.Slides kullanarak kümelenmiş sütun grafiği oluşturmayı açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir kümelenmiş sütun grafiğinin nasıl üretildiğini görebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Diziniyle slayta başvurun.  
1. Veri ekleyerek bir grafik ekleyin ve `ChartType.ClusteredColumn` tipini belirtin.  
1. Grafik için bir başlık ekleyin.  
1. Grafiğin veri çalışma sayfasına erişin.  
1. Tüm varsayılan serileri ve kategorileri temizleyin.  
1. Yeni seriler ve kategoriler ekleyin.  
1. Grafik serileri için yeni veri ekleyin.  
1. Grafik serilerine bir doldurma rengi uygulayın.  
1. Grafik serilerine etiketler ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu, bir kümelenmiş sütun grafiğinin nasıl oluşturulacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir sunum sınıfı örnekleyerek
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
    
    // Grafik veri sayfası için dizini ayarlar
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
    
    //Create yeni seri için her kategoriye özel etiketler oluşturur
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
    
    // Grafikli sunumu kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Saçılım (Scatter) Grafikler Oluşturma**
Saçılım grafikler (diğer adıyla dağılım grafiği veya x‑y grafiği), iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için sıklıkla kullanılır.

Saçılım grafiği şu durumlarda tercih edilir:

* eşleşmiş sayısal verileriniz olduğunda
* iki değişkenin birbiriyle iyi bir ilişki kurduğu durumlarda
* iki değişkenin birbiriyle ilişkili olup olmadığını belirlemek istediğinizde
* bağımlı bir değişken için birden çok değer içeren bağımsız bir değişkeniniz olduğunda

1. [Kümelenmiş Sütun Grafikleri Oluşturma](#create-clustered-column-charts) bölümündeki adımları izleyin.  
2. Üçüncü adımda, bir grafik ekleyin ve grafik tipinizi aşağıdakilerden biri olarak belirtin:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Bir saçılım grafiği temsil eder._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğri çizgilerle bağlanan, veri işaretçileri bulunan bir saçılım grafiği temsil eder._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğri çizgilerle bağlanan, veri işaretçileri olmayan bir saçılım grafiği temsil eder._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Düz çizgilerle bağlanan, veri işaretçileri bulunan bir saçılım grafiği temsil eder._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Düz çizgilerle bağlanan, veri işaretçileri olmayan bir saçılım grafiği temsil eder._

Bu Java kodu, her seri için farklı işaretçili bir saçılım grafiğinin nasıl oluşturulacağını gösterir:

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden bir sunum sınıfı örnekler
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
    
    // Seri tipini değiştirir
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Grafik seri işaretçisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    
    // Grafik seri işaretçisini değiştirir
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Pasta Grafikler Oluşturma**

Pasta grafikleri, özellikle kategorik etiketlere sahip sayısal değerler içerdiğinde veri içinde bütün‑parça ilişkisini göstermek için en uygundur. Ancak veri çok fazla parça ya da etiket içeriyorsa, çubuk grafiği tercih etmek daha mantıklı olabilir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Pie](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Pie) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Grafik için yeni puanlar ekleyin ve pasta dilimlerine özel renkler uygulayın.  
9. Seriler için etiketler ayarlayın.  
10. Seri etiketleri için lider çizgileri etkinleştirin.  
11. Pasta dilimlerinin dönüş açılarını ayarlayın.  
12. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir pasta grafiğinin nasıl oluşturulacağını gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slayta erişir
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Varsayılan veriyle bir grafik ekler
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Grafiğin başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Grafik veri sayfası için dizini ayarlar
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
    // Yeni noktalar ekleyip sektör rengini ayarlama
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
    
    // Grafik için Lider Çizgileri gösterir
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Pasta Grafik Dilimlerinin Dönüş Açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Grafik içeren sunumu kaydeder
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Çizgi Grafikler Oluşturma**

Çizgi grafikler (diğer adıyla çizgi diyagramlar), zaman içinde değer değişimlerini göstermek istediğiniz durumlar için en uygundur. Çizgi grafiği kullanarak aynı anda büyük miktarda veriyi karşılaştırabilir, zaman içindeki değişim ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Diziniyle slayta başvurun.  
1. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Line](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Line) tipini belirtin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir çizgi grafiğinin nasıl oluşturulacağını gösterir:

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

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz, kesintisiz çizgilerle birleştirilir. Noktaların kesikli çizgilerle birleştirilmesini isterseniz, tercih ettiğiniz kesik çizgi tipini şu şekilde belirtebilirsiniz:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ağaç Haritası (Tree Map) Grafikler Oluşturma**

Ağaç haritası grafikler, her kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek ve veri kategorilerinin göreceli boyutlarını göstermek istediğiniz satış verileri için idealdir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Treemap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Treemap) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir ağaç haritası grafiğinin nasıl oluşturulacağını gösterir:

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

### **Hisse Senedi (Stock) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#OpenHighLowClose) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Yüksek‑düşük çizgi biçimini belirtin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir hisse senedi grafiğinin nasıl oluşturulacağını gösterir:

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

### **Kutu ve Bıyık (Box and Whisker) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#BoxAndWhisker) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir kutu ve bıyık grafiğinin nasıl oluşturulacağını gösterir:

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

### **Huni (Funnel) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Funnel](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Funnel) tipini belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir huni grafiğinin nasıl oluşturulacağını gösterir:

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

### **Güneş Patlaması (Sunburst) Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Sunburst](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Sunburst) tipini belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir güneş patlaması grafiğinin nasıl oluşturulacağını gösterir:

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

### **Histogram Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.Histogram](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Histogram) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir histogram grafiğinin nasıl oluşturulacağını gösterir:

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

### **Radar Grafikler Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Biraz veri ekleyerek bir grafik ekleyin ve tercih ettiğiniz grafik tipini ([ChartType.Radar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#Radar) bu örnek için) belirtin.  
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir radar grafiğinin nasıl oluşturulacağını gösterir:

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

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Varsayılan veriyle bir grafik ekleyin ve [ChartType.ClusteredColumn](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/#ClusteredColumn) tipini belirtin.  
4. Grafik veri çalışma kitabı olan [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) erişin.  
5. Varsayılan serileri ve kategorileri temizleyin.  
6. Yeni seriler ve kategoriler ekleyin.  
7. Grafik serileri için yeni veri ekleyin.  
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, çok kategorili bir grafiğin nasıl oluşturulacağını gösterir:

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

### **Harita Grafikler Oluşturma**

Harita grafikler, coğrafi verileri görselleştirir ve bölgeler arasındaki değerleri karşılaştırmanıza yardımcı olur.

Bu Java kodu, bir harita grafiğinin nasıl oluşturulacağını gösterir:

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

### **Kombinasyon Grafikler Oluşturma**

Kombinasyon (veya combo) grafiği, tek bir grafikte iki ya da daha fazla grafik tipini birleştirir. Bu grafik, birden çok veri kümesini vurgulamanıza, karşılaştırmanıza veya farklılıklarını incelemenize olanak tanır ve aralarındaki ilişkileri tanımlamanıza yardımcı olur.

![Kombinasyon grafiği](combination_chart.png)

Aşağıdaki Java kodu, yukarıdaki kombinasyon grafiğinin bir PowerPoint sunumunda nasıl oluşturulacağını gösterir:

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

    // Grafik başlığını ayarla.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Grafik lejantını ayarla.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Varsayılan oluşturulan serileri ve kategorileri sil.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Yeni kategoriler ekle.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // İlk seriyi ekle.
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
    // Yatay ekseni ayarla.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Dikey ekseni ayarla.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().setFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Dikey ana ızgara çizgilerinin rengini ayarla.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // İkincil yatay ekseni ayarla.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // İkincil dikey ekseni ayarla.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
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

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Tüm şekiller arasında dolaşarak istenen grafiği bulun.  
4. Grafik veri çalışma sayfasına erişin.  
5. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.  
6. Yeni bir seri ekleyin ve verilerini doldurun.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir grafiğin nasıl güncelleneceğini gösterir:

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

    // İlk grafik serisini alır
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Seri adını değiştiriyor
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1);

    // Şimdi seri verilerini güncelliyor
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Seri adını değiştiriyor
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Şimdi, yeni bir seri ekliyor
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Üçüncü grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(2);

    // Şimdi seri verilerini dolduruyor
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Grafikli sunumu kaydeder
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafiği içeren sunumu temsil eden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta başvurun.  
3. Tüm şekiller arasında dolaşarak istenen grafiği bulun.  
4. Grafiğin verisine erişin ve aralığı ayarlayın.  
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu, bir grafik için veri aralığının nasıl ayarlanacağını gösterir:

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

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisi otomatik olarak farklı bir işaretçi simgesi alır.

Bu Java kodu, bir grafik serisinin işaretçisinin otomatik olarak nasıl ayarlanacağını gösterir:

```java
import com.aspose.slides.*;

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
    //İkinci grafik serisini al
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Şimdi seri verilerini dolduruyor
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

**Aspose.Slides tarafından desteklenen grafik türleri nelerdir?**

Aspose.Slides, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok [grafik türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik tipini seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Grafik eklemek için önce [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturur, istediğiniz slaytı diziniyle alırsınız ve ardından grafik ekleme metodunu çağırarak grafik tipini ve başlangıç verisini belirlersiniz. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafiğin gösterdiği veriler nasıl güncellenir?**

Grafiğin verilerini güncellemek için veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/)) erişir, varsayılan serileri ve kategorileri temizler ve ardından özelleştirilmiş verilerinizi eklersiniz. Böylece grafiği en yeni verileri yansıtacak şekilde yenileyebilirsiniz.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, lejantlar ve diğer [biçimlendirme öğeleri](/slides/tr/java/chart-entities/) gibi unsurları değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre uyarlayabilirsiniz.