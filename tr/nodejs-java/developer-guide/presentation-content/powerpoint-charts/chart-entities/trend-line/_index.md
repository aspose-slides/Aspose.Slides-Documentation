---
title: JavaScript ile Sunum Grafiklerine Eğri Çizgiler Ekleme
linktitle: Eğri Çizgi
type: docs
url: /tr/nodejs-java/trend-line/
keywords:
- grafik
- eğri çizgi
- üstel eğri çizgi
- doğrusal eğri çizgi
- logaritmik eğri çizgi
- hareketli ortalama eğri çizgi
- polinom eğri çizgi
- güç eğri çizgi
- özel eğri çizgi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js aracılığıyla Java kullanarak PowerPoint grafiklerine eğri çizgileri hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğri çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine eğri çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğri çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemenin nasıl yapılacağını açıklar ve ileri ve geri eğri çizgi projeksiyon değerleri ile eğri çizgilerin PDF veya SVG olarak dışa aktarılırken ve grafikler görüntülere render edildiğinde korunup korunmadığına dair kısa bir SSS içerir.

## **Eğri Çizgi Ekle**

Bir grafik serisine eğri çizgi eklemek için [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) kullanın, türünü ise [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur ve üç serisinin her birine iki eğri çizgi ekler.

Üstel eğri çizgi, denklemini ve R-kare değerini [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) ve [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue) ile gizler, doğrusal eğri çizgi ise kırmızıdır. Logaritmik eğri çizgi, özel bir etiket için [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) kullanır. Hareketli ortalama, üç veri noktasının bir [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) değerini ve özel bir [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) kullanır.

Polinom eğri çizginin [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) değeri üçtür ve bir kategori ileri [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward) ile uzatılır. Güç eğri çizgi ise bir kategori geri [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward) ile uzatılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eğri Çizgi Kesiti Ayarla**

[setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) kullanarak bir eğri çizginin Y değerini X = 0'da sabitleyin. Bu ayar, doğrusal, üstel ve polinom eğri çizgileri için desteklenir.

Örneğin, bir üretim maliyet modeli, sıfır olmayan üretim hacimlerinde ölçümler farklı bir temel çizgisi önerse bile, 100 sabit maliyetle başlaması gerekebilir. Doğrusal bir eğri çizgi için kesiti sabitlemek, `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uydurulur. Bu, zaten uydurulmuş bir çizgiyi sadece kaydırmaz. Eksen kesişim ayarları, grafiğin eksenlerinin nerede buluşacağını kontrol eder, uydurulmuş eğri çizginin katsayılarını değil.

Aşağıdaki örnek, 1'den 4'e kadar üretim hacimleri ve 170, 200, 230 ve 260 maliyetleriyle bir dağılım (XY) grafiği oluşturur. Grafik, varsayılan otomatik kesitle kaydedilir, kesit 100 olarak ayarlanır ve ikinci bir PPTX dosyası kaydedilir. İki dosya yalnızca kesit ayarında farklılık gösterir. Eğri çizgi denklemini gösterir ve X = 0'a kadar uzanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otomatik hesaplama ile bu veriler `y = 30x + 140` üretir. Kesiti 100 olarak ayarlamak ise yaklaşık olarak `y = 43.33x + 100` verir: sıfırdaki uydurulan değer bilinen temel çizgiyle eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesit | 100'lü sabit kesit |
| --- | --- |
| ![140 otomatik olarak hesaplanan kesitle doğrusal eğri çizgisi](intercept-automatic.png) | ![100 sabit kesitle doğrusal eğri çizgisi](intercept-fixed.png) |

Her iki görüntü de aynı veri ve eksen ölçeklerini kullanır. Eğri çizgileri, kesitlerini göstermek için X = 0'a kadar uzatılır.

Varsayılan olarak, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN` döndürür; bu, sıfır yerine belirtilmemiş bir kesiti temsil eder. Kesit daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Çizgi Ekle**

Özel bir çizgi, seri verilerinden hesaplanan bir eğri çizgi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) kullanarak grafiğin üstüne yatay bir çizgi ekler. Çizginin konumu slayt koordinatlarıyla, nokta biriminde belirtilir; bu yüzden grafik sol kenarından başlar ve grafiğin ortasına kadar uzanır. Genişliği grafiğin genişliğiyle aynıdır. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) çizgiye dolu kırmızı bir renk verir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**'İleri' ve 'geri' bir eğri çizgi için ne anlama geliyor?**

Bunlar, eğri çizginin ileri/geri projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde eksen birimlerinde; dağılım olmayan grafiklerde kategori sayısında. Yalnızca negatif olmayan değerler kabul edilir.

**Sunum PDF veya SVG olarak dışa aktarılırken ya da bir slayt bir görüntüye render edilirken eğri çizgi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerini görüntülere render eder; eğri çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin bir görüntüsünü [grafiğin bir görüntüsünü dışa aktar](/slides/tr/nodejs-java/create-shape-thumbnails/) yöntemi de mevcuttur.