---
title: PHP'de Sunum Şekillerini Özelleştir
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/php-java/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekil değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- kıvrımlı köşe
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kıvrımlı köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmeyi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenmiş geometrinin bir şekle uygulanmasını göstermek için [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca, özel ve bileşik şekiller oluşturmayı, köşeleri kıvrımlı olan şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin konturlarını geometri yollarına dönüştürmeyi gösterir.

## **Bir Şekli Düzenleme Noktalarıyla Değiştirme**

PowerPoint'te **Edit Points** özelliğini kullanarak bir kareyi değiştirebilirsiniz:

* Bir köşeyi içe ya da dışa taşıyın.
* Bir noktada eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Nokta düzenleme, bir şeklin dış hatlarını değiştirmenize veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanıza olanak tanır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan çapa noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Çapa noktaları ve kontrol kolları şeklinin biçimini belirler.
* Çapa noktaları köşe noktaları, düz noktalar veya pürüzsüz noktalar olarak bulunur:
  * Bir köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Bir pürüzsüz noktada, iki kontrol kolu hizalanmış ve çapa noktasına eşit uzaklıktadır.
  * Bir düz noktada, iki kontrol kolu hizalanmıştır ancak çapa noktasına farklı mesafelerde olabilir.
* Çapa noktalarını taşıyarak veya kollarını ayarlayarak şeklin dış hattı değişir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) elde etmek için [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ayarlamak üzere bu yöntemleri kullanabilirsiniz: tek yollu şekiller için [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ve birden çok yol içeren şekiller için [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) yöntemini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) geometrisinin yol verisini yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) nesnesini [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyabilir ve segmentleri bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, segmenti yolun segment dizisinde sıfır tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir bitiş noktası ile kübik Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Bir kontrol noktası ve bir bitiş noktası ile ikinci dereceden Bézier eğrisi ekleyin veya yerleştirin. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen boyut ve derece cinsinden açıyla eliptik bir yay ekleyin. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Bitiş noktasını başlangıç noktasına bağlayarak geçerli şekli kapatın. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Bir şeklin başlangıç noktasını ayarlayın. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır tabanlı bir dizindeki segmenti kaldırın. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Bir Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) kullanır ve düzenlenmiş yolu [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygular. Koordinatlar şekle göre lokalidir: her iki yeni nokta da merkezinde, soldan 100 puan ve üstten 50 puan uzaktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Şekilden Noktaları Kaldırma**

Bu örnek, bir kalp şeklinin dış hatlarını [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) ile sıfır tabanlı indeks 2'deki segmenti kaldırarak değiştirir. Değiştirilmiş yolu [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulamak şeklin konturunu günceller.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız inşa eder. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması uçları ve girintileri tanımlar; 72 derecelik adım beş ucu eşit aralıklarla dağıtır. Yol, [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) kullanılarak dikdörtgen bir şekle uygulanır; böylece mevcut dış hat yer değiştirir.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birini temsil eden iki kapalı [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) tanımlar. Her iki yolu da [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, ortasında bir boşluk bırakan tek bir bileşik şekil oluşturur.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Kıvrımlı Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) ile birleştirerek içe kıvrılan köşelere sahip bir şekil oluşturur. Her köşe boyutu, yayı puan cinsinden genişlik ve yükseklik olarak ayarlar ve -90 derecelik süpürme saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX formatında kaydedilir.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenin**

Aşağıdaki yardımcı, her dolu olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) okur ve son segmentin [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) değerini [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) ile karşılaştırır. Boş olmayan yol olmadığında false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek bir dikdörtgen için `true` yazar.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Şekil Öğelerini Çıkarma ve İnceleme**

Mevcut bir şekli, yol noktaları ve nokta türlerini içeren öğeler olarak incelemek için [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) kullanın. Dönen her [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) üzerinden [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) ve [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) metodlarıyla nokta ve tip dizileri alınır. Bu temsil, kontur analizi veya geometriyi özel çizim araçlarına aktarmak için kullanışlıdır.

Örnek, input.pptx dosyasını açar, ilk slaytta doğrudan ilk geometri şeklini bulur ve yol segmentlerini yazdırır. Hem düz hem de eğri segmentler içeren bir şekil içeren bir sunum kullanın; çıktı iki türde de gösterilir. Gruplar içinde arama yapılmaz.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Bayrakları hariç tutarak segment tipini koru.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Diziler indeksle eşleşir: `$points[$i]` bir noktadır ve `$types[$i]` onun rolünü tanımlar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan şu anki noktaya bir çizgi çizer. Kübik Bézier segmenti önceki bitiş noktasından başlar ve üç ardışık tip-`3` girdisi kullanır: iki kontrol noktası ardından yeni bitiş noktası. Döngü bu üç girdiği birlikte tüketir ve kapanış için bitiş noktasını denetler.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` ile maskeleyin ve kapalı bir alt yol tespiti için `0x80` i ayrı‑ ayrı test edin. Örneğin `129` (`0x81`) bir satır bitiş noktası olup bir alt yolu kapatır, `131` (`0x83`) ise bir Bézier bitiş noktası olup bir alt yolu kapatır. PHP/Java Bridge byte dizisini ikili bir dize olarak döndürür; "C*" ile ayrıştırmak işaretsiz byte değerleri üretir. Maskeleme, amaçlanan bit değerlerini korur. Sadece `1` veya `3` ile karşılaştırmak bu durumları atlayacaktır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) biriminde ölçülür; X sağa, Y aşağı doğru artar. Gruplamış bir şekil için, çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutunda bir döndürülmemiş dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. X ve Y değerlerini çıkararak, dönüşülmemiş çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) tarafından döndürülen şeklin rotasyonunu veya yatay‑dikey çevirileri uygulamaz. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezinde uygulayın. Gruplar içinde ise grup koordinat haritalamasını ve dönüşümleri de hesaba katın; çıkarılan noktaların sunumun nihai slayt koordinatları olduğunu varsaymayın ve çeviri ya da ölçekleme iki kez uygulanmasın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tip dizilerine ihtiyaç duyduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyaç duyuyorsanız ya da geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) veya [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulayın.

## **Java AWT Şekilini GeometryPath’e Dönüştürme**

Bu örnek, bir dikdörtgen konturunu metne dönüştürülmüş geometrisiyle birleştirir. Konturun [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) yöntemi doldurulmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html), bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin konturunu oluşturur. Bunun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapanış segmentlerini sağlar; örnek bunları bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) üzerinde yeniden oynatır.

Örnek, PHP/Java Bridge’in iteratör tarafından yazılan koordinatları koruması için bir Java float dizisi kullanır. Metin 40 puanlık Arial yazı tipinde. Kontur yatayda 20 puan kaydırılır ve görsel üstü şeklin üst kenarının 10 puan altında konumlandırılır. Metin yolu doldurulurken, orijinal dikdörtgen bir kontur olarak kalır. Her iki yolu da [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulamak, dikdörtgen ve metni içeren tek bir şekil üretir.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometri değiştirildikten sonra dolgu ve kontur ne olur?**

Stil şekil ile birlikte kalır; yalnızca kontur değişir. Dolgu ve kontur yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte doğru şekilde nasıl döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) yöntemini kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Sonucu "kilitlemek" için özel bir şekli görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slide](/slides/tr/php-java/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/php-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle sonraki çalışmayı basitleştirir.