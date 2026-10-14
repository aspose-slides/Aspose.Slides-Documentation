---
title: Android'de Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/androidjava/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile Android'de pasta grafiklerini oluşturun ve özelleştirin. İkincil grafikler yapılandırın, veri etiketlerini görüntüleyin ve PowerPoint'te otomatik dilim renkleri uygulayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slide'a grafik ekleme, seriler ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafiklerinde İkincil Grafik Seçenekleri**

Aspose.Slides for Android via Java, Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerini destekler. Bu seçenekler, ikincil grafiğin boyutunu ve veri noktalarının iki grafik arasında nasıl bölündüğünü kontrol eder.

Aşağıdaki örnek, yeni bir sunumda Pie of Pie grafik oluşturur ve veri noktası değerlerini etiket olarak gösterir. [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) yöntemi, ikincil grafiğin boyutunu ana grafiğin %149'una ayarlar. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) yüzde temelli bölmeyi seçer ve [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) eşik değerini %53 olarak ayarlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Değerleri göster ve ikincil grafiği yapılandır.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **İkincil Grafik İçin Kategorileri Seçin**

Yüzde değerlerinden bağımsız olarak belirli kategorileri ikincil grafikte gruplamak istediğinizde özel bölme kullanın. Örneğin, bir satış raporu Online ve Events'i birlikte göstererek okuyucuların bu iki kanalı karşılaştırmasını sağlayabilir; her ne kadar bunlar toplam satışların %35 ve %10'ını oluşturuyor olsa da.

Bu örnekte, [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) yöntemi, [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) ile çağrılır ve noktalar [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) aracılığıyla seçilir. Koleksiyonun [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) yöntemi, seride sıfır tabanlı bir indeks kabul eder; bir veri noktası nesnesi eklemek için [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) kullanın. Bu örnekte, indeks 1 Online'ı, indeks 3 ise Events'i seçer. Partners da geçici olarak eklenir ve ardından [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) ile çıkarılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Varsayılan verileri kanal bazında satışlarla değiştir.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online'ı sıfır tabanlı indeksiyle ve Events'i veri noktası nesnesiyle seç.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners'ı seçimden çıkart, ancak kaynak verisini silme.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) ve Events (10), ikincil grafikte ayrı dilimler olarak görülür. Birincil grafikte ise, Retail (40) ve Partners (15) ile birlikte 45 değerinde tek bir birleşik dilim olarak temsil edilirler. Partners, özel seçimden çıkarıldığında birincil grafikte kalır; kategori ya da değeri grafik kaynak verilerinden kaldırılmaz.

Aşağıdaki görüntü, kaydedilen sunumu PowerPoint'te gösterir:
![İkincil grafikte Online ve Events bulunan ve birincil grafikte 45 birleşik değere sahip Pie of Pie grafiği](pie_of_pie_custom.png)

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarlama**

Aspose.Slides for Android via Java, pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla bir pasta grafiği oluşturur ve varsayılan verileri üç çeyrek kategorisi ve değerleriyle değiştirir. [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) yöntemi, 20, 50 ve 30 değerlerini etiket olarak gösterirken, [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) her dilim için farklı bir renk etkinleştirir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ortalanmış bir grafik başlığı ekle.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // İlk çalışma sayfasını kullanarak varsayılan verileri değiştir.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Değerleri göster ve dilimlere farklı renkler ata.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane, Pie of Pie ve Bar of Pie tipleri dahil olmak üzere pasta grafikleri için ikincil bir grafiği [destekler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

**Sadece grafiği bir görüntü olarak (örneğin, PNG) dışa aktarabilir miyim?**

Evet, tüm sunumu dışa aktarmadan grafiği (örneğin PNG) bir görüntü olarak [grafiği doğrudan bir görüntü olarak dışa aktar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (örneğin PNG) yapabilirsiniz.