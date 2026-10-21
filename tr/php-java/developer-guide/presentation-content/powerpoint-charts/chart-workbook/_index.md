---
title: Sunumlarda Grafik Çalışma Kitaplarını PHP Kullanarak Yönet
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/php-java/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirtileceğini gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabı nasıl oluşturulup atanacağını, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Gizli çalışma sayfası satırları ve sütunlarından veri çizerken bir grafiğin davranışını kontrol etmek için [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) yöntemini kullanın. Görünür hücreleri yalnızca çizdirmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satırlarını veya sütunlarını gizleme ya da gösterme işlemini yapmaz.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını (`A1:C4`) içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (hidden row) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişin ve gizli durumlarını incelemek için [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) okuyun. Bu yöntem gizli durumunu değiştirmenize gerek kalmadan rapor eder. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken ayrıca [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) kullanarak gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yükleyin. Bayrağı yalnızca değiştirmek bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Gömülü çalışma kitabından grafik verilerini yenile.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükle.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünür Perakende değerlerini (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak verileri dahil etmez ya da hariç tutmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek amacıyla kaynak aralıklarını inceleyin. [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar olan hücreleri tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekillerde grafik olup olmadığını kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafiğe geçer.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Çalışma Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides for PHP via Java, [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sunar; bu yöntemler, Aspose.Cells ile düzenlenmiş grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Note** grafik verilerinin aynı şekilde düzenlenmiş olması veya kaynağa benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaytının ilk şekli olarak bir grafiği içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Çalışma Kitabı Değişikliğinden Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir versiyonla değiştirirken, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Çalışma kitabı baytlarını burada değiştirin, örneğin Aspose.Cells kullanarak.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri başvurularını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimleri Ayarla**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) yöntemi, grafik gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol eder. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamak ve bir katsayısını beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutarak hesaplamalar ve grafik çizimi için kullanılabilir tutun.

Bir sayı biçimi yalnızca görüntüyü değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` değerini `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde, `0.00000` biçimi `0.1234567` değerini `0.12346` olarak gösterir ancak saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişir. 0 numaralı çalışma sayfasında B2 dönüşüm oranını, C2 ise katsayısını içerir. Her iki hücre de grafik değerleri sağlar. Örnek ayrıca kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Çalışma kitabı hücre biçimleri, doğrudan grafik eksenlerine veya veri etiketlerine ayarlanan biçimlerden ayrıdır. Bu örnekte, her etiket, [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true` olarak ayarlandığı için kaynak hücrenin değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` olduğu için kaynak sayı biçimini takip eder. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` gösterir, aşağıda gösterildiği gibi. Dikey eksen, kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) `0.00` olarak ayarlar ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` olur.

Bir veri etiketini bağımsız olarak biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirmesi için [Chart Data Labels](/slides/tr/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunumu yeniden açtıktan sonra kaydedilip oluşturulmuştur:

![Kaynak‑bağlantılı etiketleriyle 12.5000% ve 0.12346 gösteren sütun grafik ve bağımsız biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. 0 numaralı çalışma sayfasındaki A10:A12 hücrelerini ilk serinin ilk üç etiketi için kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Çalışma Sayfalarını Yönet**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek bir pasta grafik oluşturur, varsayılan verileri ekler ve her çalışma sayfasının adını konsola yazar.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Veri Kaynağı Türünü Belirle**

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad sabit bir dize; ikincisi 0 numaralı çalışma sayfasındaki C1 hücresinden alır. [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Bu formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` yöntemini ve [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) enumunu kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı içeren her grafik için tanı mesajı yazar.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    $presentation->dispose();
}
```

## **Dış Çalışma Kitabı**

Aspose.Slides, dış çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu dış çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra dış çalışma kitabı grafik veri kaynağı olarak atanır, ardından bağlı sunum kaydedilir.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Dış Çalışma Kitabını Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) yöntemiyle bir grafiğe dış bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda dış çalışma kitabının yolu (taşınmışsa) güncellenmek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de seri adı, A2:A4’te kategori adları ve B2:B4’te sayısal değerler bulunan bir dış çalışma kitabını kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafikle sunumu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metodundaki `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` **false** olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir örnek URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için, grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, dış çalışma kitabına bağlı bir grafik olup olmadığını kontrol eder; eğer öyleyse [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) konsola yazar. Ardından sunumun bir kopyasını kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Grafik Verilerini Düzenle**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir dış çalışma kitabına bağlanır. İlk serinin ilk veri noktasının hücre‑tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek dış XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabı kullandığında, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki PHP örneği, ilk slayttaki ilk şekil olarak bir grafik ve kullanılamayan bir dış çalışma kitabına referans veren bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişir:

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Dış çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön bellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; çünkü ön bellek, dış çalışma kitabında sunum en son güncellendiği zamandan sonraki değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış ya da gömülü bir çalışma kitabına bağlı olup olmadığını belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ve [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabı ise, tam yolu okuyarak bir dış dosyanın kullanıldığından emin olabilirsiniz.

**Dış çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez — yalnızca veri kaynağı olarak kullanılabilir.

**Aspose.Slides sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre‑tabanlı grafik verilerini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa, çalışma kitabının bir kopyasını kullanın.

**Dış dosya şifreli olduğunda ne yapmalıyım?**

Aspose.Slides, bağlarken şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak ya da bir çözülmüş kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/java/)) hazırlamak ve bu kopyaya bağlamaktır.

**Birden çok grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler her bir grafiğin bir sonraki veri yüklemesinde yansıtılır.