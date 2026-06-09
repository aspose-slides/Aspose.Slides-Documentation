---
title: PHP'de Sunumlardan Paragraf Sınırlarını Al
linktitle: Paragraf
type: docs
weight: 60
url: /tr/php-java/paragraph/
keywords:
- paragraf sınırları
- metin bölümü sınırları
- paragraf koordinatı
- bölüm koordinatı
- paragraf boyutu
- metin bölümü boyutu
- metin çerçevesi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da paragraf ve metin bölümü sınırlarını almayı öğrenerek PowerPoint sunumlarında metin konumlandırmasını optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde paragrafların ve metin bölümlerinin sınırlamalarını, boyutunu ve koordinatlarını nasıl alacağınızı açıklar. `getRect()` kullanarak bir `TextFrame` içinde paragrafın dikdörtgenini nasıl alacağınızı, tablo hücresi metin çerçevesi içinde paragraf ve bölüm koordinatlarını nasıl alacağınızı gösterir ve ölçüm birimleri, metin kaydırmanın sınırlamalara etkisi, piksel dönüşümü ve etkili paragraf biçimlendirme değerleri gibi önemli ayrıntıları vurgular.

## **Paragraf ve Bölüm Koordinatlarını bir TextFrame içinde Al**

Java üzerinden PHP için Aspose.Slides kullanarak, geliştiriciler artık TextFrame'in paragraf koleksiyonundaki Paragraf için dikdörtgen koordinatlarını alabilir. Ayrıca bir paragraftaki bölüm koleksiyonundaki [bölüm koordinatlarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getCoordinates) almanıza da izin verir. Bu konuda, bir örnek yardımıyla paragrafın dikdörtgen koordinatlarını ve paragraf içindeki bölümün konumunu nasıl alacağınızı göstereceğiz.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Paragrafın Dikdörtgen Koordinatlarını Al**

Geliştiriciler, [**getRect()**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getRect) yöntemini kullanarak paragraf sınırları dikdörtgenini alabilir.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Tablo Hücresi TextFrame içinde Paragraf ve Bölümün Boyutunu Al**

Tablo hücresi metin çerçevesinde [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Portion) veya [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Paragraph) boyutunu ve koordinatlarını elde etmek için [Portion::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getRect) ve [Paragraph::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/#getRect) yöntemlerini kullanabilirsiniz.

Bu örnek kod, açıklanan işlemi gösterir:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Paragraf ve metin bölümleri için döndürülen koordinatlar hangi birimlerde ölçülür?**

Puan (point) cinsinden, 1 inç = 72 puan. Bu, slayttaki tüm koordinat ve boyutlar için geçerlidir.

**Kelime kaydırma bir paragrafın sınırlarını etkiler mi?**

Evet. Eğer [wrapping](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setwraptext/) [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içinde etkinleştirilmişse, metin alana genişliğe uyması için bölünür ve bu paragrafın gerçek sınırlarını değiştirir.

**Paragraf koordinatları dışa aktarılan görüntüde piksellere güvenilir bir şekilde eşlenebilir mi?**

Evet. Puanları piksellere şu şekilde dönüştürün: pixels = points × (DPI / 72). Sonuç, render/ dışa aktarma için seçilen DPI'ye bağlıdır.

**"Etkili" paragraf biçimlendirme parametrelerini, stil kalıtımını göz önünde bulundurarak nasıl alırım?**

[effective paragraph formatting data structure](/slides/tr/php-java/shape-effective-properties/) kullanın; bu, girintiler, boşluklar, kaydırma, RTL ve diğerleri için nihai birleştirilmiş değerleri döndürür.