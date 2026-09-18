---
title: นำการเคลื่อนไหวของรูปร่างไปใช้ในงานนำเสนอด้วย PHP
linktitle: การเคลื่อนไหวของรูปร่าง
type: docs
weight: 60
url: /th/php-java/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปร่างที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงของเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปร่าง, เวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว และข้อความที่เคลื่อนไหวด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

หากต้องการทำงานกับพฤติกรรมแต่ละอย่างภายในเอฟเฟกต์หรือแก้ไขส่วนของเส้นทางการเคลื่อนที่ ให้ดูที่ [การเคลื่อนไหวแบบกำหนดเอง](/slides/th/php-java/custom-animation/)  

Aspose.Slides for PHP via Java แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์ เอฟเฟกต์มีรูปร่างเป้าหมาย ประเภทและชนิดย่อยของการเคลื่อนไหว ตัวกระตุ้น การตั้งค่าเวลา และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว  

ไทม์ไลน์ประกอบด้วยลำดับสองประเภท:

- **ลำดับหลัก** จะเล่นเมื่อสไลด์ก้าวหน้า
- **ลำดับโต้ตอบ** จะเริ่มเมื่อรูปร่างตัวกระตุ้นถูกคลิก  

เนื่องจากกล่องข้อความ รูปภาพ แผนภูมิ ตาราง และออบเจกต์สไลด์อื่น ๆ เป็นรูปร่าง คุณจึงใช้เมธอด [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) เดียวกันสำหรับเนื้อหาสไลด์ส่วนใหญ่ เอฟเฟกต์ที่มีให้จะถูกแสดงในคลาส [EffectType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttype/)  

## **เพิ่มการเคลื่อนไหวของรูปร่าง**

เพื่อเพิ่มการเคลื่อนไหว ให้รับลำดับหลักของสไลด์และเรียกเมธอด [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) พร้อมด้วยรูปร่างเป้าหมาย ประเภทเอฟเฟกต์ ชนิดย่อยและตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อรูปร่างอื่นถูกคลิก ให้สร้างลำดับโต้ตอบที่ตัวกระตุ้นคือรูปร่างอื่นนั้น  

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`  

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

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) รอการคลิกในลำดับหลัก หรือรอการคลิกบนรูปร่างตัวกระตุ้นในลำดับโต้ตอบ
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttriggertype/) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าสิ้นสุด  

เพื่อเคลื่อนไหวรูปภาพ แผนภูมิ หรือรูปร่างประเภทอื่น ให้ส่งออบเจกต์นั้นไปยัง [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) แทน `$targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ให้ดูที่ [Animated Charts](/slides/th/php-java/animated-charts/)  

## **อ่านการเคลื่อนไหวของรูปร่าง**

ใช้ [Sequence::getEffectsByShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/geteffectsbyshape/) เมื่อคุณรู้จักรูปร่างเป้าหมาย หากต้องการตรวจสอบทุกเอฟเฟกต์ ให้วนลูปลำดับหลักและลำดับโต้ตอบทั้งหมด การวนลูปหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ดัชนี `0`  

ตัวอย่างต่อไปนี้สร้างรูปร่างที่มีเอฟเฟกต์ลำดับหลักและโต้ตอบ แล้วดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปร่างนั้น จากนั้นวนลูปทุกลำดับในสไลด์  

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

หากคุณต้องการเอฟเฟกต์สำหรับรูปร่างเดียว ให้ระบุรูปร่างด้วยชื่อ ประเภท placeholder หรือคุณสมบัติสเตเบิลอื่น ๆ ก่อน แล้วเรียก [Sequence::getEffectsByShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/geteffectsbyshape/) อย่าแ assumesว่า [ShapeCollection::get_Item](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/get_item/) ที่ดัชนี `0` เป็นออบเจกต์ที่ต้องการเสมอ  

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก Placeholder ที่สอดคล้องบนสไลด์เลายเอาต์และมาสเตอร์ได้ [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) จะคืนค่า Placeholder พ่อแม่ หรือ `null` หากไม่มีพ่อแม่  

