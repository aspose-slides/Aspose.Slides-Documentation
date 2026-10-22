---
title: PHP ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/php-java/chart-series/
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
- PHP
- Aspose.Slides
description: "PHP ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) bir ilişkili değer kümesini temsil eder ve her [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) o serideki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan veri ile oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri grafik çalışma kitabından [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve geri kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) metoduna geçirilen Çalışma Sayfası, satır ve sütun indeksleri sıfır temellidir. Bu düzen, varsayılan veri ile bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans edilen hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) gibi, bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) gibi, bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) üzerinden erişin.

Hiçbir açık nokta veya seri dolgu ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Seri Değerlerini Sayısal Sabitler Kullanarak Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalardan geliyor ve çalışma sayfası hücre referanslarına ihtiyaç duymuyorsa sayısal sabitler kullanın. Her noktanın [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) sonucunu [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) aracılığıyla atamadan önce [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) yöntemini [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) ile çağırın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak türünü kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) yöntemi seçili türü raporlar; türü koleksiyon ayarıyla değiştirin. `Worksheet` ile referans verilen hücreye erişmek için [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) kullanın. `DoubleLiterals` ile sayı doğrudan okunup yazılabilir; bunun için [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) veya `setAsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafik oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanan değerleri atar. Sunumu kaydeder, tekrar açar ve saklanan değerleri yazdırır.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Nokta değeri kaynak türü, grafik iç veya dış çalışma kitabı yapılandırmasını belirten [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) yönteminden ayrıktır. Sayısal sabitler kullanmak, gömülü çalışma kitabını kaldırmaz. Bu örnekte, çalışma kitabı kategori etiketleri, seri adları ve diğer seriler için hâlâ kullanılmaktadır. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/php-java/chart-workbook/) sayfasına bakın.

Dağılım (scatter) ve balon grafiklerinde, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) yöntemleri sırasıyla [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) ve [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) kaynaklarını seçmenizi sağlar. Balon grafikleri ayrıca [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) ile [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) kaynağını belirler. Her uygulanabilir kaynağı `DoubleLiterals` olarak ayarlayın ve ardından o değerin `setAsLiteralDouble` yöntemiyle sayıları atayın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) 2B bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100 ile %100 arasında bildirir. Bu değer, üst grup üzerindeki ayarın yalnızca okunabilir bir projeksiyonudur. Uyumlu tüm serileri aynı grup içinde güncellemek için [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik tiplerinde geçerlidir; birleşik bir grafikteki diğer seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grubun örtüşmesini ayarlar:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolguyu ayarlamak amacıyla [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) kullanın. Bir noktanın zaten açık bir dolgusu varsa, o noktanın [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) ayarı serinin dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi satır 0, sütun 1 konumunda olup ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça göstermektedir:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Ayrıca, [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) tarafından zaten referans edilen hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Seri adı](series_name.png)

### **Birden Çok Hücreden Oluşan Seri Adı Oluşturma**

Ürün adı ve raporlama dönemi ayrı hücrelerde saklandığında birleşik bir seri adı kullanışlıdır. Örneğin, B1 hücresindeki `Product A` ile C1 hücresindeki `2026` değeri birleştirilerek tek bir seri adı oluşturulabilir; her iki parça da kaynak hücrelerine bağlı kalır.

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) ile ad aralığını alın, ardından bu koleksiyonu [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) metoduna aktarın. `skipHiddenCells` parametresi gizli hücrelerin dahil edilip edilmemesini kontrol eder: `true` gizli olanları dışarıda tutar, `false` dahil eder. Bu örnek, ad aralığındaki tüm hücreleri eklemek için `false` kullanır.

Aşağıdaki örnek bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 yalnızca seri adını temin eder; A2:A3 kategori etiketlerini, B2:B3 ise sayısal değerleri sağlar.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Bu iki hücre seri adını sağlar.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Oluşturulan seri adı `Product A 2026` şeklindedir; iki hücre değeri arasında bir boşluk vardır. Lejende bu, iki sütun için tek bir giriş olarak gösterilir. Sonuç aşağıdaki görselde gösterilmiştir:

![Kuzey ve Güney değerleriyle sütun grafik ve birleşik seri adı Product A 2026 lejende](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) yöntemi, seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu renk, seri dolgu açıkça tanımlanmadığında kullanılır. Yöntemi çağırmak yalnızca hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, varsayılan her seri için otomatik rengi yazdırır:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Kesin renkler grafik stili ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve balon serileri için [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) yöntemini kullanın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini bir seriyle değiştirir. Çalışma sayfası satır 0 serinin adını, sütun 0 kategori adlarını, sütun 1 ise değerleri içerir:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Etkiyi göstermek amacıyla nokta negatif bir değere de atanmıştır:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Belirli Bir Veri Noktası Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `null` yapın. Sütun grafiğinde, çizilen değer [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) ile elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini boş olarak kabul eder ve ilgili boş‑değer ayarına göre davranır.

Aşağıdaki örnek, ilk serinin yalnızca ikinci noktasını temizler:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Dağılım grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ayrıca boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istediğinizde [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) yöntemini çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden farklı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya dışlamak için [Include Data from Hidden Rows and Columns](/slides/tr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) yöntemini `null` parametresiyle çağırın. Sayısal sıfır, boş hücre ayarından bağımsız olarak sıfır olarak kalır.

Grafiğin boş hücreleri nasıl gösterdiğini seçmek için [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) yöntemini kullanın. Bu ayar tüm grafik için geçerlidir ve boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresi sıfır ya da ara değerle doldurulmaz.

Aşağıdaki bağımsız örnek, bir satır grafik oluşturur, 3. Gün için değeri temizler ve her modda aynı grafiği kaydeder. Girdi dosyasına gerek yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 3. günü gerçekten boş bırak, ancak kategori ve veri noktasını koru.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Her çıktı dosyası, kaydetmeden önce atanmış modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu sadece bir kez kaydedin.

Aşağıdaki karşılaştırma üç dosyadaki aynı veriyi gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Aynı veriye sahip satır grafikler: Gap çizgiyi 3. Gün'de kırar, Zero çizgiyi sıfıra düşürür, Span ise 2. Gün'den 4. Gün'e bağlar.](display_blanks_as.png)

Görünüm etkisi grafik tipine bağlıdır. Satır grafiği, üç modu da kolayca karşılaştırmanıza olanak tanır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayacak bir çizgi olmadığından `Span` yukarıdaki bağlayıcı segmanı üretemez; eksik bir sütun ve sıfır yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicilere sahip dağılım grafiği de bağlayıcı çizgi içermez. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde ifadesidir. Örtüşme gibi, bu ayar bireysel seriye değil, üst seri grubuna aittir. Gruba bir kez [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) enum'ı tarafından temsil edilen tüm grafik tipleri veri içerir, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategori ve değerler, dağılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Serinin tipine uygun veri noktası oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun grupları için geçerlidir.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bir seriden erişilen grup ayarlarını değiştirmek, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce hem seri hem de kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri noktası değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) içindeki hücrelere referans verir. Referans verilen bir hücre değiştirilirse ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir seriyi değil sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu koruyun ve boş bir nokta oluşturun. [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırırsanız, diğer serileri kategori koleksiyonuyla hizalı tutmak için güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik tipine ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) yöntemiyle yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları, sıfır değerleri olarak ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) yöntemini çağırın ve [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta her ikisi de biçimlendirilmişse hangi format kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını veya serinin formatı tanımlı değilse otomatik grafik stilini ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakında mı yoksa çok uzakta mı olduğunda ne değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine daha yakın hâle getirin.