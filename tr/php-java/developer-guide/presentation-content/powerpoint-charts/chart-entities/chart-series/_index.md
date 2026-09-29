---
title: PHP ile Sunuluklarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/php-java/chart-series/
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
- PHP
- Aspose.Slides
description: "PHP ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/) ilişkili değerlerin bir kümesini temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartcategory/) nesneleri seriler arasında paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmaz; [ChartDataCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanılır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getCell) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktalarının başvurduğu hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seriye özgü ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden gruba erişerek örtüşme veya boşluk genişliği gibi seçenekleri ayarlayabilirsiniz.

Açıkça bir nokta veya seri doldurması ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarla**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getOverlap) bir 2D grafikte çubukların veya sütunların ne kadar çakıştığını -%100 ile %100 arasında raporlar. Bu, üst grup üzerindeki ayarın yalnızca okunabilir bir yansımasıdır. O grup içindeki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; kombinasyon grafiğindeki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

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

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştir**

Tüm bir seri için varsayılan doldurmayı ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getFormat) kullanın. Bir noktanın zaten belirlenmiş bir doldurması varsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getFormat) ayarı o nokta için seri doldurmasını geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir doldurma uygular:

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

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Seri adı, grafik veri çalışma kitabında saklanır ve genellikle lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça ortaya koyar:

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

Ayrıca [ChartSeries.getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getName) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Dolgu Rengini Al**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) yöntem, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmamışken kullanılan renktir. Yöntem, hesaplanan rengi okur; yeni bir doldurma atamaz.

Aşağıdaki örnek, her varsayılan seri için otomatik rengi yazdırır:

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

Tam renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir doldurma ile gösterebilir. Düzenli seri doldurmasını katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![Ters çevirilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi yalnızca [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkinliği göstermek için nokta da negatif bir değer alır:

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

## **Belirli bir Veri Noktası Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiği için, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getValue) aracılığıyla elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak işler.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

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

Saçılım grafikleri ayrı X ve Y hücreleri kullanır, balon grafikler ayrıca bir boyut hücresi de kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointcollection/#clear) yöntemini çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Değer içeren gizli hücreler, tamamen boş hücrelerden farklı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya hariç tutmak için [Gizli Satır ve Sütunlardan Veri Dahil Et](/slides/tr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için `null` ile [ChartDataCell::setValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setValue) çağırın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin nasıl gösterileceğini seçmek için [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#setDisplayBlanksAs) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş hücreyi sıfır ya da ara bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün değerini temizler ve her moda göre aynı grafik dosyasını kaydeder. Giriş dosyasına gerek yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` şeklindedir.

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

    // 3. günü gerçekten boş bırakın, ancak kategorisini ve veri noktasını koruyun.
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

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün çalışma kitabında her zaman boştur:

![Satır grafikleri aynı veriyle: Boşluk modu 3. Günde çizgiyi kırar, Sıfır modu çizgiyi sıfıra düşürür, Ve Yay modu 2. Günden 4. Güne bağlar.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Bir satır grafiği üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayacak bir çizgi olmadığından, `Span` bu örnekteki gibi bir bağlantı segmenti üretmez; eksik bir sütun ve sıfır‑yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde sadece işaretçileri olan bir saçılım grafiğinde de bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tipteki çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Çakışma gibi, bu da tek bir seriye değil, üst grup seviyesine aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

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

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) enum'ı tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serilerinin değer yapısı ve ayarları aynı değildir. Örneğin, kategori grafiklerinde kategoriler ve değerler, saçılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup içerebilir; bir seri üzerinden ulaşılan grup ayarlarını değiştirmek, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırlarıyla seri‑değer satırlarını hizalı tutun.

**Bir seriyi tamamen silmek yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayın; böylece noktanın kategori konumu boş bir nokta olarak kalır. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointcollection/#clear) yöntemi yalnızca tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, serilerin değerlerini kategori koleksiyonuyla hizalı tutmak için tüm serileri güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#setDisplayBlanksAs) aracılığıyla yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk olarak, sıfır değeri olarak veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setInvertIfNegative) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) tarafından döndürülen rengi atayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açıkça tanımlı bir seri biçimi bulunmuyorsa otomatik grafik stili ve temasını kullanır. Çakışma ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersizliği oluşturmaz.

**Bir grafiğin içerebileceği maksimum seri sayısı var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve okunabilirlik gibi faktörler kullanılabilecek anlamlı bir üst sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne değiştirilmelidir?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine yakınlaştırabilirsiniz.