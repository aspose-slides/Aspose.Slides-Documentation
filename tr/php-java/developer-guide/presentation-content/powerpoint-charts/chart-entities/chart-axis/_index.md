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
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Java aracılığıyla PHP için Aspose.Slides kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for PHP via Java kullanarak grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretleme aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafiğin düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) metodunu çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) metodlarını, işaretleme aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) metodlarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) zaman birimi ölçeklerini sağlar; bunlar tarih eksenleriyle ilgilidir. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

Grafik verilerinde seri ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) metodunu kullanın. Her eski kategori bir seri, her eski seri ise bir kategori haline gelir. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` adresine, başlık satırı ve kategori sütunu da dahil olmak üzere bağlamak için [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) metodunu kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırak**

Dikey eksende gizlemek için `false` değerini kullanarak [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve dikey ekseni gizli olarak kaydeder.

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

Yatay eksende gizlemek için `false` değerini kullanarak [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Kategori Ekseni Değiştir**

Bir tarih veya metin kategori ekseni seçmek için [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücreleri sayısal Excel tarih değerleri içeren `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType::Months` ile çağırmak, büyük işaretçileri bir‑aylık aralıklarla yerleştirir.

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

## **Kategori Eksen Etiketi Aralıklarını Kontrol Et**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` ile çağırın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) metoduna iletin. Normal sıradaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi zorunlu olarak göstermez.

İşaretleme çizgileri ayrı kontrolere sahiptir. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` ile çağırın ve aralığını ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) metodunu kullanın. Örneğin, `1` her kategori aralığında bir işaretleme bırakırken, etiketler sadece her üçüncü kategoride görülür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) metodunu kullanarak sonucu görebilirsiniz. Otomatik‑aralık ayarlayıcısını `true` ile tekrar çağırmak, grafiğin tekrar o aralığı seçmesini sağlar.

İzleyen bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretleme çizgileriyle manuel etiket aralığı ve geri yüklenmiş otomatik aralık. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluk farkını kolayca görmenizi sağlar.

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

    // Slide 2: her üçüncü etiketi göster, ancak her kategori için bir işaretleme tut.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slide 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Otomatik aralık (slayt 1):** Bu görüntüde, her ikinci kategori etiketi gösterilir ve iki satıra kayar. Otomatik sonuç, grafik boyutu, fontlar ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket bir satırda gösterilir, işaretleme çizgeleri ise her kategori aralığında kalır. Etiketsiz olanlar da dahil olmak üzere tüm 24 sütun aynı değerlerle görünür kalır. Slayt 3, yukarıda gösterilen otomatik görünümü geri getirir.

![Manuel kategori etiketi üç aralıkla tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seç**

Bu kategori‑sayısı aralığını, bir sütun, çizgi, alan veya çubuk grafiğin kategori ekseni gibi bir metin kategori ekseni için kullanın. Bir sütun grafiğinde, bu yatay eksen olur. Yatay çubuk grafiğinde kategori ekseni dikeydir, bu yüzden bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) metodunun döndürdüğü eksene uygulayın. İşaretleme aralığı, bir seri eksenine sahip grafiklerde de geçerlidir.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) bir değer farkını belirtir: örneğin, `10` bir birim, eksen sıfırdan başlıyorsa 0, 10, 20 vb. gibi işaretler oluşturur. `3` bir kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikleri, metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Kategori Eksenini Değiştir](#change-a-category-axis) bölümünde açıklandığı gibi zaman temelli büyük birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (`0` indeks) OLE Automation seri numaraları olarak depolanır; bu tarihler 30 Aralık 1899’dan itibaren geçen gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType::Date` ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` ile çağırın ve kategori etiketlerinin hücre biçimlendirmesinden bağımsız olarak dört basamaklı yıl göstermesi için `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) metoduna iletin.

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

## **Grafik Eksen Başlığı İçin Döndürme Açısı Ayarla**

Dikey eksende başlığı etkinleştirmek için `true` ile [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) metodunu çağırın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metodunu kullanın. Açı derece cinsindendir; bu örnek, değer‑ekseni başlığı 90 derece döndürülmüş bir sütun grafiği kaydeder.

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

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) metodunu, değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretlemelerinde mi kesişeceğini kontrol etmek için kullanın. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` olarak ayarlar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntü Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) metodunu, altta yatan verileri değiştirmeden değer eksenindeki etiketleri ölçeklendirmek için kullanın. [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60.000.000 değeri 60 olarak gösterilir. Örnek, bir sütun grafiği oluşturur ve dikey eksenine milyon görüntü birimini uygular.

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

Pozitif değerler birkaç büyüklük mertebesi kapsadığında logaritmik değer ekseni faydalıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1.000, 10.000 ve 100.000 istek alabilir. Doğrusal ölçekte, daha küçük değerler sıfıra yakın bir yerde sıkışık görünür. Logaritmik ölçek, büyüme oranlarını karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde logaritmik özelliği etkinleştirmek için [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) metodunu `true` ile çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) metodunu kullanın. Bu, mevcut değerlerin gösterilme şeklini değiştirir; verileri değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki uyarlanmış ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi veya sütun grafiği için değer ekseni, [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülür. Yatay çubuk grafiği için ise [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) döndürür. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay eksen, Y değerleri için dikey eksen veya ikisi de kullanılabilir. Kategori eksenine logaritmik ölçekleme uygulamayın.

Varsayılan logaritmik taban `10`dur. PPTX grafiklerinde, `2` ile `1000` arasında (her ikisi dahil) bir taban kullanın; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` verildiğinde, 10, 100, 1.000 ve 10.000 gibi ardışık kuvvetler eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısı ile bir çizgi grafiği oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerlerin ayırt edilmesini zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki döneme göre on kat daha fazla istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı taban‑10 logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnızca sıfırdan büyük değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun veya bunları ayrı olarak gösterin. Analiz için bu değerleri dışlamak uygun ise, nedeni açıklayın. Bunları küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için elle ayarlanmış herhangi bir minimum veya maksimum da pozitif olmalıdır.

## **FAQ**

**Bir eksenin diğerini kestiği değeri (eksen kesişimi) nasıl ayarlarım?**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirlemek için [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**İşaretleme etiketlerini eksene göre nasıl konumlandırabilirim?**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) ile `Low`, `High`, `NextTo` veya `None` değerleriyle çağırın. İşaretleme çizgilerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) veya [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı olarak işlem görür.