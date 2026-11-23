---
title: PHP Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
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
- geçiş tipi
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ile diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for PHP via Java ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması ya da zamanlayıcı ile yapılandırabilir ve bir efekti özel seçeneklerle ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, tam geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için PHP örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için bir sunumu [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfıyla yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) üzerinden erişin. [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) yöntemini [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumʼundan bir değerle kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Wheel Geçişi**

[setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) yöntemi, hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) ile [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)ʼden Wheel seçin, ardından [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) çağırarak [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/) ayarlarına erişin.

Örnek, iki aynı slayt çiftini oluşturur. Her çift, siyah bir slaytla başlar ve altın bir dikdörtgenle kaplanan bir slaytla biter. Slayt 2 bir spoke (kiriş) kullanırken slayt 4 sekiz kiriş kullanır. Her iki geçiş de aynı yavaş hızda, [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) ile ayarlanmış ve 8.000 milisaniye açıkça belirlenmiş bir süreye sahip ([setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ile).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen sunumu PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta ilerlediğinizde tek yönlü saat yönünde bir süpürme görülür. Ardından 3. slayttan 4. slayta ilerlediğinizde sekiz radyal sektör aynı anda aynı dikdörtgeni ortaya çıkarır.

## **Reveal Geçişi ile Siyah Üzerinden Geçiş**

Hedef slaydın geçiş tipini Reveal olarak ayarlayın, ardından [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) metodunu [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) ayarları üzerinde çağırın. Örnek, turkuaz bir kaynak slaytı ve mercan bir hedef slaytı oluşturur, ardından ikisini klonlar. Her çift aynı iki saniyelik Reveal geçişini kullanır. Sadece ikinci çift siyah üzerinden geçiş yapar.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen sunumu PowerPoint’te açın ve slayt gösterisini başlatın. 1. slayttan 2. slayta ilerlediğinizde turkuaz doğrudan mercana geçer. Ardından 3. slayttan 4. slayta ilerlediğinizde ekran kısa bir süre neredeyse siyaha karar, ardından mercan slaytı görünür. Her iki slayt da özgün arka plan renklerini korur.

Aşağıdaki satırlar, yarım saniyelik aralıklarla PowerPoint’ten alınan kareleri gösterir. Etkiyi görmek için her satırdaki orta kareyi karşılaştırın.

![PowerPoint oynatımı, siyah üzerinden geçiş devre dışı (üst) ve etkin (alt). Yalnızca alt satır neredeyse siyaha geçer.](reveal-through-black.png)

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytun ekranda ne kadar kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) izleyicinin fareyi tıklayarak ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) otomatik ilerleme gecikmesini milisaniye cinsinden belirtir.

Hem tıkla hem zamanlayıcıyla ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesini ya da zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) yöntemine `false` gönderin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlayıcıyla ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) metodunu çağırın. Saklanan bir gecikme tek başına zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

## **Geçiş Zamanlamasını Tam Olarak Kontrol Et**

Geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) yöntemini kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) yöntemi bu ayarları [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/) aracılığıyla ortaya çıkarır:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) metoduna `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) enumʼundan (Slow, Medium, Fast) önceden tanımlı bir hız kategorisi seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) değerine göre efekt süresini belirler.

<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar, 750 ms geçiş süresi ile 5.000 ms otomatik ilerleme ayarını gösterir.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Paylaşılan örnek, her slayta 750 ms Fade geçişi verir ve ayrıca 5.000 ms sonrasında otomatik ilerlemeyi etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme slayttan ne zaman çıkılacağını kontrol eder. Bu çubuklar ölçülen bir birleşik zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Tüm Slaytlara Aynı Süreyi Uygula**

Tutarlı bir tempo için her slayta aynı efekti ve kesin süreyi uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/)ʼden Fade seçer ve her geçişe 750 milisaniye verir. Ayrıca otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir ve fare tıklamasıyla ilerlemeyi devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

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

### **Bireysel Slaytlar İçin Farklı Süreler Belirle**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek, ilk slayta 500 milisaniye ve ikinci slayta 1.200 milisaniye süresi atar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Animasyonlu Çıktıyla Geçişleri Koordine Et**

[animasyonlu GIF](/slides/tr/php-java/convert-powerpoint-to-animated-gif/), [HTML5 sunumu](/slides/tr/php-java/export-to-html5/) veya [video](/slides/tr/php-java/convert-powerpoint-to-video/) hazırlarken dışa aktarma öncesinde tam geçiş sürelerini ayarlayarak istenen tempoyu eşleştirin. Örneğin, sahneler arasında 600 milisaniyelik bir solma kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım ya da içerik için zaman tanıyın.

GIF ve video için, kare hızıyla efekt süresini eşleştirin: 600 milisaniye, saniyede 30 karede 18 kareye denk gelir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma biçiminin desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) metodunu çağırarak açık bir değer depolanıp depolanmadığını öğrenin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden depolanmış süreyi gösterir. Ayarlanmamış değer, oynatma süresi olarak hesaplanmış bir değer değildir: Aspose.Slides, geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) değerine göre bu süreyi belirler. Bir geçiş tipi ayarlamak, bir süreyi başlatabilir; bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph etkisi yaratmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Bu, geçişin ilgili nesneleri orijinal ve değiştirilmiş halleri arasında canlandırmasını sağlar.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumʼundan Morph seçer. Kaydedilen dosyayı Morph’u destekleyen bir sunum görüntüleyicide açarak slayt gösterisi sırasında efekti görün.

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

[TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) enumʼu, Morph’un içeriği nasıl eşleştirip canlandıracağını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Morph’u seçmek için [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) yöntemiyle Morph’u belirleyin, ardından [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) ile bir [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) nesnesi alın ve bu nesnenin [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) yöntemiyle eşleme modunu seçin.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime bazlı Morph animasyonu kullanacak şekilde yapılandırır.

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

Bazı geçişler, yön veya etkinin siyah bir ekrandan başlayıp başlamadığı gibi ek seçenekler sunar. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) ile seçilen geçişe bağlıdır. Önce türü ayarlayın, ardından [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) aracılığıyla uygun geçiş nesnesini kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlaması için [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) üzerinden [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) metodunu çağırır.

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

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (Slow, Medium, Fast) kategorisi yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) kullanın. Bu ayarlar, geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyip döngüde çalmasını sağlayabilir miyim?**

Evet. Gömülü sesi [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound) ile atayın, [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) enumʼundan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode) metoduna gönderin ve [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) metodunu `true` yaparak sesin döngüde çalmasını sağlayın. Ses, slayt gösterisindeki bir sonraki ses olayı gerçekleşene kadar döngüde çalar.

**Her slayta aynı geçişi en hızlı şekilde nasıl uygularım?**

Sunumun [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) koleksiyonunu döngüyle gezerek her slaytın geçişine aynı değerle [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) çağırın. Aynı döngüde zamanlama ve efekt seçeneklerini de ayarlayarak davranışı tüm slaytlar arasında tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol ederim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) sonucunda [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) enumʼundan bir değer döndürür; None değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.