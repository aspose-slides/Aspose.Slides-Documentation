---
title: PHP ile Sunularda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/php-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görüntü ekle
- görüntü oluştur
- görüntü çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görüntü etkisi
- en-boy oranı
- görüntü şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Bir resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içindeki bir resim gibidir.  

Bir resmi slayta bir resim çerçevesi aracılığıyla ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 

Aspose ücretsiz dönüştürücüler sağlar—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—ki bu, kişilerin görüntülerden hızlı bir şekilde sunumlar oluşturmasına olanak tanır. 

{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks üzerinden alın.  
3. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayda bağlı şekil nesnesi tarafından sunulan `addPictureFrame` yöntemiyle, görüntünün genişliği ve yüksekliğine dayalı bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) oluşturun.  
6. Resim çerçevesini (görseli içeren) slayta ekleyin.  
7. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu PHP kodu, bir resim çerçevesi oluşturmayı gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekler
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Görüntünün aynı yüksekliği ve genişliğiyle bir resim çerçevesi ekler
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PPTX dosyasını diske yazar
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Resim çerçeveleri, görüntülere dayalı sunum slaytlarını hızlı bir şekilde oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir formattan diğerine dönüştürmek için giriş/çıkış işlemlerini yönetebilirsiniz. Aşağıdaki sayfalara göz atmak isteyebilirsiniz: [görüntüyü JPG'ye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-image/); [JPG'yi PNG'ye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-png/); [PNG'yi JPG'ye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/png-to-jpg/); [PNG'yi SVG'ye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/png-to-svg/); [SVG'yi PNG'ye dönüştürme](https://products.aspose.com/slides/tr/php-java/conversion/svg-to-png/).  

{{% /alert %}}

## **Göreceli Ölçekli Resim Çerçevesi Oluşturma**

Görüntünün göreceli ölçeklendirmesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks üzerinden alın.  
3. Sunum görüntü koleksiyonuna bir görüntü ekleyin.  
4. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
5. Resim çerçevesindeki görüntünün göreceli genişliğini ve yüksekliğini belirtin.  
6. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu PHP kodu, göreceli ölçekli bir resim çerçevesi oluşturmayı gösterir:

```php
  # PPTX'i temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekle
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Resmin eşdeğer yüksekliği ve genişliğiyle Resim Çerçevesi ekle
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Göreceli ölçek genişliği ve yüksekliğini ayarlama
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # PPTX dosyasını diske yaz
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) nesnelerinden raster görüntüleri çıkarabilir ve PNG, JPG ve diğer formatlarda kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi göstermektedir.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) şekilleri içinde SVG grafikler içerdiğinde, Aspose.Slides for PHP via Java, orijinal vektör görüntülerini tam sadakatle almanıza olanak tanır. Slaydın şekil koleksiyonunu gezerek her bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) nesnesini tanımlayabilir, alttaki [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) SVG içeriği tutuyor mu kontrol edebilir ve ardından görüntüyü yerel SVG formatında diskete ya da akışa kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı göstermektedir:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Bir Görüntünün Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza izin verir. Bu PHP kodu işlemi gösterir:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilecek birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak, bir resim çerçevesini belirli gereksinimlere göre değiştirebilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks üzerinden alın.  
3. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slayda bağlı [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) yöntemiyle, görüntünün genişliği ve yüksekliğine dayalı bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (görseli içeren) slayta ekleyin.  
7. Resim çerçevesinin çizgi rengini ayarlayın.  
8. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
9. Pozitif ya da negatif bir değer vererek resim çerçevesini döndürün.  
   * Pozitif değer, görüntüyü saat yönünde döndürür.  
   * Negatif değer, görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (görseli içeren) slayta tekrar ekleyin.  
11. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu PHP kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```php
  # PPTX'i temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekler
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Görüntünün aynı yüksekliği ve genişliğiyle Resim Çerçevesi ekler
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # PictureFrameEx'e bazı biçimlendirmeler uygular
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # PPTX dosyasını diske yazar
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmek, fotoğraflardan ızgara oluşturmak istediğinizde bu hizmeti kullanabilirsiniz. 

{{% /alert %}}

## **Bir Görüntüyü Bağlantı Olarak Ekleme**

Sunum dosya boyutlarını büyük tutmamak için, görüntüleri (veya videoları) doğrudan dosya içine gömmek yerine bağlantı yoluyla ekleyebilirsiniz. Bu PHP kodu, bir yer tutucu içerisine bir görüntü ve bir video nasıl eklenir gösterir:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Görüntüleri Kırpma**

Bu PHP kodu, bir slayd üzerindeki mevcut bir görüntüyü nasıl kırpacağınızı gösterir:

```php
  $pres = new Presentation();
  # Yeni görüntü nesnesi oluşturur
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Bir slayta PictureFrame ekler
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Görüntüyü kırpar (yüzde değerleri)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Sonucu kaydeder
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Resmin Kırpılmış Alanlarını Silme**

Bir çerçevede bulunan görüntünün kırpılmış alanlarını silmek isterseniz, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) yöntemini kullanabilirsiniz. Bu yöntem, kırpılmış görüntüyü döndürür; kırpma gerekmezse orijinal görüntüyü döndürür.  

Bu PHP kodu işlemi gösterir:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # İlk slayttan PictureFrame'i alır
    $picFrame = $slide->getShapes()->get_Item(0);
    # PictureFrame görüntüsünün kırpılmış alanlarını siler ve kırpılmış görüntüyü döndürür
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Sonucu kaydeder
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOT" color="warning" %}} 

[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu ayar sunum boyutunu azaltabilir; aksi takdirde sonuçtaki sunumdaki görüntü sayısı artar.  

Bu yöntem, kırpma işlemi sırasında WMF/EMF metafile'larını raster PNG görüntüsüne dönüştürür.  

{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) yöntemiyle sıkıştırabilirsiniz. Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre görüntünün boyutunu küçülterek, istenirse kırpılmış bölgeleri silme seçeneği de sunar.  

PowerPoint'in **Resim Biçimi -> Resimleri Sıkıştır -> Çözünürlük** özelliğiyle aynı şekilde, resmin boyutunu ve çözünürlüğünü ayarlar.  

Aşağıdaki PHP örnekleri, hedef çözünürlük belirterek ve isteğe bağlı olarak kırpılmış alanları silerek bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Görüntüyü hedef çözünürlük 150 DPI (Web çözünürlüğü) ile sıkıştır ve kırpılmış alanları kaldır.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Sıkıştırmanın sonucunu kontrol et.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Veya doğrudan özel bir DPI değeri kullanarak:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Görüntüyü 150 DPI (web çözünürlüğü) ye sıkıştır, kırpılmış alanları kaldır.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOT" color="warning" %}} 

Yöntem, şeklin boyutuna ve verilen DPI'ye göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler aynı zamanda dosya boyutunu optimize etmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. JPEG kalitesi ise çözünürlüğe bağlı olarak korunur ya da hafifçe düşer; bu davranış PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesiyle benzerdir.  

{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir şeklin içinde görüntü bulundururken, görüntünün boyutlarını değiştirdiğinizde bile şeklin en-boy oranını korumasını istiyorsanız, *Lock Aspect Ratio* ayarını yapılandırmak için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) yöntemini kullanabilirsiniz.  

Bu PHP kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # yeniden boyutlandiginda sekilin en-boy oranini korumasini ayarla
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOT" color="warning" %}} 

Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur; içinde bulunan görüntünün en‑boy oranını korumaz.  

{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) sınıfının [setStretchOffsetLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) ve [setStretchOffsetBottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) yöntemlerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.  

Bir görüntü için germe belirtildiğinde, bir kaynak dikdörtgen belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak alınan bir ofsetle tanımlanır. Pozitif yüzde bir içeri (inset) tanımlarken, negatif yüzde bir dışarı (outset) tanımlar.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks üzerinden alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma türünü ayarlayın.  
6. Şeklin resim doldurma kipini ayarlayın.  
7. Şekli dolduracak görüntüyü ekleyin.  
8. Görüntünün ofsetlerini, şeklin sınırlayıcı kutusunun ilgili kenarına göre belirtin.  
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.  

Bu PHP kodu, StretchOff özelliğinin kullanıldığı bir süreci gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $slide = $pres->getSlides()->get_Item(0);
    # ImageEx sınıfını örnekler
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Rectangle olarak ayarlanmış bir AutoShape ekler
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Şeklin doldurma tipini ayarlar
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Şeklin resim doldurma kipini ayarlar
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Şekli dolduracak görüntüyü ayarlar
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Şeklin sınırlayıcı kutusunun ilgili kenarından görüntü ofsetlerini belirtir
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX dosyasını diske yazar
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**  

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) nesnesine atanan görüntü nesnesi aracılığıyla raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) destekler. Desteklenen formatların listesi, slayt ve görüntü dönüştürme motorunun yetenekleriyle genellikle örtüşür.  

**Yüzlerce büyük görüntü eklemek PPTX boyutu ve performansını nasıl etkiler?**  

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak dosya boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için bağlantı yoluyla görüntü ekleme yeteneği sunar.  

**Bir görüntü nesnesinin kazara taşınmasını/yeniden boyutlandırılmasını nasıl kilitleyebilirim?**  

[shape locks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/getpictureframelock/) özelliğini bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) için (örneğin, hareketi veya yeniden boyutlandırmayı devre dışı bırakma) kullanın. Kilitleme mekanizması, [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) dahil çeşitli şekil türleri için desteklenir.  

**SVG vektör doğruluğu, bir sunumu PDF/görüntülere dışa aktarırken korunur mu?**  

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) içinden SVG'yi orijinal vektör olarak çıkarmaya olanak tanır. [PDF'ye dışa aktarma](/slides/tr/php-java/convert-powerpoint-to-pdf/) veya [raster formatlarına](/slides/tr/php-java/convert-powerpoint-to-png/) sırasında, dışa aktarma ayarlarına bağlı olarak sonuç rasterleştirilebilir; ancak SVG'nin vektör olarak saklandığı doğrulanır.