---
title: จัดการข้อความในงานนำเสนอใน Node.js ผ่าน .NET
linktitle: จัดการข้อความ
type: docs
weight: 50
url: /th/nodejs-net/manage-text/
keywords:
- ข้อความ
- กล่องข้อความ
- เพิ่มข้อความ
- เปลี่ยนข้อความ
- จัดรูปแบบข้อความ
- ขนาดแบบอักษร
- ข้อความหนา
- กรอบข้อความ
- ย่อหน้า
- ส่วนข้อความ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มกล่องข้อความลงในสไลด์ แล้วเปลี่ยนข้อความ ขนาดแบบอักษร และรูปแบบตัวหนาใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน .NET."
---
## **ภาพรวม**

ใน Aspose.Slides ข้อความบนสไลด์เป็นส่วนหนึ่งของรูปทรง รูปร่างอัตโนมัติ เช่น สี่เหลี่ยม มีกรอบข้อความ; กรอบข้อความมีย่อหน้าต่าง ๆ และแต่ละย่อหน้ามีส่วนย่อย (portion) ซึ่งเป็นชุดข้อความที่มีการจัดรูปแบบเดียวกัน คุณสามารถเปลี่ยนข้อความได้ผ่านกรอบข้อความและเปลี่ยนแบบอักษรได้ผ่านการจัดรูปแบบของส่วนย่อย

บทความนี้เพิ่มกล่องข้อความลงในสไลด์และบันทึกพรีเซนเทชัน จากนั้นเปิดไฟล์ที่บันทึกและเปลี่ยนข้อความของกล่องข้อความ, ขนาดแบบอักษร, และรูปแบบตัวหนา

ตัวอย่างต้องการให้ตั้งค่าโครงการตามที่อธิบายไว้ใน [Installation](/slides/th/nodejs-net/installation/). บันทึกแต่ละตัวอย่างเป็นไฟล์ `.js` ในโฟลเดอร์โครงการและเรียกใช้จากโฟลเดอร์นั้นด้วย `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides สำหรับ Node.js ผ่าน .NET ไม่มีเอกสารอ้างอิง API ของตนเอง มันเป็นการสังเคราะห์ API ของ Aspose.Slides สำหรับ .NET ด้วยชื่อแบบ camelCase ดังนั้นลิงก์ API ในบทความนี้จะแสดงคลาสและสมาชิกที่สอดคล้องใน [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/th/net/).
{{% /alert %}}

## **เพิ่มกล่องข้อความ**

เพื่อเพิ่มกล่องข้อความ ให้เพิ่มรูปร่างอัตโนมัติลงในสไลด์ด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/shapecollection/addautoshape/) และใส่ข้อความด้วยเมธอด [addTextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/addtextframe/). ตัวอย่างต่อไปนี้เพิ่มสี่เหลี่ยมลงในสไลด์แรกของพรีเซนเทชันใหม่และบันทึกพรีเซนเทชันเป็น `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // ตำแหน่ง (x, y) และขนาด (width, height) มีหน่วยเป็นพอยต์.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

สไลด์ใน `text-box.pptx` มีสี่เหลี่ยมที่กว้าง 500 พอยต์และสูง 80 พอยต์ พร้อมข้อความ "Quarterly report" ด้วยแบบอักษรและขนาดเริ่มต้น ตัวอย่างต่อไปจะเปลี่ยนกล่องข้อความนี้

## **เปลี่ยนข้อความและการจัดรูปแบบของมัน**

