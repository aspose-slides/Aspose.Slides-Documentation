---
title: PHP ile Sunumlarda Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/php-java/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim etkisi
- parlaklık
- kontrast
- gri tonlama
- çift ton
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
description: "Aspose.Slides for PHP via Java ile resim çerçeveleri için görüntü dönüşüm efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlarını görüntü dönüşüm işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) ile başlayın ve [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) orijinal görüntü baytlarını yeniden yazmadan efektleri eklemenize, numaralandırmanıza, incelemenize, kaldırmanıza ve temizlemenize olanak tanır.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı etki zincirleri, etkin değerler, kaldırma ve PPTX çift yönlü doğrulama için tam bir iş akışını gösterir.

## **Etkilerin Sahipliği ve Görüntü Yeniden Kullanımını Anlamak**

Bir görüntü kaynağı ve onu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) sunumun sahip olduğu kaynak görüntü verisini depolar veya referans verir.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu saklar.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ilgili resim doldurmayı, geometrileri, kırpma ayarlarını ve diğer çerçeve‑düzeyi biçimlendirmeleri sahip olan slayt şeklidir.

Dolayısıyla, görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) içindeki baytları değiştirmez. Aynı `PPImage` birden çok kez [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) metoduna iletildiğinde, her yeni resim çerçevesi kendi `Picture` nesnesini ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulamak diğer çerçevelerin gri tonlamasını etkilemez; tüm çerçeveler aynı gömülü görüntü kaynağını yeniden kullansa da.

Aynı `Picture::getImageTransform` modeli, bir şekil veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıklar ve birimler kullanır. Belirli bir kütüphane sürümü her dış‑aralığı hemen reddetmese bile bu aralıklarda değerleri tutun; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açarken geçersiz verileri normalleştirebilir, yok sayabilir veya reddedebilir.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | Sayısal parametre yoktur. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içindeki RGB ve alfa kanalları `0`‑`255` değerleri alır. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Ton değeri `0` dahil `360` hariç derece; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Ton `0` dahil `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Değiştirilecek renk kanalları `0`‑`255` aralığında. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına genişleyip genişlemeyeceğini kontrol eden Boolean değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0`‑`100` kullanın: `0` tamamen şeffaf, `100` mevcut alfayı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`‑`100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`‑`100` arasında, yüzde alfa eşik değeri. Altındaki değerler şeffaf, eşik değerdeki veya üzerindeki değerler opaktır. |

Sabit alfa modülasyonu için şeffaflık ve opaklık tamamlayıcıdır. Örneğin, %35 şeffaflık alfa modülasyonu miktarı %65’e karşılık gelir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) bir [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) hesaplanmış salt okunur değerleri döndürür; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

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

`Luminance` standart DrawingML parlaklık ve kontrast etkisidir. Bu ayarlar bir PPTX turundan sonra düzenlenebilir kalmalıysa, kaydedilen sunumu yeniden açın ve hem işlem türünü hem de etkin değerlerini doğrulayın.

## **Renk Dönüşümlerini Uygulama**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirmeyi uygular.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri temsil eder. Bu, ayarları tek bir skaler değerden daha karmaşık olan bir etki örneği olarak yararlıdır.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) her pikselin rengini sabit bir renkle değiştirirken alfabayı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkan [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) metodundan farklıdır.

### **Luminance Eşiği Uygulama**

Luminance eşiği, taranmış bir sayfadaki hafif işaretlerin arka planla daha kolay ayırt edilmesini sağlar. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) ara ton gri gölgelerini korur. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) luminansı siyah veya beyaza dönüştürürken, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) opaklığa bir eşik uygular.

Luminance eşiği %0‑%100 arasında, yüzde olarak tanımlanır. Eşiğin altındaki pikseller siyah olur. Eşiğe eşit veya üstündeki pikseller beyaz olur. Eşiği yükseltmek, daha fazla tonu siyaha dönüştürür çünkü daha fazla ton eşik değerinin altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını PHP betiğinin bulunduğu dizine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyesini gösterir. Örnek, orijinali iki kopyasının yanına yerleştirir ve her kopyanın eşik değerini sunuma kaydeder.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Çıktı sunumunu PowerPoint’te açarak üç çerçeveyi karşılaştırın. 96 etiketli örnek %38 luminansa sahiptir (96/255). %20 eşiğinde beyaza, %60 eşiğinde ise siyaha dönüşür.

![Orijinal gri örnekler, luminans eşikleri %20 ve %60'da siyah-beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` değerini `true` yapın.

Tekdüzen şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) kullanın. Bu, mevcut alfa değerlerinin her birini çarpar; böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) alfa değerlerini bir eşik temelinde iki düzeye dönüştürür.

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

Parametresiz diğer alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), her sıfır‑olmayan alfanın tamamen opak olmasını sağlar; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), %100’den düşük tüm alfaları tamamen şeffaf yapar; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), alfanın `100% - alpha` değerine dönüştürür.

