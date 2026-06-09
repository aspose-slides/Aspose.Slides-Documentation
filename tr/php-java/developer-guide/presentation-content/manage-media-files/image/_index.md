---
title: Sunumlarda Görüntü Yönetimini PHP ile Optimize Edin
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/php-java/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- EMF
- SVG
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument'te görüntü yönetimini Aspose.Slides for PHP via Java ile hızlandırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha ilgi çekici ve etkileyici hâle getirir. Microsoft PowerPoint'te bir dosyadan, internetten veya başka konumlardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunumlarınızdaki slaytlara farklı prosedürlerle resim eklemenizi sağlar.

{{% alert  title="Tip" color="primary" %}} 

Aspose, insanlara görüntülerden hızlıca sunumlar oluşturmayı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek ve benzeri standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/php-java/picture-frame/) sayfasına bakın.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bir görüntüyü bir biçimden diğerine dönüştürmek için görüntüler ve PowerPoint sunumlarıyla ilgili giriş/çıkış işlemlerini manipüle edebilirsiniz. Bu sayfalara bakın: dönüştür [görüntüyü JPG'ye](https://products.aspose.com/slides/tr/php-java/conversion/image-to-jpg/); dönüştür [JPG'yi görüntüye](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-image/); dönüştür [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/php-java/conversion/jpg-to-png/), dönüştür [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/php-java/conversion/png-to-jpg/); dönüştür [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/php-java/conversion/png-to-svg/), dönüştür [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, bu popüler formatlardaki görüntülerle (JPEG, PNG, GIF ve diğerleri) işlemleri destekler. 

## **Yerel Olarak Saklanan Görselleri Slaytlara Ekle**

Bilgisayarınızdaki bir veya birden fazla görüntüyü bir sunum slaytına ekleyebilirsiniz. Bu örnek kod, bir resmi slayta nasıl ekleyeceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Web'den Görselleri Slaytlara Ekle**

Bir slayta eklemek istediğiniz görüntü bilgisayarınızda bulunmuyorsa, görüntüyü doğrudan web'ten ekleyebilirsiniz. 

Bu örnek kod, web'ten bir resmi slayta nasıl ekleyeceğinizi gösterir :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Görselleri Slayt Ana Şablonlarına Ekle**

Bir slayt ana şablonu, altındaki tüm slaytların (tema, düzen vb.) bilgilerini depolayan ve kontrol eden üst slayttır. Bu nedenle, bir slayt ana şablonuna bir resim eklediğinizde, o resim o ana şablon altındaki her slaytta görünür. 

Bu Java örnek kodu, bir resmi slayt ana şablonuna nasıl ekleyeceğinizi gösterir:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Görselleri Slayt Arka Planı Olarak Ekle**

Belirli bir slayt veya birden fazla slayt için resmi arka plan olarak kullanmaya karar verebilirsiniz. Bu durumda, [Bir Resmi Slayt Arka Planı Olarak Ayarla](/slides/tr/php-java/presentation-background/#set-an-image-as-a-slide-background) nasıl yapılır bakmanız gerekir.

## **Sunumlara SVG Ekle**

Sunuma herhangi bir görüntüyü eklemek veya eklemek için, [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfına ait olan [addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) yöntemini kullanabilirsiniz.

SVG görüntüsüne dayalı bir görüntü nesnesi oluşturmak için bunu şu şekilde yapabilirsiniz:

1. SvgImage nesnesi oluşturun ve ImageShapeCollection'a ekleyin
2. ISvgImage'den PPImage nesnesi oluşturun
3. PPImage sınıfını kullanarak PictureFrame nesnesi oluşturun

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görüntüsünü sunuma nasıl ekleyeceğinizi gösterir:
```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVG'yi Şekil Kümesine Dönüştür**

Aspose.Slides'in SVG'yi şekil kümesine dönüştürme işlemi, SVG görüntüleriyle çalışmak için kullanılan PowerPoint işlevselliğine benzer:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) nesnesini ilk argüman olarak alan [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) sınıfının [addGroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addgroupshape/) yönteminin aşırı yüklemelerinden biri tarafından sağlanır.

Bu örnek kod, bir SVG dosyasını şekil kümesine dönüştürmek için açıklanan yöntemi nasıl kullanacağınızı gösterir:

```php
  # Yeni sunum oluştur
  $presentation = new Presentation();
  try {
    # SVG dosya içeriğini oku
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImage nesnesi oluştur
    $svgImage = new SvgImage($svgContent);
    # Slayt boyutunu al
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG görüntüsünü slayt boyutuna ölçeklendirerek şekil grubuna dönüştür
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Sunumu PPTX formatında kaydet
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Görselleri EMF Olarak Slaytlara Ekle**

Aspose.Slides for PHP via Java, Excel sayfalarından EMF görüntüleri oluşturmanıza ve bu görüntüleri Aspose.Cells ile slaytlara EMF olarak eklemenize olanak tanır.  

Bu örnek kod, açıklanan görevi nasıl yerine getireceğinizi gösterir:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Çalışma kitabını akışa kaydet
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, bir sunumun görsel koleksiyonunda (slayt şekilleri tarafından kullanılanlar dahil) depolanan görselleri değiştirmenize olanak tanır. Bu bölüm, koleksiyondaki görselleri güncellemenin birkaç yaklaşımını gösterir. API, ham bayt verileri, bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görsel kullanarak görseli değiştirmek için doğrudan yöntemler sağlar.

Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfını kullanarak görüntüleri içeren sunum dosyasını yükleyin.
2. Yeni bir görüntüyü dosyadan bir bayt dizisine yükleyin.
3. Hedef görseli, bayt dizisini kullanarak yeni görsel ile değiştirin.
4. İkinci yaklaşımda, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesne ile değiştirin.
5. Üçüncü yaklaşımda, hedef görseli sunumun görsel koleksiyonunda zaten mevcut olan bir görsel ile değiştirin.
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
$presentation = new Presentation("sample.pptx");
try {
    // İlk yol.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // İkinci yol.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Üçüncü yol.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Sunumu bir dosyaya kaydet.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose ÜCRETSİZ [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü kullanarak metinleri kolayca canlandırabilir, metinlerden GIF oluşturabilir vb. 

{{% /alert %}}

## **SSS**

**Ekleme sonrası orijinal görüntü çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slaytta [picture](/slides/tr/php-java/picture-frame/) nasıl ölçeklendirildiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu bir anda değiştirmek için en iyi yöntem nedir?**

Logoyu ana slayt veya bir yerleşime yerleştirin ve sunumun görsel koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilirsiniz; böylece bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slayt için aynı anda arka plan olarak nasıl ayarlayabilirim?**

[Görseli arka plan olarak ata](/slides/tr/php-java/presentation-background/) ana slaytta veya ilgili yerleşimde—bu ana/slayt düzenini kullanan tüm slaytlar arka planı miras alır.

**Birçok resim nedeniyle sunumun boyutu "şişmesi" nasıl önlenir?**

Tek bir görüntü kaynağını tekrar kullanın, çoğaltmalar yerine, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafikleri gerektiğinde ana slaytta tutun.