ในตัวอย่างการนำเสนอด้านล่าง ส่วนท้ายมี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลายเอาต์, และ **Fly In** บนสไลด์มาสเตอร์  

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายในสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์เลายเอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนไหวของส่วนท้ายบนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปใช้โครงสร้าง placeholder จากการนำเสนอใหม่ โดยเพิ่มเอฟเฟกต์ให้กับ placeholder ของมาสเตอร์, placeholder ของเลายเอาต์ และ placeholder ที่สอดคล้องบนสไลด์ปกติ ทุกการเรียก [Shape::getBasePlaceholder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getbaseplaceholder/) จะตรวจสอบก่อนใช้รูปร่างที่คืนค่า  

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

## **เปลี่ยนการตั้งค่าเวลาในการเคลื่อนไหว**

กล่องโต้ตอบ **Timing** ของ PowerPoint จับคู่กับคุณสมบัติของ [Timing](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/)  

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนไหว](shape-animation.png)

- **เริ่ม** จับคู่กับ [Timing::getTriggerType](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/gettriggertype/)
- **ระยะเวลา** จับคู่กับ [Timing::getDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getduration/) (หน่วยวินาที)
- **หน่วงเวลา** จับคู่กับ [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/gettriggerdelaytime/) (หน่วยวินาที)
- **ทำซ้ำ** จับคู่กับ [Timing::getRepeatCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilnextclick/) หรือ [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilendslide/)
- **ย้อนกลับเมื่อเล่นเสร็จ** จับคู่กับ [Timing::getRewind](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrewind/)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์ ปรับเวลาผ่านออบเจกต์ที่คืนจาก [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) และบันทึกผลลัพธ์ การเก็บอ้างอิง [Effect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/) ที่คืนค่าไว้ช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเลกชันที่ไม่จำเป็น  

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

ใช้โหมดทำซ้ำแบบใดแบบหนึ่งเท่านั้น การผสานจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมดูต่าง ๆ เมื่อตั้งค่าโหมดทำซ้ำ ให้เรียก [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatuntilnextclick/) และ [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatuntilendslide/) ก่อน [Timing::setRepeatCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatcount/) เพราะการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะเปลี่ยนโหมดทำซ้ำที่ใช้งานอยู่  

## **เพิ่มและดึงเสียงการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงฝังอยู่ผ่าน [Effect::getSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getsound/) [Effect::setStopPreviousSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/setstopprevioussound/) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มจากเอฟเฟกต์ก่อนหน้า  

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าไฟล์เสียงท้องถิ่นชื่อ `animation-sound.wav` จะสร้างเอฟเฟกต์สองอัน ฝังไฟล์นั้นเป็นเสียงของเอฟเฟกต์แรก และตั้งค่าให้เอฟเฟกต์ที่สองหยุดเสียง ใช้ออบเจกต์ที่คืนจาก [Sequence::addEffect] จึงไม่ต้องระบุดัชนีลำดับ  

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

### **ดึงเสียงที่ฝังไว้ในเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าไฟล์นำเสนอท้องถิ่นชื่อ `presentation-with-animation-sounds.pptx` จะสแกนลำดับหลักและโต้ตอบทั้งหมดและเขียนเสียงเอฟเฟกต์ที่ฝังไว้ทุกไฟล์ลงในโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์จะเลือกจาก MIME type ของเสียงที่ `Audio::getContentType` คืนค่า  

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

