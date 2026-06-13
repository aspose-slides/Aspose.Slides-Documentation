---
title: "อัตโนมัติการแปลงานนำเสนอใน Java"
linktitle: "การแปลงานนำเสนอ"
type: docs
weight: 100
url: /th/java/presentation-localization/
keywords:
- "เปลี่ยนภาษา"
- "ตรวจการสะกด"
- "รหัสภาษา"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "อัตโนมัติการแปลสไลด์ PowerPoint และ OpenDocument ใน Java ด้วย Aspose.Slides โดยใช้ตัวอย่างโค้ดที่ใช้งานได้จริงและเคล็ดลับเพื่อการเปิดตัวสู่ระดับโลกที่เร็วขึ้น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีตั้งค่า `LanguageId` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides แสดงวิธีเปิดงานนำเสนอ, เพิ่มรูปร่างที่มีข้อความ, กำหนดตัวระบุภาษาให้กับส่วนข้อความ, และบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับการนำเสนอและข้อความรูปร่าง**
- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) คลาส
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ของประเภท [Rectangle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ShapeType#Rectangle) ไปยังสไลด์
- เพิ่มข้อความบางส่วนลงใน TextFrame
- [ตั้งค่า Language Id](https://reference.aspose.com/slides/th/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ให้กับข้อความ
- เขียนการนำเสนอเป็นไฟล์ PPTX

การดำเนินการของขั้นตอนข้างต้นแสดงไว้ด้านล่างเป็นตัวอย่าง

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ID ภาษากระตุ้นการแปลข้อความอัตโนมัติหรือไม่?**

ไม่. [Language ID](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ใน Aspose.Slides จะเก็บภาษาสำหรับการตรวจสอบการสะกดและการพิสูจน์ไวยากรณ์, แต่ไม่ทำการแปลหรือเปลี่ยนแปลงเนื้อหาข้อความ. มันเป็นเมตาดาต้าที่ PowerPoint เข้าใจเพื่อการพิสูจน์

**ID ภาษามีผลต่อการแทรก hyphen และการตัดบรรทัดในระหว่างการแสดงผลหรือไม่?**

ใน Aspose.Slides, [language ID](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ใช้สำหรับการพิสูจน์. คุณภาพของ hyphenation และการตัดบรรทัดขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/java/powerpoint-fonts/) และการตั้งค่า layout/line‑break สำหรับระบบการเขียน. เพื่อให้การแสดงผลถูกต้อง, ให้ทำให้ฟอนต์ที่จำเป็นพร้อมใช้งาน, กำหนด [font substitution rules](/slides/th/java/font-substitution/), หรือ [embed fonts](/slides/th/java/embedded-font/) ในงานนำเสนอ

**ฉันสามารถตั้งค่าภาษาที่แตกต่างกันในย่อหน้าเดียวได้หรือไม่?**

ได้. [Language ID](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ถูกนำไปใช้ระดับส่วนข้อความ, ดังนั้นย่อหน้าเดียวจึงสามารถผสมหลายภาษาโดยมีการตั้งค่าการพิสูจน์ที่แตกต่างกันได้