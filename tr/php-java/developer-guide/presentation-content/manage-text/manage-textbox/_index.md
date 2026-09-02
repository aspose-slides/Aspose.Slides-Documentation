---
title: PHP Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/php-java/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- köprü ekle
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP, PowerPoint ve OpenDocument dosyalarında metin kutularını kolayca oluşturmanızı, düzenlemenizi ve kopyalamanızı sağlar ve sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için bir metin kutusu eklemeniz ve ardından kutuya bazı metin yerleştirmeniz gerekir. Aspose.Slides for PHP via Java, bazı metin içeren bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) sınıfını sağlar.

{{% alert title="Bilgi" color="info" %}}

Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfını sunar. Ancak, `Shape` sınıfı aracılığıyla eklenen tüm şekiller metin tutamaz. `AutoShape` sınıfı aracılığıyla eklenen şekiller ise metin içerebilir.

{{% /alert %}}

{{% alert title="Not" color="warning" %}} 

Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `AutoShape` sınıfı aracılığıyla oluşturulduğunu kontrol edip doğrulamanız gerekebilir. Ancak o zaman `AutoShape` altındaki bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ile çalışabilirsiniz. Bu sayfadaki [Metni Güncelle](/slides/tr/php-java/manage-textbox/#update-text) bölümüne bakın.

{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın.  
3. Slayt üzerindeki belirli bir konumda şekil türü olarak [Rectangle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapetype/#Rectangle) ayarlı bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesi ekleyin ve yeni eklenen `AutoShape` nesnesinin referansını elde edin.  
4. `AutoShape` nesnesine bir `TextFrame` ekleyin; bu çerçeve bir metin içerecek. Aşağıdaki örnekte *Aspose TextBox* metnini ekledik.  
5. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin.  

Bu PHP kodu—yukarıdaki adımların bir uygulaması—size bir slayta nasıl metin ekleneceğini gösterir:

```php
  # Presentation nesnesini oluşturur
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Rectangle olarak ayarlanmış bir AutoShape ekler
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Rectangle'a TextFrame ekler
    $ashp->addTextFrame(" ");
    # Metin çerçevesine erişir
    $txtFrame = $ashp->getTextFrame();
    # Metin çerçevesi için Paragraph nesnesi oluşturur
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Paragraf için Portion nesnesi oluşturur
    $portion = $para->getPortions()->get_Item(0);
    # Metni ayarlar
    $portion->setText("Aspose TextBox");
    # Sunumu diske kaydeder
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanıyan [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) sınıfından [isTextBox](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/istextbox/) yöntemini sağlar.

![Metin kutusu ve şekil](istextbox.png)

Bu PHP kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını kontrol etmenizi gösterir:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Şunu unutmayın: `addAutoShape` yöntemini [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfından kullanarak bir autoshape eklediğinizde, autoshape'in `isTextBox` yöntemi `false` döndürür. Ancak, `addTextFrame` veya `setText` yöntemleriyle autoshape'e metin eklediğinizde, `isTextBox` özelliği `true` döndürür.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() false döner
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() true döner

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() false döner
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() true döner

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() false döner
$shape3->addTextFrame("");
// shape3->isTextBox() false döner

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() false döner
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() false döner
```

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodunda, hangi sunum nesnesinin içerdiğini bilmeden bir [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) alabilirsiniz. Sahibi olan [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesnesine geri dönmek için [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) yöntemini kullanın.

[AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) veya başka bir metin içeren şekle ait bir metin çerçevesi için, [TextFrame::getParentShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentShape) sahibi döndürür ve [TextFrame::getParentCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/#getParentCell) `null` döndürür. Her iki yöntem de yalnızca okuma amaçlı gezinme sağlar; çağrıldıklarında mülkiyet değişmez. Şekle erişmeden önce her zaman dönen değeri `java_is_null` ile kontrol edin.

SmartArt düğümleriyle ilişkili şekilleri de içeren, şekil ve tablo hücresi sahiplerini tanımlayan tam bir örnek için [Metin Ara ve Değiştir](/slides/tr/php-java/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfından [setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumncount/) ve [setColumnSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumnspacing/) yöntemlerini sağlayarak metin kutularına sütun eklemenize olanak tanır. Bir metin kutusundaki sütun sayısını belirtebilir ve sütunlar arasındaki boşluğu puan cinsinden ayarlayabilirsiniz.

Bu kod, açıklanan işlemi göstermektedir:

```php
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # Şekil türü Rectangle olarak ayarlanmış bir AutoShape ekler
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle'a TextFrame ekler
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame'in metin formatını alır
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame'de sütun sayısını belirtir
    $format->setColumnCount(3);
    # Sütunlar arasındaki boşluğu belirtir
    $format->setColumnSpacing(10);
    # Sunumu kaydeder
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metin Çerçevesine Sütun Ekleme**
Aspose.Slides for PHP via Java, metin çerçevelerine sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfından [setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumncount/) yöntemini sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirtebilirsiniz.

Bu PHP kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metni Güncelle**

Aspose.Slides, bir metin kutusunda veya bir sunumdaki tüm metinlerdeki içeriği değiştirmenize veya güncellemenize izin verir.

Bu PHP kodu, bir sunumdaki tüm metinlerin güncellenmesini veya değiştirilmesini gösteren bir işlemi örnekler:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Metin çerçevesindeki paragrafları iterasyonla gezer
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Paragraftaki her bölümü iterasyonla gezer
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Metni değiştirir

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Biçimlendirmeyi değiştirir

            }
          }
        }
      }
    }
    # Değiştirilmiş sunumu kaydeder
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Köprü İçeren Metin Kutusu Ekle**

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında kullanıcılar bağlantıyı açmak için yönlendirilir.

Bir bağlantı içeren metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumun ilk slaytı için bir referans alın.  
3. Slayt üzerindeki belirli bir konumda `ShapeType` değerini `Rectangle` olarak ayarladığınız bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesinin referansını elde edin.  
4. `AutoShape` nesnesine *Aspose TextBox* varsayılan metnini içeren bir `TextFrame` ekleyin.  
5. `HyperlinkManager` sınıfını örnekleyin.  
6. `TextFrame` içindeki istediğiniz bölüme [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) yöntemiyle bir köprü atayın.  
7. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin.  

Bu PHP kodu—yukarıdaki adımların bir uygulaması—size bir slayta köprü içeren bir metin kutusu eklemenin yolunu gösterir:

```php
  # Bir PPTX temsil eden Presentation sınıfının bir örneğini oluşturur
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # Türü Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Şekli AutoShape tipine dönüştürür
    $pptxAutoShape = $shape;
    # AutoShape ile ilişkili ITextFrame özelliğine erişir
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Çerçeveye bir metin ekler
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Parça metni için Köprüyü ayarlar
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX sunumunu kaydeder
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Ana slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/php-java/manage-placeholder/) stil/konumu [master](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) üzerinden devralır ve [layouts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzenleri değiştirdiğinizde değişmez.

**Grafikler, tablolar ve SmartArt içindeki metinlere dokunmadan sunumda toplu metin değiştirme nasıl yapılır?**

Metin çerçevelerine sahip autoshape'leri yineleyerek ve yerleşik nesneleri ([charts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/)) dışarıda bırakarak koleksiyonlarını ayrı ayrı gezebilir veya bu nesne türlerini atlayabilirsiniz.