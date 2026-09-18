---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام PHP
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/php-java/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية إضافة وفحص وتخصيص الرسوم المتحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

للتعامل مع السلوكيات الفردية داخل تأثير أو تحرير مقاطع مسار الحركة، راجع [الرسوم المتحركة المخصصة](/slides/ar/php-java/custom-animation/).

تمثل Aspose.Slides for PHP via Java الرسوم المتحركة للشرائح كـ Effects في مخطط زمني للشفرة. يحتوي Effect على الشكل الهدف، نوع الرسوم المتحركة والفرع، المشغل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

يحتوي المخطط الزمني على نوعين من التسلسلات:

- **التسلسلة الرئيسية** تُشغل عندما تتقدم الشريحة.
- **التسلسلة التفاعلية** تبدأ عندما يتم النقر على الشكل المشغل.

نظرًا لأن مربعات النص والصور والمخططات والجداول وغيرها من كائنات الشريحة هي أشكال، يمكنك استخدام نفس طريقة [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في الفئة [EffectType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسم متحرك، احصل على التسلسل الرئيسي للشريحة واستدعِ [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) مع الشكل الهدف، نوع التأثير، الفرع، والمشغل. بالنسبة لتأثير يبدأ عندما يتم النقر على شكل آخر، أنشئ تسلسلاً تفاعليًا يكون مشغله ذلك الشكل الآخر.

المثال التالي يُنشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة في `shape-animations.pptx`.

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

المشغل يتحكم بموعد بدء التأثير:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) ينتظر النقر في التسلسل الرئيسي، أو النقر على الشكل المشغل في التسلسل التفاعلي.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) يبدأ مع التأثير السابق.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو نوع شكل آخر، مرّر ذلك الكائن إلى [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) بدلاً من `$targetShape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [الرسوم المتحركة للمخططات](/slides/ar/php-java/animated-charts/).

## **قراءة رسوم متحركة للأشكال**

استخدم [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/geteffectsbyshape/) عندما تعرف الشكل الهدف. لاستعراض كل تأثير، قم بتعداد التسلسل الرئيسي وكل تسلسل تفاعلي. يضمن التعداد عدم الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي يُنشئ شكلاً به تأثيرات تسلسل رئيسي وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدد كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/geteffectsbyshape/). لا تفترض أن [ShapeCollection::get_Item](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/get_item/) في الفهرس `0` هو دائمًا الكائن المقصود.

## **التعامل مع تأثيرات العناصر النائبة الموروثة**

يمكن للعنصر النائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط والشريحة الرئيسة. تُعيد [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) ذلك العنصر النائب الأب، أو `null` عندما لا يكون هناك أب.

في عرض الشرائح المثال التالي، يحتوي التذييل على **Random Bars** على الشريحة العادية، **Split** على شريحة التخطيط، و**Fly In** على الشريحة الرئيسة.

![تأثير الرسوم المتحركة للتذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير الرسوم المتحركة للعنصر النائب في التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير الرسوم المتحركة للعنصر النائب في التذييل على الشريحة الرئيسة](master-shape-animation.png)

المثال التالي يستخدم هيكلية عناصر نائبة من عرض تقديمي جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب تخطيط، والعنصر النائب المقابل على شريحة عادية. يتم فحص كل استدعاء لـ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) قبل استخدام الشكل المرتجع.

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

## **تغيير توقيت الرسوم المتحركة**

يتطابق مربع حوار PowerPoint **Timing** مع خصائص [Timing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/).

![مربع حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يتطابق مع [Timing::getTriggerType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** يتطابق مع [Timing::getDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getduration/)، بالثواني.
- **Delay** يتطابق مع [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/gettriggerdelaytime/)، بالثواني.
- **Repeat** يتطابق مع [Timing::getRepeatCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatcount/)، [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilnextclick/)، أو [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** يتطابق مع [Timing::getRewind](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrewind/).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المرتجع من [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/)، ويحفظ النتيجة. إن الحفاظ على مرجع [Effect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/) المرتجع يجنب الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضعية تكرار واحدة فقط. الجمع بين عدد التكرارات وعلم “until” قد ينتج عنه نتائج مربكة في عارضات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatuntilnextclick/) و[Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatuntilendslide/) قبل [Timing::setRepeatCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatcount/)، لأن ضبط أي علم يغير وضعية التكرار النشطة.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة الإشارة إلى صوت مدمج عبر [Effect::getSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getsound/). يُخبر [Effect::setStopPreviousSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/setstopprevioussound/) التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوت محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يدمج ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/)، لذا لا يحتاج إلى فهرس تسلسل.

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

### **استخراج أصوات التأثيرات المدمجة**

المثال التالي يتوقع عرض تقديمي محلي اسمه `presentation-with-animation-sounds.pptx`. يقوم بمسح كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت تأثير مدمج إلى دليل `extracted-animation-sounds`. يتم اختيار الامتداد بناءً على نوع MIME الصوتي الذي تُعيده [Audio::getContentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audio/getcontenttype/).

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

للكائنات الصوتية الكبيرة، استخدم [Audio::getStream](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audio/getstream/) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل في مصفوفة بايت.

## **تعيين سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم بما يحدث للشكل بعد انتهاء تأثيره.

![مربع حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

تدعم فئة [AfterAnimationType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/afteranimationtype/) ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقر التالي. عندما يكون النوع [AfterAnimationType::Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/afteranimationtype/)، اضبط أيضًا [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getafteranimationcolor/).

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوك ما بعد الرسوم المتحركة عبر كائن التأثير المرتجع، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType::Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/afteranimationtype/) يمسح إعداد لون ما بعد الرسوم المتحركة.

## **تحريك النص**

لتحريك النص تحكمان مرتبطان:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textanimation/getbuildtype/) يتحكم فيما إذا كانت الفقرات تظهر معًا أو بحسب مستوى الفقرة.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getanimatetexttype/) يتحكم فيما إذا كان النص يظهر دفعة واحدة، بالكلمة، أو بالحرف. تُحدد [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getdelaybetweentextparts/) الفاصل الزمني بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل مربع نص. يوقف [BuildType::AsOneObject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/buildtype/) بناء الفقرة‑بفقرة بحيث يُطبق إعداد الكلمة على كامل إطار النص.

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

لبناء مربع نص بحسب الفقرة، اضبط [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ar/php-java/aspose.slides/buildtype/) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص بها، استخدم نسخة [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) التي تقبل [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/). راجع [النص المتحرك](/slides/ar/php-java/animated-text/) لأمثلة على مستوى الفقرة.

## **تصدير وملاحظات التوافق**

- حفظ إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن تشغيله النهائي يتحكم فيه عارض العرض.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [تصدير HTML5](/slides/ar/php-java/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/php-java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- لـ HTML5، فعل [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/html5options/setanimateshapes/) وعند الحاجة [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/html5options/setanimatetransitions/).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول والتأكيد والخروج ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف ولكن تُظهر بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا يظهر تأثير في PowerPoint لكنه غير موجود في PDF؟**

PDF تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُعرض تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلاً من حفظ سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو يتم تقريبها. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام في الإنتاج.

**هل تغيير ترتيب الشكل إلى أمام أو خلف يؤثر على ترتيب الرسوم المتحركة؟**

لا. يتحكم ترتيب Z للأشكال في التراكب، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الرسوم المتحركة. غيّر المخطط الزمني إذا كنت تحتاج ترتيب تشغيل مختلف.