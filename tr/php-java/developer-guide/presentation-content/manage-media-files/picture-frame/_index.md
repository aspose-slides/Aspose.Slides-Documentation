---
title: PHP Kullanarak Sunularda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/php-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü resim
- bağlı resim
- resim çıkar
- raster resim
- SVG resmi
- resmi kırp
- kırpılmış alanları sil
- resmi sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreli ölçek
- resim efekti
- en/boy oranı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunularda resim çerçevelerini oluşturma, biçimlendirme, bağlama, kırpma, çıkarma ve sıkıştırma."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi görüntüleyen bir slayt şeklidir. Aspose.Slides'te, resim kaynağı ve onu görüntüleyen şekil ayrı nesnelerdir: bir [Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yerleşik resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarları kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde kullanışlıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu kaynak nesneyi kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster resimler ve SVG gibi vektör resimler içerebilir. Ayrıca, sunum içinde resim baytlarını saklamak yerine bağlanmış resimlere de referans verebilirler. Bu seçim taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu yüzden formatlama veya optimizasyon uygulamadan önce resmin nasıl saklanacağına karar vermek faydalıdır.

## **Gömülü Bir Resim Ekleme ve Biçimlendirme**

Gömülü bir resim için, resim verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) yöntemini kullanın. Resim, sunum paketinin bir parçası haline gelir; böylece sunum başka bir bilgisayara taşındığında da kendine yeten kalır.

Aşağıdaki örnek bir JPEG resmi ekler, resmin doğal boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüş uygulamaktadır:

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

Resim çerçevesi gösterilen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü resim kaynağında saklanan orijinal piksel boyutlarını etkilemez. Bu ayrım, daha sonra resmi kırpma veya sıkıştırma yapıldığında önemli hâle gelir.

## **Göreli Ölçek Kullanma**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeğini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescalewidth/) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescaleheight/) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak resim boyutuyla ilişkiyi koruması gerektiğinde kullanışlıdır.

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

Göreli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü resmi yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlı Resimler**

Gömülü bir resim, görüntü verisini doğrudan sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli tercihtir. Bağlı bir resim ise [Picture::setLinkPathLong](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/setlinkpathlong/) yöntemiyle dış bir konuma işaret eder; görüntü verisi aynı şekilde gömülmez.

Bağlı resimler PPTX içinde saklanan veri miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa ya da kaynak kullanılamazsa, bağlı resim beklenildiği gibi görüntülenmeyebilir. E‑posta ile gönderilmesi, arşivlenmesi ya da izole ortamda render edilmesi gereken sunumlar için gömülü resimler genellikle daha güvenilirdir.

### **Bağlı Bir Resim Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir resim dosyasına işaret eder. Yalnızca resim bağlama işlemine odaklanır; video bağlama ayrı bir medya iş akışıdır ve kasıtlı olarak bu örnekte karıştırılmamıştır.

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

Dış dosya yönetimi kasıtlıysa bağlantıları kullanın. Sıkıştırma yerine sadece bir alternatif olarak kullanmayın: kırık bağlantılara sahip küçük bir PPTX, genellikle daha büyük ama kendi kendine yeten bir sunumdan daha az yararlıdır.

## **Resimleri Resim Çerçevelerinden Çıkarma**

Mevcut bir sunumdan resim çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir resim içerdiğini kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılabilen görüntü baytlarını içermeyebilir.

### **Raster Resim Çıkarma**

Modern resim API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) arayüzünü kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save) yöntemiyle kaydetmek, çıkarılan resmi istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyacınız varsa, dönüştürülmüş raster dosya yerine resim kaynağının ikili verisini kullanın.

### **SVG Resim Çıkarma**

SVG bir resim için, [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) nesnesini ortaya çıkarır. Bu sayede SVG verisini rasterleştirmeden doğrudan alabilirsiniz.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarımı da bir render işlemidir; dışa aktarılan grafikler orijinal gömülü SVG'nin bire bir kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage::getSvgData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/getsvgdata/) verisini kullanın.

## **Bir Resmi Kırpma**

Kırpma, çerçeve içinde hangi kısmın görüleceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak resmin boyutlarının yüzde değerleridir. Kırpma, gizli pikselleri gömülü resimden hemen silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek güvenli bir şekilde bir resim çerçevesi bulur ve kırpma değerlerini uygular:

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

