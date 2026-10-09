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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Pratik Java kod örnekleriyle grafik ekleyin, biçimlendirin ve düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir kılavuz sunar. Bir slayta programlı olarak grafik eklemeyi, verileri doldurmayı ve belirli tasarım gereksinimlerinize göre çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan seriler, eksenler ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunur. Bu kılavuzu izleyerek, dinamik grafik oluşturmayı uygulamalarınıza entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini kolaylaştıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek bir tablo veya elektronik tablodan hemen fark edilmeyen içgörüler elde etmeyi sağlar.

**Grafik Oluşturmanın Nedenleri**

Grafikler kullanarak:

* bir sunumdaki tek bir slaytta büyük miktarda veriyi toplulaştırabilir, sıkıştırabilir veya özetleyebilirsiniz
* veri içindeki desenleri ve eğilimleri ortaya çıkarabilirsiniz
* zaman içinde veya belirli bir ölçü birimine göre verinin yönünü ve ivmesini belirleyebilirsiniz
* aykırı değerleri, sapmaları, hataları, anlamsız verileri vb. tespit edebilirsiniz
* karmaşık verileri iletişim kurabilir veya sunabilirsiniz

PowerPoint’te, *Insert* işlevi sayesinde birçok grafik türü için şablonlar sunulur. Aspose.Slides kullanarak hem popüler grafik türlerine dayalı normal grafikler hem de özel grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}
Grafik oluşturmak için [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) sınıfını kullanın. Bu sınıftaki alanlar farklı grafik türlerine karşılık gelir.
{{% /alert %}}

### **Sütun Gruplu Grafik Oluşturma**

Bu bölüm, Aspose.Slides kullanarak sütun grupla grafiklerinin nasıl oluşturulacağını açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seriler, kategoriler ve stil gibi öğeleri özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir sütun grupla grafiğinin nasıl üretildiğini görebilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Bir grafik ekleyin, bazı veriler ekleyin ve `ChartType.ClusteredColumn` türünü belirtin.
1. Grafiğe bir başlık ekleyin.
1. Grafiğin veri çalışma sayfasına erişin.
1. Varsayılan tüm serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni grafik verileri ekleyin.
1. Grafik serilerine bir doldurma rengi uygulayın.
1. Grafik serilerine etiketler ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu C# kodu bir sütun grupla grafik oluşturmayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX dosyasını temsil eden bir sunum sınıfını örnekler
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
    
    // Yeni seri için her kategoriye özel etiketler oluşturur
    // İlk etiketi Kategori adını gösterecek şekilde ayarlar
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Üçüncü etiket için değeri gösterir
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Sunumu grafik ile kaydeder
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Serpme Grafik Oluşturma**

Serpme grafikler (diğer adıyla dağılım grafikleri veya x‑y grafikleri) iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için sıkça kullanılır.

Aşağıdaki durumlarda serpme grafik kullanın:

* eşleştirilmiş sayısal verileriniz varsa
* birlikte iyi eşleşen iki değişkeniniz varsa
* iki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız
* bağımsız bir değişkenin bağımlı bir değişken için birden çok değeri varsa

1. [Create Clustered Column Charts](#create-clustered-column-charts) bölümündeki adımları izleyin.
2. Üçüncü adımda, bir grafik ekleyin, bazı veriler ekleyin ve grafik türünüzü aşağıdakilerden biri olarak belirtin:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Seri işaretçileri olan bir serpme grafik._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğriyle bağlanan, veri işaretçileri olan bir serpme grafik._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğriyle bağlanan, veri işaretçileri olmayan bir serpme grafik._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Doğrusal hatlarla bağlanan, veri işaretçileri olan bir serpme grafik._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Doğrusal hatlarla bağlanan, veri işaretçileri olmayan bir serpme grafik._

Bu Java kodu, her seri için farklı işaretçilerle bir serpme grafik oluşturmayı gösterir:

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
    
    // Demo serilerini siler
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

### **Pasta Grafik Oluşturma**

Pasta grafikler, özellikle kategorik etiketleri sayısal değerlerle içeren verilerde, bütün‑parça ilişkisini göstermek için en uygunudur. Ancak veriniz çok sayıda parça veya etiket içeriyorsa, çubuk grafik kullanmayı düşünebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Pie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Pie) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Grafik için yeni puanlar ekleyin ve pasta dilimlerine özel renkler uygulayın.
9. Seriler için etiketleri ayarlayın.
10. Seri etiketleri için lider çizgileri etkinleştirin.
11. Pasta dilimlerinin dönüş açılarını ayarlayın.
12. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir pasta grafik oluşturmayı gösterir:

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
    
    // Yeni kategoriler ekler
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Yeni seriler ekler
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Yeni sürümde çalışmıyor
    // Yeni puanlar ekleyerek dilim rengini ayarlar
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Dilim kenarlığını ayarlar
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Dilim kenarlığını ayarlar
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().setFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Dilim kenarlığını ayarlar
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
    
    // Grafik için lider çizgileri gösterir
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Pasta grafik dilimleri için dönüş açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Grafikli sunumu kaydeder
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Çizgi Grafik Oluşturma**

Çizgi grafikler (diğer adıyla çizgi diyagramları), zaman içinde değer değişimlerini göstermek istediğiniz durumlarda en uygunudur. Çizgi grafik kullanarak aynı anda büyük miktarda veriyi karşılaştırabilir, zaman içinde değişimleri ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Diziniyle bir slayta referans alın.
1. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Line) türünü belirtin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir çizgi grafik oluşturmayı gösterir:

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

