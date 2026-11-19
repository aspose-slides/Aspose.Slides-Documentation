---
title: PHP kullanarak Sunumlarda 3B Grafikleri Özelleştirme
linktitle: 3B Grafik
type: docs
url: /tr/php-java/3d-chart/
keywords:
- 3B grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında 3B grafikler oluşturun. PHP örnekleriyle döndürmeyi, yükseklik oranlarını, grafik derinliğini ve seriler arasındaki boşluğu ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, 3B bir grafiğin görünümünü [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) yöntemiyle özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşluğu nasıl ayarlayacağınızı ve ardından sunumu PPTX formatında nasıl kaydedeceğinizi gösterir.

## **3B Bir Grafiğin Döndürülmesi ve Derinliğinin Ayarlanması**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturur ve [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) yöntemini kullanarak ilk slaytına yığılmış bir 3B sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seri ile değiştirir. Çalışma sayfası dizini `0`, grafiğin ilk veri çalışma sayfasını; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) ve [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) yöntemleri, grafiğin döndürülmesini sırasıyla 40 ve 270 derece olarak ayarlar. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) derinliğini genişliğinin %150'si olarak ayarlar, [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) ise perspektif yerine dik açı eksenlerini etkinleştirir. Oluşan sunum, bu 3B görünüm ayarlarıyla doldurulmuş grafiği içerir.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **3B Bir Grafiğin Yükseklik Oranlarını Ayarlama**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) yöntemini kullanarak bir 3B grafiğin yüksekliğini genişliğinin yüzdesi olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3B sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veriyle bir [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunum kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri boşluğu ve biçimlendirme üç dosyada da aynıdır; yalnızca yükseklik yüzdesi değişir.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı yükseklik ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha küçük bir yüzde daha düz bir sahne üretirken, daha büyük bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne oluşturur. PowerPoint, sahneyle uyum sağlamak için eksen işaretçi aralıklarını ve etiket yerleşimini de ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![3B sütun grafiği, yüksekliği genişliğinin %50'si olarak ayarlandı](height_percent_50.png) | ![3B sütun grafiği, yüksekliği genişliğinin %100'si olarak ayarlandı](height_percent_100.png) | ![3B sütun grafiği, yüksekliği genişliğinin %200'si olarak ayarlandı](height_percent_200.png) |

| Yöntem | Etki |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3B sahnenin yüksekliği, genişliğinin yüzdesi olarak. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Slayttaki grafik nesnesinin yüksekliği, punto cinsinden. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3B sahnenin derinliği, genişliğinin yüzdesi olarak. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Seriler arasındaki derinlik eksenindeki boşluk, işaretleyici genişliğinin yüzdesi olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantları dahil olmak üzere 3B sütun ve çubuk grafiklerini ve ayrıca 3B çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma, doğrulanmış `Column3D` türünü kullanır. Ayar, 2B `ClusteredColumn` grafiği veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/php-java/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) yöntemini kullanarak bir 3B grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi, işaretleyici genişliğinin yüzdesi olarak kontrol edebilirsiniz. **0 ile 500** arasında değerler kullanın, dahil: `0` boşluğu kaldırır, daha büyük değerler ise boşluğu artırır. Sabit bir grafik derinliğiyle, boşluğu artırmak işaretleyicileri derinlik ekseninde daha ince yapar.

Grupla, [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) aracılığıyla erişin. Ayar, bu gruptaki tüm serilere uygulanır, yalnızca erişilen seriye değil. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) derinlik boşluğunu döndürür ve üst grup ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantları dahil 3B sütun ve çubuk grafiklerini ve ayrıca 3B çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik, kümelenmiş veya yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukların net karşılaştırması için [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfından `ChartType::Column3D` kullanın.

| Yöntem | Etki |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Seriler arasındaki derinlik eksenindeki boşluk, işaretleyici genişliğinin yüzdesi olarak. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Yan yana çubuk veya sütun kümeleri arasındaki boşluk, çubuk ya da sütun genişliğinin yüzdesi olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Grafik genişliğinin yüzdesi olarak genel derinlik. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunum kaydeder; yalnızca boşluk derinliği değişir.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı boşluk derinliği ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: %0 | Boşluk derinliği: %500 |
| --- | --- |
| ![Derinlik ekseninde seriler arasında boşluk olmayan 3B sütun grafiği](gap_depth_0.png) | ![Derinlik ekseninde seriler arasında %500 boşluk olan 3B sütun grafiği](gap_depth_500.png) |

## **3B Seri Türünü ve Çubuk Şeklini Değiştirme**

Kümelenmiş silindir grafikde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) ve [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) tarafından döndürülen tam sayı değerlerini yazdırır. Tablo, karşılık gelen sabit adlarını verir.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| İlk seride değişiklik | Seri türü | Çubuk şekli |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| Seri türünü `ClusteredCone` olarak ayarla | `ClusteredCone` | `Cone` |
| Çubuk şeklini `Box` olarak ayarla | `ClusteredColumn3D` | `Box` |

`Box` şekline ayarlamak aynı zamanda seri türünü `ClusteredColumn3D` olarak değiştirir. Kodunuz seri türüne göre dallanıyorsa, şekli değiştirdikten sonra [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) çağırın. Atamadan önce önbelleğe alınmış bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk seriyi soldan sağa doğru silindir, koni ve dikdörtgen sütunlar şeklinde gösteriyor](series-shapes.png)

## **SSS**

**Aspose.Slides'te hangi grafik türleri 3B modunu destekler?**

Aspose.Slides, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3B varyantlarını ve ilgili 3B türleri destekler. Tam ve güncel bir liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3B grafik raster görüntüsü alabilir miyim?**

Evet. Bir grafiği [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) yöntemiyle bir görüntüye dışa aktarabilir veya tüm slaytı [tüm slaytı dönüştür](/slides/tr/php-java/convert-powerpoint-to-png/) ile PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, raster önizleme gerektiğinde veya grafiği PowerPoint gerektirmeden belgeler, kontrol panelleri veya web sayfalarına yerleştirmek istediğinizde yararlıdır.

**Büyük 3B grafiklerin oluşturulması ve render edilmesi ne kadar performanslı?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3B efektleri minimumda tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef ekran veya baskı ihtiyacına uygun bir çözünürlük ve boyutta çıktı üreterek render edin.