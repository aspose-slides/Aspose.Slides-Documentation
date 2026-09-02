---
title: PHP ile Sunumlarda Resim Dönüşüm Efektlerini Yönetme
linktitle: Resim Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/php-java/image-transform-effects/
keywords:
- resim dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- duoton
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile resim çerçeveleri için resim dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir `image transform` işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/) nesnesiyle başlayın ve [Picture::getImageTransform](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/getimagetransform/) metoduna erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/) ile orijinal resim baytlarını yeniden yazmadan efektleri ekleyebilir, sıralayabilir, inceleyebilir, kaldırabilir ve temizleyebilirsiniz.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX tur‑tur kontrolü için tam bir iş akışını gösterir.

## **Efekt Sahipliğini ve Resim Yeniden Kullanımını Anlama**

Bir resim kaynağı ve onu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) sunumun sahip olduğu kaynak resim verilerini saklar veya onlara referans verir.
- [Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picture/) bir resim dolgusuna ait olup bir resim kaynağına işaret eder ve aynı zamanda resim dönüşüm koleksiyonunu depolar.
- [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ilgili resim dolgusunu, geometrisini, kırpma ayarlarını ve diğer çerçeve‑düzeyi biçimlendirmeleri sahiplenen slayt şeklidir.

Bu nedenle, resim dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) baytlarını değiştirmez. Aynı `PPImage` birden fazla kez [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) metoduna geçirilirse, her yeni resim çerçevesi kendi `Picture` nesnesine ve kendi dönüşüm koleksiyonuna sahip olur. Bir çerçeveye gri tonlamayı uygulamak, diğer çerçeveleri gri tonlamaz; çünkü hepsi aynı gömülü resim kaynağını paylaşsa da her birinin ayrı `Picture` nesnesi vardır.

