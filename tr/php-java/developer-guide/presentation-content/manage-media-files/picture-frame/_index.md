---
title: PHP ile Sunumlarda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/php-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görsel ekle
- görsel oluştur
- görsel çıkar
- raster görsel
- vektör görsel
- görsel kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görsel efekti
- en boy oranı
- görsel şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. Çalışma akışınızı basitleştirin ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Resim çerçevesi, bir görüntüyü içeren bir şekildir—çerçeve içinde bir resim gibidir.  

Bir slayta bir resim çerçevesi aracılığıyla görüntü ekleyebilirsiniz. Böylece, resmi resim çerçevesini biçimlendirerek biçimlendirebilirsiniz.

{{% alert  title="Tip" color="primary" %}} 
Aspose ücretsiz dönüştürücüler sağlar—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—ki bunlar, kişilerin görüntülerden hızlıca sunum oluşturmasını sağlar. 
{{% /alert %}} 

## **Resim Çerçevesi Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slaytın şekil nesnesi tarafından sunulan `addPictureFrame` yöntemini kullanarak görüntünün genişliği ve yüksekliği temelinde bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) oluşturun.  
6. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Değiştirilen sunumu bir PPTX dosyası olarak yazın.  

Bu PHP kodu, bir resim çerçevesi oluşturmayı gösterir:

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekler
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Resmin eşdeğer yüksekliği ve genişliği ile bir picture frame ekler
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
Resim çerçeveleri, görüntülerden hızlı bir şekilde sunum slaytları oluşturmanıza olanak tanır. Resim çerçevesini Aspose.Slides kaydetme seçenekleriyle birleştirerek giriş/çıkış işlemlerini yönlendirebilir ve görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara göz atabilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/php-java/conversion/image-to-jpg/) dönüştürme; [JPG to image](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-image/) dönüştürme; [JPG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-png/) dönüştürme; [PNG to JPG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-jpg/) dönüştürme; [PNG to SVG](https://products.aspose.com/slides/tr/php-java/conversion/png-to-svg/) dönüştürme; [SVG to PNG](https://products.aspose.com/slides/tr/php-java/conversion/svg-to-png/) dönüştürme. 
{{% /alert %}}

## **İlgili Ölçekli Resim Çerçevesi Oluşturma**

Bir görüntünün ilgili ölçeklemesini değiştirerek daha karmaşık bir resim çerçevesi oluşturabilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Sunum görüntü koleksiyonuna bir görüntü ekleyin.  
4. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
5. Resim çerçevesindeki görüntünün ilgili genişliğini ve yüksekliğini belirtin.  
6. Değiştirilen sunumu bir PPTX dosyası olarak yazın.  

Bu PHP kodu, ilgili ölçekli bir resim çerçevesi oluşturmayı gösterir:

```php
  # PPTX'i temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekle
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Resmin eşdeğer yükseklik ve genişliği ile Picture Frame ekle
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Göreceli ölçek genişliği ve yüksekliğini ayarla
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

## **Resim Çerçevelerinden Raster Görüntüleri Ayıklama**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) nesnelerinden raster görüntüleri ayıklayabilir ve PNG, JPG ve diğer biçimlerde kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü ayıklayıp PNG biçiminde kaydetmeyi gösterir.

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

## **Resim Çerçevelerinden SVG Görüntüleri Ayıklama**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) şekilleri içinde SVG grafikler içerdiğinde, Aspose.Slides for PHP via Java, orijinal vektör görüntülerini tam doğrulukla almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) tanımlayabilir, temel [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) SVG içeriği tutuyor mu kontrol edebilir ve ardından bu görüntüyü diske ya da akıma yerel SVG biçiminde kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü ayıklamayı gösterir:

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

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu PHP kodu işlemi gösterir:

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

## **Bir Görüntünün Parlaklık ve Kontrastını Alma**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza izin verir. [Luminance](https://reference.aspose.com/slides/tr/php-java/aspose.slides/luminance/) sınıfı bu görüntü dönüşüm etkisini temsil eder.

Bu PHP kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını almayı gösterir:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulanabilen birçok biçimlendirme seçeneği sunar. Bu seçenekleri kullanarak bir resim çerçevesini belirli gereksinimlere uyduracak şekilde değiştirebilirsiniz.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Sunum nesnesine bağlı [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) içine bir görüntü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun; bu nesne şekli doldurmak için kullanılacaktır.  
4. Görüntünün genişliğini ve yüksekliğini belirtin.  
5. Referans alınan slaytın [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) yöntemiyle bir `PictureFrame` oluşturun.  
6. Resim çerçevesini (içindeki resmi) slayta ekleyin.  
7. Resim çerçevesinin kenar rengini ayarlayın.  
8. Resim çerçevesinin kenar kalınlığını ayarlayın.  
9. Resim çerçevesini pozitif ya da negatif bir değer vererek döndürün.  
   * Pozitif değer görüntüyü saat yönünde döndürür.  
   * Negatif değer görüntüyü saat yönünün tersine döndürür.  
10. Resim çerçevesini (içindeki resmi) slayta tekrar ekleyin.  
11. Değiştirilen sunumu bir PPTX dosyası olarak yazın.  

Bu PHP kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```php
  # PPTX'i temsil eden Presentation sınıfını örnekler
  $pres = new Presentation();
  try {
    # İlk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Image sınıfını örnekler
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Resmin eşdeğer yükseklik ve genişliği ile Picture Frame ekler
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
Aspose yakın zamanda ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntüleri birleştirmeniz, fotoğraflardan ızgara oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz. 
{{% /alert %}}

## **Bağlantı Olarak Görüntü Ekleme**

Sunum boyutlarını küçültmek için dosyaları doğrudan yerleştirmek yerine, görüntüleri (veya videoları) bağlantı yoluyla ekleyebilirsiniz. Bu PHP kodu, bir yer tutucu içine görüntü ve video eklemeyi gösterir:

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

## **Görüntü Kırpma**

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

## **Bir Resim Çerçevesinin Kırpılmış Alanlarını Silme**

Bir çerçeve içinde bulunan görüntünün kırpılmış alanlarını silmek istiyorsanız, [deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metodunu kullanabilirsiniz. Bu metod, kırpılmış resmi ya da kırpma gereksizse orijinal resmi döndürür.

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

{{% alert title="NOTE" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metodu, kırpılmış görüntüyü sunum görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu ayar sunum boyutunu azaltabilir. Aksi takdirde, sonuç sunumdaki görüntü sayısı artar.  

Bu metod, kırpma işlemi sırasında WMF/EMF metafilelerini raster PNG görüntüsüne dönüştürür. 
{{% /alert %}}

## **Görüntü Sıkıştırma**

Bir sunumdaki resmi, [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) metoduyle sıkıştırabilirsiniz. Bu metod, şekil boyutu ve belirtilen çözünürlüğe göre görüntünün boyutunu azaltır; ayrıca kırpılmış alanları silme seçeneği sunar.  

PowerPoint'in **Picture Format → Compress Pictures → Resolution** özelliğine benzer şekilde resmin boyutu ve çözünürlüğü ayarlanır.  

Aşağıdaki PHP örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Görüntüyü 150 DPI (Web çözünürlüğü) hedef çözünürlük ile sıkıştır ve kırpılmış alanları kaldır.
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

    # Görüntüyü 150 DPI (web çözünürlüğü) ile sıkıştır ve kırpılmış alanları kaldır.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metod, şeklin boyutu ve sağlanan DPI değerine göre görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler de dosya boyutunu iyileştirmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) ya da SVG ise sıkıştırma uygulanmaz. JPEG kalitesi, çözünürlüğe göre aynı PowerPoint davranışıyla korunur veya hafifçe düşürülür. 
{{% /alert %}}

## **En Boy Oranını Kilitleme**

Bir şeklin içindeki görüntünün boyutlarını değiştirdiğinizde bile en boy oranının korunmasını istiyorsanız, *Lock Aspect Ratio* ayarını ayarlamak için [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) metodunu kullanabilirsiniz.

Bu PHP kodu, bir şeklin en boy oranını nasıl kilitleyeceğinizi gösterir:

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
    # Yeniden boyutlandırmada en boy oranını koruması için şekli ayarla
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en boy oranını korur, içinde bulunan görüntüyü değil. 
{{% /alert %}}

## **StretchOff Özelliğini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) sınıfındaki [setStretchOffsetLeft](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) ve [setStretchOffsetBottom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) yöntemlerini kullanarak bir doldurma dikdörtgeni belirtebilirsiniz.  

Bir görüntü için germe belirtildiğinde, bir kaynak dikdörtgen, belirtilen doldurma dikdörtgenine sığacak şekilde ölçeklendirilir. Doldurma dikdörtgeninin her kenarı, şeklin sınır kutusunun karşılık gelen kenarından yüzde olarak bir offset ile tanımlanır. Pozitif yüzde bir içe çekme, negatif yüzde bir dışa çıkma belirtir.  

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksine göre bir referans alın.  
3. Bir `AutoShape` dikdörtgeni ekleyin.  
4. Bir görüntü oluşturun.  
5. Şeklin doldurma türünü ayarlayın.  
6. Şeklin resim doldurma kipini ayarlayın.  
7. Şekli dolduracak bir görüntü ekleyin.  
8. Görüntünün offsetlerini, şeklin sınır kutusunun karşılık gelen kenarına göre belirtin.  
9. Değiştirilen sunumu bir PPTX dosyası olarak yazın.  

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
    # Şekli dolduracak resmi ayarlar
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarına göre offsetlerini belirtir
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # PPTX dosyasını diske yazar
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Resim Çerçevesi için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) üzerine atanan görüntü nesnesi aracılığıyla raster (PNG, JPEG, BMP, GIF vb.) ve vektör (ör. SVG) görüntüleri destekler. Desteklenen formatların listesi genel olarak slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.  

**Büyük sayıda büyük görüntü eklemek PPTX boyutunu ve performansı nasıl etkiler?**

Büyük görüntülerin yerleştirilmesi dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak, sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağ olarak ekleme imkanı sunar.  

**Bir görüntü nesnesinin kazara taşınmasını/yeniden boyutlandırılmasını nasıl kilitlebilirim?**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/getpictureframelock/) kullanabilirsiniz (ör. taşıma veya yeniden boyutlandırmayı devre dışı bırakma). Kilitleme mekanizması, çeşitli şekil türleri için, özellikle [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) için desteklenir.  

**SVG vektör bütünlüğü, bir sunumu PDF/görüntülere dışa aktarırken korunur mu?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) içindeki SVG'yi orijinal vektör olarak ayıklamayı sağlar. [PDF'ye dışa aktarırken](/slides/tr/php-java/convert-powerpoint-to-pdf/) veya [raster formatlara](/slides/tr/php-java/convert-powerpoint-to-png/) yapılan dışa aktarımda, ayarlarla rasterleştirilebilir; ancak SVG'nin vektör olarak saklandığı, ayıklama davranışıyla doğrulanır.