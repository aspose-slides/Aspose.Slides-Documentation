---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอด้วย Python
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/python-net/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- ส่งออกสมการเป็น LaTeX
- PowerPoint ไปยัง LaTeX
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ส่งออกสมการคณิตศาสตร์จากงานนำเสนอ PowerPoint ไปยัง LaTeX หรือ MathML โดยตรงด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **บทนำ**

Aspose.Slides for Python via .NET ช่วยให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอได้ ตัวอย่างเช่น คุณอาจต้องการดึงสมการจากสไลด์ที่เฉพาะเจาะจงและใช้ซ้ำในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}}
คุณสามารถส่งออกสมการโดยตรงเป็น LaTeX หรือ MathML ซึ่งเป็นมาตรฐานที่นิยมสำหรับเนื้อหาคณิตศาสตร์ที่ใช้บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **ส่งออกสมการคณิตศาสตร์เป็น LaTeX**

Aspose.Slides สามารถแปลงสมการคณิตศาสตร์ใน PowerPoint ให้เป็น LaTeX ได้โดยตรง ไม่จำเป็นต้องมีไฟล์ MathML ระหว่างทางหรือโปรแกรมแปลงภายนอก สมการคณิตศาสตร์จะถูกเก็บในกรอบข้อความเป็น [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/)。ใช้ [MathPortion.math_paragraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) เพื่อรับ [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/)，แล้วเรียก [MathParagraph.to_latex](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/to_latex/)。เมธอดนี้จะคืนสตริงที่คุณสามารถบันทึก, แสดง, ส่งให้แอปพลิเคชันอื่น, หรือประมวลผลต่อได้

ตัวอย่างต่อไปนี้จะตรวจสอบกรอบข้อความทั้งหมดในแต่ละสไลด์, ค้นหาส่วนคณิตศาสตร์ทั้งหมด, และเขียนสมการแต่ละอันลงในไฟล์ `.tex` แยกกัน:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) คืนค่ากรอบข้อความทั้งหมดที่พบบนสไลด์ การตรวจสอบประเภท [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/) จะแยกสมการที่สามารถแก้ไขได้จริงออกจากข้อความและรูปภาพทั่วไป

เอนจิ้น LaTeX และเทมเพลตเอกสารไม่ได้รองรับคำสั่ง, แพคเกจ หรืออักขระ Unicode ทั้งหมดเดียวกัน ทดสอบสตริงที่คืนค่าด้วยเอนจิ้น LaTeX ที่แอปพลิเคชันของคุณใช้ หากสัญลักษณ์หรือองค์ประกอบ Office Math ไม่มีการแทนที่ที่เหมาะสมในสภาพแวดล้อมนั้น ให้แทนที่ในสตริงที่คืนค่าด้วยคำสั่งเฉพาะโครงการ หรือข้ามสมการนั้นและบันทึกประเด็นเพื่อตรวจสอบต่อไป

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะเขียน LaTeX ได้ง่าย, MathML มักถูกสร้างโดยอัตโนมัติโดยแอปพลิเคชัน เนื่องจาก MathML เป็น XML ทำให้โปรแกรมสามารถอ่านและแยกวิเคราะห์ได้อย่างเชื่อถือได้ จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันทั่วไปในหลายสาขา

โค้ดตัวอย่างต่อไปนี้แสดงวิธีส่งออกสมการคณิตศาสตร์จากงานนำเสนอเป็น MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **คำถามที่พบบ่อย**

**อะไรที่ส่งออกเป็น MathML—ย่อหน้าหรือบล็อกสูตรแบบแยกส่วน?**

คุณสามารถส่งออกได้ทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรแยกส่วน ([MathBlock](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีเมธอดสำหรับเขียนเป็น MathML

**ฉันจะทราบได้อย่างไรว่าวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์ไม่ใช่ข้อความหรือรูปภาพทั่วไป?**

สูตรอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) รูปภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) ไม่สามารถส่งออกเป็นสูตรได้

**MathML ในงานนำมาจากไหน—เป็นฟีเจอร์เฉพาะของ PowerPoint หรือเป็นมาตรฐาน?**

การส่งออกมุ่งหมายที่ MathML มาตรฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่มุ่งเน้นการแสดงผล ซึ่งถูกใช้กันอย่างกว้างขวางในแอปพลิเคชันและเว็บ

**การส่งออกสูตรที่อยู่ในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

ใช่ หากวัตถุนั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) (เช่นสูตร PowerPoint ที่แท้จริง) จะถูกส่งออก หากสูตรนั้นฝังเป็นรูปภาพ จะไม่ได้รับการส่งออก

**การส่งออกเป็น MathML จะทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการจัดเรียงข้อมูลของสูตรอย่างเป็นลำดับ ไม่ได้ทำการแก้ไขไฟล์งานนำเสนอ