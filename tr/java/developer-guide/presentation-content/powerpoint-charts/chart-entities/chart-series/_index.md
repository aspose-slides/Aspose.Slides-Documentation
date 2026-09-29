---
title: Java ile Sunularda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/java/chart-series/
keywords:
- grafik serisi
- seri çakışması
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
description: "Java ile sunularda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri yönetmeyi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/) bir ilgili değer kümesini temsil eder ve serideki her bir [IChartDataPoint](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine işaret eder. [IChartCategory](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak depolanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’ı seri adları için, sütun 0’ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan veri ile bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarları, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑noktası ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden gruba erişerek çakışma veya boşluk genişliği gibi seçenekleri ayarlayabilirsiniz.

Açıkça bir nokta ya da seri doldurması ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getOverlap--) bir 2D grafikte çubukların veya sütunların ne kadar çakıştığını ‑100 ile 100 yüzde arasında raporlar. Bu, üst seri grubundaki ayarın salt okunur bir yansımasıdır. O gruptaki tüm uyumlu serileri güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; bir kombinasyon grafiğinde ilgili olmayan seri gruplarını etkilemez.

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

![The series overlap](series_overlap.png)

## **Seri Doldurma Rengini Değiştirme**

Tam bir seri için varsayılan doldurmayı ayarlamak üzere [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir noktanın zaten açık bir doldurması varsa, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı, o nokta için seri doldurmasını geçersiz kılar.

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

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı, grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [IChartSeries.getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getName--) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Doldurma Rengini Almak**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir doldurma atamaz.

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

Tam renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir doldurma ile gösterebilir. Normal seri doldurmasını katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metodunu kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır ve yalnızca seçilen nokta için etkinleştirilir. Etkinin görülmesi için nokta ayrıca negatif bir değer alır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için onun arka plan çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#getValue--) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak işler.

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

Dağılım grafiklerinde X ve Y hücreleri ayrı, baloncuk grafiklerinde ise ek bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın; bu yöntem serinin tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etme veya hariç tutma hakkında bilgi için **[Include Data from Hidden Rows and Columns](/slides/tr/java/chart-workbook/#include-data-from-hidden-rows-and-columns)** bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş hâle getirmek için [IChartDataCell.setValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metoduna `null` gönderin. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır kalır.

Boş hücrelerin nasıl gösterileceğini seçmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metodunu kullanın. Bu ayar tüm grafik için geçerlidir ve boşlukların nasıl çizileceğini, hücreyi sıfır ya da aralıklı bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir serili bir çizgi grafik oluşturur, Gün 3 için değeri temizler ve grafiği her kipte kaydeder. Giriş dosyası gerekmez. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

Her çıktı dosyası, kaydetmeden önce atanan kipi isimlendirir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz kipi atayın ve sunumu bir kez kaydedin; kipi döngüyle yinelemeyin.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği, üç kip arasındaki farkları karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlanacak bir çizgi olmadığından, `Span` yukarıdaki bağlayıcı segmenti üretemez; eksik bir sütun ve sıfır‑yükseklikteki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçiler içeren dağılım grafiğinde de bağlantı çizgisi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız türün çıktısını kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Çakışma gibi, bu da tek bir seriye değil ana seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun hâle getirir.

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

[ChartType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) enumʼu tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değer, dağılım grafikleri X ve Y değer ve baloncuk grafikleri baloncuk boyutları kullanır. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden çok grup içerebilir; bu nedenle bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan bir grafik de oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücreyi değiştirmek ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yapın; böylece noktanın kategori konumu boş bir nokta olarak kalır. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu yalnızca serinin tüm noktalarını kaldırmak istediğinizde kullanın. Kategorileri de kaldırırsanız, değerlerin kategori koleksiyonuyla hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için **[Control the Display of Empty Cells](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metodunu çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metodundan dönen rengi ayarlayın. Bireysel bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Hem seri hem de nokta biçimlendirilmişse hangi ayar kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimini veya seri biçimi tanımlı değilse otomatik grafik stilini ve temasını kullanmaya devam eder. Çakışma ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısı için bir üst sınır var mı?**

Aspose.Slides ayrı bir sabit seri sayısı limiti uygulamaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınırı belirler.

**Sütunlar çok yakındaysa ya da çok uzakta ise ne yapılmalı?**

Uygun ana seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.