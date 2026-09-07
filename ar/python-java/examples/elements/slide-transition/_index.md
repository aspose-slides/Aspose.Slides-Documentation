---
title: انتقل الشريحة
type: docs
weight: 110
url: /ar/python-java/examples/elements/slide-transition/
keywords:
- مثال على الكود
- انتقال الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تطبيق وإزالة انتقالات الشرائح وتحديد توقيتات التقدم التلقائي للشرائح باستخدام Aspose.Slides for Python عبر Java مع أمثلة شفرة للعرض التقديمي بصيغ PPT، PPTX، و ODP."
---
هذه المقالة توضح تطبيق تأثيرات الانتقال للشرائح وتوقيتاتها باستخدام **Aspose.Slides for Python via Java**.

قم بتثبيت الحزمة كما هو موضح في [Installation](/slides/ar/python-java/installation/). يستورد كل مثال `asposeslides` قبل تشغيل JVM، ثم يستورد الـ API بعد تشغيل JVM.

## **إضافة انتقال شريحة**

طبق تأثير انتقال تلاشي على الشريحة الأولى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # تطبيق انتقال تلاشي.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **الوصول إلى انتقال شريحة**

اقرأ نوع الانتقال المعيّن حاليًا لشريحة.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # الوصول إلى نوع الانتقال.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **إزالة انتقال شريحة**

امسح أي تأثير انتقال. تُظهر JPype الثابت Java المسمى `None` كـ `None_` لأن `None` كلمة محجوزة في Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # إزالة تأثير الانتقال.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **تحديد مدة الانتقال**

حدد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا. يتقدم هذا المثال بعد ثانيتين ويتيح أيضًا التقدم بنقرة الفأرة. يتحكم هذا التوقيت في انتقال الشريحة، وليس في سرعة تأثير الانتقال.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # بالمللي ثانية.
finally:
    presentation.dispose()
```