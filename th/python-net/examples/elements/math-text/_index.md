---
title: ข้อความคณิตศาสตร์
type: docs
weight: 160
url: /th/python-net/examples/elements/math-text/
keywords:
- ข้อความคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- เข้าถึงข้อความคณิตศาสตร์
- ลบข้อความคณิตศาสตร์
- จัดรูปแบบข้อความคณิตศาสตร์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำงานกับข้อความคณิตศาสตร์ใน Python ด้วย Aspose.Slides: สร้างและแก้ไขสมการ, เศษส่วน, ราก, สคริปต์, การจัดรูปแบบ, และเรนเดอร์ผลลัพธ์สำหรับ PPT และ PPTX."
---
อธิบายการทำงานกับรูปร่างข้อความคณิตศาสตร์และการจัดรูปแบบสมการโดยใช้ **Aspose.Slides for Python via .NET**.

## **Add Math Text**

สร้างรูปร่างคณิตศาสตร์ที่ประกอบด้วยเศษส่วนและสูตรพีทาโกรัส.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มรูปร่าง Math ลงบนสไลด์.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # เข้าถึงย่อหน้าคณิตศาสตร์.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # เพิ่มเศษส่วนง่าย: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # เพิ่มสมการ: c² = a² + b².
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Access Math Text**

ค้นหารูปร่างที่มีย่อหน้าคณิตศาสตร์บนสไลด์.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # หารูปร่างแรกที่มีย่อหน้าคณิตศาสตร์.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **Remove Math Text**

ลบรูปร่างคณิตศาสตร์ออกจากสไลด์.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นรูปร่างที่มีข้อความคณิตศาสตร์.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Math Text**

ตั้งค่าลักษณะตัวอักษรสำหรับส่วนของคณิตศาสตร์.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่ารูปร่างแรกเป็นรูปร่างที่มีข้อความคณิตศาสตร์.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```