---
title: ใช้การเคลื่อนไหวรูปทรงในงานนำเสนอด้วย PHP
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/php-java/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- ดึงการเคลื่อนไหว
- เพิ่มเอฟเฟ็กต์
- รับเอฟเฟ็กต์
- ดึงเอฟเฟ็กต์
- เสียงของเอฟเฟ็กต์
- ประยุกต์ใช้การเคลื่อนไหว
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปทรง, การตั้งเวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์หนึ่งมีรูปทรงเป้าหมาย, ชนิดและประเภทย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์มีลำดับสองประเภท:

- **ลำดับหลัก** เล่นเมื่อสไลด์เดินหน้า
- **ลำดับโต้ตอบ** เริ่มเมื่อรูปทรงตัวกระตุ้นถูกคลิก

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตารางและวัตถุสไลด์อื่น ๆ เป็นรูปทรง คุณจึงใช้เมธอด [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) เดียวกันสำหรับเนื้อหาในสไลด์ส่วนใหญ่ เอฟเฟกต์ที่ใช้ได้ถูกระบุในคลาส [EffectType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttype/)

## **เพิ่มการเคลื่อนไหวรูปทรง**

เพื่อเพิ่มการเคลื่อนไหว ให้ดึงลำดับหลักของสไลด์และเรียก [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) พร้อมกับรูปทรงเป้าหมาย, ชนิดเอฟเฟกต์, ประเภทย่อยและตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปทรงอื่นถูกคลิก ให้สร้างลำดับโต้ตอบที่ตัวกระตุ้นคือรูปทรงนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์จะเริ่มเมื่อใด:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) รอการคลิกในลำดับหลัก หรือการคลิกบนรูปทรงตัวกระตุ้นในลำดับโต้ตอบ
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบ

