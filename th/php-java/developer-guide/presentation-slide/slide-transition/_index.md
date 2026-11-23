---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย PHP
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/php-java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, ตั้งค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการแสดงสไลด์ระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสไลด์สำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนไปข้างหน้าด้วยการคลิกเมาส์หรือด้วยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงต่อเอฟเฟกต์ ตัวอย่างในบทความนี้ใช้ PHP เพื่อประยุกต์ใช้การเปลี่ยนสไลด์ ตั้งค่าระยะเวลาเปลี่ยนอย่างแม่นยำ จัดการการตั้งเวลาสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนสไลด์ ให้โหลดพรีเซนเทชันด้วยคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนสไลด์ของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). ใช้ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) กับค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) จากนั้นบันทึกพรีเซนเทชัน

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยน Wheel**

เมธอด [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์ปลายทาง ใช้ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Wheel จาก [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), จากนั้นเรียก [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) เพื่อเข้าถึงการตั้งค่า [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่ แต่ละคู่เริ่มต้นด้วยสไลด์สีดำและสิ้นสุดด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ที่ 2 ใช้ spokes หนึ่งอันและสไลด์ที่ 4 ใช้แปดอัน ทั้งสองการเปลี่ยนใช้ความเร็วช้าเดียวกันที่ตั้งค่าด้วย [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) และระยะเวลาแน่ชัด 8,000 มิลลิวินาทีที่ตั้งค่าด้วย [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration)

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

เปิดพรีเซนเทชันที่บันทึกไว้ใน PowerPoint แล้วเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูการสแกนทิศทางตามเข็มนาฬิกาเดียว จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 เพื่อดูส่วนรัศมีแปดส่วนเปิดเผยสี่เหลี่ยมเดียวกันพร้อมกัน

## **จางผ่านสีดำด้วยการเปลี่ยน Reveal**

ตั้งค่าประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal, แล้วเรียก [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) บนการตั้งค่า [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/) ตัวอย่างสร้างสไลด์ต้นฉบับสีเทาลมและสไลด์ปลายทางสีฟีโครลา, แล้วทำการโคลนทั้งสอง คู่แต่ละคู่ใช้การเปลี่ยน Reveal ที่ระยะเวลา 2 วินาทีเดียวกัน เพียงคู่ที่สองเท่านั้นที่จางผ่านสีดำ

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

เปิดพรีเซนเทชันที่บันทึกไว้ใน PowerPoint แล้วเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูสีเทาลมจางโดยตรงเข้าสีฟีโครลา จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงชั่วคราวจนเกือบสีดำก่อนที่สไลด์สีฟีโครลาจะปรากฏ ทั้งสองสไลด์ยังคงสีพื้นหลังเดิม

แถวด้านล่างแสดงเฟรมจาก PowerPoint ทุกครึ่งวินาที เปรียบเทียบเฟรมกลางในแต่ละแถวเพื่อดูเอฟเฟกต์

![การเล่น PowerPoint กับการจางผ่านสีดำปิด (บน) และเปิด (ล่าง) ส่วนล่างเท่านั้นที่ผ่านสีดำเกือบเต็ม](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์แสดงบนหน้าจอและว่าการคลิกเมาส์จะเลื่อนการแสดงสไลด์หรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมนี้:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) อนุญาตให้ผู้ชมกดเมาส์เพื่อเลื่อนสไลด์
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดใช้งานการเลื่อนไปอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาที่ตั้งค่าเพื่อให้ผู้ชมสามารถกดคลิกเพื่อเดินหน้าได้หรือรอจนเวลาถึง หากต้องการใช้เฉพาะตัวจับเวลา ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ความล่าช้ากำหนดว่าเมื่อไหร่การแสดงสไลด์จะเลื่อนต่อ; ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลังจาก 3, 5 และ 7 วินาทีตามลำดับ โดยสไลด์เหล่านี้ยังสามารถเลื่อนด้วยการคลิกเมาส์ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าความล่าช้าที่บันทึกไว้เพียงอย่างเดียวไม่บ่งบอกว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดใช้งานแต่ละอัน และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าช้ามากกว่าสองวินาที จากนั้นเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัพเดต

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

## **ควบคุมการตั้งเวลาเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | กำหนดความล่าช้าก่อนสไลด์จะเลื่อนอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานตัวจับเวลานี้ |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium หรือ Fast ใช้เมื่อไม่ได้กำหนดระยะเวลาที่แน่นอน |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; ไม่ได้กำหนดว่ารอบสไลด์จะคงอยู่บนหน้าจอเป็นเวลานานเท่าใด ให้กำหนดความล่าช้าของการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่าระยะเวลาที่ชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าของ [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed)

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแสดงระยะเวลาการเปลี่ยน 750 มิลลิวินาทีและการตั้งค่าการเลื่อนอัตโนมัติ 5,000 มิลลิวินาที](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างร่วมนี้กำหนดให้แต่ละสไลด์มีการเปลี่ยน Fade 750 มิลลิวินาทีและเปิดใช้งานการเลื่อนอัตโนมัติที่ 5,000 มิลลิวินาทีอย่างแยกกัน ระยะเวลาการเปลี่ยนควบคุมเอฟเฟกต์; การเลื่อนควบคุมเวลาที่จะออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าเชิงโครงร่าง ไม่ใช่ไทม์ไลน์รวมที่วัดได้*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้องกัน ใช้เอฟเฟกต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx`, เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), และกำหนดระยะเวลา 750 มิลลิวินาทีให้กับแต่ละการเปลี่ยน อีกทั้งเปิดใช้งานการเลื่อนอัตโนมัติหลังจาก 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

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

        // กำหนดการเลื่อนอัตโนมัติอย่างอิสระจากระยะเวลาเอฟเฟกต์
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **กำหนดระยะเวลาที่แตกต่างสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับสไลด์แนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีให้สไลด์แรกและ 1,200 มิลลิวินาทีให้สไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์แบบเคลื่อนไหว**

เมื่อต้องเตรียม [animated GIF](/slides/th/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/php-java/export-to-html5/), หรือ [video](/slides/th/php-java/convert-powerpoint-to-video/), ให้ตั้งค่าระยะเวลาการเปลี่ยนอย่างแม่นยำก่อนส่งออกเพื่อให้สอดคล้องกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉาก และปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาพูดบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนแบบเคลื่อนไหวในตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในรูปแบบการส่งออกที่เลือกและแสดงตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยนเพื่อกำหนดว่ามีค่าระยะเวลาที่ชัดเจนถูกจัดเก็บหรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่าระยะเวลาที่ชัดเจน; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์ระบุระยะเวลาที่จัดเก็บเป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งค่านี้ไม่ใช่ระยะเวลาการเล่นที่คำนวนได้: Aspose.Slides จะใช้ประเภทการเปลี่ยนและค่าของ [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลานั้น การตั้งค่าชนิดการเปลี่ยนอาจทำให้ระยะเวลาเริ่มต้นได้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้วัตถุระหว่างสไลด์ต่อเนื่องแอนิเมชั่น เพื่อสร้างเอฟเฟกต์ Morph แบบง่าย ให้โคลนสไลด์, ย้ายหรือปรับขนาดวัตถุบนสไลด์โคลน, แล้วใส่การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้จะทำให้วัตถุตรงกันที่ต้องแอนิเมชั่นระหว่างสถานะเดิมและสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ, โคลนสไลด์, แล้วเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสไลด์โคลน จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในโปรแกรมดูพรีเซนเทชันที่สนับสนุน Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

## **ประเภทการเปลี่ยน Morph**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) ควบคุมว่าการจับคู่และแอนิเมชั่นเนื้อหาอย่างไร:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปทรงเป็นวัตถุหนึ่งทั้งหมด
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) ทำแอนิเมชั่นข้อความโดยจับคู่คำที่เป็นไปได้
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) ทำแอนิเมชั่นข้อความโดยจับคู่อักขระที่เป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). ค่าที่ได้จะเป็นอ็อบเจ็กต์ [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดพรีเซนเทชันที่สร้างในส่วนก่อนหน้าและตั้งค่าสไลด์ที่สองให้ใช้แอนิเมชั่น Morph แบบตามคำ

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

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์จะเริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). ตั้งค่าชนิดก่อน, แล้วใช้วัตถุการเปลี่ยนที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx`. มันเรียก [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. ให้ใช้ [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อหมวดความเร็วที่กำหนดล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) — Slow, Medium หรือ Fast — พอใ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ใช่. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), แล้วเปิด [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วย `true`. เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงต่อไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) ของพรีเซนเทชันและเรียก [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) ด้วยค่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวเพื่อให้พฤติกรรมสอดคล้องกันทุกสไลด์

**ฉันจะตรวจสอบการเปลี่ยนที่ตั้งอยู่ในสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์ นั้น มันจะคืนค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); ค่า None หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