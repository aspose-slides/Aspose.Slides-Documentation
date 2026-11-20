---
title: PHP Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/php-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Java üzerinden PHP için Aspose.Slides kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve tick‑mark aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce, grafik düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) metodunu çağırın.

Eksen limitleri için [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) metodlarını, tick aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) metodlarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eksenler Arasındaki Verileri Değiştir**

[swapRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) metodunu kullanarak grafik verilerinde seri ve kategori rollerini değiştirin. Önceki her kategori bir seri, önceki her seri ise bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değişmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metodunu kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Eksenin Çizim Sırasını Tersine Çevirmek**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) metodunu kullanarak bir kategori ya da değer ekseninin çizim sırasını tersine çevirin. Örneğin, yatay çubuk grafik proje aşamalarını aynı sırada (Planlama, Geliştirme, Test) üstten alta gösterebilir. Eksenin tersine çevrilmesi çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) serilerin ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Üç slayt kaydeder: normal sıra, tersine çevrilmiş kategoriler ve tersine çevrilmiş değerler. Her kopya aynı veri kümesini kullanır ve her birinde yalnız bir eksen tersine çevrilir.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Slayt 2: ilk kategoriyi üstte göster.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Yatay değer eksenini altta tut.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Slayt 3: yalnızca yatay sayısal ölçeği tersine çevir.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tersine çevrilen bir eksen, dik ekseni grafiğin karşı tarafına da taşıyabilir. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) eksenin diğer ekseni nerede kesişeceğini kontrol eder. 2. slaytta, tersine çevrilmiş kategori ekseninde `CrossesType::Maximum` kullanmak, yatay değer ekseninin altta kalmasını sağlar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Yön değiştirirken, özellikle grafik zaten özel bir kesişim noktasına sahipse, kesişim ayarlarını kontrol edin. Normal çizim yönünü geri getirmek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişim ayarları ayrı tutulur.

| Normal sıralama (slayt 1) | Tersine çevrilmiş kategoriler (slayt 2) | Tersine çevrilmiş değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafiği](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafiği](axis-order-categories-reversed.png) | ![Değer ekseni tersine çevrilmiş ve sıfır sağda olan yatay çubuk grafiği](axis-order-values-reversed.png) |
| Kategoriler altdan üste doğru gider; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru gider. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırak**