สำหรับออบเจกต์เสียงขนาดใหญ่ ให้ใช้ [Audio::getStream](https://reference.aspose.com/slides/th/php-java/aspose.slides/audio/getstream/) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจกต์ทั้งหมดเข้าสู่ byte array  

## **ตั้งค่าพฤติกรรมหลังการเคลื่อนไหว**

ตัวเลือก **After animation** ควบคุมว่ารูปร่างจะทำอย่างไรหลังจากเอฟเฟกต์เสร็จสิ้น  

![กล่องโต้ตอบตัวเลือกเอฟเฟกต์ของ PowerPoint แสดงการตั้งค่าหลังการเคลื่อนไหว](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/) รองรับการทิ้งรูปร่างไว้โดยไม่เปลี่ยน แก้สี ซ่อนหลังการเคลื่อนไหว หรือซ่อนเมื่อคลิกต่อไป เมื่อประเภทเป็น [AfterAnimationType::Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/) ให้ตั้งค่า [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getafteranimationcolor/) ด้วย  

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์ ตั้งค่าพฤติกรรมหลังการเคลื่อนไหวผ่านออบเจกต์เอฟเฟกต์ที่คืนค่า แล้วบันทึกผลลัพธ์  

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

การเคลื่อนไหวของข้อความมีการควบคุมสองส่วนที่เกี่ยวข้อง:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/th/php-java/aspose.slides/textanimation/getbuildtype/) ควบคุมว่าพารากราฟจะปรากฏพร้อมกันหรือเป็นระดับพารากราฟ
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getanimatetexttype/) ควบคุมว่าข้อความจะแสดงทั้งหมด, แบ่งตามคำ, หรือแบ่งตามอักษร [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getdelaybetweentextparts/) ตั้งค่าหน่วงระหว่างคำหรืออักษร ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าลบเป็นหน่วงเวลาเป็นวินาที  

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType::AsOneObject](https://reference.aspose.com/slides/th/php-java/aspose.slides/buildtype/) ปิดการสร้างพารากราฟต่อพารากราฟเพื่อให้การตั้งค่าคำใช้กับกรอบข้อความทั้งหมด  

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

หากต้องการสร้างกล่องข้อความตามพารากราฟ ให้ตั้งค่า [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/th/php-java/aspose.slides/buildtype/) (หรือตามระดับพารากราฟอื่น) เพื่อให้เอฟเฟกต์ที่แยกสำหรับพารากราฟเดียว ให้ใช้การ overload ของ [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) ที่รับ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) ดูตัวอย่างระดับพารากราฟที่ [Animated Text](/slides/th/php-java/animated-text/)  

## **ส่งออกและหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะคงโมเดลการเคลื่อนไหวไว้ แต่การเล่นขั้นสุดท้ายขึ้นอยู่กับโปรแกรมดูสไลด์
- PDF และภาพคงที่ไม่เล่นการเคลื่อนไหว ใช้ [การส่งออกเป็น HTML5](/slides/th/php-java/export-to-html5/), GIF เคลื่อนไหว หรือ [การแปลงเป็นวิดีโอ](/slides/th/php-java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนที่
- สำหรับ HTML5 เปิดใช้งาน [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimateshapes/) และเมื่อจำเป็นให้เปิด [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimatetransitions/)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์การเข้าสู่, เน้น, ออก, และเส้นทางการเคลื่อนที่ที่เป็นที่นิยมหลายประเภท แต่ไม่ใช่ทุกเอฟเฟกต์ของ PowerPoint จะรองรับ ตรวจสอบ [การสนับสนุนการเคลื่อนไหวและเอฟเฟกต์](/slides/th/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) เวอร์ชันปัจจุบันและทดสอบการนำเสนอสำคัญกับเวอร์ชัน Aspose.Slides ของคุณ
- เอฟเฟกต์ที่กำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบการนำเสนออื่น ๆ อาจถูกเก็บไว้ในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลลัพธ์ที่ส่งออกแทนการพึ่งพาชื่อเอฟเฟกต์อย่างเดียว  

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวถึงปรากฏใน PowerPoint แต่ไม่แสดงใน PDF?**  

PDF เป็นรูปแบบคงที่ ดังนั้นการเคลื่อนไหวและการเปลี่ยนสไลด์จะไม่ทำงาน ให้ส่งออกเป็น HTML5, GIF เคลื่อนไหว หรือวิดีโอเมื่อจำเป็นต้องเก็บการเคลื่อนที่ไว้  

**ทำไมเอฟเฟกต์จึงเล่นแตกต่างกันในวิดีโอ?**  

การส่งออกเป็นวิดีโอทำการเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงอาจไม่รองรับหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟกต์ที่รองรับและทดสอบการนำเสนอจริงก่อนใช้งานจริง  

**การย้ายรูปร่างไปข้างหน้า或ข้างหลังเปลี่ยนลำดับการเคลื่อนไหวหรือไม่?**  

ไม่ การจัดลำดับ z‑order ของรูปร่างควบคุมการทับกัน ส่วนลำดับของลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว หากต้องการลำดับการเล่นที่ต่างออกไป ให้ปรับไทม์ไลน์ของลำดับ**