## **Sıralı Etki Zinciri Oluşturma**

Her `add...Effect` metodu, koleksiyonun sonuna yeni bir işlem ekler. İşleyici, koleksiyonu sıralı bir veri akışı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve bu şekilde devam eder. Dolayısıyla aynı işlemler farklı bir sırada uygulandığında farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından tonlama önce renk bilgisini kaldırır, ardından luminans sonucunu yeniden renklendirir. Tonlama ardından gri tonlama ise tonlamayı tekrar kaldırır. Benzer şekilde, alfa değiştirme önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise bunların göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sıralarını kontrol eder ve yeniden açılan sonucu render eder:

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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilirler, ancak kombinasyonlar her zaman yararlı olmayabilir. Sabit bir renk değiştirme, önceki renk efektleri tarafından üretilen RGB varyasyonunu kaldırır; duotone ardından gri tonlama iki seçili rengi kaldırır; ve alfa tavan, taban, değiştirme veya iki‑düzey işlemleri daha önce oluşturulan alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları olarak değil.

<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra tonlamadan, ardından tonlamadan sonra gri tonlamadan geçer. İki son gri tonlama görüntüsü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu açıklayıcı Aspose.Slides for .NET 26.11 renderında, %25’te %220 tonlama gri tonlamayı değiştirmez. Aynı tonlamayı gri tonlamadan önce uygulamak farklı tonlar üretir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkin Değerleri İnceleme**

Düzenlenebilir bir işlem, `Picture::getImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan ortaya çıkabilir. Örneğin, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak sunar. [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) gibi renk efektleri değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) nesnelerini ortaya çıkarır.

[Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/) gibi bazı işlemler, yaratım skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp, istenen konumda yeni bir işlem ekleyin.

`getEffective()` tarafından döndürülen etkili veri, hesaplanmış ve salt okunurdur. Tema‑bağımlı renkleri çözmek ve işleyicinin kullandığı normalleştirilmiş değerleri okumak için kullanışlıdır; ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri numaralandırır ve ilgili API etkin değerler sağlıyorsa bunları inceler:

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

Skalarsız efektler (gri tonlama, alfa tavan, alfa ters) de bir etkili‑veri nesnesine sahiptir, ancak yazdırılacak skaler ayarları yoktur. Bunların varlığı ve koleksiyondaki konumu önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) kullanın. Kaldırma sonrası indeksler kaydığı için önce hedefi bulun, ardından numaralandırmadan sonra kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Gömülü [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünmek**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX, etki zincirleri için tercih edilen düzenlenebilir formattır. PPTX kullanılsa bile her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri, PPTX çift yönlü turunda hayatta kalma olasılığı en yüksek olandır. Düzenlenebilirlik bir gereklilikse, oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- İkili PPT formatı, tam DrawingML etki modelinden önce gelmiştir. PPT’ye kaydetmek desteklenmeyen işlemleri atlayabilir, zinciri desteklenen bir alt küme ile sınırlayabilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir zincirler için doğrulama formatı olarak PPT kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara render etmek, desteklenen zinciri render edilen görünüme uygular. Bu çıktılar düzenlenebilir `ImageTransformOperationCollection` içermez; raster formatları sonucu piksellere döker, belge veya vektör dışa aktarımları kendi render temsilini depolar.
- Efektler, bağlanmış bir görüntünün kendi içinde tamamlanmasını sağlamaz. Bağlanmış bir resmi render etmek, sunum yüklendiğinde bağlanmış kaynağın mevcut olmasına hâlâ bağlıdır.

Farklı sunum tüketicileri kenar durumlarını farklı şekilde render edebilir; özellikle birden çok alfa veya renk‑kuantizasyon işlemi birleştirildiğinde. Kritik çıktılar için aynı Aspose.Slides sürümüyle hem düzenlenebilir çift yönlü turunu hem de nihai dışa aktarma formatını test edin.

## **FAQ**

**Görüntü dönüşüm efektleri gömülü görüntü verisini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. `PPImage` yeniden kullanımı, görüntü verisinin çoğaltılmasını önler, ancak her resim çerçevesi normalde ayrı bir `Picture` ve ayrı bir görüntü dönüşüm koleksiyonu alır.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısını nasıl etkilediğine dikkat edin; değiştirme ve eşik işlemleri daha önceki renk veya alfa detayını yok edebilir.

**Etkin değerler neden salt okunurdur?**

Etkin veri, render için kullanılan hesaplanmış değerleri temsil eder; çözülmüş renkler de dahil. Yazılabilir üyeleri olan işlemi, dönüşüm koleksiyonunda düzenleyin; aksi takdirde işlemi kaldırıp yeni yaratım parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi format kullanılmalı?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML etki modelini temsil edemez; render edilen dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini içermez.