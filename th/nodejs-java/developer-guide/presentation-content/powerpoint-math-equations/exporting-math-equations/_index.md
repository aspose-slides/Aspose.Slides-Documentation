---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน JavaScript
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/nodejs-java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML อย่างราบรื่นด้วย JavaScript และ Aspose.Slides สำหรับ Node.js — รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides ช่วยให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการสกัดสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) แล้วนำไปใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นรูปแบบหรือมาตรฐานที่เป็นที่นิยมสำหรับสมการคณิตศาสตร์และเนื้อหาในรูปแบบคล้ายกันที่พบบนเว็บและในหลายแอปพลิเคชัน 
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างอย่าง LaTeX ได้ง่าย แต่มันยากที่จะเขียนโค้ดสำหรับ MathML เนื่องจาก MathML ถูกออกแบบให้สร้างโดยแอปพลิเคชันโดยอัตโนมัติ โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากโค้ดของมันอยู่ใน XML ดังนั้น MathML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้ทั่วไปในหลายสาขา

โค้ดตัวอย่างนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**What exactly is exported to MathML—a paragraph or an individual formula block?**  
คุณสามารถส่งออกได้ทั้ง **MathParagraph** ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/)) หรือบล็อกสูตรเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**  
สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/) ภาพและข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**  
การส่งออกมุ่งเป้าไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML—ส่วนย่อยของมาตรฐานที่ใช้สำหรับการนำเสนอ—ซึ่งเป็นที่ใช้กันอย่างแพร่หลายทั้งในแอปพลิเคชันและบนเว็บ

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**  
ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/) (คือสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพจะไม่ถูกส่งออก

**Does exporting to MathML modify the original presentation?**  
ไม่ การเขียน MathML เป็นการทำซีเรียลไลเซชันของเนื้อหาสูตรเท่านั้น ไม่ได้ทำการแก้ไขไฟล์งานนำเสนอต้นฉบับ