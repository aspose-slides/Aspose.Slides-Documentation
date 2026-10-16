---
title: Java'da Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/java/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint grafiklerine Aspose.Slides for Java ile trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkileyen pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğri çizgileri eklemenin nasıl yapılacağını açıklar. Bir grafik oluşturmayı, grafik serilerine eğri çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğri çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek bir grafiğe özelleştirilmiş bir çizgi eklemenin nasıl yapılacağını açıklar ve ileri ve geri eğri çizgisi projeksiyon değerleri ile eğri çizgilerinin PDF veya SVG olarak dışa aktarılırken ve grafikler görüntülere dönüştürülürken korunup korunmadığına ilişkin kısa bir SSS içerir.

## **Eğri Çizgisi Ekle**

Bir grafik serisine eğri çizgisi eklemek için [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) kullanın ve türünü [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir küme sütun grafiği oluşturur ve her bir üç serisine iki eğri çizgisi ekler.

Üstel eğri çizgisi, denklemini ve R-kare değerini [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) ve [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) ile gizler, doğrusal eğri çizgisi ise kırmızıdır. Logaritmik eğri çizgisi, özel bir etiket için [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) kullanır. Hareketli ortalama, üç veri noktası için bir [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) ve özel bir [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) kullanır.

Polinom eğri çizgisi, üçlük bir [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) değerine sahiptir ve bir kategori ileriye doğru [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-) ile uzatılır. Güç eğri çizgisi, bir kategori geriye doğru [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-) ile uzatılır.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Eğri Çizgisi Kesiti Ayarla**

[setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) kullanarak bir eğri çizgisinin Y değerini X = 0'da sabitleyin. Bu ayar doğrusal, üstel ve polinom eğri çizgileri için desteklenir.

Örneğin, bir üretim maliyet modeli, sıfır olmayan üretim hacimlerinde yapılan ölçümler farklı bir temel çizgi önermesine rağmen, 100 birim sabit maliyetle başlamalı olabilir. Doğrusal bir eğri çizgisi için, kesiti sabitlemek denklemi `y = ax + b` yerine `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uydurulur. Bu, zaten uydurulmuş bir çizgiyi sadece kaydırmak anlamına gelmez. Eksen kesişim ayarları, grafik eksenlerinin nerede buluştuğunu kontrol eder, uydurulmuş eğri çizgisinin katsayılarını değil.

Aşağıdaki örnek, 1'den 4'e kadar üretim hacimleri ve 170, 200, 230 ve 260 maliyetleriyle bir dağılım (XY) grafiği oluşturur. Grafiği varsayılan otomatik kesitle kaydeder, kesiti 100'e ayarlar ve ikinci bir PPTX kaydeder. İki dosya sadece kesit ayarı açısından farklıdır. Eğri çizgisi denklemini gösterir ve X = 0'a kadar uzatılır.

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

Otomatik hesaplamayla, bu veriler `y = 30x + 140` üretir. Kesiti 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` üretir: sıfırdaki uydurulmuş değer bilinen temel çizgiyle eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesit | 100 sabit kesit |
| --- | --- |
| ![140 otomatik hesaplanan kesite sahip doğrusal eğri çizgisi](intercept-automatic.png) | ![100 sabit kesite sahip doğrusal eğri çizgisi](intercept-fixed.png) |

Her iki görüntü de aynı veri ve eksen ölçeklerini kullanır. Eğri çizgileri, kesitlerini göstermek için X = 0'a kadar uzatılır.

Varsayılan olarak, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` döndürür; bu, sıfır yerine belirtilmemiş bir kesiti temsil eder. Kesit daha sonra verilerden otomatik olarak hesaplanır.

## **Özelleştirilmiş Çizgi Ekle**

Özelleştirilmiş bir çizgi, serilerden hesaplanan bir eğri çizgisi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, grafiğin üzerine bir yatay çizgi eklemek için [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) kullanır. Çizginin konumu slayt koordinatlarıyla, puan cinsinden belirtilir; bu nedenle grafik sol kenarından başlar ve grafiğin yarısına kadar düşer. Genişliği grafiğin genişliğiyle eşleşir. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) çizgiye katı kırmızı bir renk verir.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

**'İleri' ve 'geri' bir eğri çizgisi için ne anlama gelir?**

Bunlar, eğri çizgisinin ileri/geri yönlerine doğru projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Sadece negatif olmayan değerler izinlidir.

**Sunum PDF veya SVG olarak dışa aktarıldığında ya da bir slayt görüntüye dönüştürüldüğünde eğri çizgisi korunacak mı?**

Evet. Aspose.Slides, sunumları [PDF](/slides/tr/java/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerini görüntülere renderlar; eğri çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin bir görüntüsünü [grafiğin bir görüntüsünü dışa aktar](/slides/tr/java/create-shape-thumbnails/) yöntemi de mevcuttur.