Gizli resim verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu, geri dönüşümden daha önemliyse, kırpılmış bölgeler bir sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Resim Verisini Kaldırma**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) mevcut kırpma dikdörtgeninin dışındaki resim verisini siler ve ortaya çıkan resim kaynağını döndürür. Bu, dosya boyutunu azaltabilir, fakat yıkıcı bir optimizasyondur: sunum kaydedildikten sonra silinen pikseller daha sonraki bir “uncrop” işlemi için artık mevcut değildir.

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

Bu yöntem sunuma yeni bir resim kaynağı ekleyebilir. Orijinal resim başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynağa ihtiyacı olur; bu yüzden kırpılmış alanların silinmesi mutlaka toplam resim sayısını azaltmayabilir. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Resimleri Sıkıştırma**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) raster resim çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Metod, resim yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik yapılmadıysa `false` döndürür.

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

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine özelleştirilmiş pozitif DPI değeri geçirilebilir.

Sıkıştırma raster resimler için tasarlanmıştır. SVG ve metafile içerikleri bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, daha düşük çözünürlük ve silinen kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, resmin gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Resim Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa etkileri, sıralı zincirler, inceleme, kaldırma ve çift yönlü doğrulama dahil tam bir iş akışı için [Image Transform Effects](/php-java/image-transform-effects/) konusuna bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) şeklin ölçeklenirken oranını korur.

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

Kilit, resim çerçevesi şekline uygulanır. Kaynak resmin yeniden örneklenmesini veya kalıcı olarak aynı en/boy oranına zorlanmasını içermez.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru bir boşluk oluştururken, negatif yüzde değerleri dışarıya doğru bir çıkıntı oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak resmin hangi kısmının görüleceğini seçerken; stretch offset değerleri, görülen resim doldurmasının hangi dikdörtgene uzatılacağını değiştirir.

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

Doldurma yerleşimi için stretch offset değerlerini kullanın. Kaynak resim kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Resim depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında ana tavizler daha kolay yönetilir:

- **Gömülü resimler** sunumu kendine yeten hâle getirir ve paylaşım ve sunucu tarafı render için en güvenilirdir; ancak büyük raster resimler PPTX boyutunu ve bellek tüketimini artırır.
- **Bağlı resimler** paketi daha küçük tutabilir, ancak sunumun dış dosyaların belirtilen yollarda mevcut olmasına bağımlı olmasını getirir.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene ya da sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma** aşırı büyük raster resimler için dosya boyutunu önemli ölçüde azaltabilir, fakat kaynak çözünürlüğü feda eder. Öncelikle slayt üzerindeki hedef boyut bilindiğinde uygulanmalıdır.
- **SVG resimler** vektör korunumu önemliyse SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan resimler** mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalı, aynı dosyayı tekrar tekrar sunuma yüklemekten kaçınmalıdır.

Büyük sunumlar için, resim optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logolar ve diyagramlar vektör içerik olarak, fotoğraflar gerçek gösterim boyutuna göre sıkıştırılarak, kırpılmış pikseller yalnızca ileride düzenleme gerekmiyorsa kaldırılarak ve dış bağlantılar yalnızca bağımlılık yönetiminin dağıtım tasarımının bir parçası olduğu durumlarda kullanılmalıdır.

## **SSS**

**Bir resim çerçevesi ile bir resim kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) sunumla ilişkili bir resim kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ise bir slaytta resmi gösteren, boyut, dönüş, kırpma değerleri, efektler ve kilitler gibi çerçeve‑seviyesi geometri ve biçimlendirmeyi depolayan bir şekildir.

**Resimleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa resimleri gömün. Resim dosyalarını PPTX dışına tutmak kasıtlı ve dış konumlar güvenilir bir şekilde yönetilebiliyorsa bağlamayı tercih edin.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değil. Normal kırpma ayarları, kaynak resmin bir kısmını gizler ancak alttaki pikselleri tutar. [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) veya kırpılmış alanların kaldırıldığı bir sıkıştırma, bu pikseller kalıcı olarak atıldığında dosya boyutunu azaltabilir.

**Sıkıştırma sonrası resim kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü azaltabilir ve kırpılmış alanların silinmesi görüntü verisini yok eder. Daha sonra yüksek çözünürlükte düzenleme gerekecekse orijinal kaynak resmi sunum dışında saklayın.

**SVG resimler nasıl ele alınmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriği SVG olarak tutulmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. Slaytı PNG veya JPEG gibi raster bir formata render etmek, SVG'yi piksellere çevirir.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınılır?**

Resim‑çerçevesine özgü üyeler kullanılmadan önce şekil türü kontrol edilmelidir. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) karşısında bir `java_instanceof` kontrolü, geçersiz tip dönüşümlerini önler ve resim çerçevesi içermeyen slaytların düzgün işlenmesini sağlar.