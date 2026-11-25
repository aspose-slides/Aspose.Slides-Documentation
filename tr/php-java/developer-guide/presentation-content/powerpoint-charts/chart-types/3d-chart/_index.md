---
title: PHP Kullanarak Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/php-java/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP via Java için Aspose.Slides ile PowerPoint sunumlarında 3D grafikler oluşturun. Döndürme, yükseklik oranları, grafik derinliği ve seriler arasındaki boşlukları PHP örnekleriyle ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, 3D bir grafiğin görünümünü [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) yöntemiyle özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşlukları nasıl ayarlayacağınızı ve ardından sunumu PPTX formatında kaydedeceğinizi gösterir.

## **3D Grafik Döndürme ve Derinliğini Ayarlama**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) oluşturur ve [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) kullanarak ilk slaytına yığılmış bir 3D sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriye değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) ve [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) yöntemleri, grafiğin dönüşünü sırasıyla 40 ve 270 derece olarak ayarlar. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) derinliğini genişliğinin %150'si olarak belirler, [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) ise perspektif yerine dik açı eksenlerini etkinleştirir. Oluşturulan sunum, bu 3D görünüm ayarlarıyla doldurulmuş grafiği içerir.

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

## **3D Grafik Yüzeyine Resim Doldurması Uygulama**

Bir 3D grafiğin [yan duvar](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [arka duvar](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) ve [zemin](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) yüzeylerini bağımsız olarak doldurabilirsiniz. Yüzeyin [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) özelliğini `Picture` olarak ayarlayın ve bir resim atayın. Hem [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) hem de yüzeyin [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) özelliğini `Stretch` olarak ayarlayarak resmi yüzey boyunca tek bir kopya sığdırın.

PHP betiğinin yanına [arrow.png](arrow.png) kaydedin. Örnek, grafiği döndürür ve dikey eksende maksimum değeri yükselterek zeminin sütunlar arasına görünmesini sağlar. Ardından slaytı iki kez kopyalar ve her slaytta oka farklı bir yüzeye uygular. Üç grafik de aynı veri, görüntü açısı ve arka planı korur.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint, üç slaytı aşağıdaki gibi gösterir.

| Yan duvar | Arka duvar | Zemin |
| --- | --- | --- |
| ![Yan duvarda grafiğe doğru ok](side-wall.png) | ![Arka duvarda sağa doğru ok](back-wall.png) | ![Sütunlar arasındaki zeminde sağa doğru ok](floor.png) |

## **3D Grafiğin Yükseklik Oranlarını Ayarlama**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) kullanarak bir 3D grafiğin yüksekliğini genişliğinin bir yüzdesi olarak ayarlayın. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3D sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veriyle bir [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunum kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, dönüş, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynıdır; yalnızca yükseklik yüzdesi değişir.

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

Aşağıdaki görüntüler, eşdeğer .NET örneğinde aynı yükseklik ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha düşük bir yüzde daha düz bir sahne oluştururken, daha yüksek bir yüzde aynı grafik nesnesi içinde daha dik bir sahne oluşturur. PowerPoint, sahneye uyacak şekilde eksen işaretçi aralıklarını ve etiket yerleşimini de ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![Genişliğinin %50'si olarak ayarlanmış 3D sütun grafiği](height_percent_50.png) | ![Genişliğinin %100'si olarak ayarlanmış 3D sütun grafiği](height_percent_100.png) | ![Genişliğinin %200'si olarak ayarlanmış 3D sütun grafiği](height_percent_200.png) |

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D sahnenin yüksekliği, genişliğinin bir yüzdesi olarak. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D sahnenin derinliği, genişliğinin bir yüzdesi olarak. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Derinlik eksenindeki seriler arasındaki boşluk, işaretçi genişliğinin bir yüzdesi olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma doğrulanmış `Column3D` tipini kullanır. Ayar, 2D `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/php-java/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) kullanarak bir 3D grafiğin derinlik eksenindeki veri serileri arasındaki mesafeyi işaretçi genişliğinin bir yüzdesi olarak kontrol edin. **0 ile 500** arasında (0 dahil) değerler kullanın: `0` boşluğu kaldırır, daha büyük değerler ise aralığı artırır. Sabit bir grafik derinliğiyle boşluğu artırmak, işaretçileri derinlik ekseninde daha ince yapar.

Gruba, [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) aracılığıyla erişin. Ayar, erişim için kullanılan seriye değil, o gruptaki tüm serilere uygulanır. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) derinlik boşluğunu döndürür ve ana grup ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlikte, küme halinde veya yığılmış olarak düzenlenip düzenlenmediğine bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfından `ChartType::Column3D` kullanın.

| Yöntem | Etkisi |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Derinlik eksenindeki seriler arasındaki boşluk, işaretçi genişliğinin bir yüzdesi olarak. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Bitişik çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin bir yüzdesi olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Grafik toplam derinliği, grafik genişliğinin bir yüzdesi olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Aynı veri, döndürme, boşluk genişliği ve grafik derinliğiyle iki sunum kaydeder; yalnızca boşluk derinliği değişir.

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

Aşağıdaki görüntüler, eşdeğer .NET örneğinde aynı boşluk derinliği ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseninde seriler arasında boşluk olmayan 3D sütun grafiği](gap_depth_0.png) | ![Derinlik ekseninde seriler arasında %500'lik boşluk olan 3D sütun grafiği](gap_depth_500.png) |

## **3D Serisi Tipini ve Çubuk Şeklini Değiştirme**

Küme silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) ve [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) tarafından döndürülen tam sayı değerlerini yazdırır. Tablo, karşılık gelen sabit adlarını verir.

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

| İlk seriye değişiklik | Seri tipi | Çubuk şekli |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| Seri tipini `ClusteredCone` olarak ayarla | `ClusteredCone` | `Cone` |
| Çubuk şekli `Box` olarak ayarla | `ClusteredColumn3D` | `Box` |

`Box` şekline ayarlamak, aynı zamanda seri tipini `ClusteredColumn3D` olarak değiştirir. Kodunuz seri tipine göre dallanıyorsa, şekli değiştirdikten sonra [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) çağırın. Atamadan önce önbelleğe alınmış bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk seriyi soldan sağa silindir, koni ve dikdörtgen sütunlar olarak gösterir](series-shapes.png)

## **SSS**

**Aspose.Slides'te hangi grafik tipleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D tiplerini destekler. Tam ve güncel bir liste için yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster (bitmap) görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ile bir görüntüye dışa aktarabilir veya tüm slaytı [tüm slaytı render et](/slides/tr/php-java/convert-powerpoint-to-png/) kullanarak PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, raster bir önizleme gerektiğinde veya grafiği belge, gösterge panosu veya web sayfasına PowerPoint gerektirmeden eklemek istediğinizde faydalıdır.

**Büyük 3D grafikler oluşturma ve render etme performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D etkilerini minimumda tutun, duvar ve çizim alanlarında ağır doku kullanımından kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef ekran ya da baskı ihtiyacına uygun (çözünürlük ve boyutlarda) bir çıktı üzerine render edin.