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
- صدا اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های متحرک را با Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java انیمیشن‌های اسلاید را به‌صورت افکت‌ها در جدول زمانی اسلاید نمایش می‌دهد. هر افکت دارای شکل هدف، نوع و زیرنوع انیمیشن، محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری نظیر صدا یا رفتار پس از انیمیشن است.

جدول زمانی شامل دو نوع توالی است:

- **توالی اصلی** هنگام پیشرفت اسلاید پخش می‌شود.
- **توالی تعاملی** زمانی که شکل محرک‌اش کلیک شود، آغاز می‌گردد.

چون جعبه‌های متن، تصویرها، نمودارها، جدول‌ها و سایر اشیاء اسلاید همه به‌عنوان شکل محسوب می‌شوند، برای اکثر محتوای اسلاید از همان روش [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) استفاده می‌کنید. افکت‌های قابل استفاده در کلاس [EffectType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن به شکل‌ها**

برای افزودن انیمیشن، توالی اصلی اسلاید را دریافت کنید و با استفاده از [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) شکل هدف، نوع افکت، زیرنوع و محرک را مشخص کنید. برای افکتی که با کلیک روی شکل دیگر شروع می‌شود، یک توالی تعاملی ایجاد کنید که محرکش همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در فایل `shape-animations.pptx` ذخیره می‌سازد.

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

محرک تعیین می‌کند افکت چه زمانی آغاز شود:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) در توالی اصلی به‌دنبال کلیک یا در توالی تعاملی به‌دنبال کلیک روی شکل محرک انتظار می‌کشد.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) همزمان با افکت قبلی شروع می‌شود.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effecttriggertype/) پس از پایان افکت قبلی آغاز می‌گردد.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به‌جای `$targetShape` همان شیء را به [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) پاس بدهید. برای گزینه‌های گروه‌بندی خاص نمودار، به بخش [Animated Charts](/slides/fa/php-java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

زمانی که شکل هدف را می‌دانید، از [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/geteffectsbyshape/) استفاده کنید. برای بررسی هر افکت، توالی اصلی و تمام توالی‌های تعاملی را پیمایش کنید. پیمایش از این‌جهت انجام می‌شود که فرض نکنید توالی حتماً افکتی در اندیس `0` دارد.

مثال زیر یک شکل با افکت‌های توالی اصلی و تعاملی ایجاد می‌کند، افکت‌های هدفش را دریافت می‌کند و سپس همه توالی‌های اسلاید را پیمایش می‌نماید.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع نگه‌دارنده یا ویژگی پایدار دیگری شناسایی کنید؛ سپس [Sequence::getEffectsByShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/geteffectsbyshape/) را فراخوانی کنید. فرض نکنید که [ShapeCollection::get_Item](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/get_item/) در اندیس `0` همیشه شیء موردنظر است.

## **کار با افکت‌های نگه‌دارنده ارث‌برده‌شده**

یک نگه‌دارنده در اسلاید عادی می‌تواند رفتار انیمیشن را از نگه‌دارنده متناظر در اسلاید طرح‌بندی و اسلاید اصلی به‌ارث ببرد. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) همان نگه‌دارنده والد را برمی‌گرداند یا `null` وقتی والد وجود ندارد.

در ارائهٔ نمونهٔ زیر، پاورقی دارای **Random Bars** در اسلاید عادی، **Split** در اسلاید طرح‌بندی و **Fly In** در اسلاید اصلی است.

![پیشنویس انیمیشن پاورقی در اسلاید عادی](slide-shape-animation.png)

![پیشنویس انیمیشن پاورقی در اسلاید طرح‌بندی](layout-shape-animation.png)

