---
title: PHP ile Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/php-java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni ekleme, inceleme ve özelleştirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efekt, hedef şekil, animasyon türü ve alt türü, tetikleyici, zamanlama ayarları ve isteğe bağlı olarak ses ya da animasyon sonrası davranış gibi özelliklere sahiptir.

Zaman çizelgesi iki çeşit sıra içerir:

- **ana sıra**, slayt ilerlediğinde oynatılır.
- **etkileşimli sıra**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri şekil olduğundan, çoğu slayt içeriği için aynı [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttype/) sınıfında listelenmiştir.

## **Şekil Animasyonları Ekle**

Bir animasyon eklemek için slaydın ana sırasını alın ve [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) metodunu hedef şekil, efekt türü, alt tür ve tetikleyici ile çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli sıra oluşturun.

Aşağıdaki örnek her iki animasyon tipini oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttriggertype/) ana sırada bir tıklama ya da etkileşimli sırada tetikleyici şekle tıklanmasını bekler.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttriggertype/) önceki efektle birlikte başlar.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttriggertype/) önceki efekt bittiğinde başlar.

Bir resmi, grafiği ya da başka bir şekil tipini animasyonlamak için `$targetShape` yerine o nesneyi [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) metoduna geçirin. Grafik‑özel grup seçenekleri için [Animated Charts](/slides/tr/php-java/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [Sequence::getEffectsByShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/geteffectsbyshape/) metodunu kullanın. Tüm efektleri incelemek için ana sırayı ve her etkileşimli sırayı döngüye alın. Döngü, bir sıranın `0` indeksinde bir efekt olduğu varsayımını ortadan kaldırır.

Aşağıdaki örnek bir şekil oluşturur, hem ana‑sıra hem de etkileşimli etkileri ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm sıraları döngüye alır.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Yalnızca tek bir şeklin efektlerine ihtiyacınız varsa, önce şekli ad, yer tutucu türü ya da başka sabit bir özellik ile tanımlayın; ardından [Sequence::getEffectsByShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/geteffectsbyshape/) metodunu çağırın. [ShapeCollection::get_Item](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/get_item/) metodunun `0` indeksindeki öğesinin her zaman istenen nesne olduğunu varsaymayın.

## **Kalıtılmış Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki yer tutucu, düzen slaytı ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getbaseplaceholder/) bu üst yer tutucuyu döndürür; üst yer tutucu yoksa `null` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** efektlerine sahiptir.

![Normal slaytta altbilgi animasyon etkisi](slide-shape-animation.png)

![Düzen slaytta altbilgi yer tutucu animasyon etkisi](layout-shape-animation.png)

![Ana slaytta altbilgi yer tutucu animasyon etkisi](master-shape-animation.png)

Sonraki örnek, yeni bir sunumda yer tutucu hiyerarşisi kullanır. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal bir slayttaki karşılık gelen yer tutucuya efektler ekler. Her [Shape::getBasePlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getbaseplaceholder/) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Animasyon Zamanlamasını Değiştir**

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/) sınıfının özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** [Timing::getTriggerType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/gettriggertype/) ile eşleşir.
- **Duration** [Timing::getDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/getduration/) ile eşleşir, saniye cinsindendir.
- **Delay** [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/gettriggerdelaytime/) ile eşleşir, saniye cinsindendir.
- **Repeat** [Timing::getRepeatCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/getrepeatuntilnextclick/) veya [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/getrepeatuntilendslide/) ile eşleşir.
- **Rewind when done playing** [Timing::getRewind](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/getrewind/) ile eşleşir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/) referansını tutmak, gereksiz bir koleksiyon indeksinden kaçınır.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tek bir tekrar modunu kasıtlı olarak kullanın. Tekrar sayısını bir “until” bayrağı ile birleştirmek, farklı izleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/setrepeatuntilnextclick/) ve [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/setrepeatuntilendslide/) ardından [Timing::setRepeatCount](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/setrepeatcount/) ayarlayın; çünkü herhangi bir bayrağın ayarlanması aktif tekrar modunu değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon efekti, [Effect::getSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getsound/) aracılığıyla gömülü ses referansına sahip olabilir. [Effect::setStopPreviousSound](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/setstopprevioussound/) bir efektin daha önceki bir efekt tarafından başlatılan sesi durdurmasını söyler.

### **Bir Efekte Ses Ekle**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası varsayar. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) tarafından döndürülen nesneler kullanıldığı için sıra indeksi gerekmez.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Gömülü Efekt Seslerini Çıkar**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum varsayar. Hem ana hem de etkileşimli sıraları tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [Audio::getContentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audio/getcontenttype/) tarafından sağlanan ses MIME tipinden seçilir.

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Büyük ses nesneleri için, tüm nesneyi bir byte dizisine yüklemek yerine [Audio::getStream](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audio/getstream/) kullanıp akışı bir dosyaya kopyayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** seçeneği, bir şeklin efekt tamamlandıktan sonra ne olacağını belirler.

![PowerPoint Efekt Seçenekleri iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/) sınıfı, şekli değişmeden bırakma, rengini değiştirme, animasyondan sonra gizleme ya da bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType::Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/) olduğunda, aynı zamanda [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getafteranimationcolor/) de ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi üzerinden animasyon sonrası davranışı ayarlar ve sonucu kaydeder.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[AfterAnimationType::Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/) dışına bir tür değiştirildiğinde, animasyon sonrası renk ayarı temizlenir.

## **Metni Animasyonla**

Metin animasyonunun iki ilgili kontrolü vardır:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textanimation/getbuildtype/) paragraf düzeyinde mi yoksa toplu mu görüneceğini kontrol eder.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getanimatetexttype/) metnin bir kerede, kelime bazında ya da harf bazında görüneceğini kontrol eder. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getdelaybetweentextparts/) kelime ya da harf arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzdesi; negatif bir değer saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek, bir metin kutusundaki kelimeleri animasyonlar. [BuildType::AsOneObject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/buildtype/) paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Paragraf bazlı bir metin kutusu oluşturmak için [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/tr/php-java/aspose.slides/buildtype/) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektiyle hedeflemek için bir [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) kabul eden [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animated Text](/slides/tr/php-java/animated-text/) bölümüne bakın.

## **Dışa Aktarım ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından yönetilir.
- PDF ve sabit görüntüler animasyonları oynatmaz. Çıktı hareket göstermeli ise [HTML5 dışa aktarımı](/slides/tr/php-java/export-to-html5/), animasyonlu GIF veya [video dönüşümü](/slides/tr/php-java/convert-powerpoint-to-video/) kullanın.
- HTML5 için [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimateshapes/) etkinleştirin ve gerektiğinde [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimatetransitions/) kullanın.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini desteklese de her PowerPoint efekti desteklenmez. Güncel [desteklenen animasyonlar ve efektler](/slides/tr/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum biçimlerinden içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video ortamında farklı renderlanabilir. Etki adının kendisine güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünürken PDF’de neden görünmüyor?**

PDF statik bir formattır; bu nedenle animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video olarak farklı nasıl oynatılıyor?**

Video dışa aktarımı, animasyonları render eder; orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez ya da yaklaşık olarak işlenir. Desteklenen‑efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli öne ya da arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şekil z‑order’ı örtüşmeyi kontrol eder, sıra düzeni ve tetikleyiciler animasyon oynatımını belirler. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.