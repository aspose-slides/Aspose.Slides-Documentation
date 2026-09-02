---
title: การดำเนินการงานนำเสนอแบบ Low-Code ใน JavaScript
linktitle: API Low-Code
type: docs
weight: 50
url: /th/nodejs-java/low-code-presentation-operations/
keywords:
- API งานนำเสนอแบบ Low-Code
- แปลงงานนำเสนอ
- รวมงานนำเสนอ
- วนรอบสไลด์
- วนรอบรูปร่าง
- วนรอบข้อความ
- รวบรวมรูปร่าง
- บีบอัดงานนำเสนอ
- ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้
- ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้
- บีบอัดฟอนท์ที่ฝังอยู่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้ Aspose.Slides low-code API ใน JavaScript เพื่อแปลงและรวมงานนำเสนอ, วนรอบเนื้อหา, รวบรวมรูปร่าง, และลดขนาดของงานนำเสนอ"
---
## **ภาพรวม**

`aspose.slides` เนมสเปซให้คลาส helper แบบสถิตสำหรับการทำงานทั่วไปของงานนำเสนอ Helper เหล่านี้ห่อหุ้มกระบวนการโมเดลวัตถุที่ใช้บ่อยในเมธอดที่มุ่งเน้น ทำให้คุณสามารถแปลงหรือรวมไฟล์ ประมวลผลองค์ประกอบของงานนำเสนอ รวบรวมรูปร่าง และลบเนื้อหาที่ไม่ได้ใช้ด้วยโค้ดที่น้อยลง

Low-code helper มีประโยชน์มากที่สุดเมื่อการดำเนินการใช้กับไฟล์หรือการนำเสนอทั้งหมดและกระบวนการทำงานเริ่มต้นตรงกับความต้องการของคุณ ให้ใช้ [Aspose.Slides object model](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/) อย่างเต็มรูปแบบเมื่อคุณต้องการการควบคุมระดับละเอียดบนสไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, การตั้งค่าการส่งออก หรือความสัมพันธ์ระหว่างองค์ประกอบของงานนำเสนอ

ตารางต่อไปนี้สรุปตัวช่วยที่มีให้:

| ตัวช่วย | ใช้สำหรับ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/) | แปลงงานนำเสนอเป็นรูปแบบอื่นโดยใช้การเรียกไฟล์ต่อไฟล์โดยตรง |
| [Merger](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/) | รวมไฟล์งานนำเสนอเต็มรูปแบบที่เป็นรูปแบบเดียวกัน |
| [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) | เรียกใช้การทำงานสำหรับแต่ละสไลด์, รูปร่าง, ย่อหน้า หรือส่วนของข้อความ |
| [Collect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/) | ดึงรูปร่างจากงานนำเสนอทั้งหมดเพื่อการประมวลผลหรือวิเคราะห์หลายครั้ง |
| [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) | ลบมาสเตอร์และเลย์เอาต์ที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังอยู่ |

## **แปลงงานนำเสนอ**

ใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/#autoByExtension) เมื่อส่วนต่อท้ายไฟล์ผลลัพธ์เพียงพอที่จะเลือกรูปแบบการส่งออก เมธอดจะเปิดงานนำแหล่งที่มา กำหนดรูปแบบที่ต้องการจากเส้นทางไฟล์ผลลัพธ์ และเขียนผลลัพธ์

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

คลาส [Convert](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/) ยังมีเมธอดเฉพาะสำหรับการส่งออกเป็น PDF, SVG, JPEG, PNG, และ TIFF. ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการตรวจสอบหรือแก้ไขงานนำเสนอก่อนการส่งออก หรือกำหนดค่าตัวเลือกการส่งออกที่ไม่ได้เปิดเผยโดยตัวช่วยที่เลือก ดู [Convert Presentation](/nodejs-java/convert-presentation/) สำหรับกระบวนการทำงานและตัวเลือกตามรูปแบบ

## **รวมงานนำเสนอ**

ใช้ [Merger.process](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/#process) เพื่อรวมไฟล์งานนำเสนอเต็มรูปแบบด้วยการเรียกครั้งเดียว งานนำเข้าต้องมีรูปแบบไฟล์เดียวกัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

ตัวช่วยนี้เหมาะเมื่อสไลด์ทั้งหมดควรถูกต่อท้ายเป็นผลลัพธ์เดียวโดยไม่ต้องเลือกหรือแมพใหม่แต่ละสไลด์ ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการรวมสไลด์ที่เลือก ใช้มาสเตอร์หรือเลย์เอาต์ปลายทาง, รักษาภาคอย่างชัดเจน, หรือปรับขนาดสไลด์ที่แตกต่างกัน ดู [Merge Presentations](/nodejs-java/merge-presentation/) สำหรับสถานการณ์เหล่านั้น

## **วนรอบผ่านองค์ประกอบของงานนำเสนอ**

คลาส [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) เรียก callback สำหรับแต่ละประเภทขององค์ประกอบงานนำเสนอที่ต้องการ มันช่วยหลีกเลี่ยงลูปคอลเลกชันซ้อนกันและสะดวกสำหรับการตรวจสอบหรือการเปลี่ยนแปลงรูปแบบทั่วงานนำเสนอ ใน Node.js สร้างการนำเข้า interface callback ด้วย `java.newProxy`

ตัวอย่างต่อไปนี้ใช้ [ForEach.slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#paragraph), และ [ForEach.portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#portion) เพื่อตรวจสอบองค์ประกอบที่สอดคล้องกัน:

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

โดยค่าเริ่มต้น การเดินทางผ่านรูปร่างและข้อความทั่วงานนำเสนอรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอ็ต การ overload ที่มีพารามิเตอร์ `includeNotes` สามารถประมวลผลสไลด์บันทึกได้ ใช้ลูปคอลเลกชันโดยตรงเมื่อลำดับการเดินทาง, การออกก่อนหน้า, การกรองก่อนเรียก callback, หรือการควบคุมความสัมพันธ์พาเรนท์-ชิลด์อย่างละเอียดเป็นสิ่งสำคัญ

## **รวบรวมรูปร่าง**

ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการคอลเลกชันของรูปร่างทั้งหมดในงานนำเสนอแทนการใช้ callback สำหรับแต่ละรูปร่าง นี้มีประโยชน์เมื่อชุดเดียวกันต้องถูกกรอง, นับ, หรือประมวลผลหลายครั้ง

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

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape) แทนเมื่อแต่ละรูปร่างสามารถจัดการได้ทันทีและคุณไม่จำเป็นต้องเก็บผลลัพธ์ที่รวบรวมไว้

## **บีบอัดเนื้อหางานนำเสนอ**

คลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) สามารถลบองค์ประกอบโครงสร้างที่ไม่ได้ใช้และลดข้อมูลฟอนท์ที่ฝังอยู่:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) ลบสไลด์เลย์เอาต์ที่ไม่มีสไลด์ปกติอ้างอิง
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้แล้ว
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

