---
title: Sunumlarda Java ile Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/java/chart-series/
keywords:
- grafik serisi
- serilerin çakışması
- serinin rengi
- serinin adı
- veri noktası
- çalışma kitabı hücresi
- serinin boşluğu
- negatif değer
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında depolar. Bir [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) ilgili değerlerin bir kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) nesneleri, seri tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca gösterim metni olarak depolanmak yerine [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metoduna geçirilen çalışma sayfası, satır ve sütun dizinleri sıfır tabanlıdır. Bu düzen, varsayılan veri ile bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Çakışma veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) aracılığıyla erişin.

Açık bir nokta ya da seri dolgusu ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) bir 2D grafikte çubukların veya sütunların ne kadar çakıştığını –100 ile 100 yüzde arasında raporlar. Bu, üst seri grubunun ayarının yalnızca okunabilir bir yansımasıdır. Aynı gruptaki her uyumlu seriyi güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; kombinasyon grafiğinde ilişkili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

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

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

[Tüm bir seri için varsayılan dolguyu ayarlamak için [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı o nokta için seri dolgusu üzerine yazar.

Aşağıdaki örnek, ilk seriye katı mavi dolgu uygular:

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

Bir seri adı, grafik veri çalışma kitabında depolanır ve genellikle legendede görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1’de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, zaten [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) tarafından başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Birden Çok Hücreden Oluşan Seri Adı Oluşturma**

Ürün adı ve raporlama dönemi ayrı çalışma kitabı hücrelerinde saklandığında bileşik bir seri adı faydalıdır. Örneğin, B1’deki `Product A` ile C1’deki `2026` değerlerini tek bir seri adı olarak birleştirirken her iki kısmı da kaynak hücrelerine bağlı tutabilirsiniz.

[İsım aralığını almak için [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) kullanın, ardından bu koleksiyonu [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) metoduna aktarın. `skipHiddenCells` bağımsız değişkeni gizli hücrelerin dahil edilip edilmemesini kontrol eder: `true` gizler, `false` dahil eder. Bu örnek, isim aralığındaki her hücreyi dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 yalnızca seri adını sağlar; A2:A3 kategori etiketlerini, B2:B3 sayısal değerleri sağlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Bu iki hücre seri adını sağlar.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Elde edilen seri adı, iki hücre değerinin arasında bir boşlukla `Product A 2026` olur. Legendede bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görüntü sonucu gösterir:

![Kuzey ve Güney değerli sütun grafiği ve birleşik seri adı Product A 2026 legendede](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) metodu, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, varsayılan her serinin otomatik rengini yazdırır:

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

Kesin renkler grafik stili ve temaya bağlıdır.

## **Grafik Serisi için Ters Dolgu Rengini Ayarla**

Sütun, çubuk ve balon serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, tersleme özelliğini etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verilerini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) üzerinden etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme kapalı, yalnızca seçilen nokta için etkinleştirilir. Etkiyi görünür kılmak için nokta negatif bir değer de alır:

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

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, ara hücreyi `null` olarak ayarlayın. Sütun grafiği için çizilen değer, [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, değerini grafik boş değer ayarlarına göre boş olarak işler.

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

Scatter grafikler ayrı X ve Y hücreleri, balon grafikler ise bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durum oluşturur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metodunu `null` ile çağırın. Sayısal sıfır, boş hücre ayarına bakılmaksızın sıfır olarak kalır.

Grafiğin boş hücreleri nasıl görüntüleyeceğini seçmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kullanın. Bu ayar tüm grafiğe uygulanır. Boşlukların nasıl çizileceğini değiştirir, boş hücreyi sıfır ya da interpolasyonla doldurmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafik oluşturur, Gün 3 değerini temizler ve grafiği her modda ayrı kaydeder. Giriş dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler; satır 0 seri adı içerir. Son veri `10, 20, empty, 30, 40` şeklindedir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Gün 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını tut.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Her çıktı dosyası, kaydetmeden önce atanan modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Aynı veriyle üç satır grafik: Gap, 3. Gün'de çizgiyi kırar, Zero, çizgiyi sıfıra düşürür ve Span, 2. Gün ile 4. Gün arasını bağlar.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırır. Çubuk ve sütun grafikleri, eksik bir kategori üzerinden bağlamak için bir çizgiye sahip olmadığından, `Span` yukarıdaki bağlayıcı bölümü üretemez; eksik bir sütun ve sıfır yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir scatter grafiği de bağlayıcı çizgiye sahip değildir. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk ya da sütun genişliğinin yüzde olarak ifade edilir. Çakışma gibi, bu da tek bir seriye değil üst seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasında daha fazla boşluk oluşturur; daha küçük bir değer onları daha sıklaştırır.

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
Tüm grafik türleri ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) enum'ı) veri kullanır, ancak serilerinin değer yapısı ve ayarları aynı değildir. Örneğin, kategori grafiklerinde kategori ve değerler, scatter grafiklerinde X ve Y değerleri, balon grafiklerde ise balon boyutları bulunur. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarında geçerlidir.

**Grafik seri grubu nedir?**  
[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) uyumlu serileri, grup düzeyinde çizim ayarlarını paylaşan bir koleksiyondur. Kombinasyon grafiği birden fazla grup içerebilir; bir seri üzerinden erişilen grup ayarını değiştirmek, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**  
Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yük, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**  
Seri adları, kategori etiketleri ve veri noktası değerleri, bir [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın doğru kategori altında çizilebilmesi için kategori satırlarıyla seri‑değer satırlarının hizalı olmasına dikkat edin.

**Tüm seriyi değil tek bir noktayı nasıl temizlerim?**  
İlgili değer hücresini `null` olarak ayarlayın; böylece nokta kategori konumunu korur ancak boş bir nokta olarak değerlendirilir. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu yalnızca tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutacak şekilde güncelleyin.

**Boş noktalar nasıl görüntülenir?**  
Sonuç, grafik tipi ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) yöntemiyle yapılandırılan değere bağlıdır. Desteklenen grafikler, boşlukları boşluk (gap), sıfır (zero) veya komşu noktaları bağlayarak (span) gösterebilir. Eksik verinin anlamına uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**  
Desteklenen çubuk, sütun ve balon serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metodunu çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile dönen rengi ayarlayın. Bireysel bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler yalnızca biçimlendirmeyi, saklanan sayısal değeri etkilemez.

**Hem seri hem de nokta biçimlendirilmiş olduğunda hangi biçimlendirme kazanır?**  
Açık veri noktası biçimlendirmesi, o nokta için önceliklidir. Diğer noktalar, açık seri biçimlendirmesini (veya seri biçimi tanımlı değilse otomatik grafik stili ve temasını) kullanmaya devam eder. Grup ayarları (çakışma, boşluk genişliği vb.) düzeni kontrol eder ve nokta seviyesindeki biçimlendirme geçersizliklerine girmez.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**  
Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, dosya formatı kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın veya çok uzak olduğunda ne değiştirmeliyim?**  
Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu çağırın. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.