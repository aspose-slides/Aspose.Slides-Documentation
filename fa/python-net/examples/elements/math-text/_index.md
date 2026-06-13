---
title: متن ریاضی
type: docs
weight: 160
url: /fa/python-net/examples/elements/math-text/
keywords:
- متن ریاضی
- افزودن متن ریاضی
- دسترسی به متن ریاضی
- حذف متن ریاضی
- قالب‌بندی متن ریاضی
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کار با متن ریاضی در Python با استفاده از Aspose.Slides: ایجاد و ویرایش معادلات، کسرها، رادیکال‌ها، اسکریپت‌ها، قالب‌بندی، و رندر نتایج برای PPT و PPTX."
---
کار با اشکال متن ریاضی و قالب‌بندی معادلات را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن متن ریاضی**

یک شکل ریاضی شامل یک کسر و فرمول فیثاغورث ایجاد کنید.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # افزودن یک شکل ریاضی به اسلاید.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # دسترسی به پاراگراف ریاضی.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # افزودن یک کسر ساده: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # افزودن معادله: c² = a² + b².
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

## **دسترسی به متن ریاضی**

یک شکل که شامل یک پاراگراف ریاضی در اسلاید است را پیدا کنید.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # پیدا کردن اولین شکل که شامل پاراگراف ریاضی است.
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

## **حذف متن ریاضی**

یک شکل ریاضی را از اسلاید حذف کنید.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل، شکلی با متن ریاضی است.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **قالب‌بندی متن ریاضی**

ویژگی‌های قلم را برای یک بخش ریاضی تنظیم کنید.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض بر این است که اولین شکل، شکلی با متن ریاضی است.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```