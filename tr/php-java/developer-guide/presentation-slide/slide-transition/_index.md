---
title: PHP Kullanarak Sunumlarda Slayt Geçişlerini Yönetin
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/php-java/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- Morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ile diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slide geçişleri, slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for PHP via Java ile her slayt için bir geçiş efekti seçebilir, fare tıklaması ya da zamanlayıcı ile ilerlemeyi yapılandırabilir ve efekti özel seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için PHP örnekleri kullanır. Örnekler ayrıca ayarları bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfıyla bir sunumu yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getSlideShowTransition) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitiontype/) enum\’undan bir değerle [setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişini ve ikinci slayta Comb geçişini uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**

Bir slayt ekran’da ne kadar kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerlemeden önceki gecikmeyi milisaniye cinsinden belirtir.

Hem tıklamayı hem de zamanlamayı etkinleştirerek izleyicinin bir tıklama ile devam etmesini ya da zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick)’a `false` geçirin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) çağırın. Saklanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Geçiş Zamanlamasını Hassas Bir Şekilde Kontrol Et**

Geçiş efektinin tam süresini milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setDuration) kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi, bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/) aracılığıyla ortaya çıkarır:

| Metod | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter)’a `true` geçirin. |
| [setSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setSpeed) | Önceden tanımlı bir hız kategorisini [TransitionSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionspeed/): Slow, Medium veya Fast. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration] yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipinden ve [getSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getSpeed) değerinden etki süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süresi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5 000 milisaniye sonra etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş ve bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek ilk slayta 500 milisaniye, ikinci slayta 1 200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Geçişleri Animasyonlu Çıktı ile Koordine Et**

Bir [animated GIF](/slides/tr/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/php-java/export-to-html5/) veya [video](/slides/tr/php-java/convert-powerpoint-to-video/) hazırlarken, hedef temposa uygun olması için dışa aktarmadan önce kesin geçiş sürelerini ayarlayın. Örneğin sahneler arasında 600 milisaniyelik bir fade kullanın ve her slaytın ilerleme gecikmesini ayrı olarak ayarlayarak anlatım veya içerik süresine izin verin.

GIF ve video için, efekt süresiyle çıktı kare hızı eşleşmelidir: 600 milisaniye, 30 fps’de 18 kareye eşittir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efektleri ve zamanlama seçeneklerini kontrol edin, senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getDuration) çağırarak açık bir değer depolanıp depolanmadığını öğrenin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden saklanan sürenin olduğunu gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [getSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getSpeed) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süre başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri animasyonlu olarak gösterir. Basit bir Morph efekti oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve Morph geçişini ikinci slayta uygulayın. Bu, geçişin ilgili nesneleri orijinal ve değiştirilmiş durumları arasında animasyon yapmasını sağlar.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Daha sonra ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitiontype/) enum\'undan Morph seçer. Morph’u destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak slayt gösterisi sırasında efekti görün.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Morph Geçiş Tipleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionmorphtype/) enum\'u, Morph’un içeriği nasıl eşleştirip animasyonladığını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionmorphtype/#ByWord) metni mümkün olduğunda kelimelere göre eşleştirerek animasyon yapar.
- [ByChar](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionmorphtype/#ByChar) metni mümkün olduğunda karakterlere göre eşleştirerek animasyon yapar.

Morph’u seçmek için [setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setType) kullanın, ardından [getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getValue) ile bir [MorphTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/morphtransition/) nesnesi alın; bu nesnenin [setMorphType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/morphtransition/#setMorphType) yöntemi eşleme modunu seçer.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime‑bazlı Morph animasyonu kullanacak şekilde yapılandırır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek yön veya efektin siyah bir ekrandan başlaması gibi ek seçenekler sunar. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. Önce tip belirlenir, ardından [getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getValue) üzerinden uygun geçiş nesnesi kullanılır.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlaması için [OptionalBlackTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/optionalblacktransition/) üzerinden [setFromBlack](https://reference.aspose.com/slides/tr/php-java/aspose.slides/optionalblacktransition/#setFromBlack) çağrısı yapılır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setDuration) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionspeed/) kategorisi—Slow, Medium veya Fast—yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setSpeed) kullanın. Bu ayarlar, otomatik ilerleme gecikmesinden bağımsız olarak geçiş efektini kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [setSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setSound) ile atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitionsoundmode/) enum\'undan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setSoundMode)’a geçirin ve `true` ile [setSoundLoop](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setSoundLoop)’u etkinleştirin. Ses, slayt gösterisindeki bir sonraki ses olayı gerçekleşene kadar döngüye girer.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlides) koleksiyonunda döngü oluşturun ve her slaytın geçişi için aynı değeri [setType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#setType) ile ayarlayın. Aynı döngüde zamanlama ve efekt seçeneklerini de ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getSlideShowTransition) sonucunda [getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideshowtransition/#getType) çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/transitiontype/) enum\'undan bir değer döndürür; None değeri, geçiş efektinin uygulanmadığını gösterir.