---
title: สร้างและแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองใน PHP
linktitle: แอนิเมชันแบบกำหนดเอง
type: docs
weight: 151
url: /th/php-java/custom-animation/
keywords:
- แอนิเมชันแบบกำหนดเอง
- พฤติกรรมแอนิเมชัน
- เส้นทางการเคลื่อนที่
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

พฤติกรรมแอนิเมชันที่กำหนดเองช่วยให้คุณควบคุมการทำงานแต่ละอย่างภายในเอฟเฟกต์แอนิเมชัน เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนที่ที่สามารถแก้ไขได้ คำแนะนำนี้แสดงวิธีสร้างและรวมพฤติกรรม ตั้งค่าการกำหนดเวลา ตรวจสอบและแก้ไขแอนิเมชันที่มีอยู่ และตรวจสอบว่าคุณสมบัติเหล่านั้นคงอยู่หลังจากบันทึกและเปิดงานนำเสนอใหม่

สำหรับเอฟเฟกต์ที่กำหนดล่วงหน้าและทริกเกอร์คลิก ดูที่ [Shape Animation](/slides/th/php-java/shape-animation/)

## **ทำความเข้าใจโมเดลแอนิเมชัน**

แอนิเมชันจัดเป็น **Timeline → Sequence → Effect → Behaviors**:

- แต่ละสไลด์มีไทม์ไลน์ที่บรรจุซีเควนซ์หลักและซีเควนซ์เชิงโต้ตอบ
- A [Sequence](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/) มีเอฟเฟกต์ ซึ่งอาจกำหนดเป้าหมายไปยังรูปร่างต่าง ๆ
- A [Effect](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/) ระบุรูปร่างเป้าหมาย พรีเซ็ต ชนิดย่อย และการกำหนดเวลาของเอฟเฟกต์
- คอลเลกชันที่คืนค่าจาก [Effect::getBehaviors](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getbehaviors/) ประกอบด้วยการทำงานที่ทำให้เอฟเฟกต์เกิดขึ้น เช่น การเปลี่ยนสี การย้าย การหมุน การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมแต่ละรายการ**

เรียก [Sequence::addEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/addeffect/) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [getBehaviors](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/getbehaviors/) พรีเซ็ตสามารถเติมคอลเลกชันนี้โดยอัตโนมัติ ให้คงการทำงานของพรีเซ็ตไว้เมื่อต่อเติม หรือใช้ [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/clear/) เมื่อจงใจแทนที่ทั้งหมด

