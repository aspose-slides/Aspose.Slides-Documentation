---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Java
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint เป็น LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Java."
---
## **บทนำ**

Aspose.Slides ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="info" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ของ PowerPoint ให้เป็น LaTeX ได้โดยตรง; ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นและตัวแปลงภายนอก สมการคณิตศาสตร์จะถูกจัดเก็บในกรอบข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/). ใช้ [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/#getMathParagraph--) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathparagraph/), จากนั้นเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathparagraph/#toLatex--). เมธอดจะคืนค่าเป็นสตริงที่คุณสามารถบันทึก แสดง ส่งไปยังแอปพลิเคชันอื่น หรือดำเนินการต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบทุกกรอบข้อความบนทุกสไลด์ ค้นหาส่วนคณิตศาสตร์ทั้งหมด และเขียนแต่ละสมการลงในไฟล์ `.tex` แยกกัน:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) คืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์ การตรวจสอบชนิด [IMathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/) แยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป

เอนจิ้น LaTeX และเทมเพลตเอกสารไม่ได้รองรับคำสั่ง แพ็คเกจ หรืออักขระ Unicode เดียวกันทั้งหมด ให้ทดสอบสตริงที่คืนค่าด้วยเอนจิ้น LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการ หรือข้ามสมการและบันทึกประเด็นเพื่อตรวจสอบภายหลัง

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางรูปแบบอย่าง LaTeX ได้อย่างง่ายดาย แต่การเขียนโค้ดสำหรับ MathML นั้นทำได้ยาก เพราะ MathML ถูกออกแบบให้สร้างขึ้นโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดของมันอยู่ในรูปแบบ XML ดังนั้น MathML จึงเป็นที่นิยมใช้เป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายสาขา

โค้ดตัวอย่างนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**จริง ๆ แล้วสิ่งที่ส่งออกเป็น MathML คือ ย่อหน้า หรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดที่จะเขียนเป็น MathML

**ฉันจะทราบได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือรูปภาพปกติ?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/). รูปภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำมาจากไหน—เป็นของ PowerPoint เฉพาะหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเน้นที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้ในการนำเสนอ ซึ่งเป็นที่ใช้อย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม, เป็นต้น รองรับหรือไม่?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) (คือสูตร PowerPoint ที่แท้จริง) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำให้ข้อมูลสูตรเป็นรูปแบบซีเรียลไลซ์ ไม่ได้ทำการแก้ไขไฟล์งานนำเสนอ