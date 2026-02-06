---
title: نص رياضي
type: docs
weight: 160
url: /ar/python-net/examples/elements/math-text/
keywords:
- نص رياضي
- إضافة نص رياضي
- الوصول إلى نص رياضي
- إزالة نص رياضي
- تنسيق نص رياضي
- أمثلة على التعليمات البرمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع النص الرياضي في بايثون باستخدام Aspose.Slides: إنشاء وتعديل المعادلات، الكسور، الجذور، النصوص المكتوبة، التنسيق، وعرض النتائج لملفات PPT و PPTX."
---
يوضح العمل مع أشكال النص الرياضي وتنسيق المعادلات باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة نص رياضي**

إنشاء شكل رياضي يحتوي على كسر وصيغة فيثاغورس.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة شكل رياضي إلى الشريحة.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # الوصول إلى الفقرة الرياضية.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # إضافة كسر بسيط: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # إضافة معادلة: c² = a² + b².
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

## **الوصول إلى نص رياضي**

تحديد شكل يحتوي على فقرة رياضية في الشريحة.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # العثور على أول شكل يحتوي على فقرة رياضية.
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

## **إزالة نص رياضي**

حذف شكل رياضي من الشريحة.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو شكل يحتوي على نص رياضي.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسيق نص رياضي**

تعيين خصائص الخط لجزء رياضي.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو شكل يحتوي على نص رياضي.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```