---
title: "Sunularda Görüntü Yönetimini PHP ile Optimize Etme"
linktitle: "Görüntüleri Yönet"
type: docs
weight: 10
url: /tr/php-java/image/
keywords:
  - görüntü ekle
  - resim ekle
  - görüntüyü değiştir
  - görüntü koleksiyonu
  - resim çerçevesi
  - bağlantılı görüntü
  - arka plan
  - PNG ekle
  - JPG ekle
  - SVG ekle
  - SVG'den şekillere
  - harici SVG kaynakları
  - PowerPoint
  - OpenDocument
  - sunum
  - PHP
  - Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunularında raster ve SVG görüntülerini eklemeyi, yeniden kullanmayı, bağlamayı, değiştirmeyi ve yönetmeyi öğrenin."
---
## **Giriş**

Aspose.Slides for PHP via Java, görüntülerle çalışmak için çeşitli yollar sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü sunuma kaydedebilir, bir resim çerçevesinde gösterebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale, görüntü kaynaklarına ve bunların bir sunu içinde nasıl kullanıldığına odaklanır. Kırpma, saydamlık, efektler, esnetme ve bireysel bir resim çerçevesine uygulanan diğer biçimlendirmeler için [Resim Çerçevesi](/slides/tr/php-java/picture-frame/) bölümüne bakın.

## **Görüntü Modelini Anlamak**

Aşağıdaki API kavramları yakından ilişkilidir ancak birbirinin yerine kullanılamaz:

- [Sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) sunumda kullanılan görüntü kaynaklarını saklar. Görüntü verisini eklemek ve bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kaynağı elde etmek için [ImageCollection::addImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) kullanın.
- Bir [resim çerçevesi](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) bir slayt, düzen veya ana taslak üzerinde bir görüntüyü gösteren bir şekildir. Bir slayta görüntü kaynağı yerleştirmek için [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) kullanın.
- Bir slayt arka planı, görüntüyü bir şekil olarak değil, slayt doldurmasının bir parçası olarak kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [PPImage::replaceImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) bir görüntü kaynağını değiştirir. Bu kaynağı kullanan birden çok sunum öğesi varsa, hepsi değişikliği alır.
- Bir SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Tipik bir iş akışı şu şekildedir: görüntü verisini görüntü koleksiyonuna ekleyin, bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesinde veya doldurmalarda kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntü eklemek için dosyayı yükleyin, görüntü koleksiyonuna ekleyin ve döndürülen `PPImage`i kullanan bir resim çerçevesi oluşturun.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu şekilde eklenen görüntü sunuya gömülür, bu yüzden ortaya çıkan dosya orijinal görüntü dosyasının mevcut olmasına bağlı değildir.

### **Web’den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden erişilebiliyorsa, baytlarını indirin, sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uzun çalışan uygulamalarda, gereksiz ağ altyapısı oluşturmak yerine uygulamaya uygun bir HTTP istemcisi veya bağlantı yönetim stratejisi yeniden kullanın. Kaynak güvenilir değilse uzak URL'leri, yanıt boyutlarını ve içerik türlerini de doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerekiyorsa, görüntüyü sunuma bir kez ekleyin ve ek resim çerçevelerini oluştururken döndürülen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/)i yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanım yerleri arasındaki ilişkiyi açık hâle getirir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler (örneğin şirket logosu) için, her slayda eşdeğer bir şekil eklemek yerine resmi bir [slayt ana taslağı](/slides/tr/php-java/slide-master/) veya düzen üzerine yerleştirmenizi öneririz.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Bir arka plan görüntüsü slayt doldurmasına atanır; bir resim çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi manipüle edilmemesi gerektiğinde işe yarar.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ana taslak ve düzen arka planları dahil ek arka plan seçenekleri için [Sunum Arka Planı](/slides/tr/php-java/presentation-background/) bölümüne bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya boyutu açısından farklı ödünleşimleri vardır:

- **Gömülü görüntü:** görüntü verisi sununun içinde saklanır. Sunu kendine yeterli olur, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunu harici bir görüntüye yol veya URL saklar. Bu, sunu boyutunu küçültebilir, ancak harici kaynak sunu açıldığında veya render edildiğinde erişilebilir olmalıdır.

Harici yol veya URL'yi [Picture::setLinkPathLong](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/) aracılığıyla atayarak bir bağlantılı resim oluşturulabilir; bu yöntem görüntü verisini gömmeyi içermez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı harici kaynağa güvenilir bir şekilde erişebiliyorsa kullanın. Çevrimdışı çalışması veya sistemler arasında taşınması gereken sunular için genellikle gömülü görüntüler daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG bir vektör formatıdır; bu nedenle ikonlar, diyagramlar ve ayrıntı kaybı yaşamadan ölçeklenmesi gereken diğer grafikler için yararlıdır. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) oluşturun, bunu görüntü koleksiyonuna ekleyin ve oluşan görüntü kaynağını bir resim çerçevesine yerleştirin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Harici Kaynaklı SVG Dosyaları**

