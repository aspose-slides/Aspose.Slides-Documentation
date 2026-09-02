---
title: การดำเนินการนำเสนอแบบ Low-Code ใน JavaScript
linktitle: API Low-Code
type: docs
weight: 50
url: /th/nodejs-java/low-code-presentation-operations/
keywords:
- API การนำเสนอแบบ Low-Code
- แปลงการนำเสนอ
- ผสานการนำเสนอ
- วนรอบสไลด์
- วนรอบรูปร่าง
- วนรอบข้อความ
- รวบรวมรูปร่าง
- บีบอัดการนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบสไลด์การจัดวางที่ไม่ได้ใช้
- บีบอัดฟอนท์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน JavaScript เพื่อแปลงและผสานการนำเสนอ, วนรอบเนื้อหา, รวบรวมรูปร่าง, และลดขนาดการนำเสนอ"
---
## **ภาพรวม**

เนมสเปซ `aspose.slides` ให้คลาสช่วยเหลือแบบสแตติกสำหรับการดำเนินการนำเสนอทั่วไป ตัวช่วยเหล่านี้ห่อหุ้มกระบวนการทำงานของโมเดลวัตถุที่ใช้บ่อยเป็นเมธอดที่เน้นจุดประสงค์ เพื่อให้คุณสามารถแปลงหรือรวมไฟล์ ประมวลผลองค์ประกอบของการนำเสนอ รวบรวมรูปร่าง และลบเนื้อหาที่ไม่ได้ใช้ได้โดยโค้ดน้อยลง

ตัวช่วยแบบ low‑code มีประโยชน์ที่สุดเมื่อการดำเนินการครอบคลุมไฟล์หรือการนำเสนอทั้งหมดและกระบวนการทำงานค่าเริ่มต้นตรงกับความต้องการของคุณ ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/) อย่างเต็มรูปแบบเมื่อคุณต้องการควบคุมระดับละเอียดบนสไลด์แต่ละสไลด์ มาสเตอร์ ใช้รูปแบบ รูปร่าง การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของการนำเสนอ

ตารางต่อไปสรุปตัวช่วยที่มีอยู่:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [แปลง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/) | แปลงการนำเสนอเป็นรูปแบบอื่นโดยการเรียกไฟล์‑to‑ไฟล์โดยตรง |
| [ผสาน](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/) | รวมไฟล์การนำเสนอเต็มรูปแบบที่มีรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) | เรียกกระทำสำหรับแต่ละสไลด์ รูปร่าง ย่อหน้า หรือส่วนของข้อความ |
| [รวบรวม](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/) | ดึงรูปร่างจากการนำเสนอทั้งหมดเพื่อประมวลผลหรือวิเคราะห์ซ้ำ |
| [บีบอัด](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) | ลบมาสเตอร์และการจัดวางที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังอยู่ |

