---
title: PHP'de Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/php-java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil yerleşim biçimleri
- şekil SVG olarak
- şekli SVG'ye
- şekli hizala
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da şekilleri oluşturmayı, düzenlemeyi ve optimize etmeyi öğrenin ve yüksek performanslı PowerPoint sunumları sunun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardaki şekillerle nasıl çalışılacağını açıklar. Bir slayttaki şekli bulma, kopyalama, kaldırma, gizleme, sırasını değiştirme, Interop şekil kimliğini alma ve tanımlama ile sonraki işlemler için alternatif metin ayarlama süreçlerini gösterir.

Ayrıca şekiller için yerleşim biçimlerine erişim, şekli SVG olarak oluşturma, slayttaki şekilleri hizalama ve yatay‑dikey yansıtma için flip özelliklerinin kullanımını kapsar. Makaleye ek olarak, şekil birleştirme, katman sırası ve şekil kilitleme konularında kısa bir SSS de eklenmiştir.

## **Bir Slaytta Şekil Bulma**
Bu bölüm, geliştiricilerin bir şeklin dahili Id'sini kullanmadan belirli bir şekli bulmasını kolaylaştıran basit bir teknik tanımlar. PowerPoint dosyalarında bir şekli tanımlamanın dahili benzersiz Id dışındaki bir yolu yoktur. Geliştiricilerin dahili benzersiz Id ile şekil bulması zor olabilir. Tüm eklenen şekillerin bir Alternatif Metni (Alt Text) vardır. Belirli bir şekli bulmak için alternatif metnin kullanılmasını öneririz. Gelecekte değiştirmeyi düşündüğünüz nesneler için MS PowerPoint ile alternatif metin tanımlayabilirsiniz.

İstediğiniz şeklin alternatif metnini ayarladıktan sonra, Aspose.Slides for PHP via Java ile sunumu açıp slayta eklenen tüm şekillerde dönebilir ve her yinelemede şeklin alternatif metnini kontrol edebilirsiniz; eşleşen alternatif metne sahip şekil sizin istediğiniz şekil olacaktır. Bu tekniği daha iyi göstermek için, bir slaytta belirli bir şekli bulup doğrudan döndüren bir yöntem oluşturduk: [findShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-).

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfı örneği oluştur
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Bulunacak şeklin alternatif metni
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Şekil Kopyalama**
Aspose.Slides for PHP via Java ile bir şekli bir slayta kopyalamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaydın indeksini kullanarak slayt referansını elde edin.
1. Kaynak slaydın şekil koleksiyonuna erişin.
1. Sunuma yeni bir slayt ekleyin.
1. Kaynak slaydın şekil koleksiyonundan yeni slayta şekilleri kopyalayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek bir grup şekli slayta ekler.

