---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอบน Android
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/androidjava/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML ด้วย Aspose.Slides สำหรับ Android ผ่าน Java อย่างไร้รอยต่อ—คงรูปร่างและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides for Android via Java ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) แล้วนำไปใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่ได้รับความนิยมสำหรับสมการคณิตศาสตร์และเนื้อหาในลักษณะเดียวกันที่พบบนเว็บและในหลายแอปพลิเคชัน 
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างได้ง่าย เช่น LaTeX แต่การเขียนโค้ดสำหรับ MathML กลับเป็นเรื่องที่ท้าทาย เพราะ MathML ถูกออกแบบให้สร้างโดยอัตโนมัติจากแอปพลิเคชัน โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดเป็น XML ดังนั้น MathML จึงมักถูกใช้เป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายสาขา

ตัวอย่างโค้ดนี้แสดงให้คุณเห็นวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**สิ่งที่ส่งออกเป็น MathML จริง ๆ คือ ย่อหน้าหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกได้ทั้งย่อหน้าทางคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathblock/)) เป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ทำอย่างไรจึงบอกได้ว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) ส่วนรูปภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML มาจากที่ไหนในงานนำเสนอ—เป็นของ PowerPoint อย่างเฉพาะเจาะจงหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเน้นไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้ในการนำเสนอ ซึ่งเป็นที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม, ฯลฯ รองรับหรือไม่?**

รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) (คือสูตร PowerPoint ที่แท้จริง) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพ จะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำสำเนาข้อมูลสูตรในรูปแบบการจัดลำดับใหม่ ไม่ได้แก้ไขไฟล์งานนำเสนอต้นฉบับ