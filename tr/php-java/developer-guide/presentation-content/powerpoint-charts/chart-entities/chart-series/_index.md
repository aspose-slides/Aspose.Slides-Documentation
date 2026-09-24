---
title: PHP ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/php-java/chart-series/
keywords:
- grafik serileri
- seri üst üste binmesi
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
description: "PHP ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, üst üste binme, boşluk genişliği ve negatif değerlerin nasıl yönetileceğini öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/) ilgili değerler kümesini temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartcategory/) nesneleri, seri tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri, yalnızca görüntü metni olarak saklanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getCell) yöntemine geçirilen çalışma sayfası, satır ve sütun dizinleri sıfır tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluştururken faydalıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, sınıflar ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Bir serideki tüm noktalar için varsayılan görünümü sağlayan, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getFormat) gibi seri düzeyindeki ayarlar.
- Bir nokta için seri görünümünü geçersiz kılan, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getFormat) gibi veri noktası ayarları.
- UyumlU serilere aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/) içinde ait olan grup ayarları. Üst üste binme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getParentSeriesGroup) yöntemiyle erişin.

Herhangi bir açık nokta veya seri dolgu ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Üst Üste Binmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getOverlap) bir 2D grafikte çubukların veya sütunların -%100 ile %100 arasında ne kadar üst üste geldiğini rapor eder. Bu, üst grup ayarının yalnızca okunabilir bir yansımasıdır. Bu gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk ya da sütun gösteren grafik türlerine uygulanır; bir birleşik grafikte ilişkili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için üst üste binmeyi ayarlar:

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

![Seri üst üste binmesi](series_overlap.png)

## **Seri Doldurma Rengini Değiştir**

Bir bütün seri için varsayılan dolgu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getFormat) kullanın. Bir noktanın zaten açık bir dolgusu varsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getFormat) ayarı o nokta için seri dolgusunu geçersiz kılar.

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

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1’de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça gösterir:

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

Mevcut bir grafikte zaten [ChartSeries.getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getName) tarafından başvurulan hücreyi de güncelleyebilirsiniz. Bu yaklaşım, belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Doldurma Rengini Al**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) seri indeksinden ve grafik stilinden hesaplanan rengi döndürür. Bu, seri dolgusu açıkça tanımlanmadığında kullanılan renktir. Yöntemi çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

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

Tam renkler, grafik stili ve temaya bağlıdır.

## **Grafik Serisi İçin Ters Doldurma Rengini Ayarla**

Çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Noktaya da etkisinin görülmesi için negatif bir değer atanmıştır:

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

## **Belirli Bir Veri Noktası Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getValue) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, boş değer ayarlarına göre değerini boş olarak kabul eder.

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

Saçılım grafiklerinde ayrı X ve Y hücreleri, balon grafiklerinde ise bir boyut hücresi kullanılır. Sadece kaldırmak istediğiniz değeri temsil eden hücreyi temizleyin. Diğer noktaları tutmak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointcollection/#clear) çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell::setValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setValue) yöntemini `null` ile çağırın. Sayısal sıfır, boş hücre ayarına bakılmaksızın sıfır olarak kalır.

Grafiğin boş hücreleri nasıl görüntüleyeceğini seçmek için [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#setDisplayBlanksAs) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresini sıfır ya da aradeğerle doldurmaz.

Aşağıdaki bağımsız örnek, bir serili bir çizgi grafiği oluşturur, Gün 3 için değeri temizler ve grafiği her modda kaydeder. Giriş dosyası gerektirmez. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40`dır:

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

Her çıktı dosyası, kaydetmeden önce atanmış modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek için istediğiniz modu atayın ve sunumu yalnızca bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı veriyi üç dosyada da gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Aynı veriye sahip çizgi grafikler: Boşluk Gün 3'te çizgiyi keser, Sıfır çizgiyi sıfıra düşürür, ve Uzatma Gün 2 ile Gün 4'ü bağlar.](display_blanks_as.png)

Görünüm, grafik türüne bağlıdır. Bir çizgi grafik, üç modu da kolayca karşılaştırmayı sağlar. Çubuk ve sütun grafiklerinde eksik bir kategoriye bağlanacak bir çizgi olmadığından `Span` yukarıda gösterilen bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicilere sahip bir saçılım grafik de bağlayıcı çizgiye sahip değildir. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Üst üste binme gibi, tek bir seriye değil üst grup serisine aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer ise kümeleri daha sıkışık yapar.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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
Tüm grafik türleri, [ChartType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) enum'ı tarafından temsil edilen, grafik verisi kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değerler, saçılım grafikleri X ve Y değerleri, balon grafikleri ise balon boyutları kullanır. Seri tipine uygun veri noktası oluşturma yöntemini kullanın. Üst üste binme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/) uyumlu serileri, grup düzeyinde çizim ayarlarını paylaşacak şekilde içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bu nedenle bir seriden erişilen grupta yapılan değişiklik, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**  
Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri seti eklemeden önce seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme aynı zamanda varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**  
Seri adları, kategori etiketleri ve veri noktası değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizilmesi için kategori satırlarını ve seri-değer satırlarını hizalı tutun.

**Tüm seriyi değil tek bir noktayı nasıl temizlerim?**  
İlgili değer hücresini `null` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak tutun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointcollection/#clear) yöntemini yalnızca o seriden tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırırsanız, her serinin değerlerinin kategori koleksiyonuyla hizalı kalmasını sağlamak için serileri güncelleyin.

**Boş noktalar nasıl görüntülenir?**  
Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/#setDisplayBlanksAs) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluklar (gaps), sıfır değerler (zero) ya da komşu noktaları bağlayarak (span) gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**  
Desteklenen çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#setInvertIfNegative) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Hem seri hem nokta biçimlendirilmiş olduğunda hangisi kazanır?**  
Açık veri noktası biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını kullanmaya devam eder veya seri formatı tanımlı değilse otomatik grafik stilini ve temasını kullanır. Üst üste binme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta düzeyinde biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısında bir limit var mı?**  
Aspose.Slides ayrı bir sabit seri sayısı limiti uygulamaz. Pratikte, sunum dosyasının kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınırlamayı belirler.

**Sütunlar çok yakın ya da çok uzakta olduğunda ne değiştirmeliyim?**  
Uygun üst seri grubu üzerinde [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri daha yakın hâle getirebilirsiniz.