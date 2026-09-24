---
title: Android'te Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Android'de sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/) bir grup ilgili değeri temsil eder ve serideki her [IChartDataPoint](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’ı seri adları, sütun 0’ı kategori adları ve kalan hücreleri seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) aracılığıyla grup erişilir.

Açıkça bir nokta veya seri dolgu ayarı belirtilmemişse, grafik stilleri ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarla**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2B bir grafikte çubukların veya sütunların ne kadar çakıştığını –%100’den +%100’e kadar – raporlar. Bu, üst grup üzerindeki ayarın salt okunur bir yansımasıdır. O grup içindeki tüm uyumlu serileri güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; kombinasyon grafiğindeki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

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

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştir**

Tam bir seri için varsayılan dolgu ayarlamak üzere [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir noktanın zaten açık bir dolgu ayarı varsa, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı, o nokta için seri dolgusunu geçersiz kılar.

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

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle legend’da gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, [IChartSeries.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten başvurulan hücreyi de güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Dolgu Rengini Al**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) serinin dizine ve grafik stiline göre hesaplanan Android ARGB renk tamsayısını döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodun çağrılması sadece hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan seri için otomatik renk tamsayısını yazdırır:

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

Tam tamsayı değerleri grafik stili ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve balon serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, tersleme özelliğini etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

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

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır ve yalnızca seçilen nokta için etkinleştirilir. Noktaya, etkinliği göstermek üzere negatif bir değer de atanır:

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

## **Belirli Bir Veri Noktası Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun arka plan hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) ile elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değeri boş olarak işler.

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

Dağılım grafikleri ayrı X ve Y hücreleri, balon grafikleri ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değere karşılık gelen hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın; bu metod tüm veri noktalarını koleksiyondan siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Boş bir çalışma kitabı hücresi eksik veri, `0` içeren bir hücre ise bilinen sayısal bir değeri temsil eder. Hücreyi boş bırakmak için [IChartDataCell.setValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metoduna `null` gönderin. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metodunu kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukları çizim şeklini değiştirir; hücreyi sıfır ya da interpolasyonla doldurmaz.

Aşağıdaki bağımsız örnek, bir seri ile bir çizgi grafik oluşturur, 3. Gün değerini temizler ve aynı grafiği her modda kaydeder. Giriş dosyasına ihtiyaç yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir:

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

    // Day 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
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

Her çıktı dosyası, kaydetmeden önce atanmış modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir versiyonu kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırır. Çubuk ve sütun grafiklerde eksik bir kategori için bağlayacak bir çizgi olmadığından, `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır‑yüksekliğindeki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir dağılım grafiği de bağlayıcı çizgi içermez. Her grafik türü için üç farklı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Çakışma gibi, bu da tek bir seriye değil, üst grup seviyesine aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

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

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) enum’unda yer alan tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değer, dağılım grafikleri X ve Y değerleri, balon grafikleri ise balon boyutları kullanır. Seri tipine uygun veri‑nokta oluşturma metodunu seçin. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/) grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup barındırabilir; bir seriden ulaşarak grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücreleriyle nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri, bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücreyi değiştirmek ilgili grafik öğesini günceller. Özel veri oluştururken, kategori satırları ve seri‑değer satırlarının hizalı olduğundan emin olun; böylece her nokta istediğiniz kategori altında çizilir.

**Bir seriyi tamamen silmeden yalnızca bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktayı boş bırakın; kategori konumu korunur. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler, boşlukları aralık olarak, sıfır değer olarak veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Ayrıntılı örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metodunu çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile dönen rengi ayarlayın. Bireysel bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu metodlar biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirildiğinde hangi biçimleme geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık seri biçimlendirmesini ya da seri biçimi tanımlı değilse otomatik grafik stili ve temasını kullanmaya devam eder. Çakışma ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılma değildir.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**

Aspose.Slides ayrı bir sabit seri‑sayısı sınırı getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın veya çok uzak olduğunda ne yapılmalı?**

Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu çağırın. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.