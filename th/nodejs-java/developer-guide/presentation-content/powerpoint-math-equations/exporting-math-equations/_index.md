---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน JavaScript
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/nodejs-java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint ไปยัง LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **บทนำ**

Aspose.Slides ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์จากสไลด์ (จากงานนำเสนอเฉพาะ) แล้วใช้งานในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}} 
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่ได้รับความนิยมสำหรับเนื้อหาคณิตศาสตร์บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ของ PowerPoint เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องใช้ไฟล์ MathML ระหว่างขั้นตอนหรือโปรแกรมแปลงภายนอก สมการคณิตศาสตร์จะถูกจัดเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathportion/). ใช้ [MathPortion.getMathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) เพื่อรับ [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/), จากนั้นเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/#toLatex--) วิธีนี้จะคืนสตริงที่คุณสามารถบันทึก, แสดง, ส่งไปยังแอปพลิเคชันอื่น หรือประมวลผลต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบทุกกรอบข้อความบนทุกสไลด์, ค้นหาส่วนคณิตศาสตร์ทั้งหมด, และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกไฟล์

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) คืนค่ากรอบข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบชนิด [MathPortion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathportion/) ช่วยแยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและภาพทั่วไป

เครื่องมือ LaTeX และเทมเพลตเอกสารไม่ได้สนับสนุนคำสั่ง, แพ็คเกจ หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่ได้กับเครื่องมือ LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแทนที่ที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่ได้ด้วยคำสั่งเฉพาะโปรเจกต์หรือข้ามสมการและบันทึกประเด็นเพื่อตรวจสอบต่อไป

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างเช่น LaTeX ได้อย่างง่ายดาย แต่การเขียนโค้ดสำหรับ MathML กลับเป็นเรื่องยาก เพราะ MathML มีจุดประสงค์ให้สร้างโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมต่าง ๆ สามารถอ่านและวิเคราะห์ MathML ได้ง่าย เนื่องจากโค้ดของมันอยู่ในรูปแบบ XML ทำให้ MathML ถูกใช้เป็นรูปแบบการส่งออกและการพิมพ์ทั่วไปในหลายสาขา

ตัวอย่างโค้ดนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML

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

**จริง ๆ แล้วสิ่งที่ส่งออกเป็น MathML คือ ย่อหน้าหรือบล็อกสูตรแยกส่วน?**  
คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ทำอย่างไรจึงจะรู้ว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ ไม่ใช่ข้อความหรือภาพทั่วไป?**  
สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/). ภาพและข้อความปกติที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML ที่ได้จากงานนำเสนอมาจากไหน—เป็นของ PowerPoint โดยเฉพาะหรือเป็นมาตรฐาน?**  
การส่งออกมุ่งไปที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้กันอย่างแพร่หลายในแอปพลิเคชันและเว็บ

**การส่งออกสูตรจากตาราง, SmartArt, กลุ่มและอื่น ๆ รองรับหรือไม่?**  
รองรับ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mathparagraph/) (คือสูตร PowerPoint ของจริง) จะถูกส่งออก หากสูตรถูกฝังเป็นภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**  
ไม่ การเขียน MathML คือการทำซีเรียลไลเซชันของเนื้อหาสูตร ไม่ได้แก้ไขไฟล์งานนำเสนอต้นฉบับ