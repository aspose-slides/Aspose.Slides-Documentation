---
title: Android'de Sunumlarda Grafik Seri Verilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/androidjava/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- seri adı
- veri noktası
- çalışma kitabı hücresi
- seri boşluğu
- negatif değer
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında depolar. Bir [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) bir dizi ilgili değeri temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine referans verir. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak depolanmak yerine [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluştururken faydalıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans verilen hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Seri düzeyinde ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Gruba, bir seri üzerinden [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) erişilir ve bu grup üzerinden örtüşme veya boşluk genişliği gibi seçenekler ayarlanabilir.

Açıkça belirlenmiş bir nokta veya seri dolgu ayarı yoksa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2B bir grafikte çubukların veya sütunların % -100 ile 100 arasında ne kadar örtüştüğünü rapor eder. Bu, üst seriler grubundaki ayarın yalnızca okuma‑yazma olmayan bir yansımasıdır. [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanarak o gruptaki her uyumlu seriyi güncelleyebilirsiniz. Bu seçenek, gruplanmış çubukları veya sütunları gösteren grafik türlerine uygulanır; bir kombinasyon grafiğindeki ilişkili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Yeni grafik örnek serileri, kategorileri ve değerleri içerir.
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

## **Seri Dolgu Rengini Değiştir**

[IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) kullanarak bir serinin tamamı için varsayılan dolguyu ayarlayın. Bir nokta zaten açıkça bir dolguya sahipse, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı o nokta için seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Seri rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı, grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1'de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça belirtir:

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

[IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten referans verilen hücreyi de güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Birden Çok Hücreden Adı Olan Seri Oluştur**

Bir bileşik seri adı, ürün adı ve raporlama dönemi ayrı çalışma kitabı hücrelerinde depolandığında kullanışlıdır. Örneğin, B1 hücresindeki `Product A` ve C1 hücresindeki `2026` değerlerini biriyle birleştirerek tek bir seri adı oluşturabilir ve her iki kısmın da kaynak hücrelerine bağlı kalmasını sağlayabilirsiniz.

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) kullanarak isim aralığını alın, ardından bu koleksiyonu [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) metodına geçirin. `skipHiddenCells` parametresi gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `true` dışlar, `false` dahil eder. Bu örnek, isim aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını sağlar; A2:A3 hücreleri kategori etiketlerini, B2:B3 hücreleri ise sayısal değerleri sağlar.

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

Ortaya çıkan seri adı `Product A 2026` olarak iki hücre değerinin arasına bir boşluk eklenir. Lejende bu, her iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki resim sonucu göstermektedir:

![Lejende North ve South değerleri ile bileşik seri adı Product A 2026 bulunan sütun grafiği](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) serinin indeksinden ve grafik stilinden hesaplanan rengi Android ARGB renk tam sayısı olarak döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik renk tam sayısını yazdırır:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Tam sayı değerleri grafik stili ve temasına bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) üzerinden atayın. Negatif sayılar çalışma kitabında değişmez; yalnızca görüntü renkleri değişir.

Aşağıdaki örnek, varsayılan grafik verilerini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile tek bir nokta için terslemeyi etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakıldı ve yalnızca seçilen nokta için etkinleştirildi. Nokta ayrıca negatif bir değer alarak etkinin görünür olmasını sağlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Belirli Bir Veri Noktasının Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, onun arka plan çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiği için, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak kabul eder.

Aşağıdaki örnek, ilk seride yalnızca ikinci noktayı temizler:

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

Saçılım grafikleri ayrı X ve Y hücreleri kullanır, baloncuk grafikleri ayrıca bir boyut hücresi kullanır. Sadece kaldırmak istediğiniz değeri temsil eden hücreyi temizleyin. Diğer noktaları tutmak istediğinizde [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın, çünkü bu yöntem serideki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarındaki verileri dahil etmek veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metoduna `null` gönderin. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) kullanarak grafiğin boş hücreleri nasıl görüntüleyeceğini seçin. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir, boş çalışma kitabı hücresini sıfır ya da ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafiği oluşturur, Gün 3 için değeri temizler ve grafiği her modda kaydeder. Girdi dosyası gerekmez. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40`.

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

    // Gün 3'ü gerçekten boş bırak, kategori ve veri noktasını koruyarak.
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

Her çıktı dosyası, kaydetmeden önce atanmış modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek için istenen modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı veriyi üç dosyada gösterir. Gün 3 çalışma kitabında her durumda boştur:

![Aynı veriye sahip çizgi grafikler: Gap, Gün 3'te çizgiyi keser, Zero, çizgiyi sıfıra düşürür, Span ise Gün 2'yi Gün 4'e bağlar.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafiği, üç modu da kolayca karşılaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayacak bir çizgi olmadığından `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, sadece işaretçileri olan bir saçılım grafiğinde de bağlantı çizgisi yoktur. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Örtüşme gibi, bir seriye değil, üst seriler grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasında daha fazla boşluk oluşturur; daha küçük bir değer onları daha yoğun yapar.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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

**Hangi grafik tipleri veri serilerini destekler?**  
Enum [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) tarafından temsil edilen tüm grafik türleri grafik verisi kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**  
[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) uyumlu serileri içerir ve grup‑düzeyinde çizim ayarlarını paylaşır. Bir kombinasyon grafiği birden fazla grup içerebilir, bu yüzden bir seriden erişilen grup değiştirildiğinde grafik içindeki tüm seriler mutlaka etkilenmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**  
Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme aynı zamanda varsayılan veri olmadan grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**  
Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere referans verir. Referans verilen hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, kategori satırlarını ve seri‑değer satırlarını hizalı tutun; böylece her nokta hedeflenen kategori altında çizilir.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**  
İlgili değer hücresini `null` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak tutun. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, değerlerin kategori koleksiyonu ile hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**  
Sonuç grafik tipine ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk (gap), sıfır değer (zero) veya komşu noktaları bağlayarak (span) gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**  
Desteklenen çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) çağırıp [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) üzerinden dönen rengi ayarlayabilirsiniz. Tek bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta her ikisi de biçimlendirilmişken hangi biçimlendirme kazanır?**  
Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını kullanmaya devam eder; seri formatı tanımlı değilse otomatik grafik stil ve tema kullanılır. Örtüşme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑düzeyinde biçimlendirme geçersiz kılmaz.

**Bir grafiğin içerebileceği seri sayısında bir limit var mı?**  
Aspose.Slides ayrı bir sabit seri sayısı limiti getirmez. Uygulamada, sunum dosyası kısıtlamaları, mevcut bellek, oluşturma süresi ve grafik okunabilirliği faydalı bir limit belirler.

**Sütunlar çok yakın veya çok uzaktaysa ne değiştirmeliyim?**  
[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu uygun üst seriler grubunda çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, değeri azaltarak kümeleri birbirine daha yakın hale getirin.