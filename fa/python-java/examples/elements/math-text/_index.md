---
title: متن ریاضی
type: docs
weight: 160
url: /fa/python-java/examples/elements/math-text/
keywords:
- مثال کد
- متن ریاضی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "مثال‌های متن ریاضی Aspose.Slides for Python via Java را بررسی کنید: ایجاد و قالب‌بندی معادلات، کسرها، ماتریس‌ها و نمادها در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه کار با اشکال متن ریاضی و فرمت‌بندی معادلات را با استفاده از **Aspose.Slides for Python via Java** نشان می‌دهد.

پکیج را همان‌طور که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را ایمپورت می‌کند، سپس پس از اجرای JVM API را ایمپورت می‌نماید.

## **افزودن متن ریاضی**

یک شکل ریاضی حاوی یک کسر و فرمول فیثاغورث ایجاد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ریاضی به اسلاید اضافه کنید.
    math_shape = slide.getShapes().addMathShape(0, 0, 720, 150)

    # به پاراگراف ریاضی دسترسی پیدا کنید.
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()

    # یک کسر ساده اضافه کنید: x / y.
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # یک معادله اضافه کنید: c² = a² + b².
    math_block = MathematicalText("c").setSuperscript("2").join("=").join(MathematicalText("a").setSuperscript("2")).join("+").join(MathematicalText("b").setSuperscript("2"))
    math_paragraph.add(math_block)
finally:
    presentation.dispose()
```

## **دسترسی به متن ریاضی**

یک شکل که شامل پاراگراف ریاضی در اسلاید است را پیدا کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathBlock, MathematicalText, MathPortion, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ریاضی که در زیر می‌توان یافت را اضافه کنید.
    created_math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    created_paragraph = created_math_shape.getTextFrame().getParagraphs().get_Item(0)
    created_portion = created_paragraph.getPortions().get_Item(0)
    created_math_paragraph = created_portion.getMathParagraph()
    created_fraction = MathematicalText("x").divide("y")
    created_math_paragraph.add(MathBlock(created_fraction))

    # اولین شکل حاوی یک پاراگراف ریاضی را پیدا کنید.
    math_shape = None
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                has_math = False
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        if isinstance(portion, MathPortion):
                            has_math = True
                            break
                    if has_math:
                        break
                if has_math:
                    math_shape = shape
                    break

    if math_shape is not None:
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        text_portion = paragraph.getPortions().get_Item(0)
        math_paragraph = text_portion.getMathParagraph()

        # مثال: یک کسر ایجاد کنید (در اینجا اضافه نشده است).
        fraction = MathematicalText("x").divide("y")

        # در صورت نیاز از math_paragraph یا fraction استفاده کنید.
finally:
    presentation.dispose()
```

## **حذف متن ریاضی**

یک شکل ریاضی را از اسلاید حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)

    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    # شکل ریاضی را حذف کنید.
    slide.getShapes().remove(math_shape)
finally:
    presentation.dispose()
```

## **فرمت‌بندی متن ریاضی**

ویژگی‌های قلم را برای یک بخش ریاضی تنظیم کنید.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(50, 50, 100, 50)
    paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    math_paragraph = text_portion.getMathParagraph()
    fraction = MathematicalText("x").divide("y")
    math_paragraph.add(MathBlock(fraction))

    text_portion.getPortionFormat().setFontHeight(20)
finally:
    presentation.dispose()
```