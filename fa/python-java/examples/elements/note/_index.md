---
title: یادداشت
type: docs
weight: 240
url: /fa/python-java/examples/elements/note/
keywords:
- نمونه کد
- یادداشت
- یادداشت سخنران
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides برای Python از طریق Java: افزودن، خواندن، حذف و به روز رسانی یادداشت‌های سخنران در ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چگونه اسلایدهای یادداشت را اضافه، بخوانید، حذف کنید و به‌روز کنید با استفاده از **Aspose.Slides for Python via Java**.

پکيج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM `asposeslides` را وارد می‌کند، سپس پس از اجرا شدن JVM API را وارد می‌سازد.

## **افزودن اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **دسترسی به اسلاید یادداشت**

متن یک اسلاید یادداشت موجود را بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **حذف اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **به‌روزرسانی متن یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```