```php
  # Presentation sınıfını örnekle
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # PPTX dosyasını diske yaz
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekil Kaldırma**
Aspose.Slides for PHP via Java, geliştiricilerin herhangi bir şekli kaldırmasına olanak tanır. Şekli bir slayttan kaldırmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Belirli bir AlternativeText içeren şekli bulun.
1. Şekli kaldırın.
1. Dosyayı diske kaydedin.

```php
  # Presentation nesnesi oluştur
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde otomatik şekil ekle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Sunumu diske kaydet
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekil Gizleme**
Aspose.Slides for PHP via Java, geliştiricilerin herhangi bir şekli gizlemesine olanak tanır. Şekli bir slaytta gizlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Belirli bir AlternativeText içeren şekli bulun.
1. Şekli gizleyin.
1. Dosyayı diske kaydedin.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde otomatik şekil ekle
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Sunumu diske kaydet
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekil Sırasını Değiştirme**
Aspose.Slides for PHP via Java, geliştiricilerin şekillerin sırasını değiştirmesine izin verir. Sıra değişikliği, hangi şeklin önde, hangisinin arka planda olduğunu belirler. Şeklin sırasını değiştirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Bir şekil ekleyin.
1. Şeklin metin çerçevesine bazı metinler ekleyin.
1. Aynı koordinatlarda başka bir şekil ekleyin.
1. Şekilleri yeniden sırala.
1. Dosyayı diske kaydedin.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop Şekil Kimliğini Alma**
Aspose.Slides for PHP via Java, geliştiricilerin slayt kapsamında benzersiz bir şekil tanımlayıcısı almasını sağlar; bu, [getUniqueId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getuniqueid/) metodunun sunum kapsamındaki benzersiz tanımlayıcıdan farklıdır. [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfına eklenen [getOfficeInteropShapeId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getofficeinteropshapeid/) yöntemi, Microsoft.Office.Interop.PowerPoint.Shape nesnesinin Id değerine karşılık gelen bir değer döndürür. Aşağıda örnek kod yer almaktadır.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Slayt kapsamında benzersiz şekil tanımlayıcısını al
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şekil İçin Alternatif Metin Ayarlama**
Aspose.Slides for PHP via Java, geliştiricilerin herhangi bir şeklin AlternateText değerini ayarlamasına olanak tanır. Bir sunumdaki şekiller `Alternative Text` veya [Shape Name](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setname/) yöntemiyle ayırt edilebilir. [setAlternativeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setalternativetext/) ve [getAlternativeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getalternativetext/) yöntemleri Aspose.Slides ve Microsoft PowerPoint tarafından okunup ayarlanabilir. Bu yöntemle bir şekli etiketleyebilir ve Şekli Kaldırma, Şekli Gizleme veya Slaytta Şekil Sıralama gibi farklı işlemler gerçekleştirebilirsiniz. Bir şeklin AlternateText değerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Slayta herhangi bir şekil ekleyin.
1. Yeni eklenen şekil ile bazı işlemler yapın.
1. Şekiller arasında gezinerek istediğiniz şekli bulun.
1. AlternativeText değerini ayarlayın.
1. Dosyayı diske kaydedin.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde otomatik şekil ekle
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Sunumu diske kaydet
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şekil İçin Yerleşim Biçimlerine Erişim**
Aspose.Slides for PHP via Java, bir şeklin yerleşim biçimlerine erişmek için basit bir API sunar. Bu makale, yerleşim biçimlerine nasıl erişileceğini gösterir.

Aşağıda örnek kod bulunmaktadır.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekli SVG Olarak Oluşturma**
Artık Aspose.Slides for PHP via Java, bir şekli SVG olarak oluşturmayı destekler. [writeAsSvg](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) (ve aşırı yüklenmiş sürümü) yöntemi [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfına eklenmiştir. Bu yöntem, şeklin içeriğini bir SVG dosyası olarak kaydetmeye olanak tanır. Aşağıdaki kod parçacığı, slaytın şekli bir SVG dosyasına nasıl dışa aktarılacağını gösterir.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekli Hizalama**
Aspose.Slides, şekilleri ya slayt kenar boşluklarına ya da birbirlerine göre hizalamaya izin verir. Bu amaçla, aşırı yüklenmiş [SlidesUtil::alignShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/alignshapes/) yöntemi eklenmiştir. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapesalignmenttype/) enum’ı olası hizalama seçeneklerini tanımlar.

**Örnek 1**

Aşağıdaki kaynak kod, indeksleri 1, 2 ve 4 olan şekilleri slaytın üst kenarı boyunca hizalar.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Örnek 2**

Aşağıdaki örnek, şekil koleksiyonunun tamamını koleksiyondaki en alttaki şekle göre hizalamayı gösterir.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Flip Özellikleri**

Aspose.Slides’ta, [ShapeFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/) sınıfı, `flipH` ve `flipV` özellikleri aracılığıyla şekillerin yatay ve dikey yansıtılmasını kontrol eder. Her iki özellik de [NullableBool](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) tipindedir; `True` dönüşümü, `False` dönüşüm yoksa, `NotDefined` varsayılan davranışı ifade eder. Bu değerler bir şeklin [Frame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getFrame) özelliğinden erişilebilir.

Flip ayarlarını değiştirmek için, şeklin mevcut konum ve boyutları, istenen `flipH` ve `flipV` değerleri ve döndürme açısı ile yeni bir [ShapeFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/) örneği oluşturulur. Bu örnek şeklin [Frame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getFrame) özelliğine atanır ve sunum kaydedildiğinde yansıtma dönüşümleri uygulanır ve çıktıya işlenir.

İlk slaytında varsayılan flip ayarlarına sahip tek bir şekil bulunan örnek.pptx dosyamız olduğunu varsayalım.

![The shape to be flipped](shape_to_be_flipped.png)

Aşağıdaki kod örneği, şeklin mevcut flip özelliklerini alır ve hem yatay hem de dikey olarak çevirir.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Şeklin yatay çevirme özelliğini al.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Şeklin dikey çevirme özelliğini al.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Yatay olarak çevir.
    $flipV = NullableBool::True; // Yatay olarak çevir.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Bir slaytta şekilleri (birleşim/kesişim/çıkarma) masaüstü editörü gibi birleştirebilir miyim?**

Yerleşik bir Boolean işlem API’si yoktur. İstediğiniz konturu kendiniz oluşturup (ör. [GeometryPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometrypath/) ile sonuç geometrisini hesaplayıp) yeni bir şekil oluşturabilir, orijinal şekilleri isteğe bağlı olarak kaldırabilirsiniz.

**Şeklin her zaman “üstte” kalmasını sağlamak için katman sırasını (z‑order) nasıl kontrol edebilirim?**

Slaydın [shapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getShapes) koleksiyonundaki ekleme/taşıma sırasını değiştirin. Tutarlı sonuçlar için, tüm diğer slayt değişikliklerinden sonra z‑order’ı sabitleyin.

**PowerPoint’te bir şeklin düzenlenmesini engellemek için “kilitleyebilir” miyim?**

Evet. Şekil düzeyinde koruma bayraklarını (ör. seçim, hareket, yeniden boyutlandırma, metin düzenlemelerini kilitle) ayarlayabilirsiniz. Gerekirse, bu kısıtlamaları master veya layout’a da yansıtabilirsiniz. Bu, UI‑düzeyinde bir korumadır, güvenlik özelliği değildir; daha güçlü koruma için dosya‑düzeyi kısıtlamalarla (örn. [salt okunur önerileri veya parolalar](/slides/tr/php-java/password-protected-presentation/)) birleştirin.