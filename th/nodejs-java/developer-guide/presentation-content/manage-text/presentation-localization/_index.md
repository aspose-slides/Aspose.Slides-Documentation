---
title: ทำให้การแปลภาษาผลงานนำเสนอใน JavaScript เป็นอัตโนมัติ
linktitle: การแปลภาษาผลงานนำเสนอ
type: docs
weight: 100
url: /th/nodejs-java/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจการสะกด
- รหัสภาษา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำให้การแปลภาษาสไลด์ PowerPoint และ OpenDocument ใน JavaScript ด้วย Aspose.Slides เป็นอัตโนมัติ โดยใช้ตัวอย่างโค้ดที่ปฏิบัติได้จริงและเคล็ดลับเพื่อการเปิดตัวสู่ตลาดทั่วโลกอย่างรวดเร็ว"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีตั้งค่า `LanguageId` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีการเปิดงานนำเสนอ, เพิ่มรูปทรงพร้อมข้อความ, กำหนดตัวระบุภาษาให้กับส่วนข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับงานนำเสนอและข้อความของรูปร่าง**

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ประเภท [Rectangle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeType#Rectangle) ลงบนสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- [Setting Language Id](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) ให้กับข้อความ
- บันทึกงานนำเสนอเป็นไฟล์ PPTX

การทำงานของขั้นตอนข้างต้นถูกสาธิตด้านล่างในตัวอย่าง

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**การระบุ Language ID ทำให้เกิดการแปลข้อความอัตโนมัติหรือไม่?**

ไม่. [setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) ใน Aspose.Slides จะเก็บข้อมูลภาษาสำหรับการตรวจสอบการสะกดและไวยากรณ์, แต่ไม่ทำการแปลหรือเปลี่ยนแปลงเนื้อหาข้อความ. มันเป็นเมตาดาต้าที่ PowerPoint เข้าใจเพื่อการตรวจทาน.

**การระบุ Language ID มีผลต่อการเว้นบรรทัดและการแยกคำ (hyphenation) ระหว่างการเรนเดอร์หรือไม่?**

ใน Aspose.Slides, [setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) ใช้สำหรับการตรวจทาน. คุณภาพของการแยกคำและการตัดบรรทัดส่วนใหญ่ขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/nodejs-java/powerpoint-fonts/) และการตั้งค่า layout/line-break ของระบบเขียน. เพื่อให้การเรนเดอร์ถูกต้อง, ให้ทำให้ฟอนต์ที่จำเป็นพร้อมใช้งาน, กำหนดค่า [font substitution rules](/slides/th/nodejs-java/font-substitution/), และ/หรือ [embed fonts](/slides/th/nodejs-java/embedded-font/) ลงในงานนำเสนอ.

**ฉันสามารถตั้งค่าภาษาต่าง ๆ ภายในย่อหน้าเดียวได้หรือไม่?**

ได้. [setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) จะถูกนำไปใช้ระดับส่วนของข้อความ, ดังนั้นย่อหน้าเดียวสามารถผสมหลายภาษาโดยมีการตั้งค่าการตรวจทานที่แตกต่างกันได้.