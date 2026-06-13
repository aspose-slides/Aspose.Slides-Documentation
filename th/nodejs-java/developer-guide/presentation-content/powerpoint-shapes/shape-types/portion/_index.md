---
title: จัดการส่วนข้อความในงานนำเสนอด้วย JavaScript
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/nodejs-java/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนข้อความในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slidesสำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง"
---
## **ภาพรวม**

ส่วนข้อความเป็นตัวแทนของส่วนย่อยของข้อความภายในย่อหน้าและทำให้คุณสามารถทำงานกับส่วนนั้นแยกจากเนื้อหาที่อยู่รอบๆ ได้ ใน Aspose.Slides สามารถใช้ portion ได้เมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงส่วนหนึ่งของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดมากขึ้น

บทความนี้แสดงวิธีการรับพิกัดของจุดเริ่มต้นของ portion ด้วยเมธอด `getCoordinates()` นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับ portion เช่น การใส่ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบถูกแก้ไขผ่าน portion, paragraph, text frame และการสืบทอดธีมอย่างไร, และการจัดการกรณีที่ฟอนต์ที่ระบุไม่มีอยู่ในระบบ. อีกทั้งยังอธิบายว่าการเติมสีข้อความ, สี, และความโปร่งใสสามารถตั้งค่าแตกต่างกันสำหรับแต่ละ portion ภายในย่อหน้าเดียวได้.

## **รับพิกัดตำแหน่งของ Portion**
เมธอด [**getCoordinates()**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion#getCoordinates--) ถูกเพิ่มเข้ามาในคลาส [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) ซึ่งทำให้สามารถดึงพิกัดของจุดเริ่มต้นของ portion ได้.

```javascript
// สร้างคลาส Presentation ที่แสดงถึงไฟล์ PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // ปรับรูปแบบบริบทของงานนำเสนอ
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับเพียงส่วนหนึ่งของข้อความภายในย่อหน้าเดียวได้หรือไม่?**

ได้, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/nodejs-java/manage-hyperlinks/) ให้กับ portion แต่ละอัน; เพียงส่วนนั้นจะคลิกได้, ไม่ใช่ทั้งย่อหน้า.

**การสืบทอดสไตล์ทำงานอย่างไร: Portion จะครอบคลุมอะไรบ้าง, และอะไรที่ได้รับจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงสุด หากคุณสมบัติบางอย่างไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/), ระบบจะดึงมาจาก [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/); หากไม่ได้ตั้งค่าในนั้นเช่นกัน จะมาจาก [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/theme/).

**จะเกิดอะไรขึ้นหากฟอนต์ที่ระบุสำหรับ Portion ไม่พบบนเครื่อง/เซิร์ฟเวอร์เป้าหมาย?**

[กฎการแทนที่ฟอนต์](/slides/th/nodejs-java/font-selection-sequence/) จะถูกนำมาใช้. ข้อความอาจเปลี่ยนรูปแบบ: เมทริกซ์, การใส่เครื่องหมายยัติภังค์, และความกว้างอาจเปลี่ยนแปลง, ซึ่งสำคัญต่อการวางตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสหรือไล่สีของการเติมข้อความระดับ Portion แยกจากส่วนอื่นของย่อหน้าได้หรือไม่?**

ได้, สีข้อความ, การเติม, และความโปร่งใสในระดับ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) สามารถแตกต่างจากส่วนที่อยู่ติดกันได้.