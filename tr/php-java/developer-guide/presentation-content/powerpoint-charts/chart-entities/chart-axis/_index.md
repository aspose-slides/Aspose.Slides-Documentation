---
title: Sunumlarda Grafik Eksenlerini PHP ile Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/php-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- ekseni manipüle et
- ekseni yönet
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
description: "Aspose.Slides for PHP via Java'ı kullanarak raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarını değiştirme, eksen görünürlüğü, kategori etiketi ve tik işareti aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma ve görüntü birimlerini kapsar.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Alın**

Bir [Sunum](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) çağırın.

Eksen sınırlamaları için [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) okurun, tik aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) zaman birimi ölçeklerini sağlar; bunlar tarih eksenleriyle ilgilidir. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştirin**

[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) kullanarak grafik verilerinde seriler ve kategorilerin rollerini değiştirin. Her eski kategori bir seri olur ve her eski seri bir kategori olur. Bu, verilerin nasıl gruplandığını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına bağlamak için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) kullanır, başlık satırı ve kategori sütununu da içerir, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırakın**

Dikey ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu `false` ile çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırakın**

Yatay ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu `false` ile çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Bir Kategori Ekseni Değiştirin**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) kullanarak tarih veya metin kategori ekseni seçin. Bu örnek `ExistingChart.pptx` dosyasını gerektirir, grafiği ilk slayttaki ilk şekil olarak ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType::Months` ile ayarlamak, ana tikleri bir aylık aralıklarla yerleştirir.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Edin**

Bir grafikte birçok kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` ile çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metoduna geçirin. Metin kategorileri normal sıralarında, sayma ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her zaman tüm etiketleri göstermez.

Tik işaretlerinin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` ile çağırın ve [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) ile aralığını ayarlayın. Örneğin, `1` her kategori aralığında bir tik işareti bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) kullanın. Otomatik‑aralık ayarını tekrar `true` yaparak grafiğin o aralığı yeniden seçmesine izin verin.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tik işaretleriyle manuel etiket aralığı ve otomatik aralığın geri getirilmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

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

**Otomatik aralık (slayt 1):** Bu gösterimde her ikinci kategori etiketi görüntülenir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, fontlar ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda görüntülenirken, tik işaretleri her kategori aralığında kalır. Etiketsiz olanlar dahil tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri yükler.

![Üçlü manuel kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seçin**

Bu kategori‑sayısı aralığını bir metin kategori ekseni için kullanın; örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni. Bir sütun grafiğinde bu yatay eksendir. Yatay çubuk grafiğinde kategori ekseni dikeydir; bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) ile dönen eksene uygulayın. Tik‑işareti aralığı ayrıca bir serinin eksenine de uygulanabilir.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Bir değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) bir değer farkını belirtir: örneğin `10` bir birim, eksen sıfırdan başladığında 0, 10, 20 vb. noktalar oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikleri metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Bir Kategori Ekseni Değiştirin](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑temelli ana birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri İçin Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri sayıları olarak saklanır; bu sayılar 30 Aralık 1899’dan beri geçen gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType::Date` ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` ile çağırın ve [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metoduna `yyyy` geçirin; böylece kategori etiketleri hücre biçiminden bağımsız olarak dört haneli yılları gösterir.

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

## **Bir Grafik Ekseni Başlığı İçin Döndürme Açısı Ayarlayın**

Dikey eksende başlığı göstermek için [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metodunu `true` ile çağırın, başlık metnini sağlayın ve [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) ile başlığı döndürün. Açı derecelerle ölçülür; bu örnek, değer‑ekseni başlığını 90 derece döndürülmüş bir sütun grafiği kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Ekseni Konumlandırın**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) kullanarak değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori tik işaretlerinde mi kesiştireceğini kontrol edin. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

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

## **Bir Grafik Değer Ekseninde Görüntü Birimini Ayarlayın**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) kullanarak bir değer eksenindeki etiketleri temel veriyi değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafiği oluşturur ve dikey eksenine milyon görüntü birimini uygular.

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

## **SSS**

**Bir eksenin diğerini kesiştiği değeri (ekseni kesişim) nasıl ayarlarım?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**Tik etiketlerini eksene göre nasıl konumlandırırım?**

[TikLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) kullanarak [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metodunu `Low`, `High`, `NextTo` veya `None` değerlerinden biriyle çağırın. Tik işaretlerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) veya [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) kullanın; bunlar etiket konumlandırmadan ayrı olarak çalışır.