---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน PHP
linktitle: API Low-Code
type: docs
weight: 50
url: /th/php-java/low-code-presentation-operations/
keywords:
- API พรีเซนเทชัน low-code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนซ้ำสไลด์
- วนซ้ำรูปร่าง
- วนซ้ำข้อความ
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้
- ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน PHP เพื่อแปลงและรวมพรีเซนเทชัน, วนซ้ำผ่านเนื้อหา, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน"
---
## **ภาพรวม**

เนมสเปซ [aspose.slides](https://reference.aspose.com/slides/th/php-java/aspose.slides/) ให้คลาสช่วยเหลือแบบสเตติกสำหรับการดำเนินการงานพรีเซนเทชันทั่วไป ตัวช่วยเหลือเหล่านี้ห่อหุม workflow ของ object‑model ที่ใช้บ่อยไว้ในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์, ประมวลผลองค์ประกอบของพรีเซนเทชัน, รวบรวมรูปร่าง, และลบเนื้อหาที่ไม่ได้ใช้ได้ด้วยโค้ดที่น้อยลง

Low-code helpers มีประโยชน์สูงสุดเมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและ workflow เริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/php-java/aspose.slides/) เต็มรูปแบบเมื่อต้องการควบคุมในระดับละเอียดของสไลด์แต่ละอัน, มาสเตอร์, เลย์เอาต์, รูปร่าง, การตั้งค่าการส่งออก, หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปนี้สรุปตัวช่วยที่มีอยู่:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/) | การแปลงพรีเซนเทชันเป็นรูปแบบอื่นด้วยการเรียกไฟล์ต่อไฟล์โดยตรง. |
| [Merger](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/) | การรวมไฟล์พรีเซนเทชันทั้งหมดที่มีรูปแบบเดียวกัน. |
| [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) | การเรียกคอลแบ็คสำหรับแต่ละสไลด์, รูปร่าง, ย่อหน้า, หรือส่วนของข้อความ. |
| [Collect](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/) | การดึงรูปทรงจากพรีเซนเทชันทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์ซ้ำ. |
| [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) | การลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่. |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert::autoByExtension](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/#autoByExtension) เมื่อส่วนต่อท้ายของไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดนี้จะเปิดพรีเซนเทชันต้นฉบับ, กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์, และเขียนผลลัพธ์ออกมา.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF อีกด้วย ใช้ object model เต็มรูปแบบเมื่อต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนการส่งออกหรือกำหนดค่าตัวเลือกการส่งออกที่ไม่ได้เปิดเผยโดยตัวช่วยที่เลือก ดูที่ [Convert Presentation](/php-java/convert-presentation/) สำหรับ workflow และตัวเลือกเฉพาะรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger::process](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/#process) เพื่อรวมไฟล์พรีเซนเทชันทั้งหมดด้วยการเรียกครั้งเดียว พรีเซนเทชันอินพุตต้องมีรูปแบบไฟล์เดียวกัน.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะสมเมื่อต้องการเพิ่มสไลด์ทั้งหมดต่อเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือทำแผนที่ใหม่แต่ละสไลด์ ใช้ object model เต็มรูปแบบเมื่อต้องการรวมสไลด์ที่เลือก, ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, เก็บส่วน (section) อย่างชัดเจน, หรือปรับขนาดสไลด์ที่ต่างกัน ดูที่ [Merge Presentations](/php-java/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **วนซ้ำผ่านองค์ประกอบของพรีเซนเทชัน**

คลาส [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) จะเรียกคอลแบ็คสำหรับแต่ละประเภทขององค์ประกอบพรีเซนเทชันที่ร้องขอ มันช่วยหลีกเลี่ยงการวนลูปคอลเลคชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วทั้งพรีเซนเทชัน

ตัวอย่างต่อไปนี้ใช้ [ForEach_::slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#paragraph) และ [ForEach_::portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#portion) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

โดยค่าเริ่มต้น การเดินทางผ่านรูปร่างและข้อความทั่วทั้งพรีเซนเทชันจะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอาต์ การโอเวอร์โหลดที่มีพารามิเตอร์ `includeNotes` สามารถประมวลผลสไลด์โน้ตได้เช่นกัน ใช้ลูปคอลเลคชันโดยตรงเมื่อการจัดลำดับการเดินทาง, การออกก่อนเวลา, การกรองก่อนการเรียกคอลแบ็ค, หรือการควบคุมความสัมพันธ์แม่-ลูกอย่างละเอียดมีความสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect::shapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/#shapes) เมื่อต้องการคอลเลคชันของรูปร่างทั้งหมดในพรีเซนเทชันแทนการใช้คอลแบ็คสำหรับแต่ละรูปร่าง ซึ่งมีประโยชน์เมื่อชุดเดียวกันจะต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

ใช้ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape) แทนเมื่อแต่ละรูปร่างสามารถจัดการได้ทันทีและไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ได้:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedMasterSlides) ลบสไลด์มาสเตอร์ที่ไม่ถูกใช้แล้ว
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#compressEmbeddedFonts) ลบตัวอักษรที่ไม่ได้ใช้จากฟอนต์ที่ฝังอยู่

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ให้ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถลบได้ ให้บันทึกพรีเซนเทชันที่ปรับปรุงแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์ หรือข้อมูลฟอนต์ที่ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดูที่ [Slide Master](/php-java/slide-master/) และ [Embedded Font](/php-java/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ Low‑code API แทนการใช้ object model เต็มรูปแบบ?**

ใช้ตัวช่วย Low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมรายละเอียดของแต่ละองค์ประกอบ ใช้ object model เต็มรูปแบบเมื่อต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะระหว่างขั้นตอน, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่เปิดเผย

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่. [Merger::process](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/#process) ต้องการพรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน ก่อนนั้นให้แปลงไฟล์อินพุตเป็นรูปแบบเดียวกันก่อน ตัวอย่างเช่นใช้ [Convert::autoByExtension](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/#autoByExtension) แล้วจึงรวมไฟล์ที่แปลงแล้ว

**ForEach_ ประมวลผลสไลด์มาสเตอร์, เลย์เอาต์, และโน้ตหรือไม่?**

[ForEach_::slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#slide) จะวนผ่านสไลด์พรีเซนเทชันปกติ การทำงานทั่วทั้งพรีเซนเทชันของ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#paragraph) และ [ForEach_::portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#portion) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอตโดยค่าเริ่มต้น ใช้โอเวอร์โหลดของพวกมันโดยตั้งค่า `includeNotes` เป็น `true` เพื่อรวมสไลด์โน้ต

**ความแตกต่างระหว่าง ForEach_::shape และ Collect::shapes คืออะไร?**

ใช้ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ค ใช้ [Collect::shapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/#shapes) เมื่อต้องการผลลัพธ์ที่เป็น iterable ที่สามารถเก็บไว้, กรอง, นับ, หรือเดินผ่านได้หลายครั้ง

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

ไม่จำเป็นเสมอ ผลลัพธ์ขึ้นอยู่กับว่าพรีเซนเทชันมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนต์ที่ฝังอยู่ซึ่งมีอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านั้น การดำเนินการของ [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) ที่เกี่ยวข้องอาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach_ หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่. ตัวช่วยเหล่านี้ทำงานบนอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่โหลดในหน่วยความจำ หลังจากเปลี่ยนแปลงองค์ประกอบในคอลแบ็คของ [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) ให้เรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [แปลงพรีเซนเทชัน](/php-java/convert-presentation/)
- [รวมพรีเซนเทชัน](/php-java/merge-presentation/)
- [มาสเตอร์สไลด์](/php-java/slide-master/)
- [จัดการกล่องข้อความ](/php-java/manage-textbox/)
- [ฟอนต์ที่ฝังไว้](/php-java/embedded-font/)