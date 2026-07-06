---
title: รับขอบเขตส่วนข้อความจากการนำเสนอใน JavaScript
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/nodejs-java/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

ส่วนข้อความเป็นตัวแทนของส่วนย่อยเฉพาะของข้อความภายในย่อหน้าและให้คุณทำงานกับส่วนนั้นแยกจากเนื้อหารอบข้างได้อย่างอิสระ ใน Aspose.Slides สามารถใช้ส่วนข้อความเมื่อคุณต้องการดึงขอบเขตของส่วนข้อความ, ปรับรูปแบบเฉพาะส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับละเอียดกว่า

บทความนี้แสดงวิธีการรับสี่เหลี่ยมขอบเขตของส่วนข้อความโดยใช้ [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getrect/). นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของส่วนข้อความโดยใช้ [Portion.getCoordinates](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getcoordinates/). นอกจากนี้ยังเน้นสถานการณ์ทั่วไปที่เกี่ยวกับส่วนข้อความ เช่น การเพิ่มไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบถูกสืบทอดผ่านส่วน, ย่อหน้า, กรอบข้อความ และธีมอย่างไร, และการจัดการกรณีที่แบบอักษรที่ระบุไม่พร้อมใช้งาน

## **รับขอบเขตของส่วนข้อความ**

ใช้ [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getrect/) เพื่อดึงสี่เหลี่ยมขอบเขตของส่วนข้อความ:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [Portion.getCoordinates](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getcoordinates/) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มไฮเปอร์ลิงก์ให้กับบางส่วนของข้อความในย่อหน้าเดียวได้หรือไม่?**

ได้ คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/nodejs-java/manage-hyperlinks/) ให้กับส่วนข้อความเฉพาะได้; เฉพาะส่วนนั้นจะเป็นลิงก์คลิกได้, ไม่ใช่ทั้งย่อหน้า.

**การสืบทอดสไตล์ทำงานอย่างไร: ส่วนข้อความจะครอบคลุมค่าอะไร และค่าอะไรจะถูกดึงมาจากย่อหน้าหรือกรอบข้อความ?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงสุด หากคุณสมบัติไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/), Aspose.Slides จะดึงมาจาก [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/). หากยังไม่ได้ตั้งค่าในที่นั้นเช่นกัน Aspose.Slides จะใช้สไตล์จาก [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) หรือ [theme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/theme/).

**จะเกิดอะไรขึ้นหากแบบอักษรที่ระบุสำหรับส่วนข้อความไม่มีอยู่บนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[กฎการแทนที่แบบอักษร](/slides/th/nodejs-java/font-selection-sequence/) จะถูกนำไปใช้ ข้อความอาจเปลี่ยนรูปแบบใหม่: เมตริก, การแยกคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งส่งผลต่อการวางตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งใสหรือการไล่สีของการเติมข้อความระดับ Portion อย่างอิสระจากย่อหน้าที่เหลือได้หรือไม่?**

ได้ สีข้อความ, การเติม, และความโปร่งใสที่ระดับ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.