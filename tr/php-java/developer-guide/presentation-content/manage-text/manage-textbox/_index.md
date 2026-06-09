---
title: Sunumlarda PHP Kullanarak Metin Kutularını Yönetme
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
- hiperlink ekle
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP, PowerPoint ve OpenDocument dosyalarında metin kutularını kolayca oluşturmanıza, düzenlemenize ve kopyalamanıza olanak tanır, sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutuları veya şekiller içinde bulunur. Bu nedenle, bir slayta metin eklemek için önce bir metin kutusu eklemeli ve ardından metni bu kutuya yerleştirmelisiniz. Aspose.Slides for PHP via Java, içinde metin barındıran bir şekil eklemenizi sağlayan [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) sınıfını sunar.

{{% alert title="Bilgi" color="info" %}}

Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfını da sunar. Ancak, `Shape` sınıfı üzerinden eklenen tüm şekiller metin içermeyebilir. `AutoShape` sınıfı üzerinden eklenen şekiller ise metin içerebilir.

{{% /alert %}}

{{% alert title="Not" color="warning" %}} 

Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `AutoShape` sınıfı üzerinden oluşturulduğunu kontrol edip doğrulamak isteyebilirsiniz. Ancak o zaman `AutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ile çalışabilirsiniz. Bu sayfadaki [Update Text](/slides/tr/php-java/manage-textbox/#update-text) bölümüne bakın.

{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın.  
3. Slayt üzerinde belirtilen bir konumda `Rectangle` olarak ayarlanmış şekil türü ile bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesnesi ekleyin ve yeni eklenen `AutoShape` nesnesinin referansını alın.  
4. `AutoShape` nesnesine bir `TextFrame` ekleyin; bu çerçeve metin içerecektir. Aşağıdaki örnekte, *Aspose TextBox* metni eklendi.  
5. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin.  

Yukarıdaki adımları uygulayan bu PHP kodu, bir slayta metin eklemenizi gösterir:

```php
  # Presentation nesnesini oluşturur
  # Sunumdaki ilk slaytı alır
  # Tipi Rectangle olarak ayarlanmış bir AutoShape ekler
  # Rectangle'a bir TextFrame ekler
  # TextFrame'e erişir
  # TextFrame için Paragraph nesnesi oluşturur
  # Paragraph için bir Portion nesnesi oluşturur
  # Metni ayarlar
  # Sunumu diske kaydeder
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    $ashp->addTextFrame(" ");
    $txtFrame = $ashp->getTextFrame();
    $para = $txtFrame->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Aspose TextBox");
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, şekilleri inceleyip metin kutularını tespit etmenizi sağlayan `AutoShape` sınıfındaki [isTextBox](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/istextbox/) yöntemini sunar.

![Text box and shape](istextbox.png)

Bu PHP kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Unutmayın ki, `ShapeCollection` sınıfındaki `addAutoShape` yöntemiyle bir autoshape eklediğinizde, bu autoshape’in `isTextBox` yöntemi **false** dönecektir. Ancak, `addTextFrame` veya `setText` yöntemleriyle autoshape’e metin eklediğinizde, `isTextBox` özelliği **true** döner.

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

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, metin kutularına sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfındaki [setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumncount/) ve [setColumnSpacing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumnspacing/) yöntemlerini sunar. Bu sayede bir metin kutusundaki sütun sayısını ve sütunlar arasındaki boşluk miktarını puan (point) cinsinden belirleyebilirsiniz.

Bu kod, açıklanan işlemi gösterir:

```php
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # Tipi Rectangle olarak ayarlanmış bir AutoShape ekler
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Rectangle'a bir TextFrame ekler
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # TextFrame'in metin formatını alır
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # TextFrame içindeki sütun sayısını belirtir
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
Aspose.Slides for PHP via Java, metin çerçevelerine sütun eklemenizi sağlayan [TextFrameFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/) sınıfındaki [setColumnCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframeformat/setcolumncount/) yöntemini sunar. Bu özellik sayesinde bir metin çerçevesinde istediğiniz sütun sayısını belirtebilirsiniz.

Bu PHP kodu, bir metin çerçevesine sütun eklemeyi gösterir:

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

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki ya da bir sunumdaki tüm metinlerde değişiklik yapmanıza ve güncellemenize olanak tanır.

Bu PHP kodu, bir sunumdaki tüm metinlerin nasıl güncellenip değiştirileceğini gösterir:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Şeklin metin çerçevesini (IAutoShape) destekleyip desteklemediğini kontrol eder.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Metin çerçevesindeki paragraflar arasında döner
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Paragraftaki her bölümü iterasyonla dolaşır
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Metni değiştirir

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Formatlamayı değiştirir

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

## **Hipermetin Bağlantılı Bir Metin Kutusu Ekleme**

Bir metin kutusunun içine bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında, kullanıcılar bağlantıyı açar.

Bir bağlantı içeren metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.  
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın.  
3. Slayt üzerinde belirtilen bir konumda `Rectangle` olarak ayarlanmış `ShapeType` ile bir `AutoShape` nesnesi ekleyin ve yeni eklenen `AutoShape` nesnesinin referansını alın.  
4. `AutoShape` nesnesine *Aspose TextBox* varsayılan metni içeren bir `TextFrame` ekleyin.  
5. `HyperlinkManager` sınıfının bir örneğini oluşturun.  
6. `TextFrame` içinde istediğiniz bölüme [setExternalHyperlinkClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) yöntemiyle bir dış bağlantı atayın.  
7. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını kaydedin.  

Bu PHP kodu, bir slayta hipermetin bağlantılı bir metin kutusu eklemeyi gösterir:

```php
  # PPTX'i temsil eden bir Presentation sınıfının örneğini oluşturur
  $pres = new Presentation();
  try {
    # Sunumdaki ilk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # Tipi Rectangle olarak ayarlanmış bir AutoShape nesnesi ekler
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Şekli AutoShape'e dönüştürür
    $pptxAutoShape = $shape;
    # AutoShape ile ilişkili ITextFrame özelliğine erişir
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Çerçeveye bir miktar metin ekler
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Bölüm metni için Hipermetni ayarlar
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # PPTX Sunumunu kaydeder
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Ana slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/php-java/manage-placeholder/) stil/konumu [master](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) dan miras alır ve [layout](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) larda geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve layout değiştirildiğinde değişmez.

**Sunumdaki metni toplu olarak değiştirmek isterken grafikleri, tabloları ve SmartArt içindeki metinlere dokunmadan nasıl gerçekleştiririm?**

Metin çerçeveleri olan otomatik şekilleri iterasyonla ele alıp gömülü nesneleri ([chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/), [table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/)) dışarıda bırakın; bu nesnelerin koleksiyonlarını ayrı ayrı dolaşarak veya bu tip nesneleri atlayarak gerçekleştirebilirsiniz.