---
title: แปลงงานนำเสนอ PowerPoint เป็นเอกสาร Word บน Android
linktitle: PowerPoint เป็น Word
type: docs
weight: 110
url: /th/androidjava/convert-powerpoint-to-word/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น Word
- การนำเสนอเป็น Word
- สไลด์เป็น Word
- PPT เป็น Word
- PPTXเป็น Word
- PowerPoint เป็น DOCX
- การนำเสนอเป็น DOCX
- สไลด์เป็น DOCX
- PPT เป็น DOCX
- PPTX เป็น DOCX
- PowerPoint เป็น DOC
- การนำเสนอเป็น DOC
- สไลด์เป็น DOC
- PPT เป็น DOC
- PPTX เป็น DOC
- บันทึก PPT เป็น DOCX
- บันทึก PPTX เป็น DOCX
- ส่งออก PPT เป็น DOCX
- ส่งออก PPTX เป็น DOCX
- Android
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint PPT และ PPTX ให้เป็นเอกสาร Word ที่แก้ไขได้ใน Java โดยใช้ Aspose.Slides for Android พร้อมรักษาการจัดเรียง รูปภาพและการจัดรูปแบบให้แม่นยำ"
---
## **ภาพรวม**

บทความนี้ให้วิธีแก้ปัญหาแก่ผู้พัฒนาสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word โดยใช้ Aspose.Slides และ Aspose.Words. คู่มือแบบขั้นตอนช่วยคุณผ่านทุกขั้นตอนของกระบวนการแปลง

## **Aspose.Slides และ Aspose.Words**

เพื่อแปลงไฟล์ PowerPoint (PPTX หรือ PPT) เป็น Word (DOCX หรือ DOCX) คุณต้องมีทั้ง [Aspose.Slides for Android via Java](https://products.aspose.com/slides/th/androidjava/)และ[Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/)

ในฐานะ API ที่ใช้แยกอิสระ, [Aspose.Slides](https://products.aspose.app/slides) for java มีฟังก์ชันที่ช่วยให้คุณดึงข้อความจากการนำเสนอ

[Aspose.Words](https://docs.aspose.com/words/androidjava/) คือ API การประมวลผลเอกสารขั้นสูงที่ช่วยให้แอปพลิเคชันสร้าง, แก้ไข, แปลง, เรนเดอร์, พิมพ์ไฟล์ และทำงานอื่น ๆ กับเอกสารโดยไม่ต้องใช้ Microsoft Word.

## **แปลง PowerPoint เป็น Word**

1. ดาวน์โหลดไลบรารี [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/th/java) และ [Aspose.Words for Java](https://downloads.aspose.com/words/java)
2. เพิ่ม *aspose-slides-x.x-jdk16.jar* และ *aspose-words-x.x-jdk16.jar* ไปยัง CLASSPATH ของคุณ
3. ใช้โค้ดสแนปนี้เพื่อแปลง PowerPoint เป็น Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // สร้างภาพสไลด์เป็นสตรีมอาร์เรย์ของไบต์
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // แทรกข้อความของสไลด์
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **คำถามที่พบบ่อย**

**ส่วนประกอบใดที่ต้องติดตั้งเพื่อแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word?**

คุณเพียงแค่ต้องเพิ่มแพคเกจที่เกี่ยวข้องสำหรับ [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/th/androidjava/)และ[Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) ไปยังโปรเจกต์ของคุณ ทั้งสองไลบรารีทำงานเป็น API แยกอิสระและไม่จำเป็นต้องติดตั้ง Microsoft Office.

**รองรับรูปแบบงานนำเสนอ PowerPoint และ OpenDocument ทั้งหมดหรือไม่?**

Aspose.Slides [supports all presentation formats](/slides/th/androidjava/supported-file-formats/), รวมถึง PPT, PPTX, ODP และประเภทไฟล์ทั่วไปอื่น ๆ สิ่งนี้ทำให้คุณสามารถทำงานกับงานนำเสนอที่สร้างในเวอร์ชันต่าง ๆ ของ Microsoft PowerPoint.