## **แปลงการนำเสนอ**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/#autoByExtension) เมื่อส่วนขยายไฟล์ผลลัพธ์เพียงพอสำหรับการเลือกรูปแบบการส่งออก เมธอดจะเปิดการนำเสนอต้นทาง กำหนดรูปแบบที่ต้องการจากเส้นทางผลลัพธ์ และเขียนผลลัพธ์ออกไป

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [แปลง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG และ TIFF อีกด้วย ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขการนำเสนอก่อนการส่งออก หรือกำหนดตัวเลือกการส่งออกที่ตัวช่วยไม่ได้เปิดเผย ดู [Convert Presentation](/slides/th/nodejs-java/convert-presentation/) สำหรับขั้นตอนและตัวเลือกเฉพาะรูปแบบ

## **ผสานการนำเสนอ**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/#process) เพื่อรวมไฟล์การนำเสนอเต็มรูปแบบด้วยการเรียกครั้งเดียว การนำเสนอที่นำเข้าต้องมีรูปแบบไฟล์เดียวกัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรถูกต่อท้ายเป็นผลลัพธ์หนึ่งโดยไม่ต้องเลือกหรือแมปใหม่เป็นรายสไลด์ ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการผสานสไลด์ที่เลือกใช้งาน ใส่มาสเตอร์หรือการจัดวางปลายทาง รักษาส่วนต่างโดยเจาะจง หรือจัดการขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/slides/th/nodejs-java/merge-presentation/) สำหรับกรณีเหล่านั้น

## **วนรอบผ่านองค์ประกอบการนำเสนอ**

คลาส [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) จะเรียกคอลแบ็กสำหรับแต่ละประเภทขององค์ประกอบการนำเสนอที่ระบุ มันช่วยลดการวนลูปเก็บรวบรวมแบบซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วการนำเสนอ ใน Node.js ให้สร้างการนำเข้าของอินเทอร์เฟซคอลแบ็กด้วย `java.newProxy`

ตัวอย่างต่อไปนี้ใช้ [ForEach.slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#paragraph) และ [ForEach.portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#portion) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

โดยค่าปริยาย การเดินทางผ่านรูปร่างและข้อความทั่วทั้งการนำเสนอรวมสไลด์แบบปกติ มาสเตอร์ และการจัดวางด้วย การโอเวอร์โหลดที่มีพารามิเตอร์ `includeNotes` ยังสามารถประมวลผลสไลด์บันทึกได้ ใช้ลูปการเก็บรวบรวมโดยตรงเมื่อลำดับการเดินทาง ความต้องการออกก่อนเวลาอายุการกรองก่อนการเรียกคอลแบ็ก หรือการควบคุมพาเรนท์‑ชิลด์อย่างละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการชุดของรูปร่างทั้งหมดในการนำเสนอแทนการใช้คอลแบ็กสำหรับแต่ละรูปร่าง นี่มีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง นับ หรือประมวลผลหลายครั้ง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

หากต้องการจัดการแต่ละรูปร่างทันทีและไม่ต้องการเก็บผลลัพธ์ที่รวบรวมไว้ ให้ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape) แทน

## **บีบอัดเนื้อหาการนำเสนอ**

คลาส [บีบอัด](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังอยู่ได้:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) ลบสไลด์การจัดวางที่สไลด์ปกติไม่มีการอ้างอิง
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) ลบมาสเตอร์สไลด์ที่ไม่ถูกใช้งานอีกต่อไป
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) ลบอักขระที่ไม่ได้ใช้จากฟอนท์ที่ฝังอยู่

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ให้ลบการจัดวางที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดการจัดวางก็สามารถลบได้ด้วย บันทึกการนำเสนอที่ปรับให้เหมาะสมเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์ การจัดวาง หรือข้อมูลฟอนท์ที่ฝังอยู่ทั้งหมดในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/slides/th/nodejs-java/slide-master/) และ [Embedded Font](/slides/th/nodejs-java/embedded-font/)

## **FAQ**

**ควรใช้ API แบบ low‑code แทนโมเดลวัตถุเต็มรูปแบบเมื่อไร?**

ใช้ตัวช่วยแบบ low‑code เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการควบคุมรายละเอียดบนองค์ประกอบแต่ละอัน ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการเลือกสไลด์เฉพาะ ควบคุมความสัมพันธ์ระหว่างมาสเตอร์และการจัดวาง ตรวจสอบสถานะกลาง หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถผสานการนำเสนอในรูปแบบไฟล์ที่แตกต่างกันได้หรือไม่?**

ไม่ได้ ตัวช่วย [Merger.process](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/#process) ต้องการการนำเข้าที่มีรูปแบบเดียวกันก่อน ให้แปลงไฟล์อินพุตเป็นรูปแบบร่วมกันก่อน เช่นใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/#autoByExtension) แล้วจึงผสานไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลสไลด์มาสเตอร์ การจัดวางและบันทึกหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#slide) วนผ่านสไลด์การนำเสนอแบบปกติ การทำงานทั่วการนำเสนอของ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#paragraph) และ [ForEach.portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#portion) จะรวมสไลด์ปกติ มาสเตอร์และการจัดวางเป็นค่าเริ่มต้น ใช้โอเวอร์โหลดโดยตั้งค่า `includeNotes` เป็น `true` เพื่อรวมสไลด์บันทึกด้วย

**ความแตกต่างระหว่าง ForEach.shape และ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่านคอลแบ็ก ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการผลลัพธ์ที่สามารถเก็บไว้ กรอง นับ หรือเดินทางหลายครั้งได้

**Compress ทำให้ไฟล์การนำเสนอเล็กลงเสมอหรือไม่?**

ไม่เสมอ ผลลัพธ์ขึ้นอยู่กับว่าการนำเสนอมีการจัดวางที่ไม่ได้ใช้ มาสเตอร์ที่ไม่ได้ใช้ หรือฟอนท์ที่ฝังอยู่โดยมีอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านั้น การดำเนินการ [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) ที่เกี่ยวข้องอาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกอัตโนมัติหรือไม่?**

ไม่ ตัวช่วยเหล่านี้ทำงานบนอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากแก้ไของค์ประกอบในคอลแบ็กของ [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) หรือรัน [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์

## **บทความที่เกี่ยวข้อง**

- [Convert Presentation](/slides/th/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/th/nodejs-java/merge-presentation/)
- [Slide Master](/slides/th/nodejs-java/slide-master/)
- [Manage Text Box](/slides/th/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/th/nodejs-java/embedded-font/)