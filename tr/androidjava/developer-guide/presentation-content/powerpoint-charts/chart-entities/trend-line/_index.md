---
title: Android'de Sunum Grafiklerine Trend Çizgileri Ekleme
linktitle: Trend Çizgisi
type: docs
url: /tr/androidjava/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinomsal trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Java ile Aspose.Slides kullanarak PowerPoint grafiklerine trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinomsal ve güç dahil olmak üzere çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemenin nasıl yapılacağını ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG’ye dışa aktarılırken ve grafikler görüntülere dönüştürülürken korunup korunmadığına dair kısa bir SSS'yi içerir.

## **Trend Çizgisi Ekleme**

[ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) kullanarak bir grafik serisine trend çizgisi ekleyin, tipini [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur ve üç serisinin her birine iki trend çizgisi ekler.

Üstel trend çizgisi, denklemini ve R-kare değerini [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) ve [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) ile gizler, doğrusal trend çizgisi ise kırmızıdır. Logaritmik trend çizgisi, özel bir etiket için [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) kullanır. Hareketli ortalama, üç veri noktasının [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) değerini ve özel bir [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) kullanır.

Polinomsal trend çizgisinin [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) değeri üçtür ve bir kategori ileriye [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-) ile uzatılır. Güç trend çizgisi ise bir kategori geriye [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-) ile uzatılır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trend Çizgisi Kesiti Ayarlama**

[setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) kullanarak bir trend çizgisinin Y değerini X = 0'da sabitleyin. Bu ayar, doğrusal, üstel ve polinomsal trend çizgileri için desteklenir.

Örneğin, bir üretim maliyeti modeli, sıfır olmayan üretim hacimlerinde ölçümler farklı bir temel değer önerse bile, bilinen sabit 100 maliyetle başlaması gerekebilir. Doğrusal bir trend çizgisi için, kesiti sabitlemek denklemi `y = ax + b` den `b = 100` e zorlar; eğim bu kısıtlama altında verilere uyarlanır. Bu, zaten uyarlanmış bir çizgiyi sadece taşımak anlamına gelmez. Eksen kesişim ayarları, grafik eksenlerinin nerede buluştuğunu kontrol eder, uyarlanmış trend çizgisinin katsayılarını değil.

Aşağıdaki örnek, 1 ila 4 arası üretim hacimleri ve 170, 200, 230 ve 260 maliyetleriyle bir dağılım (XY) grafiği oluşturur. Grafiği varsayılan otomatik kesitle kaydeder, kesiti 100 olarak ayarlar ve ikinci bir PPTX kaydeder. İki dosya yalnızca kesit ayarında farklılık gösterir. Trend çizgisi denklemini gösterir ve X = 0'a kadar uzanır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik hesaplamayla, bu veriler `y = 30x + 140` üretir. Kesiti 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` elde eder: sıfırdaki uyarlanmış değer bilinen temel değere eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesit | 100 sabit kesit |
| --- | --- |
| ![Otomatik olarak hesaplanan 140 kesitli doğrusal trend çizgisi](intercept-automatic.png) | ![100 sabit kesitli doğrusal trend çizgisi](intercept-fixed.png) |

Her iki görüntü aynı veri ve eksen ölçeklerini kullanır. Trend çizgileri, kesitlerini göstermek için X = 0'a kadar uzatılmıştır.

Varsayılan olarak, [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` döndürür; bu, sıfır yerine belirtilmemiş bir kesiti temsil eder. Kesit daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Bir Çizgi Ekleme**

Özel bir çizgi, seri verilerinden hesaplanan bir trend çizgisi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) kullanarak grafiğin üzerine yatay bir çizgi ekler. Çizginin konumu, slayt koordinatlarında nokta cinsinden belirtilir; bu nedenle grafiğin sol kenarından başlar ve grafiğin ortasına kadar uzanır. Genişliği grafiğin genişliğiyle eşleşir. [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) çizgiye katı kırmızı bir renk verir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Trend çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geriye projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı cinsinden. Yalnızca negatif olmayan değerler izinlidir.

**Trend çizgisi, sunum PDF veya SVG'ye dışa aktarılırken ya da bir slayt görüntüye render edilirken korunur mu?**

Evet. Aspose.Slides, sunumları [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/androidjava/render-a-slide-as-an-svg-image/) biçimlerine dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/androidjava/create-shape-thumbnails/) için bir yöntem mevcuttur.