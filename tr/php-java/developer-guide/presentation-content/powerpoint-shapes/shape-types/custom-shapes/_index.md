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
- kavisli köşe
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, kavisli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştirileceğini açıklıyor. `GeometryPath` ile mevcut şekilleri nasıl değiştirebileceğinizi, temel yol düzenleme işlemlerini nasıl gerçekleştirebileceğinizi, nokta ekleyip kaldırmayı ve güncellenmiş geometrinin şekle yeniden uygulanmasını gösterir.

Ayrıca, özel ve birleşik şekillerin nasıl oluşturulacağını, kavisli köşeli şekillerin nasıl inşa edileceğini, bir şekil geometrisinin kapalı olup olmadığının nasıl belirleneceğini ve ek geometri özelleştirme senaryoları için `GeometryPath` ile `java.awt.Shape` arasında nasıl dönüştürüleceğini gösterir.

## **Düzenleme Noktalarını Kullanarak Şekli Değiştirme**

Bir kareyi düşünün. PowerPoint’te **düzenleme noktalarını** kullanarak şunları yapabilirsiniz

* karenin köşesini içeri ya da dışarı doğru hareket ettirmek
* bir köşe ya da noktanın eğriliğini belirlemek
* kareye yeni noktalar eklemek
* kare üzerindeki noktaları manipüle etmek, vb. 

Özetle, tanımlanan görevleri herhangi bir şekil üzerinde gerçekleştirebilirsiniz. Düzenleme noktalarını kullanarak bir şekli değiştirebilir veya mevcut bir şekilden yeni bir şekil oluşturabilirsiniz. 

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenleme noktaları aracılığıyla düzenlemeye başlamadan önce, şekillerle ilgili aşağıdaki noktalara göz atmak isteyebilirsiniz:

* Bir şekil (veya yolu) ya kapalı ya da açıktır.
* Bir şekil kapalı olduğunda bir başlangıç ya da bitiş noktasına sahip değildir. Şekil açık olduğunda bir başlangıç ve bitişi vardır.
* Tüm şekiller, birbirine çizgilerle bağlanan en az 2 tutama noktasından oluşur.
* Bir çizgi ya düz ya da kavisli olabilir. Tutama noktaları çizginin niteliğini belirler.
* Tutama noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Bir köşe noktası, 2 düz çizginin bir açıyla birleştiği noktadır.
  * Bir yumuşak nokta, 2 tutamaçının düz bir hat üzerinde bulunduğu ve çizgi segmentlerinin sorunsuz bir eğri ile birleştiği noktadır. Bu durumda, tüm tutamaçlar tutama noktasından eşit bir mesafede bulunur.
  * Bir düz nokta, 2 tutamaçının düz bir hat üzerinde bulunduğu ve çizgi segmentlerinin bir eğriyle birleştiği noktadır. Bu durumda tutamaçların tutama noktasından eşit mesafede olmaları gerekmez.
* Tutama noktalarını (çizgi açılarını değiştiren) hareket ettirerek veya düzenleyerek bir şeklin görünümünü değiştirebilirsiniz. 

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [**GeometryPath**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) örneği, [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* `GeometryShape` örneğinden `GeometryPath` değerini almak için [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#getGeometryPaths) metodunu kullanabilirsiniz.
* Bir şekil için `GeometryPath` ayarlamak üzere bu yöntemleri kullanabilirsiniz: *katı şekiller* için [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#setGeometryPath) ve *birleşik şekiller* için [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#setGeometryPaths).
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath::setStroke](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/setstroke/) ve [GeometryPath::setFillMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/setfillmode/) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath::getPathData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/getpathdata/) yöntemini kullanarak bir `GeometryShape`'in geometri yolunu yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/) öğesini [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) öğesine dönüştürebilirsiniz.
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) ve [graphicsPathToGeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) yöntemlerini ([ShapeUtil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeUtil) sınıfından) kullanarak [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/) öğesini [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) öğesine ve geri dönüştürebilirsiniz.

## **Basit Düzenleme İşlemleri**

Bu PHP kodu size nasıl

