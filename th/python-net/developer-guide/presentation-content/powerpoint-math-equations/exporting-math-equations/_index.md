---
title: ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Python
linktitle: ส่งออกสมการ
type: docs
weight: 30
url: /th/python-net/exporting-math-equations/
keywords:
- ส่งออกสมการคณิตศาสตร์
- MathML
- LaTeX
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เปิดใช้งานการส่งออกสมการคณิตศาสตร์จาก PowerPoint ไปยัง MathML อย่างราบรื่นด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—รักษาการจัดรูปแบบและเพิ่มความเข้ากันได้."
---
## **บทนำ**

Aspose.Slides for Python via .NET ช่วยให้คุณส่งออกสมการคณิตศาสตร์จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการดึงสมการจากสไลด์เฉพาะและนำไปใช้ใหม่ในโปรแกรมหรือแพลตฟอร์มอื่น

{{% alert color="primary" %}}
คุณสามารถส่งออกสมการเป็น MathML ซึ่งเป็นมาตรฐานที่ใช้กันอย่างแพร่หลายสำหรับการแทนเนื้อหาทางคณิตศาสตร์บนเว็บและในหลายแอปพลิเคชัน
{{% /alert %}}

## **บันทึกสมการคณิตศาสตร์เป็น MathML**

แม้ว่ามนุษย์จะสามารถเขียน LaTeX ได้อย่างง่ายดาย แต่โดยทั่วไป MathML จะถูกสร้างโดยอัตโนมัติโดยแอปพลิเคชันต่าง ๆ เนื่องจาก MathML เป็น XML โปรแกรมจึงสามารถอ่านและแยกวิเคราะห์ได้อย่างเชื่อถือได้ จึงเป็นรูปแบบการส่งออกและการพิมพ์ที่ใช้กันทั่วไปในหลายสาขา

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

## **FAQ**

**สิ่งที่ส่งออกเป็น MathML จริงๆ คืออะไร—ย่อหน้าหรือบล็อกสูตรแยกส่วน?**

คุณสามารถส่งออกทั้งย่อหน้าคณิตศาสตร์ทั้งหมด ([MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/)) หรือบล็อกสูตรเดียว ([MathBlock](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathblock/)) ไปเป็น MathML ทั้งสองประเภทมีวิธีการเขียนเป็น MathML

**ฉันจะบอกได้อย่างไรวัตถุบนสไลด์เป็นสูตรคณิตศาสตร์หรือเป็นข้อความหรือภาพปกติ?**

สูตรจะอยู่ใน [MathPortion](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathportion/) และมี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/). ภาพและส่วนข้อความทั่วไปที่ไม่มี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) จะไม่สามารถส่งออกเป็นสูตรได้

**MathML มาจากที่ไหนในงานนำเสนอ—เป็นของ PowerPoint เท่านั้นหรือเป็นมาตรฐาน?**

การส่งออกมุ่งเป้าไปที่ MathML มาตฐาน (XML) Aspose ใช้ Presentation MathML ซึ่งเป็นส่วนย่อยของมาตรฐานที่ใช้กันอย่างแพร่หลายในแอปพลิเคชันและเว็บ

**การส่งออกสูตรภายในตาราง, SmartArt, กลุ่ม ฯลฯ รองรับหรือไม่?**

ใช่ หากวัตถุเหล่านั้นมีส่วนข้อความที่มี [MathParagraph](https://reference.aspose.com/slides/th/python-net/aspose.slides.mathtext/mathparagraph/) (คือสูตร PowerPoint ที่แท้จริง) จะถูกส่งออก หากสูตรฝังเป็นภาพจะไม่ถูกส่งออก

**การส่งออกเป็น MathML ทำให้ไฟล์งานนำเสนอเดิมเปลี่ยนแปลงหรือไม่?**

ไม่ การเขียน MathML เป็นการทำสำเนาข้อมูลของสูตร ไม่ได้แก้ไขไฟล์งานนำเสนอ