Varsayılan olarak, bir çizgi grafikteki noktalar düz sürekli hatlarla birleştirilir. Noktaların kesikli hatlarla birleştirilmesini isterseniz, tercih ettiğiniz kesikli tipini aşağıdaki gibi belirtebilirsiniz:

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

### **Ağaç Haritası Grafik Oluşturma**

Ağaç haritası grafikler, her bir kategori içinde büyük katkı sağlayan öğelere hızlıca dikkat çekmek istediğiniz satış verileri için en uygundur.

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Treemap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Treemap) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir ağaç haritası grafik oluşturmayı gösterir:

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

### **Hisse Senedi Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#OpenHighLowClose) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Yüksek‑düşük hat formatını belirleyin.
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir hisse senedi grafik oluşturmayı gösterir:

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

### **Kutu ve Bıyık Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#BoxAndWhisker) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir kutu ve bıyık grafik oluşturmayı gösterir:

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

### **Huni Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Funnel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Funnel) türünü belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir huni grafik oluşturmayı gösterir:

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

### **Güneş Patlaması Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Sunburst](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Sunburst) türünü belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir güneş patlaması grafik oluşturmayı gösterir:

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

### **Histogram Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.Histogram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Histogram) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir histogram grafik oluşturmayı gösterir:

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

### **Radar Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Bazı verilerle bir grafik ekleyin ve tercih ettiğiniz grafik türünü ([ChartType.Radar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Radar) bu örnekte) belirtin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir radar grafik oluşturmayı gösterir:

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

### **Çok Kategorili Grafik Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Diziniyle bir slayta referans alın.
3. Varsayılan verilerle bir grafik ekleyin ve [ChartType.ClusteredColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ClusteredColumn) türünü belirtin.
4. Grafik veri çalışma kitabı [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)’a erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu çok kategorili bir grafik oluşturmayı gösterir:

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

### **Harita Grafik Oluşturma**

Harita grafikleri coğrafi verileri görselleştirir ve bölgeler arasındaki değerleri karşılaştırmanıza yardımcı olur.

Bu Java kodu bir harita grafik oluşturmayı gösterir:

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

### **Kombinasyon Grafik Oluşturma**

Kombinasyon grafiği (veya combo grafik), tek bir diyagramda iki ya da daha fazla grafik türünü birleştirir. Bu grafik, iki ya da daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri belirlemenize yardımcı olur.

![Kombinasyon Grafiği](combination_chart.png)

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

    // Grafik başlığını ayarlar.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Grafik lejandını ayarlar.
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

    // Dikey ana ızgara çizgileri rengini ayarlar.
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

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Diziniyle bir slayta referans alın.
3. İstenilen grafiği bulmak için tüm şekiller arasında dolaşın.
4. Grafik veri çalışma sayfasına erişin.
5. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.
6. Yeni bir seri ekleyin ve verilerini doldurun.
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir grafiği güncellemeyi gösterir:

```java
import com.aspose.slides.*;

// Grafiği güncelleyecek sunumu açar
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // İlk slaytı eriş
    ISlide sld = pres.getSlides().get_Item(0);

    // Slayttan grafiği al
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Grafik veri sayfası indeksini ayarlar
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

    // Şimdi, yeni bir seri ekliyor
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // 3. grafik serisini al
    series = chart.getChartData().getSeries().get_Item(2);

    // Şimdi seri verilerini dolduruyor
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Grafikli sunumu kaydet
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Grafik İçin Veri Aralığını Ayarlama**

Mevcut bir grafik tarafından zaten kullanılan aralığı incelemek için [Retrieve a Chart's Data Range](/slides/tr/androidjava/chart-workbook/#retrieve-a-charts-data-range) bölümüne bakın.

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafiği içeren bir sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfı örneği oluşturun.
2. Diziniyle bir slayta referans alın.
3. İstenilen grafiği bulmak için tüm şekiller arasında dolaşın.
4. Grafik verilerine erişin ve aralığı ayarlayın.
5. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Bu Java kodu bir grafik için veri aralığını ayarlamayı gösterir:

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

Grafiklerde varsayılan işaretçileri kullandığınızda, her grafik serisi otomatik olarak farklı bir işaretçi sembolü alır.

Bu Java kodu bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

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

**Aspose.Slides hangi grafik türlerini destekliyor?**

Aspose.Slides, çubuk, çizgi, pasta, alan, serpme, histogram, radar ve daha pek çok [chart types](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) destekler. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenizi sağlar.

**Bir slayta yeni bir grafik nasıl eklenir?**

Bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) sınıfının örneğini oluşturur, istenen slayta indeks ile erişir ve ardından grafik türü ve başlangıç verilerini belirterek grafik ekleme metodunu çağırırsınız. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafikteki veriler nasıl güncellenir?**

Grafiğin verilerini, veri çalışma kitabına ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip kendi özel verilerinizi ekleyerek güncelleyebilirsiniz. Böylece grafik, en son verilere göre yenilenir.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkler, yazı tipleri, etiketler, lejandlar ve diğer [formatting elements](/slides/tr/androidjava/chart-entities/) gibi öğeleri değiştirerek grafiğin görünümünü tasarım gereksinimlerinize göre şekillendirebilirsiniz.