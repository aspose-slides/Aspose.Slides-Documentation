---
title: PHP Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for PHP via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi sadeleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirleneceğini gösterir. Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamanın, bir grafikle ilişkili harici çalışma kitabının yolunu almanın ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemenin nasıl yapılacağını gösterir. Boş hücreleri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir gösterim modlarının çizgi grafiği karşılaştırmasını görmek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Grafiğin gizli çalışma sayfası satırları ve sütunlarından veri çizip çizmeyeceğini kontrol etmek için [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setplotvisiblecellsonly/) kullanın. Sadece görünür hücreleri çizmek için `true`, görünür ve gizli hücreleri birlikte dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satırlarını veya sütunlarını gizlemez ya da göstermek için kullanılmaz.

Dosyayı indirin: [hidden-source-data.pptx](hidden-source-data.pptx) ve çalışma dizinine yerleştirin. İlk slaytı, ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getchartdataworkbook/) ile erişin ve gizli durumlarını incelemek için [ChartDataCell::isHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/ishidden/) metodunu okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 göründür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/readworkbookstream/) ile koruyun ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setrange/) kullanın. Sadece bayrağı değiştirmek, bu örnekteki önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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

            // Gömülü çalışma kitabından grafik verilerini yenileyin.
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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) ile `hidden_cells_true.pptx` dosyasını ve tüm altı değerle `hidden_cells_false.pptx` dosyasını kaydeder. Aşağıdaki görseller iki çizim kipini gösterir. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Sadece görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Sadece görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren gizli bir hücre, boş bir hücreden farklıdır. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setdisplayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verilerini dahil etmez ya da çıkarmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for PHP via Java, grafik verileri (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okumanıza ve yazmanıza izin veren [readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir versiyonla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart::validateChartLayout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/validatechartlayout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik içine yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `chart.pptx` dosyasına ihtiyaç duyar. Yorum satırı, çalışma kitabı düzenlemesinin nerede yapılacağını gösterir; çalışan örnek orijinal çalışma kitabını geri yazar ve bellek içinde düzeni doğrular.

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

        // Burada çalışma kitabı baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli tüm seri ve kategori eşlemelerini yeniden oluşturun ve grafiği kullanın.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketleri olarak kullanabilirsiniz. Aşağıdaki adımlar, bir balon grafiğindeki etiketleri veri çalışma kitabındaki hücrelere nasıl bağlayacağınızı gösterir.

1. Presentation sınıfının bir örneğini oluşturun.
2. Sıfır tabanlı indeksi ile ilk slayta erişin.
3. Varsayılan veri ile bir balon grafiği ekleyin.
4. Grafik serisine erişin.
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
6. Sunumu kaydedin.

Bu örnek, en az bir slayt içeren `chart2.pptx` dosyasını açar ve varsayılan veri ile bir balon grafiği ekler. İlk serideki ilk üç etiket için 0. çalışma sayfasındaki A10:A12 hücrelerini kullanır, hücrelerden etiketlemeyi etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve her çalışma sayfası adını konsola yazdırır.

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

Bu örnek, varsayılan veri ile bir 3D sütun grafiği oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti, ikincisi 0. çalışma sayfasındaki C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datasourcetype/) enumeration'ı her ad için kaynağı seçer. Sonuç `pres.pptx` dosyasına kaydedilir.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışması (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` yöntemiyle birlikte [WorkbookType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/workbooktype/) enumeration'ını kullanabilirsiniz. Bu örnek, `sample.pptx` ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve gömülü .xlsb çalışma kitabı bulunan her grafik için bir tanılama mesajı yazdırır.

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

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını kullanmayı destekler.

### **Harici Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setexternalworkbook/) kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği o harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur, çalışma kitabını `externalWorkbook1.xlsx` dosyasına yazar ve dosya yazımını tamamladıktan sonra dosyayı grafik veri kaynağı olarak atar. Bağlantılı sunumu `externalWorkbook.pptx` olarak kaydeder.

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

### **Harici Çalışma Kitabı Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setexternalworkbook/) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolu taşınmışsa yolu güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verilerini doğrudan düzenleyemezsiniz, ancak bu çalışma kitapları harici bir veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` dosyasının bulunmasını gerektirir. `Sheet1` adlı çalışma sayfası B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içermelidir. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve A1:B4 aralığını bir seri ve üç kategoriye eşlemek için [setRange](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setrange/) kullanır. Sonuç `Presentation_with_externalWorkbook.pptx` olarak kaydedilir.

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

[setExternalWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/setexternalworkbook/) metodunun `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğe bağlı çalışma kitabını belirlemek için, önce grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek çalışma kitabı yolunu elde edebilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.
2. Sıfır tabanlı indeksi ile ilk slayta erişin.
3. İlk şeklin bir grafik olduğundan emin olun.
4. Grafik veri kaynağı türünü okuyun.
5. Kaynak bir harici çalışma kitabı ise, yolunu okuyun.

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slaydındaki ilk şekli inceler. Grafik, harici bir çalışma kitabına bağlanmışsa, konsola [getExternalWorkbookPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) yolunu yazdırır. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

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

### **Grafik Verisini Düzenle**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içerikleri değiştirdiğiniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `presentation.pptx` dosyasını ve erişilebilir bir harici çalışma kitabını gerektirir. İlk serinin ilk veri noktasının hücre temelli değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını da güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

Bir grafik, eksik veya bulunamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) değerini `true` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki PHP örneği, ilk slaydının ilk şekli bir grafik olan ve bulunamayan bir harici çalışma kitabına referans veren `presentation.pptx` dosyasını açar ve kurtarılan verilere [Chart::getChartData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/getchartdata/) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişir:

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

        // Kurtarılmış çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Harici çalışma kitabı bulunamaz ve kurtarma devre dışı bırakılırsa, Aspose.Slides bir istisna fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüşümse ve harici çalışma kitabına yapılan değişiklikler önbellekte bulunmuyorsa, kurtarmayı yalnızca o zaman etkinleştirin.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [harici bir çalışma kitabının yolu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında depolar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici bir veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides ile uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, [harici dosyaya bağlantı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre temelli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa, çalışma kitabının bir kopyasını kullanın.

**Harici dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken bir parola kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak) hazırlamak ve bu kopyaya bağlanmaktır.

**Birden çok grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyayı güncellemek, bir sonraki veri yüklemesinde her grafiğe yansır.