---
title: PHP kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını kolayca yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler dış bir çalışma kitabı oluşturma ve atama, bir grafikle ilişkili dış çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verisini düzenleme adımlarını gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için boş hücrelerin gösterilmesiyle ilgili farkı ve kullanılabilir gösterim modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Etme**

Gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeye karar vermek için [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) yöntemini kullanın. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` ayarlayın. Bu ayar yalnızca grafiğin çizimini kontrol eder; çalışma sayfası satır ve sütunlarını gizlemez veya gizlemez.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücrelerinde hâlâ değerler bulunur.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) ile erişin ve gizli durumlarını incelemek için [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) yöntemini okuyun. Bu yöntem gizli durumu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ile koruyun ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken gizli Şubat kategorisini geri getirmek için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) kullanın. Sadece bayrağı değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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
                // Gizli kategorileri de içerecek şekilde tam kaynak aralığını geri yükleyin.
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

Örnek, sadece görünür Perakende değerleri (10 ve 20) içeren bir sunum sürümü ile tüm altı değeri içeren ikinci bir sürüm kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C her iki gömülü çalışma kitabında da gizli kalır.

| Sadece görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Sadece görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değeri olan gizli bir hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl gösterileceğini kontrol etmek için [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) yöntemini kullanın; bu yöntem gizli kaynak veriyi eklemez veya çıkartmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/php-java/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumdaki çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek amacıyla kaynak aralıklarını inceleyin. [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) yöntemi mevcut veri aralığını çalışma sayfası nitelikli bir formül olarak döndürür; örnek: `Sheet1!$A$1:$D$5`. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1‑D5 arasındaki hücreleri mutlak referansla belirtir.

Yöntem grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafikleri bulur. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj verir ve bir sonraki grafiğe geçer.

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

## **Bir Çalışma Kitabından Grafik Verisini Okuma ve Yazma**

Aspose.Slides for PHP via Java, [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sunar; bu yöntemlerle grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okuyup yazabilirsiniz. **Not**: Grafik verisinin aynı şekilde düzenlenmiş ya da kaynakla benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaydının ilk şekli olarak bir grafiği olan bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Gömülü çalışma kitabını değiştirilmiş bir sürümle değiştirirken, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu tutarsızlık, [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) yönteminin indeks dışı hatasıyla sonuçlanabilir. Güncellenen çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydın ilk şekli olarak bir grafiği kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

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

Koleksiyonların temizlenmesi, çalışma kitabı yeniden yazılmadan önce eski veri referanslarını kaldırır. Güncellenen çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Ayarlama**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) yöntemi, bir grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol eder. Örneğin bir rapor, dönüşüm oranını yüzde dört ondalık basamakla ve bir katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutarak hesaplamalarda ve grafik çizmelerinde kullanılabilir kalmasını sağlayın.

Bir sayı biçimi yalnızca görüntüyü değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde `0.00000` biçimi `0.1234567` sayısını `0.12346` olarak gösterir ancak saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) üzerinden erişir. Çalışma sayfası 0’da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca kaynak biçimlere bağlı değer etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, doğrudan eksenlere veya veri etiketlerine uygulanan biçimlerden ayrı tutulur. Bu örnekte her etiket, [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) `true` olduğu için kaynak hücre değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` olduğu için kaynak sayı biçimini izler. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak gösterilir. Dikey eksen, kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) `0.00` ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` ile ayarlamıştır.

Bir veri etiketini bağımsız biçimlendirmek için kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini etkilemez. Örneğin bağımsız `0.00` biçimi ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirmesi için [Grafik Veri Etiketleri](/slides/tr/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) sayfasına bakın.

Aşağıdaki görsel, sunumu kaydedip yeniden açtıktan sonra render edilmiştir:

![Kaynak‑bağlantılı etiketlerde 12.5000% ve 0.12346 gösteren ve bağımsız biçimlendirilmiş sayısal eksene sahip sütun grafik.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan veriye sahip bir balon grafik ekler. İlk serinin ilk üç etiketi için çalışma sayfası 0’da A10:A12 aralığını kullanır, hücrelerden etiket alımını etkinleştirir ve güncellenen sunumu kaydeder.

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek bir pasta grafik oluşturur, varsayılan veriyi ekler ve her çalışma sayfasının adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirtme**

Seri nokta değerleri doğrudan sayısal sabitler olarak da saklanabilir. Tüm örnek için [Seri Değerlerini Sayısal Sabitlerle Ayarlama](/slides/tr/php-java/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin kaynak türü, grafiğin iç ya da dış çalışma kitabı yapılandırmasından ayrı bir kavramdır; sayısal sabitlerin kullanılması, gömülü çalışma kitabını otomatik olarak kaldırmaz.

Bu örnek, varsayılan veriye sahip bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir string sabiti, ikinci ad ise çalışma sayfası 0’da C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) enum’u her ad için kaynağı seçer. Örnek, güncellenen seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri tespit etmek ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) enum’unu kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı içeren her grafik için bir tanı mesajı yazdırır.

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

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Bir Dış Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metodlarını kullanarak gömülü grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu dış çalışma kitabına bağlayabilirsiniz.

Bu örnek bir pasta grafik oluşturur, çalışma kitabını dışa aktarır. Dosya yazma işlemini tamamladıktan sonra dış çalışma kitabını grafik veri kaynağı olarak atar ve bağlı sunumu kaydeder.

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

### **Bir Dış Çalışma Kitabı Atama**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) metodunu kullanarak bir grafiğe dış çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda dış çalışma kitabının yolunu (dosya taşındıysa) güncellemek için de kullanılabilir.

Uzaktaki konumlardaki veya kaynaklardaki çalışma kitaplarını doğrudan düzenleyemesiniz de, bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Göreli bir yol sağlanırsa otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir dış çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafiği içeren sunumu kaydeder.

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

* `updateChartData` **false** olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; böylece çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bağlanmış dış çalışma kitabı olan bir sunumun ilk slaydındaki ilk şekli inceler. Eğer şekil bir dış çalışma kitabına bağlı bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) değerini konsola yazdırır ve ardından sunumun bir kopyasını kaydeder.

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

Dış çalışma kitaplarındaki veriyi, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış çalışma kitabı yüklenemiyorsa bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır ve erişilebilir bir dış çalışma kitabına bağlanmıştır. İlk serinin ilk veri noktasının hücre‑güdümlü değerini **100** olarak ayarlar ve güncellenen sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanmış dış XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak için bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabı Kurtarma**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) **true** olarak ayarlayın; ardından sunumu açın.

Aşağıdaki PHP örneği, ilk slaydının ilk şekli olarak bir grafik ve mevcut olmayan bir dış çalışma kitabına referans veren bir senaryoda çalışma kitabı verisini kurtarır. Kurtarılan verilere [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) ve [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) üzerinden erişir:

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

Eğer dış çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekten grafik verisinin kullanılmasının kabul edilebilir bir geri dönüş yolu olduğu durumlarda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabına yapılan son değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış veya gömülü bir çalışma kitabına bağlandığını nasıl öğrenebilirim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ve [dış çalışma kitabı yolu](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabıysa tam yolu okuyarak dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Sunum mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides’tan doğrudan uzak çalışma kitaplarını düzenlemek desteklenmez — yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre‑güdümlü grafik verisini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinali değişmemeli ise çalışma kitabının bir kopyasını kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak veya [Aspose.Cells](https://reference.aspose.com/cells/java/) gibi bir araçla şifresiz bir kopya hazırlamaktır.

**Birden çok grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan bir güncelleme her grafiğin bir sonraki veri yüklemesinde yansıtılır.