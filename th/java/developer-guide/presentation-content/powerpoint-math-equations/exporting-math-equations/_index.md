---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Java
linktitle: ส่งออกสูตร
type: docs
weight: 30
url: /th/java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML อย่างราบรื่นด้วย Aspose.Slides สำหรับ Java—รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) แล้วนำไปใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่นิยมสำหรับสมการคณิตศาสตร์และเนื้อหาแบบคล้ายกันที่พบบนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้อย่างง่ายดาย แต่ก็มีความยากลำบากในการเขียนโค้ดสำหรับ MathML เนื่องจากรูปแบบนี้ออกแบบมาให้แอปพลิเคชันสร้างโดยอัตโนมัติ โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากโค้ดของมันอยู่ในรูปแบบ XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้ทั่วไปในหลายสาขา

โค้ดตัวอย่างนี้แสดงให้คุณเห็นวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:
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

**สิ่งที่ส่งออกเป็น MathML คืออะไร—ย่อหน้าหรือบล็อกสูตรแต่ละอัน?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดที่ให้เขียนเป็น MathML

**ฉันจะทราบได้อย่างไรวัตถุในสไลด์เป็นสูตรคณิตศาสตร์หรือเป็นข้อความหรือรูปภาพธรรมดา?**  
สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) รูปภาพและส่วนข้อความธรรมดาที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำเสนอมาจากไหน—เป็นของ PowerPoint เท่านั้นหรือเป็นมาตรฐาน?**  
การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้ในการนำเสนอ ซึ่งเป็นที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**สนับสนุนการส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม เป็นต้นหรือไม่?**  
ใช่ หากวัตถุเหล่านั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) (คือสูตร PowerPoint ที่แท้จริง) จะถูกส่งออก ถ้าสูตรถูกฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**  
ไม่ การเขียน MathML เป็นการทำให้ข้อมูลสูตรเป็นรูปแบบซีเรียลไลซ์เท่านั้น ไม่ได้ทำให้ไฟล์งานนำเปลี่ยนแปลง