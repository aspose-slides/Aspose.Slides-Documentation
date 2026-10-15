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
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek üzere Java aracılığıyla PHP için Aspose.Slides kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve tik işareti aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksende Maksimum Değerleri Almak**

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafik ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) metodunu çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) metodlarını okuyun, tik aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) metodlarını kullanın. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) tarih eksenleri için geçerli zaman birimi ölçeklerini sağlar. Örnek, bu değerleri yerel değişkenlerde saklar ve grafik kaydeder.

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

[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) metodunu kullanarak grafik verilerinde seriler ve kategorilerin rollerini değiştirin. Önceki her kategori bir seri, önceki her seri bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` adresine (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metodunu kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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
## **Bir Eksenin Çizim Sırasını Tersine Çevir**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) metodunu kullanarak bir kategori veya değer ekseninin çizim yönünü tersine çevirin. Örneğin, bir yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırada, üstten alta: Planlama, Geliştirme, Test olarak gösterebilir. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma sayfası verilerini sıralamaz ya da yeniden düzenlemez. Buna karşılık, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) seriler ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seriden oluşan bir yatay çubuk grafik oluşturur. Normal sıra, ters kategoriler ve ters değerler olmak üzere üç slayt içeren bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

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
Bir ekseni tersine çevirmek, dikey ekseni çizimin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metoduyla yapılandırılan eksenin diğer ekseni nerede kesişeceği kontrol edilir. 2. slaytta, ters kategori ekseninde `CrossesType::Maximum` ile çağrıldığında yatay değer ekseni altta kalır. Belirli bir kesişme noktası için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) kullanın. Yön değiştirirken, özellikle grafiğin zaten özel bir kesişme noktasına sahip olması durumunda, kesişme ayarlarını kontrol edin. Normal çizim yönünü geri getirmek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişme ayarları ayrı tutulur.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer eksen sırası ile yatay çubuk grafik](axis-order-normal.png) | ![Kategoriler üstten alta gösterilen yatay çubuk grafik](axis-order-categories-reversed.png) | ![Ters değer ekseni ve sağda sıfır ile yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten aşağı doğru. Değerler ve çalışma sayfası satır sırası değişmemiştir. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Eksen'i Devre Dışı Bırak**

Dikey eksende `false` ile [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu çağırarak onu gizleyin. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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
## **Çizgi Grafiklerde Yatay Eksen'i Devre Dışı Bırak**

Yatay eksende `false` ile [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu çağırarak gizleyin. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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
## **Bir Kategori Ekseni Değiştir**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu kullanarak tarih ya da metin kategori ekseni seçebilirsiniz. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücrelerinin sayısal Excel tarih değerleri içerdiği `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType::Months` ile çağırmak, ana tik işaretlerini bir aylık aralıklara yerleştirir.

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
## **Kategori Ekseni Etiket Aralıklarını Kontrol Et**

Bir grafikte çok sayıda kategori olduğunda, kategori ya da veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` ile çağırın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metoduna aktarın. Normal sıradaki metin kategorileri için sayım ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; mutlaka tüm etiketleri göstermez.

Tik işaretlerinin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` ile çağırın ve aralığı ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) metodunu kullanın. Örneğin, `1` her kategori aralığında bir tik işareti bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) metodunu kullanın. Otomatik-aralık ayarını `true` yaparak tekrar çağırmak, grafiğin aralığı yeniden seçmesini sağlar.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tik işaretleri ile manuel etiket aralığı ve geri yüklenen otomatik aralık. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluktaki farkı kolayca görmenizi sağlar.

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

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir tik işareti tut.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Otomatik aralık (slayt 1):** Bu renderda, her ikinci kategori etiketi görüntülenir ve iki satıra döner. Otomatik sonuç grafik boyutu, yazı tipleri ve renderleyiciye bağlı olarak değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, tik işaretleri ise her kategori aralığında kalır. Etiketsiz olanlar da dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünümü geri yükler.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seç**

Bu kategori-sayısı aralığını metin kategori ekseni için kullanın; örneğin sütun, çizgi, alan veya çubuk grafiğin kategori ekseni. Bir sütun grafiğinde yatay eksen olur. Yatay çubuk grafiğinde kategori ekseni dikey olduğundan bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülen eksene uygulayın. Tik işareti aralığı, bir seriye sahip grafiklerde seriler eksenine de uygulanır.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) bir değer farkını belirtir: örneğin, `10` ana birim, eksen sıfırdan başladığında 0, 10, 20 vb. tick işaretleri oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verisini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak depolanır; bu tarihler 30 Aralık 1899'dan itibaren geçen gün sayısı olarak hesaplanır. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType::Date` ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` ile çağırın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl gösterimi için `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metoduna geçirin.

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
## **Grafik Ekseni Başlığı için Döndürme Açısı Ayarla**

Dikey eksende `true` ile [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metodunu çağırın, başlık metni sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metodunu kullanın. Açı derece cinsindedir; bu örnek, değer ekseni başlığı 90 derece döndürülmüş bir sütun grafik kaydeder.

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
## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarla**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) metodunu kullanarak değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori tik işaretlerinde mi kesişeceğini kontrol edin. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğin yatay kategori ekseninde bunu `true` olarak ayarlar ve sonucu kaydeder.

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

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) metodunu kullanarak değer eksenindeki etiketleri temel veriyi değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60.000.000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dikey eksenine milyon birimini uygular.

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
## **Logaritmik Değer Ekseni Yapılandır**

Pozitif değerler birkaç mertebe büyüklük farkı gösterdiğinde logaritmik değer ekseni faydalıdır. Örneğin, bir hizmet beş dönem boyunca 10, 100, 1.000, 10.000 ve 100.000 istek alabilir. Doğrusal ölçekle küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, göreceli büyümeyi karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları, eşit farkları değil gösterir.

Değer ekseninde `true` ile [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) metodunu çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) metodunu kullanın. Bu, mevcut değerlerin gösterim şeklini değiştirir; veriyi değiştirmez veya logaritmik bir eğilim çizgisi eklemez. Eğilim çizgisi, verideki uyarlanmış ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi veya sütun grafiğinde değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülür. Yatay çubuk grafiğinde ise [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) döndürür. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay ekseni, Y değerleri için dikey ekseni veya her ikisini seçin. Bir kategori eksenine logaritmik ölçeklendirme uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerde `2` ile `1000` arasında (dahil) bir taban kullanın; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanı ile ardışık katlar 10, 100, 1.000 ve 10.000 eşit aralıklıdır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısı ile bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban-10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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
**Doğrusal ölçek (slayt 1):** Eşit düşey mesafeler istek sayısındaki eşit farkları gösterir. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit düşey mesafeler eşit oranları gösterir. Her dönem, bir önceki dönemin on katı istek alır, bu yüzden noktalar taban-10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı taban-10 logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun ya da ayrı olarak gösterin. Analiz için bu değerleri dışlamak uygun ise, eksikliği açıklayın. Verileri gizlice küçük pozitif sayılarla değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**
**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metodunu kullanın; bu ayarlar eksen kesişimini uygun bir temel çizgiye taşımayı sağlar.

**Tik etiketlerini eksene göre nasıl konumlandırabilirim?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) kullanarak `Low`, `High`, `NextTo` veya `None` değerleriyle çağırın. Tik işaretlerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) veya [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı ayrı çalışır.