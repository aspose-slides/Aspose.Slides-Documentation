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
description: "Android'de sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) bir dizi ilgili değeri temsil eder ve her [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) bu serideki bir noktayı temsil eder. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan verilerle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri grafik çalışma kitabındaki [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreleri seri değerleri için kullanır. Çalışma sayfası, satır ve sütun dizinleri [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metoduna sıfır tabanlı olarak geçilir. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans verilen hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seriye‑özel ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑noktası ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları aynı [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden erişin.

Açıkça bir nokta veya seri dolgu ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Seri Değerlerini Sayısal Sabitler Kullanarak Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalarından geliyor ve çalışma sayfası hücre referansına ihtiyaç duymuyorsa sayısal sabitler kullanın. Her noktanın [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) sonucunu atamadan önce [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) ile [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) çağırın ve ardından [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) kullanın.

Koleksiyon ayarı, serideki tüm nokta değerlerinin kaynak türünü kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) yöntemi seçili türü raporlar; bunu koleksiyon ayarıyla değiştirin. `Worksheet` kullanıyorsanız, referans verilen hücreye erişmek için [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) kullanın. `DoubleLiterals` ile, sayıyı doğrudan okumak veya yazmak için [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) veya `setAsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafiği oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanmış değerleri atar. Sunumu kaydeder, yeniden açar ve saklanan değerleri yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Nokta değeri kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasını tanımlayan [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) yönteminden ayrıktır. Sayısal sabitler kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz. Bu örnekte, çalışma kitabı kategori etiketleri, seri adları ve diğer seriler için kullanılabilir durumda kalır. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/androidjava/chart-workbook/) sayfasına bakın.

Dağılma ve balon grafiklerinde, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) kullanarak [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) ve [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) kaynaklarını seçin. Balon grafikleri ayrıca [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) ile [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) kaynaklarını seçer. Her uygulanabilir kaynağı `DoubleLiterals` yapın ve ardından sayıyı `setAsLiteralDouble` yöntemiyle atayın.

## **Grafik Seri Çaprazlamasını Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2D bir grafikte çubukların veya sütunların ne kadar çakıştığını –100 ile 100 yüzde arasında raporlar. Bu, üst grup üzerindeki ayarın yalnızca okunabilir bir yansımasıdır. Uyumlu serilerin tümünü güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleştirilmiş grafikte ilişkili olmayan seri gruplarını etkilemez.

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

## **Seri Dolgu Rengini Değiştirme**

Bir serinin tümü için varsayılan dolgu ayarlamak üzere [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı o nokta için serinin dolgusunu geçersiz kılar.

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

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejanda görüntülenir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı netleştirir:

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

Ayrıca [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten referans verilen hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Birden Çok Hücreden Adı Olan Seri Oluşturma**

Ürün adı ve raporlama dönemi ayrı hücrelerde saklanıyorsa birleşik bir seri adı faydalıdır. Örneğin, B1 hücresindeki `Product A` ve C1 hücresindeki `2026` değerlerini tek bir seri adı haline getirirken her iki kısmı da kaynak hücrelerine bağlı tutabilirsiniz.

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) ile ad aralığını alın, ardından bu koleksiyonu [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) yöntemine geçirin. `skipHiddenCells` argümanı gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `true` hariç tutar, `false` dahil eder. Bu örnek, ad aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 aralığı yalnızca seri adını sağlar; A2:A3 kategori etiketlerini, B2:B3 sayısal değerleri sağlar.

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

Ortaya çıkan seri adı `Product A 2026` olur; iki hücre değeri arasında bir boşluk bulunur. Lejand bu iki sütunu tek bir giriş olarak gösterir. Sonuç aşağıdaki görselde gösterilmiştir:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) yöntem, seri indeksine ve grafik stiline göre hesaplanan Android ARGB renk tamsayısını döndürür. Bu, seri dolgusunun açıkça tanımlanmadığı durumda kullanılan renktir. Yöntemi çağırmak yalnızca hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, varsayılan her seri için otomatik renk tamsayısını yazdırır:

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

## **Bir Grafik Serisi İçin Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını, sütun 1 değerleri içerir:

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

Bir nokta için tersleme, [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirilebilir. Aşağıdaki örnek, seride terslemeyi devre dışı bırakır, yalnızca seçilen noktada etkinleştirir ve nokta için negatif bir değer atar:

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

## **Belirli Bir Veri Noktası Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, ilgili çalışma kitabı hücresini `null` yapın. Sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) ile elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak kabul eder.

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

Dağılma grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ayrıca boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metodunu çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından gelen verileri dahil etmek veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Hücreyi boş yapmak için [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metodunu `null` ile çağırın. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

[İChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile grafiğin boş hücreleri nasıl göstereceğini seçin. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir, boş çalışma kitabı hücresini sıfır ya da ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafiği oluşturur, 3. Gün değerini temizler ve her modda aynı grafiği kaydeder. Girdi dosyasına ihtiyaç yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0, değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

Her çıktı dosyası, kaydetmeden önce atanmış modu yansıtır: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir versiyon kaydetmek isterseniz istenen modu atayın ve sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünüm etkisi grafik türüne bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori olduğunda bağlayıcı bir çizgi olmaz; bu yüzden `Span` yukarıdaki bağlayıcı bölümü üretemez; eksik bir sütun ve sıfır yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicileri olan bir dağılma grafiğinde bağlayıcı çizgi yoktur. Her grafik türü için üç farklı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluğu, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Örtüşme gibi, bu ayar bir seriye değil, üst seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun hâle getirir.

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

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) enumʼu tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategori ve değerler, dağılma grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri kümesi eklemeden önce hem seri hem de kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere referans verir. Referans verilen bir hücre değiştirilirse ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın amaçlanan kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Tüm seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, diğer serileri de güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) üzerinden yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları kesik, sıfır değer olarak veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Control the Display of Empty Cells](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile dönen rengi ayarlayın. Bireysel bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Hem seri hem de nokta biçimlendirilirse hangisi kazanır?**

Açıkça nokta‑seviyesi biçimlendirme o nokta için önceliklidir. Diğer noktalar açıkça belirlenmiş seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stili ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersizliği değildir.

**Bir grafiğin içerebileceği seri sayısında bir sınır var mı?**

Aspose.Slides ayrı bir sabit seri‑sayısı sınırı getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakınımı yoksa çok mu uzakta? Ne yapmalıyım?**

Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak kümeleri birbirine yaklaştırır.