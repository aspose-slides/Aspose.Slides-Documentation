---
title: แปลงงานนำเสนอ PowerPoint เป็นเอกสาร Word ใน Java
linktitle: PowerPoint เป็น Word
type: docs
weight: 110
url: /th/java/convert-powerpoint-to-word/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น Word
- งานนำเสนอเป็น Word
- สไลด์เป็น Word
- PPT เป็น Word
- PPTX เป็น Word
- PowerPoint เป็น DOCX
- งานนำเสนอเป็น DOCX
- สไลด์เป็น DOCX
- PPT เป็น DOCX
- PPTX เป็น DOCX
- PowerPoint เป็น DOC
- งานนำเสนอเป็น DOC
- สไลด์เป็น DOC
- PPT เป็น DOC
- PPTX เป็น DOC
- บันทึก PPT เป็น DOCX
- บันทึก PPTX เป็น DOCX
- ส่งออก PPT เป็น DOCX
- ส่งออก PPTX เป็น DOCX
- Java
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint PPT และ PPTX ให้เป็นเอกสาร Word ที่สามารถแก้ไขได้ใน Java ด้วย Aspose.Slides พร้อมคงรูปแบบ การจัดวาง ภาพและการจัดรูปแบบอย่างแม่นยำ"
---
## **ภาพรวม**

บทความนี้นำเสนอวิธีแก้ปัญหาให้กับนักพัฒนาในการแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word โดยใช้ Aspose.Slides และ Aspose.Words คู่มือแบบขั้นตอนต่อขั้นตอนจะพาคุณผ่านทุกขั้นตอนของกระบวนการแปลง

## **แปลง PowerPoint เป็น Word**

ทำตามขั้นตอนต่อไปนี้เพื่อแปลงงานนำเสนอ PowerPoint หรือ OpenDocument เป็นเอกสาร Word:

1. ดาวน์โหลดไลบรารี [Aspose.Slides for Java](https://downloads.aspose.com/slides/th/java) และ [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. เพิ่ม *aspose-slides-x.x-jdk16.jar* และ *aspose-words-x.x-jdk16.jar* ไปยัง CLASSPATH ของคุณ.
3. ใช้ส่วนของโค้ดนี้เพื่อแปลง PowerPoint เป็น Word:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // สร้างภาพสไลด์เป็นสตรีมไบต์อาร์เรย์
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

คุณเพียงแค่ต้องเพิ่มแพ็กเกจที่เกี่ยวข้องสำหรับ [Aspose.Slides for Java](https://releases.aspose.com/slides/th/java/) และ [Aspose.Words for Java](https://releases.aspose.com/words/java/) ลงในโครงการของคุณ ทั้งสองไลบรารีทำงานเป็น API แบบสแตนด์อโลนและไม่จำเป็นต้องติดตั้ง Microsoft Office.

**รองรับรูปแบบไฟล์งานนำเสนอ PowerPoint และ OpenDocument ทั้งหมดหรือไม่?**

Aspose.Slides [รองรับรูปแบบไฟล์งานนำเสนอทั้งหมด](/slides/th/java/supported-file-formats/), รวมถึง PPT, PPTX, ODP และประเภทไฟล์ทั่วไปอื่นๆ ซึ่งทำให้คุณสามารถทำงานกับงานนำเสนอที่สร้างในรุ่นต่างๆ ของ Microsoft PowerPoint ได้.