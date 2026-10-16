---
title: PHP'de Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/php-java/trend-line/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint grafiklerine trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinomsal ve güç dahil olmak üzere çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemeyi açıklar ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG'ye dışa aktarılırken ve grafiklerin görüntülere dönüştürülürken korunup korunmadığına dair kısa bir SSS içerir.

## **Eğri Çizgisi Ekle**

Bir grafik serisine trend çizgisi eklemek için [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) kullanın ve türünü [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur ve üç serisinin her birine iki trend çizgisi ekler.

Üstel trend çizgisi, denklemini ve R-kare değerini [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) ve [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/) aracılığıyla gizler, doğrusal trend çizgisi ise kırmızıdır. Logaritmik trend çizgisi, özel bir etiket için [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) kullanır. Hareketli ortalama, üç veri noktasının bir [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) ve özel bir [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) kullanır.

Polinomsal trend çizgisinin derecesi üçtür ve [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/) ile ayarlanır, ayrıca [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/) ile bir kategori ileri uzatılır. Güç trend çizgisi ise [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/) ile bir kategori geri uzatılır.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eğri Çizgi Kesişimini Ayarla**

[setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) kullanarak bir eğri çizgisinin Y değerini X = 0'da sabitleyin. Bu ayar; doğrusal, üstel ve polinomsal trend çizgileri için desteklenir.

Örneğin, bir üretim maliyet modeli, sıfır olmayan üretim hacimlerinde ölçümler farklı bir temel değer önerse bile, 100'lük bilinen sabit maliyetlerle başlamalıdır. Doğrusal bir trend çizgi için, kesişimi sabitlemek `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uyarlanır. Bu, zaten uyarlanmış bir çizgiyi sadece taşımaz. Ekseni kesişim ayarları, grafiğin eksenlerinin nerede buluştuğunu kontrol eder, uyarlanmış eğri çizgisinin katsayılarını değil.

Aşağıdaki örnek, 1 ile 4 arasındaki üretim hacimleri ve 170, 200, 230 ve 260 maliyetleri kullanarak bir dağılım (XY) grafiği oluşturur. Grafik, varsayılan otomatik kesişimle kaydedilir, kesişim 100 olarak ayarlanır ve ikinci bir PPTX kaydedilir. İki dosya yalnızca kesişim ayarında farklılık gösterir. Trend çizgisi denklemini gösterir ve X = 0'a kadar geri uzanır.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Otomatik hesaplamayla, bu veriler `y = 30x + 140` üretir. Kesişimi 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` verir: sıfırdaki uyarlanmış değer bilinen temel değerle eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesişim | 100 sabit kesişim |
| --- | --- |
| ![Otomatik olarak hesaplanan 140 kesişimli doğrusal eğri çizgisi](intercept-automatic.png) | ![100 sabit kesişimli doğrusal eğri çizgisi](intercept-fixed.png) |

Her iki görüntü de aynı veri ve eksen ölçeklerini kullanır. Trend çizgileri kesişimlerini göstermek için X = 0'a kadar geri uzatılmıştır.

Varsayılan olarak, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) `NaN` döndürür; bu, sıfır yerine belirtilmemiş bir kesişimi temsil eder. Kesişim daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Çizgi Ekle**

Özel bir çizgi, seri verilerinden hesaplanan bir trend çizgi yerine grafiğin üzerine çizilen bir şekildir. Bu örnek, [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) kullanarak grafiğin üzerine yatay bir çizgi ekler. Çizginin konumu slayt koordinatlarıyla, puan cinsinden belirtilir; bu nedenle çizgi grafiğin sol kenarından başlar ve grafiğin ortasına kadar uzanır. Genişliği grafiğin genişliğiyle eşleşir. [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) çizgiye katı kırmızı bir renk verir.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**'İleri' ve 'geri' bir eğri çizgi için ne anlama geliyor?**

Bunlar, eğri çizginin ileri/geri projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler izinlidir.

**Eğri çizgi, sunum PDF veya SVG olarak dışa aktarılırken veya bir slayt görüntüye dönüştürülürken korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/php-java/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere render eder; eğri çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/php-java/create-shape-thumbnails/) için bir yöntem de mevcuttur.