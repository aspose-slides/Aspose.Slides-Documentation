---
title: ทำให้การแปลภาษาในงานนำเสนอบน Android เป็นอัตโนมัติ
linktitle: การแปลภาษาในงานนำเสนอ
type: docs
weight: 100
url: /th/androidjava/presentation-localization/
keywords:
- เปลี่ยนภาษา
- ตรวจสอบการสะกด
- รหัสภาษา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำให้การแปลภาษาสไลด์ PowerPoint และ OpenDocument ใน Java ด้วย Aspose.Slides สำหรับ Android เป็นอัตโนมัติ ด้วยตัวอย่างโค้ดและเคล็ดลับที่เป็นประโยชน์เพื่อการเปิดตัวทั่วโลกที่เร็วขึ้น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีตั้งค่า `LanguageId` สำหรับข้อความในงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีเปิดงานนำเสนอ เพิ่มรูปร่างที่มีข้อความ กำหนดตัวระบุภาษาให้กับส่วนข้อความ แล้วบันทึกผลลัพธ์เป็นไฟล์ PPTX

## **เปลี่ยนภาษาสำหรับงานนำเสนอและข้อความในรูปร่าง**
- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) .
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ของประเภท [Rectangle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ShapeType#Rectangle) ไปยังสไลด์.
- เพิ่มข้อความบางส่วนลงใน TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) ให้กับข้อความ.
- เขียนงานนำเสนอเป็นไฟล์ PPTX.

การทำงานของขั้นตอนข้างต้นแสดงด้านล่างในตัวอย่าง.

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

**ID ภาษาทำให้เกิดการแปลข้อความอัตโนมัติหรือไม่?**

ไม่. [Language ID](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ใน Aspose.Slides เก็บข้อมูลภาษาสำหรับการตรวจสอบการสะกดและการพิสูจน์ไวยากรณ์ แต่ไม่ได้แปลหรือเปลี่ยนเนื้อความของข้อความ มันเป็นเมตาดาต้าที่ PowerPoint เข้าใจเพื่อการพิสูจน์

**ID ภาษามีผลต่อการใส่ hyphen และการตัดบรรทัดระหว่างการแสดงผลหรือไม่?**

ใน Aspose.Slides, [language ID](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ใช้สำหรับการพิสูจน์คุณภาพ การใส่ hyphen และการตัดบรรทัดส่วนใหญ่ขึ้นอยู่กับการมีอยู่ของ [proper fonts](/slides/th/androidjava/powerpoint-fonts/) และการตั้งค่า layout/line‑break สำหรับระบบเขียนข้อความ เพื่อให้การแสดงผลถูกต้อง ให้ทำให้ฟอนต์ที่จำเป็นพร้อมใช้งาน ตั้งค่า [font substitution rules](/slides/th/androidjava/font-substitution/) และ/หรือ [embed fonts](/slides/th/androidjava/embedded-font/) ลงในงานนำเสนอ

**ฉันสามารถตั้งค่าหลายภาษาในย่อหน้าเดียวได้หรือไม่?**

ได้. [Language ID](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) จะถูกนำไปใช้ระดับส่วนของข้อความ ดังนั้นย่อหน้าเดียวสามารถผสมหลายภาษาโดยมีการตั้งค่าการพิสูจน์ที่แตกต่างกัน