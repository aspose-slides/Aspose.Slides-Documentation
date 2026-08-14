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
description: "تعرف على كيفية إضافة وفحص وتخصيص الرسوم المتحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يمثل الرسوم المتحركة للشرائح كـ Effects في مخطط الزمن للشرائح. كل Effect له شكل مستهدف، نوع الرسوم المتحركة وتحت النوع، مشغّل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

يحتوي مخطط الزمن على نوعين من التسلسلات:

- التسلسل **الرئيسي** يُشغل عندما يتقدم الشريحة.
- التسلسل **التفاعلي** يبدأ عندما يتم النقر على الشكل المشغّل.

نظرًا لأن مربعات النص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة هي أشكال، تستخدم نفس [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) لمعظم محتوى الشريحة. تم سرد التأثيرات المتاحة في فئة [EffectType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشريحة واستدعِ [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) مع الشكل المستهدف، نوع الـ Effect، تحت النوع، والمشغّل. لتأثير يبدأ عندما يُنقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون مشغّله ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المشغّل يتحكم في وقت بدء الـ Effect:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) ينتظر نقرة في التسلسل الرئيسي، أو نقرة على الشكل المشغّل في تسلسل تفاعلي.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) يبدأ مع الـ Effect السابق.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effecttriggertype/) يبدأ عندما ينتهي الـ Effect السابق.

لتحريك صورة أو مخطط أو أي شكل آخر، مرّر ذلك الكائن إلى [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) بدلاً من `$targetShape`. لخيارات تجميع خاصة بالمخططات، راجع [الرسوم المتحركة للرسوم البيانية](/slides/ar/php-java/animated-charts/).

## **قراءة الرسوم المتحركة للأشكال**

استخدم [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/geteffectsbyshape/) عندما تعرف الشكل المستهدف. لتفقد كل Effect، عدّ التسلسل الرئيسي وكل تسلسل تفاعلي. العدّ يمنع الافتراض بأن التسلسل يحتوي على Effect في الفهرس `0`.

المثال التالي ينشئ شكلاً به تأثيرات في التسلسل الرئيسي وتفاعلية، يحصل على الـ Effects التي تستهدف الشكل، ثم يعدّ كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى Effects لشكل واحد، حدد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [Sequence::getEffectsByShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/geteffectsbyshape/). لا تفترض أن [ShapeCollection::get_Item](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/get_item/) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العنصر النائب الموروثة**

يمكن لعنصر نائب في شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل في شريحة التخطيط وشريحة القالب. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) يرجع ذلك العنصر النائب الأصلي، أو `null` إذا لم يكن هناك أصل.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، **Split** في شريحة التخطيط، و**Fly In** في شريحة القالب.

![تأثير حركة التذييل في الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل في شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل في شريحة القالب](master-shape-animation.png)

المثال التالي يستخدم تسلسلًا هرميًا لعناصر نائب من عرض تقديم جديد. يضيف تأثيرات إلى عنصر نائب القالب، عنصر نائب التخطيط، والعنصر النائب المقابل في الشريحة العادية. يتم فحص كل استدعاء لـ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getbaseplaceholder/) قبل استخدام الشكل المرتجع.

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

حوار **Timing** في PowerPoint يطابق خصائص فئة [Timing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/).

![حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يطابق [Timing::getTriggerType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** يطابق [Timing::getDuration](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getduration/)، بالثواني.
- **Delay** يطابق [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/gettriggerdelaytime/)، بالثواني.
- **Repeat** يطابق [Timing::getRepeatCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatcount/)، [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilnextclick/)، أو [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** يطابق [Timing::getRewind](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/getrewind/).

هذا المثال المستقل يضيف Effect، يغيّر توقيته عبر الكائن المرتجع من [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/)، ويحفظ النتيجة. الحفاظ على مرجع [Effect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/) المرتجع يمنع الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضع تكرار واحد فقط بنية. الجمع بين عدد التكرار وعلامة "حتى" قد ينتج عنه نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، عيّن [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatuntilnextclick/) و[Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatuntilendslide/) قبل [Timing::setRepeatCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/timing/setrepeatcount/)، لأن تعيين أيٍ من العلامتين يغيّر وضع التكرار النشط.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة الإشارة إلى صوت مدمج عبر [Effect::getSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/setstopprevioussound/) يطلب من تأثير إيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوت محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يدمج ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/)، لذلك لا يلزم فهرس تسلسل.

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

### **استخراج أصوات التأثير المدمجة**

المثال التالي يتوقع عرضًا محليًا اسمه `presentation-with-animation-sounds.pptx`. يفحص كل من التسلسل الرئيسي والتفاعلي ويكتب كل صوت تأثير مدمج إلى دليل `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي الذي يُظهره [Audio::getContentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audio/getcontenttype/).

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

للكائنات الصوتية الكبيرة، استخدم [Audio::getStream](https://reference.aspose.com/slides/ar/php-java/aspose.slides/audio/getstream/) وانسخ الدفق إلى ملف بدلًا من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم في ما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

فئة [AfterAnimationType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/afteranimationtype/) تدعم ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقرة التالية. عندما يكون النوع هو [AfterAnimationType::Color](https://reference.aspose.com/slides/ar/php-java/aspose.slides/afteranimationtype/)، عيّن أيضًا [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getafteranimationcolor/).

هذا المثال المستقل ينشئ Effect، يضبط سلوكه ما بعد الرسوم المتحركة عبر كائن Effect المرتجع، ويحفظ النتيجة.

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

تحريك النص يحتوي على عنصرين مرتبطين:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textanimation/getbuildtype/) يتحكم فيما إذا كانت الفقرات تظهر معًا أو مستوى الفقرة.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getanimatetexttype/) يتحكم فيما إذا كان النص يظهر دفعة واحدة، كلمة بكلمة، أو حرفًا بحرف. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/effect/getdelaybetweentextparts/) يحدد التأخير بين الكلمات أو الأحرف. القيمة الإيجابية هي نسبة مئوية من مدة الـ Effect؛ القيمة السلبية هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل مربع نص. [BuildType::AsOneObject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/buildtype/) يعطّل بناء الفقرات واحدة تلو الأخرى بحيث ينطبق إعداد الكلمة على الإطار النصي بأكمله.

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

لبناء مربع نص وفقًا للفقرات، عيّن [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/ar/php-java/aspose.slides/buildtype/) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثيرها الخاص، استخدم نسخة [Sequence::addEffect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sequence/addeffect/) التي تقبل [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/). راجع [النص المتحرك](/slides/ar/php-java/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ الملف إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن تشغيله النهائي يتحكم فيه عارض العروض.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [تصدير HTML5](/slides/ar/php-java/export-to-html5/)، GIF متحرك، أو [تحويل إلى فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- بالنسبة إلى HTML5، فعّل [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/html5options/setanimateshapes/) وعند الحاجة [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/html5options/setanimatetransitions/).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول، التأكيد، الخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير في PowerPoint مدعوم. تحقق من جدول [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحفظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض أخرى في الملف ولكنها تُعرض بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا يظهر تأثير الرسوم المتحركة في PowerPoint لكن لا يظهر في PDF؟**

PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب حفظ الحركة.

**لماذا يُعرض تأثير بطريقة مختلفة في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلًا من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو يتم تقريبها. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل يؤدي نقل الشكل للأمام أو الخلف إلى تغيير ترتيب الرسوم المتحركة؟**

لا. يتحكم ترتيب Z للشكل في التراكب، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الرسوم المتحركة. غير مخطط الزمن إذا كنت بحاجة إلى ترتيب تشغيل مختلف.