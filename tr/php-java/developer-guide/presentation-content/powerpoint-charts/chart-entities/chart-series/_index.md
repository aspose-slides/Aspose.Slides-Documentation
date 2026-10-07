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
description: "PHP ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, örtüşme, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) bir ilişkili değer kümesini temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) bir veya birden fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Seri adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak saklanmaz, [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0'ı seri adları için, sütun 0'ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) metoduna geçirilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluştururken kullanışlıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklü bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, grup üzerinden [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) erişin.

Açık bir nokta veya seri dolgu ayarı belirlenmemişse, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) bir 2D grafikte çubukların veya sütunların ne kadar örtüştüğünü –%‑100 arasında – rapor eder. Bu, üst grup üzerindeki ayarın yalnızca okunabilir bir yansımasıdır. O gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik tiplerine uygulanır; birleşik bir grafikteki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

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

## **Seri Dolgu Rengini Değiştirin**

Tam bir seri için varsayılan dolgu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) kullanın. Bir nokta için açık bir dolgu zaten tanımlanmışsa, o noktanın [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) ayarı seri dolgusunu geçersiz kılar.

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

## **Seri Adını Değiştirin**

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki değişken adları bu yapıyı açıkça gösterir:

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

Ayrıca [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

### **Birden Çok Hücreden Oluşturulan Seri Adı**

Ürün adı ve raporlama dönemi ayrı hücrelerde saklandığında birleşik bir seri adı yararlı olur. Örneğin, B1 hücresindeki `Product A` ile C1 hücresindeki `2026` değerlerini tek bir seri adı olarak birleştirip her iki kısmı da kaynak hücrelerine bağlı tutabilirsiniz.

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) kullanarak ad aralığını alın, ardından bu koleksiyonu [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add) metoduna gönderin. `skipHiddenCells` parametresi gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `true` dışlar, `false` dahil eder. Aşağıdaki örnek, adı aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını, A2:A3 hücreleri kategori etiketlerini ve B2:B3 hücreleri sayısal değerleri sağlar.

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

Oluşan seri adı `Product A 2026` olup iki hücre değeri arasında bir boşluk bulunur. Lejende bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görsel sonucu göstermektedir:

![Kuzey ve Güney değerlerine sahip sütun grafik ve efsanede birleşik seri adı Product A 2026](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alın**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) metodu, seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metod, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Tam renkler grafik stili ve temaya bağlıdır.

## **Grafik Serisi İçin Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı bir renk olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) yöntemiyle atayın. Negatif sayılar çalışma kitabında aynı kalır; yalnızca görüntülenen renk değişir.

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

![Tersine çevrilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için ters çevirme, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) yöntemiyle etkinleştirilebilir. Aşağıdaki örnekte seri için ters çevirme devre dışı bırakılmış, yalnızca seçili nokta için etkinleştirilmiştir. Noktaya da görünür bir etki sağlamak için negatif bir değer atanmıştır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiği için, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue) üzerinden alınabilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değeri, boş‑değer ayarlarına göre boş olarak işlenir.

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

Seri grafiklerinde X ve Y hücreleri ayrı, baloncuk grafiklerinde ayrıca bir boyut hücresi bulunur. Sadece kaldırmak istediğiniz değeri temsil eden hücreyi temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri gösterir. Bir hücreyi boş yapmak için [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) metodunu `null` ile çağırın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır kalır.

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) metodunu kullanarak grafiğin boş hücreleri nasıl göstereceğini seçin. Bu ayar tüm grafik için geçerlidir ve boş değerlerin nasıl çizileceğini değiştirir; hücreyi sıfır ya da ara bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir çizgi grafik oluşturur, 3. Gün için değeri temizler ve her modu ayrı dosyaya kaydeder. Girdi dosyası gerekmez. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler için kullanılır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

    // 3. günü gerçekten boş bırak, ancak kategorisini ve veri noktasını tut.
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

Her çıktı dosyası, kaydetmeden önce atanan modu dosya adında saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu sadece bir kez kaydedin.

Aşağıdaki karşılaştırma, üç dosyada aynı verinin nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Satır grafiklerde aynı veri: Boşluk modu çizgiyi 3. günde kırar, Sıfır modu çizgiyi sıfıra düşürür, Ve Span modu 2. gün ile 4. gün arasını bağlar.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafikleri üç modu da kolayca karşılaştırır. Çubuk ve sütun grafiklerinde eksik bir kategoriyi bağlayacak bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır‑yükseklikte bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir dağılım grafiğinde de bağlayıcı bir çizgi yoktur. Her grafik tipi için üç ayrı sonuç beklemeyin; kullandığınız tipin çıktısını kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup çubuk veya sütun genişliğinin yüzde olarak ifade edilir. Örtüşme gibi, bu da bireysel seriden değil üst grup serisinden kaynaklanır. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun hâle getirir.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca nihai sunumu kaydeder:

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

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) numaralandırmasıyla temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısı veya ayarları paylaşmaz. Örneğin, kategori grafiklerinde kategoriler ve değerler, dağılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma metodunu kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bu yüzden bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce hem seri hem de kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri, bir [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) içinde hücrelere başvurur. Başvurulan bir hücreyi değiştirmek, ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir bütün seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak o noktayı boş bırakın; kategori konumu korunur. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) metodunu yalnızca serideki bütün noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, diğer serilerin değerlerinin kategori koleksiyonuyla hizalı kalması için güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik tipi ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) yöntemiyle yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ile dönen rengi ayarlayın. Tek bir nokta için davranışı, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler yalnızca biçimlendirmeyi etkiler, depolanan sayısal değeri değiştirmez.

**Bir seri ve bir nokta aynı anda biçimlendirilmişse hangi biçimlendirme geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık seri biçimlendirmesini ya da tanımlı değilse otomatik grafik stilini ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısı için bir sınırlama var mı?**

Aspose.Slides, ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, sunum dosyası kısıtlamaları, mevcut bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın olduğunda ya da çok uzak olduğunda neyi değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırmak, kümeler arasındaki boşluğu genişletir; azaltmak ise kümeleri birbirine daha yakın hâle getirir.