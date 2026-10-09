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
description: "Aspose.Slides for PHP via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazabileceğinizi, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanmayı, çalışma sayfası koleksiyonlarına erişmeyi ve grafik değerleri için veri kaynağı türünü nasıl belirtebileceğinizi gösterir.

Ayrıca, harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabı nasıl oluşturulup atanır, bir grafikle bağlantılı harici çalışma kitabının yolu nasıl alınır ve çalışma kitabı mevcut olduğunda grafik verileri nasıl düzenlenir konularını gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki fark ve mevcut gösterim modlarının bir çizgi grafiği karşılaştırması için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Etme**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) yöntemini kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `true`, görünür ve gizli hücreleri birlikte dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytında ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) yöntemini okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) kullanın. Bayrağı sadece değiştirmek, bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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
                // Gizli kategorileri de dahil ederek tam kaynak aralığını geri yükleyin.
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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sunum sürümü ve tüm altı değeri içeren bir sürüm olmak üzere iki sürüm kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak verileri eklemez veya hariç tutmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumdaki çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek için kaynak aralıklarını inceleyin. [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar kapsayan hücreleri tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Bu yöntem grafik veya çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafik için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafikle devam eder.

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

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for PHP via Java, [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sağlar; bu yöntemler, (Aspose.Cells ile düzenlenmiş) grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Note** grafik verileri aynı şekilde organize edilmelidir ya da kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafik içeren bir sunumu kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliğinden Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir kitapla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) yönteminin dizin dışı hatasıyla başarısız olmasına neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalışan örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

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

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan veriyle bir balon grafiği ekler. İlk serinin ilk üç etiketi için çalışma sayfası 0’da A10:A12 hücrelerini kullanır, hücrelerden etiketlerin etkinleştirilmesini sağlar ve güncellenmiş sunumu kaydeder.

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

## **Çalışma Sayfalarını Yönetme**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veriyle bir pasta grafiği oluşturur ve her çalışma sayfasının adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirleme**

Bu örnek, varsayılan veriyle bir 3D sütun grafiği oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti kullanır; ikincisi ise çalışma sayfası 0’da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) enum’ı her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılamak**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` yöntemini, [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) enum’u ile birlikte kullanarak desteklenmeyen biçimleri algılayabilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı bulunan her grafik için tanı mesajı yazdırır.

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

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Bir Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarın ve grafiği bu harici çalışma kitabına bağlayın.

Bu örnek, varsayılan veriyle bir pasta grafiği oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemini tamamladıktan sonra harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlanmış sunumu kaydeder.

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

### **Harici Bir Çalışma Kitabı Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) yöntemini kullanarak bir grafiğin veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolu (konumu) değiştirildiğinde de güncellemek için kullanılabilir (çalışma kitabı taşınmışsa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verilerini doğrudan düzenleyemezsiniz, ancak bu çalışma kitapları harici veri kaynağı olarak hâlâ kullanılabilir. Harici bir çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafikle birlikte sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metodundaki `updateChartData` parametresi çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve bulunamayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

Bir grafiğin hangi çalışma kitabına bağlı olduğunu belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bir sunumun ilk slaydındaki ilk şekli inceler; eğer şekil harici bir çalışma kitabına bağlanan bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) metodunu konsola yazdırır. Ardından bir kopyasını kaydeder.

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

### **Grafik Verisini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki değişiklikler gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanır. İlk serinin ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarmak**

Bir grafik, eksik veya erişilemeyen bir harici çalışma kitabı kullanıyorsa, Aspose.Slides, sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki PHP örneği, ilk slayttaki ilk şekil olarak bir grafik ve bulunamayan bir harici çalışma kitabına başvuran bir grafik için çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişir:

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

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir yedekleme olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak bir harici çalışma kitabı ise tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl saklanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak bir yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides ile uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez — yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre tabanlı grafik verilerini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını güncelleyebilir. Orijinali değişmemeli ise çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlama sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresi çözülmüş bir kopya (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/java/)) hazırlamak ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyadaki bir güncelleme her grafiğin bir sonraki veri yüklemesinde yansıtılır.