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
- gömülü görüntü
- bağlantılı görüntü
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreceli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir slayt şekli olarak görüntüyü gösterir. Aspose.Slides içinde, görüntü kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) gömülü görüntü kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) aracılığıyla sahiplenir, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ise görüntünün konumunu, boyutunu, kenar biçimlendirmesini, döndürmesini, kırpmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarları denetler.

Bu ayrım, aynı görüntünün birden fazla kez gösterilmesi gerektiğinde faydalıdır. Görüntüyü sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu görüntü kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntüyü sunuma byte olarak kaydetmek yerine bağlanmış (linked) görüntülere de işaret edebilirler. Bu seçim, taşınabilirliği, dosya boyutunu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme ya da optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek yararlıdır.

## **Gömülü Bir Görüntüyü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verilerini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) metodunu kullanın. Görüntü, sunum paketinin bir parçası haline gelir; böylece sunum başka bir bilgisayara taşındığında bile kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün doğal boyutlarında bir çerçeve oluşturur ve kenar biçimlendirmesi ile döndürme uygular:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resim çerçevesi görüntülenen geometriden sorumludur; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağındaki orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra görüntüyü kırpma veya sıkıştırma yapıldığında önem kazanır.

## **Göreceli Ölçek Kullanma**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) çerçeve için göreceli genişlik ve yükseklik ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescalewidth/) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescaleheight/) metodlarıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla ilişkisini koruması gerektiğinde yararlıdır.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir render alma açısından en güvenli seçimdir. Bağlantılı bir resim ise görüntü verisini aynı şekilde gömmek yerine [Picture::setLinkPathLong](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/setlinkpathlong/) yöntemiyle harici bir konuma işaret eder.

Bağlantılı görüntüler PPTX içinde depolanan veri miktarını azaltabilir, ancak harici bir bağımlılık getirir. Bağlantılı dosya, sunumu açan ya da render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut olmazsa, bağlantılı resim beklenildiği gibi görüntülenmeyebilir. E‑posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına işaret eder. Sadece görüntü bağlantısına odaklanır; video bağlantısı ayrı bir medya iş akışıdır ve bu örnekte karıştırılmamıştır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Harici dosya yönetimi kasıtlı olduğunda bağlantılar kullanılmalıdır. Sıkıştırma yerine sadece bir yedekleme yöntemi olarak kullanılmamalıdır: kırık bağlantılara sahip küçük bir PPTX, büyük ve kendi kendine yeterli bir sunuma göre genellikle daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si, [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) arayüzünü doğrudan kullanır. Aşağıdaki örnek, bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

[IImage::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save) aracılığıyla kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

SVG bir resim için, [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) nesnesi sunar. Bu sayede SVG verisini doğrudan alabilir, resmi rasterlemeden önce veri elde edebilirsiniz.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

SVG içeriğini SVG olarak tutmak, vektör kaynağının sunum içinde korunmasını sağlar. PNG veya JPEG gibi raster dışa aktarmalar, bu vektör içeriğini piksellere dönüştürür. PDF veya SVG slayt dışa aktarma da bir render işlemidir; dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage::getSvgData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/getsvgdata/) verisi kullanılmalıdır.

## **Görüntüyü Kırpma**

Kırpma, çerçeve içinde hangi kısmın görüleceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarına oranla yüzde değerleridir. Kırpma, gömülü görüntüden gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek, bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, sonraki bölümde açıklanan şekilde kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) mevcut kırpma dikdörtgeni dışındaki görüntü verisini siler ve elde edilen görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonra bir “uncrop” işlemi için mevcut değildir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Bu yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynağa ihtiyaç duyar; bu nedenle kırpılmış alanların silinmesi zorunlu olarak toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) raster görüntünün çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiç değişiklik gerekmiyorsa `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturescompression/) değeri kullanın:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Belirli bir hedef gerektiğinde önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içerikleri bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinmiş kırpılmış bölgeler optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek ya da dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve çift‑yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/slides/tr/php-java/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) şeklin yeniden boyutlandırılırken oranını korur.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kilitleme, yalnızca resim çerçevesi şekline uygulanır. Kaynak görüntüyü yeniden örneklemeye veya kalıcı olarak aynı en‑boy oranına zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri kenardan bir içe doğru kaydırma, negatif yüzde değerleri ise dışa doğru kaydırma oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görünür olduğunu seçerken; stretch‑offset değerleri, görünür resim doldurmasının hangi dikdörtgene uzatılacağını değiştirir.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dolgu konumlandırması için stretch‑offsetleri kullanın. Kaynak görüntü kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görüntü depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşimler daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendine yeterli hâle getirir ve paylaşım ile sunucu tarafı render için en güvenilir seçenek olup, büyük raster görüntüler PPTX boyutunu ve bellek tüketimini artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunumun belirtilen yollar ya da konumlarda harici dosyalara erişebilmesine bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılana kadar gömülüdür.
- **Sıkıştırma**, aşırı büyük raster görüntülerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü ödün verir. Slayt üzerindeki hedef boyut bilindikten sonra uygulanmalıdır.
- **SVG görüntüler** vektör korunmasının önemli olduğu durumlarda SVG olarak bırakılmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, aynı dosyayı sunum iş akışına defalarca yüklemek yerine mevcut bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalıdır.

Büyük sunumlarda, görüntü optimizasyonu seçici olarak yapıldığında daha etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutuna göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonra düzenleme gerekmediğinde kaldırın ve dış bağlantılardan kaçının, dış bağımlılık yönetimi dağıtım tasarımının bir parçası değilse.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) sunuma bağlı bir görüntü kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ise bir slayttaki görüntüyü gösteren ve çerçeve‑seviyesi geometri ve biçimlendirmeyi (boyut, döndürme, kırpma değerleri, efektler, kilitleme vb.) depolayan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mıyım?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak kasıtlı ve dış konumlar güvenilir bir şekilde yönetilebiliyorsa yalnızca bağlantı kullanın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden olmaz. Normal kırpma ayarları, kaynak görüntünün parçalarını gizler ama altında yatan pikselleri tutar. Bu pikselleri kalıcı olarak kaldırmak için [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) ya da kırpılmış alanların kaldırıldığı görüntü sıkıştırması kullanılmalıdır.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü azaltır ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışına alın.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriği SVG olarak tutulmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. Slaytı PNG ya da JPEG gibi raster bir formata dışa aktarmak, SVG’yi slayt görüntüsünün bir parçası olarak rasterleştirir.

**Mevcut slaytları okurken güvensiz cast’lerden nasıl kaçınabilirim?**

Resim‑çerçevesine özgü üyeler kullanılmadan önce şekil türü kontrol edilmelidir. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) karşılığı bir `java_instanceof` kontrolü, geçersiz cast’leri önler ve resim‑çerçevesi içermeyen slaytların kod tarafından güvenli bir şekilde işlenmesini sağlar.