เพื่อเคลื่อนไหวรูปภาพ, แผนภูมิ หรือรูปทรงประเภทอื่น ให้ส่งออบเจ็กต์นั้นไปยัง [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) แทน `$targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/php-java/animated-charts/)

## **อ่านการเคลื่อนไหวรูปทรง**

ใช้ [Sequence::getEffectsByShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/geteffectsbyshape/) เมื่อคุณทราบรูปทรงเป้าหมาย เพื่อดูทุกเอฟเฟกต์ ให้วนลูปผ่านลำดับหลักและลำดับโต้ตอบทั้งหมด การวนลูปหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ตำแหน่ง `0`

ตัวอย่างต่อไปนี้สร้างรูปทรงที่มีเอฟเฟกต์ในลำดับหลักและโต้ตอบ, ดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปทรุงนั้น, แล้ววนลูปทุกลำดับบนสไลด์

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปทรงเดียว ให้ระบุตัวรูปทรงด้วยชื่อ, ชนิด placeholder, หรือคุณสมบัติที่คงที่อื่น ๆ; แล้วเรียก [Sequence::getEffectsByShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/geteffectsbyshape/) อย่าสันนิษฐานว่า [ShapeCollection::get_Item](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/get_item/) ที่ตำแหน่ง `0` เป็นออบเจ็กต์ที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอด**

placeholder บนสไลด์ปกติเสริมพฤติกรรมการเคลื่อนไหวจาก placeholder ที่สอดคล้องบนสไลด์เลเอาต์และมาสเตอร์ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) คืนค่า placeholder พ่อแม่ หรือ `null` หากไม่มีพ่อแม่

ในตัวอย่างพรีเซนเทชันต่อไป, ส่วนท้าย (footer) มี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลเอาต์, และ **Fly In** บนสไลด์มาสเตอร์

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์เลเอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของ placeholder ส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปนี้ใช้ลำดับ hierarchy ของ placeholder จากพรีเซนเทชันใหม่ เพิ่มเอฟเฟกต์ให้กับ placeholder ของมาสเตอร์, placeholder ของเลเอาต์, และ placeholder ที่สอดคล้องบนสไลด์ปกติ ทุกการเรียก [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) จะตรวจสอบก่อนนำ shape ที่คืนค่ามาใช้

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

## **เปลี่ยนการตั้งค่าเวลาเคลื่อนไหว**

กล่องโต้ตอบ **Timing** ของ PowerPoint แมพไปยังคุณสมบัติของ [Timing](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/)

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **Start** แมพไปยัง [Timing::getTriggerType](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/gettriggertype/)
- **Duration** แมพไปยัง [Timing::getDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getduration/) หน่วยเป็นวินาที
- **Delay** แมพไปยัง [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/gettriggerdelaytime/) หน่วยเป็นวินาที
- **Repeat** แมพไปยัง [Timing::getRepeatCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilnextclick/) หรือ [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilendslide/)
- **Rewind when done playing** แมพไปยัง [Timing::getRewind](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrewind/)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, เปลี่ยนเวลาผ่านออบเจ็กต์ที่คืนจาก [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/), แล้วบันทึกผลลัพธ์ การเก็บอ้างอิง [Effect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/) ที่คืนมาช่วยหลีกเลี่ยงการอ้างอิงตำแหน่งคอลเลกชันที่ไม่จำเป็น

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

ใช้โหมดการทำซ้ำหนึ่งแบบเท่านั้น การผสมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมอ่านต่าง ๆ เมื่อเปลี่ยนโหมดการทำซ้ำ ให้ตั้งค่า [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatuntilnextclick/) และ [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatuntilendslide/) ก่อน [Timing::setRepeatCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatcount/) เนื่องจากการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งาน

## **เพิ่มและดึงเสียงการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงเสียงที่ฝังไว้ผ่าน [Effect::getSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getsound/) [Effect::setStopPreviousSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/setstopprevioussound/) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่ามีไฟล์เสียงโลคัลชื่อ `animation-sound.wav` สร้างเอฟเฟกต์สองรายการ ฝังไฟล์เป็นเสียงสำหรับเอฟเฟกต์แรกและตั้งค่าให้เอฟเฟกต์ที่สองหยุดเสียง ใช้ออบเจ็กต์ที่คืนจาก [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) ดังนั้นไม่ต้องระบุตำแหน่งลำดับ

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

### **ดึงเสียงเอฟเฟกต์ที่ฝังไว้**

ตัวอย่างต่อไปนี้คาดว่ามีพรีเซนเทชันโลคัลชื่อ `presentation-with-animation-sounds.pptx` มันสแกนลำดับหลักและโต้ตอบทั้งหมดและบันทึกเสียงเอฟเฟกต์ที่ฝังไว้ทุกไฟล์ลงในโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์เลือกจาก MIME type ของเสียงที่ให้โดย [Audio::getContentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/audio/getcontenttype/)

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

สำหรับออบเจ็กต์เสียงขนาดใหญ่ ให้ใช้ [Audio::getStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/audio/getstream/) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจ็กต์ทั้งหมดเข้าสู่ byte array

## **ตั้งค่าพฤติกรรมหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมว่ารูปทรงจะทำอย่างไรหลังจากเอฟเฟกต์จบ

![กล่องโต้ตอบตัวเลือกเอฟเฟกต์ของ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/) รองรับการคงรูปทรงเดิม, เปลี่ยนสี, ซ่อนหลังการเคลื่อนไหว, หรือซ่อนเมื่อคลิกครั้งต่อไป เมื่อประเภทเป็น [AfterAnimationType::Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/) ให้ตั้งค่า [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getafteranimationcolor/) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านออบเจ็กต์เอฟเฟกต์ที่คืนมา, แล้วบันทึกผลลัพธ์

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

การเปลี่ยนประเภทออกจาก [AfterAnimationType::Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/) จะล้างการตั้งค่าสีหลังการเคลื่อนไหว

## **เคลื่อนไหวข้อความ**

การเคลื่อนไหวข้อความมีการควบคุมสองส่วนที่เกี่ยวข้อง:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textanimation/getbuildtype/) ควบคุมว่าพารากราฟปรากฏพร้อมกันหรือระดับพารากราฟ
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getanimatetexttype/) ควบคุมว่าข้อความปรากฏทั้งหมด, คำต่อคำ, หรืออักษรต่ออักษร [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getdelaybetweentextparts/) ตั้งค่าการหน่วงเวลาระหว่างคำหรืออักษร ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าลบเป็นการหน่วงเวลาเป็นวินาที

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType::AsOneObject](https://reference.aspose.com/slides/th/php-java/aspose.slides/buildtype/) ปิดการสร้างตามพารากราฟเพื่อให้การตั้งค่าคำใช้กับกรอบข้อความทั้งหมด

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

เพื่อสร้างกล่องข้อความตามพารากราฟ ให้ตั้งค่า [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/th/php-java/aspose.slides/buildtype/) (หรือระดับพารากราฟอื่น) เพื่อให้พารากราฟเดี่ยวมีเอฟเฟกต์ของตนเอง ใช้โอเวอร์โหลดของ [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) ที่รับ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) ดูที่ [Animated Text](/slides/th/php-java/animated-text/) เพื่อดูตัวอย่างระดับพารากราฟ

## **การส่งออกและหมายเหตุเกี่ยวกับความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX รักษาโมเดลการเคลื่อนไหว แต่การเล่นสุดท้ายถูกควบคุมโดยโปรแกรมอ่านพรีเซนเทชัน
- PDF และรูปภาพคงที่ไม่เล่นการเคลื่อนไหว ใช้ [HTML5 export](/slides/th/php-java/export-to-html5/), GIF เคลื่อนไหว, หรือ [video conversion](/slides/th/php-java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- สำหรับ HTML5 ให้เปิดใช้งาน [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimateshapes/) และหากต้องการ [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimatetransitions/)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์การเข้าตา, เน้น, ออกจาก, และเส้นทางการเคลื่อนไหวทั่วไปหลายประเภท แต่ไม่รองรับเอฟเฟกต์ PowerPoint ทุกประเภท ตรวจสอบ [supported animations and effects](/slides/th/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบพรีเซนเทชันสำคัญกับเวอร์ชัน Aspose.Slides ที่คุณใช้
- เอฟเฟกต์ที่กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบพรีเซนเทชันอื่นอาจถูกเก็บไว้ในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลการส่งออกแทนการพึ่งพาชื่อเอฟเฟกต์อย่างเดียว

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวจึงแสดงใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและการเปลี่ยนสไลด์จะไม่เล่น ส่งออกเป็น HTML5, GIF เคลื่อนไหว, หรือวิดีโอเมื่อจำเป็นต้องรักษาการเคลื่อนไหว

**ทำไมเอฟเฟกต์จึงเล่นต่างกันในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงไม่ได้รับการสนับสนุนหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบพรีเซนเทชันจริงก่อนการใช้งานจริง

**การย้ายรูปทรงไปข้างหน้าหรือข้างหลังจะเปลี่ยนลำดับการเคลื่อนไหวหรือไม่?**

ไม่ การจัดลำดับ z‑order ของรูปทรงควบคุมการทับซ้อน ส่วนลำดับและตัวกระตุ้นของลำดับควบคุมการเล่นการเคลื่อนไหว ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่ต่างออกไป