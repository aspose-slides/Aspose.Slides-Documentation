---
title: PHP Kullanarak Sunumlarda Resim Çerçevelerini Yönetme
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
- görüntüyü çıkart
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
description: "Aspose.Slides for PHP via Java ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkartın ve sıkıştırın."
---
## **Genel Bakış**

Resim çerçevesi, bir resim gösteren bir slayt şeklidir. Aspose.Slides içinde, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yerleşik resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarlarını kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntüyü sunuma gömmek yerine bağlantılı bir resme referans verebilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkartma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntüyü Ekle ve Biçimlendir**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak üzere [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) yöntemini kullanın. Görüntü, sunum paketinin bir parçası haline gelir, bu yüzden sunum başka bir bilgisayara taşındığında kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün özgün boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüş uygular:

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

Resim çerçevesi, görüntülenen geometrinin kontrolünü sağlar; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma gerektiğinde önem kazanır.

## **Göreceli Ölçek Kullanımı**

[PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) çerçeve için genişlik ve yükseklik ölçeklemesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescalewidth/) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/setrelativescaleheight/) metodlarıyla ortaya koyar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının kaynak görüntü boyutuna ilişkin ilişkiyi koruması gerektiğinde, nihai boyutları manuel olarak hesaplamaktan daha kullanışlıdır.

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

Gömülü bir resim, görüntü verisini sunum içinde saklar ve bu nedenle taşınabilirlik ve öngörülebilir renderleme açısından en güvenli tercihtir. Bağlantılı bir resim ise görüntü verisini aynı şekilde gömmek yerine [Picture::setLinkPathLong](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/setlinkpathlong/) yöntemiyle harici bir konuma işaret eder.

Bağlantılı görüntüler, PPTX içinde depolanan görüntü verisinin miktarını azaltabilir, ancak dış bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak erişilemez olursa, bağlantılı resim beklendiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda renderlenmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilir olur.

### **Bağlantılı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görüntü dosyasına yönlendirir. Sadece görüntü bağlantısına odaklanır; video bağlantısı ayrı bir medya iş akışıdır ve bu örneğe bilinçli olarak karıştırılmamıştır.

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

Dış dosya yönetimi kasıtlıysa bağlantılar kullanın. Sıkıştırma yerine bir alternatif olarak kullanmayın: kırık görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendi içinde bütünleşik bir sunumdan daha az kullanışlıdır.

## **Resimleri Resim Çerçevelerinden Çıkarma**

Mevcut bir sunumdan bir görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerip içermediğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) kullanır. Aşağıdaki örnek, bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde depolanmış şifrelenmiş baytlara ihtiyacınız varsa, dönüştürülmüş raster dosyası yerine görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntüsü Çıkarma**

SVG bir resim için, [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanıza olanak tanır.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar, o vektör içeriğini piksellere dönüştürür. PDF veya SVG slayt dışa aktarma da bir renderleme işlemidir; bu yüzden dışa aktarılan grafikler, orijinal gömülü SVG'nin bayt-düğüm kopyası gibi ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage::getSvgData](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/getsvgdata/) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının görüneceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntü boyutlarının yüzdesidir. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğu için, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu çok önemliyse ve geri dönüşebilirlik öncelik değilse, sonraki bölümde açıklandığı gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini siler ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için mevcut olmaz.

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

Yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını ihtiyaç duyar; bu yüzden kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) raster görüntü çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `true`, hiçbir değişiklik gerekmediyse `false` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda, önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturescompression/) değeri kullanın:

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

Belirli bir hedef gerektiğinde, önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metadoşya içerikleri bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinmiş kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; tüm sunumda en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık ile kontrast için parlaklık gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti de güvenli bir şekilde okur:

```php
use aspose\slides\Presentation;

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
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Bu efektler, görüntünün çerçevede nasıl render edildiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazarlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) yeniden boyutlandırılırken şeklin oranını korur.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en-boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzdeler bir kenardan içeriye, negatif yüzdeler ise dışarıya doğru bir genişleme oluşturur.

Bu, kırpmaktan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görünür olduğunu seçerken; stretch offset değerleri, görünür resim doldurmasının hangi dikdörtgene uzatılacağını değiştirir.

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

Doldurma yerleşimi için stretch offset değerlerini, kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Düşünceleri**

Görüntü depolama ile resim‑çerçeve biçimlendirmesinin ayrı ayrı ele alındığı zaman temel ticaret‑off’lar daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde bütünleştirir ve paylaşım ile sunucu‑tarafı renderleme için en güvenilir seçenek olup, büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görüntüler** paketi daha küçük tutabilir, ancak sunum, depolanmış yollar veya konumlardaki dış dosyaların hâlâ mevcut olmasına bağımlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene kadar gömülü kalır.
- **Sıkıştırma**, aşırı büyük raster görüntüler için dosya boyutunu büyük ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Çerçeve üzerindeki nihai boyut bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör korunumu önemliyse SVG olarak kalmalıdır. Vektör kaynağına ihtiyacınız olduğunda gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görüntüler**, mümkün olduğunda aynı [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kaynağının yeniden kullanılmasını önerir; aynı dosyanın sunuma birden çok kez yüklenmesinden kaçının.

Büyük sunumlar için, görüntü optimizasyonu genellikle seçici uygulanarak en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek görüntüleme boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonraki düzenleme gerekli değilse kaldırın ve dış bağlantılardan kaçının; dış bağımlılık yönetimi dağıtım tasarımının bir parçası değilse.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) sunumla ilişkili bir görüntü kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ise bir slayt üzerindeki, bir görüntüyü gösteren ve boyut, dönüş, kırpma değerleri, efektler ve kilitler gibi çerçeve‑düzeyi geometrik ve biçimsel bilgileri depolayan bir şekildir.

**Görüntüleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilebilir olması gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına almak kasıtlı ve dış konumların güvenilir bir şekilde korunabileceği durumlarda sadece bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Tek başına hayır. Normal kırpma ayarları, kaynak görüntünün bir kısmını gizler ancak altındaki pikselleri tutar. [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) veya kırpılmış alanların kaldırıldığı görüntü sıkıştırması, bu pikseller kalıcı olarak atılabilir.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma, depolanan raster çözünürlüğü düşürebilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriği SVG olarak kalmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster bir formata slayt renderlemek, SVG’yi slayt görüntüsünün bir parçası olarak rasterleştirir.

**Mevcut slaytları okurken güvenli olmayan cast’lerden nasıl kaçınılır?**

Resim çerçevesi‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) üzerine bir `java_instanceof` kontrolü, geçersiz cast’leri önler ve resim çerçevesi içermeyen slaytları kodunuzun uygun şekilde işlemesini sağlar.