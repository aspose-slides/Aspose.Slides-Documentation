---
title: Java ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/java/chart-series/
keywords:
- grafik serisi
- seri örtüşmesi
- seri rengi
- seri adı
- veri noktası
- çalışma kitabı hücresi
- seri boşluğu
- negatif değer
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java kullanarak sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında depolar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/) ilgili değerlerin bir kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine referans verir. [IChartCategory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartcategory/) nesneleri, seriler arasında paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) yöntemine geçirilen çalışma sayfası, satır ve sütun dizinleri sıfır tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluştururken faydalıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans verilen hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri seviyesindeki ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getFormat--), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getFormat--), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, gruba [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) aracılığıyla erişin.

Açık bir nokta veya seri doldurma ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getOverlap--) 2B bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100 ile %100 arasında rapor eder. Bu, üst seriler grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Bu gruptaki her uyumlu seriyi güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; bir kombinasyon grafiğindeki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Doldurma Rengini Değiştirme**

Bir serinin tamamı için varsayılan doldurmayı ayarlamak üzere [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir noktanın zaten açık bir doldurması varsa, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı o nokta için seri doldurmasını geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir doldurma uygular:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Serinin rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı, grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumundadır ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıklar:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[IChartSeries.getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getName--) tarafından zaten referans verilen hücreyi de güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Seri adı](series_name.png)

## **Otomatik Seri Doldurma Rengini Alma**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) serinin indeksinden ve grafik stilinden hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmamışsa kullanılan renktir. Yöntemi çağırmak hesaplanan rengi okur; yeni bir doldurma atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Tam renkler grafik stili ve temasına bağlıdır.

## **Grafik Serisi için Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir doldurma ile gösterebilir. Normal seri doldurmasını katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntüleme renkleri değişir.

Aşağıdaki örnek, varsayılan grafik verilerini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Ters katı doldurma rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Etkinin görünür olması için nokta ayrıca negatif bir değer alır:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Belirli Bir Veri Noktası Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, ona ait çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getValue--) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, boş değer ayarlarına göre bu değeri boş olarak kabul eder.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dağılım grafiklerinde X ve Y hücreleri ayrı ayrı kullanılır, balon grafiklerde ise bir boyut hücresi de bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istediğinizde [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapointcollection/#clear--) çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını kaldırır.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, tek bir seriye değil, üst seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun yapar.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

Tüm grafik türleri, [ChartType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) sayımıyla temsil edilen, grafik verilerini kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değerleri, dağılım grafikleri X ve Y değerlerini, balon grafikleri ise balon boyutlarını kullanır. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/) aynı grup seviyesindeki çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafik birden fazla grup içerebilir; bu nedenle bir seriden erişilen grup değiştirilse bile grafikteki tüm seriler zorunlu olarak değişmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Tamamen özel bir veri kümesi eklemeden önce bu hücreleri düzenleyebilir veya seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri, bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere referans verir. Referans verilen bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, kategori satırlarını ve seri‑değer satırlarını hizalı tutun; böylece her nokta amaçlanan kategori altında çizilir.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak koruyun. O seriden tüm noktaları kaldırmak istediğinizde yalnızca [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapointcollection/#clear--) kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk (gap), sıfır değer olarak veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) tarafından döndürülen rengi ayarlayın. Tek bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Hem seri hem de nokta biçimlendirildiğinde hangi biçimlendirme kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stili ve temasını kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesindeki biçimlendirme geçersiz kılmalarını yapmaz.

**Bir grafiğin içinde kaç seri bulunabileceği konusunda bir sınırlama var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı koymaz. Uygulamada, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafiğin okunabilirliği faydalı bir sınırı belirler.

**Sütunlar çok birbirine yakın ya da çok uzak olduğunda ne değiştirilmeli?**

Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri daha yakın hale getirin.