[BehaviorFactory](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/) สร้างพฤติกรรมแปดประเภทตามตัวอย่างด้านล่าง การเคลื่อนที่อธิบายไว้ใน [Build a Motion Path](#build-a-motion-path) ตัวอย่างโค้ดแต่ละส่วนรวมการนำเข้าและสมมติว่า PHP/Java Bridge และไลบรารี Aspose.Slides PHP ได้ถูกโหลดแล้ว ตัวอย่างการแก้ไขต่อมาจะระบุไฟล์ผลลัพธ์ที่ใช้

### **การหมุน**

ใช้ [createRotationEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createrotationeffect/) เพื่อสร้างการหมุน [getBy](https://reference.aspose.com/slides/th/php-java/aspose.slides/rotationeffect/getby/) ระบุมุมสัมพัทธ์เป็นองศา; [getFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/rotationeffect/getfrom/) และ [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/rotationeffect/getto/) ระบุจุดสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin แทนที่การทำงานของพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการและกำหนดระยะเวลาเป็นสองวินาที มุมสัมพัทธ์ 90 องศาแสดงการหมุนหนึ่งไตรมาสจากทิศทางเริ่มต้นของรูปทรง ดังนั้นไม่จำเป็นต้องระบุมุมเริ่มต้นอย่างชัดเจน

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` มีรูปทรงหนึ่งรูปและพฤติกรรมการหมุนหนึ่งรายการ คอลเลกชัน เวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การปรับขนาด**

ใช้ [createScaleEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createscaleeffect/) พร้อมเปอร์เซ็นต์ X/Y: [getFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/scaleeffect/getfrom/) และ [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/scaleeffect/getto/) บรรยายขนาดเริ่มต้นและขนาดสุดท้าย ส่วน [getBy](https://reference.aspose.com/slides/th/php-java/aspose.slides/scaleeffect/getby/) บรรยายการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดต้นฉบับ

ตัวอย่างเพิ่มขนาดทั้งสองมิติจาก 100 % ไปเป็น 125 % ภายในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะคงอัตราส่วนของรูปทรงไว้; เปอร์เซ็นต์ที่ต่างกันจะยืดมิติก่อหนึ่งมากกว่าก่ออื่น

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **สี**

ใช้ [createColorEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createcoloreffect/) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [getFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/coloreffect/getfrom/) และ [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/coloreffect/getto/) เป็นสี; [getBy](https://reference.aspose.com/slides/th/php-java/aspose.slides/coloreffect/getby/) เป็นออฟเซ็ตสี คอลเลกชัน [BehaviorPropertyCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorpropertycollection/) ของพฤติกรรมบ่งบอกแอตทริบิวต์ที่กำลังทำแอนิเมชัน

การเติมเต็มแบบสีทึบของรูปทรงเริ่มต้นเป็นสีน้ำเงิน ซึ่งตรงกับสีเริ่มต้นของแอนิเมชัน การเลือกแอตทริบิวต์สีเติมทำให้พฤติกรรมรู้ว่าต้องเปลี่ยนส่วนใดของรูป; จุดสิ้นสุดของสีเพียงอย่างเดียวไม่บ่งบอกแอตทริบิวต์นั้น เอฟเฟกต์ที่บันทึกบรรยายการเปลี่ยนเป็นสีส้มในสองวินาที

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ฟิลเตอร์**

ใช้ [createFilterEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createfiltereffect/) เพื่อเลือกการลบล้าง [getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/th/php-java/aspose.slides/filtereffect/getsubtype/), และ [getReveal](https://reference.aspose.com/slides/th/php-java/aspose.slides/filtereffect/getreveal/) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดเผยหรือซ่อนรูป

ตัวอย่างนี้ตั้งค่าการลบล้างสองวินาทีที่เปิดเผยรูปโดยใช้ชนิดย่อยที่มาทางขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟกต์ ดังนั้นจึงทำหลังจากลบการทำงานดั้งเดิมของพรีเซ็ตออกแล้ว

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **คุณสมบัติ**

ใช้ [createPropertyEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) เพื่อทำแอนิเมชันความทึบ [getFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/propertyeffect/getto/), และ [getBy](https://reference.aspose.com/slides/th/php-java/aspose.slides/propertyeffect/getby/) เป็นสตริงที่ตีความด้วย [getValueType](https://reference.aspose.com/slides/th/php-java/aspose.slides/propertyeffect/getvaluetype/) และ [getCalcMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/propertyeffect/getcalcmode/) เลือกจุดสิ้นสุดหรือออฟเซ็ตสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกัน

ที่นี่แอตทริบิวต์ที่เลือกคือ opacity และสตริงตัวเลขแสดงการเปลี่ยนจากความทึบ 25 % ไปเป็นความทึบเต็มค่า การประมาณเชิงเส้นอธิบายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าทั้งสอง เมื่อปรับตัวอย่างนี้ไปใช้แอตทริบิวต์อื่น ให้เลือกประเภทค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ตั้งค่า**

ใช้ [createSetEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createseteffect/) เพื่อกำหนดความมองเห็นผ่าน [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/seteffect/getto/) พฤติกรรม set ไม่ทำการอินเทอร์โพเลตระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์ความมองเห็นและกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน สี่เหลี่ยมผืนผ้าถูกตั้งให้มองเห็นอยู่แล้วในงานนำเสนอขั้นต่ำนี้ ดังนั้นการกำหนดอาจไม่แสดงการเปลี่ยนแปลงที่ชัดเจน การทำเช่นนี้เป็นประโยชน์เมื่อเป็นส่วนหนึ่งของเอฟเฟกต์ที่ใหญ่กว่า ซึ่งควบคุมว่ารูปร่างจะซ่อนหรือแสดงเมื่อใด

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **คำสั่ง**

ใช้ [createCommandEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createcommandeffect/) และตั้งค่า [getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/th/php-java/aspose.slides/commandeffect/getcommandstring/), และ [getShapeTarget](https://reference.aspose.com/slides/th/php-java/aspose.slides/commandeffect/getshapetarget/) ใส่ไฟล์บันทึกเสียง WAV ชื่อ `sample.wav` ลงในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [addAudioFrameEmbedded](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addaudioframeembedded/) และแนบคำสั่งเล่นไปกับเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟกต์และของคำสั่ง การเชื่อมนี้ทำให้คำสั่งเล่นอ้างอิงไปยังไฟล์บันทึกที่ฝังไว้; สตริงคำสั่งโดยลำพังไม่บ่งบอกวัตถุสื่อใดที่จะควบคุม เอฟเฟกต์ตั้งค่าให้เริ่มเมื่อคลิกระหว่างการแสดงสไลด์

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Saving stores the command in `command.pptx`; it does not play the recording. Playback requires a slideshow player that supports the command and its media target.

## **จัดการคอลเลกชันพฤติกรรม**

[BehaviorCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/remove/), และ [removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/removeat/). ตัวอย่างนี้เปิด `rotation.pptx` เพิ่มการปรับขนาด ย้ายมันก่อนการหมุน และลบการหมุนออก การลบและแทรกซ้ำวัตถุเดียวกันทำให้ตำแหน่งที่เก็บเปลี่ยนโดยไม่ต้องสร้างสำเนาใหม่

การแก้ไขลำดับทำให้คอลเลกชันเปลี่ยนจาก rotation–scale เป็น scale–rotation แล้วเป็น scale เท่านั้น ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังจากจัดเรียงใหม่ การนับครั้งสุดท้ายยืนยันว่าพฤติกรรมใดจะถูกบันทึก

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์คือ `ScaleEffect`: เหลือการปรับขนาดอย่างเดียว คำสั่งเรียงลำดับของคอลเลกชันไม่ได้โดยอัตโนมัติจัดเวลาให้ทำงานต่อเนื่อง ให้ใช้ [clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/clear/) เฉพาะเมื่อแทนที่การทำงานทั้งหมด

## **ตั้งค่าการกำหนดเวลาพฤติกรรม**

พฤติกรรมมี [Timing](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/) ของตัวเอง แยกจากการกำหนดเวลาที่ได้รับจาก [Effect::getTiming](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/gettiming/) การกำหนดเวลาเอฟเฟกต์จัดตารางให้เอฟเฟกต์โดยรวม; การกำหนดเวลาพฤติกรรมอธิบายการทำงานภายในเอฟเฟกต์นั้น

### **กำหนดระยะเวลา, การหน่วง, การทำซ้ำ, และการเร่ง**

เปิด `rotation.pptx` และตั้งระยะเวลา ([getDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getduration/)) และการหน่วงทริกเกอร์ ([getTriggerDelayTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/gettriggerdelaytime/)) เป็นวินาที แล้วกำหนดจำนวนครั้งทำซ้ำด้วย [setRepeatCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/setrepeatcount/) [getAccelerate](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getaccelerate/) และ [getDecelerate](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getdecelerate/) เป็นส่วนของระยะเวลา; ให้ผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนแค่การกำหนดเวลาของพฤติกรรมนั้น; มุม 90 ° ยังคงเดิม การแยกมุมและเวลาช่วยให้ปรับความเร็วได้โดยไม่ต้องสร้างเอฟเฟกต์ใหม่

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

พฤติกรรมใช้ระยะเวลา 2 วินาที หน่วง 0.5 วินาที และทำซ้ำ 3 ครั้ง 20 % แรกและสุดของระยะเวลาถูกใช้สำหรับการเร่งและการชะลอ

นโยบายทำซ้ำอื่น ๆ ได้แก่ [getRepeatDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilendslide/), และ [getRepeatUntilNextClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getrepeatuntilnextclick/) ให้เลือกนโยบายหนึ่งแทนการเปิดใช้งานทั้งหมดพร้อมกัน [getAutoReverse](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/getautoreverse/) เล่นแอนิเมชันย้อนกลับหลังการทำงานไปข้างหน้า การเร่งและการชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าแบบกระโดดหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [createMotionEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorfactory/createmotioneffect/) เพื่อสร้างการเคลื่อนที่ ส่วน [getFrom](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/getto/), และ [getBy](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/getby/) บรรยายพิกัดหรือออฟเซ็ตตามเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ ให้สร้าง [MotionPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpath/) แล้วกำหนดด้วย [MotionEffect::setPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/setpath/) [MotionPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpath/) จะเก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncommandpathtype/) เลือกการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | One | Set the starting position. |
| LineTo | One | Move along a straight segment to its endpoint. |
| CurveTo | Three | Follow a cubic curve defined by two control points and an endpoint. |
| CloseLoop | None | Return to the starting position. |
| End | None | Finish the path. |

[MotionPathPointsType](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpathpointstype/) บรรยายคุณลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดแบบ curve สำหรับตัวอย่างเส้นโค้งด้านล่าง และประเภทจุดแบบ corner สำหรับส่วนตรง

พิกัดของเส้นทางปกติกับขนาดสไลด์: การเคลื่อนที่ X 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 พิกเซล Y บวกหมายถึงลงล่าง คำสั่ง absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่ง relative ระบุออฟเซ็ตจากตำแหน่งปัจจุบัน สิ่งนี้แยกจาก [getOrigin](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/getorigin/) ที่เลือกกรอบอ้างอิงของเส้นทาง และ [getPathEditMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioneffect/getpatheditmode/) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อย้ายรูป

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น ส่วนตรงหนึ่งส่วน และคำสั่งจบ [MotionPath::add](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpath/add/) รับประเภทคำสั่ง, จุด, ประเภทจุด, และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นกำหนด (0, 0) และเส้นตรงจบที่ (0.25, 0) ทำให้เส้นทางเคลื่อนที่แนวนอนหนึ่งในสี่ของความกว้างสไลท์ คำสั่งจบไม่มีจุดพิกัด เมื่อเส้นทางถูกกำหนด การเพิ่มพฤติกรรมการเคลื่อนที่เข้าไปในเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยมผืนผ้า

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งรายการพร้อมสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างที่รู้จักนี้

### **เปรียบเทียบพิกัด Absolute กับ Relative**

วัตถุสองอันนี้อธิบายเส้นทางเดียวกัน คำสั่ง absolute จบที่ (0.3, 0.1) คำสั่ง relative เพิ่ม (0.1, 0.1) ไปยังตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มจากตำแหน่งเดียวกัน สำหรับเส้น relative ให้นำออฟเซ็ต X และ Y ไปบวกกับตำแหน่งปัจจุบันเพื่อได้จุดสิ้นสุด; ส่วนเส้น absolute อ่านจุดสิ้นสุดโดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางแตกต่างกัน

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ ค่าบูลีนสุดท้ายเลือกพิกัด relative สำหรับคำสั่งนั้น

### **แทนที่เส้นตรงด้วยโค้ง**

เปิด `motion.pptx` และแทนที่คำสั่งเส้นตรงด้วยโค้งแบบคิวบิก ให้ใส่จุดควบคุมสองจุดก่อน แล้วตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดสองจุดแรกกำหนดรูปโค้ง ส่วนจุดที่สามคือปลายทาง; ไม่ใช่สามจุดต่อเนื่อง การอัปเดตประเภทคำสั่ง ประเภทการแก้ไขจุด และอาเรย์จุดพร้อมกันทำให้ส่วนเส้นตรงสอดคล้องกับเรขาคณิตใหม่

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เส้นทางใน `curve.pptx` ยังมีสามคำสั่ง; คำสั่งกลางตอนนี้เป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [MotionCmdPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncmdpath/) เปิดเผย [getPoints](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncmdpath/getpointstype/), และ [isRelative](https://reference.aspose.com/slides/th/php-java/aspose.slides/motioncmdpath/isrelative/). ตัวอย่างต่อไปนี้ใช้เส้นทางสามคำสั่งที่รู้จักใน `motion.pptx`. สำหรับอินพุตที่ไม่กำหนดไว้ล่วงหน้า ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขตามดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง end และ close-loop ไม่ต้องการจุด จึงต้องรองรับอาเรย์จุดเป็น null

ผลลัพธ์จะแสดงคู่ประเภทคำสั่งตัวเลขกับแฟล็กพิกัด relative ก่อนรายการจุด ช่วยให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง โค้งจะแสดงสามจุด ส่วนเส้นตรงในไฟล์นี้จะแสดงเพียงหนึ่งจุด

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

รายการประกอบด้วยจุดเริ่มต้น เส้น absolute สิ้นสุดที่ (0.25, 0) และคำสั่ง end

### **เปลี่ยนจุดสิ้นสุด**

เปิด `motion.pptx` แล้วแทนที่อาเรย์จุดของเส้นเพื่อย้ายจุดสิ้นสุด

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้น ดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นทำให้ปลายทางเปลี่ยนโดยไม่กระทบประเภทคำสั่ง เวลา หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัด absolute คู่ใหม่ระบุตำแหน่งแทนออฟเซ็ตที่เพิ่ม

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เส้นใน `motion-endpoint.pptx` สิ้นสุดที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

### **แทนที่ส่วนเส้น**

ใช้ [insert](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpath/insert/) และ [removeAt](https://reference.aspose.com/slides/th/php-java/aspose.slides/motionpath/removeat/) เพื่อแทนที่เส้นใน `motion.pptx`. การแทรกทำให้เส้นเก่าลำดับที่ 2

ตัวอย่างนี้แสดงการแทนที่วัตถุคำสั่งแทนการแก้ไขพิกัดเดิม หลังการแทรก คอลเลกชันชั่วคราวมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, คำสั่ง end การลบดัชนี 2 จะทิ้งเส้นเก่าและเหลือเส้นใหม่ในที่เดิม

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เส้นทางที่บันทึกยังคงมีสามคำสั่ง โดยเส้นใหม่สิ้นสุดที่ (0.2, 0.1) และคำสั่ง end อยู่ตำแหน่งสุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกตามประเภท ตัวอย่างนี้เปิด `rotation.pptx`, ค้นหา [RotationEffect](https://reference.aspose.com/slides/th/php-java/aspose.slides/rotationeffect/), เปลี่ยนมุม, และตรวจสอบค่าที่บันทึกหลังจากเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในออบเจ็กต์การนำเสนอแยกต่างหาก ดังนั้นการเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่จริง ไม่ใช่ค่าที่ยังอยู่ในหน่วยความจำ ตัวอย่างนี้สมมติว่าเอฟเฟกต์ที่รู้จักเป็นรายการแรกในซีเควนซ์หลัก; การเลือกพฤติกรรมตามประเภทไม่ได้ค้นหาเอฟเฟ็กต์ที่ถูกต้องในงานนำเสนอใด ๆ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์คือ `Rotation preserved: true`. ใช้รูปแบบการตรวจสอบประเภทเดียวกันกับพฤติกรรมอื่น ๆ เพื่อทำการตรวจสอบการคงอยู่อย่างสมบูรณ์ เปรียบเทียบรูปร่างเป้าหมาย, เอฟเฟกต์, ประเภทและลำดับพฤติกรรม, การกำหนดเวลา, และคำสั่งเส้นทาง ใช้ความคลาดเคลื่อนเชิงตัวเลขสำหรับค่าทศนิยม สำหรับงานนำเสนอที่ไม่ทราบโครงสร้างแอนิเมชัน ดูที่ [Read Shape Animations](/slides/th/php-java/shape-animation/#read-shape-animations) เพื่อท่องซีเควนซ์หลักและเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [BehaviorCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/behaviorcollection/) คือลำดับที่บันทึกของการทำงานของเอฟเฟกต์ ไม่ใช่เพลย์ลิสต์ที่พฤติกรรมทุกตัวจะรอคำสั่งจากตัวก่อนหน้าโดยอัตโนมัติ การกำหนดเวลาและเอฟเฟกต์ที่บรรจุกำหนดการจัดตาราง พฤติกรรมสามารถทับซ้อนกันได้ และการทำงานบนแอตทริบิวต์เดียวกันอาจโต้ตอบผ่านการตั้งค่า [additive](https://reference.aspose.com/slides/th/php-java/aspose.slides/behavioradditivetype/) และ [accumulation](https://reference.aspose.com/slides/th/php-java/aspose.slides/behavioraccumulatetype/) อย่าใช้การจัดลำดับคอลเลกชันอย่างเดียวเพื่อกำหนด “ย้ายแล้วหมุน” ให้ใช้การกำหนดเวลาที่ชัดเจนหรือเอฟเฟกต์แยกตามที่อธิบายใน [Shape Animation](/slides/th/php-java/shape-animation/)

[type] และ [subtype] ของเอฟเฟกต์อธิบายพรีเซ็ต แต่ไม่ได้อธิบายต้นไม้พฤติกรรมที่แก้ไขแล้วทั้งหมด เลือกพรีเซ็ตและ subtype ก่อนปรับพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการทำงานที่คุณเพิ่มเอง ตัวอย่างเช่น การเปลี่ยนเอฟเฟกต์ Spin ที่ปรับแต่งเป็น Fade สามารถแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันใหม่หลังจากเปลี่ยนพรีเซ็ตหรือ subtype การล้างพรีเซ็ตอาจลบการทำงานที่พรีเซ็ตจำเป็นต้องมี ตัวอย่างใช้รูปทรงที่มองเห็นได้และแทนที่พฤติกรรม; ไม่ได้สร้างโครงสร้างพรีเซ็ตใหม่ทั้งหมด

## **ความเข้ากันได้ของรูปแบบ**

ต้นไม้พฤติกรรมที่คงอยู่ไม่ได้รับประกันการเล่นที่เหมือนกันในทุกโปรแกรมแสดงหรือเครื่องมือแปลง ให้ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| รูปแบบหรือผลลัพธ์ | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นรูปแบบหลักสำหรับตัวอย่างนี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ จากนั้นตรวจสอบการเล่นในเวอร์ชัน PowerPoint ที่ต้องการ |
| PPT | ตัวแทนไบนารีแบบเก่าสามารถแตกต่างจาก PPTX ทดสอบการบันทึก‑เปิด‑เล่นแยกกัน; อย่าสรุปการสนับสนุนทุกการผสมผสานจากผลลัพธ์ PPTX ที่สำเร็จ |
| PDF, PNG, JPEG, and other static slide images | มีเพียงภาพสไลด์คงที่ ไม่ได้เป็นไทม์ไลน์แอนิเมชันหรือเฟรมแอนิเมชันสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/php-java/export-to-html5/) | สามารถเล่นแอนิเมชันที่สนับสนุนได้เมื่อเปิดใช้การแอนิเมชันของรูปทรงในตัวเลือกการส่งออก ทดสอบการผสมผสานแบบกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/php-java/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมแก้ไขได้หรือการโต้ตอบบนคลิก ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/php-java/convert-powerpoint-to-video/) | เรนเดอร์เฟรมแอนิเมชันและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [animations and effects ที่รองรับ](/slides/th/php-java/convert-powerpoint-to-video/#supported-animations-and-effects); คำสั่งและเหตุการณ์เชิงโต้ตอบจะไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **FAQ**

**ทำไมเอฟเฟกต์ของฉันถึงมีพฤติกรรมอยู่แล้วก่อนที่ฉันจะเพิ่มอะไรเลย?**  
การสร้างเอฟเฟกต์ที่กำหนดล่วงหน้าสามารถสร้างการทำงานพื้นฐานของมันได้ ตรวจสอบก่อนตัดสินใจต่อเติมพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังตำแหน่งแรกทำให้มันเล่นก่อนหรือไม่?**  
ไม่จำเป็น ลำดับคอลเลกชันไม่ใช่ตัวแทนของการกำหนดเวลา ตรวจสอบการหน่วง, ระยะเวลา, และปฏิสัมพันธ์ระหว่างการทำงานบนแอตทริบิวต์เดียวกัน

**ทำไมคำสั่ง end ไม่มีจุด?**  
เป็นเครื่องหมายจบเส้นทาง ไม่ต้องการพิกัด ตรวจสอบอาเรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การทำรอบไป‑กลับสำเร็จถือว่ายืนยันการเล่นหรือไม่?**  
ไม่ การเปิดใหม่ยืนยันว่าคุณสมบัติที่ตรวจสอบยังคงอยู่ ต้องทดสอบโปรแกรมสไลด์โชว์หรือการส่งออกแบบแอนิเมชันแยกต่างหากเพื่อยืนยันพฤติกรรมภาพที่เห็น)