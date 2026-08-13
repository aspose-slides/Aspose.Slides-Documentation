---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอบน Android
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/androidjava/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint เป็น LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint เป็น LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

Aspose.Slides for Android via Java ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="info" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานยอดนิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ของ PowerPoint เป็น LaTeX ได้โดยตรง; ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นและตัวแปลงภายนอก สมการคณิตศาสตร์จะถูกจัดเก็บในกรอบข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/). ใช้ [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathparagraph/), แล้วเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathparagraph/#toLatex--) วิธีนี้จะคืนค่าเป็นสตริงที่คุณสามารถบันทึก, แสดง, ส่งให้แอปอื่น หรือดำเนินการต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบกรอบข้อความทุกกรอบบนทุกสไลด์, ค้นหาส่วนคณิตศาสตร์ทั้งหมด, แล้วเขียนสมการแต่ละอันลงไฟล์ `.tex` แยกกัน:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) คืนค่ากรอบข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบชนิด [IMathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/) แยกสมการที่แก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป

เอนจิน LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุนคำสั่ง, แพ็กเกจ หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่คืนค่ากับเอนจิน LaTeX ที่แอปของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการนั้นและบันทึกปัญหาเพื่อตรวจสอบภายหลัง

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างเช่น LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML นั้นยาก because MathML ถูกออกแบบให้สร้างโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมต่าง ๆ สามารถอ่านและแยกวิเคราะห์ MathML ได้อย่างง่ายดายเนื่องจากโค้ดของมันอยู่ในรูป XML ดังนั้น MathML จึงมักถูกใช้เป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

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

**What exactly is exported to MathML—a paragraph or an individual formula block?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathblock/)) ไปยัง MathML ทั้งสองชนิดมีเมธอดสำหรับเขียนเป็น MathML

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**  
สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/). ส่วนที่เป็นรูปภาพหรือข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**  
การส่งออกมุ่งหมายที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML—ส่วนย่อยของมาตรฐานที่มุ่งเน้นการแสดงผล ซึ่งเป็นที่นิยมใช้ในแอปพลิเคชันและบนเว็บหลายแห่ง

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**  
สนับสนุน หากวัตถุเหล่านั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) (เช่นสูตร PowerPoint จริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพจะไม่ถูกส่งออก

**Does exporting to MathML modify the original presentation?**  
ไม่ การเขียน MathML เป็นการทำสำเนาเนื้อหาสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอเดิม