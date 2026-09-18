---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از PHP
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/php-java/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های متحرک را با Aspose.Slides برای PHP از طریق Java اضافه، بررسی و سفارشی‌سازی کنید."
---
## **نمای کلی**

برای کار با رفتارهای فردی داخل یک اثر یا ویرایش بخش‌های مسیر حرکتی، به [انیمیشن سفارشی](/slides/fa/php-java/custom-animation/) مراجعه کنید.

Aspose.Slides for PHP via Java انیمیشن‌های اسلاید را به‌عنوان اثرها در جدول زمانی اسلاید نشان می‌دهد. یک اثر دارای شکل هدف، نوع و زیرنوع انیمیشن، محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشروی اسلاید اجرا می‌شود.
- **دنباله تعاملی** زمانی شروع می‌شود که شکل محرک آن کلیک شود.

چون جعبه‌های متن، تصویرها، نمودارها، جدول‌ها و سایر اشیای اسلاید همگی شکل هستند، برای اکثر محتویات اسلاید از همان متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) استفاده می‌کنید. اثرهای موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن به شکل‌ها**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کرده و متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) را با شکل هدف، نوع اثر، زیرنوع و محرک صدا بزنید. برای اثری که هنگام کلیک بر شکل دیگری شروع می‌شود، یک دنباله تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد کرده و نتیجه را در `shape-animations.pptx` ذخیره می‌کند.

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

محرک تعیین می‌کند اثر چه زمانی آغاز شود:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) در دنباله اصلی منتظر کلیک می‌ماند یا در دنباله تعاملی منتظر کلیک روی شکل محرک است.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) همراه با اثر قبلی آغاز می‌شود.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) پس از پایان اثر قبلی شروع می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگر، به‌جای `$targetShape` همان شیء را به متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، به [نمودارهای انیمیشنی](/slides/fa/php-java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

زمانی که شکل هدف را می‌دانید، از [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/geteffectsbyshape/) استفاده کنید. برای بررسی تمام اثرها، دنباله اصلی و هر دنباله تعاملی را پیمایش کنید. پیمایش از این‌رو از فرض وجود اثر در ایندکس `0` جلوگیری می‌کند.

مثال زیر یک شکل با اثرهای دنباله اصلی و تعاملی ایجاد می‌کند، اثرهای هدف‌دار به شکل را می‌گیرد و سپس تمام دنباله‌های اسلاید را پیمایش می‌کند.

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

اگر فقط به اثرهای یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع جای‌دار یا ویژگی ثابت دیگری شناسایی کنید؛ سپس متد [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/geteffectsbyshape/) را صدا بزنید. فرض نکنید که [ShapeCollection::get_Item](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/get_item/) در ایندکس `0` همیشه شیء موردنظر است.

## **کار با اثرهای جای‌دار ارث‌بری‌شده**

یک جای‌دار در اسلاید معمولی می‌تواند رفتار انیمیشن را از جای‌دار متناظر در اسلاید طرح‌بندی و اسلاید مستر به ارث ببرد. متد [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) آن جای‌دار والد را باز می‌گرداند یا `null` اگر والد وجود نداشته باشد.

در ارائه مثال زیر، پاورقی بر اسلاید معمولی دارای **نوارهای تصادفی**، بر اسلاید طرح‌بندی دارای **تقسیم** و بر اسلاید مستر دارای **پرواز به داخل** است.

![اثر انیمیشن فوتر در اسلاید معمولی](slide-shape-animation.png)

![اثر انیمیشن فوتر در اسلاید طرح‌بندی](layout-shape-animation.png)

![اثر انیمیشن فوتر در اسلاید مستر](master-shape-animation.png)

مثال بعدی از یک سلسله مراتب جای‌دار در یک ارائه جدید استفاده می‌کند. اثرها به جای‌دار مستر، جای‌دار طرح‌بندی و جای‌دار متناظر در اسلاید معمولی اضافه می‌شود. قبل از استفاده از شکل بازگشتی، هر بار متد [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

دیالوگ **Timing** در پاورپوینت به خواص [Timing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/) نقشه می‌شود.

![دیالوگ Timing در پاورپوینت برای یک اثر انیمیشن](shape-animation.png)

- **Start** به [Timing::getTriggerType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/gettriggertype/) نقشه می‌شود.
- **Duration** به [Timing::getDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getduration/) (ثانیه) نقشه می‌شود.
- **Delay** به [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/gettriggerdelaytime/) (ثانیه) نقشه می‌شود.
- **Repeat** به [Timing::getRepeatCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatcount/)، [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilnextclick/) یا [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilendslide/) نقشه می‌شود.
- **Rewind when done playing** به [Timing::getRewind](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrewind/) نقشه می‌شود.

این مثال مستقل یک اثر را اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده‌شده توسط [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگهداری مرجع بازگردانده‌شدهٔ [Effect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/) از یک ایندکس مجموعه غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت عمدی استفاده کنید. ترکیب تعداد تکرار با پرچم «until» می‌تواند نتایج مبهمی در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatuntilnextclick/) و [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatuntilendslide/) را تنظیم کنید و سپس [Timing::setRepeatCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatcount/) را صدا بزنید، چرا که تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک اثر انیمیشن می‌تواند به صداهای توکار از طریق [Effect::getSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getsound/) ارجاع دهد. متد [Effect::setStopPreviousSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/setstopprevioussound/) به یک اثر می‌گوید صداهای شروع‌شده توسط اثر قبلی را متوقف کند.

### **افزودن صدا به یک اثر**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` موجود باشد. دو اثر ایجاد می‌کند، آن فایل را به عنوان صدای اثر اول تعبیه می‌کند و اثر دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیائی که توسط [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) بازگردانده می‌شوند استفاده می‌شود، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای توکار اثر**

مثال زیر انتظار دارد ارائه‌ای محلی به نام `presentation-with-animation-sounds.pptx` وجود داشته باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و هر صدای توکار اثر را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند از نوع MIME صوتی که توسط [Audio::getContentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audio/getcontenttype/) در دسترس است، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio::getStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کامل شیء در آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان اثر چه اتفاقی برای شکل می‌افتد.

![دیالوگ گزینه‌های اثر در پاورپوینت نشان‌دهنده تنظیمات After animation](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/) حمایت می‌کند از باقی‌ماندن شکل بدون تغییر، تغییر رنگ، مخفی شدن پس از انیمیشن یا مخفی شدن در کلیک بعدی. وقتی نوع برابر با [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/) باشد، همچنین [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getafteranimationcolor/) را تنظیم کنید.

این مثال مستقل یک اثر می‌سازد، رفتار پس از انیمیشن را از طریق شیء اثر بازگردانده تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textanimation/getbuildtype/) تعیین می‌کند پاراگراف‌ها به‌صورت گروهی یا به‌صورت سطح پاراگراف ظاهر شوند.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getanimatetexttype/) تعیین می‌کند متن به‌صورت یک‌باره، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. متد [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getdelaybetweentextparts/) تأخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تأخیری بر حسب ثانیه.

مثال مستقل زیر کلمات یک جعبه متن را انیمیشن می‌دهد. [BuildType::AsOneObject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/buildtype/) ساخت پاراگراف به‌پارگراف را غیرفعال می‌کند تا تنظیم کلمه برای کل فریم متن اعمال شود.

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

برای ساخت جعبه متن به‌صورت پاراگراف، [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fa/php-java/aspose.slides/buildtype/) (یا سطح پاراگراف دیگر) را تنظیم کنید. برای هدف‌گیری یک پاراگراف منفرد با اثر مخصوص خود، از اورلود متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) که یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) می‌پذیرد، استفاده کنید. برای مثال‌های سطح پاراگراف به [متن انیمیشنی](/slides/fa/php-java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره به قالب PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را اجرا نمی‌کنند. هنگام نیاز به نمایش حرکت، از [صادرات به HTML5](/slides/fa/php-java/export-to-html5/)، GIFهای متحرک یا [تبدیل به ویدیو](/slides/fa/php-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، متد [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimateshapes/) را فعال کنید و در صورت نیاز، [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimatetransitions/) را نیز تنظیم نمایید.
- رندر ویدیو از بسیاری از اثرهای ورود، تأکید، خروج و مسیر حرکتی رایج پشتیبانی می‌کند، اما همهٔ اثرهای PowerPoint پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و اثرهای پشتیبانی‌شده](/slides/fa/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های حیاتی را با نسخه Aspose.Slides هدف خود تست کنید.
- اثرهای سفارشی پیشرفته و اثرهایی که از فرمت‌های ارائه دیگر وارد شده‌اند ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. نتیجهٔ صادرشده را اعتبارسنجی کنید نه فقط بر اساس نام اثر.

## **سوالات متداول**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. هنگام نیاز به حفظ حرکت، به HTML5، GIF متحرک یا ویدیو خروجی بدهید.

**چرا یک اثر در ویدیو به‌صورت متفاوتی اجرا می‌شود؟**

صادرات ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی اثرهای پیشرفته پشتیبانی نشده یا به‌صورت تخمینی اجرا می‌شوند. جدول اثرهای پشتیبانی‌شده را مرور کنید و پیش از استفاده در تولید، ارائه واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب لایه (z-order) شکل فقط کنترل همپوشانی را دارد، در حالی که ترتیب دنباله و محرک‌ها کنترل پخش انیمیشن را دارند. اگر به ترتیب پخش متفاوتی نیاز دارید، جدول زمانی را تغییر دهید.