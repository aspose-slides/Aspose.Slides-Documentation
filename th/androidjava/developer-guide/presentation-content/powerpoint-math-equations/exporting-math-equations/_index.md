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
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปเป็น LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **Introduction**

Aspose.Slides for Android via Java ช่วยให้คุณสามารถส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการแยกสมการคณิตศาสตร์บนสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint ให้เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องใช้ไฟล์ MathML ระดับกลางหรือเครื่องแปลงภายนอก สมการคณิตศาสตร์จะถูกเก็บไว้ในกรอบข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/). ใช้ [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathparagraph/), จากนั้นเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathparagraph/#toLatex--). วิธีนี้จะคืนสตริงที่คุณสามารถบันทึก แสดง ส่งไปยังแอปพลิเคชันอื่น หรือดำเนินการต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบทุกกรอบข้อความในแต่ละสไลด์ ค้นหาส่วนของสมการทั้งหมด และเขียนแต่ละสมการลงในไฟล์ `.tex` แยกกัน:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) คืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์ การตรวจสอบประเภท [IMathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imathportion/) แยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและภาพทั่วไป

เครื่องยนต์ LaTeX และเทมเพลตเอกสารไม่ได้รองรับคำสั่ง แพ็กเกจ หรืออักขระ Unicode เหมือนกันทั้งหมด ให้ทดสอบสตริงที่คืนค่ากับเครื่องยนต์ LaTeX ที่ใช้ในแอปพลิเคชันของคุณ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการนั้นและบันทึกปัญหาเพื่อตรวจสอบต่อไป

## **Save Math Equations as MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางแบบเช่น LaTeX ได้ง่าย แต่การเขียนโค้ดสำหรับ MathML จะยากกว่าเพราะ MathML ถูกออกแบบให้สร้างโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมจึงอ่านและวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดอยู่ในรูป XML ทำให้ MathML ถูกใช้เป็นรูปแบบผลลัพธ์และการพิมพ์ในหลายวงการอย่างแพร่หลาย

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

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

## **FAQ**

**สิ่งที่ส่งออกเป็น MathML จริง ๆ คือพารากรกหรือบล็อกสูตรเดี่ยว?**

คุณสามารถส่งออกได้ทั้งพารากรของสมการทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**จะบอกได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความหรือรูปภาพธรรมดา?**

สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/). รูปภาพและข้อความปกติที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ที่ได้จากงานนำเสนอมาจากไหน—เป็นของ PowerPoint เองหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเป้าไปที่ MathML มาตฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/mathparagraph/) (คือสูตร PowerPoint ของแท้) จะถูกส่งออก หากสูตรถูกฝังเป็นรูปภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำซีเรียลไลเซชันของเนื้อหาสูตรเท่านั้น ไม่ได้แก้ไขไฟล์งานนำเสนอต้นฉบับ