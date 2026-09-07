---
title: جعبه متن
type: docs
weight: 40
url: /fa/python-java/examples/elements/text-box/
keywords:
- نمونه کد
- جعبه متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کار با جعبه‌های متن در Aspose.Slides برای Python از طریق Java: افزودن، قالب‌بندی، یافتن و حذف متن در ارائه‌های PowerPoint و OpenDocument."
---
در **Aspose.Slides for Python via Java**، یک جعبه متن یک شکل خودکار است که متن را در خود نگه می‌دارد. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما توضیح می‌دهد که چگونه جعبه‌های متن را به‌صورت برنامه‌نویسی اضافه، دسترسی پیدا کنید و حذف کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و سپس پس از راه‌اندازی JVM، API را وارد می‌نماید.

## **افزودن یک جعبه متن**

یک مستطیل ایجاد کنید، پر و حاشیه آن را حذف کنید و متن قالب‌بندی‌شده‌ای را اختصاص دهید.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک شکل مستطیلی ایجاد کنید.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # پر و حاشیه را حذف کنید تا فقط متن نمایش داده شود.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # قالب‌بندی پیش‌فرض متن را تنظیم کنید.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **دسترسی به جعبه‌های متن بر اساس محتوا**

یک جعبه متن نمونه اضافه کنید، سپس شکل‌هایی را پیدا کنید که متن آن‌ها شامل کلیدواژه «Slide» باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # از جعبه متن مطابق استفاده کنید.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **حذف جعبه‌های متن بر اساس محتوا**

جعبه‌های متنی را که در اولین اسلاید وجود دارند و شامل یک کلیدواژه خاص هستند پیدا کرده و حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
قبل از حذف شکل‌ها، آن‌هایی که مطابقت دارند را در یک لیست جداگانه جمع‌آوری کنید تا از تغییر مجموعه شکل‌ها در حین تکرار جلوگیری شود.
{{% /alert %}}