---
title: ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน Java
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint ไปยัง LaTeX
- MathML
- LaTeX
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากการนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Java."
---
## **คำนำ**

Aspose.Slides ให้คุณส่งออกสมการคณิตศาสตร์จากการนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์บนสไลด์ (จากการนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานยอดนิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint โดยตรงเป็น LaTeX ได้ ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นตอนหรือเครื่องแปลงภายนอก สมการคณิตศาสตร์จะถูกจัดเก็บในเฟรมข้อความเป็น [IMathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/). ใช้ [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/#getMathParagraph--) เพื่อรับ [IMathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathparagraph/), แล้วเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathparagraph/#toLatex--). วิธีนี้จะคืนสตรีングที่คุณสามารถบันทึก, แสดง, ส่งไปยังแอปพลิเคชันอื่น, หรือประมวลผลต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบทุกเฟรมข้อความบนแต่ละสไลด์, หา math portion ทั้งหมด, และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกกัน:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) คืนค่าเฟรมข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบประเภท [IMathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/imathportion/) แยกสมการที่สามารถแก้ไขได้จริงจากข้อความและรูปภาพทั่วไป

เอนจิน LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุคำสั่ง, แพ็กเกจ หรืออักขระ Unicode เดียวกันทั้งหมด ทดสอบสตรี่งที่ได้กับเอนจิน LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแทนที่ที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตรี่งที่ได้ด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการและบันทึกปัญหาเพื่อการตรวจสอบ

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางแบบอย่าง LaTeX ได้อย่างง่ายดาย แต่การเขียนโค้ดสำหรับ MathML ยากกว่า เนื่องจาก MathML ถูกออกแบบให้สร้างโดยอัตโนมัติจากแอปพลิเคชัน โปรแกรมจึงอ่านและวิเคราะห์ MathML ได้ง่าย เพราะโค้ดเป็น XML ทำให้ MathML เป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้ทั่วไปในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากการนำเสนอเป็น MathML:

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

**สิ่งที่ส่งออกเป็น MathML คืออะไร — ย่อหน้าหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกได้ ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathblock/)) เป็น MathML ทั้งสองประเภทมีวิธีเขียนเป็น MathML

**ฉันจะทราบได้อย่างไรวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/). รูปภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในการนำเสนอมาจากไหน — เป็นของ PowerPoint โดยเฉพาะหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเน้นที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML — ส่วนย่อยการนำเสนอของมาตรฐาน ซึ่งถูกใช้อย่างกว้างขวางในแอปพลิเคชันและบนเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/mathparagraph/) (เช่นสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรฝังเป็นรูปภาพ จะไม่ถูกส่งออก

**การส่งออกเป็น MathML มีผลต่อการนำเสนอเดิมหรือไม่?**

ไม่ การเขียน MathML เป็นการทำซีเรียลไลซ์ของเนื้อหาสูตร; ไม่ทำการแก้ไขไฟล์การนำเสนอ