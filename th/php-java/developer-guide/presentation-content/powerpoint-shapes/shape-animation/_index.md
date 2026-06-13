---
title: ใช้แอนิเมชันรูปทรงในงานนำเสนอด้วย PHP
linktitle: แอนิเมชันรูปทรง
type: docs
weight: 60
url: /th/php-java/shape-animation/
keywords:
- รูปร่าง
- แอนิเมชัน
- เอฟเฟกต์
- รูปร่างที่แอนิเมชัน
- ข้อความที่แอนิเมชัน
- เพิ่มแอนิเมชัน
- รับแอนิเมชัน
- สกัดแอนิเมชัน
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟ็กต์
- เสียงเอฟเฟกต์
- ใช้แอนิเมชัน
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแอนิเมชันรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ให้โดดเด่น!"
---
## **บทนำ**

แอนิเมชันเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ, รูปภาพ, รูปร่าง หรือ [แผนภูมิ](https://docs.aspose.com/slides/th/php-java/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา.

## **ทำไมจึงใช้แอนิเมชันในการนำเสนอ?**

* ควบคุมการไหลของข้อมูล  
* เน้นจุดสำคัญ  
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม  
* ทำให้เนื้อหาง่ายต่อการอ่านหรือทำความเข้าใจหรือประมวลผล  
* ดึงความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในการนำเสนอ  

PowerPoint มีตัวเลือกและเครื่องมือมากมายสำหรับแอนิเมชันและเอฟเฟกต์แอนิเมชันในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**.

## **แอนิเมชันใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการเพื่อทำงานกับแอนิเมชันภายใต้เนมสเปส `Aspose.Slides.Animation`,
* Aspose.Slides มีแอนิเมชันเอฟเฟกต์กว่า **150** รายการภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/php-java/aspose.slides/effecttype). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือนกับ (หรือเทียบเท่ากับ) เอฟเฟกต์ที่ใช้ใน PowerPoint.

## **ใช้แอนิเมชันกับ TextBox**

Aspose.Slides for PHP via Java อนุญาตให้คุณใช้แอนิเมชันกับข้อความในรูปทรง.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)  
4. เพิ่มข้อความไปยัง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/#getTextFrame) ของ `AutoShape`  
5. ได้รับลำดับหลักของเอฟเฟกต์  
6. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)  
7. ใช้เมธอด `TextAnimation.setBuildType` พร้อมค่าจาก enumeration `BuildType`  
8. เขียนการนำเสนอเป็นไฟล์ PPTX บนดิสก์  

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าแอนิเมชันข้อความเป็นค่า *By 1st Level Paragraphs*:

```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ใหม่พร้อมข้อความ
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # รับลำดับหลักของสไลด์
    $sequence = $sld->getTimeline()->getMainSequence();
    # เพิ่มเอฟเฟกต์แอนิเมชัน Fade ให้กับรูปทรง
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # ทำแอนิเมชันข้อความของรูปทรงตามย่อหน้าระดับที่ 1
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 
นอกจากการใช้แอนิเมชันกับข้อความแล้ว คุณยังสามารถใช้แอนิเมชันกับ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เพียงหนึ่งรายการได้ ดู [**Animated Text**](/slides/th/php-java/animated-text/).
{{% /alert %}} 

## **ใช้แอนิเมชันกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe) บนสไลด์  
4. รับลำดับหลักของเอฟเฟกต์  
5. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [PictureFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/pictureframe)  
6. เขียนการนำเสนอเป็นไฟล์ PPTX บนดิสก์  

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์ `Fly` กับ picture frame:

```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ
  $pres = new Presentation();
  try {
    # โหลดภาพเพื่อเพิ่มในคอลเลกชันรูปภาพของการนำเสนอ
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # เพิ่มเฟรมรูปภาพลงสไลด์
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # รับลำดับหลักของสไลด์
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # เพิ่มเอฟเฟกต์แอนิเมชัน Fly จากด้านซ้ายให้กับเฟรมรูปภาพ
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้แอนิเมชันกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)  
4. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แบบบีเวิล (เมื่อวัตถุนี้ถูกคลิก แอนิเมชันจะเล่น)  
5. สร้างลำดับของเอฟเฟกต์บนรูปทรงบีเวิล  
6. สร้าง `UserPath` แบบกำหนดเอง  
7. เพิ่มคำสั่งสำหรับการย้ายไปยัง `UserPath`  
8. เขียนการนำเสนอเป็นไฟล์ PPTX บนดิสก์  