ตัวอย่างต่อไปนี้เปิดไฟล์ `text-box.pptx` ซึ่งสร้างจากตัวอย่างก่อนหน้าและดึงรูปร่างแรกบนสไลด์แรก รูปร่างเช่นรูปภาพและตารางไม่มีกรอบข้อความดังนั้นตัวอย่างจะตรวจสอบว่ารูปร่างเป็น [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ก่อนที่จะใช้ [textFrame](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/textframe/) ของรูปร่างนั้น แล้วทำตามขั้นตอนต่อไปนี้:

1. มันแทนที่ข้อความโดยใช้คุณสมบัติ [text](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/text/) ของกรอบข้อความ หลังจากนั้นกรอบข้อความจะมีหนึ่งย่อหน้าที่มีหนึ่งส่วน
1. มันดึงส่วนนั้นจากคอลเลกชัน [paragraphs](https://reference.aspose.com/slides/th/net/aspose.slides/textframe/paragraphs/) และ [portions](https://reference.aspose.com/slides/th/net/aspose.slides/paragraph/portions/) แล้วอ่าน [portionFormat](https://reference.aspose.com/slides/th/net/aspose.slides/portion/portionformat/) ของมัน
1. มันกำหนดค่า [fontHeight](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontheight/), ขนาดแบบอักษรเป็นพอยต์, และ [fontBold](https://reference.aspose.com/slides/th/net/aspose.slides/baseportionformat/fontbold/), ซึ่งรับค่า [NullableBool](https://reference.aspose.com/slides/th/net/aspose.slides/nullablebool/)

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

ใน `text-box-updated.pptx` กล่องข้อความจะแสดง "Quarterly report: third quarter" ด้วยแบบอักษรตัวหนาขนาด 32 พอยต์ เพราะข้อความใหม่เป็นส่วนเดียวสองคุณสมบัติจัดรูปแบบจึงใช้กับทั้งหมด หากไม่มีใบอนุญาต การบันทึกทุกครั้งจะเพิ่มลายน้ำการประเมินผล เนื่องจาก `text-box.pptx` ถูกบันทึกในโหมดการประเมิน `text-box-updated.pptx` จึงมีลายน้ำสองครั้ง; ดูที่ [Evaluate Aspose.Slides](/slides/th/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**ทำไม `fontBold` ถึงรับค่า `NullableBool` แทน `true` หรือ `false`?**

ส่วนหนึ่งอาจไม่กำหนดค่าคุณสมบัติโดยปล่อยให้เป็น undefined และสืบทอดจากย่อหน้า, รูปร่าง, หรือเลย์เอาต์และมาสเตอร์ของสไลด์ `NullableBool.NotDefined` หมายถึง "สืบทอด", ในขณะที่ `NullableBool.True` และ `NullableBool.False` จะทับค่าที่สืบทอด การกำหนดค่า `true` หรือ `false` จะทำให้เกิดข้อผิดพลาด เหตุผลเดียวกันทำให้ `fontHeight` คืนค่า `NaN` เมื่อส่วนสืบทอดขนาดแบบอักษร

**ฉันจะเปลี่ยนสีข้อความได้อย่างไร?**

กำหนดการเติมของ portionFormat: ตั้งค่า `FillType.Solid` ให้กับ `portionFormat.fillFormat.fillType` แล้วตั้งค่าสี เช่น `"#FF0000"` ให้กับ `portionFormat.fillFormat.solidFillColor.color`. เพิ่ม `FillType` ไปยังชื่อที่คุณนำเข้าจากแพ็กเกจ

**ฉันจะจัดรูปแบบเฉพาะส่วนของข้อความได้อย่างไร?**

การจัดรูปแบบเป็นของแต่ละ portion ดังนั้นให้แยกส่วนของข้อความนั้นเป็น portion ของตัวเอง สร้าง portion ด้วย `Portion.CreatePortionFromText`, เพิ่มเข้าไปในย่อหน้าด้วยเมธอด `add` ของคอลเลกชัน `portions` ของย่อหน้า, จากนั้นกำหนด `portionFormat` ของ portion ใหม่. เพิ่ม `Portion` ไปยังชื่อที่คุณนำเข้าจากแพ็กเกจ

**ทำไมการอ่านข้อความจึงคืนค่า "... text has been truncated due to evaluation version limitation"?**

หากไม่มีใบอนุญาต Aspose.Slides จะคืนค่าเฉพาะห้าตัวอักษรแรกของข้อความที่ยาวกว่าเมื่อคุณอ่าน เช่น `textFrame.text` แล้วตามด้วยข้อความแจ้งนี้ ข้อความที่คุณเขียนจะถูกบันทึกเต็มรูปแบบ ให้ใช้ใบอนุญาตตามที่อธิบายใน [Licensing](/slides/th/nodejs-net/licensing/) เพื่ออ่านข้อความทั้งหมด