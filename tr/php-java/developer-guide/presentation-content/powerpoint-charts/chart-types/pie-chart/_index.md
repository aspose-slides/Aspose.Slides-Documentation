---
title: PHP Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/php-java/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP ile Aspose.Slides kullanarak pasta grafiklerini oluşturun ve özelleştirin. İkincil grafikleri yapılandırın, veri etiketlerini gösterin ve PowerPoint'te otomatik dilim renklerini uygulayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikler için ikincil grafik seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklendirmesini nasıl etkinleştireceğinizi gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **İkincil Grafik Seçenekleri Pie of Pie ve Bar of Pie Grafikler için**

Aspose.Slides for PHP via Java, Pie of Pie ve Bar of Pie grafikler için ikincil grafik seçeneklerini destekler. Bu seçenekler, ikincil grafiğin boyutunu ve veri noktalarının iki grafik arasında nasıl bölündüğünü kontrol eder.

Aşağıdaki örnek, yeni bir sunumda Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) yöntemi ikincil grafik boyutunu ana grafiğin %149'una ayarlar. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yüzde tabanlı bölmeyi seçer ve [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) eşiği %53 olarak belirler.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Değerleri göster ve ikincil grafiği yapılandır.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **İkincil Grafik İçin Kategorileri Seçin**

Yüzde değerlerinden bağımsız olarak belirli kategorileri ikincil grafikte gruplamak istediğinizde özel bölmeyi kullanın. Örneğin, bir satış raporu Online ve Events kategorilerini birlikte gösterebilir, böylece okuyucular bu iki kanalı karşılaştırabilir, her ne kadar toplam satışların %35 ve %10'luk bir payı olsa da.

[setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yöntemini [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) ile çağırın ve noktaları [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) aracılığıyla seçin. Koleksiyonun [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) yöntemi seride sıfır tabanlı bir indeks kabul eder; bir veri noktası nesnesi eklemek için [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) kullanın. Bu örnekte, indeks 1 Online'ı, indeks 3 ise Events'i seçer. Partners da geçici olarak eklenir ve ardından [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) ile dışlanır.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Varsayılan verileri kanal bazında satışlarla değiştir.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Online'ı sıfır tabanlı indeksiyle ve Events'i veri noktası nesnesiyle seç.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Partners'ı seçimden dışla, kaynak verisini silmeden.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) ve Events (10) ikincil grafikte ayrı dilimler olarak görünür. Birincil grafikte, 45 değerinde birleşik bir dilim olarak temsil edilirler; bu dilimin yanında Retail (40) ve Partners (15) bulunur. Partners'ın özel seçimden çıkarılması, onu birincil grafikte tutar; kategori ya da değeri grafik veri kaynağından silmez.

Aşağıdaki resim, kaydedilmiş sunumu PowerPoint'te gösterir:

![İkincil grafikte Online ve Events ile Pie of Pie grafiği ve birincil grafikte 45 birleşik değeri](pie_of_pie_custom.png)

## **Otomatik Pasta Grafik Dilimi Renklerini Ayarla**

Aspose.Slides for PHP via Java, pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla bir pasta grafik oluşturur ve varsayılan verileri üç çeyrek kategori ve değerleriyle değiştirir. [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) yöntemi 20, 50 ve 30 değerlerini etiket olarak görüntülerken, [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) her dilim için farklı bir renk etkinleştirir.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Ortalanmış bir grafik başlığı ekle.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // İlk çalışma sayfasını kullanarak varsayılan verileri değiştir.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Değerleri göster ve dilimlere farklı renkler ata.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) pasta grafikler için ikincil bir grafik, Pie of Pie ve Bar of Pie tipleri dahil.

**Grafiği yalnızca bir görüntü (örneğin PNG) olarak dışa aktarmak mümkün mü?**

Evet, [grafiği doğrudan bir görüntü olarak dışa aktar](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (örneğin PNG) bütün sunumu dışa aktarmadan yapabilirsiniz.