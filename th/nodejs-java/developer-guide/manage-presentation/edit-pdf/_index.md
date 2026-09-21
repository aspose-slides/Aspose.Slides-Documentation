---
title: แก้ไขเอกสาร PDF ด้วย JavaScript
linktitle: แก้ไข PDF
type: docs
weight: 65
url: /th/nodejs-java/edit-pdf/
keywords:
- แก้ไข PDF
- แทนที่ข้อความ PDF
- PDF เป็น PPTX
- PPTX เป็น PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ด้วย JavaScript โดยนำเข้าไปใน Aspose.Slides, แทนที่ข้อความ, และบันทึกงานนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ให้คุณแก้ไขเนื้อหา PDF โดยนำเข้าหน้าต่างเป็นสไลด์ แก้ไขงานนำเสนอ และส่งออกกลับเป็น PDF บทความนี้แสดงการแทนที่ข้อความอย่างง่าย งานนำเสนอคงอยู่ในหน่วยความจำ ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นสิ่งเลือกได้

## **แทนที่ข้อความใน PDF**

ใช้ [addFromPdf](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/#addFromPdf) เพื่อดึงเข้าหน้า, [replaceText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#replaceText) เพื่ออัปเดตข้อความ, และ [save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#save) เพื่อส่งออกผลลัพธ์

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่แก้ไขได้หลังการนำเข้า มันจะแทนที่คำนั้นด้วย "Final" และเขียนเป็น `edited.pdf` การลบสไลด์แรกก่อนการนำเข้าจะป้องกันไม่ให้มีหน้าว่างเพิ่มในผลลัพธ์ การค้นหาจะตรงกับคำเต็มที่มีการใช้ตัวอักษรเดียวกัน; `null` หมายถึงไม่จำเป็นต้องมี callback ผลลัพธ์

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

สำหรับตัวเลือกเพิ่มเติม ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/nodejs-java/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/)

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำได้กับข้อความที่นำเข้า ไม่ใช่ข้อความภายในภาพสแกน การแปลงอาจส่งผลต่อการจัดรูปแบบและการจัดวาง ดังนั้นควรตรวจสอบผลลัพธ์ โดยเฉพาะเมื่อข้อความแทนที่ยาวกว่าข้อความเดิม
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่. คุณสามารถแก้ไขและส่งออกงานนำเสนอเดียวกันในหน่วยความจำได้ ให้บันทึกสำเนา PPTX ก็ต่อเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดู [บันทึกการนำเสนอ](/slides/th/nodejs-java/save-presentation/).

**ทำไมข้อความบางส่วนอาจไม่เปลี่ยนแปลง?**

ตัวอย่างจะตรงกับคำเต็ม "Draft" ที่มีตัวอักษรตรงกัน ข้อความที่นำเข้าในรูปภาพหรือแยกเป็นกรอบข้อความหลายกรอบอาจไม่ตรงกับการค้นหา ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