Dikey ekseni gizlemek için eksene `false` ile [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu uygulayın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dik ekseni gizli olarak kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırak**

Yatay ekseni gizlemek için eksene `false` ile [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu uygulayın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Grafik Izgara Çizgilerini Göster veya Gizle**

Bir eksenin hangi ızgara çizgilerini gösterdiğini öğrenmek için [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) ve [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) metodlarını çağırın. Küçük ızgara çizgilerini göstermek için [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) metodunu kullanın ve çizgi doldurmasını katı, görünür bir renge ayarlayın. Gizlemek için doldurmayı [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) olarak ayarlayın. Büyük ızgara çizgileri için aynı şekilde [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) metodunu kullanın. Doldurma değişikliği eksen görünürlüğünü ve tick işaretlerini korur.

Bu kümelenmiş sütun grafiğinin dik ekseni başlangıçta yalnız büyük ızgara çizgilerini gösterir. Örnek, küçük ızgara çizgilerini koyu turuncu renkte gösterir, ardından tekrar gizleyerek sunumu kaydeder. Her adımda ızgara çizgisi görünürlüğünü yazdırır.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Küçük ızgara çizgileri etkin | Küçük ızgara çizgileri gizli |
| --- | --- |
| ![Dikey eksende büyük ızgara çizgileri arasında turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Sadece büyük ızgara çizgileri görünür aynı sütun grafiği](minor-gridlines-hidden.png) |

## **Bir Kategori Eksenini Değiştir**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu kullanarak tarih ya da metin kategori ekseni seçin. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; grafiğin ilk şekli ilk slaytta ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni haline getirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType::Months` olarak ayarlamak, ana tick işaretlerini bir‑ay aralıklarla yerleştirir.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Veriden Kategori Eksen Türünü Belirle**

Kategorileri doldurduktan sonra [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) metodunu çağırın, ardından seçimi incelemek için [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) metodunu okuyun. Bu, aynı grafiğin ya metin etiketleri ya da sayısal tarih değerleri alması durumunda kullanışlıdır. Metod çağrıldığı anda türü belirler; daha sonraki veri değişikliklerini yeniden değerlendiren kalıcı bir mod etkinleştirmez. Kategorileri değiştirdikten sonra tekrar çağırın.

Aşağıdaki örnek, metin kategorileri içeren bir grafik oluşturur ve seçilen tür `CategoryAxisType::Text` olduğunda `true` yazdırır. Ardından kategori hücre değerlerini tarihlere değiştirir ve metod tekrar çağrıldığında seçilen tür `CategoryAxisType::Date` olduğunda `true` yazdırır. Tarihler, 30 Aralık 1899’dan beri geçen gün sayısı olarak saklanan sayısal OLE Automation değerleridir; tarih dizgeleri değildir. [setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) bu değerlerin nasıl görüntüleneceğini kontrol eder; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/php-java/chart-workbook/) sayfasına bakın.

Sayısal tarih ya da metin kategori olması bilindiğinde otomatik belirlemeyi kullanın. Normal sayısal etiketler, karışık kategoriler veya boş veri için, amaçlanan anlama uygun olarak açıkça [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu çağırın. Yalnız sayısal değerler, kategorilerin tarih olduğu sonucunu ortaya koymaz.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategori Eksen Etiket Aralıklarını Kontrol Et**

Bir grafiğin çok sayıda kategorisi olduğunda, kategori veya veri kaybı olmadan görünür eksen etiketlerinin sayısını azaltın. Önce [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` olarak ayarlayın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metoduna aktarın. Normal sıradaki metin kategorileri için sayılamaya ilk kategoriden başlanır:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir; gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi göstermeyebilir.

Tick işaretleri ayrı olarak kontrol edilir. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` olarak ayarlayın ve aralıklarını belirlemek için [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) metodunu kullanın. Örneğin, `1` değeri her kategori aralığında bir tick işareti bırakırken, etiketler yalnız her üçüncü kategoriye gösterilir. Görünür bir stil seçmek için [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) metodunu kullanın. Otomatik‑aralık ayarını tekrar `true` olarak çağırmak, grafiğin aralığı yeniden otomatik olarak seçmesini sağlar.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tick işaretleriyle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmeyi sağlar.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir tick işareti tut.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slayt 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Otomatik aralık (slayt 1):** Bu renderda her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç, grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, ancak tick işaretleri her kategori aralığında kalır. Etiketsiz kalan tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıda gösterilen otomatik görünüme geri döner.

![Üçlü manuel kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seç**

Metin kategori ekseni kullanılan bir grafik (örneğin sütun, çizgi, alan veya çubuk grafik) için bu kategori‑sayısı aralığını uygulayın. Sütun grafiğinde yatay eksen, yatay çubuk grafiğinde ise kategori ekseni dik eksen olduğundan, bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülen eksene uygulayın. Tick‑mark aralığı, bir seri eksenine sahip grafiklerde de geçerlidir.

Kategori etiketi aralığını değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) metoduyla değer farkı belirlenir: örneğin `10` bir birim, eksen sıfırdan başlayıp 0, 10, 20 … şeklinde tick işareti oluşturur. `3` bir kategori etiketi aralığı ise kategori konumlarını sayar; veri değerlerinden bağımsızdır. Dağılım ve balon grafikleri, metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Değiştir bir Kategori Eksenini](#de%C4%9Fi%C5%9Ftir-bir-kategori-eksenini) bölümünde açıklandığı gibi zaman‑bazlı birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değere değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu tarihler 30 Aralık 1899’dan beri geçen gün sayısı olarak hesaplanır. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType::Date` ile kullanın, ardından [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` olarak ayarlayın ve `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metoduna aktarın; böylece kategori etiketleri hücre biçiminden bağımsız olarak dört haneli yıl gösterir.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Grafik Eksen Başlığı için Döndürme Açısı Ayarla**

Dikey eksende başlığı etkinleştirmek için [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metodunu `true` ile çağırın, başlık metnini sağlayın ve [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metoduyla başlığı döndürün. Açı derece cinsinden ölçülür; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarla**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) metodunu kullanarak değer ekseninin kategori eksenini kategori aralıkları arasında mı yoksa kategori tick işaretlerinde mi kesiştireceğini kontrol edin. Bu ayar yalnız kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Grafik Değer Ekseninde Görüntüleme Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) metodunu kullanarak değer eksenindeki etiketleri veriyi değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dik eksenine milyon görüntüleme birimini uygular.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Logaritmik Değer Eksenini Yapılandır**

Pozitif değerlerin birden çok mertebe arasına yayılması durumunda logaritmik değer ekseni kullanışlıdır. Örneğin bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 isteği alabilir. Doğrusal ölçekle, daha küçük değerler sıfıra yakın bir bölgede sıkışır. Logaritmik ölçek, büyüme oranlarını karşılaştırmayı kolaylaştırır: eşit uzaklıklar eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) metodunu `true` ile çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) metodunu kullanın. Bu, mevcut değerlerin görüntülenme şeklini değiştirir; veriyi ya da bir logaritmik eğri çizgisi eklemez. Eğri çizgi, verideki bir ilişkili modeli temsil eden ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi ya da sütun grafiğinde, değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) ile döndürülür. Yatay çubuk grafiğinde, değer ekseni [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) ile döndürülür. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay, Y değerleri için dik eksen ya da ikisini birden seçin. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`’dur. PPTX grafiklerde, `2`‑`1000` aralığında (dahil) bir taban kullanılabilir; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanında, 10, 100, 1 000, 10 000 gibi ardışık güçler eşit aralıkta yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafik oluşturur, ardından bu slaytı klonlayıp ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // İlk slaytı lineer tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler, istek sayısındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, daha küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler, eşit oranları temsil eder. Her dönem bir önceki dönemin on katı isteği alır; bu nedenle noktalar taban‑10 skalada düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ orijinal istek sayılarını gösterir.

![Taban‑10 logaritmik değer ekseninde aynı beş istek sayısını gösteren PowerPoint grafiği](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnız kesinlikle pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır ya da negatif değerler anlamlıysa, doğrusal ölçeği tutun veya bu değerleri ayrı olarak gösterin. Bu değerleri analiz için dışlamak uygun ise, eksikliği açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum ya da maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kırılma değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza imkan verir.

**Tick etiketlerini eksene göre nasıl konumlandırabilirim?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) ile birlikte kullanın: `Low`, `High`, `NextTo` veya `None`. Tick işaretlerini kontrol etmek için ayrı olarak [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) ya da [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) metodlarını kullanın; bunlar etiket konumlandırmadan bağımsızdır.