ลบเลย์เอาต์ที่ไม่ได้ใช้ก่อนมาสเตอร์ที่ไม่ได้ใช้ เพื่อให้มาสเตอร์ที่กลายเป็นไม่มีการอ้างอิงหลังจากทำความสะอาดเลย์เอาต์ก็สามารถถูกลบได้ บันทึกงานนำเสนอที่ปรับแต่งแล้วเป็นไฟล์ใหม่หากคุณอาจต้องการมาสเตอร์, เลย์เอาต์ หรือข้อมูลฟอนท์ที่ฝังอยู่แบบเต็มในภายหลัง สำหรับรายละเอียดเพิ่มเติม ดู [Slide Master](/nodejs-java/slide-master/) และ [Embedded Font](/nodejs-java/embedded-font/)

## **FAQ**

**เมื่อไหร่ควรใช้ low-code API แทนการใช้โมเดลวัตถุเต็มรูปแบบ?**

ใช้ low-code helper เมื่อการดำเนินการมาตรฐานใช้กับไฟล์หรือการนำเสนอทั้งหมดและไม่ต้องการการควบคุมอย่างละเอียดบนแต่ละองค์ประกอบ ใช้โมเดลวัตถุเต็มรูปแบบเมื่อคุณต้องการเลือกสไลด์เฉพาะ, ควบคุมความสัมพันธ์ของมาสเตอร์และเลย์เอาต์, ตรวจสอบสถานะกลาง, หรือกำหนดพฤติกรรมที่ตัวช่วยไม่ได้เปิดเผย

**Merger สามารถรวมงานนำเสนอในรูปแบบไฟล์ที่แตกต่างกันได้หรือไม่?**

ไม่ได้. [Merger.process](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/merger/#process) ต้องการงานนำเข้าที่มีรูปแบบไฟล์เดียวกัน ก่อนที่จะรวมให้แปลงไฟล์อินพุตเป็นรูปแบบเดียวกันก่อน ตัวอย่างเช่นใช้ [Convert.autoByExtension](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/convert/#autoByExtension), จากนั้นจึงรวมไฟล์ที่แปลงแล้ว

**ForEach ประมวลผลสไลด์มาสเตอร์, เลย์เอต, และบันทึกหรือไม่?**

[ForEach.slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#slide) วนผ่านสไลด์ปกติของงานนำเสนอ การดำเนินการทั่วงานนำเสนอของ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#paragraph), และ [ForEach.portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#portion) จะรวมสไลด์ปกติ, มาสเตอร์, และเลย์เอ็ตโดยค่าเริ่มต้น ใช้ overload ของพวกมันโดยกำหนด `includeNotes` เป็น `true` เพื่อรวมสไลด์บันทึก

**ความแตกต่างระหว่าง ForEach.shape และ Collect.shapes คืออะไร?**

ใช้ [ForEach.shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/#shape) เพื่อประมวลผลแต่ละรูปร่างทันทีผ่าน callback. ใช้ [Collect.shapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/collect/#shapes) เมื่อคุณต้องการผลลัพธ์ที่สามารถวนซ้ำได้ ซึ่งสามารถเก็บ, กรอง, นับ, หรือเดินทางหลายครั้ง

**Compress ทำให้ไฟล์งานนำเสนอเล็กลงเสมอหรือไม่?**

ไม่จำเป็น. ผลลัพธ์ขึ้นอยู่กับว่ามีเลย์เอาต์ที่ไม่ได้ใช้, มาสเตอร์ที่ไม่ได้ใช้, หรือฟอนท์ที่ฝังอยู่ซึ่งมีอักขระที่ไม่ได้ใช้หรือไม่ หากไม่มีสิ่งเหล่านั้น การดำเนินการ [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) ที่เกี่ยวข้องอาจไม่ลดขนาดไฟล์

**การเปลี่ยนแปลงที่ทำโดย ForEach หรือ Compress จะถูกบันทึกโดยอัตโนมัติหรือไม่?**

ไม่. ตัวช่วยเหล่านี้ทำงานบนอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่โหลดอยู่ในหน่วยความจำ หลังจากเปลี่ยนแปลงองค์ประกอบใน callback ของ [ForEach](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/foreach/) หรือเรียกใช้ [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) ให้เรียก [Presentation.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์

## **Related Articles**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)