Aynı `Picture::getImageTransform` modeli, bir şekil veya slayt arka planı gibi diğer resim dolgu türleri tarafından da kullanılır. Aşağıdaki örnekler yalnızca resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her out‑of‑range değeri reddetmese bile, hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Yok | Sayısal parametre yok. Alfa aynı kalır. |
| [addDuotoneEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içinde RGB ve alfa kanalları `0`‑`255` arasında. |
| [addTintEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Ton `0` dahil `360` hariç derece cinsinden; miktar `-100`‑`100` yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Ton `0` dahil `360` hariç derece; doygunluk ve parlaklık `-100`‑`100` yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Yerine konulacak renk `0`‑`255` aralığında kanal değerleri kullanır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına taşmasını kontrol eden Boolean değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0`‑`100` kullanın: `0` tamamen şeffaf, `100` mevcut alfabı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑`100` yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑`100` yüzde alfa eşiği. Bu değerin altındaki pikseller şeffaf, eşit veya üzerindekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirini tamamlar. Örneğin %35 şeffaflık, %65 alfa modülasyon miktarına eşittir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) bir [Luminance](https://reference.aspose.com/slides/tr/php-java/aspose.slides/luminance/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [Luminance::getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/luminance/geteffective/) hesaplanmış yalnızca‑okunur değerleri verir; bu değerler incelenebilir veya günlüklenebilir.

Aşağıdaki örnek parlaklığı %15, kontrasti %20 artırır ve gömülü resmi değiştirmeden bir ön izleme oluşturur:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance`, standart DrawingML parlaklık ve kontrast efektidir. Bu ayarlar PPTX tur‑tur sonrası düzenlenebilir kalmalıysa, kaydedilen sunumu yeniden açın ve hem işlem tipini hem de etkili değerlerini doğrulayın.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı resim kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[Duotone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri haritalar. Bu, ayarları tek bir skaler değerden daha karmaşık olan bir efektin yararlı bir örneğidir.

```php
use aspose\slides\Images;
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

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini sabit bir renkle değiştirirken alfa kanalını korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) metodundan farklıdır.

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına taşabileceği durumlarda `grow` değerini `true` yapın.

Tekdüzen şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmî şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) ise alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

```php
use aspose\slides\Images;
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

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Parametresiz diğer alfa işlemleri arasında [addAlphaCeilingEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) (her sıfır olmayan alfa tam opak olur), [addAlphaFloorEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) (her alfa %100 altı tamamen şeffaf olur) ve [addAlphaInverseEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) (alfa `100% - alpha` olarak değişir) bulunur.

## **Sıralı Bir Efekt Zinciri Oluşturma**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. Oluşturucu, koleksiyonu sıralı bir boru hattı gibi kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur, vb. Bu nedenle aynı işlemler farklı bir sırada farklı bir resim üretir.

Örneğin, önce gri tonlama sonra tonlama uygulamak önce renk bilgisini siler, ardından parlaklık sonucunu yeniden renklendirir. Tonlama ardından gri tonlama ise tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir; alfa modülasyonu ise bunların göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem tiplerini hem de sırasını kontrol eder ve yeniden açılan sonucu işler:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerinin ayrı zincirlere sınırlı olduğu bir uyumluluk matrisi uygulamaz. Birlikte kullanılabilirler, ancak kombinasyonlar her zaman faydalı olmayabilir. Sabit renk değiştirme, önceki renk efektleriyle üretilen RGB varyasyonunu kaldırır; duotoneden sonra gri tonlama seçilen iki rengi siler; alfa tavan, taban, değiştirme ya da iki‑seviye işlemler daha önce oluşturulan alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları gibi düşünmeyin.

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `Picture::getImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan sunulabilir. Örneğin, [Blur](https://reference.aspose.com/slides/tr/php-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak sunar. [Duotone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/duotone/) gibi renk efektleri ise değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorformat/) nesnelerini açar.

[Luminance](https://reference.aspose.com/slides/tr/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/tr/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/tr/php-java/aspose.slides/alphareplace/) gibi bazı işlemler, oluşturma skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konuma yeni bir tane ekleyin.

`getEffective()` tarafından döndürülen etkili veri, hesaplanmış ve yalnızca‑okunur. Tema‑bağımlı renkleri çözmek ve oluşturucunun kullandığı normalleştirilmiş değerleri okumak için yararlıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri döngüsel olarak listeler ve ilgili API etkili değer sağlıyorsa bunları inceler:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
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
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Gri tonlama, alfa tavan ve alfa tersine çevirme gibi parametresiz efektlerin de bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayar yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Resim Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksine göre kaldırmak için [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/removeat/) kullanın. Kaldırma sonrası indeksler kaydırıldığı için önce hedefi bulup ardından kaldırın. Tüm zinciri silmek için [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagetransformoperationcollection/clear/) metodunu kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
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
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Formatlarını ve Dışa Aktarma Hedeflerini Göz Önünde Bulundurma**

Resim dönüşümleri DrawingML içinde ortaya çıkar, bu nedenle PPTX efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX bile olsa, her işlem aynı taşınabilirlik seviyesine sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, PPTX tur‑tur sonrasında hayatta kalma şansı en yüksek olandır. Üretilen dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- İkili PPT formatı tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktılar, desteklenen zinciri işlenmiş görünüme uygular. Bu çıktılar düzenlenebilir bir `ImageTransformOperationCollection` içermez; raster formatlar sonucu piksellere dönüştürür, belge ya da vektör dışa aktarımları kendi çizim temsillerini saklar.
- Efektler, bağlanmış bir resmi kendine yeterli hâle getirmez. Bağlantılı bir resmin renderlanması, sunum yüklendiğinde bağlanmış kaynağın mevcut olmasına bağlıdır.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantizasyon işlemi bir arada kullanıldığında, kenar durumlarını farklı yorumlayabilir. Kritik çıktı için, üretimde kullanılan aynı Aspose.Slides sürümüyle hem düzenlenebilir tur‑tur hem de nihai dışa aktarma formatını test edin.

## **SSS**

**Resim dönüşüm efektleri gömülü resim verilerini değiştirir mi?**

Hayır. İşlemler, resim dolgusunun kullandığı `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmeden kalır.

**Aynı resmi yeniden kullanan iki resim çerçevesi efektlerini paylaşır mı?**

Hayır. `PPImage` yeniden kullanımı, görüntü verisinin kopyalanmasını önler; ancak her resim çerçevesi genellikle ayrı bir `Picture` ve ayrı bir dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısını bir sonraki işlem nasıl kullandığını dikkate alın; değiştirme ve eşik işlemleri önceki renk ya da alfa detayını ortadan kaldırabilir.

**Etkili değerler neden yalnızca‑okunur?**

Etkili veri, renderlama sırasında kullanılan, renklerin çözümlendiği hesaplanmış değerleri temsil eder. Yazılabilir üye bulunan bir işlemde değişiklik yapın; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML efekt modelini temsil edemez; render dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini tutmaz.