---
title: PHP'de Sunum Köprülerini Yönetin
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/php-java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprüyü biçimlendir
- köprüyü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- görüntü köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarındaki köprüleri zahmetsizce yönetin — etkileşimi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Köprü, bir nesneye, veriye ya da bir konuma başvuran bir referanstır. Bunlar PowerPoint Sunumlarında yaygın köprülerdir:

* Metin, şekil veya medya içinde web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for PHP via Java, sunumlarda köprülerle ilgili birçok görevi gerçekleştirmenizi sağlar.

{{% alert color="primary" %}} 
Aspose basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

### **Metne URL Köprüsü Ekleme**

Bu PHP kodu, bir metne web sitesi köprüsü eklemenizi gösterir:

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Şekillere veya Çerçevelere URL Köprüsü Ekleme**

Bu örnek kod, bir şekle web sitesi köprüsü eklemenizi gösterir:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Medyaya URL Köprüsü Ekleme**

Aspose.Slides, görüntülere, ses ve video dosyalarına köprü eklemenize olanak tanır. 

Bu örnek kod, bir **görüntüye** köprü eklemenizi gösterir:

```php
  $pres = new Presentation();
  try {
    # Sunuma görüntü ekler
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Daha önce eklenen görüntüye dayanarak slayt 1'de resim çerçevesi oluşturur
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu örnek kod, bir **ses dosyasına** köprü eklemenizi gösterir:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Bu örnek kod, bir **video**’ya köprü eklemenizi gösterir:

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
Şu içeriğe bakmak isteyebilirsiniz *[OLE Yönetimi](/slides/tr/php-java/manage-ole/)*.
{{% /alert %}}

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler, nesnelere veya konumlara referans eklemenize izin verdiği için bunları bir içindekiler tablosu oluşturmak için kullanabilirsiniz. 

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanızı gösterir:

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Köprüleri Biçimlendirme**

### **Renk**

[setColorSource](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/setcolorsource/) metodunu [Hyperlink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/) sınıfında kullanarak köprülerin rengini ayarlayabilir ve köprülerden renk bilgisini alabilirsiniz. Özellik ilk olarak PowerPoint 2019'da tanıtıldı, bu nedenle özellikteki değişiklikler eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, aynı slayta farklı renkte köprülerin eklenmesini gösterir:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sunumlardan Köprüleri Kaldırma**

### **Metinden Köprüleri Kaldırma**

Bu PHP kodu, bir sunum slaydındaki metinden köprüyü kaldırmanızı gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu PHP kodu, bir sunum slaydındaki bir şekilden köprüyü kaldırmanızı gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/) sınıfı değiştirilebilir. Bu sınıfla aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

Bu kod parçacığı, bir slayta köprü eklemeyi ve daha sonra araç ipucunu düzenlemeyi gösterir:

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **IHyperlinkQueries'te Desteklenen Özellikler**

Bir sunum, slayt veya köprünün tanımlandığı metinden [HyperlinkQueries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/) öğesine erişebilirsiniz.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/gethyperlinkqueries/)

[HyperlinkQueries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/) sınıfı aşağıdaki yöntem ve özellikleri destekler:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **SSS**

**Bir slayta değil, bir “bölüm”e veya bir bölümün ilk slaytına dahili navigasyon nasıl oluşturabilirim?**  

PowerPoint’te bölümler, slayt gruplarıdır; navigasyon teknik olarak belirli bir slayta yönelir. “Bir bölüme gitmek” için genellikle o bölümün ilk slaytına bağlanırsınız.

**Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**  

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu bağlantılar alt slaytlarda görünür ve gösterim sırasında tıklanabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**  

[PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) dışa aktarmalarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/php-java/convert-powerpoint-to-png/) ve [video](/slides/tr/php-java/convert-powerpoint-to-video/) dışa aktarmalarında tıklanabilirlik, bu formatların doğası gereği (raster çerçeveler/video) korunmaz.