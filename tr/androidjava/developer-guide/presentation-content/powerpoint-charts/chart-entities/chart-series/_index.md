---
title: Android'de Sunumlarda Grafik Veri Serilerini Yönetme
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
## **Overview**

Bir grafik, çizilmiş değerlerini çalışma kitabı hücrelerinde saklayabilir veya doğrudan sayısal sabitler olarak tutabilir. Bir [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) ilgili değerlerin bir kümesini, her [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) ise bu serideki bir noktayı temsil eder. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Varsayılan veriyle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri, grafik çalışma kitabının [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) nesnelerinden alınır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanılır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑bazlıdır. Bu düzen, varsayılan veriyle bir grafik oluştururken kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesindeki ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Çakışma veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, gruba [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden erişin.

Açıkça bir nokta veya seri dolgu ayarı belirtilmediğinde, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

Kümelenmiş silindir grafik için, [changing the 3D series type or bar shape](/slides/tr/androidjava/3d-chart/#change-the-3d-series-type-and-bar-shape) seçeneğinin ilk seriye etkisini görün.

## **Set Series Values Using Numeric Literals**

Seri değerleri uygulama verilerinden veya hesaplamalardan geliyorsa ve çalışma sayfası hücre referansına ihtiyaç duymuyorsa sayısal sabitleri kullanın. Her noktanın [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) sonucunu [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) aracılığıyla atamadan önce [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) yöntemini [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) ile çağırın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak türünü kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) yöntemi seçili türü raporlar; türü koleksiyon ayarıyla değiştirin. `Worksheet` ile başvurulan hücreye ulaşmak için [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) kullanın. `DoubleLiterals` ile doğrudan sayı okumak veya yazmak için [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) ya da `setAsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafik oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanmış değerleri atar. Sunumu kaydeder, yeniden açar ve depolanan değerleri yazdırır.

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

Nokta değeri kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasını belirten [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) öğesinden ayrıdır. Sayısal sabitlerin kullanılması, gömülü çalışma kitabını otomatik olarak kaldırmaz. Bu örnekte, çalışma kitabı kategori etiketleri, seri adları ve diğer seriler için hâlâ kullanılmaktadır. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/androidjava/chart-workbook/) sayfasına bakın.

Dağılım (scatter) ve baloncuk (bubble) grafiklerinde, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) yöntemleri, sırasıyla [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) ve [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) kaynaklarını seçmenizi sağlar. Baloncuk grafikleri ayrıca [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) ile [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) kaynaklarını belirler. Uygun her kaynağı `DoubleLiterals` olarak ayarlayın, ardından `setAsLiteralDouble` yöntemiyle sayıları atayın.

## **Set the Chart Series Overlap**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2D bir grafikte çubukların veya sütunların ne kadar çakıştığını –100 ile 100 yüzde arasında – raporlar. Bu, üst seriler grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Uyumlu tüm serileri güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik tiplerinde geçerlidir; birleşik bir grafikte ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışma değerini ayarlar:

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

## **Change the Series Fill Color**

Bir bütün serinin varsayılan dolgusunu ayarlamak için [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı, o nokta için seri dolgusunu geçersiz kılar.

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

## **Change the Series Name**

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejanda gösterilir. Kümelenmiş sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Create a Series with a Name from Multiple Cells**

Bir ürün adı ve raporlama dönemi ayrı hücrelerde saklandığında bileşik bir seri adı faydalıdır. Örneğin, B1 hücresindeki `Product A` ile C1 deki `2026` değerlerini tek bir seri adı olarak birleştirip her iki kısmın da kaynak hücrelerine bağlı kalabilirsiniz.

İsim aralığını elde etmek için [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) yöntemini kullanın, ardından bu koleksiyonu [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) yöntemine geçirin. `skipHiddenCells` parametresi gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `true` hariç tutar, `false` dahil eder. Bu örnek, isim aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını, A2:A3 hücreleri kategori etiketlerini ve B2:B3 hücreleri sayısal değerleri sağlar.

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

    // Bu iki hücre seri ismini sağlar.
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

Ortaya çıkan seri adı `Product A 2026`dır; iki hücre değeri arasına bir boşluk eklenir. Lejand bu iki sütun için tek bir giriş olarak gösterilir. Sonuç aşağıdaki resimde gösterilmiştir:

![Kuzey ve Güney değerli sütun grafik ve birleşik seri adı Product A 2026 lejanda](composite_series_name.png)

## **Get the Automatic Series Fill Color**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) yöntemi, seri indeksine ve grafik stiline göre hesaplanan Android ARGB renk tamsayısını döndürür. Bu, seri dolgusu açıkça tanımlanmamışsa kullanılan renktir. Yöntem, hesabı okur; yeni bir dolgu atamaz.

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

Tam sayı değerleri grafik stiline ve temaya bağlıdır.

## **Set Invert Fill Color for a Chart Series**

Çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) yöntemi negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) kullanın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfasının satır 0’ı seri adını, sütun 0 kategori adlarını, sütun 1 ise değerleri içerir:

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

Bir nokta için terslemeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır, yalnızca seçilen nokta için etkinleştirilir ve nokta negatif bir değer alır, böylece efekt görülür:

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

## **Clear a Specific Data Point Value**

Diğer noktaları silmeden bir noktayı boş bırakmak için o noktanın arka plan hücresini `null` yapın. Bir sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) ile elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarına göre değeri boş kabul eder.

Aşağıdaki örnek, ilk serinin yalnızca ikinci noktasını temizler:

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

Dağılım (scatter) grafikler ayrı X ve Y hücreleri, baloncuk grafikler ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) yöntemini çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Control the Display of Empty Cells**

Değer içeren gizli hücreler, boş hücrelerden farklı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi, `0` içeren hücre ise bilinen sayısal değeri temsil eder. Bir hücreyi boş hâle getirmek için [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) yöntemine `null` geçirin. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin grafikte nasıl gösterileceğini seçmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) yöntemini kullanın. Bu ayar tüm grafik için geçerlidir ve boşlukları doldurmaz, sadece boş hücrelerin nasıl çizileceğini değiştirir.

Aşağıdaki bağımsız örnek, bir satır grafik oluşturur, 3. Gün değerini boş bırakır ve her modda aynı grafiği kaydeder. Giriş dosyasına gerek yoktur. [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

    // Gün 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
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

Her çıktı dosyası, kaydetmeden önce atanmış modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu ayarlayıp sunumu bir kez kaydedin, modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, üç dosyadaki aynı veriyi gösterir. 3. Gün, her durumda çalışma kitabında boştur:

![Boş hücrelerin gösterimi: Gap çizgiyi 3. Gün'de keser, Zero sıfıra düşürür, Span ise 2. Gün ile 4. Gün arasında bağlar.](display_blanks_as.png)

Görünüm, grafik tipine bağlıdır. Çizgi grafikleri üç modu da rahatça karşılaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori olduğunda bağlayıcı bir çizgi olmadığından `Span` bağlama segmenti oluşturamaz; boş bir sütun ve sıfır‑yükseklikli bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan dağılım grafiğinde de bağlantı çizgisi yoktur. Her grafik tipi için üç ayrı sonuç beklemeyin; kullandığınız tipteki çıktıyı kontrol edin.

## **Set the Series Gap Width**

Boşluk genişliği, komşu çubuk veya sütun kümeleri arasındaki boşluğu, çubuk veya sütun genişliğinin yüzde olarak ifadesini belirtir. Çakışma gibi, bu da tek bir seriye değil, üst seriler grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük değer kümeler arasına daha fazla boşluk ekler; daha küçük değerleri ise daha yoğun hâle getirir.

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

## **Show or Hide Series Lines**

Seri çizgileri, bir grafiğin ilgili bölümlerini görsel olarak birbirine bağlar. Desteklenen yığılmış çubuk ve OfPie grafiklerinde, [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) yöntemiyle gösterimlerini açıp kapatabilirsiniz. İki‑boyutlu yığılmış çubuk ve sütun grafiklerinde, bu çizgiler kategori boyunca eşleşen yığın sınırlarını bağlar. Pie of Pie ve Bar of Pie grafiklerinde ise ana çizmeyi ikincil çizmeye bağlar. Bu ayar, diğer grafik tipleri için genel bir bağlayıcı değildir.

Gruba, [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden erişin. Ayar, o grup içindeki tüm serilere uygulanır. [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#hasSeriesLines--) yalnızca okunabilir ve üst grup ayarını yansıtır; güncellemek için grubun ayarlayıcısını kullanın.

Aşağıdaki örnek, varsayılan veriyle bir [PieOfPie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#PieOfPie) grafik oluşturur, aynı grafiği seri çizgileri açık ve kapalı olarak kaydeder, karşılaştırma için iki sunum üretir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Seri çizgileri açık | Seri çizgileri kapalı |
| --- | --- |
| ![Seri çizgileri açık Pie of Pie grafiği](series_lines_enabled.png) | ![Seri çizgileri kapalı Pie of Pie grafiği](series_lines_disabled.png) |
| İki çizgi, ana pasta ile ikincil pastayı bağlar. | İki pasta görünür, ancak bağlayıcı çizgiler gizlenir. |

Seri çizgileri, etiketleri veri noktalarına bağlayan lider çizgilerden, eksenleri işaretleyen ızgara çizgilerinden ve veri değerlerini temsil eden çizgi grafik çizgilerinden farklıdır. Bu ayar, bu öğeleri kontrol etmez.

## **FAQ**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) enumʼu tarafından temsil edilen tüm grafik tipleri veri kullanır, ancak serilerin değer yapısı ve ayarları farklıdır. Örneğin, kategori grafiklerinde kategori ve değerler bulunurken, dağılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise ek olarak baloncuk boyutları vardır. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarında geçerlidir.

**Grafik seri grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) uyumlu serileri, grup‑seviyesindeki çizim ayarlarını paylaşan serileri içerir. Kombinasyon grafiği birden çok grup içerebilir; bu nedenle bir seriden ulaşan grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler üretir. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategorileri temizleyebilirsiniz. Bir aşırı yükleme, varsayılan verisiz bir grafik de oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) içindeki hücrelere referans verir. Başvurulan hücre değiştiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir seriyi değil, sadece bir noktayı nasıl temizlerim?**

Diğer noktaları tutmak için ilgili değer hücresini `null` yapın; nokta kategori konumunu bir boş nokta olarak korur. [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) yalnızca tüm noktaları kaldırmak istediğinizde kullanılmalıdır; aksi takdirde diğer noktalar silinir.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik tipi ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları, sıfır değerlerini veya komşu noktaları bağlayarak gösterebilir. Eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Control the Display of Empty Cells](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) ve ardından [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ile renk ayarlaması yapın. Bireysel bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler yalnızca biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi kazanır?**

Açıkça ayarlanmış veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimini veya, seri biçimi tanımlı değilse otomatik grafik stili ve temasını kullanır. Çakışma ve boşluk genişliği gibi grup ayarları düzeni kontrol eder; nokta‑seviyesinde biçimlendirme geçersiz kılmaz.

**Bir grafik kaç seriyi barındırabilir?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği sınırlayıcı faktörlerdir.

**Sütunlar çok yakın veya çok uzak olduğunda ne yapmalıyım?**

Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) yöntemini çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak ise kümeleri birbirine yaklaştırın.