**Bir satır ekle** bir yolun sonuna

```php

```
**Bir satır ekle** bir yolun belirli bir konumuna:

```php

```
**Kübik Bezier eğrisi ekle** bir yolun sonuna:

```php

```
**Kübik Bezier eğrisi ekle** bir yolun belirli bir konumuna:

```php

```
**Kuadratik Bezier eğrisi ekle** bir yolun sonuna:

```php

```
**Kuadratik Bezier eğrisi ekle** bir yolun belirli bir konumuna:

```php

```
**Belirli bir yay ekle** bir yola:

```php

```
**Mevcut şekli kapat** bir yolda:

```php

```
**Sonraki nokta için konumu ayarla**:

```php

```
**Belirli bir indeksindeki yol segmentini kaldır**:

```php

```

## **Bir Şekle Özel Noktalar Ekle**

1. [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType::Rectangle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfı örneği alın.
3. Yoldaki iki üst nokta arasına yeni bir nokta ekleyin.
4. Yoldaki iki alt nokta arasına yeni bir nokta ekleyin.
5. Yolu şekle uygulayın.

Bu PHP kodu, bir şekle özel noktalar nasıl eklenir gösterir:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Şekilden Noktaları Kaldırma**

1. [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun ve [ShapeType::Heart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeType) tipini ayarlayın.
2. Şekilden bir [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfı örneği alın.
3. Yol için segmenti kaldırın.
4. Yolu şekle uygulayın.

Bu PHP kodu, bir şekilden noktaların nasıl kaldırılacağını gösterir:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

1. Şekil için noktaları hesaplayın.
2. [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfının bir örneğini oluşturun.
3. Yolu noktalarla doldurun.
4. [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
5. Yolu şekle uygulayın.

Bu Java kodu, özel bir şekil nasıl oluşturulur gösterir:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **Bileşik Özel Şekil Oluşturma**

  1. [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
  2. [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfının ilk örneğini oluşturun.
  3. [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) sınıfının ikinci örneğini oluşturun.
  4. Yolları şekle uygulayın.

Bu PHP kodu, bir bileşik özel şekil nasıl oluşturulur gösterir:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Kavisli Köşeli Özel Şekil Oluşturma**

Bu PHP kodu, içe doğru kavisli köşelere sahip özel bir şekil nasıl oluşturulacağını gösterir;

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Kapalı bir şekil, tüm kenarları birbirine bağlanarak boşluk bırakmayan tek bir sınır oluşturan şekil olarak tanımlanır. Böyle bir şekil basit bir geometrik form ya da karmaşık bir özel kontur olabilir. Aşağıdaki kod örneği, bir şekil geometrisinin kapalı olup olmadığını nasıl kontrol edeceğinizi gösterir:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **GeometryPath'i java.awt.Shape'e Dönüştürme**

1. [GeometryShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryShape) sınıfının bir örneğini oluşturun.
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) sınıfının bir örneğini oluşturun.
3. [ShapeUtil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeUtil) kullanarak [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) örneğini [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/GeometryPath) örneğine dönüştürün.
4. Yolları şekle uygulayın.

Bu PHP kodu—yukarıdaki adımların bir uygulaması—**GeometryPath**'i **GraphicsPath**'e dönüştürme sürecini gösterir:

```php
  $pres = new Presentation();
  try {
    # Yeni bir şekil oluştur
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Şeklin geometri yolunu al
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Metinle yeni bir grafik yolu oluştur
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Grafik yolunu geometri yoluna dönüştür
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Yeni geometri yolu ve orijinal geometri yolunun kombinasyonunu şekle ayarla
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Geometriyi değiştirdikten sonra dolgu ve kenarlık ne olur?**

Stil şekil ile kalır; sadece kontur değişir. Dolgu ve kenarlık otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru şekilde döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setrotation/) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekil ile birlikte döner.

**Sonucu "kilitlemek" için özel bir şekli bir görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slaytı](/slides/tr/php-java/convert-powerpoint-to-png/) bölgesini ya da [şekli](/slides/tr/php-java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarabilirsiniz; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.