![پیشنویس انیمیشن پاورقی در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از سلسله‌مراتب نگه‌دارنده‌ها در یک ارائهٔ جدید استفاده می‌کند. افکت‌ها را به یک نگه‌دارندهٔ اصلی، یک نگه‌دارندهٔ طرح‌بندی و نگه‌دارندهٔ متناظر در اسلاید عادی اضافه می‌کند. هر بار قبل از استفاده از شیء بازگشت‌شده، وجود آن با [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) بررسی می‌شود.

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

پنجرهٔ **Timing** در PowerPoint به ویژگی‌های [Timing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/) نگاشته می‌شود.

![پنجره زمان‌بندی PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [Timing::getTriggerType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/gettriggertype/) نگاشت می‌شود.
- **Duration** به [Timing::getDuration](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getduration/) (ثانیه) نگاشت می‌شود.
- **Delay** به [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/gettriggerdelaytime/) (ثانیه) نگاشت می‌شود.
- **Repeat** به [Timing::getRepeatCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatcount/)، [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilnextclick/) یا [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrepeatuntilendslide/) نگاشت می‌شود.
- **Rewind when done playing** به [Timing::getRewind](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/getrewind/) نگاشت می‌شود.

این مثال مستقل یک افکت افزود، زمان‌بندی آن را از طریق شیء برگردانده‌شده توسط [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) تغییر داد و نتیجه را ذخیره کرد. نگه داشتن مرجع [Effect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/) بازگشت‌شده از ایجاد یک شاخص مجموعهٔ غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت عمدی استفاده کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند نتایج گیج‌کننده‌ای در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatuntilnextclick/) و [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatuntilendslide/) را تنظیم کنید و سپس [Timing::setRepeatCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/timing/setrepeatcount/) را صدا بزنید، زیرا تنظیم هرکدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صداهای جاسازی‌شده را از طریق [Effect::getSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getsound/) ارجاع دهد. [Effect::setStopPreviousSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/setstopprevioussound/) به افکتی می‌گوید صداهای شروع‌شده توسط افکت‌های قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایل صوتی محلی با نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، آن فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و دومین افکت را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیاء بازگشت‌شده توسط [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) استفاده می‌کند، بنابراین نیازی به اندیس توالی نیست.

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

### **استخراج صداهای افکت جاسازی‌شده**

مثال زیر انتظار دارد ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` وجود داشته باشد. توالی‌های اصلی و تعاملی را اسکن می‌کند و هر صداهای افکت جاسازی‌شده را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند بر اساس MIME type صوتی که توسط [Audio::getContentType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audio/getcontenttype/) ارائه می‌شود، انتخاب می‌شود.

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

برای اشیاء صوتی بزرگ، از [Audio::getStream](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای اینکه کل شیء را در یک آرایه بایت بارگذاری کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** مشخص می‌کند پس از پایان افکت چه اتفاقی برای شکل بیفتد.

![پنجره گزینه‌های افکت PowerPoint که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/) از باقی‌ماندهٔ شکل بدون تغییر، تغییر رنگ، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی پشتیبانی می‌کند. وقتی نوع برابر با [AfterAnimationType::Color](https://reference.aspose.com/slides/fa/php-java/aspose.slides/afteranimationtype/) باشد، باید [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getafteranimationcolor/) نیز تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن را از طریق شیء افکت بازگردانده تنظیم می‌کند و نتیجه را ذخیره می‌سازد.

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

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textanimation/getbuildtype/) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌سطح پاراگراف ظاهر شوند.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getanimatetexttype/) تعیین می‌کند متن به‌صورت یکجا، به‌واحد کلمه یا به‌واحد حرف ظاهر شود. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/effect/getdelaybetweentextparts/) تأخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تأخیر بر حسب ثانیه محسوب می‌شود.

مثال مستقل زیر کلمات یک جعبهٔ متن را انیمیشن می‌دهد. [BuildType::AsOneObject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/buildtype/) ساخت پاراگراف به‌پاراگراف را غیرفعال می‌کند تا تنظیم کلمه روی تمام فریم متن اعمال شود.

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

برای ساخت جعبهٔ متن بر پایهٔ پاراگراف، [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/fa/php-java/aspose.slides/buildtype/) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف منفرد با افکت خاص، از overload متد [Sequence::addEffect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sequence/addeffect/) که یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) می‌پذیرد، استفاده کنید. برای مثال‌های سطح پاراگراف به بخش [Animated Text](/slides/fa/php-java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره به‌صورت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط مشاهده‌کنندهٔ ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن پخش نمی‌کنند. برای نمایش حرکت، از [HTML5 export](/slides/fa/php-java/export-to-html5/)، GIF متحرک یا [تبدیل به ویدیو](/slides/fa/php-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimateshapes/) را فعال کنید و در صورت نیاز [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimatetransitions/) را نیز تنظیم کنید.
- رندر ویدیو بسیاری از افکت‌های ورودی، تأکید، خروج و مسیر حرکتی را پشتیبانی می‌کند، اما تمام افکت‌های PowerPoint پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های مهم را با نسخهٔ هدف Aspose.Slides خود آزمایش کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های واردشده از قالب‌های دیگر ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوت رندر شوند. نتیجهٔ صادرات را اعتبارسنجی کنید نه فقط بر اساس نام افکت.

## **سؤالات متداول**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال اسلاید اجرا نمی‌شوند. برای حفظ حرکت، به HTML5، GIF متحرک یا ویدیو خروجی دهید.

**چرا یک افکت در ویدیو به‌طور متفاوتی پخش می‌شود؟**

در خروجی ویدیو، انیمیشن‌ها رندر می‌شوند نه اینکه رفتار اصلی PowerPoint ذخیره شود. برخی افکت‌های پیشرفته پشتیبانی یا تقریباً شبیه‌سازی می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و ارائهٔ واقعی را قبل از استفادهٔ تولیدی تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب لایهٔ Z شکل فقط همپوشانی را کنترل می‌کند، در حالی که ترتیب توالی و محرک‌ها ترتیب پخش انیمیشن را تعیین می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، جدول زمانی را تغییر دهید.