Bir SVG harici görüntüler, stil dosyaları veya yazı tiplerine başvurabilir. Bu durumlar için [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) bir [ExternalResourceResolver](https://reference.aspose.com/slides/tr/php-java/aspose.slides/externalresourceresolver/) ve temel bir URI kabul eden yapıcılar sağlar. Çözücü, bir göreli URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynağın akışını döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken harici kaynakları kullanılabilir kılar, ancak SVG'yi kendine yeterli bir belgeye dönüştürmez. SVG'nin taşınabilir kalması gerekiyorsa, örneğin bağlantılı görüntüler için `data:` URI'larını kullanarak gerekli kaynakları SVG'ye gömün.

Güvenilmeyen kaynaklardan gelen SVG dosyaları için, çözücünün erişebileceği şema, dosya konumu ve barındırıcıları kısıtlayın. Ağ çözücüleri ayrıca zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi düzenlenebilir slayt şekilleri grubuna dönüştürebilir; bu, ilgili PowerPoint komutuna benzer.

![PowerPoint Açılır Menüsü](img_01_01.png)

Dönüştürmeyi gerçekleştirmek için bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) kabul eden [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addgroupshape/) aşırı yüklemesini kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

SVG‑yi şekillere dönüştürme, bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde kullanılmalıdır. SVG yalnızca görüntülenmesi gerekiyorsa, bir görüntü olarak tutmak daha basittir ve birçok ayrı şekil oluşturulmasını önler.

## **Mevcut Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [PPImage::replaceImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kullanın. Bu, özellikle logolar gibi paylaşılan grafikler için faydalıdır.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Birden çok resim çerçevesi, arka plan, ana taslak veya düzen aynı görüntü kaynağını kullanıyorsa, bu kaynağın değiştirilmesi tüm bu kullanım yerlerini günceller. Yalnızca bir resim çerçevesinin değişmesi gerekiyorsa, paylaşılan kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

`PPImage::replaceImage` ayrıca bir bayt dizisi veya başka bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kabul eden aşırı yüklemeler sunar.

## **Pratik Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Etme**

Büyük raster görüntüler bir sunuyu gereksiz yere büyük yapabilir. Amaçlanan gösterim boyutuna uygun boyutlarda kaynak görüntüler kullanın, mümkün olduğunca paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı yüksek çözünürlüklü grafiğin tekrarlı gömülmesinden kaçının.

Resim çerçevelerine zaten yerleştirilmiş raster resimler için [PictureFillFormat::compressImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, resim‑çerçeve işleme olup görüntü‑koleksiyonu yönetimi değildir; ilgili biçimlendirme işlemleri için [Resim Çerçevesi](/slides/tr/php-java/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasında Seçim Yapma**

Gömme, tüm gerekli görüntü verileri dosyayla birlikte taşındığı için sunuyu taşınabilir kılar. Bağlantı dosya boyutunu küçültebilir, ancak harici bir bağımlılık getirir. Bağlantıları yalnızca bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Markayı Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya süsleme grafikleri için tek bir görüntü kaynağı kullanın ve yeniden kullanın. Grafik sunu tasarımına aitse (slayt içeriği değil) bir ana taslak veya düzen üzerine yerleştirerek uygun slaytlar tarafından devralınmasını sağlayın.

### **SVG Kaynaklarını Taşınabilir Tutma**

Kendine yeterli bir SVG, dış dosyalara veya ağ kaynaklarına bağımlı bir SVG'den daha kolay hareket ettirilebilir ve tutarlı şekilde render edilir. Mümkün olduğunda SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi şekillere dönüştürme yalnızca bireysel vektör öğelerinin düzenlenmesi gerektiğinde yapılmalıdır.

### **Modern Çok Platformlu Görüntü API'sını Kullanma**

Yeni PHP via Java kodu için, eski `java.awt.image.BufferedImage` tabanlı herkese açık API yerine Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/php-java/aspose.slides/images/) API'larını kullanın. Göç rehberi için [Modern API](/slides/tr/php-java/modern-api/) bölümüne bakın.

WMF ve EMF özel dikkate ihtiyaç duyar. Bu formatlar bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) aracılığıyla geçirildiğinde, [ImageCollection::addImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) metafili bir raster PNG temsiline dönüştürür. Metafili verisini korumak önemliyse, akış tabanlı bir [ImageCollection::addImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) aşırı yüklemesi kullanın. Elektronik tablolar veya diğer ürünlerden EMF içeriği üretmek ayrı bir bütünleşme iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu yeniden kullanılabilir görüntü kaynaklarını saklar. Resim çerçevesi ise bu kaynaklardan birini gösteren ve kırpma, efekt gibi resim‑özel biçimlendirmeler sağlayan bir slayt şeklidir.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, o kaynağı [PPImage::replaceImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) ile değiştirin. Sunu geneli markalama için logo bir ana taslak veya düzen üzerine yerleştirildiğinde yinelemeli slayt içeriği azaltılabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı bir resim, dış dosya veya URL'ye bağlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü kullanılamaz hâle gelir. Sununun kendine yeterli olması gerekiyorsa görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addgroupshape/) ile dönüştürün; ortaya çıkan grup tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunuların daha küçük kalmasını nasıl sağlayabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, tekrarlanan markayı ana taslak veya düzenlerde tutun ve harici bir bağımlılık kabul edilebilir olduğunda yalnızca bağlantılı görüntüleri kullanın.