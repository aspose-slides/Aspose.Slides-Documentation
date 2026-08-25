---
title: การดำเนินการพรีเซนเทชันแบบ Low-Code ใน PHP
linktitle: API Low-Code
type: docs
weight: 50
url: /th/php-java/low-code-presentation-operations/
keywords:
- API พรีเซนเทชันแบบ Low-Code
- แปลงพรีเซนเทชัน
- รวมพรีเซนเทชัน
- วนรอบสไลด์
- วนรอบรูปร่าง
- วนรอบข้อความ
- รวบรวมรูปร่าง
- บีบอัดพรีเซนเทชัน
- ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้
- ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้
- บีบอัดฟอนต์ฝัง
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "ใช้ Aspose.Slides API แบบ Low-Code ใน PHP เพื่อแปลงและรวมพรีเซนเทชัน, วนรอบเนื้อหา, รวบรวมรูปร่าง, และลดขนาดพรีเซนเทชัน"
---
## **ภาพรวม**

เนมสเปซ [aspose.slides](https://reference.aspose.com/slides/th/php-java/aspose.slides/) ให้คลาสช่วยเหลือแบบสเตติกสำหรับการทำงานกับพรีเซนเทชันทั่วไป คลาสเหล่านี้ห่อหุ้มกระบวนการทำงานของโมเดลออบเจกต์ที่ใช้บ่อยในเมธอดที่เน้นจุดประสงค์เฉพาะ ดังนั้นคุณจึงสามารถแปลงหรือรวมไฟล์ได้ ประมวลผลองค์ประกอบของพรีเซนเทชัน รวบรวมรูปร่าง และลบเนื้อหาที่ไม่ได้ใช้ด้วยโค้ดที่สั้นลง

ผู้ช่วยแบบ low‑code มีประโยชน์เมื่อการดำเนินการใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและเวิร์กโฟลว์เริ่มต้นตรงตามความต้องการของคุณ ใช้โมเดลออบเจกต์เต็มของ [Aspose.Slides](https://reference.aspose.com/slides/th/php-java/aspose.slides/) เมื่อคุณต้องการควบคุมระดับละเอียดบนสไลด์เดี่ยว มาสเตอร์ เลย์เอาต์ รูปร่าง การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของพรีเซนเทชัน

ตารางต่อไปสรุปผู้ช่วยที่พร้อมใช้งาน:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/) | แปลงพรีเซนเทชันเป็นรูปแบบอื่นโดยเรียกไฟล์‑to‑ไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/) | รวมไฟล์พรีเซนเทชันเต็มรูปแบบเดียวกัน |
| [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) | เรียกคอลแบ็กสำหรับทุกสไลด์ รูปร่าง ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/) | ดึงรูปร่างทั้งหมดจากพรีเซนเทชันเพื่อประมวลผลหรือวิเคราะห์ซ้ำ |
| [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังอยู่ |

## **แปลงพรีเซนเทชัน**

ใช้ [Convert::autoByExtension](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/#autoByExtension) เมื่อนามสกุลไฟล์ผลลัพธ์เพียงพอในการเลือกรูปแบบการส่งออก เมธอดนี้เปิดพรีเซนเทชันต้นฉบับ กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์ และเขียนผลลัพธ์ออกมา

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF ใช้โมเดลออบเจกต์เต็มเมื่อคุณต้องการตรวจสอบหรือแก้ไขพรีเซนเทชันก่อนส่งออก หรือกำหนดตัวเลือกการส่งออกที่ผู้ช่วยไม่ได้เปิดเผย ดู [Convert Presentation](/slides/th/php-java/convert-presentation/) สำหรับเวิร์กโฟลว์และตัวเลือกตามรูปแบบ

## **รวมพรีเซนเทชัน**

ใช้ [Merger::process](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/#process) เพื่อรวมไฟล์พรีเซนเทชันเต็มรูปแบบด้วยการเรียกครั้งเดียว พรีเซนเทชันที่นำเข้า必须มีรูปแบบไฟล์เดียวกัน

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

ผู้ช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดต้องถูกรวมเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมปแต่ละสไลด์แยกกัน ใช้โมเดลออบเจกต์เต็มเมื่อคุณต้องการรวมสไลด์ที่เลือก ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง เก็บส่วนต่างอย่างชัดเจน หรือปรับขนาดสไลด์ที่ต่างกัน ดู [Merge Presentations](/slides/th/php-java/merge-presentation/) สำหรับกรณีนั้น ๆ

## **วนรอบผ่านองค์ประกอบพรีเซนเทชัน**

คลาส [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) จะเรียกคอลแบ็กสำหรับประเภทขององค์ประกอบพรีเซนเทชันที่คุณร้องขอ มันช่วยหลีกเลี่ยงลูปการเก็บรวบรวมซ้อนกันและสะดวกสำหรับการตรวจสอบหรือเปลี่ยนรูปแบบทั่วพรีเซนเทชัน

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

โดยค่าเริ่มต้น การวนรอบรูปทรงและข้อความทั่วพรีเซนเทชันรวมสไลด์ปกติ, มาสเตอร์และเลย์เอาต์ด้วย เมธอดที่มีพารามิเตอร์ `includeNotes` สามารถประมวลผลสไลด์โน้ตได้ด้วย ใช้ลูปการเก็บรวบรวมโดยตรงเมื่อลำดับการวนรอบ, การออกก่อนเวลา, การกรองก่อนเรียกคอลแบ็ก หรือการควบคุมความสัมพันธ์แม่‑บุตรอย่างละเอียดมีความสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect::shapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในพรีเซนเทชัน แทนการใช้คอลแบ็กสำหรับแต่ละรูปร่าง ซึ่งมีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง นับ หรือประมวลผลหลายครั้ง

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

ใช้ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape) แทนเมื่อสามารถจัดการแต่ละรูปร่างได้ทันทีและไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหาพรีเซนเทชัน**

คลาส [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนต์ที่ฝังไว้ได้:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#removeUnusedMasterSlides) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/#compressEmbeddedFonts) ลบอักขระที่ไม่ได้ใช้จากฟอนต์ฝัง

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

ให้ลบเลย์เอาต์ที่ไม่ใช้ก่อนมาสเตอร์ที่ไม่ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังการทำความสะอาดเลย์เอาต์ถูกลบด้วย บันทึกพรีเซนเทชันที่ทำให้เหมาะสมลงในไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์ หรือข้อมูลฟอนต์ฝังทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/slides/th/php-java/slide-master/) และ [Embedded Font](/slides/th/php-java/embedded-font/)

## **คำถามที่พบบ่อย**

**เมื่อไหร่ที่ควรใช้ API low‑code แทนโมเดลออบเจกต์เต็ม?**

ใช้ผู้ช่วย low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือพรีเซนเทชันทั้งหมดและไม่ต้องการการควบคุมรายละเอียดระดับองค์ประกอบแต่ละตัว ใช้โมเดลออบเจกต์เต็มเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์ ตรวจสอบสถานะกลาง หรือกำหนดพฤติกรรมที่ผู้ช่วยไม่เปิดเผย

**Merger สามารถรวมพรีเซนเทชันที่มีรูปแบบไฟล์ต่างกันได้หรือไม่?**

ไม่ได้. [Merger::process](https://reference.aspose.com/slides/th/php-java/aspose.slides/merger/#process) ต้องการพรีเซนเทชันอินพุตที่มีรูปแบบเดียวกัน แปลงไฟล์อินพุตให้เป็นรูปแบบเดียวกันก่อน เช่นใช้ [Convert::autoByExtension](https://reference.aspose.com/slides/th/php-java/aspose.slides/convert/#autoByExtension) แล้วจึงทำการรวมไฟล์ที่แปลงแล้ว

**ForEach_ ประมวลผลสไลด์มาสเตอร์, เลย์เอาต์ และโน้ตหรือไม่?**

[ForEach_::slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#slide) วนรอบสไลด์พรีเซนเทชันแบบปกติ การทำงานทั่วพรีเซนเทชันของ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#paragraph) และ [ForEach_::portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#portion) รวมสไลด์ปกติ, มาสเตอร์และเลย์เอาต์โดยค่าเริ่มต้น ใช้ overload ที่มี `includeNotes` ตั้งค่าเป็น `true` เพื่อรวมสไลด์โน้ตด้วย

**ความแตกต่างระหว่าง ForEach_::shape กับ Collect::shapes คืออะไร?**

ใช้ [ForEach_::shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/#shape) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ก ใช้ [Collect::shapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการผลลัพธ์ที่สามารถเก็บไว้, กรอง, นับหรือวนรอบหลายครั้ง

**Compress ทำให้ไฟล์พรีเซนเทชันเล็กลงเสมอหรือไม่?**

ไม่จำเป็น ผลลัพธ์ขึ้นกับว่าพรีเซนเทชันมีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้ หรือฟอนต์ฝังที่มีอักขระไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านี้ การดำเนินการ [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) ที่เกี่ยวข้องอาจไม่ได้ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach_ หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่ การช่วยเหลือนี้ทำงานบนอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่โหลดไว้ในหน่วยความจำ หลังจากเปลี่ยนแปลงองค์ประกอบในคอลแบ็กของ [ForEach_](https://reference.aspose.com/slides/th/php-java/aspose.slides/foreach_/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/php-java/aspose.slides/compress/) ต้องเรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [Convert Presentation](/slides/th/php-java/convert-presentation/)
- [Merge Presentations](/slides/th/php-java/merge-presentation/)
- [Slide Master](/slides/th/php-java/slide-master/)
- [Manage Text Box](/slides/th/php-java/manage-textbox/)
- [Embedded Font](/slides/th/php-java/embedded-font/)