---
title: PHP'de Sunum Yakınlaştırmasını Yönet
linktitle: Yakınlaştırmayı Yönet
type: docs
weight: 60
url: /tr/php-java/manage-zoom/
keywords:
- yakınlaştırma
- yakınlaştırma çerçevesi
- slayt yakınlaştırması
- bölüm yakınlaştırması
- özet yakınlaştırması
- yakınlaştırma ekle
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile Yakınlaştırma oluşturun ve özelleştirin — bölümler arasında geçiş yapın, PPT, PPTX ve ODP sunumları arasında küçük resimler ve geçişler ekleyin."
---
## **Giriş**

PowerPoint'teki Yakınlaştırmalar belirli slaytlara, bölümlere ve sunumun parçalarına atlamanızı sağlar. Sunum yaparken, içeriğe hızlıca geçiş yapabilme yeteneği çok faydalı olabilir. 

![overview_image](overview.png)

* Tüm sunumu tek bir slaytta özetlemek için bir [Summary Zoom](#Summary-Zoom) kullanın.
* Yalnızca seçili slaytları göstermek için bir [Slide Zoom](#Slide-Zoom) kullanın.
* Tek bir bölümü göstermek için bir [Section Zoom](#Section-Zoom) kullanın.

## **Slide Zoom**
Bir slayt yakınlaştırması, sunumunuzu daha dinamik hâle getirebilir, istediğiniz sırayla slaytlar arasında kesintisiz bir şekilde gezinmenizi sağlar. Slayt yakınlaştırmaları, çok bölümlü olmayan kısa sunumlar için harikadır, ancak farklı sunum senaryolarında da kullanılabilir.

Slayt yakınlaştırmaları, tek bir tuvaldeymiş gibi hissetmenizi sağlar ve birden çok bilgi parçasına derinlemesine dalmanıza yardımcı olur. 

![overview_image](slidezoomsel.png)

Slayt yakınlaştırma nesneleri için Aspose.Slides, [ZoomImageType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zoomimagetype/) enum'ını, [ZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfı altında bazı yöntemleri sağlar.

### **Create Zoom Frames**

Bir slayta yakınlaştırma çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Zoom çerçevelerini bağlamak istediğiniz yeni slaytlar oluşturun. 
3.	Oluşturulan slaytlara tanıtım metni ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referansları içeren) zoom çerçeveleri ekleyin.
5.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni slaytlar ekler
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # İkinci slayt için bir arka plan oluşturur
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # İkinci slayt için bir metin kutusu oluşturur
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Üçüncü slayt için bir arka plan oluşturur
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Üçüncü slayt için bir metin kutusu oluşturur
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame nesnelerini ekler
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Create Zoom Frames with Custom Images**
Aspose.Slides for PHP via Java kullanarak farklı bir slayt önizleme resmiyle bir zoom çerçevesi şu şekilde oluşturabilirsiniz:
1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Zoom çerçevesini bağlamak istediğiniz yeni bir slayt oluşturun. 
3.	Slayta tanıtım metni ve arka plan ekleyin.
4.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine ait Images koleksiyonuna bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
5.	İlk slayta (oluşturulan slayta referans içeren) zoom çerçeveleri ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # İkinci slayt için bir arka plan oluşturur
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # Üçüncü slayt için bir metin kutusu oluşturur
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Yakınlaştırma nesnesi için yeni bir resim oluşturur
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # ZoomFrame nesnesini ekler
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Format Zoom Frames**
Önceki bölümlerde basit zoom çerçevelerinin nasıl oluşturulacağını gösterdik. Daha karmaşık zoom çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir zoom çerçevesine uygulayabileceğiniz birkaç biçimlendirme seçeneği vardır. 

Bir slaytta bir zoom çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Zoom çerçevesini bağlamak istediğiniz yeni slaytlar oluşturun. 
3.	Oluşturulan slaytlara bazı tanıtım metinleri ve arka plan ekleyin.
4.	İlk slayta (oluşturulan slaytlara referansları içeren) zoom çerçeveleri ekleyin.
5.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine ait Images koleksiyonuna bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
6.	İlk zoom çerçevesi nesnesi için özel bir resim ayarlayın.
7.	İkinci zoom çerçevesi nesnesi için çizgi biçimini değiştirin.
8.	İkinci zoom çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
5.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni slaytlar ekler
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # İkinci slayt için bir arka plan oluşturur
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # İkinci slayt için bir metin kutusu oluşturur
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # Üçüncü slayt için bir arka plan oluşturur
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # Üçüncü slayt için bir metin kutusu oluşturur
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # ZoomFrame nesnelerini ekler
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # Yakınlaştırma nesnesi için yeni bir resim oluşturur
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # zoomFrame1 nesnesi için özel resim ayarlar
    $zoomFrame1->setImage($picture);
    # zoomFrame2 nesnesi için bir zoom çerçeve biçimi ayarlar
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # zoomFrame2 nesnesi için arka planı gösterme ayarı
    $zoomFrame2->setShowBackground(false);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Section Zoom**

Bölüm yakınlaştırması, sunumunuzdaki bir bölüme bağlantı sağlar. Bölüm yakınlaştırmalarını, özellikle vurgulamak istediğiniz bölümlere geri dönmek için kullanabilirsiniz. Veya sunumunuzun belirli bölümlerinin nasıl bağlandığını gösteren bir araç olarak da kullanabilirsiniz. 

![overview_image](seczoomsel.png)

Bölüm yakınlaştırma nesneleri için Aspose.Slides, [SectionZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sectionzoomframe/) sınıfını ve [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfı altında bazı yöntemleri sağlar.

### **Create Section Zoom Frames**

Bir slayta bölüm yakınlaştırma çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun. 
3.	Oluşturulan slayta bir tanıtım arka planı ekleyin.
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame nesnesi ekler
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Create Section Zoom Frames with Custom Images**

Aspose.Slides for PHP via Java kullanarak farklı bir slayt önizleme resmiyle bir bölüm yakınlaştırma çerçevesi şu şekilde oluşturabilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta bir tanıtım arka planı ekleyin.
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine ait Images koleksiyonuna bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
5.	İlk slayta (oluşturulan bölüme referans içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # Yakınlaştırma nesnesi için yeni bir resim oluşturur
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # SectionZoomFrame nesnesi ekler
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **Format Section Zoom Frames**

Daha karmaşık bölüm yakınlaştırma çerçeveleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir bölüm yakınlaştırma çerçevesine uygulayabileceğiniz birkaç biçimlendirme seçeneği vardır. 

Bir slaytta bir bölüm yakınlaştırma çerçevesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Yeni bir slayt oluşturun.
3.	Oluşturulan slayta bir tanıtım arka planı ekleyin.
4.	Zoom çerçevesini bağlamak istediğiniz yeni bir bölüm oluşturun. 
5.	İlk slayta (oluşturulan bölüme referansları içeren) bir bölüm yakınlaştırma çerçevesi ekleyin.
6.	Oluşturulan bölüm yakınlaştırma nesnesinin boyut ve konumunu değiştirin.
7.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine ait Images koleksiyonuna bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
8.	oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir resim ayarlayın.
9.	*Bağlı bölümden orijinal slayta dönüş* yeteneğini ayarlayın. 
10.	Bölüm yakınlaştırma çerçevesi nesnesinin görüntüsünden arka planı kaldırın.
11.	İkinci zoom çerçevesi nesnesi için çizgi biçimini değiştirin.
12.	Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # SectionZoomFrame nesnesi ekler
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # SectionZoomFrame biçimlendirmesi
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Summary Zoom**

Özet yakınlaştırması, tüm sunum parçalarının aynı anda gösterildiği bir açılış sayfası gibidir. Sunum yaparken, yakınlaştırmayı kullanarak sunumunuzdaki bir yerden diğerine istediğiniz sırayla geçiş yapabilirsiniz. Yaratıcı olabilir, ilerleyebilir ya da slayt gösterinizin bölümlerini tekrar ziyaret edebilirsiniz; bu, sunum akışını kesintiye uğratmaz.

![overview_image](sumzoomsel.png)

Özet yakınlaştırma nesneleri için Aspose.Slides, [SummaryZoomFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomsection/) ve [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomsectioncollection/) sınıflarını ve [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfı altında bazı yöntemleri sağlar.

### **Create a Summary Zoom**

Bir slayta özet yakınlaştırma çerçevesi eklemek için şu adımları izleyebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planına sahip yeni slaytlar ve oluşturulan slaytlar için yeni bölümler oluşturun.
3.	İlk slayta özet yakınlaştırma çerçevesi ekleyin.
4.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 2", $slide);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 3", $slide);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 4", $slide);
    # SummaryZoomFrame nesnesi ekler
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Add and Remove a Summary Zoom Section**

Bir özet yakınlaştırma çerçevesindeki tüm bölümler, [SummaryZoomSection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomsection/) nesneleriyle temsil edilir ve bu nesneler [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomsectioncollection/) nesnesinde depolanır. Bir özet yakınlaştırma bölümü nesnesini eklemek veya kaldırmak için [SummaryZoomSectionCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/summaryzoomsectioncollection/) sınıfını şu şekilde kullanabilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planına sahip yeni slaytlar ve oluşturulan slaytlar için yeni bölümler oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	Sunuma yeni bir slayt ve bölüm ekleyin.
5.	Oluşturulan bölümü özet yakınlaştırma çerçevesine ekleyin.
6.	Özet yakınlaştırma çerçevesinden ilk bölümü kaldırın.
7.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame nesnesi ekler
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # Summary Zoom'a bir bölüm ekler
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # Summary Zoom'dan bölümü kaldırır
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Format Summary Zoom Sections**

Daha karmaşık özet yakınlaştırma bölümü nesneleri oluşturmak için basit bir çerçevenin biçimlendirmesini değiştirmeniz gerekir. Bir özet yakınlaştırma bölüm nesnesine uygulayabileceğiniz birkaç biçimlendirme seçeneği vardır. 

Bir özet yakınlaştırma çerçevesindeki özet yakınlaştırma bölümü nesnesinin biçimlendirmesini şu şekilde kontrol edebilirsiniz:

1.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.	Kimlik arka planına sahip yeni slaytlar ve oluşturulan slaytlar için yeni bölümler oluşturun.
3.	İlk slayta bir özet yakınlaştırma çerçevesi ekleyin.
4.	`SummaryZoomSectionCollection` öğesinden ilk nesne için bir özet yakınlaştırma bölümü nesnesi alın.
7.	[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesine ait images koleksiyonuna bir resim ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne çerçeveyi doldurmak için kullanılacak.
8.	oluşturulan bölüm yakınlaştırma çerçevesi nesnesi için özel bir resim ayarlayın.
9.	*Bağlı bölümden orijinal slayta dönüş* yeteneğini ayarlayın. 
11.	İkinci zoom çerçevesi nesnesi için çizgi biçimini değiştirin.
12.	Geçiş süresini değiştirin.
13.	Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  $pres = new Presentation();
  try {
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 1", $slide);
    # Sunuma yeni bir slayt ekler
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # Sunuma yeni bir bölüm ekler
    $pres->getSections()->addSection("Section 2", $slide);
    # SummaryZoomFrame nesnesi ekler
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # İlk SummaryZoomSection nesnesini alır
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # SummaryZoomSection nesnesi için biçimlendirme
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # Sunumu kaydeder
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hedef gösterildikten sonra 'ebeveyn' slayta geri dönmeyi kontrol edebilir miyim?**

Evet. [Zoom frame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zoomframe/) veya [section](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sectionzoomframe/) nesnesinin `ReturnToParent` davranışı etkinleştirildiğinde, izleyicileri hedef içeriği ziyaret ettikten sonra orijinal slayta geri gönderir.

**Zoom geçişinin 'hızını' veya süresini ayarlayabilir miyim?**

Evet. Zoom, `TransitionDuration` ayarlamayı destekler; böylece atlama animasyonunun ne kadar süreceğini kontrol edebilirsiniz.

**Bir sunum kaç Zoom nesnesi içerebilir konusunda limitler var mı?**

Belirtilen bir API sınırı yoktur. Pratik limitler, sunumun genel karmaşıklığı ve izleyicinin performansına bağlıdır. Çok sayıda Zoom çerçevesi ekleyebilirsiniz, ancak dosya boyutu ve render süresini göz önünde bulundurun.