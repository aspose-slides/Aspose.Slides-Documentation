---
title: PHP'de Sunum Şekillerini Özelleştirme
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
- eğri köşe
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides kullanarak PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğri köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta şekil geometrisini düzenleme noktaları ve geometri yolları aracılığıyla nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenen geometriyi bir şekle uygulamak için [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca özel ve birleşik şekiller oluşturma, köşeleri eğimli şekiller inşa etme, bir şekil geometrisinin kapalı olup olmadığını belirleme, şekil öğelerini inceleme ve Java AWT metin hatlarını geometri yollarına dönüştürme konularını da örneklerle anlatır.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirme**

PowerPoint’te **Düzenleme Noktalarını** kullanarak bir kareyi şu şekilde değiştirebilirsiniz:

* Bir köşeyi içe veya dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin ana hatlarını değiştirmenize veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanıza olanak tanır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları akılda tutun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, bölümlerle bağlanan çapa noktalarından oluşur.
* Bir bölüm düz veya eğimli olabilir. Çapa noktaları ve kontrol tutamaçları şeklin biçimini belirler.
* Çapa noktaları köşe, düz veya pürüzsüz nokta olarak bulunur:
  * Köşe noktasında, bitişik bölümler bir açıyla buluşabilir.
  * Pürüzsüz noktada, iki kontrol tutamağı hizalanmış ve çapa noktasından eşit mesafededir.
  * Düz noktada, iki kontrol tutamağı hizalanmıştır ancak çapa noktasından farklı mesafelerde olabilir.
* Çapa noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin ana hatlarını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) almak için [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ayarlamak için tek bir yola sahip şekillerde [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), birden fazla yola sahip şekillerde ise [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) yöntemlerini kullanabilirsiniz.
* Bölümler eklemek için [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) yöntemleriyle bir geometrik yolun görünümünü ayarlayabilirsiniz.
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) yöntemi, bir [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)’nin geometri yolunu yol bölümleri dizisi olarak döndürür.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)’i [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyabilir ve bölümleri bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) üzerinde yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir indeks kabul eden aşırı yüklemeler, bölümlerin dizi içindeki sıfır‑bazlı konumuna bir bölüm ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir son nokta içeren kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Bir kontrol noktası ve bir son nokta içeren ikinci dereceden Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen boyut ve açı ile eliptik bir yay ekleyin. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Şeklin son noktasını başlangıç noktasına bağlayarak mevcut figürü kapatın. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Bir figürün başlangıç noktasını ayarlayın. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır‑bazlı bir indeksteki bölümü kaldırın. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) kullanır ve düzenlenmiş yolu [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygular. Koordinatlar şekle göre lokal olup, her iki yeni nokta da merkezde, soldan 100 puan ve üstten 50 puan uzaktadır. Bölüm indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

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

Bu örnek, bir kalp şeklinin dış hatlarını [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) ile sıfır‑bazlı indeks 2’deki bölümü kaldırarak değiştirir. Değiştirilmiş yolu [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulamak, şeklin konturunu günceller.

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

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. Dış ve iç yarıçapların 100 ve 50 puan olarak dönüşümlü olarak ayarlanması, uçları ve girintileri tanımlar; 72 derecelik adım, beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile bir dikdörtgen şekle uygulanarak dış hatı değiştirilir.

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

Bu örnek, bir şeklin üst ve alt üçte birini temsil eden iki kapalı [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yol da [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak orta üçte bir boşluk bırakan tek bir birleşik şekil oluşturulur.

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

## **Eğri Köşeli Özel Şekil Oluşturma**

Bu örnek, [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) kullanarak içe doğru eğimli köşelere sahip bir şekil oluşturmak için düz bölümleri birleştirir. Her köşe boyutu, yay genişliğini ve yüksekliğini puan cinsinden ayarlar; -90 derecelik döndürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış bölümüyle bitip bitmediğini denetler. [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) okunur ve son bölümün [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) değeri [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş olmayan yol bulunmadığında false döner. Bu kontrol, her yolun son komutunu inceler; yol içindeki alt‑figürleri taramaz. Örnekte bir dikdörtgen için `true` çıktısı alınır.

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

## **Geometri Yol Komutlarını İnceleme**

[contour.pptx](contour.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slayttaki ilk şekil, düz bir üst kenar, bir kübik Bézier eğrisi ve düz bir kapanış kenarı içerir. Şeklin yollarını okumak için [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), her yolun çizim sırasındaki bölümlerini okumak için ise [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) kullanın. Her bölüm için [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand), komutu tanımlar ve [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

Şekil, slaytta (200, 100) puan konumunda bulunur. Bildirilen koordinatlar şekle göre lokal olup, (0, 0) köşesi şeklin sol‑üst köşesidir; x sağa, y aşağıya doğru artar. Kapanış bölümü, ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Şekil Elemanlarını Çıkarma ve İnceleme**

Mevcut bir şekli, yol noktaları ve nokta türlerini içeren öğeler olarak incelemek için [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) yöntemini kullanın. Döndürülen her [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) üzerinden [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) ve [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) ile nokta ve tür dizilerini alabilirsiniz. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için faydalıdır.

Örnek, input.pptd dosyasını açar, ilk slayttaki ilk geometri şekli bulur ve yol bölümlerini yazdırır. Düz ve eğimli bölümler içeren bir şekil kullandığınızda her iki çıktıyı da görebilirsiniz. Gruplar içinde arama yapılmaz.

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
                $pointType = $types[$i] & 0x07; // Bölüm tipini tut, bayrakları hariç tut.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Her iki kontrol noktasını ve son noktayı tüket.
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

Diziler indeks bazında eşleşir: `$points[$i]` bir nokta, `$types[$i]` ise onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan şu anki noktaya bir çizgi çizer. Kübik Bézier bölümü, önceki son noktadan başlar ve ardışık üç tip‑`3` girdisini kullanır: iki kontrol noktası ve yeni son nokta. Döngü bu üç girişi birlikte tüketir ve son noktanın kapanışı kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi, kapalı alt‑yolu algılamak için ise `0x80` ayrı ayrı test edilmelidir. Örneğin `129` (`0x81`) bir çizgi son noktasının aynı zamanda bir alt‑yolu kapattığını, `131` (`0x83`) ise bir Bézier son noktasının kapattığını gösterir. PHP/Java Bridge, bayt dizisini ikili bir dize olarak döndürür; “C*” ile ayrıştırmak unsigned bayt değerlerini verir. Maskelenmesi, istenen bit değerlerini korur. Sadece `1` veya `3` ile karşılaştırmak bu durumları göz ardı eder. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, inç başına 72 puan ölçüsünde (point) ölçülür; X sağa, Y aşağıya doğru artar. Gruplanmamış bir şekil için çıkarılan koordinatlar, zaten [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve mevcut genişlik‑yüksekliği yansıtılır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` olur. Şeklin konumunu tekrar eklemeyin; X ve Y’yi çıkartarak döndürülmemiş çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar, şeklin [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) tarafından döndürülen dönüşümünü veya yatay‑dikey çevirileri içermez. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezinde uygulayın. Gruplara ait şekillerde, grup koordinat haritalaması ve dönüşümleri de hesaba katılmalıdır; çıkarılan noktaların son slayt koordinatları olduğunu varsaymayın ve bir çeviri ya da ölçekleme zaten çocuğun çerçevesinde yansıtıldıysa iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yöntemi tercih edin. Şeklin yerel koordinat sisteminde geometri komutlarına ihtiyaç duyuyorsanız veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) veya [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulayın.

## **Java AWT Shape’i GeometryPath’e Dönüştürme**

Bu örnek, bir dikdörtgen dış hattını metinle birleştirerek geometriye dönüştürür. Dış hattın [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) yöntemi doldurmayı devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html), bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin dış hattını oluşturur. Bunun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapanış bölümlerini sağlar; örnek bu bölümleri bir [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) üzerinde yeniden oynatır.

Örnek, Java float dizisini kullanır, böylece PHP/Java Bridge iteratör tarafından yazılan koordinatları korur. Metin, 40‑puanlık Arial fontu ile oluşturulur. Dış hat, yatayda 20 puan, görsel üst kenarı şefanın üst kenarının 10 puan altında konumlandırılarak kaydırılır. Metin yolu doldurulur, orijinal dikdörtgen ise dış hat olarak kalır. Her iki yol da [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak dikdörtgen ve metni içeren tek bir şekil elde edilir.

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

**Geometriyi değiştirdikten sonra dolgu ve kenarlık ne olur?**  
Stil şekle bağlı kalır; yalnızca kontur değişir. Dolgu ve kenarlık yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**  
Şeklin [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) yöntemini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekil ile birlikte döner.

**Özel bir şekli “kilitlemek” için görüntüye dönüştürebilir miyim?**  
Evet. Gereken [slide](/slides/tr/php-java/convert-powerpoint-to-png/) alanını veya [shape](/slides/tr/php-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.