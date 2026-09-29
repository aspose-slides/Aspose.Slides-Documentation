---
title: Android'de Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Android'de sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/) bir ilişkili değerler kümesini temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine referans verir. [IChartCategory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle, seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiğinde, varsayılan çalışma kitabı satır 0'ı seri adları için, sütun 0'ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. Çalışma sayfası, satır ve sütun indisleri [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) yöntemine sıfır‑tabanlı olarak geçirilir. Bu düzen, varsayılan veri ile bir grafik oluşturduğunuzda faydalıdır, ancak mevcut tüm grafiklerin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans alınan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑ düzeyindeki ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/)’a ait uyumlu serilere uygulanır. Üst‑üst bindirme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden erişin.

Açıkça bir nokta ya da seri dolgu ayarı bulunmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Üst Üst Bindirmesini Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2D bir grafikte çubukların veya sütunların ne kadar üst‑üst bindirildiğini -%100 ile %100 arasında bildirir. Bu, üst seri grubundaki ayarın yalnızca okunabilen bir yansımasıdır. Grup içindeki tüm uyumlu serileri güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; kombinasyon grafiğindeki ilgisiz seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için üst‑üst bindirmeyi ayarlar:

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

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

[Tüm bir seri için varsayılan dolguyu ayarlamak için [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) yöntemini kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı o nokta için serinin dolgusunu geçersiz kılar.

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

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı grafik veri çalışma kitabında saklanır ve normalde lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [IChartSeries.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten referans alınan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

![The series name](series_name.png)

## **Otomatik Seri Dolgu Rengini Almak**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) serinin indeksi ve grafik stiliyle hesaplanan rengi Android ARGB renk tamsayısı olarak döndürür. Bu, seri dolgu açıkça tanımlanmadığında kullanılan renktir. Yöntemi çağırmak yalnızca hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik renk tamsayısını yazdırır:

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

Kesin tamsayı değerleri grafik stili ve temaya bağlıdır.

## **Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, ters dönüşümü etkinleştirin ve negatif‑değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) üzerinden atayın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için ters dönüşümü [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için ters dönüşüm devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkinin görülmesi için nokta negatif bir değer de alır:

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

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, onun destekleyen çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafiği için çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş kabul eder.

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

Saçılım (scatter) grafiklerinde ayrı X ve Y hücreleri, baloncuk grafiklerinde ise bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın; bu metod serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Gizli satır ve sütunlarda bulunan değerler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satırları ve sütunlarından veri dahil etmek veya hariç tutmak için **[Include Data from Hidden Rows and Columns](/slides/tr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)** bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [IChartDataCell.setValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metoduna `null` gönderin. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metodunu kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresi sıfır ya da ara bir değerle doldurulmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafiği oluşturur, Gün 3 için değeri siler ve aynı grafiği her modda kaydeder. Girdi dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir:

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

    // 3. günü gerçekten boş bırakırken, kategori ve veri noktasını koruyun.
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

Her çıktı dosyası kaydetmeden önce atanmış modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayıp sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori arasında bağlayıcı bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ile sıfır‑yükseklikteki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir saçılım grafiği de bağlayıcı çizgi içermez. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tipin çıktısını kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzdesi olarak ifade edilir. Üst‑üst bindirme gibi, bu da tek bir seriye değil, üst seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıkı hâle getirir.

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

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**  
Tüm [ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) enum değerleri veri kullanır, ancak serilerin değer yapısı ve ayarları farklıdır. Örneğin, kategori grafiklerinde kategori ve değerler, saçılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Üst‑üst bindirme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**  
[IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/) aynı grup‑düzeyi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup barındırabilir; bir seriden ulaşarak grup ayarını değiştirmeniz, grafiğin tüm serilerini mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**  
Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri seti eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**  
Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere referans verir. Referans verilen bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, kategori satırları ile seri‑değer satırlarının hizalı olmasına dikkat edin; böylece her nokta doğru kategori altında çizilir.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**  
İlgili değer hücresini `null` yaparak noktanın konumunu boş bir nokta olarak tutabilirsiniz. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her seriyi güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl gösterilir?**  
Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşluk, sıfır değeri veya komşu noktaları bağlayarak boşlukları gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**  
Desteklenen çubuk, sütun ve baloncuk serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile dönen rengi atayın. Tek bir nokta için ters dönüşümü [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Bir seri ve bir nokta her ikisi de biçimlendirilmiş olduğunda hangi biçimlendirme geçerli olur?**  
Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını veya seri formatı tanımlı değilse otomatik grafik stilini ve temasını kullanmaya devam eder. Üst‑üst bindirme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑düzeyi biçimlendirme geçersiz kılmaları değildir.

**Bir grafikte kaç seri bulunabileceği konusunda bir sınırlama var mı?**  
Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve okunabilirlik gibi faktörler faydalı bir limit belirler.

**Sütunlar çok yakın veya çok uzak olduğunda neyi değiştirmeliyim?**  
Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine daha yakın hâle getirebilirsiniz.