โค้ด PHP นี้แสดงวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับรูปทรง:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างเอฟเฟกต์ PathFootball สำหรับรูปทรงที่มีอยู่ตั้งแต่ต้น.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # เพิ่มเอฟเฟกต์แอนิเมชัน PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # สร้าง "ปุ่ม" ประเภทหนึ่ง.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # สร้างเส้นทางผู้ใช้แบบกำหนดเอง วัตถุของเราจะย้ายเฉพาะหลังจากคลิกปุ่มเท่านั้น.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # เพิ่มคำสั่งการย้ายเนื่องจากเส้นทางที่สร้างไว้ว่างเปล่า.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # เขียนไฟล์ PPTX ลงดิสก์
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **รับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `getEffectsByShape` จากคลาส [Sequence](https://reference.aspose.com/slides/th/php-java/aspose.slides/sequence/) เพื่อรับเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับรูปทรงหนึ่ง.

**ตัวอย่างที่ 1: รับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape บนสไลด์ปกติ**

ก่อนหน้านี้ คุณได้เรียนรู้วิธีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับ Shape ในการนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับเอฟเฟกต์ที่ใช้กับ Shape แรกบนสไลด์ปกติแรกในไฟล์การนำเสนอ `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # รับลำดับแอนิเมชันหลักของสไลด์.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # รับรูปทรงแรกบนสไลด์แรก.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # รับเอฟเฟกต์แอนิเมชันที่ใช้กับรูปทรง.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**ตัวอย่างที่ 2: รับเอฟเฟกต์แอนิเมชันทั้งหมด รวมถึงที่สืบทอดจาก Placeholder**

หาก Shape บนสไลด์ปกติมี Placeholder ที่อยู่บนสไลด์เลย์เอาต์และ/หรือสไลด์มาสเตอร์ และมีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับ Placeholder เหล่านั้น แล้วเอฟเฟกต์ทั้งหมดของ Shape จะถูกเล่นในระหว่างการสไลด์โชว์ รวมถึงที่สืบทอดจาก Placeholder ด้วย

สมมติว่าเรามีไฟล์การนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งที่มีเพียง Shape ส่วนท้ายที่มีข้อความ "Made with Aspose.Slides" และมีการใช้เอฟเฟกต์ **Random Bars** กับ Shape นั้น.

![เอฟเฟกต์แอนิเมชันของ Shape สไลด์](slide-shape-animation.png)

ให้สมมติเพิ่มเติมว่าเอฟเฟกต์ **Split** ถูกใช้กับ Placeholder ส่วนท้ายบนสไลด์ **layout**.

![เอฟเฟกต์แอนิเมชันของ Shape ใน Layout](layout-shape-animation.png)

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกใช้กับ Placeholder ส่วนท้ายบนสไลด์ **master**.

![เอฟเฟกต์แอนิเมชันของ Shape ใน Master](master-shape-animation.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `getBasePlaceholder` จากคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) เพื่อเข้าถึง Placeholder ของ Shape และรับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape ส่วนท้าย รวมถึงที่สืบทอดจาก Placeholder ที่อยู่บนสไลด์ layout และ master

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// รับเอฟเฟกต์แอนิเมชันของรูปทรงบนสไลด์ปกติ.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// รับเอฟเฟกต์แอนิเมชันของ placeholder บนสไลด์เลย์เอาต์.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// รับเอฟเฟกต์แอนิเมชันของ placeholder บนสไลด์มาสเตอร์.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // บิน, ด้านล่าง
Type: 134, subtype: 45            // แยก, แนวตั้งเข้า
Type: 126, subtype: 22            // แถบสุ่ม, แนวนอน
```

## **วิธีการเปลี่ยนเวลาเอฟเฟกต์แอนิเมชัน**

Aspose.Slides for PHP via Java อนุญาตให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์แอนิเมชัน

นี่คือแผง Animation Timing ใน Microsoft PowerPoint:
![แผง Animation Timing](shape-animation.png)

นี่คือความสอดคล้องระหว่าง PowerPoint Timing กับคุณสมบัติ [Effect Timing](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#getTiming):

- ค่าลดลง (drop-down) **Start** ของ PowerPoint Timing ตรงกับเมธอด [Timing::getTriggerType](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/#getTriggerType)  
- **Duration** ของ PowerPoint Timing ตรงกับเมธอด [Timing::getDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/#getDuration) ระยะเวลาของแอนิเมชัน (เป็นวินาที) คือเวลาทั้งหมดที่แอนิเมชันใช้ในการทำครบหนึ่งรอบ  
- **Delay** ของ PowerPoint Timing ตรงกับเมธอด [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/timing/#getTriggerDelayTime)

วิธีการเปลี่ยนคุณสมบัติ Effect Timing มีดังนี้:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน  
2. ตั้งค่าตัวใหม่ที่ต้องการโดยใช้เมธอด [Effect::getTiming](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#getTiming)  
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว  

โค้ด PHP นี้สาธิตการทำงาน:
```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # รับลำดับหลักของสไลด์.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # รับเอฟเฟกต์แรกของลำดับหลัก.
    $effect = $sequence->get_Item(0);
    # เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # เปลี่ยนระยะเวลาเอฟเฟกต์
    $effect->getTiming()->setDuration(3.0);
    # เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เสียงของเอฟเฟกต์แอนิเมชัน**

Aspose.Slides มีเมธอดต่อไปนี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์แอนิเมชัน:

- [setSound(IAudio value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **เพิ่มเสียงให้กับเอฟเฟกต์แอนิเมชัน**

โค้ด PHP นี้แสดงวิธีการเพิ่มเสียงให้กับเอฟเฟ็กต์แอนิเมชันและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มต้น:
```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # เพิ่มเสียงลงในคอลเลกชันเสียงของการนำเสนอ
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # รับลำดับหลักของสไลด์.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # รับเอฟเฟ็กต์แรกของลำดับหลัก
    $firstEffect = $sequence->get_Item(0);
    # ตรวจสอบว่าเอฟเฟ็กต์ไม่มีเสียงหรือไม่
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # เพิ่มเสียงให้กับเอฟเฟ็กต์แรก
      $firstEffect->setSound($effectSound);
    }
    # รับลำดับอินเทอร์แอคทีฟแรกของสไลด์.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟ็กต์
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สกัดเสียงจากเอฟเฟกต์แอนิเมชัน**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. รับลำดับหลักของเอฟเฟกต์  
4. สกัด [setSound(IAudio value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ที่ฝังอยู่ในแต่ละเอฟเฟกต์แอนิเมชัน  

โค้ด PHP นี้แสดงวิธีสกัดเสียงที่ฝังอยู่ในเอฟเฟกต์แอนิเมชัน:
```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # รับลำดับหลักของสไลด์.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # แยกเสียงเอฟเฟกต์เป็นอาร์เรย์ไบต์
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **หลังจากแอนิเมชัน**

Aspose.Slides for PHP via Java อนุญาตให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์แอนิเมชัน

นี่คือแผง Animation Effect และเมนูขยายใน Microsoft PowerPoint:
![แผง Animation Effect และเมนูขยาย](shape-after-animation.png)

ค่า drop-down **After animation** ของ PowerPoint Effect ตรงกับเมธอดต่อไปนี้:

* เมธอด [setAfterAnimationType(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setAfterAnimationType) ซึ่งอธิบายประเภท After animation:
  * **More Colors** ของ PowerPoint ตรงกับประเภท [AfterAnimationType::Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/#Color)
  * รายการ **Don't Dim** ของ PowerPoint ตรงกับประเภท [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/#DoNotDim) (ประเภท After animation เริ่มต้น)
  * รายการ **Hide After Animation** ของ PowerPoint ตรงกับประเภท [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation)
  * รายการ **Hide on Next Mouse Click** ของ PowerPoint ตรงกับประเภท [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick)
* เมธอด [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setAfterAnimationColor) ซึ่งกำหนดรูปแบบสีของ After animation เมธอดนี้ทำงานร่วมกับประเภท [AfterAnimationType::Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/afteranimationtype/#Color). หากคุณเปลี่ยนประเภทเป็นอื่น สี After animation จะถูกลบออก

โค้ด PHP นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ After animation:
```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # รับเอฟเฟ็กต์แรกของลำดับหลัก
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # เปลี่ยนประเภท after animation เป็นสี
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # ตั้งค่าสีของ after animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แอนิเมตข้อความ**

Aspose.Slides มีเมธอดต่อไปนี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์แอนิเมชัน:

- เมธอด [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setAnimateTextType) ซึ่งอธิบายประเภทการแอนิเมตข้อความของเอฟเฟกต์ ข้อความของ Shape สามารถแอนิเมตได้:
  * ทั้งหมดพร้อมกัน ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/th/php-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  * ตามคำ ([AnimateTextType::ByWord](https://reference.aspose.com/slides/th/php-java/aspose.slides/animatetexttype/#ByWord) type)
  * ตามอักขระ ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/th/php-java/aspose.slides/animatetexttype/#ByLetter) type)
- เมธอด [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setDelayBetweenTextParts) ตั้งค่าการหน่วงเวลาระหว่างส่วนของข้อความที่แอนิเมต (คำหรืออักขระ) ค่าบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์ ค่าลบระบุหน่วงเวลาเป็นวินาที

วิธีการเปลี่ยนคุณสมบัติ Effect Animate text มีดังนี้:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน  
2. ใช้เมธอด [setBuildType(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/textanimation/#setBuildType) กับค่า [BuildType::AsOneObject](https://reference.aspose.com/slides/th/php-java/aspose.slides/buildtype/#AsOneObject) เพื่อปิดโหมดแอนิเมชัน *By Paragraphs*  
3. ตั้งค่าตัวใหม่โดยใช้เมธอด [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setAnimateTextType) และ [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/php-java/aspose.slides/effect/#setDelayBetweenTextParts)  
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว  

โค้ด PHP นี้สาธิตการทำงาน:
```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # รับเอฟเฟกต์แรกของลำดับหลัก
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # เปลี่ยนประเภทการแอนิเมชันข้อความของเอฟเฟกต์เป็น "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # เปลี่ยนประเภทการแอนิเมตข้อความของเอฟเฟกต์เป็น "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
    $firstEffect->setDelayBetweenTextParts(20.0);
    # บันทึกไฟล์ PPTX ลงดิสก์
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรให้แอนิเมชันคงอยู่เมื่อเผยแพร่การนำเสนอไปยังเว็บ?**

[Export to HTML5](/slides/th/php-java/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/) ที่รับผิดชอบต่อการแอนิเมชัน [shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimateshapes/) และ [transition](https://reference.aspose.com/slides/th/php-java/aspose.slides/html5options/setanimatetransitions/) หากใช้ HTML ธรรมดาจะไม่เล่นแอนิเมชันของสไลด์ แต่ HTML5 จะทำให้เล่นได้.

**การเปลี่ยนลำดับ z-order (ลำดับชั้น) ของ Shape มีผลต่อแอนิเมชันอย่างไร?**

แอนิเมชันและลำดับการวาดเป็นสิ่งอิสระกัน: เอฟเฟกต์ควบคุมเวลาและประเภทของการปรากฏ/หายไป ในขณะที่ [z-order](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getzorderposition/) กำหนดว่ารูปใดบังรูปใด ผลลัพธ์ที่มองเห็นจึงเป็นผลของการรวมกันของทั้งสอง (นี่เป็นลักษณะการทำงานทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และ Shape ของ Aspose.Slides ทำตามตรรกะเดียวกัน).

**มีข้อจำกัดใดเมื่อแปลงแอนิเมชันเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?**

โดยทั่วไป [แอนิเมชันได้รับการสนับสนุน](/slides/th/php-java/convert-powerpoint-to-video/) แต่ในบางกรณีหรือเอฟเฟกต์เฉพาะอาจแสดงผลแตกต่างกัน คำแนะนำคือให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.