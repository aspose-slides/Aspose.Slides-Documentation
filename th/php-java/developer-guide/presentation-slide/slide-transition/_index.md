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
- ชนิดการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph พร้อมเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมว่าภาพสไลด์จะแสดงอย่างไรระหว่างการนำเสนอ ด้วย Aspose.Slides for PHP via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการเลื่อนต่อด้วยการคลิกเมาส์หรือเครื่องจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงสำหรับเอฟเฟกต์นั้น บทความนี้ใช้ตัวอย่าง PHP เพื่อนำการเปลี่ยนไปใช้ การตั้งค่าระยะเวลาการเปลี่ยนให้แม่นยำ การจัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้ [setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitiontype/) จากนั้นบันทึกงานนำเสนอ

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

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดว่าหนึ่งสไลด์จะคงอยู่บนหน้าจอนานเท่าใดและว่าจะให้การคลิกเมาส์ทำให้การนำเสนอเลื่อนไปข้างหน้า วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ให้ผู้ชมเลื่อนโดยคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดการเลื่อนอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติ เป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถกดคลิกเพื่อดำเนินการต่อหรือรอจนกว่าเครื่องจับเวลาจะทำงาน หากต้องการใช้เฉพาะเครื่องจับเวลา ให้ส่งค่า `false` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ความล่าช้านั้นควบคุมเวลาที่การนำเสนอเลื่อนหน้า ไม่ได้กำหนดระยะเวลาแสดงเอฟเฟกต์การเปลี่ยน

ตัวอย่างนี้กำหนดเอฟเฟกต์ที่ต่างกันให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลัง 3, 5 และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ด้วย ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาเปิดอยู่หรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าความล่าช้าที่เก็บไว้เพียงอย่างเดียวไม่ได้บ่งบอกว่าเครื่องจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานเครื่องจับเวลาที่เปิดอยู่ และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าชุมากกว่าสองวินาที แล้วเปิดใช้งานการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าที่อัปเดต

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

## **ควบคุมเวลาเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setDuration) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที วิธี [getSlideShowTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/) :

| Method | Purpose |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | กำหนดความล่าช้าก่อนที่สไลด์จะเลื่อนไปโดยอัตโนมัติเป็นมิลลิวินาที ส่งค่า `true` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานเครื่องจับเวลานี้ |
| [setSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก enumeration [TransitionSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionspeed/) : Slow, Medium, หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่แน่นอน |

[setDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดระยะเวลาที่สไลด์ค้างอยู่บนหน้าจอ ให้กำหนดความล่าช้าการเลื่อนอัตโนมัติแยกกัน เมื่อไม่ได้ตั้งค่าระยะเวลาอย่างชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [getSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getSpeed)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสอดคล้อง ใช้เอฟเฟกต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitiontype/) และกำหนดระยะเวลาให้แต่ละการเปลี่ยนเป็น 750 มิลลิวินาที โดยแยกเปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ จากนั้นบันทึกผลลัพธ์เป็น PPTX

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

        // กำหนดการเลื่อนอัตโนมัติอย่างอิสระจากระยะเวลาเอฟเฟกต์.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ตั้งค่าระยะเวลาที่แตกต่างสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนที่สั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนที่ยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์แบบเคลื่อนที่**

เมื่อเตรียม [animated GIF](/slides/th/php-java/convert-powerpoint-to-animated-gif/) , [HTML5 presentation](/slides/th/php-java/export-to-html5/) หรือ [video](/slides/th/php-java/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาการเปลี่ยนให้แม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉากและปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาแบ่งปันการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนแบบเคลื่อนที่ในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่รองรับของรูปแบบการส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าที่ระบุไว้หรือไม่ ค่าที่เป็น `-1` หมายความว่าไม่ได้ตั้งค่าระยะเวลาที่ชัดเจน ค่าที่ไม่เป็นลบระบุระยะเวลาที่เก็บเป็นมิลลิวินาที ค่าไม่ได้ตั้งค่านี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่า [getSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจทำให้ระยะเวลาเริ่มต้นได้ ดังนั้นตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเกิดการเคลื่อนไหว เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนาแล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง ทำให้วัตถุตรงกันที่ต้องเคลื่อนที่ระหว่างสถานะเดิมและแก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในตัวแสดงงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการนำเสนอ

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

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionmorphtype/#ByObject) ถือแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionmorphtype/#ByWord) เคลื่อนที่ข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionmorphtype/#ByChar) เคลื่อนที่ข้อความโดยจับคู่ตัวอักษรเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getValue) ค่าที่ได้จะให้วัตถุ [MorphTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/th/php-java/aspose.slides/morphtransition/#setMorphType) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph ตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setType) ตั้งค่าชนิดก่อนแล้วใช้วัตถุการเปลี่ยนที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` เรียก [setFromBlack](https://reference.aspose.com/slides/th/php-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่ ให้ใช้ [setDuration](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อต้องการหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionspeed/) (Slow, Medium, หรือ Fast) เพียงพอและไม่ได้ตั้งค่าระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความล่าช้าการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและให้วนซ้ำได้หรือไม่?**

ใช่ กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setSoundMode) แล้วเปิด [setSoundLoop](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วย `true` เสียงจะวนจนกว่าจะมีเหตุการณ์เสียงถัดไปในการนำเสนอ

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#setType) ด้วยค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดตั้งอยู่บนสไลด์ในขณะนี้ได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์ มันจะส่งค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/php-java/aspose.slides/transitiontype/) ; None หมายถึงไม่มีเอฟเฟกต์การเปลี่ยนใด ๆ ถูกใช้งาน