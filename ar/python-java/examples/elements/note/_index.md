---
title: ملاحظة
type: docs
weight: 240
url: /ar/python-java/examples/elements/note/
keywords:
- مثال على الكود
- ملاحظة
- ملاحظة المتحدث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "التعامل مع ملاحظات الشرائح في Aspose.Slides for Python via Java: إضافة، قراءة، حذف، وتحديث ملاحظات المتحدث في عروض PowerPoint وعروض OpenDocument."
---
توضح هذه المقالة كيفية إضافة، قراءة، حذف، وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). كل مثال يستورد `asposeslides` قبل بدء الـ JVM، ثم يستورد الـ API بعد تشغيل الـ JVM.

## **إضافة شريحة ملاحظات**

أنشئ شريحة ملاحظات وعيّن النص لها.

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

## **الوصول إلى شريحة ملاحظات**

اقرأ النص من شريحة ملاحظات موجودة.

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

## **إزالة شريحة ملاحظات**

قم بإزالة شريحة الملاحظات المرتبطة بشريحة.

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

## **تحديث نص الملاحظات**

غيّر نص شريحة الملاحظات.

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