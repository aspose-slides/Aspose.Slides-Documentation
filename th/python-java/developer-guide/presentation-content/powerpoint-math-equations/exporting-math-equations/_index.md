---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/python-java/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint ไปยัง LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **Introduction**

Aspose.Slides ให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการคณิตศาสตร์ในสไลด์ (จากงานนำเสนอเฉพาะ) และใช้ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="info" title="Note" %}} 
คุณสามารถส่งออกสมการได้โดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides สามารถแปลงสมการ PowerPoint เป็น LaTeX ได้โดยตรง; ไม่จำเป็นต้องใช้ไฟล์ MathML ขั้นกลางหรือตัวแปลงภายนอก สมการคณิตศาสตร์จะถูกเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathportion/). ใช้ [MathPortion.getMathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathportion/#getMathParagraph) เพื่อรับ [MathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/), แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/#toLatex). วิธีนี้จะคืนสtringที่คุณสามารถบันทึก, แสดง, ส่งไปยังแอปพลิเคชันอื่น, หรือทำการประมวลผลต่อได้

ตัวอย่างต่อไปนี้ตรวจสอบกรอบข้อความทุกกรอบในทุกสไลด์, พบส่วน Math ทั้งหมด, และเขียนแต่ละสมการลงไฟล์ `.tex` แยกกัน:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#getAllTextBoxes) จะคืนค่ากรอบข้อความทั้งหมดที่พบในสไลด์ การตรวจสอบชนิด [MathPortion](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathportion/) จะคัดแยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและรูปภาพธรรมดา

เครื่องมือแปลง LaTeX และแม่แบบเอกสารไม่สนับสนุนคำสั่ง, แพ็คเกจ หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่คืนค่ากับเอนจิน LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแสดงผลที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการหรือข้ามสมการนั้นและบันทึกปัญหาเพื่อการตรวจสอบ

## **Save Math Equations as MathML**

แม้คนจะเขียนโค้ดสำหรับรูปแบบสมการบางอย่างได้ง่าย เช่น LaTeX, MathML ยากต่อการเขียนด้วยมือเพราะออกแบบให้สร้างโดยอัตโนมัติโดยแอปพลิเคชัน โปรแกรมสามารถอ่านและแยกวิเคราะห์ MathML ได้ง่ายเนื่องจากเป็น XML จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันอย่างแพร่หลายในหลายสาขา

โค้ดตัวอย่างนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/)) หรือบล็อกเดี่ยว ([MathBlock](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathblock/)) เป็น MathML ทั้งสองชนิดให้วิธีการเขียนเป็น MathML

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/). ภาพและส่วนข้อความปกติที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

การส่งออกเป้าหมายเป็น MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML—ส่วนย่อยของมาตรฐานที่ใช้กันอย่างกว้างขวางในแอปพลิเคชันและเว็บ

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/mathparagraph/) (คือสูตร PowerPoint ของแท้) จะถูกส่งออก หากสูตรเป็นรูปภาพฝังอยู่ จะไม่ถูกส่งออก

**Does exporting to MathML modify the original presentation?**

ไม่ การเขียน MathML เป็นการซีเรียลไลซ์เนื้อหาสูตร ไม่ได้แก้ไขไฟล์งานนำเสนอเดิม